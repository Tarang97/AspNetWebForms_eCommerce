using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class AboutTermPrivacy : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if(!IsPostBack)
        {
            BindSiteInfo();
            btnUpdate.Visible = false;
            if(Request.QueryString["atpid"] != null)
            {
                Int64 ATPID = Convert.ToInt64(Request.QueryString["atpid"]);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblSiteInfo", con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while(sdr.Read())
                    {
                        CKEditor1.Text = Server.HtmlEncode(sdr.GetString(1));
                        CKEditor2.Text = Server.HtmlEncode(sdr.GetString(2));
                        CKEditor3.Text = Server.HtmlEncode(sdr.GetString(3));
                        CKEditor4.Text = Server.HtmlEncode(sdr.GetString(4));
                        CKEditor5.Text = Server.HtmlEncode(sdr.GetString(5));
                    }
                    btnUpdate.Visible = true;
                }
                btnSubmit.Visible = false;
            }
        }
    }

    private void BindSiteInfo()
    {
        String redirectlink;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblSiteInfo", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblID.Text = ds.Tables[0].Rows[0]["ID"].ToString();
                lblAbout.Text = ds.Tables[0].Rows[0]["AboutUs"].ToString();
                lblTerms.Text = ds.Tables[0].Rows[0]["Terms"].ToString();
                lblPrivacy.Text = ds.Tables[0].Rows[0]["Privacy"].ToString();
                lblShipping.Text = ds.Tables[0].Rows[0]["ShippingOpt"].ToString();
                lblReturn.Text = ds.Tables[0].Rows[0]["Returns"].ToString();

                redirectlink = ds.Tables[0].Rows[0]["ID"].ToString();
                HyperLink1.NavigateUrl = "AboutTermPrivacy.aspx?atpid=" + redirectlink;
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO tblSiteInfo VALUES(@AboutUs,@Terms,@Privacy,@Shipping,@Return)", con))
            {
                cmd.Parameters.AddWithValue("@AboutUs", Server.HtmlDecode(CKEditor1.Text));
                cmd.Parameters.AddWithValue("@Terms", Server.HtmlDecode(CKEditor2.Text));
                cmd.Parameters.AddWithValue("@Privacy", Server.HtmlDecode(CKEditor3.Text));
                cmd.Parameters.AddWithValue("@Shipping", Server.HtmlDecode(CKEditor4.Text));
                cmd.Parameters.AddWithValue("@Return", Server.HtmlDecode(CKEditor5.Text));
                con.Open();
                cmd.ExecuteNonQuery();
            }
            lblSuccess.Text = "Info. Added Successfully";
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Int64 ATPID = Convert.ToInt64(Request.QueryString["atpid"]);
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("UPDATE tblSiteInfo SET AboutUs = @About, Terms = @ToS, Privacy = @PPolicy, ShippingOpt = @ShippingO, Returns = @ReturnP WHERE ID = '"+ATPID+"'", con);
            cmd.Parameters.AddWithValue("@About", Server.HtmlDecode(CKEditor1.Text));
            cmd.Parameters.AddWithValue("@Tos", Server.HtmlDecode(CKEditor2.Text));
            cmd.Parameters.AddWithValue("@PPolicy", Server.HtmlDecode(CKEditor3.Text));
            cmd.Parameters.AddWithValue("@ShippingO", Server.HtmlDecode(CKEditor4.Text));
            cmd.Parameters.AddWithValue("@ReturnP", Server.HtmlDecode(CKEditor5.Text));
            con.Open();
            cmd.ExecuteNonQuery();
        }
        Response.Redirect("~/AboutTermPrivacy.aspx");
    }
}