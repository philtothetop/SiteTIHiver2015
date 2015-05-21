//Cette Afficher le profil du étudiant
//Écrit par Cédric Archambault 27 mars 2015

using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
   
    public partial class ProfilEtudiant : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, true, true,false);
        }

        //Cette classe va chercher l'étudiant
        //Écrit par Cédric Archambault 18 février 2015
        //Intrants: aucun
        //Extrants:Etudiant
        public Etudiant SelectEtudiant()
        {
            Etudiant etudiantCo = null;

            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                try
                {
                    int idUtilisateurAChercher = -1;

                    //Si recherche quelqu'un
                    if (Request.QueryString["id"] != null)
                    {
                        idUtilisateurAChercher = Convert.ToInt32(Request.QueryString["id"]);
                    }
                    else
                    //Si veu voir son propre profil
                    {
                        idUtilisateurAChercher = Convert.ToInt32(Request.Cookies["TIID"].Value);
                    }

                    etudiantCo = (from cl in lecontexte.UtilisateurSet.OfType<Etudiant>()
                                  where cl.IDUtilisateur == idUtilisateurAChercher
                                  select cl).FirstOrDefault();

                    //Si utilisateur a afficher est pas trouvé
                    if (etudiantCo == null)
                    {
                        dvModifier.Visible = false;
                        return null;
                    }

                    //Mettre div modification visible ou non, dabord va chercher le id du connecté
                    int idConnecte = Convert.ToInt32(Request.Cookies["TIID"].Value);

                    //Si le connecté est le profil afficher
                    if (idConnecte == idUtilisateurAChercher)
                    {
                        dvModifier.Visible = true;
                    }
                    else
                    {
                        dvModifier.Visible = false;
                    }
                }
                //Si catch sa veut dire qu'il ne recherche pas un ID ou n'est pas conecté
                catch (Exception ex)
                {
                    Response.Redirect("Default.aspx");
                }
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
                throw new Exception("Erreur Modifier_click: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Essai d'envoi à : ");
            }
        }

        protected void lnkFaireTemoignage_Click(object sender, EventArgs e)
        {
            Response.Redirect("FaireTemoignage.aspx");
        }

        protected void lnkPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string FilePath = Server.MapPath("~//Upload//CV//" + ((LinkButton)sender).CommandArgument.ToString() );

                if (File.Exists(FilePath))
                {
                    WebClient User = new WebClient();
                    Byte[] FileBuffer = User.DownloadData(FilePath);
                    if (FileBuffer != null)
                    {
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-length", FileBuffer.Length.ToString());
                        Response.BinaryWrite(FileBuffer);
                    }
                }
            }
            catch
            {
                //Si problem
            }
        }

        //Savoir si mettre le CV visible ou non si possède un
        protected bool VisibleSiCV(string pathCV)
        {
            if(pathCV != null)
            {
                if(!pathCV.Equals(""))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}