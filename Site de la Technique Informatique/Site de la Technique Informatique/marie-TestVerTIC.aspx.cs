using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class marie_TestVerTIC : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            using (LeModelTIContainer leModel = new LeModelTIContainer())
            {
                Etudiant leMembre = (from cl in leModel.UtilisateurSet.OfType<Etudiant>()
                                   where cl.IDUtilisateur == 55
                                   select cl).FirstOrDefault();

                leMembre.valideCourriel = true;

                leModel.SaveChanges();

            }

          

        }
    }

}