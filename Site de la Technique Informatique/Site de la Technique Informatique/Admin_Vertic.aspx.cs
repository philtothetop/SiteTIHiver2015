using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_Vertic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HtmlControl body = Master.FindControl("pageBody") as HtmlControl;
            //body.Attributes.Add("data-spy", "scroll");
            //body.Attributes.Add("data-target", ".scrolltarget");
            //body.Attributes.Add("data-offset", "20");
            //body.Attributes.Add("style", "position:relative; overflow:auto;");
            if (!IsPostBack)
            {


                string caract = getCaracteristiquePortable();
                txtCaractPortatif.Text = caract;
                string autres = getAutresPortable();
                txtAutres.Text = autres;
                string licences = getLicences();
                txtLogicielLicenses.Text = licences;
                string libres = getLibres();
                txtLogicielLibres.Text = libres;
            }
        }

        public String getCaracteristiquePortable()
        {
            string caracteristiquePortable = "";
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                caracteristiquePortable = (from description in lecontexte.VerTICSet select description.caractéristiquesPortable).FirstOrDefault();
            }
            return caracteristiquePortable;
        }
        public String getAutresPortable()
        {
            string autresPortable = "";
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                autresPortable = (from autres in lecontexte.VerTICSet select autres.autrePortable).FirstOrDefault();
            }
            return autresPortable;
        }
        public String getLicences()
        {
            string licences = "";
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                licences = (from licence in lecontexte.VerTICSet select licence.descriptionLicence).FirstOrDefault();
            }
            return licences;
        }
        public String getLibres()
        {
            string libres = "";
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                libres = (from libre in lecontexte.VerTICSet select libre.descriptionLibre).FirstOrDefault();
            }


            string caract = getCaracteristiquePortable();
            txtCaractPortatif.Text = caract;
            return libres;
        }




        public IQueryable<DateEvenementVerTIC> lvEcheancier_GetData()
        {
            var listeEvenements = new List<DateEvenementVerTIC>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                listeEvenements = (from cl in lecontexte.DateEvenementVerTICSet select cl).ToList();
            }

            if (listeEvenements.Count() == 0)
            {

                DateEvenementVerTIC eventTest = new DateEvenementVerTIC();
                eventTest.dateDescription = DateTime.Today;
                eventTest.evenement = "Date de Test";
                eventTest.IDDateEvenementVerTIC = 1;
                listeEvenements.Add(eventTest);

                listeEvenements.Add(new DateEvenementVerTIC { dateDescription = DateTime.Today.AddDays(1), evenement = "dadadad" });
                listeEvenements.Add(new DateEvenementVerTIC { dateDescription = DateTime.Today.AddDays(3), evenement = "WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW" });
            }
            return listeEvenements.AsQueryable();
        }

        protected void btnSauvegarder_Click(object sender, EventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                VerTIC vertic = new VerTIC();
                vertic = (from tic in lecontexte.VerTICSet select tic).FirstOrDefault();
                vertic.descriptionLicence = txtLogicielLicenses.Text;
                vertic.descriptionLibre = txtLogicielLibres.Text;
                vertic.caractéristiquesPortable = txtCaractPortatif.Text;
                vertic.autrePortable = txtAutres.Text;
                lecontexte.SaveChanges();
            }
        }
    }
}