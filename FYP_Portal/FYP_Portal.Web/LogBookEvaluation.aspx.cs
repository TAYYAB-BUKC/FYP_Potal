using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace FYP_Portal.Web
{
    public partial class LogBookEvaluation : Page
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        private List<DataRow> toBeRemovedCLOs = new List<DataRow>(20);
        private List<DataRow> toBeRemovedGroups = new List<DataRow>(20);
        private List<int> groupsToBeShown = new List<int>(20);
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string E;
        string i;
        string n;

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
                spname.InnerText = n;
                spname1.InnerText = n;
            }

            if (!IsPostBack)
            {
                LoadData("Select Group Name", "select Id,GroupName as Name from Groups", groupNumber);
                groupNumber_SelectedIndexChanged(null, null);
                studentName_SelectedIndexChanged(null, null);
                PopulateGridview();
                controls.Visible = false;
            }
        }

        private void FetchGroups(string spID)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("select distinct(GroupID) from RegisterStudent where SupervisorID= @Id", con);

            cmd.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = spID;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    groupsToBeShown.Add(reader.GetInt32(0));
                }
            }
        }

        private void PopulateGridview()
        {
            con = new SqlConnection(connectionString);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select Id,Name as perind,OutStanding as outs,Good as good, Average as avg, Satisfactory as satis,Poor as poor,Fail as fail from CLO order by CLONumber", con);
            da.Fill(dt);
            con.Close();

            foreach (DataRow row in dt.Rows)
            {
                if (row["perind"].ToString() == "CLO 9" || row["perind"].ToString() == "CLO 11")
                {

                }
                else
                {
                    toBeRemovedCLOs.Add(row);
                }
            }

            foreach (var row in toBeRemovedCLOs)
            {
                dt.Rows.Remove(row);
            }
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    controls.Visible = true;
                    MessageLabel.Visible = false;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    GridView1.FooterRow.Cells[5].Text = "Total (10 Marks)";
                    //GridView1.Visible = false;
                }
                else
                {
                    controls.Visible = false;
                    MessageLabel.Visible = true;
                    MessageLabel.Text = "CLO(s) are not added yet for Assessment";
                    MessageLabel.ForeColor = Color.Red;
                }
            }
        }

        private void LoadData(string title, string query, DropDownList grp)
        {
            DataTable table = GetData(query);
            //foreach (DataRow row in table.Rows)
            //{
            //    int a = Convert.ToInt32(row["Id"]);
            //    bool check = groupsToBeShown.Contains(a);
            //    if (!check)
            //    {
            //        toBeRemovedGroups.Add(row);
            //    }
            //}
            //foreach (var row in toBeRemovedGroups)
            //{
            //    table.Rows.Remove(row);
            //}

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
                SqlConnection sql = new SqlConnection(connectionString);
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

        protected void studentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("select FYPTitle from RegisterStudent where Enrollment = @Enrollment", con);
            cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = studentName.SelectedValue;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    fyptitle.Text = reader.GetString(0);
                }
            }
            populateMarks();

        }

        private void populateMarks()
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                var rowIndex = row.RowIndex;

                var cloID = GridView1.DataKeys[row.RowIndex]["Id"].ToString();

                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand("select isNull(Marks,0) from LogBookMarks where Group_Id = @Group_Id and CLO_Id = @CLO_Id and Supervisor_Id = @Supervisor_Id and MarksFor=@MarksFor", con);
                cmd.Parameters.AddWithValue("@Group_Id ", SqlDbType.VarChar).Value = groupNumber.SelectedValue;
                cmd.Parameters.AddWithValue("@Supervisor_Id", SqlDbType.VarChar).Value = E;
                cmd.Parameters.AddWithValue("@CLO_Id", SqlDbType.VarChar).Value = cloID;
                cmd.Parameters.AddWithValue("@MarksFor", SqlDbType.VarChar).Value = reports.SelectedItem.ToString();

                SqlDataReader reader1 = cmd.ExecuteReader();
                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        row.Cells[8].Text = reader1.GetDecimal(0).ToString();
                    }
                }
            }
        }

        protected void Btn_save_Click(object sender, EventArgs e)
        {
            bool valid = false;
            foreach (GridViewRow row in GridView1.Rows)
            {
                var rowIndex = row.RowIndex;
                string value = (row.FindControl("marks") as TextBox).Text;
                if (Convert.ToInt32(value) > -1 && Convert.ToInt32(value) < 6)
                {
                    valid = true;
                }
            }

            foreach (GridViewRow row in GridView1.Rows)
            {
                var docID = GridView1.DataKeys[row.RowIndex]["Id"].ToString();

                if (Convert.ToInt32(row.Cells[5].Text) > -1 && Convert.ToInt32(row.Cells[5].Text) < 6)
                {
                    valid = true;
                }
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            PopulateGridview();
            populateMarks();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            PopulateGridview();
            populateMarks();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var cloID = GridView1.DataKeys[e.RowIndex]["Id"].ToString();
            if (IsMarksExist(Convert.ToInt32(cloID)))
            {
                string message = "Marks of this clo already exist";
                string script = "alert('";
                script += message;
                script += "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Error Message", script, true);
                GridView1_RowCancelingEdit(null, null);
            }
            else
            {
                string value = (GridView1.Rows[e.RowIndex].FindControl("marks") as TextBox).Text;
                if (Convert.ToDecimal(value) >= 0 && Convert.ToDecimal(value) <= 5)
                {
                    con = new SqlConnection(connectionString);
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO LogBookMarks (Group_Id,CLO_Id,Marks,Supervisor_Id,MarksFor) VALUES (@Group_Id,@CLO_Id,@Marks,@Supervisor_Id,@MarksFor)", con);

                    cmd.Parameters.AddWithValue("@Group_Id", SqlDbType.Int).Value = groupNumber.SelectedValue;
                    cmd.Parameters.AddWithValue("@CLO_Id", SqlDbType.VarChar).Value = cloID;
                    cmd.Parameters.AddWithValue("@Marks", Convert.ToDecimal(value));
                    cmd.Parameters.AddWithValue("@Supervisor_Id", SqlDbType.VarChar).Value = E;
                    cmd.Parameters.AddWithValue("@MarksFor", reports.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();
                    GridView1_RowCancelingEdit(null, null);
                    populateMarks();
                }
                else
                {
                    string message = "please marks should be from 0 to 5";
                    string script = "alert('";
                    script += message;
                    script += "');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
                }
            }
        }

        private bool IsMarksExist(int cloID)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("select '#' from LogBookMarks where Group_Id  = @Group_Id  and CLO_Id = @CLO_Id and Supervisor_Id = @Supervisor_Id and MarksFor=@MarksFor", con);
            cmd.Parameters.AddWithValue("@Group_Id", SqlDbType.Int).Value = groupNumber.SelectedValue;
            cmd.Parameters.AddWithValue("@CLO_Id", SqlDbType.VarChar).Value = cloID;
            cmd.Parameters.AddWithValue("@Supervisor_Id", SqlDbType.VarChar).Value = E;
            cmd.Parameters.AddWithValue("@MarksFor", SqlDbType.VarChar).Value = reports.SelectedItem.ToString();
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void Unnamed_Click1(object sender, ImageClickEventArgs e)
        {

        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }

        protected void groupNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("select Enrollment as Id,Name from RegisterStudent where GroupID = @GroupID", con);
            cmd.Parameters.AddWithValue("@GroupID", SqlDbType.VarChar).Value = groupNumber.SelectedValue;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();

            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                studentName.DataSource = table;
                studentName.DataTextField = "Name";
                studentName.DataValueField = "Id";
                studentName.DataBind();
                studentName_SelectedIndexChanged(null, null);
            }
        }

        protected void reports_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (reports.SelectedIndex == 0)
            {
                controls.Visible = false;
                return;
            }
            controls.Visible = true;
        }
    }
}