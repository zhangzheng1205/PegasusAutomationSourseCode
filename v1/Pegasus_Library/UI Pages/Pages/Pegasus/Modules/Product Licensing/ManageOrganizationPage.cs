using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference
{
    public class ManageOrganizationPage : BasePage
    {
        // Calling of other classes
        readonly OrganizationManagementPage _organizationManagement = new OrganizationManagementPage();

        //Purpose: Method to Select Licenses Tab
        public void SelectLicensesTab()
        {
            try
            {
              GenericHelper.SelectWindow("Manage Organization");
              GenericHelper.WaitUntilElement(By.Id("_ctl1_anc_4"));
              WebDriver.FindElement(By.Id("_ctl1_anc_4")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Manage Organization"))
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Method to Select Libraries Tab
        public void SelectLibrariesTab()
        {
            try
            {
                GenericHelper.SelectWindow("Manage Organization");
                GenericHelper.WaitUntilElement(By.Id("_ctl1_anc_6"));
                WebDriver.FindElement(By.Id("_ctl1_anc_6")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Manage Organization"))
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Method to Select Classes Tab
        public void SelectClassesTab()
        {
            try
            {
            GenericHelper.SelectWindow("Manage Organization");
            GenericHelper.WaitUntilElement(By.Id("_ctl1_anc_3"));
            WebDriver.FindElement(By.Id("_ctl1_anc_3")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Manage Organization"))
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Method To Select Home Button and Navigate Back To Manage Organization Window
        public void ToSelectBackButton()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:_ctl0:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:_ctl0:Backbutton")).Click();
                bool isWindowPresent = GenericHelper.IsPopUpWindowPresent("Manage Organization");
                if (isWindowPresent)
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    GenericHelper.WaitUntilElement(By.Id("_ctl1_anc_3"));
                    WebDriver.SwitchTo().DefaultContent();
                    GenericHelper.Logs("Back button has been successfully clicked and navigated to the 'Manage Organization window'.", "Passed");
                }
                else
                {
                    GenericHelper.Logs("Back button has not been successfully clicked and not navigated to the 'Manage Organization window'.", "Passed");
                    Assert.Fail("Back button has not been successfully clicked and not navigated to the 'Manage Organization window'.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isOverviewWindowPresent = GenericHelper.IsPopUpWindowPresent("Overview");
                if (isOverviewWindowPresent)
                {
                    GenericHelper.SelectWindow("Overview");
                    WebDriver.Close();
                }
                bool isContentWindowPresent = GenericHelper.IsPopUpWindowPresent("Content");
                if (isContentWindowPresent)
                {
                    GenericHelper.SelectWindow("Content");
                    WebDriver.Close();
                }
                bool isManageOrganizationWindowPresent = GenericHelper.IsPopUpWindowPresent("Manage Organization");
                if (isManageOrganizationWindowPresent)
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }
    }
}
