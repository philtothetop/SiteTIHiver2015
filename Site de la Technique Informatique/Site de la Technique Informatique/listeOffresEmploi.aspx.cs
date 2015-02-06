using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class listeOffresEmploi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public IQueryable<OffreEmploi> getOffresEmploi()
        //{
        //    List<OffreEmploi> listeOffresEmploi = new List<OffreEmploi>();
        //    using (ModelTIContainer lecontexte = new ModelTIContainer())
        //    {

        //      listeOffresEmploi = (from offresEmploi in lecontexte.OffreEmploiJeuSet select offresEmploi).ToList();
        //}
        //    return listeOffresEmploi;
        //}

        protected void lviewOffresEmploi_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }

    }
}
