using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class AjoutProfesseur : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Professeur getProfesseur()
        {
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    Professeur newProf = new Professeur();

                    return newProf;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void creerProfesseur ()
        {
            try
            {
                using(LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    Professeur nouveauProf = new Professeur();
                    var lviewItems = lvInscriptionProf.Items[0];



                    TryUpdateModel(nouveauProf);



                }
            }
            
        }

    }
}