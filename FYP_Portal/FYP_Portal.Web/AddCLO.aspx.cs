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
	public partial class AddCLO : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        string i;
        string n;
        string E;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");

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
                if (Convert.ToInt32(CLOnumber.Value) > 0 && Convert.ToInt32(CLOnumber.Value) <= 11)
                {
                    if (IsExist(name.Text + CLOnumber.Value))
                    {
                        string message = "CLO Already Exist.";
                        string script = "alert('";
                        script += message;
                        script += "');";
                        ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);

                    }
                    else
                    {
                        con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                        con.Open();
                        cmd = new SqlCommand("INSERT INTO CLO (Name,Description,OutStanding, Good, Average, Satisfactory, Poor, Fail,CLONumber) VALUES (@Name,@Description,@OutStanding, @Good, @Average, @Satisfactory, @Poor, @Fail, @CLONumber)", con);
                        cmd.Parameters.AddWithValue("@Name", SqlDbType.VarChar).Value = name.Text + CLOnumber.Value;
                        cmd.Parameters.AddWithValue("@Description", SqlDbType.VarChar).Value = Description.Value.ToString();
                        cmd.Parameters.AddWithValue("@OutStanding", SqlDbType.VarChar).Value = outs.Value.ToString();
                        cmd.Parameters.AddWithValue("@Good", SqlDbType.VarChar).Value = good.Value.ToString();
                        cmd.Parameters.AddWithValue("@Average", SqlDbType.VarChar).Value = avg.Value.ToString();
                        cmd.Parameters.AddWithValue("@Satisfactory", SqlDbType.VarChar).Value = satisfactory.Value.ToString();
                        cmd.Parameters.AddWithValue("@Poor", SqlDbType.VarChar).Value = poor.Value.ToString();
                        cmd.Parameters.AddWithValue("@Fail", SqlDbType.VarChar).Value = fail.Value.ToString();
                        cmd.Parameters.AddWithValue("@CLONumber", SqlDbType.VarChar).Value = CLOnumber.Value.ToString();

                        cmd.ExecuteNonQuery();

                        string message = "Add CLO Successfully!";
                        string message1 = " ";
                        string message2 = "success";
                        string script = "swal('" + message + "','" + message1 + "','" + message2 + "');";
                        ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);


                    }

                }

                else
                {
                    string message = "CLO value must be from 1 to 12";
                    string script = "alert('";
                    script += message;
                    script += "');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
                }
                con.Close();
            }
            else
            {
                string message = "CLO Limit reached";
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
            cmd = new SqlCommand("select count(*) from CLO", con);
            int a = Convert.ToInt32(cmd.ExecuteScalar());
            return a;
        }
        public bool IsExist(string clo)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from CLO where Name=@clo", con);
            cmd.Parameters.AddWithValue("@clo", clo);

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