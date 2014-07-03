using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Selenium;
namespace Framework.CommonBaseTestScript.BaseTestScript
{
    public class CommonBaseTestScript
    {
        public static IWebDriver WebDriver = null;
        public static ISelenium BackedSelenium = null;
        public static SqlConnection DatConnection = DatabaseTools.GetSqlConnection();
        private static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        // Purpose: To Start WebDriver
        public static void WebDriverStart()
        {
            //ScreenCaptureJobStart();
            WebDriver.Navigate().GoToUrl(DatabaseTools.GetUrl(Enumerations.UserType.WsAdmin));
            WebDriver.Manage().Cookies.DeleteAllCookies();
            WebDriver.Manage().Window.Maximize();
            Thread.SetData(Thread.GetNamedDataSlot("webdriverInstance"), WebDriver);
            Thread.SetData(Thread.GetNamedDataSlot("backedseleniumdriverInstance"), BackedSelenium);
        }

        // Purpose: To Stop WebDriver
        public static void WebDriverStop()
        {
            try
            {
                //Purpose: Stops all the associated services
                if (Browser.ToUpper() == "IE")
                {
                    Process[] iexpPro = Process.GetProcessesByName("iexplore");
                    if (iexpPro.Length > 0)
                    {
                        foreach (Process clsProcess in iexpPro)
                        {
                            clsProcess.Kill();
                        }
                    }
                }
                if (Browser.ToUpper().Equals("FF"))
                {
                    Process[] fireFoxPro = Process.GetProcessesByName("firefox");
                    if (fireFoxPro.Length > 0)
                    {
                        foreach (Process clsProcess in fireFoxPro)
                        {
                            clsProcess.Kill();
                        }
                    }
                }
                if (Browser.ToUpper().Equals("Safari"))
                {
                    Process[] safariPro = Process.GetProcessesByName("safari");
                    if (safariPro.Length > 0)
                    {
                        foreach (Process clsProcess in safariPro)
                        {
                            clsProcess.Kill();
                        }
                    }
                }
                if (Browser.ToUpper().Equals("GC"))
                {
                    Process[] chromePro = Process.GetProcessesByName("chrome");
                    if (chromePro.Length > 0)
                    {
                        foreach (Process clsProcess in chromePro)
                        {
                            clsProcess.Kill();
                        }
                    }
                }

                Process[] ieDriverserver = Process.GetProcessesByName("IEDriverServer");
                if (ieDriverserver.Length > 0)
                {
                    foreach (Process clsProcess in ieDriverserver)
                    {
                        clsProcess.Kill();
                    }
                }
                Process[] chromeDriverserver = Process.GetProcessesByName("chromedriver");
                if (chromeDriverserver.Length > 0)
                {
                    foreach (Process clsProcess in chromeDriverserver)
                    {
                        clsProcess.Kill();
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            //WebDriver = null;
            Console.WriteLine("WebDriver Stopped");
        }

        // Purpose: To Initialize TestScript
        public static void TestInitialize()
        {
            try
            {
               // WebDriverStop();
                if (WebDriver != null) WebDriver.Dispose();
                //Purpose: Opening DB Connection
                if (DatConnection.State == ConnectionState.Open)
                {
                    DatConnection.Close();
                }
                DatConnection.Open();

                //Purpose: Call Method To Select Browser To Run Test 
                BrowserSetup();

                //Purpose : Call Method To Start WebDriver
                WebDriverStart();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString() + " Please Try Again.");
            }
        }

        // Purpose: To Dispose TestScript
        public static void TearDown()
        {
            try
            {
                //Purpose: Closing DB Connection
                if (DatConnection.State == ConnectionState.Open)
                {
                    DatConnection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Unable To Close WebDriver: Please Try Again. " + e.ToString());
            }
            //ScreenCaptureJobStop();
            WebDriverStop();
            Thread.SetData(Thread.GetNamedDataSlot("webdriverInstance"), WebDriver);
            Thread.SetData(Thread.GetNamedDataSlot("backedseleniumdriverInstance"), BackedSelenium);
        }

        //Purpose: Selecting Browser To Run Test 
        public static void BrowserSetup()
        {
            if (Browser.ToUpper().Equals("IE"))
            {
                String processorArchitecture = Microsoft.Win32.Registry.GetValue(
                    "HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Control\\Session Manager\\Environment"
                    , "PROCESSOR_ARCHITECTURE", null).ToString();

                string ieDriverPath =
                    (Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                    + "\\..\\..\\..\\..\\ExternalAssemblies\\" + ((processorArchitecture == "x86") ? "x86" : "x64")).Replace("file:\\", "");

                var options = new InternetExplorerOptions { IntroduceInstabilityByIgnoringProtectedModeSettings = true };
                WebDriver = new InternetExplorerDriver(ieDriverPath, options, TimeSpan.FromMinutes(10));
                WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromMinutes(5));
                BackedSelenium = new WebDriverBackedSelenium(WebDriver, ConfigurationManager.AppSettings["browserUrl"]);
                BackedSelenium.Start();
            }
            if (Browser.ToUpper().Equals("FF"))
            {
                FirefoxProfile firefoxProfile = new FirefoxProfile();
                firefoxProfile.EnableNativeEvents = false;
                WebDriver = new FirefoxDriver();
                WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromMinutes(5));
                BackedSelenium = new WebDriverBackedSelenium(WebDriver, ConfigurationManager.AppSettings["browserUrl"]);
                BackedSelenium.Start();
            }
            if (Browser.ToUpper().Equals("Safari"))
            {
                WebDriver = new SafariDriver();
                WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromMinutes(5));
                BackedSelenium = new WebDriverBackedSelenium(WebDriver, ConfigurationManager.AppSettings["browserUrl"]);
                BackedSelenium.Start();
            }
            if (Browser.ToUpper().Equals("GC"))
            {
                string chromeDriverPath = (Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                + "\\..\\..\\..\\..\\ExternalAssemblies").Replace("file:\\", "");
                WebDriver = new ChromeDriver(chromeDriverPath);
                Thread.Sleep(5000);
                BackedSelenium = new WebDriverBackedSelenium(WebDriver, ConfigurationManager.AppSettings["browserUrl"]);
                BackedSelenium.Start();
            }
        }

        //Purpose : To Verify The Test Environment Status
        public static int NetworkStatus()
        {
            HttpWebRequest req = WebRequest.Create(DatabaseTools.GetUrl(Enumerations.UserType.WsAdmin)) as HttpWebRequest;
            HttpWebResponse rsp = null;
            try
            {
                if (req != null) rsp = req.GetResponse() as HttpWebResponse;
            }
            catch (WebException e)
            {
                if (e.Response is HttpWebResponse)
                {
                    rsp = e.Response as HttpWebResponse;
                }
                else
                {
                    rsp = null;
                }
                throw new Exception(e.ToString());
            }
            if (rsp != null && rsp.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine(rsp.StatusCode);
            }
            return Convert.ToInt16(rsp.StatusCode);
        }
    }
}