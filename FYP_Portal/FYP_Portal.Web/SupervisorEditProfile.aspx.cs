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
	public partial class SupervisorEditProfile : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from RegisterSupervisor where Email = @Email", con);
            cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = E;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    uname.Text = reader.GetString(1);
                    Phone.Text = reader.GetString(5);
                    Designation.Text = reader.GetString(7);
                    depart.Text = reader.GetString(6);
                    uemail.Text = reader.GetString(4);
                    pemail.Text = reader.GetString(3);
                    Image1.ImageUrl = "~/SupervisorImages/" + reader.GetString(9);
                }
            }
        }

        protected void FileUpload1_PreRendr(object sender, EventArgs e)
        {
            Image1.ImageUrl = "~/images/gallery/6.jpg";
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string str = MyGuid.GetRandomPasswordForUpload() + FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/SupervisorImages/" + str));
                string file = str.ToString();

                if (E == pemail.Text)
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("UPDATE RegisterSupervisor SET [Phone] = @Phone,[ProfileImage] = @ProfileImage WHERE Email = @Email", con);

                    cmd.Parameters.AddWithValue("@ProfileImage", file);
                    cmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = Phone.Text.ToString();
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = pemail.Text.ToString();

                    cmd.ExecuteNonQuery();

                    Response.Redirect("SupervisorLogin.aspx");
                }
                else
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("UPDATE RegisterSupervisor SET [Phone] = @Phone,[ProfileImage] = @ProfileImage WHERE Email = @Email", con);

                    cmd.Parameters.AddWithValue("@ProfileImage", file);
                    cmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = Phone.Text.ToString();
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = pemail.Text.ToString();

                    cmd.ExecuteNonQuery();

                    Response.Redirect("SupervisorLogin.aspx");

                }
            }
            else
            {
                string file = Image1.ImageUrl.Substring(23);
                if (E == pemail.Text)
                {

                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("UPDATE RegisterSupervisor SET [Phone] = @Phone,[ProfileImage] = @ProfileImage WHERE Email = @Email", con);

                    cmd.Parameters.AddWithValue("@ProfileImage", file);
                    cmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = Phone.Text.ToString();
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = pemail.Text.ToString();
                    cmd.ExecuteNonQuery();

                    Response.Redirect("SupervisorLogin.aspx");

                }
                else
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("UPDATE RegisterSupervisor SET [Phone] = @Phone,[ProfileImage] = @ProfileImage WHERE Email = @Email", con);

                    cmd.Parameters.AddWithValue("@ProfileImage", file);
                    cmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = Phone.Text.ToString();
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = pemail.Text.ToString();
                    cmd.ExecuteNonQuery();

                    Response.Redirect("SupervisorLogin.aspx");

                }
            }
        }
    }
}