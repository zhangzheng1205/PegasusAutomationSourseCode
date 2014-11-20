using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Users;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports
{
    /// <summary>
    /// This class handles Pegasus Learning Aid Frequency Analysis Page Actions 
    /// </summary>
    public class RptLearningAidFrequencyPage : BasePage
    {
        /// <summary>
        /// Instance of logger
        /// </summary>
        private static Logger logger = Logger.
            GetInstance(typeof(RptTrainingFreqAnalysisPage));

        /// <summary>
        /// Select Learning Aid Usage window
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("RptLearningAidFrequencyPage", "SelectWindow"
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait Until Window
            base.WaitUntilWindowLoads("Learning Aid Usage Report");
            //Selecting the 'Learning Aid Usage' window                
            base.SelectWindow("Learning Aid Usage Report");
            logger.LogMethodExit("RptLearningAidFrequencyPage", "SelectWindow"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the question name in Learning Aid Usage reports.
        /// </summary>
        /// <param name="questionName">Question name.</param>
        /// <returns>Question name.</returns>
        public Boolean IsQuestionPresentInLearningAidUsageReport(string questionName)
        {
            //Verify the question name in Learning Aid Usage reports
            logger.LogMethodEntry("RptLearningAidFrequencyPage",
               "IsQuestionPresentInLearningAidUsageReport",
               base.IsTakeScreenShotDuringEntryExit);
            bool isQuestionPresent = false;
            string getQuestionName = string.Empty;
            //Select reports window
            this.SelectWindow();
            try
            {
                base.WaitForElement(By.XPath(RptLearningAidFrequencyPageResource.
                    RptLearningAidUsage_Page_QuestionCount_XPath_Locator));
                int getCount = base.GetElementCountByXPath(
                    RptLearningAidFrequencyPageResource.
                    RptLearningAidUsage_Page_QuestionCount_XPath_Locator);
                for (int questionSearch = 1; questionSearch <= getCount; questionSearch++)
                {
                    //Get the question name
                    getQuestionName = base.GetElementTextByXPath(String.Format(
                        RptLearningAidFrequencyPageResource.
                    RptLearningAidUsage_Page_QuestionName_XPath_Locator,
                        questionSearch));
                    if (getQuestionName == questionName)
                    {
                        isQuestionPresent = true;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptLearningAidFrequencyPage",
                "IsQuestionPresentInLearningAidUsageReport",
                base.IsTakeScreenShotDuringEntryExit);
            return isQuestionPresent;
        }

        /// <summary>
        /// Get the Activity name from the Learning Aid Usage Report.
        /// </summary>
        /// <param name="chapterName">This is the activity name.</param>       
        /// <returns>Activity name.</returns>
        public string GetLearningAidUsageActivityNameInReport(string chapterName)
        {
            // Get the details from the learning aid usage report
            logger.LogMethodEntry("RptLearningAidFrequencyPage",
                "GetLearningAidUsageActivityNameInReport",
                   base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            this.SelectWindow();
            try
            {               
                getActivityName = base.GetElementTextByXPath(
                    RptLearningAidFrequencyPageResource.
                    RptLearningAidUsage_Page_ActivityName_XPath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptLearningAidFrequencyPage",
               "GetLearningAidUsageActivityNameInReport",
                   base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Get the Score from the Learning Aid Usage Report.
        /// </summary>
        /// <param name="chapterName">This is the Score.</param>       
        /// <returns>Score.</returns>
        public string GetLearningAidUsageScoreInReport(string score)
        {
            // Get the details from the learning aid usage report
            logger.LogMethodEntry("RptLearningAidFrequencyPage",
                "GetLearningAidUsageScoreInReport",
                   base.IsTakeScreenShotDuringEntryExit);
            string getScore = string.Empty;
            this.SelectWindow();
            try
            {               
                getScore = base.GetElementTextByXPath(
                    RptLearningAidFrequencyPageResource.
                    RptLearningAidUsage_Page_ActivityScore_XPath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptLearningAidFrequencyPage",
               "GetLearningAidUsageScoreInReport",
                   base.IsTakeScreenShotDuringEntryExit);
            return getScore;
        }

        /// <summary>
        /// Verify question details.
        /// </summary>
        /// <param name="questionName">This is a question name.</param>
        /// <param name="questionData">This is the question details column.</param>
        /// <returns>Question details.</returns>
        public string GetLearningAidUsageQuestionDetails(string questionName, int questionData)
        {
            //Verify the Question details
            logger.LogMethodEntry("RptLearningAidFrequencyPage",
                "GetLearningAidUsageQuestionDetails",
                   base.IsTakeScreenShotDuringEntryExit);
            string getQuestionName = string.Empty;
            string getQuestionDetails = string.Empty;
            this.SelectWindow();
            try
            {                
                base.WaitForElement(By.XPath(RptLearningAidFrequencyPageResource.
                    RptLearningAidUsage_Page_QuestionCount_XPath_Locator));
                int getCount = base.GetElementCountByXPath(RptLearningAidFrequencyPageResource.
                    RptLearningAidUsage_Page_QuestionCount_XPath_Locator);
                for (int questionSearch = 1; questionSearch <= getCount; questionSearch++)
                {
                    //Get the question name                 
                    getQuestionName = base.GetElementTextByXPath(String.Format(
                        RptLearningAidFrequencyPageResource.
                    RptLearningAidUsage_Page_QuestionName_XPath_Locator,
                        questionSearch));
                    if (getQuestionName == questionName)
                    {                    
                        //Get the question details                          
                        base.WaitForElement(By.XPath(String.Format(
                            RptLearningAidFrequencyPageResource.
                            RptLearningAidUsage_Page_QuestionDetails_XPath_Locator,
                            questionSearch, questionData)));
                        getQuestionDetails = base.GetElementTextByXPath(String.
                            Format(RptLearningAidFrequencyPageResource.
                            RptLearningAidUsage_Page_QuestionDetails_XPath_Locator,
                            questionSearch, questionData));                       
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptLearningAidFrequencyPage",
                "GetLearningAidUsageQuestionDetails",
                    base.IsTakeScreenShotDuringEntryExit);
            return getQuestionDetails;
        }

        /// <summary>
        /// Verift Learning Aid Usage Report detail by Section Instructor.
        /// </summary>
        /// <param name="questionName">This is the question name.</param>
        /// <param name="rownumber">This is the question row number.</param>
        /// <param name="questionData">This is the question data field.</param>
        /// <returns>Question details.</returns>
        public string GetLearningAidFrequencyQuestionDetailsBySectionInstructor(
            string questionName, int rowNumber, int questionData)
        {
            //Verify the Question details
            logger.LogMethodEntry("RptLearningAidFrequencyPage",
                "GetLearningAidUsageQuestionDetails",
                   base.IsTakeScreenShotDuringEntryExit);
            string getQName = string.Empty;
            string getQDetails = string.Empty;
            this.SelectWindow();
            base.WaitForElement(By.XPath(RptLearningAidFrequencyPageResource.
                    RptLearningAidUsage_Page_QuestionCount_XPath_Locator));
            int getCount = base.GetElementCountByXPath(RptLearningAidFrequencyPageResource.
                RptLearningAidUsage_Page_QuestionCount_XPath_Locator);
            for (int questionSearch = 1; questionSearch <= getCount; questionSearch++)
            {
                //Get the question name                 
                getQName = base.GetElementTextByXPath(String.Format(
                    RptLearningAidFrequencyPageResource.
                RptLearningAidUsage_Page_QuestionName_XPath_Locator,
                    questionSearch));
                if (getQName == questionName)
                {                    
                    base.WaitForElement(By.XPath(String.Format(
                        RptLearningAidFrequencyPageResource.
                       RptLearningAidUsage_Page_SectionInstructor_QuestionDetails_XPath_Locator, 
                       rowNumber, questionData)));
                    getQDetails = base.GetElementTextByXPath(
                        String.Format(RptLearningAidFrequencyPageResource.
                       RptLearningAidUsage_Page_SectionInstructor_QuestionDetails_XPath_Locator,
                       rowNumber, questionData));
                    break;
                }

            }

            logger.LogMethodExit("RptLearningAidFrequencyPage",
                   "GetLearningAidUsageQuestionDetails",
                      base.IsTakeScreenShotDuringEntryExit);
            return getQDetails;
        }
    }

}

