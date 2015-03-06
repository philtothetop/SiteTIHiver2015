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

            if (IsPostBack)
            {

                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {

                    //if (Request.Cookies["userName"] != null)
                    //    Label1.Text = Server.HtmlEncode(Request.Cookies["userName"].Value);

                    //Verification s'il y a un utilisateur de connecté.

                    if (Request.Cookies["TIUtilisateur"] == null) //si l'utilisateur est null, donc personne de connecter
                    {
                        lblConnexion.Visible = true; //Affiche le lien de connexion
                        lblEnLigne.Visible = false; //Cache le label donnant le nom de l'utilisateur
                    }
                    else //donc utilisateur contient une valeur
                    {
                        lblConnexion.Visible = false; //Cache le lien de connexion
                        lblEnLigne.Visible = true; //Affiche le label donnant le nom de l'utilisateur

                        Utilisateur userConnect = new Utilisateur(); //crée un utilisateur
                        userConnect = (from user in lecontexte.UtilisateurSet where user.courriel == Server.HtmlEncode(Request.Cookies["TICourriel"].Value) select user).FirstOrDefault(); //va chercher l'utilisateur correspondant au courriel

                        lblEnLigne.Text = Server.HtmlEncode(Request.Cookies["TINom"].Value); //Envoie le prénom nom de l'utilisateur dans le label
                    }
                }
            }
        }

        //Connexion
        protected void btnConnexion_Click(object sender, EventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {

                //prochain test à faire, enlever le try
                try
                {
                    //Session.Abandon(); //détruit les sessions existantes
                    //Session["Courriel"] = txtIdentifiant.Text.Trim(); //envoie le courriel entré dans l'objet session
                    Response.Cookies["TICourriel"].Value = txtIdentifiant.Text.Trim();
                    string pwdUserConnect = null; //Permet de stocker le mot de passe entré et hashé
                    string pwdVerification = ""; //Permet de stocker le mot de passe hashé de la BD
                    Utilisateur userConnect = new Utilisateur(); //Crée un utilisateur vide


                    userConnect = (from user in lecontexte.UtilisateurSet where user.courriel == txtIdentifiant.Text select user).FirstOrDefault(); //Va chercher l'utilisateur qui correspond au courriel

                    if (userConnect == null) //si le courriel n'est pas dans la BD
                    {
                        lblMessageConnexion.Text += "Votre courriel n'existe pas dans notre base de données.";
                        //Session["Courriel"] = null; //enlève la valeur de l'objet session
                        Response.Cookies["TICourriel"].Value = "";
                    }
                    if (userConnect != null) //si le membre existe
                    {
                        pwdUserConnect = GetSHA256Hash(txtPassword.Text); //récupère le mdp
                        pwdVerification = userConnect.hashMotDePasse; //valide si c'est le bon mdp
                    }

                    if (pwdUserConnect == pwdVerification) //si ok, donne le bon statut
                    {

                        //Crée des user par profil pour éventuellement trouver le type
                        Model.Admin userAdmin = (from user in lecontexte.Set<Model.Admin>() where user.IDUtilisateur == userConnect.IDUtilisateur select user).FirstOrDefault();
                        Employeur userEmpl = (from user in lecontexte.Set<Employeur>() where user.IDUtilisateur == userConnect.IDUtilisateur select user).FirstOrDefault();
                        Etudiant userEtu = (from user in lecontexte.Set<Etudiant>() where user.IDUtilisateur == userConnect.IDUtilisateur select user).FirstOrDefault();
                        Professeur userProf = (from user in lecontexte.Set<Professeur>() where user.IDUtilisateur == userConnect.IDUtilisateur select user).FirstOrDefault();
                        Membre userMembre = (from user in lecontexte.Set<Membre>() where user.IDUtilisateur == userConnect.IDUtilisateur select user).FirstOrDefault();

                        //Si c'est un admin

                        if (userAdmin != null)
                        {
                            Session["Utilisateur"] = "Admin";
                            Session["Nom"] = "Admin";
                        }

                        //Si c'est un employeur
                        if (userEmpl != null)
                        {
                            if (userEmpl.valideCourriel == true)
                            {
                                Session["Utilisateur"] = "Employeur";
                                Session["Nom"] = userEmpl.nomEmployeur.ToString();
                            }
                            else
                            {
                                lblMessageConnexion.Text = "Votre courriel n'a pas été validé. Veuillez réessayer ultérieurement";
                                Session["Courriel"] = null; //enlève la valeur de l'objet session
                            }
                        }

                        //Si c'est un étudiant
                        if (userEtu != null)
                        {
                            if (userEtu.valideCourriel == true)
                            {
                                //Session["Utilisateur"] = "Etudiant";
                                //Session["Nom"] = userMembre.prenom + " " + userMembre.nom;
                                Response.Cookies["TIUtilisateur"].Value = "Etudiant";
                                Response.Cookies["TINom"].Value = userMembre.prenom + " " + userMembre.nom;
                            }
                            else
                            {
                                lblMessageConnexion.Text = "Votre courriel n'a pas été validé. Veuillez réessayer ultérieurement";
                                Response.Cookies["TICourriel"].Value = ""; //enlève la valeur de l'objet session
                            }
                        }

                        //Si c'est un prof

                        if (userProf != null)
                        {
                            Session["Utilisateur"] = "Professeur";
                            Session["Nom"] = userMembre.prenom + " " + userMembre.nom;
                        }

                        //tests

                        string s1 = Session["Utilisateur"].ToString();
                        string s2 = Session["Nom"].ToString();


                    }
                    else
                    {
                        lblMessageConnexion.Text += "Votre courriel ou votre mot de passe n'est pas valide."; //Avertis que le mot de passe est incorrect
                        Session["Courriel"] = null; //enlève la valeur de l'objet session
                        txtIdentifiant.Text = ""; //reset le textbox identifiant
                        txtPassword.Text = "";//reset le textbox password
                    }
                }
                catch (Exception ex) //au cas où ça marcherait pas
                {
                    //Session.Clear();
                    lblMessageConnexion.Text = "Une erreur s'est produite à la connexion.¸.. : " + ex.Message;
                }

                if (Request.Cookies["TIUtilisateur"] != null)
                {

                    Model.Log log = new Model.Log();
                    log.dateLog = DateTime.Now;
                    log.typeLog = 0;
                    log.actionLog = Server.HtmlEncode(Request.Cookies["TINom"].Value) + " s'est connecté au site.";
                    lecontexte.LogSet.Add(log);
                    lecontexte.SaveChanges();

                    ScriptManager.RegisterStartupScript(this, GetType(), "myModal", "$(function(){closeModal();});", true);

                    Response.Redirect(Request.RawUrl, false);

                    //Server.Transfer("default.aspx");


                    //Response.Redirect("default.aspx", false);
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
