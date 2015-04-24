// Cette classe permet à un étudiant ou professeur de faire un témoignage
// Écrit par Raphael Brouard, Mars 2015
// Intrants: Le string du témoignage
// Extrants: Le témoignage choisi a été sauvegarder dans la BD et POUR les étudiants, la valeur validéTémoignage doit redevenir a false pour être revalidé

using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class FaireTemoignage : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Response.Cookies["TIID"].Value = "9";
                SavoirSiPossedeAutorizationPourLaPage(false, true, true, false, false);

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
                                        txtbLeTemoignageDuConnecte.Text = leMembre.temoignage.Replace("¤","\r");
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
            //Compter les retoures a la lignes comme valeur 1 (Car stocker dans la BD de cette facon)
            int nombreRetourALaLigne = txtbLeTemoignageDuConnecte.Text.Split('\r').Count();

            //C'est soi 0 ou 2 ou plus mais on veut compter les retour a la ligne, pas les 2 partis splitter en fait, donc -1
            if (nombreRetourALaLigne != 0)
            {
                nombreRetourALaLigne--;
            }

            //Premierement vérifier si le témoignage possède le minimum de caractère (3) ou le maximum (1000)
            if (txtbLeTemoignageDuConnecte.Text.Replace("\r", "").Replace("\n","").Length < 3 || 
                txtbLeTemoignageDuConnecte.Text.Replace("\r", "").Replace("\n","").Length + nombreRetourALaLigne > 1000)
            {
               divErreurEnvoiTemoignage.Visible = true;
               lblErreurTemoignage.Text = "Le témoignage doit être entre 3 et 1000 caractères : <b> Vous en avez " + (txtbLeTemoignageDuConnecte.Text.Length + nombreRetourALaLigne) + "</b>";
                
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
                            try
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
                                                lEtudiantConnecte.temoignage = txtbLeTemoignageDuConnecte.Text.Replace("\r", "¤").Replace("\n", "");
                                                lEtudiantConnecte.valideTemoignage = false;

                                                //Créer le log
                                                Model.Log loggerUnLog = new Model.Log();
                                                loggerUnLog.actionLog = "Le témoignage de " + lEtudiantConnecte.prenom + " " + lEtudiantConnecte.nom + " a été créé ou modifié";
                                                loggerUnLog.dateLog = DateTime.Now;
                                                loggerUnLog.typeLog = 0;
                                                loggerUnLog.Utilisateur = lEtudiantConnecte;
                                                loggerUnLog.UtilisateurIDUtilisateur = lEtudiantConnecte.IDUtilisateur;
                                                leModel.LogSet.Add(loggerUnLog);

                                                leModel.SaveChanges();

                                                divSuccesEnvoiTemoignage.Visible = true;
                                                divErreurEnvoiTemoignage.Visible = false;
                                                btnFaireUnTemoignage.Visible = false;
                                            }
                                        }
                                        //Pour prof
                                        else
                                        {
                                            leMembre.temoignage = txtbLeTemoignageDuConnecte.Text.Replace("\r", "¤").Replace("\n","");

                                            //Créer le log
                                            Model.Log loggerUnLog = new Model.Log();
                                            loggerUnLog.actionLog = "Le témoignage de " + leMembre.prenom + " " + leMembre.nom + " a été créé ou modifié";
                                            loggerUnLog.dateLog = DateTime.Now;
                                            loggerUnLog.typeLog = 0;
                                            loggerUnLog.Utilisateur = leMembre;
                                            loggerUnLog.UtilisateurIDUtilisateur = leMembre.IDUtilisateur;
                                            leModel.LogSet.Add(loggerUnLog);

                                            leModel.SaveChanges();

                                            divSuccesEnvoiTemoignage.Visible = true;
                                            divErreurEnvoiTemoignage.Visible = false;
                                            btnFaireUnTemoignage.Visible = false;
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                LogErreur("FaireTemoignage dans la méthode EnvoyerTemoignage_Click", ex);
                            }
                        }
                    }
                }
                //Et pu connecté, donc rediriger
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }
}