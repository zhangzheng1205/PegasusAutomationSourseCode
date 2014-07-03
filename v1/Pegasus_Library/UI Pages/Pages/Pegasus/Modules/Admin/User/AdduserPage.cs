using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using System.Threading;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Admin.User
{
    public class AdduserPage:BasePage
    {
        //Purpose : To add cs user
        public void AddUser(Table table,string username)
        {
            try
            {
            GenericHelper.WaitUntillWindowAndElement("Add User", By.Id("txtLoginName"));
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

    }
}
