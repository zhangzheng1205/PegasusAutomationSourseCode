using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.Threading;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Admin Tool Page Actions.
    /// </summary>
    public class AdminToolPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(AdminToolPage));

        /// <summary>
        /// This the enum available for Asset type Enum.
        /// </summary>
        public enum AdminWorkspaceTypeEnum
        {
            /// <summary>
            ///Workspace create
            /// </summary>
            Create = 1,
            /// <summary>
            /// Workspace update
            /// </summary>
            Update = 2,
            /// <summary>
            /// Workspace Delete
            /// </summary>
            Delete = 3,
        }

        /// <summary>
        /// Click on Enrollment Mode Option Menu.
        /// </summary>
        public void ClickAddNewCourseEnrollmentModeOption()
        {
            // Click on Enrollment Mode Option Menu
            Logger.LogMethodEntry("AdminToolPage", "ClickEnrollmentModeOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Switch To Default Window
                base.SwitchToDefaultPageContent();
                base.WaitForElement(By.Id(AdminToolPageResource
                    .AdminTool_Page_AddasNew_Button_Id_Locator));
                //Click Add New Course Button
                IWebElement addNewCourseButton = base.GetWebElementPropertiesById
                    (AdminToolPageResource.AdminTool_Page_AddasNew_Button_Id_Locator);
                base.ClickByJavaScriptExecutor(addNewCourseButton);
                //Wait Until Element
                base.WaitUntilWindowLoads(AdminToolPageResource
                    .AdminTool_Page_EnrollmentMode_Window_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "ClickEnrollmentModeOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// User search in the left frame.
        /// </summary>
        /// <param name="username">This is user name.</param>
        public void UserSearch(String username)
        {
            Logger.LogMethodEntry("AdminToolPage", "UserSearch",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // To click New Search link
                if (base.GetWebElementPropertiesById(AdminToolPageResource
                    .AdminTool_Page_SearchLink_Id_Locator).Displayed)
                    base.GetWebElementPropertiesById(AdminToolPageResource
                        .AdminTool_Page_SearchLink_Id_Locator).Click();
                //Search User 
                new SearchUsersPage().SearchUser(username);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "UserSearch",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enroll user as teacher.
        /// </summary>
        /// <param name="userTypeEnum">This is user by type enum.</param>
        public void EnrollUserInCourse(User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("AdminToolPage", "EnrollUserAsTeacher",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Switch to users to enroll in the course
                switch (userTypeEnum)
                {
                    // Case - HED WS Instructor
                    case User.UserTypeEnum.HedWsInstructor:
                    //Case -  WS Teacher
                    case User.UserTypeEnum.WsTeacher:
                        // Click Enroll Button
                        this.EnrollUserAsInstructor();
                        break;
                    // Case - WS Student
                    case User.UserTypeEnum.WsStudent:
                    case User.UserTypeEnum.HedWsStudent:
                        this.EnrollUserAsStudent();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "EnrollUserAsTeacher",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Extract method of EnrollUserIntoCourse for enrolling user as Instructor.
        /// </summary>
        private void EnrollUserAsInstructor()
        {
            //Enroll User as Instructor
            Logger.LogMethodEntry("AdminToolPage", "EnrollUserAsInstructor",
                base.isTakeScreenShotDuringEntryExit);
            //Click enroll button
            new EnrollmentPage().ClickEnrollButton();
            base.SwitchToDefaultWindow();
            //Click on Add As Instructor link
            base.WaitForElement(By.Id(AdminToolPageResource.
                AdminTool_Page_AddAsInstructor_Id_Locator));
            base.FocusOnElementByID(AdminToolPageResource.
                AdminTool_Page_AddAsInstructor_Id_Locator);
            IWebElement getInstructorLink = base.GetWebElementPropertiesById
                (AdminToolPageResource.
                AdminTool_Page_AddAsInstructor_Id_Locator);
            base.ClickByJavaScriptExecutor(getInstructorLink);
            Logger.LogMethodExit("AdminToolPage", "EnrollUserAsInstructor",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Extract method of EnrollUserIntoCourse for enrolling user as Student.
        /// </summary>
        private void EnrollUserAsStudent()
        {
            //Enroll User as Student
            Logger.LogMethodEntry("AdminToolPage", "EnrollUserAsStudent",
                base.isTakeScreenShotDuringEntryExit);
            //Click enroll button
            new EnrollmentPage().ClickEnrollButton();
            base.SwitchToDefaultWindow();
            //Click on Add As Student link
            base.WaitForElement(By.Id(AdminToolPageResource.
                AdminTool_Page_AddAsStudent_Id_Locator));
            IWebElement getStudentLink = base.GetWebElementPropertiesById
                (AdminToolPageResource.
                AdminTool_Page_AddAsStudent_Id_Locator);
            base.ClickByJavaScriptExecutor(getStudentLink);
            Logger.LogMethodExit("AdminToolPage", "EnrollUserAsStudent",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to ManagePrograms Page.
        /// </summary>
        public void NavigateToManageProgramsPage()
        {
            //Navigate To Manage Programs Page
            Logger.LogMethodEntry("AdminToolPage", "NavigateToManageProgramsPage",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.WaitUntilWindowLoads(AdminToolPageResource.
                    AdminTool_Page_CourseEnrollment_Window_Title_Name);
                //Select Default Window
                base.SelectWindow(AdminToolPageResource.
                    AdminTool_Page_CourseEnrollment_Window_Title_Name);
                // Selecting the manage program page
                if (base.IsPopupPresent
                    (AdminToolPageResource.AdminTool_Page_ManagePrograms_Page_Title_Name, 
                    Convert.ToInt32(AdminToolPageResource.AdminTool_Page_Custom_Wait_Time_Value)))
                {
                    //Select Window
                    base.SelectWindow(AdminToolPageResource.
                        AdminTool_Page_ManagePrograms_Page_Title_Name);
                }
                else
                {
                    //Navigate to Manage Program Page
                    NavigateToSubTabOfPublishingTab(AdminToolPageResource.
                        AdminTool_Page_ManagePrograms_Tab_Text_Locator,
                        AdminToolPageResource.
                        AdminTool_Page_ManagePrograms_Page_Title_Name);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "NavigateToManageProgramsPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Handling To Navigate To Organization Management Page.
        /// </summary>
        public void NavigateOrganizationManagementPage()
        {
            //Handling To Organization management Page
            Logger.LogMethodEntry("AdminToolPage", "NavigateOrganizationManagementPage",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.WaitUntilWindowLoads(AdminToolPageResource.
                    AdminTool_Page_CourseEnrollment_Window_Title_Name);
                //Select Default Window
                base.SelectWindow(AdminToolPageResource.
                    AdminTool_Page_CourseEnrollment_Window_Title_Name);
                //Is Organization management Page Open Already
                Boolean isOrganizationManagementPageExists =
                    base.IsPopupPresent(AdminToolPageResource.
                    AdminTool_Page_OrganizationManagementWindow_Name_Locator, Convert.ToInt32(
                    AdminToolPageResource.AdminTool_Page_Custom_Wait_Time_Value));
                if (isOrganizationManagementPageExists)
                {
                    //Selecting the Organization management Page If Opened
                    base.SelectWindow(AdminToolPageResource.
                        AdminTool_Page_OrganizationManagementWindow_Name_Locator);
                }
                else
                {
                    //Navigate to Organization Admin Page If not Opened 
                    this.NavigateToOrganizationAdminTab();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "NavigateOrganizationManagementPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Navigate to Organization Admin tab.
        /// </summary>       
        private void NavigateToOrganizationAdminTab()
        {
            //Navigate To Organization Admin Tab
            Logger.LogMethodEntry("AdminToolPage", "NavigateToOrganizationAdminTab",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Window
            base.WaitUntilWindowLoads(AdminToolPageResource.
                AdminTool_Page_CourseEnrollment_Window_Title_Name);
            //Select Default Window
            base.SelectWindow(AdminToolPageResource.
                AdminTool_Page_CourseEnrollment_Window_Title_Name);
            // Navigating To Organization admin tab
            base.WaitForElement(By.PartialLinkText(AdminToolPageResource.
                AdminTool_Page_OrganizationAdminTab_LinkText_Locator));
            base.GetWebElementPropertiesByPartialLinkText(AdminToolPageResource.
                AdminTool_Page_OrganizationAdminTab_LinkText_Locator).Click();
            //Wait for the Organization Management Window
            base.WaitUntilWindowLoads(AdminToolPageResource.
                AdminTool_Page_OrganizationManagementWindow_Name_Locator);
            //Select Window
            base.SelectWindow(AdminToolPageResource.
                AdminTool_Page_OrganizationManagementWindow_Name_Locator);
            Logger.LogMethodExit("AdminToolPage", "NavigateToOrganizationAdminTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Handling To Navigate Manage Products Page.
        /// </summary>
        public void NavigateManageProductsPage()
        {
            //Handling To Navigate Manage Products Page
            Logger.LogMethodEntry("AdminToolPage", "NavigateManageProductsPage",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.WaitUntilWindowLoads(AdminToolPageResource.
                    AdminTool_Page_CourseEnrollment_Window_Title_Name);
                //Select Default Window
                base.SelectWindow(AdminToolPageResource.
                    AdminTool_Page_CourseEnrollment_Window_Title_Name);
                //Is Manage Products Page Open Already
                Boolean isManageProductPageExists = base.IsPopupPresent(AdminToolPageResource.
                    AdminTool_Page_ManageProducts_Page_Title_Name, Convert.ToInt32(
                    AdminToolPageResource.AdminTool_Page_Custom_Wait_Time_Value));
                if (isManageProductPageExists)
                {
                    //Selecting the Manage Products Page If Opened
                    base.SelectWindow(AdminToolPageResource.
                        AdminTool_Page_ManageProducts_Page_Title_Name);
                }
                else
                {
                    //Navigate to Manage Products Page If not Opened
                    NavigateToSubTabOfPublishingTab(AdminToolPageResource.
                        AdminTool_Page_ManageProducts_Tab_Text_Locator, AdminToolPageResource.
                        AdminTool_Page_ManageProducts_Page_Title_Name);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "NavigateManageProductsPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Navigate to Sub Tab of Publishing Page 
        /// </summary>
        /// <param name="subTab">This Is Subtab Name</param>
        /// <param name="pageName">This Is The PageName</param>
        private void NavigateToSubTabOfPublishingTab(
            String subTab, String pageName)
        {
            //Navigate To Sub Tab
            Logger.LogMethodEntry("AdminToolPage", "NavigateToSubTabOfPublishingTab",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Window
            base.WaitUntilWindowLoads(AdminToolPageResource.
                AdminTool_Page_CourseEnrollment_Window_Title_Name);
            //Select Default Window
            base.SelectWindow(AdminToolPageResource.
                AdminTool_Page_CourseEnrollment_Window_Title_Name);
            // Navigating To Sub Tab Of Publishing Page
            base.WaitForElement(By.PartialLinkText(AdminToolPageResource.
                AdminTool_Page_Publishing_Tab_Text_Locator));
            IWebElement getPublishingTab = base.GetWebElementPropertiesByPartialLinkText
                (AdminToolPageResource.
                AdminTool_Page_Publishing_Tab_Text_Locator);
            base.ClickByJavaScriptExecutor(getPublishingTab);
            //Click on sub tab 
            base.WaitForElement(By.PartialLinkText(subTab));
            IWebElement getManageProductTab = base.GetWebElementPropertiesByPartialLinkText
                (subTab);
            base.ClickByJavaScriptExecutor(getManageProductTab);
            //Selecting The Window
            base.WaitUntilWindowLoads(pageName);
            //Select Window
            base.SelectWindow(pageName);
            Logger.LogMethodExit("AdminToolPage", "NavigateToSubTabOfPublishingTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on My Profile Link.
        /// </summary>
        public void ClickMyProfileLinkByWSAdmin()
        {
            // Selecting MyProfile Link
            Logger.LogMethodEntry("AdminToolPage", "ClickMyProfileLinkByWSAdmin",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.WaitUntilWindowLoads(AdminToolPageResource.
                    AdminTool_Page_CourseEnrollment_Window_Title_Name);
                //Select Default Window
                base.SelectWindow(AdminToolPageResource.
                    AdminTool_Page_CourseEnrollment_Window_Title_Name);
                //Wait For Element
                base.WaitForElement(By.Id(AdminToolPageResource.
                    AdminTool_Page_MyProfile_Link_Id_Locator));
                // Focus on My Profile Link
                base.FocusOnElementByID(AdminToolPageResource.
                    AdminTool_Page_MyProfile_Link_Id_Locator);
                // Get Element Property
                IWebElement getMyProfileLink = base.GetWebElementPropertiesById(AdminToolPageResource.
                    AdminTool_Page_MyProfile_Link_Id_Locator);
                //Click on Link
                base.ClickByJavaScriptExecutor(getMyProfileLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "ClickMyProfileLinkByWSAdmin",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Sign out link on the page.
        /// </summary>
        /// <param name="linkSignOut">This is SingOut Link.</param>
        public void SignOutByPegasusUser(String linkSignOut)
        {
            //Complete SingOut Process
            Logger.LogMethodEntry("LoginPage", "SignOutByPegasusUser",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Base Page
                base.SelectDefaultWindow();
                base.WaitForElement((By.LinkText(linkSignOut)));
                //Get Sign Out Link Property
                IWebElement getSignOutLinkProperty = GetWebElementPropertiesByLinkText(linkSignOut);
                //Click SignOut Link
                base.ClickByJavaScriptExecutor(getSignOutLinkProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LoginPage", "SignOutByPegasusUser",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Sign out link on the page.
        /// </summary>
        /// <param name="linkSignOut">This is SingOut Link.</param>
        public void SignOutByHigherEdUsers(String linkSignOut)
        {
            //Complete SingOut Process
            Logger.LogMethodEntry("AdminToolPage", "SignOutByHigherEdUsers",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Default Window           
                base.SelectDefaultWindow();
                //Wait For Element
                base.WaitForElement((By.PartialLinkText(linkSignOut)));
                //Get Element Property
                IWebElement getLinkProperty = base.
                    GetWebElementPropertiesByPartialLinkText(linkSignOut);
                //Click SignOut Link
                base.ClickByJavaScriptExecutor(getLinkProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "SignOutByHigherEdUsers",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Organization Admin Tab.
        /// </summary>
        public void ClickOnOrganizationAdminTab()
        {
            //Click on Organization Admin Tab
            Logger.LogMethodEntry("AdminToolPage", "ClickOnOrganizationAdminTab",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Select Course Enrollment window 
                base.SelectWindow(AdminToolPageResource.
                    AdminTool_Page_CourseEnrollment_Window_Title_Name);
                // Wait for the ogranization management tab link & click
                base.WaitForElement(By.Id
                    (AdminToolPageResource.AdminTool_Page_TabName_ID_Locator));
                //Get Tab Element Property
                IWebElement getTabProperty = base.GetWebElementPropertiesById
                    (AdminToolPageResource.AdminTool_Page_TabName_ID_Locator);
                //Click on Tab
                base.ClickByJavaScriptExecutor(getTabProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "ClickOnOrganizationAdminTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the Create New Workspace Link.
        /// </summary> 
        /// <param name="adminWorkspaceEnum">This is Admin workspace type by enum.</param>
        public void ClickTheCreateNewWorkspaceLink(
            AdminWorkspaceTypeEnum adminWorkspaceEnum)
        {
            //Click the Create New Workspace Link
            Logger.LogMethodEntry("AdminToolPage", "ClickTheCreateNewWorkspaceLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (adminWorkspaceEnum)
                {
                    case AdminWorkspaceTypeEnum.Create:
                        //Select Workspace Frame
                        this.SelectWorkspaceFrame();
                        //Wait for the element
                        base.WaitForElement(By.PartialLinkText(AdminToolPageResource.
                        AdminTool_Page_CTG_CreateWorkspace_PartialText_Locator));
                        //Get web element
                        IWebElement getCreateWorkspace = base.GetWebElementPropertiesByPartialLinkText
                            (AdminToolPageResource.
                        AdminTool_Page_CTG_CreateWorkspace_PartialText_Locator);
                        //Click the Create New Workspace link
                        base.ClickByJavaScriptExecutor(getCreateWorkspace);
                        //Wait for the window opened
                        base.WaitUntilWindowLoads(AdminToolPageResource.
                            AdminTool_Page_CTG_CreateWorkspace_Window_Name);
                        break;
                }

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "ClickTheCreateNewWorkspaceLink",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Workspace Frame.
        /// </summary>
        private void SelectWorkspaceFrame()
        {
            //Select Workspace Frame
            Logger.LogMethodEntry("AdminToolPage", "SelectWorkspaceFrame",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the window name
                base.WaitUntilWindowLoads(AdminToolPageResource.
                    AdminTool_Page_CTG_admin_Window_Name);
                base.SelectWindow(AdminToolPageResource.
                    AdminTool_Page_CTG_admin_Window_Name);
                //Selct the frame
                base.SwitchToIFrame(AdminToolPageResource.
                    AdminTool_Page_CTG_Window_Frame_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "SelectWorkspaceFrame",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Default Tabs For CTG Publisher Admin.
        /// </summary>
        /// <returns>Returns True if all the Default tabs are displayed otherwise False.</returns>
        public Boolean IsDefaultTabsDisplayedForCtgPublisherAdmin()
        {
            //Display Of Default Tabs For CTG Publisher Admin
            Logger.LogMethodEntry("AdminToolPage", "IsDefaultTabsDisplayedForCtgPublisherAdmin",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            bool isDefaultTabsPresent = false;
            try
            {
                //Select the Default Window
                base.SelectDefaultWindow();
                //Get the Tab Names
                base.WaitForElement(By.Id((AdminToolPageResource.
                    AdminTool_Page_Workspaces_TabNames_Id_Locator)));
                string getTabNames = base.GetElementTextByID(AdminToolPageResource.
                    AdminTool_Page_Workspaces_TabNames_Id_Locator);
                isDefaultTabsPresent = (getTabNames.Contains(AdminToolPageResource.
                    AdminTool_Page_Workspaces_TabName_Workspaces_Text) &&
                    getTabNames.Contains(AdminToolPageResource.
                    AdminTool_Page_Workspaces_TabName_Preferences_Text));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "IsDefaultTabsDisplayedForCtgPublisherAdmin",
                base.isTakeScreenShotDuringEntryExit);
            return isDefaultTabsPresent;
        }

        /// <summary>
        /// Search Created Workspace.
        /// </summary>
        /// <param name="workspaceName">This is workspace type by enum.</param>
        /// <param name="adminWorkspaceType">This is workspace.</param>
        public void SearchCreatedWorkspace(
            AdminWorkspaceTypeEnum adminWorkspaceType,
            string workspaceName)
        {
            //Search Created Workspace
            Logger.LogMethodEntry("AdminToolPage", "SearchCreatedWorkspace",
               base.isTakeScreenShotDuringEntryExit);
            //Intialize the workspace
            string getWorkspaceName = workspaceName.Substring(
                Convert.ToInt32(AdminToolPageResource.AdminTool_Page_Substring_Value),
                Convert.ToInt32(AdminToolPageResource.AdminTool_Page_Substring_Second_Value));
            const int getWorkspaceRowNumber = 0;
            try
            {
                //Select Workspace Frame
                this.SelectWorkspaceFrame();
                //Initialized Variable
                string getElementtext=string.Empty;
                do
                {
                    //Get the table text
                    getElementtext = base.GetElementTextByID(AdminToolPageResource.
                        AdminTool_Page_Workspace_Table_ID_Locator);
                    if (!getElementtext.Contains(getWorkspaceName))
                    {
                        //Click on next button
                        base.ClickLinkById(AdminToolPageResource.
                            AdminTool_Page_Workspace_Table_Next_ID_Locator);
                        //Select Workspace Frame
                        this.SelectWorkspaceFrame();
                    }                   
                }
                while (!getElementtext.Contains(getWorkspaceName));
                //Select Row of Workspace Name
                this.SelectRowOfWorkspaceName(getWorkspaceRowNumber,
                    getWorkspaceName, adminWorkspaceType);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "SearchCreatedWorkspace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Row of Workspace Name.
        /// </summary>
        /// <param name="getWorkspaceRowNumber">Row count.</param>
        /// <param name="workspace">workspace name.</param>
        /// <param name="adminWorkspaceType">This is admin workspace.</param>
        private void SelectRowOfWorkspaceName(int getWorkspaceRowNumber,
            String workspace, AdminWorkspaceTypeEnum adminWorkspaceType)
        {
            //Select Row of Workspace Name
            Logger.LogMethodEntry("AdminToolPage", "SelectRowOfWorkspaceName",
               base.isTakeScreenShotDuringEntryExit);
            //Get the table row count 
            int count = GetElementCountByXPath(AdminToolPageResource.
                AdminTool_Page_Workspace_Table_RowCount_Xpath_Locator);
            for (int setRowCount = 1; setRowCount <= count; setRowCount++)
            {
                if (base.IsElementPresent(By.XPath(string.Format(AdminToolPageResource.
                    AdminTool_Page_Workspace_Table_RowText_Xpath_Locator, setRowCount))))
                {
                    //Get the row text
                    string getText = base.GetElementTextByXPath(string.Format(AdminToolPageResource.
                        AdminTool_Page_Workspace_Table_RowTextValue_Xpath_Locator, setRowCount));
                    if (getText.Contains(workspace))
                    {
                        getWorkspaceRowNumber = setRowCount;
                        break;
                    }
                }
            }
            switch (adminWorkspaceType)
            {
                case AdminWorkspaceTypeEnum.Update:
                    //Click The Image Cmenu Option
                    this.ClickTheImageCmenuOption(getWorkspaceRowNumber);
                    break;
                case AdminWorkspaceTypeEnum.Delete:
                    //Select Checkbox For Delete Workspace
                    this.SelectCheckboxForDeleteWorkspace(getWorkspaceRowNumber);
                    break;
            }
            Logger.LogMethodExit("AdminToolPage", "SelectRowOfWorkspaceName",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Checkbox For Delete Workspace.
        /// </summary>
        /// <param name="getWorkspaceRowNumber">This is rowcount.</param>
        private void SelectCheckboxForDeleteWorkspace(int getWorkspaceRowNumber)
        {
            //Select Checkbox For Delete Workspace
            Logger.LogMethodEntry("AdminToolPage", "SelectCheckboxForDeleteWorkspace",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(string.Format(AdminToolPageResource.
                AdminTool_Page_Workspaces_Delete_Checkbox_Xpath_Locator, 
                getWorkspaceRowNumber)));
            base.FocusOnElementByXPath(string.Format(AdminToolPageResource.
                AdminTool_Page_Workspaces_Delete_Checkbox_Xpath_Locator,
                getWorkspaceRowNumber));
            //Delay time
            Thread.Sleep(Convert.ToInt32(AdminToolPageResource.
               AdminTool_Page_Substring_Second_Value));
            IWebElement getCheckbox = base.GetWebElementPropertiesByXPath
                (string.Format(AdminToolPageResource.
                AdminTool_Page_Workspaces_Delete_Checkbox_Xpath_Locator,
                getWorkspaceRowNumber));
            //Click the checkbox
            base.ClickByJavaScriptExecutor(getCheckbox);
            Logger.LogMethodExit("AdminToolPage", "SelectCheckboxForDeleteWorkspace",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Delete Link In CTGPublisher Admin.
        /// </summary>
        public void ClickOnDeleteLinkInCtgPublisherAdmin()
        {
            //Click On Delete Link In CTGPublisher Admin
            Logger.LogMethodEntry("AdminToolPage", "ClickOnDeleteLinkInCtgPublisherAdmin",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(AdminToolPageResource.
                    AdminTool_Page_Workspaces_Delet_Id_Locator));
                IWebElement getDeleteProperty = base.GetWebElementPropertiesById
                    (AdminToolPageResource.
                    AdminTool_Page_Workspaces_Delet_Id_Locator);
                //Click the delete link
                base.ClickByJavaScriptExecutor(getDeleteProperty);
                //Wait for the window
                base.WaitUntilWindowLoads(AdminToolPageResource.AdminTool_Page_Pegasus_WindowName);
                base.SelectWindow(AdminToolPageResource.AdminTool_Page_Pegasus_WindowName);
                //Wait for the element
                base.WaitForElement(By.Id(AdminToolPageResource.
                    AdminTool_Page_Pegasus_Ok_Button_Id_Locator));
                IWebElement getOkButton = base.GetWebElementPropertiesById
                    (AdminToolPageResource.
                    AdminTool_Page_Pegasus_Ok_Button_Id_Locator);
                //Click ok button
                base.ClickByJavaScriptExecutor(getOkButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "ClickOnDeleteLinkInCtgPublisherAdmin",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click The Image Cmenu Option.
        /// </summary>
        /// <param name="workspaceRowNumber">This is row count.</param>
        private void ClickTheImageCmenuOption(int workspaceRowNumber)
        {
            //Select Cmenu Option 
            Logger.LogMethodEntry("AdminToolPage", "ClickTheImageCmenuOption",
               base.isTakeScreenShotDuringEntryExit);
            //Focus on the row
            base.FocusOnElementByXPath(string.Format(AdminToolPageResource.
              AdminTool_Page_Workspace_Table_Row_Img_Xpath_Locator, workspaceRowNumber));
            Thread.Sleep(Convert.ToInt32(AdminToolPageResource.
                AdminTool_Page_Substring_Second_Value));
            //Get web element
            IWebElement getImgOption = base.GetWebElementPropertiesByXPath
                (string.Format(AdminToolPageResource.
                AdminTool_Page_Workspace_Table_Row_Img_Xpath_Locator, workspaceRowNumber));
            //Click the cmenu
            base.ClickByJavaScriptExecutor(getImgOption);
            Logger.LogMethodExit("AdminToolPage", "ClickTheImageCmenuOption",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Is Displayed The Cmenu Options.
        /// </summary>
        /// <returns>Returns True if all cmenu options present.</returns>
        public Boolean IsDisplayedTheCmenuOptions()
        {
            //Verify The Displayed Of Cmenu Options  
            Logger.LogMethodEntry("AdminToolPage", "VerifyTheDisplayedOfCmenuOptions",
               base.isTakeScreenShotDuringEntryExit);
            bool isCmenuOptionsDisplayed = false;
            try
            {
                //Is 'Edit Workspace info' link Displayed
                bool isEditWorkspaceinfoDisplayed = base.IsElementPresent(By.PartialLinkText
                    (AdminToolPageResource.
                    AdminTool_Page_Workspace_EditWorkspace_Text));
                //Is 'Delete' link Displayed
                bool isDeleteDisplayed = base.IsElementPresent(By.PartialLinkText
                    (AdminToolPageResource.
                    AdminTool_Page_Workspace_Delete_Cmenu_Text));
                //Is 'Inactive' link Displayed
                bool isInactiveDisplayed = base.IsElementPresent(By.PartialLinkText
                    (AdminToolPageResource.
                    AdminTool_Page_Workspace_Inactive_Cmenu_Text));
                isCmenuOptionsDisplayed = isEditWorkspaceinfoDisplayed && isDeleteDisplayed && isInactiveDisplayed;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "VerifyTheDisplayedOfCmenuOptions",
               base.isTakeScreenShotDuringEntryExit);
            return isCmenuOptionsDisplayed;
        }

        /// <summary>
        /// Click Edit Workspace info CmenuOption.
        /// </summary>
        public void ClickEditWorkspaceinfoCmenuOption()
        {
            //Click Edit Workspace info CmenuOption
            Logger.LogMethodEntry("AdminToolPage", "ClickEditWorkspaceinfoCmenuOption",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the elemnet
                base.WaitForElement(By.PartialLinkText(AdminToolPageResource.
                    AdminTool_Page_Workspace_EditWorkspace_Text));
                IWebElement getEditWorkspaceInfoLink = base.GetWebElementPropertiesByPartialLinkText
                    (AdminToolPageResource.
                    AdminTool_Page_Workspace_EditWorkspace_Text);
                //Click the Edit workspace info cmenu option
                base.ClickByJavaScriptExecutor(getEditWorkspaceInfoLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "ClickEditWorkspaceinfoCmenuOption",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the User Created in Adminitrators Page.
        /// </summary>
        /// <param name="userName">This is User Type name.</param>
        public void SearchUserInAdministratorsPage(String userName)
        {
            //Search User In Administrators Page
            Logger.LogMethodEntry("AdminToolPage", "SearchUserInAdministratorsPage",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Search the User
                this.UserSearch(userName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "SearchUserInAdministratorsPage",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Administrator Tool Page.
        /// </summary>
        public void NavigateAdministratorToolPage()
        {
            //Navigate Administrator Tool Page
            Logger.LogMethodEntry("AdminToolPage", "NavigateAdministratorToolPage",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Parent Window
                base.SelectDefaultWindow();
                //Is Administrator Tool Page Open Already
                Boolean isAdministratorToolPageExists = base.IsPopupPresent(AdminToolPageResource.
                    AdminTool_Page_AdministratorToolWindow_Name_Locator, Convert.ToInt32(
                    AdminToolPageResource.AdminTool_Page_Custom_Wait_Time_Value));
                if (isAdministratorToolPageExists)
                {
                    //Selecting the Administrator Tool Page If Opened
                    base.SelectWindow(AdminToolPageResource.
                        AdminTool_Page_AdministratorToolWindow_Name_Locator);
                }
                else
                {
                    //Navigate to Administrator Tool Page If not Opened 
                    this.NavigateToAdministratorsTab();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "NavigateAdministratorToolPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Administrators Tab.
        /// </summary>
        private void NavigateToAdministratorsTab()
        {
            //Navigate To Administrators Tab
            Logger.LogMethodEntry("AdminToolPage", "NavigateToAdministratorsTab",
                base.isTakeScreenShotDuringEntryExit);
            base.SelectDefaultWindow();
            // Navigating To Administrators tab
            base.WaitForElement(By.PartialLinkText(AdminToolPageResource.
                AdminTool_Page_AdministratorsTab_LinkText_Locator));
            base.GetWebElementPropertiesByPartialLinkText(AdminToolPageResource.
                AdminTool_Page_AdministratorsTab_LinkText_Locator).Click();
            //Wait for the Administrator Tool Window
            base.WaitUntilWindowLoads(AdminToolPageResource.
                AdminTool_Page_AdministratorToolWindow_Name_Locator);
            //Select Window
            base.SelectWindow(AdminToolPageResource.
                AdminTool_Page_AdministratorToolWindow_Name_Locator);
            Logger.LogMethodExit("AdminToolPage", "NavigateToAdministratorsTab",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
