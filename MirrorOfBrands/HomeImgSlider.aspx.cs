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
public partial class HomeImgSlider : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddImage_Click(object sender, EventArgs e)
    {
        // Image Slider 1
        if(fuImg1.HasFile && fuImg2.HasFile && fuImg2.HasFile)
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
                SqlCommand cmd = new SqlCommand("INSERT INTO tblImageSlider VALUES('"+Img1txt1.Text+"','"+Img1txt2.Text+"','"+Img1txt3.Text+"','"+btn1txt.Text+"','"+ myGUID1 + "','"+Extension1+ "','" + Img2txt1.Text + "','" + Img2txt2.Text + "','" + Img2txt3.Text + "','" + btn2txt.Text + "','" + myGUID2 + "','" + Extension2 + "','" + Img3txt1.Text + "','" + Img3txt2.Text + "','" + Img3txt3.Text + "','" + Img3txt4.Text + "','" + btn3txt.Text + "','" + myGUID3 + "','" + Extension3 + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            lblSuccess.Text = "Image for Slider is Added and Uploaded Successfully";
        }
    }
}