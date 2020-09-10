using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class GroupsAttendanceSummary : System.Web.UI.Page
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

            messageLabel.Visible = false;

            if (!IsPostBack)
            {
                LoadData("Select Group Name", "select Id,GroupName as Name from Groups order by GroupName", groups);
                groups_SelectedIndexChanged(null, null);
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
            catch (Exception ex)
            {

            }
            return table;
        }

        protected void groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select Attendance.Enrollment as enrollment,Attendance.Name as name, sum(Attendance.Present) + sum(Attendance.Absent) as meetings,sum(Attendance.Present) as present1,Attendance.Name as present,sum(Attendance.Absent)  as absent from Attendance where Attendance.GroupID = " + groups.SelectedValue + " group by Attendance.Name,Attendance.Enrollment", con);
            da.Fill(dt);
            con.Close();

            foreach (DataRow row in dt.Rows)
            {
                int actualValue = Convert.ToInt32(row["present1"]);
                int total = Convert.ToInt32(row["meetings"]);
                decimal percent = (actualValue * 100) / total;
                row["present"] = "" + actualValue + "\t\t(" + Math.Round(percent, 2).ToString() + "%)";
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();

            if (dt.Rows.Count > 0)
            {
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
}