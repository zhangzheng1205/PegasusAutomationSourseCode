using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Enrollment;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Users;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Program Admin Manage Users Page Actions
    /// </summary>
    public class ProgramAdminManageUsersPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.
            GetInstance(typeof(ProgramAdminManageUsersPage));

        /// <summary>
        /// Search user
        /// </summary>
        /// <param name="username">This is Username</param>
        public void SearchUser(string username)
        {
            //Search User 
            logger.LogMethodEntry("ProgramAdminManageUsersPage", "SearchUser",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Selecting Default Page
                base.SwitchToDefaultPageContent();                
                //Select top frame
                new ProgramAdminToolPage().SelectFrame();
                //Select Left Frame
                SelectLeftFrame();
                //Click search link
                ClickSearchLink();
                //Select Default window
                base.SelectWindow(ProgramAdminUsersPageResource
                    .ProgramAdminUsers_Page_Window_Title_Name);
                //Select top frame
                new ProgramAdminToolPage().SelectFrame();
                //Selecting the contians value in Drop down
                SelectUserNameRadioButton();
                //Enter username search textbox field
                EnterUserNameInSearchTextField(username);
                //Click search button
                ClickSearchButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProgramAdminManageUsersPage", "SearchUser",
               base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Extract method of search user for Clicking on Search Button
        /// </summary>
        private void ClickSearchButton()
        {
            //Clicking on Search Button
            logger.LogMethodEntry("ProgramAdminManageUsersPage", "ClickSearchButton",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ProgramAdminManageUsersPageResource.
                                          ProgramAdminManageUsers_Page_Search_Button_Id_Locator));
            //Click search link
            base.ClickButtonById(ProgramAdminManageUsersPageResource.
                                     ProgramAdminManageUsers_Page_Search_Button_Id_Locator);
            logger.LogMethodExit("ProgramAdminManageUsersPage", "ClickSearchButton",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Extract method of search user for Entering username in search textbox
        /// </summary>
        /// <param name="username">This is Username</param>
        private void EnterUserNameInSearchTextField(string username)
        {
            //Entering username is search textbox
            logger.LogMethodEntry("ProgramAdminManageUsersPage", "EnterUserNameInSearchTextField",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ProgramAdminManageUsersPageResource.
                                          ProgramAdminManageUsers_Page_UserDetail_TextBox_Id_Locator));
            // Enter username search textbox field
            base.ClearTextById(ProgramAdminManageUsersPageResource.
                                   ProgramAdminManageUsers_Page_UserDetail_TextBox_Id_Locator);
            //Enter Username in Text Box
            base.FillTextBoxById(ProgramAdminManageUsersPageResource.
                                     ProgramAdminManageUsers_Page_UserDetail_TextBox_Id_Locator, username);
            logger.LogMethodExit("ProgramAdminManageUsersPage", "EnterUserNameInSearchTextField",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Extract method of search user for selecting usrname radio button
        /// </summary>
        private void SelectUserNameRadioButton()
        {
            // Search user for selecting the contains value in Drop down
            logger.LogMethodEntry("ProgramAdminManageUsersPage", "SelectContainsValueInDropDown",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ProgramAdminManageUsersPageResource.
                 ProgramAdminManageUsers_Page_SearchCondition_DropDown_Id_Locator));
            // select username radio button
            base.ClickButtonById(ProgramAdminManageUsersPageResource
                 .ProgramAdminManageUsers_Page_UserNameRadioButton_Id_Locator);
            logger.LogMethodExit("ProgramAdminManageUsersPage", "SelectContainsValueInDropDown",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Extract method of search user for clicking the search link
        /// </summary>
        private void ClickSearchLink()
        {
            // Clicking on search link
            logger.LogMethodEntry("ProgramAdminManageUsersPage", "ClickSearchLink",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(ProgramAdminManageUsersPageResource.
                ProgramAdminManageUsers_Page_Search_Link_Locator));
            // click search link
            base.ClickButtonByPartialLinkText(ProgramAdminManageUsersPageResource.
                ProgramAdminManageUsers_Page_Search_Link_Locator);
            logger.LogMethodExit("ProgramAdminManageUsersPage", "ClickSearchLink",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Extract method of search user for selecting Left Frame
        /// </summary>
        private void SelectLeftFrame()
        {
            // Select Left Frame
            logger.LogMethodEntry("ProgramAdminManageUsersPage", "SelectLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
            // selecting Left Frame
            base.WaitForElement(By.Id(ProgramAdminManageUsersPageResource.
                ProgramAdminManageUsers_Page_LeftFrame_Id_Locator));
            base.SwitchToIFrame(ProgramAdminManageUsersPageResource.
                ProgramAdminManageUsers_Page_LeftFrame_Id_Locator);
            logger.LogMethodExit("ProgramAdminManageUsersPage", "SelectLeftFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Get searched user Text.
        /// </summary>
        /// <returns>search user result</returns>
        public string GetSearchedUser()
        {
            //Search User Present
            logger.LogMethodEntry("ProgramAdminManageUsersPage", "GetSearchedUser",
                base.isTakeScreenShotDuringEntryExit);
            //Initialized User Name Variable
            string getUserName = string.Empty;
            try
            {                
                //select top frame
                new ProgramAdminToolPage().SelectFrame();
                //select Left Frame
                base.WaitForElement(By.Id(ProgramAdminManageUsersPageResource.
                    ProgramAdminManageUsers_Page_LeftFrame_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(ProgramAdminManageUsersPageResource.
                    ProgramAdminManageUsers_Page_LeftFrame_Id_Locator);
                //get the username text   
                getUserName =
                    base.GetTitleAttributeValueByXPath(ProgramAdminManageUsersPageResource.
                            ProgramAdminManageUsers_Page_SearchedUserName_Title_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProgramAdminManageUsersPage", "GetSearchedUser",
                base.isTakeScreenShotDuringEntryExit);
            return getUserName;
        }

        /// <summary>
        /// Check To SelectAll Users
        /// </summary>
        public void SelectAllUser()
        {
            //Select All the CheckBox
            logger.LogMethodEntry("ProgramAdminManageUsersPage", "SelectAllUser",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Check SelectAll CheckBox
                base.SelectCheckBoxById(ProgramAdminManageUsersPageResource.
                    ProgramAdminManageUsers_Page_SelectAllUsers_CheckBox_Id_Locator);
                //Switch To Default Page
                base.SelectWindow(ProgramAdminUsersPageResource
                    .ProgramAdminUsers_Page_Window_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProgramAdminManageUsersPage", "SelectAllUser",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
