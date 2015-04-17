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
            }
            return listeEvenements.AsQueryable();
        }

        protected void UpdateEvent()
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                //Button btnModifier = (Button)sender;
                //int idEvent = Int32.Parse(btnModifier.CommandArgument);
                DateEvenementVerTIC eventTest = (from even in lecontexte.DateEvenementVerTICSet
                                                 where even.IDDateEvenementVerTIC == 6 //idEvent
                                                 select even).FirstOrDefault();
             
             //string id=   lviewEcheancier.ID;
             //   TextBox txtDate= new TextBox();
             //   TextBox txtEvent= new TextBox();
             //txtEvent =  (TextBox)lviewEcheancier.FindControl("txtDescEvent");
             //txtDate = (TextBox)lviewEcheancier.FindControl("txtDate");
             //   eventTest.dateDescription = DateTime.Parse(txtDate.Text);
                //   eventTest.evenement = txtEvent.Text;

                TryUpdateModel(eventTest);
                lecontexte.SaveChanges();
                Response.Redirect("~/Admin_Evenement.aspx");
            }
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            var listeEvenements = new List<DateEvenementVerTIC>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                DateEvenementVerTIC eventTest = new DateEvenementVerTIC { dateDescription = DateTime.Parse(txtAjoutDate.Text), evenement = txtAjoutEvenement.Text };
                listeEvenements = (from cl in lecontexte.DateEvenementVerTICSet select cl).ToList();
                listeEvenements.Add(eventTest);
                lecontexte.DateEvenementVerTICSet.Add(eventTest);
                lecontexte.SaveChanges();
                Response.Redirect("~/Admin_Evenement.aspx");

            }
        }

        protected void btnSupprimer_Click(object sender, EventArgs e)
        {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                  
                    Button btnSupprimer = (Button)sender;
                    int idEvent = Int32.Parse(btnSupprimer.CommandArgument);
                    DateEvenementVerTIC eventTest = (from even in lecontexte.DateEvenementVerTICSet
                                                     where even.IDDateEvenementVerTIC == idEvent
                                                     select even).FirstOrDefault();
                    lecontexte.DateEvenementVerTICSet.Remove(eventTest);
                    lecontexte.SaveChanges();
                    Response.Redirect("~/Admin_Evenement.aspx");
                }
        }

        // Le nom du paramètre id doit correspondre à la valeur DataKeyNames définie sur le contrôle
        public void lviewEcheancier_UpdateItem(string id)
        {
            Site_de_la_Technique_Informatique.Model.DateEvenementVerTIC item = null;
            // Charge l'élément ici, par ex. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // Élément introuvable
                ModelState.AddModelError("", String.Format("L'élément avec l'ID {0} est introuvable", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Enregistre les modifications ici, par ex. MyDataLayer.SaveChanges();

            }
        }

           

     
    }
}