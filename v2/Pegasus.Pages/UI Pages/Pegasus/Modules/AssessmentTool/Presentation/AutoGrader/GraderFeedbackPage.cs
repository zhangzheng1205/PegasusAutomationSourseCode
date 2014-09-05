﻿using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation.AutoGrader;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;
namespace Pegasus.Pages.UI_Pages.Pegasus
{
    public class GraderFeedbackPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = Logger.GetInstance(typeof(GraderFeedbackPage));

        public Boolean ValidateTheMessageOnPopupPage(string message)
        {
            //To Validate The Message On the Copy as Section Popup Page
            Logger.LogMethodEntry("GraderFeedbackPage", "ValidateTheMessageOnPopupPage",
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

            Logger.LogMethodExit("PresentationPage", "ValidateTheMessageOnPopupPage",
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
            Logger.LogMethodEntry("GraderFeedbackPage",
                "ValidateTheMessageOnTestResultPopupPage",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isTrue = false;
            try
            {
                //Select the pop window so as to set focus to its elements.
                base.SelectWindow(GraderFeedbackResource.
                    GraderFeedbackResource_Popup_Title);
                //Check the message excpected and obtained are same
                isTrue = base.IsElementContainsTextById(GraderFeedbackResource.
                    GraderFeedbackResource_Page_Table_Id_Locator, message);
            }
            //Exception Handling
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PresentationPage", 
                "ValidateTheMessageOnTestResultPopupPage",
            base.IsTakeScreenShotDuringEntryExit);
            return isTrue;
        }

        /// <summary>
        /// Get MaximumScore in Test Result Popup
        /// Channel
        /// </summary>
        /// <returns>Alert Count</returns>
        public int GetScorefromTestResult(String popupName)
        {
            //Get Alert count from Notification Channel
            Logger.LogMethodEntry("GraderFeedbackPage", "GetScorefromTestResult",
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
            Logger.LogMethodExit("GraderFeedbackPage", "GetScorefromTestResult",
                                 base.IsTakeScreenShotDuringEntryExit);
            return alertValue;
        }

        /// <summary>
        /// Click Return to course button operation.
        /// </summary>
        public void ClickReturnToCourseButton()
        {
            //To perform click operation on "Retuen To Course" button.
            Logger.LogMethodEntry("GraderFeedbackPage", "ClickReturnToCourseButton",
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
            Logger.LogMethodExit("GraderFeedbackPage", "ClickReturnToCourseButton",
                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Refresh Course Preview Iframe.
        /// </summary>
        public void RefreshCoursePreviewIframe()
        {
            //To perform click operation on "Retuen To Course" button.
            Logger.LogMethodEntry("GraderFeedbackPage", "RefreshCoursePreviewIframe",
                                  base.IsTakeScreenShotDuringEntryExit);
            base.SelectDefaultWindow();
            base.RefreshTheCurrentPage();
            Logger.LogMethodExit("GraderFeedbackPage", "RefreshCoursePreviewIframe",
                      base.IsTakeScreenShotDuringEntryExit);
        }
    }
}