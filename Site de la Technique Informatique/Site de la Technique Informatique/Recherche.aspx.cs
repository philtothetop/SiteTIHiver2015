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
                    if (txtNomMembre.Text.ToCharArray()[txtNomMembre.Text.ToCharArray().Length - 1] == '*' && txtNomMembre.Text.ToCharArray()[0] == '*')
                    {
                        listeMembre = listeMembre.AsQueryable().Where(cl => cl.nom.ToLower().Contains(txtNomMembre.Text.Substring(1, txtNomMembre.Text.ToCharArray().Length - 2).ToLower())).ToList();
                    }

                    else if (txtNomMembre.Text.ToCharArray()[txtNomMembre.Text.ToCharArray().Length - 1] == '*')
                    {
                        listeMembre = listeMembre.AsQueryable().Where(cl => cl.nom.ToLower().StartsWith(txtNomMembre.Text.Substring(0, txtNomMembre.Text.ToCharArray().Length - 1).ToLower())).ToList();
                    }

                    else if (txtNomMembre.Text.ToCharArray()[0] == '*')
                    {
                        listeMembre = listeMembre.AsQueryable().Where(cl => cl.nom.ToLower().EndsWith(txtNomMembre.Text.Substring(1).ToLower())).ToList();
                    }

                    else
                    {
                        listeMembre = listeMembre.AsQueryable().Where(cl => cl.nom.ToLower().Contains(txtNomMembre.Text.ToLower())).ToList();
                    }
                }

                if (txtPrenomMembre.Text != "")
                {
                    if (txtPrenomMembre.Text.ToCharArray()[txtPrenomMembre.Text.ToCharArray().Length - 1] == '*' && txtPrenomMembre.Text.ToCharArray()[0] == '*')
                    {
                        listeMembre = listeMembre.AsQueryable().Where(cl => cl.prenom.ToLower().Contains(txtPrenomMembre.Text.Substring(1, txtPrenomMembre.Text.ToCharArray().Length - 2).ToLower())).ToList();
                    }

                    else if (txtPrenomMembre.Text.ToCharArray()[txtPrenomMembre.Text.ToCharArray().Length - 1] == '*')
                    {
                        listeMembre = listeMembre.AsQueryable().Where(cl => cl.prenom.ToLower().StartsWith(txtPrenomMembre.Text.Substring(0, txtPrenomMembre.Text.ToCharArray().Length - 1).ToLower())).ToList();
                    }

                    else if (txtPrenomMembre.Text.ToCharArray()[0] == '*')
                    {
                        listeMembre = listeMembre.AsQueryable().Where(cl => cl.prenom.ToLower().EndsWith(txtPrenomMembre.Text.Substring(1).ToLower())).ToList();
                    }

                    else
                    {
                        listeMembre = listeMembre.AsQueryable().Where(cl => cl.prenom.ToLower().Contains(txtPrenomMembre.Text.ToLower())).ToList();
                    }
                }

                if (chbProfesseur.Checked && !chbEtudiant.Checked)
                {
                    listeMembre = listeMembre.AsQueryable().Where(cl => cl is Professeur).ToList();
                }

                else if (!chbProfesseur.Checked && chbEtudiant.Checked)
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