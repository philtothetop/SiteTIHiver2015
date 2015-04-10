using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
   
    public partial class ProfilEtudiant : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(true, true, true, false);
        }
        public Etudiant SelectEtudiant()
        {
            Etudiant etudiantCo = null;



            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                try
                {
                    String strIDUtilisateur = "";
                    dvModifier.Visible = true;//Afficher le div contenant le bouton modifier.
                    if (Request.QueryString["id"] == null)//Vérifier si un queryString EtudiantId est null.
                    {
                        if (Request.Cookies["TIUtilisateur"].Value.Equals("Etudiant"))//Vérifier si l'utilisateur est un étudiant
                        {
                            strIDUtilisateur = Request.Cookies["TIID"].Value;//Va chercher l'id
                            
                        }
                    }
                    else
                    {
                        strIDUtilisateur = Request.QueryString["id"].ToString();//Va chercher la valleur du query String.
                        
                        if (Request.Cookies["TIUtilisateur"].Value.Equals("Admin"))
                        {
                            dvModifier.Visible = true;//Afficher le div contenant le bouton modifier.
                        }
                        else
                        {
                            dvModifier.Visible = false;//Chache le div contant modifier.
                        }
                    }
                    int IDUtilisateur = 0;
                    if (int.TryParse(strIDUtilisateur, out IDUtilisateur))
                    {
                        etudiantCo = (from etu in lecontexte.UtilisateurSet.OfType<Etudiant>() where etu.IDUtilisateur == IDUtilisateur select etu).FirstOrDefault();
                     
                    }
                    else
                    {
                        Response.Redirect(Request.UrlReferrer.ToString());
                    }

                }


                catch (Exception ex)
                {
                    LogErreur("ProfilEtudiant-erreur-SelectEtudiant", ex);
                }
            return etudiantCo;
        }

        protected void lnkModifier_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton monBouton = (LinkButton)sender;
                Response.Redirect("modifProfilEtudiant.aspx?id=" + Request.QueryString["id"]);
            }catch(Exception ex)
            {

            }
        }
    }
}