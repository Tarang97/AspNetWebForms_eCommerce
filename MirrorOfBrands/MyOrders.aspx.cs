using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class MyOrders : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["EMAIL"] != null)
        {
            if (!IsPostBack)
            {
                string USERID = Session["USERID"].ToString();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT A.*,A.Name,B.*,E.*,E.Name,A.Name as Namee,E.Name as ImageName FROM tblOrders A INNER JOIN tblProducts B ON B.PID = A.PID CROSS APPLY(SELECT top 1 * FROM tblProductImages E WHERE E.PID = A.PID ORDER BY E.PID DESC) E WHERE A.UserID = @UID ORDER BY A.OrderID DESC", con);
                    cmd.Parameters.AddWithValue("@UID", USERID);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dtOrderHist = new DataTable();
                    sda.Fill(dtOrderHist);
                    if(dtOrderHist.Rows.Count == 0)
                    {
                        tableOrder.Visible = false;
                    }
                    else
                    {
                        tableOrder.Visible = true;
                    }
                    rptrOrderHist.DataSource = dtOrderHist;
                    rptrOrderHist.DataBind();

                    int count = 0;
                    SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM tblOrders WHERE UserID = @User", con);
                    cmd1.Parameters.AddWithValue("@User", USERID);
                    count = (int)cmd1.ExecuteScalar();

                    if (count == 0)
                    {
                        spanOH.InnerText = "You have no Order History";
                    }
                    else
                    {
                        spanOH.InnerText = "You have " + count.ToString() + " Records of Order History";
                    }
                }
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}
