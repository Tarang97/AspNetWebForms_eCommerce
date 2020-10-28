using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddGender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindGenderRptr();
        }
    }

    private void BindGenderRptr()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblGender", con))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtBrands = new DataTable();
                    sda.Fill(dtBrands);
                    rptrGender.DataSource = dtBrands;
                    rptrGender.DataBind();
                }
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtGenderName.Text != "")
        {
            String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblGender VALUES('" + txtGenderName.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                txtGenderName.Text = string.Empty;
                lblSuccess.Text = "Gender Added Successfully";
                lblSuccess.ForeColor = System.Drawing.Color.Green;
            }
        }
        else
        {
            lblError.Text = "Please Write Gender Value!";
            lblError.ForeColor = System.Drawing.Color.Red;
        }
    }

    protected void btnGDelete_Click(object sender, EventArgs e)
    {
        // For Gender Delete
        Int64 GID = Convert.ToInt64(Request.QueryString["gid"]);
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tblGender WHERE GenderID = '" + GID + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();

            lblSuccess.Text = "Gender Deleted Successfully";
            lblSuccess.ForeColor = System.Drawing.Color.Green;
        }
    }
}