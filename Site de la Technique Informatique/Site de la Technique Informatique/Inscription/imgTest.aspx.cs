using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site_de_la_Technique_Informatique.Inscription
{
    public partial class imgTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public System.Drawing.Image LoadImage()
        {
            //get a temp image from bytes, instead of loading from disk
            //data:image/gif;base64,
            //this image is a single pixel (black)
            //byte[] bytes = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw==");
            byte[] bytes = Convert.FromBase64String(txtBox.Text);
            System.Drawing.Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = System.Drawing.Image.FromStream(ms);
                string cropFileName = "";
                string cropFilePath = "";
                cropFileName = "crop_" + "testImg";
                cropFilePath = Path.Combine(Server.MapPath("~/Photos/Profils/"), cropFileName);
                
                image.Save(cropFilePath);
            }

            return image;
        }

        protected void lnk_Click(object sender, EventArgs e)
        {
            LoadImage();
        }
    }
}