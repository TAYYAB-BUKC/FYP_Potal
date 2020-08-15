using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class FYPCoordinatorDashboard : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["fypname"] == null)
            {
                Response.Redirect("FYPCoordinatorLogin.aspx");
            }
            else
            {
                var n = Session["fypname"].ToString();
                var i = Session["fypimage"].ToString();
                var E = Session["fypemail"].ToString();
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
	}
}