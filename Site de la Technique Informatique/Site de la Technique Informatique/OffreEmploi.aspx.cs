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
    public partial class OffreEmploi : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, true, true, false);

            Model.OffreEmploi offreEmploi;
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                int idOffre = Int32.Parse(Session["IDOffreEmploi"].ToString());

                offreEmploi = (from offresEmploi in lecontexte.OffreEmploiSet
                               where offresEmploi.IDOffreEmploi == idOffre
                               select offresEmploi).FirstOrDefault();

                lblTitreOffre.Text = offreEmploi.titreOffre;
                lblAdresseVille.Text = offreEmploi.adresseTravail + ", " + offreEmploi.Ville.nomVille;
                lblNbHeureSemaine.Text = offreEmploi.nbHeureSemaine + " heures par semaine";
                lblDescriptionOffre.Text = offreEmploi.descriptionOffre;

                if (offreEmploi.dateExpiration == null)
                {
                    lblDateExpiration.Text = "Expiration de l'offre: Non définie";
                }
                else
                {
                    lblDateExpiration.Text = "Expiration de l'offre: " + offreEmploi.dateExpiration.ToString();
                }

                lblDateDebutOffre.Text = "Début de l'offre: " + offreEmploi.dateDebutOffre.ToString("dd/MM/yyyy");
                lblSalaire.Text = offreEmploi.salaire + " $/heure";
                lblNoTelephone.Text = "No de téléphone: " + offreEmploi.noTelephone;

                if (offreEmploi.noPoste != null)
                {
                    lblNoPoste.Text = "  Ext: (" + offreEmploi.noPoste + ")";
                }

                lblNoTelecopieur.Text = "No de télécopieur: " + offreEmploi.noTelecopieur;
                lblCourrielOffre.Text = "Courriel: " + offreEmploi.courrielOffre;
                lblPersonneRessource.Text = "Personne ressource: " + offreEmploi.personneRessource;

                if (offreEmploi.pathPDFDescription == "" || offreEmploi.pathPDFDescription == null)
                {
                    lnkPDF.Visible = false;
                }
                else
                {
                    lnkPDF.Visible = true;
                    ViewState["pathPDF"] = "Upload\\PDFOffreEmploi\\" + offreEmploi.pathPDFDescription;
                }

                if (offreEmploi.noPoste == "" || offreEmploi.noPoste == null)
                {
                    lblNoPoste.Visible = false;
                }

                if (Request.Cookies["TIID"] != null)
                {
                    int idUtilisateur = Int32.Parse(Server.HtmlEncode(Request.Cookies["TIID"].Value));
                    if (offreEmploi.EmployeurIDUtilisateur == idUtilisateur)
                    {
                        lnkSupprimer.Visible = true;
                        lnkModifier.Visible = true;
                    }
                }

            }
        }

        protected void lnkPDF_Click(object sender, EventArgs e)
        {
            string FilePath = Server.MapPath(ViewState["pathPDF"].ToString());
            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }

        protected void lnkSupprimer_Click(object sender, EventArgs e)
        {
            Model.OffreEmploi offreEmploi;
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                int idOffre = Int32.Parse(Session["IDOffreEmploi"].ToString());

                offreEmploi = (from offresEmploi in lecontexte.OffreEmploiSet
                               where offresEmploi.IDOffreEmploi == idOffre
                               select offresEmploi).FirstOrDefault();

                if (offreEmploi.pathPDFDescription != "" || offreEmploi.pathPDFDescription != null)
                {
                    string Path = Server.MapPath("Upload\\PDFOffreEmploi\\" + offreEmploi.pathPDFDescription);

                    if (System.IO.File.Exists(Path))
                    {

                        System.IO.File.Delete(Path);

                    }
                }

                lecontexte.OffreEmploiSet.Remove(offreEmploi);
                lecontexte.SaveChanges();
                Response.Redirect("~/listeOffresEmploi.aspx", false);

            }
        }

        protected void lnkModifier_Click(object sender, EventArgs e)
        {
            Session["IDOffreEmploiModifier"] = Int32.Parse(Session["IDOffreEmploi"].ToString());
            Session["IDOffreEmploi"] = null;
            Response.Redirect("~/ajoutOffreEmploi.aspx", false);
        }
    }
}