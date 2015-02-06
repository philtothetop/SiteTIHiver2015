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
                        pwdVerification = userConnect.courriel ; //valide si c'est le bon mdp

                    }

                    if (pwdUserConnect == pwdVerification) //si ok, donne le bon statut
                    {
                        Session["Connexion"] = "Oui"; 

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