using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Enrollment Page Actions
    /// </summary>
    public class EnrollmentPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(EnrollmentPage));

        /// <summary>
        /// Select Enroll Button
        /// </summary>
        public void ClickEnrollButton()
        {
            //Click Enroll Button
            logger.LogMethodEntry("EnrollmentPage", "ClickEnrollButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Switch to Middle Frame
                base.WaitForElement(By.Id(EnrollmentPageResource.
                    Enrollment_Page_MiddleFrame_Id_Locator));
                base.SwitchToIFrame(EnrollmentPageResource.
                    Enrollment_Page_MiddleFrame_Id_Locator);
                base.WaitForElement(By.Id(EnrollmentPageResource.
                    Enrollment_Page_EnrollButton_Id_Locator));
                IWebElement getEnrollButton = base.GetWebElementPropertiesById
                    (EnrollmentPageResource.
                    Enrollment_Page_EnrollButton_Id_Locator);
                // Click On The Enroll Button
                base.ClickByJavaScriptExecutor(getEnrollButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EnrollmentPage", "ClickEnrollButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Promoted Workspace Admin Name
        /// </summary>
        /// <param name="userName">This is promoted user name</param>
        /// <returns>Promoted Workspace Admin Name</returns>
        public String GetPromotedWorkspaceAdminName(string userName)
        {
            //Get Promoted Workspace Admin Name
            logger.LogMethodEntry("EnrollmentPage", "GetPromotedWorkspaceAdminName",
                base.isTakeScreenShotDuringEntryExit);
            //Variable Declaration of User
            string getUserName = string.Empty;
            try
            {
                //Select Administrator Right Frame
                this.SelectAdministratorRightFrame();               
                //Get Promoted User's Row Counts 
                int count = base.GetElementCountByXPath(EnrollmentPageResource.
                    Enrollment_Page_EnrolledUser_Rowcount_Xpath_Locator);
                for (int setRowCount = 1; setRowCount <= count; setRowCount++)
                {
                    if (base.IsElementPresent(By.XPath(string.Format(EnrollmentPageResource.
                        Enrollment_Page_EnrolledUser_Xpath_Locator,setRowCount)))) 
                    {
                        //Get the user name text
                        getUserName = base.GetTitleAttributeValueByXPath
                            (string.Format(EnrollmentPageResource.
                        Enrollment_Page_EnrolledUser_Xpath_Locator, setRowCount));                       
                        if (getUserName == userName)
                        {
                            break;
                        }
                    }
                }               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EnrollmentPage", "GetPromotedWorkspaceAdminName",
                base.isTakeScreenShotDuringEntryExit);
            return getUserName;
        }
       
        /// <summary>
        /// Search The Promoted Admin
        /// </summary>
        /// <param name="userName">This is Promoted user name</param>
        /// <param name="userTypeEnum">This is User type by enum</param>
        public void SearchThePromotedAdmin(string userName, User.UserTypeEnum userTypeEnum)
        {
            //Search The Promoted Admin
            logger.LogMethodEntry("EnrollmentPage", "SearchThePromotedAdmin",
               base.isTakeScreenShotDuringEntryExit);
            //Intialize the promoted user name
            string getPromotedUserName = userName.Substring(
               Convert.ToInt32(EnrollmentPageResource.
               Enrollment_Page_PromotedUser_Substring_StartValue),
               Convert.ToInt32(EnrollmentPageResource.
               Enrollment_Page_PromotedUser_Substring_SecondValue));               
            try
            {                
                //Select Administrator Right Frame
                this.SelectAdministratorRightFrame();
                //Initialized Variable
                string getTableText = string.Empty;
                do
                {
                    //Get the table text
                    getTableText = base.GetElementTextById(EnrollmentPageResource.
                        Enrollment_Page_promotedUserTable_Id_Locator);
                    if (!getTableText.Contains(getPromotedUserName))
                    {
                        //Click on next button
                        base.ClickLinkById(EnrollmentPageResource.
                            Enrollment_Page_promotedUserTable_NextButton_Id_Locator);
                        //Select Administrator Right Frame
                        this.SelectAdministratorRightFrame();
                    }                    
                }
                while (!getTableText.Contains(getPromotedUserName));
                //Search The Promoted User In Administrator Tab
                this.SearchThePromotedUserInAdministratorTab(userName, userTypeEnum);               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EnrollmentPage", "SearchThePromotedAdmin",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The Promoted User In Administrator Tab
        /// </summary>
        /// <param name="userName">This is Promoted User name</param>
        /// <param name="userTypeEnum">This is User type by enum</param>
        private void SearchThePromotedUserInAdministratorTab(
            string userName, User.UserTypeEnum userTypeEnum)
        {
            //Search The Promoted User In Administrator Tab
            logger.LogMethodEntry("EnrollmentPage", "SearchThePromotedUserInAdministratorTab",
              base.isTakeScreenShotDuringEntryExit);
            //Get Promoted User's Row Counts 
            int count = base.GetElementCountByXPath(EnrollmentPageResource.
                Enrollment_Page_EnrolledUser_Rowcount_Xpath_Locator);
            for (int setRowCount = 1; setRowCount <= count; setRowCount++)
            {
                if (base.IsElementPresent(By.XPath(string.Format(EnrollmentPageResource.
                    Enrollment_Page_EnrolledUser_Xpath_Locator, setRowCount))))
                {
                    //Get the user name text
                    string getUserName = base.GetTitleAttributeValueByXPath
                        (string.Format(EnrollmentPageResource.
                    Enrollment_Page_EnrolledUser_Xpath_Locator, setRowCount));
                    if (getUserName == userName)
                    {
                        switch (userTypeEnum)
                        {
                                //CourseSpace promoted admin
                            case User.UserTypeEnum.DPCourseSpacePramotedAdmin:
                                //Click UnEnrolled Frame Image Cmenu Option
                                this.ClickUnEnrolledFrameImageCmenuOption(setRowCount);
                                break;
                            //Workspace promoted admin
                            case User.UserTypeEnum.DPWorkSpacePramotedAdmin:
                                //Click Checkbox For UnEnrolled Select User
                                this.ClickCheckboxForUnEnrolledSelectUser(setRowCount);
                                break;
                        }
                        break;
                    }
                }
            }
            logger.LogMethodExit("EnrollmentPage", "SearchThePromotedUserInAdministratorTab",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Checkbox For UnEnrolled Select User
        /// </summary>
        /// <param name="setRowCount">Enrolled User Row count</param>
        private void ClickCheckboxForUnEnrolledSelectUser(int setRowCount)
        {
            //Click Checkbox For UnEnrolled Select User
            logger.LogMethodEntry("EnrollmentPage", "ClickCheckboxForUnEnrolledSelectUser",
              base.isTakeScreenShotDuringEntryExit);
            //Wait for the selected user checkbox
            base.WaitForElement(By.XPath(string.Format(EnrollmentPageResource.
                Enrollment_Page_UnenrolledUser_Checkbox_Xpath_Locator, setRowCount)));
            base.FocusOnElementByXPath(string.Format(EnrollmentPageResource.
                Enrollment_Page_UnenrolledUser_Checkbox_Xpath_Locator, setRowCount));
            //Get web element
            IWebElement getCmenuProperty = GetWebElementPropertiesByXPath
                (string.Format(EnrollmentPageResource.
                Enrollment_Page_UnenrolledUser_Checkbox_Xpath_Locator, setRowCount));
            //Click the selected user checkbox
            base.ClickByJavaScriptExecutor(getCmenuProperty);
            logger.LogMethodExit("EnrollmentPage", "ClickCheckboxForUnEnrolledSelectUser",
               base.isTakeScreenShotDuringEntryExit);
        }       

        /// <summary>
        /// Click UnEnrolled Frame Image Cmenu Option
        /// </summary>
        /// <param name="setRowCount">Enrolled User Row count</param>
        private void ClickUnEnrolledFrameImageCmenuOption(int setRowCount)
        {
            //Click UnEnrolled Frame Image Cmenu Option
            logger.LogMethodEntry("EnrollmentPage", "ClickUnEnrolledFrameImageCmenuOption",
              base.isTakeScreenShotDuringEntryExit);           
            //Wait for the img cmenu
            base.WaitForElement(By.XPath(string.Format(EnrollmentPageResource.
                Enrollment_Page_PromotedAdmin_ImgCmenu_Xpath_Locator, setRowCount)));
            base.FocusOnElementByXPath(string.Format(EnrollmentPageResource.
                Enrollment_Page_PromotedAdmin_ImgCmenu_Xpath_Locator, setRowCount));
            //Get web element
            IWebElement getCmenuProperty = GetWebElementPropertiesByXPath
                (string.Format(EnrollmentPageResource.
                Enrollment_Page_PromotedAdmin_ImgCmenu_Xpath_Locator, setRowCount));
            //Click the img cmenu
            base.ClickByJavaScriptExecutor(getCmenuProperty);
            logger.LogMethodExit("EnrollmentPage", "ClickUnEnrolledFrameImageCmenuOption",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click UnEnroll Selected Users In WsAdmin
        /// </summary>
        public void ClickUnEnrollSelectedUsersInWsAdmin()
        {
            //Click UnEnroll Selected Users In WsAdmin
            logger.LogMethodEntry("EnrollmentPage", "ClickUnEnrollSelectedUsersInWsAdmin",
             base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Unenroll selected users link              
                base.WaitForElement(By.Id(EnrollmentPageResource.
                    Enrollment_Page_Unenroll_Id_Locator));
                //Focus on Unenroll selected users link
                base.FocusOnElementById(EnrollmentPageResource.
                    Enrollment_Page_Unenroll_Id_Locator);
                IWebElement getUnEnrolledLink = base.GetWebElementPropertiesById
                    (EnrollmentPageResource.
                    Enrollment_Page_Unenroll_Id_Locator);
                //Click the Unenroll selected users link
                base.ClickByJavaScriptExecutor(getUnEnrolledLink);
                Thread.Sleep(Convert.ToInt32(EnrollmentPageResource.
                    Enrollment_Page_UnenrolledUser_Time_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EnrollmentPage", "ClickUnEnrollSelectedUsersInWsAdmin",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Administrator Right Frame
        /// </summary>
        private void SelectAdministratorRightFrame()
        {
            //Select Administrator Right Frame
            logger.LogMethodEntry("EnrollmentPage", "SelectAdministratorRightFrame",
               base.isTakeScreenShotDuringEntryExit);
            //Select the window
            base.SelectWindow(EnrollmentPageResource.
                Enrollment_Page_Administrator_Window_Name);
            base.SwitchToIFrame(EnrollmentPageResource.
                Enrollment_Page_RightFrame_Id_Locator);
            logger.LogMethodExit("EnrollmentPage", "SelectAdministratorRightFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The ManageAccess Cmenu In Administrator Tab
        /// </summary>
        public void ClickTheManageAccessCmenuInAdministratorTab()
        {
            //Click The ManageAccess Cmenu In Administrator Tab
            logger.LogMethodEntry("EnrollmentPage", "ClickTheManageAccessCmenuInAdministratorTab",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wai for the cmenu option
                base.WaitForElement(By.Id(EnrollmentPageResource.
                    Enrollment_Page_Cmenu_Div_Id_Locator)); 
                base.WaitForElement(By.PartialLinkText(EnrollmentPageResource.
                    Enrollment_Page_ManageAccess_Cmenu_Name));
                //Focus on Manage Access cmenu
                base.FocusOnElementByPartialLinkText(EnrollmentPageResource.
                    Enrollment_Page_ManageAccess_Cmenu_Name);
                IWebElement getManageAccess = base.GetWebElementPropertiesByPartialLinkText
                    (EnrollmentPageResource.
                    Enrollment_Page_ManageAccess_Cmenu_Name);
                //Click the Manage Access cmenu
                base.ClickByJavaScriptExecutor(getManageAccess);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EnrollmentPage", "ClickTheManageAccessCmenuInAdministratorTab",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save The Manage Access Save Button
        /// </summary>
        public void SaveTheManageAccessSaveButton()
        {
            //Save The Manage Access Save Button
            logger.LogMethodEntry("EnrollmentPage", "SaveTheManageAccessSaveButton",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the window loads
                base.WaitUntilWindowLoads(EnrollmentPageResource.
                    Enrollment_Page_ManageAccess_Window_Name);
                base.SelectWindow(EnrollmentPageResource.
                    Enrollment_Page_ManageAccess_Window_Name);
                //Wait for the element
                base.WaitForElement(By.Id(EnrollmentPageResource.
                    Enrollment_Page_ManageAccess_Save_Button_Id_Locator));
                IWebElement getSaveButton = GetWebElementPropertiesById
                    (EnrollmentPageResource.
                    Enrollment_Page_ManageAccess_Save_Button_Id_Locator);
                //Click the Save button
                base.ClickByJavaScriptExecutor(getSaveButton);
                base.SelectDefaultWindow();
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EnrollmentPage", "SaveTheManageAccessSaveButton",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
