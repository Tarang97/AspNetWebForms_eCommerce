using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Data;
using System.Net.Mail;
using System.Net;

public partial class Signup : System.Web.UI.Page
{
    static String activationcode; 
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btSignup_Click(object sender, EventArgs e)
    {
        Random random = new Random();
        activationcode = random.Next(100000, 200000000).ToString();

        if(checkemail() == true)
        {
            lblError.Text = "Your Email Already Registered with Us";
        }
        else if(checkmobile() == true)
        {
            lblError.Text = "Your Mobile Number Already Registered with us";
        }
        else
        {
            if (tbName.Text != "" && tbEmail.Text != "" && tbPass.Text != "" && tbCPass.Text != "" && txtMobileNo.Text != "")
            {
                // Hash First Password Field
                byte[] hs1 = new byte[50];
                string pass = tbPass.Text;
                SHA1 sh = SHA1.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
                byte[] hash = sh.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    hs1[i] = hash[i];
                    sb.Append(hs1[i].ToString("x2"));
                }
                var hash_pass = sb.ToString();

                // Hash Second Password Field
                byte[] hs2 = new byte[50];
                string pass2 = tbCPass.Text;
                SHA1 sh2 = SHA1.Create();
                byte[] inputBytes2 = System.Text.Encoding.ASCII.GetBytes(pass2);
                byte[] hash2 = sh2.ComputeHash(inputBytes2);
                StringBuilder sb2 = new StringBuilder();
                for (int i = 0; i < hash2.Length; i++)
                {
                    hs2[i] = hash2[i];
                    sb2.Append(hs2[i].ToString("x2"));
                }
                var hash_pass2 = sb2.ToString();

                if (hash_pass == hash_pass2)
                {
                    String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Users VALUES('" + tbName.Text + "','" + tbEmail.Text + "','" + hash_pass + "', 'U','" + txtMobileNo.Text + "', 'Unverified', '"+activationcode+"')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        sendcode();
                        Response.Redirect("~/ActivateAccount.aspx?email=" +tbEmail.Text);

                    }
                }
                else
                {
                    lblMsg.Text = "Password does not match";
                    lblMsg.ForeColor = Color.Red;
                }
            }
            else
            {
                lblMsg.Text = "All Fields are Mandatory";
                lblMsg.ForeColor = Color.Red;
            }
        }
    }

    private void sendcode()
    {
        String EmailAddress = tbEmail.Text;
        String Name = tbName.Text;
        String EmailBody = "Hi " + Name + ",<br/><br/>Welcome to Mirror of Brands. You are one step away to join with us.<br/><br/> Please find the Activation Code below to activate your Account '"+activationcode+ "'<br/><br/><br/> Thanks & Regards,<br/><br/>Support Team<br/><br/>Mirror of Brands";
        MailMessage PassRecMail = new MailMessage(new MailAddress("support@mirrorofbrands.com", "Support Team"), new MailAddress(EmailAddress, Name));
        PassRecMail.Body = EmailBody;
        PassRecMail.IsBodyHtml = true;
        PassRecMail.Subject = "Account Activation";

        SmtpClient SMTP = new SmtpClient("mail.mirrorofbrands.com", 25);
        SMTP.Credentials = new NetworkCredential()
        {
            UserName = "support@mirrorofbrands.com",
            Password = "vaibhav@1308"
        };
        SMTP.EnableSsl = false;
        SMTP.Send(PassRecMail);
    }

    private Boolean checkemail()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        Boolean emailavailable = false;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email = '"+tbEmail.Text+"' AND Name = '"+tbName.Text+"' AND Mobile = '"+txtMobileNo.Text+"'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if(ds.Tables[0].Rows.Count > 0)
            {
                emailavailable = true;
            }
            return emailavailable;
        }
    }

    private Boolean checkmobile()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        Boolean mobileavailable = false;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Mobile = '" + txtMobileNo.Text + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                mobileavailable = true;
            }
            return mobileavailable;
        }
    }
}