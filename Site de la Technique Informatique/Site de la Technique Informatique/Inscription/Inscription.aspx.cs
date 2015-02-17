//code C# page d'inscription
//Écrit par Cédric Archambault
//
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
    public partial class Inscription : Site
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Cette classe permet de créer un nouveau membre Utilisateur vide pour afficher dans le listeview.
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants: aucun
        //Extrants:Utilisateur
        public Utilisateur GetUtilisateurEtudiant()
        {

            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    List<Utilisateur> listUtilisateur = (from cl in leContext.UtilisateurSet select cl).ToList();
                    Utilisateur nouveauUtilisateur = new Utilisateur();
                    listUtilisateur.Add(nouveauUtilisateur);

                    return listUtilisateur.Last();
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        //Cette class permet de valider l'utilisateur qui est a l'écran et sauvegarder dans la BD
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants:Etudiant
        //Extrants:Aucun
        public void CreerUtilisateurEtudiant(Etudiant etudiantACreer)
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    Etudiant etudiantACreerCopie = new Etudiant();

                    //Validation

                    TryUpdateModel(etudiantACreerCopie);
                    var contextVal = new ValidationContext(etudiantACreerCopie, serviceProvider: null, items: null);
                    var resultatsValidation = new List<ValidationResult>();
                    var isValid = Validator.TryValidateObject(etudiantACreerCopie, contextVal, resultatsValidation, true);

                    //Comparer les mots de passe
                    ListViewItem lviewItem = lviewFormulaireInscription.Items[0];
                    TextBox txtConfirmationMotDePasse = (TextBox)lviewItem.FindControl("txtConfirmationMotDePasse");
                    if (txtConfirmationMotDePasse != null && etudiantACreerCopie.hashMotDePasse != txtConfirmationMotDePasse.Text)
                    {
                        ValidationResult vald = new ValidationResult("Les mots de passes ne match pas.", new[] { "hashMotDepasse" });
                        isValid = true;
                        resultatsValidation.Add(vald);
                    }
                    //Valider la date de naissance
                    TextBox txtDateNaissanceJour = (TextBox)lviewItem.FindControl("txtDateNaissanceJour");
                    TextBox txtDateNaissanceMois = (TextBox)lviewItem.FindControl("txtDateNaissanceMois");
                    TextBox txtDateNaissanceAnnee = (TextBox)lviewItem.FindControl("txtDateNaissanceAnnee");

                    int jour;
                    int mois;
                    int annee;

                    if (!int.TryParse(txtDateNaissanceJour.Text, out jour) || !int.TryParse(txtDateNaissanceMois.Text, out mois) || !int.TryParse(txtDateNaissanceAnnee.Text, out annee))
                    {
                        etudiantACreerCopie.dateNaissance = new DateTime();
                    }
                    else
                    {
                        etudiantACreerCopie.dateNaissance = new DateTime(annee, mois, jour);
                    }
                    //Classes validations

                    if (!isValid)
                    {

                    }
                    else
                    {
                        //Convertir le mot de passe en hashcode
                        etudiantACreerCopie.hashMotDePasse = GetSHA256Hash(etudiantACreerCopie.hashMotDePasse);
                        //Date inscription
                        etudiantACreerCopie.dateInscription = DateTime.Now;
                        etudiantACreerCopie.valideCourriel = false;
                        etudiantACreerCopie.compteActif = false;

                        leContext.UtilisateurSet.Add(etudiantACreerCopie);
                        leContext.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        //Cette class permet des/active le bouton accepter par le checkbox
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants:sende,e
        //Extrants:Aucun
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
        //Cette class permet des/active le bouton accepter par le link  Accepter
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants:sende,e
        //Extrants:Aucun
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
        //Cette class permet des/active le bouton accepter
        //Écrit par Cédric Archambault 17 février 2015
        //Intrants:aucun
        //Extrants:Aucun
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

    }
}