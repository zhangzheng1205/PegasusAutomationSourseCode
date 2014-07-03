using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Common;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Admin.User
{
    public class ManageUserPage : BasePage
    {

        //Purpose: To creat CS users
        public void Createusers(Table table)
        {
            try
            {
            GenericHelper.WaitUntilElement(By.Id("frm"));
            WebDriver.SwitchTo().Frame("frm");
            WebDriver.FindElement(By.Id("lblCreateUser")).Click();
            // Purpose: Username and Password will be written to DB
            string username = string.Empty;
            switch (((string[])(table.Rows[0].Values))[1])
            {
                case "Teacher":
                    WebDriver.FindElement(By.Id("lblins")).Click();
                    username = GenericHelper.GenerateUniqueVariable("CsTeach");
                    DatabaseTools.UpdateUserDb(Enumerations.UserType.CsTeacher, username, "bdd_pwd123", "user.bdd@excelindia.com", 5, true);
                    break;
                case "Student":
                    WebDriver.FindElement(By.Id("lblStudent")).Click();
                    username = GenericHelper.GenerateUniqueVariable("CsStud");
                    DatabaseTools.UpdateUserDb(Enumerations.UserType.CsStudent, username, "bdd_pwd123", "user.bdd@excelindia.com", 6, true);
                    break;
                case "OrgAdmin":
                    WebDriver.FindElement(By.Id("lblAdmin")).Click();
                    username = GenericHelper.GenerateUniqueVariable("OrgAdmin");
                    DatabaseTools.UpdateUserDb(Enumerations.UserType.CsOrganizationAdmin, username, "bdd_pwd123", "user.bdd@excelindia.com", 7, true);
                    break;
            }
            GenericHelper.SelectWindow("Add User");
            ((string[])(table.Rows[0].Values))[1] = username;
            ((string[])(table.Rows[1].Values))[1] = "bdd_pwd123";
            ((string[])(table.Rows[2].Values))[1] = username;
            ((string[])(table.Rows[3].Values))[1] = username;
            ((string[])(table.Rows[4].Values))[1] = "user.bdd@excelindia.com";
            foreach (var tableRow in table.Rows)
            {
                GenericHelper.WaitUntilElement(By.Id(tableRow["Field"]));
                WebDriver.FindElement(By.Id(tableRow["Field"])).SendKeys(tableRow["Value"]);
            }
            WebDriver.FindElement(By.Id("imgBtnSave")).Click();
            GenericHelper.IsPopUpClosed(3);
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Add User"))
                {
                    GenericHelper.SelectWindow("Add User");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        // Purpose: to select 'Import Users from File' option
        public void SelectImportUsers()
        {
            try
            {
            WebDriver.SwitchTo().Frame("frm");
            WebDriver.FindElement(By.Id("lblCreateUser")).Click();
            WebDriver.FindElement(By.Id("lblBulkUser")).Click();
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

        public void verifyBulkRegistration()
        {
            try
            {
            GenericHelper.SelectWindow("Manage Organization");
            WebDriver.SwitchTo().Frame("frm");
            if (GenericHelper.IsElementPresent(By.Id("lblQueueInfo")) && GenericHelper.IsElementPresent(By.Id("lnkViewQueueData")))
            {
                GenericHelper.Logs("After uploading bulk students 'Bulk Registration- 1 of 1 Files in progress   View Registration Queue' Text Displayed", "PASSED");
            }
            else
            {
                GenericHelper.Logs("After uploading bulk students 'Bulk Registration- 1 of 1 Files in progress   View Registration Queue' Text not Displayed", "FAILED");
            }
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

    }
}
