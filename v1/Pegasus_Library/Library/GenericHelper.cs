using System;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using Framework.Common;
using OpenQA.Selenium.Support.UI;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Selenium;
using System.IO;
using System.Linq;
using System.Threading;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
namespace Pegasus_Library.Library
{
    public class GenericHelper : BasePage
    {
        #region Constants Declaration

        //Pupose: Constant Declaration
        private static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private static string _successMessage = null;
        private static readonly string ProjPath = Assembly.GetExecutingAssembly().Location;
        private static readonly string[] Arr = Regex.Split(ProjPath, "PegasusTestScripts");
        private static readonly string FilePath = ConfigurationManager.AppSettings["BulkUserFile"];
        private static readonly string PassedlogFileName = String.Empty;
        private static readonly string FailedLogFileName = String.Empty;
        private static readonly string ErrorLogFileName = String.Empty;

        #endregion Constants Declaration

        //Purpose: Create Time Stamp Log Files
        static GenericHelper()
        {
            PassedlogFileName = ":\\Passed_Results_" +
                                DateTime.Now.ToString("dd-MM-yyyy_HHmmss").ToString(CultureInfo.InvariantCulture) +
                                ".html";
            FailedLogFileName = ":\\Failed_Results_" +
                                DateTime.Now.ToString("dd-MM-yyyy_HHmmss").ToString(CultureInfo.InvariantCulture) +
                                ".html";
            ErrorLogFileName = ":\\Error_Results_" +
                               DateTime.Now.ToString("dd-MM-yyyy_HHmmss").ToString(CultureInfo.InvariantCulture) +
                               ".html";
        }

        //Function to Wait Until Particular Element Visible on Page
        public static bool WaitUntilElement(By by)
        {
            try
            {
                string expectedTimeToWait = ConfigurationManager.AppSettings["WaitUntillElementSeconds"];
                int currentWaitTime = Convert.ToInt32(expectedTimeToWait);
                if (currentWaitTime > 0)
                {
                    var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(currentWaitTime));
                    wait.Until(ExpectedConditions.ElementIsVisible(@by));
                }
                return true;
            }
            catch (Exception)
            {
                Logs(String.Format("The expected element '{0}' has not found under specified time interval.", @by),
                     "FAILED");
                return false;
            }
        }

        //Purpose: Method To Wait For a particular Element on The Page Through Backed Selenium
        public static void WaitForElement(string elementValue)
        {
            Boolean elementFound = false;
            var sw = new Stopwatch();
            sw.Start();
            int secondsToWait = Int32.Parse(ConfigurationManager.AppSettings["WaitUntillElementSeconds"]);
            while (sw.Elapsed.TotalSeconds < secondsToWait)
            {
                if (BackedSelenium.IsElementPresent(elementValue))
                {
                    elementFound = true;
                    break;
                }
            }
            if (!elementFound)
            {
                Logs(
                    String.Format(
                        "The expected element '{0}' has not found under specified time interval of '{1}' second(s).",
                        elementValue, secondsToWait), "FAILED");
                throw new TimeoutException(
                    String.Format(
                        "The expected element '{0}' has not found under specified time interval of '{1}' second(s).",
                        elementValue, secondsToWait));
            }
            sw.Stop();
            sw = null;
        }

        //Purpose: Method To Generate Unique Variable
        public static string GenerateUniqueVariable(string interOrg)
        {
            var clCourse = new string[10];
            clCourse[0] = interOrg;
            clCourse[1] = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
            clCourse[2] = DateTime.Now.Month.ToString(CultureInfo.InvariantCulture);
            clCourse[3] = DateTime.Now.Day.ToString(CultureInfo.InvariantCulture);
            clCourse[4] = DateTime.Now.Hour.ToString(CultureInfo.InvariantCulture);
            clCourse[5] = DateTime.Now.Minute.ToString(CultureInfo.InvariantCulture);
            clCourse[6] = DateTime.Now.Second.ToString(CultureInfo.InvariantCulture);
            string funInterOrg = String.Concat(clCourse);
            return funInterOrg;
        }

        //Purpose: Method To Get Count of Table Row
        public static string GetRowCount(By by)
        {
            IWebDriver WebDriver = GetWebDriverInstance();
            return
                (WebDriver.FindElement(@by).FindElements(By.TagName("tr")).Count.ToString(CultureInfo.InvariantCulture));
        }

