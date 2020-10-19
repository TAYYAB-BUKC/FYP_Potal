using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYP_Portal.Web
{
	public partial class FYPCoordinatorForgotPassword : Page
	{
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter da;
        NetworkCredential logincredentials;
        SmtpClient client;
        MailMessage message;
        string passwordGenerator;
        string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");
        }

        protected void Btn_submit_Click1(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();

            cmd = new SqlCommand("select Name from FYPCoordinatorLogin where PersonalEmail=@PersonalEmail", con);

            cmd.Parameters.AddWithValue("@PersonalEmail", SqlDbType.VarChar).Value = pemail.Text.ToString();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                while (reader.Read())
                {
                    name = reader.GetString(0);
                }
                logincredentials = new NetworkCredential("misbahhussain679@gmail.com", "04AUG1997");
                client = new SmtpClient("smtp.gmail.com") { Port = Convert.ToInt32("587") };
                client.EnableSsl = true;
                client.Credentials = logincredentials;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                message = new MailMessage { From = new MailAddress("misbahhussain679@gmail.com", "Misbah Hussain", Encoding.UTF8) };
                message.To.Add(new MailAddress(pemail.Text.ToString()));
                passwordGenerator = MyGuid.GetRandomPassword();
                message.Subject = "Password Recovery Request";
                message.Body = "Dear <b>" + name + "</b>,<br>&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;We received your Forgot Password request and we Updated your password.So, now your new password is: <b>"
    + passwordGenerator + "</b>.<br>We hope this will rectify your issue.If you still need any help please feel free to contact us via this mail or on my number.<b><br><br>Thanks & Regards,<br><br>Misbah Hussain<br>Undergraduate Student of Department of Software Engineering<br>Bahria University - Karachi Campus<br>13 National Stadium Road, Karachi, Pakistan</b>";
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;
                message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.SendCompleted += new SendCompletedEventHandler(Custom_SendCompletedEventHandler);
                string userEstate = "Sending...";
                client.SendAsync(message, userEstate);

            }

            else
            {
                Console.WriteLine("No Account Found with this Email. Please enter the correct registered Email.");
            }
            con.Close();
            reader.Close();
        }

        private void Custom_SendCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {

            }
            if (e.Error != null)
            {
                Console.WriteLine(e.Error);
            }
            else
            {
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                sql.Open();
                SqlCommand cmd = new SqlCommand("update FYPCoordinatorLogin set Password=@Password where PersonalEmail=@PersonalEmail", sql);
                cmd.Parameters.AddWithValue("@PersonalEmail", SqlDbType.VarChar).Value = pemail.Text.ToString();
                cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = passwordGenerator;
                cmd.ExecuteNonQuery();
                pemail.Text = "";
                sql.Close();
            }
        }

    }
}