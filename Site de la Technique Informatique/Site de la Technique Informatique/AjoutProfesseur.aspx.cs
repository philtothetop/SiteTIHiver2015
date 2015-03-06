using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using Site_de_la_Technique_Informatique.Classes;

namespace Site_de_la_Technique_Informatique
{
    public partial class AjoutProfesseur : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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

        public void creerProfesseur()
        {
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    Professeur nouveauProf = new Professeur();
                    var lviewItems = lvInscriptionProf.Items[0];
                    var tempPassword = GetRandomHexNumber(8);
                    var hash = new hash();

                  nouveauProf.hashMotDePasse =  hash.GetSHA256Hash(tempPassword);
                  nouveauProf.dateInscription = DateTime.Now;
                  nouveauProf.compteActif = true;
                    

                    TryUpdateModel(nouveauProf);

                    if (!ModelState.IsValid)
                    {
                        
                        
                        foreach (var modelErrors in ModelState)
                        {
                            string propertyName = modelErrors.Key;
                            if (modelErrors.Value.Errors.Count > 0)
                            {
                                lblMessages.Text = "";
                                //Hello

                                for (int i = 0; i < modelErrors.Value.Errors.Count; i++)
                                {
                                    lblMessages.Text += "<b>" + propertyName + ": </b>" + "<br/>" + modelErrors.Value.Errors[i].ErrorMessage.ToString() + "<br/>";
                                }

                            }
                        }

                    }
                    else
                    {
                        lecontexte.SaveChanges();
                    }

                }
            }

            catch (Exception)
            {
                throw;
            }
        }

        static Random random = new Random();
        public static string GetRandomHexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
                return result;
            return result + random.Next(16).ToString("X");
        }

    }
}