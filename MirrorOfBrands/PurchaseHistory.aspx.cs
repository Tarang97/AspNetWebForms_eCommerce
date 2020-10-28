using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class PurchaseHistory : System.Web.UI.Page
{ 
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindPurchaserptr();
            if (Request.QueryString["phid"] != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT A.*,C.*,D.*,D.Name as UserName FROM tblOrders A INNER JOIN tblProducts C ON C.PID = A.PID INNER JOIN Users D ON D.UId = A.UserID WHERE A.OrderID = '"+ Request.QueryString["phid"] + "'", con);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if(ds.Tables[0].Rows.Count > 0)
                    {
                        lblID.Text = ds.Tables[0].Rows[0]["OrderID"].ToString();
                        lblUserName.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                        lblUEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                        lblPName.Text = ds.Tables[0].Rows[0]["PName"].ToString();
                        lblPPrice.Text = ds.Tables[0].Rows[0]["PSelPrice"].ToString();
                        PrdDisc.Text = ds.Tables[0].Rows[0]["PDiscount"].ToString();
                        Size.Text = ds.Tables[0].Rows[0]["SizeName"].ToString();
                        Qty.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();
                        Delivery.Text = ds.Tables[0].Rows[0]["DeliveryOpt"].ToString();
                        CartA.Text = ds.Tables[0].Rows[0]["CartAmount"].ToString();
                        CartD.Text = ds.Tables[0].Rows[0]["CartDiscount"].ToString();
                        TotalP.Text = ds.Tables[0].Rows[0]["TotalPayed"].ToString();
                        PayT.Text = ds.Tables[0].Rows[0]["PaymentType"].ToString();
                        ddlPayS.SelectedItem.Text = ds.Tables[0].Rows[0]["PaymentStatus"].ToString();
                        ddlOS.SelectedItem.Text = ds.Tables[0].Rows[0]["OrderStatus"].ToString();
                        Courier.Text = ds.Tables[0].Rows[0]["Courier"].ToString();
                        DateOP.Text = ds.Tables[0].Rows[0]["DateOfOrder"].ToString();
                        Name.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        Address.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        PinCode.Text = ds.Tables[0].Rows[0]["PinCode"].ToString();
                        Mobile.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                        City.Text = ds.Tables[0].Rows[0]["City"].ToString();
                        State.Text = ds.Tables[0].Rows[0]["State"].ToString();
                    }
                }
            }
        }
    }

    private void BindPurchaserptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT A.*,C.*,D.*,D.Name as UserName FROM tblOrders A INNER JOIN tblProducts C ON C.PID = A.PID INNER JOIN Users D ON D.UId = A.UserID", con);
            con.Open();
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dtPurchase = new DataTable();
                sda.Fill(dtPurchase);
                rptrPurchase.DataSource = dtPurchase;
                rptrPurchase.DataBind();
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Int64 PHID = Convert.ToInt64(Request.QueryString["phid"]);
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("UPDATE tblOrders SET PaymentStatus='"+ddlPayS.SelectedItem.Text+"',OrderStatus='"+ddlOS.SelectedItem.Text+"' WHERE OrderID = @OID", con);
            cmd.Parameters.AddWithValue("@OID", PHID);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        Response.Redirect("PurchaseHistory.aspx");
    }
}