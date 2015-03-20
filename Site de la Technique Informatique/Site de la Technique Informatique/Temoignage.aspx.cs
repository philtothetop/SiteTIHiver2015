using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class Temoignage : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Cookies["TIID"].Value = "10";
                // SavoirSiPossedeAutorizationPourLaPage(false, true, true, false);

                //Mettre le témoignage dans le textbox si la personne connecté en a déja un
                //Vérifier si il y a bien un id dans le cookie
                if (Request.Cookies["TIID"] != null)
                {
                    if (Server.HtmlEncode(Request.Cookies["TIID"].Value) != null)
                    {
                        int leIdDuConnecte = 0;

                        try
                        {
                            leIdDuConnecte = Convert.ToInt32(Server.HtmlEncode(Request.Cookies["TIID"].Value));
                        }
                        //Devrais pas arrivé mais au ca ou
                        catch (Exception ex)
                        {
                            LogErreur("Temoignage.aspx.cs dans la méthode Page_Load", ex);
                        }

                        //Si pas de probleme a récupérer le id
                        if (leIdDuConnecte != 0)
                        {
                            using (LeModelTIContainer leModel = new LeModelTIContainer())
                            {
                                Membre leMembre = (from cl in leModel.UtilisateurSet.OfType<Membre>()
                                                   where cl.IDUtilisateur == leIdDuConnecte
                                                   select cl).FirstOrDefault();

                                //Si le membre est trouvé
                                if (leMembre != null)
                                {
                                    if (leMembre.temoignage != null)
                                    {
                                        txtbLeTemoignageDuConnecte.Text = leMembre.temoignage;
                                    }
                                    else
                                    {
                                        txtbLeTemoignageDuConnecte.Text = "";
                                    }
                                }
                                //Si pas trouvé, le rediriger
                                else
                                {
                                    Response.Redirect("Default.aspx");
                                }
                            }
                        }
                    }
                }
                //Au sinon ya pas d'affaire a faire un témoignage
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }


        //Boutton pour envoyer son témoignage
        protected void EnvoyerTemoignage_Click(object sender, EventArgs e)
        {
            //Premierement vérifier si le témoignage possède le minimum/maximum de caractère
            if (txtbLeTemoignageDuConnecte.Text.Length > 1000 || txtbLeTemoignageDuConnecte.Text.Length < 3)
            {
                divErreurEnvoiTemoignage.Visible = true;
                lblErreurTemoignage.Text = "Le témoignage doit être entre 3 et 1000 caractères : <b> Vous en avez " + txtbLeTemoignageDuConnecte.Text.Length + "</b>";
            }
            else
            {
                //Reécupéré le membre courrant connecté
                if (Request.Cookies["TIID"] != null)
                {
                    if (Server.HtmlEncode(Request.Cookies["TIID"].Value) != null)
                    {
                        int leIdDuConnecte = 0;

                        try
                        {
                            leIdDuConnecte = Convert.ToInt32(Server.HtmlEncode(Request.Cookies["TIID"].Value));
                        }
                        //Devrais pas arrivé mais au ca ou
                        catch (Exception ex)
                        {
                            LogErreur("Temoignage.aspx.cs dans la méthode EnvoyerTemoignage", ex);
                        }

                        //Si pas de probleme a récupérer le id
                        if (leIdDuConnecte != 0)
                        {
                            using (LeModelTIContainer leModel = new LeModelTIContainer())
                            {
                                Membre leMembre = (from cl in leModel.UtilisateurSet.OfType<Membre>()
                                                   where cl.IDUtilisateur == leIdDuConnecte
                                                   select cl).FirstOrDefault();

                                //Si le membre est trouvé
                                if (leMembre != null)
                                {
                                    if (leMembre is Etudiant)
                                    {
                                        Model.Etudiant lEtudiantConnecte = (from cl in leModel.UtilisateurSet.OfType<Etudiant>()
                                                                            where cl.IDUtilisateur == leIdDuConnecte
                                                                            select cl).FirstOrDefault();

                                        //Pour étudiant
                                        if (lEtudiantConnecte != null)
                                        {
                                            lEtudiantConnecte.temoignage = txtbLeTemoignageDuConnecte.Text;
                                            lEtudiantConnecte.valideTemoignage = false;
                                            leModel.SaveChanges();
                                            divSuccesEnvoiTemoignage.Visible = true;
                                            divErreurEnvoiTemoignage.Visible = false;
                                            btnFaireUnTemoignage.Visible = false;
                                        }
                                    }
                                    //Pour prof
                                    else
                                    {
                                        leMembre.temoignage = txtbLeTemoignageDuConnecte.Text;
                                        leModel.SaveChanges();
                                        divSuccesEnvoiTemoignage.Visible = true;
                                        divErreurEnvoiTemoignage.Visible = false;
                                        btnFaireUnTemoignage.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /*
        //Validation pour regarder si l'âge est valide
        protected void cvTextLenght_ServerValidate(object source, ServerValidateEventArgs e)
        {
            try
            {
                //Premierement vérifier si le témoignage possède le minimum/maximum de caractère
                if (txtbLeTemoignageDuConnecte.Text.Length > 1000 || txtbLeTemoignageDuConnecte.Text.Length < 3)
                {
                    lblErreurTemoignage.Text = "Le témoignage doit être entre 3 et 1000 caractères : <b> Vous en avez " + txtbLeTemoignageDuConnecte.Text.Length + "</b>";
                    e.IsValid = false;
                }
                else
                {
                    e.IsValid = true;
                }
            }
            catch (Exception ex)
            {
                e.IsValid = false;
            }
        }*/
    }
}