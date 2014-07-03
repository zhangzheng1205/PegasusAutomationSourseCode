using System;
using Framework.Common;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using System.Threading;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.OrganizationManagement
{
    public class CreateOrganisationPage : BasePage
    {
        //Purpose : To create District level of Organization at root
        public void CreateDistrictAtRootLevel()
        {
            try
            {
            Thread.Sleep(3000);
            GenericHelper.SelectWindow("Create Organization");
            string distName = GenericHelper.GenerateUniqueVariable("BDDDist");
            GenericHelper.WaitUntilElement(By.Id("txtInternalOrganisation"));
            WebDriver.FindElement(By.Id("txtInternalOrganisation")).SendKeys(distName);
            WebDriver.FindElement(By.Id("txtOrganisation")).Click();
            WebDriver.FindElement(By.Id("address")).SendKeys("BDD");
            WebDriver.FindElement(By.Id("City")).SendKeys("BDD");
            WebDriver.FindElement(By.Id("zip")).SendKeys("12345");
            WebDriver.FindElement(By.XPath("//table[@id='tblOrganisationLevel']/tbody/tr/td/input")).Click();
            WebDriver.FindElement(By.XPath("//table[@id='tblOrganisationLevel']/tbody/tr[2]/td/input")).Click();
            WebDriver.FindElement(By.Id("tdRemove")).Click();
            WebDriver.FindElement(By.Id("imgbtnSave")).Click();
            bool isWindowClosed = GenericHelper.IsPopUpClosed(2);
            if (isWindowClosed)
            {
                GenericHelper.Logs("'Create Organization'  window closed successfully and district name updated in DB", "PASSED");
                DatabaseTools.UpdateOrganizationTrue(distName, Enumerations.OrgLevelType.District);
            }
            else
            {
                GenericHelper.Logs("'Create Organization' window not closed successfully and district name not updated in DB", "FAILED");
                DatabaseTools.UpdateOrganizationFalse(distName, Enumerations.OrgLevelType.District);
            }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Create Organization"))
                {
                    GenericHelper.SelectWindow("Create Organization");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To create school level of Organization
        public void CreateSchool()
        {
            try
            {
            string orgName = GenericHelper.GenerateUniqueVariable("BDDSchool");
            Thread.Sleep(2000);
            GenericHelper.SelectWindow("Create Organization");
            GenericHelper.WaitUntilElement(By.Id("txtInternalOrganisation"));
            WebDriver.FindElement(By.Id("txtInternalOrganisation")).SendKeys(orgName);
            WebDriver.FindElement(By.Id("txtOrganisation")).Click();
            WebDriver.FindElement(By.Id("address")).SendKeys("BDD");
            WebDriver.FindElement(By.Id("City")).SendKeys("BDD");
            WebDriver.FindElement(By.Id("zip")).SendKeys("12345");
            WebDriver.FindElement(By.Id("imgbtnSave")).Click();
            bool isWindowClosed = GenericHelper.IsPopUpClosed(2);
            if (isWindowClosed)
            {
                GenericHelper.Logs("Organization has been created successfully,School name updated in DB", "PASSED");
                DatabaseTools.UpdateOrganizationTrue(orgName, Enumerations.OrgLevelType.School);
            }
            else
            {
                GenericHelper.Logs("'Create Organization' window not closed no clicking Save button,hence School name not updated in DB", "FAILED");
                DatabaseTools.UpdateOrganizationFalse(orgName, Enumerations.OrgLevelType.School);
            }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Create Organization"))
                {
                    GenericHelper.SelectWindow("Create Organization");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }
    }
}
