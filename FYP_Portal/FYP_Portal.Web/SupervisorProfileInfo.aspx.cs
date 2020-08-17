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
	public partial class SupervisorProfileInfo : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
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

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select * from RegisterSupervisor where Email = @Email", con);
            cmd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = E;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    svname.InnerText = reader.GetString(1);
                    phone.InnerText = reader.GetString(5);
                    designation.InnerText = reader.GetString(7);
                    depart.InnerText = reader.GetString(6);
                    uemail.InnerText = reader.GetString(3);
                    pemail.InnerText = reader.GetString(4);

                }
            }

        }
    }
}