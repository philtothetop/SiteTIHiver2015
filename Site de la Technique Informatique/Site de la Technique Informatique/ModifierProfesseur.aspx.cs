//Permet de modifier certaines informations du compte professeur, de changer son mot de passe, gérer ses cours et supprimer son compte
// Philippe Baron, Mars 2015


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
using System.Web.UI.HtmlControls;


namespace Site_de_la_Technique_Informatique
{
    public partial class ModifierProfesseur : ErrorHandling
    {
        public Professeur currentProf;
      
        #region Page_events
        protected void Page_Load(object sender, EventArgs e)
        {
            //SavoirSiPossedeAutorizationPourLaPage(true, true, false, false);
            currentProf = lvProfesseur_GetData();
            
            if (!Page.IsPostBack) {
               
                
            divSuccess.Attributes["style"] = "visibility:hidden";
            divWarning.Attributes["style"] = "visibility:hidden";
            }
        }

        #endregion

        #region Modifier_Profil


        public Professeur lvProfesseur_GetData()
        {
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    int id = int.Parse(Request.Cookies["TIID"].Value);
                    Professeur profAModifier = lecontexte.UtilisateurSet.OfType<Professeur>().Where(prof => prof.IDUtilisateur == id).FirstOrDefault();

                    return profAModifier;

                }
            }
            catch
            {
                throw;
            }
        }

        public void updateProfesseur()
        {
            Professeur profAUpdater = new Professeur();
            int id = int.Parse(Request.Cookies["TIID"].Value);

            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                profAUpdater = lecontexte.UtilisateurSet.OfType<Professeur>().Where(p => p.IDUtilisateur == id).FirstOrDefault();

                int cPres = (lvProfesseur.Items[0].FindControl("txtPresentation") as TextBox).Text.Count();
                int cPhoto = (lvProfesseur.Items[0].FindControl("txtDescPhoto") as TextBox).Text.Count();

                TryUpdateModel(profAUpdater);
                lblMessage.Text = "";
               
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
                    divWarning.Attributes["style"] = "visibility:visible";

                }
                else
                {

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


                    Model.Log logEntry = new Model.Log
                    {
                        dateLog = DateTime.Now,
                        actionLog = profAUpdater.prenom + " " + profAUpdater.nom + " a modifié son profil",
                        typeLog = 0
                    };

                    lecontexte.LogSet.Add(logEntry);
                    lecontexte.SaveChanges();
                    divSuccess.Attributes["style"] = "visibility:visible";
                }
            }
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
        #endregion


        #region Modifier_Password

        protected void lnkSaveNewPassword_Click(object sender, EventArgs e)
        {
            var hash = new hash();
           
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {


                Professeur profAModifier = lecontexte.UtilisateurSet.OfType<Professeur>().Where(x => x.IDMembre == currentProf.IDMembre).First();
                if(!String.IsNullOrEmpty(txtAncienMp.Text) && !String.IsNullOrEmpty(txtNouveauMp.Text) && !String.IsNullOrEmpty(txtNouveauMpConfirm.Text) ){
                    string ancienPwd = hash.GetSHA256Hash(txtAncienMp.Text.ToString());
                if (profAModifier.hashMotDePasse.Equals(ancienPwd))
                {


                    if (txtNouveauMp.Text.Equals(txtNouveauMpConfirm.Text) && txtAncienMp.Text != txtNouveauMpConfirm.Text)
                    {
                        string newPwd = hash.GetSHA256Hash(txtNouveauMpConfirm.Text);
                        profAModifier.hashMotDePasse = newPwd;
                        Model.Log logEntry = new Model.Log
                        {
                            dateLog = DateTime.Now,
                            actionLog = profAModifier.prenom + " " + profAModifier.nom + " a modifié son mot de passe",
                            typeLog = 0
                        };
                        lecontexte.SaveChanges();
                        divWarning.Attributes["style"] = "visibility:hidden;";
                        divSuccess.Attributes["style"] = "visibility:visible";
                    }
                    else if (!txtNouveauMp.Text.Equals(txtNouveauMpConfirm.Text))
                    {
                        lblMessage.Text = "<b>Nouveau mot de passe:</b>Les deux nouveaux mots de passe ne sont pas identiques";
                        divWarning.Attributes["style"] = "visibility:visible;";
                    }
                    else
                    {
                        lblMessage.Text = "<b>Nouveau mot de passe:</b>Le nouveau mot de passe doit être différent du mot de passe actuel";
                        divWarning.Attributes["style"] = "visibility:visible;";
                    }
                }
                else
                {
                    lblMessage.Text = "<b>Ancien mot de passe:</b>Le mot de passe que vous avez entré n'est pas valide";
                    divWarning.Attributes["style"] = "visibility:visible;";
                }
            }
                else{
                    lblMessage.Text = "<b>Nouveau mot de passe:</b> Des valeurs ont été laissé vides.";
                    divWarning.Attributes["style"] = "visibility:visible;";
                }
           }
            
        }

        #endregion

        #region DeleteAccount



        protected void lnkDeleteProfil_Click(object sender, EventArgs e)
        {
            lblModalTitle.Text = "Dernière vérification";
            lblModalBody.Text = "Inscrivez votre mot de passe afin de confirmer la suppression de votre compte";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popupDelete", "  document.getElementById('aDelete').click(); $('#popupDelete').modal();", true);
            upDelete.Update();
        }

        protected void lnkDeletePass_Click(object sender, EventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                try {
                    hash hashing = new hash();
                    string inputPwd = hashing.GetSHA256Hash(txtDeletePass.Text);
                    Professeur profADesactiver = lecontexte.UtilisateurSet.OfType<Professeur>().Where(x => x.IDMembre == currentProf.IDMembre).FirstOrDefault();
                    if (inputPwd.Equals(profADesactiver.hashMotDePasse)) { 


                
                profADesactiver.compteActif = 0;

                lecontexte.SaveChanges();

                Response.Cookies["TICourriel"].Value = ""; //enlève la valeur du cookie
                Response.Cookies["TINom"].Value = ""; //enlève la valeur du cookie
                Response.Cookies["TIID"].Value = ""; //enlève la valeur du cookie
                Response.Cookies["TIUtilisateur"].Value = ""; //enlève la valeur du cookie

                Response.Redirect(Request.RawUrl, false);

                    }

                    }catch{
                        throw;
                    }
            }
        }


        #endregion

       

        

    }
}
