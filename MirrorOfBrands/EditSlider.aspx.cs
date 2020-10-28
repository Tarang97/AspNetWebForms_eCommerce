using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

public partial class EditSlider : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        String imagelink;
        if(!IsPostBack)
        {
            if(Request.QueryString["esid"] != null)
            {
                Int64 ESID = Convert.ToInt64(Request.QueryString["esid"]);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblImageSlider WHERE ImageID = '"+ESID+"'", con);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if(ds.Tables[0].Rows.Count > 0)
                    {
                        Img1txt1.Text = ds.Tables[0].Rows[0]["Image1Text1"].ToString();
                        Img1txt2.Text = ds.Tables[0].Rows[0]["Image1Text2"].ToString();
                        Img1txt3.Text = ds.Tables[0].Rows[0]["Image1Text3"].ToString();
                        btn1txt.Text = ds.Tables[0].Rows[0]["ButtonText1"].ToString();
                        imagelink = ds.Tables[0].Rows[0]["ImageUpload1"].ToString() + ds.Tables[0].Rows[0]["Extension1"].ToString();
                        Image1.ImageUrl = "images/HomeImageSlider/" + imagelink;

                        Img2txt1.Text = ds.Tables[0].Rows[0]["Image2Text1"].ToString();
                        Img2txt2.Text = ds.Tables[0].Rows[0]["Image2Text2"].ToString();
                        Img2txt3.Text = ds.Tables[0].Rows[0]["Image2Text3"].ToString();
                        btn2txt.Text = ds.Tables[0].Rows[0]["ButtonText2"].ToString();
                        imagelink = ds.Tables[0].Rows[0]["ImageUpload2"].ToString() + ds.Tables[0].Rows[0]["Extension2"].ToString();
                        Image2.ImageUrl = "images/HomeImageSlider/" + imagelink;

                        Img3txt1.Text = ds.Tables[0].Rows[0]["Image3Text1"].ToString();
                        Img3txt2.Text = ds.Tables[0].Rows[0]["Image3Text2"].ToString();
                        Img3txt3.Text = ds.Tables[0].Rows[0]["Image3Text3"].ToString();
                        Img3txt4.Text = ds.Tables[0].Rows[0]["Image3Text4"].ToString();
                        btn3txt.Text = ds.Tables[0].Rows[0]["ButtonText3"].ToString();
                        imagelink = ds.Tables[0].Rows[0]["ImageUpload3"].ToString() + ds.Tables[0].Rows[0]["Extension3"].ToString();
                        Image3.ImageUrl = "images/HomeImageSlider/" + imagelink;
                    }
                }
            }
            else
            {
                Response.Redirect("~/ViewEditImgSlider.aspx");
            }
        }
    }

    protected void btnUpdateImage_Click(object sender, EventArgs e)
    {
        Int64 ESID = Convert.ToInt64(Request.QueryString["esid"]);
        if(fuImg1.HasFile)
        {
            String myGUID = Guid.NewGuid().ToString();
            string SavePath = Server.MapPath("~/images/HomeImageSlider/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extension1 = Path.GetExtension(fuImg1.PostedFile.FileName);
            fuImg1.SaveAs(SavePath + "\\" + myGUID + Extension1);

            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd1 = new SqlCommand("UPDATE tblImageSlider SET Image1Text1 = '" +
                    Img1txt1.Text.Trim() + "', Image1Text2 = '" + Img1txt2.Text.Trim() + "', Image1Text3 = '" + Img1txt3.Text.Trim()
                    + "', ButtonText1 = '" + btn1txt.Text.Trim() + "', ImageUpload1 = '" + myGUID + "', Extension1 = '" + Extension1
                    + "' WHERE ImageID = '"+ESID+"'", con))
                {
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("~/ViewEditImgSlider.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd4 = new SqlCommand("UPDATE tblImageSlider SET Image1Text1 = '" +
                    Img1txt1.Text.Trim() + "', Image1Text2 = '" + Img1txt2.Text.Trim() + "', Image1Text3 = '" + Img1txt3.Text.Trim()
                    + "', ButtonText1 = '" + btn1txt.Text.Trim() + "' WHERE ImageID = '" + ESID + "'", con);
                con.Open();
                cmd4.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("~/ViewEditImgSlider.aspx");
        }
        if(fuImg2.HasFile)
        {
            string SavePath = Server.MapPath("~/images/HomeImageSlider/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID = Guid.NewGuid().ToString();
            string Extension2 = Path.GetExtension(fuImg2.PostedFile.FileName);
            fuImg2.SaveAs(SavePath + "\\" + myGUID + Extension2);

            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd2 = new SqlCommand("UPDATE tblImageSlider SET Image2Text1 = '" + Img2txt1.Text.Trim() + "', Image2Text2 = '" + Img2txt2.Text.Trim() + "', Image2Text3 = '" + Img2txt3.Text.Trim()
                    + "', ButtonText2 = '" + btn2txt.Text.Trim() + "', ImageUpload2 = '" + myGUID + "', Extension2 = '" + Extension2
                    + "' WHERE ImageID = '"+ESID+"'", con))
                {
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("~/ViewEditImgSlider.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd5 = new SqlCommand("UPDATE tblImageSlider SET Image2Text1 = '" + Img2txt1.Text.Trim() + "', Image2Text2 = '" + Img2txt2.Text.Trim() + "', Image2Text3 = '" + Img2txt3.Text.Trim()
                    + "', ButtonText2 = '" + btn2txt.Text.Trim() + "' WHERE ImageID = '" + ESID + "'", con);
                con.Open();
                cmd5.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("~/ViewEditImgSlider.aspx");
        }
        if(fuImg3.HasFile)
        {
            string SavePath = Server.MapPath("~/images/HomeImageSlider/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID = Guid.NewGuid().ToString();
            string Extension3 = Path.GetExtension(fuImg3.PostedFile.FileName);
            fuImg3.SaveAs(SavePath + "\\" + myGUID + Extension3);

            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd3 = new SqlCommand("UPDATE tblImageSlider SET Image3Text1 = '" + Img3txt1.Text.Trim() + "',Image3Text2 = '" + Img3txt2.Text.Trim() + "',Image3Text3 = '" + Img3txt3.Text.Trim()
                    + "', Image3Text4 = '" + Img3txt4.Text.Trim() + "',ButtonText3 = '" + btn3txt.Text + "', ImageUpload3 = '" + myGUID
                    + "', Extension3 = '" + Extension3 + "' WHERE ImageID = '"+ESID+"'", con))
                {
                    con.Open();
                    cmd3.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("~/ViewEditImgSlider.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd6 = new SqlCommand("UPDATE tblImageSlider SET Image3Text1 = '" + Img3txt1.Text.Trim() + "',Image3Text2 = '" + Img3txt2.Text.Trim() + "',Image3Text3 = '" + Img3txt3.Text.Trim()
                    + "', Image3Text4 = '" + Img3txt4.Text.Trim() + "',ButtonText3 = '" + btn3txt.Text + "' WHERE ImageID = '" + ESID + "'", con);
                con.Open();
                cmd6.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("~/ViewEditImgSlider.aspx");
        }
        if(fuImg1.HasFile && fuImg2.HasFile && fuImg3.HasFile)
        {
            string SavePath = Server.MapPath("~/images/HomeImageSlider/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID1 = Guid.NewGuid().ToString();
            string Extension1 = Path.GetExtension(fuImg1.PostedFile.FileName);
            fuImg1.SaveAs(SavePath + "\\" + myGUID1 + Extension1);

            String myGUID2 = Guid.NewGuid().ToString();
            string Extension2 = Path.GetExtension(fuImg2.PostedFile.FileName);
            fuImg2.SaveAs(SavePath + "\\" + myGUID2 + Extension2);

            String myGUID3 = Guid.NewGuid().ToString();
            string Extension3 = Path.GetExtension(fuImg3.PostedFile.FileName);
            fuImg3.SaveAs(SavePath + "\\" + myGUID3 + Extension3);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblImageSlider SET Image1Text1 = '"+ 
                    Img1txt1.Text.Trim() + "', Image1Text2 = '"+ Img1txt2.Text.Trim() + "', Image1Text3 = '"+ Img1txt3.Text.Trim()
                    + "', ButtonText1 = '"+ btn1txt.Text.Trim() + "', ImageUpload1 = '"+ myGUID1 + "', Extension1 = '"+Extension1
                    +"', Image2Text1 = '"+ Img2txt1.Text.Trim() + "', Image2Text2 = '"+ Img2txt2.Text.Trim() + "', Image2Text3 = '"+ Img2txt3.Text.Trim()
                    + "', ButtonText2 = '"+ btn2txt.Text.Trim() + "', ImageUpload2 = '"+ myGUID2 + "', Extension2 = '"+Extension2
                    +"', Image3Text1 = '"+Img3txt1.Text.Trim()+"',Image3Text2 = '"+Img3txt2.Text.Trim()+"',Image3Text3 = '"+Img3txt3.Text.Trim()
                    +"', Image3Text4 = '"+Img3txt4.Text.Trim()+"',ButtonText3 = '"+btn3txt.Text+"', ImageUpload3 = '"+myGUID2
                    +"', Extension3 = '"+Extension3+"' WHERE ImageID = '" + ESID + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("~/ViewEditImgSlider.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd1 = new SqlCommand("UPDATE tblImageSlider SET Image1Text1 = '" +
                    Img1txt1.Text.Trim() + "', Image1Text2 = '" + Img1txt2.Text.Trim() + "', Image1Text3 = '" + Img1txt3.Text.Trim()
                    + "', ButtonText1 = '" + btn1txt.Text.Trim() + "', Image2Text1 = '" + Img2txt1.Text.Trim() + "', Image2Text2 = '" + Img2txt2.Text.Trim() + "', Image2Text3 = '" + Img2txt3.Text.Trim()
                    + "', ButtonText2 = '" + btn2txt.Text.Trim() + "', Image3Text1 = '" + Img3txt1.Text.Trim() + "',Image3Text2 = '" + Img3txt2.Text.Trim() + "',Image3Text3 = '" + Img3txt3.Text.Trim()
                    + "', Image3Text4 = '" + Img3txt4.Text.Trim() + "',ButtonText3 = '" + btn3txt.Text + "' WHERE ImageID = '" + ESID + "'", con))
                {
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
            Response.Redirect("~/ViewEditImgSlider.aspx");
        }
    }
}