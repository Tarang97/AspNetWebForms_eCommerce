using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Net;

public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btPassRec_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email = '" + tbEmailId.Text + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                String myGUID = Guid.NewGuid().ToString();
                int Uid = Convert.ToInt32(dt.Rows[0][0]);
                SqlCommand cmd1 = new SqlCommand("INSERT INTO ForgotPassRequests VALUES('" + myGUID + "','" + Uid + "',getdate())", con);
                cmd1.ExecuteNonQuery();

                //Send Email
                String ToEmailAddress = dt.Rows[0][2].ToString();
                String Name = dt.Rows[0][1].ToString();
                String EmailBody = "Hi " + Name + ",<br/><br/> Click the link below to reset your password <br/><br/> http://www.mirrorofbrands.com/RecoverPassword.aspx?Uid=" + myGUID;
                MailMessage PassRecMail = new MailMessage(new MailAddress("support@mirrorofbrands.com", "Support Team"), new MailAddress(ToEmailAddress, Name));
                PassRecMail.Body = EmailBody;
                PassRecMail.IsBodyHtml = true;
                PassRecMail.Subject = "Reset Password";

                SmtpClient SMTP = new SmtpClient("mail.mirrorofbrands.com", 25);
                SMTP.Credentials = new NetworkCredential()
                {
                    UserName = "support@mirrorofbrands.com",
                    Password = "vaibhav@1308"
                };
                SMTP.EnableSsl = false;
                SMTP.Send(PassRecMail);

                lblPassRec.Text = "Check your email or spam box for instructions to reset your password";
                lblPassRec.ForeColor = Color.Green;
            }
            else
            {
                lblPassRec.Text = "Oops, This Email Id does not exist!";
                lblPassRec.ForeColor = Color.Red;
            }
        }
    }
}