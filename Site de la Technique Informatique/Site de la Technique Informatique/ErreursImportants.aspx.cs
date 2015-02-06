using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class ErreursImportants : System.Web.UI.Page
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

            if (ex != null)
            {
                lblErreurs.Text = ex.Message;
                error.Visible = true;
            }

            if (Request.IsLocal)
            {
                lblErreurs.Text = ex.Message + "<br/>";

                if (ex.InnerException != null)
                {
                    lblErreurs.Text += "***Inner Exception***<br/> Type: " + ex.InnerException.GetType().ToString()
                                     + "<br/>Message: <br/>" + ex.InnerException.Message + "<br/>";

                    lblInnerTrace.Text = "Inner Stack Trace: <br/>Source: " + errorHandler +
                                         "<br/>" + ex.InnerException.StackTrace + "<br/>";



                }
                lblStackTrace.Text += "***Stack Trace***<br/>";
                lblStackTrace.Text += "Type: " + ex.GetType().ToString() + "<br/>";
                lblStackTrace.Text += "Exception: " + ex.Message + "<br/>";
                lblStackTrace.Text += "Source: " + ex.Source + "<br/>";
                lblStackTrace.Text += "StackTrace: <br/>" + ex.StackTrace;

            }
            Server.ClearError();
        }
    }
}