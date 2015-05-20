//Code Inscription Employeur
//Cédric Archambault
//2015-03-06

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Classes;
using Site_de_la_Technique_Informatique.Model;
using System.IO;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Site_de_la_Technique_Informatique.Inscription
{
    public partial class Inscription_Employeur : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, false, false, false, true);
        }
        //Cette classe permet de créer un nouveau membre Utilisateur vide pour afficher dans le listeview.
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants: aucun
        //Extrants:Utilisateur
        public Employeur GetUtilisateurEmployeur()
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    Employeur employeur = new Employeur();
                    List<Employeur> listEmployeur = (from cl in leContext.UtilisateurSet.OfType<Employeur>() select cl).ToList();

                    listEmployeur.Add(employeur);

                    return listEmployeur.Last();
                }
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur GetUtilisateurEmployeur : " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Essai d'envoi à : ");
            }
         
        }
        //Cette class permet de valider l'utilisateur qui est a l'écran et sauvegarder dans la BD
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants:Etudiant
        //Extrants:Aucun
        public void CreerUtilisateurEmployeur(Employeur employeurACreer)
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    Employeur employeurACreerCopie = new Employeur();
                    ListViewItem lviewItem = lviewFormulaireInscriptionEmployeur.Items[0];


                    //Validation

                    TryUpdateModel(employeurACreerCopie);
                    var contextVal = new ValidationContext(employeurACreerCopie, serviceProvider: null, items: null);
                    var resultatsValidation = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(employeurACreerCopie, contextVal, resultatsValidation, true);


                    //Nom validation
                    if (employeurACreerCopie.nomEmployeur == "" || employeurACreerCopie.nomEmployeur == null)
                    {
                        ValidationResult vald = new ValidationResult("Un nom est requis.", new[] { "nom" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    if (employeurACreerCopie.nomEmployeur != null && employeurACreerCopie.nomEmployeur.Length > 64)
                    {
                        ValidationResult vald = new ValidationResult("Le nom doit avoir moins de 64 caractères.", new[] { "nom" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    //Courriel
                    if (employeurACreerCopie.courriel == null)
                    {
                        ValidationResult vald = new ValidationResult("Le courriel est requis.", new[] { "courriel" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    bool isEmail = Regex.IsMatch(employeurACreerCopie.courriel + "", @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

                    if (employeurACreerCopie.courriel != null && (isEmail == false || employeurACreerCopie.courriel.Length > 64))
                    {
                        ValidationResult vald = new ValidationResult("Le courriel doit être valide et doit avoir moins de 64 caractères.", new[] { "courriel" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    //Comparer les mots de passe
                    TextBox txtConfirmationMotDePasse = (TextBox)lviewItem.FindControl("txtConfirmationMotDePasse");
                    if (txtConfirmationMotDePasse != null && employeurACreerCopie.hashMotDePasse != txtConfirmationMotDePasse.Text)
                    {
                        ValidationResult vald = new ValidationResult("Les mots de passe ne condordent pas.", new[] { "hashMotDepasse" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }

                    //Classes validations

                    if (!isValid)
                    {
                        //Effacer les erreurs
                        Label lblMessageValidationErreur = (Label)lviewItem.FindControl("lblMessageValidationErreur");
                        lblMessageValidationErreur.Text = "";
                        TextBox txtNom = (TextBox)lviewItem.FindControl("txtNom");
                        Label lblnom = (Label)lviewItem.FindControl("lblNomErreur");
                        lblnom.Text = "";
                        txtNom.CssClass = "form-control";
                        TextBox txtCourriel = (TextBox)lviewItem.FindControl("txtCourriel");
                        Label lblCourriel = (Label)lviewItem.FindControl("lblCourrielErreur");
                        lblCourriel.Text = "";
                        txtNom.CssClass = "form-control";
                        TextBox txtMotDePasse = (TextBox)lviewItem.FindControl("txtMotDePasse");
                        Label lblMotDePasse = (Label)lviewItem.FindControl("lblMotDePasseErreur");
                        lblMotDePasse.Text = "";
                        txtNom.CssClass = "form-control";
                        Label lblConfirmationMotDePasse = (Label)lviewItem.FindControl("lblConfirmationMotDePasseErreur");
                        lblConfirmationMotDePasse.Text = "";
                        txtConfirmationMotDePasse.CssClass = "form-control";

                        //Afficher les erreurs
                        foreach (var ValidationResult in resultatsValidation)
                        {
                            lblMessageValidationErreur.Text += ValidationResult.ErrorMessage + "<br/>";


                            if (ValidationResult.MemberNames.FirstOrDefault().Equals("nom"))
                            {
                                lblnom.Text = ValidationResult.ErrorMessage;
                                lblnom.ForeColor = Color.Red;
                                txtNom.CssClass = "form-control hash-error";
                            }
                            if (ValidationResult.MemberNames.FirstOrDefault().Equals("courriel"))
                            {
                                lblCourriel.Text = ValidationResult.ErrorMessage;
                                lblCourriel.ForeColor = Color.Red;
                                txtCourriel.CssClass = "form-control hash-error";
                            }
                            if (ValidationResult.MemberNames.FirstOrDefault().Equals("motDePasse"))
                            {
                                lblMotDePasse.Text = ValidationResult.ErrorMessage;
                                lblMotDePasse.ForeColor = Color.Red;
                                txtMotDePasse.CssClass = "form-control hash-error";
                            }
                            if (ValidationResult.MemberNames.FirstOrDefault().Equals("ConfirmationMotDePasse"))
                            {
                                lblConfirmationMotDePasse.Text = ValidationResult.ErrorMessage;
                                lblConfirmationMotDePasse.ForeColor = Color.Red;
                                txtConfirmationMotDePasse.CssClass = "form-control hash-error";
                            }

                        }
                        lblMessageValidationErreur.Visible = true;

                    }
                    else
                    {

                        //Convertir le mot de passe en hashcode
                        hash hash = new hash();
                        employeurACreerCopie.hashMotDePasse = hash.GetSHA256Hash(employeurACreerCopie.hashMotDePasse);
                        //Date inscription
                        employeurACreerCopie.dateInscription = (DateTime)DateTime.Now;

                        employeurACreerCopie.valideCourriel = false;
                        employeurACreerCopie.compteActif = false;

                        if (envoie_courriel_confirmation(employeurACreerCopie) == true)
                        {

                            leContext.UtilisateurSet.Add(employeurACreerCopie);
                            leContext.SaveChanges();

                            Response.Redirect("Inscription-message.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("Inscription-message.aspx?id=0", false);//Si le courriel ne peut être envoyer il l'envoie sur la page avec un text modifier.
                        }
                    }
                }
            }
            //Catch les erreurs de différence de la bd et du model.
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                Response.Redirect("Inscription-message.aspx?id=0", false);//Si le courriel ne peut être envoyer il l'envoie sur la page avec un text modifier.
            }
        }
        //Cette class permet des/active le bouton accepter par le checkbox
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants:sende,e
        //Extrants:Aucun
        protected void cbCondition_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                activer_bouton_Accepter();
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur Condition Checked Change : " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Essai d'envoi à : ");
            }
        }
        //Cette class permet des/active le bouton accepter par le link  Accepter
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants:sende,e
        //Extrants:Aucun
        protected void lnkAcccepter_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem lviewItem = lviewFormulaireInscriptionEmployeur.Items[0];
                CheckBox cbCondition = (CheckBox)lviewItem.FindControl("cbCondition");
                cbCondition.Checked = true;
                activer_bouton_Accepter();

            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur Accepter : " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Essai d'envoi à : ");
            }
        }
        //Cette class permet des/active le bouton accepter
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants:aucun
        //Extrants:Aucun
        protected void activer_bouton_Accepter()
        {
            ListViewItem lviewItem = lviewFormulaireInscriptionEmployeur.Items[0];
            CheckBox cbCondition = (CheckBox)lviewItem.FindControl("cbCondition");
            LinkButton lnkEnvoyer = (LinkButton)lviewItem.FindControl("lnkEnvoyer");
            if (cbCondition.Checked == true)
            {
                lnkEnvoyer.Enabled = true;
                lnkEnvoyer.CssClass = "btn btn-primary";
            }
            else
            {
                lnkEnvoyer.Enabled = false;
                lnkEnvoyer.CssClass = "btn btn-default";
            }
        }
        //Cette class permet d'envoyer un courriel de confirmation de l'inscription.
        //Écrit par Cédric Archambault 18 février 2015
        //Intrants:Etudiant
        //Extrants:Aucun
        public bool envoie_courriel_confirmation(Employeur employeur)
        {
            hash hash = new hash();

            String hashCourriel = employeur.dateInscription.GetHashCode().ToString();
            String hyperLien = "http://sqlinfo.cegepgranby.qc.ca/projetdeux_2015_1/Inscription-valide.aspx?type=emp&id=" + employeur.courriel + "&code=" + hashCourriel;
            String titre = "Inscription TI Cegep de Granby";
            String message= "Cher/chère " + employeur.nomEmployeur + ",<br/><br/>Merci de votre inscription sur le site de la technique informatique du Cégep de Granby, Cliquez sur le lien ci-dessous pour valider votre compte<br><a href=\"" + hyperLien + "\">cliquez ici.</a>";

            courrielAutomatiser courriel = new courrielAutomatiser();

            return courriel.envoie(employeur.courriel, titre, message);

        }


    }


}