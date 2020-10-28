using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class HomePage : System.Web.UI.MasterPage
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCategoriesRptr();
            BindSubMenurptr();
            BindmSubMenurptr();
            BindMobileCatRptr();
            BindCartItems();
            BindCartCount();
            BindWishlistCount();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        if(Page.User.Identity.IsAuthenticated)
        {
            Page.ViewStateUserKey = Session.SessionID;
        }
    }

    private void BindmSubMenurptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories WHERE CatID > 7", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                mSubMenu.Visible = false;
            }
            rptrmSubMenu.DataSource = dt;
            rptrmSubMenu.DataBind();
        }
    }

    private void BindSubMenurptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories WHERE CatID > 7", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                divSM.Visible = false;
            }
            rptrSubMenu.DataSource = dt;
            rptrSubMenu.DataBind();
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
                    spanmWCount.InnerText = "0";
                }
                else
                {
                    spanWCount.InnerText = count.ToString();
                    spanmWCount.InnerText = count.ToString();
                }
            }
        }
        else
        {
            spanWCount.InnerText = "0";
        }
    }

    private void BindMobileCatRptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories WHERE CatID <= 7", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptrMobileCat.DataSource = dtBrands;
                    rptrMobileCat.DataBind();
                }
            }
        }
    }

    private void BindCategoriesRptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories WHERE CatID <= 7", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptrCategories.DataSource = dtBrands;
                    rptrCategories.DataBind();
                }
            }
        }
    }

    private void BindCartItems()
    {
        Int64 PPrice;
        Int64 PSelPrice;
        Int64 PQuantity;
        Int64 Quantity;
        string DlvyChrg;

        Int64 CartTotal = 0;
        Int64 Total = 0;
        decimal Discount;
        Int64 DiscountPrice;
        Int64 SubTotal;
        Int64 TotalAmt;

        Int64 FDiscount = 0;
        Int64 DeliveryOpt;
        Int64 Delivery = 0;
        //string PDiscount;
        if (Session["EMAIL"] != null)
        {
            string USERID = Session["USERID"].ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.* FROM tblCart A INNER JOIN tblProducts B ON B.PID = A.ProductID CROSS APPLY (SELECT top 1 * FROM tblProductImages C WHERE C.PID = A.ProductID ORDER BY C.PID DESC) C WHERE A.Username = @User ORDER BY A.CartID DESC", con);
                cmd.Parameters.AddWithValue("@User", USERID);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtCart = new DataTable();
                sda.Fill(dtCart);
                if (dtCart.Rows.Count != 0)
                {
                    for (int i = 0; i < dtCart.Rows.Count; i++)
                    {
                        PPrice = Convert.ToInt64(dtCart.Rows[i]["PPrice"]);
                        PSelPrice = Convert.ToInt64(dtCart.Rows[i]["PSelPrice"]);
                        Discount = Convert.ToDecimal(dtCart.Rows[i]["PDiscount"]);
                        PQuantity = Convert.ToInt64(dtCart.Rows[i]["Quantity"]);
                        DlvyChrg = Convert.ToString(dtCart.Rows[i]["DeliveryOpt"]);

                        if (DlvyChrg == "250")
                        {
                            Quantity = PQuantity;
                            DeliveryOpt = Convert.ToInt64(DlvyChrg);
                            DiscountPrice = (PPrice - PSelPrice) * Quantity;
                            SubTotal = PPrice * Quantity;
                            TotalAmt = (PSelPrice * Quantity) + DeliveryOpt;
                            FDiscount += DiscountPrice;
                            Delivery += DeliveryOpt;
                            CartTotal += SubTotal;
                            Total += TotalAmt;
                        }
                        else if (DlvyChrg == "0")
                        {
                            Quantity = PQuantity;
                            DeliveryOpt = Convert.ToInt64(DlvyChrg);
                            DiscountPrice = (PPrice - PSelPrice) * Quantity;
                            SubTotal = PPrice * Quantity;
                            TotalAmt = (PSelPrice * Quantity) + DeliveryOpt;
                            FDiscount += DiscountPrice;
                            Delivery += DeliveryOpt;
                            CartTotal += SubTotal;
                            Total += TotalAmt;
                        }
                        strongTotal.InnerText = "Rs. " + Total.ToString();
                    }
                }
                else
                {
                    tfootPriceDetails.Visible = false;
                    divCheckoutBtn.Visible = false;
                }

                rptrCartProducts.DataSource = dtCart;
                rptrCartProducts.DataBind();
            }
        }
        else
        {
            tfootPriceDetails.Visible = false;
            divCheckoutBtn.Visible = false;
        }
    }

    private void BindCartCount()
    {
        if (Session["USERID"] != null)
        {
            string USERID = Session["USERID"].ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                int count = 0;
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblCart WHERE Username = @Cart", con);
                cmd.Parameters.AddWithValue("@Cart", USERID);
                con.Open();
                count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    spanNoItems.InnerText = "Your Cart is Empty!";
                    pCount.InnerText = "0";
                }
                else
                {
                    spanNoItems.InnerText = "Recent Cart Item(s): " + count.ToString() + " Products";
                    pCount.InnerText = count.ToString();
                }
            }
        }
        else
        {
            spanNoItems.InnerText = "Your Cart is Empty!";
            pCount.InnerText = "0";
        }
    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        Session["EMAIL"] = null;
        Session["USERID"] = null;
        Response.Redirect("~/Index.aspx");
    }

    protected void lbSignOut_Click(object sender, EventArgs e)
    {
        Session["EMAIL"] = null;
        Session["USERID"] = null;
        Response.Redirect("~/Index.aspx");
    }

    protected void btnSubscribe_Click(object sender, EventArgs e)
    {
        if (Session["EMAIL"] != null)
        {
            if (txtEmail.Text != "")
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblNewsletter VALUES(@Email)", con);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                txtEmail.Text = string.Empty;
            }
            else
            {
                lblError.Text = "Please Enter Email Address";
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void btnRemoveItem_Click(object sender, EventArgs e)
    {
        if (Session["USERID"] != null)
        {
            Button btn = (Button)(sender);
            string UniqueID = btn.CommandArgument;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tblCart WHERE UniqueID = @UID", con);
                cmd.Parameters.AddWithValue("@UID", UniqueID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("Index.aspx");
        }
    }
}
