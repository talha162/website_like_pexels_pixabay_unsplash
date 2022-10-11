using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace WebApplication9
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    Button4.Visible = false;
                }
                else if (Session["role"].Equals("user"))
                {
                    Button4.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Button4.Visible = false;
            }
            Image1.ImageUrl = Request.QueryString["ImageUrl"];
            Image1.CssClass = "col-12";

        }
        uploadLinqDataContext updb = new uploadLinqDataContext();
       
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    string msg = "<script language=\"javascript\">";
                    msg += "alert('" + "sign up and login to download" + "');";
                    msg += "</script>";
                    Response.Write(msg);
                }
                else if (Session["role"].Equals("user"))
                {
                    FileInfo fileInfo = new FileInfo(Request.QueryString["ImageUrl"]);
                    Response.ContentType = "application/octect-stream";
                    Response.AppendHeader("content-disposition", "filename=" + fileInfo.Name);

                    Response.TransmitFile(Server.MapPath(Request.QueryString["imageurl"]));
                    Response.End();

                }
            }
            catch(Exception ex)
            {
                string msg = "<script language=\"javascript\">";
                msg += "alert('" + "sign up and login to download" + "');";
                msg += "</script>";
                Response.Write(msg);
            }
            }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string imageurl = Request.QueryString["ImageUrl"];
            
            var id = from i in updb.uploads where Session["id"].Equals(i.SId) && i.filesource.Equals(Server.MapPath(imageurl)) select i;
            try
            {
                foreach (var c in id)
                {
                    if (Session["id"].Equals(c.SId))
                    {
                        updb.uploads.DeleteOnSubmit(c);
                        updb.SubmitChanges();
                        Response.Redirect("WebForm1.aspx");
                    }
                    else
                    {
                        ViewState["v"] = c.SId;
                    }
                }

                if (!Session["id"].Equals(ViewState["v"]))
                {

                    string msg = "<script language=\"javascript\">";
                    msg += "alert('" + "can not be deleted because you not upload this" + "');";
                    msg += "</script>";
                    Response.Write(msg);
                }
            }
            catch (Exception ex) {

                string msg = "<script language=\"javascript\">";
                msg += "alert('" + "can not be deleted because you not upload this" + "');";
                msg += "</script>";
                Response.Write(msg);
            } 
        }
        }
}