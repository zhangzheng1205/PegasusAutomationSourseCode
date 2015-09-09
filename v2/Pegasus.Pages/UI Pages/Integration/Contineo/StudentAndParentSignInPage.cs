using System;
using System.Threading;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Integration.Contineo;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    public class StudentAndParentSignInPage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(StudentAndParentSignInPage));

        public void SignInAsPowerSchoolUser(User.UserTypeEnum userTypeEnum)
        {
            //Login into Power School
            Logger.LogMethodEntry("StudentAndParentSignInPage", "SignInAsPowerSchoolUser",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Check whether the user is already loggedin or not
                Boolean isUserAlreadyLoggedIn = base.IsElementPresent(By.
                    PartialLinkText(StudentAndParentSignInPageResource.
                    StudentAndParentSignInPage_Signout_Link_Id_Locator), 10);
                if (!isUserAlreadyLoggedIn)
                {   //Get the user of the given type from memory
                    User user = User.Get(userTypeEnum);
                    //Authenticate the user
                    this.Authentication(user.Name, user.Password, userTypeEnum);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("StudentAndParentSignInPage", "SignInAsPowerSchoolUser",
                base.IsTakeScreenShotDuringEntryExit);
        }

        private void Authentication(String username, String password,
            User.UserTypeEnum userTypeEnum)
        {
            //User authentication
            Logger.LogMethodEntry("StudentAndParentSignInPage", "Authentication",
                base.IsTakeScreenShotDuringEntryExit);
            bool isLoginSuccessful = false;
            while (!isLoginSuccessful)
            {
                this.EnterUserNamePassword(username, password);
                //SignIn To Power School
                base.SubmitButtonById(StudentAndParentSignInPageResource.
                    StudentAndParentSignInPage_SignIn_Button_Id_Locator);
                Thread.Sleep(Convert.ToInt32(StudentAndParentSignInPageResource.
                    StudentAndParentSignInPage_Custom_TimeToWait_Value));
                //Stores the Power School Login validation result
                isLoginSuccessful = new PowerSchoolHomePage().ValidatePowerSchoolUserLogin(userTypeEnum);
                //User not successfully logged in
                if (!isLoginSuccessful)
                {
                    //Throws an message "Unable to login"
                    throw new LoginFailedException(string.Format
                        ("Invalid Username = {0} or Password! = {1} Attempt has been recorded.",
                        username, password));
                }
            }
            Logger.LogMethodExit("StudentAndParentSignInPage", "Authentication",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter User Name and Password
        /// </summary>
        /// <param name="username">This is Username</param>
        /// <param name="password">This is Password</param>
        private void EnterUserNamePassword(String username, String password)
        {
            //Enter User Name and Password
            Logger.LogMethodEntry("StudentAndParentSignInPage", "EnterUserNamePassword",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Username Text Box
            base.WaitForElement(By.Id(StudentAndParentSignInPageResource.
                StudentAndParentSignInPage_UserName_Id_Locator), Convert.ToInt32(
                    StudentAndParentSignInPageResource.StudentAndParentSignInPage_Custom_TimeToWait_Value));
            //Clear The UserName Text Box
            base.ClearTextById(StudentAndParentSignInPageResource.
                StudentAndParentSignInPage_UserName_Id_Locator);
            //Enter username
            base.FillTextBoxById(StudentAndParentSignInPageResource.
                StudentAndParentSignInPage_UserName_Id_Locator, username);
            //Wait For Password Text Box
            base.WaitForElement(By.XPath(StudentAndParentSignInPageResource.
                StudentAndParentSignInPage_Password_Xpath_Locator), Convert.ToInt32(
                StudentAndParentSignInPageResource.StudentAndParentSignInPage_Custom_TimeToWait_Value));
            //Clear The Password Text Box
            base.ClearTextByXPath(StudentAndParentSignInPageResource.
                StudentAndParentSignInPage_Password_Xpath_Locator);
            //Enter password
            base.FillTextBoxByXPath(StudentAndParentSignInPageResource.
                StudentAndParentSignInPage_Password_Xpath_Locator, password);
            Logger.LogMethodExit("StudentAndParentSignInPage", "EnterUserNamePassword",
               base.IsTakeScreenShotDuringEntryExit);
        }
    }
}