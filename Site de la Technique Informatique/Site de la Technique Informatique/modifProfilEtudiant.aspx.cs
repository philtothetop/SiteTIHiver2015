// Page qui permet aux étudiants de modifier leur profil (photo de profil, nom, prénom, date de naissance, mot de passe)
// Écrit par Cédric Archambault  et un peut par Marie-Philippe Gill, Février 2015

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
    public partial class modifProfilEtudiant : ErrorHandling
    {
        // va contenir le courriel modifié 
        string courrielModifie = "";

        #region Évènements de la page
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(true, false, true, false);
        }
        #endregion

        #region Évènements du lvModifProfilEtudiant
        public Etudiant SelectEtudiant()
        {
            Etudiant etudiantCo = null;


       
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                try
                {
                    String courriel = "";
                    //Chercher l'utilisateur
                    courriel = Request.Cookies["TICourriel"].Value;

                    etudiantCo = (from etu in lecontexte.UtilisateurSet.OfType<Etudiant>() where etu.courriel == courriel select etu).FirstOrDefault();


                }
                catch (Exception ex)
                {
                    LogErreur("modifProfilEtudiant-erreur-SelectEtudiant", ex);
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
                String courriel = "";
                //Chercher l'utilisateur
                courriel = Request.Cookies["TICourriel"].Value;


                Etudiant etudiantAUpdaterCopie = (lecontexte.UtilisateurSet.OfType<Membre>().OfType<Etudiant>().SingleOrDefault(m => m.courriel == courriel)); ;

                // contient le nouveau courriel modifié de l'étudiant
                TextBox txtCourriel = (TextBox)lvModifProfilEtudiant.Items[0].FindControl("txtCourriel");
                courrielModifie = txtCourriel.Text;

                //Validation

                var resultatsValidation = new List<ValidationResult>();
                var isValid = true;

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
                //Vérifier si l'utilisateur modifit sont mot de passe.
                TextBox txtMotDePasse = (TextBox)lvModifProfilEtudiant.Items[0].FindControl("txtMotDePasse");
                TextBox txtNouveauMotDePasse = (TextBox)lvModifProfilEtudiant.Items[0].FindControl("txtNouveauMotDePasse");
                TextBox txtConfirmationNouveauMotDePasse = (TextBox)lvModifProfilEtudiant.Items[0].FindControl("txtConfirmationNouveauMotDePasse");

                if (txtMotDePasse.Text != "" || txtNouveauMotDePasse.Text != "" || txtMotDePasse.Text != "")
                {
                    //Vérifier si le mot de passe les valide.
                    hash hash = new hash();
                    String strHashMotDePassehash = hash.GetSHA256Hash(txtMotDePasse.Text);
                    if (txtMotDePasse.Text == "" || !etudiantAUpdaterCopie.hashMotDePasse.Equals(strHashMotDePassehash))
                    {
                        ValidationResult vald = new ValidationResult("Le mot de passe n'est pas valide.", new[] { "MotDepasse" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    if (txtNouveauMotDePasse.Text == "")
                    {
                        ValidationResult vald = new ValidationResult("Le nouveau mot de passe ne doit pas être vide.", new[] { "hashMotDepasse" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    if (txtNouveauMotDePasse.Text.Length < 4)
                    {
                        ValidationResult vald = new ValidationResult("Le nouveau mot de passe est trop court.", new[] { "hashMotDepasse" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                    //Comparer les mots de passe
                    if (txtNouveauMotDePasse.Text != txtConfirmationNouveauMotDePasse.Text)
                    {
                        ValidationResult vald = new ValidationResult("Les mots de passes ne match pas.", new[] { "hashMotDepasse" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                }
                //CV upload
                FileUpload fupCV = (FileUpload)lvModifProfilEtudiant.Items[0].FindControl("fupCV");
                if (fupCV.HasFile)
                {
                    String extension = fupCV.FileName.Substring(fupCV.FileName.LastIndexOf('.') + 1).ToLower();

                    if (extension.Equals("pdf") || extension.Equals("docx") || extension.Equals("doc") || extension.Equals("odf"))
                    {

                    }
                    else
                    {
                        ValidationResult vald = new ValidationResult("Le C.V. n'a pas une extension  valide.", new[] { "CV" });
                        isValid = false;
                        resultatsValidation.Add(vald);
                    }
                }

                Label lblMessage = (Label)lvModifProfilEtudiant.Items[0].FindControl("lblMessage");

                if (!isValid) // NON VALIDE
                {
                    lblMessage.Text = "";
                    foreach (var validationResult in resultatsValidation)
                    {

                        lblMessage.Text += validationResult.ErrorMessage + "<br/>";
                    }
                }
                else // VALIDE
                {

                    lblMessage.Text = "";
                    //CV upload
                    if (fupCV.HasFile)
                    {
                        try
                        {
                            String AdresseCV = "";
                            if (etudiantAUpdaterCopie.pathCV != "")
                            {
                                AdresseCV = Server.MapPath("/Upload/CV/" + etudiantAUpdaterCopie.pathCV);
                                File.Delete(AdresseCV);//Efface l'ancien CV.
                            }
                            //Ajouter path CV et saugarder.
                            String extension = fupCV.FileName.Substring(fupCV.FileName.LastIndexOf('.') + 1).ToLower();
                            String date = DateTime.Now.ToString("dd MM yyyy");
                            date.Replace("/", "-");
                            String CVNom = etudiantAUpdaterCopie.prenom + "_" + etudiantAUpdaterCopie.nom + "_CV_" + date + "." + extension;
                            AdresseCV = Server.MapPath("/Upload/CV/" + CVNom);
                            etudiantAUpdaterCopie.pathCV = CVNom;
                            fupCV.SaveAs(AdresseCV);
                        }
                        catch (Exception ex)
                        {
                            etudiantAUpdaterCopie.pathCV = "";
                            lblMessage.Text = "Erreur de la sauvegarde du CV.";
                            LogErreur("ModifProfilEtudiant-SauvegardeCV", ex);
                        }

                    }
                    try
                    {

                        //Changer le mot de passe.
                        if (txtMotDePasse.Text != "")
                        {
                            hash hash = new hash();
                            etudiantAUpdaterCopie.hashMotDePasse = hash.GetSHA256Hash(txtNouveauMotDePasse.Text);
                        }
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
                                String AdressePhoto = Server.MapPath("/Photos/Profils/" + etudiantAUpdaterCopie.pathPhotoProfil);
                                File.Delete(AdressePhoto);//Efface l'ancienne photo.
                            }
                            imageProfil.Save(imageProfilChemin);

                            etudiantAUpdaterCopie.pathPhotoProfil = imageNom;
                        }

                        lecontexte.SaveChanges();
                        Response.Redirect("modifProfilEtudiant.aspx", false);
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
                        LogErreur("modifProfilEtudiant-erreur-update-Profil", ex);
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
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    Etudiant etudiant = (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where cl.IDEtudiant == id select cl).FirstOrDefault();
                    etudiant.compteActif = false;
                    leContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}