using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.Net;

namespace Site_de_la_Technique_Informatique
{
    public partial class ValiderLesOffresEmploi : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Courriel"] = "admin";
            SavoirSiPossedeAutorizationPourLaPage(true, true, false, false);
        }

        //Méthode pour downloader le PDF de l'offre d'emploi
        protected void lnkPDF_Click(object sender, EventArgs e)
        {
            String argument = Convert.ToString(((Button)sender).CommandArgument);
            string FilePath = Server.MapPath(argument);

            WebClient User = new WebClient();
            Byte[] FileBuffer = User.DownloadData(FilePath);
            if (FileBuffer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", FileBuffer.Length.ToString());
                Response.BinaryWrite(FileBuffer);
            }
        }


         //Méthode pour accepter l'offre d'emploi
        protected void accepterOffreEmploi_Click(object sender, EventArgs e)
        {
            int argument = Convert.ToInt32(((Button)sender).CommandArgument);

            using (LeModelTIContainer leModel = new LeModelTIContainer())
            {
                Model.OffreEmploi lOffreAAccepter = (from cl in leModel.OffreEmploiSet
                                                     where cl.IDOffreEmploi == argument
                                                     select cl).FirstOrDefault();

                //Si l'offre est trouvé
                if (lOffreAAccepter != null)
                {
                    lOffreAAccepter.validerOffre = true;
                    leModel.SaveChanges();
                    lviewOffresDEmploi.DataBind();
                }
                
            }
        }

        //Méthode pour refuser l'offre d'emploi
        protected void refuserOffreEmploi_Click(object sender, EventArgs e)
        {
            int argument = Convert.ToInt32(((Button)sender).CommandArgument);

            using (LeModelTIContainer leModel = new LeModelTIContainer())
            {
                Model.OffreEmploi lOffreARefuser = (from cl in leModel.OffreEmploiSet
                                                    where cl.IDOffreEmploi == argument
                                                    select cl).FirstOrDefault();

                //Si l'offre est trouvé
                if (lOffreARefuser != null)
                {
                    leModel.OffreEmploiSet.Remove(lOffreARefuser);
                    leModel.SaveChanges();
                    lviewOffresDEmploi.DataBind();
                }

            }
        }

        //Méthode pour récupérer les offres d'emploi de la BD
        public IQueryable<Model.OffreEmploi> GetLesOffresDEmploi()
        {
            //Créer une liste de base
            List<Model.OffreEmploi> listeDesOffresEmploi = new List<Model.OffreEmploi>();

            try
            {
                using (LeModelTIContainer modelTI = new LeModelTIContainer())
                {
                    //Récupérer les offres d'emploi dans la BD qui ne sont pas validé
                    listeDesOffresEmploi = (from cl in modelTI.OffreEmploiSet
                                            where cl.validerOffre == false
                                            select cl).ToList();
                }

                //QUE POUR TEST
                OffreEmploi unOffre = new OffreEmploi();
                //unOffre.
            }
            catch (Exception ex)
            {
                //A AJOUTER UN LOG DANS LA ROUTINE DERREUR? ATTENDRE ROUTINE DERREUR FINI?
            }

            return listeDesOffresEmploi.AsQueryable();
        }
    }
}