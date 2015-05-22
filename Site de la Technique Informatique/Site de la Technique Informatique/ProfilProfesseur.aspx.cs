using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class ProfilProfesseur : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, true, true, false);

            if (Request.QueryString["id"] != null)
            {
                try
                {
                    int idProf = -1;
                    //Récupérer le ID du querystring du professeur a cheker
                    if (Request.QueryString["id"] != null)
                    {
                        idProf = Convert.ToInt32(Request.QueryString["id"]);
                    }
                    else
                    {
                        idProf = -1;
                    }


                    //Si le id du prof est trouvé
                    if (idProf != -1)
                    {
                        using (LeModelTIContainer modelTI = new LeModelTIContainer())
                        {
                            Professeur leProf = null;
                            leProf = (from cl in modelTI.UtilisateurSet.OfType<Professeur>()
                                    where cl.IDUtilisateur == idProf && cl.compteActif == 1
                                    select cl).FirstOrDefault();

                            //Si le prof est trouvé
                            if (leProf != null)
                            {
                                mltvProfesseur.ActiveViewIndex = 0;
                                divTrouverProf.Visible = true;
                                divPasTrouveProf.Visible = false;
                            }
                            else
                            {
                                divTrouverProf.Visible = false;
                                divPasTrouveProf.Visible = true;
                            }
                        }
                    }
                }
                catch
                {

                }
            }
            else
            {

                divTrouverProf.Visible = false;
                divPasTrouveProf.Visible = true;
            }
        }

        public IQueryable<Cours> GetLesCoursDuProf()
        {
            List<Cours> lesCours = new List<Cours>();

            try
            {
                int idProf = -1;
                //Récupérer le ID du querystring du professeur a cheker
                if (Request.QueryString["id"] != null)
                {
                    idProf = Convert.ToInt32(Request.QueryString["id"]);
                }
                else
                {
                    idProf = -1;
                }


                //Si le id du prof est trouvé
                if (idProf != -1)
                {
                    using (LeModelTIContainer modelTI = new LeModelTIContainer())
                    {
                        Professeur leProf = null;
                        leProf = (from cl in modelTI.UtilisateurSet.OfType<Professeur>()
                                where cl.IDUtilisateur == idProf
                                select cl).FirstOrDefault();

                        //Si le prof est trouvé
                        if (leProf != null)
                        {
                            int sessionToGet = Convert.ToInt32(ddlSession.SelectedValue);
                            foreach (Cours c in leProf.Cours)
                            {
                                if (c.noSessionCours == sessionToGet)
                                {
                                    lesCours.Add(c);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return lesCours.AsQueryable();
        }

        public Professeur lvProfesseur_GetData()
        {
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    Professeur profAAfficher = lecontexte.UtilisateurSet.OfType<Professeur>().Where(prof => prof.IDUtilisateur == id).FirstOrDefault();

                    return profAAfficher;

                }
            }
            catch
            {
                throw;
            }
        }


        protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvCours.DataBind();
            mltvProfesseur.ActiveViewIndex = 1;
        }

        protected void lnkInformation_Click(object sender, EventArgs e)
        {
            mltvProfesseur.ActiveViewIndex = 0;
        }

        protected void lnkMesCours_Click(object sender, EventArgs e)
        {
            mltvProfesseur.ActiveViewIndex = 1;
        }
    }
}