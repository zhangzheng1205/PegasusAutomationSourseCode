using System;
using System.Globalization;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.User_Creation;
using Pegasus.Pages.Exceptions;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus new user creation actions.
    /// </summary>
    public class NewUserPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(NewUserPage));

        /// <summary>
        /// Create User(s) In WorkSpace.
        /// </summary>
        /// <param name="userTypeEnum">This is user by type.</param>
        public void CreateNewUserInWorkSpace(User.UserTypeEnum userTypeEnum)
        {
            // Create New User(s) In WorkSpace
            logger.LogMethodEntry("NewUserPage", "CreateNewUserInWorkSpace"
                , base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Creating WS User
                SelectCreateNewUserWindow();
                String userLoginName = EnterWorkSpaceUserLoginInformation().ToString();
                // Enter User Details - First name last name 
                String userFullName = EnterWorkSpaceUserPersonalInformation().ToString();
                //Store User Details in Memory
                StoreUserDetailsInMemory(userTypeEnum, userLoginName, NewUserPageResource.
                    NewUser_Page_PasswordOfUser_Value, userFullName, userFullName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("NewUserPage", "CreateNewUserInWorkSpace"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create new User Window.
        /// </summary>
        private void SelectCreateNewUserWindow()
        {
            //Select Window
            logger.LogMethodEntry("NewUserPage", "SelectCreateNewUserWindow"
               , base.isTakeScreenShotDuringEntryExit);
            //Wait For Window Load
            base.WaitUntilWindowLoads(NewUserPageResource.NewUser_Page_PopUpName);
            //Select Window
            base.SelectWindow(NewUserPageResource.NewUser_Page_PopUpName);
            logger.LogMethodExit("NewUserPage", "SelectCreateNewUserWindow"
           , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter work Space User Login Information.
        /// </summary>
        /// <returns>User Login Name.</returns>
        private Guid EnterWorkSpaceUserLoginInformation()
        {
            logger.LogMethodEntry("NewUserPage", "EnterWorkSpaceUserLoginInformation"
           , base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(NewUserPageResource
                                          .NewUser_Page_LoginNameTextBox_Id_Locator));
            base.GetWebElementPropertiesById(NewUserPageResource
                                                 .NewUser_Page_LoginNameTextBox_Id_Locator).Clear();
            // Generate User Login Details Guid
            Guid userLoginName = Guid.NewGuid();
            //Fill LoginName
            base.GetWebElementPropertiesById(NewUserPageResource
                                                 .NewUser_Page_LoginNameTextBox_Id_Locator).
                 SendKeys(userLoginName.ToString());
            //Fill Password
            base.WaitForElement(By.Id(NewUserPageResource
                                          .NewUser_Page_PasswordTextBox_Id_Locator));
            base.GetWebElementPropertiesById(NewUserPageResource
                                                 .NewUser_Page_PasswordTextBox_Id_Locator).Clear();
            base.GetWebElementPropertiesById(NewUserPageResource
                                                 .NewUser_Page_PasswordTextBox_Id_Locator).SendKeys
                (NewUserPageResource.NewUser_Page_PasswordOfUser_Value);
            logger.LogMethodExit("NewUserPage", "EnterWorkSpaceUserLoginInformation"
          , base.isTakeScreenShotDuringEntryExit);
            return userLoginName;
        }

        /// <summary>
        /// Enter Work Space User Personal Information.
        /// </summary>
        private Guid EnterWorkSpaceUserPersonalInformation()
        {
            //Enter WS User Details in create new user pop up
            logger.LogMethodEntry("NewUserPage", "EnterWorkSpaceUserPersonalInformation"
                , base.isTakeScreenShotDuringEntryExit);
            // Generate User Full Name Details Guid
            Guid userFullName = Guid.NewGuid();
            EnterUserFirstName(userFullName.ToString());
            EnterUserLastName(userFullName.ToString());
            EnterUserEMailAddress();
            ClickCreateNewUserSaveButton();          
            logger.LogMethodExit("NewUserPage", "EnterWorkSpaceUserPersonalInformation"
                  , base.isTakeScreenShotDuringEntryExit);
            return userFullName;
        }

        /// <summary>
        /// Enter User EMail Address in The Text Box.
        /// </summary>
        private void EnterUserEMailAddress()
        {
            //Enter Email Address
            logger.LogMethodEntry("NewUserPage", "EnterUserEMailAddress"
               , base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewUserPageResource
                                          .NewUser_Page_EmailTextBox_Id_Locator));
            //Clear Text Box
            base.ClearTextByID(NewUserPageResource
                                                 .NewUser_Page_EmailTextBox_Id_Locator);
            //Fill Text Box Value
            base.FillTextBoxByID(NewUserPageResource.
                                                 NewUser_Page_EmailTextBox_Id_Locator,
                                                 NewUserPageResource.NewUser_Page_EmailOfUser_Value);
            logger.LogMethodExit("NewUserPage", "EnterUserEMailAddress"
                  , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter User Last Name In The Text Box.
        /// </summary>
        /// <param name="userLastName">This is user last name.</param>
        private void EnterUserLastName(string userLastName)
        {
            //Enter User LastName
            logger.LogMethodEntry("NewUserPage", "EnterUserLastName"
              , base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewUserPageResource
                                          .NewUser_Page_LastNameTextBox_Id_Locator));
            //Clear Text Box
            base.ClearTextByID(NewUserPageResource
                                                 .NewUser_Page_LastNameTextBox_Id_Locator);
            //Enter Value in Text Box
            base.FillTextBoxByID(NewUserPageResource
                                                 .NewUser_Page_LastNameTextBox_Id_Locator, userLastName);
            logger.LogMethodEntry("NewUserPage", "EnterUserLastName"
               , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter User First Name in Text Box.
        /// </summary>
        /// <param name="userFirstName">This is user first name.</param>
        private void EnterUserFirstName(string userFirstName)
        {
            // Enter FirstName                  
            logger.LogMethodEntry("NewUserPage", "EnterUserFirstName"
              , base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewUserPageResource
                                          .NewUser_Page_FirstNameTextBox_Id_Locator));
            //Clear Text Box
            base.ClearTextByID(NewUserPageResource
                                                 .NewUser_Page_FirstNameTextBox_Id_Locator);
            //Enter Value n Text Box
            base.FillTextBoxByID(NewUserPageResource
                                                   .NewUser_Page_FirstNameTextBox_Id_Locator, userFirstName);
            logger.LogMethodEntry("NewUserPage", "EnterUserFirstName"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Create New User Save Button.
        /// </summary>
        private void ClickCreateNewUserSaveButton()
        {
            //Click To Save Button
            logger.LogMethodEntry("NewUserPage", "ClickCreateNewUserSaveButton",
           base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewUserPageResource
                                          .NewUser_Page_SaveButton_Id_Locator));
            IWebElement getSaveButton = base.GetWebElementPropertiesById
                (NewUserPageResource.NewUser_Page_SaveButton_Id_Locator);
            //Click on button
            base.ClickByJavaScriptExecutor(getSaveButton);      
            logger.LogMethodExit("NewUserPage", "ClickCreateNewUserSaveButton",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save the User Details in Memory.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum,</param>
        /// <param name="userLoginName">This is user login name.</param>
        /// <param name="userPassword">This is user password.</param>
        /// <param name="userFirstName">This is user first name.</param>
        /// <param name="userLastName">This is last name.</param>
        private void StoreUserDetailsInMemory(User.UserTypeEnum userTypeEnum,
            string userLoginName, string userPassword, string userFirstName, string userLastName)
        {
            //Save user in Memory
            logger.LogMethodEntry("NewUserPage", "StoreUserDetailsInMemory",
                base.isTakeScreenShotDuringEntryExit);
            //Save User Properties in Memory
            User newUser = new User
            {
                Name = userLoginName,
                Password = userPassword,
                LastName = userLastName,
                FirstName = userFirstName,
                UserType = userTypeEnum,
                IsCreated = true,
            };
            //Save The User in Memory
            newUser.StoreUserInMemory();
            logger.LogMethodExit("NewUserPage", "StoreUserDetailsInMemory",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit the WorkSpace User Details.
        /// </summary>
        public void EditWorkSpaceUserDetails()
        {
            //Edit User Details
            logger.LogMethodEntry("NewUserPage", "EditWorkSpaceUserDetails",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectUpdateUserWindow();
                //Click Reset Password Link
                this.ClickResetPasswordLink();
                //Enter New Password 
                this.ResetUserPasswordDetails();
                //Click on Save and Close Button
                this.ClickEditUserSaveAndCloseButton();               
                //Verify is Reset Window Pop Closed
                base.IsPopUpClosed(3);
                //Select Update user window
                base.SelectWindow(NewUserPageResource.
                                  NewUser_Page_Updateuser_Window_Name);
                //Enter User Information
                this.EnterWorkSpaceUserPersonalInformation();                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("NewUserPage", "EditWorkSpaceUserDetails",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Reset Password Link.
        /// </summary>
        private void ClickResetPasswordLink()
        {
            //Click on Link
            logger.LogMethodEntry("NewUserPage", "ClickResetPasswordLink",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(NewUserPageResource.
                                                       NewUser_Page_ResetPassword_Link_Locator));
            //Get Reset Password Button 
            IWebElement getButtonProperty = base.
                GetWebElementPropertiesByPartialLinkText(NewUserPageResource.
                                                             NewUser_Page_ResetPassword_Link_Locator);
            base.ClickByJavaScriptExecutor(getButtonProperty);
            logger.LogMethodExit("NewUserPage", "ClickResetPasswordLink",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Update User Window.
        /// </summary>
        private void SelectUpdateUserWindow()
        {
            //Select Window
            logger.LogMethodEntry("NewUserPage", "SelectUpdateUserWindow",
               base.isTakeScreenShotDuringEntryExit);
            //Wait For Window Loads
            base.WaitUntilWindowLoads(NewUserPageResource.
                                  NewUser_Page_Updateuser_Window_Name);
            //Select Update User Window
            base.SelectWindow(NewUserPageResource.
                                  NewUser_Page_Updateuser_Window_Name);
            logger.LogMethodEntry("NewUserPage", "SelectUpdateUserWindow",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Reset User Password. 
        /// </summary>
        private void ResetUserPasswordDetails()
        {
            //Enter Password
            logger.LogMethodEntry("NewUserPage", "ResetUserPasswordDetails",
              base.isTakeScreenShotDuringEntryExit);
            //Select Reset Password Window
            base.SelectWindow(NewUserPageResource.
                NewUser_Page_ResetPassword_Link_Locator);
            base.WaitForElement(By.Id(NewUserPageResource.
                NewUser_Page_TxtPasswordTextBox_Id_Locator));
            base.GetWebElementPropertiesById(NewUserPageResource.
                NewUser_Page_TxtPasswordTextBox_Id_Locator).Clear();
            //Fill Password
            base.GetWebElementPropertiesById(NewUserPageResource.
                NewUser_Page_TxtPasswordTextBox_Id_Locator).
                SendKeys(NewUserPageResource.NewUser_Page_EditPassword_Value);
            base.WaitForElement(By.Id(NewUserPageResource.
                NewUser_Page_TxtReTypePassword_Id_Locator));
            //Clear the Retype Password Text Box
            base.GetWebElementPropertiesById(NewUserPageResource.
                NewUser_Page_TxtReTypePassword_Id_Locator).Clear();
            //Fill Password in Retype Password Textbox
            base.GetWebElementPropertiesById(NewUserPageResource.
                NewUser_Page_TxtReTypePassword_Id_Locator).
                SendKeys(NewUserPageResource.NewUser_Page_EditPassword_Value);           
            logger.LogMethodExit("NewUserPage", "ResetUserPasswordDetails",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Edit User Save and Close Button.
        /// </summary>
        private void ClickEditUserSaveAndCloseButton()
        {
            //Click Save and Close Button
            logger.LogMethodEntry("NewUserPage", "ClickEditUserSaveAndCloseButton",
               base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(NewUserPageResource.
                                          NewUser_Page_SaveAndClose_Id_Locator));
            //Click on Button
            base.ClickButtonByID(NewUserPageResource.
                                                 NewUser_Page_SaveAndClose_Id_Locator);
            logger.LogMethodExit("NewUserPage", "ClickEditUserSaveAndCloseButton",
                 base.isTakeScreenShotDuringEntryExit);
        }
    }
}
