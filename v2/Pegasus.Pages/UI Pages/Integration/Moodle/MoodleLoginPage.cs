using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pegasus.Pages.UI_Pages.Integration.Moodle
{
    public class MoodleLoginPage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(MyPearsonLoginPage));

        /// <summary>
        /// Login to Blackboard
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        public void LoginToCanvas(string username, string password)
        {
            //Login to Blackboard
            logger.LogMethodEntry("BlackboardLoginPage", "LoginToMMND",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Click login link
                base.WaitForElement(By.PartialLinkText("Login"));
                IWebElement getLoginLink = base.GetWebElementPropertiesByPartialLinkText("Login");
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
            logger.LogMethodExit("BlackboardLoginPage", "LoginToMMND",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}