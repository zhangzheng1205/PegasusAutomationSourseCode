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
    /// This class handles AssignmentPage Page Actions.
    /// </summary>
   public class AssignmentPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class.
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(AssignmentPage));


        /// <summary>
        /// Validate Visibilty Questions Tab for Assignment Activity  
        /// </summary>
        public bool isQuestionsTabVisibile()
        {
            bool isQuestionTabsDisplayed = false;
            try
            {
                // Validate Visibilty Questions Tab for Assignment Activity
                logger.LogMethodEntry("AssignmentPage",
                    "isQuestionsTabVisibile",
                      base.isTakeScreenShotDuringEntryExit);
                //Wait for the Window
                base.WaitUntilWindowLoads(AssignmentResource.
                    Assignment_Page_WindowName);
                //Validate Visibilty Questions Tab
                isQuestionTabsDisplayed = base.IsElementPresent(
                  By.Id(AssignmentResource.Assignment_Page_QuestionsTab_ID),
                  Convert.ToInt16(AssignmentResource.Assignment_Page_Custom_Wait_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignmentPage",
                "isQuestionsTabVisibile",
                base.isTakeScreenShotDuringEntryExit);
            return isQuestionTabsDisplayed;
        }
    }
}