using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ProductFeatured : System.Web.UI.Page
{
    static int currentposition = 0;
    static int totalrows = 0;
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            int id = 0;
            if(Request.QueryString["sc"] != null)
            {
                if(int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
                {
                    BindFeaturedResults(id);
                    BindBannerResults(id);
                }
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
        }
    }

    private void BindBannerResults(int id)
    {
        //Int64 SubCatID = Convert.ToInt64(Request.QueryString["sc"]);
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.BrandID,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblSubCategories D ON D.SubCatID = A.PSubCatID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE (A.PSubCatID = @Accessory or A.PBrandID = @Brands) AND A.Status = 'Publish' ORDER BY A.PID DESC", con))
            {
                cmd.Parameters.AddWithValue("@Accessory", id);
                cmd.Parameters.AddWithValue("@Brands", id);
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
                }
            }
        }
    }

    private void BindFeaturedResults(int id)
    {
        //Int64 SubCatID = Convert.ToInt64(Request.QueryString["sc"]);
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.*,D.* FROM tblProducts A INNER JOIN tblCategories B ON B.CatID = A.PCategoryID INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblSubCategories D ON D.SubCatID = A.PSubCatID WHERE (A.PSubCatID = @SCID or A.PBrandID = @BID) AND A.Status = 'Publish'", con))
            {
                cmd.Parameters.AddWithValue("@SCID", id);
                cmd.Parameters.AddWithValue("@BID", id);
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtFeatured = new DataTable();
                    sda.Fill(dtFeatured);

                    if(dtFeatured.Rows.Count != 0)
                    {
                        if(Request.QueryString["sc"] != null)
                        {
                            if(int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
                            {
                                if(id.ToString() == dtFeatured.Rows[0]["PSubCatID"].ToString())
                                {
                                    lblCatNamebc.Text = dtFeatured.Rows[0]["CatName"].ToString();
                                    lblCatName.Text = dtFeatured.Rows[0]["CatName"].ToString();
                                    lblAccessoryName.Text = dtFeatured.Rows[0]["SubCatName"].ToString();
                                    if(id.ToString() == dtFeatured.Rows[0]["SubCatID"].ToString())
                                    {
                                        Page.Title = dtFeatured.Rows[0]["SubCatName"].ToString() + " Products";
                                    }
                                }
                                BindBannerResults(id);
                            }
                        }
                        else if(Request.QueryString["sc"] != null)
                        {
                            if(int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
                            {
                                if (id.ToString() == dtFeatured.Rows[0]["PBrandID"].ToString())
                                {
                                    lblCatNamebc.Text = dtFeatured.Rows[0]["Name"].ToString();
                                    lblBrandName.Text = dtFeatured.Rows[0]["Name"].ToString();
                                    lblBrandName.Text = dtFeatured.Rows[0]["Name"].ToString();
                                    if(id.ToString() == dtFeatured.Rows[0]["BrandID"].ToString())
                                    {
                                        Page.Title = dtFeatured.Rows[0]["Name"].ToString() + " Products";
                                    }
                                }
                                BindBannerResults(id);
                            }
                        }
                    }
                    else
                    {
                        if(Request.QueryString["sc"] != null)
                        {
                            if(int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
                            {
                                if (id.ToString() == "19" || id.ToString() == "12" || id.ToString() == "9" || id.ToString() == "19" || id.ToString() == "5" || id.ToString() == "10" || id.ToString() == "10014" || id.ToString() == "10012")
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No Products Available for this Accessory or Brand!');window.location='Index.aspx';</script>");
                                    bdc.Visible = false;
                                    divPagination.Visible = false;
                                    divPrice.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        using (SqlConnection con = new SqlConnection(CS))
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProducts WHERE PSelPrice BETWEEN 399 AND 1000 AND (PSubCatID = '"+id+"' or PBrandID = '"+id+"')", con);
            con.Open();
            count = (int)cmd.ExecuteScalar();

            if (count == 0)
            {
                lblProductCount1.Text = " (0)";
            }
            else
            {
                lblProductCount1.Text = " (" + count.ToString() + ")";
            }
        }

        using (SqlConnection con = new SqlConnection(CS))
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProducts WHERE PSelPrice BETWEEN 1000 AND 3000 AND (PSubCatID = '" + id + "' or PBrandID = '" + id + "')", con);
            con.Open();
            count = (int)cmd.ExecuteScalar();

            if (count == 0)
            {
                lblProductCount2.Text = " (0)";
            }
            else
            {
                lblProductCount2.Text = " (" + count.ToString() + ")";
            }
        }

        using (SqlConnection con = new SqlConnection(CS))
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProducts WHERE PSelPrice BETWEEN 3000 AND 5000 AND (PSubCatID = '" + id + "' or PBrandID = '" + id + "')", con);
            con.Open();
            count = (int)cmd.ExecuteScalar();

            if (count == 0)
            {
                lblProductCount3.Text = " (0)";
            }
            else
            {
                lblProductCount3.Text = " (" + count.ToString() + ")";
            }
        }

        using (SqlConnection con = new SqlConnection(CS))
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProducts WHERE PSelPrice BETWEEN 5000 AND 10000 AND (PSubCatID = '" + id + "' or PBrandID = '" + id + "')", con);
            con.Open();
            count = (int)cmd.ExecuteScalar();

            if (count == 0)
            {
                lblProductCount4.Text = " (0)";
            }
            else
            {
                lblProductCount4.Text = " (" + count.ToString() + ")";
            }
        }

        using (SqlConnection con = new SqlConnection(CS))
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProducts WHERE PSelPrice > 10000 AND (PSubCatID = '" + id + "' or PBrandID = '" + id + "')", con);
            con.Open();
            count = (int)cmd.ExecuteScalar();

            if (count == 0)
            {
                lblProductCount5.Text = " (0)";
            }
            else
            {
                lblProductCount5.Text = " (" + count.ToString() + ")";
            }
        }
        using (SqlConnection con = new SqlConnection(CS))
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProducts WHERE (PSubCatID = '" + id + "' or PBrandID = '" + id + "')", con);
            con.Open();
            count = (int)cmd.ExecuteScalar();

            if (count == 0)
            {
                lblAllPrdCount.Text = " (0)";
            }
            else
            {
                lblAllPrdCount.Text = " (" + count.ToString() + ")";
            }
        }
    }

    protected void lb1_Click(object sender, EventArgs e)
    {
        int id = 0;
        currentposition = 0;
        if(Request.QueryString["sc"] != null)
        {
            if(int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
            {
                BindBannerResults(id);
            }
        }
    }

    protected void lb2_Click(object sender, EventArgs e)
    {
        int id = 0;
        if (currentposition == 0)
        {

        }
        else
        {
            currentposition = currentposition - 1;
            if (Request.QueryString["sc"] != null)
            {
                if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
                {
                    BindBannerResults(id);
                }
            }
        }
    }

    protected void lb3_Click(object sender, EventArgs e)
    {
        int id = 0;
        if (currentposition == totalrows - 1)
        {

        }
        else
        {
            currentposition = currentposition + 1;
            if (Request.QueryString["sc"] != null)
            {
                if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
                {
                    BindBannerResults(id);
                }
            }
        }
    }

    protected void lb4_Click(object sender, EventArgs e)
    {
        int id = 0;
        currentposition = totalrows - 1;
        if (Request.QueryString["sc"] != null)
        {
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
            {
                BindBannerResults(id);
            }
        }
    }

    protected void lbAllProducts_Click(object sender, EventArgs e)
    {
        int id = 0;
        if (Request.QueryString["sc"] != null)
        {
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
            {
                BindBannerResults(id);
            }
        }
    }

    protected void lbPrice1_Click(object sender, EventArgs e)
    {
        //Int64 SubCatID = Convert.ToInt64(Request.QueryString["sc"]);
        int id = 0;
        if (Request.QueryString["sc"] != null)
        {
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblSubCategories D ON D.SubCatID = A.PSubCatID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSelPrice BETWEEN 399 AND 1000 AND (A.PSubCatID = @Accessory or A.PBrandID = @Brands) AND A.Status = 'Publish' ORDER BY A.PID DESC", con))
                    {
                        cmd.Parameters.AddWithValue("@Accessory", id);
                        cmd.Parameters.AddWithValue("@Brands", id);
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dtProducts = new DataTable();
                            sda.Fill(dtProducts);
                            rptrProducts.DataSource = dtProducts;
                            rptrProducts.DataBind();

                            if (dtProducts.Rows.Count == 0)
                            {
                                lblNone.Text = "No Products Available for this Price Range...Sorry!";
                            }
                            else
                            {
                                if(id.ToString() == dtProducts.Rows[0]["SubCatID"].ToString())
                                {
                                    Page.Title = dtProducts.Rows[0]["SubCatName"].ToString() + " Products";
                                }
                                else if(id.ToString() == dtProducts.Rows[0]["BrandID"].ToString())
                                {
                                    Page.Title = dtProducts.Rows[0]["BrandName"].ToString() + " Products";
                                }
                            }
                        }
                    }
                }
                divPagination.Visible = false;
            }
        }
    }

    protected void lbPrice2_Click(object sender, EventArgs e)
    {
        //Int64 SubCatID = Convert.ToInt64(Request.QueryString["sc"]);
        int id = 0;
        if(Request.QueryString["sc"] != null)
        {
            if(int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblSubCategories D ON D.SubCatID = A.PSubCatID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSelPrice BETWEEN 1000 AND 3000 AND (A.PSubCatID = @Accessory or A.PBrandID = @Brands) AND A.Status = 'Publish' ORDER BY A.PID DESC", con))
                    {
                        cmd.Parameters.AddWithValue("@Accessory", id);
                        cmd.Parameters.AddWithValue("@Brands", id);
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dtProducts = new DataTable();
                            sda.Fill(dtProducts);
                            rptrProducts.DataSource = dtProducts;
                            rptrProducts.DataBind();

                            if (dtProducts.Rows.Count == 0)
                            {
                                lblNone.Text = "No Products Available for this Price Range...Sorry!";
                            }
                            else
                            {
                                if (id.ToString() == dtProducts.Rows[0]["SubCatID"].ToString())
                                {
                                    Page.Title = dtProducts.Rows[0]["SubCatName"].ToString() + " Products";
                                }
                                else if (id.ToString() == dtProducts.Rows[0]["BrandID"].ToString())
                                {
                                    Page.Title = dtProducts.Rows[0]["BrandName"].ToString() + " Products";
                                }
                            }
                        }
                    }
                }
                divPagination.Visible = false;
            }
        }
    }

    protected void lbPrice3_Click(object sender, EventArgs e)
    {
        //Int64 SubCatID = Convert.ToInt64(Request.QueryString["sc"]);
        int id = 0;
        if(Request.QueryString["sc"] != null)
        {
            if(int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblSubCategories D ON D.SubCatID = A.PSubCatID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSelPrice BETWEEN 3000 AND 5000 AND (A.PSubCatID = @Accessory or A.PBrandID = @Brands) AND A.Status = 'Publish' ORDER BY A.PID DESC", con))
                    {
                        cmd.Parameters.AddWithValue("@Accessory", id);
                        cmd.Parameters.AddWithValue("@Brands", id);
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dtProducts = new DataTable();
                            sda.Fill(dtProducts);
                            rptrProducts.DataSource = dtProducts;
                            rptrProducts.DataBind();

                            if (dtProducts.Rows.Count == 0)
                            {
                                lblNone.Text = "No Products Available for this Price Range...Sorry!";
                            }
                            else
                            {
                                if (id.ToString() == dtProducts.Rows[0]["SubCatID"].ToString())
                                {
                                    Page.Title = dtProducts.Rows[0]["SubCatName"].ToString() + " Products";
                                }
                                else if (id.ToString() == dtProducts.Rows[0]["BrandID"].ToString())
                                {
                                    Page.Title = dtProducts.Rows[0]["BrandName"].ToString() + " Products";
                                }
                            }
                        }
                    }
                }
                divPagination.Visible = false;
            }
        }
    }

    protected void lbPrice4_Click(object sender, EventArgs e)
    {
        //Int64 SubCatID = Convert.ToInt64(Request.QueryString["sc"]);
        int id = 0;
        if(Request.QueryString["sc"] != null)
        {
            if(int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblSubCategories D ON D.SubCatID = A.PSubCatID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSelPrice BETWEEN 5000 AND 10000 AND (A.PSubCatID = @Accessory or A.PBrandID = @Brands) AND A.Status = 'Publish' ORDER BY A.PID DESC", con))
                    {
                        cmd.Parameters.AddWithValue("@Accessory", id);
                        cmd.Parameters.AddWithValue("@Brands", id);
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dtProducts = new DataTable();
                            sda.Fill(dtProducts);
                            rptrProducts.DataSource = dtProducts;
                            rptrProducts.DataBind();

                            if (dtProducts.Rows.Count == 0)
                            {
                                lblNone.Text = "No Products Available for this Price Range...Sorry!";
                            }
                            else
                            {
                                if (id.ToString() == dtProducts.Rows[0]["SubCatID"].ToString())
                                {
                                    Page.Title = dtProducts.Rows[0]["SubCatName"].ToString() + " Products";
                                }
                                else if (id.ToString() == dtProducts.Rows[0]["BrandID"].ToString())
                                {
                                    Page.Title = dtProducts.Rows[0]["BrandName"].ToString() + " Products";
                                }
                            }
                        }
                    }
                }
                divPagination.Visible = false;
            }
        }
    }

    protected void lbPrice5_Click(object sender, EventArgs e)
    {
        //Int64 SubCatID = Convert.ToInt64(Request.QueryString["sc"]);
        int id = 0;
        if(Request.QueryString["sc"] != null)
        {
            if(int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["sc"].ToString()), out id))
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblSubCategories D ON D.SubCatID = A.PSubCatID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSelPrice > 10000 AND (A.PSubCatID = @Accessory or A.PBrandID = @Brands) AND A.Status = 'Publish' ORDER BY A.PID DESC", con))
                    {
                        cmd.Parameters.AddWithValue("@Accessory", id);
                        cmd.Parameters.AddWithValue("@Brands", id);
                        con.Open();
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dtProducts = new DataTable();
                            sda.Fill(dtProducts);
                            rptrProducts.DataSource = dtProducts;
                            rptrProducts.DataBind();

                            if (dtProducts.Rows.Count == 0)
                            {
                                lblNone.Text = "No Products Available for this Price Range...Sorry!";
                            }
                            else
                            {
                                if (id.ToString() == dtProducts.Rows[0]["SubCatID"].ToString())
                                {
                                    Page.Title = dtProducts.Rows[0]["SubCatName"].ToString() + " Products";
                                }
                                else if (id.ToString() == dtProducts.Rows[0]["BrandID"].ToString())
                                {
                                    Page.Title = dtProducts.Rows[0]["BrandName"].ToString() + " Products";
                                }
                            }
                        }
                    }
                }
                divPagination.Visible = false;
            }
        }
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
            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Login to add Product in Wishlist');window.location='FeaturedProducts.aspx?sc=" + Request.QueryString["sc"] + "';</script>");
        }
    }
}