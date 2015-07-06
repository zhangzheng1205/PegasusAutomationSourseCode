using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.User;
using System.Configuration;
using System.Threading;
using System.IO;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{
    public class UpdateUserPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(AddUserPage));


        /// <summary>
        /// Update user details
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type.</param>
        public void UpdateUser(User.UserTypeEnum userTypeEnum)
        {
            // Create New User
            logger.LogMethodEntry("AddUserPage", "UpdateUser"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Creating the Cs User by UserType                
                Guid userInformation = this.UpdateCsUser(userTypeEnum);
                //Stores User Details in Memory
                new AddUserPage().StoreUserDetails(userTypeEnum, userInformation);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddUserPage", "UpdateUser"
                , base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Create New User in Coursespace.
        /// </summary>
        /// <param name="userTypeEnum">This Is User Type Enum.</param>
        /// <returns>User Name.</returns>
        private Guid UpdateCsUser(User.UserTypeEnum userTypeEnum)
        {
            // CreateNewUser for CS user creation
            logger.LogMethodEntry("UpdateUserPage", "CreateCsUser"
                , base.IsTakeScreenShotDuringEntryExit);
            //Select Add User Window
            this.SelectUpdateUserWindow();
            // Generate User Login Details Guid
            Guid userInformation = Guid.NewGuid();
            // Enter First name and last name 
            EnterCsUserDetails(userInformation.ToString(), userInformation.ToString());
            //Fill Username
            base.ClearTextById(AddUserPageResource.AddUser_Page_LoginNameTextBox_Id_Locator);
            base.FillEmptyTextById(AddUserPageResource.AddUser_Page_LoginNameTextBox_Id_Locator);
            base.FillTextBoxById(AddUserPageResource
                .AddUser_Page_LoginNameTextBox_Id_Locator, userInformation.ToString());
            //Fill Password  
            base.ClickLinkById(UpdateUserPageResource.UpdateUser_ResetPassword_ID);
            this.SelectResetPasswordPopup();
            base.FillTextBoxById("TxtPassword", UpdateUserPageResource.
                UpdateUser_Page_PasswordTextbox_Value);
            base.FillTextBoxById("TxtReTypePassword", UpdateUserPageResource.
                UpdateUser_Page_PasswordTextbox_Value);
            this.ClickOnSaveAndFinishButtonInResetPasswordPopup();
            base.SwitchToLastOpenedWindow();
            this.SelectUpdateUserWindow();
            this.ClickOnSaveAndFinishButtonInAddUserPage();
            logger.LogMethodExit("UpdateUserPage", "CreateCsUser",
                base.IsTakeScreenShotDuringEntryExit);
            return userInformation;
        }

        /// <summary>
        /// Select Add User Window.
        /// </summary>
        private void SelectUpdateUserWindow()
        {
            //Select Add User Window
            logger.LogMethodEntry("UpdateUserPage", "SelectUpdateUserWindow"
                , base.IsTakeScreenShotDuringEntryExit);
            //Select the Add User window
            base.WaitUntilWindowLoads(UpdateUserPageResource.UpdateUser_Page_PopUpName);
            base.SelectWindow(UpdateUserPageResource.UpdateUser_Page_PopUpName);
            logger.LogMethodExit("UpdateUserPage", "SelectUpdateUserWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select Reset Password popup.
        /// </summary>
        private void SelectResetPasswordPopup()
        {
            //Select Add User Window
            logger.LogMethodEntry("UpdateUserPage", "SelectResetPasswordPopup"
                , base.IsTakeScreenShotDuringEntryExit);
            //Select the Add User window
            base.SwitchToDefaultWindow();
            base.WaitUntilPopUpLoads(UpdateUserPageResource.UpdateUser_ResetPassword_PopUpName);
            base.SelectWindow(UpdateUserPageResource.UpdateUser_ResetPassword_PopUpName);
            logger.LogMethodExit("UpdateUserPage", "SelectResetPasswordPopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter User Details in Update User pop up.
        /// </summary>
        /// <param name="firstName">This is First Name.</param>
        /// <param name="lastName">This Is Last Name.</param>
        private void EnterCsUserDetails(string firstName, string lastName)
        {
            //Enter WS User Details in create new user pop up
            logger.LogMethodEntry("UpdateUserPage", "EnterCsUserDetails"
                , base.IsTakeScreenShotDuringEntryExit);
            // Enter FirstName                  
            base.WaitForElement(By.Id(AddUserPageResource
                .AddUser_Page_FirstNameTextBox_Id_Locator));
            base.ClearTextById(AddUserPageResource.AddUser_Page_FirstNameTextBox_Id_Locator);
            base.FillEmptyTextById(AddUserPageResource.AddUser_Page_FirstNameTextBox_Id_Locator);
            base.FillTextBoxById(AddUserPageResource
                .AddUser_Page_FirstNameTextBox_Id_Locator, firstName);
            //Enter LastName
            base.WaitForElement(By.Id(AddUserPageResource
                .AddUser_Page_LastNameTextBox_Id_Locator));
            base.ClearTextById(AddUserPageResource
                .AddUser_Page_LastNameTextBox_Id_Locator);
            base.FillEmptyTextById(AddUserPageResource.AddUser_Page_LastNameTextBox_Id_Locator);
            base.FillTextBoxById(AddUserPageResource
                .AddUser_Page_LastNameTextBox_Id_Locator, lastName);
            //Enter Email
            base.WaitForElement(By.Id(AddUserPageResource
                .AddUser_Page_EmailTextBox_Id_Locator));
            base.ClearTextById(AddUserPageResource
                .AddUser_Page_EmailTextBox_Id_Locator);
            base.FillEmptyTextById(UpdateUserPageResource.UpdateUser_Page_EmailTextBox_Id_Locator);
            base.FillTextBoxById(UpdateUserPageResource.UpdateUser_Page_EmailTextBox_Id_Locator,
                UpdateUserPageResource.UpdateUser_Page_EmailTextbox_Value);
            logger.LogMethodExit("UpdateUserPage", "EnterCsUserDetails"
                , base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click On Save and Finish Button in Reset password popup
        /// </summary>
        private void ClickOnSaveAndFinishButtonInResetPasswordPopup()
        {
            //Click on the Save and Finish button
            logger.LogMethodEntry("UpdateUserPage", "ClickOnSaveAndFinishButtonInResetPasswordPopup",
                base.IsTakeScreenShotDuringEntryExit);
            //Click Save and Finish Button
            base.WaitForElement(By.Id(UpdateUserPageResource.UpdateUser_Page_ResetPassword_SaveButton_Id_Locator));
            IWebElement getSaveButton = base.GetWebElementPropertiesById
                (UpdateUserPageResource.UpdateUser_Page_ResetPassword_SaveButton_Id_Locator);
            //Click on Save button
            base.ClickByJavaScriptExecutor(getSaveButton);
            //Wait for 4 secs
            Thread.Sleep(Convert.ToInt32(AddUserPageResource.AddUser_Page_SleepTime));
            logger.LogMethodExit("UpdateUserPage", "ClickOnSaveAndFinishButtonInResetPasswordPopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save and Finish Button in Add User Page
        /// </summary>
        private void ClickOnSaveAndFinishButtonInAddUserPage()
        {
            //Click on the Save and Finish button
            logger.LogMethodEntry("AddUserPage", "ClickOnSaveAndFinishButtonInAddUserPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Click Save and Finish Button
            base.WaitForElement(By.Id(AddUserPageResource.AddUser_Page_SaveButton_Id_Locator));
            IWebElement getSaveButton = base.GetWebElementPropertiesById
                (AddUserPageResource.AddUser_Page_SaveButton_Id_Locator);
            //Click on Save button
            base.ClickByJavaScriptExecutor(getSaveButton);
            //Wait for 4 secs
            Thread.Sleep(Convert.ToInt32(AddUserPageResource.AddUser_Page_SleepTime));
            logger.LogMethodExit("AddUserPage", "ClickOnSaveAndFinishButtonInAddUserPage",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}