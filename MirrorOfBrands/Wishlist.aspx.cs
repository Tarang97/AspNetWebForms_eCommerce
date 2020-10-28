using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class Wishlist : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EMAIL"] != null)
        {
            if(!IsPostBack)
            {
                BindWishlistCount();
                BindOrderCount();
                string USERID = Session["USERID"].ToString();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.* FROM tblWishlist A INNER JOIN tblProducts B ON B.PID = A.ProductID CROSS APPLY(SELECT top 1 * FROM tblProductImages C WHERE C.PID = A.ProductID ORDER BY C.PID DESC) C WHERE A.Username = @User ORDER BY A.WishlistID DESC", con);
                    cmd.Parameters.AddWithValue("@User", USERID);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dtWishlist = new DataTable();
                    sda.Fill(dtWishlist);
                    if(dtWishlist.Rows.Count == 0)
                    {
                        fieldsetWishlist.Visible = false;
                        lblEmpty.Text = "Your Wishlist is Empty!";
                    }
                    else
                    {
                        fieldsetWishlist.Visible = true;
                    }

                    rptrWishlist.DataSource = dtWishlist;
                    rptrWishlist.DataBind();
                }
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void lblDelete_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        string Wishlist = btn.CommandArgument;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tblWishlist WHERE UniqueID = @Product", con);
            cmd.Parameters.AddWithValue("@Product", Wishlist);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        Response.Redirect("Wishlist.aspx");
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