using System.IO;
using OpenQA.Selenium;
using Selenium;
using System;
using System.Diagnostics;

namespace Pearson.Pegasus.TestAutomation.Frameworks
{
    /// <summary>
    /// This is the base test script.
    /// </summary>
    public class WebDriverSingleton : IDisposable
    {
        private readonly IWebDriver _webDriver = null;
        private readonly ISelenium _selenium = null;
        private readonly string _browser;

        // download file path
        private static readonly string DownloadFilePath = (AutomationConfigurationManager.
            DownloadFilePath + "\\ApplicationDownloadedFiles").Replace("file:\\", "");

        /// <summary>
        /// Get browser instance.
        /// </summary>
        public string Browser
        {
            get { return _browser; }
        }

        private static WebDriverSingleton _webDriverSingleton = null;

        /// <summary>
        /// This method returns an instance of web driver singleton.
        /// </summary>
        /// <returns></returns>
        public static WebDriverSingleton GetInstance()
        {
            if (_webDriverSingleton == null)
            {
                _webDriverSingleton = new WebDriverSingleton();
            }

            return _webDriverSingleton;
        }

        /// <summary>
        /// Returns an instance of web driver
        /// </summary>
        public IWebDriver WebDriver
        {
            get
            {
                if (_webDriverSingleton == null)
                {
                    _webDriverSingleton = new WebDriverSingleton();
                }
                return _webDriver;
            }
        }

        /// <summary>
        /// Returns an instance of Selenium
        /// </summary>
        public ISelenium Selenium
        {
            get
            {
                if (_webDriverSingleton == null)
                {
                    _webDriverSingleton = new WebDriverSingleton();
                }
                return _selenium;
            }
        }

        /// <summary>
        /// Resets the singleton
        /// </summary>
        public void ResetSingleton()
        {
            Cleanup();
            _webDriverSingleton = new WebDriverSingleton();
        }

        /// <summary>
        /// Creates an instance of the web driver
        /// </summary>
        protected WebDriverSingleton()
        {
            WebDriverFactory.Init();
            _browser = WebDriverFactory.GetBrowser();
            _webDriver = WebDriverFactory.GetInstance();
            Array.ForEach(Directory.GetFiles(DownloadFilePath), File.Delete);
            _selenium = new WebDriverBackedSelenium(_webDriver, AutomationConfigurationManager.WorkSpaceUrlRoot);
            _webDriver.Navigate().GoToUrl(AutomationConfigurationManager.WorkSpaceUrlRoot + "frmlogin.aspx?mode=admin");
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Cleans up the web driver and related processess.
        /// </summary>
        public void Cleanup()
        {
            try
            {
                if (_webDriver != null) _webDriver.Quit();
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
