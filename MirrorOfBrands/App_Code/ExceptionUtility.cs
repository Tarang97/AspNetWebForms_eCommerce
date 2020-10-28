using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExceptionUtility
/// </summary>

namespace MirrorOfBrands.Logic
{
    public sealed class ExceptionUtility
    {
        private ExceptionUtility()
        {}

        public static string LogFile { get; private set; }

        public static void LogException(Exception exc, string source)
        {
            string Logfile = "App Data/ErrorLog.txt";
            LogFile = HttpContext.Current.Server.MapPath(Logfile);

            StreamWriter sw = new StreamWriter(Logfile, true);
            sw.WriteLine("********** {0} **********", DateTime.Now);
            if(exc.InnerException != null)
            {
                sw.Write("Inner Exception Type: ");
                sw.WriteLine(exc.InnerException.GetType().ToString());
                sw.WriteLine("Inner Exception: ");
                sw.WriteLine(exc.InnerException.Message);
                sw.Write("Inner Source: ");
                sw.WriteLine(exc.InnerException.Source);
                if(exc.InnerException.StackTrace != null)
                {
                    sw.WriteLine("Inner Stack Trace: ");
                    sw.WriteLine(exc.InnerException.StackTrace);
                }
            }
            sw.WriteLine("Exception Type: ");
            sw.WriteLine(exc.GetType().ToString());
            sw.WriteLine("Exception: " + exc.Message);
            sw.WriteLine("Source: " + source);
            sw.WriteLine("Stack Trace: ");
            if(exc.StackTrace != null)
            {
                sw.WriteLine(exc.StackTrace);
                sw.WriteLine();
            }
            sw.Close();
        }
    }
}
