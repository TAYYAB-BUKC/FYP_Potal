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
    public partial class StudentEditProfile : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        string E;
        string i;
        string n;

        protected void Page_Load(object sender, EventArgs e)
        {
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

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand(" select * from RegisterStudent where Enrollment = @Enrollment", con);

            cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = E;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Name.Text = reader.GetString(1);
                    Phone.Text = reader.GetString(4);
                    class1.Text = reader.GetString(10);
                    depart.Text = reader.GetString(12);
                    inst.Text = reader.GetString(6);
                    pemail.Text = reader.GetString(5);
                    Image1.ImageUrl = "~/StudentImages/" + reader.GetString(11);
                }
                reader.Close();
                con.Close();
            }
			else
			{
                reader.Close();
                con.Close();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string str = MyGuid.GetRandomPasswordForUpload() + FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/StudentImages/" + str));
                string file = str.ToString();
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("UPDATE RegisterStudent SET [Email]=@Email,[Name] = @Name,[MobileNo] = @Phone,[ProfileImage] = @ProfileImage WHERE Enrollment = @Enrollment", con);
                cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = Name.Text.ToString();
                cmd.Parameters.AddWithValue("@ProfileImage", file);
                cmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = Phone.Text.ToString();
                cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = pemail.Text.ToString();
                cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = enrollment.Text.ToString();
                cmd.ExecuteNonQuery();
                Response.Redirect("StudentLogin.aspx");
            }
            else
            {
                string file = Image1.ImageUrl.Substring(16);
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("UPDATE RegisterStudent SET [Email]=@Email,[Name] = @Name,[MobileNo] = @Phone,[ProfileImage] = @ProfileImage WHERE Enrollment = @Enrollment", con);
                cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = Name.Text.ToString();
                cmd.Parameters.AddWithValue("@ProfileImage", file);
                cmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = Phone.Text.ToString();
                cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = pemail.Text.ToString();
                cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = enrollment.Text.ToString();
                cmd.ExecuteNonQuery();
                Response.Redirect("StudentLogin.aspx");
            }
        }
    }
}
