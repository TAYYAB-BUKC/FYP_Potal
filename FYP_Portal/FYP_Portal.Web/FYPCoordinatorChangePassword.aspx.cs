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
	public partial class FYPCoordinatorChangePassword : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        string E;
        string i;
        string n;

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
                email.Text = E;
                email.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;
                fname.InnerText = n;
                fname1.InnerText = n;
            }

        }

        protected void BtnUpdate_Click1(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("select Password from FYPCoordinatorLogin where PersonalEmail = @PersonalEmail", con);
            cmd.Parameters.AddWithValue("@PersonalEmail", SqlDbType.VarChar).Value = E;
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
                        cmd = new SqlCommand("Update FYPCoordinatorLogin set Password = @Password where PersonalEmail = @PersonalEmail", con);
                        cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = NewPassword.Text.ToString();
                        cmd.Parameters.AddWithValue("@PersonalEmail", SqlDbType.VarChar).Value = E;
                        cmd.ExecuteNonQuery();

                        Response.Redirect("FYPCoordinatorLogin.aspx");
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