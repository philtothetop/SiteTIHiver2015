//Type de log valeur
//0 = Normal
//1 = Erreur
//2 = Warning
//3 = Inscription
//4 = Banni



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
             */
        }
        
        //Méthode pour récupérer les logs de la BD
        public IQueryable<Model.Log> GetLesLogs()
        {
            //Créer une liste de base
            List<Model.Log> listeDesLogs = new List<Model.Log>();

            try
            {
                using (LeModelTIContainer modelTI = new LeModelTIContainer())
                {
                    //Récupérer les logs dans la BD
                    listeDesLogs = (from cl in modelTI.LogSet
                                    select cl).ToList();
                    

                    //POUR TEST UNIQUEMENT
                    for (int i = 0; i < 24; i++)
                    {
                        
                        Model.Log logErreur = new Model.Log();
                        logErreur.actionLog = "LOG DE TEST WOOT" + i;
                        logErreur.dateLog = DateTime.Now + new TimeSpan(i, 0, 0, 0);
                        logErreur.IDLog = i;
                        logErreur.typeLog = 0;
                        logErreur.UtilisateurIDUtilisateur = i;
                        listeDesLogs.Add(logErreur);
                    }
                }
            }
            catch (Exception ex)
            {
                //Si Erreur, retourner une liste avec un log qui indique erreur
                Model.Log logErreur = new Model.Log();
                logErreur.actionLog = "Erreur l'Hors du chargement des logs";
                logErreur.dateLog = DateTime.Now;
                logErreur.IDLog = 1;
                logErreur.typeLog = 1;
                logErreur.UtilisateurIDUtilisateur = 0;

                listeDesLogs.Add(logErreur);

                //A AJOUTER UN LOG DANS LA ROUTINE DERREUR?
            }

            return listeDesLogs.AsQueryable().SortBy("dateLog");
        }
    }
}