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
public partial class ProductBanner : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAddBanner_Click(object sender, EventArgs e)
    {
        if(fuImgBan1.HasFile && fuImgBan2.HasFile && fuImgBan3.HasFile && fuImgBan4.HasFile && fuImgBan5.HasFile)
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
                SqlCommand cmd = new SqlCommand("INSERT INTO tblProductBanner VALUES('"+txt1Ban1.Text.Trim()+"','"+txt2Ban1.Text.Trim()+"','"
                    +myGUID1+"','"+Extension1+"','"+txt1Ban2.Text.Trim()+"','"+txt2Ban2.Text.Trim()+"','"
                    +myGUID2+"','"+Extension2+"','"+txt1Ban3.Text.Trim()+"','"+txt2Ban3.Text.Trim()+"','"
                    +txt3Ban3.Text.Trim()+"','"+myGUID3+"','"+Extension3+"','"+txt1Ban4.Text.Trim()+"','"
                    +txt2Ban4.Text.Trim()+"','"+myGUID4+"','"+Extension4+"','"+txt1Ban5.Text.Trim()+"','"
                    +txt2Ban5.Text.Trim()+"','"+txt3Ban5.Text.Trim()+"','"+txt4Ban5.Text.Trim()+"','"+txt5Ban5.Text.Trim()+"','"
                    +myGUID5+"','"+Extension5+"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            lblSuccess.Text = "Banner Image Added Successfully";
        }
    }
}