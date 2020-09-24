using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FYP_Portal.Web
{
	public partial class SubmitDocument : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        string i;
        string n;
        string E;
        string docID;
        string doctitle;

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
                docID = Session["documentId"].ToString();
                doctitle = GetTitle(docID);

                enrollment.Text = E;
                enrollment.Visible = false;
                profileImage.Src = i;
                p.Src = i;
                profileImage1.Src = i;
                p1.Src = i;
                sname.InnerText = n;
                sname1.InnerText = n;
            }

            docid.Text = docID;
            docid.Visible = false;
            docTitle.InnerText = doctitle;
        }

        private string GetTitle(string docID)
        {
            string title = "";
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select [Document Title] from Documents where Id = @Id", con);

            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = docID;

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    title = reader.GetString(0);
                }
            }
            return title;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string str = MyGuid.GetRandomPasswordForUpload() + FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Submissions/" + str));
                string file = str.ToString();

                con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into AddSubmission([Date/Time],[Enrollment],[FileSubmit],[DocumentId]) values(@Datetime, @Enrollment, @FileSubmit, @DocumentID)", con);
                cmd.Parameters.AddWithValue("@Datetime", DateTime.Now);
                cmd.Parameters.AddWithValue("@Enrollment", enrollment.Text);
                cmd.Parameters.AddWithValue("@FileSubmit", file);
                cmd.Parameters.AddWithValue("@DocumentID", docid.Text);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect("Documents.aspx");
            }

            else
            {
                string message = "Please select the File first.";
                string script = "alert('";
                script += message;
                script += "');";
                ClientScript.RegisterStartupScript(this.GetType(), "Success Message", script, true);
            }
        }

    }
}