using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class Temoignages : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public IQueryable<Membre> lviewTemoignages_GetData()
        {
            List<Membre> liste5Membre = new List<Membre>();
            List<Membre> listeDesTemoignages = new List<Membre>();
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    //Afficher tout les témoignages validés 
                    listeDesTemoignages = (from cl in lecontexte.UtilisateurSet.OfType<Etudiant>() 
                                           where cl.temoignage.Length > 1 //&& cl.valideTemoignage == true 
                                           select cl as Membre).ToList(); 

                    List<Membre> listeDesProfs = (from cl in lecontexte.UtilisateurSet.OfType<Professeur>() 
                                                        where cl.temoignage.Length > 1
                                                        select cl as Membre).ToList();
                    //Si liste témoignage prof pas vide 
                    if (listeDesProfs != null) { 
                        foreach (Model.Membre membre in listeDesProfs) { 
                            listeDesTemoignages.Add(membre); 
                        } 
                    }

                    if (listeDesTemoignages != null && listeDesTemoignages.Count > 5)
                    {
                        Randomize(listeDesTemoignages);
                        for (int i = 0; i < 5; i++)
                        {
                            liste5Membre.Add(listeDesTemoignages[i]);
                        }

                    }
                    else
                    {
                        liste5Membre = listeDesTemoignages;
                    }
                }
            }
            catch (Exception ex)
            {
                LogErreur("Temoignages-lviewTemoignges_GetData", ex);
            }
            return liste5Membre.AsQueryable();
        }

    }
}