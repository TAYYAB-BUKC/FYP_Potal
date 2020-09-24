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
	public partial class UpDelCLO : System.Web.UI.Page
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
                update.Visible = false;
                delete.Visible = false;
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
            }
            catch (Exception ex)
            {

            }
            return table;
        }

        protected void upclo_CheckedChanged(object sender, EventArgs e)
        {
            update.Visible = true;
            delete.Visible = false;

            LoadData("Select CLO", "select Id,Name from CLO order by CLONumber", updateclo, "Id", "Name");
            updateclo_SelectedIndexChanged(null, null);

        }

        protected void delclo_CheckedChanged(object sender, EventArgs e)
        {
            update.Visible = false;
            delete.Visible = true;

            LoadData("Select CLO", "select Id,Name from CLO order by CLONumber", deleteclo, "Id", "Name");
        }

        protected void updateclo_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from CLO where Id = @Id", con);

            cmd.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = updateclo.SelectedValue;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    Description.Value = reader.GetString(2);
                    outs.Value = reader.GetString(3);
                    good.Value = reader.GetString(5);
                    avg.Value = reader.GetString(4);
                    satisfactory.Value = reader.GetString(6);
                    poor.Value = reader.GetString(7);
                    fail.Value = reader.GetString(8);
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();

            cmd = new SqlCommand("Update CLO set Description=@Description,OutStanding=@OutStanding,Average=@Average,Good=@Good, Satisfactory=@Satisfactory, Poor=@Poor, Fail=@Fail where Id = @Id", con);

            cmd.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = Description.Value.ToString();
            cmd.Parameters.AddWithValue("@OutStanding", SqlDbType.VarChar).Value = outs.Value.ToString();
            cmd.Parameters.AddWithValue("@Good", SqlDbType.VarChar).Value = good.Value.ToString();
            cmd.Parameters.AddWithValue("@Average", SqlDbType.VarChar).Value = avg.Value.ToString();
            cmd.Parameters.AddWithValue("@Satisfactory", SqlDbType.VarChar).Value = satisfactory.Value.ToString();
            cmd.Parameters.AddWithValue("@Poor", SqlDbType.VarChar).Value = poor.Value.ToString();
            cmd.Parameters.AddWithValue("@Fail", SqlDbType.VarChar).Value = fail.Value.ToString();
            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Convert.ToInt32(updateclo.SelectedValue);

            cmd.ExecuteNonQuery();

            //string message = "Update CLO Successfully!";
            //string message1 = " ";
            //string message2 = "success";
            //string script = "swal('" + message + "','" + message1 + "','" + message2 + "');";
            //ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);

        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();

            cmd = new SqlCommand("Delete from CLO where Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = deleteclo.SelectedValue;
            cmd.ExecuteNonQuery();

            LoadData("Select CLO", "select Id,Name from CLO order by CLONumber", deleteclo, "Id", "Name");

            //string message = "Delete CLO Successfully!";
            //string message1 = " ";
            //string message2 = "success";
            //string script = "swal('" + message + "','" + message1 + "','" + message2 + "');";
            //ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
        }

    }
}