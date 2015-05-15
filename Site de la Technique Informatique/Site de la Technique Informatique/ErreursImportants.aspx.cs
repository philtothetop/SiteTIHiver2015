using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class ErreursImportants : ErrorHandling
    {
        //Yolo
        protected void Page_Load(object sender, EventArgs e)
        {
            String errorHandler = Request.QueryString["handler"];
            if (errorHandler == null)
            {
                errorHandler = "Error Page";
            }

            Exception ex = Server.GetLastError();



            if (isLocal())
            {

            }

            Server.ClearError();
        }

        protected void Redirect_Click(object sender, EventArgs e)
        {
            if (isLocal())
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Response.Redirect("~/../Default.aspx");
            }
        }

    }
}