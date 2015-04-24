using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_AjoutPhoto : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cookies["TIID"].Value = "2";
            //SavoirSiPossedeAutorizationPourLaPage(false, true, false, false);
        }

        protected void btnajouterAutreImage_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_AjoutPhoto");
        }


        //---------------------------------------------------------------
        //V2 POUR SAUVEGARDER PHOTO
        //Uploader une photo dans PhotoProfil
        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (LeModelTIContainer modelTI = new LeModelTIContainer())
        //        {
        //            Model.Professeur leProfCo = new Model.Professeur();
        //            leProfCo = null;

        //            //Récupérer la personne connecté
        //            if (Request.Cookies["TIID"] != null)
        //            {
        //                if (Server.HtmlEncode(Request.Cookies["TIID"].Value) != null)
        //                {
        //                    int leId = Convert.ToInt32(Server.HtmlEncode(Request.Cookies["TIID"].Value));

        //                    leProfCo = (from cl in modelTI.UtilisateurSet.OfType<Professeur>()
        //                                where cl.IDUtilisateur == leId
        //                                select cl).FirstOrDefault();

        //                    //Si le prof connecté est trouvé
        //                    if (leProfCo != null)
        //                    {
        //                        //VERSION 2 TEST DE FILE UPLOAD
        //                        FileUpload fuplPhoto = (FileUpload)lviewAjouterUneImage.Items[0].FindControl("fuplPhoto");
        //                        Label lblEchecImage = (Label)lviewAjouterUneImage.Items[0].FindControl("lblEchecImage");

        //                        //Si le fileupload n'est pas vide
        //                        if (fuplPhoto.HasFile)
        //                        {
        //                            if (Path.GetExtension(fuplPhoto.PostedFile.FileName.ToLower()) == ".jpg" || Path.GetExtension(fuplPhoto.PostedFile.FileName.ToLower()) == ".png" || Path.GetExtension(fuplPhoto.PostedFile.FileName.ToLower()) == ".jpeg")
        //                            {
        //                                try
        //                                {
        //                                    System.Drawing.Image imageAAjouter = System.Drawing.Image.FromStream(fuplPhoto.PostedFile.InputStream);

        //                                    //Grosseur max est de 1000 px et minimum 120 px
        //                                    imageAAjouter = ResizeTheImage(1000, 120, imageAAjouter);

        //                                    String imageNom = (leProfCo.nom + DateTime.Now.ToString()).GetHashCode() + "_521.jpg";
        //                                    String imageProfilChemin = Path.Combine(Server.MapPath("~/Photos/" + ddlTypeDImage.SelectedValue.ToString() + "/"), imageNom);
        //                                    imageAAjouter.Save(imageProfilChemin);

        //                                    //Sauvegarder image pour utiliser avec la bd
        //                                    Model.Photos laPhotoBD = new Model.Photos();
        //                                    laPhotoBD.pathPhoto = imageNom;
        //                                    laPhotoBD.typePhoto = ddlTypeDImage.SelectedItem.Text;

        //                                    //Faire un log pour l'action
        //                                    Model.Log logPhoto = new Model.Log();
        //                                    logPhoto.actionLog = leProfCo.prenom + " " + leProfCo.nom + " vien d'ajouter une photos sur le serveur pour : " + ddlTypeDImage.SelectedValue.ToString() + ".";
        //                                    logPhoto.dateLog = DateTime.Now;
        //                                    logPhoto.typeLog = 0;
        //                                    logPhoto.Utilisateur = leProfCo;

        //                                    modelTI.PhotosSet.Add(laPhotoBD);
        //                                    modelTI.LogSet.Add(logPhoto);
        //                                    modelTI.SaveChanges();

        //                                    //Indiquer que cela a marché
        //                                    divReussiAjouterImage.Visible = true;
        //                                    divPasReussiAjouterImage.Visible = false;
        //                                    divPourAjouterUnePhoto.Visible = false;

        //                                    lblEchecImage.Text = "";
        //                                }
        //                                catch (Exception ex)
        //                                {
        //                                    lblEchecImage.Text = "Upload de l'image à échoué";
        //                                }
        //                            }
        //                            else 
        //                            {
        //                                divPasReussiAjouterImage.Visible = true;
        //                                lblPasReussi.Text = "Mauvais format de l'image";
        //                            }
        //                        }
        //                        else
        //                        {
        //                            divPasReussiAjouterImage.Visible = true;
        //                            lblPasReussi.Text = "Image impossible à ajouter.";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        divPasReussiAjouterImage.Visible = true;
        //                        lblPasReussi.Text = "Veuillez-vous reconnecter.";
        //                    }
        //                }
        //                else
        //                {
        //                    divPasReussiAjouterImage.Visible = true;
        //                    lblPasReussi.Text = "Veuillez-vous reconnecter.";
        //                }
        //            }
        //            else
        //            {
        //                Response.Redirect("Default.aspx");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        //---------------------------------------------------------------

        //Pour sauvegarder la photo
        protected void SauvegarderLaPhoto_Click(object sender, EventArgs e)
        {
            try
            {
                using (LeModelTIContainer modelTI = new LeModelTIContainer())
                {
                    Model.Professeur leProfCo = new Model.Professeur();
                    leProfCo = null;

                    //Récupérer la personne connecté
                    if (Request.Cookies["TIID"] != null)
                    {
                        if (Server.HtmlEncode(Request.Cookies["TIID"].Value) != null)
                        {
                            int leId = Convert.ToInt32(Server.HtmlEncode(Request.Cookies["TIID"].Value));

                            leProfCo = (from cl in modelTI.UtilisateurSet.OfType<Professeur>()
                                        where cl.IDUtilisateur == leId
                                        select cl).FirstOrDefault();

                            //Si le prof connecté est trouvé
                            if (leProfCo != null)
                            {
                                //Sauvegarder image sur le server
                                String imgData = ImgExSrc.Value;

                                //Si photos de base, donc pas choisi de photo, à peut-être optimiser plus tard
                                if (imgData.Contains("Photos/Profils/photobase.bmp"))
                                {
                                    imgData = "";
                                }

                                if (imgData != "" && imgData.Length > 21 && imgData.Substring(0, 21).Equals("data:image/png;base64"))
                                {
                                    System.Drawing.Image imageAAjouter = LoadImage(imgData);

                                    //Grosseur max est de 1000 px et minimum 120 px
                                    imageAAjouter = ResizeTheImage(1000, 120, imageAAjouter);
                                    
                                    String imageNom = (leProfCo.nom + DateTime.Now.ToString()).GetHashCode() + "_521.jpg";
                                    String imageProfilChemin = Path.Combine(Server.MapPath("~/Photos/" + ddlTypeDImage.SelectedValue.ToString() + "/"), imageNom);
                                    imageAAjouter.Save(imageProfilChemin);

                                    //Sauvegarder image pour utiliser avec la bd
                                    Model.Photos laPhotoBD = new Model.Photos();
                                    laPhotoBD.pathPhoto = imageNom;
                                    laPhotoBD.typePhoto = ddlTypeDImage.SelectedItem.Text;

                                    //Faire un log pour l'action
                                    Model.Log logPhoto = new Model.Log();
                                    logPhoto.actionLog = leProfCo.prenom + " " + leProfCo.nom + " vien d'ajouter une photos sur le serveur pour : " + ddlTypeDImage.SelectedValue.ToString() + ".";
                                    logPhoto.dateLog = DateTime.Now;
                                    logPhoto.typeLog = 0;
                                    logPhoto.Utilisateur = leProfCo;

                                    modelTI.PhotosSet.Add(laPhotoBD);
                                    modelTI.LogSet.Add(logPhoto);
                                    modelTI.SaveChanges();

                                    //Indiquer que cela a marché
                                    divReussiAjouterImage.Visible = true;
                                    divPasReussiAjouterImage.Visible = false;
                                    divPourAjouterUnePhoto.Visible = false;
                                }
                                else
                                {
                                    divPasReussiAjouterImage.Visible = true;
                                    lblPasReussi.Text = "Image impossible à ajouter.";
                                }
                            }
                            else
                            {
                                divPasReussiAjouterImage.Visible = true;
                                lblPasReussi.Text = "Veuillez-vous reconnecter.";
                            }
                        }
                        else
                        {
                            divPasReussiAjouterImage.Visible = true;
                            lblPasReussi.Text = "Veuillez-vous reconnecter.";
                        }
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                divPasReussiAjouterImage.Visible = true;
                lblPasReussi.Text = "Problème avec le serveur, veuillez réassayer plus tard";
            }
        }

        public System.Drawing.Image ResizeTheImage(int maxSize, int minSize, System.Drawing.Image imageAChecker)
        {
            int valeurAUtiliser = imageAChecker.Height;

            //Si image plus grand que max size
            if (imageAChecker.Height > maxSize && imageAChecker.Width > maxSize)
            {
                if (valeurAUtiliser < imageAChecker.Width)
                {
                    valeurAUtiliser = imageAChecker.Width;
                }
            }
            else if (imageAChecker.Height > maxSize)
            {
                valeurAUtiliser = imageAChecker.Height;
            }
            else if (imageAChecker.Width > maxSize)
            {
                valeurAUtiliser = imageAChecker.Width;
            }
            else
            {
                valeurAUtiliser = maxSize;
            }

            double valeurDivision = Convert.ToDouble(maxSize) / Convert.ToDouble(valeurAUtiliser);

            imageAChecker = (System.Drawing.Image)new Bitmap(imageAChecker, new Size(Convert.ToInt32(imageAChecker.Width * valeurDivision), Convert.ToInt32(imageAChecker.Height * valeurDivision)));

            //Si plus petit que min grosseur maintenant
            if (imageAChecker.Width < minSize)
            {
                imageAChecker = (System.Drawing.Image)new Bitmap(imageAChecker, new Size(minSize, imageAChecker.Height));
            }

            if (imageAChecker.Height < minSize)
            {
                imageAChecker = (System.Drawing.Image)new Bitmap(imageAChecker, new Size(imageAChecker.Width, minSize));
            }

            return imageAChecker;
        }

        public Model.Photos GetUnePhoto()
        {
            return new Model.Photos();
        }

        //Cette class permet de convertir data/jpeg à image.
        //Écrit par Cédric Archambault 26 février 2015 (Recopier par Raphael pour utiliser dans cette page)
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
                cropFilePath = Path.Combine(Server.MapPath("~/Photos/Souvenir/"), cropFileName);
            }

            return image;
        }
    }
}