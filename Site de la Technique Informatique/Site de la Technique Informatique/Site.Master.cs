using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConnexion_Click(object sender, EventArgs e)
        {
            using (ModelTIContainer lecontexte = new ModelTIContainer())
            {
                try
                {
                    Session["Courriel"] = txtIdentifiant.Text.Trim();
                    string pwdUserConnect = null;
                    string pwdVerification = "";
                    UtilisateurJeu userConnect = new UtilisateurJeu();


                    userConnect = (from user in lecontexte.UtilisateurJeu where user.courriel == txtIdentifiant.Text select user).FirstOrDefault();
                   


                    if (userConnect == null) //si le courriel n'est pas dans la BD
                    {
                        lblMessageConnexion.Text += "Votre courriel n'existe pas dans notre base de données.";
                    }
                    if (userConnect != null) //si le membre existe
                    {
                        pwdUserConnect = GetSHA256Hash(txtPassword.Text); //récupère le mdp
                        pwdVerification = UtilisateurJeu. ; //valide si c'est le bon mdp

                    }
                   
                    if (mdpConnectionMembre == mdpMembreVerif || mdpConnectionEmploye == mdpEmployeVerif) //si ok, donne le bon statut
                    {
                        if (mdpConnectionEmploye == mdpEmployeVerif)
                        { Session["Statut"] = "Admin"; }

                        if (mdpConnectionMembre == mdpMembreVerif)
                        { Session["Statut"] = "Membre"; }

                        // Si le cookie contient la date heure de la dernière connexion
                        if (Request.Cookies["DerniereConnexion"] != null)
                        {
                            Session["DerniereConnexion"] = Request.Cookies["DerniereConnexion"].Value;
                            var cookie = Request.Cookies["DerniereConnexion"];
                            cookie.Value = DateTime.Now.ToString();
                            Response.Cookies.Add(cookie);

                        }
                        // S'il n'y a pas de cookie, on le crée
                        else
                        {
                            //Stocke la date et l'heure de la dernière connexion
                            Response.Cookies["DerniereConnexion"].Value = DateTime.Now.ToString();
                            Session["DerniereConnexion"] = Request.Cookies["DerniereConnexion"].Value;
                            Response.Cookies["DerniereConnexion"].Expires = DateTime.Now.AddDays(50);
                        }

                        lecontexte.SaveChanges();
                        Response.Redirect("accueilMembre.aspx", false);
                    }
                    else
                    {
                        lblMessageConnexion.Text += "Votre courriel ou votre mot de passe n'est pas valide.";
                    }
                }
                catch (Exception ex)
                {
                    Session.Clear();
                    lblMessageConnexion.Text = "Une erreur s'est produite à la connexion.¸.. : " + ex.Message;
                }
            }
        }
    }
}