using System;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using System.Collections.Generic;

namespace Pegasus.Pages.UI_Pages.Integration.Rumba
{
    ///<Summary>
    /// Contains login page details
    ///</Summary>

    public class SignInPage : BasePage
    {
      
        // Static instance of the logger
        private static readonly Logger logger = Logger.GetInstance(typeof(SignInPage));

        /// <summary>
        /// Login in to the Rumba as RADmin
        /// </summary>
        /// <param name="userTypeEnum">User Type</param>
        public void LoginToRumba(User.UserTypeEnum userTypeEnum)
        {
            //Login in Rumba
            logger.LogMethodEntry("SignInPage", "LoginToRumba",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Check whether the user already loggedin or not
                Boolean isUserAlreadyLoggedIn = base.IsElementPresent
                    (By.PartialLinkText(SignInPageResource.
                    SignInPage_Signout_Link_Title_Locator),
                    Convert.ToInt32(SignInPageResource.SignInPage_Custom_TimeToWait_Value));
                if (!isUserAlreadyLoggedIn)
                {   //Get the user of the given type from memory
                    User user = User.Get(userTypeEnum);
                    //Authenticate the user
                    Authentication(user.Name, user.Password, userTypeEnum);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SignInPage", "LoginToRumba",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Authenticate the user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <param name="userTypeEnum">This is user by type</param>
        /// <returns>Login successfully status</returns>
        private void Authentication(String username, String password,
            User.UserTypeEnum userTypeEnum)
        {
            //User authentication
            logger.LogMethodEntry("SignInPage", "Authentication",
                base.IsTakeScreenShotDuringEntryExit);
            bool isLoginSuccessful = false;
            while (!isLoginSuccessful)
            {
                this.EnterUserNamePassword(username, password);
                //SignIn To Rumba
                base.SubmitButtonByClassName(SignInPageResource.
                    SignInPage_SignIn_Button_ClassName_Locator);
                Thread.Sleep(Convert.ToInt32(SignInPageResource.
                    SignInPage_ThreadTimeToWait));
                //Stores the RADmin Login validation result
                isLoginSuccessful = ValidateRAdminLogin(userTypeEnum);
                //User not successfully logged in
                if (!isLoginSuccessful)
                {
                    //Throws an message "Unable to login"
                    throw new LoginFailedException(string.Format
                        ("Unable to login using Username = {0} and Password = {1}",
                        username, password));
                }
            }
            logger.LogMethodExit("SignInPage", "Authentication",
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
            logger.LogMethodEntry("SignInPage", "EnterUserNamePassword",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Username Text Box
            base.WaitForElement(By.Id(SignInPageResource.
                SignInPage_Username_Text_id_Locator), Convert.ToInt32(
                    SignInPageResource.SignInPage_Custom_TimeToWait_Value));
            //Clear The UserName Text Box
            base.ClearTextById(SignInPageResource.
                SignInPage_Username_Text_id_Locator);
            //Enter username
            base.FillTextBoxById(SignInPageResource.
                SignInPage_Username_Text_id_Locator, username);
            //Wait For Password Text Box
            base.WaitForElement(By.Id(SignInPageResource.
                SignInPage_Password_Text_id_Locator), Convert.ToInt32(
                SignInPageResource.SignInPage_Custom_TimeToWait_Value));
            //Clear The Password Text Box
            base.ClearTextById(SignInPageResource.
                SignInPage_Password_Text_id_Locator);
            //Enter password
            base.FillTextBoxById(SignInPageResource.
                SignInPage_Password_Text_id_Locator, password);
            logger.LogMethodExit("SignInPage", "EnterUserNamePassword",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate RADmin login
        /// </summary>
        /// <param name="userTypeEnum">This is user by type</param>
        /// <returns>Login Success Status</returns>
        private Boolean ValidateRAdminLogin(User.UserTypeEnum userTypeEnum)
        {
            //RADmin login validation
            logger.LogMethodEntry("SignInPage", "ValidateRAdminLogin",
                base.IsTakeScreenShotDuringEntryExit);
            //Check Is Login Sucessful
            bool isLoginSuccessful = base.IsWindowsExists(SignInPageResource.
                SignInPage_HomePage_Title_Name);
            logger.LogMethodEntry("SignInPage", "ValidateRAdminLogin",
                  base.IsTakeScreenShotDuringEntryExit);
            return isLoginSuccessful;
        }

        /// <summary>
        /// Click Sign out link on the page
        /// </summary>
        /// <param name="linkSignOut">This is SingOut Link Name</param>
        public void ClickSignOutLink(String linkSignOut)
        {
            //Click Sign out link on the page
            logger.LogMethodEntry("LoginPage", "ClickSignOutLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for element
                base.WaitForElement((By.PartialLinkText(linkSignOut)));
                //Click SignOut Link
                base.GetWebElementPropertiesByPartialLinkText(linkSignOut).Click();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("LoginPage", "ClickSignOutLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Rumba User Sign Out Message
        /// </summary>
        /// <returns>Signout Message</returns>
        public String GetRumbaUserSignOutMessage()
        {
            //Get Sign Out Message
            logger.LogMethodEntry("LoginPage", "GetRumbaUserSignOutMessage",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSignOutMessage = string.Empty;
            try
            {
                //Wait for Window To Get Load
                base.WaitUntilWindowLoads(SignInPageResource.
                    SignInPage_Logout_Window_Title);
                //Select Window
                base.SelectWindow(SignInPageResource.
                    SignInPage_Logout_Window_Title);
                //Wait For Element Login Container
                base.WaitForElement(By.Id(SignInPageResource.
                    SignInPage_LoginContainer_Id_Locator));
                //Wait For Element Sign Out Message
                base.WaitForElement(By.XPath(SignInPageResource.
                        SignInPage_SignoutMessage_xpath_Locator));
                //Get SignOut Message From Application
                getSignOutMessage = base.GetElementTextByXPath(SignInPageResource.
                    SignInPage_SignoutMessage_xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("LoginPage", "GetRumbaUserSignOutMessage",
               base.IsTakeScreenShotDuringEntryExit);
            //Return Message
            return getSignOutMessage;
        }

        /// <summary>
        /// Method to return dictionary object that contains requied contineo parameters.
        /// </summary>
        /// <returns>Dictionary contains key value pairs.</returns>
        public Dictionary<String, String> GetRequiredParametersForRUL(String profile,
            String k12Int)
        {
            //Log Method entry
            logger.LogMethodEntry("SignInPage", "GetRequiredParametersForRUL",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            Dictionary<String, String> requiredParametrs = new Dictionary<String, String>();            
            try
            {
                //Wait for Window To Get Load
                base.WaitUntilWindowLoads(SignInPageResource.
                    SignInPage_Logout_Window_Title);
                //Logic to populate dictionary 
                String getUrl = base.GetCurrentUrl;
                String[] getUrlSegmentCollection = getUrl.Substring(getUrl.IndexOf(SignInPageResource.Url_Separator) + 1).
                    Split(SignInPageResource.QueryString_Separator.ToCharArray());
                foreach (String urlSegment in getUrlSegmentCollection)
                {
                    String getUrlKey = urlSegment.Substring(0, urlSegment.IndexOf(SignInPageResource.Key_Value_Separator));
                    String value = urlSegment.Substring((urlSegment.IndexOf(SignInPageResource.Key_Value_Separator) + 1));
                    if (getUrlKey.Equals(profile, StringComparison.OrdinalIgnoreCase)
                        || getUrlKey.Equals(k12Int, StringComparison.OrdinalIgnoreCase))
                    {
                        requiredParametrs.Add(getUrlKey, value);
                    }
                }
                          
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Log Method exit
            logger.LogMethodExit("SignInPage", "GetRequiredParametersForRUL",
               base.IsTakeScreenShotDuringEntryExit);
            //Return dictionary
            return requiredParametrs;     
        }

        /// <summary>
        /// Method to redirect to RUL page
        /// </summary>
        /// <returns>Dictionary</returns>
        public void RedirectToRULPage(String buttonClassName)
        {
            // Log method entry
            logger.LogMethodEntry("SignInPage", "RedirectToRULPage",
              base.IsTakeScreenShotDuringEntryExit);

            try
            {
                //Wait for element
                base.WaitForElement((By.ClassName(buttonClassName)));
                //Click Sign In button
                base.GetWebElementPropertiesByClassName(buttonClassName).Click();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            // Log method exit
            logger.LogMethodExit("SignInPage", "RedirectToRULPage",
               base.IsTakeScreenShotDuringEntryExit);


        }


    }
}
