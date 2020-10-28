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

public partial class ViewEditImgSlider : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        BindImageSliderRptr();
    }

    private void BindImageSliderRptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM tblImageSlider ORDER BY ImageID DESC", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtImage = new DataTable();
            sda.Fill(dtImage);
            rptrImages.DataSource = dtImage;
            rptrImages.DataBind();
        }
    }
}