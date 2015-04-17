using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.IO;
using System.Drawing;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_LesPhotos : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cookies["TIID"].Value = "2";
            //SavoirSiPossedeAutorizationPourLaPage(false, true, false, false);
        }

        protected void btnajouterAutreImage_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuePourTest.aspx");
        }


        //Uploader une image dans souvenir
        protected void btnUpdate_Click(object sender, EventArgs e)
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
                                //Si le fileupload n'est pas vide
                                if (fuplPhoto.HasFile)
                                {
                                    if (Path.GetExtension(fuplPhoto.PostedFile.FileName.ToLower()) == ".jpg" || Path.GetExtension(fuplPhoto.PostedFile.FileName.ToLower()) == ".png" || Path.GetExtension(fuplPhoto.PostedFile.FileName.ToLower()) == ".jpeg")
                                    {
                                        try
                                        {
                                            System.Drawing.Image imageAAjouter = System.Drawing.Image.FromStream(fuplPhoto.PostedFile.InputStream);

                                            //Grosseur max est de 1000 px et minimum 120 px
                                            imageAAjouter = ResizeTheImage(1000, 120, imageAAjouter);

                                            String imageNom = ddlTypeDImage.SelectedValue.ToString() + "/" + (leProfCo.nom + DateTime.Now.ToString()).GetHashCode() + "_521.jpg";
                                            String imageProfilChemin = Path.Combine(Server.MapPath("~/Photos/Souvenir/" + ddlTypeDImage.SelectedValue.ToString() + "/"), imageNom);
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

                                            //lblEchecImage.Text = "";
                                        }
                                        catch (Exception ex)
                                        {
                                            divPasReussiAjouterImage.Visible = true;
                                            lblPasReussi.Text = "Problème pour uploader l'image.";
                                        }
                                    }
                                    else
                                    {
                                        divPasReussiAjouterImage.Visible = true;
                                        lblPasReussi.Text = "Mauvais format de l'image.";
                                    }
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
                LogErreur("Admin_LesPhotos.aspx.cs dans la méthode btnUpdate_Click", ex);
            }
        }

        protected void lviewSupprimerPhotosDataBound(object sender, EventArgs e)
        {
            dataPagerPhotosSouvenirs.Visible = (dataPagerPhotosSouvenirs.PageSize < dataPagerPhotosSouvenirs.TotalRowCount);
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

        //Méthode pour récupérer les photos dans la BD
        public IQueryable<Model.Photos> GetLesPhotos()
        {
            //Créer une liste de base
            List<Model.Photos> listeDesPhotos = new List<Model.Photos>();

            try
            {
                using (LeModelTIContainer modelTI = new LeModelTIContainer())
                {
                    string voirSeTypeDePhotos = ddlTypePhotoSupprimer.SelectedValue;

                    if (voirSeTypeDePhotos.Equals("Tous"))
                    {
                        //Récupérer toutes les photos
                        listeDesPhotos = (from cl in modelTI.PhotosSet
                                          select cl).ToList();
                    }
                    else
                    {
                        //Récupérer les photos du type choisi
                        listeDesPhotos = (from cl in modelTI.PhotosSet
                                          where cl.typePhoto.Equals(voirSeTypeDePhotos)
                                          select cl).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Admin_LesPhotos.aspx.cs dans la méthode GetLesPhotos", ex);
            }

            return listeDesPhotos.AsQueryable();
        }

        //Changer d'onglet pour ajouter une photos
        protected void btnAjouterUnePhoto_Click(object sender, EventArgs e)
        {
            mviewLesPhotos.ActiveViewIndex = 1;
        }

        //Changer d'onglet pour modifier une photo
        protected void btnModifierLaPhoto_Click(object sender, EventArgs e)
        {
            mviewLesPhotos.ActiveViewIndex = 2;
        }

        //Changer d'onglet pour voir les photos
        protected void btnModifierSupprimerPhoto_Click(object sender, EventArgs e)
        {
            mviewLesPhotos.ActiveViewIndex = 3;
        }


        //Supprimer la photo choisi
        protected void btnSupprimerLaPhoto_Click(object sender, EventArgs e)
        {
            int argumentIDPhoto = Convert.ToInt32(((Button)sender).CommandArgument);

            using (LeModelTIContainer modelTI = new LeModelTIContainer())
            {
                Model.Photos laPhotoATrouver = new Model.Photos();
                laPhotoATrouver = null;

                laPhotoATrouver = (from cl in modelTI.PhotosSet
                                   where cl.IDPhotos == argumentIDPhoto
                                   select cl).FirstOrDefault();

                //Si la photo est trouvé
                if (laPhotoATrouver != null)
                {
                    
                }

            }
        }

        
    }
}