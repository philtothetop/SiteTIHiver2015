﻿// Cette classe permet à un administrateur ET aux professeurs de pouvoir accepter/refuser les offres d'emplois en plus de les supprimers
// Écrit par Raphael Brouard, Février 2015
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
using System.IO;

namespace Site_de_la_Technique_Informatique
{
    public partial class ValiderLesOffresEmploi : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, false, false, false);
        }

        //Méthode pour downloader le PDF de l'offre d'emploi
        protected void lnkPDF_Click(object sender, EventArgs e)
        {
            try
            {
                String argument = Convert.ToString(((LinkButton)sender).CommandArgument);
                string FilePath = Server.MapPath("~//Upload//PDFOffreEmploi//" + argument);

                //Check si le PDF exist bien sur avant de l'ouvrir
                if (File.Exists(FilePath))
                {
                    WebClient User = new WebClient();
                    Byte[] FileBuffer = User.DownloadData(FilePath);
                    if (FileBuffer != null)
                    {
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                }
            }
            catch
            { 
                //Si problem
            }
        }

         //Méthode pour accepter l'offre d'emploi
        protected void AccepterOffreEmploi_Click(object sender, EventArgs e)
        {
            int argument = Convert.ToInt32(((Button)sender).CommandArgument);

            using (LeModelTIContainer leModel = new LeModelTIContainer())
            {
                Model.OffreEmploi lOffreAAccepter = (from cl in leModel.OffreEmploiSet
                                                     where cl.IDOffreEmploi == argument
                                                     select cl).FirstOrDefault();

                //Si l'offre est trouvé
                if (lOffreAAccepter != null)
                {
                    lOffreAAccepter.validerOffre = true;
                    leModel.SaveChanges();
                    lviewOffresDEmploi.DataBind();
                }
                
            }
        }

        //Méthode pour refuser l'offre d'emploi
        protected void SupprimerOffreEmploi_Click(object sender, EventArgs e)
        {
            int argument = Convert.ToInt32(((Button)sender).CommandArgument);

            using (LeModelTIContainer leModel = new LeModelTIContainer())
            {
                Model.OffreEmploi lOffreARefuser = (from cl in leModel.OffreEmploiSet
                                                    where cl.IDOffreEmploi == argument
                                                    select cl).FirstOrDefault();

                //Si l'offre est trouvé
                if (lOffreARefuser != null)
                {
                    leModel.OffreEmploiSet.Remove(lOffreARefuser);
                    leModel.SaveChanges();
                    lviewOffresDEmploi.DataBind();
                }

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

                    //Si on a changé la valeur du hidden field
                    if (hfieldVoirOffreValideOuNon.Value != null)
                    {
                        if (!hfieldVoirOffreValideOuNon.Value.Equals(""))
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
                LogErreur("ValiderLesOffresEmplois dans la méthode GetLesOffresEmploi", ex);
            }

            //Datapager visible ou non
            if (listeDesOffresEmploi.Count > dataPagerDesLogs.PageSize)
            {
                dataPagerDesLogs.Visible = true;
            }
            else
            {
                dataPagerDesLogs.Visible = false;
            }

            return listeDesOffresEmploi.AsQueryable();
        }

        //Pas afficher les champs vides
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

        public bool VisibiliteBoutonValidation(bool voirLesNonValide)
        {
            string VoirOffreValideOuNon = "VoirNonValidé";

            //Si on a changé la valeur du hidden field
            if (hfieldVoirOffreValideOuNon.Value != null)
            {
                if(!hfieldVoirOffreValideOuNon.Value.Equals(""))
                {
                    VoirOffreValideOuNon = Convert.ToString(hfieldVoirOffreValideOuNon.Value);
                }
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

        //Savoir si montrer le bouton pour voir le pdf
        protected bool VisiblePDF(string pathPDF)
        {
            if (pathPDF != null)
            {
                if (!pathPDF.Equals(""))
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
    }
}