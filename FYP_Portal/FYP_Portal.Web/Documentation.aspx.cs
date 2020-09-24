using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace FYP_Portal.Web
{
	public partial class Documentation : System.Web.UI.Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        NetworkCredential logincredentials;
        SmtpClient client;
        MailMessage message;
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


        }

        protected void BtnUpload1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string str = MyGuid.GetRandomPasswordForUpload() + FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploads/" + str));
                string file = str.ToString();

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Documents values(@DocumentTitle, @Startdate, @Enddate, @Format)", con);
                cmd.Parameters.AddWithValue("@DocumentTitle", doctitle.Text);
                cmd.Parameters.AddWithValue("@Startdate", datepicker1.Value);
                cmd.Parameters.AddWithValue("@Enddate", datepicker2.Value);
                cmd.Parameters.AddWithValue("@Format", file);

                DataTable dt = new DataTable();
                cmd.ExecuteNonQuery();
                con.Close();
                SendEmail();
            }

            else
            {

            }
        }

        private void SendEmail()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();
            cmd = new SqlCommand("select Name,Email from RegisterStudent", con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                logincredentials = new NetworkCredential("misbahhussain679@gmail.com", "04AUG1997");
                string mail = reader.GetString(1);
                int Place = mail.LastIndexOf('@');
                string server = mail.Substring(Place + 1);

                if (server == "yahoo.com")
                {
                    client = new SmtpClient("smtp.yahoo.com") { Port = Convert.ToInt32("465") };
                }
                else
                {
                    client = new SmtpClient("smtp.gmail.com") { Port = Convert.ToInt32("587") };
                }
                client.EnableSsl = true;
                client.Credentials = logincredentials;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                message = new MailMessage { From = new MailAddress("misbahhussain679@gmail.com", "Misbah Hussain", Encoding.UTF8) };
                message.To.Add(new MailAddress(reader.GetString(1)));
                message.Subject = "New Document Uploaded";
                message.Body = "Dear <b>" + reader.GetString(0) + "</b>,<br>&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;New document added to your FYP Portal by the FYP Coordinator that is <b>" + doctitle.Text.ToString() + " </b>"
                + "<br>This is the Deadline for the submission of this document <b>" + datepicker2.Value + "</b> .If you still need any help please feel free to contact us via Email or by Portal.<b><br><br>Thanks & Regards,<br><br>Misbah Hussain";
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                string userEstate = "Sending...";
                client.SendAsync(message, userEstate);
            }

            con.Close();
        }
    }
}