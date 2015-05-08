// Cette classe permet à qui le souhaite de lire les questions et réponses de la FAQ 
// Écrit par Marie-Philippe Gill, Avril 2015
// Intrants: MasterPage


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
    public partial class FAQ : ErrorHandling
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
                    LogErreur("FAQ-SelectFAQ", ex);
                }
            }
            return listeDesQuestions.AsQueryable();
        }

    }
}