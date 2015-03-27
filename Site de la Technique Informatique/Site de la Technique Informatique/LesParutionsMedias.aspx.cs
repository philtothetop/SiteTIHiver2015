// Cette classe permet à tout le monde de pouvoir consulter les aprutions médias
// Écrit par Raphael Brouard, Mars 2015
// Intrants: Vide
// Extrants: Vide

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Site_de_la_Technique_Informatique.Model;
using System.Net;

namespace Site_de_la_Technique_Informatique
{
    public partial class LesParutionsMedias : ErrorHandling
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                //Besoin de cela pour la premiere fois que on load la page, mettre le datapager visible ou non si plusieurs parutions médias
                dataPagerDesParutions.Visible = (dataPagerDesParutions.PageSize < dataPagerDesParutions.TotalRowCount);
            }
        }

        //Méthode pour récupérer les parutions mdias de la BD
        public IQueryable<Model.ParutionMedia> GetLesParutionsMedias()
        {
            //Créer une liste de base
            List<Model.ParutionMedia> listeParutionMedias = new List<Model.ParutionMedia>();

            try
            {
                using (LeModelTIContainer modelTI = new LeModelTIContainer())
                {
                    DateTime dateAComparer = DateTime.Now.AddYears(-1);

                    //Récupérer les parutions médias
                    listeParutionMedias = (from cl in modelTI.ParutionMediaSet
                                                   where cl.dateParution >= dateAComparer
                                                   select cl).ToList();
                }
            }
            catch (Exception ex)
            {
                LogErreur("LesParutionsMedias.aspx.cs dans la méthode GetLesParutionsMedias", ex);
            }

            return listeParutionMedias.AsQueryable().Reverse();
        }

        //Méthode pour voir/downloader le PDF de la parution média
        protected void lnkPDF_Click(object sender, EventArgs e)
        {
            try
            {
                String argument = Convert.ToString(((LinkButton)sender).CommandArgument);
                string FilePath = Server.MapPath("Upload/Media/" + argument);

                WebClient User = new WebClient();
                Byte[] FileBuffer = User.DownloadData(FilePath);
                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }
            }
            catch (Exception ex)
            {
                LogErreur("LesParutionsMedias.aspx.cs dans la méthode lnkPDF_Click", ex);
            }
        }
    }
}