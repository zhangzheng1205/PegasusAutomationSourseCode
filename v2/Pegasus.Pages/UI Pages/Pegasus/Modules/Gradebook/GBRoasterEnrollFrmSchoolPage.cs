using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{
    public class GBRoasterEnrollFrmSchoolPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(GBDefaultUXPage));

        /// <summary>
        /// Switch control to enroll from school popup.
        /// </summary>
        private void SwitchToEnrollFromSchoolWindow()
        {
            logger.LogMethodEntry("GBRoasterEnrollFrmSchoolPage", "SwitchToEnrollFromSchoolWindow",
                 base.IsTakeScreenShotDuringEntryExit);
            //Switch to enroll from school pop up
            base.WaitUntilWindowLoads(GBRoasterEnrollFrmSchoolPageResource.
                GBRoasterEnrollFrmSchoolPage_WindowTitle_Locator);
            base.SelectWindow(GBRoasterEnrollFrmSchoolPageResource.
                GBRoasterEnrollFrmSchoolPage_WindowTitle_Locator);
            logger.LogMethodExit("GBRoasterEnrollFrmSchoolPage", "SwitchToEnrollFromSchoolWindow",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Search button in Enroll from School pop up.
        /// </summary>
        public void ClickOnSearchButton()
        {
            logger.LogMethodEntry("GBRoasterEnrollFrmSchoolPage", "ClickOnSearchButton",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to Enroll from school window
                this.SwitchToEnrollFromSchoolWindow();
                //Click on search button
                base.SwitchToIFrameById(GBRoasterEnrollFrmSchoolPageResource.
                    GBRoasterEnrollFrmSchoolPage_UserListFrame_Id_Locator);
                base.ClickButtonById(
                    GBRoasterEnrollFrmSchoolPageResource.GBRoasterEnrollFrmSchoolPage_SearchBtn_Id_Locator);
                base.SwitchToDefaultPageContent();
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("GBRoasterEnrollFrmSchoolPage", "ClickOnSearchButton",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the username in search text box.
        /// </summary>
        /// <param name="userName">Name of the user to search.</param>
        public void SearchForUsers(string userName)
        {
            logger.LogMethodEntry("GBRoasterEnrollFrmSchoolPage", "SearchForUsers",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Enter Search term
                base.WaitForElement(By.Id(GBRoasterEnrollFrmSchoolPageResource.
                    GBRoasterEnrollFrmSchoolPage_SearchTextBox_Id_Locator));
                base.FillTextBoxById(GBRoasterEnrollFrmSchoolPageResource.
                    GBRoasterEnrollFrmSchoolPage_SearchTextBox_Id_Locator, userName);
                //Click on Search button
                base.ClickButtonById(GBRoasterEnrollFrmSchoolPageResource.
                    GBRoasterEnrollFrmSchoolPage_SearchUsersButton_Id_Locator);
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRoasterEnrollFrmSchoolPage", "SearchForUsers",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the username from search result page in Enroll from school pop up.
        /// </summary>
        /// <returns>Username</returns>
        public string GetUserNameFromSearchResult()
        {
            //Get user name.
            logger.LogMethodEntry("GBRoasterEnrollFrmSchoolPage", "ValidateSearchedUserName",
                 base.IsTakeScreenShotDuringEntryExit);
            string getUserName = null;
            try
            {
                //Get user name from search results.
                base.SwitchToIFrameById(GBRoasterEnrollFrmSchoolPageResource.
               GBRoasterEnrollFrmSchoolPage_UserListFrame_Id_Locator);
                getUserName = base.GetElementTextByXPath(GBRoasterEnrollFrmSchoolPageResource.
                    GBRoasterEnrollFrmSchoolPage_UserNameColumn_SearchedList_Xpath_Locator);

            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRoasterEnrollFrmSchoolPage", "ValidateSearchedUserName",
                         base.IsTakeScreenShotDuringEntryExit);
            return getUserName;
        }

        /// <summary>
        /// Enroll searched student to class.
        /// </summary>
        public void EnrollUser()
        {
            //Enroll student
            logger.LogMethodEntry("GBRoasterEnrollFrmSchoolPage", "EnrollUser",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the searched student check box
                base.ClickLinkById(GBRoasterEnrollFrmSchoolPageResource.
                GBRoasterEnrollFrmSchoolPage_UserSelectionCheckBox_Id_Locator);
                base.SwitchToDefaultPageContent();
                //Click on Add button
                base.ClickButtonById(GBRoasterEnrollFrmSchoolPageResource.
                    GBRoasterEnrollFrmSchoolPage_AddButton_Id_Locator);
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRoasterEnrollFrmSchoolPage", "EnrollUser",
                         base.IsTakeScreenShotDuringEntryExit);
        }

        public string getEnrolledUserUserName()
        {
            logger.LogMethodEntry("GBRoasterEnrollFrmSchoolPage", "getEnrolledUserUserName",
                base.IsTakeScreenShotDuringEntryExit);
            string getStudentUserName = null;
            try
            {
                base.SwitchToIFrameById(GBRoasterEnrollFrmSchoolPageResource.
                    GBRoasterEnrollFrmSchoolPage_SelectedUsersFrame_Id_Locator);
                base.WaitForElement(By.XPath(GBRoasterEnrollFrmSchoolPageResource.
                    GBRoasterEnrollFrmSchoolPage_UserNameColumn_EnrolledUsersList_Xpath_Locator));
                getStudentUserName = base.GetElementTextByXPath(
                    GBRoasterEnrollFrmSchoolPageResource.
                    GBRoasterEnrollFrmSchoolPage_UserNameColumn_EnrolledUsersList_Xpath_Locator);
                base.SwitchToDefaultPageContent();
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRoasterEnrollFrmSchoolPage", "getEnrolledUserUserName",
                         base.IsTakeScreenShotDuringEntryExit);
            return getStudentUserName;
        }

        /// <summary>
        /// Get success message displayed in enroll from school pop up.
        /// </summary>
        /// <returns>Success message from application.</returns>
        public string GetSuccessMessage()
        {
            //Get success message
            logger.LogMethodEntry("GBRoasterEnrollFrmSchoolPage", "GetSuccessMessage",
                base.IsTakeScreenShotDuringEntryExit);
            string getSuccessMessage = null;
            try
            {
                //Fetch success message from application UI
                base.WaitForElement(By.Id(GBRoasterEnrollFrmSchoolPageResource.
                GBRoasterEnrollFrmSchoolPage_SucessMessage_Div_Id_Locator));
                getSuccessMessage = base.GetElementTextById(GBRoasterEnrollFrmSchoolPageResource.
                    GBRoasterEnrollFrmSchoolPage_SucessMessage_Div_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRoasterEnrollFrmSchoolPage", "GetSuccessMessage",
                         base.IsTakeScreenShotDuringEntryExit);
            return getSuccessMessage;
        }

        /// <summary>
        /// Click on Close button in enroll from school pop up.
        /// </summary>
        public void ClickOnCloseButton()
        {
            //Click on close button
            logger.LogMethodEntry("GBRoasterEnrollFrmSchoolPage", "ClickOnCloseButton",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on close button
                IWebElement getCloseButtonProperty = base.GetWebElementPropertiesById(
                GBRoasterEnrollFrmSchoolPageResource.GBRoasterEnrollFrmSchoolPage_CloseButton_Id_Locator);
                base.ClickByJavaScriptExecutor(getCloseButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRoasterEnrollFrmSchoolPage", "ClickOnCloseButton",
                        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate whether pop up closed or not.
        /// </summary>
        /// <param name="popUpName">Name of the pop up to validate.</param>
        /// <returns></returns>
        public bool IsEnrollFromSchoolPopupClosed(string popUpName)
        {
            //Validate whether pop up closed or not.
            logger.LogMethodEntry("GBRoasterEnrollFrmSchoolPage", "IsEnrollFromSchoolPopupClosed",
               base.IsTakeScreenShotDuringEntryExit);
            bool isPopUpClosed = true;
            try
            {
                //Check whether pop up present or not
                isPopUpClosed = base.IsPopupPresent(popUpName, 5);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBRoasterEnrollFrmSchoolPage", "IsEnrollFromSchoolPopupClosed",
                       base.IsTakeScreenShotDuringEntryExit);
            return isPopUpClosed;
        }
    }
}
