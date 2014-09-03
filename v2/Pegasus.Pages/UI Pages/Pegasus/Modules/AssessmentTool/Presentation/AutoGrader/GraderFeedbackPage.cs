using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TodaysView;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation.AutoGrader
{
    public class GraderFeedbackPage : BasePage
    {
        // <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(GraderFeedbackPage));

        public Boolean ValidateTheMessageOnPopupPage(string message)
        {
            //To Validate The Message On the Copy as Section Popup Page
            logger.LogMethodEntry("GraderFeedbackPage", "ValidateTheMessageOnPopupPage",
            base.IsTakeScreenShotDuringEntryExit);

            //Initialize Variable
            bool IsTrue = false; ;
            try
            {
                //Select the pop window so as to set focus to its elements.
                base.SelectWindow(GraderFeedbackResource.
                    GraderFeedbackResource_Popup_Title);

                //Check the message excpected and obtained are same
                IsTrue = base.IsElementContainsTextById(GraderFeedbackResource.
                    GraderFeedbackResource_Page_Table_Id_Locator, message);
            }
            //Exception Handling
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("PresentationPage", "ValidateTheMessageOnPopupPage",
            base.IsTakeScreenShotDuringEntryExit);

            return IsTrue;
        }

        /// <summary>
        /// Validate the Score
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public Boolean ValidateTheMessageOnTestResultPopupPage(string message)
        {
            //To Validate The Message On the Copy as Section Popup Page
            logger.LogMethodEntry("GraderFeedbackPage",
                "ValidateTheMessageOnTestResultPopupPage",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool IsTrue = false; ;
            try
            {
                //Select the pop window so as to set focus to its elements.
                base.SelectWindow(GraderFeedbackResource.
                    GraderFeedbackResource_Popup_Title);
                //Check the message excpected and obtained are same
                IsTrue = base.IsElementContainsTextById(GraderFeedbackResource.
                    GraderFeedbackResource_Page_Table_Id_Locator, message);
            }
            //Exception Handling
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PresentationPage", 
                "ValidateTheMessageOnTestResultPopupPage",
            base.IsTakeScreenShotDuringEntryExit);
            return IsTrue;
        }

        /// <summary>
        /// Get MaximumScore in Test Result Popup
        /// Channel
        /// </summary>
        /// <returns>Alert Count</returns>
        public int GetScorefromTestResult(String popupName)
        {
            //Get Alert count from Notification Channel
            logger.LogMethodEntry("GraderFeedbackPage", "GetScorefromTestResult",
                                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize Alert Variable
            int alertValue = 0;
            //TO select the pop window so as to set focus to its elements.
            base.SelectWindow(GraderFeedbackResource.GraderFeedbackResource_Popup_Title);
            //Store the Alert channel text
            string newGradesAlert = base.GetElementTextById(GraderFeedbackResource.
                GraderFeedbackResource_MaximumScore_ID);
            try
            {
                //Extract only alert count from the string
                alertValue = Convert.ToInt32(newGradesAlert);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GraderFeedbackPage", "GetScorefromTestResult",
                                 base.IsTakeScreenShotDuringEntryExit);
            return alertValue;
        }

        /// <summary>
        /// Click Return to course button operation.
        /// </summary>
        public void ClickReturnToCourseButton()
        {
            //To perform click operation on "Retuen To Course" button.
            logger.LogMethodEntry("GraderFeedbackPage", "ClickReturnToCourseButton",
                                  base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(GraderFeedbackResource.
                GraderFeedbackResource_Popup_Title);
            // Wait untill "Retuen To Course" button loads and click.
            IWebElement returnToCoursebtnid = base.GetWebElementPropertiesByClassName("btn_p");
            base.ClickByJavaScriptExecutor(returnToCoursebtnid);
            base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_Window_Title_Name_HED);
            base.SelectWindow(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_Window_Title_Name_HED);
            base.RefreshIFrameByJavaScriptExecutor("ifrmCoursePreview");
            logger.LogMethodExit("GraderFeedbackPage", "ClickReturnToCourseButton",
                      base.IsTakeScreenShotDuringEntryExit);
        }
    }
}