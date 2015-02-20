using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class OffreEmploi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Model.OffreEmploi getOffreEmploi()
        {
            Model.OffreEmploi offreEmploi;
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                offreEmploi = (from offresEmploi in lecontexte.OffreEmploiSet 
                               where offresEmploi.IDOffreEmploi == Int32.Parse(Session["IDOffreEmploi"].ToString()) 
                               select offresEmploi).FirstOrDefault();
            }

            return offreEmploi;
        }

        protected void lviewOffresEmploi_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                Label lblheulblNbHeureSemaine = (Label)e.Item.FindControl("lblheulblNbHeureSemaine");
                Label lblVille = (Label)e.Item.FindControl("lblVille");

                int nbHeulblNbHeureSemaine = int.Parse(lviewOffresEmploi.DataKeys[e.Item.DisplayIndex].Values[1].ToString());
                lblheulblNbHeureSemaine.Text = nbHeulblNbHeureSemaine + " heures par semaine";

                int idVille = int.Parse(lviewOffresEmploi.DataKeys[e.Item.DisplayIndex].Values[0].ToString());
                Ville ville = (from villes in lecontexte.VilleSet where villes.IDVille == idVille select villes).FirstOrDefault();
                lblVille.Text = ville.nomVille;
            }
        }
    }
}