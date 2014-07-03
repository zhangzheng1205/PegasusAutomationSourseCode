using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus RptExamFreqAnalysisPage Page Actions
    /// </summary>
    public class RptExamFreqAnalysisPage:BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptExamFreqAnalysisPage));

        /// <summary>
        /// Get Exam Frequency Analysis Score In Report.
        /// </summary>
        /// <returns>Activity Report Score.</returns>
        public string GetExamFrequencyAnalysisScoreInReport()
        {
            //Get Exam Frequency Analysis Score In Report
            logger.LogMethodEntry("RptExamFreqAnalysisPage",
                "GetExamFrequencyAnalysisScoreInReport",
                base.isTakeScreenShotDuringEntryExit);
            //Initialized Activity Score Variable
            string getActivityScore = string.Empty;
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
                base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
                //Wait for the element
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ReportScore_Xpath_Locator));
                //Get Activity Score
                getActivityScore = base.GetElementTextByXPath(
                    RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ReportScore_Xpath_Locator);
                getActivityScore = getActivityScore.Substring(Convert.ToInt32(
                    RptStudentAllAssessmentsPageResource.
                    RptStudentAllAssessmentsPage_Intial_Substring_Value),
                    Convert.ToInt32(RptStudentAllAssessmentsPageResource.
                    RptStudentAllAssessmentsPage_End_Substring_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptExamFreqAnalysisPage",
                "GetExamFrequencyAnalysisScoreInReport",
                base.isTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }
    }
}
