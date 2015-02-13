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
            try
            {
                using (ModelTIContainer leContext = new ModelTIContainer())
                {
                    List<EvenementJeu> listEvents = (from cl in leContext.EvenementJeu where (cl.dateDebutEvenement.Month == today.Month && cl.dateDebutEvenement.Year == today.Year) select cl).ToList();
                    foreach (EvenementJeu UnEvent in listEvents)
                    {
                        CalendrierEvents.SelectedDates.Add(UnEvent.dateDebutEvenement);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erreur dans le chargement des événements du calendrier ", ex);
            }

        }

        protected void CalendrierEvents_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                using (ModelTIContainer leContext = new ModelTIContainer())
                {
                    List<EvenementJeu> listEvents = (from cl in leContext.EvenementJeu where (cl.dateDebutEvenement.Month == today.Month && cl.dateDebutEvenement.Year == today.Year) select cl).ToList();
                    foreach (EvenementJeu UnEvent in listEvents)
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


        public IQueryable<Site_de_la_Technique_Informatique.Model.EvenementJeu> lviewEvents_GetData()
        {
            try
            {
                List<EvenementJeu> listeEvenement = new List<EvenementJeu>();

                using (ModelTIContainer leContext = new ModelTIContainer())
                {
                        try
                        {
                            if (leContext.EvenementJeu.ToList() != null)
                            {
                                listeEvenement = (from cl in leContext.EvenementJeu where (cl.dateDebutEvenement.Month == today.Month && cl.dateDebutEvenement.Year == today.Year) select cl).ToList();
                            }
                            else
                            {
                                return null;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException(ex.InnerException.Message, ex.InnerException);
                        }
                    }
                return listeEvenement.AsQueryable();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erreur dans le listeView Evenements PageAccueilConnecté", ex);
            }
        }

        protected void btnPlusEvents_Click(object sender, EventArgs e)
        {

        }

    }
}