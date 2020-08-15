using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class SupervisorDashboard : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["supervisorname"] == null)
            {
                Response.Redirect("SupervisorLogin.aspx");
            }
            else
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
            }
        }
	}
}