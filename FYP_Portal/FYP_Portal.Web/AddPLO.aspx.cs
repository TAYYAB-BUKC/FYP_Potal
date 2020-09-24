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
	public partial class AddPLO : System.Web.UI.Page
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

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (RowCount() <= 11)
            {
                if (IsExist(name.Text + PLOnumber.Value))
                {

                    string message = "PLO Already Exist.";
                    string script = "alert('";
                    script += message;
                    script += "');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);

                }
                else
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO PLO (Name, PLONumber, Description) VALUES (@Name, @PLONumber, @Description)", con);
                    cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = name.Text + PLOnumber.Value;
                    cmd.Parameters.AddWithValue("@PLONumber", SqlDbType.VarChar).Value = PLOnumber.Value.ToString();
                    cmd.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = Description.Value.ToString();
                    cmd.ExecuteNonQuery();
                }

            }
            else
            {
                string message = "PLO Limit reached";
                string script = "alert('";
                script += message;
                script += "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);

            }
        }

        public int RowCount()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select count(*) from PLO", con);
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return a;

        }

        public bool IsExist(string plo)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from PLO where Name=@plo", con);
            cmd.Parameters.AddWithValue("@plo", plo);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                con.Close();
                return true;
            }

            else
            {
                reader.Close();
                con.Close();
                return false;
            }

        }
    }
}