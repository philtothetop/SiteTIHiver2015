using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;


namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_Evenement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}