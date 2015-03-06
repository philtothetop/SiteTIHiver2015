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
    public partial class modifProfilEtudiant : System.Web.UI.Page
    {
        string courrielDeBase = "";


        protected void Page_Load(object sender, EventArgs e)
        {

            Session["Courriel"] = "philippe@bibeau.com";
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
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                Etudiant etudiantAUpdaterCopie = new Etudiant();
                if (courrielDeBase != etudiantAUpdaterCopie.courriel)
                {
                    etudiantAUpdaterCopie = (lecontexte.UtilisateurSet.OfType<Membre>().OfType<Etudiant>().SingleOrDefault(m => m.courriel == courrielDeBase));
                }
                else
                {
                    etudiantAUpdaterCopie = (lecontexte.UtilisateurSet.OfType<Membre>().OfType<Etudiant>().SingleOrDefault(m => m.courriel == etudiantAUpdater.courriel));
                }
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
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("Une erreur s'est produite lors de la mise à jour de l'étudiant." + ex.ToString());
                    }

                }
            }

        }
        #endregion

        protected void lvModifProfilEtudiants_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    if (e.Item.ItemType == ListViewItemType.DataItem)
                    {
                        Etudiant etudiantalecran = (Etudiant)e.Item.DataItem;
                        Etudiant letudiant = (lecontexte.UtilisateurSet.OfType<Membre>().OfType<Etudiant>().SingleOrDefault(m => m.courriel == etudiantalecran.courriel));

                        if (!Page.IsPostBack)
                            courrielDeBase = ((TextBox)e.Item.FindControl("txtCourriel")).Text.Trim();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}