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
            string autres = getAutresPortable();
            txtAutres.Text=autres;
            string licences = getLicences();
            txtLogicielLicenses.Text = licences;
            string libres = getLibres();
            txtLogicielLibres.Text = libres;
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
        public String getAutresPortable()
        {
            string autresPortable = "";
            using (ModelTIContainer lecontexte = new ModelTIContainer())
            {

                autresPortable = (from autres in lecontexte.VerTICJeu select autres.autrePortable).FirstOrDefault();
            }
            return autresPortable;
        }
        public String getLicences()
        {
            string licences = "";
            using (ModelTIContainer lecontexte = new ModelTIContainer())
            {

                licences = (from licence in lecontexte.VerTICJeu select licence.descriptionLicence).FirstOrDefault();
            }
            return licences;
        }
        public String getLibres()
        {
            string libres = "";
            using (ModelTIContainer lecontexte = new ModelTIContainer())
            {

                libres = (from libre in lecontexte.VerTICJeu select libre.descriptionLibre).FirstOrDefault();
            }
            

            string caract = getCaracteristiquePortable();
            txtCaractPortatif.Text = caract;
            return libres;
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