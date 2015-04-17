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
    public partial class AjoutDiscussion : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, true, false);

            if (Session["IDSectionForum"] == null)
            {
                Response.Redirect("~/SectionForum.aspx", false);
            }

            txtMessage.Attributes.Add("maxlength", txtMessage.MaxLength.ToString());

        }

        protected void lnkAjouter_Click(object sender, EventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                int nbErreurs = 0;
                lblErreur.Text = "";
                lblTitreDiscussion.Text = "";
                lblMessage.Text = "";
                txtTitreDiscussion.BorderColor = Color.LightGray;
                txtMessage.BorderColor = Color.LightGray;

                if (txtTitreDiscussion.Text == "")
                {
                    lblTitreDiscussion.Text = "Titre requis";
                    txtTitreDiscussion.BorderColor = Color.Red;
                    nbErreurs++;
                }
                else if (txtTitreDiscussion.Text.Length < 5)
                {
                    lblTitreDiscussion.Text = "Titre trop court";
                    txtTitreDiscussion.BorderColor = Color.Red;
                    nbErreurs++;
                }

                if (txtMessage.Text == "")
                {
                    lblMessage.Text = "Message requis";
                    txtMessage.BorderColor = Color.Red;
                    nbErreurs++;
                }
                else if (txtMessage.Text.Length < 5)
                {
                    lblMessage.Text = "Message trop court";
                    txtMessage.BorderColor = Color.Red;
                    nbErreurs++;
                }

                if (nbErreurs == 1)
                {
                    lblErreur.Text = "Veuillez corriger le champ en erreur";
                }
                else if (nbErreurs > 1)
                {
                    lblErreur.Text = "Veuillez corriger les " + nbErreurs + " champs en erreur";
                }
                else
                {
                    try
                    {

                        int IDSectionForum = Int32.Parse(Session["IDSectionForum"].ToString());
                        int IDUtilisateur = Int32.Parse(Server.HtmlEncode(Request.Cookies["TIID"].Value));

                        Model.EnteteForum enteteForum = new Model.EnteteForum();
                        Model.EnteteForum derniereEnteteForum = lecontexte.EnteteForumSet.OrderByDescending(u => u.IDEnteteForum).FirstOrDefault();

                        if (derniereEnteteForum == null)
                        {
                            enteteForum.IDEnteteForum = 1;
                        }
                        else
                        {
                            enteteForum.IDEnteteForum = derniereEnteteForum.IDEnteteForum + 1;
                        }

                        enteteForum.titreEnteteForum = txtTitreDiscussion.Text;
                        enteteForum.dateEnteteForum = DateTime.Now;
                        DateTime dateAjout = enteteForum.dateEnteteForum;
                        enteteForum.SectionForumIDSectionForum = IDSectionForum;
                        enteteForum.MembreIDUtilisateur = IDUtilisateur;
                        enteteForum.SectionForum = (from sectionsForum in lecontexte.SectionForumSet
                                                    where sectionsForum.IDSectionForum == IDSectionForum
                                                    select sectionsForum).FirstOrDefault();
                        enteteForum.Membre = (from membres in lecontexte.UtilisateurSet.OfType<Membre>()
                                              where membres.IDUtilisateur == IDUtilisateur
                                              select membres).FirstOrDefault();

                        lecontexte.EnteteForumSet.Add(enteteForum);
                        lecontexte.SaveChanges();

                        Model.MessageForum messageForum = new Model.MessageForum();
                        Model.MessageForum dernierMessageForum = lecontexte.MessageForumSet.OrderByDescending(u => u.IDMessageForum).FirstOrDefault();

                        if (dernierMessageForum == null)
                        {
                            messageForum.IDMessageForum = 1;
                        }
                        else
                        {
                            messageForum.IDMessageForum = dernierMessageForum.IDMessageForum + 1;
                        }

                        messageForum.texteMessage = txtMessage.Text;
                        messageForum.dateMessage = DateTime.Now;

                        Model.EnteteForum enteteForumRecherche = (from etetesForum in lecontexte.EnteteForumSet
                                                                  where etetesForum.dateEnteteForum.CompareTo(dateAjout) == 1
                                                                  select etetesForum).FirstOrDefault();

                        ViewState["IDEnteteForum"] = enteteForumRecherche.IDEnteteForum;

                        messageForum.EnteteForumIDEnteteForum = Int32.Parse(ViewState["IDEnteteForum"].ToString());
                        messageForum.EnteteForum = enteteForumRecherche;

                        messageForum.MembreIDUtilisateur = IDUtilisateur;
                        messageForum.Membre = (from membres in lecontexte.UtilisateurSet.OfType<Membre>()
                                               where membres.IDUtilisateur == IDUtilisateur
                                               select membres).FirstOrDefault();

                        lecontexte.MessageForumSet.Add(messageForum);
                        lecontexte.SaveChanges();

                        mvAjoutDiscussion.SetActiveView(viewFin);

                    }
                    catch (Exception ex)
                    {

                        lblErreur.Text = "Erreur lors de l'ajout de de la discussion";
                    }
                }
            }
        }

        protected void lnkRetour_Click(object sender, EventArgs e)
        {

            Session["IDEnteteForum"] = Int32.Parse(ViewState["IDEnteteForum"].ToString());
            Response.Redirect("~/DiscussionForum.aspx", false);
        }
    }
}