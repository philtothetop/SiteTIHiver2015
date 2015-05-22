//code C# page Validation Inscription
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



namespace Site_de_la_Technique_Informatique.Inscription
{
    public partial class Validation_Inscription : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SavoirSiPossedeAutorizationPourLaPage(false, true, false, false, false);

        }
        //Cette class chercher la liste des étudiant inscription dont leur courriel n'a pas été validé depuis plus de 24 h.
        //Écrit par Cédric Archambault 2 mars 2015
        //Intrants:Vide
        //Extrants:IQueryable<Etudiant> List
        public String GetCourrielNonValiderList()
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    DateTime dt = DateTime.Now.AddHours(-24);
                    return (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where cl.valideCourriel == false && cl.compteActif == 0 && cl.dateInscription < dt select cl).Count().ToString();
                }

            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur liste etudiant courriel non valide 24h: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Chercher liste nombre courriel : ");
            }
            
        }
        //Cette class chercher la liste des étudiant inscription dont leur courriel à été validé, mais leur compte n'est pas acctiver.
        //Écrit par Cédric Archambault 27 février 2015
        //Intrants:Vide
        //Extrants:IQueryable<Etudiant> List
        public IQueryable<Etudiant> GetUtilisateurEtudiantList()
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    List<Etudiant> etudiantList = (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where cl.valideCourriel == true && cl.compteActif == 0 orderby cl.IDEtudiant descending select cl).ToList();

                    
                    if(etudiantList.Count==0)
                    { divAucunNouvelleInscription.Visible = true;
                    }
                    else
                    {
                        divAucunNouvelleInscription.Visible = false;
                    }

                    return etudiantList.AsQueryable();
                        
                }
            }
            catch (Exception ex)
            {

                Exception logEx = ex;
                throw new Exception("Erreur GetUtilisateurEtudiantList: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Essai d'envoi à : ");
            }
       
        }
       
        //Cette class refuser un étudiant.
        //Écrit par Cédric Archambault 27 février 2015
        //Intrants:Objet Etudiant
        //Extrants:vide
        protected void lnkRefuser_Click(object sender, EventArgs e)
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    LinkButton lnkAccepter = (LinkButton)sender;
                    int idEtudiant = int.Parse(lnkAccepter.CommandArgument);
                    Etudiant etudiant = (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where cl.IDEtudiant == idEtudiant select cl).FirstOrDefault();
                    leContext.UtilisateurSet.Remove(etudiant);

                    string pathImageDelete = "~/Upload/Photos/Profils/" + etudiant.pathPhotoProfil;

                    //Vérifier si image exist avant de delete ET si c pas iamge de base
                    if (File.Exists(pathImageDelete) && !etudiant.pathPhotoProfil.ToLower().Equals("photobase.bmp"))
                    {
                        File.Delete(pathImageDelete);
                    }

                    if (envoie_courriel_confirmationRefuser(etudiant) == false)
                    {
                        lblMessage.Text = "Il est impossible d'envoyer un courriel de confirmation du refus, mais inscription a été refusée.";
                        lblMessage.Visible = true;
                    }
                    else
                    {
                        lblMessage.Visible = false;
                    }
                    leContext.SaveChanges();
                    lviewValidationInscription.DataBind();

                }
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur Refuser: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Essai d'envoi à : ");
            }
        }

        //Cette class Accepter un étudiant.
        //Écrit par Cédric Archambault 27 février 2015
        //Intrants:Objet Etudiant
        //Extrants:vide
        protected void lnkAccepter_Click(object sender, EventArgs e)
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    LinkButton lnkAccepter = (LinkButton)sender;
                    int idEtudiant = int.Parse(lnkAccepter.CommandArgument);
                    Etudiant etudiant = (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where cl.IDEtudiant == idEtudiant select cl).FirstOrDefault();

                    if (envoie_courriel_confirmation(etudiant) == false)
                    {
                        lblMessage.Text = "Impossible d'accepter l'inscription, car il est impossible d'envoyer un courriel de validation.";
                        lblMessage.Visible = true;
                    }
                    else
                    {
                        lblMessage.Visible = false;
                        etudiant.compteActif = 1;//Ative le compte.
                        leContext.SaveChanges();
                        lviewValidationInscription.DataBind();
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
        //Intrants:Objet Etudiant
        //Extrants:vide
       

        protected void lnkEffacerInscriptionCourrielNonValider_Click(object sender, EventArgs e)
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    DateTime dt = DateTime.Now.AddHours(-24);
                    List<Etudiant> etudiantList = (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where cl.valideCourriel == false && cl.compteActif == 0 && cl.dateInscription < dt select cl).ToList();

                    if (etudiantList.Count > 0)
                    {
                        foreach (var etudiant in etudiantList)
                        {
                            leContext.UtilisateurSet.Remove(etudiant);
                        }
                        leContext.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur Effacer Inscription Courriel Non Valide: " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + " ");
            }
        }
        //Cette class permet d'envoyer un courriel de confirmation de l'inscription.
        //Écrit par Cédric Archambault 18 février 2015
        //Intrants:Etudiant
        //Extrants:Aucun
        public bool envoie_courriel_confirmation(Etudiant etudiant)
        {
            String titre = "Inscription TI Cégep de Granby";
            String message = "Cher/Chère " + etudiant.prenom + " " + etudiant.nom + ", l'administrateur a activé votre compte. ";

            courrielAutomatiser courriel = new courrielAutomatiser();

            return courriel.envoie(etudiant.courriel, titre, message);
        }

        public bool envoie_courriel_confirmationRefuser(Etudiant etudiant)
        {

             
            String titre = "Inscription TI Cégep de Granby";
            String message = "Cher/Chère " + etudiant.prenom + " " + etudiant.nom + ", l'administrateur a refusé votre inscription. ";

            courrielAutomatiser courriel = new courrielAutomatiser();

            return courriel.envoie(etudiant.courriel, titre, message);
            



        }

    }
}