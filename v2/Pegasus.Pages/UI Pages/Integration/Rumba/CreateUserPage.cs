using System;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.Rumba;
using System.Configuration;
using System.Diagnostics;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles the Create User Page Actions.
    /// </summary>
    public class CreateUserPage : BasePage
    {
        // Static instance of the logger
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(CreateUserPage));

        /// <summary>
        /// Get Wait Time From App Config File.
        /// </summary>
        static readonly double GetSecondsToWait = Convert.ToDouble
        (ConfigurationManager.AppSettings[CreateUserPageResource.
        CreateUser_Page_TimeOut_Config_Key]);

        /// <summary>
        /// Create Rumba User.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="organizationLevelEnum">This is organization level enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        public void CreateNewUser(User.UserTypeEnum userTypeEnum,
            Organization.OrganizationLevelEnum organizationLevelEnum,
            Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Create a User
            Logger.LogMethodEntry("CreateUserPage", "CreateNewUser",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                SelectCreateUserAccountWindow();
                // Generate User Login Details Guid
                Guid userLoginInformation = Guid.NewGuid();
                //Enter User Details
                this.EnterUserDetails(userLoginInformation);
                //Enter Organization Name
                this.EnterOrganizationName(organizationLevelEnum,
                    organizationTypeEnum);
                //Select organization
                this.SelectOrganizationName();
                //Get Organization Id
                this.GetAndStoreOrganizationID(organizationLevelEnum, 
                    organizationTypeEnum);
                //Select the Role and Create User
                this.SelectRoleAndCreateUser(userTypeEnum, userLoginInformation);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CreateUserPage", "CreateNewUser",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Organization Name.
        /// </summary>
        private void SelectOrganizationName()
        {
            //Select Organization Name
            Logger.LogMethodEntry("CreateUserPage", "SelectOrganizationName",
                  base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.ClassName(CreateUserPageResource.
                CreateUser_Page_OrganizationName_ClassName_Locator));
            //Wait for element
            base.WaitForElement(By.ClassName(CreateUserPageResource.
                CreateUser_Page_Organization_ClassName_Locator));
            //Click on organization name
            base.ClickButtonByClassName(CreateUserPageResource.
                CreateUser_Page_Organization_ClassName_Locator);
            Logger.LogMethodExit("CreateUserPage", "SelectOrganizationName",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectCreateUserAccountWindow()
        {
            //Select Create User Account Window
            Logger.LogMethodExit("CreateUserPage", "SelectCreateUserAccountWindow",
               base.isTakeScreenShotDuringEntryExit);
            //Select Create User Account Window
            base.SelectWindow(CreateUserPageResource.
                                  CreateUser_Page_CreateaUserAccount_Window_Name);
            Logger.LogMethodExit("CreateUserPage", "SelectCreateUserAccountWindow",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Organization Name.
        /// </summary>
        /// <param name="organizationLevelEnum">This is organization name.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        private void EnterOrganizationName(
            Organization.OrganizationLevelEnum organizationLevelEnum,
            Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Enter Organization Name
            Logger.LogMethodEntry("CreateUserPage", "EnterOrganizationName",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CreateUserPageResource.
                CreateUser_Page_EnterOrganizationName_Id_Locator));
            // Fetch the organization name from the memory data base
            Organization organization = Organization.Get(
                organizationLevelEnum, organizationTypeEnum);
            base.GetWebElementPropertiesById(CreateUserPageResource.
                CreateUser_Page_EnterOrganizationName_Id_Locator).Clear();
            //Enter Organization Name
            base.GetWebElementPropertiesById(CreateUserPageResource.
                CreateUser_Page_EnterOrganizationName_Id_Locator).SendKeys(organization.Name);
            base.WaitForElement(By.ClassName(CreateUserPageResource.
                CreateUser_Page_OrganizationName_ClassName_Locator));
            Logger.LogMethodExit("CreateUserPage", "EnterOrganizationName",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This function is to get the organization id and store in memory.
        /// </summary>
        /// <param name="organizationLevelEnum">This is organization level enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        /// <returns>Organization ID.</returns>
        private void GetAndStoreOrganizationID(Organization.OrganizationLevelEnum
            organizationLevelEnum, Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            Logger.LogMethodEntry("CreateUserPage", "GetAndStoreOrganizationID",
              base.isTakeScreenShotDuringEntryExit);
            // Get the Organization id
            String organizationId = base.GetValueAttributeByXPath(CreateUserPageResource.
                CreateUser_Page_GetOrgID);
            string[] getSplittedOrgID = organizationId.Split(Convert.ToChar
                (CreateUserPageResource.CreateUser_Page_OrganizationId_Split_Character));
            string getRumbaOrganizationID = getSplittedOrgID[1].Substring(0, 32).Trim();
            // Store for school level organization
            Organization organization = Organization.Get(organizationLevelEnum, organizationTypeEnum);
            organization.RumbaOrgId = getRumbaOrganizationID;
            Logger.LogMethodExit("CreateUserPage", "GetAndStoreOrganizationID",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Role and Create User.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="userLoginInformation">This is UserLoginInformation guid.</param>
        private void SelectRoleAndCreateUser(User.UserTypeEnum userTypeEnum,
            Guid userLoginInformation)
        {
            //Select Role and Create user
            Logger.LogMethodEntry("CreateUserPage", "SelectRoleAndCreateUser",
                base.isTakeScreenShotDuringEntryExit);
            //Select Role
            this.SelectUserRole(userTypeEnum);
            //Enter User Name and Password
            this.EnterUserNameAndPassword(userLoginInformation);
            //Store User Information to Memory
            this.SaveRadminUserInMemory(userLoginInformation, CreateUserPageResource.
                CreateUser_Page_Password_Value,
                userLoginInformation.ToString(), userLoginInformation.ToString(), userTypeEnum);
            Logger.LogMethodExit("CreateUserPage", "SelectRoleAndCreateUser",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter User Name and Password.
        /// </summary>
        /// <param name="userLoginInformation">This is UserLoginInformation guid.</param>
        private void EnterUserNameAndPassword(Guid userLoginInformation)
        {
            //Enter UserName and Password
            Logger.LogMethodEntry("CreateUserPage", "EnterUserNameAndPassword",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for UserName Field
            base.WaitForElement(By.Id(CreateUserPageResource.
                CreateUser_Page_Username_Id_Locator));
            base.GetWebElementPropertiesById(CreateUserPageResource.
                CreateUser_Page_Username_Id_Locator).Clear();
            //Enter UserName 
            base.GetWebElementPropertiesById(CreateUserPageResource.
                CreateUser_Page_Username_Id_Locator).
                SendKeys(userLoginInformation.ToString());
            //Wait for Password Field
            base.WaitForElement(By.Id(CreateUserPageResource.
                CreateUser_Page_Password_Id_Locator));
            base.GetWebElementPropertiesById(CreateUserPageResource.
                CreateUser_Page_Password_Id_Locator).Clear();
            //Enter Password
            base.GetWebElementPropertiesById(CreateUserPageResource.
                CreateUser_Page_Password_Id_Locator).
                SendKeys(CreateUserPageResource.
                CreateUser_Page_Password_Value);
            base.WaitForElement(By.Id(CreateUserPageResource.
                Createuser_Page_CreateAccount_Id_Locator));
            //Click On Create Account Option
            base.GetWebElementPropertiesById(CreateUserPageResource.
                Createuser_Page_CreateAccount_Id_Locator).Click();
            Logger.LogMethodExit("CreateUserPage", "EnterUserNameAndPassword",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter User Details.
        /// </summary>
        /// <param name="userLoginInformation">This UserInformation guid.</param>
        private void EnterUserDetails(Guid userLoginInformation)
        {
            //Enter User Details
            Logger.LogMethodEntry("CreateUserPage", "EnterUserDetails",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for First Name Field
            base.WaitForElement(By.Id(CreateUserPageResource.
                CreateUser_Page_Firstname_Id_Locator));
            //Enter FirstName
            base.GetWebElementPropertiesById(CreateUserPageResource.
                CreateUser_Page_Firstname_Id_Locator).
                SendKeys(userLoginInformation.ToString());
            base.WaitForElement(By.Id(CreateUserPageResource.
                CreateUser_Page_Lastname_Id_Locator));
            //Enter LastName
            base.GetWebElementPropertiesById(CreateUserPageResource.
                CreateUser_Page_Lastname_Id_Locator).SendKeys(userLoginInformation.ToString());
            base.WaitForElement(By.Id(CreateUserPageResource.
                CreateUser_Page_Mail_Id_Locator));
            //Enter Mail Id
            base.GetWebElementPropertiesById(CreateUserPageResource.
                CreateUser_Page_Mail_Id_Locator).
                SendKeys(CreateUserPageResource.CreateUser_Page_EMail_Address);
            base.WaitForElement(By.Id(CreateUserPageResource.
                CreateUser_Page_AddOrganization_Id_Locator));
            //Click On Add Button
            base.ClickButtonByID(CreateUserPageResource.
                CreateUser_Page_AddOrganization_Id_Locator);
            Logger.LogMethodExit("CreateUserPage", "EnterUserDetails",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select User Role.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        private void SelectUserRole(User.UserTypeEnum userTypeEnum)
        {
            //Select the Role
            Logger.LogMethodEntry("CreateUserPage", "SelectUserRole",
              base.isTakeScreenShotDuringEntryExit);
            //Wait for Role Element
            base.WaitForElement(By.Name(CreateUserPageResource.
                CreateUser_Page_Role_Name_Locator));
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.RumbaTeacher:
                case User.UserTypeEnum.RumbaNonPSNTeacher:
                    //Select Teacher in Drop Down
                    base.SelectDropDownValueThroughTextByName(CreateUserPageResource.
                    CreateUser_Page_Role_Name_Locator, CreateUserPageResource.
                    CreateUser_Page_Role_Teacher);
                    break;
                case User.UserTypeEnum.RumbaStudent:
                    //Select Student in Drop Down
                    base.SelectDropDownValueThroughTextByName(CreateUserPageResource.
                    CreateUser_Page_Role_Name_Locator, CreateUserPageResource.
                    CreateUser_Page_Role_Student);
                    break;
            }
            base.WaitForElement(By.Id(CreateUserPageResource.
                CreateUser_Page_Role_Add_Id_Locator));
            //Click On Add Button
            base.ClickButtonByID(CreateUserPageResource.
                CreateUser_Page_Role_Add_Id_Locator);
            Logger.LogMethodExit("CreateUserPage", "SelectUserRole",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the User.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        public void SearchTheUser(User.UserTypeEnum userTypeEnum)
        {
            //Search the User
            Logger.LogMethodEntry("CreateUserPage", "SearchTheUser",
                base.isTakeScreenShotDuringEntryExit);
            //Get User From Memory
            User user = User.Get(userTypeEnum);
            this.SearchUserName(user.Name);
            Logger.LogMethodExit("CreateUserPage ", "SearchTheUser",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search User Name.
        /// </summary>
        /// <param name="userName">This is User Name.</param>
        private void SearchUserName(string userName)
        {
            //Search the UserName
            Logger.LogMethodEntry("CreateUserPage", "SearchUserName",
               base.isTakeScreenShotDuringEntryExit);
            //Select People Window
            base.SelectWindow(CreateUserPageResource.
                CreateUser_Page_People_Window_Name);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            do
            {
                if (stopWatch.Elapsed.TotalSeconds > GetSecondsToWait) break;
                //Enter User Name In Search Box
                this.EnterUserNameInSearchBox(userName);
            } while (!IsElementPresent(By.XPath(CreateUserPageResource.
                CreateUser_Page_GetUserName_Xpath_Locator),
                Convert.ToInt32(CreateUserPageResource.CreateUser_Page_TimeToWait)));
            //Stop The Watch
            stopWatch.Stop();
            Logger.LogMethodExit("CreateUserPage ", "SearchUserName",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Search User Name In Search Box.
        /// </summary>
        /// <param name="userName">This is user name.</param>
        private void EnterUserNameInSearchBox(string userName)
        {
            Logger.LogMethodEntry("CreateUserPage ", "EnterUserNameInSearchBox",
              base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CreateUserPageResource.
                                          CreateUser_Page_EnterUserName_Id_Locator));
            //Clear The Search text box And Fill The User Name
            base.ClearTextByID(CreateUserPageResource.
                                   CreateUser_Page_EnterUserName_Id_Locator);
            base.FillTextBoxByID(CreateUserPageResource.
                                     CreateUser_Page_EnterUserName_Id_Locator, userName);
            //Click On The Search Button
            base.WaitForElement(By.ClassName(CreateUserPageResource.
                                                 CreateUser_Page_SearchButton_ClassName_Locator));
            base.ClickButtonByClassName(CreateUserPageResource.
                                            CreateUser_Page_SearchButton_ClassName_Locator);
            Thread.Sleep(Convert.ToInt32(CreateUserPageResource.
                                             Createuser_Page_ThreadTime_Value));
            Logger.LogMethodExit("CreateUserPage ", "EnterUserNameInSearchBox",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the User Name.
        /// </summary>
        /// <returns>Return Username.</returns>
        public String GetUserName()
        {
            //Get the UserName
            Logger.LogMethodEntry("CreateUserPage", "GetUserName",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getUserName = string.Empty;
            try
            {
                //Select People Window
                base.SelectWindow(CreateUserPageResource.CreateUser_Page_People_Window_Name);
                //Get the UserName
                getUserName = base.GetElementTextByXPath(CreateUserPageResource.
                    CreateUser_Page_GetUserName_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CreateUserPage", "GetUserName",
               base.isTakeScreenShotDuringEntryExit);
            return getUserName;
        }

        /// <summary>
        /// Get Teacher Name From Memory.
        /// </summary>
        /// <returns>Teacher Name.</returns>
        public String GetDigitalPathTeacherNameFromMemory(User.UserTypeEnum userTypeEnum)
        {
            //Get the DP UserName from Memory
            Logger.LogMethodEntry("CreateUserPage", "GetDigitalPathTeacherNameFromMemory",
              base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getRumbaTeacherName = string.Empty;
            try
            {
                //Get user Details
                User user = User.Get(userTypeEnum);
                getRumbaTeacherName = user.Name;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CreateUserPage ", "GetDigitalPathTeacherNameFromMemory",
               base.isTakeScreenShotDuringEntryExit);
            return getRumbaTeacherName;
        }

        /// <summary>
        /// Save Owner ID of Rumba User.
        /// </summary>
        /// <param name="userTypeEnum">This is the user type.</param>
        public void StoreRumbaOwnerIdInMemory(User.UserTypeEnum userTypeEnum)
        {
            //Get the Rumba User ID
            Logger.LogMethodEntry("CreateUserPage", "StoreRumbaOwnerIdInMemory",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.XPath(CreateUserPageResource.
                    CreateUser_Page_SearchedUserTable_Xpath));
                string getValue = base.GetHrefAttributeValueByXPath
                    (CreateUserPageResource.CreateUser_Page_SearchedUserID);
                string[] getSplittedCharacter = getValue.Split('/');
                // Get the User ID
                string getOwnerID = getSplittedCharacter[5].Trim();
                //Get User From Memory
                User rumbaUser = User.Get(userTypeEnum);
                // Save the Rumba Owner ID in Memory
                rumbaUser.RumbaOwnerId = getOwnerID;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CreateUserPage ", "StoreRumbaOwnerIdInMemory",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Student Name from Memory.
        /// </summary>
        /// <returns>Student name.</returns>
        public String GetDigitalPathStudentNameFromMemory()
        {
            //Get the DP Student Name From Memory
            Logger.LogMethodEntry("CreateUserPage", "GetDigitalPathStudentNameFromMemory",
              base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getDPStudentName = string.Empty;
            try
            {
                User user = User.Get(User.UserTypeEnum.RumbaStudent);
                getDPStudentName = user.Name;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CreateUserPage", "GetDigitalPathStudentNameFromMemory",
               base.isTakeScreenShotDuringEntryExit);
            return getDPStudentName;
        }

        /// <summary>.
        /// Get the User name.
        /// </summary>
        /// <param name="userName">This is User Name.</param>
        /// <returns>User Name.</returns>
        public String GetUserNameFromManageFrame(string userName)
        {
            //Get the UserName From Manage Frame
            Logger.LogMethodEntry("CreateUserPage", "GetUserNameFromManageFrame",
              base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getUserName = string.Empty;
            try
            {
                //Wait for Manage Window of User
                base.WaitUntilWindowLoads(CreateUserPageResource.
                    CreateUser_Page_Manage_Name + userName);
                base.SelectWindow(CreateUserPageResource.
                    CreateUser_Page_Manage_Name + userName);
                //Get the UserName
                getUserName = base.GetElementTextByXPath(
                    CreateUserPageResource.CreateUser_Page_GetUserNameFromManage_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CreateUserPage ", "GetUserNameFromManageFrame",
               base.isTakeScreenShotDuringEntryExit);
            return getUserName;
        }

        /// <summary>
        /// Save the User Details.
        /// </summary>
        /// <param name="userName">This is User Name Guid.</param>
        /// <param name="userPassword">This is User Password.</param>
        /// <param name="firstName">This is First Name.</param>
        /// <param name="lastName">This is Last Name.</param>
        /// <param name="userTypeEnum">This is user type enum.</param>
        private void SaveRadminUserInMemory(Guid userName, string userPassword,
            string firstName, string lastName, User.UserTypeEnum userTypeEnum)
        {
            //Save User In Memory
            Logger.LogMethodEntry("CreateUserPage", "SaveRadminUserInMemory",
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
            //Save The User Details
            newUser.StoreUserInMemory();
            Logger.LogMethodExit("CreateUserPage", "SaveRadminUserInMemory",
                      base.isTakeScreenShotDuringEntryExit);
        }
    }
}
