using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class listeOffresEmploi : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(true,true,true,true,false);

            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                if (Request.Cookies["TIID"] != null)
                {
                    int idUtilisateur = Int32.Parse(Server.HtmlEncode(Request.Cookies["TIID"].Value));
                    Employeur employeur = (from employeurs in lecontexte.UtilisateurSet.OfType<Employeur>()
                                           where employeurs.IDUtilisateur == idUtilisateur
                                           select employeurs).FirstOrDefault();
                    if (employeur != null)
                    {
                        lnkAjouterOffre.Visible = true;
                    }
                }
            }
        }

        public IQueryable<Model.OffreEmploi> getOffresEmploi()
        {

            List<Model.OffreEmploi> listeOffresEmploi = new List<Model.OffreEmploi>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                listeOffresEmploi = (from offresEmploi in lecontexte.OffreEmploiSet where offresEmploi.etatOffre == "1" && offresEmploi.validerOffre == true select offresEmploi).ToList();
            }
            return listeOffresEmploi.AsQueryable();
        }

        protected void lviewOffresEmploi_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                Label lblNbHeureSemaine = (Label)e.Item.FindControl("lblNbHeureSemaine");
                Label lblVille = (Label)e.Item.FindControl("lblVille");

                int nbHeulblNbHeureSemaine = int.Parse(lviewOffresEmploi.DataKeys[e.Item.DisplayIndex].Values[1].ToString());
                lblNbHeureSemaine.Text = nbHeulblNbHeureSemaine + " heures par semaine";

                int idVille = int.Parse(lviewOffresEmploi.DataKeys[e.Item.DisplayIndex].Values[0].ToString());
                Ville ville = (from villes in lecontexte.VilleSet where villes.IDVille == idVille select villes).FirstOrDefault();
                lblVille.Text = ville.nomVille;
            }
        }

        protected void lnkOffre_Click(object sender, EventArgs e)
        {
            LinkButton lnkOffre = (LinkButton)sender;
            Session["IDOffreEmploi"] = lnkOffre.CommandArgument;
            Response.Redirect("~/OffreEmploi.aspx", false);
        }
    }
}