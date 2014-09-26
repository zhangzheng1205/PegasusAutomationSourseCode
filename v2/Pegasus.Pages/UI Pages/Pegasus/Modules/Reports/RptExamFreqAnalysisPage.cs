
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
    public class RptExamFreqAnalysisPage : BasePage
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        ///  Verifying Question Name in Report Generated.
        /// </summary>
        /// <returns>Get Question Name.</returns>
        public string GetExamFrequencyAnalysisReportQuestionName()
        {
            // Verifying Question Name in Report Generated.
            logger.LogMethodEntry("RptExamFreqAnalysisPage",
                "GetExamFrequencyAnalysisReportQuestionName",
              base.IsTakeScreenShotDuringEntryExit);
            string getQuestName = string.Empty;
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                        RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
                base.SelectWindow(RptExamFreqAnalysisPageResource.
                        RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
                //Wait for the element           
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_QuestionName));
                //Get Question Name
                getQuestName =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_QuestionName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptExamFreqAnalysisPage", 
                "GetExamFrequencyAnalysisReportQuestionName",
               base.IsTakeScreenShotDuringEntryExit);
            return getQuestName;

        }
        /// <summary>
        /// Verifying Question Type in Report Generated.
        /// </summary>
        /// <returns>Get Applicattion Type.</returns>
        public string GetExamFrequencyAnalysisReportTypeName()
        {
            logger.LogMethodEntry("RptExamFreqAnalysisPage", 
                "GetExamFrequencyAnalysisReportTypeName",
               base.IsTakeScreenShotDuringEntryExit);
            string getTypeName = string.Empty;
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                        RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
                base.SelectWindow(RptExamFreqAnalysisPageResource.
                        RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
                //Wait for the element            
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                    RptMainUX_Page_ExamFrequencyAnalysis_TypeName_Locator));
                //Get Type Name
                getTypeName =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                    RptMainUX_Page_ExamFrequencyAnalysis_TypeName_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptExamFreqAnalysisPage", 
                "GetExamFrequencyAnalysisReportTypeName",
               base.IsTakeScreenShotDuringEntryExit);
            return getTypeName;

        }
        /// <summary>
        /// Verifying Application Name in Report Generated.
        /// </summary>
        /// <returns>Get Application Name.</returns>
        public string GetExamFrequencyAnalysisReportApplicationName()
        {
            //Verifying Application Name in Report Generated.
            logger.LogMethodEntry("RptExamFreqAnalysisPage", 
                "GetExamFrequencyAnalysisReportApplicationName",
              base.IsTakeScreenShotDuringEntryExit);
            string getAppName = string.Empty;
            //Select the window
            base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);           
            //Wait for the element
            base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                RptExamFreqAnalysisPage_ExamFrequencyAnalysis_ApplicationName));
            //Get App Name
            getAppName =
                base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                RptExamFreqAnalysisPage_ExamFrequencyAnalysis_ApplicationName);
            logger.LogMethodExit("RptExamFreqAnalysisPage",
                "GetExamFrequencyAnalysisReportApplicationName",
             base.IsTakeScreenShotDuringEntryExit);
            return getAppName;

        }

        /// <summary>
        /// Verify Correct Percentage in Report Generated.
        /// </summary>
        /// <returns>Get Correct Percentage.</returns>
        public string GetExamFrequencyAnalysisCorrectPercentInReport()
        {
            // Verify Correct Percentage in Report Generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage",
                "VerifyingCorrectPercentageinReport",
             base.IsTakeScreenShotDuringEntryExit);
            string getCorrectPercent = string.Empty;
            //Select the window
            base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);            
            //Wait for the element
            base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysis_CorrectPercentage)); 
            //Get Correct Percent
            getCorrectPercent =
                base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysis_CorrectPercentage);
            logger.LogMethodExit("RptExamFreqAnalysisPage", 
                "VerifyingCorrectPercentageinReport",
             base.IsTakeScreenShotDuringEntryExit);
            return getCorrectPercent;
        }

        /// <summary>
        /// Verify Correct attempt details displayed in report generated.
        /// </summary>
        /// <returns>Correct Attempt.</returns>
        public string GetFirstQuestionCorrectAttempt()
        {
            //Verify Correct attempt details displayed in report generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage", "GetCorrectAttempt",
           base.IsTakeScreenShotDuringEntryExit);
            string getCorrectAttempt = string.Empty;
            //Select the window
            base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);           
            //Wait for the element
            base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysis_CorrectAttempt));
            //Get Correct attempt
            getCorrectAttempt =
                base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysis_CorrectAttempt);
            logger.LogMethodExit("RptExamFreqAnalysisPage", "GetCorrectAttempt",
           base.IsTakeScreenShotDuringEntryExit);
            return getCorrectAttempt;
        }
        /// <summary>
        /// Verify InCorrect attempt displayed in report generated.
        /// </summary>
        /// <returns>InCorrect Attempt.</returns>
        public string GetFirstQuestionIncorrectAttempt()
        {
            //Verify InCorrect attempt displayed in report generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage", "GetIncorrectAttempt",
           base.IsTakeScreenShotDuringEntryExit);
            string getIncorrectAttempt = string.Empty;
            //Select the window
            base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            //Wait for the element
            base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysis_InCorrectAttempt));           
            //Get incorrect attempt
            getIncorrectAttempt =
                base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysis_InCorrectAttempt);
            logger.LogMethodExit("RptExamFreqAnalysisPage", "GetIncorrectAttempt",
           base.IsTakeScreenShotDuringEntryExit);
            return getIncorrectAttempt;
        }

        /// <summary>
        ///Verify Skipped attempt displayed in report generated.
        /// </summary>
        /// <returns>Skipped Attempt.</returns>
        public string GetFirstQuestionSkippedAttempt()
        {
            //Verify Skipped attempt displayed in report generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage", "GetSkippedAttempt",
           base.IsTakeScreenShotDuringEntryExit);
            string getSkippedAttempt = string.Empty;
            //Select the window
            base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);            
            //Wait for the element
            base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysis_SkippedAttempt));
            //Get skipped attempt
            getSkippedAttempt =
                base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysis_SkippedAttempt);
            logger.LogMethodExit("RptExamFreqAnalysisPage", "GetSkippedAttempt",
           base.IsTakeScreenShotDuringEntryExit);
            return getSkippedAttempt;
        }

        /// <summary>
        /// Verify Question Name in Report Generated.
        /// </summary>
        /// <returns>Get Question Name.</returns>
        public string GetExamFrequencySecondQuestionName()
        {
            //Verify Question Name in Report Generated.
            logger.LogMethodEntry("RptExamFreqAnalysisPage", "GetQuestionName",
            base.IsTakeScreenShotDuringEntryExit);
            string getQName = string.Empty;
            //Select the window
            base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);           
            //Wait for the element
            base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysis_ySecondQuestionName));
            //Get Question Name
            getQName =
                base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysis_ySecondQuestionName);
            logger.LogMethodExit("RptExamFreqAnalysisPage", "GetQuestionName",
           base.IsTakeScreenShotDuringEntryExit);
            return getQName;

        }
        /// <summary>
        /// Verifying Question Type in Report Generated.
        /// </summary>
        /// <returns>Get Applicattion Type</returns>
        public string GetExamFrequencySecondQuestionType()
        {
            logger.LogMethodEntry("RptExamFreqAnalysisPage", "GetQuestionType",
           base.IsTakeScreenShotDuringEntryExit);
            string getQuestionType = string.Empty;
            //Select the window
            base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);           
            //Wait for the element
            base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysis_ySecondQuestionType));
            //Get Type Name
            getQuestionType =
                base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysis_ySecondQuestionType);
            logger.LogMethodExit("RptExamFreqAnalysisPage", "GetQuestionType",
           base.IsTakeScreenShotDuringEntryExit);
            return getQuestionType;

        }
        /// <summary>
        /// Verifying Application Name in Report Generated.
        /// </summary>
        /// <returns>Get Application Name</returns>
        public string GetExamFrequencySecondApplicationName()
        {
            logger.LogMethodEntry("RptExamFreqAnalysisPage", "GetApplicationName",
          base.IsTakeScreenShotDuringEntryExit);
            string getApplicationName = string.Empty;
            //Select the window
            base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);           
            //Wait for the element
            base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ApplicationName));
            //Get App Name
            getApplicationName =
                base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ApplicationName);
            return getApplicationName;


        }

        /// <summary>
        /// Verify Correct Percentage in Report Generated.
        /// </summary>
        /// <returns>Get Correct Percentage.</returns>
        public string GetExamFrequencySecondActivityPercent()
        {
            //Verify Correct Percentage in Report Generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage", "GetApplicationName",
            base.IsTakeScreenShotDuringEntryExit);
            string getPercent = string.Empty;
            //Select the window
            base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            //Wait for the element
            base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondActivityPercent));
            //Get Correct Percent
            getPercent =
                base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondActivityPercent);
            logger.LogMethodExit("RptMainUXPage", "GetApplicationName",
         base.IsTakeScreenShotDuringEntryExit);
            logger.LogMethodExit("RptExamFreqAnalysisPage", "GetApplicationName",
         base.IsTakeScreenShotDuringEntryExit);
            return getPercent;

        }

        /// <summary>
        ///Verify Correct Attempt Displayed in Report Generated.
        /// </summary>
        /// <returns> Correct Attempt.</returns>
        public string GetExamFrequencySecondQuestionCorrectAttemptDetails()
        {
            //Verifying Correct Attempt Displayed in Report Generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage", "CorrectAttemptDetails",
           base.IsTakeScreenShotDuringEntryExit);
            string getCorrectAttemptDetails = string.Empty;
            //Select the window
            base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);          
            //Wait for the element
            base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondCorrectAttempt));
            //Get App Name
            getCorrectAttemptDetails =
                base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondCorrectAttempt);
            logger.LogMethodExit("RptExamFreqAnalysisPage", "CorrectAttemptDetails",
           base.IsTakeScreenShotDuringEntryExit);
            return getCorrectAttemptDetails;
        }
        /// <summary>
        /// Verify InCorrect Attempt Displayed in Report Generated.
        /// </summary>
        /// <returns>InCorrect Attempt</returns>
        public string GetExamFrequencySecondQuestionInCorrectAttemptDetails()
        {
            //Verify InCorrect Attempt Displayed in Report Generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage", "InCorrectAttemptDetails",
           base.IsTakeScreenShotDuringEntryExit);
            string getInCorrectAttemptDetails = string.Empty;
            //Select the window
            base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            //Wait for the element
            base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondInCorrectAttempt));
            //Get App Name
            getInCorrectAttemptDetails =
                base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondInCorrectAttempt);
            logger.LogMethodExit("RptExamFreqAnalysisPage", "InCorrectAttemptDetails",
           base.IsTakeScreenShotDuringEntryExit);
            return getInCorrectAttemptDetails;
        }

        /// <summary>
        ///Verify Skipped Attempt Displayed in Report Generated.
        /// </summary>
        /// <returns>Skipped Attempt</returns>
        public string GetExamFrequencySecondQuestionSkippedAttemptDetails()
        {
            //Verify Skipped Attempt Displayed in Report Generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage", "SkippedAttemptDetails",
           base.IsTakeScreenShotDuringEntryExit);
            string getSkippedAttemptDetails = string.Empty;
            //Select the window
            base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            //Wait for the element
            base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                 RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondSkippedAttempt));
            //Get App Name
            getSkippedAttemptDetails =
                base.GetElementTextByXPath("//table[@id='MainTBL']/tbody/tr[2]/td[9]");
            logger.LogMethodExit("RptExamFreqAnalysisPage", "SkippedAttemptDetails",
           base.IsTakeScreenShotDuringEntryExit);
            return getSkippedAttemptDetails;
        }

    }
}

