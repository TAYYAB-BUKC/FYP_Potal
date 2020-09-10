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
	public partial class MarkAttendance : Page
	{
		SqlCommand cmd;
		SqlConnection con;
		SqlDataAdapter da;
		int gId;
		string gName;
		string n;
		string i;
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
                string grId = Request.QueryString["gId"];
                string dgId = Cryptography.GetDecryptedQueryString(grId);
                gId = Convert.ToInt32(dgId);
                gName = GetGroupName(gId);

                email.Text = E;
                email.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;
                spname.InnerText = n;
                spname1.InnerText = n;
            }
            //gId = Convert.ToInt32(Session["groupId"]);
            //gName = Session["groupName"].ToString();

            grpname.Text = "<b>" + gName + "</b>";

            if (!IsPostBack)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select Enrollment,Name,Department +' '+ Class Program from RegisterStudent where GroupID =" + gId, con);
                da.Fill(dt);
                con.Close();

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private string GetGroupName(int id)
        {
            string s = "";
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select GroupName from Groups where Id = @Id", con);

            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    s = reader.GetString(0);
                }
                return s;
            }
            else
            {
                return s;
            }
        }


        //private void LoadData(string title, string query, DropDownList grp)
        //{
        //    //try
        //    //{
        //    //    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //    //    con.Open();
        //    //     grp.Items.Clear();
        //    //     cmd = new SqlCommand(query, con);
        //    //     SqlDataReader reader = cmd.ExecuteReader();
        //    //     grp.Items.Add(title);
        //    //        while (reader.Read())
        //    //        {
        //    //        //grp.Items.Add(reader.GetString(0));
        //    //        grp.DataSource = new DataTable();
        //    //        }
        //    //        con.Close();

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //   // MessageBox.Show("Exception occurs: " + ex.Message);
        //    //}

        //    //DataTable table = GetData(query);
        //    //grp.DataSource = table;
        //    //grp.DataTextField = "Name";
        //    //grp.DataValueField = "Id";
        //    //grp.DataBind();

        //}

        //private DataTable GetData(string query)
        //{
        //    DataTable table = new DataTable();
        //    try
        //    {
        //        SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //        sql.Open();
        //        SqlCommand command = new SqlCommand(query, sql);
        //        SqlDataAdapter adapter = new SqlDataAdapter(command);

        //        adapter.Fill(table);
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return table;
        //}

        //protected void grp_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //    con.Open();
        //    DataTable dt = new DataTable();
        //    da = new SqlDataAdapter("select Enrollment,Name,Class as Program from RegisterStudent where GroupID ="+ grp.SelectedValue, con);
        //    da.Fill(dt);
        //    con.Close();

        //    GridView1.DataSource = dt;
        //    GridView1.DataBind();
        //}

        protected void Btn_save_Click(object sender, EventArgs e)
        {
            if (IsExist())
            {
                string message = "Attendance for these are already marked";
                string script = "alert('";
                script += message;
                script += "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Error Message", script, true);
            }
            else
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO Attendance (Name,Enrollment,GroupID, Present, Absent, SupervisorID, Datetime, Remarks) VALUES (@Name,@Enrollment,@GroupID, @Present, @Absent, @SupervisorID, @Datetime, @Remarks)", con);

                    cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = GridView1.Rows[i].Cells[0].Text.ToString();
                    cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = GridView1.Rows[i].Cells[1].Text.ToString();
                    RadioButton rbtn2 = (GridView1.Rows[i].Cells[3].FindControl("Absent") as RadioButton);
                    RadioButton rbtn1 = (GridView1.Rows[i].Cells[3].FindControl("Present") as RadioButton);
                    if (rbtn1.Checked)
                    {
                        cmd.Parameters.AddWithValue("@Present", SqlDbType.Int).Value = 1;
                        cmd.Parameters.AddWithValue("@Absent", SqlDbType.Int).Value = 0;

                    }
                    else if (rbtn2.Checked)
                    {

                        cmd.Parameters.AddWithValue("@Present", SqlDbType.Int).Value = 0;
                        cmd.Parameters.AddWithValue("@Absent", SqlDbType.Int).Value = 1;

                    }

                    cmd.Parameters.AddWithValue("@SupervisorID", SqlDbType.VarChar).Value = email.Text.ToString();
                    cmd.Parameters.AddWithValue("@Datetime", SqlDbType.DateTime).Value = DateTime.Now;
                    cmd.Parameters.AddWithValue("@Remarks", SqlDbType.VarChar).Value = Remarks.Value.ToString();
                    cmd.Parameters.AddWithValue("@GroupID", gId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool IsExist()
        {
            var endDate = DateTime.Now;
            var startDate = DateTime.Now.Date;

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from Attendance where GroupID =@GroupID and SupervisorID=@SupervisorID and Datetime between @StartDate and @EndDate", con);
            cmd.Parameters.AddWithValue("@SupervisorID", email.Text.ToString());
            cmd.Parameters.AddWithValue("@StartDate", startDate);
            cmd.Parameters.AddWithValue("@EndDate", endDate);
            cmd.Parameters.AddWithValue("@GroupID", gId);

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