using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using paytm;

public partial class Callback : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EMAIL"] != null)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Pay"] == "PayTm")
                {
                    String merchantKey = "1RFbjjzxk@fOE0V&"; // Replace this with the Merchant Key provided by Paytm at the time of registration.

                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    string paytmChecksum = "";
                    foreach (string key in Request.Form.Keys)
                    {
                        parameters.Add(key.Trim(), Request.Form[key].Trim());
                    }

                    if (parameters.ContainsKey("CHECKSUMHASH"))
                    {
                        paytmChecksum = parameters["CHECKSUMHASH"];
                        parameters.Remove("CHECKSUMHASH");
                    }

                    if (CheckSum.verifyCheckSum(merchantKey, parameters, paytmChecksum))
                    {
                        string paytmStatus = parameters["STATUS"];
                        string txnID = parameters["TXNID"];

                        if (paytmStatus == "TXN_SUCCESS")
                        {
                            lblOrder.Text = "Your Payment Done Successfully...Your Order is Confirmed";
                            lbltxnID.Text = "Your Transaction Id :" + txnID;
                            string transactionid = "11";
                            Random random = new Random();
                            lbltID.Text = transactionid;
                            lbltID.Text = "Order ID: " + (Convert.ToString(random.Next(1000000, 200000000)));
                            DeleteCart();
                        }
                        else if (paytmStatus == "PENDING")
                        {
                            lblOrder.Text = "Your Payment is Pending!";
                        }
                        else if (paytmStatus == "TXN_FAILURE")
                        {
                            lblOrder.Text = "Unfortunately Your Payment Failed - Your Order is not Confirmed!";
                        }
                    }
                    else
                    {
                        Response.Write("Checksum MisMatch");
                    }
                }
                else if(Request.QueryString["Pay"] == "Confirmed")
                {
                    lblOrder.Text = "Your Order Placed Sucessfully";
                    string transactionid = "11";
                    Random random = new Random();
                    lbltxnID.Text = transactionid;
                    lbltxnID.Text = "Order ID: "+(Convert.ToString(random.Next(1000000, 200000000)));
                    DeleteCart();
                }
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    private void DeleteCart()
    {
        string USERID = Session["USERID"].ToString();
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tblCart WHERE Username = @UID", con);
            cmd.Parameters.AddWithValue("@UID", USERID);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        
    }
}