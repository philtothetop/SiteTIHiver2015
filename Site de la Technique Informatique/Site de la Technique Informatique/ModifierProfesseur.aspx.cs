using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.Drawing;
using Site_de_la_Technique_Informatique.Classes;
using System.IO;

namespace Site_de_la_Technique_Informatique
{
    public partial class ModifierProfesseur : System.Web.UI.Page
    {
        public Professeur currentProf;

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

        private void updateProfesseur(Professeur profAUpdater)
        {
            string courriel = Request.Cookies["TICourriel"].Value;

            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                profAUpdater = lecontexte.UtilisateurSet.OfType<Professeur>().Where(p => p.courriel == courriel).FirstOrDefault();

                TryUpdateModel(profAUpdater);

                if (!ModelState.IsValid)
                {
                    foreach (var modelErrors in ModelState)
                    {
                        string propertyName = modelErrors.Key;
                        if (modelErrors.Value.Errors.Count > 0)
                        {
                            for (int i = 0; i < modelErrors.Value.Errors.Count; i++)
                            {
                                lblMessage.Text += "<b>" + propertyName + ": </b>" + modelErrors.Value.Errors[i].ErrorMessage.ToString() + "<br/>";
                            }
                        }
                    }
                    lblMessage.Visible = true;

                }
                else { 

                String imgData = ImgExSrc.Value;
                if (imgData != "" && imgData.Length > 21 && imgData.Substring(0, 21).Equals("data:image/png;base64"))
                {
                    System.Drawing.Image imageProfil = LoadImage(imgData);
                    imageProfil = (System.Drawing.Image)new Bitmap(imageProfil, new Size(125, 125)); //prevention contre injection de trop grande image.

                    String imageNom = (profAUpdater.prenom + profAUpdater.dateInscription.ToString()).GetHashCode() + "_125.jpg";
                    String imageProfilChemin = Path.Combine(Server.MapPath("~/Photos/Profils/"), imageNom);
                    imageProfil.Save(imageProfilChemin);
                    profAUpdater.pathPhotoProfil = imageNom;
                }
                else// sion photo par défault
                {
                    profAUpdater.pathPhotoProfil = "photobase.bmp";
                }


                }
            }
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

        public System.Drawing.Image LoadImage(String data)
        {
            //get a temp image from bytes, instead of loading from disk
            //data:image/gif;base64,
            //this image is a single pixel (black)
            //byte[] bytes = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw==");
            data = data.Remove(0, 22);
            byte[] bytes = Convert.FromBase64String(data);
            System.Drawing.Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = System.Drawing.Image.FromStream(ms);
                string cropFileName = "";
                string cropFilePath = "";
                cropFileName = "crop_" + "testImg";
                cropFilePath = Path.Combine(Server.MapPath("~/Photos/Profils/"), cropFileName);
            }

            return image;
        }

    }
}
