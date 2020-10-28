using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
public partial class AddSize : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindBrand();
            BindMainCategory();
            BindGender();
            BindSizeRptr();
            if (Request.QueryString["sid"] != null)
            {
                // For Size Delete
                Int64 SID = Convert.ToInt64(Request.QueryString["sid"]);
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblProductSizeQuantity WHERE SizeID = '" + SID + "'",con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblSizes WHERE SizeID = '" + SID + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    lblSuccess.Text = "Size Deleted Succeesfully!";
                    lblSuccess.ForeColor = System.Drawing.Color.Green;
                }
                BindSizeRptr();
            }
        }
    }

    private void BindSizeRptr()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.*,C.*,D.*,E.* FROM tblSizes A INNER JOIN tblCategories B ON B.CatID = A.CategoryID INNER JOIN tblBrands C on C.BrandID = A.BrandID INNER JOIN tblSubCategories D ON D.SubCatID = A.SubCategoryID INNER JOIN tblGender E on E.GenderID = A.GenderID", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptrSizes.DataSource = dtBrands;
                    rptrSizes.DataBind();
                }
            }
        }
    }

    private void BindGender()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblGender", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlGender.DataSource = dt;
                ddlGender.DataTextField = "GenderName";
                ddlGender.DataValueField = "GenderID";
                ddlGender.DataBind();
                ddlGender.Items.Insert(0, new ListItem("- Select Gender -", "0"));
            }
        }
    }

    private void BindMainCategory()
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

    private void BindBrand()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblBrands", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if(dt.Rows.Count != 0)
            {
                ddlBrands.DataSource = dt;
                ddlBrands.DataTextField = "Name";
                ddlBrands.DataValueField = "BrandID";
                ddlBrands.DataBind();
                ddlBrands.Items.Insert(0, new ListItem("- Select Brand -", "0"));
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO tblSizes VALUES('" + txtSizeName.Text + "','" + ddlBrands.SelectedItem.Value + "','" + ddlCategory.SelectedItem.Value+ "','" + ddlSubCat.SelectedItem.Value+ "','"+ddlGender.SelectedItem.Value+"')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            txtSizeName.Text = string.Empty;
            ddlBrands.ClearSelection();
            ddlBrands.Items.FindByValue("0").Selected = true;
            ddlCategory.ClearSelection();
            ddlCategory.Items.FindByValue("0").Selected = true;
            ddlSubCat.ClearSelection();
            ddlSubCat.Items.FindByValue("0").Selected = true;
            ddlGender.ClearSelection();
            ddlGender.Items.FindByValue("0").Selected = true;
        }
        Response.Redirect("~/AddSize.aspx");
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);

        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblBrands WHERE MainCatID = '" + ddlCategory.SelectedItem.Value + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlBrands.DataSource = dt;
                ddlBrands.DataTextField = "Name";
                ddlBrands.DataValueField = "BrandID";
                ddlBrands.DataBind();
                ddlBrands.Items.Insert(0, new ListItem("- Select Brand -", "0"));
                ddlBrands.Enabled = true;
            }
        }

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubCategories WHERE MainCatID = '" + ddlCategory.SelectedItem.Value + "' ", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlSubCat.DataSource = dt;
                ddlSubCat.DataTextField = "SubCatName";
                ddlSubCat.DataValueField = "SubCatID";
                ddlSubCat.DataBind();
                ddlSubCat.Items.Insert(0, new ListItem("- Select SubCategory -", "0"));
            }
        }
    }
}