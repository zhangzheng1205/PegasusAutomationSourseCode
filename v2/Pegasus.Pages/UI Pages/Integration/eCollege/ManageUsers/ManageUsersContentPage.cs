using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Integration.eCollege;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.eCollege.ManageUsers;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handle user managemen actions.
    /// </summary>
    public class ManageUsersContentPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger.
        /// </summary>
        private static readonly Logger Logger = Logger.
            GetInstance(typeof(ManageUsersContentPage));

        /// <summary>
        /// Create ECollege user.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        public void CreateECollegeUser(User.UserTypeEnum userTypeEnum)
        {
            //Create ECollege user
            Logger.LogMethodEntry("ManageUsersContentPage", "CreateECollegeUser",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Administrator Window
                this.SelectAdministrationPagesWindow();
                //Select Conetent frame
                this.SelectContentFrame();
                //Select ECollge user role
                this.SelectECollegeUserRole(userTypeEnum);
                String getLoginID = this.EnterECollegeUserInformation().ToString();
                this.EnterECollegeUserPersonalInformation();
                //Store User Details in Memory
                StoreUserDetailsInMemory(userTypeEnum, getLoginID, getLoginID);
                //Click on Next button
                this.ClickCreateNewUserNextButton();
                //Click on Save button
                this.ClickOnSaveButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageUsersContentPage", "CreateECollegeUser",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select Content frame.
        /// </summary>
        private void SelectContentFrame()
        {
            //Switch to Frame
            Logger.LogMethodEntry("ManageUsersContentPage", "SelectContentFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Name(ManageUsersContentPageResource.
                MangeUsersContent_Content_Frame_Name));
            //Switch To Frame
            base.SwitchToIFrame(ManageUsersContentPageResource.
                MangeUsersContent_Content_Frame_Name);
            Logger.LogMethodExit("ManageUsersContentPage", "SelectContentFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select ECollge User role.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        private void SelectECollegeUserRole(User.UserTypeEnum userTypeEnum)
        {
            //Select ECollge User role from dropdown
            Logger.LogMethodEntry("ManageUsersContentPage", "SelectECollegeUserRole",
                base.IsTakeScreenShotDuringEntryExit);
            IWebElement getManageUserDropDownProperty = base.GetWebElementPropertiesById
                    (ManageUsersContentPageResource.MangeUsersContent_DropDown_Id_Locator);
            //Click on Drop Down 
            base.ClickByJavaScriptExecutor(getManageUserDropDownProperty);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.ECollegeTeacher:
                    base.SelectDropDownValueThroughTextById(ManageUsersContentPageResource.
                        MangeUsersContent_DropDown_Id_Locator, ManageUsersContentPageResource.
                        MangeUsersContent_DropDown_TeacherTextValue);
                    break;
                case User.UserTypeEnum.ECollegeStudent:
                    base.SelectDropDownValueThroughTextById(ManageUsersContentPageResource.
                    MangeUsersContent_DropDown_Id_Locator, ManageUsersContentPageResource.
                    MangeUsersContent_DropDown_StudentTextValue);
                    break;
            }
            Logger.LogMethodExit("ManageUsersContentPage", "SelectECollegeUserRole",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter ECollege user Information.
        /// </summary>
        /// <returns>Returns The User Login Name Guid.</returns>
        private Guid EnterECollegeUserInformation()
        {
            //Enter User Information
            Logger.LogMethodEntry("ManageUsersContentPage", "EnterECollegeUserInformation",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Default Window
            this.SelectAdministrationPagesWindow();
            //Select Conetent frame
            this.SelectContentFrame();
            //Generate User Login Details Guid
            Guid userLoginInformationGuid = Guid.NewGuid();
            //Enter User Login Information
            this.EnterUserLoginInformation(userLoginInformationGuid);
            Logger.LogMethodExit("ManageUsersContentPage", "EnterECollegeUserInformation",
            base.IsTakeScreenShotDuringEntryExit);
            return userLoginInformationGuid;
        }

        /// <summary>
        /// Enter User Login Information.
        /// </summary>
        /// <param name="userLoginInformationGuid">This is user login information guid.</param>
        private void EnterUserLoginInformation(Guid userLoginInformationGuid)
        {
            //Enter Username and Password on Loginpage
            Logger.LogMethodEntry("ManageUsersContentPage","EnterUserLoginInformation",
                 base.IsTakeScreenShotDuringEntryExit);
            //Fill user Login name
            base.WaitForElement(By.Name(ManageUsersContentPageResource.
                 MangeUsersContent_LoginId_Name_Locator));
            //Enter Text In TextBox
            base.FillTextBoxByName(ManageUsersContentPageResource.
                 MangeUsersContent_LoginId_Name_Locator,
                 userLoginInformationGuid.ToString());
            //Fill Password
            base.WaitForElement(By.Name(ManageUsersContentPageResource.
                 MangeUsersContent_Password_Name_Text_Locator));
            //Enter Text In TextBox
            base.GetWebElementPropertiesByName(ManageUsersContentPageResource.
                 MangeUsersContent_Password_Name_Text_Locator).
                 SendKeys(userLoginInformationGuid.ToString());
            //Fill Confirm Password
            base.WaitForElement(By.Name(ManageUsersContentPageResource.
                 MangeUsersContent_ConfirmPassword_Name_TextLocator));
            //Enter Text In TextBox
            base.GetWebElementPropertiesByName(ManageUsersContentPageResource.
                  MangeUsersContent_ConfirmPassword_Name_TextLocator).
                 SendKeys(userLoginInformationGuid.ToString());
            Logger.LogMethodExit("ManageUsersContentPage","EnterUserLoginInformation",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter ECollege User personal information.
        /// </summary>
        /// <returns></returns>
        private Guid EnterECollegeUserPersonalInformation()
        {
            //Enter ECollege Personal information
            Logger.LogMethodEntry("ManageUsersContentPage",
                "EnterECollegeUserPersonalInformation",
                 base.IsTakeScreenShotDuringEntryExit);
            //Generate Full name guid
            Guid userFullName = Guid.NewGuid();
            this.EnterUserFirstName(userFullName.ToString());
            this.EnterUserLastName(userFullName.ToString());
            this.EnterUserEMailAddress();
            Logger.LogMethodExit("ManageUsersContentPage",
                "EnterECollegeUserPersonalInformation"
                  , base.IsTakeScreenShotDuringEntryExit);
            return userFullName;
        }

        /// <summary>
        /// Click on Next Button.
        /// </summary>
        private void ClickCreateNewUserNextButton()
        {
            //Click To Next Button
            Logger.LogMethodEntry("ManageUsersContentPage",
                "ClickCreateNewUserNextButton"
                   , base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ManageUsersContentPageResource.
                MangeUsersContent_NextButton_Id_Locator));
            IWebElement nextButton = base.GetWebElementPropertiesById(
                ManageUsersContentPageResource.
                MangeUsersContent_NextButton_Id_Locator);
            base.ClickByJavaScriptExecutor(nextButton);
            Logger.LogMethodExit("ManageUsersContentPage",
                "ClickCreateNewUserNextButton"
                   , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Email Id.
        /// </summary>
        private void EnterUserEMailAddress()
        {
            //Enter Email ID
            Logger.LogMethodEntry("ManageUsersContentPage", "EnterUserEMailAddress"
                   , base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Name(ManageUsersContentPageResource.
                MangeUsersContent_EmailId_Name_TextLocator));
            base.FillTextBoxByName(ManageUsersContentPageResource.
                MangeUsersContent_EmailId_Name_TextLocator,
                ManageUsersContentPageResource.MangeUsersContent_EmailIdOfUser_Value);
            Logger.LogMethodExit("ManageUsersContentPage", "EnterUserEMailAddress"
                   , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter User Last Name.
        /// </summary>
        /// <param name="userLastName">This is User Last Name.</param>
        private void EnterUserLastName(String userLastName)
        {
            //Enter user Last Name
            Logger.LogMethodEntry("ManageUsersContentPage", "EnterUserLastName"
                   , base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Name(ManageUsersContentPageResource.
                MangeUsersContent_LastName_Name_TextLocator));
            base.GetWebElementPropertiesByName(ManageUsersContentPageResource.
                MangeUsersContent_LastName_Name_TextLocator).Clear();
            base.GetWebElementPropertiesByName(ManageUsersContentPageResource.
                MangeUsersContent_LastName_Name_TextLocator).SendKeys(userLastName);
            Logger.LogMethodExit("ManageUsersContentPage", "EnterUserLastName"
                   , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter user First name.
        /// </summary>
        /// <param name="userFirstName">This is User First Name.</param>
        private void EnterUserFirstName(String userFirstName)
        {
            //Enter First Name
            Logger.LogMethodEntry("ManageUsersContentPage", "EnterUserFirstName"
                   , base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Name(ManageUsersContentPageResource.
                MangeUsersContent_FirstName_Name_TextLocator));
            base.GetWebElementPropertiesByName(ManageUsersContentPageResource.
                MangeUsersContent_FirstName_Name_TextLocator).Clear();
            base.GetWebElementPropertiesByName(ManageUsersContentPageResource.
                MangeUsersContent_FirstName_Name_TextLocator).SendKeys(userFirstName);
            Logger.LogMethodExit("ManageUsersContentPage", "EnterUserFirstName"
                   , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on User Save Button.
        /// </summary>
        private void ClickOnSaveButton()
        {
            //Click on Save button
            Logger.LogMethodEntry("ManageUsersContentPage",
                "ClickOnSaveButton",
                base.IsTakeScreenShotDuringEntryExit);
            this.SelectAdministrationPagesWindow();
            base.SwitchToIFrame(ManageUsersContentPageResource.
                MangeUsersContent_Content_Frame_Name);
            base.WaitForElement(By.Name(ManageUsersContentPageResource.
                MangeUsersContent_SaveButton_Name_Locator));
            //Get property of save button
            IWebElement saveButton = base.GetWebElementPropertiesByName
                (ManageUsersContentPageResource.
                MangeUsersContent_SaveButton_Name_Locator);
            //Click on Save button
            base.ClickByJavaScriptExecutor(saveButton);
            Logger.LogMethodExit("ManageUsersContentPage",
                "ClickOnSaveButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save the User Details in Memory.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        /// <param name="userLoginName">This is user login name.</param>
        /// <param name="userPassword">This is user password.</param>
        private void StoreUserDetailsInMemory(User.UserTypeEnum userTypeEnum,
           String userLoginName, String userPassword)
        {
            //Save user in Memory
            Logger.LogMethodEntry("ManageUsersContentPage",
                "StoreUserDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            //Save User Properties in Memory
            User newUser = new User
            {
                Name = userLoginName,
                Password = userPassword,
                UserType = userTypeEnum,
                IsCreated = true,
            };
            //Save The User in Memory
            newUser.StoreUserInMemory();
            Logger.LogMethodExit("ManageUsersContentPage",
                "StoreUserDetailsInMemory",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Administration Pages Window.
        /// </summary>
        private void SelectAdministrationPagesWindow()
        {
            //Select Window
            Logger.LogMethodEntry("ManageUsersContentPage",
             "SelectAdministrationPagesWindow",
             base.IsTakeScreenShotDuringEntryExit);
            //Wait For Window Gets Load
            base.WaitUntilWindowLoads(ManageUsersContentPageResource.
                ManageUsersContent_Page_AdministrationPages_Window_Title);
            //Select Administration Pages
            base.SelectWindow(ManageUsersContentPageResource.
                ManageUsersContent_Page_AdministrationPages_Window_Title);
            Logger.LogMethodEntry("ManageUsersContentPage",
             "SelectAdministrationPagesWindow",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search ECollege User.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        public void SearchECollegeUsers(User.UserTypeEnum userTypeEnum)
        {
            //Search Users
            Logger.LogMethodEntry("ManageUsersContentPage",
             "SearchECollegeUsers",
             base.IsTakeScreenShotDuringEntryExit);
            //Select Administration Pages Window
            this.SelectAdministrationPagesWindow();
            //Select Content Frame
            this.SelectContentFrame();
            //Wait for Login ID element
            base.WaitForElement(By.Name(ManageUsersContentPageResource.
                MangeUsersContent_Page_EnrollUser_LoginID_Name_Locator));
            //Get the User From Memory
            User user = User.Get(userTypeEnum);
            //Enter UserName into LoginID
            base.FillTextBoxByName(ManageUsersContentPageResource.
               MangeUsersContent_Page_EnrollUser_LoginID_Name_Locator, user.Name);
            // Wait for Next button on Enroll User page
            base.WaitForElement(By.Name(ManageUsersContentPageResource.
                MangeUsersContent_Page_EnrollUser_NextButton_Name_Locator));
            // Get property of Next button
            IWebElement nextButtonElement = base.GetWebElementPropertiesByName(
                ManageUsersContentPageResource.
                MangeUsersContent_Page_EnrollUser_NextButton_Name_Locator);
            base.ClickByJavaScriptExecutor(nextButtonElement);
            Logger.LogMethodExit("ManageUsersContentPage",
             "SearchECollegeUsers",
             base.IsTakeScreenShotDuringEntryExit);
            
        }
    }
}
