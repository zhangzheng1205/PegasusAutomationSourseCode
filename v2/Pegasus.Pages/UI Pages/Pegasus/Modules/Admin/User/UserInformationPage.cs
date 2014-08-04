using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.User;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.OrganizationManagement;
using System.Configuration;
using System.Threading;
using System.IO;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles information of User Information Page
    /// </summary>
    public class UserInformationPage : BasePage
    {

        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(UserInformationPage));


        /// <summary>
        /// Get User Information Details
        /// </summary>
        /// <returns>User Information</returns>
        public String GetUserInformationDetails()
        {
            //Verify User Information
            logger.LogMethodEntry("UserInformationPage", "GetUserInformationDetails",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable to get UserInformationDetails
            string getUserInformationDetails = string.Empty;
            //Initialize Variable to get UserName
            string getUserName = string.Empty;
            //Initialize Variable to get UserEmail
            string getUserEmail = string.Empty;
            //Initialize Variable to get UserId
            string getUserId = string.Empty;
            //Initialize Variable to get SignIn
            string getSignIn = string.Empty;
            //Initialize Variable to get UserAccess
            string getUserAccess = string.Empty;
            try
            {
                base.SelectWindow(UserInformationPageResource.
                    UserInformation_Page_Userformation_Window_Name);
                //Get User name
                base.WaitForElement(By.XPath(UserInformationPageResource.
                            UserInformation_Page_NameField_Xpath_Locator));
                getUserName = base.GetElementTextByXPath(UserInformationPageResource.
                            UserInformation_Page_NameField_Xpath_Locator);
                //Get User Email
                getUserEmail = this.GetUserMail(getUserEmail);
                //Get User Id
                getUserId = this.GetUserId(getUserId);
                //Get Sign In
                getSignIn = this.GetSignIn(getSignIn);
                //Get User Access
                getUserAccess = this.GetUserAccess(getUserAccess);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserInformationPage", "GetUserInformationDetails",
               base.IsTakeScreenShotDuringEntryExit);
            getUserInformationDetails = getUserName + getUserEmail + getUserId + getSignIn + getUserAccess;
            return getUserInformationDetails;
        }


        /// <summary>
        /// Get User Mail
        /// </summary>
        /// <param name="userEmail">This is User Mail</param>
        /// <returns>User Mail</returns>
        private string GetUserMail(string userEmail)
        {
            //Get User Mail
            logger.LogMethodEntry("UserInformationPage", "GetUserMail",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(UserInformationPageResource.
                UserInformation_Page_EmailField_Xpath_Locator));
            userEmail = base.GetElementTextByXPath(UserInformationPageResource.
                UserInformation_Page_EmailField_Xpath_Locator);
            logger.LogMethodExit("UserInformationPage", "GetUserMail",
              base.IsTakeScreenShotDuringEntryExit);
            return userEmail;
        }

        /// <summary>
        /// Get User Id
        /// </summary>
        /// <param name="userId">This is User Id</param>
        /// <returns>User Id</returns>
        private string GetUserId(string userId)
        {
            //Get User Id
            logger.LogMethodEntry("UserInformationPage", "GetUserId",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(UserInformationPageResource.
                    UserInformation_Page_UserIdField_Xpath_Locator));
            userId = base.GetElementTextByXPath(UserInformationPageResource.
                    UserInformation_Page_UserIdField_Xpath_Locator);
            logger.LogMethodExit("UserInformationPage", "GetUserId",
              base.IsTakeScreenShotDuringEntryExit);
            return userId;
        }

        /// <summary>
        /// Get Sign In
        /// </summary>
        /// <param name="signIn">This is Sign In</param>
        /// <returns>Sign In</returns>
        private string GetSignIn(string signIn)
        {
            //Get Sign In
            logger.LogMethodEntry("UserInformationPage", "GetSignIn",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(UserInformationPageResource.
                    UserInformation_Page_SignInFiled_Xpath_Locator));
            signIn = base.GetElementTextByXPath(UserInformationPageResource.
                    UserInformation_Page_SignInFiled_Xpath_Locator);
            logger.LogMethodExit("UserInformationPage", "GetSignIn",
              base.IsTakeScreenShotDuringEntryExit);
            return signIn;
        }

        /// <summary>
        /// Get User Access
        /// </summary>
        /// <param name="userAccess">This is User Access</param>
        /// <returns>User Access</returns>
        private string GetUserAccess(string userAccess)
        {
            //Get User Access
            logger.LogMethodEntry("UserInformationPage", "GetUserAccess",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(UserInformationPageResource
                    .USerInformation_Page_AccessField_Xpath_Locator));
            userAccess = base.GetElementTextByXPath(UserInformationPageResource
                    .USerInformation_Page_AccessField_Xpath_Locator);
            logger.LogMethodExit("UserInformationPage", "GetUserAccess",
              base.IsTakeScreenShotDuringEntryExit);
            return userAccess;
        }


        /// <summary>
        /// Get the UserName
        /// </summary>
        /// <returns>UserName</returns>
        public string GetUserName()
        {
            //Get the User Name
            logger.LogMethodEntry("UserInformationPage", "GetUserName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            string getUserName = string.Empty;
            try
            {
                //Select User Information Window
                base.SelectWindow(UserInformationPageResource.
                        UserInformation_Page_Userformation_Window_Name);
                base.WaitForElement(By.XPath(UserInformationPageResource.
                    UserInformation_Page_GetUsername_Xpath_Locator));
                //Get the User Name
                getUserName = base.GetElementTextByXPath(UserInformationPageResource.
                    UserInformation_Page_GetUsername_Xpath_Locator);
                //Select User Formation Window
                base.SelectWindow(UserInformationPageResource.
                    UserInformation_Page_Userformation_Window_Name);
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserInformationPage", "GetUserName",
               base.IsTakeScreenShotDuringEntryExit);
            return getUserName;
        }

    }
}
