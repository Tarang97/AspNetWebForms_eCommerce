using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class AddCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindCategoryRptr();
        }
        if(Request.QueryString["cdid"] != null)
        {
            Int64 CDID = Convert.ToInt64(Request.QueryString["cdid"]);
            String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tblCategories WHERE CatID = '"+CDID+"'", con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            BindCategoryRptr();
        }
    }

    private void BindCategoryRptr()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptrCategory.DataSource = dtBrands;
                    rptrCategory.DataBind();
                }
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtCatName.Text != "")
        {
            String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblCategories VALUES('" + txtCatName.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                txtCatName.Text = string.Empty;
                lblSuccess.Text = "Category Added Successfully";
                lblSuccess.ForeColor = System.Drawing.Color.Green;
            }
            BindCategoryRptr();
        }
        else
        {
            lblError.Text = "Unable to Add Category";
            lblError.ForeColor = System.Drawing.Color.Red;
        }
    }
}