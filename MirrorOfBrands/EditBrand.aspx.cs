using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class EditBrand : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindCategory();
            if(Request.QueryString["ebid"] != null)
            {
                Int64 EBID = Convert.ToInt64(Request.QueryString["ebid"]);
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblBrands WHERE BrandID = '" + EBID + "'", con);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if(ds.Tables[0].Rows.Count > 0)
                    {
                        txtUpdateBrand.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                        ddlCategory.SelectedItem.Text = ds.Tables[0].Rows[0]["MainCatName"].ToString();
                    }
                }
            }
            else
            {
                Response.Redirect("~/AddBrands.aspx");
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

    protected void btnUpdateBrand_Click(object sender, EventArgs e)
    {
       //Int64 UBID = Convert.ToInt64(Request.QueryString["ubid"]);
       String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
       using (SqlConnection con = new SqlConnection(CS))
       {
           SqlCommand cmd = new SqlCommand("UPDATE tblBrands SET Name = '" + txtUpdateBrand.Text.Trim() + "', MainCatID = '"+ ddlCategory.SelectedItem.Value + "' WHERE BrandID = '" + Request.QueryString["ebid"] + "'", con);
           con.Open();
           cmd.ExecuteNonQuery();

           lblSuccess2.Text = "Brand Updated Successfully";
           lblSuccess2.ForeColor = System.Drawing.Color.Green;
       }
        Response.Redirect("~/AddBrands.aspx");
    }
}