using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using System.Threading;
using System.Diagnostics;
using System.Configuration;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.User;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains the details of 'Manage Student Default' Page Actions
    /// </summary>
    public class ManageStudentsDefaultPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(ManageStudentsDefaultPage));

        /// <summary>
        /// This is the Bulk Upload Interval Time from AppSettings
        /// </summary>
        static readonly int getMinutesToWait = Int32.Parse
            (ConfigurationManager.AppSettings[ManageStudentsDefaultPageResource.
            ManageStudentsDefaultPage_AppSettings_AssignedToCopyInterval_Key_Text]);

        /// <summary>
        /// Display Of 'Manage Students' Page
        /// </summary>
        /// <returns>Manage Students window Name</returns>
        public String GetManageStudentsPage()
        {
            //Display Of 'Manage Students' Page
            logger.LogMethodEntry("ManageStudentsDefaultPage", "GetManageStudentsPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string windowName = string.Empty;
            try
            {
                //Wait for the window to Load
                base.SwitchToDefaultPageContent();
                base.WaitUntilWindowLoads(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Window_Title);
                //Get the Window Name                
                base.SelectWindow(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Window_Title);
                windowName = base.GetWindowTitleByJavaScriptExecutor();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageStudentsDefaultPage", "GetManageStudentsPage",
                base.IsTakeScreenShotDuringEntryExit);
            return windowName;
        }

        /// <summary>
        /// Click On 'Create New' Button in Manage Students Page
        /// </summary>
        public void ClickOnCreateNewButtonInManageStudentsPage()
        {
            //Click On 'Create New' Button in Manage Student
            logger.LogMethodEntry("ManageStudentsDefaultPage",
                "ClickOnCreateNewButtonInManageStudentsPage",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select The Roster Frame
                this.SelectTheRosterFrame();
                //Click on the Create New Button
                base.WaitForElement(By.ClassName(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Button_CreateNew_ClassName_Locator));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByClassName(
                    ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Button_CreateNew_ClassName_Locator));
                //Wait for the Cmenu options
                base.WaitForElement(By.Id(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Div_CMenu_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageStudentsDefaultPage",
                "ClickOnCreateNewButtonInManageStudentsPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Roster Frame
        /// </summary>
        private void SelectTheRosterFrame()
        {
            //Select The Roster Frame
            logger.LogMethodEntry("ManageStudentsDefaultPage", "SelectTheRosterFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Select the Manage Students window
            base.SelectWindow(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Window_Title);
            //Select the Container Frame
            base.WaitForElement(By.Id(ManageStudentsDefaultPageResource.
                ManageStudentsDefaultPage_Frame_Container_Id_Locator));
            base.SwitchToIFrame(ManageStudentsDefaultPageResource.
                ManageStudentsDefaultPage_Frame_Container_Id_Locator);
            //Select the Roster Frame
            base.WaitForElement(By.Id(ManageStudentsDefaultPageResource.
                ManageStudentsDefaultPage_Frame_Roster_Id_Locator));
            base.SwitchToIFrame(ManageStudentsDefaultPageResource.
                ManageStudentsDefaultPage_Frame_Roster_Id_Locator);
            logger.LogMethodExit("ManageStudentsDefaultPage", "SelectTheRosterFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Option From 'Create New' Drop Down Options
        /// </summary>
        /// <param name="dropDownOption">This is the Drop Down Option to be Selected</param>
        public void SelectTheOptionFromCreateNewDropDown(string dropDownOption)
        {
            //Select The Option From 'Create New' Drop Down Options
            logger.LogMethodEntry("ManageStudentsDefaultPage",
                "SelectTheOptionFromCreateNewDropDown",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click On 'Create New' Button
                this.ClickOnCreateNewButtonInManageStudentsPage();
                //Click on the CMenu Option
                base.WaitForElement(By.PartialLinkText(dropDownOption));
                base.ClickLinkByPartialLinkText(dropDownOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageStudentsDefaultPage",
                "SelectTheOptionFromCreateNewDropDown",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Delete The Older Uploaded Files
        /// </summary>
        public void DeleteTheOlderUploadedFiles()
        {
            //Delete The Older Uploaded Files
            logger.LogMethodEntry("ManageStudentsDefaultPage", "DeleteTheOlderUploadedFiles",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select The Roster Frame
                this.SelectTheRosterFrame();
                if (base.IsElementPresent(By.Id(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_ViewRegistrationQueue_Id_Locator),
                    Convert.ToInt32(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Customized_Wait_Time)))
                {
                    base.ClickLinkById(ManageStudentsDefaultPageResource.
                        ManageStudentsDefaultPage_ViewRegistrationQueue_Id_Locator);
                    //Delete the Files
                    new BulkUploadQueuePage().DeleteOlderUploadedFileInManageStudentsWindow();
                    //Refresh the 'Manage Students' Page
                    base.SelectWindow(ManageStudentsDefaultPageResource.
                        ManageStudentsDefaultPage_Window_Title);
                    base.RefreshTheCurrentPage();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageStudentsDefaultPage", "DeleteTheOlderUploadedFiles",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Import Users
        /// </summary>
        public void ImportUsers()
        {
            //Import Users
            logger.LogMethodEntry("ManageStudentsDefaultPage", "ImportUsers",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Import Users window
                new ImportUsersPage().SelectImportUsersWindow();
                //Upload the File
                new ImportUsersPage().UploadBulkUserFile();
                //Click on the Ok Button in Pegasus popup
                new ShowMessagePage().ClickOnPegasusAlertOkButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageStudentsDefaultPage", "ImportUsers",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display of Successfull Message For Bulk Registration
        /// </summary>
        /// <returns>Successfull Message after Bulk Registration</returns>
        public String GetSuccessfullMessageAfterBulkRegistration()
        {
            //Display of Successfull Message After Bulk Registration
            logger.LogMethodEntry("ManageStudentsDefaultPage",
                "GetSuccessfullMessageAfterBulkRegistration",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable getSuccessfulMessage
            string getSuccessfulMessage = string.Empty;
            try
            {
                //Wait For Successfull Message To Display After Bulk Registration
                this.WaitForSuccessfullMessageToDisplayForBulkRegistration();
                //Get the successfull Message
                getSuccessfulMessage = GetElementTextById(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_BulkRegistration_Successfull_Message_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageStudentsDefaultPage",
                "GetSuccessfullMessageAfterBulkRegistration",
                base.IsTakeScreenShotDuringEntryExit);
            return getSuccessfulMessage;
        }

        /// <summary>
        /// Wait For Successfull Message To Display For Bulk Registration
        /// </summary>
        private void WaitForSuccessfullMessageToDisplayForBulkRegistration()
        {
            //Wait For Successfull Message To Display For Bulk Registration
            logger.LogMethodEntry("ManageStudentsDefaultPage",
                "WaitForSuccessfullMessageToDisplayForBulkRegistration",
                base.IsTakeScreenShotDuringEntryExit);
            //Select The Roster Frame
            this.SelectTheRosterFrame();
            //Start the StopWatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Initialize variable getSuccessfulMessage
            string getSuccessfulMessage = string.Empty;
            do
            {
                base.SwitchToDefaultPageContent();
                //Refresh the Frame
                base.RefreshIFrameByJavaScriptExecutor(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Frame_Container_Id_Locator);
                //Wait for 5 secs                
                Thread.Sleep(Convert.ToInt32(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Sleep_Time));
                //Select The Roster Frame
                this.SelectTheRosterFrame();
                //Get the Successfull Message
                getSuccessfulMessage = GetElementTextById(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_BulkRegistration_Successfull_Message_Id_Locator);
                //Split the Message by Space
                string[] getDisplayedMessage = getSuccessfulMessage.
                    Split(Convert.ToChar(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_BulkRegistration_Successfull_Message_Split_By_Space));
                //Get Successful Message
                getSuccessfulMessage = getDisplayedMessage[Convert.ToInt32(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_BulkRegistration_Successfull_Message_IndexOfCurrent_Upload_Value)];
            } while ((getSuccessfulMessage == ManageStudentsDefaultPageResource.
                ManageStudentsDefaultPage_Split_Index_Value) &&
                (stopWatch.Elapsed.TotalMinutes < getMinutesToWait));
            logger.LogMethodExit("ManageStudentsDefaultPage",
                "WaitForSuccessfullMessageToDisplayForBulkRegistration",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The Enrolled User
        /// </summary>
        /// <param name="userName">This is User Name</param>
        /// <returns>Enrolled User Name</returns>
        public String GetEnrolledUser(string userName)
        {
            //Get The Enrolled User
            logger.LogMethodEntry("ManageStudentsDefaultPage", "GetEnrolledUser",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getUserName = string.Empty;
            try
            {
                //Select The Roster Frame
                this.SelectTheRosterFrame();
                base.WaitForElement(By.XPath(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Total_User_Count_XPath_Locator));
                //Get the Total Course Count
                int getTotalUserCount = base.GetElementCountByXPath(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Total_User_Count_XPath_Locator);
                for (int rowCount = Convert.ToInt32(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Loop_Initializer_Value);
                    rowCount <= getTotalUserCount; rowCount++)
                {
                    base.WaitForElement(By.XPath(String.Format(
                        ManageStudentsDefaultPageResource.ManageStudentsDefaultPage_User_Name_XPath_Locator,
                        rowCount)));
                    //Get the User Name
                    if (base.GetTitleAttributeValueByXPath(String.Format(
                        ManageStudentsDefaultPageResource.ManageStudentsDefaultPage_User_Name_XPath_Locator,
                        rowCount)).Contains(userName))
                    {
                        getUserName = userName;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageStudentsDefaultPage", "GetEnrolledUser",
                base.IsTakeScreenShotDuringEntryExit);
            return getUserName;
        }


        /// <summary>
        /// Get The Unenrolled text for unenroll user
        /// </summary>
        /// <param name="userName">This is User Name</param>
        /// <returns>Enrolled User Name</returns>
        public String GetUnenrolledText(string userName)
        {
            //Get The Enrolled User
            logger.LogMethodEntry("ManageStudentsDefaultPage", "GetUnenrolledText",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getUnenrolledText = string.Empty;
            try
            {
                //Select The Roster Frame
                this.SelectTheRosterFrame();
                base.WaitForElement(By.XPath(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Total_User_Count_XPath_Locator));
                //Get the Total Course Count
                int getTotalUserCount = base.GetElementCountByXPath(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Total_User_Count_XPath_Locator);
                for (int rowCount = Convert.ToInt32(ManageStudentsDefaultPageResource.
                    ManageStudentsDefaultPage_Loop_Initializer_Value);
                    rowCount <= getTotalUserCount; rowCount++)
                {
                    if (!(base.IsElementPresent(By.XPath(string.Format(ManageStudentsDefaultPageResource.
                        ManageStudentsDefaultPage_User_Name_XPath_Locator, rowCount)),
                        Convert.ToInt32(ManageStudentsDefaultPageResource.
                        ManageStudentsDefaultPage_Customized_Wait_Time))))
                    {
                        base.WaitForElement(By.XPath(String.Format(
                        ManageStudentsDefaultPageResource.ManageStudentsDefaultPage_UnenrolledUser_Name_XPath_Locator,
                        rowCount)));
                        //Get the User Name
                        if (base.GetTitleAttributeValueByXPath((String.Format(
                        ManageStudentsDefaultPageResource.ManageStudentsDefaultPage_UnenrolledUser_Name_XPath_Locator,
                        rowCount))).Contains(userName))
                        {
                            getUnenrolledText = base.GetElementTextByXPath
                                (String.Format(
                            ManageStudentsDefaultPageResource.
                            ManageStudentsDefaultPage_UnenrolledText_XPath_Locator,
                            rowCount));
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageStudentsDefaultPage", "GetUnenrolledText",
                base.IsTakeScreenShotDuringEntryExit);
            return getUnenrolledText.Trim();
        }

        /// <summary>
        /// Click Cmenu of the user listed in Class roaster frame
        /// </summary>
        /// <param name="cmenuOption">This is the Cmenu option name.</param>
        /// <param name="userData">This is the user type.</param>
        public void ClickUserCmenuInManageRoaster(string cmenuOption, User.UserTypeEnum userData)
        {
            logger.LogMethodEntry("ManageStudentsDefaultPage", "ClickUserCmenuInManageRoaster",
                base.IsTakeScreenShotDuringEntryExit);
            // Get the user details from the user type enum
            User userDetails = User.Get(userData);
            string userName = userDetails.Name.ToString();
            string firstName = userDetails.FirstName.ToString();
            string lastName = userDetails.LastName.ToString();
            string getUsername;
            this.SelectManageStudentsWindow();
            base.WaitForElement(By.Id(GBRosterGridUXPageResource.
                GBRosterGridUX_Page_Frame_Id_Locator));
            //Switch to iframe
            base.SwitchToIFrameById(GBRosterGridUXPageResource.
                GBRosterGridUX_Page_Frame_Id_Locator);
            //Get users count
            int getEnrolledUsersCount = base.GetElementCountByXPath(GBRosterGridUXPageResource.
                GBRosterGridUX_Page_UserListTable_Xpath_Locator);
            for (int initialCount = 1; initialCount <= getEnrolledUsersCount;
                initialCount++)
            {
                //Fetch enrolled user name
                getUsername = base.GetWebElementPropertiesByXPath(string.Format(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_EnrolledUserName_Xpath_Locator, initialCount)).GetAttribute("title");
                if (userName.Equals(getUsername))
                {
                    // Click user cmenu option
                    IWebElement userNameProperty = base.GetWebElementPropertiesByXPath(
                        string.Format(GBRosterGridUXPageResource.GBRosterGridUX_Page_Username_Mouseover_Xpath_Locator, 
                        initialCount));
                    base.PerformMouseHoverByJavaScriptExecutor(userNameProperty);
                    IWebElement cmenuIconProperty = base.GetWebElementPropertiesByXPath(
                        string.Format(GBRosterGridUXPageResource.GBRosterGridUX_Page_Username_CmenuImg_Xpath_Locator, initialCount));
                    base.ClickByJavaScriptExecutor(cmenuIconProperty);
                    base.ClickLinkByPartialLinkText(cmenuOption);
                    break;
                }
            }
            logger.LogMethodExit("ManageStudentsDefaultPage", "ClickUserCmenuInManageRoaster",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click Cmenu of the user listed in ManageOrganization popup
        /// </summary>
        /// <param name="cmenuOption">This is the Cmenu option name.</param>
        /// <param name="userData">This is the user type.</param>
        public void ClickUserCmenuInManageOrganizationPopup(string cmenuOption, User.UserTypeEnum userData)
        {
            logger.LogMethodEntry("ManageStudentsDefaultPage", "ClickUserCmenuInManageOrganizationPopup",
                base.IsTakeScreenShotDuringEntryExit);
            // Get the user details from the user type enum
            User userDetails = User.Get(userData);
            string userName = userDetails.Name.ToString();
            string firstName = userDetails.FirstName.ToString();
            string lastName = userDetails.LastName.ToString();
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

            if (userName.Equals(getUserName))
                {
                    bool jas1 = base.IsElementPresent(By.XPath("//table[@id='grdSCLCourse']/tbody/tr/td[2]/table/tbody/tr/td"), 10);
                    IWebElement hoverOnUserName = base.GetWebElementPropertiesByXPath("//table[@id='grdSCLCourse']/tbody/tr/td[2]/table/tbody/tr/td");
                    base.MouseOverByJavaScriptExecutor(hoverOnUserName);
                    bool jha = base.IsElementPresent(By.XPath("//table[@id='grdSCLCourse']/tbody/tr/td[2]/table/tbody/tr/td[2]/center/img"), 10);
                    IWebElement hoverOnUserNameCmenu = base.GetWebElementPropertiesByXPath("//table[@id='grdSCLCourse']/tbody/tr/td[2]/table/tbody/tr/td[2]/center/img");
                    base.ClickByJavaScriptExecutor(hoverOnUserNameCmenu);
                    bool jjkas = base.IsElementPresent(By.PartialLinkText("Manage User Information"),10);
                    IWebElement selectCmenuOption = base.GetWebElementPropertiesByPartialLinkText("Manage User Information");
                    base.ClickByJavaScriptExecutor(selectCmenuOption);
                }
            logger.LogMethodExit("ManageStudentsDefaultPage", "ClickUserCmenuInManageOrganizationPopup",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select Enrollment Window.
        /// </summary>
        private void SelectManageStudentsWindow()
        {
            //Select Manage students Window
            logger.LogMethodEntry("ManageStudentsDefaultPage", "SelectEnrollmentWindow",
                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for window to load
            base.WaitUntilWindowLoads(GBRosterGridUXPageResource.
                GBRosterGridUX_Page_ManageRoster_Window_Title);
            base.WaitForElement(By.Id("ManageRosterTab"));
            Thread.Sleep(2000);
            //Select the window
            base.SelectWindow(GBRosterGridUXPageResource.
                GBRosterGridUX_Page_ManageRoster_Window_Title);
            //Switch to parent iframe
            base.SwitchToIFrameById(GBRosterGridUXPageResource.GBRosterGridUX_Page_ContainerFrame_Id_Locator);
            logger.LogMethodExit("ManageStudentsDefaultPage", "SelectEnrollmentWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
