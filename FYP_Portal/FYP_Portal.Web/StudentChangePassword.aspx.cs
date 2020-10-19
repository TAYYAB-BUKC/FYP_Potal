using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class StudentChangePassword : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        string E;
        string n;
        string i;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");

            if (Session["name"] == null)
            {
                Response.Redirect("StudentLogin.aspx");
            }
            else
            {
                n = Session["name"].ToString();
                i = Session["image"].ToString();
                E = Session["enroll"].ToString();
                enrollment.Text = E;
                enrollment.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;
                sname.InnerText = n;
                sname1.InnerText = n;
            }

        }

        protected void BtnUpdate_Click1(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select Password from RegisterStudent where Enrollment = @Enrollment", con);
            cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = E;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                string em = String.Empty;
                while (reader.Read())
                {
                    em = reader.GetString(0);
                }

                if (em == OldPassword.Text)
                {
                    if (NewPassword.Text == ConPassword.Text)
                    {
                        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        con.Open();
                        cmd = new SqlCommand("Update RegisterStudent set Password = @Password where Enrollment = @Enrollment", con);
                        cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = NewPassword.Text.ToString();
                        cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = E;
                        cmd.ExecuteNonQuery();

                        Response.Redirect("StudentLogin.aspx");
                    }

                    else
                    {
                        string message = "new password and confirm password doesnot match";
                        string script = "alert('";
                        script += message;
                        script += "');";
                        ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
                    }
                }
                else
                {
                    string message = "old password is not correct";
                    string script = "alert('";
                    script += message;
                    script += "');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
                }
            }

        }

    }
}