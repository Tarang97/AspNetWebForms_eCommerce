using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Search : System.Web.UI.Page
{
    static int currentposition = 0;
    static int totalrows = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString["term"] != null)
            {
                BindSearchResult();
            }
            else
            {
                Response.Redirect("~/Index.aspx");
            }
        }
    }

    private void BindSearchResult()
    {
        if(Request.QueryString["term"] != null)
        {
            String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PName LIKE ('%" + Request.QueryString["term"].ToString() + "%') AND A.Status = 'Publish' ORDER BY A.PID DESC", con);
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    totalrows = ds.Tables[0].Rows.Count;
                    DataTable dt = ds.Tables[0];
                    PagedDataSource pg = new PagedDataSource();
                    pg.DataSource = dt.DefaultView;
                    pg.AllowPaging = true;
                    pg.CurrentPageIndex = currentposition;
                    pg.PageSize = 12;
                    lb1.Enabled = !pg.IsFirstPage;
                    lb2.Enabled = !pg.IsFirstPage;
                    lb3.Enabled = !pg.IsLastPage;
                    lb4.Enabled = !pg.IsLastPage;
                    //Binding pg to Repeater
                    rptrProducts.DataSource = pg;
                    rptrProducts.DataBind();

                    spanResult.InnerText = "Search Result for: " + Request.QueryString["term"].ToString();
                    Page.Title = "Search Result for: " + Request.QueryString["term"].ToString();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        divPagination.Visible = true;
                        lblNoFound.Visible = false;
                    }
                    else
                    {
                        divPagination.Visible = false;
                        lblNoFound.Text = "No Products found for: " + Request.QueryString["term"].ToString();
                    }
                }
            }
        }
        else
        {
            Response.Redirect("Index.aspx");
        }
    }

    protected void lb1_Click(object sender, EventArgs e)
    {
        currentposition = 0;
        BindSearchResult();
    }

    protected void lb2_Click(object sender, EventArgs e)
    {
        if (currentposition == 0)
        {

        }
        else
        {
            currentposition = currentposition - 1;
            BindSearchResult();
        }
    }

    protected void lb3_Click(object sender, EventArgs e)
    {
        if (currentposition == totalrows - 1)
        {

        }
        else
        {
            currentposition = currentposition + 1;
            BindSearchResult();
        }
    }

    protected void lb4_Click(object sender, EventArgs e)
    {
        currentposition = totalrows - 1;
        BindSearchResult();
    }

    protected void lbWishlist_Click(object sender, EventArgs e)
    {
        if (Session["EMAIL"] != null)
        {
            String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
            string USERID = Session["USERID"].ToString();
            LinkButton btn = (LinkButton)(sender);
            string PID = btn.CommandArgument;
            String myGUID = Guid.NewGuid().ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM tblWishlist WHERE Username = '" + USERID + "' AND ProductID = '" + PID + "'", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (USERID == ds.Tables[0].Rows[0]["Username"].ToString() && PID == ds.Tables[0].Rows[0]["ProductID"].ToString())
                        {
                            Response.Redirect("Wishlist.aspx");
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO tblWishlist VALUES(@User,@PerProduct,@UID)", con);
                            cmd.Parameters.AddWithValue("@User", USERID);
                            cmd.Parameters.AddWithValue("@PerProduct", PID);
                            cmd.Parameters.AddWithValue("@UID", myGUID);
                            cmd.ExecuteNonQuery();
                        }
                        Response.Redirect("Wishlist.aspx");
                    }
                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO tblWishlist VALUES(@User,@PerProduct,@UID)", con);
                    cmd2.Parameters.AddWithValue("@User", USERID);
                    cmd2.Parameters.AddWithValue("@PerProduct", PID);
                    cmd2.Parameters.AddWithValue("@UID", myGUID);
                    cmd2.ExecuteNonQuery();
                }
                Response.Redirect("Wishlist.aspx");
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Login to add Product in Wishlist');window.location='Search.aspx?term=" + Request.QueryString["term"] + "';</script>");
        }
    }
}