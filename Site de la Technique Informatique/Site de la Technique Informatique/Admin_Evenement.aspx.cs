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
            //if (!IsPostBack)
            //{
            //    for (int i = 0; i < 6; i++)
            //    {
            //        ListItem listItem = new ListItem();

            //        DateTime date = DateTime.Now.AddYears(i);
            //        string annee = date.Year.ToString();
            //        listItem.Text = annee;
            //        listItem.Value = annee;
                    
            //        DropDownList ddlAnneeEvent = (lviewEcheancier.Items[0].FindControl("ddlAnneeEvent") as DropDownList);
            //        ddlAnneeEvent.Items.Insert(i + 1, listItem);
            //    }
            //}
        }

        #region GETDATA DES ÉVÉNEMENTS
        public IQueryable<DateEvenementVerTIC> lvEcheancier_GetData()
        {
            var listeEvenements = new List<DateEvenementVerTIC>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                listeEvenements = (from cl in lecontexte.DateEvenementVerTICSet select cl).ToList();
            }

            return listeEvenements.AsQueryable();
        }
        #endregion

        #region UPDATE/ADD/DELETE UN ÉVÉNEMENT

        protected void UpdateEvent(object sender, EventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                Button btnModifier = (Button)sender;
                int idEvent = Int32.Parse(btnModifier.CommandArgument);
                DateEvenementVerTIC eventTest = (from even in lecontexte.DateEvenementVerTICSet
                                                 where even.IDDateEvenementVerTIC == idEvent
                                                 select even).FirstOrDefault();

                //TextBox lblMinuteActivite = (e.Item.FindControl("txtDescEvent") as TextBox);
                TextBox txtEvent = (lviewEcheancier.Items[0].FindControl("txtDescEvent") as TextBox);
                TextBox txtJourEvent = (lviewEcheancier.Items[0].FindControl("txtJourEvent") as TextBox);
                DropDownList ddlMoisEvent = (lviewEcheancier.Items[0].FindControl("ddlMoisEvent") as DropDownList);
                if (ddlMoisEvent.Text == "" && ddlMoisEvent.SelectedValue == "0")
                {
                    //Erreur
                }
                DropDownList ddlAnneeEvent = (lviewEcheancier.Items[0].FindControl("ddlAnneeEvent") as DropDownList);

                DropDownList ddlHeures = (lviewEcheancier.Items[0].FindControl("ddlHeures") as DropDownList);
                DropDownList ddlMinutes = (lviewEcheancier.Items[0].FindControl("ddlMinutes") as DropDownList);

                DateTime date = new DateTime(Int32.Parse(ddlAnneeEvent.Text), Int32.Parse(ddlMoisEvent.Text), Int32.Parse(txtJourEvent.Text), Int32.Parse(ddlHeures.Text), Int32.Parse(ddlMinutes.Text), 0);

                eventTest.dateDescription = date;
                eventTest.evenement = txtEvent.Text;

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

        #endregion

    }
}