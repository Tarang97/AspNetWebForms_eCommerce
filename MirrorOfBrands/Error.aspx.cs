using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using MirrorOfBrands.Logic;

public partial class NotFound : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string generalErrorMsg = "An HTTP Error Occured. Page Not Found. The URL may be misspelled or the page you're looking for is no longer available.";
        //string generalErrorMsg2 = "A Problem has occured on this web site. Please try again. " + "If this error persist, please contact support.";
        //string httpErrorMsg = "An HTTP Error Occured. Page Not Found. The URL may be misspelled or the page you're looking for is no longer available.";
        //string unhandledErrorMsg = "The Error was unhandled by application code.";

        //FriendlyErrorMsg.Text = generalErrorMsg;
        //FriendlyErrorMsg2.Value = generalErrorMsg2;

        //string errorHandler = Request.QueryString["handler"];
        //if(errorHandler == null)
        //{
        //    errorHandler = "Error Page";
        //}

        //Exception ex = Server.GetLastError();

        //string errorMsg = Request.QueryString["msg"];
        //if(errorMsg == "404")
        //{
        //    ex = new HttpException(404, httpErrorMsg, ex);
        //    FriendlyErrorMsg.Text = ex.Message;
        //}

        //if (ex == null)
        //{
        //    ex = new Exception(unhandledErrorMsg);
        //}

        //if(Request.IsLocal && Session["EMAIL"] != null)
        //{
        //    if(Session["EMAIL"].ToString() == "director@mirrorofbrands.com")
        //    {
        //        ErrorDetailedMsg.Text = ex.Message;

        //        ErrorHandler.Text = errorHandler;

        //        DetailedErrorPanel.Visible = true;

        //        FriendlyErrorMsg2.Visible = true;

        //        if (ex.InnerException != null)
        //        {
        //            InnerMessage.Text = ex.GetType().ToString() + "<br/>" + ex.InnerException.Message;
        //            InnerTrace.Text = ex.InnerException.StackTrace;
        //        }
        //        else
        //        {
        //            InnerMessage.Text = ex.GetType().ToString();

        //            if (ex.StackTrace != null)
        //            {
        //                InnerTrace.Text = ex.StackTrace.ToString().TrimStart();
        //            }
        //        }
        //    }
        //}
        //else
        //{
        //    ErrorDetailedMsg.Text = ex.Message;

        //    ErrorHandler.Text = errorHandler;

        //    DetailedErrorPanel.Visible = false;

        //    FriendlyErrorMsg2.Visible = false;

        //    if (ex.InnerException != null)
        //    {
        //        InnerMessage.Text = ex.GetType().ToString() + "<br/>" + ex.InnerException.Message;
        //        InnerTrace.Text = ex.InnerException.StackTrace;
        //    }
        //    else
        //    {
        //        InnerMessage.Text = ex.GetType().ToString();

        //        if (ex.StackTrace != null)
        //        {
        //            InnerTrace.Text = ex.StackTrace.ToString().TrimStart();
        //        }
        //    }
        //}
        //ExceptionUtility.LogException(ex, errorHandler);
        //Server.ClearError();
    }
}