using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace FYP_Portal.Web
{
	public partial class ViewStudentTimetable : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        string i;
        string n;
        string E;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorname"] == null)
            {
                Response.Redirect("SupervisorLogin.aspx");
            }
            else
            {
                n = Session["supervisorname"].ToString();
                i = Session["supervisorimage"].ToString();
                E = Session["supervisoremail"].ToString();
                em.Text = E;
                em.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;
                spname.InnerText = n;
                spname1.InnerText = n;
            }

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string query = "select distinct(RegisterStudent.Class),Timetable.Timetable from RegisterStudent inner join RegisterSupervisor on RegisterStudent.SupervisorID = RegisterSupervisor.Email inner join Timetable on RegisterStudent.Class = Timetable.StudentId where RegisterSupervisor.Email = '" + E + "'";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                string enroll = String.Empty;
                string em = String.Empty;
                while (reader.Read())
                {
                    em = reader.GetString(1);
                    enroll = reader.GetString(0);
                }
                if (em != null)
                {
                    image.Visible = true;
                    messageLabel.Visible = false;
                    image.Src = "~/Timetable/" + em;
                }
                else
                {
                    image.Visible = false;
                    messageLabel.Visible = true;
                    messageLabel.Text = "No record Found";
                    messageLabel.ForeColor = Color.Red;
                }

            }
            else
            {
                image.Visible = false;
                messageLabel.Visible = true;
                messageLabel.Text = "No record Found";
                messageLabel.ForeColor = Color.Red;
            }

        }

    }
}