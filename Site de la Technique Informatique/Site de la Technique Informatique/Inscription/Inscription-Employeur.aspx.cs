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
    public partial class Inscription_Employeur : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Cette classe permet de créer un nouveau membre Utilisateur vide pour afficher dans le listeview.
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants: aucun
        //Extrants:Utilisateur
        public Employeur GetUtilisateurEmployeur()
        {
            try
            {
                using(LeModelTIContainer leContext= new LeModelTIContainer())
                {
                    Employeur employeur = new Employeur();
                    List<Employeur> listEmployeur = (from cl in leContext.UtilisateurSet.OfType<Employeur>() select cl).ToList();

                    listEmployeur.Add(employeur);

                    return listEmployeur.Last();
                }
            }catch(Exception ex)
            {

            }
            return null;
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
                        ValidationResult vald = new ValidationResult("Les mots de passes ne match pas.", new[] { "hashMotDepasse" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }

                    //Classes validations

                    if (!isValid)
                    {
                        foreach (var ValdationResult in resultatsValidation)
                        {

                            String input = ValdationResult.MemberNames.FirstOrDefault();
                            input = input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
                            



                        }

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


                        leContext.UtilisateurSet.Add(employeurACreerCopie);
                        leContext.SaveChanges();
                        envoie_courriel_confirmation(employeurACreerCopie);

                        Response.Redirect("Inscription-message.aspx", false);
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
        public void envoie_courriel_confirmation(Employeur employeur)
        {
            // METTRE ICI LE EMAIL DE LA PERSONNE QUI VA RÉPONDRE AUX MESSAGES DES FUTURS ÉTUDIANTS 

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(employeur.courriel);

            // Informations de l'en-tête du message 
            // 1- Email de la personne qui contacte le département 
            // 2- Nom / Prénom de la personne qui contacte le département 
            mail.From = new System.Net.Mail.MailAddress(employeur.courriel, "Cegep", System.Text.Encoding.UTF8);

            // Sujet de l'email envoyé
            mail.Subject = "Inscription Employeur TI Cegep de Granby";

            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            // Email de qui provient l'email (donc va chercher l'email de la personne dans le textbox)


            // Corps du message : contient ce que la personne a écrit dans le module seulement
            hash hash = new hash();
            String hashCourriel = hash.GetSHA256Hash(employeur.dateInscription.ToString());
            String hyperLien = HttpContext.Current.Request.Url.Authority + "/Inscription/Inscription-valide.aspx?type=emp&id=" + employeur.courriel + "&code=" + hashCourriel;
            mail.Body = "Chère " + employeur.nomEmployeur + ",<br/><br/>Valider votre courriel :<a href=\"" + hyperLien + "\">cliquez ici.</a>";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.High;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("mariephilippe.gill@gmail.com", "(pap!er)");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur d'envoie de message : " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Essai d'envoi à : ");
            }


        }


    }


}