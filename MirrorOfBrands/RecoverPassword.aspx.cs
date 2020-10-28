using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Text;
using System.Security.Cryptography;

public partial class RecoverPassword : System.Web.UI.Page
{
    String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    String GUIDvalue;
    DataTable dt = new DataTable();
    int Uid;
    protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            GUIDvalue = Request.QueryString["Uid"];
            if(GUIDvalue != null)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ForgotPassRequests WHERE Id = '"+GUIDvalue+"'",con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if(dt.Rows.Count != 0)
                { 
                    Uid = Convert.ToInt32(dt.Rows[0][1]);
                }
                else
                {
                    lblMsg.Text = "Your Password Reset link is Expired or Invalid!";
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        if (!IsPostBack)
        {
            if (dt.Rows.Count != 0)
            {
                tbNewPass.Visible = true;
                tbConfirmPass.Visible = true;
                lblPassword.Visible = true;
                lblRetypePass.Visible = true;
                lblPassError.Visible = true;
                btRecPass.Visible = true;
                RequiredFieldValidator1.Visible = true;
                CompareValidator1.Visible = true;
            }
            else
            {
                lblMsg.Text = "Your password reset link is Expired or Invalid!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }

    protected void btRecPass_Click(object sender, EventArgs e)
    {
        //Check for password length           
        if (tbNewPass.Text.Length < 8)
        {
            lblPassError.Text = "Password length should be atleast 8 or more characters";
            tbNewPass.Focus();
            return;
        }

        if (tbNewPass.Text != "" && tbConfirmPass.Text != "" && tbNewPass.Text == tbConfirmPass.Text)
        {
            // Hash First Password Field
            byte[] hs1 = new byte[50];
            string pass = tbNewPass.Text;
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

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE Users SET Password = '"+hash_pass+"' WHERE Uid = '"+Uid+"'",con);
                con.Open();
                cmd1.ExecuteNonQuery();

                SqlCommand cmd2 = new SqlCommand("DELETE FROM ForgotPassRequests WHERE Uid = '"+Uid+"'",con);
                cmd2.ExecuteNonQuery();
                Response.Write("<script>alert('Password Changed Successfully');</script>");
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}