using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AddBrands : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindBrandsRptr();
            BindCategory();
            if (Request.QueryString["ebid"] != null)
            {
                Int64 BID = Convert.ToInt64(Request.QueryString["ebid"]);
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblBrands WHERE BrandID = '" + BID + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    lblSuccess.Text = "Brand Deleted Successfully";
                    lblSuccess.ForeColor = System.Drawing.Color.Green;
                }
                BindBrandsRptr();
            }
        }
    }

    private void BindCategory()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "CatName";
                ddlCategory.DataValueField = "CatID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("- Select Category -", "0"));
            }
        }
    }

    private void BindBrandsRptr()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT B.BrandID, B.Name, B.MainCatID, C.CatID, C.CatName FROM tblBrands AS B LEFT JOIN tblCategories AS C ON C.CatID = B.MainCatID",con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptrBrands.DataSource = dtBrands;
                    rptrBrands.DataBind();
                }
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(txtBrandName.Text != "")
        { 
            String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblBrands VALUES('" + txtBrandName.Text + "','"+ddlCategory.SelectedItem.Value+"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                txtBrandName.Text = string.Empty;
                lblSuccess.Text = "Brand Added Successfully";
                lblSuccess.ForeColor = System.Drawing.Color.Green;
            }
            BindBrandsRptr();
        }
        else
        {
            lblError.Text = "Unable to Add Brand";
            lblError.ForeColor = System.Drawing.Color.Red;
        }
    }
}