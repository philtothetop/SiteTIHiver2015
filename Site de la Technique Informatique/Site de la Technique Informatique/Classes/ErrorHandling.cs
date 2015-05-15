// Cette classe permet de réutiliser les méthodes par l'héritage.
// Écrit par Karl Gosselin, Février 2015
// Intrants: Vide
// Extrants: Vide


using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Site_de_la_Technique_Informatique
{
    public class ErrorHandling : System.Web.UI.Page
    {
        protected bool isLocal()
        {
            return HttpContext.Current.Request.IsLocal;
        }

        static Random rng = new Random();

        #region Error Handling
        public void Page_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            Server.Transfer("~/ErreursImportants.aspx?handler=" + ex.TargetSite.Name, true);

            LogErreurCritique(ex);

            Server.ClearError();
        }

        public  void LogErreur(String source, Exception ex)
        {
            using (LeModelTIContainer leContext = new LeModelTIContainer())
            {
                try
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
                catch
                {
                    //On le laisse failer silencieusement...
                }
            }
        }

        //Pour logger les erreurs dans la bd
        public void LogErreurCritique(Exception ex)
        {
            using (LeModelTIContainer leContext = new LeModelTIContainer())
            {

                try { 
                    string leMessage = ex.TargetSite.Name + "/" + ex.Message + "/" + ex.InnerException;
               
                    Model.Log uneNouvelleErreur = new Model.Log();
                    uneNouvelleErreur.dateLog = DateTime.Now;
                    uneNouvelleErreur.actionLog = leMessage;
                    uneNouvelleErreur.typeLog = 1;

                    if (Request.Cookies["TICourriel"] != null && !Request.Cookies["TICourriel"].Equals(""))
                    {
                        String courrielDuConnecte = Convert.ToString(Request.Cookies["TICourriel"]);
                        Model.Utilisateur lUtilisateurConnecte = (from cl in leContext.UtilisateurSet
                                                                  where cl.courriel.Equals(courrielDuConnecte)
                                                                  select cl).FirstOrDefault();
                        int noCompte = lUtilisateurConnecte.IDUtilisateur;
                        uneNouvelleErreur.UtilisateurIDUtilisateur = noCompte;
                    }

                    leContext.LogSet.Add(uneNouvelleErreur);
                    leContext.SaveChanges();
                }
                catch
                {
                    //On le laisse failer silencieusement...
                }
            }
        }
        #endregion

        //Méthode maison pour randomize les items dans une liste
        public void Randomize(IList list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                if (swapIndex != i)
                {
                    object tmp = list[swapIndex];
                    list[swapIndex] = list[i];
                    list[i] = tmp;
                }
            }
        }

        //Méthode pour savoir si la personne a les autorisations pour voir la page
        //Devrais être utiliser QUE SUR LES PAGES qui on besoin de quelqu'un de connecté
        public void SavoirSiPossedeAutorizationPourLaPage(bool admin, bool professeur, bool etudiant, bool employeur, bool visiteur)
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
                        if (!Server.HtmlEncode(Request.Cookies["TIUtilisateur"].Value).Equals(""))
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
                            else if (valeurDuCookie.Equals("Etudiant") && etudiant == true)
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
                        else if (visiteur == true)
                        {
                            doitRedirigerLaPersonne = false;
                        }
                        else
                        {
                            doitRedirigerLaPersonne = true;
                        }
                    }
                    else if (visiteur == true)
                    {
                        doitRedirigerLaPersonne = false;
                    }
                    //Si cookie vide, dire de rediriger la page
                    else
                    {
                        doitRedirigerLaPersonne = true;
                    }
                }
                else if (visiteur == true)
                {
                    doitRedirigerLaPersonne = false;
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