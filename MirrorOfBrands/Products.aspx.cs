using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products : System.Web.UI.Page
{
    static int currentposition = 0;
    static int totalrows = 0;
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCartItems();
            BindCartCount();
            BindProductPgSlider();
            dttags.Visible = false;
            ddtags.Visible = false;

            int id = 0;
            if (Request.QueryString["cat"] != null)
            {
                if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
                {
                    SelectData(id);
                }
            }
            else
            {
                Response.Redirect("~/Index.aspx");
            }
        }
    }

    private void SelectData(int id)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT A.*,B.* FROM tblProducts A INNER JOIN tblCategories B ON B.CatID = A.PCategoryID WHERE A.PCategoryID = @Category AND A.Status = 'Publish'", con);
            cmd.Parameters.AddWithValue("@Category", id);
            con.Open();

            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dtProducts = new DataTable();
                sda.SelectCommand = cmd;
                sda.Fill(dtProducts);

                if (dtProducts.Rows.Count != 0)
                {
                    //if (Request.QueryString["cat"] == dtProducts.Rows[0]["PCategoryID"].ToString())
                    if(Request.QueryString["cat"] != null)
                    {
                        if(int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
                        {
                            if(id.ToString() == dtProducts.Rows[0]["PCategoryID"].ToString())
                            {
                                lblCatName.Text = dtProducts.Rows[0]["CatName"].ToString();
                                lblCatNamebc.Text = dtProducts.Rows[0]["CatName"].ToString();
                                //if(id.ToString() == dtProducts.Rows[0]["CatID"].ToString())
                                //{
                                //    Page.Title = dtProducts.Rows[0]["CatName"].ToString() + " Products";
                                //}
                            }
                            BindMenCategory(id);
                        }
                    }
                }
                else
                {
                    if (Request.QueryString["cat"] != null)
                    {
                        if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
                        {
                            if(id.ToString() == "1" || id.ToString() == "4" || id.ToString() == "5" || id.ToString() == "6" || id.ToString() == "7")
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('No Products Available for this Category!');window.location='Index.aspx';</script>");
                                divPagination.Visible = false;
                                imgSlider.Visible = false;
                                bdc.Visible = false;
                                filters.Visible = false;
                            }
                        }
                    }
                }
            }
        }

        using (SqlConnection con = new SqlConnection(CS))
        {
            int count = 0;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProducts WHERE PSelPrice BETWEEN 399 AND 1000 AND PCategoryID = '" + id + "'", con);
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
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProducts WHERE PSelPrice BETWEEN 1000 AND 3000 AND PCategoryID = '" + id + "'", con);
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
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProducts WHERE PSelPrice BETWEEN 3000 AND 5000 AND PCategoryID = '" + id + "'", con);
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
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProducts WHERE PSelPrice BETWEEN 5000 AND 10000 AND PCategoryID = '" + id + "'", con);
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
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProducts WHERE PSelPrice > 10000 AND PCategoryID = '" + id + "'", con);
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
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProducts WHERE PCategoryID = '" + id + "'", con);
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

    private void BindProductPgSlider()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        String imagelink;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblProductPgSlider", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblImg1Txt1.Text = ds.Tables[0].Rows[0]["Text1Img1"].ToString();
                lblImg1Txt2.Text = ds.Tables[0].Rows[0]["Text2Img1"].ToString();
                lblImg1Txt3.Text = ds.Tables[0].Rows[0]["Text3Img1"].ToString();
                imagelink = ds.Tables[0].Rows[0]["Image1"].ToString();
                Image1.ImageUrl = "images/ProductPgSlider/" + imagelink + ds.Tables[0].Rows[0]["Extension1"].ToString();

                lblImg2Txt1.Text = ds.Tables[0].Rows[0]["Text1Img2"].ToString();
                lblImg2Txt2.Text = ds.Tables[0].Rows[0]["Text2Img2"].ToString();
                lblImg2Txt3.Text = ds.Tables[0].Rows[0]["Text3Img2"].ToString();
                imagelink = ds.Tables[0].Rows[0]["Image2"].ToString();
                Image2.ImageUrl = "images/ProductPgSlider/" + imagelink + ds.Tables[0].Rows[0]["Extension2"].ToString();

                lblImg3Txt1.Text = ds.Tables[0].Rows[0]["Text1Img3"].ToString();
                lblImg3Txt2.Text = ds.Tables[0].Rows[0]["Text2Img3"].ToString();
                lblImg3Txt3.Text = ds.Tables[0].Rows[0]["Text3Img3"].ToString();
                imagelink = ds.Tables[0].Rows[0]["Image3"].ToString() + ds.Tables[0].Rows[0]["Extension3"].ToString();
                Image3.ImageUrl = "images/ProductPgSlider/" + imagelink;
            }
        }
    }

    private void BindMenCategory(int id)
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblCategories D ON D.CatID = A.PCategoryID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PCategoryID = @MenCategory AND A.Status = 'Publish' ORDER BY A.PID DESC", con))
            {
                cmd.Parameters.AddWithValue("@MenCategory", id);
                cmd.CommandType = CommandType.Text;
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
                    if(ds.Tables[0].Rows.Count > 0)
                    {
                        if(id.ToString() == ds.Tables[0].Rows[0]["CatID"].ToString())
                        {
                            Page.Title = ds.Tables[0].Rows[0]["CatName"].ToString() + " Products";
                        }
                    }
                }
            }
        }
        BindProductBrands(id);
        BindSubCategories(id);
    }

    private void BindSubCategories(int id)
    {
        //Int64 SCID = Convert.ToInt64(Request.QueryString["cat"]);
        if (Request.QueryString["cat"] != null)
        {
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
            {
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubCategories WHERE MainCatID = @MainCategory", con);
                    cmd.Parameters.AddWithValue("@MainCategory", id);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrAccessories.DataSource = dt;
                    rptrAccessories.DataBind();
                    //if (dt.Rows.Count != 0)
                    //{
                    //    cblAccessories.DataSource = dt;
                    //    cblAccessories.DataTextField = "SubCatName";
                    //    cblAccessories.DataValueField = "SubCatID";
                    //    cblAccessories.DataBind();
                    //}
                    //else
                    //{
                    //    lblnull.Text = "No Accessories";
                    //}
                }
            }
        }
    }

    private void BindProductBrands(int id)
    {
        //Int64 CatID = Convert.ToInt64(Request.QueryString["cat"]);
        if(Request.QueryString["cat"] != null)
        {
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
            {
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblBrands WHERE MainCatID = @Category", con);
                    cmd.Parameters.AddWithValue("@Category", id);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count != 0)
                    {
                        cblBrands.DataSource = dt;
                        cblBrands.DataTextField = "Name";
                        cblBrands.DataValueField = "BrandID";
                        cblBrands.DataBind();
                    }
                }
            }
        }
    }

    //private void BindProductRepeater()
    //{
    //    String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    //    using (SqlConnection con = new SqlConnection(CS))
    //    {
    //        using (SqlCommand cmd = new SqlCommand("procBindAllProducts", con))
    //        {
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            con.Open();
    //            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
    //            {
    //                DataSet ds = new DataSet();
    //                sda.Fill(ds);
    //                totalrows = ds.Tables[0].Rows.Count;
    //                DataTable dt = ds.Tables[0];
    //                PagedDataSource pg = new PagedDataSource();
    //                pg.DataSource = dt.DefaultView;
    //                pg.AllowPaging = true;
    //                pg.CurrentPageIndex = currentposition;
    //                pg.PageSize = 12;
    //                lb1.Enabled = !pg.IsFirstPage;
    //                lb2.Enabled = !pg.IsFirstPage;
    //                lb3.Enabled = !pg.IsLastPage;
    //                lb4.Enabled = !pg.IsLastPage;
    //                //Binding pg to Repeater
    //                rptrProducts.DataSource = pg;
    //                rptrProducts.DataBind();
    //                //DataTable dtBrands = new DataTable();
    //                //sda.Fill(dtBrands);
    //                //rptrProducts.DataSource = dtBrands;
    //                //rptrProducts.DataBind();
    //            }
    //        }
    //    }
    //}

    protected void lb1_Click(object sender, EventArgs e)
    {
        int id = 0;
        currentposition = 0;
        if (Request.QueryString["cat"] != null)
        {
            //Int64 CategoryName = Convert.ToInt64(Request.QueryString["cat"]);
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
            {
                BindMenCategory(id);
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
            if (Request.QueryString["cat"] != null)
            {
                //Int64 CategoryName = Convert.ToInt64(Request.QueryString["cat"]);
                if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
                {
                    BindMenCategory(id);
                }
            }
            //BindMenCategory(id);
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
            if (Request.QueryString["cat"] != null)
            {
                //Int64 CategoryName = Convert.ToInt64(Request.QueryString["cat"]);
                if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
                {
                    BindMenCategory(id);
                }
            }
            //BindMenCategory(id);
        }
    }

    protected void lb4_Click(object sender, EventArgs e)
    {
        int id = 0;
        currentposition = totalrows - 1;
        if (Request.QueryString["cat"] != null)
        {
            //Int64 CategoryName = Convert.ToInt64(Request.QueryString["cat"]);
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
            {
                BindMenCategory(id);
            }
        }
        //BindMenCategory(id);
    }

    protected void lbPrice1_Click(object sender, EventArgs e)
    {
        int id = 0;
        if (Request.QueryString["cat"] != null)
        {
            //Int64 CategoryName = Convert.ToInt64(Request.QueryString["cat"]);
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
            {
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblCategories D ON D.CatID = A.PCategoryID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSelPrice BETWEEN 399 AND 1000 AND A.PCategoryID = @CategoryP AND A.Status = 'Publish' ORDER BY A.PID DESC", con);
                    cmd.Parameters.AddWithValue("@CategoryP", id);
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
                            if (id.ToString() == dtProducts.Rows[0]["CatID"].ToString())
                            {
                                Page.Title = dtProducts.Rows[0]["CatName"].ToString() + " Products: ₹399 - ₹1000";
                            }
                        }
                    }
                }
                divPagination.Visible = false;
                lblBrandName.Text = "";
                lblAccessoryName.Text = "";
            }
        }
    }

    protected void lbPrice2_Click(object sender, EventArgs e)
    {
        int id = 0;
        if (Request.QueryString["cat"] != null)
        {
            //Int64 CategoryName = Convert.ToInt64(Request.QueryString["cat"]);
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
            {
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblCategories D ON D.CatID = A.PCategoryID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSelPrice BETWEEN 1000 AND 3000 AND A.PCategoryID = @CategoryP AND A.Status = 'Publish' ORDER BY A.PID DESC", con);
                    cmd.Parameters.AddWithValue("@CategoryP", id);
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
                            if (id.ToString() == dtProducts.Rows[0]["CatID"].ToString())
                            {
                                Page.Title = dtProducts.Rows[0]["CatName"].ToString() + " Products: ₹1000 - ₹3000";
                            }
                        }
                    }
                }
                divPagination.Visible = false;
                lblBrandName.Text = "";
                lblAccessoryName.Text = "";
            }
        }
    }

    protected void lbPrice3_Click(object sender, EventArgs e)
    {
        int id = 0;
        if (Request.QueryString["cat"] != null)
        {
            //Int64 CategoryName = Convert.ToInt64(Request.QueryString["cat"]);
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
            {
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblCategories D ON D.CatID = A.PCategoryID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSelPrice BETWEEN 3000 AND 5000 AND AND A.PCategoryID = @CategoryP AND A.Status = 'Publish' ORDER BY A.PID DESC", con);
                    cmd.Parameters.AddWithValue("@CategoryP", id);
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
                            if (id.ToString() == dtProducts.Rows[0]["CatID"].ToString())
                            {
                                Page.Title = dtProducts.Rows[0]["CatName"].ToString() + " Products: ₹3000 - ₹5000";
                            }
                        }
                    }
                }
                divPagination.Visible = false;
                lblBrandName.Text = "";
                lblAccessoryName.Text = "";
            }
        }
    }

    protected void lbPrice4_Click(object sender, EventArgs e)
    {
        int id = 0;
        if (Request.QueryString["cat"] != null)
        {
            //Int64 CategoryName = Convert.ToInt64(Request.QueryString["cat"]);
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
            {
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblCategories D ON D.CatID = A.PCategoryID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSelPrice BETWEEN 5000 AND 10000 AND AND A.PCategoryID = @CategoryP AND A.Status = 'Publish' ORDER BY A.PID DESC", con);
                    cmd.Parameters.AddWithValue("@CategoryP", id);
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
                            if (id.ToString() == dtProducts.Rows[0]["CatID"].ToString())
                            {
                                Page.Title = dtProducts.Rows[0]["CatName"].ToString() + " Products: ₹5000 - ₹10,000";
                            }
                        }
                    }
                }
                divPagination.Visible = false;
                lblBrandName.Text = "";
                lblAccessoryName.Text = "";
            }
        }
    }

    protected void lbPrice5_Click(object sender, EventArgs e)
    {
        int id = 0;
        if (Request.QueryString["cat"] != null)
        {
            //Int64 CategoryName = Convert.ToInt64(Request.QueryString["cat"]);
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
            {
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblCategories D ON D.CatID = A.PCategoryID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSelPrice > 10000 AND A.PCategoryID = @CategoryP AND A.Status = 'Publish' ORDER BY A.PID DESC", con);
                    cmd.Parameters.AddWithValue("@CategoryP", id);
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
                            if (id.ToString() == dtProducts.Rows[0]["CatID"].ToString())
                            {
                                Page.Title = dtProducts.Rows[0]["CatName"].ToString() + " Products: ₹10,000 and above";
                            }
                        }
                    }
                }
                divPagination.Visible = false;
                lblBrandName.Text = "";
                lblAccessoryName.Text = "";
            }
        }
    }

    protected void cblBrands_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = 0;
        hfBrand.Value = string.Empty;
        if (Request.QueryString["cat"] != null)
        {
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
            {
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        if (cblBrands.SelectedItem != null)
                        {
                            SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PBrandID = " + cblBrands.SelectedItem.Value + " AND A.PCategoryID = '" + id + "' AND A.Status = 'Publish' ORDER BY A.PID DESC", con);
                            con.Open();
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                sda.Fill(dt);
                                rptrProducts.DataSource = dt;
                                rptrProducts.DataBind();

                                lblBrandName.Text = (cblBrands.SelectedItem == null ? "" : cblBrands.SelectedItem.Text);
                                hfBrand.Value = cblBrands.SelectedItem.Value;

                                if (dt.Rows.Count == 0)
                                {
                                    lblNone.Text = "No products available for this Mens Brand or a Accessories...Sorry!";
                                    divPagination.Visible = false;
                                    Page.Title = lblBrandName.Text;
                                }
                                else
                                {
                                    divPagination.Visible = false;
                                    Page.Title = lblBrandName.Text;

                                    StringBuilder items = new StringBuilder();
                                    foreach (ListItem item in cblBrands.Items)
                                    {
                                        if (item.Selected == true)
                                        {
                                            Tags.Text = lblBrandName.Text;
                                        }
                                    }
                                    lblNone.Text = "";
                                    lblAccessoryName.Text = "";
                                    ddtags.Visible = true;
                                    dttags.Visible = true;
                                }
                            }
                            cblBrands.ClearSelection();
                        }
                        else
                        {
                            BindMenCategory(id);
                            lblBrandName.Text = "";
                            lblAccessoryName.Text = "";
                            lblNone.Text = "";
                            divPagination.Visible = true;
                        }
                    }
                }     
            }
    }

    //protected void cblAccessories_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int id = 0;
    //    cblBrands.SelectedItem.Selected = true;
    //    if(Request.QueryString["cat"] != null)
    //    {
    //        if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
    //        {
    //            String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    //            using (SqlConnection con = new SqlConnection(CS))
    //            {
    //                if (cblAccessories.SelectedItem != null)
    //                {
    //                    SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblSubCategories D ON D.SubCatID = A.PSubCatID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSubCatID = '" + cblAccessories.SelectedItem.Value + "' AND A.PCategoryID = '" + id + "' ORDER BY A.PID DESC", con);
    //                    con.Open();
    //                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
    //                    {
    //                        DataTable dt = new DataTable();
    //                        sda.Fill(dt);
    //                        rptrProducts.DataSource = dt;
    //                        rptrProducts.DataBind();

    //                        lblAccessoryName.Text = (cblAccessories.SelectedItem == null ? "" : cblAccessories.SelectedItem.Text);

    //                        if (dt.Rows.Count == 0)
    //                        {
    //                            lblNone.Text = "No Products available for this Mens Accessories or a Brand...Sorry!";
    //                            divPagination.Visible = false;
    //                            Page.Title = lblAccessoryName.Text;
    //                        }
    //                        else
    //                        {
    //                            divPagination.Visible = false;
    //                            Page.Title = lblAccessoryName.Text;

    //                            //Cascading
    //                            SqlCommand cmd1 = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblSubCategories D ON D.SubCatID = A.PSubCatID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSubCatID = '" + cblAccessories.SelectedItem.Value + "' AND A.PBrandID = '" + cblBrands.SelectedItem.Value + "' AND A.PCategoryID = '" + id + "' ORDER BY A.PID DESC", con);
    //                            using (SqlDataAdapter sda1 = new SqlDataAdapter(cmd1))
    //                            {
    //                                DataTable dtBind = new DataTable();
    //                                sda1.Fill(dtBind);
    //                                rptrProducts.DataSource = dtBind;
    //                                rptrProducts.DataBind();

    //                                lblAccessoryName.Text = (cblBrands.SelectedItem == null && cblAccessories.SelectedItem == null ? "" : cblBrands.SelectedItem.Text + " - " + cblAccessories.SelectedItem.Text);
    //                                if (dtBind.Rows.Count == 0)
    //                                {
    //                                    lblNone.Text = "No Products available for this particular Brand and Accessory!";
    //                                    divPagination.Visible = false;
    //                                    Page.Title = lblAccessoryName.Text;
    //                                }
    //                                else
    //                                {
    //                                    divPagination.Visible = false;
    //                                    Page.Title = lblAccessoryName.Text;
    //                                }
    //                            }
    //                        }
    //                    }
    //                    cblBrands.Enabled = false;
    //                }
    //                else
    //                {
    //                    BindMenCategory(id);
    //                    lblAccessoryName.Text = "";
    //                    lblBrandName.Text = "";
    //                    lblNone.Text = "";
    //                    divPagination.Visible = true;
    //                    cblBrands.Enabled = true;
    //                }
    //            }
    //            //cblAccessories.SelectedItem.Selected = false;
    //        }
    //    }
    //}

    private void BindCartCount()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
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
                    spanNoItems.InnerText = "There are no Item(s) in your Cart";
                }
                else
                {
                    spanNoItems.InnerText = "Recent Cart Item(s): "+count.ToString() + " Products";
                }
            }
        }
        else
        {
            spanNoItems.InnerText = "There are no Item(s) in your Cart";
            divCheckoutBtn.Visible = false;
        }

    }

    private void BindCartItems()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
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
                        strongTotal.InnerText = "Cart Total ₹. " + Total.ToString();
                    }
                }
                else
                {
                    divCheckoutBtn.Visible = false;
                }
                rptrCart.DataSource = dtCart;
                rptrCart.DataBind();
            }
        }
        else
        {
            divCheckoutBtn.Visible = false;
        }
    }

    protected void lbDelete_Click(object sender, EventArgs e)
    {
        if(Session["USERID"] != null)
        {
            LinkButton btn = (LinkButton)(sender);
            string UniqueID = btn.CommandArgument;

            String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tblCart WHERE UniqueID = @UID", con);
                cmd.Parameters.AddWithValue("@UID", UniqueID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("Products.aspx?cat=" + Request.QueryString["cat"]);
        }
    }

    protected void lbAllProducts_Click(object sender, EventArgs e)
    {
        int id = 0;
        if (Request.QueryString["cat"] != null)
        {
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
            {
                BindMenCategory(id);
            }
        }
        lblBrandName.Text = "";
        lblAccessoryName.Text = "";
        divPagination.Visible = true;
    }

    protected void lbWishlist_Click(object sender, EventArgs e)
    {
        if(Session["EMAIL"] != null)
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
            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Login to add Product in Wishlist');window.location='Products.aspx?cat=" + Request.QueryString["cat"] + "';</script>");
        }
    }

    protected void lbAccessory_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)(sender);
        string SubCatID = btn.CommandArgument;
        int id = 0;
        hfAccessory.Value = string.Empty;

        if (Request.QueryString["cat"] != null)
        {
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
            {
                string SelectedAccessory = string.Empty;
                foreach (RepeaterItem item in rptrAccessories.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        var Accessory = item.FindControl("lbAccessory") as LinkButton;
                        SelectedAccessory = Accessory.CommandArgument;
                    }
                }
                using (SqlConnection con = new SqlConnection(CS))
                {
                    if(hfBrand.Value == "")
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblSubCategories D ON D.SubCatID = A.PSubCatID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSubCatID = '" + SubCatID + "' AND A.PCategoryID = '" + id + "' AND A.Status = 'Publish' ORDER BY A.PID DESC", con))
                        {
                            con.Open();
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dtSubCat = new DataTable();
                                sda.Fill(dtSubCat);
                                rptrProducts.DataSource = dtSubCat;
                                rptrProducts.DataBind();

                                hfAccessory.Value = SelectedAccessory;

                                if (dtSubCat.Rows.Count == 0)
                                {
                                    lblNone.Text = "No Products available for this particular Brand and Accessory!";
                                    divPagination.Visible = false;
                                    Page.Title = lblNone.Text;
                                }
                                else
                                {
                                    divPagination.Visible = false;
                                    if (SubCatID == dtSubCat.Rows[0]["PSubCatID"].ToString())
                                    {
                                        lblAccessoryName.Text = dtSubCat.Rows[0]["SubCatName"].ToString();
                                        Page.Title = lblAccessoryName.Text;
                                    }
                                    lblNone.Text = "";
                                }
                            }
                        }
                    }
                    else
                    {
                        using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.Name,A.PPrice-A.PSelPrice AS DiscAmount,B.Name AS ImageName,C.Name as BrandName,D.*,E.* FROM tblProducts A INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblSubCategories D ON D.SubCatID = A.PSubCatID INNER JOIN tblCategories E ON E.CatID = A.PCategoryID CROSS APPLY(SELECT top 1 * FROM tblProductImages B WHERE B.PID = A.PID ORDER BY B.PID DESC) B WHERE A.PSubCatID = '" + SubCatID + "' AND A.PBrandID = '"+hfBrand.Value+"' AND A.PCategoryID = '" + id + "' AND A.Status = 'Publish' ORDER BY A.PID DESC", con))
                        {
                            con.Open();
                            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                            {
                                DataTable dtSubCat = new DataTable();
                                sda.Fill(dtSubCat);
                                rptrProducts.DataSource = dtSubCat;
                                rptrProducts.DataBind();

                                hfAccessory.Value = SelectedAccessory;

                                if (dtSubCat.Rows.Count == 0)
                                {
                                    lblNone.Text = "No Products available for this particular Brand and Accessory!";
                                    divPagination.Visible = false;
                                    Page.Title = lblNone.Text;
                                }
                                else
                                {
                                    divPagination.Visible = false;
                                    if (id.ToString() == dtSubCat.Rows[0]["PCategoryID"].ToString() && SubCatID == dtSubCat.Rows[0]["PSubCatID"].ToString() && hfBrand.Value == dtSubCat.Rows[0]["PBrandID"].ToString())
                                    {
                                        lblAccessoryName.Text = dtSubCat.Rows[0]["BrandName"].ToString()+" - "+dtSubCat.Rows[0]["SubCatName"].ToString();
                                        Page.Title = dtSubCat.Rows[0]["CatName"].ToString() + " - " + lblAccessoryName.Text;
                                    }
                                    lblNone.Text = "";
                                }
                            }
                        }
                    }                   
                }
            }
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        int id = 0;
        if(Request.QueryString["cat"] != null)
        {
            if(int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["cat"].ToString()), out id))
            {
                BindMenCategory(id);
            }
            dttags.Visible = false;
            ddtags.Visible = false;
            lblBrandName.Text = "";
            lblAccessoryName.Text = "";
            lblNone.Text = "";
            hfBrand.Value = string.Empty;
            hfAccessory.Value = string.Empty;
            Tags.Text = string.Empty;
            divPagination.Visible = true;
        }
    }
}
