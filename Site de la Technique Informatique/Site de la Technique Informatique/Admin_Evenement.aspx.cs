using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.Globalization;


namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_Evenement : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, false, false, false);
            
            lblErreur.Text = "";
            lblErreur.ForeColor = Color.Red;

            //Bind cela que a la premiere ouverture de la page
            if (Page.IsPostBack == false)
            {
                ddlAnneeDebutEventAjouter.DataBind();
                ddlHeuresDebutAjouter.DataBind();
                ddlMinutesDebutAjouter.DataBind();
                ddlMoisDebutEventAjouter.DataBind();
                ddlMoisDebutEventAjouter.SelectedIndex = 1;

                ddlAnneeFinEventAjouter.DataBind();
                ddlHeuresFinAjouter.DataBind();
                ddlMinutesFinAjouter.DataBind();
                ddlMoisFinEventAjouter.DataBind();
                ddlMoisFinEventAjouter.SelectedIndex = 1;
            }
        }

        #region GETDATA DES ÉVÉNEMENTS
        public IQueryable<Evenement> lvEcheancier_GetData()
        {
            var listeEvenements = new List<Evenement>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                listeEvenements = (from cl in lecontexte.EvenementSet where cl.dateDebutEvenement >= DateTime.Now select cl).ToList();
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
                Evenement eventTest = (from even in lecontexte.EvenementSet
                                       where even.IDEvenement == idEvent
                                       select even).FirstOrDefault();

                //Liste des événements pour trouver l'index (Patch pour le moment, devrais avoir meilleur moyen a faire pour plus tard)
                List<Evenement> listeEvenements = new List<Evenement>();
                listeEvenements = (from cl in lecontexte.EvenementSet where cl.dateDebutEvenement >= DateTime.Now select cl).ToList();

                //Trouver index des controls a modifier
                int indexItemAModifier = listeEvenements.IndexOf(eventTest);

                TextBox txtEvent = (lviewEcheancier.Items[indexItemAModifier].FindControl("txtDescEvent") as TextBox);
                TextBox txtModifTitre = (lviewEcheancier.Items[indexItemAModifier].FindControl("txtModifTitre") as TextBox);

                TextBox txtJourDebutEvent = (lviewEcheancier.Items[indexItemAModifier].FindControl("txtJourDebutEvent") as TextBox);
                TextBox txtJourFinEvent = (lviewEcheancier.Items[indexItemAModifier].FindControl("txtJourFinEvent") as TextBox);

                DropDownList ddlMoisDebutEvent = (lviewEcheancier.Items[indexItemAModifier].FindControl("ddlMoisDebutEvent") as DropDownList);
                DropDownList ddlMoisFinEvent = (lviewEcheancier.Items[indexItemAModifier].FindControl("ddlMoisFinEvent") as DropDownList);

                DropDownList ddlAnneeDebutEvent = (lviewEcheancier.Items[indexItemAModifier].FindControl("ddlAnneeDebutEvent") as DropDownList);
                DropDownList ddlAnneeFinEvent = (lviewEcheancier.Items[indexItemAModifier].FindControl("ddlAnneeFinEvent") as DropDownList);

                DropDownList ddlHeuresDebut = (lviewEcheancier.Items[indexItemAModifier].FindControl("ddlHeuresDebut") as DropDownList);
                DropDownList ddlHeuresFin = (lviewEcheancier.Items[indexItemAModifier].FindControl("ddlHeuresFin") as DropDownList);

                DropDownList ddlMinutesDebut = (lviewEcheancier.Items[indexItemAModifier].FindControl("ddlMinutesDebut") as DropDownList);
                DropDownList ddlMinutesFin = (lviewEcheancier.Items[indexItemAModifier].FindControl("ddlMinutesFin") as DropDownList);

                CheckBox chkbPasDateDeFin = (lviewEcheancier.Items[indexItemAModifier].FindControl("chkbPasDateDeFin") as CheckBox);

                bool isValid = true;
                string listErreurs = "";

                int jourDebut = 1;
                int jourFin = 1;

                if (Int32.TryParse(txtJourDebutEventAjouter.Text, out jourDebut))
                {
                    jourDebut = Convert.ToInt32(txtJourDebutEventAjouter.Text);
                }
                else
                {
                    jourDebut = 1;
                }

                if (Int32.TryParse(txtJourFinEventAjouter.Text, out jourFin))
                {
                    jourFin = Convert.ToInt32(txtJourFinEventAjouter.Text);
                }
                else
                {
                    jourFin = 1;
                }
                try
                {
                    DateTime dateDebut = new DateTime(Int32.Parse(ddlAnneeDebutEvent.Text), Int32.Parse(ddlMoisDebutEvent.Text), jourDebut, Int32.Parse(ddlHeuresDebut.Text), Int32.Parse(ddlMinutesDebut.Text), 0);
                    DateTime dateFin = new DateTime(Int32.Parse(ddlAnneeFinEvent.Text), Int32.Parse(ddlMoisFinEvent.Text), jourFin, Int32.Parse(ddlHeuresFin.Text), Int32.Parse(ddlMinutesFin.Text), 0);

                    eventTest.dateDebutEvenement = dateDebut;
                    eventTest.dateFinEvenement = dateFin;

                    DateTime datemin = DateTime.Parse("01/01/1900", new CultureInfo("en-CA"));

                    //Vérifier date de début
                    if (dateDebut < datemin)
                    {
                        listErreurs += "La date de début n'est pas valide.<br/>";
                        txtJourDebutEvent.BorderColor = Color.Red;
                        ddlMoisDebutEvent.BorderColor = Color.Red;
                        ddlAnneeDebutEvent.BorderColor = Color.Red;
                        isValid = false;
                    }
                    else if (dateDebut < DateTime.Now.AddDays(1))
                    {
                        listErreurs += "La date de début n'est pas valide.<br/>";
                        txtJourDebutEvent.BorderColor = Color.Red;
                        ddlMoisDebutEvent.BorderColor = Color.Red;
                        ddlAnneeDebutEvent.BorderColor = Color.Red;
                        isValid = false;
                    }

                    //Si ya une date de fin
                    if (chkbPasDateDeFin.Checked == false)
                    { 
                        //Cehcker si date de fin est plus grande que date de début
                        if (dateDebut > dateFin)
                        {
                            listErreurs  += "La date de fin est plus petite que celle de début.<br/>";
                            txtJourDebutEvent.BorderColor = Color.Red;
                            ddlMoisDebutEvent.BorderColor = Color.Red;
                            ddlAnneeDebutEvent.BorderColor = Color.Red;
                            isValid = false;
                        }
                    }
                }
                catch (Exception)
                {
                    lblErreur.Text = "Erreurs l'hors de la validation des dates.";
                    txtJourDebutEvent.BorderColor = Color.Red;
                    ddlMoisDebutEvent.BorderColor = Color.Red;
                    ddlAnneeDebutEvent.BorderColor = Color.Red;
                    ddlHeuresDebut.BorderColor = Color.Red;
                    ddlMinutesDebut.BorderColor = Color.Red;

                    txtJourFinEvent.BorderColor = Color.Red;
                    ddlMoisFinEvent.BorderColor = Color.Red;
                    ddlAnneeFinEvent.BorderColor = Color.Red;
                    ddlHeuresFin.BorderColor = Color.Red;
                    ddlMinutesFin.BorderColor = Color.Red;

                    isValid = false;
                }

                //Ajouter un minimum de 5 caracter pour un évenement
                if (txtEvent.Text.Count() < 5)
                {
                    listErreurs += "Doit contenir une description de au moin 5 caractères.<br/>";
                    txtEvent.BorderColor = Color.Red;
                    isValid = false;
                }

                //Ajouter un minimum de 3 caracter pour le titre
                if (txtModifTitre.Text.Count() < 3)
                {
                    listErreurs += "Doit contenir un titre de au moin 3 caractères.<br/>";
                    txtModifTitre.BorderColor = Color.Red;
                    isValid = false;
                }

                //Si tout est ok
                if (isValid == true)
                {

                    eventTest.descriptionEvenement = txtEvent.Text;
                    lecontexte.SaveChanges();

                    lblErreur.Text = "La modification a réussi.";
                    lblErreur.ForeColor = Color.Green;

                    Color initialBorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
                    ddlAnneeDebutEvent.BorderColor = initialBorderColor;
                    ddlMoisDebutEvent.BorderColor = initialBorderColor;
                    txtJourDebutEvent.BorderColor = initialBorderColor;
                    ddlHeuresDebut.BorderColor = initialBorderColor;
                    ddlMinutesDebut.BorderColor = initialBorderColor;

                    ddlAnneeFinEvent.BorderColor = initialBorderColor;
                    ddlMoisFinEvent.BorderColor = initialBorderColor;
                    txtJourFinEvent.BorderColor = initialBorderColor;
                    ddlHeuresFin.BorderColor = initialBorderColor;
                    ddlMinutesFin.BorderColor = initialBorderColor;

                    txtModifTitre.BorderColor = initialBorderColor;
                    txtEvent.BorderColor = initialBorderColor;

                    lviewEcheancier.DataBind();
                }
                else
                {
                    lblErreur.Text = listErreurs;
                    lblErreur.ForeColor = Color.Red;
                }
            }
        }

        protected void btnAjouter_Click(object sender, EventArgs e)
        {
            var listeEvenements = new List<Evenement>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                Evenement eventAjouter = new Evenement();

                bool isValid = true;
                string listErreurs = "";

                try
                {
                    int jourDebut = 1;
                    int jourFin = 1;

                    if (Int32.TryParse(txtJourDebutEventAjouter.Text, out jourDebut))
                    {
                        jourDebut = Convert.ToInt32(txtJourDebutEventAjouter.Text);
                    }
                    else
                    {
                        jourDebut = 1;
                    }

                    if (Int32.TryParse(txtJourFinEventAjouter.Text, out jourFin))
                    {
                        jourFin = Convert.ToInt32(txtJourFinEventAjouter.Text);
                    }
                    else
                    {
                        jourFin = 1;
                    }

                    DateTime dateAjoutDebut = new DateTime(Int32.Parse(ddlAnneeDebutEventAjouter.Text), Int32.Parse(ddlMoisDebutEventAjouter.Text), jourDebut, Int32.Parse(ddlHeuresDebutAjouter.Text), Int32.Parse(ddlMinutesDebutAjouter.Text), 0);
                    DateTime dateAjoutFin = new DateTime(Int32.Parse(ddlAnneeFinEventAjouter.Text), Int32.Parse(ddlMoisFinEventAjouter.Text), jourFin, Int32.Parse(ddlHeuresFinAjouter.Text), Int32.Parse(ddlMinutesFinAjouter.Text), 0);

                    DateTime datemin = DateTime.Parse("01/01/1900", new CultureInfo("en-CA"));

                    if (dateAjoutDebut < datemin)
                    {
                        listErreurs += "La date de début n'est pas valide.<br/>";
                        txtJourDebutEventAjouter.BorderColor = Color.Red;
                        ddlMoisDebutEventAjouter.BorderColor = Color.Red;
                        ddlAnneeDebutEventAjouter.BorderColor = Color.Red;
                        isValid = false;
                    }
                    else if (dateAjoutDebut < DateTime.Now.AddDays(1))
                    {

                        listErreurs += "La date de début n'est pas valide.<br/>";
                        txtJourDebutEventAjouter.BorderColor = Color.Red;
                        ddlMoisDebutEventAjouter.BorderColor = Color.Red;
                        ddlAnneeDebutEventAjouter.BorderColor = Color.Red;
                        isValid = false;
                    }

                    //Si pas de date de fin
                    if (chkbPasDateDeFinAjouter.Checked == true)
                    {
                        eventAjouter.dateFinEvenement = new DateTime(2015, 1, 1);
                    }
                    else
                    {
                        //Checker si date de fin est plus grand que début
                        if (dateAjoutDebut > dateAjoutFin)
                        {
                            listErreurs += "La date de fin n'est pas valide.<br/>";
                            txtJourFinEventAjouter.BorderColor = Color.Red;
                            ddlMoisFinEventAjouter.BorderColor = Color.Red;
                            ddlAnneeFinEventAjouter.BorderColor = Color.Red;
                            isValid = false;
                        }
                        else
                        {
                            eventAjouter.dateFinEvenement = dateAjoutFin;
                        }
                    }

                    eventAjouter.dateDebutEvenement = dateAjoutDebut;

                }
                catch (Exception)
                {
                    listErreurs += "Les date ne sont pas valide.<br/>";
                    txtJourDebutEventAjouter.BorderColor = Color.Red;
                    ddlMoisDebutEventAjouter.BorderColor = Color.Red;
                    ddlAnneeDebutEventAjouter.BorderColor = Color.Red;
                    isValid = false;
                }

                //Ajouter un minimum de 5 caracter pour un évenement
                if (txtAjoutEvenement.Text.Count() < 5)
                {
                    listErreurs += "Doit contenir une description de au moin 5 caractères.<br/>";
                    txtAjoutEvenement.BorderColor = Color.Red;
                    isValid = false;
                }

                //Ajouter un minimum de 3 caracter pour le titre
                if  (txtAjoutTitre.Text.Count() < 3)
                {
                    listErreurs += "Doit contenir un titre de au moin 3 caractères.<br/>";
                    txtAjoutTitre.BorderColor = Color.Red;
                    isValid = false;
                }

                if (isValid == true)
                {

                    try
                    {
                        Professeur profQuiAdd = new Professeur();
                        int emailProfCo = Convert.ToInt32(Request.Cookies["TIID"].Value);
                        profQuiAdd = (from cl in lecontexte.UtilisateurSet.OfType<Professeur>()
                                      where cl.IDUtilisateur == emailProfCo
                                      select cl).FirstOrDefault();

                        eventAjouter.Professeur = profQuiAdd;

                        eventAjouter.datePublication = DateTime.Now;
                        eventAjouter.descriptionEvenement = txtAjoutEvenement.Text;
                        eventAjouter.titreEvenement = txtAjoutTitre.Text;

                        listeEvenements = (from cl in lecontexte.EvenementSet select cl).ToList();
                        listeEvenements.Add(eventAjouter);

                        lecontexte.EvenementSet.Add(eventAjouter);
                        lecontexte.SaveChanges();

                        Color initialBorderColor = System.Drawing.ColorTranslator.FromHtml("#ccc");
                        ddlAnneeDebutEventAjouter.BorderColor = initialBorderColor;
                        ddlMoisDebutEventAjouter.BorderColor = initialBorderColor;
                        txtJourDebutEventAjouter.BorderColor = initialBorderColor;

                        ddlAnneeFinEventAjouter.BorderColor = initialBorderColor;
                        ddlMoisFinEventAjouter.BorderColor = initialBorderColor;
                        txtJourFinEventAjouter.BorderColor = initialBorderColor;

                        txtAjoutTitre.BorderColor = initialBorderColor;
                        txtAjoutEvenement.BorderColor = initialBorderColor;

                        lblErreur.Text = "L'événement a été ajouté.";
                        lblErreur.ForeColor = Color.Green;
                        lviewEcheancier.DataBind();
                    }
                    catch
                    {
                        lblErreur.Text = "Erreur pour enregustrer événement dans la BD, Réessayer plus tard.";
                        lblErreur.ForeColor = Color.Red;
                    }
                }
                else
                {
                    lblErreur.Text = listErreurs;
                    lblErreur.ForeColor = Color.Red;
                }
            }
        }

        protected void btnSupprimer_Click(object sender, EventArgs e)
        {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                  
                    Button btnSupprimer = (Button)sender;
                    int idEvent = Int32.Parse(btnSupprimer.CommandArgument);
                    Evenement eventTest = (from even in lecontexte.EvenementSet
                                           where even.IDEvenement == idEvent
                                           select even).FirstOrDefault();
                    lecontexte.EvenementSet.Remove(eventTest);
                    lecontexte.SaveChanges();

                    lblErreur.Text = "L'événement a été supprimé.";
                    lblErreur.ForeColor = Color.Green;

                    lviewEcheancier.DataBind();
                }
        }



        #endregion

        protected bool KnowIfNoEndDate(DateTime dateFinEvenement)
        {
            try
            {
                if (dateFinEvenement.Day == 1 && dateFinEvenement.Month == 1 && dateFinEvenement.Year == 2015)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

    }
}