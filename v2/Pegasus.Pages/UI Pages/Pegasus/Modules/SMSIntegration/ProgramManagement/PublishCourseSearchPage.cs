using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using System.Threading;
using System.Configuration;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class contains the code for Publish Course Search Page
    /// </summary>
    public class PublishCourseSearchPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(PublishCourseSearchPage));

        /// <summary>
        /// This is the Assigned to Copy Interval Time
        /// </summary>
        static readonly int MinutesToWait =
            Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);


        /// <summary>
        /// Select Search Course Frame.
        /// </summary>
        /// <param name="courseName">This is Course Name.</param>
        public void SelectSearchCourseFrame(string courseName)
        {
            try
            {
                //Method To Search Course
                logger.LogMethodEntry("PublishCourseSearchPage", "SelectSearchCourseFrame",
                    base.IsTakeScreenShotDuringEntryExit);
                //Select Default Window
                base.SelectDefaultWindow();
                //Wait For Element
                base.WaitForElement(By.Id(PublishCourseSearchPageResource.
                    PublishCourseSearch_Page_Workspace_IFrame_Id_Locator));
                base.SwitchToIFrame(PublishCourseSearchPageResource.
                    PublishCourseSearch_Page_Workspace_IFrame_Id_Locator);
                // Calling Method To click on Course Search Link
                new ProductManagementContainerPage().ClickSearchCoursesLink();
                base.WaitForElement(By.Id(PublishCourseSearchPageResource.
                    PublishCourseSearch_Page_LeftFrame_Id_Locator));
                //Switch To IFrame
                base.SwitchToIFrame(PublishCourseSearchPageResource.
                    PublishCourseSearch_Page_LeftFrame_Id_Locator);
                //Search Course by Name
                SearchCourse(courseName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PublishCourseSearchPage", "SelectSearchCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Course.
        /// </summary>
        /// <param name="courseName">This is Course Name.</param>
        private void SearchCourse(string courseName)
        {
            //Course Displayed After Search
            logger.LogMethodEntry("PublishCourseSearchPage", "SearchCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(PublishCourseSearchPageResource.
                PublishCourseSearch_Page_CourseDetail_Id_Locator));
            //Enter Course Name in Text Box
            base.FillTextBoxById(PublishCourseSearchPageResource.
                PublishCourseSearch_Page_CourseDetail_Id_Locator, courseName);
            base.WaitForElement(By.Id(PublishCourseSearchPageResource.
                 PublishCourseSearch_Page_ButtonSearch_Id_Locator));
            //Get HTML Element Property
            IWebElement buttonSearch = base.GetWebElementPropertiesById(
                PublishCourseSearchPageResource.
                PublishCourseSearch_Page_ButtonSearch_Id_Locator);
            base.ClickByJavaScriptExecutor(buttonSearch);
            //Wait For Element
            base.WaitForElement(By.Id(PublishCourseSearchPageResource.
                PublishCourseSearch_Page_CourseGrid_Id_Locator));
            logger.LogMethodExit("PublishCourseSearchPage", "SearchCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This method is for selecting course to approve.
        /// </summary>
        /// <param name="courseName">This is the course name.</param>
        public void SelectCourseToApprove(string courseName)
        {
            //Method To Select Course To Approve
            logger.LogMethodEntry("PublishCourseSearchPage", "SelectCourseToApprove",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Start Stop Watch
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                //Wait Till Assigned To Copy State Completes
                while (stopWatch.Elapsed.TotalMinutes < MinutesToWait)
                {
                    //If Assigned To Copy Text Present 
                    if (base.IsElementPresent(By.XPath(PublishCourseSearchPageResource.
                        PublishCourseSearch_Page_AssignedToCopyText_Label_Locator),
                        Convert.ToInt32(PublishCourseSearchPageResource
                        .Sleep_Time_For_MenuTimeOutInSeconds)) == false) break;
                    SelectSearchCourseFrame(courseName);
                    //Sleep Time To Wait
                    Thread.Sleep(Convert.ToInt32(PublishCourseSearchPageResource.
                        Sleep_Time_For_AssignedToCopyState));
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PublishCourseSearchPage", "SelectCourseToApprove",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
