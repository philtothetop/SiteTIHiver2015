using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
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
                throw new InvalidOperationException("Erreur dans selectionChanged du calendrier ", ex);
            }
        }


        public IQueryable<Site_de_la_Technique_Informatique.Model.Evenement> lviewEvents_GetData()
        {

            if (CalendrierEvents.SelectedDates[0] != null)
            {
                var monthSelected = CalendrierEvents.SelectedDates[0].Month;
                var yearSelected = CalendrierEvents.SelectedDates[0].Year;

                try
                {
                    List<Evenement> listeEvenement = new List<Evenement>();

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
                    return listeEvenement.AsQueryable().SortBy("dateDebutEvenement");
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Erreur dans le listeView Evenements PageAccueilConnecté", ex);
                }
            }
            else
            {
                return null;
            }
        }

        protected void btnPlusEvents_Click(object sender, EventArgs e)
        {

        }

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

    }
}