using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace WebApplication9
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadImages();
        }

        uploadLinqDataContext up = new uploadLinqDataContext();
        loginDataContext lo = new loginDataContext();
        private void LoadImages()
        {
                var data = from u in up.uploads where u.SId ==Convert.ToInt32(Session["id"]) select u.filesource;
                foreach(var d3 in data)
                {
                    FileInfo fi = new FileInfo(d3);
                    ImageButton imageButton = new ImageButton();
                    imageButton.ImageUrl = "~/image/" + fi.Name;
                    imageButton.Height = Unit.Pixel(250);
                    imageButton.Style.Add("padding", "1px");
                    imageButton.CssClass = "col-md-3 col-sm-6 img-fluid img-thumbnail";
                    imageButton.Click += new ImageClickEventHandler(imageButton_Click);
                    Panel1.Controls.Add(imageButton);
                }
               
            
        }

        protected void imageButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WebForm4.aspx?ImageURL=" +
                ((ImageButton)sender).ImageUrl);
        }
    }
}