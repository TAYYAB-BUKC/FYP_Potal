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

    public partial class StudentProfileInfo : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        string n;
        string i;
        string E;

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


            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from RegisterStudent inner join RegisterSupervisor on RegisterStudent.SupervisorID = RegisterSupervisor.Email inner join Groups on RegisterStudent.GroupID = Groups.Id where Enrollment = @Enrollment", con);
            cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = E;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    enroll.InnerText = reader.GetString(0);
                    stdname.InnerText = reader.GetString(1);
                    regnum.InnerText = reader.GetString(2);
                    fname.InnerText = reader.GetString(3);
                    inst.InnerText = reader.GetString(6);
                    class1.InnerText = reader.GetString(10);
                    mobnum.InnerText = reader.GetString(4);
                    pemail.InnerText = reader.GetString(5);
                    fyptitle.InnerText = reader.GetString(13);
                    supervisorname.InnerText = reader.GetString(15);
                }
            }
            reader.Close();
            con.Close();
        }
    }
}
