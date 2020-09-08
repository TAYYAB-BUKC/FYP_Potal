using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class Notifications : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        private string email;
        string i;
        string n;
        string E;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");

            if (Session["fypname"] == null)
            {
                Response.Redirect("FYPCoordinatorLogin.aspx");
            }
            else
            {
                n = Session["fypname"].ToString();
                i = Session["fypimage"].ToString();
                E = Session["fypemail"].ToString();
                em.Text = E;
                em.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;
                fname.InnerText = n;
                fname1.InnerText = n;
            }

        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("insert into Notifications(Message, Subject, DateTime, SentBy ) values(@Message, @Subject, @DateTime, @SentBy)", con);
            cmd.Parameters.AddWithValue("@Subject", subject.Text);
            cmd.Parameters.AddWithValue("@Message", messages.Value);
            cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@SentBy", em.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            string message = "Notifications Sent Successfully";
            string message1 = " ";
            string message2 = "success";
            string script = "swal('" + message + "','" + message1 + "','" + message2 + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
        }

    }
}