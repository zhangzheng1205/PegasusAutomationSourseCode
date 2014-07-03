using System;
using System.Collections.Generic;
using Framework.Common;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Admin.Enrollment
{
    public class UserEnrollmentPage : BasePage
    {
        //Purpose : to select user in Enrollment tab of Manage Organization Page
        public void SelectUserToEnroll(string userRole)
        {
            try
            {
            GenericHelper.SelectWindow("Manage Organization");
            WebDriver.SwitchTo().Frame("frm");
            WebDriver.SwitchTo().Frame("ifrmleft");

            switch (userRole)
            {
                case "Teacher":
                    GenericHelper.WaitUntilElement(By.Id("txtLN"));
                    WebDriver.FindElement(By.Id("txtLN")).Clear();
                    WebDriver.FindElement(By.Id("txtLN")).SendKeys(DatabaseTools.GetUsername(Enumerations.UserType.CsTeacher));
                    break;
                case "Student":
                    GenericHelper.WaitUntilElement(By.Id("txtLN"));
                    WebDriver.FindElement(By.Id("txtLN")).Clear();
                    WebDriver.FindElement(By.Id("txtLN")).SendKeys(DatabaseTools.GetUsername(Enumerations.UserType.CsStudent));
                    break;
            }
            try
            {
                GenericHelper.WaitUntilElement(By.Id("btnGO"));
                WebDriver.FindElement(By.Id("btnGO")).Click();
                try
                {
                    bool isUserTablePresent = GenericHelper.IsElementPresent(By.Id("grdSCLCourse$divContent"));
                    if (isUserTablePresent)
                    {
                        string noRecordMessagePresent = WebDriver.FindElement(By.Id("grdSCLCourse")).Text;
                        if (noRecordMessagePresent.Contains("There are no users."))
                        {
                            GenericHelper.Logs("There are no users..", "FAILED");
                            throw new NoSuchElementException("There are no users.");
                        }
                    }
                }
                catch (Exception e)
                {
                    GenericHelper.Logs(e.ToString(), "FAILED");
                    throw new Exception(e.ToString());
                }
                GenericHelper.WaitUntilElement(By.Id("grdSCLCourse$_ctrl0"));
                WebDriver.FindElement(By.Id("grdSCLCourse$_ctrl0")).Click();
                GenericHelper.Logs("User has been selected successfully in order to enroll in the class.", "PASSED");
            }
            catch (Exception e)
            {
                GenericHelper.Logs("User has not been selected successfully in order to enroll in the class.", "FAILED");
                throw new Exception(e.ToString());
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

        //Purpose : to click 'Enroll in Selected' button in Enrollment tab of Manage Organization Page
        public void ClickEnrollButton()
        {
            try
            {
            GenericHelper.SelectWindow("Manage Organization");
            WebDriver.SwitchTo().Frame("frm");
            WebDriver.SwitchTo().Frame("ifrmMiddle");
            if (WebDriver.FindElement(By.Id("btnEnroll")).Enabled)
            {
                try
                {
                    GenericHelper.WaitUntilElement(By.Id("btnEnroll"));
                    WebDriver.FindElement(By.Id("btnEnroll")).Click();
                    GenericHelper.Logs("Enroll button get enabled on selecting the user in enrollment tab under user frame", "PASSED");
                }
                catch (Exception e)
                {
                    GenericHelper.Logs("Enroll button not get enabled on selecting the user in enrollment tab under user frame.", "FAILED");
                    throw new Exception(e.ToString());
                }
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
