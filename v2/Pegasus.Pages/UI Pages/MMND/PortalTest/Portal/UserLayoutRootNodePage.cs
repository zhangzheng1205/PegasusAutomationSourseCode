using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.MMND.PortalTest.Portal;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles UserLayoutRootNodePage page actions
    /// </summary>
    public class UserLayoutRootNodePage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(UserLayoutRootNodePage));

        /// <summary>
        /// Click On the 'Create/Copy Course' Button
        /// </summary>
        public void ClickOntheCreateCopyCourseButton()
        {
            //Click On the 'Create/Copy Course' Option
            logger.LogMethodEntry("UserLayoutRootNodePage", "ClickOntheCreateCopyCourseButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the Refresh button if Present
                this.ClickOnRefreshButton();
                //Wait for The Window
                base.WaitUntilWindowLoads(UserLayoutRootNodePageResource.
                    UserLayoutRootNodePage_Window_Title);
                //Select the Window
                base.SelectWindow(UserLayoutRootNodePageResource.
                    UserLayoutRootNodePage_Window_Title);
                //Wait for the 'Create/Copy Course' Option
                base.WaitForElement(By.ClassName(UserLayoutRootNodePageResource.
                    UserLayoutRootNodePage_CreateCopyCourse_ClassName_Locator));
                //Click On the 'Create/Copy Course' Option
                base.ClickByJavaScriptExecutor(base.
                    GetWebElementPropertiesByClassName(UserLayoutRootNodePageResource.
                    UserLayoutRootNodePage_CreateCopyCourse_ClassName_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodePage", "ClickOntheCreateCopyCourseButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Refresh Button
        /// </summary>
        private void ClickOnRefreshButton()
        {
            //Click on the Refresh Button
            logger.LogMethodEntry("UserLayoutRootNodePage", "ClickOnRefreshButton",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for The Window
            base.WaitUntilWindowLoads(UserLayoutRootNodePageResource.
                UserLayoutRootNodePage_Window_Title);
            //Select the Window
            base.SelectWindow(UserLayoutRootNodePageResource.
                UserLayoutRootNodePage_Window_Title);
            if (base.IsElementPresent(By.XPath(UserLayoutRootNodePageResource.
                UserLayoutRootNodePage_ErrorRefresh_Button_Xpath_Locator), Convert.ToInt32(
                UserLayoutRootNodePageResource.UserLayoutRootNodePage_Customized_Wait_Time)))
            {
                base.ClickButtonByXPath(UserLayoutRootNodePageResource.
                UserLayoutRootNodePage_ErrorRefresh_Button_Xpath_Locator);
            }
            logger.LogMethodExit("UserLayoutRootNodePage", "ClickOnRefreshButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Enorll In Another Course Button.
        /// </summary>
        public void ClickOnEnrollInAnotherCourseButton()
        {
            //Click On Enroll In Another Course Button
            logger.LogMethodEntry("UserLayoutRootNodePage", "ClickOnEnrollInAnotherCourseButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectWindow();
                //Focus on Enroll In Another Course Button
                base.FocusOnElementByPartialLinkText(UserLayoutRootNodePageResource.
                    UserLayoutRootNodePage_EnrollInAnotherCourse_Button_Locator);
                //Click on Enroll In Another Course Button 
                base.ClickButtonByPartialLinkText(UserLayoutRootNodePageResource.
                    UserLayoutRootNodePage_EnrollInAnotherCourse_Button_Locator);
                switch (base.Browser)
                {
                    //This is for Internet Explorer Browser
                    case PegasusBaseTestFixture.InternetExplorer:
                        //Select Certificate Error Window
                        this.SelectCertificateErrorWindow();
                        base.NavigateToBrowseUrl(UserLayoutRootNodePageResource.
                            UserLayoutRootNodePage_Certification_Button_Locator);
                        break;
                    //This is for Chrome and FireFox Browser
                    case PegasusBaseTestFixture.FireFox:
                        break;
                }
                //Select Window
                base.WaitUntilWindowLoads(UserLayoutRootNodePageResource.
                    UserLayoutRootNodePage_RegisterPearsonMyLabMastering_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodePage", "ClickOnEnrollInAnotherCourseButton",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Certificate Error Window.
        /// </summary>
        private void SelectCertificateErrorWindow()
        {
            //Select Certificate Error Window
            logger.LogMethodEntry("UserLayoutRootNodePage", "SelectCertificateErrorWindow",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(UserLayoutRootNodePageResource.
                UserLayoutRootNodePage_CertificateErrorNavigationBlocked_Window_Title);
            //Select Window
            base.SelectWindow(UserLayoutRootNodePageResource.
                UserLayoutRootNodePage_CertificateErrorNavigationBlocked_Window_Title);
            logger.LogMethodExit("UserLayoutRootNodePage", "SelectCertificateErrorWindow",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("UserLayoutRootNodePage", "SelectWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(UserLayoutRootNodePageResource.
                UserLayoutRootNodePage_Window_Title);
            base.WaitForElement(By.PartialLinkText(UserLayoutRootNodePageResource.
                UserLayoutRootNodePage_EnrollInAnotherCourse_Button_Locator));
            logger.LogMethodExit("UserLayoutRootNodePage", "SelectWindow",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify if Course Name is Displayed
        /// </summary>
        /// <param name="courseName">This is Course name</param>
        /// <returns>Return True if Course name is Displayed otherwise false.</returns>
        public Boolean IsCourseNameDisplayed(string courseName)
        {
            //Verify if Course Name is Displayed
            logger.LogMethodEntry("UserLayoutRootNodePage", "IsCourseNameDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            Boolean isCourseNameDisplayed = false;
            try
            {
                //Wait for Partial Link text
                base.WaitForElement(By.PartialLinkText(courseName));
                //Verify Course
                isCourseNameDisplayed = base.IsElementPresent(By.PartialLinkText(courseName));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserLayoutRootNodePage", "IsCourseNameDisplayed",
               base.isTakeScreenShotDuringEntryExit);
            return isCourseNameDisplayed;
        }

    }
}
