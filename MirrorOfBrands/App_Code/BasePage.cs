using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    protected override void OnLoadComplete(EventArgs e)
    {
        // Set the page's title, if necessary
        if (string.IsNullOrEmpty(Page.Title) || Page.Title == "Untitled Page")
        {
            // Determine the filename for this page
            string fileName = System.IO.Path.GetFileNameWithoutExtension(Request.PhysicalPath);

            Page.Title = fileName;
        }

        base.OnLoadComplete(e);
    }
}