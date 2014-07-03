using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using System.Linq;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSIntegration.ProgramManagement
{
    public class ProgramManagementPage : BasePage
    {
        //Purpose: To click on 'Create New Program' link
        public void ClickCreateNewProgramLink()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("ifrmWorkspace"));
                WebDriver.SwitchTo().Frame("ifrmWorkspace");
                GenericHelper.WaitUntilElement(By.Id("grdPegasusProgramGrid_lnkAddProgram"));
                IWebElement manageProgram = WebDriver.FindElement(By.Id("grdPegasusProgramGrid_lnkAddProgram"));
                new Actions(WebDriver).MoveToElement(manageProgram).Click(manageProgram).Perform();
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To verify the control is on 'Manage Programs' page
        public void NavigatingToManageProgramsPage()
        {
            try
            {
                bool organizationAdminPage = GenericHelper.IsWindowPresent("Manage Programs");
                if (organizationAdminPage)
                {
                    GenericHelper.SelectWindow("Manage Programs");
                }
                else
                {
                    GenericHelper.SelectDefaultWindow();
                    string currentUrl = WebDriver.Url;
                    GenericHelper.WaitUntilElement(By.PartialLinkText("Publishing"));
                    WebDriver.FindElement(By.PartialLinkText("Publishing")).Click();
                    WebDriver.SwitchTo().ActiveElement().Click();
                    GenericHelper.WaitUntilElement(By.PartialLinkText("Manage Programs"));
                    WebDriver.FindElement(By.PartialLinkText("Manage Programs")).Click();
                    if (currentUrl == WebDriver.Url)
                    {
                        WebDriver.FindElement(By.PartialLinkText("Manage Programs")).Click();
                    }
                    GenericHelper.SelectWindow("Manage Programs");
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
