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
	public partial class UpDelPLO : System.Web.UI.Page
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

        protected void upplo_CheckedChanged(object sender, EventArgs e)
        {
            update.Visible = true;
            delete.Visible = false;

            LoadData("Select PLO", "select Id,Name from PLO order by PLONumber", updateplo, "Id", "Name");

        }

        protected void delplo_CheckedChanged(object sender, EventArgs e)
        {
            update.Visible = false;
            delete.Visible = true;

            LoadData("Select CLO", "select Id,Name from PLO order by PLONumber", deleteplo, "Id", "Name");

        }

        protected void updateplo_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from PLO where Id = @Id", con);

            cmd.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = updateplo.SelectedValue;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Description.Value = reader.GetString(2);
                }
            }
            con.Close();
            reader.Close();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("Update PLO set Description=@Description where Id = @Id", con);
            cmd.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = Description.Value.ToString();
            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = Convert.ToInt32(updateplo.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void Unnamed_Click1(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("Delete from PLO where Id = @Id", con);
            cmd.Parameters.AddWithValue("@Id", SqlDbType.VarChar).Value = deleteplo.SelectedValue;
            cmd.ExecuteNonQuery();
            LoadData("Select PLO", "select Id,Name from PLO order by PLONumber", deleteplo, "Id", "Name");
            con.Close();
        }

    }
}