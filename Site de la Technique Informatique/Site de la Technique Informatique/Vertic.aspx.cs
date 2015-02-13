using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;


namespace Site_de_la_Technique_Informatique.Classes
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlControl body = Master.FindControl("pageBody") as HtmlControl;
            body.Attributes.Add("data-spy", "scroll");
            body.Attributes.Add("data-target", ".scrolltarget");
            body.Attributes.Add("data-offset", "20");
            body.Attributes.Add("style", "position:relative; overflow:auto;");

            string caract = getCaracteristiquePortable();
            txtCaractPortatif.Text = caract;
        }

        public String getCaracteristiquePortable()
        {
            string caracteristiquePortable="";
            using (ModelTIContainer lecontexte = new ModelTIContainer())
            {

                caracteristiquePortable = (from description in lecontexte.VerTICJeu select description.caracteristiquesPortable).FirstOrDefault();
            }
            return caracteristiquePortable;
        }

    }
}