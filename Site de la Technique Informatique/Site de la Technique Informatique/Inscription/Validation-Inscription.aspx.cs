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


namespace Site_de_la_Technique_Informatique.Inscription
{
    public partial class Validation_Inscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<Etudiant> GetUtilisateurEtudiantList()
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {

                    return (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where cl.valideCourriel == false && cl.compteActif == false orderby cl.IDEtudiant descending select cl).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
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
                            Etudiant etudiant = (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where cl.IDEtudiant == id select cl).FirstOrDefault();

                            leContext.UtilisateurSet.Remove(etudiant);
                        }
                    }
                    leContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }
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
                            Etudiant etudiant = (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where cl.IDEtudiant == id select cl).FirstOrDefault();

                            etudiant.compteActif = true;
                        }
                    }
                    leContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void checkTous()
        {
            try
            {
                using (LeModelTIContainer leContext = new LeModelTIContainer())
                {
                    ListView listv = lviewValidationInscription;
                    CheckBox chSelectionnerTous =(CheckBox)listv.FindControl("chSelectionnerTous");
                    if(chSelectionnerTous!=null)
                    {
                    foreach (ListViewDataItem item in listv.Items)
                    {
                        CheckBox chSelectionner = (CheckBox)item.FindControl("chSelectionner");
                        if (chSelectionner != null)
                        {
                         if(chSelectionnerTous.Checked)
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

            }
        }
        protected void lnkRefuserTousHaut_Click(object sender, EventArgs e)
        {
            lnkSupprimerTous();
            Response.Redirect(Request.RawUrl);
        }

        protected void lnkAccepterTousHaut_Click(object sender, EventArgs e)
        {
            lnkAccepterTous();
            Response.Redirect(Request.RawUrl);
        }

        protected void chSelectionnerTous_CheckedChanged(object sender, EventArgs e)
        {
            checkTous();
        }

        protected void lnkAccepter_Click(object sender, EventArgs e)
        {
            try
            {
                using(LeModelTIContainer leContext= new LeModelTIContainer())
                {
                    LinkButton lnkAccepter = (LinkButton)sender;
                    int idEtudiant =int.Parse(lnkAccepter.CommandArgument);
                    Etudiant etudiant = (from cl in leContext.UtilisateurSet.OfType<Etudiant>() where cl.IDEtudiant == idEtudiant select cl).FirstOrDefault();
                    etudiant.compteActif = true;
                    leContext.SaveChanges();


                }
            }catch(Exception ex)
            {

            }
        }

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
                    leContext.SaveChanges();


                }
            }
            catch (Exception ex)
            {

            }
        }


    }
}