using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class AjoutOffreEmploi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDescriptionOffre.Attributes.Add("maxlength", txtDescriptionOffre.MaxLength.ToString());

                for (int i = 0; i < 2; i++)
                {
                    ListItem listItem = new ListItem();

                    DateTime date = DateTime.Now.AddYears(i);
                    string annee = date.Year.ToString();
                    listItem.Text = annee;
                    listItem.Value = annee;
                    ddlAnneeExpiration.Items.Insert(i + 1, listItem);
                    ddlAnneeDebut.Items.Insert(i + 1, listItem);
                }
            }
        }

        protected void lnkAjouter_Click(object sender, EventArgs e)
        {

            Boolean enErreur = false;

            lblErreur.Text = "";
            lblTitreOffre.Text = "";
            lblDescriptionOffre.Text = "";
            lblDateExpiration.Text = "";
            lblDebut.Text = "";
            lblSalaire.Text = "";
            lblHeures.Text = "";
            lblAdresse.Text = "";
            lblVille.Text = "";
            lblTelephonePoste.Text = "";
            lblTelecopieur.Text = "";
            lblCourriel.Text = "";
            lblRessource.Text = "";
            lblPDF.Text = "";

            txtTitreOffre.BorderColor = Color.LightGray;
            txtDescriptionOffre.BorderColor = Color.LightGray;
            txtJourExpiration.BorderColor = Color.LightGray;
            txtMoisExpiration.BorderColor = Color.LightGray;
            ddlAnneeExpiration.BorderColor = Color.LightGray;
            txtJourDebut.BorderColor = Color.LightGray;
            txtMoisDebut.BorderColor = Color.LightGray;
            ddlAnneeDebut.BorderColor = Color.LightGray;
            txtSalaire.BorderColor = Color.LightGray;
            txtHeures.BorderColor = Color.LightGray;
            txtAdresse.BorderColor = Color.LightGray;
            txtVille.BorderColor = Color.LightGray;
            txtTelephone.BorderColor = Color.LightGray;
            txtposte.BorderColor = Color.LightGray;
            txtTelecopieur.BorderColor = Color.LightGray;
            txtCourriel.BorderColor = Color.LightGray;
            txtRessource.BorderColor = Color.LightGray;
            fuPDF.Attributes.Add("border-color", "#FFD3D3D3");

            if (txtTitreOffre.Text == "")
            {
                lblTitreOffre.Text = "Poste requis";
                txtTitreOffre.BorderColor = Color.Red;
                enErreur = true;
            }

            if (txtDescriptionOffre.Text == "")
            {
                lblDescriptionOffre.Text = "Description de l'offre requise";
                txtDescriptionOffre.BorderColor = Color.Red;
                enErreur = true;
            }

            if (txtJourExpiration.Text != "" || txtMoisExpiration.Text != "" || ddlAnneeExpiration.SelectedIndex != 0)
            {
                try
                {
                    DateTime dateExpiration = DateTime.Parse(txtJourExpiration.Text + "/" + txtMoisExpiration.Text + "/" + ddlAnneeExpiration.Text, new CultureInfo("en-CA"));

                    DateTime datemin = DateTime.Parse("01/01/1900", new CultureInfo("en-CA"));

                    if (dateExpiration < datemin)
                    {
                        lblDateExpiration.Text += "Date d'expiration de l'offre invalide";
                        txtJourExpiration.BorderColor = Color.Red;
                        txtMoisExpiration.BorderColor = Color.Red;
                        ddlAnneeExpiration.BorderColor = Color.Red;
                        enErreur = true;
                    }
                    else if (dateExpiration < DateTime.Now.AddDays(1) || dateExpiration > DateTime.Now.AddYears(1))
                    {

                        lblDateExpiration.Text += "La date d'expiration doit être d'ici un an et à partir de demain";
                        txtJourExpiration.BorderColor = Color.Red;
                        txtMoisExpiration.BorderColor = Color.Red;
                        ddlAnneeExpiration.BorderColor = Color.Red;
                        enErreur = true;
                    }
                }
                catch (Exception)
                {
                    lblDateExpiration.Text += "Date d'exipration de l'offre invalide";
                    txtJourExpiration.BorderColor = Color.Red;
                    txtMoisExpiration.BorderColor = Color.Red;
                    ddlAnneeExpiration.BorderColor = Color.Red;
                    enErreur = true;
                }
            }

            if (txtJourDebut.Text == "" || txtMoisDebut.Text == "" || ddlAnneeDebut.SelectedIndex == 0)
            {
                lblDebut.Text = "Date de début de l'emploi requise";
                txtJourDebut.BorderColor = Color.Red;
                txtMoisDebut.BorderColor = Color.Red;
                ddlAnneeDebut.BorderColor = Color.Red;
                enErreur = true;
            }
            else
            {
                try
                {
                    DateTime dateDebut = DateTime.Parse(txtJourDebut.Text + "/" + txtMoisDebut.Text + "/" + ddlAnneeDebut.Text, new CultureInfo("en-CA"));

                    DateTime datemin = DateTime.Parse("01/01/1900", new CultureInfo("en-CA"));

                    if (dateDebut < datemin)
                    {
                        lblDebut.Text += "Date de début de l'emploi invalide";
                        txtJourDebut.BorderColor = Color.Red;
                        txtMoisDebut.BorderColor = Color.Red;
                        ddlAnneeDebut.BorderColor = Color.Red;
                        enErreur = true;
                    }
                    else if (dateDebut < DateTime.Now.AddDays(1) || dateDebut > DateTime.Now.AddYears(1))
                    {

                        lblDebut.Text += "La date de début de l'emploi doit être d'ici un an et à partir de demain";
                        txtJourDebut.BorderColor = Color.Red;
                        txtMoisDebut.BorderColor = Color.Red;
                        ddlAnneeDebut.BorderColor = Color.Red;
                        enErreur = true;
                    }
                }
                catch (Exception)
                {
                    lblDateExpiration.Text += "Date de début de l'emploi invalide";
                    txtJourExpiration.BorderColor = Color.Red;
                    txtMoisExpiration.BorderColor = Color.Red;
                    ddlAnneeExpiration.BorderColor = Color.Red;
                    enErreur = true;
                }
            }

            Double d;
            if (txtSalaire.Text == "")
            {
                lblSalaire.Text = "Salaire requis";
                txtSalaire.BorderColor = Color.Red;
                enErreur = true;
            }
            else if (Double.TryParse(txtSalaire.Text, out d) == false)
            {
                lblSalaire.Text = "Salaire invalide (Utilisez la virgule pour les décimals)";
                txtSalaire.BorderColor = Color.Red;
                enErreur = true;
            }
            else if (Double.Parse(txtSalaire.Text) > 99)
            {
                lblSalaire.Text = "Salaire trop élevé";
                txtSalaire.BorderColor = Color.Red;
                enErreur = true;
            }

            int i;
            if (txtHeures.Text == "")
            {
                lblHeures.Text = "Nombre d'heures par semaine requis";
                txtHeures.BorderColor = Color.Red;
                enErreur = true;
            }
            else if (Int32.TryParse(txtHeures.Text, out i) == false)
            {
                lblHeures.Text = "Nombre d'heures par semaine invalid";
                txtHeures.BorderColor = Color.Red;
                enErreur = true;
            }
            else if (Int32.Parse(txtHeures.Text) > 60)
            {
                lblHeures.Text = "Nombre d'heures par semaine trop élevé";
                txtHeures.BorderColor = Color.Red;
                enErreur = true;
            }

            if (txtAdresse.Text == "")
            {
                lblAdresse.Text = "Adresse requise";
                txtAdresse.BorderColor = Color.Red;
                enErreur = true;
            }

            if (enErreur == false)
            {

            }
            else
            {
                lblErreur.Text = "Veuillez corriger les champs en erreur";
            }
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count, string contextKey) //Auto-complete de Ajax
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                List<Ville> listeVille = null;
                listeVille = (from ville in lecontexte.VilleSet select ville).ToList();
                List<string> listeRecherche = new List<string>();

                foreach (Ville ville in listeVille)
                {
                    bool villeLa = false;
                    string villeNom = (ville.nomVille).ToLower();
                    villeLa = listeRecherche.Any(item => item.Contains(villeNom));
                    if (villeLa == false)
                    {
                        string villeAdd = villeNom.First().ToString().ToUpper() + String.Join("", villeNom.Skip(1));
                        listeRecherche.Add(villeAdd);
                    }
                }

                String[] listeRetour = (from resultat in listeRecherche where resultat.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) select resultat).Take(count).ToArray();
                return listeRetour;
            }
        }
    }
}