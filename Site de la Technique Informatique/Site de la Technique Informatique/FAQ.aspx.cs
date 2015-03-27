using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class FAQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Model.FAQ> SelectFAQ()
        {
            List<Model.FAQ> listeDesQuestions = null;

            using (LeModelTIContainer lecontexte = new LeModelTIContainer()) { 
                try
                {
                    listeDesQuestions = (from faq in lecontexte.FAQSet select faq).ToList();
                }
                catch (Exception ex)
                {
                    //lblMessage.Text += "ERREUR AVEC LE MEMBRE, " + ex.ToString();
                }
            }
            return listeDesQuestions.AsQueryable();
        }

        //protected void lnkQuestion_Command(object sender, CommandEventArgs e)
        //{

        //    LinkButton lnkQuestion = ((LinkButton)sender);
        //    int no = lviewFAQ.SelectedIndex;
        //}

        //protected void lviewFAQ_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    string no = lviewFAQ.SelectedIndex.ToString(); ;
        //    HtmlControl lnkQuestion = (HtmlControl) lviewFAQ.FindControl("lnkQuestion");
        //    string collapseNo = "collapse" + no;
        //    lnkQuestion.Attributes.Add("href", no);

        //    HtmlControl divCollapse = (HtmlControl)lviewFAQ.FindControl("collapseOne");
        //    divCollapse.Attributes.Add("id", no);
        //}

        //protected void lnkQuestion_ServerClick(object sender, EventArgs e)
        //{
            
        //}

    }
}