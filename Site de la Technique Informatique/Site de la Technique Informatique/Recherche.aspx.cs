using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class Recherche : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public IQueryable<Site_de_la_Technique_Informatique.Model.Membre> lviewRecherche_GetData()
        {
            List<Model.Membre> listeMembre = new List<Membre>();

            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                listeMembre = (from cl in lecontexte.UtilisateurSet.OfType<Model.Membre>()
                               select cl).ToList();

                if (txtNomMembre.Text != "")
                {
                    List<Model.Membre> prenomFirst = listeMembre.AsQueryable().Where(cl => (cl.prenom + " " + cl.nom).ToLower().Contains(txtNomMembre.Text.Trim().ToLower())).ToList();
                    List<Model.Membre> nomFirst = listeMembre.AsQueryable().Where(cl => (cl.nom + " " + cl.prenom).ToLower().Contains(txtNomMembre.Text.Trim().ToLower())).ToList();
                    listeMembre = prenomFirst.Concat(nomFirst).ToList().Distinct().ToList();
                }


                if (rdbProfesseur.Checked && !rdbEtudiant.Checked)
                {
                    listeMembre = listeMembre.AsQueryable().Where(cl => cl is Professeur).ToList();
                }

                else if (!rdbProfesseur.Checked && rdbEtudiant.Checked)
                {
                    listeMembre = listeMembre.AsQueryable().Where(cl => cl is Etudiant).ToList();
                }

                else
                {
                    listeMembre = listeMembre.AsQueryable().Where(cl => cl is Membre).ToList();
                }

                return listeMembre.AsQueryable();
            }
        }

        protected void btnRecherche_Click(object sender, EventArgs e)
        {
            panelResultats.Visible = true;
            lviewRecherche.DataBind();
        }
    }
}