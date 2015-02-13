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
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime demain = DateTime.Now;
            demain = demain.AddDays(1);
            CalendrierEvents.SelectedDates.Add(demain);
        }

        protected void CalendrierEvents_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                

                foreach (DateTime UneDateChoisie in CalendrierEvents.SelectedDates)
                {
                    //UneDateChoisie.

                    //BorderColor = "#CCCCCC"; 
                    //BorderWidth = "1px";
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erreur dans selectionChanged du calendrier ", ex);
            }
        }


    }
}