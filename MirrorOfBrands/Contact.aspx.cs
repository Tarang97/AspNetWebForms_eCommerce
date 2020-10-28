using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Contact : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtFullName.Text != "" && txtEmail.Text != "" && txtSubject.Text != "" && txtComments.Text != "")
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblContacts VALUES('" + txtFullName.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" + txtSubject.Text.Trim() + "','" + txtComments.Text.Trim() + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();

                ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Your Contact Request is Successfully Submitted. Our Support team will be in touch with you soon.');window.location='Contact.aspx';</script>");
            }
            txtFullName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtComments.Text = string.Empty;
        }
        else
        {
            lblError.Text = "Request not Submitted!";
        } 
    }
}