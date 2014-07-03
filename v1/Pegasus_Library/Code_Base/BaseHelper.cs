using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using TechTalk.SpecFlow;
using System.Diagnostics;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;
using Pegasus_DataAccess;

namespace Pegasus.BaseHelper
{
    [Binding]
    public  class Helper
    {
        public static IWebDriver WebDriver = null;
        public static ISelenium Selenium;
        public static SqlConnection DatConnection = DatabaseTools.GetSqlConnection();

        // Pupose: Action Before Test Run
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            try
            {
                //Purpose: Opening DB Connection
                DatConnection.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Unable To Open Database Connection: Please Try Again.");
            }
            WebDriverStart();
        }


        // Purpose: Action After test Run
        [AfterTestRun]
        public static void AfterTestRun()
        {
            WebDriverStop();
            try
            {
                //Purpose: Closing DB Connection
                DatConnection.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Unable To Clode WebDriver: Please Try Again.");
            }
        }

        // Purpose: To Start WebDriver
        public static void WebDriverStart()
        {
            try
            {
                string ieDriverPath = ConfigurationManager.AppSettings["ieDriverPath"];
                var options = new InternetExplorerOptions { IntroduceInstabilityByIgnoringProtectedModeSettings = true };
                WebDriver = new InternetExplorerDriver(ieDriverPath, options);
                Selenium = new WebDriverBackedSelenium(WebDriver, ConfigurationManager.AppSettings["browserUrl"]);
                Selenium.Start();
                Thread.Sleep(5000);
                WebDriver.Navigate().GoToUrl(ConfigurationManager.AppSettings["browserUrl"]);
                WebDriver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 0, 5));
                WebDriver.Manage().Window.Maximize();
            }
            catch (Exception e)
            {
                //GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
            Console.WriteLine("WebDriver Started");
        }

        // Purpose: To Stop WebDriver
        public static void WebDriverStop()
        {
            if (WebDriver == null)
                return;
            try
            {
                WebDriver.Manage().Cookies.DeleteAllCookies();
                WebDriver.Dispose();
                Selenium.Stop();
                Process[] iexppro = Process.GetProcessesByName("iexplore");
                if (iexppro.Length > 0)
                {
                    foreach (Process clsProcess in iexppro)
                    {
                        clsProcess.Kill();
                    }
                }
                Process[] selcomwin = Process.GetProcessesByName("mshta");
                if (selcomwin.Length > 0)
                {
                    foreach (Process clsProcess in selcomwin)
                    {
                        clsProcess.Kill();
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
            }
            catch (Exception)
            {
                throw new Exception("Unable To Stop WebDriver: Please Try Again.");
            }
            WebDriver = null;
            Console.WriteLine("WebDriver Stopped");
        }
    }
}
