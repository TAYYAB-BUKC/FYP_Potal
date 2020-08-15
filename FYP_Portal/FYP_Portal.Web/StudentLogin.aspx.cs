using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
    public partial class StudentLogin : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");
        }

        protected void BtnStdLogin_Click1(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-G46F2K8\SQLEXPRESS;Initial Catalog=FYP PORTAL;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("select * from RegisterStudent where Enrollment = @Enrollment and Password = @Password and Institute = @Institute", con);

            cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = enroll.Text.ToString();
            cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = pwd.Text.ToString();
            cmd.Parameters.AddWithValue("@Institute", SqlDbType.VarChar).Value = inst.Text.ToString();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                string enroll = String.Empty;
                string image = String.Empty;
                string name = String.Empty;

                while (reader.Read())
                {
                    enroll = reader.GetString(0);
                    image = reader.GetString(11);
                    name = reader.GetString(1);
                }
                con.Close();
                Session["name"] = name;
                Session["image"] = "~/StudentImages/" + image;
                Session["enroll"] = enroll;
                Response.Redirect("StudentDashboard.aspx");
            }

            else
            {
                con.Close();
                string message = "Error!";
                string message1 = "Invalid credentials provided.";
                string message2 = "error";
                string script = "swal('" + message + "','" + message1 + "','" + message2 + "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);

            }

        }
    }
}

