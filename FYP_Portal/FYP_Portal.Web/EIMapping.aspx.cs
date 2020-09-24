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
	public partial class EIMapping : System.Web.UI.Page
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
                LoadData("Select CLO", "select Id,Name from CLO order by CLONumber", clo);
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


        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string parameter = EIParameters.SelectedItem.Text;
            if (parameter == "Mid Year Evaluation")
            {
                parameter = "Mid-year Evaluation";
            }

            if (IsExist(clo.SelectedItem.Text, parameter))
            {
                string message = "CLO PLO Mapping already exist.";
                string script = "alert('";
                script += message;
                script += "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);

            }
            else
            {
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("update EIMapping set [" + clo.SelectedItem.Text + "]=@Id where Name=@Name", con);
                cmd.Parameters.AddWithValue("@Id", 1);
                cmd.Parameters.AddWithValue("@Name", parameter);
                cmd.ExecuteNonQuery();

                string message = "Add PLO Successfully!";
                string message1 = " ";
                string message2 = "success";
                string script = "swal('" + message + "','" + message1 + "','" + message2 + "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);

            }
        }

        public bool IsExist(string clo, string paramater)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from EIMapping where '" + clo + "'= 1 and Name=@Name", con);
            cmd.Parameters.AddWithValue("@Name", paramater);

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