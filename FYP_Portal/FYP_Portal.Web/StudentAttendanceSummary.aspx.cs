using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class StudentAttendanceSummary : Page
	{
		SqlCommand cmd; 
		SqlConnection con;
		SqlDataAdapter da;
		int gId;
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
                email.Text = E;
                email.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;
                string grId = Request.QueryString["gId"];
                string dgId = Cryptography.GetDecryptedQueryString(grId);
                gId = Convert.ToInt32(dgId);

                spname.InnerText = n;
                spname1.InnerText = n;
            }


            if (!IsPostBack)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select Attendance.Enrollment as enrollment,Attendance.Name as name, sum(Attendance.Present) + sum(Attendance.Absent) as meetings ,sum(Attendance.Present) as present,sum(Attendance.Absent)  as absent from Attendance where Attendance.GroupID = " + gId + " group by Attendance.Name,Attendance.Enrollment", con);
                da.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    messageLabel.Visible = false;
                }
                else
                {
                    messageLabel.Visible = true;
                    messageLabel.Text = "No record Found";
                    messageLabel.ForeColor = Color.Red;
                }
            }
        }

        private void LoadData(string title, string query, DropDownList grp)
        {

            DataTable table = GetData(query);
            grp.DataSource = table;
            grp.DataTextField = "Name";
            grp.DataValueField = "Id";
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
            }
            catch (Exception)
            {
              
            }
            return table;
        }
    }
}