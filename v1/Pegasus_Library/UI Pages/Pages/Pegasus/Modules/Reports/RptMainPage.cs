using System;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Reports
{
    public class RptMainPage : BasePage
    {
        //Purpose : to click Student Activity Link
        public void SelectStudentActivity()
        {
            try
            {
                GenericHelper.SelectWindow("Reports");
                GenericHelper.WaitUntilElement(By.Id("Mainframe"));
                WebDriver.SwitchTo().Frame("Mainframe");
                GenericHelper.WaitUntilElement(By.XPath("//table[@id='tblrptgrid']/tbody/tr[8]/td/span"));
                WebDriver.FindElement(By.XPath("//table[@id='tblrptgrid']/tbody/tr[8]/td/span")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : to click Study Plan Results Link
        public void SelectStudyPlanResults()
        {
            try
            {
                GenericHelper.SelectWindow("Reports");
                GenericHelper.WaitUntilElement(By.Id("Mainframe"));
                WebDriver.SwitchTo().Frame("Mainframe");
                GenericHelper.WaitUntilElement(By.XPath("//table[@id='tblrptgrid']/tbody/tr[5]/td/span"));
                WebDriver.FindElement(By.XPath("//table[@id='tblrptgrid']/tbody/tr[5]/td/span")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
