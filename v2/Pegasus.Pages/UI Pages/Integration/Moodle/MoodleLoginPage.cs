using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pegasus.Pages.UI_Pages.Integration.Moodle
{
    public class MoodleLoginPage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(MyPearsonLoginPage));

        /// <summary>
        /// Login to Moodle
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        public void LoginToCanvas(string username, string password)
        {
            //Login to Blackboard
            logger.LogMethodEntry("MoodleLoginPage", "LoginToMMND",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Click login link
                base.WaitForElement(By.PartialLinkText(MoodleLoginPageResource.
                    MoodleLoginPage_LoginButton_Text_Value));
                IWebElement getLoginLink = base.GetWebElementPropertiesByPartialLinkText(
                    MoodleLoginPageResource.
                    MoodleLoginPage_LoginButton_Text_Value);
                base.PerformMouseClickAction(getLoginLink);

                // Enter username
                base.WaitForElement(By.Id(MoodleLoginPageResource.
                    MoodleLoginPage_UsernameTextbox_Id_Value));
                base.ClearTextById(MoodleLoginPageResource.
                    MoodleLoginPage_UsernameTextbox_Id_Value);
                base.FillTextBoxById(MoodleLoginPageResource.
                    MoodleLoginPage_UsernameTextbox_Id_Value, username);

                // Enter Password
                base.WaitForElement(By.Id(MoodleLoginPageResource.
                    MoodleLoginPage_PasswordTextbox_Id_Value));
                base.ClearTextById(MoodleLoginPageResource.
                    MoodleLoginPage_PasswordTextbox_Id_Value);
                base.FillTextBoxById(MoodleLoginPageResource.
                    MoodleLoginPage_PasswordTextbox_Id_Value, password);

                // Click on login button
                base.WaitForElement(By.Id(MoodleLoginPageResource.
                    MoodleLoginPage_LoginButton_Id_Value));
                base.ClickButtonById(MoodleLoginPageResource.
                    MoodleLoginPage_LoginButton_Id_Value);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MoodleLoginPage", "LoginToMMND",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checks If User Logged In To Blackboard SuccessFully
        /// </summary>
        /// <returns>Return True if user logged in otherwise false.</returns>
        public Boolean IsUserLoggedInSuccessFullyMoodle()
        {
            //Checks If User Logged In To MMND SuccessFully
            logger.LogMethodEntry("MoodleLoginPage", "IsUserLoggedInSuccessFullyMoodle",
                base.IsTakeScreenShotDuringEntryExit);
            //Initializing Variable
            Boolean isUserLoggedIn = false;
            try
            {
                Thread.Sleep(Convert.ToInt32(MoodleLoginPageResource.MoodleLoginPage_Custom_TimeToWait_Element));
                //Wait for the Header to Load
                base.WaitForElement(By.ClassName(MoodleLoginPageResource.
                    MoodleLoginPage_GetHeaderText_Class_Name));
                isUserLoggedIn = base.IsElementPresent(By.ClassName(MoodleLoginPageResource.
                    MoodleLoginPage_GetHeaderText_Class_Name));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MoodleLoginPage", "IsUserLoggedInSuccessFullyMoodle",
                base.IsTakeScreenShotDuringEntryExit);
            return isUserLoggedIn;
        }
    }
}