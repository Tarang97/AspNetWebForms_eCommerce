using paytm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckOut : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Recomment later - Commented for Testing Purpose
        if (Session["EMAIL"] == null)
        {
            //divCheckOut.Visible = false;
            Response.Redirect("~/Login.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                //BindCartProducts();
                BindCartItems();
                GetPID();
            }
        }
    }

    private void GetPID()
    {
        string USERID = Session["USERID"].ToString();
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblCart WHERE Username = @User", con);
            cmd.Parameters.AddWithValue("@User", USERID);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hfProductID.Value = ds.Tables[0].Rows[0]["ProductID"].ToString();
            }
        }
    }

    private void BindCartItems()
    {
        Int64 CartID;
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
                if (dtCart.Rows.Count != 0)
                {
                    for (int i = 0; i < dtCart.Rows.Count; i++)
                    {
                        CartID = Convert.ToInt64(dtCart.Rows[i]["CartID"]);
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
                        strongDlvy.InnerText = "Rs. " + Delivery.ToString();
                        strongTotal.InnerText = "Rs. " + Total.ToString();

                        hdCart.Value = CartID.ToString();
                        hdCartAmount.Value = CartTotal.ToString();
                        hdCartDiscount.Value = FDiscount.ToString();
                        hdTotalPayed.Value = Total.ToString();
                        hfDlvy.Value = Delivery.ToString();
                    }
                }
                rptrReview.DataSource = dtCart;
                rptrReview.DataBind();
            }
        }
        else
        {
            Response.Redirect("~/Index.aspx");
        }
    }

    protected void btnPaytm_Click(object sender, EventArgs e)
    {
        if (Session["USERID"] != null)
        {
            if (txtName.Text != "" && txtMobileNumber.Text != "" && txtAddress.Text != "" && txtCity.Text != "" && txtState.Text != "" && txtPinCode.Text != "")
            {
                string USERID = Session["USERID"].ToString();
                string PaymentType = "Paytm";
                string PaymentStatus = "NotPaid";
                string OrderStatus = "Received";
                string EMAILID = Session["USEREMAIL"].ToString();
                string CallBackURL = "https://www.mirrorofbrands.com/Callback.aspx?Pay=PayTm";
                String myGUID = Guid.NewGuid().ToString();

                // Insert data to tblpurchase
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblPurchase  VALUES('" + USERID + "','" + hdCart.Value + "','" + hfProductID.Value + "','"
                        + hdCartAmount.Value + "','" + hdCartDiscount.Value + "','" + hdTotalPayed.Value + "','" + PaymentType + "','" + PaymentStatus + "','" + OrderStatus + "','"
                        + rblCourier.SelectedItem.Text + "',getDate(),'" + txtName.Text + "','" + txtAddress.Text + "','" + txtPinCode.Text + "','" + txtMobileNumber.Text + "','"
                        + txtCity.Text + "','" + txtState.Text + "','" + myGUID + "') select SCOPE_IDENTITY()", con);
                    con.Open();
                    Int64 PurchaseID = Convert.ToInt64(cmd.ExecuteScalar());

                    SqlCommand cmd1 = new SqlCommand("UPDATE tblOrders SET CartAmount = '" + hdCartAmount.Value + "',CartDiscount='" + hdCartDiscount.Value + "',TotalPayed='"
                        + hdTotalPayed.Value + "',PaymentType='" + PaymentType + "',PaymentStatus='" + PaymentStatus + "',OrderStatus='" + OrderStatus + "',Courier='" + rblCourier.SelectedItem.Text + "',Name='"
                        + txtName.Text + "',Address='" + txtAddress.Text + "',PinCode='" + txtPinCode.Text + "',MobileNo='" + txtMobileNumber.Text + "',City='" + txtCity.Text + "',State='"
                        + txtState.Text + "' WHERE CartAmount='999' AND CartDiscount='999' AND TotalPayed='999' AND PaymentType='PayType' AND PaymentStatus='PayS' AND Name='XYZ' AND Address='XYZ' AND PinCode='123456' AND MobileNo='1234567890' AND City='XYZ' AND State='XYZ'", con);
                    cmd1.ExecuteNonQuery();

                    //Random Purchase ID
                    Random random = new Random();
                    hfPurchaseID.Value = PurchaseID.ToString();
                    hfPurchaseID.Value = (Convert.ToString(random.Next(1000000, 200000000)));
                    hfPurchaseID.Value = hfPurchaseID.Value.ToString();

                    PaytmPayment(EMAILID, txtMobileNumber.Text, USERID, hfPurchaseID.Value, hdTotalPayed.Value, CallBackURL);
                }
            }
            else
            {
                lblError.Text = "Please Fill Out the Required Fields";
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    public void PaytmPayment(string EMAIL, string MOBILE_NO, string CUST_ID, string ORDER_ID, string TXN_AMOUNT, string CALLBACK_URL)
    {
        String merchantKey = "1RFbjjzxk@fOE0V&";
        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("MID", "IenHZV35851036253027");
        parameters.Add("CHANNEL_ID", "WEB");
        parameters.Add("INDUSTRY_TYPE_ID", "RETAIL");
        parameters.Add("WEBSITE", "DEFAULT");
        parameters.Add("EMAIL", EMAIL);
        parameters.Add("MOBILE_NO", MOBILE_NO);
        parameters.Add("CUST_ID", CUST_ID);
        parameters.Add("ORDER_ID", ORDER_ID);
        parameters.Add("TXN_AMOUNT", TXN_AMOUNT);
        parameters.Add("CALLBACK_URL", CALLBACK_URL); //This parameter is not mandatory. Use this to pass the callback url dynamically.

        string checksum = CheckSum.generateCheckSum(merchantKey, parameters);

        string paytmURL = "https://securegw.paytm.in/theia/processTransaction?orderid=" + ORDER_ID;

        string outputHTML = "<html>";
        outputHTML += "<head>";
        outputHTML += "<title>Merchant Check Out Page</title>";
        outputHTML += "</head>";
        outputHTML += "<body>";
        outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
        outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
        outputHTML += "<table border='1'>";
        outputHTML += "<tbody>";
        foreach (string key in parameters.Keys)
        {
            outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
        }
        outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
        outputHTML += "</tbody>";
        outputHTML += "</table>";
        outputHTML += "<script type='text/javascript'>";
        outputHTML += "document.f1.submit();";
        outputHTML += "</script>";
        outputHTML += "</form>";
        outputHTML += "</body>";
        outputHTML += "</html>";
        Response.Write(outputHTML);
    }

    protected void btnCouponApply_Click(object sender, EventArgs e)
    {
        //Varibles for Coupon
        int discount;
        int maxdiscount;
        Int64 finalprice;
        Int64 discountprice;
        string datetime;
        string dob = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt");

        string USERID = Session["USERID"].ToString();
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCoupon WHERE CouponCode = @CC AND UserID = @UID AND IsUsed = '0'", con))
            {
                cmd.Parameters.AddWithValue("@CC", txtCoupon.Text);
                cmd.Parameters.AddWithValue("@UID", USERID);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if(ds.Tables[0].Rows.Count > 0)
                {
                    lblCouponSuccess.Text = "Coupon Code " + txtCoupon.Text + " Applied Successfully";
                    lblCouponSuccess.ForeColor = System.Drawing.Color.Green;

                    datetime = ds.Tables[0].Rows[0]["ExpireDate"].ToString();
                    discount = Convert.ToInt16(ds.Tables[0].Rows[0]["Discount"].ToString());
                    maxdiscount = Convert.ToInt16(ds.Tables[0].Rows[0]["MaxDiscount"].ToString());
                    discountprice = (Convert.ToInt16(hdTotalPayed.Value) * discount) / 100;
                    if (discountprice > maxdiscount)
                    {
                        discountprice = maxdiscount;
                    }
                    if (Convert.ToDateTime(dob) >= Convert.ToDateTime(datetime))
                    {
                        lblCouponSuccess.Text = "Coupon is Expired...Please try another one!";
                        lblCouponSuccess.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblMaxDiscount.Text = "Rs. " + discountprice.ToString() + "(" + discount + "%) Maximum Upto Rs." + maxdiscount;
                        finalprice = Convert.ToInt16(hdTotalPayed.Value) - discountprice;
                        strongTotal.InnerText = "Rs. " + finalprice.ToString();
                        hdTotalPayed.Value = finalprice.ToString();
                    }
                    SqlCommand cmd3 = new SqlCommand("UPDATE tblCoupon SET IsUsed = '1' WHERE CouponCode = '" + txtCoupon.Text.Trim() + "' AND UserID = '" + USERID + "'", con);
                    cmd3.ExecuteNonQuery();
                }
                else
                {
                    lblCouponSuccess.Text = "Coupon Code is Invalid or Already Used...Please try another one!";
                    lblCouponSuccess.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }

    protected void rptrReview_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string CartID = (e.Item.FindControl("hfCart") as HiddenField).Value;
            string ProductID = (e.Item.FindControl("hfPID") as HiddenField).Value;
            string SizeID = (e.Item.FindControl("hfSID") as HiddenField).Value;
            string Quantity = (e.Item.FindControl("hfQty") as HiddenField).Value;
            string Delivery = (e.Item.FindControl("hfDlvy") as HiddenField).Value;
            string CartAmt = (e.Item.FindControl("hfCA") as HiddenField).Value;
            string CartDiscount = (e.Item.FindControl("hfCD") as HiddenField).Value;
            string TotalPayed = (e.Item.FindControl("hfTP") as HiddenField).Value;
            string PaymentType = (e.Item.FindControl("hfPT") as HiddenField).Value;
            string PaymentStatus = (e.Item.FindControl("hfPS") as HiddenField).Value;
            string OrderStatus = (e.Item.FindControl("hfOS") as HiddenField).Value;
            string Name = (e.Item.FindControl("hfName") as HiddenField).Value;
            string Address = (e.Item.FindControl("hfAddr") as HiddenField).Value;
            string PinCode = (e.Item.FindControl("hfPC") as HiddenField).Value;
            string MobileNo = (e.Item.FindControl("hfMob") as HiddenField).Value;
            string City = (e.Item.FindControl("hfCity") as HiddenField).Value;
            string State = (e.Item.FindControl("hfState") as HiddenField).Value;
            string CourierComapany = (e.Item.FindControl("hfCC") as HiddenField).Value;

            String myGUID = Guid.NewGuid().ToString();
            string USERID = Session["USERID"].ToString();

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblOrders WHERE CartID = @Cart AND UserID = @User", con);
                cmd.Parameters.AddWithValue("@Cart", CartID);
                cmd.Parameters.AddWithValue("@User", USERID);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (CartID == ds.Tables[0].Rows[0]["CartID"].ToString() && USERID == ds.Tables[0].Rows[0]["UserID"].ToString())
                        {
                            SqlCommand cmd1 = new SqlCommand("DELETE FROM tblOrders WHERE CartID = @Cart AND UserID = @User", con);
                            cmd1.Parameters.AddWithValue("@Cart", CartID);
                            cmd1.Parameters.AddWithValue("@User", USERID);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand cmd1 = new SqlCommand("INSERT INTO tblOrders VALUES(@Prd,@UID,@CID,@Size,@CA,@CD,@TP,@PT,@PS,@OS,@CC,@Name,@Addr,@PC,@Mob,@City,@Province,@Qty,@Dlvy,@DT,@Unique)", con);
                            cmd1.Parameters.AddWithValue("@Prd", ProductID);
                            cmd1.Parameters.AddWithValue("@UID", USERID);
                            cmd1.Parameters.AddWithValue("@CID", CartID);
                            cmd1.Parameters.AddWithValue("@Size", SizeID);
                            cmd1.Parameters.AddWithValue("@CA", CartAmt);
                            cmd1.Parameters.AddWithValue("@CD", CartDiscount);
                            cmd1.Parameters.AddWithValue("@TP", TotalPayed);
                            cmd1.Parameters.AddWithValue("@PT", PaymentType);
                            cmd1.Parameters.AddWithValue("@PS", PaymentStatus);
                            cmd1.Parameters.AddWithValue("@OS", OrderStatus);
                            cmd1.Parameters.AddWithValue("@CC", CourierComapany);
                            cmd1.Parameters.AddWithValue("@Name", Name);
                            cmd1.Parameters.AddWithValue("@Addr", Address);
                            cmd1.Parameters.AddWithValue("@PC", PinCode);
                            cmd1.Parameters.AddWithValue("@Mob", MobileNo);
                            cmd1.Parameters.AddWithValue("@City", City);
                            cmd1.Parameters.AddWithValue("@Province", State);
                            cmd1.Parameters.AddWithValue("@Qty", Quantity);
                            cmd1.Parameters.AddWithValue("@Dlvy", Delivery);
                            cmd1.Parameters.AddWithValue("@DT", DateTime.Now);
                            cmd1.Parameters.AddWithValue("@Unique", myGUID);
                            cmd1.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO tblOrders VALUES(@Prd,@UID,@CID,@Size,@CA,@CD,@TP,@PT,@PS,@OS,@CC,@Name,@Addr,@PC,@Mob,@City,@Province,@Qty,@Dlvy,@DT,@Unique)", con);
                    cmd2.Parameters.AddWithValue("@Prd", ProductID);
                    cmd2.Parameters.AddWithValue("@UID", USERID);
                    cmd2.Parameters.AddWithValue("@CID", CartID);
                    cmd2.Parameters.AddWithValue("@Size", SizeID);
                    cmd2.Parameters.AddWithValue("@CA", CartAmt);
                    cmd2.Parameters.AddWithValue("@CD", CartDiscount);
                    cmd2.Parameters.AddWithValue("@TP", TotalPayed);
                    cmd2.Parameters.AddWithValue("@PT", PaymentType);
                    cmd2.Parameters.AddWithValue("@PS", PaymentStatus);
                    cmd2.Parameters.AddWithValue("@OS", OrderStatus);
                    cmd2.Parameters.AddWithValue("@CC", CourierComapany);
                    cmd2.Parameters.AddWithValue("@Name", Name);
                    cmd2.Parameters.AddWithValue("@Addr", Address);
                    cmd2.Parameters.AddWithValue("@PC", PinCode);
                    cmd2.Parameters.AddWithValue("@Mob", MobileNo);
                    cmd2.Parameters.AddWithValue("@City", City);
                    cmd2.Parameters.AddWithValue("@Province", State);
                    cmd2.Parameters.AddWithValue("@Qty", Quantity);
                    cmd2.Parameters.AddWithValue("@Dlvy", Delivery);
                    cmd2.Parameters.AddWithValue("@DT", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@Unique", myGUID);
                    cmd2.ExecuteNonQuery();
                }
            }
        }
    }

    protected void btnCod_Click(object sender, EventArgs e)
    {
        if (Session["EMAIL"] != null)
        {
            if (txtName.Text != "" && txtMobileNumber.Text != "" && txtAddress.Text != "" && txtCity.Text != "" && txtState.Text != "" && txtPinCode.Text != "")
            {
                string USERID = Session["USERID"].ToString();
                string PaymentType = "Cash On Delivery";
                string PaymentStatus = "NotPaid";
                string OrderStatus = "Received";
                String myGUID = Guid.NewGuid().ToString();

                // Insert data to tblpurchase
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tblPurchase  VALUES('" + USERID + "','" + hdCart.Value + "','" + hfProductID.Value + "','"
                        + hdCartAmount.Value + "','" + hdCartDiscount.Value + "','" + hdTotalPayed.Value + "','" + PaymentType + "','" + PaymentStatus + "','" + OrderStatus + "','"
                        + rblCourier.SelectedItem.Text + "',getDate(),'" + txtName.Text + "','" + txtAddress.Text + "','" + txtPinCode.Text + "','" + txtMobileNumber.Text + "','"
                        + txtCity.Text + "','" + txtState.Text + "','" + myGUID + "') select SCOPE_IDENTITY()", con);
                    con.Open();
                    Int64 PurchaseID = Convert.ToInt64(cmd.ExecuteScalar());

                    SqlCommand cmd1 = new SqlCommand("UPDATE tblOrders SET CartAmount = '" + hdCartAmount.Value + "',CartDiscount='" + hdCartDiscount.Value + "',TotalPayed='"
                        + hdTotalPayed.Value + "',PaymentType='" + PaymentType + "',PaymentStatus='" + PaymentStatus + "',OrderStatus='" + OrderStatus + "',Courier='" + rblCourier.SelectedItem.Text + "',Name='"
                        + txtName.Text + "',Address='" + txtAddress.Text + "',PinCode='" + txtPinCode.Text + "',MobileNo='" + txtMobileNumber.Text + "',City='" + txtCity.Text + "',State='"
                        + txtState.Text + "' WHERE CartAmount='999' AND CartDiscount='999' AND TotalPayed='999' AND PaymentType='PayType' AND PaymentStatus='PayS' AND Name='XYZ' AND Address='XYZ' AND PinCode='123456' AND MobileNo='1234567890' AND City='XYZ' AND State='XYZ'", con);
                    cmd1.ExecuteNonQuery();
                }
                Response.Redirect("Callback.aspx?Pay=Confirmed");
            }
            else
            {
                lblError.Text = "Please fill Out all required Fields";
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}