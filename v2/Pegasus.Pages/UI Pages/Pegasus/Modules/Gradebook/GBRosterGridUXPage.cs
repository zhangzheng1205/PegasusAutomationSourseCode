using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    // <summary>
    /// This Class Handles GBRosterGridUX Page Actions
    /// </summary>
    public class GBRosterGridUXPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(GBRosterGridUXPage));

        /// <summary>
        /// Click on Create New Button to Create User
        /// </summary>
        public void ClickonCreateNewButtonToCreateUser()
        {
            //Click on Create New Button to Create User
            logger.LogMethodEntry("GBRosterGridUXPage", "ClickonCreateNewButtonToCreateUser",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.SelectWindow(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_Window_Title);
                //Wait for element
                base.WaitForElement(By.Id(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_Frame_Id_Locator));
                //Switch to frame
                base.SwitchToIFrame(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_Frame_Id_Locator);
                base.WaitForElement(By.PartialLinkText(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_CreateNewButton_PartialLinkText));
                //Get element property
                IWebElement getCreateNewButton = base.GetWebElementPropertiesByPartialLinkText
                    (GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_CreateNewButton_PartialLinkText);
                //Click on Create New button
                base.ClickByJavaScriptExecutor(getCreateNewButton);
                base.WaitForElement(By.Id(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_Student_Id_Locator));
                base.FocusOnElementById(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_Student_Id_Locator);
                //Get element property
                IWebElement getStudentOption = base.GetWebElementPropertiesById
                    (GBRosterGridUXPageResource.GBRosterGridUX_Page_Student_Id_Locator);
                //Click on student option
                base.ClickByJavaScriptExecutor(getStudentOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRosterGridUXPage", "ClickonCreateNewButtonToCreateUser",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Success Message
        /// </summary>
        /// <returns>This is Success Message</returns>
        public string GetSuccessMessage()
        {
            //Get Success Message
            logger.LogMethodEntry("GBRosterGridUXPage", "GetSuccessMessage",
                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSuccessMessage = string.Empty;
            try
            {
                //Wait for the window loades
                base.WaitUntilWindowLoads(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_ManageRoster_Window_Title);
                base.SelectWindow(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_ManageRoster_Window_Title);                
                //Get Success Message From Application
                getSuccessMessage = base.GetElementTextByXPath(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_ManageRoster_Message_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRosterGridUXPage", "GetSuccessMessage",
                  base.IsTakeScreenShotDuringEntryExit);
            return getSuccessMessage;
        }

        /// <summary>
        ///Click Roster Cmenu In SMSInstructor
        /// </summary>
        /// <param name="userName">This is User type</param>
        public void ClickRosterCmenuInSMSInstructor(string userName)
        {
            //Click Roster Cmenu In SMSInstructor
            logger.LogMethodEntry("GBRosterGridUXPage", "ClickRosterCmenuInSMSInstructor",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Enrollment Window
                this.SelectEnrollmentWindow();
                base.WaitForElement(By.XPath(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_User_Count_Xpath_Locator));
                //Getting the counts of Users
                int getUserCount = base.GetElementCountByXPath(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_User_Count_Xpath_Locator);
                for (int setRowCount = Convert.ToInt32(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_Loop_Initializer_Value); 
                    setRowCount <= getUserCount; setRowCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(GBRosterGridUXPageResource.
                      GBRosterGridUX_Page_Username_Xpath_Locator, setRowCount)));
                    //Getting the User name
                    string getUserName = base.GetTitleAttributeValueByXPath
                      (string.Format(GBRosterGridUXPageResource.
                      GBRosterGridUX_Page_Username_Xpath_Locator, setRowCount));
                    if (getUserName == userName)
                    {
                        //Select Grant TA Privileges Cmenu
                        this.SelectGrantTAPrivilegesCmenu(setRowCount);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRosterGridUXPage", "ClickRosterCmenuInSMSInstructor",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Grant TA Privileges Cmenu
        /// </summary>
        /// <param name="setRowCount">This is user row count</param>
        private void SelectGrantTAPrivilegesCmenu(int setRowCount)
        {
            //Select Grant TA Privileges Cmenu
            logger.LogMethodEntry("GBRosterGridUXPage", "SelectGrantTAPrivilegesCmenu",
                  base.IsTakeScreenShotDuringEntryExit);           
            //Wait for the element
            base.WaitForElement(By.XPath(string.Format
            (GBRosterGridUXPageResource.
            GBRosterGridUX_Page_Username_Mouseover_Xpath_Locator, setRowCount)));
            IWebElement getStudentName = base.GetWebElementPropertiesByXPath
                (string.Format(GBRosterGridUXPageResource.
            GBRosterGridUX_Page_Username_Mouseover_Xpath_Locator, setRowCount));
            //Perform mouse over action
            base.PerformMouseHoverAction(getStudentName);
            //Wait for the element
            base.WaitForElement(By.XPath(string.Format
           (GBRosterGridUXPageResource.
           GBRosterGridUX_Page_Username_CmenuImg_Xpath_Locator, setRowCount)));
            base.FillEmptyTextByXPath(string.Format
           (GBRosterGridUXPageResource.
           GBRosterGridUX_Page_Username_CmenuImg_Xpath_Locator, setRowCount));           
            //Get web element for Cmenu img
            IWebElement getCmenuImg = base.GetWebElementPropertiesByXPath
                (string.Format(GBRosterGridUXPageResource.
            GBRosterGridUX_Page_Username_CmenuImg_Xpath_Locator, setRowCount));
            //Click the cmenu img
            base.ClickByJavaScriptExecutor(getCmenuImg);
            //Wait for the element
            base.WaitForElement(By.PartialLinkText
                (GBRosterGridUXPageResource.
                GBRosterGridUX_Page_Username_Cmenu_Option_Xpath_Locator));
            base.FillEmptyTextByPartialLinkText(GBRosterGridUXPageResource.
                GBRosterGridUX_Page_Username_Cmenu_Option_Xpath_Locator);
            IWebElement getTACmenu = base.GetWebElementPropertiesByPartialLinkText
                (GBRosterGridUXPageResource.
                GBRosterGridUX_Page_Username_Cmenu_Option_Xpath_Locator);
            //Click th cmenu 'Grant TA Privileges' option
            base.ClickByJavaScriptExecutor(getTACmenu);
            Thread.Sleep(Convert.ToInt32(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_UserRole_Time_Value));
            logger.LogMethodExit("GBRosterGridUXPage", "SelectGrantTAPrivilegesCmenu",
                  base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select Enrollment Window
        /// </summary>
        private void SelectEnrollmentWindow()
        {
            //Select Enrollment Window
            logger.LogMethodEntry("GBRosterGridUXPage", "SelectEnrollmentWindow",
                  base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            base.WaitUntilWindowLoads(GBRosterGridUXPageResource.
                GBRosterGridUX_Page_Window_Title);
            base.SelectWindow(GBRosterGridUXPageResource.
                GBRosterGridUX_Page_Window_Title);
            base.WaitForElement(By.Id(GBRosterGridUXPageResource.
                GBRosterGridUX_Page_Frame_Id_Locator));
            //Switch to frame
            base.SwitchToIFrame(GBRosterGridUXPageResource.
                GBRosterGridUX_Page_Frame_Id_Locator);
            logger.LogMethodExit("GBRosterGridUXPage", "SelectEnrollmentWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get User Role Name
        /// </summary>
        /// <returns>User role</returns>
        public String GetUserRoleName()
        {
            //Select Enrollment Window
            logger.LogMethodEntry("GBRosterGridUXPage", "GetUserRoleName",
                  base.IsTakeScreenShotDuringEntryExit);
            //Initialized User role Text
            string getUserRole = string.Empty;
            try
            {
                //Select Enrollment Window
                this.SelectEnrollmentWindow();
                //Wait for Element
                base.WaitForElement(By.XPath(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_UserRole_Title_Xpath_Locator));
                getUserRole = base.GetElementTextByXPath(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_UserRole_Title_Xpath_Locator);              
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRosterGridUXPage", "GetUserRoleName",
                  base.IsTakeScreenShotDuringEntryExit);
            return getUserRole;
        }

        /// <summary>
        ///Store The TA Details In Memory
        /// </summary>
        /// <param name="userStudentType"></param>
        /// <param name="userTeacherAssistentType"></param>
        public void StoreTheTADetailsInMemory(User.UserTypeEnum userStudentType,
            User.UserTypeEnum userTeacherAssistentType)
        {
            //Store The TA Details In Memory
            logger.LogMethodEntry("GBRosterGridUXPage", "StoreTheTADetailsInMemory",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Fetch the user details from Memory
                User user = User.Get(userStudentType);
                Guid studentName = Guid.Parse(user.Name);
                //Store Teaching Assistent User details In Memory
                new Reg1Page().StoreSmsUserInMemory(userTeacherAssistentType, studentName,
                    GBRosterGridUXPageResource.GBRosterGridUX_Page_TeachingAssistent_Password);
                Thread.Sleep(Convert.ToInt32(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_UserRole_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRosterGridUXPage", "StoreTheTADetailsInMemory",
                  base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on Create new button.
        /// </summary>
        public void ClickOnCreateNewButton()
        {
            //Click on create new button
            logger.LogMethodEntry("GBRosterGridUXPage", "ClickOnCreateNewButton",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectManageStudentsWindow();
                base.WaitForElement(By.Id(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_Frame_Id_Locator));
                //Switch to iframe
                base.SwitchToIFrameById(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_Frame_Id_Locator);
                base.WaitForElement(By.PartialLinkText(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_CreateNewButton_PartialLinkText));
                //Get element property
                IWebElement getCreateNewButton = base.GetWebElementPropertiesByPartialLinkText
                    (GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_CreateNewButton_PartialLinkText);
                //Click on Create New button
                base.ClickByJavaScriptExecutor(getCreateNewButton);
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRosterGridUXPage", "ClickOnCreateNewButton",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Enrollment Window.
        /// </summary>
        private void SelectManageStudentsWindow()
        {
            //Select Manage students Window
            logger.LogMethodEntry("GBRosterGridUXPage", "SelectEnrollmentWindow",
                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for window to load
            base.WaitUntilWindowLoads(GBRosterGridUXPageResource.
                GBRosterGridUX_Page_ManageRoster_Window_Title);
            //Select the window
            base.SelectWindow(GBRosterGridUXPageResource.
                GBRosterGridUX_Page_ManageRoster_Window_Title);
            //Switch to parent iframe
            base.SwitchToIFrameById(GBRosterGridUXPageResource.GBRosterGridUX_Page_ContainerFrame_Id_Locator);
            logger.LogMethodExit("GBRosterGridUXPage", "SelectEnrollmentWindow",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on create new drop down option in Manage students pop up.
        /// </summary>
        /// <param name="dropDownValue">Drop down option to click.</param>
        public void SelectOptionsUnderCreateNewDropDown(string dropDownValue)
        {
            //Click on drop down option
            logger.LogMethodEntry("GBRosterGridUXPage", "SelectOptionsUnderCreateNewDropDown",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the drop down option counts
                int getCreateNewDropDownValuesCount = base.GetElementCountByXPath(
                GBRosterGridUXPageResource.
                GBRosterGridUX_Page_CreateNew_DropDownOption_Count_Xpath_Locator);
                for (int i = 1; i <= getCreateNewDropDownValuesCount; i++)
                {
                    //Get drop down option text
                    string getCreateNewDropValuesText = base.GetElementTextByXPath(
                    string.Format(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_CreateNew_DropDownOption_Text_Xpath_Locator, i)).Trim();
                    if (dropDownValue.Equals(getCreateNewDropValuesText))
                    {
                        //Click on drop down option
                        IWebElement getCreateNewDropDownValueProperty = base.GetWebElementPropertiesByXPath
                            (string.Format(GBRosterGridUXPageResource.
                        GBRosterGridUX_Page_CreateNew_DropDownOption_Text_Xpath_Locator, i));
                        base.ClickByJavaScriptExecutor(getCreateNewDropDownValueProperty);
                        break;
                    }
                }
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRosterGridUXPage", "SelectOptionsUnderCreateNewDropDown",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on close button in manage students pop up.
        /// </summary>
        public void ClickOnCloseButton()
        {
            //Click on close button
            logger.LogMethodEntry("GBRosterGridUXPage", "ClickOnCloseButton",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on close button
                base.ClickButtonById(GBRosterGridUXPageResource.
                GBRosterGridUX_Page_CloseButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRosterGridUXPage", "ClickOnCloseButton",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check whether student displayed or not.
        /// </summary>
        /// <param name="username">User name to validate.</param>
        /// <returns></returns>
        public bool IsEnrolledStudentDisplayedUnderRoster(string username)
        {

            logger.LogMethodEntry("GBRosterGridUXPage", "IsEnrolledStudentDisplayedUnderRoster",
                  base.IsTakeScreenShotDuringEntryExit);
            Thread.Sleep(10000);
            string getUsername;
            bool isUserEnrolled = false;
            //Select manage students window
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
                if (username.Equals(getUsername))
                {
                    //If user name found then set the variable to true
                    isUserEnrolled = true;
                    base.SwitchToDefaultPageContent();
                    break;
                }

            }
            logger.LogMethodExit("GBRosterGridUXPage", "IsEnrolledStudentDisplayedUnderRoster",
                  base.IsTakeScreenShotDuringEntryExit);
            return isUserEnrolled;
        }
    }
}
