using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using Site_de_la_Technique_Informatique.Classes;
using System.Text.RegularExpressions;

namespace Site_de_la_Technique_Informatique
{
    public partial class AjoutOffreEmploi : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SavoirSiPossedeAutorizationPourLaPage(false, false, false, true);

            txtDescriptionOffre.Attributes.Add("maxlength", txtDescriptionOffre.MaxLength.ToString());
            if (!IsPostBack)
            {            
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

                if (Session["IDOffreEmploiModifier"] != null)
                {
                    Model.OffreEmploi offreEmploi;
                    using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                    {

                        int idOffre = Int32.Parse(Session["IDOffreEmploiModifier"].ToString());

                        offreEmploi = (from offresEmploi in lecontexte.OffreEmploiSet
                                       where offresEmploi.IDOffreEmploi == idOffre
                                       select offresEmploi).FirstOrDefault();

                        txtTitreOffre.Text = offreEmploi.titreOffre;
                        txtDescriptionOffre.Text = offreEmploi.descriptionOffre;

                        if (offreEmploi.dateExpiration != null)
                        {
                            string dateExpiration = offreEmploi.dateExpiration.ToString();
                            txtJourExpiration.Text = dateExpiration.Substring(8, 2);
                            txtMoisExpiration.Text = dateExpiration.Substring(5, 2);
                            ddlAnneeExpiration.SelectedValue = dateExpiration.Substring(0, 4);
                        }

                        string dateDebut = offreEmploi.dateDebutOffre.ToString();
                        txtJourDebut.Text = dateDebut.Substring(8, 2);
                        txtMoisDebut.Text = dateDebut.Substring(5, 2);
                        ddlAnneeDebut.SelectedValue = dateDebut.Substring(0, 4);

                        txtSalaire.Text = offreEmploi.salaire.ToString();
                        txtHeures.Text = offreEmploi.nbHeureSemaine.ToString();
                        txtAdresse.Text = offreEmploi.adresseTravail;
                        txtVille.Text = offreEmploi.Ville.nomVille;
                        txtTelephone.Text = offreEmploi.noTelephone;
                        if (offreEmploi.noPoste != null)
                        {
                            txtposte.Text = offreEmploi.noPoste;
                        }
                        if (offreEmploi.noTelecopieur != null)
                        {
                            txtTelecopieur.Text = offreEmploi.noTelecopieur;
                        }
                        txtCourriel.Text = offreEmploi.courrielOffre;
                        txtRessource.Text = offreEmploi.personneRessource;
                    }
                }
            }

