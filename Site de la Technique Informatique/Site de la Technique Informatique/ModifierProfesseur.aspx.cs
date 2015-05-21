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
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;


namespace Site_de_la_Technique_Informatique
{
    public partial class ModifierProfesseur : ErrorHandling
    {
        public Professeur currentProf;
        

        #region Page_events
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, false, false, false);
            currentProf = lvProfesseur_GetData();
            string tab = hidTab.Value;

            lblCoursErreurs.Visible = false;
            ddlCours.Enabled = ddlCours.Items.Count > 0 ? true : false;
            btnModif.Enabled = ddlCours.Enabled;
            
            if (ddlCours.Items.Count > 0)
            {
                ddlCours.Enabled = true;
                btnModif.Enabled = true;
            }
            if (!Page.IsPostBack)
            {

                ddlCours.DataBind();
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
                    divSuccess.Attributes["style"] = "visibility:hidden";

                }
                else
                {

                    String imgData = ImgExSrc.Value;
                    if (imgData != "" && imgData.Length > 21 && imgData.Substring(0, 21).Equals("data:image/png;base64"))
                    {
                        System.Drawing.Image imageProfil = LoadImage(imgData, profAUpdater);
                       
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
                    divWarning.Attributes["style"] = "visibility:hidden";
                }
            }
        }



        public System.Drawing.Image LoadImage(String data, Professeur profAUpdater)
        {
            try { 
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
                cropFileName = "crop_" + "testImg.jpg";
                cropFilePath = Path.Combine(Server.MapPath(Request.ApplicationPath + "/Upload/Photos/Profils/"), cropFileName);
                image = (System.Drawing.Image)new Bitmap(image, new Size(125, 125)); //prevention contre injection de trop grande image.
                
                string something = profAUpdater.dateInscription.ToShortDateString().Replace("/", "");
                something = something.Replace("-", "");
                String imageNom = (profAUpdater.prenom + something) + "_125.jpg";
                String imageProfilChemin = (Server.MapPath("~//Upload//Photos//Profils//" + imageNom));
                image.Save(imageProfilChemin);
                profAUpdater.pathPhotoProfil = imageNom;
                    
            }

            return image;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.StackTrace,ex);
            }
        }
        #endregion

        #region Modifier_Password

        protected void lnkSaveNewPassword_Click(object sender, EventArgs e)
        {
            var hash = new hash();

            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {


                Professeur profAModifier = lecontexte.UtilisateurSet.OfType<Professeur>().Where(x => x.IDMembre == currentProf.IDMembre).First();
                if (!String.IsNullOrEmpty(txtAncienMp.Text) && !String.IsNullOrEmpty(txtNouveauMp.Text) && !String.IsNullOrEmpty(txtNouveauMpConfirm.Text))
                {
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
                            lblMessage.Text = "<b>Nouveau mot de passe: </b>Les deux nouveaux mots de passe ne sont pas identiques";
                            divWarning.Attributes["style"] = "visibility:visible;";
                            divSuccess.Attributes["style"] = "visibility:hidden";
                        }
                        else
                        {
                            lblMessage.Text = "<b>Nouveau mot de passe: </b>Le nouveau mot de passe doit être différent du mot de passe actuel";
                            divWarning.Attributes["style"] = "visibility:visible;";
                            divSuccess.Attributes["style"] = "visibility:hidden";
                        }
                    }
                    else
                    {
                        lblMessage.Text = "<b>Ancien mot de passe: </b>Le mot de passe que vous avez entré n'est pas valide";
                        divWarning.Attributes["style"] = "visibility:visible;";
                        divSuccess.Attributes["style"] = "visibility:hidden";
                    }
                }
                else
                {
                    lblMessage.Text = "<b>Nouveau mot de passe:</b> Des valeurs ont été laissé vides.";
                    divWarning.Attributes["style"] = "visibility:visible;";
                    divSuccess.Attributes["style"] = "visibility:hidden";
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
                try
                {
                    hash hashing = new hash();
                    string inputPwd = hashing.GetSHA256Hash(txtDeletePass.Text);
                    Professeur profADesactiver = lecontexte.UtilisateurSet.OfType<Professeur>().Where(x => x.IDMembre == currentProf.IDMembre).FirstOrDefault();
                    if (inputPwd.Equals(profADesactiver.hashMotDePasse))
                    {

                        profADesactiver.compteActif = 0;

                        lecontexte.SaveChanges();

                        Response.Cookies["TICourriel"].Value = ""; //enlève la valeur du cookie
                        Response.Cookies["TINom"].Value = ""; //enlève la valeur du cookie
                        Response.Cookies["TIID"].Value = ""; //enlève la valeur du cookie
                        Response.Cookies["TIUtilisateur"].Value = ""; //enlève la valeur du cookie

                        Response.Redirect(Request.RawUrl, false);

                    }

                }
                catch
                {
                    throw;
                }
            }
        }


        #endregion

        #region Modifier_Cours
        public IQueryable<Cours> lvModifierCours_GetData()
        {

            List<Cours> nbCours = null;
            List<Cours> newCours = null;

            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    
                    nbCours = ((from cours in lecontexte.CoursSet.OfType<Cours>() select cours).ToList());  //génère une liste des membres pour en avoir un nombre de membres et générer le bon ID Utilisateur
                    if (!string.IsNullOrEmpty(ddlCours.SelectedValue)) { 
                    int selectedCours = int.Parse(ddlCours.SelectedValue);
                    newCours = ((from cours in lecontexte.CoursSet.OfType<Cours>() where cours.IDCours == selectedCours select cours).ToList());
                    }

                if ((string)ViewState["mode"] + "" == "ajoute")  // SEULEMENT UN MEDIA «VIDE»
                {
                    newCours = new List<Cours>();
                    Cours coursVide = new Cours();

                    
                    coursVide.noCours = "";
                    coursVide.nomCours = "";
                    coursVide.noSessionCours = short.Parse( ddlSession.SelectedValue);
                    coursVide.Professeur.Add(currentProf);
                    newCours.Add(coursVide);
                }
                else
                {

                }

                }
            }
            catch (Exception ex)
            {
                lblMessage.Text += "ERREUR AVEC LE COURS, " + ex.ToString();
            }
            return newCours.AsQueryable();
        }

        public IQueryable<Cours> getAllCours()
        {

            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                var session = short.Parse(ddlSession.SelectedValue);


                List<Cours> cours = new List<Cours>();

                Professeur profCours = (from cl in lecontexte.UtilisateurSet.OfType<Professeur>()
                                        from cr in cl.Cours
                                        where cl.IDMembre == currentProf.IDMembre
                                        select cl).FirstOrDefault();

                if (profCours != null)
                {
                    cours = profCours.Cours.Where(x => x.noSessionCours == session).ToList();
                }
                return cours.AsQueryable();
            }
        }


        //public 

        public void updateCours(Cours leCoursAUpdater)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                
                Cours leCoursAUpdaterCopie = new Cours();
                if ((string)ViewState["mode"] == "édite")
                {
                    leCoursAUpdaterCopie = (lecontexte.Set<Cours>().SingleOrDefault(m => m.IDCours == leCoursAUpdater.IDCours));
                }
                else
                { leCoursAUpdaterCopie = leCoursAUpdater;
                leCoursAUpdaterCopie.noSessionCours = short.Parse(ddlSession.SelectedValue);
                leCoursAUpdaterCopie.Professeur = lecontexte.UtilisateurSet.OfType<Professeur>().Where(x => x.IDProfesseur == currentProf.IDProfesseur).ToList();
                
                
                }

                ListViewItem lvcourscourant = lvModifierCours.Items[0];

                //VÉRIFIE SI CE QUI EST A L'ÉCRAN EST VALIDE ET EN VERSE LE CONTENU DANS LEMEMBREAUPDATER
                //---------------------------------------------------------------------------------------
                TryUpdateModel(leCoursAUpdaterCopie);  //RAMÈNE LE MEMBRE QUI EST A L'ÉCRAN VERS L'OBJET, FAIT AUSSI LA VALIDATION MAIS ON L'IGNORE
                var contextval = new ValidationContext(leCoursAUpdaterCopie, serviceProvider: null, items: null);
                var results = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(leCoursAUpdaterCopie, contextval, results); // VALIDE LE MEMBRE
                if (!isValid) // NON VALIDE
                {
                    foreach (var validationResult in results)
                    {
                        lblCoursErreurs.Text += validationResult.ErrorMessage;
                    }
                    lblCoursErreurs.Visible = true;
                }
                else // VALIDE
                {
                    lblMessage.Text = "";
                    try
                    {

                        if ((string)ViewState["mode"] == "ajoute")
                        {
                            lecontexte.Set<Cours>().Add(leCoursAUpdaterCopie);
                            
                        }
                        Model.Log logEntry = new Model.Log
                        {
                            dateLog = DateTime.Now,
                            actionLog = currentProf.prenom + " " + currentProf.nom + " a modifié un cours: " + leCoursAUpdaterCopie.noCours ,
                            typeLog = 0
                        };

                        lecontexte.LogSet.Add(logEntry);

                        lecontexte.SaveChanges();
                    }
                    // Attrappe les erreurs au Save Changes. Utile pour découvrir quelle propriété est en erreur.
                    catch (DbEntityValidationException el)
                    {
                        foreach (var eve in el.EntityValidationErrors)
                        {
                            lblCoursErreurs.Text += "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:" +
                                eve.Entry.Entity.GetType().Name + eve.Entry.State;
                            foreach (var ve in eve.ValidationErrors)
                            {
                                lblCoursErreurs.Text += "- Property: \"{0}\", Error: \"{1}\"" +
                                    ve.PropertyName + ve.ErrorMessage;
                                lblCoursErreurs.Visible = true;
                            }
                        }
                    }
                    ViewState["mode"] = "édite";
                    ddlCours.DataBind();
                    ddlCours.Enabled = true;
                    btnModif.Enabled = true;
                    lvModifierCours.Visible = false;


                }
            }
        }

        public void deleteCours(Cours coursASupprimer)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                try
                {
                    Cours cours = (lecontexte.Set<Cours>().SingleOrDefault(x => x.IDCours == coursASupprimer.IDCours));
                    Professeur leProf = lecontexte.UtilisateurSet.OfType<Professeur>().Where(x => x.IDProfesseur == currentProf.IDProfesseur).FirstOrDefault();
                    
                    //Vérifier si le cours existe, au sinon ne rien faire
                    if(cours != null)
                    {
                        leProf.Cours.Remove(cours);
                        lecontexte.CoursSet.Remove(cours);
                        lecontexte.SaveChanges();
                        lvModifierCours.DataBind();
                        lvModifierCours.Visible = false;
                        ddlCours.DataBind();

                        if (ddlCours.Items.Count < 1)
                        {
                            ddlCours.Enabled = false;
                            btnModif.Enabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblCoursErreurs.Text += "ERREUR DE SUPPRESSION D'UN COURS, " + ex.ToString();
                    lblCoursErreurs.Visible = true;
                }
        }
        #endregion

        protected void btnModif_Click(object sender, EventArgs e)
        {
          
            lvModifierCours.DataBind();
            lvModifierCours.Visible = true;
            ViewState["mode"] ="édite";
        }

        protected void btnAjout_Click(object sender, EventArgs e)
        {
            try
            {
                lvModifierCours.Visible = true;
                ViewState["mode"] = "ajoute";
                lvModifierCours.DataBind();
                lblNoClass.Visible = false;
            }
            catch (Exception ex)
            {
               lblCoursErreurs.Text += "ERREUR LORS DE L'«AJOUT» D'UN COURS, " + ex.ToString();
               lblCoursErreurs.Visible = true;
            }
        }

        protected void lvModifierCours_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    if (e.Item.ItemType == ListViewItemType.DataItem)
                    {
                        int currentCours = int.Parse(ddlCours.SelectedValue);

                                     
                        Cours leCours = (lecontexte.Set<Cours>().SingleOrDefault(cours => cours.IDCours == currentCours));
                                                
                    }
                }
            }
            catch (Exception ex)
            {
                lblCoursErreurs.Text += "ERREUR DE ITEMDATABOUND, " + ex.ToString();
                lblCoursErreurs.Visible = true;
            }
        }

        protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCours.DataBind();
            lvModifierCours.Visible = false;
            if (ddlCours.Items.Count > 0)
            {
                ddlCours.Enabled = true;
                lblNoClass.Visible = false;
                btnModif.Enabled = true;

            }
            else
            {
                ddlCours.Enabled = false;
                lblNoClass.Visible = true;
                btnModif.Enabled = false;
            }
        }
    }
}
