// Page qui permet aux étudiants de modifier leur profil (photo de profil, nom, prénom, date de naissance, mot de passe)
// Écrit par Marie-Philippe Gill, Février 2015

using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class modifProfilEtudiant : System.Web.UI.Page
    {
        // va contenir le courriel modifié 
        string courrielModifie = "";

        #region Évènements de la page
        protected void Page_Load(object sender, EventArgs e)
        {
            // Pour tests seulement pendant que la connexion était non fonctionnelle !! à enlever 
            Session["Courriel"] = "marie-philippe.gill@hotmail.ca";
            // fin de la partie pour test à effacer
        }
        #endregion

        #region Évènements du lvModifProfilEtudiant
        public IQueryable<Etudiant> SelectEtudiant()
        {
            List<Etudiant> etudiantCo = null;

            string courriel = Session["Courriel"].ToString();
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                try
                {
                    etudiantCo = ((from etu in lecontexte.UtilisateurSet.OfType<Membre>().OfType<Etudiant>() where etu.courriel == courriel select etu).ToList());
                }
                catch (Exception ex)
                {
                    lblMessage.Text += "ERREUR AVEC LE MEMBRE, " + ex.ToString();
                }
            return etudiantCo.AsQueryable();
        }

        // Met à jour l'étudiant
        public void UpdateEtudiant(Etudiant etudiantAUpdater)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                Etudiant etudiantAUpdaterCopie = new Etudiant();

                // contient le courriel de départ de l'étudiant (avant qu'il ne soit modifié)
                string courrielDeBase = Session["Courriel"].ToString();

                // contient le nouveau courriel modifié de l'étudiant
                TextBox txtCourriel = (TextBox) lvModifProfilEtudiant.Items[0].FindControl("txtCourriel");
                courrielModifie = txtCourriel.Text;


                // Va chercher le bon étudiant car le courriel pourrait avoir été changé
                etudiantAUpdaterCopie = (lecontexte.UtilisateurSet.OfType<Membre>().OfType<Etudiant>().SingleOrDefault(m => m.courriel == courrielDeBase));
                
                TryUpdateModel(etudiantAUpdaterCopie);
                var contextval = new ValidationContext(etudiantAUpdaterCopie, serviceProvider: null, items: null);
                var results = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(etudiantAUpdaterCopie, contextval, results); // VALIDE L'ÉTUDIANT
                if (!isValid) // NON VALIDE
                {
                    foreach (var validationResult in results)
                    {
                        lblMessage.Text += validationResult.ErrorMessage;
                    }
                }
                else // VALIDE
                {
                    lblMessage.Text = "";
                    try
                    {

                        lecontexte.SaveChanges();
                    }
                    catch (DbEntityValidationException ex) // D'AUTRES ERREURS PEUVENT SURVENIR QUI N'ONT PAS ÉTÉ PRÉVUE VIA DATAANNOTATIONS.
                    {
                        foreach (DbEntityValidationResult failure in ex.EntityValidationErrors)
                        {
                            foreach (DbValidationError lerror in failure.ValidationErrors)
                            {
                                lblMessage.Text += string.Format("{0} : {1}", lerror.PropertyName, lerror.ErrorMessage);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("Une erreur s'est produite lors de la mise à jour de l'étudiant." + ex.ToString());
                    }

                }
            }

        }
        #endregion

      
    }
}