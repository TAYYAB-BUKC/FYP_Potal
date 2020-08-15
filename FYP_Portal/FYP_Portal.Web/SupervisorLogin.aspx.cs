using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace FYP_Portal.Web
{
    public partial class SupervisorLogin : Page
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");
        }

        protected void BtnSvLogin_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from RegisterSupervisor where Username = @Username and Password = @Password and Institute = @Institute", con);

            cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = uname.Text.ToString();
            cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = pwd.Text.ToString();
            cmd.Parameters.AddWithValue("@Institute", SqlDbType.VarChar).Value = inst.Text.ToString();

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                string email = String.Empty;
                string image = String.Empty;
                string name = String.Empty;

                while (reader.Read())
                {
                    email = reader.GetString(3);
                    image = reader.GetString(9);
                    name = reader.GetString(1);
                }

                con.Close();
                Session["supervisorname"] = name;
                Session["supervisorimage"] = "~/SupervisorImages/" + image;
                Session["supervisoremail"] = email;
                Response.Redirect("SupervisorDashboard.aspx");
            }

            else
            {
                string message = "Error!";
                string message1 = "Invalid credentials provided.";
                string message2 = "error";
                string script = "swal('" + message + "','" + message1 + "','" + message2 + "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
                con.Close();
            }

        }
    }
}