            if (fuPDF.HasFile)
            {
                Session["fuPDF"] = fuPDF;
                lblNomPDF.Text = "Fichier sélectioné: " + fuPDF.FileName;
                lnkRetirerPDF.Visible = true;
            }
        }

        protected void lnkAjouter_Click(object sender, EventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                int nbErreurs = 0;
                int idVille = 0;

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
                fuPDF.BorderColor = Color.LightGray;

                if (txtTitreOffre.Text == "")
                {
                    lblTitreOffre.Text = "Poste requis";
                    txtTitreOffre.BorderColor = Color.Red;
                    nbErreurs++;
                }
                else if (txtTitreOffre.Text.Length < 5)
                {
                    lblTitreOffre.Text = "Le poste est trop court";
                    txtTitreOffre.BorderColor = Color.Red;
                    nbErreurs++;
                }

                if (txtDescriptionOffre.Text == "")
                {
                    lblDescriptionOffre.Text = "Description de l'offre requise";
                    txtDescriptionOffre.BorderColor = Color.Red;
                    nbErreurs++;
                }
                else if (txtDescriptionOffre.Text.Length < 5)
                {
                    lblDescriptionOffre.Text = "La description est trop courte";
                    txtDescriptionOffre.BorderColor = Color.Red;
                    nbErreurs++;
                }

                if (txtJourExpiration.Text != "" || txtMoisExpiration.Text != "" || ddlAnneeExpiration.SelectedIndex != 0)
                {
                    try
                    {
                        DateTime dateExpiration = DateTime.Parse(txtJourExpiration.Text + "/" + txtMoisExpiration.Text + "/" + ddlAnneeExpiration.Text, new CultureInfo("en-CA"));

                        DateTime datemin = DateTime.Parse("01/01/1900", new CultureInfo("en-CA"));

                        if (dateExpiration < datemin)
                        {
                            lblDateExpiration.Text = "Date d'expiration de l'offre invalide";
                            txtJourExpiration.BorderColor = Color.Red;
                            txtMoisExpiration.BorderColor = Color.Red;
                            ddlAnneeExpiration.BorderColor = Color.Red;
                            nbErreurs++;
                        }
                        else if (dateExpiration < DateTime.Now.AddDays(1) || dateExpiration > DateTime.Now.AddYears(1))
                        {

                            lblDateExpiration.Text = "Date d'exipration de l'offre invalide";
                            txtJourExpiration.BorderColor = Color.Red;
                            txtMoisExpiration.BorderColor = Color.Red;
                            ddlAnneeExpiration.BorderColor = Color.Red;
                            nbErreurs++;
                        }
                    }
                    catch (Exception)
                    {
                        lblDateExpiration.Text = "Date d'exipration de l'offre invalide";
                        txtJourExpiration.BorderColor = Color.Red;
                        txtMoisExpiration.BorderColor = Color.Red;
                        ddlAnneeExpiration.BorderColor = Color.Red;
                        nbErreurs++;
                    }
                }

                if (txtJourDebut.Text == "" || txtMoisDebut.Text == "" || ddlAnneeDebut.SelectedIndex == 0)
                {
                    lblDebut.Text = "Date de début de l'emploi requise";
                    txtJourDebut.BorderColor = Color.Red;
                    txtMoisDebut.BorderColor = Color.Red;
                    ddlAnneeDebut.BorderColor = Color.Red;
                    nbErreurs++;
                }
                else
                {
                    try
                    {
                        DateTime dateDebut = DateTime.Parse(txtJourDebut.Text + "/" + txtMoisDebut.Text + "/" + ddlAnneeDebut.Text, new CultureInfo("en-CA"));

                        DateTime datemin = DateTime.Parse("01/01/1900", new CultureInfo("en-CA"));

                        if (dateDebut < datemin)
                        {
                            lblDebut.Text = "Date de début de l'emploi invalide";
                            txtJourDebut.BorderColor = Color.Red;
                            txtMoisDebut.BorderColor = Color.Red;
                            ddlAnneeDebut.BorderColor = Color.Red;
                            nbErreurs++;
                        }
                        else if (dateDebut < DateTime.Now.AddDays(1) || dateDebut > DateTime.Now.AddYears(1))
                        {

                            lblDebut.Text = "Date de début de l'emploi invalide";
                            txtJourDebut.BorderColor = Color.Red;
                            txtMoisDebut.BorderColor = Color.Red;
                            ddlAnneeDebut.BorderColor = Color.Red;
                            nbErreurs++;
                        }
                    }
                    catch (Exception)
                    {
                        lblDateExpiration.Text = "Date de début de l'emploi invalide";
                        txtJourExpiration.BorderColor = Color.Red;
                        txtMoisExpiration.BorderColor = Color.Red;
                        ddlAnneeExpiration.BorderColor = Color.Red;
                        nbErreurs++;
                    }
                }

                Double d;
                if (txtSalaire.Text == "")
                {
                    lblSalaire.Text = "Salaire requis";
                    txtSalaire.BorderColor = Color.Red;
                    nbErreurs++;
                }
                else if (Double.TryParse(txtSalaire.Text, out d) == false)
                {
                    lblSalaire.Text = "Salaire invalide (Utilisez la virgule pour les décimals)";
                    txtSalaire.BorderColor = Color.Red;
                    nbErreurs++;
                }
                else if (Double.Parse(txtSalaire.Text) > 99)
                {
                    lblSalaire.Text = "Salaire trop élevé";
                    txtSalaire.BorderColor = Color.Red;
                    nbErreurs++;
                }

                int i;
                if (txtHeures.Text == "")
                {
                    lblHeures.Text = "Nombre d'heures par semaine requis";
                    txtHeures.BorderColor = Color.Red;
                    nbErreurs++;
                }
                else if (Int32.TryParse(txtHeures.Text, out i) == false)
                {
                    lblHeures.Text = "Nombre d'heures par semaine invalid";
                    txtHeures.BorderColor = Color.Red;
                    nbErreurs++;
                }
                else if (Int32.Parse(txtHeures.Text) > 60)
                {
                    lblHeures.Text = "Nombre d'heures par semaine trop élevé";
                    txtHeures.BorderColor = Color.Red;
                    nbErreurs++;
                }

                if (txtAdresse.Text == "")
                {
                    lblAdresse.Text = "Adresse requise";
                    txtAdresse.BorderColor = Color.Red;
                    nbErreurs++;
                }
                else if (txtAdresse.Text.Length < 5)
                {
                    lblAdresse.Text = "L'adresse est trop courte";
                    txtAdresse.BorderColor = Color.Red;
                    nbErreurs++;
                }

                if (txtVille.Text == "")
                {
                    lblVille.Text = "Ville requise";
                    txtVille.BorderColor = Color.Red;
                    nbErreurs++;
                }
                else
                {
                    string villeEntre = FormaterChaine.formaterChaine(txtVille.Text).ToLower().Trim();
                    string villeRecherche = "";
                    bool trouve = false;
                    foreach (Ville ville in lecontexte.VilleSet)
                    {
                        villeRecherche = FormaterChaine.formaterChaine(ville.nomVille).ToLower().Trim();
                        if (villeRecherche == villeEntre)
                        {
                            idVille = ville.IDVille;
                            trouve = true;
                        }
                    }
                    if (trouve == false)
                    {
                        lblVille.Text = "Ville invalide";
                        txtVille.BorderColor = Color.Red;
                        nbErreurs++;
                    }
                }
                if (txtTelephone.Text == "")
                {
                    lblTelephonePoste.Text = "Téléphone requis";
                    txtTelephone.BorderColor = Color.Red;
                    nbErreurs++;
                }
                else
                {
                    string reg = @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$";

                    if (!Regex.IsMatch(txtTelephone.Text, reg))
                    {
                        lblTelephonePoste.Text = "Téléphone invalide";
                        txtTelephone.BorderColor = Color.Red;
                        nbErreurs++;
                    }
                }

                if (txtposte.Text != "" && Int32.TryParse(txtposte.Text, out i) == false)
                {
                    if (lblTelephonePoste.Text == "")
                    {
                        lblTelephonePoste.Text = "Poste invalide";
                    }
                    else
                    {
                        lblTelephonePoste.Text = lblTelephonePoste.Text + " et poste invalide";
                    }

                    txtposte.BorderColor = Color.Red;
                    nbErreurs++;
                }

                if (txtTelecopieur.Text != "")
                {
                    string reg = @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$";

                    if (!Regex.IsMatch(txtTelecopieur.Text, reg))
                    {
                        lblTelecopieur.Text = "Télécopieur invalide";
                        txtTelecopieur.BorderColor = Color.Red;
                        nbErreurs++;
                    }
                }

                if (txtCourriel.Text != "")
                {
                    try
                    {
                        var addr = new System.Net.Mail.MailAddress(txtCourriel.Text);
                    }
                    catch (Exception)
                    {
                        lblCourriel.Text += "Courriel invalide";
                        txtCourriel.BorderColor = Color.Red;
                        nbErreurs++;
                    }
                }
                else
                {
                    lblCourriel.Text += "Courriel requis";
                    txtCourriel.BorderColor = Color.Red;
                    nbErreurs++;
                }

                if (txtRessource.Text == "")
                {
                    lblRessource.Text += "Personne ressource requise";
                    txtRessource.BorderColor = Color.Red;
                    nbErreurs++;
                }
                else if (txtRessource.Text.Length < 5)
                {
                    lblRessource.Text = "Le nom de la personne ressource est trop court";
                    txtRessource.BorderColor = Color.Red;
                    nbErreurs++;
                }

                fuPDF = (FileUpload)Session["fuPDF"];
                string newFile = "";
                if (fuPDF != null)
                {
                    string fileNameApplication = System.IO.Path.GetFileName(fuPDF.FileName);
                    string ext = System.IO.Path.GetExtension(fileNameApplication);
                    newFile = Guid.NewGuid().ToString() + ext;
                    string[] allowedExtenstions = new string[] { ".pdf" };

                    if (Session["fuPDF"] != null)
                    {

                        if (fuPDF.HasFile)
                        {

                            if (!allowedExtenstions.Contains(ext))
                            {
                                fuPDF.BorderColor = Color.Red;
                                lblPDF.Text = "Le fichier doit être un PDF";
                                nbErreurs++;
                            }
                            else if (fuPDF.PostedFile.ContentLength > 2000000)
                            {
                                lblPDF.Text = "Le PDF doit peser 2 Mo au maximum";
                                fuPDF.BorderColor = Color.Red;
                                nbErreurs++;
                            }

                            Session["fuPDF"] = fuPDF;
                        }
                    }
                }

                if (nbErreurs == 1)
                {
                    lblErreur.Text = "Veuillez corriger le champ en erreur";
                }
                else if (nbErreurs > 1)
                {
                    lblErreur.Text = "Veuillez corriger les " + nbErreurs + " champs en erreur";
                }
                else
                {
                    try
                    {
                        string SaveLocation = System.IO.Path.Combine(Server.MapPath("") + "\\Upload\\", newFile);

                        if (Session["IDOffreEmploiModifier"] != null)
                        {
                            Model.OffreEmploi offreEmploiAModfier;
                            int idOffre = Int32.Parse(Session["IDOffreEmploiModifier"].ToString());

                            offreEmploiAModfier = (from offresEmploi in lecontexte.OffreEmploiSet
                                                   where offresEmploi.IDOffreEmploi == idOffre
                                                   select offresEmploi).FirstOrDefault();

                            offreEmploiAModfier.titreOffre = txtTitreOffre.Text;
                            offreEmploiAModfier.descriptionOffre = txtDescriptionOffre.Text;
                            offreEmploiAModfier.dateOffre = DateTime.Now;

                            if (txtJourExpiration.Text != "")
                            {
                                offreEmploiAModfier.dateExpiration = DateTime.Parse(txtJourExpiration.Text + "/" + txtMoisExpiration.Text + "/" + ddlAnneeExpiration.Text, new CultureInfo("en-CA"));
                            }

                            offreEmploiAModfier.dateDebutOffre = DateTime.Parse(txtJourDebut.Text + "/" + txtMoisDebut.Text + "/" + ddlAnneeDebut.Text, new CultureInfo("en-CA"));
                            if (Session["fuPDF"] != null)
                            {
                                fuPDF = (FileUpload)Session["fuPDF"];
                                fuPDF.PostedFile.SaveAs(SaveLocation);
                                offreEmploiAModfier.pathPDFDescription = newFile;
                            }
                            offreEmploiAModfier.salaire = decimal.Parse(txtSalaire.Text);
                            offreEmploiAModfier.nbHeureSemaine = short.Parse(txtHeures.Text);
                            offreEmploiAModfier.adresseTravail = txtAdresse.Text;
                            offreEmploiAModfier.noTelephone = txtTelephone.Text;
                            offreEmploiAModfier.noTelecopieur = txtTelecopieur.Text;
                            offreEmploiAModfier.courrielOffre = txtCourriel.Text;
                            offreEmploiAModfier.personneRessource = txtRessource.Text;
                            offreEmploiAModfier.etatOffre = "1";
                            offreEmploiAModfier.noPoste = txtposte.Text;
                            offreEmploiAModfier.validerOffre = false;
                            offreEmploiAModfier.VilleIDVille = idVille;
                            int idUtilisateur = Int32.Parse(Server.HtmlEncode(Request.Cookies["TIID"].Value));
                            Employeur employeur = (from employeurs in lecontexte.UtilisateurSet.OfType<Employeur>()
                                                   where employeurs.IDUtilisateur == idUtilisateur
                                                   select employeurs).FirstOrDefault();
                            offreEmploiAModfier.Employeur = employeur;
                            offreEmploiAModfier.EmployeurIDUtilisateur = idUtilisateur;

                            Ville ville = (from villes in lecontexte.VilleSet
                                           where villes.IDVille == idVille
                                           select villes).FirstOrDefault();
                            offreEmploiAModfier.Ville = ville;

                            Session["IDOffreEmploiModifier"] = null;
                        }
                        else
                        {

                            Model.OffreEmploi offreEmploi = new Model.OffreEmploi();
                            Model.OffreEmploi derniereoffre = lecontexte.OffreEmploiSet.OrderByDescending(u => u.IDOffreEmploi).FirstOrDefault();

                            if (derniereoffre == null)
                            {
                                offreEmploi.IDOffreEmploi = 1;
                            }
                            else
                            {
                                offreEmploi.IDOffreEmploi = derniereoffre.IDOffreEmploi + 1;
                            }


                            offreEmploi.titreOffre = txtTitreOffre.Text;
                            offreEmploi.descriptionOffre = txtDescriptionOffre.Text;
                            offreEmploi.dateOffre = DateTime.Now;

                            if (txtJourExpiration.Text != "")
                            {
                                offreEmploi.dateExpiration = DateTime.Parse(txtJourExpiration.Text + "/" + txtMoisExpiration.Text + "/" + ddlAnneeExpiration.Text, new CultureInfo("en-CA"));
                            }

                            offreEmploi.dateDebutOffre = DateTime.Parse(txtJourDebut.Text + "/" + txtMoisDebut.Text + "/" + ddlAnneeDebut.Text, new CultureInfo("en-CA"));
                            if (Session["fuPDF"] != null)
                            {
                                fuPDF = (FileUpload)Session["fuPDF"];
                                fuPDF.PostedFile.SaveAs(SaveLocation);
                                offreEmploi.pathPDFDescription = newFile;
                            }
                            offreEmploi.salaire = decimal.Parse(txtSalaire.Text);
                            offreEmploi.nbHeureSemaine = short.Parse(txtHeures.Text);
                            offreEmploi.adresseTravail = txtAdresse.Text;
                            offreEmploi.noTelephone = txtTelephone.Text;
                            offreEmploi.noTelecopieur = txtTelecopieur.Text;
                            offreEmploi.courrielOffre = txtCourriel.Text;
                            offreEmploi.personneRessource = txtRessource.Text;
                            offreEmploi.etatOffre = "1";
                            offreEmploi.noPoste = txtposte.Text;
                            offreEmploi.validerOffre = false;
                            offreEmploi.VilleIDVille = idVille;
                            int idUtilisateur = Int32.Parse(Server.HtmlEncode(Request.Cookies["TIID"].Value));
                            Employeur employeur = (from employeurs in lecontexte.UtilisateurSet.OfType<Employeur>()
                                                   where employeurs.IDUtilisateur == idUtilisateur
                                                   select employeurs).FirstOrDefault();
                            offreEmploi.Employeur = employeur;
                            offreEmploi.EmployeurIDUtilisateur = idUtilisateur;

                            Ville ville = (from villes in lecontexte.VilleSet
                                           where villes.IDVille == idVille
                                           select villes).FirstOrDefault();
                            offreEmploi.Ville = ville;

                            lecontexte.OffreEmploiSet.Add(offreEmploi);
                        }

                        Model.Log log = new Model.Log(); //crée une entrée de log
                        log.dateLog = DateTime.Now; //on met la date du jour
                        log.typeLog = 0; //connexion est de type 0
                        log.actionLog = "L'utilisateur no " + Int32.Parse(Server.HtmlEncode(Request.Cookies["TIID"].Value)) + " a ajouté/modifié une offre d'emploi";
                        lecontexte.LogSet.Add(log); //on ajoute au log

                        lecontexte.SaveChanges();


                        mvAjoutOffre.SetActiveView(viewFin);

                    }
                    catch (Exception ex)
                    {

                        lblErreur.Text = "Erreur lors de l'ajout de l'offre";
                    }

                }
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

        protected void lnkRetirerPDF_Click(object sender, EventArgs e)
        {
            Session["fuPDF"] = null;
            lblNomPDF.Text = "";
            lnkRetirerPDF.Visible = false;
        }
    }
}