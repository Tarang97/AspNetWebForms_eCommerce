using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class EditBanner : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        String imagelink;
        if(!IsPostBack)
        {
            if (Request.QueryString["ebid"] != null)
            {
                Int64 BID = Convert.ToInt64(Request.QueryString["ebid"]);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblProductBanner WHERE BannerID = '"+BID+"'", con);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txt1Ban1.Text = ds.Tables[0].Rows[0]["Image1Text1"].ToString();
                        txt2Ban1.Text = ds.Tables[0].Rows[0]["Image1Text2"].ToString();
                        imagelink = ds.Tables[0].Rows[0]["BannerImage1"].ToString();
                        Image1.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink + ds.Tables[0].Rows[0]["Extension1"].ToString();

                        txt1Ban2.Text = ds.Tables[0].Rows[0]["Image2Text1"].ToString();
                        txt2Ban2.Text = ds.Tables[0].Rows[0]["Image2Text2"].ToString();
                        imagelink = ds.Tables[0].Rows[0]["BannerImage2"].ToString();
                        Image2.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink + ds.Tables[0].Rows[0]["Extension2"].ToString();

                        txt1Ban3.Text = ds.Tables[0].Rows[0]["Image3Text1"].ToString();
                        txt2Ban3.Text = ds.Tables[0].Rows[0]["Image3Text2"].ToString();
                        txt3Ban3.Text = ds.Tables[0].Rows[0]["Image3Text3"].ToString();
                        imagelink = ds.Tables[0].Rows[0]["BannerImage3"].ToString();
                        Image3.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink + ds.Tables[0].Rows[0]["Extension3"].ToString();

                        txt1Ban4.Text = ds.Tables[0].Rows[0]["Image4Text1"].ToString();
                        txt2Ban4.Text = ds.Tables[0].Rows[0]["Image4Text2"].ToString();
                        imagelink = ds.Tables[0].Rows[0]["BannerImage4"].ToString();
                        Image4.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink + ds.Tables[0].Rows[0]["Extension4"].ToString();

                        txt1Ban5.Text = ds.Tables[0].Rows[0]["Image5Text1"].ToString();
                        txt2Ban5.Text = ds.Tables[0].Rows[0]["Image5Text2"].ToString();
                        txt3Ban5.Text = ds.Tables[0].Rows[0]["Image5Text3"].ToString();
                        txt4Ban5.Text = ds.Tables[0].Rows[0]["Image5Text4"].ToString();
                        txt5Ban5.Text = ds.Tables[0].Rows[0]["Image5Text5"].ToString();
                        imagelink = ds.Tables[0].Rows[0]["BannerImage5"].ToString();
                        Image5.ImageUrl = "images/HomeImageSlider/Banner Images/" + imagelink + ds.Tables[0].Rows[0]["Extension5"].ToString();
                    }
                }
            }
            else
            {
                Response.Redirect("~/ViewEditBannerImg.aspx");
            }
        }
    }

    protected void btnUpdateBanner_Click(object sender, EventArgs e)
    {
        Int64 BID = Convert.ToInt64(Request.QueryString["ebid"]);
        if(fuImgBan1.HasFile)
        {
            string SavePath = Server.MapPath("~/images/HomeImageSlider/Banner Images/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID7 = Guid.NewGuid().ToString();
            string Extension1 = Path.GetExtension(fuImgBan1.PostedFile.FileName);
            fuImgBan1.SaveAs(SavePath + "\\" + myGUID7 + Extension1);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE tblProductBanner SET Image1Text1 = '" + txt1Ban1.Text + "', Image1Text2 = '"
                    + txt2Ban1.Text + "', BannerImage1 = '" + myGUID7 + "', Extension1 = '" + Extension1 + "' WHERE BannerID = '"+BID+"'", con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ViewEditBannerImg.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd2 = new SqlCommand("UPDATE tblProductBanner SET Image1Text1 = '" + txt1Ban1.Text + "', Image1Text2 = '"
                    + txt2Ban1.Text + "' WHERE BannerID = '" + BID + "'", con);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ViewEditBannerImg.aspx");
        }
        if(fuImgBan2.HasFile)
        {
            string SavePath = Server.MapPath("~/images/HomeImageSlider/Banner Images/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID8 = Guid.NewGuid().ToString();
            string Extension2 = Path.GetExtension(fuImgBan2.PostedFile.FileName);
            fuImgBan2.SaveAs(SavePath + "\\" + myGUID8 + Extension2);

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd3 = new SqlCommand("UPDATE tblProductBanner SET Image2Text1 = '"+ txt1Ban2.Text + "', Image2Text2 = '" 
                    + txt2Ban2.Text + "', BannerImage2 = '" + myGUID8 + "', Extension2 = '" + Extension2 + "' WHERE BannerID = '"+BID+"'", con);
                con.Open();
                cmd3.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ViewEditBannerImg.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd4 = new SqlCommand("UPDATE tblProductBanner SET Image2Text1 = '" + txt1Ban2.Text + "', Image2Text2 = '"
                    + txt2Ban2.Text + "' WHERE BannerID = '" + BID + "'", con);
                con.Open();
                cmd4.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ViewEditBannerImg.aspx");
        }
        if(fuImgBan3.HasFile)
        {
            string SavePath = Server.MapPath("~/images/HomeImageSlider/Banner Images/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID9 = Guid.NewGuid().ToString();
            string Extension3 = Path.GetExtension(fuImgBan3.PostedFile.FileName);
            fuImgBan3.SaveAs(SavePath + "\\" + myGUID9 + Extension3);

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd5 = new SqlCommand("UPDATE tblProductBanner SET Image3Text1 = '"
                    + txt1Ban3.Text + "', Image3Text2 = '" + txt2Ban3.Text + "', Image3Text3 = '" + txt3Ban3.Text + "', BannerImage3 = '" + myGUID9 + "', Extension3 = '"
                    + Extension3 + "' WHERE BannerID = '"+BID+"'", con);
                con.Open();
                cmd5.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ViewEditBannerImg.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd6 = new SqlCommand("UPDATE tblProductBanner SET Image3Text1 = '"
                    + txt1Ban3.Text + "', Image3Text2 = '" + txt2Ban3.Text + "', Image3Text3 = '" + txt3Ban3.Text + "' WHERE BannerID = '" + BID + "'", con);
                con.Open();
                cmd6.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ViewEditBannerImg.aspx");
        }
        if(fuImgBan4.HasFile)
        {
            string SavePath = Server.MapPath("~/images/HomeImageSlider/Banner Images/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID10 = Guid.NewGuid().ToString();
            string Extension4 = Path.GetExtension(fuImgBan4.PostedFile.FileName);
            fuImgBan4.SaveAs(SavePath + "\\" + myGUID10 + Extension4);

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd7 = new SqlCommand("UPDATE tblProductBanner SET Image4Text1 = '" + txt1Ban4.Text + "', Image4Text2 = '" + txt2Ban4.Text + "', BannerImage4 = '" + myGUID10 + "', Extension4 = '"
                    + Extension4 + "' WHERE BannerID = '" + BID + "'", con);
                con.Open();
                cmd7.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ViewEditBannerImg.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd8 = new SqlCommand("UPDATE tblProductBanner SET Image4Text1 = '" + txt1Ban4.Text + "', Image4Text2 = '" + txt2Ban4.Text + "' WHERE BannerID = '" + BID + "'", con);
                con.Open();
                cmd8.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ViewEditBannerImg.aspx");
        }
        if(fuImgBan5.HasFile)
        {
            string SavePath = Server.MapPath("~/images/HomeImageSlider/Banner Images/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID11 = Guid.NewGuid().ToString();
            string Extension5 = Path.GetExtension(fuImgBan5.PostedFile.FileName);
            fuImgBan5.SaveAs(SavePath + "\\" + myGUID11 + Extension5);

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd9 = new SqlCommand("UPDATE tblProductBanner SET Image5Text1 = '" + txt1Ban5.Text + "', Image5Text2 = '" + txt2Ban5.Text + "', Image5Text3 = '" + txt3Ban5.Text + "', Image5Text4 = '"
                    + txt4Ban5.Text + "', Image5Text5 = '" + txt5Ban5.Text + "', BannerImage5 = '" + myGUID11 + "', Extension5 = '" + Extension5 + "' WHERE BannerID = '" + BID + "'", con);
                con.Open();
                cmd9.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ViewEditBannerImg.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd10 = new SqlCommand("UPDATE tblProductBanner SET Image5Text1 = '" + txt1Ban5.Text + "', Image5Text2 = '" + txt2Ban5.Text + "', Image5Text3 = '" + txt3Ban5.Text + "', Image5Text4 = '"
                    + txt4Ban5.Text + "', Image5Text5 = '" + txt5Ban5.Text + "' WHERE BannerID = '" + BID + "'", con);
                con.Open();
                cmd10.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ViewEditBannerImg.aspx");
        }
        if (fuImgBan1.HasFile && fuImgBan2.HasFile && fuImgBan3.HasFile && fuImgBan4.HasFile && fuImgBan5.HasFile)
        {
            string SavePath = Server.MapPath("~/images/HomeImageSlider/Banner Images/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID1 = Guid.NewGuid().ToString();
            string Extension1 = Path.GetExtension(fuImgBan1.PostedFile.FileName);
            fuImgBan1.SaveAs(SavePath + "\\" + myGUID1 + Extension1);

            String myGUID2 = Guid.NewGuid().ToString();
            string Extension2 = Path.GetExtension(fuImgBan2.PostedFile.FileName);
            fuImgBan2.SaveAs(SavePath + "\\" + myGUID2 + Extension2);

            String myGUID3 = Guid.NewGuid().ToString();
            string Extension3 = Path.GetExtension(fuImgBan3.PostedFile.FileName);
            fuImgBan3.SaveAs(SavePath + "\\" + myGUID3 + Extension3);

            String myGUID4 = Guid.NewGuid().ToString();
            string Extension4 = Path.GetExtension(fuImgBan4.PostedFile.FileName);
            fuImgBan4.SaveAs(SavePath + "\\" + myGUID4 + Extension4);

            String myGUID5 = Guid.NewGuid().ToString();
            string Extension5 = Path.GetExtension(fuImgBan5.PostedFile.FileName);
            fuImgBan5.SaveAs(SavePath + "\\" + myGUID5 + Extension5);

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblProductBanner SET Image1Text1 = '"+txt1Ban1.Text+"', Image1Text2 = '"
                    +txt2Ban1.Text+"', BannerImage1 = '"+ myGUID1 + "', Extension1 = '"+Extension1+"', Image2Text1 = '"
                    +txt1Ban2.Text+"', Image2Text2 = '"+txt2Ban2.Text+"', BannerImage2 = '"+ myGUID2 + "', Extension2 = '"+Extension2+"', Image3Text1 = '"
                    +txt1Ban3.Text+"', Image3Text2 = '"+txt2Ban3.Text+"', Image3Text3 = '"+txt3Ban3.Text+"', BannerImage3 = '"+ myGUID3 + "', Extension3 = '"
                    +Extension3+"', Image4Text1 = '"+txt1Ban4.Text+"', Image4Text2 = '"+txt2Ban4.Text+"', BannerImage4 = '"+ myGUID4 + "', Extension4 = '"
                    +Extension4+"', Image5Text1 = '"+txt1Ban5.Text+"', Image5Text2 = '"+txt2Ban5.Text+"', Image5Text3 = '"+txt3Ban5.Text+"', Image5Text4 = '"
                    +txt4Ban5.Text+"', Image5Text5 = '"+txt5Ban5.Text+"', BannerImage5 = '"+ myGUID5 + "', Extension5 = '"+Extension5+"' WHERE BannerID = '"+BID+"'", con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("~/ViewEditBannerImg.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd11 = new SqlCommand("UPDATE tblProductBanner SET Image1Text1 = '" + txt1Ban1.Text + "', Image1Text2 = '"
                    + txt2Ban1.Text + "', Image2Text1 = '" + txt1Ban2.Text + "', Image2Text2 = '" + txt2Ban2.Text + "', Image3Text1 = '"
                    + txt1Ban3.Text + "', Image3Text2 = '" + txt2Ban3.Text + "', Image3Text3 = '" + txt3Ban3.Text + "', Image4Text1 = '" 
                    + txt1Ban4.Text + "', Image4Text2 = '" + txt2Ban4.Text + "', Image5Text1 = '" + txt1Ban5.Text + "', Image5Text2 = '" 
                    + txt2Ban5.Text + "', Image5Text3 = '" + txt3Ban5.Text + "', Image5Text4 = '" + txt4Ban5.Text + "', Image5Text5 = '" 
                    + txt5Ban5.Text + "' WHERE BannerID = '" + BID + "'", con);
                con.Open();
                cmd11.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("~/ViewEditBannerImg.aspx");
        }
    }
}