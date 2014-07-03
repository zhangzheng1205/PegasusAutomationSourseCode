using System;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using Selenium;
using System.Configuration;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pegasus.BaseHelper;
namespace Pegasus.Generics
{
    public class GenericHelper : BaseHelper.Helper
    {
        public ISelenium Selenium;
        

        //Purpose: Method To Wait For a particular Element on The Page
        public static void WaitUntilElement(By by)
        {
            try
            {
                WebDriverWait setwait = new WebDriverWait(WebDriver, TimeSpan.FromMinutes(double.Parse(ConfigurationManager.AppSettings["WaitUntillElementMinutes"])));
                setwait.Until((element) => { return element.FindElement(by); });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Purpose: Method To Write Data in the Excel Sheet
        public void Writedata(string fpath, int sheetno, int row, int col, string data)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(fpath, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(sheetno);
            range = xlWorkSheet.UsedRange;
            //xlWorkSheet.get_Range("B2", misValue).Formula = newpwd;
            (range.Cells[row, col] as Excel.Range).Value2 = data;
            xlWorkBook.Save();
            Killprocess("EXCEL");
        }

        //Purpose: Method To Read Dynamic Data into Excel sheet
        public string Readdata(string fpath, int sheetno, int row, int col)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(fpath, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(sheetno);
            range = xlWorkSheet.UsedRange;
            try
            {
                string dat = (string)(range.Cells[row, col] as Excel.Range).Value2;
                Killprocess("EXCEL");
                return dat;
            }
            catch (Exception)
            {
                double dat = (double)(range.Cells[row, col] as Excel.Range).Value2;
                Killprocess("EXCEL");
                return dat.ToString();
            }
        }

        //Purpose: Method To Kill Excel Process
        public void Killprocess(string pname)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {

                if (clsProcess.ProcessName.StartsWith(pname))
                {
                    clsProcess.Kill();
                }
            }
        }

        //Purpose: Method To Generate Unique Variable
        public static string Generate_Unique_variable(string inter_org)
        {
            string[] clCourse = new string[10];
            string fun_inter_org;
            clCourse[0] = inter_org;
            clCourse[1] = DateTime.Now.Year.ToString();
            clCourse[2] = DateTime.Now.Month.ToString();
            clCourse[3] = DateTime.Now.Day.ToString();
            clCourse[4] = DateTime.Now.Hour.ToString();
            clCourse[5] = DateTime.Now.Minute.ToString();
            clCourse[6] = DateTime.Now.Second.ToString();
            fun_inter_org = String.Concat(clCourse);
            return fun_inter_org;
        }

        //Purpose: Method To Get Count of Table Row
        public string GetRowCount(By by)
        {
            return (WebDriver.FindElement(by).FindElements(By.TagName("tr")).Count.ToString(CultureInfo.InvariantCulture));
        }

        //Purpose: Method To Get column Count
        public string GetColumnCount(By by)
        {
            return (WebDriver.FindElement(by).FindElements(By.TagName("td")).Count.ToString(CultureInfo.InvariantCulture));
        }

        //Purpose: Method To Log Test Case Results
        public static void Logs(string logtext, string status)
        {
            string statusTest = status.ToUpper();
            string time = TimeStamp();
            String driveName = ConfigurationManager.AppSettings["LogDriveName"];
            String errorFileName = String.Concat(driveName, ":\\Error_History.html");
            try
            {

                String logsFileName;
                string logMessage;
                switch (statusTest)
                {
                    case "PASSED":
                        logsFileName = String.Concat(driveName, ":\\Passed_Results.html");
                        logMessage = string.Format("<span style='color:Green;font-family:candara'>{0},\"&nbsp;&nbsp;\"{1},\"&nbsp;&nbsp;\"{2}</span></br></br>", logtext, time, statusTest);
                        Screenshot ssPass = ((ITakesScreenshot)WebDriver).GetScreenshot();
                        ssPass.SaveAsFile("C:\\Webdriver_Screenshots\\" + Generate_Unique_variable("Pass") + ".png", ImageFormat.Png);
                        break;
                    case "FAILED":
                        logsFileName = String.Concat(driveName, ":\\Failed_Results.html");
                        string error = Generate_Unique_variable("Error") + ".png";
                       
                        string path = String.Concat(driveName, ":\\Webdriver_Screenshots");

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        Screenshot ssFail = ((ITakesScreenshot)WebDriver).GetScreenshot();
                        ssFail.SaveAsFile("C:\\Webdriver_Screenshots\\" + Generate_Unique_variable("Error") + ".png", ImageFormat.Png);

                        logMessage = string.Format("<a style='color:Red;font-family:candara' href='" + driveName + ":\\Selenium_Screenshots\\" + error + "' >{0},\"&nbsp;&nbsp;\"{1},\"&nbsp;&nbsp;\"{2}</a></br></br>", logtext, time, statusTest);
                        break;
                    default:
                        logsFileName = String.Concat(driveName, ":\\Failed_Results.html");
                        logMessage = string.Format("<span style='color:Red;font-family:candara'>{0},\"&nbsp;&nbsp;\"{1},\"&nbsp;&nbsp;\"{2}</span></br></br>", logtext, time, statusTest);
                        break;
                }
                WriteLogs(logsFileName, logMessage);//write logs to appropriate log file.
                WriteLogs(errorFileName, logMessage);// write all the logs to error history
            }
            catch (Exception ex)
            {
                WriteLogs(string.Concat(driveName, ":\\Failed_Results.html"), String.Concat(ex.Message, "FAILED"));
            }
        }

        private static void WriteLogs(string fileName, String logMessage)
        {

            //Delete if the file is old
            if (File.GetLastAccessTime(fileName) < DateTime.Now.Subtract(new TimeSpan(24, 0, 0)) && (fileName.Contains("Error_History") == false))
            //if the file does not exist, GetLastAccessTime returns minimum datetime value
            {
                File.Delete(fileName);

            };
            logMessage = String.Concat(logMessage, "\r\n");
            //Append The Message To The File
            using (var file = new System.IO.StreamWriter(fileName, true))
            {
                file.WriteLine(logMessage);
                file.Close();
            }
        }
        //Purpose: Method To get Date & Time Stamp
        //to get date & time stamp
        public static string TimeStamp()
        {
            string[] clCourse = new string[12];
            string FullTimeStamp;
            //clCourse[0] = inter_org;
            clCourse[0] = DateTime.Now.Day.ToString(CultureInfo.InvariantCulture);
            clCourse[1] = "\\";
            clCourse[2] = DateTime.Now.Month.ToString(CultureInfo.InvariantCulture);
            clCourse[3] = "\\";
            clCourse[4] = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
            clCourse[5] = "  ";
            clCourse[6] = DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture);
            clCourse[7] = ":";
            clCourse[8] = DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture);
            clCourse[9] = ":";
            clCourse[10] = DateTime.Now.Second.ToString(CultureInfo.InvariantCulture);
            FullTimeStamp = String.Concat(clCourse);
            return FullTimeStamp;
        }


      
    }
}
