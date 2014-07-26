using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the code of enrollment use case of left frame
    /// </summary>
    public class OrgAdminUserEnrollmentPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(OrgAdminUserEnrollmentPage));

        /// <summary>
        /// Select the user in the left frame
        /// </summary>
        /// <param name="userName">This is the user name</param>
        public void SelectUserInLeftFrame(string userName)
        {
            //Select the user from left frame
            logger.LogMethodEntry("OrgAdminUserEnrollmentPage", "SelectUserInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Select default window and switch to main frame
                base.SelectWindow(OrgAdminUserEnrollmentPageResource
                    .OrgAdminUserEnrollment_Page_WindowName_Title);
                base.SwitchToIFrame(OrgAdminUserEnrollmentPageResource
                    .OrgAdminUserEnrollment_Page_MainFrame_Id_Locator);
                // Switch to left frame
                base.SwitchToIFrame(OrgAdminUserEnrollmentPageResource
                    .OrgAdminUserEnrollment_Page_LeftFrame_Id_Locator);
                // Click on the advanced button
                base.WaitForElement(By.Id(OrgAdminUserEnrollmentPageResource
                    .OrgAdminUserEnrollment_Page_AdvancedButton_Id_Locator));
                base.ClickButtonById(OrgAdminUserEnrollmentPageResource
                    .OrgAdminUserEnrollment_Page_AdvancedButton_Id_Locator);
                // Search the user name
                SearchUserName(userName);
                // Search the user name check box
                SelectUserNameCheckbox();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Select the user from left frame
            logger.LogMethodExit("OrgAdminUserEnrollmentPage", "SelectUserInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the user name check box
        /// </summary>
        private void SelectUserNameCheckbox()
        {
            // Select the searched user
            logger.LogMethodEntry("OrgAdminUserEnrollmentPage", "SelectUserNameCheckbox",
               base.isTakeScreenShotDuringEntryExit);
            // Search for the user name checkbox and click
            base.WaitForElement(By.Id(OrgAdminUserEnrollmentPageResource
                   .OrgAdminUserEnrollment_Page_UserNameCheckbox_Id_Locator));
            base.ClickButtonById(OrgAdminUserEnrollmentPageResource
                .OrgAdminUserEnrollment_Page_UserNameCheckbox_Id_Locator);
            //Switch to default content
            base.SwitchToDefaultPageContent();
            // Select the searched user
            logger.LogMethodExit("OrgAdminUserEnrollmentPage", "SelectUserNameCheckbox",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the user name after advanced search
        /// </summary>
        /// <param name="userName">This is the user name</param>
        private void SearchUserName(string userName)
        {
            //Search the user from advanced search
            logger.LogMethodEntry("OrgAdminUserEnrollmentPage", "SearchUserName",
               base.isTakeScreenShotDuringEntryExit);
            // Wait for the user name text box and click
            base.WaitForElement(By.Id(OrgAdminUserEnrollmentPageResource
                    .OrgAdminUserEnrollment_Page_UserNameTextbox_Id_Locator));
            base.FillTextBoxById(OrgAdminUserEnrollmentPageResource
                .OrgAdminUserEnrollment_Page_UserNameTextbox_Id_Locator, userName);
            //Wait for search button and click 
            base.WaitForElement(By.Id(OrgAdminUserEnrollmentPageResource
                .OrgAdminUserEnrollment_Page_SearchButton_Id_Locator));
            base.ClickButtonById(OrgAdminUserEnrollmentPageResource
                .OrgAdminUserEnrollment_Page_SearchButton_Id_Locator);
            //Search the user from advanced search
            logger.LogMethodExit("OrgAdminUserEnrollmentPage", "SearchUserName",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks On The 'Create Users' Link
        /// </summary>
        public void ClickOnTheCreateUsersLink()
        {
            //Click on the Create Users Link
            logger.LogMethodEntry("OrgAdminUserEnrollmentPage", "ClickOnTheCreateUsersLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Clicks on the Enrollment Tab
                new ManageOrganisationToolBarPage().ClickOnEnrollmentTab();
                //Select Left Frame
                this.SelectLeftFrame();
                //Click on the Create Users Link
                base.WaitForElement(By.Id(OrgAdminUserEnrollmentPageResource.
                        OrgAdminUserEnrollment_Page_CreateUsers_Link_Id_Locator));
                IWebElement getCreateUsersLink = base.GetWebElementPropertiesById
                    (OrgAdminUserEnrollmentPageResource.
                        OrgAdminUserEnrollment_Page_CreateUsers_Link_Id_Locator);
                base.ClickByJavaScriptExecutor(getCreateUsersLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrgAdminUserEnrollmentPage", "ClickOnTheCreateUsersLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search User In Enrollment Sub Tab
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        public void SearchUserInEnrollmentSubTab(User.UserTypeEnum userTypeEnum)
        {
            //Search User In Enrollment Sub Tab
            logger.LogMethodEntry("OrgAdminUserEnrollmentPage", "SearchUserInEnrollmentSubTab",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Left Frame
                this.SelectLeftFrame();
                // Click on the advanced button
                base.WaitForElement(By.Id(OrgAdminUserEnrollmentPageResource
                    .OrgAdminUserEnrollment_Page_AdvancedButton_Id_Locator));
                base.ClickButtonById(OrgAdminUserEnrollmentPageResource
                    .OrgAdminUserEnrollment_Page_AdvancedButton_Id_Locator);
                //Get User From Memory
                User user = User.Get(userTypeEnum);
                //Search the User Name
                this.SearchUserName(user.Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrgAdminUserEnrollmentPage", "SearchUserInEnrollmentSubTab",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Searched User Name in Enrollment tab
        /// </summary>
        /// <returns>Searched User Name Result</returns>
        public String GetSearchedUserInEnrollmentSubTab()
        {
            //Get the Searched User Name in Enrollment tab
            logger.LogMethodEntry("OrgAdminUserEnrollmentPage", "GetSearchedUserInEnrollmentSubTab",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the variable getUserName
            string getUserName = string.Empty;
            try
            {
                //Select the Frame
                this.SelectLeftFrame();
                //Select the Username table
                base.WaitForElement(By.Id(OrgAdminUserEnrollmentPageResource.
                    OrgAdminUserEnrollment_Page_Searched_Table_Id_Locator));
                //Get the user name
                getUserName = base.GetTitleAttributeValueByXPath(OrgAdminUserEnrollmentPageResource.
                    OrgAdminUserEnrollment_Page_Searched_UserName_Xpath_Locator);
                //Split the user name by space
                string[] arr = getUserName.Split(Convert.ToChar(OrgAdminUserEnrollmentPageResource.
                    OrgAdminUserEnrollment_Page_Split_Searched_UserName_ByCharacter_Value));
                //Get the actual user name
                getUserName = arr[Convert.ToInt32(OrgAdminUserEnrollmentPageResource.
                    OrgAdminUserEnrollment_Page_Searched_UserName_Index_Value)];
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrgAdminUserEnrollmentPage", "GetSearchedUserInEnrollmentSubTab",
                base.isTakeScreenShotDuringEntryExit);
            return getUserName;
        }

        /// <summary>
        /// Select the Frame
        /// </summary>
        private void SelectLeftFrame()
        {
            //Select the Frame
            logger.LogMethodEntry("OrgAdminUserEnrollmentPage", "SelectLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Select Manage Organization window
            base.SelectWindow(OrgAdminUserEnrollmentPageResource
                .OrgAdminUserEnrollment_Page_WindowName_Title);
            //Select the Main Frame
            base.SwitchToIFrame(OrgAdminUserEnrollmentPageResource.
                OrgAdminUserEnrollment_Page_MainFrame_Id_Locator);
            //Select the Left Frame
            base.SwitchToIFrame(OrgAdminUserEnrollmentPageResource.
                OrgAdminUserEnrollment_Page_LeftFrame_Id_Locator);
            logger.LogMethodExit("OrgAdminUserEnrollmentPage", "SelectLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

       /// <summary>
        /// Get Successfull message on the enrollment screen
       /// </summary>
       /// <returns>Successfull message text</returns>
        public String GetSuccessfulMessageText()
        {
            //Get Successfull message on the enrollment window
            logger.LogMethodEntry("OrgAdminUserEnrollmentPage", "GetSuccessfulMessageText",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the variable getSuccessMessage
            string getSuccessMessage = string.Empty;
            try
            {
                //Select Manage Organization window
                base.SelectWindow(OrgAdminUserEnrollmentPageResource
                    .OrgAdminUserEnrollment_Page_WindowName_Title);
                base.WaitForElement(By.ClassName(OrgAdminUserEnrollmentPageResource
                .OrgAdminUserEnrollment_Page_SuccessMsg_ClassName));
                //Get the successfull message shown on the enrollment window
                getSuccessMessage = base.WebDriver.FindElement
                    (By.ClassName(OrgAdminUserEnrollmentPageResource
                .OrgAdminUserEnrollment_Page_SuccessMsg_ClassName)).Text;
            }
            catch ( Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrgAdminUserEnrollmentPage", "GetSuccessfulMessageText",
                 base.isTakeScreenShotDuringEntryExit);
            return getSuccessMessage;
        }


    }
}
