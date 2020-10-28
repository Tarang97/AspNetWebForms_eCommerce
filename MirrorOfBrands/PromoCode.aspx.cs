using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class PromoCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindCouponRptr();
            BindUserslist();
            btnUpdateCoupon.Visible = false;
            if(Request.QueryString["pcid"] != null)
            {
                Int64 CouponID = Convert.ToInt64(Request.QueryString["pcid"]);
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblCoupon WHERE CouponID = @CCID", con);
                    cmd.Parameters.AddWithValue("@CCID", CouponID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                BindCouponRptr();
            }
            if(Request.QueryString["del"] != null)
            {
                btnCoupon.Visible = false;
                btnUpdateCoupon.Visible = true;
                Int64 CouponID = Convert.ToInt64(Request.QueryString["del"]);
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT A.*,B.* FROM tblCoupon A INNER JOIN Users B ON B.UId = A.UserID WHERE A.UserID = @Coupon", con);
                    cmd.Parameters.AddWithValue("@Coupon", CouponID);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while(sdr.Read())
                    {
                        tbCouponCode.Text = sdr.GetString(1);
                        tbDiscount.Text = sdr.GetInt32(2).ToString();
                        tbMaxDiscount.Text = sdr.GetInt32(3).ToString();
                        tbExpire.Text = sdr.GetDateTime(4).ToString();
                        cblUser.SelectedValue = sdr.GetInt32(5).ToString();
                    }
                }
            }
        }
    }

    private void BindUserslist()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count != 0)
            {
                cblUser.DataSource = dt;
                cblUser.DataTextField = "Name";
                cblUser.DataValueField = "UId";
                cblUser.DataBind();
            }
        }
    }

    private void BindCouponRptr()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT A.*,B.* FROM tblCoupon A INNER JOIN Users B ON B.UId = A.UserID", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rptrCoupon.DataSource = dt;
            rptrCoupon.DataBind();
        }
    }

    protected void btnCoupon_Click(object sender, EventArgs e)
    {
        DateTime dob = DateTime.Parse(Request.Form[tbExpire.UniqueID]);
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            foreach(ListItem lst in cblUser.Items)
            {
                if(lst.Selected == true)
                {
                    int UID = Convert.ToInt32(lst.Value);
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblCoupon VALUES(@CC,@Discount,@MaxDiscount,@ExpireDate,@UserID,@IU)", con);
                    cmd.Parameters.AddWithValue("@CC", tbCouponCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@Discount", tbDiscount.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaxDiscount", tbMaxDiscount.Text.Trim());
                    cmd.Parameters.AddWithValue("@ExpireDate", dob);
                    cmd.Parameters.AddWithValue("@UserID", UID);
                    cmd.Parameters.AddWithValue("@IU", "0");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        Response.Redirect("PromoCode.aspx");
    }

    protected void btnUpdateCoupon_Click(object sender, EventArgs e)
    {
        DateTime dob = DateTime.Parse(Request.Form[tbExpire.UniqueID]);
        string CouponID = Request.QueryString["del"];
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            foreach (ListItem lst in cblUser.Items)
            {
                if (lst.Selected == true)
                {
                    int UID = Convert.ToInt32(lst.Value);
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO tblCoupon VALUES('" + tbCouponCode.Text + "','" + tbDiscount.Text + "','" + tbMaxDiscount.Text + "',@Expire,'" + UID + "','0')", con))
                    {
                        cmd.Parameters.AddWithValue("@Expire", dob);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }
        Response.Redirect("PromoCode.aspx");
    }
}