// Page qui permet aux professeurs et aux administrateurs d'ajouter un autre professeur (nom, prénom, courriel, mot de passe généré auto)
// Écrit par Philippe Baron, Février 2015

using Site_de_la_Technique_Informatique.Classes;
using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;

namespace Site_de_la_Technique_Informatique
{
    public partial class AjoutProfesseur :ErrorHandling
    {

        #region Page_Events
        protected void Page_Load(object sender, EventArgs e)
        {
             SavoirSiPossedeAutorizationPourLaPage(true, true, false, false);
        }

        //Envoie le mot de passe
        protected void lnkEnvoyer_Click(object sender, EventArgs e)
        {
            try
            {
                creerProfesseur();

                if (string.IsNullOrEmpty(lblMessages.Text))
                {

                    divAjoutProf.Visible = false;
                    divComplete.Visible = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Retour à l'Accueil
        protected void lnkRetourAccueil_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        #endregion

        //Va checher le professeur 
        public Professeur getProfesseur()
        {
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    List<Professeur> lesProfs = (from cl in lecontexte.UtilisateurSet.OfType<Professeur>() select cl).ToList();

                    Professeur newProf = new Professeur();

                    lesProfs.Add(newProf);
                    return lesProfs.Last();
                }
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

            catch (Exception)
            {
                throw;
            }
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
        //Envoie le mot de passe généré
   

     
    }
}