using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique.Inscription
{
    public partial class Inscription_messaga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["id"]=="0")//Si l'envoie du courriel ne fonctionne pas.
            {
                lblMessage.Text ="Un problème est survenu durant l'inscription, votre inscription a été automatiquement refusée.";
            }
        }
    }
}