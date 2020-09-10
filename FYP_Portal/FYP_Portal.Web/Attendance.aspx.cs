using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace FYP_Portal.Web
{
	public partial class Attendance : Page
	{
		SqlCommand cmd;
		SqlConnection con;
		SqlDataAdapter da;
		string n;
		string i;
		string E;

        protected void Page_Load(object sender, EventArgs e)
        {
			//if (Session["supervisorname"] == null)
			//{
			//    Response.Redirect("SupervisorLogin.aspx");
			//}
			//else
			//{
			//    n = Session["supervisorname"].ToString();
			//    i = Session["supervisorimage"].ToString();
			//    E = Session["supervisoremail"].ToString();
			//    email.Text = E;
			//    email.Visible = false;
			//    profileImage.Src = i;
			//    p.Src = i;
			//    profileImage1.Src = i;
			//    p1.Src = i;
			//    spname.InnerText = n;
			//    spname1.InnerText = n;
			//}

			n = "Misbah Hussain";
			i = "~/SupervisorImages/rxvydiicon.png";
			E = "misbahhussain679@gmail.com";
			email.Text = E;
			email.Visible = false;
			profileImage.Src = i;
			p.Src = i;
			profileImage1.Src = i;
			p1.Src = i;
			spname.InnerText = n;
			spname1.InnerText = n;


			if (!IsPostBack)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select Groups.Id,Groups.GroupName as Titles from Groups inner join RegisterStudent on RegisterStudent.GroupID = Groups.Id inner join RegisterSupervisor on RegisterSupervisor.Email = RegisterStudent.SupervisorID where RegisterStudent.SupervisorID = '" + email.Text + "'", con);
                da.Fill(dt);
                dt = RemoveDuplicateRows(dt, "Id");
                con.Close();
                var totalRows = dt.Rows.Count;
                if (totalRows == 1)
                {
                    action2.Visible = false;
                    action3.Visible = false;
                }
                else if (totalRows == 2)
                {
                    action3.Visible = false;
                }

                var counter = 0;
                foreach (DataRow row in dt.Rows)
                {
                    counter++;
                    if (counter <= totalRows)
                    {
                        if (counter == 1)
                        {
                            grp1.Text = Convert.ToString(row["Id"]);
                            grpname1.Text = row["Titles"].ToString();
                            MA1.HRef = MA1.HRef + "?gId=" + Cryptography.GetEncryptedQueryString(grp1.Text);
                            AT1.HRef = AT1.HRef + "?gId=" + Cryptography.GetEncryptedQueryString(grp1.Text);
                            DA1.HRef = DA1.HRef + "?gId=" + Cryptography.GetEncryptedQueryString(grp1.Text);
                        }
                        else if (counter == 2)
                        {
                            grp2.Text = Convert.ToString(row["Id"]);
                            grpname2.Text = row["Titles"].ToString();
                            MA2.HRef = MA2.HRef + "?gId=" + Cryptography.GetEncryptedQueryString(grp2.Text);
                            AT2.HRef = AT2.HRef + "?gId=" + Cryptography.GetEncryptedQueryString(grp2.Text);
                            DA2.HRef = DA2.HRef + "?gId=" + Cryptography.GetEncryptedQueryString(grp2.Text);
                        }
                        else if (counter == 3)
                        {
                            grp3.Text = Convert.ToString(row["Id"]);
                            grpname3.Text = row["Titles"].ToString();
                            MA3.HRef = MA3.HRef + "?gId=" + Cryptography.GetEncryptedQueryString(grp3.Text);
                            AT3.HRef = AT3.HRef + "?gId=" + Cryptography.GetEncryptedQueryString(grp3.Text);
                            DA3.HRef = DA3.HRef + "?gId=" + Cryptography.GetEncryptedQueryString(grp3.Text);

                        }
                    }
                }
            }
        }

        public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
        {
            Hashtable hTable = new Hashtable();
            ArrayList duplicateList = new ArrayList();

            foreach (DataRow drow in dTable.Rows)
            {
                if (hTable.Contains(drow[colName]))
                    duplicateList.Add(drow);
                else
                    hTable.Add(drow[colName], string.Empty);
            }

            foreach (DataRow dRow in duplicateList)
                dTable.Rows.Remove(dRow);

            return dTable;
        }
    }
}