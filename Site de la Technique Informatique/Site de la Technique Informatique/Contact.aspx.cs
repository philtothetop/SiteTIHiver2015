// Cette classe permet à une personne d'envoyer un courriel au département
// Écrit par Marie-Philippe Gill, Février 2015	

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;


namespace Site_de_la_Technique_Informatique
{
    public partial class Contact : ErrorHandling 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessageHaut.Attributes["style"] += "";
        }

        protected void btnEnvoyer_Click(object sender, EventArgs e)
        {
            envoyerEmail();
        }

        #region Envoyer un email
        public void envoyerEmail()
        {
            // METTRE ICI LE EMAIL DE LA PERSONNE QUI VA RÉPONDRE AUX MESSAGES DES FUTURS ÉTUDIANTS 
            string destinataire = "ddupaul@cegepgranby.qc.ca";
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(destinataire);

            // Informations de l'en-tête du message 
            // 1- Email de la personne qui contacte le département 
            // 2- Nom / Prénom de la personne qui contacte le département 
            mail.From = new System.Net.Mail.MailAddress(destinataire, txtNom.Text, System.Text.Encoding.UTF8);

            // Sujet de l'email envoyé
            mail.Subject = "Module de contact du site web TI";

            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            // Email de qui provient l'email (donc va chercher l'email de la personne dans le textbox)
            string from = txtCourriel.Text.Trim();

            // Corps du message : contient ce que la personne a écrit dans le module seulement
            string myStr = txtMessage.Text;
            mail.Body = myStr;



            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.High;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("mariephilippe.gill@gmail.com", "Sarah211");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur d'envoie de message : " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Essai d'envoi à : " + destinataire);
            }
            txtNom.Text = "";
            txtCourriel.Text = "";
            txtMessage.Text = "";

            lblMessageHaut.Attributes["style"] += "color:green;";
            lblMessageHaut.Text += "Vous avez bien envoyé votre message. Vous devriez avoir une réponse sous peu.";
        }
        #endregion
    }
}