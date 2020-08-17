using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FYP_Portal.Web
{
    public partial class FYPCoordinatorProfileInfo : System.Web.UI.Page
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

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from [FYPCoordinatorLogin] where PersonalEmail = @PersonalEmail", con);
            cmd.Parameters.AddWithValue("@PersonalEmail", SqlDbType.VarChar).Value = E;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    fcname.InnerText = reader.GetString(2);
                    phone.InnerText = reader.GetString(3);
                    designation.InnerText = reader.GetString(4);
                    depart.InnerText = reader.GetString(5);
                    uemail.InnerText = reader.GetString(6);
                    pemail.InnerText = reader.GetString(0);
                }
            }
            con.Close();
            reader.Close();
        }
    }
}