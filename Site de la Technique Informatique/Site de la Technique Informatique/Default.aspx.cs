using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class Default : ErrorHandling
    {

        DateTime today = DateTime.Now;
        DateTime demain = DateTime.Now.AddDays(1);

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            int i = 0;

            SiteMapPath sitemap = (SiteMapPath)Master.FindControl("siteMapPath");
            sitemap.Visible = false;

            foreach (ListViewItem lvi in lviewAlbumPhoto.Items)
            {
                System.Web.UI.WebControls.Image imgDansCarousel = (System.Web.UI.WebControls.Image)lviewAlbumPhoto.Items[i].FindControl("imgDansCarousel");

                imgDansCarousel.Height = GetHeightCarousselImageMax(imgDansCarousel.ImageUrl, 400);
                imgDansCarousel.Width = GetWidthCarousselImageMax(imgDansCarousel.ImageUrl, 400);
                i++;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (LeModelTIContainer leContext = new LeModelTIContainer())
            {
                List<Evenement> listEvents = (from cl in leContext.EvenementSet where (cl.dateDebutEvenement.Month == today.Month && cl.dateDebutEvenement.Year == today.Year) select cl).ToList();
                foreach (Evenement UnEvent in listEvents)
                {
                    CalendrierEvents.SelectedDates.Add(UnEvent.dateDebutEvenement);
                }
            }
        }

        //Changer les dates lors du changement de mois
        protected void CalendrierEvents_SelectionChanged(object sender, EventArgs e)
        {

            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    List<Evenement> listEvents = (from cl in leContext.EvenementSet where (cl.dateDebutEvenement.Month == today.Month && cl.dateDebutEvenement.Year == today.Year) select cl).ToList();
                    foreach (Evenement UnEvent in listEvents)
                    {
                        CalendrierEvents.SelectedDates.Add(UnEvent.dateDebutEvenement);
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Default-CalendrierEvents_SelectionChanged", ex);
            }
        }

        //Changer les datas selon le mois
        public IQueryable<Site_de_la_Technique_Informatique.Model.Evenement> lviewEvents_GetData()
        {
            if (CalendrierEvents.SelectedDates.Count != 0)
            {
                var monthSelected = CalendrierEvents.SelectedDates[0].Month;
                var yearSelected = CalendrierEvents.SelectedDates[0].Year;
                List<Evenement> listeEvenement = new List<Evenement>();

                try
                {

                    //string yolo = "gerg";
                    //int moma = Convert.ToInt32(yolo);

                    using (LeModelTIContainer leContext = new LeModelTIContainer())
                    {
                        if (leContext.EvenementSet.ToList() != null)
                        {
                            listeEvenement = (from cl in leContext.EvenementSet where (cl.dateDebutEvenement.Month == monthSelected && cl.dateDebutEvenement.Year == yearSelected) select cl).ToList();
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                   LogErreur("Default-lviewEvents_GetData", ex);
                }
                return listeEvenement.AsQueryable().SortBy("dateDebutEvenement");
            }
            else
            {
                return null;
            }
        }

        //Renvoie à l'événement demander sur la page d'événement
        protected void btnPlusEvents_Click(object sender, EventArgs e)
        {

        }

        //Change le mois en cours, les dates sélectionner et appel lviewEvents_getData
        protected void CalendrierEvents_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            using (LeModelTIContainer leContext = new LeModelTIContainer())
            {
                List<Evenement> listEvents = (from cl in leContext.EvenementSet where (cl.dateDebutEvenement.Month == e.NewDate.Month && cl.dateDebutEvenement.Year == today.Year) select cl).ToList();
                CalendrierEvents.SelectedDates.Clear();

                foreach (Evenement UnEvent in listEvents)
                {
                    CalendrierEvents.SelectedDates.Add(UnEvent.dateDebutEvenement);
                }
                lviewEvents.DataBind();
            }
        }

        //Hauteur max de l'image dans le carousel
        public int GetHeightCarousselImageMax(string nomPhoto, int tailleMax)
        {
            int hauteurMax = tailleMax;

            try
            {
                string siImageExiste = nomPhoto;
                siImageExiste = HttpContext.Current.Server.MapPath(siImageExiste);

                Bitmap lImage = new Bitmap(siImageExiste);

                int height = lImage.Size.Height;
                int width = lImage.Size.Width;

                if (height >= width)
                {
                    hauteurMax = tailleMax;
                }
                else
                {
                    double difference = tailleMax / Convert.ToDouble(width);
                    hauteurMax = Convert.ToInt32(difference * height);
                }

            }
            catch
            {
                return tailleMax;
            }

            return hauteurMax;
        }

        //Largeur max de l'image dans le carousel
        public int GetWidthCarousselImageMax(string nomPhoto, int tailleMax)
        {
            int largeurMax = tailleMax;

            try
            {
                string siImageExiste = nomPhoto;
                siImageExiste = HttpContext.Current.Server.MapPath(siImageExiste);

                Bitmap lImage = new Bitmap(siImageExiste);

                int height = lImage.Size.Height;
                int width = lImage.Size.Width;

                if (width >= height)
                {
                    largeurMax = tailleMax;
                }
                else
                {
                    double difference = tailleMax / Convert.ToDouble(height);
                    largeurMax = Convert.ToInt32(difference * width);
                }

            }
            catch
            {
                return tailleMax;
            }

            return largeurMax;
        }

        //Aller chercher les photos du Carousel
        public IQueryable<Site_de_la_Technique_Informatique.Model.Photos> lviewAlbumPhoto_GetData()
        {

            List<Photos> listePhoto = new List<Photos>();

            using (LeModelTIContainer leContext = new LeModelTIContainer())
            {
                try
                {
                    listePhoto = (from cl in leContext.PhotosSet select cl).ToList();
                }
                catch (Exception ex)
                {
                    LogErreur("Default-lviewAlbumPhoto_GetData", ex);
                }
                return listePhoto.AsQueryable();
            }
        }

    }
}