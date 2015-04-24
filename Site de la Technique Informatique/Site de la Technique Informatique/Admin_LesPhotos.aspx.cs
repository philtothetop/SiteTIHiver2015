// Cette classe permet aux profeseurs de pouvoir ajouter un souvenir (Photo et description) pour le rendre visible a tous
// Écrit par Raphael Brouard, Avril 2015
// Intrants: Photos a uploader et la description
// Extrants: Un éléments photos de la BD a été créé/modifié/supprimé et enregustré dans la BD.

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
            if (Page.IsPostBack == false)
            {
                //Set les drops downs listes (modifier/Ajouter)
                Dictionary<string, string> listeDesElements = listeStaticSouvenirs(false); 

                ddlTypeDImage.DataSource = listeDesElements;
                ddlTypeDImage.DataTextField = "Key";
                ddlTypeDImage.DataValueField = "Value";
                ddlTypeDImage.DataBind();

                ddlModifierPhoto.DataSource = listeDesElements;
                ddlModifierPhoto.DataTextField = "Key";
                ddlModifierPhoto.DataValueField = "Value";
                ddlModifierPhoto.DataBind();

                //Set le drop down liste(Pour voir photos)
                Dictionary<string, string> listeDesElementsAVoir = listeStaticSouvenirs(true); 

                ddlTypePhotoSupprimer.DataSource = listeDesElementsAVoir;
                ddlTypePhotoSupprimer.DataTextField = "Key";
                ddlTypePhotoSupprimer.DataValueField = "Value";
                ddlTypePhotoSupprimer.DataBind();

            }

            Response.Cookies["TIID"].Value = "2";
            //SavoirSiPossedeAutorizationPourLaPage(false, true, false, false);
        }

        //Pour recevoir la liste des type de souvenirs
        public  Dictionary<string, string> listeStaticSouvenirs(bool avecTous)
        {
             Dictionary<string, string> listeDesElements= new Dictionary<string, string>();

             if (avecTous == true)
             {
                 listeDesElements.Add("Tous","Tous");
             }

             listeDesElements.Add("Cégep","Cégep");
             listeDesElements.Add("Étudiants", "Étudiants");
             listeDesElements.Add("Professeurs", "Professeurs");
             listeDesElements.Add("Projets", "Projets");
             listeDesElements.Add("Autre", "Autre");

             return listeDesElements;
        }

        protected void btnajouterAutreImage_Click(object sender, EventArgs e)
        {
            divPasReussiAjouterImage.Visible = false;
            divReussiAjouterImage.Visible = false;
            divPourAjouterUnePhoto.Visible = true;
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

                                            String imageNom = (leProfCo.nom + DateTime.Now.ToString()).GetHashCode() + "_521.jpg";
                                            String imageProfilChemin = Path.Combine(Server.MapPath("~/Photos/Souvenir/"), ddlTypeDImage.Text + "/" + imageNom);
                                            imageAAjouter.Save(imageProfilChemin);

                                            //Sauvegarder image pour utiliser avec la bd
                                            Model.Photos laPhotoBD = new Model.Photos();
                                            laPhotoBD.pathPhoto = imageNom;
                                            laPhotoBD.typePhoto = ddlTypeDImage.SelectedItem.Text;

                                            if (txtbDescriptionPhotoAAjouter.Text != null)
                                            {
                                                laPhotoBD.descriptionPhoto = txtbDescriptionPhotoAAjouter.Text;
                                            }
                                            else
                                            {
                                                laPhotoBD.descriptionPhoto = "";
                                            }

                                            //Faire un log pour l'action
                                            Model.Log logPhoto = new Model.Log();
                                            logPhoto.actionLog = leProfCo.prenom + " " + leProfCo.nom + " vient d'ajouter une photo sur le serveur pour : " + ddlTypeDImage.SelectedValue.ToString() + ".";
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
                                            lblPasReussi.Text = "Nous avons eu un problème pour téléverser l'image.";
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
                                lblPasReussi.Text = "Veuillez vous reconnecter.";
                            }
                        }
                        else
                        {
                            divPasReussiAjouterImage.Visible = true;
                            lblPasReussi.Text = "Veuillez vous reconnecter.";
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
            //dataPagerPhotosSouvenirs.Visible = (dataPagerPhotosSouvenirs.PageSize < dataPagerPhotosSouvenirs.TotalRowCount);
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
            divPasReussiAjouterImage.Visible = false;
            divReussiAjouterImage.Visible = false;
            divPourAjouterUnePhoto.Visible = true;
            mviewLesPhotos.ActiveViewIndex = 1;
        }

        //Changer d'onglet pour modifier une photo
        protected void btnModifierLaPhoto_Click(object sender, EventArgs e)
        {
            int argumentIDPhoto = Convert.ToInt32(((Button)sender).CommandArgument);

            using (LeModelTIContainer modelTI = new LeModelTIContainer())
            {
                Model.Utilisateur lutilisateurCo = new Model.Utilisateur();
                lutilisateurCo = null;

                Model.Photos laPhotoATrouver = new Model.Photos();
                laPhotoATrouver = null;

                //Récupérer la personne connecté
                if (Request.Cookies["TIID"] != null)
                {
                    if (Server.HtmlEncode(Request.Cookies["TIID"].Value) != null)
                    {
                        int leId = Convert.ToInt32(Server.HtmlEncode(Request.Cookies["TIID"].Value));

                        lutilisateurCo = (from cl in modelTI.UtilisateurSet
                                            where cl.IDUtilisateur == leId
                                            select cl).FirstOrDefault();

                        laPhotoATrouver = (from cl in modelTI.PhotosSet
                                            where cl.IDPhotos == argumentIDPhoto
                                            select cl).FirstOrDefault();
                    }
                }

                //Si lutilisateur connecté est trouvé et la photo
                if (lutilisateurCo != null && laPhotoATrouver != null)
                {
                    txtbModifierPhotoDescription.Text = laPhotoATrouver.descriptionPhoto;
                    imgModifierPhoto.ImageUrl = "~/Photos/Souvenir/" + laPhotoATrouver.typePhoto + "/"+ laPhotoATrouver.pathPhoto;
                    ddlModifierPhoto.SelectedValue = laPhotoATrouver.typePhoto;
                    hfieldIDItemAModifier.Value = Convert.ToString(laPhotoATrouver.IDPhotos);

                    mviewLesPhotos.ActiveViewIndex = 2;
                }
                //Si pu connecté, rediriger a la page d'accueil
                else
                {
                    Response.Redirect("Default.aspx");
                          
                }
            }
        }

        //Changer d'onglet pour voir les photos
        protected void btnVoirLesPhotos_Click(object sender, EventArgs e)
        {
            ddlTypePhotoSupprimer.SelectedIndex = 0;
            lviewSupprimerPhotos.DataBind();
            mviewLesPhotos.ActiveViewIndex = 3;
        }

        //Pour changer les photos a voir
        protected void ddlTypePhotoSupprimer_IndexChange(object sender, EventArgs e)
        {
            lviewSupprimerPhotos.DataBind();
        }



        //Pour mettre a jour la photo
        protected void btnUpdaterModifierPhoto_Click(object sender, EventArgs e)
        {
            using (LeModelTIContainer modelTI = new LeModelTIContainer())
            {

                int leID = -1;

                //Allez cherché le ID dans le hiddenfield
                if (hfieldIDItemAModifier.Value != null)
                {
                    if (!hfieldIDItemAModifier.Value.Equals(""))
                    {
                        leID = Convert.ToInt32(hfieldIDItemAModifier.Value);
                    }
                }

                if (leID != -1)
                {

                    Model.Utilisateur lutilisateurCo = new Model.Utilisateur();
                    lutilisateurCo = null;

                    Model.Photos laPhotoATrouver = new Model.Photos();
                    laPhotoATrouver = null;

                    //Récupérer la personne connecté
                    if (Request.Cookies["TIID"] != null)
                    {
                        if (Server.HtmlEncode(Request.Cookies["TIID"].Value) != null)
                        {
                            int leId = Convert.ToInt32(Server.HtmlEncode(Request.Cookies["TIID"].Value));

                            lutilisateurCo = (from cl in modelTI.UtilisateurSet
                                              where cl.IDUtilisateur == leId
                                              select cl).FirstOrDefault();

                            laPhotoATrouver = (from cl in modelTI.PhotosSet
                                               where cl.IDPhotos == leID
                                               select cl).FirstOrDefault();
                        }
                    }

                    //Si lutilisateur connecté est trouvé et la photo
                    if (lutilisateurCo != null && laPhotoATrouver != null)
                    {
                        laPhotoATrouver.descriptionPhoto = txtbModifierPhotoDescription.Text;

                        //Si le type de photos est changé, changer l'emplacement de la photo dans le bon dossier
                        if (!laPhotoATrouver.typePhoto.Equals(ddlModifierPhoto.SelectedValue))
                        {
                            String lePath = Path.Combine(Server.MapPath("~/Photos/Souvenir/"), laPhotoATrouver.typePhoto + "/" + laPhotoATrouver.pathPhoto);
                            String lePathAAllez = Path.Combine(Server.MapPath("~/Photos/Souvenir/"), ddlModifierPhoto.SelectedValue + "/" + laPhotoATrouver.pathPhoto);

                            //Changer lemplacement de la photo
                            if (File.Exists(@lePath))
                            {
                                File.Move(@lePath, @lePathAAllez);
                            }

                            laPhotoATrouver.typePhoto = ddlModifierPhoto.SelectedValue;
                        }

                        modelTI.SaveChanges();
                        hfieldIDItemAModifier.Value = "";
                    }
                    //Si pu connecté, rediriger a la page d'accueil
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
        }


        //Supprimer la photo choisi
        protected void btnSupprimerLaPhoto_Click(object sender, EventArgs e)
        {
            int argumentIDPhoto = Convert.ToInt32(((Button)sender).CommandArgument);

            try
            {
                using (LeModelTIContainer modelTI = new LeModelTIContainer())
                {
                    Model.Utilisateur lutilisateurCo = new Model.Utilisateur();
                    lutilisateurCo = null;

                    Model.Photos laPhotoATrouver = new Model.Photos();
                    laPhotoATrouver = null;

                    //Récupérer la personne connecté
                    if (Request.Cookies["TIID"] != null)
                    {
                        if (Server.HtmlEncode(Request.Cookies["TIID"].Value) != null)
                        {
                            int leId = Convert.ToInt32(Server.HtmlEncode(Request.Cookies["TIID"].Value));

                            lutilisateurCo = (from cl in modelTI.UtilisateurSet
                                              where cl.IDUtilisateur == leId
                                              select cl).FirstOrDefault();

                            laPhotoATrouver = (from cl in modelTI.PhotosSet
                                               where cl.IDPhotos == argumentIDPhoto
                                               select cl).FirstOrDefault();
                        }
                    }

                    //Si lutilisateur connecté est trouvé et la photo
                    if (lutilisateurCo != null && laPhotoATrouver != null)
                    {
                        //Créer le log
                        Model.Log loggerUnLog = new Model.Log();
                        loggerUnLog.actionLog = "Une photos de souvenir a été supprimé.";
                        loggerUnLog.dateLog = DateTime.Now;
                        loggerUnLog.typeLog = 0;
                        loggerUnLog.Utilisateur = lutilisateurCo;
                        loggerUnLog.UtilisateurIDUtilisateur = lutilisateurCo.IDUtilisateur;

                        modelTI.LogSet.Add(loggerUnLog);
                        modelTI.PhotosSet.Remove(laPhotoATrouver);
                        modelTI.SaveChanges();
                        lviewSupprimerPhotos.DataBind();

                        //Supprimer la photo du serveur
                        String imageProfilChemin = Path.Combine(Server.MapPath("~/Photos/Souvenir/"), laPhotoATrouver.typePhoto + "/" + laPhotoATrouver.pathPhoto);

                        if (File.Exists(@imageProfilChemin))
                        {
                            File.Delete(@imageProfilChemin);
                        }

                    }
                    //Si pu connecté, rediriger a la page d'accueil
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Admin_LesPhotos.aspx.cs dans la méthode btnSupprimerLaPhoto_Click", ex);
            }
        }
    }
}