using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class ProductComments : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        BindCommentsrptr();
        if (Request.QueryString["pcid"] != null)
        {
            if(!IsPostBack)
            {
                Int64 PCID = Convert.ToInt64(Request.QueryString["pcid"]);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM tblComments WHERE CommentID = @CommentID", con);
                    cmd.Parameters.AddWithValue("@CommentID", PCID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                BindCommentsrptr();
            }
        }
    }

    private void BindCommentsrptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT CommentID, C.PID, UserName, Comments, DateofComment, P.PID, PName FROM tblComments AS C LEFT JOIN tblProducts AS P ON P.PID = C.PID", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rptrComments.DataSource = dt;
            rptrComments.DataBind();
        }
    }
}