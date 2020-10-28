using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["email"] != null)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup();", true);
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void btnActivate_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email = @UserEmail", con);
            cmd.Parameters.AddWithValue("@UserEmail", Request.QueryString["email"]);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                String activationcode;
                activationcode = ds.Tables[0].Rows[0]["ActivationCode"].ToString();
                if (activationcode == tbActivate.Text)
                {
                    changestatus();
                }
                else
                {
                    
                }
            }
        }
        Response.Redirect("~/Login.aspx");
    }

    private void changestatus()
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("UPDATE Users SET Status = 'Verified' WHERE Email = @ConfirmEmail", con);
            cmd.Parameters.AddWithValue("@ConfirmEmail", Request.QueryString["email"]);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
