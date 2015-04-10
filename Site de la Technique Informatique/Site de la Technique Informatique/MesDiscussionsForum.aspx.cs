using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.Drawing;

namespace Site_de_la_Technique_Informatique
{
    public partial class MesDiscussionsForum : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, true, false);

            Session["IDSection"] = null;
        }

        public IQueryable<Model.EnteteForum> getEntetesForum()
        {

            List<Model.EnteteForum> listeEntetesForum = new List<Model.EnteteForum>();
            List<Model.MessageForum> listeMessagesForum = new List<Model.MessageForum>();

            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                int IDUtilisateur = Int32.Parse(Server.HtmlEncode(Request.Cookies["TIID"].Value));

                listeEntetesForum = (from entetesForum in lecontexte.EnteteForumSet
                                    join messagesForums in lecontexte.MessageForumSet on entetesForum.IDEnteteForum equals messagesForums.EnteteForumIDEnteteForum
                                    where messagesForums.MembreIDUtilisateur == IDUtilisateur
                                    select entetesForum).Distinct().ToList();
        
            }
            return listeEntetesForum.AsQueryable();
        }

        protected void lviewMesDiscussions_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                Label lblNom = (Label)e.Item.FindControl("lblNom");
                Label lblTitreEntete = (Label)e.Item.FindControl("lblTitreEntete");
                Label lblDateForum = (Label)e.Item.FindControl("lblDateForum");

                int idUtilisateur = Int32.Parse(lviewMesDiscussions.DataKeys[e.Item.DisplayIndex].Values[0].ToString());
                Membre membre = (from membres in lecontexte.UtilisateurSet.OfType<Membre>() where membres.IDUtilisateur == idUtilisateur select membres).FirstOrDefault();

                lblNom.Text = membre.prenom + " " + membre.nom;
                string date = lviewMesDiscussions.DataKeys[e.Item.DisplayIndex].Values[1].ToString();
                lblDateForum.Text = date.Substring(0, 16);

                int idEnteteForum = Int32.Parse(lviewMesDiscussions.DataKeys[e.Item.DisplayIndex].Values[2].ToString());
                int IDUtilisateur = Int32.Parse(Server.HtmlEncode(Request.Cookies["TIID"].Value));

                Model.Membre membreVisite = (from membres in lecontexte.UtilisateurSet.OfType<Membre>()
                                             where membres.IDUtilisateur == IDUtilisateur
                                             select membres).FirstOrDefault();

                Model.ConsultationForum consultationExistante = (from consultations in lecontexte.ConsultationForumSet
                                                                 where consultations.EnteteForumIDEnteteForum == idEnteteForum &&
                                                                 consultations.IDMembre == membreVisite.IDMembre
                                                                 select consultations).FirstOrDefault();

                if (consultationExistante != null)
                {
                    lblTitreEntete.ForeColor = Color.Blue;
                }

            }
        }

        protected void lnkEntete_Click(object sender, EventArgs e)
        {
            LinkButton lnkEntete = (LinkButton)sender;
            Session["IDEnteteForum"] = lnkEntete.CommandArgument;
            Response.Redirect("~/DiscussionForum.aspx", false);
        }
    }
}