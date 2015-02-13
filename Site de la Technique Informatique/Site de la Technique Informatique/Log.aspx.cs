using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class Log : System.Web.UI.Page
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


                    //POUR TEST
                    LogJeu logErreur = new LogJeu();
                    logErreur.actionLog = "LOG DE TEST WOOT";
                    logErreur.dateLog = DateTime.Now;
                    logErreur.IDLog = 1;

                    for (int i = 0; 1 < 24; i++)
                    {
                        //logErreur.dateLog = logErreur.dateLog + new DateTime(0, 0, 1);
                        listeDesLogs.Add(logErreur);
                    }
                }
            }
            catch (Exception ex)
            {
                //Si Erreur, retourner une liste avec un log qui indique erreur
                //ERREURS PARTOUT OH GOD HELP ME plz
                LogJeu logErreur = new LogJeu();
                logErreur.actionLog = "Erreur l'Hors du chargement des logs";
                logErreur.dateLog = DateTime.Now;
                logErreur.IDLog = 1;

                listeDesLogs.Add(logErreur);

                //A AJOUTER UN LOG DANS LA ROUTINE DERREUR?
            }

            return listeDesLogs.AsQueryable().SortBy("dateLog");
        }
    }
}