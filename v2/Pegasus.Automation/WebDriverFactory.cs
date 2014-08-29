using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace Pearson.Pegasus.TestAutomation.Frameworks
{
    /// <summary>
    /// Factory to get instance of web driver.
    /// </summary>
    internal static class WebDriverFactory
    {
        private const string ENV_PEG_AUTOMATION_REMOTE = "PEG_AUTOMATION_IS_REMOTE";
        private const string ENV_PEG_AUTOMATION_BROWSER = "PEG_AUTOMATION_BROWSER";
        private const string ENV_PEG_AUTOMATION_REMOTE_HUB_URL = "PEG_AUTOMATION_REMOTE_HUB_URL";

        private const string APP_SETTINGS_BROWSER = "Browser";
        private const string APP_SETTINGS_REMOTE = "isRemote";
        private const string APP_SETTINGS_REMOTE_HUB_URL = "remoteHubUrl";

        private static bool _isChromeExecuted;
        private const bool IsInternetExplorerExecuted = false;
        private static int _counter = 1;

        /// <summary>
        /// This is the time out for the load.
        /// </summary>
        private static readonly int TimeOut = Convert.ToInt16(ConfigurationManager.AppSettings["WebDriverTimeOutInSeconds"]);
        private static bool _isRemote = false;
        private static string _browserName;
        private static string _remoteHubUrl;
        private static readonly string DownloadFilePath = (AutomationConfigurationManager.DownloadFilePath + "\\ApplicationDownloadedFiles").Replace("file:\\", "");

        /// <summary>
        /// Get Environment Variables.
        /// </summary>
        public static void Init()
        {
            Console.Out.WriteLine(string.Format("Attempting to get ENV_PEG_AUTOMATION_REMOTE"));
            bool success = Boolean.TryParse(Environment.GetEnvironmentVariable(ENV_PEG_AUTOMATION_REMOTE), out _isRemote);
            if (!success)
            {
                Console.Out.WriteLine(string.Format("Attempting to get APP_SETTINGS_REMOTE"));
                Boolean.TryParse(ConfigurationManager.AppSettings[APP_SETTINGS_REMOTE], out _isRemote);
            }
            Console.Out.WriteLine("IS_REMOTE = {0}", _isRemote);

            Console.Out.WriteLine(string.Format("Attempting to get ENV_PEG_AUTOMATION_BROWSER"));
            _browserName = Environment.GetEnvironmentVariable(ENV_PEG_AUTOMATION_BROWSER);
            if (string.IsNullOrEmpty(_browserName))
            {
                Console.Out.WriteLine(string.Format("Attempting to get APP_SETTINGS_BROWSER"));
                _browserName = ConfigurationManager.AppSettings[APP_SETTINGS_BROWSER];
            }
            Console.Out.WriteLine("BROWSER = {0}", _browserName);

            if (_isRemote)
            {
                Console.Out.WriteLine(string.Format("Attempting to get ENV_PEG_AUTOMATION_REMOTE_HUB_URL"));
                _remoteHubUrl = Environment.GetEnvironmentVariable(ENV_PEG_AUTOMATION_REMOTE_HUB_URL);
                if (string.IsNullOrEmpty(_remoteHubUrl))
                {
                    Console.Out.WriteLine(string.Format("Attempting to get APP_SETTINGS_REMOTE_HUB_URL"));
                    _remoteHubUrl = ConfigurationManager.AppSettings[APP_SETTINGS_REMOTE_HUB_URL];
                }
                Console.Out.WriteLine("REMOTE_HUB_URL = {0}", _remoteHubUrl);
            }
        }

        /// <summary>
        /// Returns an instance of the web driver based on test browser.
        /// </summary>
        /// <returns>The browser driver.</returns>
        public static IWebDriver GetInstance()
        {
            IWebDriver webDriver = null;

            if (_isRemote)
            {
                DesiredCapabilities remoteCapability;
                switch (_browserName)
                {
                    // get browser driver based on browserName
                    case PegasusBaseTestFixture.InternetExplorer: remoteCapability = DesiredCapabilities.InternetExplorer(); break;
                    case PegasusBaseTestFixture.FireFox: remoteCapability = DesiredCapabilities.Firefox(); break;
                    case PegasusBaseTestFixture.Safari: remoteCapability = DesiredCapabilities.Safari(); break;
                    case PegasusBaseTestFixture.Chrome: remoteCapability = DesiredCapabilities.Chrome(); break;
                    default: throw new ArgumentException("The suggested browser was not found");
                }
                // object representing the image of the page on the screen
                webDriver = new ScreenShotRemoteWebDriver(new Uri(_remoteHubUrl), remoteCapability);
            }
            else
            {
                switch (_browserName)
                {
                    // get browser driver based on browserName
                    case PegasusBaseTestFixture.InternetExplorer: webDriver = IeWebDriver(); break;
                    case PegasusBaseTestFixture.FireFox: webDriver = FireFoxWebDriver(); break;
                    case PegasusBaseTestFixture.Safari: webDriver = SafariWebDriver(); break;
                    case PegasusBaseTestFixture.Chrome: webDriver = ChromeWebDriver(); break;
                    case PegasusBaseTestFixture.MultiBrowser: MultiBrowserWebDriver(ref webDriver); break;
                    default: throw new ArgumentException("The suggested browser was not found");
                }
            }
            return webDriver;
        }

        /// <summary>
        /// Multi Browser Web Driver.
        /// </summary>
        /// <param name="webDriver">This is instance of webdriver.</param>
        /// <returns>Driver browser list.</returns>
        private static DesiredCapabilities[] MultiBrowserWebDriver(ref IWebDriver webDriver)
        {
            // set each browser desired capabilities
            var browserList = new DesiredCapabilities[] { 
                DesiredCapabilities.Chrome(), 
                DesiredCapabilities.Firefox(),
                DesiredCapabilities.InternetExplorer()
            };
            foreach (DesiredCapabilities browser in browserList)
            {
                if ((_isChromeExecuted == false) || ((_isChromeExecuted == true) && (_counter == 2)))
                {
                    if (_counter == 4)
                    {
                        _counter = 2;
                    }
                    if (browser.BrowserName == "chrome")
                    {
                        _isChromeExecuted = true;
                        _counter = _counter + 1;
                        webDriver = ChromeWebDriver(); break;
                    }
                }
                else if ((_isChromeExecuted == true) && (_counter == 3))
                {
                    _counter = _counter + 1;
                    webDriver = FireFoxWebDriver(); break;
                }

                else if ((IsInternetExplorerExecuted == false) && (_counter > 3))
                {
                    _isChromeExecuted = false;
                    webDriver = IeWebDriver(); break;
                }
            }
            return browserList;
        }

        /// <summary>
        /// Returns an instance of IE based driver.
        /// </summary>
        /// <returns>IE based driver.</returns>
        private static IWebDriver IeWebDriver()
        {
            // get machine processor architecture
            String getProcessorArchitecture = Registry.GetValue(
                "HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Control\\Session Manager\\Environment"
                , "PROCESSOR_ARCHITECTURE", null).ToString();
            // get installed browser's version in machine
            Dictionary<string, string> browserList = GetBrowserDetails();
            // get Ie driver path based on Ie version installed in 
            String getIeDriverPath;
            if (getProcessorArchitecture.Contains("64") && (browserList.ContainsKey("IE") && browserList["IE"].Contains("10.")
                    || (browserList.ContainsKey("IE") && browserList["IE"].Contains("11."))))
            {

                // get Ie driver path
                getIeDriverPath =
                    (Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)
                     + "\\..\\..\\..\\..\\ExternalAssemblies\\x86").Replace("file:\\", "");
            }
            else
            {
                // Ie driver path
                getIeDriverPath =
                    (Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase)
                     + "\\..\\..\\..\\..\\ExternalAssemblies\\" + ((getProcessorArchitecture == "x86") ? "x86" : "x64"))
                        .Replace("file:\\", "");
            }
            // start internet explorer driver service
            InternetExplorerDriverService ieservice = InternetExplorerDriverService.CreateDefaultService(getIeDriverPath);
            ieservice.LoggingLevel = InternetExplorerDriverLogLevel.Info;
            // get path for save log execution file
            String getExecutingPath = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            if (getExecutingPath != null)
                ieservice.LogFile = Path.Combine(getExecutingPath, "Log", "IEDriver" + DateTime.Now.Ticks + ".log");
            // set internet explorer options
            var options = new InternetExplorerOptions
                                                  {
                                                      IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                                                      UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Ignore,
                                                      IgnoreZoomLevel = true,
                                                      EnableNativeEvents = true,
                                                      BrowserAttachTimeout = TimeSpan.FromMinutes(20),
                                                      EnablePersistentHover = false
                                                  };
            // create internet explorer driver object
            IWebDriver webDriver = new InternetExplorerDriver(ieservice, options, TimeSpan.FromMinutes(20));
            // set webDriver page load duration
            webDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromMinutes(20));
            // set cursor position center of the screen
            Cursor.Position = new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            return webDriver;
        }

        /// <summary>
        /// Returns an instance of Firefox based driver.
        /// </summary>
        /// <returns>FireFox based driver</returns>
        private static IWebDriver FireFoxWebDriver()
        {
            // create profile object
            var profile = new FirefoxProfile();
            // get Log Execution Path
            String getExecutingPath = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            // set profile preferences
            profile.SetPreference("FireFox" + DateTime.Now.Ticks + ".log", getExecutingPath);
            profile.SetPreference("browser.download.folderList", 2);
            profile.SetPreference("browser.download.dir", DownloadFilePath);
            profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream doc docx xls xlsx pdf txt zip");
            IWebDriver webDriver = new FirefoxDriver(new FirefoxBinary(), profile, TimeSpan.FromMinutes(3));
            // set page load duration
            webDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(TimeOut));
            // set cursor position center of the screen
            Cursor.Position = new Point(Screen.PrimaryScreen.Bounds.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2);
            return webDriver;
        }

        /// <summary>
        /// Returns an instance of Safari based driver.
        /// </summary>
        /// <returns>Safari based driver.</returns>
        private static IWebDriver SafariWebDriver()
        {
            // create safari browser object
            IWebDriver webDriver = new SafariDriver();
            webDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(TimeOut));
            return webDriver;
        }

        /// <summary>
        /// Returns an instance of Chrome based driver.
        /// </summary>
        /// <returns>Chrome based driver</returns>
        private static IWebDriver ChromeWebDriver()
        {
            // chrome preferences
            var chromeOptions = new ChromeOptionsWithPrefs
            {
                Prefs = new Dictionary<string, object>
                {
                    {"download.default_directory", DownloadFilePath},
                    {"download.prompt_for_download", false},
                    {"profile.default_content_settings.popups", 0},
                    {"intl.accept_languages", "nl"}
                }
            };

            // chrome capabilities
            var desiredCapabilities = DesiredCapabilities.Chrome();
            desiredCapabilities.SetCapability(ChromeOptions.Capability, chromeOptions);
            // chrome driver path
            string chromeDriverPath = (Path.GetDirectoryName
                (Assembly.GetExecutingAssembly().GetName().CodeBase)
                + "\\..\\..\\..\\..\\ExternalAssemblies").Replace("file:\\", "");
            // create chrome browser instance
            IWebDriver webDriver = new ChromeDriver(chromeDriverPath, chromeOptions, TimeSpan.FromMinutes(3));
            return webDriver;
        }

        /// <summary>
        /// Property Chrome Options With Preferences.
        /// </summary>
        public class ChromeOptionsWithPrefs : ChromeOptions
        {
            public Dictionary<string, object> Prefs { get; set; }
        }

        /// <summary>
        /// Returns list of installed browsers in local machine.
        /// </summary>
        /// <returns>Browser Name and Version List.</returns>
        private static Dictionary<string, string> GetBrowserDetails()
        {
            var browserList = new Dictionary<string, string>();

            // check in current user -- chrome
            object path = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", string.Empty, null);
            if (path == null)
            {
                // check in local machine -- chrome
                path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", string.Empty, null);
                if (path != null)
                {
                    browserList.Add("Chrome", FileVersionInfo.GetVersionInfo(path.ToString()).FileVersion);
                }
            }
            else
            {
                browserList.Add("Chrome", FileVersionInfo.GetVersionInfo(path.ToString()).FileVersion);
            }

            // check in local machine -- FF
            path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\firefox.exe", string.Empty, null);
            if (path != null)
            {
                browserList.Add("FireFox", FileVersionInfo.GetVersionInfo(path.ToString()).FileVersion);
            }

            // check in local machine --IE
            path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\iexplore.exe", string.Empty, null);
            if (path != null)
            {
                browserList.Add("IE", FileVersionInfo.GetVersionInfo(path.ToString()).FileVersion);
            }

            return browserList;
        }

        /// <summary>
        /// Object for browser instance.
        /// </summary>
        /// <returns>Browser instance.</returns>
        internal static string GetBrowser()
        {
            return _browserName;
        }
    }
}
