//Ccode C# Inscription-validate
//Écrit par Cédric Archambault 18 février 2015
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique.Inscription
{
    public partial class validation_courriel : Site
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            valider_Courriel();
        }

        //Cette classe permet confirme le courriel  à l'administrateur
        //Écrit par Cédric Archambault 18 février 2015
        //Intrants: aucun
        //Extrants:Aucun
        private void valider_Courriel()
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    String hashCodeId = Request.QueryString["id"].ToString();

                    Etudiant etudiant = (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where GetSHA256Hash(cl.courriel + cl.dateInscription) == hashCodeId select cl).FirstOrDefault();

                    //si l'etudiant existe et que sont courriel n'a pas été valider.
                    if (etudiant != null && etudiant.valideCourriel == false)
                    {
                        etudiant.valideCourriel = true;
                        leContext.SaveChanges();
                    }
                    else if (etudiant == null)
                    {
                        Response.Redirect("Inscription.aspx");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}