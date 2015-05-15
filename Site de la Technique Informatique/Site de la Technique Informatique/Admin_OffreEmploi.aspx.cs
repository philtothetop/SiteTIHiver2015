// Cette classe permet à un administrateur ET aux professeurs de pouvoir accepter/refuser les offres d'emplois en plus de les supprimers
// Écrit par Raphael Brouard, Février-Mars 2015
// Intrants: Vide
// Extrants: L'offre choisi a été VALIDÉ ou SUPPRIMÉ dans la BD.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.Net;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_OffreEmploi : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SavoirSiPossedeAutorizationPourLaPage(true, true, false, false, false);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                //Besoin de cela pour la premiere fois que on load la page, mettre le datapager visible ou non si plusieurs offres emploi
                dataPagerDesOffresEmplois.Visible = (dataPagerDesOffresEmplois.PageSize < dataPagerDesOffresEmplois.TotalRowCount);
            }
        }

        //Méthode pour downloader le PDF de l'offre d'emploi
        protected void lnkPDF_Click(object sender, EventArgs e)
        {
            String argument = Convert.ToString(((Button)sender).CommandArgument);
            string FilePath = Server.MapPath(argument);

            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        //Méthode pour accepter l'offre d'emploi
        protected void AccepterOffreEmploi_Click(object sender, EventArgs e)
        {
            int argument = Convert.ToInt32(((Button)sender).CommandArgument);

            try
            {
                using (LeModelTIContainer leModel = new LeModelTIContainer())
                {
                    Model.OffreEmploi lOffreAAccepter = (from cl in leModel.OffreEmploiSet
                                                         where cl.IDOffreEmploi == argument
                                                         select cl).FirstOrDefault();

                    //Si l'offre est trouvé
                    if (lOffreAAccepter != null)
                    {
                        lOffreAAccepter.validerOffre = true;

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
                            loggerUnLog.actionLog = "L'offre d'emploi : " + lOffreAAccepter.titreOffre + " : a été ACCEPTÉ.";
                            loggerUnLog.dateLog = DateTime.Now;
                            loggerUnLog.typeLog = 0;
                            loggerUnLog.Utilisateur = lutilisateurCo;
                            loggerUnLog.UtilisateurIDUtilisateur = lutilisateurCo.IDUtilisateur;

                            leModel.LogSet.Add(loggerUnLog);
                            leModel.SaveChanges();
                            lviewOffresDEmploi.DataBind();
                        }
                        //Si pu connecté, rediriger a la page d'accueil
                        else
                        {
                            Response.Redirect("Default.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Admin_OffreEmploi.aspx.cs dans la méthode AccepterOffreEmploi_Click", ex);
            }
        }

        //Méthode pour refuser l'offre d'emploi
        protected void SupprimerOffreEmploi_Click(object sender, EventArgs e)
        {
            int argument = Convert.ToInt32(((Button)sender).CommandArgument);

            try
            {
                using (LeModelTIContainer leModel = new LeModelTIContainer())
                {
                    Model.OffreEmploi lOffreARefuser = (from cl in leModel.OffreEmploiSet
                                                        where cl.IDOffreEmploi == argument
                                                        select cl).FirstOrDefault();

                    //Si l'offre est trouvé
                    if (lOffreARefuser != null)
                    {
                        leModel.OffreEmploiSet.Remove(lOffreARefuser);

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
                            loggerUnLog.actionLog = "L'offre d'emploi : " + lOffreARefuser.titreOffre + " : a été REFUSÉ/SUPPRIMÉ.";
                            loggerUnLog.dateLog = DateTime.Now;
                            loggerUnLog.typeLog = 0;
                            loggerUnLog.Utilisateur = lutilisateurCo;
                            loggerUnLog.UtilisateurIDUtilisateur = lutilisateurCo.IDUtilisateur;
                        }
                        else
                        {
                            loggerUnLog.actionLog = "L'offre d'emploi : " + lOffreARefuser.titreOffre + " : a été REFUSÉ/SUPPRIMÉ.";
                            loggerUnLog.dateLog = DateTime.Now;
                            loggerUnLog.typeLog = 0;
                        }

                        leModel.LogSet.Add(loggerUnLog);
                        leModel.SaveChanges();
                        lviewOffresDEmploi.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Admin_OffreEmploi.aspx.cs dans la méthode SupprimerOffreEmploi_Click", ex);
            }
        }

        //Boutton pour voit les offres non validés
        protected void VoirOffreNonValide_Click(object sender, EventArgs e)
        {
            hfieldVoirOffreValideOuNon.Value = "VoirNonValidé";
            btnVoirOffreEmploiNonValide.CssClass = "btn btnOffreEmploiSelectionne";
            btnVoirOffreEmploiValide.CssClass = "btn btn-default";
            lviewOffresDEmploi.DataBind();

        }

        //Boutton pour voit les offres validés
        protected void VoirOffreValide_Click(object sender, EventArgs e)
        {
            hfieldVoirOffreValideOuNon.Value = "VoirValidé";
            btnVoirOffreEmploiNonValide.CssClass = "btn btn-default";
            btnVoirOffreEmploiValide.CssClass = "btn btnOffreEmploiSelectionne";
            lviewOffresDEmploi.DataBind();
        }

        protected void lviewOffresDEmploiDataBound(object sender, EventArgs e)
        {
            dataPagerDesOffresEmplois.Visible = (dataPagerDesOffresEmplois.PageSize < dataPagerDesOffresEmplois.TotalRowCount);
        }

        //Méthode pour récupérer les offres d'emploi de la BD
        public IQueryable<Model.OffreEmploi> GetLesOffresDEmploi()
        {
            //Créer une liste de base
            List<Model.OffreEmploi> listeDesOffresEmploi = new List<Model.OffreEmploi>();

            try
            {
                using (LeModelTIContainer modelTI = new LeModelTIContainer())
                {

                    string VoirOffreValideOuNon = "VoirNonValidé";

                    //Vérifier si la valeur n'est pas null
                    if (hfieldVoirOffreValideOuNon.Value != null)
                    {
                        //Si valeur du hiddenfield n'est pas vide
                        if(!hfieldVoirOffreValideOuNon.Value.Equals(""))
                        {
                            VoirOffreValideOuNon = Convert.ToString(hfieldVoirOffreValideOuNon.Value);
                        }
                    }

                    if (VoirOffreValideOuNon.Equals("VoirNonValidé"))
                    {
                        //Récupérer les offres d'emploi dans la BD qui ne sont pas validé
                        listeDesOffresEmploi = (from cl in modelTI.OffreEmploiSet
                                                where cl.validerOffre == false
                                                select cl).ToList();
                    }
                    else if (VoirOffreValideOuNon.Equals("VoirValidé"))
                    {
                        //Récupérer les offres d'emploi dans la BD qui ne sont pas validé
                        listeDesOffresEmploi = (from cl in modelTI.OffreEmploiSet
                                                where cl.validerOffre == true
                                                select cl).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Admin_OffreEmploi.aspx.cs dans la méthode GetLesOffresDEmploi", ex);
            }

            return listeDesOffresEmploi.AsQueryable();
        }

        //Pour ne pas afficher les champs vides
        public bool PasAfficherSiNull(Model.OffreEmploi trouverOffre, string valeurAChecker)
        {
            if (trouverOffre != null)
            {
                if (valeurAChecker.Equals("dateExpiration"))
                {
                    if (trouverOffre.dateExpiration != null)
                    {
                        return true;
                    }
                }
                else if (valeurAChecker.Equals("noPoste"))
                {
                    if (trouverOffre.noPoste != null)
                    {
                        if (!trouverOffre.noPoste.Equals(""))
                        {
                            return true;
                        }
                    }
                }
                else if (valeurAChecker.Equals("noTelecopieur"))
                {
                    if (trouverOffre.noTelecopieur != null)
                    {
                        if (!trouverOffre.noTelecopieur.Equals(""))
                        {
                            return true;
                        }
                    }
                }
                else if (valeurAChecker.Equals("pathPDFDescription"))
                {
                    if (trouverOffre.pathPDFDescription != null)
                    {
                        if (!trouverOffre.pathPDFDescription.Equals(""))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        //Permet de savoir si on veut afficher les offres validé ou non
        public bool VisibiliteBoutonValidation(bool voirLesNonValide)
        {
            string VoirOffreValideOuNon = "VoirNonValidé";

            //Si on a changé la valeur du hidden field
            if (hfieldVoirOffreValideOuNon.Value != null)
            {
                VoirOffreValideOuNon = Convert.ToString(hfieldVoirOffreValideOuNon.Value);
            }

            if (VoirOffreValideOuNon.Equals("VoirNonValidé") && voirLesNonValide == true)
            {
                return true;
            }
            else if (VoirOffreValideOuNon.Equals("VoirValidé") && voirLesNonValide == false)
            {
                return true;
            }

            return false;
        }
    }
}