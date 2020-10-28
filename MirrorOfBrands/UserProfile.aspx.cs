using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Security.Cryptography;

public partial class UserProfile : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EMAIL"] != null)
        {
            if(!IsPostBack)
            { 
            // Select Users data from DB
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email = '" + Session["EMAIL"] + "'", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult | CommandBehavior.SingleRow);
                    // Populate the textfields with query results
                    while (sdr.Read())
                    {
                        txtName.Text = sdr.GetString(1);
                        txtEmail.Text = sdr.GetString(2);
                        txtMobileNumber.Text = sdr.GetString(5);
                    }
                }
                BindOrderCount();
                BindWishlistCount();
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void txtUpdate_Click(object sender, EventArgs e)
    {
        if(txtName.Text != "" || txtEmail.Text != "" || txtMobileNumber.Text != "" || txtPass.Text != "" || txtCPass.Text != "")
        {
            // Hash First Password Field
            byte[] hs1 = new byte[50];
            string pass = txtPass.Text;
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
            string pass2 = txtCPass.Text;
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
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Users SET Name = @UserName, Email = @UserEmail, Password = @HashPassword, Mobile = @UserMobile WHERE Email = '" + Session["EMAIL"].ToString() + "'", con);
                    cmd.Parameters.AddWithValue("@UserName", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserEmail", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserMobile", txtMobileNumber.Text.Trim());
                    cmd.Parameters.AddWithValue("@HashPassword", hash_pass);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                lblSuccess.Text = "Profile Updated Successfully";
                lblSuccess.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblError.Text = "Password does not much!";
                lblError.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            lblError.Text = "Field is Required!";
            lblError.ForeColor = System.Drawing.Color.Red;
        }
    }

    private void BindWishlistCount()
    {
        if (Session["USERID"] != null)
        {
            string USERID = Session["USERID"].ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                int count = 0;
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblWishlist WHERE Username = @Wishlist", con);
                cmd.Parameters.AddWithValue("@Wishlist", USERID);
                con.Open();
                count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    spanWCount.InnerText = "0";
                }
                else
                {
                    spanWCount.InnerText = count.ToString();
                }
            }
        }
        else
        {
            spanWCount.InnerText = "0";
        }
    }

    private void BindOrderCount()
    {
        if (Session["USERID"] != null)
        {
            string USERID = Session["USERID"].ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                int count = 0;
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblOrders WHERE UserID = @Cart", con);
                cmd.Parameters.AddWithValue("@Cart", USERID);
                con.Open();
                count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    spanOCount.InnerText = "0";
                }
                else
                {
                    spanOCount.InnerText = count.ToString();
                }
            }
        }
    }
}