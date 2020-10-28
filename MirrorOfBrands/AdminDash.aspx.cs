using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class AdminIndex : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                int count = 0;
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblCategories", con);
                con.Open();
                count = (int)cmd.ExecuteScalar();

                if(count == 0)
                {
                    divCatCount.InnerText = "0";
                }
                else
                {
                    divCatCount.InnerText = count.ToString();
                }
            }
            using (SqlConnection con = new SqlConnection(CS))
            {
                int count = 0;
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblBrands", con);
                con.Open();
                count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    divBrandCount.InnerText = "0";
                    tdBrandCount.InnerText = "0";
                }
                else
                {
                    divBrandCount.InnerText = count.ToString();
                    tdBrandCount.InnerText = count.ToString();
                }
            }
            using (SqlConnection con = new SqlConnection(CS))
            {
                int count = 0;
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblSubCategories", con);
                con.Open();
                count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    divSubCatCount.InnerText = "0";
                    tdSubCatCount.InnerText = "0";
                }
                else
                {
                    divSubCatCount.InnerText = count.ToString();
                    tdSubCatCount.InnerText = count.ToString();
                }
            }
            using (SqlConnection con = new SqlConnection(CS))
            {
                int count = 0;
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblProducts", con);
                con.Open();
                count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    divProductCount.InnerText = "0";
                    tdProductCount.InnerText = "0";
                }
                else
                {
                    divProductCount.InnerText = count.ToString();
                    tdProductCount.InnerText = count.ToString();
                }
            }
            using (SqlConnection con = new SqlConnection(CS))
            {
                int count = 0;
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblOrders", con);
                con.Open();
                count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    divPurchaseCount.InnerText = "0";
                    tdOrderCount.InnerText = "0";
                }
                else
                {
                    divPurchaseCount.InnerText = count.ToString();
                    tdOrderCount.InnerText = count.ToString();
                }
            }
            using (SqlConnection con = new SqlConnection(CS))
            {
                int count = 0;
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblSizes", con);
                con.Open();
                count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    divSizeCount.InnerText = "0";
                }
                else
                {
                    divSizeCount.InnerText = count.ToString();
                }
            }
            using (SqlConnection con = new SqlConnection(CS))
            {
                int count = 0;
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users", con);
                con.Open();
                count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    divUsersCount.InnerText = "0";
                    tdUserCount.InnerText = "0";
                }
                else
                {
                    divUsersCount.InnerText = count.ToString();
                    tdUserCount.InnerText = count.ToString();
                }
            }
            using (SqlConnection con = new SqlConnection(CS))
            {
                int count = 0;
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblNews", con);
                con.Open();
                count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    divNewsCount.InnerText = "0";
                }
                else
                {
                    divNewsCount.InnerText = count.ToString();
                }
            }
            using (SqlConnection con = new SqlConnection(CS))
            {
                int count = 0;
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblContacts", con);
                con.Open();
                count = (int)cmd.ExecuteScalar();

                if (count == 0)
                {
                    divContactCount.InnerText = "0";
                }
                else
                {
                    divContactCount.InnerText = count.ToString();
                }
            }
        }
    }
}