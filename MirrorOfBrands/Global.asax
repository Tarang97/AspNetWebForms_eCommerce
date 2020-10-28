<%@ Application Language="C#" %>
<%@ Import Namespace="System.IO" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
        new ScriptResourceDefinition {
            Path = "~/scripts/jquery-1.4.1.min.js",
            DebugPath = "~/scripts/jquery-1.4.1.js",
            CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.min.js",
            CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.js"
        });

        Application["OnlineUsers"] = 0;
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs
        //Exception exc = Server.GetLastError();
        //if (exc is HttpUnhandledException)
        //{
        //    if(exc.InnerException != null)
        //    {
        //        exc = new Exception(exc.InnerException.Message);
        //        //Pass error on to the error page
        //        Server.Transfer("Error.aspx?handler=Application Error%20-%20Global.asax", true);
        //    }
        //}

        HttpContext con = HttpContext.Current;
        var v = Server.GetLastError();

        var HttpEx = v as HttpException;
        if (HttpEx != null && HttpEx.GetHttpCode() == 404)
        {
            // Invalid Url
            Server.Transfer("~/PageNotFound.aspx", true);
        }
        else
        {
            // Exception
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Page:            " + con.Request.Url.ToString());
            sb.AppendLine("Error Message:   " + v.Message);
            sb.AppendLine("Inner Message:   " + v.InnerException.ToString());

            // Here save text file containing this error details
            string filename = Path.Combine(Server.MapPath("~/App Data"), DateTime.Now.ToString("dd-MM-YYYY hh-mm-ss") + ".txt");
            File.WriteAllText(filename, sb.ToString());
            Server.Transfer("~/Error.aspx", true);
        }
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        Application.Lock();
        Application["OnlineUsers"] = (int)Application["OnlineUsers"] + 1;
        Application.UnLock();

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Application.Lock();
        Application["OnlineUsers"] = (int)Application["OnlineUsers"] - 1;
        Application.UnLock();

    }

</script>
