using CommonLayer;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public static class Log
    {
        public static void Write(Exception ex)
        {
            if (ex.IsNotNull())
            {
                string errorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
                string errormsg = ex.GetType().Name.ToString();
                string extype = ex.GetType().ToString();
                string exurl = HttpContext.Current.Request.Url.ToString();
                string errorLocation = ex.Message.ToString();

                string hostIp = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(hostIp))
                {
                    hostIp = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }

                try
                {
                    string filepath = HttpContext.Current.Server.MapPath("~/ExceptionDetailsFile/");  //Text File Path

                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }

                    filepath = filepath + "Error_" + DateTime.Today.ToString("dd-MMM-yyyy") + ".txt";   //Text File Name

                    if (!File.Exists(filepath))
                    {
                        File.Create(filepath).Dispose();
                    }

                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        string errorLog = string.Empty;

                        errorLog += string.Empty.PadRight(100, '`') + "\n";

                        errorLog += "DateTime".PadRight(28, ' ') + " : " + DateTime.Now.ToString("dd MMM, yyyy hh:mm:ss tt") + "\n";

                        var st = new StackTrace(ex, true);
                        var query = st.GetFrames()
                                      .Select(frame => new
                                      {
                                          FileName = frame.GetFileName(),
                                          LineNumber = frame.GetFileLineNumber(),
                                          ColumnNumber = frame.GetFileColumnNumber(),
                                          Method = frame.GetMethod(),
                                          Class = frame.GetMethod().DeclaringType
                                      });

                        errorLog += "Exception Current Page".PadRight(28, ' ') + " : " + query.ToList().First().Class + "\n";
                        errorLog += "Exception Current FileName".PadRight(28, ' ') + " : " + query.ToList().First().FileName + "\n";
                        errorLog += "Exception Current LineNumber".PadRight(28, ' ') + " : " + query.ToList().First().LineNumber + "\n";
                        errorLog += "Exception Current LineNumber".PadRight(28, ' ') + " : " + errorlineNo + "\n";
                        errorLog += "Exception Current Method".PadRight(28, ' ') + " : " + query.ToList().First().Method + "\n";
                        errorLog += "Exception Current ColumnNumber".PadRight(28, ' ') + " : " + query.ToList().First().ColumnNumber + "\n";
                        errorLog += "Exception Type".PadRight(28, ' ') + " : " + extype + "\n";
                        errorLog += "Exception Page Url".PadRight(28, ' ') + " : " + exurl + "\n";
                        errorLog += "Exception Message".PadRight(28, ' ') + " : " + ex.Message + "\n";
                        errorLog += "Exception StackTrace".PadRight(28, ' ') + " : " + ex.StackTrace + "\n";
                        errorLog += "Computer IP".PadRight(28, ' ') + " : " + hostIp + "\n";
                        sw.WriteLine(errorLog);

                        errorLog = string.Empty;

                        errorLog += "OSVersion".PadRight(28, ' ') + " : " + Environment.OSVersion + "\n";
                        errorLog += "CurrentCulture".PadRight(28, ' ') + " : " + Thread.CurrentThread.CurrentUICulture.Name + "\n";
                        OperatingSystem operatingSystem = Environment.OSVersion;
                        errorLog += "Platform".PadRight(28, ' ') + " : " + operatingSystem.Platform + "\n";
                        errorLog += "Version".PadRight(28, ' ') + " : " + operatingSystem.Version + "\n";
                        errorLog += "CLR Version".PadRight(28, ' ') + " : " + Environment.Version + "\n";
                        string result = string.Empty;
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
                        foreach (ManagementObject os in searcher.Get())
                        {
                            result = os["Caption"].ToString();
                            break;
                        }

                        errorLog += "Operating System".PadRight(28, ' ') + " : " + result + "\n";

                        PerformanceCounter cpuCounter;
                        PerformanceCounter ramCounter;

                        cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                        ramCounter = new PerformanceCounter("Memory", "Available MBytes");

                        errorLog += "Processor Usage".PadRight(28, ' ') + " : " + cpuCounter.NextValue() + "%" + "\n";
                        errorLog += "Memory Usage".PadRight(28, ' ') + " : " + (ramCounter.NextValue() / 1024) + " GB" + "\n";

                        ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
                        ManagementObjectCollection moc = mc.GetInstances();
                        foreach (ManagementObject item in moc)
                        {
                            errorLog += "Memory Size".PadRight(28, ' ') + " : " + Convert.ToString(Math.Round(Convert.ToDouble(item.Properties["TotalPhysicalMemory"].Value) / 1073741824, 2)) + " GB" + "\n";
                        }

                        errorLog += string.Empty.PadRight(100, '_');

                        sw.WriteLine(errorLog);
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch (Exception e)
                {
                    e.ToString();
                } 
            }
        }
    }
}