using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_EvenementVERTIC : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, false, false, false);

            lblErreur.Text = "";
            lblErreur.ForeColor = Color.Red;

            //Bind cela que a la premiere ouverture de la page
            if (Page.IsPostBack == false)
            {
                ddlAnneeEventAjouter.DataBind();
                ddlHeuresAjouter.DataBind();
                ddlMinutesAjouter.DataBind();
                ddlMoisEventAjouter.DataBind();
                ddlMoisEventAjouter.SelectedIndex = 1;
            }
        }

        #region GETDATA DES ÉVÉNEMENTS
        public IQueryable<DateEvenementVerTIC> lvEcheancier_GetData()
        {
            var listeEvenements = new List<DateEvenementVerTIC>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                listeEvenements = (from cl in lecontexte.DateEvenementVerTICSet where cl.dateDescription >= DateTime.Now select cl).ToList();
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

                //Liste des événements pour trouver l'index (Patch pour le moment, devrais avoir meilleur moyen a faire pour plus tard)
                List<DateEvenementVerTIC> listeEvenements = new List<DateEvenementVerTIC>();
                listeEvenements = (from cl in lecontexte.DateEvenementVerTICSet where cl.dateDescription >= DateTime.Now select cl).ToList();

                //Trouver index des controls a modifier
                int indexItemAModifier = listeEvenements.IndexOf(eventTest);

                TextBox txtEvent = (lviewEcheancier.Items[indexItemAModifier].FindControl("txtDescEvent") as TextBox);
                TextBox txtJourEvent = (lviewEcheancier.Items[indexItemAModifier].FindControl("txtJourEvent") as TextBox);

                DropDownList ddlMoisEvent = (lviewEcheancier.Items[indexItemAModifier].FindControl("ddlMoisEvent") as DropDownList);
                DropDownList ddlAnneeEvent = (lviewEcheancier.Items[indexItemAModifier].FindControl("ddlAnneeEvent") as DropDownList);

                DropDownList ddlHeures = (lviewEcheancier.Items[indexItemAModifier].FindControl("ddlHeures") as DropDownList);
                DropDownList ddlMinutes = (lviewEcheancier.Items[indexItemAModifier].FindControl("ddlMinutes") as DropDownList);
                try
                {
                    DateTime date = new DateTime(Int32.Parse(ddlAnneeEvent.Text), Int32.Parse(ddlMoisEvent.Text), Int32.Parse(txtJourEvent.Text), Int32.Parse(ddlHeures.Text), Int32.Parse(ddlMinutes.Text), 0);
                    eventTest.dateDescription = date;

                    DateTime datemin = DateTime.Parse("01/01/1900", new CultureInfo("en-CA"));

                    if (date < datemin)
                    {
                        lblErreur.Text = "La date n'est pas valide.";
                        txtJourEvent.BorderColor = Color.Red;
                        ddlMoisEvent.BorderColor = Color.Red;
                        ddlAnneeEvent.BorderColor = Color.Red;
                    }
                    else if (date < DateTime.Now.AddDays(1))
                    {

                        lblErreur.Text = "La date n'est pas valide.";
                        txtJourEvent.BorderColor = Color.Red;
                        ddlMoisEvent.BorderColor = Color.Red;
                        ddlAnneeEvent.BorderColor = Color.Red;
                    }
                }
                catch (Exception)
                {
                    lblErreur.Text = "La date n'est pas valide.";
                    txtJourEvent.BorderColor = Color.Red;
                    ddlMoisEvent.BorderColor = Color.Red;
                    ddlAnneeEvent.BorderColor = Color.Red;
                    return;
                }

                //Ajouter un minimum de 5 caracter pour un évenement
                if (txtEvent.Text.Count() < 5)
                {
                    lblErreur.Text = "Doit contenir une description de au moin 5 caractères.";
                    txtEvent.BorderColor = Color.Red;
                    return;
                }

                eventTest.evenement = txtEvent.Text;
                lecontexte.SaveChanges();

                lblErreur.Text = "La modification a réussi.";
                lblErreur.ForeColor = Color.Green;

                Color initialBorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
                ddlAnneeEvent.BorderColor = initialBorderColor;
                ddlMoisEvent.BorderColor = initialBorderColor;
                txtJourEvent.BorderColor = initialBorderColor;
                txtEvent.BorderColor = initialBorderColor;

                lviewEcheancier.DataBind();
            }
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            var listeEvenements = new List<DateEvenementVerTIC>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                DateEvenementVerTIC eventAjouter = new DateEvenementVerTIC();
                try
                {
                    DateTime dateAjout = new DateTime(Int32.Parse(ddlAnneeEventAjouter.Text), Int32.Parse(ddlMoisEventAjouter.Text), Int32.Parse(txtJourEventAjouter.Text), Int32.Parse(ddlHeuresAjouter.Text), Int32.Parse(ddlMinutesAjouter.Text), 0);
                    DateTime datemin = DateTime.Parse("01/01/1900", new CultureInfo("en-CA"));

                    if (dateAjout < datemin)
                    {
                        lblErreur.Text = "La date n'est pas valide.";
                        txtJourEventAjouter.BorderColor = Color.Red;
                        ddlMoisEventAjouter.BorderColor = Color.Red;
                        ddlAnneeEventAjouter.BorderColor = Color.Red;
                        return;
                    }
                    else if (dateAjout < DateTime.Now.AddDays(1))
                    {

                        lblErreur.Text = "La date n'est pas valide.";
                        txtJourEventAjouter.BorderColor = Color.Red;
                        ddlMoisEventAjouter.BorderColor = Color.Red;
                        ddlAnneeEventAjouter.BorderColor = Color.Red;
                        return;
                    }
                    eventAjouter.dateDescription = dateAjout;
                }
                catch (Exception)
                {
                    lblErreur.Text = "La date n'est pas valide.";
                    txtJourEventAjouter.BorderColor = Color.Red;
                    ddlMoisEventAjouter.BorderColor = Color.Red;
                    ddlAnneeEventAjouter.BorderColor = Color.Red;
                    return;
                }

                //Ajouter un minimum de 5 caracter pour un évenement
                if (txtAjoutEvenement.Text.Count() < 5)
                {
                    lblErreur.Text = "Doit contenir une description de au moin 5 caractères.";
                    txtAjoutEvenement.BorderColor = Color.Red;
                    return;
                }

                eventAjouter.evenement = txtAjoutEvenement.Text;
                listeEvenements = (from cl in lecontexte.DateEvenementVerTICSet select cl).ToList();
                listeEvenements.Add(eventAjouter);
                lecontexte.DateEvenementVerTICSet.Add(eventAjouter);
                lecontexte.SaveChanges();

                Color initialBorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
                ddlAnneeEventAjouter.BorderColor = initialBorderColor;
                ddlMoisEventAjouter.BorderColor = initialBorderColor;
                txtJourEventAjouter.BorderColor = initialBorderColor;
                txtAjoutEvenement.BorderColor = initialBorderColor;

                lblErreur.Text = "L'événement a été ajouté.";
                lblErreur.ForeColor = Color.Green;
                lviewEcheancier.DataBind();
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

                lblErreur.Text = "L'événement a été supprimé.";
                lblErreur.ForeColor = Color.Green;

                lviewEcheancier.DataBind();
            }
        }

        #endregion

    }
}