using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_Temoignage : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //Besoin de cela pour la premiere fois que on load la page, mettre le datapager visible ou non si plusieurs témoignages
            if (Page.IsPostBack == false)
            {
                dataPagerDesTemoignages.Visible = (dataPagerDesTemoignages.PageSize < dataPagerDesTemoignages.TotalRowCount);
            }
        }

        //Méthode pour récupérer les témoignages de la BD
        public IQueryable<Model.Etudiant> GetLesTemoignagesEtudiants()
        {
            //Créer une liste de base
            List<Model.Etudiant> listeDesTemoignages = new List<Model.Etudiant>();

            try
            {
                using (LeModelTIContainer modelTI = new LeModelTIContainer())
                {
                    listeDesTemoignages = (from cl in modelTI.UtilisateurSet.OfType<Etudiant>()
                                           where cl.temoignage.Length > 1 && cl.valideTemoignage == false
                                           select cl).ToList();
                }
            }
            catch (Exception ex)
            {

            }

            return listeDesTemoignages.AsQueryable();
        }

        //Pour accepter les témoignages
        protected void AccepterTemoignage_Click(object sender, EventArgs e)
        {
            //Le id etudiant
            int argument = Convert.ToInt32(((Button)sender).CommandArgument);

            using (LeModelTIContainer leModel = new LeModelTIContainer())
            {
                Model.Etudiant leTemoignageAAccepter = (from cl in leModel.UtilisateurSet.OfType<Etudiant>()
                                                        where cl.IDUtilisateur == argument
                                                        select cl).FirstOrDefault();

                //Si la personne est trouvé
                if (leTemoignageAAccepter != null)
                {
                    leTemoignageAAccepter.valideTemoignage = true;
                    leModel.SaveChanges();
                    lviewTemoignage.DataBind();
                }
            }
        }

        //Pour refuser les témoignages
        protected void SupprimerTemoignage_Click(object sender, EventArgs e)
        {
            //Le id etudiant
            int argument = Convert.ToInt32(((Button)sender).CommandArgument);

            using (LeModelTIContainer leModel = new LeModelTIContainer())
            {
                Model.Etudiant leTemoignageAAccepter = (from cl in leModel.UtilisateurSet.OfType<Etudiant>()
                                                        where cl.IDUtilisateur == argument
                                                        select cl).FirstOrDefault();

                //Si la personne est trouvé
                if (leTemoignageAAccepter != null)
                {
                    leTemoignageAAccepter.valideTemoignage = false;
                    leTemoignageAAccepter.temoignage = "";
                    leModel.SaveChanges();
                    lviewTemoignage.DataBind();
                }
            }
        }
    }
}