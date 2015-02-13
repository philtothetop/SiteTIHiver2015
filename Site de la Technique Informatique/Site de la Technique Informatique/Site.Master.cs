using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.Security.Cryptography;

namespace Site_de_la_Technique_Informatique
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ModelTIContainer lecontexte = new ModelTIContainer())
            {

                //Verification s'il y a un utilisateur de connecté.

                if (Session["Courriel"] == null) //si le courriel est null, donc personne de connecter
                {
                    lblConnexion.Visible = true; //Affiche le lien de connexion
                    lblEnLigne.Visible = false; //Cache le label donnant le nom de l'utilisateur
                }
                else //donc courriel contient une valeur
                {
                    lblConnexion.Visible = false; //Cache le lien de connexion
                    lblEnLigne.Visible = true; //Affiche le label donnant le nom de l'utilisateur

                    UtilisateurJeu userConnect = new UtilisateurJeu(); //crée un utilisateur
                    userConnect = (from user in lecontexte.UtilisateurJeu where user.courriel == Session["Courriel"].ToString() select user).FirstOrDefault(); //va chercher l'utilisateur correspondant au courriel

                    lblEnLigne.Text = userConnect.prenom + " " + userConnect.nom; //Envoie le prénom nom de l'utilisateur dans le label
                }
            }
        }

        //Connexion
        protected void btnConnexion_Click(object sender, EventArgs e)
        {
            using (ModelTIContainer lecontexte = new ModelTIContainer())
            {
                try
                {
                    Session["Courriel"] = txtIdentifiant.Text.Trim(); //envoie le courriel entré dans l'objet session
                    string pwdUserConnect = null; //Permet de stocker le mot de passe entré et hashé
                    string pwdVerification = ""; //Permet de stocker le mot de passe hashé de la BD
                    UtilisateurJeu userConnect = new UtilisateurJeu(); //Crée un utilisateur vide

                    userConnect = (from user in lecontexte.UtilisateurJeu where user.courriel == txtIdentifiant.Text select user).FirstOrDefault(); //Va chercher l'utilisateur qui correspond au courriel

                    if (userConnect == null) //si le courriel n'est pas dans la BD
                    {
                        lblMessageConnexion.Text += "Votre courriel n'existe pas dans notre base de données.";
                        Session["Courriel"] = null; //enlève la valeur de l'objet session
                        Response.Redirect("default.aspx#myModal", false);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    }
                    if (userConnect != null) //si le membre existe
                    {
                        pwdUserConnect = GetSHA256Hash(txtPassword.Text); //récupère le mdp
                        pwdVerification = userConnect.courriel ; //valide si c'est le bon mdp
                    }

                    if (pwdUserConnect == pwdVerification) //si ok, donne le bon statut
                    {
                        Session["Connexion"] = "Oui"; 
                        Response.Redirect("default.aspx", false);
                        LogJeu log = new LogJeu();
                        log.dateLog = DateTime.Now;
                        log.actionLog = userConnect.prenom + " " + userConnect.nom + "s'est connecté au site.";
                    }
                    else
                    {
                        lblMessageConnexion.Text += "Votre courriel ou votre mot de passe n'est pas valide."; //Avertis que le mot de passe est incorrect
                        Session["Courriel"] = null; //enlève la valeur de l'objet session
                        txtIdentifiant.Text = ""; //reset le textbox identifiant
                        txtPassword.Text = "";//reset le textbox password
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
                    }
                }
                catch (Exception ex) //au cas où ça marcherait pas
                {
                    Session.Clear();
                    lblMessageConnexion.Text = "Une erreur s'est produite à la connexion.¸.. : " + ex.Message;
                }
            }
        }

        //pour hasher le mot de passe
        public string GetSHA256Hash(string s)
        {

            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentException("Une valeur nulle ne peut être hashée.");
            }


            Byte[] data = System.Text.Encoding.UTF8.GetBytes(s);
            Byte[] hash = new SHA256CryptoServiceProvider().ComputeHash(data);
            string hashMdp = Convert.ToBase64String(hash);
            return hashMdp;
        }
    }
}