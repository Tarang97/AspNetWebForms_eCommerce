using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class EditSubCat : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindMainCategory();
        }
        if(Request.QueryString["escid"] != null)
        {
            Int64 SCID = Convert.ToInt64(Request.QueryString["escid"]);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubCategories WHERE SubCatID = '"+SCID+"'", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if(ds.Tables[0].Rows.Count > 0)
                {
                    txtSubCatName.Text = ds.Tables[0].Rows[0]["SubCatName"].ToString();
                    ddlCategory.SelectedItem.Text = ds.Tables[0].Rows[0]["MainCatName"].ToString();
                }
            }
        }
        else
        {
            Response.Redirect("~/AddSubCategory.aspx");
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
                ddlCategory.Items.Insert(0, new ListItem("- Select Main Category -", "0"));
            }
        }
    }

    protected void btnSubCatUpdate_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("UPDATE tblSubCategories SET SubCatName = '" + txtSubCatName.Text.Trim() + "', MainCatID = '" + ddlCategory.SelectedItem.Value + "' WHERE SubCatID = '" + Request.QueryString["escid"]+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();

            lblSuccess.Text = "Sub-Category Updated Successfully";
            lblSuccess.ForeColor = System.Drawing.Color.Green;          
        }
    }
}