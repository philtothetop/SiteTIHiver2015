using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class temp_editNouvelles : System.Web.UI.Page
    {
       public int id = 1;
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

        public IQueryable<Nouvelle> getEditNouvelles()
        {
            List<Nouvelle> listeNouvelle = new List<Nouvelle>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                Nouvelle ok = new Nouvelle();

                listeNouvelle = (from nouvelles in lecontexte.NouvelleSet where nouvelles.IDNouvelle == id select nouvelles).ToList();
            }

            return listeNouvelle.AsQueryable();
        }

        protected void lnkEditNews_Command(object sender, CommandEventArgs e)
        {
             id = Convert.ToInt32(e.CommandArgument);
             lviewEditNews.DataBind();           
        }
    }
}