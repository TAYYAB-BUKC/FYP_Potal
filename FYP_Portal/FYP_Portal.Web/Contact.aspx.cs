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
	public partial class Contact : Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");
        }

        protected void BtnContact_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-G46F2K8\SQLEXPRESS;Initial Catalog=FYP PORTAL;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("INSERT INTO Contact (Name, Email, Subject, Message) VALUES (@Name, @Email, @Subject, @Message)", con);

            cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = name.Text.ToString();
            cmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = email.Text.ToString();
            cmd.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = subject.Text.ToString();
            cmd.Parameters.AddWithValue("@Message", SqlDbType.NVarChar).Value = messages.Value.ToString();

            cmd.ExecuteNonQuery();
            string message = "Your details have been saved successfully!";
            string script = "alert('";
            script += message;
            script += "');";
            ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);

            name.Text = "";
            email.Text = "";
            subject.Text = "";
            messages.Value = "";

        }
    }
}