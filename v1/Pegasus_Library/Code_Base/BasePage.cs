using System;
using System.Configuration;
using System.Threading;
using Pegasus_Library.Library;
using Selenium;
using OpenQA.Selenium;
namespace Pegasus_Library.Code_Base
{
    public abstract class BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        
        //Purpose: // Defined WebDriver Constructor
        public static IWebDriver WebDriver
        {
            get
            {
               // if (_webdriver == null)
                    _webdriver = GenericHelper.GetWebDriverInstance();
                if (!Browser.Equals("GC"))
                {
                    _webdriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromMinutes(10));
                }
                if (Browser.Equals("GC"))
                {
                    Thread.Sleep(3000);
                }
                return _webdriver;
            }
        }

        public static ISelenium BackedSelenium
        {
            get
            {
                if (_backedselenium == null)
                    _backedselenium = GenericHelper.GetBackedSeleniumInstance();
                return _backedselenium;
            }
        }
        private static IWebDriver _webdriver;
        private static ISelenium _backedselenium;
    }
}