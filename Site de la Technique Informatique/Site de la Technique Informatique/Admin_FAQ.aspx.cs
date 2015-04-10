using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_FAQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.Attributes["style"] = "";
        }

        public IQueryable<Model.FAQ> getQuestionsFAQ()
        {
            List<Model.FAQ> listeDesQuestions = null;

            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                try
                {
                    listeDesQuestions = (from faq in lecontexte.FAQSet select faq).ToList();
                }
                catch (Exception ex)
                {
                    lblMessage.Attributes["style"] = "color:red;";
                    lblMessage.Text += "ERREUR AVEC LE MEMBRE, " + ex.ToString();
                }
            }
            return listeDesQuestions.AsQueryable();
        }

        public Model.FAQ getQuestionAModifier()
        {
            Model.FAQ questionAModifier = null;

            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                try
                {
                    questionAModifier = (from faq in lecontexte.FAQSet select faq).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    lblMessage.Attributes["style"] = "color:red;";
                    lblMessage.Text += "ERREUR AVEC LE MEMBRE, " + ex.ToString();
                }
            }
            return questionAModifier;
        }

        protected void ddlQuestionsFAQ_SelectedIndexChanged(object sender, EventArgs e)
        {

            TextBox txtQuestion = (TextBox)lviewModifFAQ.Items[0].FindControl("txtQuestion");
            TextBox txtReponse = (TextBox)lviewModifFAQ.Items[0].FindControl("txtReponse");
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    int selectedValue = Convert.ToInt32(ddlQuestionsFAQ.SelectedValue);
                    Model.FAQ laFaq = (lecontexte.FAQSet.SingleOrDefault(m => m.IDFAQ == selectedValue));
                    txtQuestion.Text = laFaq.texteQuestion;
                    txtReponse.Text = laFaq.texteReponse;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text += "Une erreur est survenue lorsque l'on a tenté d'aller chercher le message. " + ex.InnerException;
            }
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                try
                {
                    Model.FAQ nouvelleQuestion = new Model.FAQ();
                    string ajouterQuestion = txtAjouterQuestion.Text;
                    string ajouterReponse = txtAjouterReponse.Text;
                    nouvelleQuestion.texteQuestion = ajouterQuestion;
                    nouvelleQuestion.texteReponse = ajouterReponse;
                    lecontexte.FAQSet.Add(nouvelleQuestion);
                    nouvelleQuestion.ProfesseurIDUtilisateur = Convert.ToInt32(Server.HtmlEncode(Request.Cookies["TIID"].Value));
                    lecontexte.SaveChanges();
                }
                catch (Exception ex)
                {
                    lblMessage.Attributes["style"] = "color:red;";
                    lblMessage.Text += "Erreur lors du clic sur btn_Ajouter: " + ex.ToString();
                }
                lblMessage.Attributes["style"] = "color:green;";
                lblMessage.Text += "Vous avez bien ajouté votre question à la FAQ!";
                txtAjouterQuestion.Text = "";
                txtAjouterReponse.Text = "";
                ddlQuestionsFAQ.DataBind();
            }
        }

        protected void lviewModifFAQ_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    int ID = Convert.ToInt32(e.CommandArgument);
                    //string pseudo = (from mem in lecontexte.UtilisateurJeu.OfType<Membre>() where mem.IDUtilisateur == ID select mem.Pseudo).FirstOrDefault();
                    if (e.CommandName == "Modifier")
                    {
                        Model.FAQ questionAMod = (from question in lecontexte.FAQSet where question.IDFAQ == ID select question).FirstOrDefault();
                        //questionAMod.texteQuestion = lviewModifFAQ.FindControl.
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text += "Une erreur est survenue lorsque l'on a tenté d'aller sur la messagerie " + ex.InnerException;
            }

        }
    }
}