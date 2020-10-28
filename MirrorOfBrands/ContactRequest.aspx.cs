using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class ContactRequest : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindContacts();
            if(Request.QueryString["crid"] != null)
            {
                Int64 CRID = Convert.ToInt64(Request.QueryString["crid"]);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblContacts WHERE ContactID = '"+CRID+"'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    lblSuccess.Text = "Contact Request Deleted Successfully.";
                }
                BindContacts();
            }
        }
    }

    private void BindContacts()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblContacts", con);
            con.Open();
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                rptrContact.DataSource = dt;
                rptrContact.DataBind();
            }
        }
    }
}