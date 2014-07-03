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
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles AdaptiveAssessmentPage Page Actions.
    /// </summary>
    public class AdaptiveAssessmentPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class.
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(AdaptiveAssessmentPage));

        /// <summary>
        /// Validate Visibilty Questions Tab for Assignment Activity.
        /// </summary>
        public bool isQuestionsTabVisible()
        {
            //
            bool isQuestionTabsDisplayed = false;
            try
            {
                // Validate Visibilty Questions Tab for Adaptive Activity
                logger.LogMethodEntry("AdaptiveAssessmentPage",
                    "isQuestionsTabVisible",
                    base.isTakeScreenShotDuringEntryExit);
                //Wait for the Window
                base.WaitUntilWindowLoads(AdaptiveAssessmentResource.
                    AdaptiveAssessment_Page_WindowName);
                //Validate Visibilty Questions Tab
                isQuestionTabsDisplayed = base.IsElementPresent(
                    By.Id(AdaptiveAssessmentResource.
                   AdaptiveAssessment_Page_QuestionsTab_ID),
                   Convert.ToInt16(AdaptiveAssessmentResource.
                   AdaptiveAssessment_Page_Custom_Wait_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AdaptiveAssessmentPage",
                "isQuestionsTabVisible",
                base.isTakeScreenShotDuringEntryExit);
            return isQuestionTabsDisplayed;
        }
    }
}