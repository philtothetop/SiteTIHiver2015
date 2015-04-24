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
    public partial class Admin_Media : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                            if (!System.IO.Directory.Exists(Server.MapPath("Upload\\" + dossier + "\\")))
                            {
                                System.IO.Directory.CreateDirectory(Server.MapPath("Upload\\" + dossier + "\\"));
                            }

                            // Enregistre la photo à sa place 
                            fuNewArticle.SaveAs(Server.MapPath("Upload\\" + dossier + "\\" + fuNewArticle.FileName));

                            // ajoute le chemin de la photo de profil dans la base de données

                            (lvMedia.Items[0].FindControl("txtArticle") as TextBox).Text = fuNewArticle.FileName;

                            //LOG
                            Model.Log log = new Model.Log(); //crée une entrée de log
                            log.dateLog = DateTime.Now; //on met la date du jour
                            log.typeLog = 0; //connexion est de type 0
                            log.actionLog = Server.HtmlEncode(Request.Cookies["TINom"].Value) + " a téléchargé " + fuNewArticle.FileName + " sur le serveur"; //on met l'action
                            lecontexte.LogSet.Add(log); //on ajoute au log
                            lecontexte.SaveChanges(); //on sauvegarde dans la BD

                        }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text += "ERREUR FILEUPLOAD: " + ex.ToString();
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
                    lblMessage.Text += "ERREUR D'OUVERTURE DU CONTEXTE/RETOUR DES PARUTIONS MÉDIAS (LISTE), " + ex.ToString();
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
                }
                catch (Exception ex)
                {
                    lblMessage.Text += "ERREUR DE SUPPRESSION D'UN MÉDIA, " + ex.ToString();
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
                    lblMessage.Text += "ERREUR DE ITEMDATABOUND, " + ex.ToString();
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
                    nbMedia = ((from article in lecontexte.ParutionMediaSet.OfType<ParutionMedia>() select article).ToList());  //génère une liste des membres pour en avoir un nombre de membres et générer le bon ID Utilisateur
                    newMedia = ((from article in lecontexte.ParutionMediaSet.OfType<ParutionMedia>() where article.IDParutionMedia == nbMedia.Count select article).ToList());

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
                lblMessage.Text += "ERREUR AVEC LE MÉDIA, " + ex.ToString();
            }
            return newMedia.AsQueryable();
        }

        //modifie une parution
        protected void btnModif_Click(object sender, EventArgs e)
        {

            lvMedia.Visible = true;
            ViewState["noMedia"] = ddlMedia.SelectedValue;
            ViewState["mode"] = "édite";
            lvMedia.DataBind();
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
                lblMessage.Text += "ERREUR LORS DE L'«AJOUT» D'UN MEDIA, " + ex.ToString();
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
                TryUpdateModel(leMediaAUpdaterCopie);  //RAMÈNE LE MEMBRE QUI EST A L'ÉCRAN VERS L'OBJET, FAIT AUSSI LA VALIDATION MAIS ON L'IGNORE
                var contextval = new ValidationContext(leMediaAUpdaterCopie, serviceProvider: null, items: null);
                var results = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(leMediaAUpdaterCopie, contextval, results); // VALIDE LE MEMBRE
                if (!isValid) // NON VALIDE
                {
                    foreach (var validationResult in results)
                    {
                        lblMessage.Text += validationResult.ErrorMessage;
                    }
                }
                else // VALIDE
                {
                    lblMessage.Text = "";
                    try
                    {

                        if ((string)ViewState["mode"] == "ajoute")
                        {
                            lecontexte.Set<ParutionMedia>().Add(leMediaAUpdaterCopie);
                        }

                        ListViewItem lvmediacourant1 = lvMedia.Items[0];

                        lecontexte.SaveChanges();
                    }
                    // Attrappe les erreurs au Save Changes. Utile pour découvrir quelle propriété est en erreur.
                    catch (DbEntityValidationException el)
                    {
                        foreach (var eve in el.EntityValidationErrors)
                        {
                            lblMessage.Text += "Entity of type \"{0}\" in state \"{1}\" has the following validation errors:" +
                                eve.Entry.Entity.GetType().Name + eve.Entry.State;
                            foreach (var ve in eve.ValidationErrors)
                            {
                                lblMessage.Text += "- Property: \"{0}\", Error: \"{1}\"" +
                                    ve.PropertyName + ve.ErrorMessage;
                            }
                        }
                    }

                    ViewState["mode"] = "édite";
                    ddlMedia.DataBind();
                }
            }
        }

    }
}