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

            LogErreurCritique(ex);

            Server.Transfer("~/ErreursImportants.aspx?handler=" + ex.TargetSite.Name, true);

            Server.ClearError();
        }


        public  void LogErreur(String source, Exception ex)
        {
            using (LeModelTIContainer leContext = new LeModelTIContainer())
            {
                string leMessage = source + "/" + ex.Message + "/" + ex.InnerException;

                Model.Log uneNouvelleErreur = new Model.Log();
                uneNouvelleErreur.dateLog = DateTime.Now;
                uneNouvelleErreur.actionLog = leMessage;
                uneNouvelleErreur.typeLog = 2;

                if (Session["Courriel"] != null && !Session["Courriel"].Equals(""))
                {
                    String courrielDuConnecte = Convert.ToString(Session["Courriel"]);
                    Model.Utilisateur lUtilisateurConnecte = (from cl in leContext.UtilisateurSet
                                                              where cl.courriel.Equals(courrielDuConnecte)
                                                              select cl).FirstOrDefault();
                    int noCompte = lUtilisateurConnecte.IDUtilisateur;
                    uneNouvelleErreur.UtilisateurIDUtilisateur = noCompte;
                }  

                leContext.LogSet.Add(uneNouvelleErreur);
                leContext.SaveChanges();
            }
        }

        public void LogErreurCritique(Exception ex)
        {
            using (LeModelTIContainer leContext = new LeModelTIContainer())
            {
                string leMessage = ex.TargetSite.Name + "/" + ex.Message + "/" + ex.InnerException;
               
                Model.Log uneNouvelleErreur = new Model.Log();
                uneNouvelleErreur.dateLog = DateTime.Now;
                uneNouvelleErreur.actionLog = leMessage;
                uneNouvelleErreur.typeLog = 1;

                if (Session["Courriel"] != null && !Session["Courriel"].Equals(""))
                {
                    String courrielDuConnecte = Convert.ToString(Session["Courriel"]);
                    Model.Utilisateur lUtilisateurConnecte = (from cl in leContext.UtilisateurSet
                                                              where cl.courriel.Equals(courrielDuConnecte)
                                                              select cl).FirstOrDefault();
                    int noCompte = lUtilisateurConnecte.IDUtilisateur;
                    uneNouvelleErreur.UtilisateurIDUtilisateur = noCompte;
                }

                leContext.LogSet.Add(uneNouvelleErreur);
                leContext.SaveChanges();
            }
        }

        //Modifier pour fonctionner avec des cookies le 2015-03-20 par Raphael Brouard
        //Méthode pour savoir si la personne a les autorisations pour voir la page
        //Devrais être utiliser QUE SUR LES PAGES qui on besoin de quelqu'un de connecté
        public void SavoirSiPossedeAutorizationPourLaPage(bool admin, bool professeur, bool etudiant, bool employeur)
        {
            try
            {
                //Un boolean pour savoir quoi faire a la fin de la méthode.
                bool doitRedirigerLaPersonne = true;

                //Vérifier si le cookie pour savoir le type d'utilisateur n'est pas vide
                if (Request.Cookies["TIUtilisateur"] != null)
                {
                    //Vérifier si la valeur du cookie n'est pas vide
                    if (Server.HtmlEncode(Request.Cookies["TIUtilisateur"].Value) != null)
                    {
                        string valeurDuCookie = Server.HtmlEncode(Request.Cookies["TIUtilisateur"].Value).ToString();

                        //Vérifier chaque type a les autorisations ET que lutilisateur connecter est de ce type
                        if (valeurDuCookie.Equals("Admin") && admin == true)
                        {
                            doitRedirigerLaPersonne = false;
                        }
                        else if (valeurDuCookie.Equals("Professeur") && professeur == true)
                        {
                            doitRedirigerLaPersonne = false;
                        }
                        else if (valeurDuCookie.Equals("Étudiant") && etudiant == true)
                        {
                            doitRedirigerLaPersonne = false;
                        }
                        else if (valeurDuCookie.Equals("Employeur") && employeur == true)
                        {
                            doitRedirigerLaPersonne = false;
                        }
                        //Si la valeur du cookie est autre chose innatendu
                        else
                        {
                            doitRedirigerLaPersonne = true;
                        }
                    }
                    //Si cookie vide, dire de rediriger la page
                    else
                    {
                         doitRedirigerLaPersonne = true;
                    }
                }

                //MÊME FONCTION SI ON DÉCIDE DE RETOURNER UTILISER UN OBJECT SESSION, ES EN COMMENTAIRE POUR LE MOMENT
                /*
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
                */


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