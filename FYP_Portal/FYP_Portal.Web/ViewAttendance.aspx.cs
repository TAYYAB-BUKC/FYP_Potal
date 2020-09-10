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
	public partial class ViewAttendance : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        private string Email;
        string i;
        string n;
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
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select RegisterStudent.Enrollment as enrollment, RegisterStudent.Name as name, Attendance.DateTime as marked, Attendance.Remarks as remarks, Attendance.Present as present, Attendance.Absent as absent from Attendance inner join RegisterStudent on RegisterStudent.Enrollment = Attendance.Enrollment where Attendance.Enrollment = '" + E + "'", con);
            da.Fill(dt);
            con.Close();

            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.FooterRow.Cells[3].Text = "Total: " + dt.Rows.Count;
            GridView1.FooterRow.Cells[4].Text = "Total Present: " + dt.Compute("sum(present)", "").ToString();
            GridView1.FooterRow.Cells[5].Text = "Total Absent: " + dt.Compute("sum(absent)", "").ToString();
        }

    }
}