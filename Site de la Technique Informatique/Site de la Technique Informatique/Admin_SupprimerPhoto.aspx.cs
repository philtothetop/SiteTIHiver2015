using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_SupprimerPhoto : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(true, true, false, false, false);

        }
    }
}