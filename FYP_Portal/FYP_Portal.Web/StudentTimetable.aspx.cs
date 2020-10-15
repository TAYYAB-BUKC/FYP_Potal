using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FYP_Portal.Web
{
	public partial class StudentTimetable : System.Web.UI.Page
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

            LoadData("Select Student", "select distinct(Class) as class from RegisterStudent", students, "class", "class");
        }

        private void LoadData(string title, string query, DropDownList grp, string id, string name)
        {
            DataTable table = GetData(query);
            grp.DataSource = table;
            grp.DataTextField = name;
            grp.DataValueField = name;
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

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                if (students.SelectedValue != string.Empty)
                {
                    if (IsExist(students.SelectedValue))
                    {
                        string message = "Timetable for this class already exist.";
                        string script = "alert('";
                        script += message;
                        script += "');";
                        ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
                    }
                    else
                    {
                        string str = MyGuid.GetRandomPasswordForUpload() + FileUpload1.FileName;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Timetable/" + str));
                        string file = str.ToString();
                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into [Timetable] (StudentId, Timetable) values (@StudentId, @Timetable)", con);
                        cmd.Parameters.AddWithValue("@StudentId", students.Text);
                        cmd.Parameters.AddWithValue("@Timetable", file);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else
                {
                    string message = "Please select Student first";
                    string script = "alert('";
                    script += message;
                    script += "');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Error Message", script, true);
                }
            }
            else
            {
                string message = "Please select the Timetable first";
                string script = "alert('";
                script += message;
                script += "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Error Message", script, true);
            }
        }
        public bool IsExist(string id)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select '#' from Timetable where StudentId=@Id", con);
            cmd.Parameters.AddWithValue("@Id", id);
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