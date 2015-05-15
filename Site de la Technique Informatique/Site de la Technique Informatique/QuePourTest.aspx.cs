using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.IO;
using System.Drawing;

namespace Site_de_la_Technique_Informatique
{
    public partial class QuePourTest : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, true, true, false);

            if (Request.QueryString["id"] == null)//Vérifier si un queryString ProfId est null.
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
        }


    }
}