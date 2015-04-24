// Cette classe permet à tous de pouvoir consulter les souvenirs de la technique informatique
// Écrit par Raphael Brouard, Avril 2015
// Intrants: Vide
// Extrants: Vide

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.Drawing;

namespace Site_de_la_Technique_Informatique
{
    public partial class Souvenirs : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Setter le drop down list
                Dictionary<string, string> listeDesElements = new Dictionary<string, string>();
                listeDesElements.Add("Tous", "Tous");
                listeDesElements.Add("Cégep", "Cégep");
                listeDesElements.Add("Étudiants", "Étudiants");
                listeDesElements.Add("Professeurs", "Professeurs");
                listeDesElements.Add("Projets", "Projets");
                listeDesElements.Add("Autre", "Autre");

                ddlTypeDeSouvenir.DataSource = listeDesElements;
                ddlTypeDeSouvenir.DataTextField = "Key";
                ddlTypeDeSouvenir.DataValueField = "Value";
                ddlTypeDeSouvenir.DataBind();

                //Querystring truc ici a faire SI ON VA UTILSER SA, A DEMENDER AU GROUPE POUR ACCUEIL TRUC
                //
                //
                //


            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //Pour afficher ou non le datapager si besoin
            //dataPagerDesSouvenirs.Visible = (dataPagerDesSouvenirs.PageSize < dataPagerDesSouvenirs.TotalRowCount);
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
                    string voirSeTypeDeSouvenir = ddlTypeDeSouvenir.SelectedValue;

                    if (voirSeTypeDeSouvenir.Equals("Tous"))
                    {
                        //Récupérer toutes les photos
                        listeDesPhotos = (from cl in modelTI.PhotosSet
                                          select cl).ToList();
                    }
                    else
                    {
                        //Récupérer les photos du type choisi
                        listeDesPhotos = (from cl in modelTI.PhotosSet
                                          where cl.typePhoto.Equals(voirSeTypeDeSouvenir)
                                          select cl).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Souvenirs.aspx.cs dans la méthode GetLesPhotos", ex);
            }

            return listeDesPhotos.AsQueryable();
        }

        //Pour changer les souvenirs a voir
        protected void ddlTypeDeSouvenir_IndexChange(object sender, EventArgs e)
        {
            lviewSouvenirs.DataBind();
        }


        //Pour mettre un texte palceholder si la description est vide
        public string SavoirSiDescriptionEstVide(string laDescription)
        {
            if (laDescription.Equals(""))
            {
                return "Aucune description pour ce souvenir.";
            }
            else
            {
                return laDescription;
            }
        }

        public string ImageToResize(string pathImage, bool faireHauteur)
        {

            System.Drawing.Image imageDuMoment = System.Drawing.Image.FromFile(pathImage);
            imageDuMoment = ResizeTheImage(500, 120, imageDuMoment);

            //Pour height
            if (faireHauteur == true)
            {
                return Convert.ToString(imageDuMoment.Height);
            }
            //Pour Width
            else
            {
                return Convert.ToString(imageDuMoment.Width);
            }
        }

        public System.Drawing.Image ResizeTheImage(int maxSize, int minSize, System.Drawing.Image imageAChecker)
        {
            int valeurAUtiliser = imageAChecker.Height;

            //Si image plus grand que max size width et height
            if (imageAChecker.Height > maxSize && imageAChecker.Width > maxSize)
            {
                if (valeurAUtiliser < imageAChecker.Width)
                {
                    valeurAUtiliser = imageAChecker.Width;
                }
            }
            //Si image plus grand que max size height
            else if (imageAChecker.Height > maxSize)
            {
                valeurAUtiliser = imageAChecker.Height;
            }
            //Si image plus grand que max size widht
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
            /*
            //Pour mettre au moin hauteur ou largeur a 500
            if (imageAChecker.Width < 500 && imageAChecker.Height < 500)
            { 
                if ()
            }
                */
            return imageAChecker;
        }

         
    }
}