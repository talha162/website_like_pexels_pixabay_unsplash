using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace WebApplication9
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            LoadImages();
        }


        

        private void LoadImages()
        {
            string textbox4 = WebForm1.textbox4value;
            uploadLinqDataContext db = new uploadLinqDataContext();
            var file2 = (from up in db.uploads
                         where up.tag1.Contains(textbox4) ||
                         up.tag2.Contains(textbox4) ||
                         up.tag3.Contains(textbox4)
                         select up.filesource); //from here you can find command

            if (file2 == null)
            {

                string msg = "<script language=\"javascript\">";
                msg += "alert('" + "No images found" + "');";
                msg += "</script>";
                Response.Write(msg);

            }
            else
            {
                foreach (var file in file2)
                {
                    FileInfo fi = new FileInfo(file);
                    ImageButton imageButton = new ImageButton();
                    imageButton.ImageUrl = "~/image/" + fi.Name;
                    imageButton.Height = Unit.Pixel(250);
                    imageButton.Style.Add("padding", "1px");
                    imageButton.CssClass = "col-md-3 col-sm-6";
                    imageButton.Click += new ImageClickEventHandler(imageButton_Click);
                    Panel1.Controls.Add(imageButton);
                }
            }
        }

       
        protected void imageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WebForm4.aspx?ImageURL=" +
                ((ImageButton)sender).ImageUrl);
        }
    }
}

