using System;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using System.Diagnostics;


namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Contains The Details Of Login Page.
    /// </summary>
    public class BrowsePegasusUserURL : BasePage
    {
        /// <summary>
        /// This is the space in pegasus where user will be logged in.
        /// </summary>
        public enum PegasusLoginSpace
        {
            /// <summary>
            /// Work space for login
            /// </summary>
            WorkSpace = 1,
            /// <summary>
            /// Course space for login
            /// </summary>
            CourseSpace = 2
        }

        /// <summary>
        /// This is Password Type Enum.
        /// </summary>
        public enum PasswordTypeEnum
        {
            /// <summary>
            /// This is Incorrect Password
            /// </summary>
            Incorrect = 1,
            /// <summary>
            /// This is Correct Password
            /// </summary>
            Correct = 2
        }

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(BrowsePegasusUserURL));

        /// <summary>
        /// This is the login retry count.
        /// </summary>
        static readonly int LoginAttemptRetryCount = Convert.ToInt32(ConfigurationManager.
            AppSettings[LoginPageResource.Login_Page_AppSetting_RetryCount_Key]);

        /// <summary>
        /// Get Wait Limit Time From Config.
        /// </summary>
        private readonly int _getWaitTimeOut = Convert.ToInt32(
            ConfigurationManager.AppSettings["ElementFindTimeOutInSeconds"]);

        /// <summary>
        /// Initialize base Pegasus login Url.
        /// </summary>
        readonly string _baseLoginUrl;

        /// <summary>
        ///  Get Title of the Page.
        /// </summary>
        public new string GetPageTitle()
        {
            //Get Page Title
            { return base.GetPageTitle; }
        }

        /// <summary>
        /// Gets the Pegasus base login Url from configuration.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type Enum.</param>
        public BrowsePegasusUserURL(User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("LoginPage", "BrowsePegasusUserURL",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userTypeEnum)
                {
                    // Get URL of workspace admin
                    case User.UserTypeEnum.HedWsAdmin:
                    case User.UserTypeEnum.HedMiLWsAdmin:
                    case User.UserTypeEnum.HedCoreVmWsAdmin:
                        _baseLoginUrl = string.Format(
                            AutomationConfigurationManager.WorkSpaceUrlRoot
                                + LoginPageResource
                                 .Login_Page_WorkSpaceAdminURL_Append_Parameters); break;
                    // Get URL of workspace Teacher/Student
                    case User.UserTypeEnum.HedWsInstructor:
                    case User.UserTypeEnum.HedWsStudent:
                        _baseLoginUrl = string.Format(
                            AutomationConfigurationManager.WorkSpaceUrlRoot
                                 + LoginPageResource
                                  .Login_Page_WorkspaceURL_Append_Parameters); break;
                    // Get URL of Course Space admin
                    case User.UserTypeEnum.HedCsAdmin:
                        _baseLoginUrl = string.Format(
                            AutomationConfigurationManager.CourseSpaceUrlRoot
                                + LoginPageResource
                                 .Login_Page_CourseSpaceAdminURL_Append_Parameters); break;
                    //Get url of course space teacher/student
                    case User.UserTypeEnum.CsSmsInstructor:
                    case User.UserTypeEnum.AmpCsSmsInstructor:
                    case User.UserTypeEnum.CsSmsStudent:
                    case User.UserTypeEnum.AmpCsSmsStudent:
                    case User.UserTypeEnum.HedProgramAdmin:
                    case User.UserTypeEnum.AmpProgramAdmin:
                    case User.UserTypeEnum.HSSCsSmsInstructor:
                    case User.UserTypeEnum.HSSCsSmsStudent:
                    case User.UserTypeEnum.HSSProgramAdmin:
                    case User.UserTypeEnum.HedTeacherAssistant:
                    case User.UserTypeEnum.HedMilAcceptanceInstructor:
                    case User.UserTypeEnum.HedMilAcceptanceStudent:
                    case User.UserTypeEnum.HedCoreAcceptanceInstructor:
                    case User.UserTypeEnum.HedCoreAcceptanceStudent:
                    case User.UserTypeEnum.WLCsSmsInstructor:
                    case User.UserTypeEnum.MyTestSmsInstructor:
                    case User.UserTypeEnum.WLCsSmsStudent:
                    case User.UserTypeEnum.WLProgramAdmin:
                        _baseLoginUrl = string.Format(
                            AutomationConfigurationManager.CourseSpaceUrlRoot
                                 + LoginPageResource
                                 .Login_Page_Hed_CourseSpaceURL_Append_Parameters);
                        break;
                    //Get url of Synapse workspace admin
                    case User.UserTypeEnum.WsAdmin:
                        _baseLoginUrl = string.Format(
                            AutomationConfigurationManager.WorkSpaceUrlRoot
                               + LoginPageResource
                               .Login_Page_WorkSpaceAdminURL_Append_Parameters); break;
                    //Get url of Synapse course space admin
                    case User.UserTypeEnum.CsAdmin:
                    case User.UserTypeEnum.DPCourseSpacePramotedAdmin:
                        _baseLoginUrl = string.Format(
                            AutomationConfigurationManager.CourseSpaceUrlRoot
                               + LoginPageResource
                               .Login_Page_WorkSpaceAdminURL_Append_Parameters); break;
                    //Get url of workspace teacher/student for Synapse users
                    case User.UserTypeEnum.WsStudent:
                    case User.UserTypeEnum.WsTeacher:
                    case User.UserTypeEnum.DPWorkSpacePramotedAdmin:
                        _baseLoginUrl = string.Format(
                            AutomationConfigurationManager.WorkSpaceUrlRoot
                                   + LoginPageResource.
                                   Login_Page_WorkspaceURL_Append_Parameters); break;
                    //Get Url of Rumba Admin
                    case User.UserTypeEnum.RUMBAAdmin:
                        _baseLoginUrl = string.Format(AutomationConfigurationManager.RumbaUrlRoot);
                        base.DeleteAllBrowserCookies();
                        break;
                    //Get Url of Synapse CourseSpace User
                    case User.UserTypeEnum.DPCsTeacher:
                    case User.UserTypeEnum.DPCsNewStudent:
                    case User.UserTypeEnum.DPCsNewTeacher:
                    case User.UserTypeEnum.DPCsNewAide:
                    case User.UserTypeEnum.DPDemoUser:
                    case User.UserTypeEnum.DPCsStudent:
                    case User.UserTypeEnum.RumbaTeacher:
                    case User.UserTypeEnum.RumbaStudent:
                        _baseLoginUrl = string.Format(AutomationConfigurationManager.
                            CourseSpaceUrlRoot
                                 + LoginPageResource
                                 .Login_Page_Synapse_CourseSpaceUserURL_Append_Parameters); break;
                    //Get url of Synapse workspace admin
                    case User.UserTypeEnum.NovaNETWsAdmin:
                        _baseLoginUrl = string.Format(AutomationConfigurationManager.
                            WorkSpaceUrlRoot
                               + LoginPageResource
                               .Login_Page_WorkSpaceAdminURL_Append_Parameters); break;
                    //Get Url of Synapse Novanet Coursespace User
                    case User.UserTypeEnum.NovaNETCsTeacher:
                    case User.UserTypeEnum.NovaNETCsStudent:
                        _baseLoginUrl = string.Format(AutomationConfigurationManager.
                            CourseSpaceUrlRoot
                                 + LoginPageResource
                                 .Login_Page_Synapse_CourseSpaceUserURL_Append_Parameters); break;
                    // Get URL of MMNDInstructor
                    case User.UserTypeEnum.MMNDInstructor:
                    // Get URL of MMNDStudent
                    case User.UserTypeEnum.MMNDStudent:
                        _baseLoginUrl = string.Format(AutomationConfigurationManager.MmndUsersLoginUrl);
                        base.DeleteAllBrowserCookies();
                        break;
                    // Get URL of MMNDAdmin
                    case User.UserTypeEnum.MMNDAdmin:
                        _baseLoginUrl = string.Format(AutomationConfigurationManager.
                            MmndUrlRoot);
                        base.DeleteAllBrowserCookies();
                        break;
                    // Get URL for DPCTGPPublisherAdmin
                    case User.UserTypeEnum.DPCTGPPublisherAdmin:
                    case User.UserTypeEnum.HEDWSCTGPublisherAdmin:
                        _baseLoginUrl = string.Format(AutomationConfigurationManager.WorkSpaceUrlRoot
                            + LoginPageResource.Login_Page_WorkSpaceAdminURL_Append_Parameters);
                        break;
                    // Get URL of OrganizationAdmin
                    case User.UserTypeEnum.DPCsOrganizationAdmin:
                        _baseLoginUrl = string.Format(AutomationConfigurationManager.CourseSpaceUrlRoot
                                + LoginPageResource
                                .Login_Page_Synapse_CourseSpaceUserURL_Append_Parameters);
                        break;
                    // Get URL of ECollege Portal Admin URL
                    case User.UserTypeEnum.ECollegeAdmin:
                    case User.UserTypeEnum.ECollegeTeacher:
                    case User.UserTypeEnum.ECollegeStudent:
                        _baseLoginUrl = string.Format(ConfigurationManager.
                            AppSettings[LoginPageResource.LoginPage_ECollegeAdmin_RootURL_Config_Value]);
                        break;
                    //Get URL for Backdoor login page
                    case User.UserTypeEnum.HedBackdoorLoginInstructor:
                    case User.UserTypeEnum.HedBackdoorLoginStudent:
                        _baseLoginUrl = string.Format("{0}{1}",
                            AutomationConfigurationManager.CourseSpaceUrlRoot
                            , LoginPageResource
                            .LoginPage_Backdoor_CourseSpaceUser_Append_Parameters);
                        break;
                    case User.UserTypeEnum.HEDCSCTGPPublisherAdmin:
                        _baseLoginUrl = string.Format("{0}{1}",
                            AutomationConfigurationManager.CourseSpaceUrlRoot
                            , LoginPageResource.LoginPage_CourseSpaceAdminURL_Append_Parameters);
                        break;
                    case User.UserTypeEnum.HedMilPPEStudent:
                        _baseLoginUrl = string.Format(
                            AutomationConfigurationManager.CourseSpaceUrlRoot
                                 + LoginPageResource
                                 .Login_Page_Hed_CourseSpaceURL_Append_Parameters); break;
                    case User.UserTypeEnum.SMSAdmin:
                        _baseLoginUrl = string.Format(AutomationConfigurationManager.SmsAdminUrlRoot)
                            + LoginPageResource.Login_Page_SMSAdmin_Append_Parameter;
                        break;
                    case User.UserTypeEnum.SMSAdminStudent:
                        _baseLoginUrl = string.Format(AutomationConfigurationManager.SmsMmndStudentRegistrationUrl)
                            + LoginPageResource.Login_Page_SMSAdmin_Append_Parameter;
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("Login", "BrowsePegasusUserURL", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Navigates from base Url in browser through WebDriver.
        /// </summary>
        public void GoToLoginUrl()
        {
            Logger.LogMethodEntry("LoginPage", "GoToLoginUrl",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Url Successfully Browsed
                if (IsUrlBrowsedSuccessful())
                {
                    //Open Url in Browser
                    base.NavigateToBrowseUrl(this._baseLoginUrl);
                }
                else
                {
                    throw new Exception("Browser cannot display the webpage");
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LoginPage", "GoToLoginUrl",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Login of User.
        /// </summary>
        /// <param name="userName">This is the user name.</param>
        /// <param name="password">This is the password.</param>
        /// <param name="loginSpace">This is the login space.</param>
        /// <param name="userTypeEnum">This is User Type.</param>
        public void Authenticate(String userName, String password,
            PegasusLoginSpace loginSpace, User.UserTypeEnum userTypeEnum)
        {
            //User Login
            Logger.LogMethodEntry("LoginPage", "Authenticate", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //First we try to login into the application
                this.Authenticate(userName, password, userTypeEnum);
                if (this.IsFirstTimeLogin)
                {
                    //Hadling First Time User Login
                    this.HandleUsersFirstLoginAttempt(userName, password, loginSpace, userTypeEnum);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LoginPage", " Authenticate",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Checks if the user is loggedin first time.
        /// </summary>
        private bool IsFirstTimeLogin
        {
            //User Login for First Time
            get
            {
                //Checks Keyword Present in Url
                return
                    base.IsUrlContainsTheKeyword(LoginPageResource.
                    Login_Page_Rumba_First_ResetPassword_Url_keyword)
                    || base.IsUrlContainsTheKeyword(LoginPageResource.
                          Login_Page_Rumba_Second_ResetPassword_Url_keyword)
                    //Checks New Password TextBox Present
                    || base.IsUrlContainsTheKeyword(LoginPageResource.
                          Login_Page_FirstTimeLogin_ResetPassword_Url_Keyword)
                    || base.IsUrlContainsTheKeyword(LoginPageResource.
                           Login_Page_FirstTimeLogin_ResetPwd_Url_Keyword);
            }
        }

        /// <summary>
        /// This method is used for handling the user's first login attempt.
        /// </summary>
        /// <param name="userName"> This is the user name.</param>
        /// <param>This is the password .<name>password.</name> </param>
        /// <param name="existingPassword">This is the user existing password.</param>
        /// <param name="loginSpace">This is the login space.</param>
        /// <param name="userType">This is the user by type.</param>
        private void HandleUsersFirstLoginAttempt(String userName, String existingPassword,
            PegasusLoginSpace loginSpace, User.UserTypeEnum userType)
        {
            //Handling First Login Attempt by User
            Logger.LogMethodEntry("LoginPage", "HandleUsersFirstLoginAttempt",
                base.IsTakeScreenShotDuringEntryExit);
            switch (loginSpace)
            {
                // Purpose: Login with Ws Teacher for First Time
                case BrowsePegasusUserURL.PegasusLoginSpace.WorkSpace:
                    this.HandleFirstTimeLoginAttemptForWorkSpace(userName, existingPassword,
                        LoginPageResource.Login_Page_NewPasswordOfUser_Value, userType);
                    break;
                // Purpose: Login with Cs Teacher for First Time
                case BrowsePegasusUserURL.PegasusLoginSpace.CourseSpace:
                    this.HandleFirstTimeLoginAttemptForCoursepsace(userName, existingPassword,
                        LoginPageResource.Login_Page_NewPasswordOfUser_Value, userType);
                    break;
            }
            //Do not reset password for Rumba Users
            if (!userType.Equals(User.UserTypeEnum.RumbaTeacher) &&
                !userType.Equals(User.UserTypeEnum.RumbaStudent))
            {
                //Get User from Memory
                User user = User.Get(userType);
                user.Password = LoginPageResource.Login_Page_NewPasswordOfUser_Value;
            }
            Logger.LogMethodExit("LoginPage", "HandleUsersFirstLoginAttempt",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method handles first time login of Coursespace.
        /// </summary>
        /// <param name="userName">This is User Name.</param>
        /// <param name="existingPassword">This is existing password.</param>
        /// <param name="newPassword">This is new password.</param>
        /// <param name="userType">This is User by Type.</param>
        private void HandleFirstTimeLoginAttemptForCoursepsace
            (String userName, String existingPassword,
            String newPassword, User.UserTypeEnum userType)
        {
            //Handling First Time User in CS
            Logger.LogMethodEntry("LoginPage", "HandleFirstTimeLoginAttemptForCoursepsace"
                , base.IsTakeScreenShotDuringEntryExit);
            // This check is to handle DP course space promoted admin login
            if (userType.Equals(User.UserTypeEnum.DPCourseSpacePramotedAdmin))
            {
                //Using this workspace function here because it is using the same locators of Promoted CS admin
                ResetPasswordForWorkSpaceUser(userName, existingPassword,
                    newPassword, userType);
            }
            else
            {
                switch (userType)
                {
                    case User.UserTypeEnum.RumbaTeacher:
                    case User.UserTypeEnum.DPCsNewAide:
                    case User.UserTypeEnum.RumbaStudent:
                    case User.UserTypeEnum.DPDemoUser:
                        //Handling User Consent Page in CS
                        HandleUserConsentAction();
                        break;
                    default:
                        //Reset Password For New User(s)
                        ResetPasswordForCourseSpaceUser(existingPassword, newPassword);
                        //Handling User Consent Page in CS
                        HandleUserConsentAction();
                        break;
                }
                if (base.IsElementPresent(By.Id(LoginPageResource.
                    Login_Page_Synapse_CSUser_SignIn_Button_Class_Locator), Convert.ToInt32
                    (LoginPageResource.Login_Page_Custom_TimeToWait)))
                {
                    //Authenticate User Login
                    Authenticate(userName, newPassword, userType);
                }
            }
            Logger.LogMethodExit("LoginPage", "HandleFirstTimeLoginAttemptForCoursepsace",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method handles first login attempt in workspace.
        /// </summary>
        /// <param name="userName">This is User Name.</param>
        /// <param name="existingPassword">This is existing password.</param>
        /// <param name="newPassword">This is new password.</param>
        /// <param name="userType">This is User by Type.</param>
        private void HandleFirstTimeLoginAttemptForWorkSpace(String userName,
            String existingPassword,
            String newPassword, User.UserTypeEnum userType)
        {
            //Handling First Time User Login
            Logger.LogMethodEntry("LoginPage", "HandleFirstTimeLoginAttemptForWorkSpace",
                base.IsTakeScreenShotDuringEntryExit);
            //Handling Reset Password
            ResetPasswordForWorkSpaceUser(userName, existingPassword,
                newPassword, userType);
            Logger.LogMethodExit("LoginPage", "HandleFirstTimeLoginAttemptForWorkSpace",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method handles the reset password for workspace user.
        /// </summary>
        /// <param name="userName">This is User Name.</param>
        /// <param name="existingPassword">This is the existing password.</param>
        /// <param name="newPassword">This is the new password.</param>
        /// <param name="userType">This is User Type.</param>
        private void ResetPasswordForWorkSpaceUser(String userName,
            String existingPassword, String newPassword, User.UserTypeEnum userType)
        {
            //Reset Password For WS User
            Logger.LogMethodEntry("LoginPage", "ResetPasswordForWorkSpaceUser",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(LoginPageResource.
                Login_Page_CurrentPassword_Textbox_Locator));
            //Insert Old Password
            base.FillTextBoxById(LoginPageResource.
                                     Login_Page_CurrentPassword_Textbox_Locator, existingPassword);
            base.WaitForElement(By.Id(LoginPageResource.
                Login_Page_NewPassword_Texbox_Locator));
            //Insert New Password
            base.FillTextBoxById(LoginPageResource.
                Login_Page_NewPassword_Texbox_Locator, newPassword);
            base.WaitForElement(By.Id(LoginPageResource.
                Login_Page_ConfirmPassword_Texbox_Locator));
            //Insert Confirm Password
            base.FillTextBoxById(LoginPageResource.
                Login_Page_ConfirmPassword_Texbox_Locator, newPassword);
            base.WaitForElement(By.Id(LoginPageResource.
                Login_Page_Save_Button_Locator));
            IWebElement getSaveButtonProperty = base.GetWebElementPropertiesById(LoginPageResource.
                Login_Page_Save_Button_Locator);
            base.ClickByJavaScriptExecutor(getSaveButtonProperty);
            //ReLogin After Reset Password
            if (base.IsElementPresent(By.Id(LoginPageResource
                .Login_Page_Powered_By_Pegasus_Image), Convert.ToInt32(LoginPageResource.
                Login_Page_Custom_TimeToWait)))
            {
                //Authenticate User Login
                Authenticate(userName, newPassword, userType);
            }
            Logger.LogMethodExit("LoginPage", "ResetPasswordForWorkSpaceUser",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method is to reset the password for coursespace user.
        /// </summary>
        /// <param name="existingPassword">This is the passord.</param>
        /// <param name="newPassword">This is the new password.</param>
        private void ResetPasswordForCourseSpaceUser
            (String existingPassword, String newPassword)
        {
            // Reset Password Details For First Time by CS Admin
            Logger.LogMethodEntry("LoginPage", "ResetPasswordForCourseSpaceUser",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(LoginPageResource.
                Login_Page_NewPassword_Textbox_Id_Locator));
            //Insert Existing Password
            base.FillTextBoxById(LoginPageResource.
                Login_Page_NewPassword_Textbox_Id_Locator, newPassword);
            base.WaitForElement(By.Id(LoginPageResource.
                  Login_Page_ConfirmPassword_Textbox_Id_Locator));
            //Insert New Password
            base.FillTextBoxById(LoginPageResource.
                Login_Page_ConfirmPassword_Textbox_Id_Locator, newPassword);
            //Wait For Element
            base.WaitForElement(By.ClassName(LoginPageResource.
               Login_Page_Next_Button_Class_Locator));
            //Click Save Button
            base.ClickButtonByClassName(LoginPageResource.
                Login_Page_Next_Button_Class_Locator);
            Logger.LogMethodExit("LoginPage", "ResetPasswordForCourseSpaceUser",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method is to handle the consent page.
        /// </summary>
        private void HandleUserConsentAction()
        {
            // Handling User Consent Page
            Logger.LogMethodEntry("LoginPage", "HandleUserConsentAction",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(LoginPageResource.LoginPage_Consent_Window_Title);
            //Wait For Element
            base.WaitForElement(By.Id(LoginPageResource.
                Login_Page_LicenseAgreement_CheckBox_Id_Locator));
            //Get Element Property
            IWebElement getCheckBoxProperty = base.GetWebElementPropertiesById
                (LoginPageResource.Login_Page_LicenseAgreement_CheckBox_Id_Locator);
            //Click Chekbox
            base.ClickByJavaScriptExecutor(getCheckBoxProperty);
            //Wait For Element
            base.WaitForElement(By.ClassName(LoginPageResource.
                               Login_Page_Synapse_CSUser_SignIn_Button_Class_Locator));
            //Get Element Property
            IWebElement getNextButtonProperty = base.GetWebElementPropertiesByClassName
                (LoginPageResource.Login_Page_Synapse_CSUser_SignIn_Button_Class_Locator);
            //Click Next Button 
            base.ClickByJavaScriptExecutor(getNextButtonProperty);
            Logger.LogMethodExit("LoginPage", "HandleUserConsentAction",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// The function locates the credentials locators and
        /// submits the data to login into the Pegasus.
        /// </summary>
        /// <param name="userName">Username of the user for login.</param>
        /// <param name="password">Password for the user to login.</param>
        /// <param>Number of times the retry needs to be performed for login.
        /// <name>retryCount</name> </param>
        /// <param name="userType"> This is User Type.</param>
        /// <returns>User Authentication Result</returns>
        private Boolean Authenticate(String userName,
            String password, User.UserTypeEnum userType)
        {
            //Authenticate User Login
            Logger.LogMethodEntry("LoginPage", "Authenticate",
                base.IsTakeScreenShotDuringEntryExit);
            const int count = 0;
            //Initialize Variable
            bool isLoginSuccessful = false;
            while (count <= LoginAttemptRetryCount && !isLoginSuccessful)
            {
                switch (userType)
                {
                    //User Type SMS Instructor and Student
                    case User.UserTypeEnum.CsSmsInstructor:
                    case User.UserTypeEnum.AmpCsSmsInstructor:
                    case User.UserTypeEnum.AmpCsSmsStudent:
                    case User.UserTypeEnum.CsSmsStudent:
                    case User.UserTypeEnum.HSSCsSmsInstructor:
                    case User.UserTypeEnum.HSSCsSmsStudent:
                    case User.UserTypeEnum.HedTeacherAssistant:
                    case User.UserTypeEnum.HedCoreAcceptanceInstructor:
                    case User.UserTypeEnum.HedCoreAcceptanceStudent:
                    case User.UserTypeEnum.HedMilAcceptanceInstructor:
                    case User.UserTypeEnum.HedMilPPEStudent:
                    case User.UserTypeEnum.HedProgramAdmin:
                    case User.UserTypeEnum.AmpProgramAdmin:
                    case User.UserTypeEnum.HSSProgramAdmin:
                    case User.UserTypeEnum.WLCsSmsInstructor:
                    case User.UserTypeEnum.WLCsSmsStudent:
                    case User.UserTypeEnum.MyTestSmsInstructor:
                    case User.UserTypeEnum.WLProgramAdmin:
                        //Enter SMS User Name    
                        this.EnterSmsUserName(userName);
                        break;
                    default:
                        //Enter Default User Name
                        this.EnterDefaultUserName(userName);
                        break;
                }
                //Authenticate Default User Login
                isLoginSuccessful = DefaultUserLoginAuthentication(userName, password,
                    userType, count, isLoginSuccessful);
            }
            Logger.LogMethodExit("LoginPage", "Authenticate",
                base.IsTakeScreenShotDuringEntryExit);
            return isLoginSuccessful;
        }

        /// <summary>
        /// Authenticate Login by Default Pegasus User.
        /// </summary>
        /// <param name="userName">This is username.</param>
        /// <param name="password">This is user password.</param>
        /// <param name="userTypeEnum">This user by type enum.</param>
        /// <param name="count">This is the number of login attempt.</param>
        /// <param name="isLoginSuccessful">This is Login Successfull Status.</param>
        /// <returns>Returns true if login successfull otherwise false.</returns>
        private bool DefaultUserLoginAuthentication(String userName, String password,
            User.UserTypeEnum userTypeEnum, int count, bool isLoginSuccessful)
        {
            Logger.LogMethodEntry("LoginPage", "DefaultUserLoginAuthentication",
                base.IsTakeScreenShotDuringEntryExit);
            //Clear and Enter Password   
            base.ClearTextById(LoginPageResource.
                         Login_Page_Password_TextBox_Id_Locator);
            base.FillTextBoxById(LoginPageResource.
                         Login_Page_Password_TextBox_Id_Locator, password);
            //Click on Login Submit Button based on User by Type
            if (User.UserTypeEnum.DPCsTeacher == userTypeEnum
                || User.UserTypeEnum.DPDemoUser == userTypeEnum
                || User.UserTypeEnum.DPCsStudent == userTypeEnum
                || User.UserTypeEnum.DPCsNewStudent == userTypeEnum
                || User.UserTypeEnum.DPCsNewTeacher == userTypeEnum
                || User.UserTypeEnum.DPCsNewAide == userTypeEnum
                || User.UserTypeEnum.RumbaTeacher == userTypeEnum
                || User.UserTypeEnum.RumbaStudent == userTypeEnum
                || User.UserTypeEnum.DPCsOrganizationAdmin == userTypeEnum
                || User.UserTypeEnum.NovaNETCsTeacher == userTypeEnum
                || User.UserTypeEnum.NovaNETCsStudent == userTypeEnum
                || User.UserTypeEnum.NovaNETCsOrganizationAdmin == userTypeEnum)
            {
                this.ClickSynapseSignInButton();
            }
            else
            {
                base.SubmitButtonByClassName(LoginPageResource.
               Login_Page_Submit_Button_ClassName_Locator);
            }
            Thread.Sleep(Convert.ToInt32(LoginPageResource
                .Login_Page_ThreadTimeToWait_Value));
            // is login success
            isLoginSuccessful = ValidateLogin(userTypeEnum);
            if (count == LoginAttemptRetryCount && !isLoginSuccessful)
            {
                throw new LoginFailedException(String.Format
                    ("Unable to logn using username = {0} and password = {1}",
                    userName, password));
            }
            Logger.LogMethodExit("LoginPage", "DefaultUserLoginAuthentication",
                base.IsTakeScreenShotDuringEntryExit);
            return isLoginSuccessful;
        }

        /// <summary>
        /// Enter Default User Name.
        /// </summary>
        /// <param name="userName">This is User Name.</param>
        private void EnterDefaultUserName(String userName)
        {
            //Enter User Name
            Logger.LogMethodEntry("LoginPage", "EnterDefaultUserName",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(LoginPageResource.
                Login_Page_UserName_TextBox_Id_Locator));
            //Insert User Name in Username TextBox
            base.FillTextBoxById(LoginPageResource.
                Login_Page_UserName_TextBox_Id_Locator, userName);
            Logger.LogMethodExit("LoginPage", "EnterDefaultUserName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter SMS User Name.
        /// </summary>
        /// <param name="userName">This is User Name.</param>
        private void EnterSmsUserName(String userName)
        {
            //Enter User Name
            Logger.LogMethodEntry("LoginPage", "EnterSmsUserName",
                base.IsTakeScreenShotDuringEntryExit);
            // Insert User Name in Username TextBox
            base.FillTextBoxByCssSelector("#loginname", userName);
            Logger.LogMethodExit("LoginPage", "EnterSmsUserName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Synapse User Sign In Button.
        /// </summary>
        private void ClickSynapseSignInButton()
        {
            //Click SignIn Button
            Logger.LogMethodEntry("LoginPage", "ClickSynapseSignInButton",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.ClassName(LoginPageResource.
                Login_Page_Synapse_CSUser_SignIn_Button_Class_Locator));
            //Get Element Property
            IWebElement getSignInButton = base.GetWebElementPropertiesByClassName(LoginPageResource.
                Login_Page_Synapse_CSUser_SignIn_Button_Class_Locator);
            //Click SignIn Button
            base.ClickByJavaScriptExecutor(getSignInButton);
            Logger.LogMethodExit("LoginPage", "ClickSynapseSignInButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Sign out link on the page.
        /// </summary>
        /// <param name="linkSignOut">This is SingOut Link.</param>
        /// <returns>Sing out link  click result.</returns>
        public void ClickSignOutButton(String linkSignOut)
        {
            //Complete SingOut Process
            Logger.LogMethodEntry("LoginPage", "ClickSignOutButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement((By.PartialLinkText(linkSignOut)));
                //Click SignOut Link
                base.GetWebElementPropertiesByPartialLinkText(linkSignOut).Click();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LoginPage", "ClickSignOutButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method is used to validate the login of usertypes.
        /// </summary>
        /// <param name="userTypeEnum">This is the user by type.</param>
        /// <returns>Login Attempt Status Result.</returns>
        private Boolean ValidateLogin(User.UserTypeEnum userTypeEnum)
        {
            //Validate Login Success
            Logger.LogMethodEntry("LoginPage", "ValidateLogin",
                base.IsTakeScreenShotDuringEntryExit);
            Boolean isLoginSuccessful = false;
            switch (userTypeEnum)
            {
                //Logged in by Hed Ws Admin
                case User.UserTypeEnum.HedWsAdmin:
                //Logged in by DP Ws Admin
                case User.UserTypeEnum.WsAdmin:
                case User.UserTypeEnum.DPWsAdmin:
                case User.UserTypeEnum.HedCoreVmWsAdmin:
                //Logged in by NN Ws Admin
                case User.UserTypeEnum.NovaNETWsAdmin:
                    isLoginSuccessful = this.
                        IsWsAdminValidated(false);
                    break;
                //Logged in by Hed Cs Admin
                case User.UserTypeEnum.HedCsAdmin:
                case User.UserTypeEnum.CsAdmin:
                case User.UserTypeEnum.DPCourseSpacePramotedAdmin:
                    //Validate Hed Cs Admin Login
                    isLoginSuccessful = this.IsCsAdminLoginValidated(false);
                    break;
                //Logged in by SMS Instructor and Student
                case User.UserTypeEnum.CsSmsInstructor:
                case User.UserTypeEnum.AmpCsSmsInstructor:
                case User.UserTypeEnum.AmpCsSmsStudent:
                case User.UserTypeEnum.CsSmsStudent:
                case User.UserTypeEnum.HSSCsSmsInstructor:
                case User.UserTypeEnum.HSSCsSmsStudent:
                case User.UserTypeEnum.HedTeacherAssistant:
                case User.UserTypeEnum.HedCoreAcceptanceInstructor:
                case User.UserTypeEnum.HedCoreAcceptanceStudent:
                case User.UserTypeEnum.HedMilAcceptanceInstructor:
                case User.UserTypeEnum.HedMilPPEStudent:
                case User.UserTypeEnum.HedProgramAdmin:
                case User.UserTypeEnum.AmpProgramAdmin:
                case User.UserTypeEnum.HSSProgramAdmin:
                case User.UserTypeEnum.WLCsSmsInstructor:
                case User.UserTypeEnum.WLCsSmsStudent:
                case User.UserTypeEnum.MyTestSmsInstructor:
                case User.UserTypeEnum.WLProgramAdmin:
                    //Validate Hed SMS User Login    
                    isLoginSuccessful = this.IsSmsUserLoggedIn(false);
                    break;
                //Logged in by Ws Teacher and Student
                case User.UserTypeEnum.WsTeacher:
                case User.UserTypeEnum.WsStudent:
                case User.UserTypeEnum.HedWsInstructor:
                case User.UserTypeEnum.HedWsStudent:
                case User.UserTypeEnum.HEDCSCTGPPublisherAdmin:
                case User.UserTypeEnum.HEDWSCTGPublisherAdmin:
                case User.UserTypeEnum.HedMiLWsAdmin:
                    //Validate WS user Login
                    isLoginSuccessful = this.IsWsUserLoggedIn(false);
                    break;
                //Logged in by DP Cs User
                case User.UserTypeEnum.DPCsTeacher:
                case User.UserTypeEnum.DPCsStudent:
                case User.UserTypeEnum.DPCsNewTeacher:
                case User.UserTypeEnum.DPCsNewStudent:
                case User.UserTypeEnum.DPCsNewAide:
                case User.UserTypeEnum.DPCsOrganizationAdmin:
                    isLoginSuccessful = this.IsDigitalPathCsUserLoggedIn(false);
                    break;

                case User.UserTypeEnum.DPDemoUser:
                    isLoginSuccessful = this.IsDigitalPathCsDemoUserLoggedIn(false);
                    break;

                case User.UserTypeEnum.RumbaStudent:
                case User.UserTypeEnum.RumbaTeacher:
                    isLoginSuccessful = this.IsRumbaUserLoggedIn(false);
                    break;

                //Logged in by NN cs User
                case User.UserTypeEnum.NovaNETCsTeacher:
                case User.UserTypeEnum.NovaNETCsStudent:
                    isLoginSuccessful = this.IsDigitalPathCsUserLoggedIn(false);
                    break;
                //Logged in by DPCTGPPublisherAdmin
                case User.UserTypeEnum.DPCTGPPublisherAdmin:
                    isLoginSuccessful = this.IsDigitalPathCsUserLoggedIn(false);
                    break;
            }
            Logger.LogMethodExit("LoginPage", "ValidateLogin",
                base.IsTakeScreenShotDuringEntryExit);
            return isLoginSuccessful;

        }

        /// <summary>
        /// Validate Hed SMS User Login.
        /// </summary>
        /// <param name="isLoginSuccessful">This is Login Success Initialization value.</param>
        /// <returns>Login Success Status.</returns>
        private Boolean IsSmsUserLoggedIn(Boolean isLoginSuccessful)
        {
            //Checks After LoggedIn Window Present    
            Logger.LogMethodEntry("LoginPage", "IsSmsUserLoggedIn",
                base.IsTakeScreenShotDuringEntryExit);
            if (base.IsElementLoadedInWindow(LoginPageResource.
            Login_Page_PageTitle_Locator_GlobalHome,
                By.CssSelector("a[id$='_testLogOut']"), 600))
            {
                isLoginSuccessful = true;
            }

            Logger.LogMethodExit("LoginPage", "IsSmsUserLoggedIn",
                base.IsTakeScreenShotDuringEntryExit);
            return isLoginSuccessful;
        }

        /// <summary>
        /// Validate Hed Cs Admin Login.
        /// </summary>
        /// <param name="isLoginSuccessful">This is Login Success Initialization value.</param>
        /// <returns>Login Success Status.</returns>
        private Boolean IsCsAdminLoginValidated(Boolean isLoginSuccessful)
        {
            //Checks After LoggedIn Window Present    
            Logger.LogMethodEntry("LoginPage", "IsCsAdminLoginValidated",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for Login Window
            if (base.IsElementLoadedInWindow(LoginPageResource.
                Login_Page_PageTitle_Locator_CourseEnrollment,
                By.XPath(LoginPageResource.Login_Page_LogOut_Locator))
                || base.IsElementPresent(By.ClassName(LoginPageResource.
                Login_Page_Text_Consent_ClassName_Locator), Convert.ToInt32
                (LoginPageResource.Login_Page_Custom_TimeToWait))
                || base.IsElementLoadedInWindow(LoginPageResource
                .Login_Page_PageTitle_Locator_UpdatePearsonAccount
                , By.Id(LoginPageResource.Login_Page_NewPassword_Texbox_Locator)))
            {
                isLoginSuccessful = true;
            }
            Logger.LogMethodExit("LoginPage", "IsCsAdminLoginValidated",
                base.IsTakeScreenShotDuringEntryExit);
            return isLoginSuccessful;
        }

        /// <summary>
        /// Validate Hed Ws Admin Login.
        /// </summary>
        /// <param name="isLoginSuccessful">This is Login Success Initialization value.</param>
        /// <returns>Login Success Status.</returns>
        private Boolean IsWsAdminValidated(Boolean isLoginSuccessful)
        {
            //Checks After LoggedIn Window Present
            Logger.LogMethodEntry("LoginPage", "IsWsAdminValidated",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for Login Window
            if (base.IsElementLoadedInWindow(LoginPageResource.
                Login_Page_PageTitle_Locator_CourseEnrollment,
                By.XPath(LoginPageResource.Login_Page_LogOut_Locator))
                || base.IsElementPresent(By.ClassName(LoginPageResource.
                Login_Page_Text_Consent_ClassName_Locator), Convert.ToInt32
                (LoginPageResource.Login_Page_Custom_TimeToWait)))
            {
                isLoginSuccessful = true;
            }
            Logger.LogMethodExit("LoginPage", "IsWsAdminValidated",
                base.IsTakeScreenShotDuringEntryExit);
            return isLoginSuccessful;
        }

        /// <summary>
        /// Validate WS User Login.
        /// </summary>
        /// <param name="isLoginSuccessful">This is Login Success Initialization value.</param>
        /// <returns>Login Success Status.</returns>
        private Boolean IsWsUserLoggedIn(Boolean isLoginSuccessful)
        {
            //Checks After LoggedIn Window Present    
            Logger.LogMethodEntry("LoginPage", "IsSMSUserLoggedIn",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Login Window
            if (base.IsElementLoadedInWindow(LoginPageResource.
                Login_Page_PageTitle_Locator_GlobalHome,
                By.XPath(LoginPageResource.Login_Page_LogOut_Locator),
                Convert.ToInt32(LoginPageResource.Login_Page_Custom_TimeToWait))
                || base.IsElementPresent(By.XPath(LoginPageResource.
                Login_Page_LogOut_Locator), Convert.ToInt32(LoginPageResource.Login_Page_Custom_TimeToWait)))
            {
                isLoginSuccessful = true;
            }
            Logger.LogMethodExit("LoginPage", "IsSMSUserLoggedIn",
                base.IsTakeScreenShotDuringEntryExit);
            return isLoginSuccessful;
        }

        /// <summary>
        /// Validate Digital Path CS User Login.
        /// </summary>
        /// <param name="isLoginSuccessful">This is Login Success Initialization value.</param>
        /// <returns>Login Success Status.</returns>
        private Boolean IsDigitalPathCsUserLoggedIn(Boolean isLoginSuccessful)
        {
            //Checks After LoggedIn Window Present    
            Logger.LogMethodEntry("LoginPage", "IsDigitalPathCsUserLoggedIn",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Login Window
            if (base.IsElementLoadedInWindow(LoginPageResource.
                Login_Page_DPUser_HomePageTitle_Name,
                By.Id(LoginPageResource.Login_Page_NewPassword_Textbox_Id_Locator),
                Convert.ToInt32(LoginPageResource.Login_Page_Custom_TimeToWait)) ||
                (!base.IsElementPresent(By.Id(LoginPageResource.
                Login_Page_UserName_TextBox_Id_Locator),
                Convert.ToInt32(LoginPageResource.Login_Page_Custom_TimeToWait))))
            {
                isLoginSuccessful = true;
            }
            Logger.LogMethodExit("LoginPage", "IsDigitalPathCsUserLoggedIn",
                base.IsTakeScreenShotDuringEntryExit);
            return isLoginSuccessful;
        }

        /// <summary>
        /// Validate Digital Path CS Demo User Login.
        /// </summary>
        /// <param name="isLoginSuccessful">This is Login Success Initialization value.</param>
        /// <returns>Login Success Status.</returns>
        private Boolean IsDigitalPathCsDemoUserLoggedIn(Boolean isLoginSuccessful)
        {
            //Checks After LoggedIn Window Present    
            Logger.LogMethodEntry("LoginPage", "IsDigitalPathCsDemoUserLoggedIn",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For consent Window
                if (base.IsElementLoadedInWindow(LoginPageResource.LoginPage_Consent_Window_Title,
                    By.ClassName(LoginPageResource.Login_Page_Synapse_CSUser_SignIn_Button_Class_Locator),
                    Convert.ToInt32(LoginPageResource.Login_Page_Custom_TimeToWait)))
                {
                    isLoginSuccessful = true;
                }
                else
                {
                    isLoginSuccessful = IsDigitalPathCsUserLoggedIn(isLoginSuccessful);
                }
            }
            catch
            {  //incase demo user log-in is not a first login attempt.
                isLoginSuccessful = IsDigitalPathCsUserLoggedIn(isLoginSuccessful);
            }
            Logger.LogMethodExit("LoginPage", "IsDigitalPathCsDemoUserLoggedIn",
                base.IsTakeScreenShotDuringEntryExit);
            return isLoginSuccessful;
        }

        /// <summary>
        /// Validate Rumba Path User Login.
        /// </summary>
        /// <param name="isLoginSuccessful">This is Login Success Initialization value.</param>
        /// <returns>Login Success Status.</returns>
        private Boolean IsRumbaUserLoggedIn(Boolean isLoginSuccessful)
        {
            //Checks After LoggedIn Window Present    
            Logger.LogMethodEntry("LoginPage", "IsRumbaUserLoggedIn",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Login Window
            if (base.IsElementLoadedInWindow(LoginPageResource.Login_Page_DPUser_HomePageTitle_Name
                , By.Id(LoginPageResource.Login_Page_LicenseAgreement_CheckBox_Id_Locator),
                Convert.ToInt32(LoginPageResource.Login_Page_Custom_TimeToWait)) ||
                base.IsElementPresent(By.ClassName(LoginPageResource.
                LoginPage_Support_Link_ClassName_Locator),
                Convert.ToInt32(LoginPageResource.LoginPage_Customized_Wait_Time)) ||
                base.IsElementPresent(By.Id(LoginPageResource.
                LoginPage_SignOut_Link_ID),
                Convert.ToInt32(LoginPageResource.LoginPage_Customized_Wait_Time)))
            //Added condition for NonvaNet Student successful login
            {
                isLoginSuccessful = true;
            }
            Logger.LogMethodExit("LoginPage", "IsRumbaUserLoggedIn",
                base.IsTakeScreenShotDuringEntryExit);
            return isLoginSuccessful;
        }

        /// <summary>
        /// Login as Workspace Teacher.
        /// </summary>
        /// <param name="passwordTypeEnum">This is Password Type Enum.</param>
        /// <param name="userName">This is username.</param>
        public void LoginAsWorkspaceTeacher(BrowsePegasusUserURL.PasswordTypeEnum
            passwordTypeEnum, string userName)
        {
            //Login as Workspace Teacher
            Logger.LogMethodEntry("LoginPage", "LoginAsWorkspaceTeacher",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (passwordTypeEnum)
                {
                    case BrowsePegasusUserURL.PasswordTypeEnum.Incorrect:
                        //Login with Incorrect Password
                        this.UserLogin(userName, LoginPageResource.
                            LoginPage_IncorrectPassword_Value);
                        break;

                    case BrowsePegasusUserURL.PasswordTypeEnum.Correct:
                        //Login with Correct Password
                        this.UserLogin(userName, LoginPageResource.
                            LoginPage_CorrectPassword_Value);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("LoginPage", "LoginAsWorkspaceTeacher",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// User Login.
        /// </summary>
        /// <param name="userName">This is UserName.</param>
        /// <param name="password">This is Password.</param>
        private void UserLogin(string userName, string password)
        {
            //User Login
            Logger.LogMethodEntry("LoginPage", "UserLogin",
               base.IsTakeScreenShotDuringEntryExit);
            base.SelectWindow(LoginPageResource.
                Login_Page_Window_Name);
            base.WaitForElement(By.Id(LoginPageResource.
                 Login_Page_UserName_TextBox_Id_Locator));
            base.ClearTextById(LoginPageResource.
                 Login_Page_UserName_TextBox_Id_Locator);
            //Insert User Name in Username TextBox
            base.FillTextBoxById(LoginPageResource.
                Login_Page_UserName_TextBox_Id_Locator, userName);
            base.WaitForElement(By.Id(LoginPageResource.
                        Login_Page_Password_TextBox_Id_Locator));
            //Clear the text of text box
            base.ClearTextById(LoginPageResource.
                        Login_Page_Password_TextBox_Id_Locator);
            base.FillTextBoxById(LoginPageResource.
                         Login_Page_Password_TextBox_Id_Locator, password);
            base.SubmitButtonByClassName(LoginPageResource.
               Login_Page_Submit_Button_ClassName_Locator);
            Logger.LogMethodExit("LoginPage", "UserLogin",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check thr Url Browsed Successfully.
        /// </summary>
        /// <returns>True if Url browsed successfully else false.</returns>
        /// <remarks>Slow web page loading or page not found then this 
        /// method open the Url in the address bar and wait till specified time
        ///  to page get successfully browse.</remarks>
        public Boolean IsUrlBrowsedSuccessful()
        {
            //Start Stop Watch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Get Image Present On The Page
            String getCurrentPageTitle = base.GetPageTitle;
            if (getCurrentPageTitle.Equals(LoginPageResource.
                LoginPage_NoConnect_Window_Title) || getCurrentPageTitle.Equals
                (LoginPageResource.Login_Page_404Error_Window_Title))
            {
                while (stopWatch.Elapsed.TotalSeconds < _getWaitTimeOut)
                {
                    //Navigate Base Url
                    base.NavigateToBrowseUrl(this._baseLoginUrl);
                    getCurrentPageTitle = base.GetPageTitle;
                    if (!getCurrentPageTitle.Equals(LoginPageResource.
                        LoginPage_NoConnect_Window_Title) && !getCurrentPageTitle.Equals
                (LoginPageResource.Login_Page_404Error_Window_Title))
                    {
                        stopWatch.Stop();
                        return true;
                    }
                }
                stopWatch.Stop();
                return false;
            }
            stopWatch.Stop();
            return true;
        }

        /// <summary>
        /// Method to fetch current URL.
        /// </summary>
        /// <returns>Current Url.</returns>
        public string GetCurrentURL()
        {
            Logger.LogMethodEntry("LoginPage", "UserLogin",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            String getCurrentURL = string.Empty;
            try
            {
                //set current window URL
                getCurrentURL = base.GetCurrentUrl;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LoginPage", "UserLogin",
                base.IsTakeScreenShotDuringEntryExit);
            return getCurrentURL;
        }

        /// <summary>
        /// Method to validate Forgot Password and Registration Link present on Login page.
        /// </summary>
        /// <returns>False if default content is not present else true.</returns>
        public Boolean IsForgotPasswordAndRegistrationLinkPresntInLoginPage()
        {
            //Check if the Default Contents are Displayed In 'Login' Page
            Logger.LogMethodEntry("LoginPage",
                "IsForgotPasswordAndRegistrationLinkPresntInLoginPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            bool isDefaultContentsDisplayed = false;
            try
            {
                //Check if the 'Forgot Password' link is displayed
                bool isBackdoorForgotPasswordLinkDisplayed = base.IsElementPresent(By.Id
                    (LoginPageResource.LoginPage_Forgot_Password_Link)
                    , Convert.ToInt32(LoginPageResource.Login_Page_Custom_TimeToWait));
                //Check if the 'Registration' link is displayed
                bool isBackdoorRegistrationLinkDisplayed = base.IsElementPresent(By.Id
                    (LoginPageResource.LoginPage_Registration_Link)
                    , Convert.ToInt32(LoginPageResource.Login_Page_Custom_TimeToWait));
                isDefaultContentsDisplayed = isBackdoorForgotPasswordLinkDisplayed ||
                    isBackdoorRegistrationLinkDisplayed;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("LoginPage",
                "IsForgotPasswordAndRegistrationLinkPresntInLoginPage",
                base.IsTakeScreenShotDuringEntryExit);
            return isDefaultContentsDisplayed;
        }
    }
}


