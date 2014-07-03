using System;
using System.Configuration;
using Framework.Common;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using System.Linq;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference
{
    public class OrganizationManagementPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        // Purpose: Method To Search the District Level Organization
        public void ManageDistrictLevel()
        {
            try
            {
            GenericHelper.SelectWindow("Organization Management");
            GenericHelper.WaitUntilElement(By.Id("ifrmWorkspace"));
            WebDriver.FindElement(By.Id("ifrmWorkspace"));
            WebDriver.SwitchTo().Frame("ifrmWorkspace");
            GenericHelper.WaitUntilElement(By.Id("btnManage"));
            WebDriver.FindElement(By.Id("btnManage")).Click();
            WebDriver.SwitchTo().DefaultContent();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose: Method To Search the School Level Organization
        public void SearchAndSelectOrg(string orgName)
        {
            try
            {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            GenericHelper.WaitUntilElement(By.Id("ifrmWorkspace"));
            WebDriver.SwitchTo().Frame("ifrmWorkspace");
            WebDriver.FindElement(By.Id("txtName")).Clear();
            WebDriver.FindElement(By.Id("txtName")).SendKeys(orgName);
            WebDriver.FindElement(By.Id("UCOrganisationManagement_imgbtnSearch")).Click();
            #region VerifyingOrganizationFound
            //Purpose: Verifying Organization Found While Search
            bool isNoRecordsMsgPresent = GenericHelper.IsElementPresent(By.Id("UCOrganisationManagement_lblNoRecordsMsg"));
            if (isNoRecordsMsgPresent)
            {
                string isOrganizationFound = WebDriver.FindElement(By.Id("UCOrganisationManagement_lblNoRecordsMsg")).Text;
                if (isOrganizationFound.Contains("No records found"))
                {
                    GenericHelper.Logs(string.Format("Organization '{0}' not found while searching.",orgName), "FAILED");
                    throw new NoSuchElementException(string.Format("Organization '{0}' not found while searching.",orgName));
                }
                else
                {
                    GenericHelper.Logs(string.Format("Organization '{0}'  found while searching.", orgName), "PASSED");
                }
            }
            #endregion VerifyingOrganizationFound
            GenericHelper.WaitUntilElement(By.XPath("//img[contains(@src,'/btn_select.gif')]"));
            WebDriver.FindElement(By.XPath("//img[contains(@src,'/btn_select.gif')]")).Click();
            WebDriver.SwitchTo().DefaultContent();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");               
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To verify the control is on 'Organization Management' page
        public void NavigatingToOrganizationManagementPage()
        {
            try
            {
            bool organizationAdminPage = GenericHelper.IsWindowPresent("Organization Management");
            if (organizationAdminPage)
            {
                GenericHelper.SelectWindow("Organization Management");
            }
            else
            {
                WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
                GenericHelper.WaitUntilElement(By.PartialLinkText("Organization Admin"));
                WebDriver.FindElement(By.PartialLinkText("Organization Admin")).Click();
                WebDriver.SwitchTo().ActiveElement().Click();
                GenericHelper.SelectWindow("Organization Management");
            }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To Click on the 'Create New Organisation' button"
        public void ClickCreateNewOrganisationButton()
        {
            try
            {
            WebDriver.SwitchTo().Frame("ifrmWorkspace");
            if (Browser.Equals("IE"))
            {
                GenericHelper.WaitUntilElement(By.Id("spnCreateOrganisation"));
                WebDriver.FindElement(By.Id("spnCreateOrganisation")).Click();
            }
            if (Browser.Equals("FF") || Browser.Equals("GC"))
            {
                GenericHelper.WaitUntilElement(By.Id("CreateOrg"));
                WebDriver.FindElement(By.Id("CreateOrg")).Click();
            }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To Click on the 'Add School' Image
        public void ClickAddSchool()
        {
            try
            {
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
            GenericHelper.WaitUntilElement(By.Id("ifrmWorkspace"));
            WebDriver.SwitchTo().Frame("ifrmWorkspace");
            GenericHelper.WaitUntilElement(By.XPath("//table[@class='tdAddLocation']/tbody/tr/td/img"));
            WebDriver.FindElement(By.XPath("//table[@class='tdAddLocation']/tbody/tr/td/img")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        public void GoToManageOrganizationPage()
        {
            try 
            {
            if (!GenericHelper.IsPopUpWindowPresent("Manage Organization"))
            {
                GenericHelper.SelectDefaultWindow();
                GenericHelper.WaitUntilElement(By.Id("_ctl8__ctl11_Link"));
                IWebElement orgAdminLink = WebDriver.FindElement(By.Id("_ctl8__ctl11_Link"));
                orgAdminLink.Click();
                string schoolName = DatabaseTools.GetOrganization(Enumerations.OrgLevelType.School);
                SearchAndSelectOrg(schoolName);
            }
            GenericHelper.SelectWindow("Manage Organization");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isWindowPresentManageOrganization = GenericHelper.IsPopUpWindowPresent("Manage Organization");
                if (isWindowPresentManageOrganization)
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }
    }
}
