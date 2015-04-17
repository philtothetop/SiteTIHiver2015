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
            //Verification s'il y a un utilisateur de connecté.

            if (Request.Cookies["TIUtilisateur"] == null || Server.HtmlEncode(Request.Cookies["TIUtilisateur"].Value) == "") //si l'utilisateur est null, donc personne de connecter
            {
                lblConnexion.Visible = true; //Affiche le lien de connexion
                lblEnLigne.Visible = false; //Cache le label donnant le nom de l'utilisateur
                lblInscription.Visible = true; //remet le lien inscription car possibilité de nouvel utilisateur
                lblOffresEmploi.Visible = false; // Même chose que les autres
                liConnexion.Visible = false;
                lblForum.Visible = false;
            }
            else //donc utilisateur contient une valeur
            {
                lblConnexion.Visible = false; //Cache le lien de connexion
                lblEnLigne.Visible = true; //Affiche le label donnant le nom de l'utilisateur
                lblInscription.Visible = false; //enlève le lien Inscription car un user existant n'a plus besoin de s'inscrire... pis ça fait de la place
                lblOffresEmploi.Visible = true; // Même chose que les autres
                liConnexion.Visible = true;
                lblForum.Visible = true;

               

                if (Request.Cookies["TINom"] == null) //si le nom est null, ce qui ne peut pas arriver mais on fait ici plaisir à Raph
                {
                    Response.Cookies["TINom"].Value = "Oups..."; //mets un nom bidon pour le 0.0000000000000000001% de chance que ça ne marche pas
                }
                lblEnLigne.Text = Server.HtmlEncode(Request.Cookies["TINom"].Value); //Envoie le prénom nom de l'utilisateur dans le label
            }
        }

        //Connexion
        protected void btnConnexion_Click(object sender, EventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                try //au cas où que ya une erreur
                {
                    Response.Cookies["TICourriel"].Value = txtIdentifiant.Text.Trim(); //envoie le courriel entré dans le cookie
                    string pwdUserConnect = null; //Permet de stocker le mot de passe entré et hashé
                    string pwdVerification = ""; //Permet de stocker le mot de passe hashé de la BD
                    Utilisateur userConnect = new Utilisateur(); //Crée un utilisateur vide

                    lblMessageConnexion.Text = ""; //vide le label de message d'erreur

                    userConnect = (from user in lecontexte.UtilisateurSet where user.courriel == txtIdentifiant.Text select user).FirstOrDefault(); //Va chercher l'utilisateur qui correspond au courriel

                    if (userConnect == null) //si le courriel n'est pas dans la BD
                    {
                        lblMessageConnexion.Text += "Votre courriel n'existe pas dans notre base de données."; //l'utilisateur n'a pas de courriel dans la BD (ou il a fait une faute de frappe)
                        Response.Cookies["TICourriel"].Value = null; //enlève le mauvais courriel du cookie
                    }
                    if (userConnect != null) //si le membre existe
                    {
                        pwdUserConnect = GetSHA256Hash(txtPassword.Text); //récupère le mdp entré et le hash
                        pwdVerification = userConnect.hashMotDePasse; //va chercher le mdp hashé présent dans la BD
                    }

                    if (pwdUserConnect == pwdVerification) //si ok, donne le bon statut
                    {

                        //Crée des user par profil pour éventuellement trouver le type
                        Model.Admin userAdmin = (from user in lecontexte.Set<Model.Admin>() where user.IDUtilisateur == userConnect.IDUtilisateur select user).FirstOrDefault(); //admin (le model. est essentiel à cause de la sous masterpage)
                        Employeur userEmpl = (from user in lecontexte.Set<Employeur>() where user.IDUtilisateur == userConnect.IDUtilisateur select user).FirstOrDefault(); //employeur
                        Etudiant userEtu = (from user in lecontexte.Set<Etudiant>() where user.IDUtilisateur == userConnect.IDUtilisateur select user).FirstOrDefault(); //etudiant
                        Professeur userProf = (from user in lecontexte.Set<Professeur>() where user.IDUtilisateur == userConnect.IDUtilisateur select user).FirstOrDefault(); //prof
                        Membre userMembre = (from user in lecontexte.Set<Membre>() where user.IDUtilisateur == userConnect.IDUtilisateur select user).FirstOrDefault(); //à cause de l'héritage, ça prend membre pour avoir certains nom + pr.nom

                        //Si c'est un admin
                        if (userAdmin != null)
                        {
                            Response.Cookies["TIUtilisateur"].Value = "Admin"; //On indique le type
                            Response.Cookies["TINom"].Value = "Admin"; //On entre à bras le nom "Admin" car non stocké dans la BD
                            Response.Cookies["TIID"].Value = userConnect.IDUtilisateur.ToString(); //Stocke le ID Utilisateur 
                        }

                        //Si c'est un employeur
                        if (userEmpl != null)
                        {
                            if (userEmpl.valideCourriel == true) //ça prend un courriel validé
                            {
                                Response.Cookies["TIUtilisateur"].Value = "Employeur"; //On indique le type
                                Response.Cookies["TINom"].Value = userEmpl.nomEmployeur.ToString(); //On récupère le nom d'employeur
                                Response.Cookies["TIID"].Value = userConnect.IDUtilisateur.ToString(); //Stocke le ID Utilisateur 

                            }
                            else //oups, pas de courriel valide
                            {
                                lblMessageConnexion.Text = "Votre courriel n'a pas été validé. Veuillez réessayer ultérieurement"; //petit warning à l'utilisateur
                                Response.Cookies["TICourriel"].Value = null; //enlève la valeur du cookie
                            }
                        }

                        //Si c'est un étudiant
                        if (userEtu != null)
                        {
                            if (userEtu.compteActif == 1) //ça prend un compte validé
                            {
                                Response.Cookies["TIUtilisateur"].Value = "Etudiant"; //On indique le type d'usager
                                Response.Cookies["TINom"].Value = userMembre.prenom + " " + userMembre.nom; //on récupère le nom + prénom de membre
                                Response.Cookies["TIID"].Value = userConnect.IDUtilisateur.ToString(); //Stocke le ID Utilisateur 
                            }
                            else //oups, courriel non validé
                            {
                                lblMessageConnexion.Text = "Votre courriel n'a pas été validé. Veuillez réessayer ultérieurement"; //warning à l'usager
                                Response.Cookies["TICourriel"].Value = null; //enlève la valeur du cookie
                            }
                        }

                        //Si c'est un prof
                        if (userProf != null)
                        {
                            Response.Cookies["TIUtilisateur"].Value = "Professeur"; //On indique le type d'usager
                            Response.Cookies["TINom"].Value = userMembre.prenom + " " + userMembre.nom; //on récupère le nom + prénom de membre
                            Response.Cookies["TIID"].Value = userConnect.IDUtilisateur.ToString(); //Stocke le ID Utilisateur 
                        }

                    }
                    else //Si aucun usager correspondant dans la BD
                    {
                        lblMessageConnexion.Text += "Votre courriel ou votre mot de passe n'est pas valide."; //Avertis que le mot de passe est incorrect
                        Response.Cookies["TICourriel"].Value = null; //enlève la valeur du cookie
                        txtIdentifiant.Text = ""; //reset le textbox identifiant
                        txtPassword.Text = "";//reset le textbox password
                    }
                }
                catch (Exception ex) //au cas où ça marcherait pas
                {
                    lblMessageConnexion.Text = "Une erreur s'est produite à la connexion.¸.. : " + ex.Message;
                }

                if (Request.Cookies["TIUtilisateur"] != null) //si l'utilisateur est en ordre et peut se connecter, on log l'info, et on reload la page
                {

                    Model.Log log = new Model.Log(); //crée une entrée de log
                    log.dateLog = DateTime.Now; //on met la date du jour
                    log.typeLog = 0; //connexion est de type 0
                    log.actionLog = Server.HtmlEncode(Request.Cookies["TINom"].Value) + " s'est connecté au site."; //on met l'action
                    lecontexte.LogSet.Add(log); //on ajoute au log
                    lecontexte.SaveChanges(); //on sauvegarde dans la BD

                    ScriptManager.RegisterStartupScript(this, GetType(), "myModal", "$(function(){closeModal();});", true); //on ferme le modal

                    Response.Redirect(Request.RawUrl, false); //on reload la page. Ça reload la page d'où le modal a été lancé
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

        //Bouton Déconnexion
        protected void lnkbtnDeconnexion_Click(object sender, EventArgs e)
        {
            Response.Cookies["TICourriel"].Value = ""; //enlève la valeur du cookie
            Response.Cookies["TINom"].Value = ""; //enlève la valeur du cookie
            Response.Cookies["TIID"].Value = ""; //enlève la valeur du cookie
            Response.Cookies["TIUtilisateur"].Value = ""; //enlève la valeur du cookie

            Response.Redirect(Request.RawUrl, false); // reload la page depuis laquelle la déconnexion a été appellée
        }
    }
}
