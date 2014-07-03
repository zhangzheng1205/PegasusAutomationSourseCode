using System;
using System.Threading;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Admin.User
{
    public class NewUserPage : BasePage
    {
        private static string userNameValue;
        //Purpose : To add new user as WSadmin
        public void AddNewUser(Table table, string username)
        {
            GenericHelper.SelectWindow("Create New User");
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
            WebDriver.FindElement(By.Id("imgBtnSave_Update")).Click();
            Thread.Sleep(5000);
            bool isCreateNewUserWindowClosed = GenericHelper.IsPopUpClosed(2);
            if (isCreateNewUserWindowClosed)
            {
                DatabaseTools.UpdateUserDb(Enumerations.UserType.WsTeacher, username, "bdd_pwd123", "user.bdd@excelindia.com", 3, true);
                GenericHelper.Logs("As 'Create New User' popup closed on clicking save button the username is updated in DB" + username, "PASSED");
            }
            else
            {
                GenericHelper.Logs("As 'Create New User' popup not closed on clicking save button the username is not updated in DB" + username, "FAILED");
            }

        }


        //Purpose : To add new user as WSadmin
        public void ToCreateWSuser(string userType)
        {
            try
            {
                GenericHelper.SelectWindow("Create New User");
                GenericHelper.WaitUntilElement(By.Id("txtLoginName"));
                WebDriver.FindElement(By.Id("txtLoginName")).Clear();
                if (userType.Equals("instructor"))
                {
                    userNameValue = GenericHelper.GenerateUniqueVariable("Ins");
                }
                if (userType.Equals("student"))
                {
                    userNameValue = GenericHelper.GenerateUniqueVariable("Stu");
                }
                WebDriver.FindElement(By.Id("txtLoginName")).SendKeys(userNameValue);
                GenericHelper.WaitUntilElement(By.Id("txtPassword"));
                WebDriver.FindElement(By.Id("txtPassword")).Clear();
                WebDriver.FindElement(By.Id("txtPassword")).SendKeys("password1");
                GenericHelper.WaitUntilElement(By.Id("txtFirstName"));
                WebDriver.FindElement(By.Id("txtFirstName")).Clear();
                WebDriver.FindElement(By.Id("txtFirstName")).SendKeys("auto");
                GenericHelper.WaitUntilElement(By.Id("txtLastName"));
                WebDriver.FindElement(By.Id("txtLastName")).Clear();
                WebDriver.FindElement(By.Id("txtLastName")).SendKeys("auto");
                GenericHelper.WaitUntilElement(By.Id("txtEmail"));
                WebDriver.FindElement(By.Id("txtEmail")).Clear();
                WebDriver.FindElement(By.Id("txtEmail")).SendKeys("auto@auto.com");
                GenericHelper.WaitUntilElement(By.Id("imgBtnSave_Update"));
                WebDriver.FindElement(By.Id("imgBtnSave_Update")).Click();
                GenericHelper.IsPopUpClosed(2);
                DatabaseTools.UpdateUserDb(Enumerations.UserType.HedWsInstructor, userNameValue, "password1", "auto@auto.com",12,true);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                WebDriver.Close();
                Assert.Fail(string.Format("Exception of type {0} caught: {1}", e.GetType(), e.Message));
            }
        }

    }
}
