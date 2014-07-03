using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.User;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment;
using System.Configuration;
using System.Threading;
using System.IO;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Diagnostics;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class handles Manage User page Actions
    /// </summary>
    public class ManageUserPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ManageUserPage));

        /// <summary>
        /// This is the Bulk Upload Interval Time from AppSettings
        /// </summary>
        static readonly int getMinutesToWait = Int32.Parse
            (ConfigurationManager.AppSettings[ManageUserPageResource.
            ManageUser_Page_AppSettings_AssignedToCopyInterval_Key_Text]);

        /// <summary>
        /// This is the Tab in pegasus where Users will be created in CS 
        /// </summary>
        public enum CreateUserTab
        {
            /// <summary>
            /// User Tab for Creating CS User
            /// </summary>
            Users = 1,
            /// <summary>
            /// Enrollment Tab for Creating CS User
            /// </summary>
            Enrollment = 2,
            /// <summary>
            /// Classes Tab for Creating CS User
            /// </summary>
            Classes = 3
        }

        /// <summary>
        /// Navigate To Sub Tab
        /// </summary>
        /// <param name="tabNameEnum">This is Tab Name Enum</param>
        public void NavigateToSubTab(CreateUserTab tabNameEnum)
        {
            //Clicks on the Sub Tab
            logger.LogMethodEntry("ManageUserPage", "NavigateToSubTab",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (tabNameEnum)
                {
                    case CreateUserTab.Users:
                        //Clicks on the Users Tab
                        this.ClickOnUsersTab();
                        break;
                    case CreateUserTab.Enrollment:
                        //Clicks on the Enrollment Tab
                        new ManageOrganisationToolBarPage().ClickOnEnrollmentTab();
                        break;
                    case CreateUserTab.Classes:
                        //Clicks on the Classes Tab
                        new ManageOrganisationToolBarPage().ClickOnClassesTab();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUserPage", "NavigateToSubTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on the Users Tab
        /// </summary>
        public void ClickOnUsersTab()
        {
            //Click on the User Tab
            logger.LogMethodEntry("ManageUserPage", "ClickOnUsersTab",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Manage Organization Window
                new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
                //Get the Selected Tab Name
                base.FocusOnElementByClassName(ManageUserPageResource.
                    ManageUser_Page_Selected_Tabname_ClassName_Locator);
                //Get Tab Name
                string getTabName = base.GetElementTextByClassName(ManageUserPageResource.
                    ManageUser_Page_Selected_Tabname_ClassName_Locator);
                if (getTabName != ManageUserPageResource.ManageUser_Page_Users_Tabname)
                {
                    //Clicks on the Users Tab
                    base.ClickButtonByPartialLinkText(ManageUserPageResource.
                        ManageUser_Page_Users_Tabname);
                }
                //Wait for the Frame
                base.WaitForElement(By.Id(ManageUserPageResource.
                    ManageUser_Page_Iframe_Id_Locator));
                //Switch toFrame
                base.SwitchToIFrame(ManageUserPageResource.ManageUser_Page_Iframe_Id_Locator);
                //Wait for Add User Link
                base.WaitForElement(By.Id(ManageUserPageResource.
                    ManageUser_Page_AddUsers_Link_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUserPage", "ClickOnUsersTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks On Add/Create Users Link
        /// </summary>
        /// <param name="tabNameEnum">This is Tab name Enum</param>
        public void ClickOnAddCreateUsersLink(CreateUserTab tabNameEnum)
        {
            //Click on the Add Users/Create Users Link
            logger.LogMethodEntry("ManageUserPage", "ClickOnAddCreateUsersLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (tabNameEnum)
                {
                    case CreateUserTab.Users:
                        {
                            //Clicks on the Add Users Link in Users tab
                            this.ClickOnTheAddUsersLink();
                        }
                        break;
                    case CreateUserTab.Enrollment:
                        {
                            //Clicks on the Create Users Link in Enrollment tab
                            new OrgAdminUserEnrollmentPage().ClickOnTheCreateUsersLink();
                        }
                        break;
                    case CreateUserTab.Classes:
                        {
                            //Click On Create New Button In Manage Student
                            new ManageStudentsDefaultPage().ClickOnCreateNewButtonInManageStudentsPage();
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Click on the Add Users Link
            logger.LogMethodExit("ManageUserPage", "ClickOnAddCreateUsersLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks On The 'Add Users' Link
        /// </summary>
        private void ClickOnTheAddUsersLink()
        {
            //Click on the Add Users Link
            logger.LogMethodEntry("ManageUserPage", "ClickOnTheAddUsersLink",
                base.isTakeScreenShotDuringEntryExit);
            //Select the Manage Organization Window
            new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
            //Switch toFrame
            base.SwitchToIFrame(ManageUserPageResource.ManageUser_Page_Iframe_Id_Locator);
            //Wait for Add User Link
            base.WaitForElement(By.Id(ManageUserPageResource.
                ManageUser_Page_AddUsers_Link_Id_Locator));
            //Click on the Add Users Link
            IWebElement getAddUserLink = base.GetWebElementPropertiesById(ManageUserPageResource.
                ManageUser_Page_AddUsers_Link_Id_Locator);
            base.ClickByJavaScriptExecutor(getAddUserLink);
            logger.LogMethodExit("ManageUserPage", "ClickOnTheAddUsersLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selects User Type
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type</param>
        public void SelectUserType(User.UserTypeEnum userTypeEnum)
        {
            //Select the User type
            logger.LogMethodEntry("ManageUserPage", "SelectUserType",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Selects the type of user to create
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.DPCsTeacher:
                    case User.UserTypeEnum.NovaNETCsTeacher:
                        IWebElement getUserLink = base.GetWebElementPropertiesById
                            (ManageUserPageResource.
                            ManageUser_Page_AddUsers_Teacher_Option_Id_Locator);
                        base.ClickByJavaScriptExecutor(getUserLink);
                        break;
                    case User.UserTypeEnum.NovaNETCsStudent:
                    case User.UserTypeEnum.DPCsStudent:
                        //Click on the Student link
                        this.ClickOnStudentOption();
                        break;
                    case User.UserTypeEnum.NovaNETCsAide:
                    case User.UserTypeEnum.DPCsAide:
                        //Click on the Aide link
                        base.ClickLinkByID(ManageUserPageResource.
                            ManageUser_Page_AddUsers_Aide_Option_Id_Locator);
                        break;
                    case User.UserTypeEnum.NovaNETCsOrganizationAdmin:
                    case User.UserTypeEnum.DPCsOrganizationAdmin:
                        //Click on the Administrator link
                        base.ClickLinkByID(ManageUserPageResource.
                            ManageUser_Page_AddUsers_Administrator_Option_Id_Locator);
                        break;
                }
                //Select the Add User Window
                base.WaitUntilWindowLoads(AddUserPageResource.AddUser_Page_PopUpName);
                base.SelectWindow(AddUserPageResource.AddUser_Page_PopUpName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUserPage", "SelectUserType",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Student Option
        /// </summary>
        private void ClickOnStudentOption()
        {
            //Click on the Student option
            logger.LogMethodEntry("ManageUserPage", "ClickOnStudentOption",
                base.isTakeScreenShotDuringEntryExit);
            //Check if the student option is present
            if (base.IsElementPresent(By.Id(ManageUserPageResource.
                ManageUser_Page_AddUsers_Student_Option_Id_Locator),
                Convert.ToInt32(ManageUserPageResource.ManageUser_Page_Wait_Time)))
            {
                IWebElement getStudentLink = base.GetWebElementPropertiesById
                    (ManageUserPageResource.
                    ManageUser_Page_AddUsers_Student_Option_Id_Locator);
                //Click on the student Option in Users tab
                base.ClickByJavaScriptExecutor(getStudentLink);
            }
            else
            {
                //Click on the student Option in Enrollment tab
                base.ClickLinkByID(OrgAdminUserEnrollmentPageResource.
                    OrgAdminUserEnrollment_Page_CreateUsers_Student_Option_Id_Locator);
            }
            logger.LogMethodExit("ManageUserPage", "ClickOnStudentOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search User In Course Space
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        /// <param name="tabNameEnum">This is Tab Name Enum</param>
        public void SearchUserInCourseSpace(User.UserTypeEnum userTypeEnum,
            CreateUserTab tabNameEnum)
        {
            //Search User
            logger.LogMethodEntry("ManageUserPage", "SearchUserInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (tabNameEnum)
                {
                    //Search User In Users Tab
                    case CreateUserTab.Users:
                        {
                            //Get User Details from Memory
                            User user = User.Get(userTypeEnum);
                            //Search user
                            this.SearchUserInUsersTab(user.Name);
                        }
                        break;
                    //Search User In Enrollment Tab
                    case CreateUserTab.Enrollment:
                        {
                            new OrgAdminUserEnrollmentPage().
                                SearchUserInEnrollmentSubTab(userTypeEnum);
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUserPage", "SearchUserInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the User in Users Tab
        /// </summary>
        /// <param name="userName">This is User Name</param>
        private void SearchUserInUsersTab(string userName)
        {
            //Search the User
            logger.LogMethodEntry("ManageUserPage", "SearchUserInUsersTab",
                base.isTakeScreenShotDuringEntryExit);
            //Select the Manage Organization window
            new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
            //Switch to the Frame
            base.SwitchToIFrame(ManageUserPageResource.ManageUser_Page_Iframe_Id_Locator);
            //Click on the Search Link
            base.WaitForElement(By.Id(ManageUserPageResource.ManageUser_Page_Link_Search_Id_Locator));
            IWebElement getSearchButton = base.GetWebElementPropertiesById
                (ManageUserPageResource.ManageUser_Page_Link_Search_Id_Locator);
            base.ClickByJavaScriptExecutor(getSearchButton);
            base.WaitForElement(By.Id(ManageUserPageResource.
                ManageUser_Page_Textbox_Username_Id_Locator));
            //Get user details from Memory           
            base.FillTextBoxByID(ManageUserPageResource.
                ManageUser_Page_Textbox_Username_Id_Locator, userName);
            IWebElement getSearctLink=base.GetWebElementPropertiesById
                (ManageUserPageResource.
                ManageUser_Page_Button_Search_Id_Locator);
            //Click on the Search button
            base.ClickByJavaScriptExecutor(getSearctLink);
            logger.LogMethodExit("ManageUserPage", "SearchUserInUsersTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Searched User In CourseSpace
        /// </summary>
        /// <param name="tabNameEnum">This is Tab Name Enum</param>
        /// <returns>Searched User Name</returns>
        public String GetSearchedUserInCourseSpace(CreateUserTab tabNameEnum)
        {
            //Get Searched User name
            logger.LogMethodEntry("ManageUserPage", "GetSearchedUserInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize variable getUserName
            string getUserName = string.Empty;
            try
            {
                switch (tabNameEnum)
                {
                    case CreateUserTab.Users:
                        {
                            //Get the Searched User In Users Tab
                            getUserName = this.GetSearchedUserInUsersTab();
                        }
                        break;
                    case CreateUserTab.Enrollment:
                        {
                            //Get the Searched User In Enrollment Tab
                            getUserName = new OrgAdminUserEnrollmentPage().
                                GetSearchedUserInEnrollmentSubTab();
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUserPage", "GetSearchedUserInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
            return getUserName;
        }

        /// <summary>
        /// Get the Searched User Name in Users Tab
        /// </summary>
        /// <returns>Searched User Name</returns>
        private String GetSearchedUserInUsersTab()
        {
            //Get Searched User name
            logger.LogMethodEntry("ManageUserPage", "GetSearchedUserInUsersTab",
                base.isTakeScreenShotDuringEntryExit);
            //Select the Manage Organization window
            new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
            //Switch to the Frame
            base.SwitchToIFrame(ManageUserPageResource.ManageUser_Page_Iframe_Id_Locator);
            //Wait for the Searched table
            base.WaitForElement(By.Id(ManageUserPageResource.
                ManageUser_Page_Searched_Table_Id_Locator));
            //Get the Username
            string getUserName = base.GetTitleAttributeValueByXPath(ManageUserPageResource.
                ManageUser_Page_Searched_Username_Xpath_Locator);
            logger.LogMethodExit("ManageUserPage", "GetSearchedUserInUsersTab",
                base.isTakeScreenShotDuringEntryExit);
            return getUserName;
        }

        /// <summary>
        /// Bulk User upload
        /// </summary>
        public void BulkUserUpload()
        {
            //Bulk User upload
            logger.LogMethodEntry("ManageUserPage", "BulkUserUpload"
                , base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.Id(ManageUserPageResource.
                    ManageUser_Page_AddUsers_BulkUser_Option_Id_Locator));
                //Click on the Bulk User link
                base.ClickLinkByID(ManageUserPageResource.
                    ManageUser_Page_AddUsers_BulkUser_Option_Id_Locator);
                //Wait For Window
                base.WaitUntilWindowLoads(ImportUsersPageResource.ImportUsers_Page_Window_Name);
                //Select Window
                base.SelectWindow(ImportUsersPageResource.ImportUsers_Page_Window_Name);
                //Upload the File
                new ImportUsersPage().UploadBulkUserFile();
                //Click on the Ok Button in Pegasus popup
                new ShowMessagePage().ClickOnPegasusOkButton();
                //Select the User tab
                new ManageUserPage().ClickOnUsersTab();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUserPage", "BulkUserUpload"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait For Successfull Message To Display For Bulk Registration
        /// </summary>
        private void WaitForSuccessfullMessageToDisplayForBulkRegistration()
        {
            //Wait For Successfull Message To Display For Bulk Registration
            logger.LogMethodEntry("ManageUserPage",
                "WaitForSuccessfullMessageToDisplayForBulkRegistration"
                , base.isTakeScreenShotDuringEntryExit);
            //Select Manage Organization Window
            new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
            //Start the StopWatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Initialize variable getSuccessfulMessage
            string getSuccessfulMessage = string.Empty;
            do
            {
                base.SwitchToDefaultPageContent();
                //Refresh the Frame
                base.RefreshIFrameByJavaScriptExecutor(ManageUserPageResource.
                    ManageUser_Page_Iframe_Id_Locator);
                //Wait for 5 secs                
                Thread.Sleep(Convert.ToInt32(ManageUserPageResource.ManageUser_Page_Sleep_Time));
                //Select Manage Organization Window
                new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
                //Switch to the Frame
                base.SwitchToIFrame(ManageUserPageResource.ManageUser_Page_Iframe_Id_Locator);
                //Get the Successfull Message
                getSuccessfulMessage = GetElementTextByID(ManageUserPageResource.
                    ManageUser_Page_BulkRegistration_Successfull_Message_Id_Locator);
                //Split the Message by Space
                string[] getDisplayedMessage = getSuccessfulMessage.
                    Split(Convert.ToChar(ManageUserPageResource.
                    ManageUser_Page_BulkRegistration_Successfull_Message_Split_By_Space));
                //Get Successful Message
                getSuccessfulMessage = getDisplayedMessage[Convert.ToInt32(ManageUserPageResource.
                    ManageUser_Page_BulkRegistration_Successfull_Message_IndexOfCurrent_Upload_Value)];
            } while ((getSuccessfulMessage == ManageUserPageResource.
                ManageUser_Page_BulkRegistration_Successfull_Message_Current_Upload_Value) &&
                (stopWatch.Elapsed.TotalMinutes < getMinutesToWait));
            logger.LogMethodExit("ManageUserPage",
                "WaitForSuccessfullMessageToDisplayForBulkRegistration"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Successfull Message After Bulk Registration of Users
        /// </summary>
        /// <returns>Successfull Message After Bulk Registration</returns>
        public String GetSuccessfullMessageAfterBulkRegistration()
        {
            //Get Successfull Message After Bulk Registration of Users
            logger.LogMethodEntry("ManageUserPage", "GetSuccessfullMessageAfterBulkRegistration"
                , base.isTakeScreenShotDuringEntryExit);
            //Initialize variable getSuccessfulMessage
            string getSuccessfulMessage = string.Empty;
            try
            {
                //Wait For Successfull Message To display For Bulk Registration
                this.WaitForSuccessfullMessageToDisplayForBulkRegistration();
                //Get Successfull Message After Bulk Registration of Users
                getSuccessfulMessage = GetElementTextByID(ManageUserPageResource.
                        ManageUser_Page_BulkRegistration_Successfull_Message_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUserPage", "GetSuccessfullMessageAfterBulkRegistration"
                , base.isTakeScreenShotDuringEntryExit);
            return getSuccessfulMessage;
        }

        /// <summary>
        /// Select User Type In Manage Student Page
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum</param>
        public void SelectUserTypeInManageStudentPage(User.UserTypeEnum userTypeEnum)
        {
            //Select User Type In Manage Student Page
            logger.LogMethodEntry("ManageUserPage", "SelectUserTypeInManageStudentPage",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Selects the type of user to create
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.DPCsTeacherManageRoster:
                        //Click on the Teacher link
                        base.WaitForElement(By.Id(ManageUserPageResource.
                            ManageUser_Page_AddUsers_ManageRoster_Teacher_Option_Id_Locator));
                        IWebElement getTeacherOption = base.GetWebElementPropertiesById(ManageUserPageResource.
                            ManageUser_Page_AddUsers_ManageRoster_Teacher_Option_Id_Locator);
                        base.ClickByJavaScriptExecutor(getTeacherOption);
                        break;
                    case User.UserTypeEnum.DPCsStudentManageRoster:
                        //Click on the Student link
                        base.WaitForElement(By.Id(ManageUserPageResource.
                            ManageUser_Page_AddUsers_ManageRoster_Student_Option_Id_Locator));
                        IWebElement getStudentOption = base.GetWebElementPropertiesById(ManageUserPageResource.
                            ManageUser_Page_AddUsers_ManageRoster_Student_Option_Id_Locator);
                        base.ClickByJavaScriptExecutor(getStudentOption);
                        break;
                    case User.UserTypeEnum.DPCsAideManageRoster:
                        //Click on the Aide link
                        base.WaitForElement(By.Id(ManageUserPageResource.
                            ManageUser_Page_AddUsers_ManageRoster_Aide_Option_Id_Locator));
                        IWebElement getAideOption = base.GetWebElementPropertiesById(ManageUserPageResource.
                            ManageUser_Page_AddUsers_ManageRoster_Aide_Option_Id_Locator);
                        base.ClickByJavaScriptExecutor(getAideOption);
                        break;
                }
                //Select the Add User Window
                Thread.Sleep(Convert.ToInt32(ManageUserPageResource.
                    ManageUser_Page_Windows_Sleep_Value));
                base.WaitUntilWindowLoads(AddUserPageResource.AddUser_Page_PopUpName);
                base.SelectWindow(AddUserPageResource.AddUser_Page_PopUpName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUserPage", "SelectUserTypeInManageStudentPage",
                base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Get Message
        /// </summary>
        /// <returns>Message</returns>
        public String GetMessage()
        {
            //Get Message
            logger.LogMethodEntry("ManageUsersPage", "GetMessage"
            , base.isTakeScreenShotDuringEntryExit);
            //Initialize variable
            string getMessage = string.Empty;
            try
            {
                //Select Manage Organization Window
                base.SelectWindow(ManageUserPageResource.
                       ManageUser_Page_ManageOrganization_Window_Name);
                base.WaitForElement(By.Id(ManageUserPageResource.
                    ManageUser_Page_Iframe_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(ManageUserPageResource.
                    ManageUser_Page_Iframe_Id_Locator);
                base.WaitForElement(By.Id(ManageUserPageResource.
                    ManageUser_Page_GetMessage_Id_Locator));
                //Get Message
                getMessage = base.GetElementTextByID(ManageUserPageResource.
                    ManageUser_Page_GetMessage_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                
            }
            logger.LogMethodExit("ManageUsersPage", "GetMessage"
            , base.isTakeScreenShotDuringEntryExit);
            return getMessage;
        }
    }
}
