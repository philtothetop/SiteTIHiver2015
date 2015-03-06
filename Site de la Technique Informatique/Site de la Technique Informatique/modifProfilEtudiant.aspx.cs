// Page qui permet aux étudiants de modifier leur profil (photo de profil, nom, prénom, date de naissance, mot de passe)
// Écrit par Marie-Philippe Gill, Février 2015

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
    public partial class modifProfilEtudiant : System.Web.UI.Page
    {
        // va contenir le courriel modifié 
        string courrielModifie = "";

        #region Évènements de la page
        protected void Page_Load(object sender, EventArgs e)
        {
            // Pour tests seulement pendant que la connexion était non fonctionnelle !! à enlever 
            Session["Courriel"] = "philippe@bibeau.com";
            // fin de la partie pour test à effacer
        }
        #endregion

        #region Évènements du lvModifProfilEtudiant
        public Etudiant SelectEtudiant()
        {
            Etudiant etudiantCo = null;

            string courriel = Session["Courriel"].ToString();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                try
                {
                    etudiantCo = (from etu in lecontexte.UtilisateurSet.OfType<Etudiant>() where etu.courriel == courriel select etu).FirstOrDefault();
                   
                   
                }
                catch (Exception ex)
                {
                    Label lblMessage = (Label)lvModifProfilEtudiant.Items[0].FindControl("lblMessage");
                    lblMessage.Text += "ERREUR AVEC LE MEMBRE, " + ex.ToString();
                }
            return etudiantCo;
        }

        // Met à jour l'étudiant
        public void UpdateEtudiant(Etudiant etudiantAUpdater)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                Etudiant etudiantAUpdaterCopie = new Etudiant();

                // contient le courriel de départ de l'étudiant (avant qu'il ne soit modifié)
                string courrielDeBase = Session["Courriel"].ToString();

                // contient le nouveau courriel modifié de l'étudiant
                TextBox txtCourriel = (TextBox) lvModifProfilEtudiant.Items[0].FindControl("txtCourriel");
                courrielModifie = txtCourriel.Text;

                //Valider la date de naissance
                TextBox txtDateNaissanceJour = (TextBox)lvModifProfilEtudiant.Items[0].FindControl("txtDateNaissanceJour");
                TextBox txtDateNaissanceMois = (TextBox)lvModifProfilEtudiant.Items[0].FindControl("txtDateNaissanceMois");
                TextBox txtDateNaissanceAnnee = (TextBox)lvModifProfilEtudiant.Items[0].FindControl("txtDateNaissanceAnnee");

                String strDateNaissance = txtDateNaissanceAnnee.Text + "/" + txtDateNaissanceMois.Text + "/" + txtDateNaissanceJour.Text;

                DateTime dateNaissance;
                DateTime.TryParse(strDateNaissance, out dateNaissance);
                etudiantAUpdaterCopie.dateNaissance = (DateTime)dateNaissance;
                //Validation

                TryUpdateModel(etudiantAUpdaterCopie);
                var contextVal = new ValidationContext(etudiantAUpdaterCopie, serviceProvider: null, items: null);
                var resultatsValidation = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(etudiantAUpdaterCopie, contextVal, resultatsValidation, true);

                //Pénom validation
                if (etudiantAUpdaterCopie.prenom == "" || etudiantAUpdaterCopie.prenom == null)
                {
                    ValidationResult vald = new ValidationResult("Le prénom est requis.", new[] { "nom" });
                    isValid = false;
                    resultatsValidation.Add(vald);
                }
                if (etudiantAUpdaterCopie.prenom != null && etudiantAUpdaterCopie.prenom.Length > 64)
                {
                    ValidationResult vald = new ValidationResult("Le prénom doit avoir moins de 64 caractères.", new[] { "nom" });
                    isValid = false;
                    resultatsValidation.Add(vald);
                }
                //Nom validation
                if (etudiantAUpdaterCopie.nom == "" || etudiantAUpdaterCopie.nom == null)
                {
                    ValidationResult vald = new ValidationResult("Un nom est requis.", new[] { "nom" });
                    isValid = false;
                    resultatsValidation.Add(vald);
                }
                if (etudiantAUpdaterCopie.nom != null && etudiantAUpdaterCopie.nom.Length > 64)
                {
                    ValidationResult vald = new ValidationResult("Le nom doit avoir moins de 64 caractères.", new[] { "nom" });
                    isValid = false;
                    resultatsValidation.Add(vald);
                }
                //Courriel
                if (etudiantAUpdaterCopie.courriel == null)
                {
                    ValidationResult vald = new ValidationResult("Le courriel est requis.", new[] { "courriel" });
                    isValid = false;
                    resultatsValidation.Add(vald);
                }
                bool isEmail = Regex.IsMatch(etudiantAUpdaterCopie.courriel + "", @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);

                if (etudiantAUpdaterCopie.courriel != null && (isEmail == false || etudiantAUpdaterCopie.courriel.Length > 64))
                {
                    ValidationResult vald = new ValidationResult("Le courriel doit être valide et doit avoir moins de 64 caractères.", new[] { "courriel" });
                    isValid = false;
                    resultatsValidation.Add(vald);
                }
                //Comparer les mots de passe
                TextBox txtConfirmationMotDePasse = (TextBox)lvModifProfilEtudiant.Items[0].FindControl("txtConfirmationMotDePasse");
                if (txtConfirmationMotDePasse != null && etudiantAUpdaterCopie.hashMotDePasse != txtConfirmationMotDePasse.Text)
                {
                    ValidationResult vald = new ValidationResult("Les mots de passes ne match pas.", new[] { "hashMotDepasse" });
                    isValid = false;
                    resultatsValidation.Add(vald);
                }
                // Va chercher le bon étudiant car le courriel pourrait avoir été changé
                etudiantAUpdaterCopie = (lecontexte.UtilisateurSet.OfType<Membre>().OfType<Etudiant>().SingleOrDefault(m => m.courriel == courrielDeBase));
                Label lblMessage = (Label)lvModifProfilEtudiant.Items[0].FindControl("lblMessage");
             
                if (!isValid) // NON VALIDE
                {
                    foreach (var validationResult in resultatsValidation)
                    {
                        
                        lblMessage.Text += validationResult.ErrorMessage+"<br/>";
                    }
                }
                else // VALIDE
                {
                    lblMessage.Text = "";
                    try
                    {
                        //Sauvegarder image du profil
                        String imgData = ImgExSrc.Value;
                        if (imgData != "" && imgData.Length > 21 && imgData.Substring(0, 21).Equals("data:image/png;base64"))
                        {
                            System.Drawing.Image imageProfil = LoadImage(imgData);
                            imageProfil = (System.Drawing.Image)new Bitmap(imageProfil, new Size(125, 125)); //prevention contre injection de trop grande image.

                            String imageNom = (etudiantAUpdaterCopie.prenom + etudiantAUpdaterCopie.dateInscription.ToString()).GetHashCode() + "_125.jpg";
                            String imageProfilChemin = Path.Combine(Server.MapPath("~/Photos/Profils/"), imageNom);
                            if (!etudiantAUpdaterCopie.pathPhotoProfil.Equals("photobase.bmp"))
                            { 
                            File.Delete("~/Photos/Profils/" + etudiantAUpdaterCopie.pathPhotoProfil);//Efface l'ancienne photo.
                            }
                            imageProfil.Save(imageProfilChemin);
                            
                            etudiantAUpdaterCopie.pathPhotoProfil = imageNom;
                        }

                        lecontexte.SaveChanges();
                        Response.Redirect("modifProfilEtudiant.aspx",false);
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
                        throw new InvalidOperationException("Une erreur s'est produite lors de la mise à jour de l'étudiant." + ex.ToString());
                    }

                }
            }

        }
        #endregion
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
                cropFilePath = Path.Combine(Server.MapPath("~/Photos/Profils/"), cropFileName);
            }

            return image;
        }

        // Le nom du paramètre id doit correspondre à la valeur DataKeyNames définie sur le contrôle
        public void lvModifProfilEtudiant_DeleteItem(int id)
        {
            try
            {
                using(LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    Etudiant etudiant = (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where cl.IDEtudiant==id select cl).FirstOrDefault();
                    etudiant.compteActif = false;
                    leContext.SaveChanges();
                }
            }catch(Exception ex)
            {

            }
        }

      
    }
}