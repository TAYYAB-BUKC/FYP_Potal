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
	public partial class ViewSupervisorNotifications : Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        string i;
        string n;                                                           
        string E;

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

            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select Notifications.Subject as subject, Notifications.Message as message, FYPCoordinatorLogin.Name as sent from Notifications inner join FYPCoordinatorLogin on FYPCoordinatorLogin.PersonalEmail = Notifications.SentBy ", con);
            da.Fill(dt);
            con.Close();

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

    }
}