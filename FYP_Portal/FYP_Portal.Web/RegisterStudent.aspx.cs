using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class RegisterStudent : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");
        }

        protected void BtnStdRegister_Click1(object sender, EventArgs e)
        {
            if (IsExist(enroll.Text.ToString()))
            {
                string message = "Student Already Exist.";
                string script = "alert('";
                script += message;
                script += "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
            }
            else
            {
                if (ProfileImage.HasFile)
                {
                    string str = MyGuid.GetRandomPasswordForUpload() + ProfileImage.FileName;
                    ProfileImage.PostedFile.SaveAs(Server.MapPath("~/StudentImages/" + str));
                    string file = str.ToString();

                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO RegisterStudent (Department,Enrollment, Name, Email, Class, ProfileImage, Password, Institute, FYPTitle, RegistrationNo, FatherName, MobileNo) VALUES (@Department, @Enrollment, @Name, @Email, @Class, @ProfileImage, @Password, @Institute, @FYPTitle, @RegistrationNo, @FatherName, @MobileNo)", con);
                    cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = enroll.Text.ToString();
                    cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = name.Text.ToString();
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = email.Text.ToString();
                    cmd.Parameters.AddWithValue("@Class", SqlDbType.VarChar).Value = class1.Text.ToString();
                    cmd.Parameters.AddWithValue("@ProfileImage", file);
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = pwd.Text.ToString();
                    cmd.Parameters.AddWithValue("@FYPTitle", SqlDbType.VarChar).Value = title.Text.ToString();
                    cmd.Parameters.AddWithValue("@Institute", SqlDbType.VarChar).Value = inst.Text.ToString();
                    cmd.Parameters.AddWithValue("@Department", SqlDbType.VarChar).Value = depart.Text.ToString();
                    cmd.Parameters.AddWithValue("@RegistrationNo", SqlDbType.VarChar).Value = registration.Text.ToString();
                    cmd.Parameters.AddWithValue("@FatherName", SqlDbType.VarChar).Value = fathername.Text.ToString();
                    cmd.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = mobile.Text.ToString();
                    cmd.ExecuteNonQuery();

                    enroll.Text = "";
                    name.Text = "";
                    pwd.Text = "";
                    class1.Text = "";
                    email.Text = "";
                    depart.Text = "BSE";
                    title.Text = "";
                    registration.Text = "";
                    inst.Text = "Karachi Campus";
                    fathername.Text = "";
                    mobile.Text = "";
                }
                else
                {

                    string file = MyGuid.GetRandomPasswordForUpload() + "icon.png";
                    File.Copy(Server.MapPath("~/StudentImages/icon.png"), Server.MapPath("~/StudentImages/" + file));

                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO RegisterStudent (Department,Enrollment, Name, Email, Class, ProfileImage, Password, Institute, FYPTitle, RegistrationNo, FatherName, MobileNo) VALUES (@Department, @Enrollment, @Name, @Email, @Class, @ProfileImage, @Password, @Institute, @FYPTitle, @RegistrationNo, @FatherName, @MobileNo)", con);
                    cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = enroll.Text.ToString();
                    cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = name.Text.ToString();
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = email.Text.ToString();
                    cmd.Parameters.AddWithValue("@Class", SqlDbType.VarChar).Value = class1.Text.ToString();
                    cmd.Parameters.AddWithValue("@ProfileImage", file);
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = pwd.Text.ToString();
                    cmd.Parameters.AddWithValue("@FYPTitle", SqlDbType.VarChar).Value = title.Text.ToString();
                    cmd.Parameters.AddWithValue("@Institute", SqlDbType.VarChar).Value = inst.Text.ToString();
                    cmd.Parameters.AddWithValue("@Department", SqlDbType.VarChar).Value = depart.Text.ToString();
                    cmd.Parameters.AddWithValue("@RegistrationNo", SqlDbType.VarChar).Value = registration.Text.ToString();
                    cmd.Parameters.AddWithValue("@FatherName", SqlDbType.VarChar).Value = fathername.Text.ToString();
                    cmd.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = mobile.Text.ToString();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public bool IsExist(string enroll)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from RegisterStudent where Enrollment=@Enrollment", con);
            cmd.Parameters.AddWithValue("@Enrollment", enroll);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
    }
}
