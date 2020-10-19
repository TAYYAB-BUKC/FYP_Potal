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
	public partial class SupervisorChangePassword : System.Web.UI.Page
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

            if (Session["supervisorname"] == null)
            {
                Response.Redirect("SupervisorLogin.aspx");
            }
            else
            {
                n = Session["supervisorname"].ToString();
                i = Session["supervisorimage"].ToString();
                E = Session["supervisoremail"].ToString();
                email.Text = E;
                email.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;
                spname.InnerText = n;
                spname1.InnerText = n;
            }
        }

        protected void BtnUpdate_Click1(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select Password from RegisterSupervisor where Email = @Email", con);
            cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = E;
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
                        cmd = new SqlCommand("Update RegisterSupervisor set Password = @Password where Email = @Email", con);

                        cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = NewPassword.Text.ToString();
                        cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = E;
                        cmd.ExecuteNonQuery();

                        Response.Redirect("SupervisorLogin.aspx");
                    }
                    else
                    {
                        string message = "New password and Confirm password doesn't Match";
                        string script = "alert('";
                        script += message;
                        script += "');";
                        ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);

                    }
                }
                else
                {
                    string message = "Old password is not Correct";
                    string script = "alert('";
                    script += message;
                    script += "');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
                }
            }
        }

    }
}