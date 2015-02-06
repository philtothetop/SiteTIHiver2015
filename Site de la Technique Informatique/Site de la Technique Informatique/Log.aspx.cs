using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;

namespace Site_de_la_Technique_Informatique
{
    public partial class Log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ModelTIContainer leModelTI = new ModelTIContainer())
            {
                /*
                 * JUST FOR TEST, IGNORER SA
                UtilisateurJeu unUtilisateur = new UtilisateurJeu();
                unUtilisateur.compteActif = true;
                unUtilisateur.courriel = "foulco1@hotmail.com";
                unUtilisateur.dateTemoignage = DateTime.Now;
                unUtilisateur.hashMotDepasse = "";
                unUtilisateur.nom = "Brouard";
                unUtilisateur.pathPhotoProfil = "none";
                unUtilisateur.photoDescription = "test Model avec C Sharp";
                unUtilisateur.prenom = "Raphael";
                unUtilisateur.temoignage = "Le témoignage";

                leModelTI.UtilisateurJeu.Add(unUtilisateur);
                leModelTI.SaveChanges();
                */
            }
        }
    }
}