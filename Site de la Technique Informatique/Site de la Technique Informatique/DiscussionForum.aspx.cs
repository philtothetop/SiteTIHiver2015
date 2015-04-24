using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class DiscussionForum : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SavoirSiPossedeAutorizationPourLaPage(false, true, true, false, false);

            txtMessage.Attributes.Add("maxlength", txtMessage.MaxLength.ToString());

            if (Session["IDEnteteForum"] == null)
            {
                Response.Redirect("~/EnteteForum.aspx", false);
            }
            if (Page.IsPostBack != true)
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    int idEnteteForum = Int32.Parse(Session["IDEnteteForum"].ToString());
                    int IDUtilisateur = Int32.Parse(Server.HtmlEncode(Request.Cookies["TIID"].Value));

                    Model.Membre membre = (from membres in lecontexte.UtilisateurSet.OfType<Membre>()
                                           where membres.IDUtilisateur == IDUtilisateur
                                           select membres).FirstOrDefault();

                    Model.ConsultationForum consultationExistante = (from consultations in lecontexte.ConsultationForumSet
                                                                     where consultations.EnteteForumIDEnteteForum == idEnteteForum &&
                                                                     consultations.IDMembre == membre.IDMembre
                                                                     select consultations).FirstOrDefault();

                    if (consultationExistante == null)
                    {

                        Model.EnteteForum enteteForum = (from entetesForum in lecontexte.EnteteForumSet
                                                         where entetesForum.IDEnteteForum == idEnteteForum
                                                         select entetesForum).FirstOrDefault();

                        lblTitreDiscussion.Text = enteteForum.titreEnteteForum;

                        Model.ConsultationForum consultation = new ConsultationForum();

                        consultation.dateConsulte = DateTime.Now;
                        consultation.EnteteForum = enteteForum;
                        consultation.EnteteForumIDEnteteForum = enteteForum.IDEnteteForum;
                        consultation.IDMembre = membre.IDMembre;
                        consultation.Membre.Add(membre);

                        lecontexte.ConsultationForumSet.Add(consultation);
                        lecontexte.SaveChanges();

                    }
                    else
                    {
                        consultationExistante.dateConsulte = DateTime.Now;
                        lecontexte.SaveChanges();
                    }
                }
            }
        }

        public IQueryable<Model.MessageForum> getDiscussion()
        {

            List<Model.MessageForum> listeDiscussion = new List<Model.MessageForum>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                int idEnteteForum = Int32.Parse(Session["IDEnteteForum"].ToString());
                listeDiscussion = (from discussionsForum in lecontexte.MessageForumSet
                                   where discussionsForum.EnteteForumIDEnteteForum == idEnteteForum
                                   orderby discussionsForum.dateMessage ascending
                                   select discussionsForum).ToList();
            }
            return listeDiscussion.AsQueryable();
        }

        protected void lviewDiscussion_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                Label lblNom = (Label)e.Item.FindControl("lblNom");
                Label lblDateMessage = (Label)e.Item.FindControl("lblDateMessage");
                Image imgPhotoProfil = (Image)e.Item.FindControl("imgPhotoProfil");

                int idUtilisateur = Int32.Parse(lviewDiscussion.DataKeys[e.Item.DisplayIndex].Values[1].ToString());
                Membre membre = (from membres in lecontexte.UtilisateurSet.OfType<Membre>() where membres.IDUtilisateur == idUtilisateur select membres).FirstOrDefault();

                lblNom.Text = membre.prenom + " " + membre.nom;
                string date = lviewDiscussion.DataKeys[e.Item.DisplayIndex].Values[0].ToString();
                lblDateMessage.Text = date.Substring(0, 16);

                if (membre.pathPhotoProfil != null && membre.pathPhotoProfil != "")
                {
                    imgPhotoProfil.ImageUrl = "~/Photos/Profils/" + membre.pathPhotoProfil;
                }
                else
                {
                    imgPhotoProfil.ImageUrl = "~/Photos/Profils/photobase.bmp";
                }

            }
        }

        protected void lnkNouveauMessage_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text != "")
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    int IDEnteteForum = Int32.Parse(Session["IDEnteteForum"].ToString());
                    int IDUtilisateur = Int32.Parse(Server.HtmlEncode(Request.Cookies["TIID"].Value));

                    Model.MessageForum messageForum = new MessageForum();

                    messageForum.texteMessage = txtMessage.Text;
                    messageForum.dateMessage = DateTime.Now;
                    messageForum.EnteteForumIDEnteteForum = IDEnteteForum;
                    messageForum.MembreIDUtilisateur = IDUtilisateur;
                    messageForum.EnteteForum = (from entetesForum in lecontexte.EnteteForumSet where entetesForum.IDEnteteForum == IDEnteteForum select entetesForum).FirstOrDefault();
                    messageForum.Membre = (from membres in lecontexte.UtilisateurSet.OfType<Membre>() where membres.IDUtilisateur == IDUtilisateur select membres).FirstOrDefault();

                    lecontexte.MessageForumSet.Add(messageForum);
                    lecontexte.SaveChanges();
                    txtMessage.Text = "";

                    Response.Redirect("DiscussionForum.aspx");
                }
            }

        }

        protected void lnkRetour_Click(object sender, EventArgs e)
        {
            if (Session["IDSectionForum"] == null)
            {
                Response.Redirect("MesDiscussionsForum.aspx");
            }
            else
            {
                Response.Redirect("EnteteForum.aspx");
            }

        }
    }
}