using System;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using System.Linq;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSIntegration.ProgramManagement
{
    public class ManageProductsPage : BasePage
    {
        //Purpose: To click the 'Create New Product' link
        public void ClickCreateNewProductLink()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("ifrmWorkspace"));
                WebDriver.SwitchTo().Frame("ifrmWorkspace");
                GenericHelper.WaitUntilElement(By.Id("ifrmRight"));
                WebDriver.SwitchTo().Frame("ifrmRight");
                WebDriver.FindElement(By.PartialLinkText("Create New Product")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To verify the control is on 'Manage Products' page
        public void NavigateToManageProductsPage()
        {
            try
            {
                bool manageProductsPage = GenericHelper.IsWindowPresent("Manage Products");
                if (manageProductsPage)
                {
                    GenericHelper.SelectWindow("Manage Products");
                }
                else
                {
                    WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                    string currentUrl = WebDriver.Url;
                    GenericHelper.WaitUntilElement(By.PartialLinkText("Publishing"));
                    WebDriver.FindElement(By.PartialLinkText("Publishing")).Click();
                    WebDriver.SwitchTo().ActiveElement().Click();
                    GenericHelper.WaitUntilElement(By.PartialLinkText("Manage Products"));
                    WebDriver.FindElement(By.PartialLinkText("Manage Products")).Click();
                    if (currentUrl == WebDriver.Url)
                    {
                        WebDriver.FindElement(By.PartialLinkText("Manage Products")).Click();
                    }
                    GenericHelper.SelectWindow("Manage Products");
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
