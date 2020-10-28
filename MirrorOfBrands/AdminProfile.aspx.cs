using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

public partial class AdminProfile : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Session["EMAIL"] != null)
            {
                string USERID = Session["EMAIL"].ToString();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email = @EAdmin AND Usertype = 'A'", con);
                    cmd.Parameters.AddWithValue("@EAdmin", USERID);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if(ds.Tables[0].Rows.Count > 0)
                    {
                        tbName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        tbEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                        tbMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
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

        if(hash_pass == hash_pass2)
        {
            string USERID = Session["EMAIL"].ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Users SET Name = @AName, Email = @AEmail, Password = @APass, Mobile = @AMobile WHERE Email = @AEmail AND Usertype = 'A'", con);
                cmd.Parameters.AddWithValue("@AName", tbName.Text.Trim());
                cmd.Parameters.AddWithValue("@AEmail", tbEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@APass", hash_pass);
                cmd.Parameters.AddWithValue("AMobile", tbMobile.Text.Trim());
                cmd.Parameters.AddWithValue("@AEmail", USERID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}