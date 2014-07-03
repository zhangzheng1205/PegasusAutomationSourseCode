using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.User;
using System.Configuration;
using System.Threading;
using System.IO;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains details of User Creation
    /// </summary>
    public class AddUserPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(AddUserPage));

        /// <summary>
        /// User Creation in Coursespace.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type.</param>
        public void CreateNewUser(User.UserTypeEnum userTypeEnum)
        {
            // Create New User
            logger.LogMethodEntry("AddUserPage", "CreateNewUser"
                , base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Creating the Cs User by UserType                
                Guid userInformation = this.CreateCsUser(userTypeEnum);
                //Stores User Details in Memory
                this.StoreUserDetails(userTypeEnum, userInformation);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddUserPage", "CreateNewUser"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create New User in Coursespace.
        /// </summary>
        /// <param name="userTypeEnum">This Is User Type Enum.</param>
        /// <returns>User Name.</returns>
        private Guid CreateCsUser(User.UserTypeEnum userTypeEnum)
        {
            // CreateNewUser for CS user creation
            logger.LogMethodEntry("AddUserPage", "CreateCsUser"
                , base.isTakeScreenShotDuringEntryExit);
            //Select Add User Window
            this.SelectAddUserWindow();
            // Generate User Login Details Guid
            Guid userInformation = Guid.NewGuid();
            // Enter First name and last name 
            EnterCsUserDetails(userInformation.ToString(), userInformation.ToString());
            //Fill Username
            base.FillEmptyTextByID(AddUserPageResource.AddUser_Page_LoginNameTextBox_Id_Locator);
            base.FillTextBoxByID(AddUserPageResource
                .AddUser_Page_LoginNameTextBox_Id_Locator, userInformation.ToString());
            this.AssociateProgram(userTypeEnum);
            //Fill Password            
            base.FillTextBoxByID(AddUserPageResource
                .AddUser_Page_PasswordTextBox_Id_Locator, AddUserPageResource.
                AddUser_Page_PasswordTextbox_Value);
            this.ClickOnSaveAndFinishButtonInAddUserPage();
            logger.LogMethodExit("AddUserPage", "CreateCsUser",
                base.isTakeScreenShotDuringEntryExit);
            return userInformation;
        }

        /// <summary>
        /// Stores User Details in Memory.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type.</param>
        /// <param name="userInformation">This is User Information Guid.</param>        
        private void StoreUserDetails(User.UserTypeEnum userTypeEnum, Guid userInformation)
        {
            //Stores User Details in Memory
            logger.LogMethodEntry("AddUserPage", "StoreUserDetails"
                , base.isTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.DPCsTeacher:
                case User.UserTypeEnum.DPCsStudent:
                case User.UserTypeEnum.DPCsAide:
                case User.UserTypeEnum.DPCsOrganizationAdmin:
                case User.UserTypeEnum.NovaNETCsTeacher:
                case User.UserTypeEnum.NovaNETCsStudent:
                case User.UserTypeEnum.NovaNETCsAide:
                case User.UserTypeEnum.NovaNETCsOrganizationAdmin:
                    //Wait to Pop Up Get Close Successfully
                    if (base.IsPopUpClosed(3))
                    {
                        //Store User Details in Memory
                        this.StoreUserDetailsInMemory(userTypeEnum, userInformation, AddUserPageResource.
                            AddUser_Page_PasswordTextbox_Value, userInformation.ToString(),
                            userInformation.ToString());
                    }
                    //Select Manage Organization window
                    new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
                    break;
                //Storing the user for Manage roster
                case User.UserTypeEnum.DPCsTeacherManageRoster:
                case User.UserTypeEnum.DPCsStudentManageRoster:
                case User.UserTypeEnum.DPCsAideManageRoster:
                    //Wait to Pop Up Get Close Successfully
                    if (base.IsPopUpClosed(4))
                    {
                        //Store User Details in Memory
                        this.StoreUserDetailsInMemory(userTypeEnum, userInformation, AddUserPageResource.
                            AddUser_Page_PasswordTextbox_Value, userInformation.ToString(),
                            userInformation.ToString());
                    }
                    //Select Manage Organization window
                    new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
                    break;
                case User.UserTypeEnum.NovaNETCsClassStudent:
                    //Wait to Pop Up Get Close Successfully
                    if (base.IsPopUpClosed(2))
                    {
                        //Store User Details in Memory
                        this.StoreUserDetailsInMemory(userTypeEnum, userInformation, AddUserPageResource.
                            AddUser_Page_PasswordTextbox_Value, userInformation.ToString(),
                            userInformation.ToString());
                    }
                    //Select Roster window
                    new GBRoasterDefaultUXPage().SelectRosterWindow();
                    break;
            }
            logger.LogMethodExit("AddUserPage", "StoreUserDetails"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Associates Program for Administrator.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        private void AssociateProgram(User.UserTypeEnum userTypeEnum)
        {
            //Associates Program for Administrator
            logger.LogMethodEntry("AddUserPage", "AssociateProgram",
                base.isTakeScreenShotDuringEntryExit);
            //Associate Program
            if (userTypeEnum.ToString() == AddUserPageResource.
                AddUser_Page_Administrator_Enum_Value)
            {
                base.ClickButtonByID(AddUserPageResource.
                    AddUser_Page_Button_ManageAssociations_Id_Locator);
                //Select the Program                
                base.SwitchToIFrameByWebElement(base.GetWebElementPropertiesByClassName(AddUserPageResource.
                    AddUser_Page_Programs_Iframe_ClassName_Locator));
                if (base.IsElementPresent(By.XPath(AddUserPageResource.
                    AddUser_Page_Program_Checkbox_Xpath_Locator), Convert.ToInt32
                    (AddUserPageResource.AddUser_Page_Customized_Wait_Time)) &&
                    (!base.IsElementSelected(By.XPath(AddUserPageResource.
                    AddUser_Page_Program_Checkbox_Xpath_Locator))))
                {
                    base.SelectCheckBoxByXPath(AddUserPageResource.
                    AddUser_Page_Program_Checkbox_Xpath_Locator);
                }
                //Click on the Save button
                base.ClickButtonByID(AddUserPageResource.
                    AddUser_Page_Button_Save_Program_Id_Locator);
                //Select Add User Window
                this.SelectAddUserWindow();
            }
            logger.LogMethodExit("AddUserPage", "AssociateProgram",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Add User Window.
        /// </summary>
        private void SelectAddUserWindow()
        {
            //Select Add User Window
            logger.LogMethodEntry("AddUserPage", "SelectAddUserWindow"
                , base.isTakeScreenShotDuringEntryExit);
            //Select the Add User window
            base.WaitUntilWindowLoads(AddUserPageResource.AddUser_Page_PopUpName);
            base.SelectWindow(AddUserPageResource.AddUser_Page_PopUpName);
            logger.LogMethodExit("AddUserPage", "SelectAddUserWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter User Details in Add User pop up.
        /// </summary>
        /// <param name="firstName">This is First Name.</param>
        /// <param name="lastName">This Is Last Name.</param>
        private void EnterCsUserDetails(string firstName, string lastName)
        {
            //Enter WS User Details in create new user pop up
            logger.LogMethodEntry("AddUserPage", "EnterCsUserDetails"
                , base.isTakeScreenShotDuringEntryExit);
            // Enter FirstName                  
            base.WaitForElement(By.Id(AddUserPageResource
                .AddUser_Page_FirstNameTextBox_Id_Locator));
            base.FillEmptyTextByID(AddUserPageResource.AddUser_Page_FirstNameTextBox_Id_Locator);
            base.FillTextBoxByID(AddUserPageResource
                .AddUser_Page_FirstNameTextBox_Id_Locator, firstName);
            //Enter LastName
            base.WaitForElement(By.Id(AddUserPageResource
                .AddUser_Page_LastNameTextBox_Id_Locator));
            base.FillEmptyTextByID(AddUserPageResource.AddUser_Page_LastNameTextBox_Id_Locator);
            base.FillTextBoxByID(AddUserPageResource
                .AddUser_Page_LastNameTextBox_Id_Locator, lastName);
            //Enter Email
            base.WaitForElement(By.Id(AddUserPageResource
                .AddUser_Page_EmailTextBox_Id_Locator));
            base.FillEmptyTextByID(AddUserPageResource.AddUser_Page_EmailTextBox_Id_Locator);
            base.FillTextBoxByID(AddUserPageResource.AddUser_Page_EmailTextBox_Id_Locator,
                AddUserPageResource.AddUser_Page_EmailTextbox_Value);
            logger.LogMethodExit("AddUserPage", "EnterCsUserDetails"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save and Finish Button in Add User Page
        /// </summary>
        private void ClickOnSaveAndFinishButtonInAddUserPage()
        {
            //Click on the Save and Finish button
            logger.LogMethodEntry("AddUserPage", "ClickOnSaveAndFinishButtonInAddUserPage",
                base.isTakeScreenShotDuringEntryExit);
            //Click Save and Finish Button
            base.WaitForElement(By.Id(AddUserPageResource.AddUser_Page_SaveButton_Id_Locator));
            IWebElement getSaveButton = base.GetWebElementPropertiesById
                (AddUserPageResource.AddUser_Page_SaveButton_Id_Locator);
            //Click on Save button
            base.ClickByJavaScriptExecutor(getSaveButton);
            //Wait for 4 secs
            Thread.Sleep(Convert.ToInt32(AddUserPageResource.AddUser_Page_SleepTime));
            logger.LogMethodExit("AddUserPage", "ClickOnSaveAndFinishButtonInAddUserPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Saving the User Details in Memory
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        /// <param name="userName">This is Username guid</param>
        /// <param name="userPassword">This is Password</param>
        /// <param name="firstName">This Is First Name</param>
        /// <param name="lastName">This Is Last Name</param>
        private void StoreUserDetailsInMemory(User.UserTypeEnum userTypeEnum,
            Guid userName, string userPassword, string firstName, string lastName)
        {
            //Save user in Memory
            logger.LogMethodEntry("AddUserPage", "StoreUserDetailsInMemory",
                base.isTakeScreenShotDuringEntryExit);
            //Save User Properties in Memory
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.DPCsOrganizationAdmin:
                case User.UserTypeEnum.NovaNETCsTeacher:
                case User.UserTypeEnum.NovaNETCsStudent:
                case User.UserTypeEnum.NovaNETCsAide:
                case User.UserTypeEnum.NovaNETCsOrganizationAdmin:
                case User.UserTypeEnum.NovaNETCsClassStudent:
                case User.UserTypeEnum.DPCsAide:
                case User.UserTypeEnum.DPCsTeacher:
                case User.UserTypeEnum.DPCsStudent:
                    {
                        //Save Student Details
                        this.SaveUserInMemory
                            (userTypeEnum, userName, userPassword, firstName, lastName);
                    }
                    break;
            }
            logger.LogMethodExit("AddUserPage", "StoreUserDetailsInMemory",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save User In Memory
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        /// <param name="userName">This is UserName Guid</param>
        /// <param name="userPassword">This is Password</param>
        /// <param name="firstName">This is First Name</param>
        /// <param name="lastName">This is Last Name</param> 
        private void SaveUserInMemory(User.UserTypeEnum userTypeEnum, Guid userName,
            string userPassword, string firstName, string lastName)
        {
            //Save The User In Memory
            logger.LogMethodEntry("AddUserPage", "SaveUserInMemory",
              base.isTakeScreenShotDuringEntryExit);
            User newUser = new User
            {
                Name = userName.ToString(),
                Password = userPassword,
                LastName = lastName,
                FirstName = firstName,
                UserType = userTypeEnum,
                IsCreated = true,
            };
            //Save The User In Memory
            newUser.StoreUserInMemory();
            logger.LogMethodExit("AddUserPage", "SaveUserInMemory",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create New User In Global Home.
        /// </summary>
        /// <param name="userTypeEnum">This User Type Enum.</param>
        public void CreateNewUserInGlobalHome(User.UserTypeEnum userTypeEnum)
        {
            // Create New User In Global Home
            logger.LogMethodEntry("AddUserPage", "CreateNewUserInGlobalHome"
                , base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Creating the Cs User by UserType                
                Guid userInformation = this.CreateCsUser(userTypeEnum);
                //Store the User Details in Memory
                this.StoreCourseSpaceUserDetails(userTypeEnum, userInformation);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddUserPage", "CreateNewUserInGlobalHome"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Course Space User Details.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type.</param>
        /// <param name="userInformation">This is Use Name.</param>
        private void StoreCourseSpaceUserDetails(User.UserTypeEnum userTypeEnum, Guid userInformation)
        {
            //Stores User Details in Memory
            logger.LogMethodEntry("AddUserPage", "StoreCourseSpaceUserDetails"
                , base.isTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.DPCsTeacher:
                    //Wait to Pop Up Get Close Successfully
                    if (base.IsPopUpClosed(Convert.ToInt32(AddUserPageResource.
                        AddUser_Page_NoOfWindowsBeforeClose_Value)))
                    {
                        //Store User Details in Memory
                        this.StoreUserDetailsInMemory(userTypeEnum, userInformation, AddUserPageResource.
                            AddUser_Page_PasswordTextbox_Value, userInformation.ToString(),
                            userInformation.ToString());
                    }
                    break;
            }
            logger.LogMethodExit("AddUserPage", "StoreCourseSpaceUserDetails"
             , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create New User In CourseSpace Admin.
        /// </summary>
        /// <param name="userTypeEnum">This is user Type Enum.</param>
        public void CreateNewUserInCourseSpaceAdmin(
            User.UserTypeEnum userTypeEnum)
        {
            // Create New User In CourseSpace Admin
            logger.LogMethodEntry("AddUserPage", "CreateNewUserInCourseSpaceAdmin"
                , base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Creating the Cs User by UserType                
                Guid userInformation = this.CreateCsUser(userTypeEnum);
                //Store the User Details in Memory
                this.StoreCourseSpaceAdminUserDetails(userTypeEnum, userInformation);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddUserPage", "CreateNewUserInCourseSpaceAdmin"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store CourseSpace Admin UserDetails.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="userInformation">User Details.</param>
        private void StoreCourseSpaceAdminUserDetails(
            User.UserTypeEnum userTypeEnum, Guid userInformation)
        {
            //Stores CourseSpace Admin Details in Memory
            logger.LogMethodEntry("AddUserPage", "StoreCourseSpaceAdminUserDetails"
                , base.isTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.DPCsTeacher:
                    //Wait to Pop Up Get Close Successfully
                    if (base.IsPopUpClosed(Convert.ToInt32(AddUserPageResource.
                        AddUser_Page_NoOfWindowsBeforeClass_Value)))
                    {
                        //Store User Details in Memory
                        this.StoreUserDetailsInMemory(userTypeEnum, 
                            userInformation, AddUserPageResource.
                            AddUser_Page_PasswordTextbox_Value, userInformation.ToString(),
                            userInformation.ToString());
                    }
                    break;
            }
            logger.LogMethodExit("AddUserPage", "StoreCourseSpaceAdminUserDetails"
             , base.isTakeScreenShotDuringEntryExit);
        }
    }
}
