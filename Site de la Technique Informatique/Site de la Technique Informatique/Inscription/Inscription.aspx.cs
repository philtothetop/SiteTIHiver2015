//code C# page d'inscription
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
    public partial class Inscription : System.Web.UI.Page
    {

        protected String img;
        protected void Page_Load()
        {


            if (Session["Utilisateur"] != null)
            {
                Response.Redirect("../Default.aspx", false);
            }
        }
    }
}
      
