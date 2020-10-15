using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class Groups : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["supervisorname"] == null)
            {
                Response.Redirect("SupervisorLogin.aspx");
            }
            else
            {
                var n = Session["supervisorname"].ToString();
                var i = Session["supervisorimage"].ToString();
                var E = Session["supervisoremail"].ToString();
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
                addgrps.Visible = false;
                addstudents.Visible = false;
                LoadData("select", "select Name,Value as Id from Defaults", DropDownList1);
                DropDownList1_SelectedIndexChanged(null, null);
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

        protected void BtnAddGroup_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("INSERT INTO Groups VALUES (@Name)", con);
            cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = grpname.Text.ToString();
            cmd.ExecuteNonQuery();

            string message = "Group Added Successfully";
            string message1 = "";
            string message2 = "success";

            string script = "swal('" + message + "','" + message1 + "','" + message2 + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
            LoadData("Select Group Name", "select Id,GroupName as Name from Groups", groupName);

        }

        [System.Web.Services.WebMethod]
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            if (IsStudentExistInThisGroup(stdname.SelectedValue, Convert.ToInt32(groupName.SelectedValue)))
            {
                string message = "Student is already added in this Group";
                string script = "alert('";
                script += message;
                script += "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Error Message", script, true);
            }
            else
            {
                if (IsGroupsLimitReached(email.Text))
                {
                    string message = "Groups limit reached";
                    string script = "alert('";
                    script += message;
                    script += "');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Error Message", script, true);
                }
                else
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("Update RegisterStudent set SupervisorID=@SupervisorID,GroupID = @GroupID where Enrollment = @Enrollment", con);
                    cmd.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = stdname.SelectedValue.ToString();
                    cmd.Parameters.AddWithValue("@GroupID", SqlDbType.VarChar).Value = groupName.SelectedValue.ToString();
                    cmd.Parameters.AddWithValue("@SupervisorID", SqlDbType.VarChar).Value = email.Text.ToString();
                    cmd.ExecuteNonQuery();

                    string message = "Student Added to Group successfully..";
                    string message1 = "";
                    string message2 = "success";

                    string script = "swal('" + message + "','" + message1 + "','" + message2 + "');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
                }
            }
        }

        private bool IsGroupsLimitReached(string spID)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select distinct(GroupID) from RegisterStudent where SupervisorID= @Id", con);
            da.SelectCommand.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = spID;
            da.Fill(dt);
            con.Close();
            if (dt != null)
            {
                if (dt.Rows.Count >= 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }


        private bool IsStudentExistInThisGroup(string Enrollment, int groupID)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select ISNULL(GroupID,0) from RegisterStudent where Enrollment = @Enrollment", con);
            cmd.Parameters.AddWithValue("@Enrollment", Enrollment);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                if (Convert.ToInt32(reader[0]) == groupID)
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
            else
            {
                con.Close();
                return false;
            }
        }


        protected void groupName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void stdname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Add New Group")
            {
                addgrps.Visible = true;
                addstudents.Visible = false;
                LoadData("Select Group Name", "select Id,GroupName as Name from Groups", groupName);

                groupName_SelectedIndexChanged(null, null);
            }
            else if (DropDownList1.SelectedValue == "Add Student to Group")
            {
                addgrps.Visible = false;
                addstudents.Visible = true;
                LoadData("Select Student Name", "select Enrollment as Id,Name from RegisterStudent", stdname);
            }
        }
    }
}