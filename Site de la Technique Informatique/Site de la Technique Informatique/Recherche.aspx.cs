//Permet de rechercher un étudiants ou un professeur
//Initialement écrit par Francis Trépanier le "?"
//Modifier/Optimizé par Raphael Brouard le 8 Mai 2015 (Les try catch et la recherche va chercher QUE les membres requis dès le départ)


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class Recherche : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, true, true, false);
        }

        public IQueryable<Site_de_la_Technique_Informatique.Model.Membre> lviewRecherche_GetData()
        {
            List<Model.Membre> listeMembre = new List<Membre>();

            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    string textRecherche = txtNomMembre.Text.ToLower().Replace(" ","");

                   if(textRecherche.Equals("minecraft"))
                   {     
                        //Francis's Easter Egg
                        Response.Redirect("https://www.youtube.com/watch?v=I-sH53vXP2A");
                   }

                    //Si les 2 checks box son coché ou aucun des deux
                    if ((chkbEtudiant.Checked == true && chkbProfesseur.Checked == true)
                         || (chkbEtudiant.Checked == false && chkbProfesseur.Checked == false))
                    {
                        listeMembre = (from cl in lecontexte.UtilisateurSet.OfType<Model.Membre>()
                                       where ((cl.nom.ToLower() + cl.prenom.ToLower()).Contains(textRecherche) ||
                                             (cl.prenom.ToLower() + cl.nom.ToLower()).Contains(textRecherche)) &&
                                              cl.compteActif == 1
                                       select cl).ToList();
                    }
                    //Si que etudiants
                    else if (chkbEtudiant.Checked == true)
                    {
                        listeMembre = (from cl in lecontexte.UtilisateurSet.OfType<Model.Membre>()
                                       where cl is Model.Etudiant && ((cl.nom.ToLower() + cl.prenom.ToLower()).Contains(textRecherche) ||
                                                                     (cl.prenom.ToLower() + cl.nom.ToLower()).Contains(textRecherche)) &&
                                                                      cl.compteActif == 1
                                       select cl).ToList();
                    }
                    //Si prof
                    else if (chkbProfesseur.Checked == true)
                    {
                        listeMembre = (from cl in lecontexte.UtilisateurSet.OfType<Model.Membre>()
                                       where cl is Model.Professeur && ((cl.nom.ToLower() + cl.prenom.ToLower()).Contains(textRecherche) ||
                                                                       (cl.prenom.ToLower() + cl.nom.ToLower()).Contains(textRecherche)) &&
                                                                        cl.compteActif == 1
                                       select cl).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Recherche.aspx.cs dans la méthode lviewRecherche_GetData", ex);
            }

            //Data pager juste quadn besoin
            if (listeMembre.Count > dataPagerRecherche.PageSize)
            {
                dataPagerRecherche.Visible = true;
            }
            else
            {
                dataPagerRecherche.Visible = false;
            }

            return listeMembre.AsQueryable();
        }

        protected void btnRecherche_Click(object sender, EventArgs e)
        {
            lviewRecherche.DataBind();
        }

        protected void lnkMembre_Click(object sender, EventArgs e)
        {
            try
            {
                String argument = Convert.ToString(((LinkButton)sender).CommandArgument);

                //Si id pas null
                if (argument != null)
                {
                    //Si id n'est pas administrateur
                    if (!argument.Equals("0"))
                    {
                        using (LeModelTIContainer modelTI = new LeModelTIContainer())
                        {
                            int id = Convert.ToInt32(argument);

                            Utilisateur trouverUtilisateur = new Utilisateur();
                            trouverUtilisateur = null;
                            trouverUtilisateur = (from cl in modelTI.UtilisateurSet
                                                  where cl.IDUtilisateur == id
                                                  select cl).FirstOrDefault();

                            //Si utilisateur est trouvé
                            if (trouverUtilisateur != null)
                            {
                                //Si est un prof
                                if (trouverUtilisateur is Professeur)
                                {
                                    Response.Redirect("ProfilProfesseur.aspx?id=" + trouverUtilisateur.IDUtilisateur);
                                }
                                //Si étudian
                                else if (trouverUtilisateur is Etudiant)
                                {
                                    Response.Redirect("ProfilEtudiant.aspx?id=" + trouverUtilisateur.IDUtilisateur);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Recherche.aspx.cs dans la méthode lnkMembre_Click", ex);
            }
        }
    }
}