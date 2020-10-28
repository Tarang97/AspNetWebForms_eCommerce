using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminHeader : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "Users Online: " + Application["OnlineUsers"].ToString();
        // Recomment Later. Commented because of Design Checking
        //if (Session["EMAIL"] != null)
        //{
        //    lblSuccess.Text = Session["EMAIL"].ToString();
        //}
        //else
        //{
        //    Response.Redirect("~/Login.aspx");
        //}
    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        Session["EMAIL"] = null;
        Response.Redirect("~/Login.aspx");
    }
}