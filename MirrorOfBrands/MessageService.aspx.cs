using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Collections.Specialized;

public partial class MessageService : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindUsersMobileRptr();
        }
    }

    private void BindUsersMobileRptr()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT UId, Name, Mobile FROM Users", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtUsers = new DataTable();
            sda.Fill(dtUsers);
            rptrUsersMobile.DataSource = dtUsers;
            rptrUsersMobile.DataBind();
        }
    }

    protected void btnSmsSend_Click(object sender, EventArgs e)
    {
        string mnumber = txtMobile.Text;
        string message = txtSmsMessage.Text;
        string result;
        String message1 = HttpUtility.UrlEncode(message);
        using (var wb = new WebClient())
        {
            byte[] response = wb.UploadValues("http://api.textlocal.in/send/", new NameValueCollection()
            {
                {"apikey" , "2+eyJBUXOe4-8btc88t912Ge7gIM2cFCiIuSADn328" },
                {"numbers" , mnumber},
                {"message" , message1},
                {"sender" , "TXTLCL"}
            });
            result = System.Text.Encoding.UTF8.GetString(response);
        }
        if(result == "SUCCESS")
        {
            lblSuccess.Text = "SMS Sent to " + mnumber + " Successfully.";
        }
        else
        {
            lblError.Text = "SMS Sent Fail";
        }
        txtSmsMessage.Text = string.Empty;
    }
}