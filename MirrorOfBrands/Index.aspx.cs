using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Index : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        //throw new InvalidOperationException("An InvalidOperationException " + "occured in the Page Load Handler on the Index.aspx page.");
        String imagelink;
        if(!IsPostBack)
        {
            BindNewsRptr();
            BindNewsImageRptr();
            BindSubCatlink();
            BindFeaturedImg();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM tblImageSlider ORDER BY ImageID DESC", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if(ds.Tables[0].Rows.Count > 0)
                {
                    Img1lbl1.Text = ds.Tables[0].Rows[0]["Image1Text1"].ToString();
                    Img1lbl2.Text = ds.Tables[0].Rows[0]["Image1Text2"].ToString();
                    Img1lbl3.Text = ds.Tables[0].Rows[0]["Image1Text3"].ToString();
                    btn1lbl1.Text = ds.Tables[0].Rows[0]["ButtonText1"].ToString();
                    imagelink = ds.Tables[0].Rows[0]["ImageUpload1"].ToString() + ds.Tables[0].Rows[0]["Extension1"].ToString();
                    Image1.ImageUrl = "images/HomeImageSlider/" + imagelink;

                    Img2lbl1.Text = ds.Tables[0].Rows[0]["Image2Text1"].ToString();
                    Img2lbl2.Text = ds.Tables[0].Rows[0]["Image2Text2"].ToString();
                    Img2lbl3.Text = ds.Tables[0].Rows[0]["Image2Text3"].ToString();
                    btn2lbl1.Text = ds.Tables[0].Rows[0]["ButtonText2"].ToString();
                    imagelink = ds.Tables[0].Rows[0]["ImageUpload2"].ToString() + ds.Tables[0].Rows[0]["Extension2"].ToString();
                    Image2.ImageUrl = "images/HomeImageSlider/" + imagelink;

                    Img3lbl1.Text = ds.Tables[0].Rows[0]["Image3Text1"].ToString();
                    Img3lbl2.Text = ds.Tables[0].Rows[0]["Image3Text2"].ToString();
                    Img3lbl3.Text = ds.Tables[0].Rows[0]["Image3Text3"].ToString();
                    Img3lbl4.Text = ds.Tables[0].Rows[0]["Image3Text4"].ToString();
                    btn3lbl1.Text = ds.Tables[0].Rows[0]["ButtonText3"].ToString();
                    imagelink = ds.Tables[0].Rows[0]["ImageUpload3"].ToString() + ds.Tables[0].Rows[0]["Extension3"].ToString();
                    Image3.ImageUrl = "images/HomeImageSlider/" + imagelink;
                }
            }
            // Banner Image
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM tblProductBanner ORDER BY BannerID DESC", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if(ds.Tables[0].Rows.Count > 0)
                {
                    lbl1Ban1.Text = ds.Tables[0].Rows[0]["Image1Text1"].ToString();
                    lbl2Ban1.Text = ds.Tables[0].Rows[0]["Image1Text2"].ToString();
                    imagelink = ds.Tables[0].Rows[0]["BannerImage1"].ToString() + ds.Tables[0].Rows[0]["Extension1"].ToString();
                    ImgBan1.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink;

                    lbl1Ban2.Text = ds.Tables[0].Rows[0]["Image2Text1"].ToString();
                    lbl2Ban2.Text = ds.Tables[0].Rows[0]["Image2Text2"].ToString();
                    imagelink = ds.Tables[0].Rows[0]["BannerImage2"].ToString() + ds.Tables[0].Rows[0]["Extension2"].ToString();
                    ImgBan2.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink;

                    lbl1Ban3.Text = ds.Tables[0].Rows[0]["Image3Text1"].ToString();
                    lbl2Ban3.Text = ds.Tables[0].Rows[0]["Image3Text2"].ToString();
                    lbl3Ban3.Text = ds.Tables[0].Rows[0]["Image3Text3"].ToString();
                    imagelink = ds.Tables[0].Rows[0]["BannerImage3"].ToString() + ds.Tables[0].Rows[0]["Extension3"].ToString();
                    ImgBan3.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink;

                    lbl1Ban4.Text = ds.Tables[0].Rows[0]["Image4Text1"].ToString();
                    lbl2Ban4.Text = ds.Tables[0].Rows[0]["Image4Text2"].ToString();
                    imagelink = ds.Tables[0].Rows[0]["BannerImage4"].ToString() + ds.Tables[0].Rows[0]["Extension4"].ToString();
                    ImgBan4.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink;

                    lbl1Ban5.Text = ds.Tables[0].Rows[0]["Image5Text1"].ToString();
                    lbl2Ban5.Text = ds.Tables[0].Rows[0]["Image5Text2"].ToString();
                    lbl3Ban5.Text = ds.Tables[0].Rows[0]["Image5Text3"].ToString();
                    lbl4Ban5.Text = ds.Tables[0].Rows[0]["Image5Text4"].ToString();
                    lbl5Ban5.Text = ds.Tables[0].Rows[0]["Image5Text5"].ToString();
                    imagelink = ds.Tables[0].Rows[0]["BannerImage5"].ToString() + ds.Tables[0].Rows[0]["Extension5"].ToString();
                    ImgBan5.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink;
                }
            }
        }
    }

    private void BindFeaturedImg()
    {
        String imagelink;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM tblFeatCatImg ORDER BY FCID DESC", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count != 0)
            {
                imagelink = dt.Rows[0]["Image1"].ToString() + dt.Rows[0]["Extension1"].ToString();
                Image4.ImageUrl = "images/FeaturedCategories/" + imagelink;
                Image4.AlternateText = "Clothing";

                imagelink = dt.Rows[0]["Image2"].ToString() + dt.Rows[0]["Extension2"].ToString();
                Image5.ImageUrl = "images/FeaturedCategories/" + imagelink;
                Image5.AlternateText = "Shoes";

                imagelink = dt.Rows[0]["Image3"].ToString() + dt.Rows[0]["Extension3"].ToString();
                Image6.ImageUrl = "images/FeaturedCategories/" + imagelink;
                Image6.AlternateText = "Handbag";

                imagelink = dt.Rows[0]["Image4"].ToString() + dt.Rows[0]["Extension4"].ToString();
                Image7.ImageUrl = "images/FeaturedCategories/" + imagelink;
                Image7.AlternateText = "Watches";

                imagelink = dt.Rows[0]["Image5"].ToString() + dt.Rows[0]["Extension5"].ToString();
                Image8.ImageUrl = "images/FeaturedCategories/" + imagelink;
                Image8.AlternateText = "Sunglasses";

                imagelink = dt.Rows[0]["Image6"].ToString() + dt.Rows[0]["Extension6"].ToString();
                Image9.ImageUrl = "images/FeaturedCategories/" + imagelink;
                Image9.AlternateText = "Accessories";
            }
        }
    }

    private void BindSubCatlink()
    {
        Int64 SubCatredirectlink;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubCategories WHERE SubCatID = '19'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    Handbaglink.NavigateUrl = "FeaturedProducts.aspx?sc=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString());
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubCategories WHERE SubCatID = '12'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    Clothinglink.NavigateUrl = "FeaturedProducts.aspx?sc=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString());
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubCategories WHERE SubCatID = '9'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    Shoeslink.NavigateUrl = "FeaturedProducts.aspx?sc=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString());
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubCategories WHERE SubCatID = '19'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    HandbagSL.NavigateUrl = "FeaturedProducts.aspx?sc=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString());
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubCategories WHERE SubCatID = '5'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    Watchlink.NavigateUrl = "FeaturedProducts.aspx?sc=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString());
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubCategories WHERE SubCatID = '10'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    Sglink.NavigateUrl = "FeaturedProducts.aspx?sc=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString());
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblBrands WHERE BrandID = '10014'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    Accessorylink.NavigateUrl = "FeaturedProducts.aspx?sc=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString());
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblBrands WHERE BrandID = '10012'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    Headphonelink.NavigateUrl = "FeaturedProducts.aspx?sc=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString());
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories WHERE CatID = '5'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    hlSlider1.NavigateUrl = "Products.aspx?cat=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString()); 
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories WHERE CatID = '6'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    hlSlider2.NavigateUrl = "Products.aspx?cat=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString());
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories WHERE CatID = '1'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    hlSlider3.NavigateUrl = "Products.aspx?cat=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString());
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories WHERE CatID = '6'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    hlAudio.NavigateUrl = "Products.aspx?cat=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString());
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories WHERE CatID = '5'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    hlSmartphone.NavigateUrl = "Products.aspx?cat=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString());
                }
                con.Close();
            }
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories WHERE CatID = '5'", con))
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    SubCatredirectlink = sdr.GetInt64(0);
                    hlCameras.NavigateUrl = "Products.aspx?cat=" + MirrorOfBrands.Crypto.GetencryptedQueryString(SubCatredirectlink.ToString());
                }
                con.Close();
            }
        }
    }

    private void BindNewsImageRptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT top 3 * FROM tblNews ORDER BY NewsID DESC", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtImages = new DataTable();
            sda.Fill(dtImages);
            rptrNewsImage.DataSource = dtImages;
            rptrNewsImage.DataBind();
        }
    }

    private void BindNewsRptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT top 3 * FROM tblNews ORDER BY NewsID DESC", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtNews = new DataTable();
            sda.Fill(dtNews);
            rptrNewsView.DataSource = dtNews;
            rptrNewsView.DataBind();
        }
    }

    protected string GetActiveClass(int ItemIndex)
    {
        if (ItemIndex == 0)
        {
            return "active";
        }
        else
        {
            return "";
        }
    }
}