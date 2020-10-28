using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class EditCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString["ceid"] != null)
            {
                Int64 CEID = Convert.ToInt64(Request.QueryString["ceid"]);
                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories WHERE CatID = '"+CEID+"'", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult | CommandBehavior.SingleRow);
                    while(sdr.Read())
                    {
                        txtUpdateCategory.Text = sdr.GetString(1);
                    }
                }
            }
        }
    }

    protected void btnUpdateCat_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("UPDATE tblCategories SET CatName = '"+txtUpdateCategory.Text.Trim()+"' WHERE CatID = '"+Request.QueryString["ceid"]+"'", con);
            con.Open();
            cmd.ExecuteNonQuery();

            lblSuccess.Text = "Category Updated Successfully";
            lblSuccess.ForeColor = System.Drawing.Color.Green;
        }
    }
}