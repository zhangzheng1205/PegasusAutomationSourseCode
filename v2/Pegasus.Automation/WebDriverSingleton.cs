using OpenQA.Selenium;
using Selenium;
using System;
using System.Diagnostics;

namespace Pearson.Pegasus.TestAutomation.Frameworks
{
    /// <summary>
    /// This is the base test script
    /// </summary>
    public class WebDriverSingleton : IDisposable
    {
        private IWebDriver webDriver = null;
        private ISelenium selenium = null;
        private string browser;

        public string Browser
        {
            get { return browser; }
        }

        private static WebDriverSingleton webDriverSingleton = null;

        /// <summary>
        /// This method returns an instance of web driver singleton.
        /// </summary>
        /// <returns></returns>
        public static WebDriverSingleton GetInstance()
        {
            if (webDriverSingleton == null)
            {
                webDriverSingleton = new WebDriverSingleton();
            }

            return webDriverSingleton;
        }

        /// <summary>
        /// Returns an instance of web driver
        /// </summary>
        public IWebDriver WebDriver
        {
            get
            {
                if (webDriverSingleton == null)
                {
                    webDriverSingleton = new WebDriverSingleton();
                }
                return webDriver;
            }
        }

        /// <summary>
        /// Returns an instance of Selenium
        /// </summary>
        public ISelenium Selenium
        {
            get
            {
                if (webDriverSingleton == null)
                {
                    webDriverSingleton = new WebDriverSingleton();
                }
                return selenium;
            }
        }

        /// <summary>
        /// Resets the singleton
        /// </summary>
        public void ResetSingleton()
        {
            Cleanup();
            webDriverSingleton = new WebDriverSingleton();
        }

        /// <summary>
        /// Creates an instance of the web driver
        /// </summary>
        protected WebDriverSingleton()
        {
            WebDriverFactory.Init();
            browser = WebDriverFactory.GetBrowser();

            webDriver = WebDriverFactory.GetInstance();
            selenium = new WebDriverBackedSelenium(webDriver, AutomationConfigurationManager.WorkSpaceURLRoot);
            webDriver.Navigate().GoToUrl(AutomationConfigurationManager.WorkSpaceURLRoot + "frmlogin.aspx?mode=admin");
            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Cleans up the web driver and related processess.
        /// </summary>
        public void Cleanup()
        {
            try
            {
                if (webDriver != null) webDriver.Quit();
                Process[] processesToKill = BrowserProcessFactory.GetProcessInstance();
                foreach (Process processToKill in processesToKill)
                {
                    try
                    {
                        // kill and clean all processess
                        processToKill.Kill();
                    }
                    catch
                    {
                        //This exception is being consumed so that if a process is not killed the testing will not stop
                    }
                }
            }
            catch
            {
                //This exception is being consumed so that if a process is not killed the testing will not stop
            }
        }

        /// <summary>
        /// Disposes the drivers
        /// </summary>
        public void Dispose()
        {
            Cleanup();
        }
    }
}
