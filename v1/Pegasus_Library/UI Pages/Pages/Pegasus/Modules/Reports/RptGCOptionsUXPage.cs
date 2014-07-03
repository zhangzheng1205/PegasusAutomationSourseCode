using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Reports
{
    public class RptGCOptionsUXPage: BasePage
    {

        public void ClickSelectStudyPlans()
        {
            try 
            {
            WebDriver.SwitchTo().Frame("Mainframe");
            GenericHelper.WaitUntilElement(By.Id("_ctl0:InnerPageContent:imgAssessment"));
            WebDriver.FindElement(By.Id("_ctl0:InnerPageContent:imgAssessment")).Click();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        public void ClickSelectStudents()
        {
            try 
            {
            WebDriver.SwitchTo().Frame("Mainframe");
            GenericHelper.WaitUntilElement(By.Id("_ctl0:InnerPageContent:Button3"));
            WebDriver.FindElement(By.Id("_ctl0:InnerPageContent:Button3")).Click();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
