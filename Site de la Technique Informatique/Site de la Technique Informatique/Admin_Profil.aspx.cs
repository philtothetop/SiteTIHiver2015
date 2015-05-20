using Newtonsoft.Json;
using Site_de_la_Technique_Informatique.Classes;
using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Drawing;
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

        public Model.Admin SelectAdmin()
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                try
                {
                    Model.Admin admin = (from etu in lecontexte.UtilisateurSet.OfType<Model.Admin>() select etu).FirstOrDefault();
                    return admin;
                }
                catch (Exception ex)
                {
                    LogErreur("modifProfilAdmin-erreur-SelectAdmin", ex);
                }
                return null;
            }
        }

        public void UpdateAdmin(Admin admin)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                TextBox txtMotDePasse = (TextBox)lvModifProfilAdmin.Items[0].FindControl("txtMotDePasse");
                TextBox txtNouveauMotDePasse = (TextBox)lvModifProfilAdmin.Items[0].FindControl("txtNouveauMotDePasse");
                TextBox txtConfirmationNouveauMotDePasse = (TextBox)lvModifProfilAdmin.Items[0].FindControl("txtConfirmationNouveauMotDePasse");

                Model.Admin adminAUpdaterCopie = (from etu in lecontexte.UtilisateurSet.OfType<Model.Admin>() select etu).FirstOrDefault();

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
                    if (!txtNouveauMotDePasse.Text.Equals(txtConfirmationNouveauMotDePasse.Text))
                    {

                        ValidationResult vald = new ValidationResult("Les mots de passes ne correspondent pas.", new[] { "NouveauMotDePasse" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }

                    if (!isValid) // NON VALIDE
                    {
                        lblMessageAAfficher.Text = "";
                        foreach (var ValidationResult in resultatsValidation)
                        {

                            String input = ValidationResult.MemberNames.FirstOrDefault();
                            input = input.First().ToString().ToUpper() + String.Join("", input.Skip(1));

                            idsEnErreur.Add(input);
                            msgsEnErreur.Add(ValidationResult.ErrorMessage);
                            lblMessageAAfficher.Text += ValidationResult.ErrorMessage + "<br/>";
                            lblMessageAAfficher.ForeColor = Color.Red;
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
                                lblMessageAAfficher.Text = "Mot de passe modifié avec succes";
                                lblMessageAAfficher.ForeColor = Color.Green;
                                txtConfirmationNouveauMotDePasse.Text = "";
                                txtMotDePasse.Text = "";
                                txtNouveauMotDePasse.Text = "";
                            }

                        }
                        catch (DbEntityValidationException ex) // D'AUTRES ERREURS PEUVENT SURVENIR QUI N'ONT PAS ÉTÉ PRÉVUE VIA DATAANNOTATIONS.
                        {
                            foreach (DbEntityValidationResult failure in ex.EntityValidationErrors)
                            {
                                foreach (DbValidationError lerror in failure.ValidationErrors)
                                {
                                    lblMessageAAfficher.Text += string.Format("{0} : {1}", lerror.PropertyName, lerror.ErrorMessage);
                                }
                            }
                            lblMessageAAfficher.ForeColor = Color.Red;
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