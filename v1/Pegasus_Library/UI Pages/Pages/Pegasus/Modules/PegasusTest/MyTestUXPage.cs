using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pegasus_Library.Code_Base;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.PegasusTest
{
    public class MyTestUXPage: BasePage 
    {
        //Purpose: Constant Declaration
        private static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private static string _successMessage = null;

        //Purpose: To
        public  bool VerifySuccesfullMessage(string successMsg)
        {
            try
            {
                string expectedTimeoutValue = ConfigurationManager.AppSettings["WaitUntillElementSeconds"];
                int currentWaitTime = Convert.ToInt32(expectedTimeoutValue);
                if (currentWaitTime > 0)
                {
                    var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(currentWaitTime));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("messageBoardTextblk")));
                }
                if (Browser.Equals("FF") || Browser.Equals("GC"))
                {
                    _successMessage = WebDriver.FindElement(By.ClassName("messageBoardTextblk")).Text;
                }
                if (Browser.Equals("IE"))
                {
                    _successMessage = WebDriver.FindElement(By.ClassName("messageBoardTextblk")).GetAttribute("innerText");
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
    }
}
