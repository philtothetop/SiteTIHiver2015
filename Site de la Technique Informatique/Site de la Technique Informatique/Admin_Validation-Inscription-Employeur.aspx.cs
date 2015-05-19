//code C# page Validation Inscription-employeur
//Écrit par Cédric Archambault
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Web.UI.HtmlControls;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using Site_de_la_Technique_Informatique.Classes;

namespace Site_de_la_Technique_Informatique
{
    public partial class Admin_Validation_Inscription_Employeur : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, false, false, false);
        }
        //Cette classe cherche la liste des étudiant inscription dont leur courriel n'a pas été validé depuis plus de 24 h.
        //Écrit par Cédric Archambault 17 avril 2015
        //Intrants:Vide
        //Extrants:IQueryable<Employeur> List
        public String GetCourrielEmployeurNonValiderList()
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    DateTime dt = DateTime.Now.AddHours(-24);
                    return (from cl in leContext.UtilisateurSet.OfType<Employeur>() where cl.valideCourriel == false && cl.compteActif == false && cl.dateInscription < dt select cl).Count().ToString();
                }

            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur Get Courriel Employeur Non Valider List : " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "");
            }
           
        }
        //Cette class chercher la liste des Employeurs inscription dont leur courriel à été validé, mais leur compte n'est pas acctiver.
        //Écrit par Cédric Archambault 27 février 2015
        //Intrants:Vide
        //Extrants:IQueryable<Employeur> List
        public IQueryable<Employeur> GetUtilisateurEmployeurList()
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    List<Employeur> employeurList = (from cl in leContext.UtilisateurSet.OfType<Employeur>() where cl.valideCourriel == true && cl.compteActif == false orderby cl.IDEmployeur descending select cl).ToList();


                    if (employeurList.Count == 0)
                    {

                        divAucunNouvelleInscription.Visible = true;
                    }
                    else
                    {
                        divAucunNouvelleInscription.Visible = false;
                    }

                    return employeurList.AsQueryable();

                }
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur GetUtilisateurEmployeurList: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Essai d'envoi à : ");
            }
            
        }
        //Cette class Efface tous les comptes étudiants sélectionner
        //Écrit par Cédric Archambault 27 février 2015
        //Intrants:Vide
        //Extrants:Vide
        protected void lnkSupprimerTous()
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    ListView listv = lviewValidationInscription;
                    foreach (ListViewDataItem item in listv.Items)
                    {
                        CheckBox chSelectionner = (CheckBox)item.FindControl("chSelectionner");
                        Label lblId = (Label)item.FindControl("lblId");
                        if (chSelectionner != null && lblId != null && chSelectionner.Checked)
                        {
                            int id = int.Parse(lblId.Text);
                            Employeur employeur = (from cl in leContext.UtilisateurSet.OfType<Employeur>() where cl.IDEmployeur == id select cl).FirstOrDefault();
                            
                            leContext.UtilisateurSet.Remove(employeur);
                            if (envoie_courriel_confirmationRefuser(employeur) == false)
                            {
                                lblMessage.Text = "Il est impossible d'envoyer les courriels de confirmation du refus, mais les inscriptions ont été refusées.";
                                lblMessage.Visible = true;
                                break;
                            }
                            else
                            {
                                lblMessage.Visible = false;
                            }
                        }
                    }
                    leContext.SaveChanges();
                    Response.Redirect(Request.RawUrl);
                }
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur Supprimer tous: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "");
            }
        }
        //Cette class refuser un étudiant.
        //Écrit par Cédric Archambault 27 février 2015
        //Intrants:Objet Employeur
        //Extrants:vide
        protected void lnkRefuser_Click(object sender, EventArgs e)
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    LinkButton lnkAccepter = (LinkButton)sender;
                    int idEmployeur = int.Parse(lnkAccepter.CommandArgument);
                    Employeur employeur = (from cl in leContext.UtilisateurSet.OfType<Employeur>() where cl.IDEmployeur== idEmployeur select cl).FirstOrDefault();
                    leContext.UtilisateurSet.Remove(employeur);
                    if (envoie_courriel_confirmationRefuser(employeur) == false)
                    {
                        lblMessage.Text = "Il est impossible d'envoyer un courriel de confirmation du refus, mais inscription a été refusée.";
                        lblMessage.Visible = true;
                    }
                    else
                    {
                        lblMessage.Visible = false;
                    }
                    
                    leContext.SaveChanges();
                    Response.Redirect(Request.RawUrl);

                }
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur refuser Click: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "");
            }
        }

        //Cette class Accepter tous les comptes étudiants sélectionner
        //Écrit par Cédric Archambault 27 février 2015
        //Intrants:Vide
        //Extrants:Vide
        protected void lnkAccepterTous()
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {

                    ListView listv = lviewValidationInscription;
                    foreach (ListViewDataItem item in listv.Items)
                    {
                        CheckBox chSelectionner = (CheckBox)item.FindControl("chSelectionner");
                        Label lblId = (Label)item.FindControl("lblId");
                        if (chSelectionner != null && lblId != null && chSelectionner.Checked)
                        {
                            int id = int.Parse(lblId.Text);
                            Employeur employeur = (from cl in leContext.UtilisateurSet.OfType<Employeur>() where cl.IDEmployeur == id select cl).FirstOrDefault();

                            if (envoie_courriel_confirmation(employeur) == false)
                            {
                                lblMessage.Text = "Impossible d'accepter toutes les inscriptions, car il est impossible d'envoyer les courriels de validation.";
                                lblMessage.Visible = true;
                                break;// sort de la boucle 
                            }
                            else
                            {
                                lblMessage.Visible = false;
                                employeur.compteActif = false;//Ative le compte.
                                leContext.SaveChanges();
                                Response.Redirect(Request.RawUrl);
                            }
                        }
                    }
                   
                    
                }
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur Accepter tous: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "");
            }
        }
        //Cette class Accepter un étudiant.
        //Écrit par Cédric Archambault 27 février 2015
        //Intrants:Objet Employeur
        //Extrants:vide
        protected void lnkAccepter_Click(object sender, EventArgs e)
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    LinkButton lnkAccepter = (LinkButton)sender;
                    int iDEmployeur = int.Parse(lnkAccepter.CommandArgument);
                    Employeur employeur = (from cl in leContext.UtilisateurSet.OfType<Employeur>() where cl.IDEmployeur == iDEmployeur select cl).FirstOrDefault();

                    if(envoie_courriel_confirmation(employeur)==false)
                    {
                        lblMessage.Text = "Impossible d'accepter l'inscription, car il est impossible d'envoyer un courriel de validation.";
                        lblMessage.Visible = true;
                    }else
                    {
                        lblMessage.Visible = false;
                        employeur.compteActif = false;//Ative le compte.
                        leContext.SaveChanges();
                        Response.Redirect(Request.RawUrl);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur Accepter Click: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "");
            }
        }
        //Cette class sélectionne tous les étudiants à l'écran.
        //Écrit par Cédric Archambault 27 février 2015
        //Intrants:Objet Employeur
        //Extrants:vide
        protected void checkTous()
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    ListView listv = lviewValidationInscription;
                    CheckBox chSelectionnerTous = (CheckBox)listv.FindControl("chSelectionnerTous");
                    if (chSelectionnerTous != null)
                    {
                        foreach (ListViewDataItem item in listv.Items)
                        {
                            CheckBox chSelectionner = (CheckBox)item.FindControl("chSelectionner");
                            if (chSelectionner != null)
                            {
                                if (chSelectionnerTous.Checked)
                                {
                                    chSelectionner.Checked = true;
                                }
                                else
                                {
                                    chSelectionner.Checked = false;
                                }
                            }
                        }
                    }
                    leContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur Check tous: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "");
            }
        }

        protected void lnkRefuserTousHaut_Click(object sender, EventArgs e)
        {
            lnkSupprimerTous();
        }

        protected void lnkAccepterTousHaut_Click(object sender, EventArgs e)
        {
            lnkAccepterTous();
        }

        protected void chSelectionnerTous_CheckedChanged(object sender, EventArgs e)
        {
            checkTous();
        }

        protected void lnkEffacerInscriptionCourrielNonValider_Click(object sender, EventArgs e)
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    DateTime dt = DateTime.Now.AddHours(-24);
                    List<Employeur> employeurList = (from cl in leContext.UtilisateurSet.OfType<Employeur>() where cl.valideCourriel == false && cl.compteActif == false && cl.dateInscription < dt select cl).ToList();

                    if (employeurList.Count > 0)
                    {
                        foreach (var employeur in employeurList)
                        {
                            leContext.UtilisateurSet.Remove(employeur);
                        }
                        leContext.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur Effacer Inscription Courriel Non Valider: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "");
            }
        }
        //Cette class permet d'envoyer un courriel de confirmation de l'inscription.
        //Écrit par Cédric Archambault 18 février 2015
        //Intrants:Employeur
        //Extrants:Aucun
        public bool envoie_courriel_confirmation(Employeur employeur)
        {
            // METTRE ICI LE EMAIL DE LA PERSONNE QUI VA RÉPONDRE AUX MESSAGES DES FUTURS ÉTUDIANTS 
            String titre = "Inscription TI Cegep de Granby";
            String message = "Cher " + employeur.nomEmployeur + ", l'administrateur a activé votre compte. ";

            courrielAutomatiser courriel = new courrielAutomatiser();

            return courriel.envoie(employeur.courriel, titre, message);
            



        }

        //Cette class permet d'envoyer un courriel de confirmation de l'inscription.
        //Écrit par Cédric Archambault 18 février 2015
        //Intrants:Employeur
        //Extrants:Aucun
        public bool envoie_courriel_confirmationRefuser(Employeur employeur)
        {
            // METTRE ICI LE EMAIL DE LA PERSONNE QUI VA RÉPONDRE AUX MESSAGES DES FUTURS ÉTUDIANTS 
            String titre = "Inscription TI Cegep de Granby";
            String message = "Cher " + employeur.nomEmployeur + ", l'administrateur a refuser votre inscription. ";

            courrielAutomatiser courriel = new courrielAutomatiser();

            return courriel.envoie(employeur.courriel, titre, message);
             



      


        }

    }
}