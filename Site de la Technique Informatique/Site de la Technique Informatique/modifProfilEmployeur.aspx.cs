// Page qui permet aux employeurs de modifier leur profil (photo de profil, nom, prénom, date de naissance, mot de passe)
// Écrit par Cédric Archambault  et un peut par Marie-Philippe Gill, Février 2015

using Newtonsoft.Json;
using Site_de_la_Technique_Informatique.Classes;
using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class modifProfilEmployeur : ErrorHandling
    {
        //Collect les erreurs de validation
        String _idsEnErreurTab;
        public String idsEnErreurTab
        {
            get { return _idsEnErreurTab; }

            set { _idsEnErreurTab = value; }
        }
        public List<String> idsEnErreur = new List<string>();
        public List<String> msgsEnErreur = new List<string>();
        public List<String> panneauxEnErreur = new List<string>();


        #region Évènements de la page
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(true, false, false, true, false);
        }
        #endregion

        #region Évènements du lvModifProfilEmployeur
        public Employeur SelectEmployeur()
        {
            Employeur EmployeurCo = null;



            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                try
                {
                    String strIDUtilisateur = "";

                    if (Request.Cookies["TIUtilisateur"].Value.Equals("Admin"))//Si c'est un Admin
                    {
                        //Si le query EmployeurId exist
                        if (Request.QueryString["id"] != null)
                        {
                            int idEmployeur = 0;

                            if (int.TryParse(Request.QueryString["id"].ToString(), out idEmployeur))
                            {
                                EmployeurCo = (from etu in lecontexte.UtilisateurSet.OfType<Employeur>() where etu.IDEmployeur == idEmployeur select etu).FirstOrDefault();
                            }
                            else //Retourne un Employeur null et affiche un message.
                            {
                                EmployeurCo = null;
                                Label lblMessage = (Label)lvModifProfilEmployeur.Items[0].FindControl("lblMessage");
                                lblMessage.Text += "L'id de l'entreprise n'existe pas.";
                            }
                        }
                    }
                    else
                    {
                        //Chercher l'utilisateur
                        strIDUtilisateur = Request.Cookies["TIID"].Value;
                        int IDUtilisateur = int.Parse(strIDUtilisateur);

                        EmployeurCo = (from etu in lecontexte.UtilisateurSet.OfType<Employeur>() where etu.IDUtilisateur == IDUtilisateur select etu).FirstOrDefault();
                    }

                }
                catch (Exception ex)
                {
                    LogErreur("modifProfilEmployeur-erreur-SelectEmployeur", ex);
                    Label lblMessage = (Label)lvModifProfilEmployeur.Items[0].FindControl("lblMessage");
                    lblMessage.Text += "ERREUR AVEC LE MEMBRE, " + ex.ToString();
                }
            return EmployeurCo;
        }

        // Met à jour l'employeur
        public void UpdateEmployeur(Employeur EmployeurAUpdater)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                //Vérifier si l'utilisateur modifit sont mot de passe.
                TextBox txtNom = (TextBox)lvModifProfilEmployeur.Items[0].FindControl("txtNom");
                TextBox txtCourriel = (TextBox)lvModifProfilEmployeur.Items[0].FindControl("txtCourriel");
                TextBox txtMotDePasse = (TextBox)lvModifProfilEmployeur.Items[0].FindControl("txtMotDePasse");
                TextBox txtNouveauMotDePasse = (TextBox)lvModifProfilEmployeur.Items[0].FindControl("txtNouveauMotDePasse");
                TextBox txtConfirmationNouveauMotDePasse = (TextBox)lvModifProfilEmployeur.Items[0].FindControl("txtConfirmationNouveauMotDePasse");
                //Chercher l'utilisateur
                String strIDUtilisateur = Request.Cookies["TIID"].Value;

                int IDUtilisateur;

                if(Request.QueryString["id"]!=null)
                {
                    IDUtilisateur = int.Parse(Request.QueryString["id"]);
                }
                else
                {
                    IDUtilisateur = int.Parse(strIDUtilisateur);
                }



                Employeur EmployeurAUpdaterCopie = (from etu in lecontexte.UtilisateurSet.OfType<Employeur>() where etu.IDUtilisateur == IDUtilisateur select etu).FirstOrDefault();


                //Validation

                var resultatsValidation = new List<ValidationResult>();
                var isValid = true;
                //Validation Nom de l'employeur
                EmployeurAUpdaterCopie.nomEmployeur = txtNom.Text;
                if (EmployeurAUpdaterCopie.nomEmployeur == null || EmployeurAUpdaterCopie.nomEmployeur == "")
                {
                    ValidationResult vald = new ValidationResult("Le nom de l'entreprise est requis.", new[] { "Nom" });
                    isValid = false;
                    resultatsValidation.Add(vald);
                }
                if (EmployeurAUpdaterCopie.nomEmployeur.Length>64)
                {
                    ValidationResult vald = new ValidationResult("Le nom de l'entreprise moins de 64 caractères..", new[] { "Nom" });
                    isValid = false;
                    resultatsValidation.Add(vald);
                }
                //Courriel
                EmployeurAUpdaterCopie.courriel = txtCourriel.Text;
                if (EmployeurAUpdaterCopie.courriel == null || EmployeurAUpdaterCopie.courriel == "")
                {
                    ValidationResult vald = new ValidationResult("Le courriel est requis.", new[] { "Courriel" });
                    isValid = false;
                    resultatsValidation.Add(vald);
                }
                bool isEmail = Regex.IsMatch(EmployeurAUpdaterCopie.courriel + "", @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

                if (EmployeurAUpdaterCopie.courriel.Length > 64)
                {
                    ValidationResult vald = new ValidationResult("Le courriel doit être valide et doit avoir moins de 64 caractères.", new[] { "Courriel" });
                    isValid = false;
                    resultatsValidation.Add(vald);
                }

                if (txtMotDePasse.Text != "" || txtNouveauMotDePasse.Text != "" || txtMotDePasse.Text != "")
                {
                    //Vérifier si le mot de passe les valide.
                    hash hash = new hash();
                    String strHashMotDePassehash = hash.GetSHA256Hash(txtMotDePasse.Text);
                    if (txtMotDePasse.Text == "" || !EmployeurAUpdaterCopie.hashMotDePasse.Equals(strHashMotDePassehash))
                    {
                        ValidationResult vald = new ValidationResult("Le mot de passe n'est pas valide.", new[] { "MotDePasse" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    if (txtNouveauMotDePasse.Text == "")
                    {
                        ValidationResult vald = new ValidationResult("Le nouveau mot de passe ne doit pas être vide.", new[] { "NouveauMotDePasse" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    if (txtNouveauMotDePasse.Text.Length < 4)
                    {
                        ValidationResult vald = new ValidationResult("Le nouveau mot de passe doit être plus grand que 4 caractères.", new[] { "NouveauMotDePasse" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    //Comparer les mots de passe
                    if (txtNouveauMotDePasse.Text != txtConfirmationNouveauMotDePasse.Text)
                    {

                        ValidationResult vald = new ValidationResult("Les mots de passes ne correspondent pas.", new[] { "NouveauMotDePasse" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                }
               

                Label lblMessage = (Label)lvModifProfilEmployeur.Items[0].FindControl("lblMessage");

                if (!isValid) // NON VALIDE
                {
                    lblMessage.Text = "";
                    foreach (var ValidationResult in resultatsValidation)
                    {

                        String input = ValidationResult.MemberNames.FirstOrDefault();
                        input = input.First().ToString().ToUpper() + String.Join("", input.Skip(1));

                        idsEnErreur.Add(input);
                        msgsEnErreur.Add(ValidationResult.ErrorMessage);
                        lblMessage.Text += ValidationResult.ErrorMessage + "<br/>";

                    }

                    idsEnErreurTab = JsonConvert.SerializeObject(idsEnErreur);
                    foreach (var validationResult in resultatsValidation)
                    {


                    }
                }
                else // VALIDE
                {

                    lblMessage.Text = "";
                   
                    try
                    {

                        //Changer le mot de passe.
                        if (txtMotDePasse.Text != "")
                        {
                            hash hash = new hash();
                            EmployeurAUpdaterCopie.hashMotDePasse = hash.GetSHA256Hash(txtNouveauMotDePasse.Text);
                        }
                        
                        lecontexte.SaveChanges();

                        Response.Redirect("~", false);
                         
                    }
                    catch (DbEntityValidationException ex) // D'AUTRES ERREURS PEUVENT SURVENIR QUI N'ONT PAS ÉTÉ PRÉVUE VIA DATAANNOTATIONS.
                    {
                        foreach (DbEntityValidationResult failure in ex.EntityValidationErrors)
                        {
                            foreach (DbValidationError lerror in failure.ValidationErrors)
                            {
                                lblMessage.Text += string.Format("{0} : {1}", lerror.PropertyName, lerror.ErrorMessage);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogErreur("modifProfilEmployeur-erreur-update-Profil", ex);
                        throw new InvalidOperationException("Une erreur s'est produite lors de la mise à jour de l'employeur." + ex.ToString());
                    }

                }
            }

        }
        #endregion

    }
}