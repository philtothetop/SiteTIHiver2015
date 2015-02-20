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
    public partial class validation_courriel : System.Web.UI.Page
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
                    
                    
                    if (Request.QueryString["id"] != null && Request.QueryString["code"] != null)
                    {


                        String courriel = Request.QueryString["id"].ToString();
                        String hash = Request.QueryString["code"].ToString();

                        List<Etudiant> etudiantList = (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where cl.courriel.Equals(courriel) && cl.valideCourriel==false select cl).ToList();

                        if (etudiantList != null && etudiantList.Count()>0)
                        {


                            foreach (var etudiant in etudiantList)
                            {
                                String etudiantHash=GetSHA256Hash(etudiant.dateInscription.ToString());
                                if (etudiantHash.Equals(hash))
                                {

                                        etudiant.valideCourriel = true;
                                        leContext.SaveChanges();
                                        break;
                                    
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("Inscription.aspx",false);
                        }

                    }
                    else
                    {
                        Response.Redirect("Inscription.aspx", false);
                    }
                }
            }
            catch (Exception ex)
            {

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