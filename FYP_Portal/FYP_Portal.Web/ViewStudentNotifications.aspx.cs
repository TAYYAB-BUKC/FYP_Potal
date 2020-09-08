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
	public partial class ViewStudentNotifications : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        string n;
        string i;
        string E;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("StudentLogin.aspx");
            }
            else
            {
                n = Session["name"].ToString();
                i = Session["image"].ToString();
                E = Session["enroll"].ToString();
                enrollment.Text = E;
                enrollment.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;

                sname.InnerText = n;
                sname1.InnerText = n;
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