using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.DRT
{
    public class DRTStudentUXPage: BasePage 
    {
        public void SelectFrame()
        {
            GenericHelper.SelectWindow("Open Study Plan");
           
            IWebElement frame = WebDriver.FindElement(By.XPath("//iframe[contains(@src,'DRTStudentUX.aspx?')]"));
            WebDriver.SwitchTo().Frame(frame);
        }

        public void OpenFirstStudyMaterial()
        {
            WebDriver.FindElement(By.XPath("//table[@id='tblStudent']/tbody/tr[3]/td/a")).SendKeys("");
            WebDriver.FindElement(By.XPath("//table[@id='tblStudent']/tbody/tr[3]/td/a")).Click();
           // WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_lblOpen")).Click();
        }

        public void OpenSecondStudyMaterial()
        {
            WebDriver.FindElement(By.XPath("//table[@id='tblStudent']/tbody/tr[4]/td/a")).SendKeys("");
            WebDriver.FindElement(By.XPath("//table[@id='tblStudent']/tbody/tr[4]/td/a")).Click();
           // WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_lblOpen")).Click();
        }

        public void OpenThirdStudyMaterial()
        {
            WebDriver.FindElement(By.XPath("//table[@id='tblStudent']/tbody/tr[5]/td/a")).SendKeys("");
            WebDriver.FindElement(By.XPath("//table[@id='tblStudent']/tbody/tr[5]/td/a")).Click();
           // WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_lblOpen")).Click();
        }

        public void SelectAllAvailableStudyMaterial()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("DDHideOrShow"));
                WebDriver.FindElement(By.Id("DDHideOrShow")).SendKeys("");
                new SelectElement(WebDriver.FindElement(By.Id("DDHideOrShow"))).SelectByText("All available Study Material");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
