// Page qui permet a ladministateur supreme d'ajouter un autre professeur ou de le supprimer (nom, prénom, courriel, mot de passe généré auto)
// Écrit par Philippe Baron, Février 2015
// Modifier pour pourvoir supprimer un professeur le 5 mai 2015 par Raphael Brouard

using Site_de_la_Technique_Informatique.Classes;
using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_AjouteSupprimeProf : ErrorHandling
    {
        #region Page_Events
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(true, false, false, false, false);
        }

        #endregion

        //Envoie le mot de passe
        protected void lnkEnvoyer_Click(object sender, EventArgs e)
        {
            try
            {
                creerProfesseur();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Créée le professeur selon les informations reçues 
        public void creerProfesseur()
        {
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {

                    Professeur nouveauProf = new Professeur();


                    var tempPassword = GetRandomHexNumber(8);
                    var hash = new hash();

                    nouveauProf.hashMotDePasse = hash.GetSHA256Hash(tempPassword);
                    nouveauProf.dateInscription = DateTime.Now;
                    nouveauProf.compteActif = 1;

                    nouveauProf.prenom = txtPrenom.Text.Trim();
                    nouveauProf.nom = txtNom.Text.Trim();
                    nouveauProf.courriel = txtCourriel.Text.Trim();
                    nouveauProf.pathPhotoProfil = "photobase.bmp";
                    nouveauProf.photoDescription = "";
                    nouveauProf.temoignage = "";
                    nouveauProf.dateTemoignage = DateTime.Now;

                    lecontexte.UtilisateurSet.Add(nouveauProf);

                    try
                    {

                        var contextval = new ValidationContext(nouveauProf, null, null);
                        var results = new List<ValidationResult>();
                        var isValid = Validator.TryValidateObject(nouveauProf, contextval, results);

                        if (isValid)
                        {

                            Model.Log logEntry = new Model.Log
                            {
                                dateLog = DateTime.Now,
                                actionLog = nouveauProf.prenom + " " + nouveauProf.nom + " a été ajouté à la table des professeurs",
                                typeLog = 3
                            };

                            lecontexte.LogSet.Add(logEntry);
                            lecontexte.SaveChanges();

                            divAjoutProf.Visible = false;
                            divComplete.Visible = true;

                            //Envoyer le mail
                            sendPassword(tempPassword, nouveauProf);
                        }
                        else
                        {
                            foreach (var validationResult in results)
                            {
                                lblMessages.Text += validationResult.ErrorMessage;
                            }

                        }


                        lblMessages.Text = "";
                    }
                    catch (DbEntityValidationException ex)
                    {

                        lblMessages.Text = "";
                        foreach (DbEntityValidationResult failure in ex.EntityValidationErrors)
                        {
                            foreach (DbValidationError lerror in failure.ValidationErrors)
                            {
                                lblMessages.Text += string.Format("{0} {1} ", "<b>" + lerror.PropertyName + "</b>", lerror.ErrorMessage + " <br /> ");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Dans Admin_AjouterSupprimerProf dans la méthode creerProfesseur", ex);
            }
        }


        private void ResetLesChamps()
        {
            txtPrenom.Text = "";
            txtNom.Text = "";
            txtCourriel.Text = "";
        }


        #region création et envoi MP
        private void sendPassword(string tempPassword, Professeur nouveauProf)
        {

            String titre = "Inscription Professeur TI Cegep de Granby";
            String message = "Bonjour, <br/>" +
                 "Un administrateur vous a ajouté en tant qu'Utilisateur Professeur sur le site de la technique informatique du Cégep de Granby." + " Vous pouvez dès maintenant vous connecter sur le site à l'aide des informations de connexion suivantes:<br/> <br/>" +
                "Courriel: " + nouveauProf.courriel + "<br/>" +
            "Mot de Passe: " + tempPassword + "<br/> <br/>" +
            "Veuillez S.V.P. changer votre mot de passe lors de votre première connexion. <br/>" +
            "Merci, <br/>" +
            "Les administrateurs du site de la technique d'informatique de gestion<br/>" +
            "Cégep de Granby.";

            courrielAutomatiser courriel = new courrielAutomatiser();

            bool courrielBool = courriel.envoie(nouveauProf.courriel, titre, message);
        }

        static Random random = new Random();

        //Génère un nombre hexa aléatoire pour le mot de passe
        public static string GetRandomHexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }
        #endregion

        protected void btnAllezSupprimerProf_Click(object sender, EventArgs e)
        {
            mViewAjoutSupprime.ActiveViewIndex = 1;
        }

        protected void btnAllezAjouterProf_Click(object sender, EventArgs e)
        {
            mViewAjoutSupprime.ActiveViewIndex = 0;
        }


        //Récupérer tout les professeurs
        public IQueryable<Site_de_la_Technique_Informatique.Model.Professeur> GetLesProfs()
        {
            List<Professeur> listProfs = new List<Professeur>();

            try
            {
                //Récupérer de la BD
                using (LeModelTIContainer modelTI = new LeModelTIContainer())
                {
                    listProfs = (from cl in modelTI.UtilisateurSet.OfType<Professeur>()
                                 where cl.compteActif == 1
                                 select cl).ToList();
                }
            }
            catch (Exception ex)
            {
                LogErreur("Admin_AjouteSupprimeProf.aspx.cs dans la fonction GetLesProfs", ex);
            }

            //Mettre datapager visible ou non si il y a plus d'élément que de nobmre montré sru une page
            if (listProfs.Count() <= dataPagerProfs.PageSize)
            {
                dataPagerProfs.Visible = false;
            }
            else
            {
                dataPagerProfs.Visible = true;
            }

            return listProfs.AsQueryable();
        }

        protected void btnSupprimerProf_Click(object sender, EventArgs e)
        {
            try
            {
                int leProfIDUtilisateur = Convert.ToInt32(((Button)sender).CommandArgument);

                using (LeModelTIContainer modelTI = new LeModelTIContainer())
                {
                    //Trouver le prof dans la bd
                    Professeur leProfADelete = new Professeur();
                    leProfADelete = null;
                    leProfADelete = (from cl in modelTI.UtilisateurSet.OfType<Professeur>()
                                     where cl.IDUtilisateur == leProfIDUtilisateur
                                     select cl).FirstOrDefault();

                    //Si le prof est trouvé
                    if (leProfADelete != null)
                    {
                        //Mettre le prof a non valide (valeur 2 a compte actif)
                        leProfADelete.compteActif = 2;
                        modelTI.SaveChanges();
                        lviewLesProfs.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Admin_AjouteSupprimeProf.aspx.cs dans la fonction btnSupprimerProf_Click", ex);
            }
        }

        //Si click sur photo profil por pour allez a son profil
        protected void photoProfil_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string leProfIDUtilisateur = ((ImageButton)sender).CommandArgument;
            
            if (isLocal())
            {
                Response.Redirect("~/Response.Redirect(ProfilProfesseur.aspx?id=" + leProfIDUtilisateur);
            }
            else
            {
                Response.Redirect("~/../Response.Redirect(ProfilProfesseur.aspx?id=" + leProfIDUtilisateur);
            }
        }

        protected void lnkAjouterUnAutreProf_Click(object sender, EventArgs e)
        {
            ResetLesChamps();
            divAjoutProf.Visible = true;
            divComplete.Visible = false;
        }
    }
}