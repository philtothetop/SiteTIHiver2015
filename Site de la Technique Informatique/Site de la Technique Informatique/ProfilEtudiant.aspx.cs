//Cette Afficher le profil du étudiant
//Écrit par Cédric Archambault 27 mars 2015

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
            SavoirSiPossedeAutorizationPourLaPage(true, true, true, true,false);
        }
        //Cette classe va chercher l'étudiant
        //Écrit par Cédric Archambault 18 février 2015
        //Intrants: aucun
        //Extrants:Etudiant
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
                        etudiantCo = (from etu in lecontexte.UtilisateurSet.OfType<Etudiant>() where etu.IDUtilisateur == IDUtilisateur && etu.compteActif==1 select etu).FirstOrDefault();

                        if(etudiantCo==null)
                        {
                            Response.Redirect("404.aspx",false);
                        }
                     
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
        //Cette classe permet d'allez sur la page modifier profil
        //Écrit par Cédric Archambault 18 février 2015
        //Intrants: aucun
        //Extrants:Aucun
        protected void lnkModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["id"] == null && Request.Cookies["TIUtilisateur"].Value.Equals("Etudiant"))
                {
                    Response.Redirect("modifProfilEtudiant.aspx",false);
                }
                else
                {
                    String id = Request.QueryString["id"];
                    Response.Redirect("modifProfilEtudiant.aspx?id=" + id,false);
                }
                
            }catch(Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur Modifier_click : " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Essai d'envoi à : ");
            }
        }

        protected void lnkFaireTemoignage_Click(object sender, EventArgs e)
        {
            Response.Redirect("FaireTemoignage.aspx");
        }
    }
}