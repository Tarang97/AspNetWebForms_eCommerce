using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class ViewEditBannerImg : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        String imagelink;
        String redirectlink;
        if(!IsPostBack)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblProductBanner", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Label1.Text = ds.Tables[0].Rows[0]["BannerID"].ToString();
                    Label2.Text = ds.Tables[0].Rows[0]["Image1Text1"].ToString();
                    Label3.Text = ds.Tables[0].Rows[0]["Image1Text2"].ToString();
                    imagelink = ds.Tables[0].Rows[0]["BannerImage1"].ToString(); 
                    Image1.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink + ds.Tables[0].Rows[0]["Extension1"].ToString();
                    Label4.Text = ds.Tables[0].Rows[0]["Extension1"].ToString();

                    Label5.Text = ds.Tables[0].Rows[0]["Image2Text1"].ToString();
                    Label6.Text = ds.Tables[0].Rows[0]["Image2Text2"].ToString();
                    imagelink = ds.Tables[0].Rows[0]["BannerImage2"].ToString();
                    Image2.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink + ds.Tables[0].Rows[0]["Extension2"].ToString();
                    Label7.Text = ds.Tables[0].Rows[0]["Extension2"].ToString();

                    Label8.Text = ds.Tables[0].Rows[0]["Image3Text1"].ToString();
                    Label9.Text = ds.Tables[0].Rows[0]["Image3Text2"].ToString();
                    Label10.Text = ds.Tables[0].Rows[0]["Image3Text3"].ToString();
                    imagelink = ds.Tables[0].Rows[0]["BannerImage3"].ToString();
                    Image3.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink + ds.Tables[0].Rows[0]["Extension3"].ToString();
                    Label11.Text = ds.Tables[0].Rows[0]["Extension3"].ToString();

                    Label12.Text = ds.Tables[0].Rows[0]["Image4Text1"].ToString();
                    Label13.Text = ds.Tables[0].Rows[0]["Image4Text2"].ToString();
                    imagelink = ds.Tables[0].Rows[0]["BannerImage4"].ToString();
                    Image4.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink + ds.Tables[0].Rows[0]["Extension4"].ToString();
                    Label14.Text = ds.Tables[0].Rows[0]["Extension4"].ToString();

                    Label15.Text = ds.Tables[0].Rows[0]["Image5Text1"].ToString();
                    Label16.Text = ds.Tables[0].Rows[0]["Image5Text2"].ToString();
                    Label17.Text = ds.Tables[0].Rows[0]["Image5Text3"].ToString();
                    Label18.Text = ds.Tables[0].Rows[0]["Image5Text4"].ToString();
                    Label19.Text = ds.Tables[0].Rows[0]["Image5Text5"].ToString();
                    imagelink = ds.Tables[0].Rows[0]["BannerImage5"].ToString();
                    Image5.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink + ds.Tables[0].Rows[0]["Extension5"].ToString();
                    Label20.Text = ds.Tables[0].Rows[0]["Extension5"].ToString();

                    redirectlink = ds.Tables[0].Rows[0]["BannerID"].ToString();
                    HyperLink1.NavigateUrl = "EditBanner.aspx?ebid=" + redirectlink;
                }
            }
        }
    }
}