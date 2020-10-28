using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Drawing;

public partial class Send_Order_Details : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (tbSName.Text != "" && tbSEmail.Text != "" && tbSubject.Text != "" && CKEditor1.Text != "")
        {
            //Send Email
            String ToEmailAddress = tbSEmail.Text;
            String Name = tbSName.Text;
            String EmailBody = Server.HtmlDecode(CKEditor1.Text);
            MailMessage Newsletter = new MailMessage(new MailAddress("postmaster@mirrorofbrands.com", "Support Team"), new MailAddress(ToEmailAddress, Name));
            Newsletter.Body = EmailBody;
            Newsletter.IsBodyHtml = true;
            Newsletter.Subject = tbSubject.Text;

            SmtpClient SMTP = new SmtpClient("mail.mirrorofbrands.com", 25);
            SMTP.Credentials = new NetworkCredential()
            {
                UserName = "postmaster@mirrorofbrands.com",
                Password = "Sa$12345"
            };
            SMTP.EnableSsl = true;
            SMTP.Send(Newsletter);

            lblSent.Text = "Order Details is Sent to User Successfully";
            lblSent.ForeColor = Color.Green;
        }
        else
        {
            lblSent.Text = "Mail Not Sent";
            lblSent.ForeColor = Color.Red;
        }
    }
}