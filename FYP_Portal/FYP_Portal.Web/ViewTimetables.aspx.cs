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
	public partial class ViewTimetables : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        string i;
        string n;
        string E;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fypname"] == null)
            {
                Response.Redirect("FYPCoordinatorLogin.aspx");
            }
            else
            {
                n = Session["fypname"].ToString();
                i = Session["fypimage"].ToString();
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
                StudentsDiv.Visible = false;
                SuperDiv.Visible = false;

            }
        }

        private void LoadData(string title, string query, DropDownList grp, string id, string name)
        {
            DataTable table = GetData(query);
            grp.DataSource = table;
            grp.DataTextField = name;
            grp.DataValueField = id;
            grp.DataBind();

        }

        private DataTable GetData(string query)
        {
            DataTable table = new DataTable();
            try
            {
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                sql.Open();
                SqlCommand command = new SqlCommand(query, sql);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                sql.Close();
            }
            catch (Exception ex)
            {

            }
            return table;
        }

        protected void ViewStdTime_CheckedChanged(object sender, EventArgs e)
        {
            StudentsDiv.Visible = true;
            SuperDiv.Visible = false;

            LoadData("Select Student", "select distinct(Class) as class from RegisterStudent", students, "class", "class");
            students_SelectedIndexChanged(null, null);
        }

        protected void ViewSupTime_CheckedChanged(object sender, EventArgs e)
        {
            StudentsDiv.Visible = false;
            SuperDiv.Visible = true;

            LoadData("Select Supervisor", "select Email,Username from RegisterSupervisor", supervisors, "Email", "Username");
            supervisors_SelectedIndexChanged(null, null);
        }

        protected void students_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string query = "select Timetable from Timetable where StudentId = '" + students.SelectedValue + "'";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                string time = String.Empty;
                while (reader.Read())
                {
                    time = reader.GetString(0);
                }
                stdImage.Visible = true;
                stdImage.Src = "~/Timetable/" + time;
                StdError.Visible = false;

            }
            else
            {
                stdImage.Visible = false;
                StdError.Visible = true;
                StdError.InnerText = "No TimeTable found for this class";
            }
            con.Close();
            reader.Close();
        }

        protected void supervisors_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            string query = "select Timetable from Timetable where SupervisorId = '" + supervisors.SelectedValue + "'";
            cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                string time = String.Empty;
                while (reader.Read())
                {
                    time = reader.GetString(0);
                }
                supImage.Visible = true;

                supImage.Src = "~/Timetable/" + time;
                SupError.Visible = false;

            }
            else
            {
                supImage.Visible = false;
                SupError.Visible = true;
                SupError.InnerText = "No TimeTable found for this faculty";
            }
            con.Close();
            reader.Close();
        }

    }
}