using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.ComponentModel.DataAnnotations;

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
                    Boolean customValidation = true;
                    TryUpdateModel(utilisateurACreerCopie);
                    var contextVal = new ValidationContext(utilisateurACreerCopie, serviceProvider: null, items: null);
                    var resultatsValidation = new List<ValidationResult>();
                    //Comparer les mots de passe
                    ListViewItem lviewItem = lviewFormulaireInscription.Items[0];
                    TextBox txtConfirmationMotDePasse = (TextBox)lviewItem.FindControl("txtConfirmationMotDePasse");
                    if (txtConfirmationMotDePasse != null && utilisateurACreerCopie.hashMotDepasse != txtConfirmationMotDePasse.Text)
                    {
                        ValidationResult vald = new ValidationResult("Les mots de passes ne match pas.", new[] { "hashMotDepasse" });
                        customValidation = false;
                        resultatsValidation.Add(vald);
                    }
                    //Valider la date de naissance
                    TextBox txtDateNaissanceJour = (TextBox)lviewItem.FindControl("txtDateNaissanceJour");
                    TextBox txtDateNaissanceMois = (TextBox)lviewItem.FindControl("txtDateNaissanceMois");
                    TextBox txtDateNaissanceAnnee = (TextBox)lviewItem.FindControl("txtDateNaissanceAnnee");

                    DateTime dateNaissance=new DateTime();
                    int jour;
                    int mois;
                    int annee;

                    if (!int.TryParse(txtDateNaissanceJour.Text,out jour) || !int.TryParse(txtDateNaissanceMois.Text,out mois) || !int.TryParse(txtDateNaissanceAnnee.Text,out annee))
                    {
                        ValidationResult valdDateNaissance = new ValidationResult("La date de naissance n'est pas valide.", new[] { "dateNaissance" });
                        customValidation = false;
                        resultatsValidation.Add(valdDateNaissance);
                    }
                    else
                    {
                        dateNaissance =new DateTime(jour,mois,annee);
                    }
                    //Classes validations
                    var isValid = Validator.TryValidateObject(utilisateurACreerCopie, contextVal, resultatsValidation, true);
                    if (!isValid)
                    {

                    }
                    else
                    {
                        //Convertir le mot de passe en hashcode
                        utilisateurACreerCopie.hashMotDepasse = utilisateurACreerCopie.hashMotDepasse.GetHashCode().ToString();
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
    }
}