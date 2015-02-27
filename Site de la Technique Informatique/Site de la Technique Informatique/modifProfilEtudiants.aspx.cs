

using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class modifProfilEtudiants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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

        public void UpdateEtudiant(Etudiant etudiantAUpdater)
        {
            Etudiant etudiantAUpdaterCopie = new Etudiant(); 

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

                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("Une erreur s'est produite lors de la mise à jour de l'étudiant." + ex.ToString());
                    }

                } 

        }
        #endregion

    }
}