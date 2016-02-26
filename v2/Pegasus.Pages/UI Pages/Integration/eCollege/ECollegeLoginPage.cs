﻿using System;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.eCollege;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the ECollege login actions.
    /// </summary>
    public class ECollegeLoginPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(LoginContentPage));

        /// <summary>
        /// Login as ECollegeAdmin User in Pearson TPI Cert.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        public void ECollegeUserLogin(User.UserTypeEnum userTypeEnum)
        {
            //Login as ECollege Admin User.
            Logger.LogMethodEntry("ECollegeLoginPage", "ECollegeUserLogin",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get User From Memory
                User user = User.Get(userTypeEnum);
                base.WaitForElementDisplayedInUi(By.CssSelector(".navOff>a"), 10);
                string check = base.GetElementTextByCssSelector(".navOff>a");

                IWebElement login = base.GetWebElementPropertiesByCssSelector(".navOff>a");

                ClickByJavaScriptExecutor(login);

                base.WaitForElementDisplayedInUi(By.Id("Username"));

                //Select Login Window
                this.SelectTPICertLoginWindow();
                //Enter Username
                this.EnterECollegeUserName(user.Name);
                //Enter Password
                this.EnterECollegeUserPassword(user.Password);
                //Log Username and password in logger file
                UserName = user.Name;
                Password = user.Password;
                UserType = userTypeEnum.ToString();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            Logger.LogMethodExit("ECollegeLoginPage", "ECLECollegeUserLoginogin",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Select Pearson TPI CERT Login window. 
        /// </summary>
        private void SelectTPICertLoginWindow()
        {
            Logger.LogMethodEntry("ECollegeLoginPage",
                "SelectTPICertLoginWindow", base.IsTakeScreenShotDuringEntryExit);
            //Wait For Window Window Load
            base.WaitUntilWindowLoads(ECollegeLoginPageResource.
                ECollegeLoginPage_LoginPage_Title);
            //Switch to Window
            base.SelectWindow(ECollegeLoginPageResource.
                ECollegeLoginPage_LoginPage_Title);
            Logger.LogMethodExit("ECollegeLoginPage",
                "SelectTPICertLoginWindow", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter ECollege UserName.
        /// </summary>
        /// <param name="userName">This is a user name.</param>
        private void EnterECollegeUserName(String userName)
        {
            //Enter ECollege User Name
            Logger.LogMethodEntry("ECollegeLoginPage",
                "EnterECollegeUserName", base.IsTakeScreenShotDuringEntryExit);
            //Wait for UserName Textbox 
            base.WaitForElement(By.Id(ECollegeLoginPageResource.
                ECollegeLoginPage_UserName_ID_Locator));
            base.ClearTextById(ECollegeLoginPageResource.
                ECollegeLoginPage_UserName_ID_Locator);
            // Enter UserName
            base.FillTextBoxById(ECollegeLoginPageResource.
                ECollegeLoginPage_UserName_ID_Locator, userName);
            Logger.LogMethodExit("ECollgeLoginPage",
                "EnterECollegeUserName", base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Enter Password for ECollege User.
        /// </summary>
        /// <param name="userPassword">This is User Password.</param>
        private void EnterECollegeUserPassword(String userPassword)
        {
            //Enter ECollege User Password
            Logger.LogMethodEntry("ECollegeLoginPage",
                "EnterECollegeUserPassword", base.IsTakeScreenShotDuringEntryExit);
            //Wait for Password Textbox
            base.WaitForElement(By.Id(ECollegeLoginPageResource
                .ECollegeLoginPage_Password_ID_Locator));
            base.ClearTextById(ECollegeLoginPageResource
                .ECollegeLoginPage_Password_ID_Locator);
            //Enter Password
            base.FillTextBoxById(ECollegeLoginPageResource.
                ECollegeLoginPage_Password_ID_Locator, userPassword);
            // Login By using Enter key in Password text.
            base.PressEnterKeyById(ECollegeLoginPageResource.
                ECollegeLoginPage_Password_ID_Locator);
            Logger.LogMethodExit("ECollegeLoginPage",
                "EnterECollegeUserPassword", base.IsTakeScreenShotDuringEntryExit);

        }
    }
}
