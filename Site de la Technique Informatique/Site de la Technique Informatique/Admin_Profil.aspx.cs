using Newtonsoft.Json;
using Site_de_la_Technique_Informatique.Classes;
using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_motDePasse : ErrorHandling
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

        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(true, false, false, false, false);
        }

        public Utilisateur SelectAdmin()
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                try
                {

                    Utilisateur admin = (from etu in lecontexte.UtilisateurSet where etu.IDUtilisateur == 1 select etu).FirstOrDefault();
                    return admin;
                }
                catch (Exception ex)
                {
                    LogErreur("modifProfilAdmin-erreur-SelectAdmin", ex);
                }
                return null;
            }
        }

        public void UpdateAdmin(Utilisateur admin)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                
                TextBox txtCourriel = (TextBox)lvModifProfilAdmin.Items[0].FindControl("txtCourriel");
                TextBox txtMotDePasse = (TextBox)lvModifProfilAdmin.Items[0].FindControl("txtMotDePasse");
                TextBox txtNouveauMotDePasse = (TextBox)lvModifProfilAdmin.Items[0].FindControl("txtNouveauMotDePasse");
                TextBox txtConfirmationNouveauMotDePasse = (TextBox)lvModifProfilAdmin.Items[0].FindControl("txtConfirmationNouveauMotDePasse");

                Utilisateur adminAUpdaterCopie = (from etu in lecontexte.UtilisateurSet where etu.IDUtilisateur == 1 select etu).FirstOrDefault();

                //Validation

                var resultatsValidation = new List<ValidationResult>();
                var isValid = true;

                if (txtMotDePasse.Text != "" || txtNouveauMotDePasse.Text != "" || txtMotDePasse.Text != "")
                {
                    //Vérifier si le mot de passe les valide.
                    hash hash = new hash();
                    String strHashMotDePassehash = hash.GetSHA256Hash(txtMotDePasse.Text);
                    if (txtMotDePasse.Text == "" || !adminAUpdaterCopie.hashMotDePasse.Equals(strHashMotDePassehash))
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

                    Label lblMessage = (Label)lvModifProfilAdmin.Items[0].FindControl("lblMessage");

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

                    }
                    else // VALIDE
                    {
                        try
                        {
                            //Changer le mot de passe.
                            if (txtMotDePasse.Text != "")
                            {
                                hash hash2 = new hash();
                                adminAUpdaterCopie.hashMotDePasse = hash2.GetSHA256Hash(txtNouveauMotDePasse.Text);

                                lecontexte.SaveChanges();
                                Response.Redirect("Admin_Default.aspx", false);
                            }

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
                            LogErreur("Admin_Profil-erreur-update-Profil", ex);
                            throw new InvalidOperationException("Une erreur s'est produite lors de la mise à jour de l'Admin." + ex.ToString());
                        }
                    }
                }
            }
        }
    }
}