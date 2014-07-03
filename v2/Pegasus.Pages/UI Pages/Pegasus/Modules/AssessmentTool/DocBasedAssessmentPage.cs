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
   public class DocBasedAssessmentPage : BasePage
    {
        /// <summary>
        /// This class handles DocBasedAssessmentPage Page Actions.
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(DocBasedAssessmentPage));


        /// <summary>
        /// Validate Visibilty Questions Tab for Doc Based Activity.
        /// </summary>
        public bool isQuestionsTabVisibe()
        {
            bool isQuestionTabsDisplayed = false;
            try
            {
                // Validate Visibilty Questions Tab for Doc Based Activity 
                logger.LogMethodEntry("DocBasedAssessmentPage",
                    "CheckQuestionsTabVisibilty",
                      base.isTakeScreenShotDuringEntryExit);
                //Wait for the Window
                base.WaitUntilWindowLoads(DocBasedAssessmentResource.
                    DocBasedAssessment_Page_WindowName);
                //Validate Visibilty Questions Tab
                isQuestionTabsDisplayed = base.IsElementPresent(By.Id(
                    DocBasedAssessmentResource.DocBasedAssessment_Page_QuestionsTab_ID),
                    Convert.ToInt16(DocBasedAssessmentResource.
                    DocBasedAssessment_Page_Custom_Wait_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DocBasedAssessmentPage", 
                "CheckQuestionsTabVisibilty",
                 base.isTakeScreenShotDuringEntryExit);
            return isQuestionTabsDisplayed;
        }

        /// <summary>
        /// Validate Visibilty Questions Tab for Doc Based Sim Study plan. 
        /// </summary>
        /// <param name="testType">This is Test type in Sim Study plan .</param>
        public bool isQuestionsTabVisibleInSimStudyPlan(
            string testType)
        {
            bool isQuestionTabsDisplayed = false;
            try
            {
                // Validate Visibilty Questions Tab for Doc Sim Study plan
                logger.LogMethodEntry("SkillBasedAssessmentPage",
                    "CheckQuestionsTabVisibiltyInSimStudyPlan",
                    base.isTakeScreenShotDuringEntryExit);
                string getWindowName;
                if (testType == DocBasedAssessmentResource.DocBasedAssessment_Page_PreTest)
                {
                   //Window name For Pre test
                    getWindowName = DocBasedAssessmentResource.
                        DocBasedAssessment_Page_Pre_Test_WindowName;
                }
                else
                {
                    //Window name For Post test
                    getWindowName = DocBasedAssessmentResource.
                        DocBasedAssessment_Page_Post_Test_WindowName;
                }
                //Wait for the Window
                base.WaitUntilWindowLoads(getWindowName);
                //Validate Visibilty Questions Tab
                isQuestionTabsDisplayed = base.IsElementPresent(By.Id(getWindowName),
                 Convert.ToInt16(DocBasedAssessmentResource.
                 DocBasedAssessment_Page_Custom_Wait_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SkillBasedAssessmentPage",
                "CheckQuestionsTabVisibiltyInSimStudyPlan",
               base.isTakeScreenShotDuringEntryExit);
            return isQuestionTabsDisplayed;
        }
    }
}