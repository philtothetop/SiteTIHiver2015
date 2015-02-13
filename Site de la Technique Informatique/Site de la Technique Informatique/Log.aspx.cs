using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class Log : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            /*
            using (ModelTIContainer leModelTI = new ModelTIContainer())
            {

                LogJeu unLoggg = new LogJeu();
                unLoggg.actionLog = "Premier Log EVER";
                unLoggg.dateLog = DateTime.Now;
                unLoggg.UtilisateurIDUtilisateur = 1;

                leModelTI.LogJeu.Add(unLoggg);
                leModelTI.SaveChanges();
            }
             * */
        }

        //Méthode pour récupérer les logs de la BD
        public IQueryable<LogJeu> GetLesLogs()
        {
            //Créer une liste de base
            List<LogJeu> listeDesLogs = new List<LogJeu>();

            try
            {
                using (ModelTIContainer modelTI = new ModelTIContainer())
                {
                    //Récupérer les logs dans la BD
                    listeDesLogs = (from cl in modelTI.LogJeu
                                    select cl).ToList();


                    //POUR TEST UNIQUEMENT
                    for (int i = 0; i < 24; i++)
                    {
                        LogJeu logErreur = new LogJeu();
                        logErreur.actionLog = "LOG DE TEST WOOT" + i;
                        logErreur.dateLog = DateTime.Now + new TimeSpan(i, 0, 0, 0);
                        logErreur.IDLog = i;
                        listeDesLogs.Add(logErreur);
                }
            }
            }
            catch (Exception ex)
            {
                //Si Erreur, retourner une liste avec un log qui indique erreur
                //ERREURS PARTOUT OH GOD HELP ME
                //DÉSOLÉ :(
                LogJeu logErreur = new LogJeu();
                logErreur.actionLog = "Erreur l'Hors du chargement des logs";
                logErreur.dateLog = DateTime.Now;
                logErreur.IDLog = 1;

                listeDesLogs.Add(logErreur);

                //A AJOUTER UN LOG DANS LA ROUTINE DERREUR?
            }

            return listeDesLogs.AsQueryable().SortBy("dateLog");
        }

        
        //Pour savoir le ID de celui qui a créé le log
        public int GetIdOfAccount(int IdDuLog)
        {
            try
            {
                using (ModelTIContainer modelTI = new ModelTIContainer())
                {
                    LogJeu theLog = (from cl in modelTI.LogJeu
                                     where cl.IDLog == IdDuLog
                                     select cl).FirstOrDefault();

                    //Vérifier que le log a été trouvé
                    if (theLog != null)
                    {
                        //Checker si c'est un étudiant ou un prof
                        if (theLog.UtilisateurJeu != null)
                        {
                            return theLog.UtilisateurJeu.IDUtilisateur;
                        }
                        //Checker si c'est un employeur alors
                        else if (theLog.EmployeurJeuSet != null)
                        {
                            return theLog.EmployeurJeuSet.IDEmployeur;
                        }
                        //Checker si c'est un admin alors
                        else if (theLog.AdminJeu != null)
                        {
                            return theLog.AdminJeu.IDAdmin;
                        }
                        //Au sinon le log a mal été produit???
                        else
                        {
                            return 0;
                        }
    }
}
            }
            //Si ya probleme, retourner 0
            catch
            {
                return 0; 
            }

            //Devrais pas se rendre ici mais, au cas ou
            return 0; 
        }
        
        //Pour savoir le type de l'account de celui qui a créé le log
        public string GetTypeOfAccount(int IdDuLog)
        {
            try
            {
                using (ModelTIContainer modelTI = new ModelTIContainer())
                {
                    LogJeu theLog = (from cl in modelTI.LogJeu
                                     where cl.IDLog == IdDuLog
                                     select cl).FirstOrDefault();

                    //Vérifier que le log a été trouvé
                    if (theLog != null)
                    {
                        //Checker si c'est un étudiant ou un prof
                        if (theLog.UtilisateurJeu != null)
                        {
                            return "Utilisateur";    
                        }
                        //Checker si c'est un employeur alors
                        else if (theLog.EmployeurJeuSet != null)
                        {
                            return "Employeur";
                        }
                        //Checker si c'est un admin alors
                        else if (theLog.AdminJeu != null)
                        {
                            return "Administrateur";
                        }
                        //Au sinon le log a mal été produit???
                        else
                        {
                            return "Introuvable";
                        }
                    }
                }
            }
            //Si ya probleme, retourner 0
            catch
            {
                return "Introuvable";
            }

            //Devrais pas se rendre ici mais, au cas ou
            return "Introuvable";
        }
    }
}