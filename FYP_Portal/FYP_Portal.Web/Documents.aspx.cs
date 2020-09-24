using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class Documents : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        bool check = false;
        string Enrollment;
        string image;
        string name;
        private List<DateTime> dateTime;
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

            if (!IsPostBack)
            {
                #region GridView Code
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select Id,[Document Title],Startdate,Enddate,Format,Format as SubmitFile from Documents ", con);
                da.Fill(dt);
                con.Close();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                DataTable dt1 = new DataTable();
                da = new SqlDataAdapter("select Enrollment,DocumentId,FileSubmit from AddSubmission where Enrollment=@Enrollment", con);
                da.SelectCommand.Parameters.AddWithValue("@Enrollment", SqlDbType.VarChar).Value = E;
                da.Fill(dt1);
                con.Close();

                if (dt1.Rows.Count > 0)
                {
                    List<string> files = new List<string>(dt.Rows.Count + 50);
                    List<int> Id = new List<int>(dt.Rows.Count + 50);

                    foreach (DataRow dr in dt1.Rows)
                    {
                        files.Add(dr["FileSubmit"].ToString());
                        Id.Add(Convert.ToInt32(dr["DocumentId"]));
                    }

                    for (int j = 0; j < files.Count; j++)
                    {
                        string searchExpression = "Id =" + Id[j];
                        DataRow[] foundRows = dt.Select(searchExpression);
                        foreach (DataRow dr in foundRows)
                        {
                            dr["SubmitFile"] = files[j];
                        }
                    }
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["SubmitFile"].ToString() == row["Format"].ToString())
                        {
                            row["SubmitFile"] = "Not Submitted";
                        }
                    }

                }
                else
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        row["SubmitFile"] = "Not Submitted";
                    }
                }

                GridView1.DataSource = dt;
                GridView1.DataBind();

                dateTime = new List<DateTime>(dt.Rows.Count);
                foreach (DataRow row in dt.Rows)
                {
                    dateTime.Add(Convert.ToDateTime(row["Enddate"]));
                }
                int counter = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (dateTime[counter] < DateTime.Now)
                    {
                        row.BackColor = Color.FromArgb(220, 186, 186);
                        if (row.Cells[5].Text == null)
                        {
                            row.Cells[5].Text = "Deadline Exceeded";
                        }
                    }
                    counter++;
                }
                #endregion

            }
        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Download")
            {
                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
                Response.TransmitFile(Server.MapPath("~/Uploads/" + e.CommandArgument));
                Response.End();
            }
            if (e.CommandName == "SDownload")
            {
                if (e.CommandArgument.ToString() == "Not Submitted")
                {

                }
                else
                {
                    Response.Clear();
                    Response.ContentType = "application/octect-stream";
                    Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
                    Response.TransmitFile(Server.MapPath("~/Submissions/" + e.CommandArgument));
                    Response.End();
                }
            }
        }

        protected void LnkUpload_Click(object sender, EventArgs e)
        {
            if (submitFile.Value != null)
            {
                string str = MyGuid.GetRandomPasswordForUpload() + submitFile.Value;
                submitFile.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + str));
                string file = str.ToString();

                DataTable dt = new DataTable();

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        protected void LnkDelete_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (GridView1.SelectedRow.BackColor == Color.FromArgb(220, 186, 186))
            {
                string message = "Deadline has been passed ";
                string script = "alert('";
                script += message;
                script += "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);

            }
            else
            {
                var docID = GridView1.DataKeys[GridView1.SelectedRow.RowIndex]["Id"].ToString();

                Session["documentId"] = docID;
                Session["documenttitle"] = GridView1.SelectedRow.Cells[2].Text;
                Response.Redirect("SubmitDocument.aspx");
            }

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;

            if (GridView1.Rows[GridView1.EditIndex].BackColor == Color.FromArgb(220, 186, 186))
            {
                string message = "Deadline has been passed ";
                string script = "alert('";
                script += message;
                script += "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
                GridView1.EditIndex = -1;

            }
            else
            {
                Session["documentId"] = GridView1.DataKeys[GridView1.EditIndex]["Id"].ToString();
                Response.Redirect("SubmitDocument.aspx");

            }
        }
    }
}