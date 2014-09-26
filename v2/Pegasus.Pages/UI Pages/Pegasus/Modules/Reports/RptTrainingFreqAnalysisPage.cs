
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

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus RptTrainingFreqAnalysis Page Actions   
    /// </summary>

    public class RptTrainingFreqAnalysisPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptTrainingFreqAnalysisPage));

        /// <summary>
        /// Get Activity Score From Generated Report.
        /// </summary>
        /// <returns>Activity Score.</returns>
        public String GetActivityScoreFromGeneratedReport()
        {
            //Get Activity Score From Generated Report
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage",
                "GetActivityScoreFromGeneratedReport"
                , base.IsTakeScreenShotDuringEntryExit);
            //Initialized Activity Score Variable
            string getActivityScore = string.Empty;
            try
            {
                //Select Window
                this.SelectWindow();
                base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
                    RptTrainingFreqAnalysisPage_Resource_ActivityScore_Xpath_Locator));
                //Get Activity Score
                getActivityScore = base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
                    RptTrainingFreqAnalysisPage_Resource_ActivityScore_Xpath_Locator);
                string[] score =
                    getActivityScore.Split(Convert.ToChar(RptTrainingFreqAnalysisPageResource.
                    RptTrainingFreqAnalysisPage_Resource_ActivityScore_SplittingCharacter));
                //Score Of The Activity
                getActivityScore = score[Convert.ToInt32(
                    RptTrainingFreqAnalysisPageResource.
                    RptTrainingFreqAnalysisPage_Resource_SplittedScore_Index_Value)];
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptTrainingFreqAnalysisPage",
                "GetActivityScoreFromGeneratedReport"
                , base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage", "SelectWindow"
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait Until Window
            base.WaitUntilWindowLoads(RptTrainingFreqAnalysisPageResource.
                RptTrainingFreqAnalysisPage_Resource_Window_Title);
            //Selecting the 'Training Frequency Analysis' window                
            base.SelectWindow(RptTrainingFreqAnalysisPageResource.
                RptTrainingFreqAnalysisPage_Resource_Window_Title);
            logger.LogMethodExit("RptTrainingFreqAnalysisPage", "SelectWindow"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifying Activity Name in Report Generated.
        /// </summary>
        /// <returns>Get Activity Name</returns>
        public string GetFrequencyAnalysisActivityNameInReport(string chapterName)
        {
            //Verifying Activity Name in Report Generated
            logger.LogMethodExit("RptTrainingFreqAnalysisPage", "VerifyingActivityNameinReport",
                base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            switch (chapterName)
            {
                case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                    base.WaitUntilWindowLoads("Exam Frequency Analysis");
                    base.SelectWindow("Exam Frequency Analysis");
                    break;
                case "Excel Chapter 1 Skill-Based Training":
                    base.WaitUntilWindowLoads("Training Frequency Analysis");
                    base.SelectWindow("Training Frequency Analysis");
                    break;
            }           
            //Wait for the element
            base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_ActivityName));
            //Get Activity Name
            getActivityName =
                base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_ActivityName);                
            logger.LogMethodExit("RptTrainingFreqAnalysisPage", "VerifyingActivityNameinReport",
                base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Verifying Activity Report Score as 50%.
        /// </summary>
        /// <returns>Get Activity Score</returns>
        public string GetFrequencyAnalysisScoreInReport(string score)
        {
            //Verifying Activity Report Score as 50%
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage", " VerifyingActivityReportScore",
                  base.IsTakeScreenShotDuringEntryExit);
            string getActivityScore = string.Empty;
            switch (score)
            {
                case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                    base.WaitUntilWindowLoads("Exam Frequency Analysis");
                    base.SelectWindow("Exam Frequency Analysis");
                    break;
                case "Excel Chapter 1 Skill-Based Training":
                    base.WaitUntilWindowLoads("Training Frequency Analysis");
                    base.SelectWindow("Training Frequency Analysis");
                    break;
            }           
            //Wait for the element
            base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_Score));               
            //Get Activity Score
            getActivityScore =
                base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_Score);
            logger.LogMethodExit("RptTrainingFreqAnalysisPage", "VerifyingActivityReportScore",
                 base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Verify question name in Training Frequency report generated.
        /// </summary>
        /// <returns>Question Name.</returns>
        public string GetTrainingFrequencyFirstQuestionName()
        {
            //Verify question name in Training Frequency report generated
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage", "GetTrainingFrequencyName",
             base.IsTakeScreenShotDuringEntryExit);
            string getTrainingQuestionName = string.Empty;
            base.WaitUntilWindowLoads("Training Frequency Analysis");
            base.SelectWindow("Training Frequency Analysis");            
            //Wait for the element
            base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_FirstQuestionName));
            //Get Question Name
            getTrainingQuestionName =
                base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_FirstQuestionName);
            logger.LogMethodExit("RptTrainingFreqAnalysisPage", "GetTrainingFrequencyName",
          base.IsTakeScreenShotDuringEntryExit);
            return getTrainingQuestionName;
        }

        /// <summary>
        /// Verify Application name in  Training Frequency report generated.
        /// </summary>
        /// <returns>Application Name.</returns>
        public string GetTrainingFrequencyFirstApplicationName()
        {
            //Verify Application name in  Training Frequency report generated
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage", "GetTrainingFrequencyAppNAme",
           base.IsTakeScreenShotDuringEntryExit);
            string getTrainingAppName = string.Empty;
            base.WaitUntilWindowLoads("Training Frequency Analysis");
            base.SelectWindow("Training Frequency Analysis");
                       //Wait for the element
            base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_FirstApplicationName));
            //Get Application Name
            getTrainingAppName =
                base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_FirstApplicationName);
            logger.LogMethodExit("RptTrainingFreqAnalysisPage", "GetTrainingFrequencyAppNAme",
         base.IsTakeScreenShotDuringEntryExit);
            return getTrainingAppName;
        }

        /// <summary>
        ///  Verify Percentage in  Training Frequency report generated.
        /// </summary>
        /// <returns>Percentage</returns>
        public string GetTrainingFrequencyFirstQuestionPercentage()
        {
            //Verify Percentage in  Training Frequency report generated
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage", "GetTrainingFrequencyPercentage",
          base.IsTakeScreenShotDuringEntryExit);
            string getTrainingPercentage = string.Empty;
            base.WaitUntilWindowLoads("Training Frequency Analysis");
            base.SelectWindow("Training Frequency Analysis");            
            //Wait for the element
            base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_FirstQuestionPercentage));
            //Get SIM Percentage
            getTrainingPercentage =
                base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_FirstQuestionPercentage);
            logger.LogMethodExit("RptTrainingFreqAnalysisPage", "GetTrainingFrequencyPercentage",
        base.IsTakeScreenShotDuringEntryExit);
            return getTrainingPercentage;
        }

        /// <summary>
        ///  Verify SIM Question Name in Report Generated.
        /// </summary>
        /// <returns>Question Name.</returns>
        public string GetTrainingFrequencyAnalysisSecondQuestionName()
        {
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage", "GetTrainingFrequencyAnalysisQuestionName",
          base.IsTakeScreenShotDuringEntryExit);
            string getTrainingAnalysisQuestion = string.Empty;
            base.WaitUntilWindowLoads("Training Frequency Analysis");
            base.SelectWindow("Training Frequency Analysis");           
            //Wait for the element
            base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_SecondQuestionName));
            //Get Question Name
            getTrainingAnalysisQuestion =
                base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_SecondQuestionName);
            logger.LogMethodExit("RptTrainingFreqAnalysisPage", "GetTrainingFrequencyAnalysisQuestionName",
        base.IsTakeScreenShotDuringEntryExit);
            return getTrainingAnalysisQuestion;
        }

        /// <summary>
        ///  Verify SIM Application Name in Report Generated.
        /// </summary>
        /// <returns>Application Name.</returns>
        public string GetTrainingFrequencyAnalysisSecondApplicationName()
        {
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage", "GetTrainingFrequencyAnalysisApplicationName",
          base.IsTakeScreenShotDuringEntryExit);
            string getTrainingAnalysisApplication = string.Empty;
            base.WaitUntilWindowLoads("Training Frequency Analysis");
            base.SelectWindow("Training Frequency Analysis");           
            //Wait for the element
            base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_ApplicationName));
            //Get Application Name
            getTrainingAnalysisApplication =
                base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_ApplicationName);
            logger.LogMethodExit("RptTrainingFreqAnalysisPage", "GetTrainingFrequencyAnalysisApplicationName",
         base.IsTakeScreenShotDuringEntryExit);
            return getTrainingAnalysisApplication;
        }

        /// <summary>
        /// Verify SIM Percentage in Report Generated.
        /// </summary>
        /// <returns>Percentage</returns>
        public string GetTrainingFrequencyAnalysisSecondQuestionPercentage()
        {
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage", "GetTrainingFrequencyAnalysisPercentage",
         base.IsTakeScreenShotDuringEntryExit);
            string getTrainingAnalysisPercentage = string.Empty;
            base.WaitUntilWindowLoads("Training Frequency Analysis");
            base.SelectWindow("Training Frequency Analysis");            
            //Wait for the element
            base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_QuestionPercentage));
            //Get SIM Percentage
            getTrainingAnalysisPercentage =
                base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
               RptTrainingFreqAnalysisPage_Resource_QuestionPercentage);
            logger.LogMethodExit("RptTrainingFreqAnalysisPage", "GetTrainingFrequencyAnalysisPercentage",
        base.IsTakeScreenShotDuringEntryExit);
            return getTrainingAnalysisPercentage;
        }

    }
}

