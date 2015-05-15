//Ccode C# Inscription-validate
//Écrit par Cédric Archambault 18 février 2015
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.Security.Cryptography;

namespace Site_de_la_Technique_Informatique.Inscription
{
    public partial class validation_courriel : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SavoirSiPossedeAutorizationPourLaPage(true, false, false, false);
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


                    if (Request.QueryString["type"] != null && Request.QueryString["id"] != null && Request.QueryString["code"] != null)
                    {

                        String type = Request.QueryString["type"].ToString();
                        String courriel = Request.QueryString["id"].ToString();
                        String hash = Request.QueryString["code"].ToString();

                        if (type.Equals("etu"))//Si c'est un étudiant
                        {
                            List<Etudiant> etudiantList = (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where cl.courriel.Equals(courriel) && cl.valideCourriel == false select cl).ToList();

                            foreach (var etudiant in etudiantList)
                            {
                                if (etudiant.dateInscription.GetHashCode().ToString().Equals(hash))
                                {
                                    etudiant.valideCourriel = true;
                                    leContext.SaveChanges();
                                }

                            }
                        }
                        else if (type.Equals("emp"))//Si c'est un employeur
                        {
                            List<Employeur> employeurtList = (from cl in leContext.UtilisateurSet.OfType<Employeur>() where cl.courriel.Equals(courriel) && cl.valideCourriel == false select cl).ToList();

                            foreach (var employeur in employeurtList)
                            {
                                String strHash = employeur.dateInscription.GetHashCode().ToString();

                                if (strHash.Equals(hash))
                                {
                                    employeur.valideCourriel = true;
                                    leContext.SaveChanges();
                                }

                            }
                        }


                    }
                    else
                    {
                        Response.Redirect("~", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur valider courriel: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Essai valider courriel : ");

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