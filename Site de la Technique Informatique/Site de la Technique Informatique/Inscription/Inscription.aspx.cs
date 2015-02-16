using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Site_de_la_Technique_Informatique.Inscription
{
    public partial class Inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public UtilisateurJeu GetUtilisateurEtudiant()
        {

            try
            {
                using (ModelTIContainer leContext = new ModelTIContainer())
                {
                    List<UtilisateurJeu> listUtilisateur = (from cl in leContext.UtilisateurJeu select cl).ToList();
                    UtilisateurJeu nouveauUtilisateur = new UtilisateurJeu();
                    nouveauUtilisateur.UtilisateurJeu_Etudiant = new UtilisateurJeu_Etudiant();
                    listUtilisateur.Add(nouveauUtilisateur);

                    return listUtilisateur.Last();
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public void CreerUtilisateurEtudiant(UtilisateurJeu utilisateurACreer)
        {
            try
            {
                using (ModelTIContainer leContext = new ModelTIContainer())
                {
                    UtilisateurJeu utilisateurACreerCopie = new UtilisateurJeu();

                    //Validation

                    TryUpdateModel(utilisateurACreerCopie);
                    var contextVal = new ValidationContext(utilisateurACreerCopie, serviceProvider: null, items: null);
                    var resultatsValidation = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(utilisateurACreerCopie, contextVal, resultatsValidation, true);

                    //Comparer les mots de passe
                    ListViewItem lviewItem = lviewFormulaireInscription.Items[0];
                    TextBox txtConfirmationMotDePasse = (TextBox)lviewItem.FindControl("txtConfirmationMotDePasse");
                    if (txtConfirmationMotDePasse != null && utilisateurACreerCopie.hashMotDepasse != txtConfirmationMotDePasse.Text)
                    {
                        ValidationResult vald = new ValidationResult("Les mots de passes ne match pas.", new[] { "hashMotDepasse" });
                        isValid = true;
                        resultatsValidation.Add(vald);
                    }
                    //Valider la date de naissance
                    TextBox txtDateNaissanceJour = (TextBox)lviewItem.FindControl("txtDateNaissanceJour");
                    TextBox txtDateNaissanceMois = (TextBox)lviewItem.FindControl("txtDateNaissanceMois");
                    TextBox txtDateNaissanceAnnee = (TextBox)lviewItem.FindControl("txtDateNaissanceAnnee");

                    DateTime dateNaissance = new DateTime();
                    int jour;
                    int mois;
                    int annee;

                    if (!int.TryParse(txtDateNaissanceJour.Text, out jour) || !int.TryParse(txtDateNaissanceMois.Text, out mois) || !int.TryParse(txtDateNaissanceAnnee.Text, out annee))
                    {
                        ValidationResult valdDateNaissance = new ValidationResult("La date de naissance n'est pas valide.", new[] { "dateNaissance" });
                        isValid = true;
                        resultatsValidation.Add(valdDateNaissance);
                    }
                    else
                    {
                        dateNaissance = new DateTime(annee, mois, jour);
                    }
                    //Classes validations

                    if (!isValid)
                    {

                    }
                    else
                    {
                        //Convertir le mot de passe en hashcode
                        utilisateurACreerCopie.hashMotDepasse = GetSHA256Hash(utilisateurACreerCopie.hashMotDepasse);
                        //Date inscription
                        utilisateurACreerCopie.UtilisateurJeu_Etudiant.dateInscription = DateTime.Now;
                        //Date de naissance
                        utilisateurACreerCopie.UtilisateurJeu_Etudiant.dateNaissance = dateNaissance;

                        utilisateurACreerCopie.UtilisateurJeu_Etudiant.IDUtilisateur = utilisateurACreerCopie.IDUtilisateur;
                        utilisateurACreerCopie.UtilisateurJeu_Etudiant.valideCourriel = false;

                        leContext.UtilisateurJeu.Add(utilisateurACreerCopie);
                        leContext.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void cbCondition_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                activer_bouton_Accepter();
            }
            catch (Exception ex)
            {

            }
        }

        protected void lnkAcccepter_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem lviewItem = lviewFormulaireInscription.Items[0];
                CheckBox cbCondition = (CheckBox)lviewItem.FindControl("cbCondition");
                cbCondition.Checked = true;
                activer_bouton_Accepter();
            }
            catch (Exception ex)
            {

            }
        }
        protected void activer_bouton_Accepter()
        {
            ListViewItem lviewItem = lviewFormulaireInscription.Items[0];
            CheckBox cbCondition = (CheckBox)lviewItem.FindControl("cbCondition");
            LinkButton lnkEnvoyer = (LinkButton)lviewItem.FindControl("lnkEnvoyer");
            if (cbCondition.Checked == true)
            {
                lnkEnvoyer.Enabled = true;
                lnkEnvoyer.CssClass = "btn btn-primary";
            }
            else
            {
                lnkEnvoyer.Enabled = false;
                lnkEnvoyer.CssClass = "btn btn-default";
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