using System;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.GradeBook
{
    public partial class GBRoasterDefaultPage : BasePage
    {
        //Purpose: To select Student option in Roster Page
        public void SelectRoasterStudentOption()
        {
            try
            {
            GenericHelper.SelectWindow("Roster");
            WebDriver.SwitchTo().Frame("frameRoster");
            GenericHelper.WaitUntilElement(By.Id("_ctl0:InnerPageContent:btn_CreateUser"));
            WebDriver.FindElement(By.Id("_ctl0:InnerPageContent:btn_CreateUser")).Click();
            IWebElement optionStudent = WebDriver.FindElement(By.Id("trStudent"));
            ((IJavaScriptExecutor)WebDriver).ExecuteScript("$(arguments[0]).click()", optionStudent);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
            
        }


        public void VerifyRosterTabClicked()
        {
           try
           {
            bool isRosterTabClicked = GenericHelper.IsElementPresent(By.Id("_ctl0__ctl0_phBody_PageContent_MANAGEROSTER_DESC"));
            if (!isRosterTabClicked)
            {
                GenericHelper.WaitUntilElement(By.PartialLinkText("Roster"));
                WebDriver.FindElement(By.PartialLinkText("Roster")).Click();
            }
           }
           catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
