using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FYP_Portal.Web
{
    public partial class FYPCoordinatorLogin : Page
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");
        }

        protected void BtnFypLogin_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from FYPCoordinatorLogin where PersonalEmail = @PersonalEmail and Password = @Password", con);

            cmd.Parameters.AddWithValue("@PersonalEmail", SqlDbType.VarChar).Value = pemail.Text.ToString();
            cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = pwd.Text.ToString();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                string email = String.Empty;
                string image = String.Empty;
                string name = String.Empty;

                while (reader.Read())
                {
                    email = reader.GetString(0);
                    image = reader.GetString(7);
                    name = reader.GetString(2);
                }
                con.Close();
                Session["fypname"] = name;
                Session["fypimage"] = "~/FYPCoordinatorImages/" + image;
                Session["fypemail"] = email;
                Response.Redirect("FYPCoordinatorDashboard.aspx");
            }

            else
            {
                string message = "Error!";
                string message1 = "Invalid credentials provided.";
                string message2 = "error";
                string script = "swal('" + message + "','" + message1 + "','" + message2 + "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);

            }

        }

    }
}
