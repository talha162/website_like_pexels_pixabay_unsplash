using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace WebApplication9
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            uploadLinqDataContext db = new uploadLinqDataContext();
            if (FileUpload1.HasFile)
            {
                string fileName = FileUpload1.FileName;
                var path = Server.MapPath("~/image/") + fileName;
                string fileExtension = Path.GetExtension(fileName);
                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".gif"
               || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                {
                    
                        FileUpload1.PostedFile.SaveAs(path);
                    string username=Session["username"].ToString();
                    
                    var uploadd = new upload()
                    {

                        name = fileName,
                        filesource = path,
                        tag1 = TextBox1.Text,
                        tag2 = TextBox2.Text,
                        tag3 = TextBox3.Text,
                        SId = Convert.ToInt32(Session["id"])
                        };
                        db.uploads.InsertOnSubmit(uploadd);
                        db.SubmitChanges();
                        string msg = "<script language=\"javascript\">";
                        msg += "alert('" + "file submitted" + "');";
                        msg += "</script>";
                        Response.Write(msg);
                    


                }
            }
            else
            {
                string msg = "<script language=\"javascript\">";
                msg += "alert('" + "Error please upload image file" + "');";
                msg += "</script>";
                Response.Write(msg);
            }

        }
        
    }
}