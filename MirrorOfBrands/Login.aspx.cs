using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Data;
using System.Drawing;
using System.Text;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UEMAIL"] != null && Request.Cookies["UPASS"] != null)
            {
                UserEmail.Text = Request.Cookies["UEMAIL"].Value;
                Password.Attributes["value"] = Request.Cookies["UPASS"].Value;
                CheckBox1.Checked = true;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // Hash Password Field
        byte[] hs1 = new byte[50];
        string pass = Password.Text;
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

        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email = '" + UserEmail.Text + "' AND Password = '" + hash_pass + "' AND Status = 'Verified'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                Session["USERID"] = dt.Rows[0]["UId"].ToString();
                Session["USEREMAIL"] = dt.Rows[0]["Email"].ToString();
                Session["USERNAME"] = dt.Rows[0]["Name"].ToString();
                if (CheckBox1.Checked)
                {
                    Response.Cookies["UEMAIL"].Value = UserEmail.Text;
                    Response.Cookies["UPASS"].Value = Password.Text;

                    Response.Cookies["UEMAIL"].Expires = DateTime.Now.AddDays(7);
                    Response.Cookies["UPASS"].Expires = DateTime.Now.AddDays(7);
                }
                else
                {
                    Response.Cookies["UEMAIL"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["UPASS"].Expires = DateTime.Now.AddDays(-1);
                }

                string Utype;
                Utype = dt.Rows[0][4].ToString().Trim();

                if (Utype == "U")
                {
                    Session["EMAIL"] = UserEmail.Text;
                    if (Request.QueryString["rurl"] != null)
                    {
                        if (Request.QueryString["rurl"] == "ShoppingCart")
                        {
                            Response.Redirect("~/ShoppingCart.aspx");
                        }
                    }
                    else if (Request.QueryString["curl"] != null)
                    {
                        if (Request.QueryString["curl"] == "Contact")
                        {
                            Response.Redirect("~/Contact.aspx");
                        }
                    }
                    else
                    { 
                        Response.Redirect("~/Index.aspx");
                    }
                }
                if (Utype == "A")
                {
                    Session["EMAIL"] = UserEmail.Text;
                    Response.Redirect("~/AdminDash.aspx");
                }

            }
            else
            {
                lblError.Text = "Invalid Username or Password...Or Account is not Active";
                lblError.ForeColor = Color.Red;
            }
        }
    }
}
