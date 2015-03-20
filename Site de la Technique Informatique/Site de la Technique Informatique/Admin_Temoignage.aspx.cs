// Cette classe permet à un administrateur ET aux professeurs de pouvoir accepter/refuser/supprimer/consulter les témoignages des étudiants et professeurs
// Écrit par Raphael Brouard, Mars 2015
// Intrants: Vide
// Extrants: Le témoignage choisi a été VALIDÉ ou SUPPRIMÉ dans la BD.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_Temoignage : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(true, true, false, false);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //Besoin de cela pour la premiere fois que on load la page, mettre le datapager visible ou non si plusieurs offres emploi
            dataPagerDesTemoignages.Visible = (dataPagerDesTemoignages.PageSize < dataPagerDesTemoignages.TotalRowCount);
        }

        //Méthode pour récupérer les témoignages de la BD
        public IQueryable<Model.Membre> GetLesTemoignages()
        {
            //Créer une liste de base
            List<Model.Membre> listeDesTemoignages = new List<Model.Membre>();

            try
            {
                using (LeModelTIContainer modelTI = new LeModelTIContainer())
                {
                    string sorteTemoignageAVoir = "NonValidé";

                    //Savoir quoi vouloir afficher avec le hiddenfield
                    if (hfieldVoirTemoignageValideOuNon != null)
                    {
                        if (hfieldVoirTemoignageValideOuNon.Value != null)
                        {
                            sorteTemoignageAVoir = hfieldVoirTemoignageValideOuNon.Value.ToString();
                        }
                    }

                    if (sorteTemoignageAVoir.Equals("NonValidé"))
                    {
                        //Afficher tout les témoignages non-validés
                        listeDesTemoignages = (from cl in modelTI.UtilisateurSet.OfType<Etudiant>()
                                               where cl.temoignage.Length > 1 && cl.valideTemoignage == false
                                               select cl as Membre).ToList();
                    }
                    else if (sorteTemoignageAVoir.Equals("Validé"))
                    {
                        //Afficher tout les témoignages validés
                        listeDesTemoignages = (from cl in modelTI.UtilisateurSet.OfType<Etudiant>()
                                               where cl.temoignage.Length > 1 && cl.valideTemoignage == true
                                               select cl as Membre).ToList();

                        List<Model.Membre> listeDesProfs = (from cl in modelTI.UtilisateurSet.OfType<Professeur>()
                                                            where cl.temoignage.Length > 1
                                                            select cl as Membre).ToList();

                        //Si liste témoignage prof pas vide
                        if (listeDesProfs != null)
                        {
                            foreach (Model.Membre membre in listeDesProfs)
                            {
                                listeDesTemoignages.Add(membre);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Admin_Temoignage.aspx.cs dans la méthode GetLesTemoignagesEtudiants", ex);
            }

            return listeDesTemoignages.AsQueryable();
        }

        //Pour accepter les témoignages
        protected void AccepterTemoignage_Click(object sender, EventArgs e)
        {
            //Le id etudiant
            int argument = Convert.ToInt32(((Button)sender).CommandArgument);

            try
            {
                using (LeModelTIContainer leModel = new LeModelTIContainer())
                {
                    Model.Etudiant leTemoignageAAccepter = (from cl in leModel.UtilisateurSet.OfType<Etudiant>()
                                                            where cl.IDMembre == argument
                                                            select cl).FirstOrDefault();

                    //Si la personne est trouvé
                    if (leTemoignageAAccepter != null)
                    {
                        leTemoignageAAccepter.valideTemoignage = true;

                        Model.Utilisateur lutilisateurCo = new Model.Utilisateur();
                        lutilisateurCo = null;

                        //Récupérer la personne connecté
                        if (Request.Cookies["TIID"] != null)
                        {
                            if (Server.HtmlEncode(Request.Cookies["TIID"].Value) != null)
                            {
                                int leId = Convert.ToInt32(Server.HtmlEncode(Request.Cookies["TIID"].Value));

                                lutilisateurCo = (from cl in leModel.UtilisateurSet
                                                  where cl.IDUtilisateur == leId
                                                  select cl).FirstOrDefault();
                            }
                        }

                        //Créer le log
                        Model.Log loggerUnLog = new Model.Log();

                        //Si lutilisateur connecté est trouvé
                        if (lutilisateurCo != null)
                        {
                            loggerUnLog.actionLog = "Le témoignage de " + leTemoignageAAccepter.prenom + " " + leTemoignageAAccepter.nom + " a été ACCEPTÉ.";
                            loggerUnLog.dateLog = DateTime.Now;
                            loggerUnLog.typeLog = 0;
                            loggerUnLog.Utilisateur = lutilisateurCo;
                            loggerUnLog.UtilisateurIDUtilisateur = lutilisateurCo.IDUtilisateur;
                        }
                        else
                        {
                            loggerUnLog.actionLog = "Le témoignage de " + leTemoignageAAccepter.prenom + " " + leTemoignageAAccepter.nom + " a été ACCEPTÉ.";
                            loggerUnLog.dateLog = DateTime.Now;
                            loggerUnLog.typeLog = 0;
                        }

                        leModel.LogSet.Add(loggerUnLog);
                        leModel.SaveChanges();
                        lviewTemoignage.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Admin_Temoignage.aspx.cs dans la méthode AccepterTemoignage_Click", ex);
            }
        }

        //Pour refuser les témoignages
        protected void SupprimerTemoignage_Click(object sender, EventArgs e)
        {
            //Le id utilisateur de l'étudiant
            int argument = Convert.ToInt32(((Button)sender).CommandArgument);

            try
            {
                using (LeModelTIContainer leModel = new LeModelTIContainer())
                {
                    Model.Membre leTemoignageAAccepter = (from cl in leModel.UtilisateurSet.OfType<Membre>()
                                                          where cl.IDMembre == argument
                                                          select cl).FirstOrDefault();

                    //Si la personne est trouvé
                    if (leTemoignageAAccepter != null)
                    {
                        //Si est un étudiant
                        if (leTemoignageAAccepter is Etudiant)
                        {
                            Model.Etudiant estUnEtudiant = leTemoignageAAccepter as Etudiant;
                            estUnEtudiant.valideTemoignage = false;
                            estUnEtudiant.temoignage = "";
                        }
                        //Si un professeur
                        else
                        {
                            leTemoignageAAccepter.temoignage = "";
                        }

                        Model.Utilisateur lutilisateurCo = new Model.Utilisateur();
                        lutilisateurCo = null;

                        //Récupérer la personne connecté
                        if (Request.Cookies["TIID"] != null)
                        {
                            if (Server.HtmlEncode(Request.Cookies["TIID"].Value) != null)
                            {
                                int leId = Convert.ToInt32(Server.HtmlEncode(Request.Cookies["TIID"].Value));

                                lutilisateurCo = (from cl in leModel.UtilisateurSet
                                                  where cl.IDUtilisateur == leId
                                                  select cl).FirstOrDefault();
                            }
                        }

                        //Créer le log
                        Model.Log loggerUnLog = new Model.Log();

                        //Si lutilisateur connecté est trouvé
                        if (lutilisateurCo != null)
                        {
                            loggerUnLog.actionLog = "Le témoignage de " + leTemoignageAAccepter.prenom + " " + leTemoignageAAccepter.nom + " a été REFUSÉ/SUPPRIMÉ.";
                            loggerUnLog.dateLog = DateTime.Now;
                            loggerUnLog.typeLog = 0;
                            loggerUnLog.Utilisateur = lutilisateurCo;
                            loggerUnLog.UtilisateurIDUtilisateur = lutilisateurCo.IDUtilisateur;
                        }
                        else
                        {
                            loggerUnLog.actionLog = "Le témoignage de " + leTemoignageAAccepter.prenom + " " + leTemoignageAAccepter.nom + " a été REFUSÉ/SUPPRIMÉ.";
                            loggerUnLog.dateLog = DateTime.Now;
                            loggerUnLog.typeLog = 0;
                        }

                        leModel.LogSet.Add(loggerUnLog);
                        leModel.SaveChanges();
                        lviewTemoignage.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Admin_Temoignage.aspx.cs dans la méthode SupprimerTemoignage_Click", ex);
            }
        }

        //Pour savoir si mettre visible ou pas le bouton pour accepter les témoignages si c'est un prof/étudiants
        //Car prof na pas besoin d'être validé
        //A PAS ÉTÉ VÉRIFIER SI SA MARCHE, DOIT ATTENDRE POUR DES TEMOIGNAGES AVANTS, + PROB VALIDATION BD
        public bool savoirSiEstUnEtudiant(Membre leMembre)
        {
            if (leMembre is Etudiant)
            {
                Model.Etudiant lEtudiant = leMembre as Etudiant;
                if (lEtudiant.valideTemoignage == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Boutton pour voit les témoignages non validés
        protected void VoirTemoignageNonValide_Click(object sender, EventArgs e)
        {
            hfieldVoirTemoignageValideOuNon.Value = "NonValidé";
            btnVoirTemoignageNonValide.CssClass = "btn btnTemoignageSelectionne";
            btnVoirTemoignageValide.CssClass = "btn btn-default";
            lviewTemoignage.DataBind();
        }

        //Boutton pour voit les témoignages validés
        protected void VoirTemoignageValide_Click(object sender, EventArgs e)
        {
            hfieldVoirTemoignageValideOuNon.Value = "Validé";
            btnVoirTemoignageNonValide.CssClass = "btn btn-default";
            btnVoirTemoignageValide.CssClass = "btn btnTemoignageSelectionne";
            lviewTemoignage.DataBind();
        }
    }
}