        //Purpose: Method To Get Column Count
        public static string GetColumnCount(By by)
        {
            IWebDriver WebDriver = GetWebDriverInstance();
            return
                (WebDriver.FindElement(@by).FindElements(By.TagName("td")).Count.ToString(CultureInfo.InvariantCulture));
        }

        //Purpose : To Delete Folder with all its Contents for every New Test Run
        public static void DeleteDirectory(string targetDir)
        {
            string[] files = Directory.GetFiles(targetDir);
            string[] dirs = Directory.GetDirectories(targetDir);
            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }
            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }
            Directory.Delete(targetDir, false);
        }

        //Purpose: Method To Log Test Case Results
        public static void Logs(string logtext, string status)
        {
            string scenarioName = ScenarioContext.Current.ScenarioInfo.Title;
            string statusTest = status.ToUpper();
            string time = TimeStamp();
            String driveName = ConfigurationManager.AppSettings["LogDriveName"];
            String errorFileName = String.Concat(driveName, ErrorLogFileName);
            string path = String.Concat(driveName, ":\\Webdriver_Screenshots");
            try
            {
                string folderpath = String.Concat(driveName, ":\\Webdriver_Screenshots");
                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                }
                if (Directory.GetLastAccessTime(folderpath) < DateTime.Now.Subtract(new TimeSpan(24, 0, 0)))
                {
                    DeleteDirectory(folderpath);
                }
                String logsFileName;
                string logMessage;
                switch (statusTest)
                {
                    case "PASSED":
                        logsFileName = String.Concat(driveName, PassedlogFileName);

                        string pass = GenerateUniqueVariable("Pass") + ".png";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        //Screenshot ssPass = ((ITakesScreenshot)WebDriver).GetScreenshot();
                        //ssPass.SaveAsFile(driveName + ":\\Webdriver_Screenshots\\" + pass, ImageFormat.Png);
                        logMessage =
                            String.Format(
                                "<a style='color:Green;font-family:Century Gothic;font-size: 12px;' href='" + driveName +
                                ":\\Webdriver_Screenshots\\" + pass +
                                "' >{0},\"&nbsp;&nbsp;\"{1},\"&nbsp;&nbsp;\"{2}</a></br></br>",
                                scenarioName + " - " + logtext, time, statusTest);
                        break;
                    case "FAILED":
                        logsFileName = String.Concat(driveName, FailedLogFileName);
                        string fail = GenerateUniqueVariable("Fail") + ".png";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        Screenshot ssFail = ((ITakesScreenshot)WebDriver).GetScreenshot();
                        ssFail.SaveAsFile(driveName + ":\\Webdriver_Screenshots\\" + fail, ImageFormat.Png);
                        logMessage =
                            String.Format(
                                "<a style='color:Red;font-family:Century Gothic;font-size: 12px;' href='" + driveName +
                                ":\\Webdriver_Screenshots\\" + fail +
                                "' >{0},\"&nbsp;&nbsp;\"{1},\"&nbsp;&nbsp;\"{2}</a></br></br>",
                                scenarioName + " - " + logtext, time, statusTest);
                        break;
                    default:
                        logsFileName = String.Concat(driveName, FailedLogFileName);
                        logMessage =
                            String.Format(
                                "<span style='color:Red;font-family:Century Gothic;font-size: 12px;'>{0},\"&nbsp;&nbsp;\"{1},\"&nbsp;&nbsp;\"{2}</span></br></br>",
                                scenarioName + " - " + logtext, time, statusTest);
                        break;
                }
                WriteLogs(logsFileName, logMessage); //write logs to appropriate log file.
                WriteLogs(errorFileName, logMessage); // write all the logs to error history
            }
            catch (Exception ex)
            {
                WriteLogs(String.Concat(driveName, FailedLogFileName), String.Concat(ex.Message, "FAILED"));
            }
        }

        //Purpose: Method To Write Log Message in File
        private static void WriteLogs(string fileName, String logMessage)
        {
            using (var file = new StreamWriter(fileName, true))
            {
                file.WriteLine(logMessage);
                file.Close();
            }
        }

        //Purpose: Method To get Date & Time Stamp For Creation of Unique Number
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

        //Purpose: To Get The WebDriver Instance
        public static IWebDriver GetWebDriverInstance()
        {
            return Thread.GetData(Thread.GetNamedDataSlot("webdriverInstance")) as IWebDriver;
        }

        //Purpose: To Get The Backed Selenium Instance
        public static ISelenium GetBackedSeleniumInstance()
        {
            return Thread.GetData(Thread.GetNamedDataSlot("backedseleniumdriverInstance")) as ISelenium;
        }

        //Purpose: To Verify Succesfull Message
        public static bool VerifySuccesfullMessage(string successMsg)
        {
            try
            {
                string expectedTimeoutValue = ConfigurationManager.AppSettings["WaitUntillElementSeconds"];
                int currentWaitTime = Convert.ToInt32(expectedTimeoutValue);
                if (currentWaitTime > 0)
                {
                    var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(currentWaitTime));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("messageBoardText")));
                }
                if (Browser.Equals("FF") || Browser.Equals("GC"))
                {
                    _successMessage = WebDriver.FindElement(By.ClassName("messageBoardText")).Text;
                }
                if (Browser.Equals("IE"))
                {
                    _successMessage = WebDriver.FindElement(By.ClassName("messageBoardText")).GetAttribute("innerText");
                }
                if (successMsg != null && _successMessage.Contains(successMsg))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Purpose: To Verify Element Exists
        public static bool IsElementPresent(By by)
        {
            try
            {
                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementIsVisible(@by));
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Purpose: To Verify PopUp Window Closed
        public static bool IsPopUpClosed(int windowcount)
        {
            try
            {
                string expectedTimeoutValue = ConfigurationManager.AppSettings["WaitUntillElementSeconds"];
                int currentWaitTime = Convert.ToInt32(expectedTimeoutValue);
                int waitTimeConsumed = 0;
                if (currentWaitTime > 0)
                {
                    while (WebDriver.WindowHandles.Count >= windowcount && waitTimeConsumed < currentWaitTime)
                    {
                        Thread.Sleep(5000);
                        waitTimeConsumed += 5;
                    }
                    if (waitTimeConsumed < currentWaitTime)
                    {
                         WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Purpose: To Verify Is Window Present This Method would Verify Base Window
        public static bool IsWindowPresent(string windowName)
        {
            if (windowName == null) throw new ArgumentNullException("windowName");
            try
            {
                var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.TitleContains(windowName));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Purpose: To Verify Is Pop Up Window Present: This Method would Verify Child Window
        public static bool IsPopUpWindowPresent(string windowName)
        {
            Thread.Sleep(10000);

            string popupHandle = WebDriver.CurrentWindowHandle;
            try
            {
                IWebDriver newWindow = null;
                string originalHandle = WebDriver.WindowHandles.First().ToString(CultureInfo.InvariantCulture);
                ReadOnlyCollection<string> windowHandles = WebDriver.WindowHandles;
                foreach (string handle in windowHandles)
                {
                    newWindow = WebDriver.SwitchTo().Window(handle);
                    if (newWindow.Title.Equals(windowName))
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        //Purpose: To Select Window
        public static void SelectWindow(string windowName)
        {
            try
            {
                WaitUtilWindow(windowName);
                if (!WebDriver.WindowHandles.Any(item => WebDriver.SwitchTo().Window(item).Title == windowName))
                {
                    Logs(windowName + "window not found", "FAILED");
                }
                foreach (string item in WebDriver.WindowHandles)
                {
                    if (WebDriver.SwitchTo().Window(item).Title == windowName)
                    {
                        WebDriver.SwitchTo().Window(item);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : To Upload File
        public static void FileUpload(string filename, By by)
        {
            try
            {
                string uploadUserFilePath = (Path.GetDirectoryName(
              System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
              + "\\Bulk Upload Import\\").Replace("file:\\", "");

                WebDriver.FindElement(@by).SendKeys(uploadUserFilePath + filename);
            }
            catch (Exception e)
            {
                Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : To Wait Until Particular Window Get Loaded
        public static bool WaitUtilWindow(string windowName)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int secondsToWait = Int32.Parse(ConfigurationManager.AppSettings["WaitUntillElementSeconds"]);
            int currentWaitTime = Convert.ToInt32(secondsToWait);
            while (sw.Elapsed.TotalSeconds < currentWaitTime)
            {
                try
                {
                    if (WebDriver.WindowHandles.Any(item => WebDriver.SwitchTo().Window(item).Title == windowName))
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            sw.Stop();
            sw = null;
            return false;
        }

        // Purpose : To Wait Until Particular Window and Element Get Loaded
        public static bool WaitUntillWindowAndElement(string windowName, By by)
        {
            Boolean windowFound = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                int secondsToWait = Int32.Parse(ConfigurationManager.AppSettings["WaitUntillElementSeconds"]);
                int currentWaitTime = Convert.ToInt32(secondsToWait);
                while (sw.Elapsed.TotalSeconds < currentWaitTime)
                {
                    if (WebDriver.WindowHandles.Any(item => WebDriver.SwitchTo().Window(item).Title == windowName))
                    {
                        SelectWindow(windowName);
                        WebDriverWait setwait = new WebDriverWait(WebDriver, TimeSpan.FromMinutes(Convert.ToInt32(ConfigurationManager.AppSettings["WaitUntillElementMinutes"])));
                        setwait.Until((element) => { return element.FindElement(@by).Displayed; });
                        windowFound = true;
                        break;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            sw.Stop();
            sw = null;
            return windowFound;
        }

        //Purpose: Handling Modal Pop Up Window
        public static void CloseModalPopUp()
        {
            string originalHandle = WebDriver.CurrentWindowHandle;
            DateTime timeoutEnd = DateTime.Now.Add(TimeSpan.FromSeconds(5));
            while (WebDriver.WindowHandles.Count == 1 && DateTime.Now < timeoutEnd)
            {
                Thread.Sleep(100);
            }
            foreach (string handle in WebDriver.WindowHandles)
            {
                if (handle != originalHandle)
                {
                    WebDriver.SwitchTo().Window(handle);
                    break;
                }
            }
        }

        // Purpose: To Select Default Window Specfic To Browsers
        public static void SelectDefaultWindow()
        {
            try
            {
                if (Browser.Equals("IE") || Browser.Equals("FF"))
                {
                    WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                }
                if (Browser.Equals("GC"))
                {
                    WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                }
            }
            catch (Exception e)
            {
                Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Wait For Thinking Indicator Gets Load's Out
        public static bool ThinkingIndicatorProcessing()
        {
            Thread.Sleep(5000);
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var secondsToWait = Int32.Parse(ConfigurationManager.AppSettings["WaitUntillElementSeconds"]);
                while (sw.Elapsed.TotalSeconds < secondsToWait)
                {

                    bool isThinkingIndicatorPresent = IsElementPresent(By.XPath("//img[contains(@src,'/Pegasus/App_Static/IMG/ThinkingIndicator/process.gif')]"));
                    if (!isThinkingIndicatorPresent)
                    {
                        return true;
                    }
                }
                sw.Stop();
                sw = null;
            }
            catch (TimeoutException e)
            {
                Logs(e.ToString(), "FAILED");
                throw new TimeoutException(e.ToString());
            }
            catch (Exception e)
            {
                Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
            return false;
        }

        //Purpose: To verify Page Loading
        public static bool PageLoadingProcessing()
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["WaitUntillElementSeconds"]);
                while (sw.Elapsed.TotalMinutes < minutesToWait)
                {
                    IWebElement loadingText = WebDriver.FindElement(By.TagName("body"));
                    if (!loadingText.Text.Contains("Loading"))
                    {
                        return true;
                    }
                }
                sw.Stop();
                sw = null;
            }
            catch (TimeoutException e)
            {
                Logs(e.ToString(), "FAILED");
                throw new TimeoutException(e.ToString());
            }
            return false;
        }

        //Purpose: To verify announcement page
        public static bool CloseAnnouncementPage()
        {

          // WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            if (IsElementPresent(By.Id("lightboxid")))
            {
                WebDriver.SwitchTo().Frame("lightboxid");
                bool isArrowPresent = IsElementPresent((By.Id("_ctl0_InnerPageContent_lnkNext")));
                while (isArrowPresent == true)
                {
                    IWebElement nextButton = WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_lnkNext"));
                    nextButton.Click();
                    if (IsElementPresent(By.Id("_ctl0_InnerPageContent_btnClose")))
                    {
                        break;
                    }
                }
                IWebElement closeButton = WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_btnClose"));
                closeButton.Click();
                WebDriver.SwitchTo().DefaultContent();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                if (!IsElementPresent(By.Id("lightboxid")))
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        //Purpose: To Wait For Url To Get Change
        public static bool WaitForUrlGetChange(string urlKeyword)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var secondsToWait = Int32.Parse(ConfigurationManager.AppSettings["WaitUntillElementSeconds"]);
                while (sw.Elapsed.TotalSeconds < secondsToWait)
                {
                    bool isUrlChanged = WebDriver.Url.Contains(urlKeyword);
                    if (isUrlChanged)
                    {
                        return true;
                    }
                }
                sw.Stop();
                sw = null;
            }
            catch (TimeoutException e)
            {
                Logs(e.ToString(), "FAILED");
                throw new TimeoutException(e.ToString());
            }
            catch (Exception e)
            {
                Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
            return false;
        }

        //Purpose: To Close Student Help Text Window
        public static bool CloseStudentHelpTextWindow()
        {
            bool isStudentHelpTextWindowPresent = IsPopUpWindowPresent("Student Help Text");
            if (isStudentHelpTextWindowPresent)
            {
                SelectWindow("Student Help Text");
                WaitUntilElement(By.Id("chkDisplay"));
                WebDriver.FindElement(By.Id("chkDisplay")).Click();
                WaitUntilElement(By.Id("imgOk"));
                WebDriver.FindElement(By.Id("imgOk")).Click();
            }
            else
            {
                return true;
            }
            bool isStudentHelpTextWindowClosed = IsPopUpClosed(2);
            if (isStudentHelpTextWindowClosed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Purpose: To Verify Template Processing State
        public static void ToVerifyTemplateInactiveState()
        {
            SelectWindow("Program Administration");
            WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
            WaitUntilElement(By.Id("grdTemplateSection$divContent"));
            //To Fetch associated course info
            string associatedCourse = DatabaseTools.GetCourse(Enumerations.CourseType.MySpanishLabMasterCourse);
            if (associatedCourse == null) throw new ArgumentNullException("associa" + "tedCourse is null");
            IWebElement templateCourse = WebDriver.FindElement(By.Id("grdTemplateSection$divContent"));
            if (templateCourse == null) throw new ArgumentNullException("templat" + "eCourse is null");
            if (templateCourse.Text.Contains(associatedCourse))
            {
                Logs("Associated course has been matched in the template frame", "passed");
            }
            else
            {
                WebDriver.SwitchTo().DefaultContent();
                SelectWindow("Program Administration");
                WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                WaitUntilElement(By.XPath("//IMG[@class='CursorHand']"));
                WebDriver.FindElement(By.XPath("//IMG[@class='CursorHand']")).Click();
                SelectWindow("Add New Template");
                WaitUntilElement(By.Id("btnAddTemplate"));
                WebDriver.FindElement(By.Id("btnAddTemplate")).Click();
                IsPopUpClosed(2);
                WebDriver.SwitchTo().DefaultContent();
                SelectWindow("Program Administration");
                WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                WaitUntilElement(By.Id("grdTemplateSection$divContent"));
            }
            WaitUntilElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody/tr/td[2]"));
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
            while (sw.Elapsed.Minutes < minutesToWait)
            {
                IWebElement assignedToCopyText = WebDriver.FindElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table"));
                if (assignedToCopyText.Text.Contains("[Request is Processing") == false) break;
                {
                    WebDriver.SwitchTo().DefaultContent();
                    SelectWindow("Program Administration");
                    WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                    Thread.Sleep(6000);
                    WaitUntilElement(By.PartialLinkText("Search"));
                    WebDriver.FindElement(By.PartialLinkText("Search")).Click();
                    WebDriver.SwitchTo().ActiveElement();
                    WaitUntilElement(By.Id("ddSearchCondition"));
                    new SelectElement(WebDriver.FindElement(By.Id("ddSearchCondition"))).SelectByText("Contains");
                    WaitUntilElement(By.Id("txtSectionDetail"));
                    WebDriver.FindElement(By.Id("txtSectionDetail")).Clear();
                    WebDriver.FindElement(By.Id("txtSectionDetail")).SendKeys(associatedCourse);
                    WaitUntilElement(By.Id("lnkbuttonsearch"));
                    WebDriver.FindElement(By.Id("lnkbuttonsearch")).Click();
                    Thread.Sleep(8000);
                    WebDriver.SwitchTo().DefaultContent();
                    SelectWindow("Program Administration");
                    WaitUntilElement(By.Id("_ctl0_PageContent_ifrmMiddle"));
                    WebDriver.SwitchTo().Frame("_ctl0_PageContent_ifrmMiddle");
                    WaitUntilElement(By.XPath("//div[@id='grdTemplateSection$divContent']/table/tbody/tr/td/table/tbody/tr/td[2]"));
                }
            }
            sw.Stop();
            sw = null;
        }
    }
}
