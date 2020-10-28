using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Newsletter : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindNewsletterrptr();
            if(Request.QueryString["nid"] != null)
            {
                Int64 NID = Convert.ToInt64(Request.QueryString["nid"]);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblNewsletter WHERE Id = '"+NID+"'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    lblSuccess.Text = "User from Newsletter Deleted Successfully.";
                }
                BindNewsletterrptr();
            }
        }
    }

    private void BindNewsletterrptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblNewsletter", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rptrNewsletter.DataSource = dt;
            rptrNewsletter.DataBind();
        }
    }
}