using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Site_de_la_Technique_Informatique
{
    public class ErrorHandling : System.Web.UI.Page
    {
        public void Page_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            Server.Transfer("~/ErreursImportants.aspx?handler=" + ex.TargetSite.Name, true);

            Server.ClearError();
        }


        public void LogErreur(string leMessage)
        {
            using (ModelTIContainer leContext = new ModelTIContainer())
            {
                LogJeu uneNouvelleErreur = new LogJeu();
                uneNouvelleErreur.dateLog = DateTime.Now;
                uneNouvelleErreur.actionLog = leMessage;
                //uneNouvelleErreur.typeLog = 1;

                leContext.LogJeu.Add(uneNouvelleErreur);
                leContext.SaveChanges();
            }
        }



    }
}