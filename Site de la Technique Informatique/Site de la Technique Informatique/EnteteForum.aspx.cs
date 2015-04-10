using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class EnteteForum : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, true, false);

            if (Session["IDSectionForum"] == null)
            {
                Response.Redirect("~/SectionForum.aspx", false);
            }

            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                int idSectionForum = Int32.Parse(Session["IDSectionForum"].ToString());
                Model.SectionForum sectionForum = (from sectionsForum in lecontexte.SectionForumSet
                                                   where sectionsForum.IDSectionForum == idSectionForum
                                                   select sectionsForum).FirstOrDefault();
                lblTitreSection.Text = sectionForum.titreSection;

            }
        }

        public IQueryable<Model.EnteteForum> getEntetesForum()
        {

            List<Model.EnteteForum> listeEntetesForum = new List<Model.EnteteForum>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                int idSectionForum = Int32.Parse(Session["IDSectionForum"].ToString());
                listeEntetesForum = (from entetesForum in lecontexte.EnteteForumSet
                                     where entetesForum.SectionForumIDSectionForum == idSectionForum
                                     orderby entetesForum.dateEnteteForum descending
                                     select entetesForum).ToList();
            }
            return listeEntetesForum.AsQueryable();
        }

        protected void lviewEntete_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                Label lblNom = (Label)e.Item.FindControl("lblNom");
                Label lblDateForum = (Label)e.Item.FindControl("lblDateForum");

                int idUtilisateur = Int32.Parse(lviewEntete.DataKeys[e.Item.DisplayIndex].Values[0].ToString());
                Membre membre = (from membres in lecontexte.UtilisateurSet.OfType<Membre>() where membres.IDUtilisateur == idUtilisateur select membres).FirstOrDefault();

                lblNom.Text = membre.prenom + " " + membre.nom;
                string date = lviewEntete.DataKeys[e.Item.DisplayIndex].Values[1].ToString();
                lblDateForum.Text = date.Substring(0, 16);

            }
        }

        protected void lnkEntete_Click(object sender, EventArgs e)
        {
            LinkButton lnkEntete = (LinkButton)sender;
            Session["IDEnteteForum"] = lnkEntete.CommandArgument;
            Response.Redirect("~/DiscussionForum.aspx", false);
        }

        protected void lnkNouvelleDiscusison_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AjoutDiscussion.aspx", false);
        }
    }
}