using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class StudentDashboard : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["name"] == null)
            {
                Response.Redirect("StudentLogin.aspx");
            }
            else
            {
                var n = Session["name"].ToString();
                var i = Session["image"].ToString();
                var E = Session["enroll"].ToString();
                enrollment.Text = E;
                enrollment.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;
                sname.InnerText = n;
                sname1.InnerText = n;
            }
        }
	}
}