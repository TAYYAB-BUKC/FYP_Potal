using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace FYP_Portal.Web
{
	public partial class FYPCoordinatorEditProfile : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        string E;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fypname"] == null)
            {
                Response.Redirect("FYPCoordinatorLogin.aspx");
            }
            else
            {
                var n = Session["fypname"].ToString();
                var i = Session["fypimage"].ToString();
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

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from [FYPCoordinatorLogin] where PersonalEmail = @PersonalEmail", con);
            cmd.Parameters.AddWithValue("@PersonalEmail", SqlDbType.VarChar).Value = E;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Name.Text = reader.GetString(2);
                    Phone.Text = reader.GetString(3);
                    Designation.Text = reader.GetString(4);
                    depart.Text = reader.GetString(5);
                    uemail.Text = reader.GetString(6);
                    pemail.Text = reader.GetString(0);
                    Image1.ImageUrl = "~/FYPCoordinatorImages/" + reader.GetString(7);
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string str = MyGuid.GetRandomPasswordForUpload() + FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/FYPCoordinatorImages/" + str));
                string file = str.ToString();

                if (E == pemail.Text)
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("UPDATE FYPCoordinatorLogin SET [Name] = @Name,[Phone] = @Phone,[ProfileImage] = @ProfileImage WHERE PersonalEmail = @PersonalEmail", con);
                    cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = Name.Text.ToString();
                    cmd.Parameters.AddWithValue("@ProfileImage", file);
                    cmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = Phone.Text.ToString();
                    cmd.Parameters.AddWithValue("@PersonalEmail", SqlDbType.VarChar).Value = pemail.Text.ToString();

                    cmd.ExecuteNonQuery();

                    Response.Redirect("FYPCoordinatorLogin.aspx");
                }
                else
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("UPDATE FYPCoordinatorLogin SET [Name] = @Name,[Phone] = @Phone,[ProfileImage] = @ProfileImage WHERE PersonalEmail = @PersonalEmail", con);
                    cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = Name.Text.ToString();
                    cmd.Parameters.AddWithValue("@ProfileImage", file);
                    cmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = Phone.Text.ToString();
                    cmd.Parameters.AddWithValue("@PersonalEmail", SqlDbType.VarChar).Value = pemail.Text.ToString();

                    cmd.ExecuteNonQuery();
                    Response.Redirect("FYPCoordinatorLogin.aspx");
                }
            }
            else
            {
                string file = Image1.ImageUrl.Substring(23);
                if (E == pemail.Text)
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("UPDATE FYPCoordinatorLogin SET [Name] = @Name,[Phone] = @Phone,[ProfileImage] = @ProfileImage WHERE PersonalEmail = @PersonalEmail", con);

                    cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = Name.Text.ToString();
                    cmd.Parameters.AddWithValue("@ProfileImage", file);
                    cmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = Phone.Text.ToString();
                    cmd.Parameters.AddWithValue("@PersonalEmail", SqlDbType.VarChar).Value = pemail.Text.ToString();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("FYPCoordinatorLogin.aspx");
                }
                else
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("UPDATE FYPCoordinatorLogin SET [Name] = @Name,[Phone] = @Phone,[ProfileImage] = @ProfileImage WHERE PersonalEmail = @PersonalEmail", con);

                    cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = Name.Text.ToString();
                    cmd.Parameters.AddWithValue("@ProfileImage", file);
                    cmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = Phone.Text.ToString();
                    cmd.Parameters.AddWithValue("@PersonalEmail", SqlDbType.VarChar).Value = pemail.Text.ToString();
                    cmd.ExecuteNonQuery();
                    Response.Redirect("FYPCoordinatorLogin.aspx");
                }
            }
        }
    }
}