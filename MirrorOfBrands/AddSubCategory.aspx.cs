using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class AddSubCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindMainCategory();
            BindSubCategoryRptr();
            if(Request.QueryString["dscid"] != null)
            {
                Int64 SubCatID = Convert.ToInt64(Request.QueryString["dscid"]);
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblSubCategories WHERE SubCatID = @SCID", con);
                    cmd.Parameters.AddWithValue("@SCID", SubCatID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                Response.Redirect("AddSubCategory.aspx");
            }
        }
    }

    private void BindSubCategoryRptr()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT A.*,B.* FROM tblSubCategories A INNER JOIN tblCategories B ON B.CatID = A.MainCatID", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    

                    if(dtBrands.Rows.Count != 0)
                    {
                        rptrSubCat.DataSource = dtBrands;
                        rptrSubCat.DataBind();
                    }
                    else
                    {
                        divtblSubCat.Visible = false;
                        lblError1.Text = "There is No Sub-Category on the list, please create one!";
                    }
                }
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
                ddlCategory.Items.Insert(0, new ListItem("- Select Main Category -", "0"));
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(txtSubCatName.Text != "" && ddlCategory.SelectedItem.Value != "")
        { 
            String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblSubCategories VALUES('" + txtSubCatName.Text + "','" + ddlCategory.SelectedItem.Value + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                txtSubCatName.Text = string.Empty;
                ddlCategory.ClearSelection();
                ddlCategory.Items.FindByValue("0").Selected = true;
                lblSuccess.Text = "Sub-Category Added Successfully";
                lblSuccess.ForeColor = System.Drawing.Color.Green;
            }
            BindSubCategoryRptr();
        }
        else
        {
            lblError.Text = "Unable to Add Sub-Category";
            lblError.ForeColor = System.Drawing.Color.Red;
        }

    }
}