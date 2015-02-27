using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique.Inscription.Cropper
{
    public partial class Cropper : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Page.IsPostBack)
            {
                lblPostBack.Text = "Is PosteBack";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            
            Response.Cookies["urlPhotoProfil"].Value = dataURL.Text;
        }
        protected void cookie()
        {
            Response.Cookies["urlPhotoProfil"].Value = dataURL.Text;
        }
    }
}