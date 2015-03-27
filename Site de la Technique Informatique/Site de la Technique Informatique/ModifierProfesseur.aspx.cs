using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.Drawing;

namespace Site_de_la_Technique_Informatique
{
    public partial class ModifierProfesseur : System.Web.UI.Page
    {
        public Professeur currentProf ;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentProf = lvProfesseur_GetData();
        }

        // Le type de retour peut être modifié en IEnumerable, toutefois pour prendre en charge
        //la pagination et le tri , vous devez ajouter les paramètres suivants :
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public Professeur lvProfesseur_GetData()
        {
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {

                    Professeur profAModifier = lecontexte.UtilisateurSet.OfType<Professeur>().Where(prof => prof.IDUtilisateur == 8).FirstOrDefault();

                    return profAModifier;

                }
            }
            catch
            {
                throw;
            }
        }

        private void updateProfesseur()
        {

        }

        protected void lnkUpload_Click(object sender, EventArgs e)
        {


            /*FileUpload fuPhoto = (FileUpload) lvProfesseur.Items[0].FindControl("fuPhoto");
            System.Web.UI.WebControls.Image imgProfil = (System.Web.UI.WebControls.Image)lvProfesseur.Items[0].FindControl("imgProfil");
            Classes.LoadImage loadImg = new Classes.LoadImage();
            Bitmap img;

            if (fuPhoto.HasFile )
            {
                string filename = fuPhoto.FileName;
                var ext = filename.Split('.');
                
                string[] acceptedExt = new string[] {"jpg","png", "jpeg", };
               if (acceptedExt.Contains(ext.Last())){

                   filename = currentProf.nom + currentProf.prenom + "imgProfil" ;

                   fuPhoto.SaveAs(Server.MapPath("/Photos/Profils/" + filename + "." + ext.Last()) );

                   img = loadImg.Resize(Server.MapPath("/Photos/Profils/" + filename), 125,125);

                   img.Save(Server.MapPath("/Photos/profils/" + filename + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);


                   imgProfil.ImageUrl = "~/Photos/Profils" + filename;
               }
               else {

               }*/

            }
        }
    }
