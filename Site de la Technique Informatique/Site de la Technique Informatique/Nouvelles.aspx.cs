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
       
        public IQueryable<Nouvelle> getNouvelles()
        {
            List<Nouvelle> listeNouvelle = new List<Nouvelle>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                Nouvelle ok = new Nouvelle();

                listeNouvelle = (from nouvelles in lecontexte.NouvelleSet select nouvelles).ToList();
            }
            return listeNouvelle.AsQueryable();
        }
	}
}