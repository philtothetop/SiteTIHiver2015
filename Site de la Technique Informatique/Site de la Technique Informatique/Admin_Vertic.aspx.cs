// Cette classe permet à un administrateur ET aux professeurs de pouvoir changer les caractéristiques des portables et les licenses
// Écrit par Jacob Fontaine, Mars-Avril 2015

using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_Vertic : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SavoirSiPossedeAutorizationPourLaPage(false, true, false, false, false);

            if (!IsPostBack)
            {


                string caract = getCaracteristiquePortable();
                txtCaractPortatif.Text = caract;
                string autres = getAutresPortable();
                txtAutres.Text = autres;
                string licences = getLicences();
                txtLogicielLicenses.Text = licences;
                string libres = getLibres();
                txtLogicielLibres.Text = libres;
            }
        }

        public String getCaracteristiquePortable()
        {
            string caracteristiquePortable = "";
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                caracteristiquePortable = (from description in lecontexte.VerTICSet select description.caractéristiquesPortable).FirstOrDefault();
            }
            return caracteristiquePortable;
        }
        public String getAutresPortable()
        {
            string autresPortable = "";
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                autresPortable = (from autres in lecontexte.VerTICSet select autres.autrePortable).FirstOrDefault();
            }
            return autresPortable;
        }
        public String getLicences()
        {
            string licences = "";
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                licences = (from licence in lecontexte.VerTICSet select licence.descriptionLicence).FirstOrDefault();
            }
            return licences;
        }
        public String getLibres()
        {
            string libres = "";
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                libres = (from libre in lecontexte.VerTICSet select libre.descriptionLibre).FirstOrDefault();
            }


            string caract = getCaracteristiquePortable();
            txtCaractPortatif.Text = caract;
            return libres;
        }




        public IQueryable<DateEvenementVerTIC> lvEcheancier_GetData()
        {
            var listeEvenements = new List<DateEvenementVerTIC>();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                listeEvenements = (from cl in lecontexte.DateEvenementVerTICSet select cl).ToList();
            }

            if (listeEvenements.Count() == 0)
            {

                DateEvenementVerTIC eventTest = new DateEvenementVerTIC();
                eventTest.dateDescription = DateTime.Today;
                eventTest.evenement = "Date de Test";
                eventTest.IDDateEvenementVerTIC = 1;
                listeEvenements.Add(eventTest);

            }
            return listeEvenements.AsQueryable();
        }

        protected void btnSauvegarder_Click(object sender, EventArgs e)
        {
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    VerTIC vertic = new VerTIC();
                    vertic = (from tic in lecontexte.VerTICSet select tic).FirstOrDefault();
                    if(vertic==null)
                        {
                             vertic = new VerTIC();

                        }
                    vertic.descriptionLicence = txtLogicielLicenses.Text;
                    vertic.descriptionLibre = txtLogicielLibres.Text;
                    vertic.caractéristiquesPortable = txtCaractPortatif.Text;
                    vertic.autrePortable = txtAutres.Text;

                    Model.Utilisateur lutilisateurCo = new Model.Utilisateur();
                    lutilisateurCo = null;
                    if (Request.Cookies["TIID"] != null)
                    {
                        if (Server.HtmlEncode(Request.Cookies["TIID"].Value) != null)
                        {
                            int leId = Convert.ToInt32(Server.HtmlEncode(Request.Cookies["TIID"].Value));

                            lutilisateurCo = (from cl in lecontexte.UtilisateurSet
                                              where cl.IDUtilisateur == leId
                                              select cl).FirstOrDefault();
                        }
                    }
                    Model.Log loggerUnLog = new Model.Log();

                    loggerUnLog.actionLog = "Les changements aux caractéristiques et aux licences ont été SAUVEGARDÉS";
                    loggerUnLog.dateLog = DateTime.Now;
                    loggerUnLog.typeLog = 0;
                    loggerUnLog.Utilisateur = lutilisateurCo;
                    loggerUnLog.UtilisateurIDUtilisateur = lutilisateurCo.IDUtilisateur;
                    lecontexte.LogSet.Add(loggerUnLog);
                    lecontexte.SaveChanges();
                    mvAdmin_Vertic.SetActiveView(viewFin);


                }
            }
            catch (Exception ex)
            {
                LogErreur("Admin_OffreEmploi.aspx.cs dans la méthode btnSauvegarder_Click", ex);
            }
        }

        protected void lnkRetour_Click(object sender, EventArgs e)
        {
            mvAdmin_Vertic.SetActiveView(viewDefault);

        }
    }
}