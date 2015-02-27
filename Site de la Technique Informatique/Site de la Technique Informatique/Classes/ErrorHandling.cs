using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Site_de_la_Technique_Informatique
{
    public class ErrorHandling : System.Web.UI.Page
    {
        public void Page_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            //Server.Transfer("~/ErreursImportants.aspx?handler=" + ex.TargetSite.Name, true);

            LogErreur(ex.Message + "/" + ex.InnerException);

            //Server.ClearError();
        }

        public static void LogErreur(string leMessage)
        {
            using (LeModelTIContainer leContext = new LeModelTIContainer())
            {
                Model.Log uneNouvelleErreur = new Model.Log();
                uneNouvelleErreur.dateLog = DateTime.Now;
                uneNouvelleErreur.actionLog = leMessage;
                uneNouvelleErreur.typeLog = 1;

                leContext.LogSet.Add(uneNouvelleErreur);
                leContext.SaveChanges();
            }
        }


        //Méthode pour savoir si la personne a les autorisations pour voir la page
        //Devrais être utiliser QUE SUR LES PAGES qui on besoin de quelqu'un de connecté
        public void SavoirSiPossedeAutorizationPourLaPage(bool admin, bool professeur, bool etudiant, bool employeur)
        {

            try
            {
                //Un boolean poru savori quoi faire a la fin de la méthode.
                bool doitRedirigerLaPersonne = true;

                //Vérifier si la session n'est pas vide
                if (Session["Courriel"] != null && !Session["Courriel"].Equals(""))
                {
                    String courrielDuConnecte = Convert.ToString(Session["Courriel"]);

                    //Trouver la personne connecté dans la bd
                    using (LeModelTIContainer leModelTI = new LeModelTIContainer())
                    {
                        Model.Utilisateur lUtilisateurConnecte = (from cl in leModelTI.UtilisateurSet
                                                                  where cl.courriel.Equals(courrielDuConnecte)
                                                                  select cl).FirstOrDefault();

                        //Si un utilisateur est trouvé
                        if (lUtilisateurConnecte != null)
                        {
                            //Vérifier chaque type a les autorisations ET que lutilisateur connecter est de ce type
                            if (lUtilisateurConnecte is Admin && admin == true)
                            {
                                doitRedirigerLaPersonne = false;
                            }
                            else if (lUtilisateurConnecte is Professeur && professeur == true)
                            {
                                doitRedirigerLaPersonne = false;
                            }
                            else if (lUtilisateurConnecte is Etudiant && etudiant == true)
                            {
                                doitRedirigerLaPersonne = false;
                            }
                            else if (lUtilisateurConnecte is Employeur && employeur == true)
                            {
                                doitRedirigerLaPersonne = false;
                            }
                            //Pas les autorisations
                            else
                            {
                                doitRedirigerLaPersonne = true;
                            }
                        }
                        else
                        {
                            //Aussi écrire un Log peut-etre?
                            doitRedirigerLaPersonne = true;
                        }
                    }
                }
                //Pas connecté, alors n'a pas les droits
                else
                {
                    doitRedirigerLaPersonne = true;
                }

                //Rediriger si pas les droits
                if (doitRedirigerLaPersonne == true)
                {
                    Response.Redirect("Default.aspx");
                }
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
        }
        
    }
}