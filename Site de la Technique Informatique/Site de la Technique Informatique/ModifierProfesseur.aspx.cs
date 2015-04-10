﻿//Permet de modifier certaines informations du compte professeur, de changer son mot de passe, gérer ses cours et supprimer son compte
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

namespace Site_de_la_Technique_Informatique
{
    public partial class ModifierProfesseur : ErrorHandling
    {
        public Professeur currentProf;

        #region Page_events
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(true, true, false, false);
            currentProf = lvProfesseur_GetData();

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
                lblMessage.Visible = false;
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


        #endregion 

        #region DeleteAccount

         

        protected void lnkDeleteProfil_Click(object sender, EventArgs e)
        {
        lblModalTitle.Text = "Dernière vérification";
                lblModalBody.Text = "Inscrivez votre mot de passe afin de confirmer que vous voulez supprimer votre compte";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "popupDelete", "$('#popupDelete').modal();", true);
                upDelete.Update();
        }
        #endregion

    }
}