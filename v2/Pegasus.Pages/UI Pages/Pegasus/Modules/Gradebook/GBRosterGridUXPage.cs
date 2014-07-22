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
                base.isTakeScreenShotDuringEntryExit);
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
                base.FocusOnElementByID(GBRosterGridUXPageResource.
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Success Message
        /// </summary>
        /// <returns>This is Success Message</returns>
        public string GetSuccessMessage()
        {
            //Get Success Message
            logger.LogMethodEntry("GBRosterGridUXPage", "GetSuccessMessage",
                  base.isTakeScreenShotDuringEntryExit);
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
                  base.isTakeScreenShotDuringEntryExit);
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
                  base.isTakeScreenShotDuringEntryExit);
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
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Grant TA Privileges Cmenu
        /// </summary>
        /// <param name="setRowCount">This is user row count</param>
        private void SelectGrantTAPrivilegesCmenu(int setRowCount)
        {
            //Select Grant TA Privileges Cmenu
            logger.LogMethodEntry("GBRosterGridUXPage", "SelectGrantTAPrivilegesCmenu",
                  base.isTakeScreenShotDuringEntryExit);           
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
                  base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select Enrollment Window
        /// </summary>
        private void SelectEnrollmentWindow()
        {
            //Select Enrollment Window
            logger.LogMethodEntry("GBRosterGridUXPage", "SelectEnrollmentWindow",
                  base.isTakeScreenShotDuringEntryExit);
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
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get User Role Name
        /// </summary>
        /// <returns>User role</returns>
        public String GetUserRoleName()
        {
            //Select Enrollment Window
            logger.LogMethodEntry("GBRosterGridUXPage", "GetUserRoleName",
                  base.isTakeScreenShotDuringEntryExit);
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
                  base.isTakeScreenShotDuringEntryExit);
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
                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Fetch the user details from Memory
                User user = User.Get(userStudentType);
                Guid studentName = Guid.Parse(user.Name);
                //Store Teaching Assistent User details In Memory
                new Reg1Page().StoreSMSUserInMemory(userTeacherAssistentType, studentName,
                    GBRosterGridUXPageResource.GBRosterGridUX_Page_TeachingAssistent_Password);
                Thread.Sleep(Convert.ToInt32(GBRosterGridUXPageResource.
                    GBRosterGridUX_Page_UserRole_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRosterGridUXPage", "StoreTheTADetailsInMemory",
                  base.isTakeScreenShotDuringEntryExit);
        }
    }
}
