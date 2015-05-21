// Cette page permet d'ajouter, modifier ou supprimer un article de journal
// Écrit par Xavier Philippe Bibeau, Mars-Avril 2015

using Site_de_la_Technique_Informatique.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_Media : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, false, false, false);


        }

        //FileUpload

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {
                    FileUpload fuNewArticle = (FileUpload)lvMedia.Items[0].FindControl("fuMedia");

                    //vérifie les extentions
                    if (fuNewArticle.HasFile)
                        if (Path.GetExtension(fuNewArticle.PostedFile.FileName) == ".pdf" || Path.GetExtension(fuNewArticle.PostedFile.FileName) == ".PDF")
                        {
                            string dossier = "Media";

                            // Si le dossier media n'existe pas, on le crée
                            if (!System.IO.Directory.Exists(Server.MapPath("~\\Upload\\" + dossier + "\\")))
                            {
                                System.IO.Directory.CreateDirectory(Server.MapPath("~\\Upload\\" + dossier + "\\"));
                            }

                            // Enregistre la photo à sa place 
                            fuNewArticle.SaveAs(Server.MapPath("~\\Upload\\" + dossier + "\\" + fuNewArticle.FileName));

                            // ajoute le chemin de la photo de profil dans la base de données

                            (lvMedia.Items[0].FindControl("txtArticle") as TextBox).Text = fuNewArticle.FileName;

                            //LOG
                            Model.Log log = new Model.Log(); //crée une entrée de log
                            log.dateLog = DateTime.Now; //on met la date du jour
                            log.typeLog = 0; //connexion est de type 0
                            log.actionLog = Server.HtmlEncode(Request.Cookies["TINom"].Value) + " a téléchargé " + fuNewArticle.FileName + " sur le serveur"; //on met l'action
                            lecontexte.LogSet.Add(log); //on ajoute au log
                            lecontexte.SaveChanges(); //on sauvegarde dans la BD
                            divSuccess.Visible = true;

                        }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text += "<b>ERREUR Lors de l'ajout d'un fichier </b>";
                divWarning.Visible = true;
            }
        }

        //Article
        //pour remplir la dropdownlist des articles
        public IQueryable<ParutionMedia> GetMediaList()
        {
            List<ParutionMedia> listeMedia = null;

            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                try
                {
                    listeMedia = ((from article in lecontexte.ParutionMediaSet.OfType<ParutionMedia>() select article).ToList());
                }
                catch (Exception ex)
                {
                    lblMessage.Text += "<b>ERREUR D'OUVERTURE DU CONTEXTE/RETOUR DES PARUTIONS MÉDIAS (LISTE)</b>";
                    divWarning.Visible = true;
                }
            return listeMedia.AsQueryable();
        }

        //Supprimer le media affiché
        public void DeleteMedia(ParutionMedia leMediaASupprimer)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                try
                {
                    ParutionMedia mediaASupprimer = (lecontexte.Set<ParutionMedia>().SingleOrDefault(article => article.IDParutionMedia == leMediaASupprimer.IDParutionMedia));


                    lecontexte.ParutionMediaSet.Remove(mediaASupprimer);

                    lecontexte.SaveChanges();
                    lvMedia.DataBind();
                    lvMedia.Visible = false;
                    ddlMedia.Items.Clear();
                    ddlMedia.DataBind();
                    divSuccess.Visible = true;
                }
                catch (Exception ex)
                {
                    lblMessage.Text += "<b>ERREUR lORS DE LA SUPPRESSION D'UN MÉDIA </b>";
                    divWarning.Visible = true;
                }
        }


        protected void lvMedia_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                try
                {
                    if (e.Item.ItemType == ListViewItemType.DataItem)
                    {
                        ParutionMedia mediaalecran = (ParutionMedia)e.Item.DataItem;
                        ParutionMedia leMedia = (lecontexte.Set<ParutionMedia>().SingleOrDefault(article => article.IDParutionMedia == mediaalecran.IDParutionMedia));
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text += "<b>ERREUR DE ITEMDATABOUND </b>";
                    divWarning.Visible = true;
                }
        }

        //récupère les parutions
        public IQueryable<ParutionMedia> GetMedia()
        {

            List<ParutionMedia> nbMedia = null;
            List<ParutionMedia> newMedia = null;

            try
            {
                using (LeModelTIContainer lecontexte = new LeModelTIContainer())
                {

                    nbMedia = ((from article in lecontexte.ParutionMediaSet.OfType<ParutionMedia>() select article).ToList());//génère une liste des membres pour en avoir un nombre de membres et générer le bon ID Utilisateur
                    if (ViewState["noMedia"] != null)
                    {
                        int media = int.Parse(ViewState["noMedia"].ToString());
                        newMedia = ((from article in lecontexte.ParutionMediaSet.OfType<ParutionMedia>() where article.IDParutionMedia == media select article).ToList());
                    }

                }

                if ((string)ViewState["mode"] + "" == "ajoute")  // SEULEMENT UN MEDIA «VIDE»
                {
                    newMedia = new List<ParutionMedia>();
                    ParutionMedia mediaVide = new ParutionMedia();

                    mediaVide.IDParutionMedia = (nbMedia.Count + 1);
                    mediaVide.pathFichierPDF = "";
                    mediaVide.dateParution = DateTime.Now;
                    mediaVide.titreParution = "";
                    mediaVide.descriptionParution = "";
                    mediaVide.ProfesseurIDUtilisateur = Convert.ToInt32(Server.HtmlEncode(Request.Cookies["TIID"].Value));
                    newMedia.Add(mediaVide);
                }


            }
            catch (Exception ex)
            {
                lblMessage.Text += "<b>ERREUR AVEC LE MÉDIA: </b>" + ex.ToString();
                divWarning.Visible = true;
            }
            return newMedia.AsQueryable();
        }

        //modifie une parution
        protected void btnModif_Click(object sender, EventArgs e)
        {


            ViewState["noMedia"] = ddlMedia.SelectedValue;
            ViewState["mode"] = "édite";
            lvMedia.DataBind();
            lvMedia.Visible = true;
        }

        //ajoute un média
        protected void btnAjout_Click(object sender, EventArgs e)
        {

            //mettre une vérification que c'est un prof
            try
            {
                lvMedia.Visible = true;
                ViewState["mode"] = "ajoute";
                lvMedia.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text += "<b>ERREUR LORS DE L'AJOUT D'UN MEDIA </b> ";
                divWarning.Visible = true;
            }
        }



        //Mettre à jour le Media
        public void UpdateMedia(ParutionMedia leMediaAUpdater)
        {
            using (LeModelTIContainer lecontexte = new LeModelTIContainer())
            {
                ParutionMedia leMediaAUpdaterCopie = new ParutionMedia();
                if ((string)ViewState["mode"] == "édite")
                {
                    leMediaAUpdaterCopie = (lecontexte.Set<ParutionMedia>().SingleOrDefault(m => m.IDParutionMedia == leMediaAUpdater.IDParutionMedia));
                }
                else
                { leMediaAUpdaterCopie = leMediaAUpdater; }

                ListViewItem lvmediacourant = lvMedia.Items[0];

                //VÉRIFIE SI CE QUI EST A L'ÉCRAN EST VALIDE ET EN VERSE LE CONTENU DANS LEMEMBREAUPDATER
                //---------------------------------------------------------------------------------------
                TryUpdateModel(leMediaAUpdaterCopie);

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
                        divWarning.Visible = true;
                    }
                    //RAMÈNE LE MEMBRE QUI EST A L'ÉCRAN VERS L'OBJET, FAIT AUSSI LA VALIDATION MAIS ON L'IGNORE

                }
                else // VALIDE
                {
                    lblMessage.Text = "";
                    try
                    {
                        var contextval = new ValidationContext(leMediaAUpdaterCopie, serviceProvider: null, items: null);
                        var results = new List<ValidationResult>();
                        var isValid = Validator.TryValidateObject(leMediaAUpdaterCopie, contextval, results); // VALIDE LE MEMBRE
                        if (!isValid) // NON VALIDE
                        {
                            foreach (var validationResult in results)
                            {
                                lblMessage.Text += validationResult.ErrorMessage + "<br/>";
                            }

                        }
                        if ((string)ViewState["mode"] == "ajoute")
                        {
                            lecontexte.Set<ParutionMedia>().Add(leMediaAUpdaterCopie);
                        }

                        ListViewItem lvmediacourant1 = lvMedia.Items[0];

                        lecontexte.SaveChanges();
                        ViewState["mode"] = "édite";
                        ddlMedia.DataBind();
                       
                    }
                    catch (DbEntityValidationException el)
                    {
                        foreach (var eve in el.EntityValidationErrors)
                        {
                            
                            foreach (var ve in eve.ValidationErrors)
                            {
                                lblMessage.Text += "<b>"+ve.PropertyName+":</b>"
                                     + ve.ErrorMessage + "<br/>";
                            }
                        }
                        divWarning.Visible = true; 
                    }
                    // Attrappe les erreurs au Save Changes. Utile pour découvrir quelle propriété est en erreur.



                }
            }
        }

    }
}
