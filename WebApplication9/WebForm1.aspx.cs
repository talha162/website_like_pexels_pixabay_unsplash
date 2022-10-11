using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication9
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static string textbox4value = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            uploadLinqDataContext db = new uploadLinqDataContext();
            var file2 = (from up in db.uploads
                         select up.filesource);
            foreach (var file in file2)
            {
                FileInfo fi = new FileInfo(file);
                ImageButton imageButton = new ImageButton();
                imageButton.ImageUrl = "~/image/" + fi.Name;
                imageButton.Height = Unit.Pixel(250);
                imageButton.Style.Add("padding", "1px");
                imageButton.CssClass = "col-lg-3 col-md-4 col-sm-6 ";
                imageButton.Click += new ImageClickEventHandler(imageButton_Click);
                Panel1.Controls.Add(imageButton);
            }
        }



        protected void Button2_Click(object sender, EventArgs e)
        {


            uploadLinqDataContext db = new uploadLinqDataContext();
            var tag12 = (from up in db.uploads select up.tag1).Union(from up in db.uploads select up.tag2);
            var tag3 = from up in db.uploads select up.tag3;
            int c = 0;

            foreach (var tags in tag12.Union(tag3))
            {
                if (tags == TextBox4.Text)
                {
                    textbox4value = TextBox4.Text;
                    Response.Redirect("WebForm2.aspx");
                }
                else
                {
                    c++;
                    if (c == 1)
                    {
                        string msg = "<script language=\"javascript\">";
                        msg += "alert('" + "Not found" + "');";
                        msg += "</script>";
                        Response.Write(msg);
                    }
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
