using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication9
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
            protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    LinkButton1.Visible = false;
                    LinkButton4.Visible = false;
                    LinkButton5.Visible = false;
                    LinkButton6.Visible = false;
                    LinkButton2.Visible = true;
                    LinkButton3.Visible = true;
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = true;
                    LinkButton4.Visible = true;
                    LinkButton5.Visible = true;
                    LinkButton6.Visible = true;
                    LinkButton2.Visible = false;
                    LinkButton3.Visible = false;
                    LinkButton5.Text = "hello " + Session["username"].ToString();
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Webform3.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Session["role"] = "";
            Session["username"] = "";
            Session["id"] = 0;
            LinkButton1.Visible = false;
            LinkButton4.Visible = false;
            LinkButton5.Visible = false;
            LinkButton6.Visible = false;
            LinkButton2.Visible = true;
            LinkButton3.Visible = true;
            Response.Redirect("WebForm1.aspx");
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm6.aspx");

        }

        protected void send_Click(object sender, EventArgs e)
        {
            contactusLinqDataContext dbp = new contactusLinqDataContext();
            var contacts = new contactus()
            {
                username = TextBox5.Text,
                email = TextBox6.Text,
                message = TextBox7.Text
            };
            dbp.contactus.InsertOnSubmit(contacts);
            dbp.SubmitChanges();

            string msg = "<script language=\"javascript\">";
            msg += "alert('" + "message submitted" + "');";
            msg += "</script>";
            Response.Write(msg);
        }

        loginDataContext ls = new loginDataContext();
        protected void signup_Click(object sender, EventArgs e)
        {

            var rows = from l in ls.signups select l.email;


            if (rows.Contains(TextBox9.Text))
            {

                string msg = "<script language=\"javascript\">";
                msg += "alert('" + "Email Already Exists" + "');";
                msg += "</script>";
                Response.Write(msg);
            }
            else
            {
                var data = new signup()
                {
                    name = TextBox8.Text,
                    email = TextBox9.Text,
                    password = Password1.Value,
                    cpassword = Password2.Value
                };
                ls.signups.InsertOnSubmit(data);
                ls.SubmitChanges();

                string msg = "<script language=\"javascript\">";
                msg += "alert('" + "Signup Completed" + "');";
                msg += "</script>";
                Response.Write(msg);
            }


        }
        protected void login_Click(object sender, EventArgs e)
        {

            var email = from l in ls.signups select l.email;
            var password = from l in ls.signups select l.password;
            var username = from l in ls.signups where l.email == TextBox10.Text && l.password == Password3.Value select l;

            foreach (var un in username)
            {
                if (username.Any())
                {
                    Session["username"] = un.name;
                    Session["id"] = un.Id;
                    Session["role"] = "user";
                    string msg = "<script language=\"javascript\">";
                    msg += "alert('" + "login successful" + "');";
                    msg += "</script>";
                    Response.Write(msg);
                    Response.Redirect("WebForm1.aspx");
                }
            }
            if (!username.Any())
            {
                string msg2 = "<script language=\"javascript\">";
                msg2 += "alert('" + "Wrong email or password" + "');";
                msg2 += "</script>";
                Response.Write(msg2);
            }

        }
    }
}