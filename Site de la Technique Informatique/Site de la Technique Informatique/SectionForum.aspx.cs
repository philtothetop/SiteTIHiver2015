using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class SectionForum : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SavoirSiPossedeAutorizationPourLaPage(false, true, true, false, false);
        }

        public IQueryable<Model.SectionForum> getSectionsForum()
        {

            List<Model.SectionForum> listeSectionsForum = new List<Model.SectionForum>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                listeSectionsForum = (from sectionsForum in lecontexte.SectionForumSet select sectionsForum).ToList();
            }
            return listeSectionsForum.AsQueryable();
        }

        protected void lnkSection_Click(object sender, EventArgs e)
        {
            LinkButton lnkSection = (LinkButton)sender;
            Session["IDSectionForum"] = lnkSection.CommandArgument;
            Response.Redirect("~/EnteteForum.aspx", false);
        }
    }
}