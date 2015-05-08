using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site_de_la_Technique_Informatique.Classes
{
    public class courrielAutomatiser
    {

        private String CourrielEnvoyeur = "sitewebti@gmail.com";
        private String nomAfficher = "Technique Informatique Cegep";
        private String motPasse = "site1web!ti?";
        private String host = "smtp.gmail.com";
        private int clientPort = 587;

        public bool envoie(String courriel,String titre,String message)
        {
            // METTRE ICI LE EMAIL DE LA PERSONNE QUI VA RÉPONDRE AUX MESSAGES DES FUTURS ÉTUDIANTS 

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(courriel);

            // Informations de l'en-tête du message 
            // 1- Email de la personne qui contacte le département 
            // 2- Nom / Prénom de la personne qui contacte le département 
            mail.From = new System.Net.Mail.MailAddress(CourrielEnvoyeur, nomAfficher, System.Text.Encoding.UTF8);

            // Sujet de l'email envoyé
            mail.Subject = titre;

            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            // Corps du message : contient ce que la personne a écrit dans le module seulement
            mail.Body = message;


            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.High;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(CourrielEnvoyeur, motPasse);
            client.Port = clientPort;
            client.Host = host;
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Exception logEx = ex;
                throw new Exception("Erreur d'envoie de message : " + ex.ToString() + "Inner exception de l'erreur: " + logEx.InnerException + "Essai d'envoi à : ");
            }
        }
    }
}