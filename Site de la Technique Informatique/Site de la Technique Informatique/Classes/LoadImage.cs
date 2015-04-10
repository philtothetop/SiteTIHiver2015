using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace Site_de_la_Technique_Informatique.Classes
{
    public class LoadImage
    {
        //public System.Drawing.Image loadImage(String data)
        //{
        //    //get a temp image from bytes, instead of loading from disk
        //    //data:image/gif;base64,
        //    //this image is a single pixel (black)
        //    //byte[] bytes = Convert.FromBase64String("R0lGODlhAQABAIAAAAAAAAAAACH5BAAAAAAALAAAAAABAAEAAAICTAEAOw==");
        //    data = data.Remove(0, 22);
        //    byte[] bytes = Convert.FromBase64String(data);
        //    System.Drawing.Image image;
        //    using (MemoryStream ms = new MemoryStream(bytes))
        //    {
        //        image = System.Drawing.Image.FromStream(ms);
        //        string cropFileName = "";
        //        string cropFilePath = "";
        //        cropFileName = "crop_" + "testImg";
        //        cropFilePath = Path.Combine(Server.MapPath("~/Photos/Profils/"), cropFileName);
        //    }

        //    return image;
        //}
    }
}