//code C# page d'inscription
//Écrit par Cédric Archambault
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using Site_de_la_Technique_Informatique.Classes;


namespace Site_de_la_Technique_Informatique.Inscription
{
    public partial class Inscription : ErrorHandling
    {

        //Recolte des erreurs des champs du formulaire.
        #region Js
        String _idsEnErreurTab;
        public String idsEnErreurTab
        {
            get { return _idsEnErreurTab; }

            set { _idsEnErreurTab = value; }
        }
        public List<String> idsEnErreur = new List<string>();
        public List<String> msgsEnErreur = new List<string>();
        public List<String> panneauxEnErreur = new List<string>();

        //Url de la photo du profil
     
        #endregion
        protected void Page_Load()
        {
            SavoirSiPossedeAutorizationPourLaPage(false, false, false, false, true);
        }

        //Cette classe permet de créer un nouveau membre Utilisateur vide pour afficher dans le listeview.
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants: aucun
        //Extrants:Utilisateur
        public Etudiant GetUtilisateurEtudiant()
        {

            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    List<Etudiant> listEtudiant = (from cl in leContext.UtilisateurSet.OfType<Etudiant>() select cl).ToList();
                    Etudiant nouveauEtudiant = new Etudiant();
                    listEtudiant.Add(nouveauEtudiant);


                    return listEtudiant.Last();
                }
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur GetUtilisateurEtudiant: " + ex.ToString() + " Inner exception de l'erreur: " + logEx.InnerException + " Essai d'envoi à: ");
            }
         
        }
        //Cette class permet de valider l'utilisateur qui est a l'écran et sauvegarder dans la BD
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants:Etudiant
        //Extrants:Aucun
        public void CreerUtilisateurEtudiant(Etudiant etudiantACreer)
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    Etudiant etudiantACreerCopie = new Etudiant();
                    ListViewItem lviewItem = lviewFormulaireInscription.Items[0];

                    //Valider la date de naissance
                    TextBox txtDateNaissanceJour = (TextBox)lviewItem.FindControl("txtDateNaissanceJour");
                    TextBox txtDateNaissanceMois = (TextBox)lviewItem.FindControl("txtDateNaissanceMois");
                    TextBox txtDateNaissanceAnnee = (TextBox)lviewItem.FindControl("txtDateNaissanceAnnee");

                    String strDateNaissance = txtDateNaissanceAnnee.Text + "/" + txtDateNaissanceMois.Text + "/" + txtDateNaissanceJour.Text;

                    DateTime dateNaissance;
                    DateTime.TryParse(strDateNaissance, out dateNaissance);
                    etudiantACreerCopie.dateNaissance = (DateTime)dateNaissance;
                    //Validation

                    TryUpdateModel(etudiantACreerCopie);
                    var contextVal = new ValidationContext(etudiantACreerCopie, serviceProvider: null, items: null);
                    var resultatsValidation = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(etudiantACreerCopie, contextVal, resultatsValidation, true);

                    //Pénom validation
                    if (etudiantACreerCopie.prenom == "" || etudiantACreerCopie.prenom == null)
                    {
                        ValidationResult vald = new ValidationResult("Le prénom est requis.", new[] { "Prenom" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    if (etudiantACreerCopie.prenom != null && etudiantACreerCopie.prenom.Length > 32)
                    {
                        ValidationResult vald = new ValidationResult("Le prénom doit avoir moins de 32 caractères.", new[] { "Prenom" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    //Nom validation
                    if (etudiantACreerCopie.nom == "" || etudiantACreerCopie.nom == null)
                    {
                        ValidationResult vald = new ValidationResult("Un nom est requis.", new[] { "Nom" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    if (etudiantACreerCopie.nom != null && etudiantACreerCopie.nom.Length > 32)
                    {
                        ValidationResult vald = new ValidationResult("Le nom doit avoir moins de 32 caractères.", new[] { "Nom" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    //Courriel
                    if (etudiantACreerCopie.courriel == null)
                    {
                        ValidationResult vald = new ValidationResult("Le courriel est requis.", new[] { "Courriel" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    bool isEmail = Regex.IsMatch(etudiantACreerCopie.courriel + "", @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

                    if (etudiantACreerCopie.courriel != null && (isEmail == false || etudiantACreerCopie.courriel.Length > 64))
                    {
                        ValidationResult vald = new ValidationResult("Le courriel doit être valide et doit avoir moins de 64 caractères.", new[] { "Courriel" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    //Vérifier si le courriel existe.
                    Utilisateur utilisateurExistant = (from cl in leContext.UtilisateurSet where cl.courriel.Equals(etudiantACreerCopie.courriel) select cl).FirstOrDefault();
                    if(utilisateurExistant!=null)
                    {
                        ValidationResult vald = new ValidationResult("Un membre ayant se courriel existe déjà.", new[] { "Courriel" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    //Comparer les mots de passe
                    TextBox txtConfirmationMotDePasse = (TextBox)lviewItem.FindControl("txtConfirmationMotDePasse");
                    if (txtConfirmationMotDePasse != null && etudiantACreerCopie.hashMotDePasse != txtConfirmationMotDePasse.Text)
                    {
                        ValidationResult vald = new ValidationResult("Les mots de passe ne correspondent pas.", new[] { "MotDePasse" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }

                    //Classes validations

                    if (!isValid)
                    {
                        Label lblMessage = (Label)lviewItem.FindControl("lblMessage");
                        lblMessage.Text = "";
                        foreach (var ValdationResult in resultatsValidation)
                        {
                            
                            lblMessage.Text += ValdationResult.ErrorMessage + "<br/>";
                            String input = ValdationResult.MemberNames.FirstOrDefault();
                            input = input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
                            idsEnErreur.Add(input);
                            msgsEnErreur.Add(ValdationResult.ErrorMessage);
                            lblMessage.ForeColor = Color.Red;


                        }

                        idsEnErreurTab = JsonConvert.SerializeObject(idsEnErreur);
                    }
                    else
                    {
                        //Sauvegarder image du profil
                        String imgData = ImgExSrc.Value;
                        if (imgData != "" && imgData.Length>21 && imgData.Substring(0, 21).Equals("data:image/png;base64"))
                        {
                            System.Drawing.Image imageProfil = LoadImage(imgData);
                            imageProfil = (System.Drawing.Image)new Bitmap(imageProfil, new Size(125, 125)); //prevention contre injection de trop grande image.

                            String imageNom = (etudiantACreerCopie.prenom + etudiantACreerCopie.dateInscription.ToString()).GetHashCode() + "_125.jpg";
                            String imageProfilChemin = Path.Combine(Server.MapPath("~//Upload//Photos//Profils//"), imageNom);
                            imageProfil.Save(imageProfilChemin);
                            etudiantACreerCopie.pathPhotoProfil = imageNom;
                        }
                        else// sion photo par défault
                        {
                            etudiantACreerCopie.pathPhotoProfil = "photobase.bmp";
                        }
                        //Convertir le mot de passe en hashcode
                        hash hash = new hash();
                        etudiantACreerCopie.hashMotDePasse = hash.GetSHA256Hash(etudiantACreerCopie.hashMotDePasse);
                        //Date inscription
                        etudiantACreerCopie.dateInscription = (DateTime)DateTime.Now;
                        etudiantACreerCopie.courriel = etudiantACreerCopie.courriel.ToLower();
                        etudiantACreerCopie.valideCourriel = false;
                        etudiantACreerCopie.compteActif = 0;
                        etudiantACreerCopie.pathCV = "";

                        if (envoie_courriel_confirmation(etudiantACreerCopie) == true)
                        {
                            leContext.UtilisateurSet.Add(etudiantACreerCopie);
                            leContext.SaveChanges();
                            Response.Redirect("Inscription-message.aspx", false);
                        }
                        else
                        {

                            Response.Redirect("Inscription-message.aspx?id=0", false);
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

                        Label lblMessage = (Label)lviewFormulaireInscription.Items[0].FindControl("lblMessage");
                        lblMessage.Text = message;
                        lblMessage.ForeColor = Color.Red;
                    }
                }
                throw raise;
            }
            catch (Exception ex)
            {
                Response.Redirect("Inscription-message.aspx?id=0", false);
                Exception logEx = ex;
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
                throw new Exception("Erreur Condition CheckedChanged: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "");
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
                ListViewItem lviewItem = lviewFormulaireInscription.Items[0];
                CheckBox cbCondition = (CheckBox)lviewItem.FindControl("cbCondition");
                cbCondition.Checked = true;
                activer_bouton_Accepter();

            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur Accepter Click: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Essai d'envoi à : ");
            }
        }
        //Cette class permet des/active le bouton accepter
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants:aucun
        //Extrants:Aucun
        protected void activer_bouton_Accepter()
        {
            ListViewItem lviewItem = lviewFormulaireInscription.Items[0];
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
        public bool envoie_courriel_confirmation(Etudiant etudiant)
        {
            hash hash = new hash();

            String hashCourriel = etudiant.courriel.GetHashCode().ToString();
            String hyperLien = Convert.ToString(HttpContext.Current.Request.Url.AbsoluteUri).Replace("Inscription-Etudiant.aspx", "Inscription-valide.aspx?type=etu&id=" + etudiant.courriel + "&code=" + hashCourriel);
            String titre = "Inscription TI Cégep de Granby";
            String message = "Cher/Chère " + etudiant.prenom + " " + etudiant.nom + ",<br/><br/>Merci de votre inscription sur le site de techniques informatique du Cégep de Granby, cliquez sur le lien ci-dessous pour valider votre compte<br>"+"<a href=\"" + hyperLien + "\">cliquez ici.</a>";

            courrielAutomatiser courriel = new courrielAutomatiser();

            return courriel.envoie(etudiant.courriel,titre,message);

        }

        //Cette class permet de convertir data/jpeg à image.
        //Écrit par Cédric Archambault 26 février 2015
        //Intrants:String Data
        //Extrants:Image
        public System.Drawing.Image LoadImage(String data)
        {
            //get a temp image from bytes, instead of loading from disk
            //data:image/gif;base64,
            //this image is a single pixel (black)
            //byte[] bytes = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw==");
            data = data.Remove(0, 22);
            byte[] bytes = Convert.FromBase64String(data);
            System.Drawing.Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = System.Drawing.Image.FromStream(ms);
                string cropFileName = "";
                string cropFilePath = "";
                cropFileName = "crop_" + "testImg";
                cropFilePath = Path.Combine(Server.MapPath("~//Upload//Photos//Profils//"), cropFileName);
            }

            return image;
        }

        protected void lnkAnnuler_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.UrlReferrer.ToString());
        }


    }


}