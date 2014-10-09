
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
                    RptExamFreqAnalysisPage_ReportScore_Xpath_Locator),10);
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
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("RptExamFreqAnalysisPage", "SelectWindow"
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait Until Window
            base.WaitUntilWindowLoads(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            //Selecting the 'Training Frequency Analysis' window                
            base.SelectWindow(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_Window_name);
            logger.LogMethodExit("RptExamFreqAnalysisPage", "SelectWindow"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Verifying Question Name in Report Generated.
        /// </summary>
        /// <returns>Get Question Name.</returns>
        public string GetExamFrequencyAnalysisReportQuestionName()
        {
            // Verifying Question Name in Report Generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage",
                "GetExamFrequencyAnalysisReportQuestionName",
              base.IsTakeScreenShotDuringEntryExit);
            string getQuestName = string.Empty;
            try
            {
                //Select the window
                this.SelectWindow();
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
            //Verifying Question Type in Report Generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage", 
                "GetExamFrequencyAnalysisReportTypeName",
               base.IsTakeScreenShotDuringEntryExit);
            string getTypeName = string.Empty;
            try
            {
                //Select the window
                this.SelectWindow();
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
            //Verifying Application Name in Report Generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage", 
                "GetExamFrequencyAnalysisReportApplicationName",
              base.IsTakeScreenShotDuringEntryExit);
            string getAppName = string.Empty;
            try
            {
                //Select the window
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_ApplicationName));
                //Get Application Name
                getAppName =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                    RptExamFreqAnalysisPage_ExamFrequencyAnalysis_ApplicationName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
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
            try
            {
                //Select the window
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysis_CorrectPercentage));
                //Get Correct Percent
                getCorrectPercent =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysis_CorrectPercentage);
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
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
            logger.LogMethodEntry("RptExamFreqAnalysisPage", 
                "GetFirstQuestionCorrectAttempt",
           base.IsTakeScreenShotDuringEntryExit);
            string getCorrectAttempt = string.Empty;
            try
            {
                //Select the window
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysis_CorrectAttempt));
                //Get Correct attempt
                getCorrectAttempt =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysis_CorrectAttempt);
            }
            catch (Exception e)
            {
             ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptExamFreqAnalysisPage",
                "GetFirstQuestionCorrectAttempt",
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
            logger.LogMethodEntry("RptExamFreqAnalysisPage", 
                "GetFirstQuestionIncorrectAttempt",
           base.IsTakeScreenShotDuringEntryExit);
            string getIncorrectAttempt = string.Empty;
            try
            {
                //Select the window
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysis_InCorrectAttempt));
                //Get incorrect attempt
                getIncorrectAttempt =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysis_InCorrectAttempt);
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptExamFreqAnalysisPage", 
                "GetFirstQuestionIncorrectAttempt",
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
            logger.LogMethodEntry("RptExamFreqAnalysisPage", 
                "GetFirstQuestionSkippedAttempt",
           base.IsTakeScreenShotDuringEntryExit);
            string getSkippedAttempt = string.Empty;
            try
            {
                //Select the window
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysis_SkippedAttempt));
                //Get skipped attempt
                getSkippedAttempt =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysis_SkippedAttempt);
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptExamFreqAnalysisPage",
                "GetFirstQuestionSkippedAttempt",
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
            logger.LogMethodEntry("RptExamFreqAnalysisPage", 
                "GetExamFrequencySecondQuestionName",
            base.IsTakeScreenShotDuringEntryExit);
            string getQName = string.Empty;
            try
            {
                //Select the window
                this.SelectWindow();                
                //Wait for the element
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysis_ySecondQuestionName));
                //Get Question Name
                getQName =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysis_ySecondQuestionName);
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptExamFreqAnalysisPage",
                "GetExamFrequencySecondQuestionName",
           base.IsTakeScreenShotDuringEntryExit);
            return getQName;

        }
        /// <summary>
        /// Verifying Question Type in Report Generated.
        /// </summary>
        /// <returns>Get Applicattion Type</returns>
        public string GetExamFrequencySecondQuestionType()
        {
            logger.LogMethodEntry("RptExamFreqAnalysisPage", 
                "GetExamFrequencySecondQuestionType",
           base.IsTakeScreenShotDuringEntryExit);
            string getQuestionType = string.Empty;
            try
            {
                //Select the window
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysis_ySecondQuestionType));
                //Get Type Name
                getQuestionType =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysis_ySecondQuestionType);
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptExamFreqAnalysisPage",
                "GetExamFrequencySecondQuestionType",
           base.IsTakeScreenShotDuringEntryExit);
            return getQuestionType;

        }
        /// <summary>
        /// Verifying Application Name in Report Generated.
        /// </summary>
        /// <returns>Get Application Name.</returns>
        public string GetExamFrequencySecondApplicationName()
        {
            logger.LogMethodEntry("RptExamFreqAnalysisPage",
                "GetExamFrequencySecondApplicationName",
            base.IsTakeScreenShotDuringEntryExit);
            string getApplicationName = string.Empty;
            try
            {
                //Select the window
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ApplicationName));
                //Get App Name
                getApplicationName =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ApplicationName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptExamFreqAnalysisPage", 
                "GetExamFrequencySecondApplicationName",
              base.IsTakeScreenShotDuringEntryExit);
            return getApplicationName;


        }

        /// <summary>
        /// Verify Correct Percentage in Report Generated.
        /// </summary>
        /// <returns>Get Correct Percentage.</returns>
        public string GetExamFrequencySecondActivityPercent()
        {
            //Verify Correct Percentage in Report Generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage",
                "GetExamFrequencySecondActivityPercent",
            base.IsTakeScreenShotDuringEntryExit);
            string getPercent = string.Empty;
            try
            {
                //Select the window
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondActivityPercent));
                //Get Correct Percent
                getPercent =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondActivityPercent).Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptMainUXPage",
                "GetExamFrequencySecondActivityPercent",
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
            logger.LogMethodEntry("RptExamFreqAnalysisPage", 
                "GetExamFrequencySecondQuestionCorrectAttemptDetails",
           base.IsTakeScreenShotDuringEntryExit);
            string getCorrectAttemptDetails = string.Empty;
            try
            {
                //Select the window
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondCorrectAttempt));
                //Get App Name
                getCorrectAttemptDetails =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondCorrectAttempt);
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptExamFreqAnalysisPage",
                "GetExamFrequencySecondQuestionCorrectAttemptDetails",
           base.IsTakeScreenShotDuringEntryExit);
            return getCorrectAttemptDetails;
        }
        /// <summary>
        /// Verify InCorrect Attempt Displayed in Report Generated.
        /// </summary>
        /// <returns>InCorrect Attempt.</returns>
        public string GetExamFrequencySecondQuestionInCorrectAttemptDetails()
        {
            //Verify InCorrect Attempt Displayed in Report Generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage", 
                "GetExamFrequencySecondQuestionInCorrectAttemptDetails",
           base.IsTakeScreenShotDuringEntryExit);
            string getInCorrectAttemptDetails = string.Empty;
            try
            {
                //Select the window
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondInCorrectAttempt));
                //Get App Name
                getInCorrectAttemptDetails =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondInCorrectAttempt);
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptExamFreqAnalysisPage", 
                "GetExamFrequencySecondQuestionInCorrectAttemptDetails",
           base.IsTakeScreenShotDuringEntryExit);
            return getInCorrectAttemptDetails;
        }

        /// <summary>
        ///Verify Skipped Attempt Displayed in Report Generated.
        /// </summary>
        /// <returns>Skipped Attempt.</returns>
        public string GetExamFrequencySecondQuestionSkippedAttemptDetails()
        {
            //Verify Skipped Attempt Displayed in Report Generated
            logger.LogMethodEntry("RptExamFreqAnalysisPage", 
                "GetExamFrequencySecondQuestionSkippedAttemptDetails",
           base.IsTakeScreenShotDuringEntryExit);
            string getSkippedAttemptDetails = string.Empty;
            try
            {
                //Select the window
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondSkippedAttempt));
                //Get App Name
                getSkippedAttemptDetails =
                    base.GetElementTextByXPath(RptExamFreqAnalysisPageResource.
                     RptExamFreqAnalysisPage_ExamFrequencyAnalysisy_SecondSkippedAttempt);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptExamFreqAnalysisPage", 
                "GetExamFrequencySecondQuestionSkippedAttemptDetails",
           base.IsTakeScreenShotDuringEntryExit);
            return getSkippedAttemptDetails;
        }

        /// <summary>
        /// Verify the Question name in Exam frequency analysis report.
        /// </summary>
        /// <param name="questionName">This is a question name.</param>
        /// <returns>Question name.</returns>
        public Boolean IsQuestionPresentInExamFrequencyAnalysis(string questionName)
        {
            //Verify the Question name
            logger.LogMethodEntry("RptExamFreqAnalysisPage",
                "IsQuestionPresentInExamFrequencyAnalysis",
                base.IsTakeScreenShotDuringEntryExit);
            bool isQuestionPresent = false;
            string getQuestionName = string.Empty;
            //Select reports window
            this.SelectWindow();
            try
            {
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                    RptMainUX_Page_ExamFrequencyAnalysis_QuestionCount_Xpath_Locator));
                int getCount = base.GetElementCountByXPath(RptExamFreqAnalysisPageResource.
                    RptMainUX_Page_ExamFrequencyAnalysis_QuestionCount_Xpath_Locator);
                for (int questionSearch = 1; questionSearch <= getCount; questionSearch++)
                {
                    //Get the question name
                    getQuestionName = base.GetElementTextByXPath(string.
                       Format(RptExamFreqAnalysisPageResource.
                       RptMainUX_Page_ExamFrequencyAnalysis_QuestionName_Xpath_Locator, 
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
            logger.LogMethodExit("RptExamFreqAnalysisPage", 
                "IsQuestionPresentInExamFrequencyAnalysis",
                base.IsTakeScreenShotDuringEntryExit);
            return isQuestionPresent;
        }

        /// <summary>
        /// Verify the Question details in Exam frequency analysis report.
        /// </summary>
        /// <param name="questionName">This is a Question name.</param>
        /// <param name="questionColumnData">This is Question details column name.</param>
        /// <returns>Question details.</returns>
        public string GetExamFrequencyAnalysisQuestionDetails(string questionName,
            int questionColumnData)
        {
            //Verify the Question details
            logger.LogMethodEntry("RptExamFreqAnalysisPage", "GetQuestionDetails",
                   base.IsTakeScreenShotDuringEntryExit);
            string getQuestionName = string.Empty;
            string getQuestionDetails = string.Empty;
            this.SelectWindow();
            try
            {
                base.WaitForElement(By.XPath(RptExamFreqAnalysisPageResource.
                    RptMainUX_Page_ExamFrequencyAnalysis_QuestionCount_Xpath_Locator));
                int getCount = base.GetElementCountByXPath(RptExamFreqAnalysisPageResource.
                    RptMainUX_Page_ExamFrequencyAnalysis_QuestionCount_Xpath_Locator);
                for (int questionSearch = 1; questionSearch <= getCount; questionSearch++)
                {
                    //Get the question name
                    getQuestionName = base.GetElementTextByXPath(
                        String.Format(RptExamFreqAnalysisPageResource.
                       RptMainUX_Page_ExamFrequencyAnalysis_QuestionName_Xpath_Locator, 
                       questionSearch));
                    if (getQuestionName == questionName)
                    {                        
                        //Get the question details
                        base.WaitForElement(By.XPath(String.Format(RptExamFreqAnalysisPageResource.
                            RptMainUX_Page_ExamFrequencyAnalysis_QuestionDetails_Xpath_Locator,
                            questionSearch, questionColumnData)));
                        getQuestionDetails = base.GetElementTextByXPath(String.
                            Format(RptExamFreqAnalysisPageResource.
                            RptMainUX_Page_ExamFrequencyAnalysis_QuestionDetails_Xpath_Locator,
                            questionSearch, questionColumnData));
                        break;
                    }                    
                 }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptExamFreqAnalysisPage", "GetQuestionDetails",
                    base.IsTakeScreenShotDuringEntryExit);
            return getQuestionDetails;
        }
    }
}

