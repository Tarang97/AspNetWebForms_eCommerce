using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class ViewProduct : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindAllProducts();
            Int64 PID = Convert.ToInt64(Request.QueryString["pid"]);
            if (Request.QueryString["pid"] != null)
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblComments WHERE PID = '" + PID + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblProductImages WHERE PID = '" + PID + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblProductSizeQuantity WHERE PID = '" + PID + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblProducts WHERE PID = '" + PID + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                Response.Redirect("~/ViewProduct.aspx");
            }
        }
    }

    private void BindAllProducts()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.*,D.*,E.* FROM tblProducts A INNER JOIN tblCategories B ON B.CatID = A.PCategoryID INNER JOIN tblBrands C ON C.BrandID = A.PBrandID INNER JOIN tblSubCategories D ON D.SubCatID = A.PSubCatID INNER JOIN tblGender E ON E.GenderID = A.PGender", con))
            //using (SqlCommand cmd = new SqlCommand("SELECT tp.PID, PName, PPrice, PSelPrice, PBrandID, PCategoryID, PSubCatID, PGender, PDescription, PProductDetails, PMaterialCare, FreeDelivery, DayReturns, COD, PDiscount, tb.Name, CatName, GenderName, SubCatName, tpi.PImgID, tpi.Name, Extension, ts.SizeID, Quantity, SizeName, ts.BrandID, ts.CategoryID, ts.SubCategoryID, ts.GenderID FROM tblProducts AS tp LEFT JOIN tblBrands AS tb ON tb.BrandID = tp.PBrandID LEFT JOIN tblCategories AS tc ON tc.CatID = tp.PCategoryID LEFT JOIN tblGender AS tg ON tg.GenderID = tp.PGender LEFT JOIN tblSubCategories AS tsc ON tsc.SubCatID = tp.PSubCatID LEFT JOIN tblProductImages AS tpi ON tpi.PImgID = tp.PID LEFT JOIN tblProductSizeQuantity AS tpsq ON tpsq.PrdSizeQuantID = tp.PID LEFT JOIN tblSizes AS ts ON ts.SizeID = tp.PID", con))
            {
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtProducts = new DataTable();
                    sda.SelectCommand = cmd;
                    sda.Fill(dtProducts);
                    rptrViewProduct.DataSource = dtProducts;
                    rptrViewProduct.DataBind();
                }
            }
        }
    }

    protected void rptrViewProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string PrdID = (e.Item.FindControl("Label1") as Label).Text;
            Int64 PID = Convert.ToInt64(PrdID);
            Label pStatus = e.Item.FindControl("Label2") as Label;
            Label pOption = e.Item.FindControl("Label3") as Label;

            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblProducts WHERE PID = '"+PID+"'", con))
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count != 0)
                    {
                        pStatus.Text = dt.Rows[0]["Status"].ToString();
                        pOption.Text = dt.Rows[0]["ProductOption"].ToString();
                    }
                }
            }
        }
    }
}
