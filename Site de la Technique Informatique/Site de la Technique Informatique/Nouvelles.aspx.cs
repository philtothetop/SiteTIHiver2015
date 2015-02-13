using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
	public partial class Nouvelles : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
          
		}
       
        public IQueryable<NouvelleJeu> getNouvelles()
        {
            List<NouvelleJeu> listeNouvelle = new List<NouvelleJeu>();
            using (ModelTIContainer lecontexte = new ModelTIContainer())
            {

                listeNouvelle = (from nouvelles in lecontexte.NouvelleJeu select nouvelles).ToList();
            }
            return listeNouvelle.AsQueryable();
        }
	}
}