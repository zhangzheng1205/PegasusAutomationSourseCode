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
    public class PowerTeacherSignInPage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PowerTeacherSignInPage));

        public void SignInAsPowerSchoolUser(User.UserTypeEnum userTypeEnum)
        {
            //Login into Power School
            Logger.LogMethodEntry("PowerTeacherSignInPage", "SignInAsPowerSchoolUser",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Check whether the user is already loggedin or not
                Boolean isUserAlreadyLoggedIn = base.IsElementPresent(By.
                    PartialLinkText(PowerTeacherSignInPageResource.
                    PowerTeacherSignInPage_Signout_Link_Id_Locator), 10);
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
            Logger.LogMethodExit("PowerTeacherSignInPage", "SignInAsPowerSchoolUser",
                base.IsTakeScreenShotDuringEntryExit);
        }

        private void Authentication(String username, String password,
            User.UserTypeEnum userTypeEnum)
        {
            //User authentication
            Logger.LogMethodEntry("PowerTeacherSignInPage", "Authentication",
                base.IsTakeScreenShotDuringEntryExit);
            bool isLoginSuccessful = false;
            while (!isLoginSuccessful)
            {
                //string WindowName = Convert.ToString(PowerTeacherSignInPageResource.PowerTeacherSignInPage_Window_Name);
                //string ExpectedWindowName = base.GetPageTitle;
                //if (WindowName != ExpectedWindowName)
                //{
                //    this.HandleSSLError();
                //}
                this.EnterUserNamePassword(username, password);
                //SignIn To Power School
                base.SubmitButtonById(PowerTeacherSignInPageResource.
                PorwerTeacherSignInPage_SignIn_Button_Id_Locator);
                Thread.Sleep(Convert.ToInt32(PowerTeacherSignInPageResource.
                PowerTeacherSignInPage_Custom_TimeToWait_Value));
                //Stores the Power School Login validation result
                isLoginSuccessful = new PowerTeacherHomePage().ValidatePowerSchoolUserLogin(userTypeEnum);                
                //User not successfully logged in
                if (!isLoginSuccessful)
                {
                    //Throws an message "Unable to login"
                    throw new LoginFailedException(string.Format
                        ("Invalid Username = {0} or Password! = {1} Attempt has been recorded.",                          
                        username, password));
                }
            }
            Logger.LogMethodExit("PowerTeacherSignInPage", "Authentication",
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
            Logger.LogMethodEntry("PowerTeacherSignInPage", "EnterUserNamePassword",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Username Text Box
            base.WaitForElement(By.Id(PowerTeacherSignInPageResource.
                PowerTeacherSignInPage_UserName_Id_Locator), Convert.ToInt32(
                    PowerTeacherSignInPageResource.PowerTeacherSignInPage_Custom_TimeToWait_Value));
            //Clear The UserName Text Box
            base.ClearTextById(PowerTeacherSignInPageResource.
                PowerTeacherSignInPage_UserName_Id_Locator);
            //Enter username
            base.FillTextBoxById(PowerTeacherSignInPageResource.
                PowerTeacherSignInPage_UserName_Id_Locator, username);
            //Wait For Password Text Box
            base.WaitForElement(By.XPath(PowerTeacherSignInPageResource.
                PowerTeacherSignInPage_Password_Xpath_Locator), Convert.ToInt32(
                PowerTeacherSignInPageResource.PowerTeacherSignInPage_Custom_TimeToWait_Value));
            //Clear The Password Text Box
            base.ClearTextByXPath(PowerTeacherSignInPageResource.
                PowerTeacherSignInPage_Password_Xpath_Locator);
            //Enter password
            base.FillTextBoxByXPath(PowerTeacherSignInPageResource.
                PowerTeacherSignInPage_Password_Xpath_Locator, password);
            Logger.LogMethodExit("PowerTeacherSignInPage", "EnterUserNamePassword",
               base.IsTakeScreenShotDuringEntryExit);
        }

        //private Boolean HandleSSLError()
        //{
        //    //IWebElement ContinuetoWebsitelink = base.GetWebElementPropertiesById(string.Format(
        //    //            PowerTeacherSignInPageResource.
        //    //            PowerTeacherSignInPage_SSL_Error_Message_Id_Locator));
        //    //base.ClickByJavaScriptExecutor(ContinuetoWebsitelink);
        //    bool ssllink = base.IsElementPresent(By.Id(PowerTeacherSignInPageResource.
        //        PowerTeacherSignInPage_SSL_Error_Continue_Link_Id_Locator),10);
        //    base.WaitForElement(By.Id(PowerTeacherSignInPageResource.
        //        PowerTeacherSignInPage_SSL_Error_Continue_Link_Id_Locator),10);
        //    base.ClickLinkById(PowerTeacherSignInPageResource.
        //        PowerTeacherSignInPage_SSL_Error_Continue_Link_Id_Locator);
        //    bool IsLoginPageAvailable = base.IsElementDisplayedById(
        //        PowerTeacherSignInPageResource.
        //        PowerTeacherSignInPage_UserName_Id_Locator);
        //    return IsLoginPageAvailable;
        //}
    }
}
