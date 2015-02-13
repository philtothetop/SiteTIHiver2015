using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique.Classes
{
    public partial class WebForm1 : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlControl body = Master.FindControl("pageBody") as HtmlControl;
            body.Attributes.Add("data-spy", "scroll");
            body.Attributes.Add("data-target", ".scrolltarget");
            body.Attributes.Add("data-offset", "20");
            body.Attributes.Add("style", "position:relative; overflow:auto;");
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

 
public IQueryable<DateEvenementVerTICJeuSet> lvEcheancier_GetData()
{
    var listeEvenements = new List<DateEvenementVerTICJeuSet>();
    using (ModelTIContainer lecontexte = new ModelTIContainer())
    {
        listeEvenements = (from cl in lecontexte.DateEvenementVerTICJeuSet select cl).ToList();
    }

    if (listeEvenements.Count() == 0)
    {
        DateEvenementVerTICJeuSet eventTest = new DateEvenementVerTICJeuSet();
        eventTest.dateDescription = "14 février 2014";
        eventTest.Evenement = "Date de Test";
        eventTest.IDDateEvenement = 1;
        listeEvenements.Add(eventTest);
    }
    return listeEvenements.AsQueryable();
}

    }
}