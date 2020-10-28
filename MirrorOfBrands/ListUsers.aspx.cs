using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class ListUsers : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindUsersrptr();
            if(Request.QueryString["uid"] != null)
            {
                Int64 UID = Convert.ToInt64(Request.QueryString["uid"]);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UId = @Users", con);
                    cmd.Parameters.AddWithValue("@Users", UID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                BindUsersrptr();
            }
        }
    }

    private void BindUsersrptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rptrUsers.DataSource = dt;
            rptrUsers.DataBind();
        }
    }
}