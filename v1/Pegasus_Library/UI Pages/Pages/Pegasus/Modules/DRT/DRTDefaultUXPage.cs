using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.DRT
{
    public class DRTDefaultUXPage : BasePage
    {
        //Pupose: Constant Declaration
        private readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private string _successMessage = null;


        // Purpose: To Enter SSP name
        public void EnterSSPName(string sppName)
        {
            try
            {     
            WebDriver.FindElement(By.Id("_ctl0__ctl0_phBody_PageContent_txtModuleName")).SendKeys(sppName);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Click on CreateTest for creating the PreTest
        public void ClickCreateTestForPretest()
        {
            try 
            {
            GenericHelper.WaitUntilElement(By.ClassName("DRT_addSmal1"));
            WebDriver.FindElement(By.ClassName("DRT_addSmal1")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Saving SSP
        public void SaveSSP()
        {
            try 
            {
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_lbtnSave"));
            WebDriver.FindElement(By.Id("_ctl0__ctl0_phBody_PageContent_lbtnSave"));
            WebDriver.SwitchTo().ActiveElement().Click();
            WebDriver.FindElement(By.Id("_ctl0__ctl0_phBody_PageContent_lbtnSave")).Click();
            
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Verify Succesfull Message
        public bool VerifySuccesfullMessage(string successMsg)
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

        public void ClickBegin()
        {
            GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phBody:PageContent:FrmDRTTestsPanel1:btnimg"));
            WebDriver.FindElement(By.Id("_ctl0:_ctl0:phBody:PageContent:FrmDRTTestsPanel1:btnimg")).Click();
        }

        public void ClickBeginForPostTest()
        {
            GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phBody:PageContent:FrmDRTTestsPanel1:postimg"));
            WebDriver.FindElement(By.Id("_ctl0:_ctl0:phBody:PageContent:FrmDRTTestsPanel1:postimg")).SendKeys("");
            WebDriver.FindElement(By.Id("_ctl0:_ctl0:phBody:PageContent:FrmDRTTestsPanel1:postimg")).Click();
        }


        public void BackToPreviousFolder()
        {
            GenericHelper.WaitUntilElement(By.XPath("//a[@title='Back to previous content folder']"));
            WebDriver.FindElement(By.XPath("//a[@title='Back to previous content folder']")).SendKeys("");
            WebDriver.FindElement(By.XPath("//a[@title='Back to previous content folder']")).Click();
        }

        public void ClickReturnToCourse()
        {
            WebDriver.FindElement(By.Id("_ctl0:_ctl0:phBody:PageContent:lbtnBack")).SendKeys("");
            WebDriver.FindElement(By.Id("_ctl0:_ctl0:phBody:PageContent:lbtnBack")).Click();
        }
    }
}
