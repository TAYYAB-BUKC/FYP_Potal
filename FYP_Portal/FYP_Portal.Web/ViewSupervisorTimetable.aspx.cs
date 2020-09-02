using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FYP_Portal.Web
{
	public partial class ViewSupervisorTimetable : System.Web.UI.Page
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

            string id = GetUniqueID(E);

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string query = "select Timetable.Timetable from Timetable where SupervisorID = '" + id + "'";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                string em = String.Empty;
                while (reader.Read())
                {
                    em = reader.GetString(0);
                }
                SPTimetable.Src = "~/Timetable/" + em;
            }
            else
            {
                Errors.InnerText = "Your Supervisor's Timetable is not been added yet";
            }

        }

        private string GetUniqueID(string enrollment)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select RegisterSupervisor.Email from RegisterStudent inner join RegisterSupervisor on RegisterStudent.SupervisorID = RegisterSupervisor.Email where RegisterStudent.Enrollment = @Enrollment", con);
            cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = enrollment;
            SqlDataReader reader = cmd.ExecuteReader();
            string em = "";

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    em = reader.GetString(0);
                }
                return em;
            }
            else
            {
                return em;
            }
        }

    }
}