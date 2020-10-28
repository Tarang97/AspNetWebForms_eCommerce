using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShoppingCart : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindCartItems();
            BindCartCount();
        }
    }

    private void BindCartCount()
    {
        if(Session["EMAIL"] != null)
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
                    spanNoItems.InnerText = " Nothing!";
                }
                else
                {
                    spanNoItems.InnerText = count.ToString() + " Products";
                }
            }
        }
        else
        {
            spanNoItems.InnerText = " Nothing!";
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
        if (Session["USERID"] != null)
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
                if(dtCart.Rows.Count != 0)
                {
                    for(int i = 0; i < dtCart.Rows.Count; i++)
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
                        tdCartTotal.InnerText = "Rs. " + CartTotal.ToString();
                        tdDiscount.InnerText = "- " + FDiscount.ToString();
                        strongDlvy.InnerText = "+" + Delivery.ToString();
                        strongTotal.InnerText = "Rs. " + Total.ToString();
                    }
                }
                else
                {
                    theadPriceDetails.Visible = false;
                    tfootPriceDetails.Visible = false;
                    divCheckoutBtn.Visible = false;
                    spanNoItems.InnerText = " Nothing";
                }
                rptrCartProducts.DataSource = dtCart;
                rptrCartProducts.DataBind();
            }
        }
        else
        {
            theadPriceDetails.Visible = false;
            tfootPriceDetails.Visible = false;
            divCheckoutBtn.Visible = false;
            spanNoItems.InnerText = " Nothing";
        }
    }        

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        if(Session["EMAIL"] != null)
        {
            LinkButton btn = (LinkButton)(sender);
            string UniqueID = btn.CommandArgument;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tblCart WHERE UniqueID = @UID", con);
                cmd.Parameters.AddWithValue("@UID", UniqueID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("ShoppingCart.aspx");
        }
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        if(Session["EMAIL"] != null)
        {
            Response.Redirect("~/CheckOut.aspx");
        }
        else
        {
            Response.Redirect("~/Login.aspx?rurl=ShoppingCart");
        }
    }
}