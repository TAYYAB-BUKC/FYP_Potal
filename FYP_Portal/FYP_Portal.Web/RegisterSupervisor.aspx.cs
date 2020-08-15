using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
    public partial class RegisterSupervisor : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            //for empty textboxes color
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");
        }

        protected void BtnSvRegister_Click1(object sender, EventArgs e)
        {
            if (IsExist(pemail.Text.ToString()))
            {
                string message = "Supervisor Already Exist.";
                string script = "alert('";
                script += message;
                script += "');";
                // script += "window.location = '";
                //script += Request.Url.AbsoluteUri;
                //script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
            }
            else
            {
                if (ProfileImage.HasFile)
                {
                    string str = MyGuid.GetRandomPasswordForUpload() + ProfileImage.FileName;
                    ProfileImage.PostedFile.SaveAs(Server.MapPath("~/SupervisorImages/" + str));
                    // string file = "~/Uploads/" + str.ToString();                
                    string file = str.ToString();

                    con = new SqlConnection(@"Data Source=DESKTOP-G46F2K8\SQLEXPRESS;Initial Catalog=FYP PORTAL;Integrated Security=True");
                    con.Open();
                    //cmd = new SqlCommand("INSERT INTO RegisterSupervisor (Username, Password, Role, Institute) VALUES (@Username, @Password, @Role, @Institute)", con);
                    cmd = new SqlCommand("INSERT INTO RegisterSupervisor (Username, Name, Password, UniversityEmail, Email, Phone, Department, Designation, ProfileImage, Institute) VALUES (@Username, @Name, @Password, @UniversityEmail, @Email, @Phone, @Department, @Designation, @ProfileImage, @Institute)", con);

                    cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = uname.Text.ToString();
                    cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = sname.Text.ToString();
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = pwd.Text.ToString();
                    cmd.Parameters.AddWithValue("@UniversityEmail", SqlDbType.VarChar).Value = uemail.Text.ToString();
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = pemail.Text.ToString();
                    cmd.Parameters.AddWithValue("@ProfileImage", file);
                    cmd.Parameters.AddWithValue("@Department", SqlDbType.VarChar).Value = depart.Text.ToString();
                    cmd.Parameters.AddWithValue("@Designation", SqlDbType.VarChar).Value = designation.Text.ToString();
                    cmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = phnum.Text.ToString();
                    cmd.Parameters.AddWithValue("@Institute", SqlDbType.VarChar).Value = inst.Text.ToString();
                    cmd.ExecuteNonQuery();

                    uname.Text = "";
                    sname.Text = "";
                    pwd.Text = "";
                    uemail.Text = "";
                    pemail.Text = "";
                    depart.Text = "BSE";
                    designation.Text = "";
                    phnum.Text = "";
                    inst.Text = "Karachi Campus";

                }
                else
                {
                    string file = MyGuid.GetRandomPasswordForUpload() + "icon.png";
                    File.Copy(Server.MapPath("~/StudentImages/icon.png"), Server.MapPath("~/SupervisorImages/" + file));
                    con = new SqlConnection(@"Data Source=DESKTOP-G46F2K8\SQLEXPRESS;Initial Catalog=FYP PORTAL;Integrated Security=True");
                    con.Open();
                    //cmd = new SqlCommand("INSERT INTO RegisterSupervisor (Username, Password, Role, Institute) VALUES (@Username, @Password, @Role, @Institute)", con);
                    cmd = new SqlCommand("INSERT INTO RegisterSupervisor (Username, Name, Password, UniversityEmail, Email, Phone, Department, Designation, ProfileImage, Institute) VALUES (@Username, @Name, @Password, @UniversityEmail, @Email, @Phone, @Department, @Designation, @ProfileImage, @Institute)", con);

                    cmd.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = uname.Text.ToString();
                    cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = sname.Text.ToString();
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = pwd.Text.ToString();
                    cmd.Parameters.AddWithValue("@UniversityEmail", SqlDbType.VarChar).Value = uemail.Text.ToString();
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = pemail.Text.ToString();
                    cmd.Parameters.AddWithValue("@ProfileImage", file);
                    cmd.Parameters.AddWithValue("@Department", SqlDbType.VarChar).Value = depart.Text.ToString();
                    cmd.Parameters.AddWithValue("@Designation", SqlDbType.VarChar).Value = designation.Text.ToString();
                    cmd.Parameters.AddWithValue("@Phone", SqlDbType.VarChar).Value = phnum.Text.ToString();
                    cmd.Parameters.AddWithValue("@Institute", SqlDbType.VarChar).Value = inst.Text.ToString();
                    cmd.ExecuteNonQuery();


                    uname.Text = "";
                    sname.Text = "";
                    pwd.Text = "";
                    uemail.Text = "";
                    pemail.Text = "";
                    depart.Text = "BSE";
                    designation.Text = "";
                    phnum.Text = "";
                    inst.Text = "Karachi Campus";
                }
            }

        }

        public bool IsExist(string email)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-G46F2K8\SQLEXPRESS;Initial Catalog=FYP PORTAL;Integrated Security=True");
            con.Open();
            //cmd = new SqlCommand("INSERT INTO RegisterStudent (Enrollment, Password, Role, Institute) VALUES (@Enrollment, @Password, @Role, @Institute)", con);
            cmd = new SqlCommand("select * from RegisterSupervisor where Email=@Email", con);
            cmd.Parameters.AddWithValue("@Email", email);
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