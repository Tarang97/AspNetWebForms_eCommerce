using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class EditSize : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString["sid"] != null)
            {
                BindBrand();
                BindMainCategory();
                BindGender();
                Int64 SID = Convert.ToInt64(Request.QueryString["sid"]);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT SizeID, SizeName, ts.BrandID, CategoryID, SubCategoryID, ts.GenderID, tb.BrandID, tb.Name, CatID, CatName, tg.GenderID, GenderName, SubCatID, SubCatName, tsc.MainCatID FROM tblSizes as ts LEFT JOIN tblBrands AS tb ON tb.BrandID = ts.BrandID LEFT JOIN tblCategories AS tc ON tc.CatID = ts.CategoryID LEFT JOIN tblSubCategories AS tsc ON tsc.SubCatID = ts.SubCategoryID LEFT JOIN tblGender AS tg ON tg.GenderID = ts.GenderID WHERE SizeID = '"+SID+"'", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult | CommandBehavior.SingleRow);
                    while(sdr.Read())
                    {
                        txtSName.Text = sdr.GetString(1);
                    }
                }
            }
            else
            {
                Response.Redirect("~/AddSize.aspx");
            }
        }
    }

    private void BindBrand()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblBrands", con);
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
                ddlBrands.Items.Insert(0, new ListItem("- Select Brands -", "0"));
            }
        }
    }

    private void BindMainCategory()
    {
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

    private void BindGender()
    {
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
                ddlSubCategory.DataSource = dt;
                ddlSubCategory.DataTextField = "SubCatName";
                ddlSubCategory.DataValueField = "SubCatID";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, new ListItem("- Select SubCategory -", "0"));
            }
        }
    }

    protected void btnUpdateSize_Click(object sender, EventArgs e)
    {
        Int64 SID = Convert.ToInt64(Request.QueryString["sid"]);
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("UPDATE tblSizes SET SizeName = '"+txtSName.Text+"', BrandID = '"+ddlBrands.SelectedItem.Value+"', CategoryID = '"+ddlCategory.SelectedItem.Value+"', SubCategoryID = '"+ddlSubCategory.SelectedItem.Value+"', GenderID = '"+ddlGender.SelectedItem.Value+"' WHERE SizeID = '"+SID+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();

            txtSName.Text = string.Empty;
            ddlBrands.ClearSelection();
            ddlBrands.Items.FindByValue("0").Selected = true;
            ddlCategory.ClearSelection();
            ddlCategory.Items.FindByValue("0").Selected = true;
            ddlSubCategory.ClearSelection();
            ddlSubCategory.Items.FindByValue("0").Selected = true;
            ddlGender.ClearSelection();
            ddlGender.Items.FindByValue("0").Selected = true;

            lblSuccess.Text = "Size Updated Successfully";
            lblSuccess.ForeColor = System.Drawing.Color.Green;
        }
    }
}