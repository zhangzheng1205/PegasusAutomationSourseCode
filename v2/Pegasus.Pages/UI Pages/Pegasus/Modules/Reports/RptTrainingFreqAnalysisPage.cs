
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
        /// Verifying activity name in the report generated.
        /// </summary>
        /// <returns>Activity Name.</returns>
        public string GetFrequencyAnalysisActivityNameInReport(string chapterName)
        {
            //Verifying activity name in the report generated
            logger.LogMethodExit("RptTrainingFreqAnalysisPage",
                "GetFrequencyAnalysisActivityNameInReport",
                base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            try
            {
                switch (chapterName)
                {
                    case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                        base.SwitchToLastOpenedWindow();                        
                        getActivityName = base.GetElementTextByXPath(
                            RptTrainingFreqAnalysisPageResource.
                            RptTrainingFrequencyPage_Resource_NameOfActivity);
                        break;

                    case "Excel Chapter 1 Skill-Based Training":
                        base.SwitchToLastOpenedWindow();                        
                        getActivityName = base.GetElementTextByXPath(
                            RptTrainingFreqAnalysisPageResource.
                   RptTrainingFreqAnalysisPage_Resource_ActivityName);
                      break;
               }                                     
              }
                              
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptTrainingFreqAnalysisPage",
                "GetFrequencyAnalysisActivityNameInReport",
                base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Verifying activity report score.
        /// </summary>
        /// <returns>Activity Score.</returns>
        public string GetFrequencyAnalysisScoreInReport(string chapterName,string score)
        {
            //Verifying activity report score 
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage",
                " GetFrequencyAnalysisScoreInReport",
                  base.IsTakeScreenShotDuringEntryExit);
            string getActivityScore = string.Empty;
            try
            {
                switch (chapterName)
                {
                    case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                        base.SwitchToLastOpenedWindow(); 
                        getActivityScore =
                            base.GetElementTextByXPath(
                            RptTrainingFreqAnalysisPageResource.
                            RptTrainingFrequencyPage_Resource_ActivityScore);
                        break;

                    case "Excel Chapter 1 Skill-Based Training":
                        base.SwitchToLastOpenedWindow(); 
                        getActivityScore =
                             base.GetElementTextByXPath(
                             RptTrainingFreqAnalysisPageResource.
                             RptTrainingFreqAnalysisPage_Resource_Score);
                        break;
                }
                      
            }               
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptTrainingFreqAnalysisPage",
                "GetFrequencyAnalysisScoreInReport",
                 base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Verify question name in training frequency report generated.
        /// </summary>
        /// <returns>Question Name.</returns>
        public string GetTrainingFrequencyFirstQuestionName()
        {
            //Verify question name in training frequency report generated
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage",
                "GetTrainingFrequencyFirstQuestionName",
             base.IsTakeScreenShotDuringEntryExit);
            string getTrainingQuestionName = string.Empty;
            try
            {
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
                   RptTrainingFreqAnalysisPage_Resource_FirstQuestionName));
                //Get Question Name
                getTrainingQuestionName =
                    base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
                   RptTrainingFreqAnalysisPage_Resource_FirstQuestionName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptTrainingFreqAnalysisPage",
                "GetTrainingFrequencyFirstQuestionName",
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
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage",
                "GetTrainingFrequencyFirstApplicationName",
           base.IsTakeScreenShotDuringEntryExit);
            string getTrainingAppName = string.Empty;
            try
            {
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
                   RptTrainingFreqAnalysisPage_Resource_FirstApplicationName));
                //Get Application Name
                getTrainingAppName =
                    base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
                   RptTrainingFreqAnalysisPage_Resource_FirstApplicationName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptTrainingFreqAnalysisPage",
                "GetTrainingFrequencyFirstApplicationName",
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
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage",
                "GetTrainingFrequencyFirstQuestionPercentage",
          base.IsTakeScreenShotDuringEntryExit);
            string getTrainingPercentage = string.Empty;
            try
            {
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
                   RptTrainingFreqAnalysisPage_Resource_FirstQuestionPercentage));
                //Get SIM Percentage
                getTrainingPercentage =
                    base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
                   RptTrainingFreqAnalysisPage_Resource_FirstQuestionPercentage);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptTrainingFreqAnalysisPage",
                "GetTrainingFrequencyFirstQuestionPercentage",
        base.IsTakeScreenShotDuringEntryExit);
            return getTrainingPercentage;
        }

        /// <summary>
        ///  Verify SIM Question Name in Report Generated.
        /// </summary>
        /// <returns>Question Name.</returns>
        public string GetTrainingFrequencyAnalysisSecondQuestionName()
        {
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage",
                "GetTrainingFrequencyAnalysisSecondQuestionName",
          base.IsTakeScreenShotDuringEntryExit);
            string getTrainingAnalysisQuestion = string.Empty;
            try
            {
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
                   RptTrainingFreqAnalysisPage_Resource_SecondQuestionName));
                //Get Question Name
                getTrainingAnalysisQuestion =
                    base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
                   RptTrainingFreqAnalysisPage_Resource_SecondQuestionName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptTrainingFreqAnalysisPage",
                "GetTrainingFrequencyAnalysisSecondQuestionName",
        base.IsTakeScreenShotDuringEntryExit);
            return getTrainingAnalysisQuestion;
        }

        /// <summary>
        ///  Verify SIM Application Name in Report Generated.
        /// </summary>
        /// <returns>Application Name.</returns>
        public string GetTrainingFrequencyAnalysisSecondApplicationName()
        {
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage",
                "GetTrainingFrequencyAnalysisSecondApplicationName",
          base.IsTakeScreenShotDuringEntryExit);
            string getTrainingAnalysisApplication = string.Empty;
            try
            {
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
                   RptTrainingFreqAnalysisPage_Resource_ApplicationName));
                //Get Application Name
                getTrainingAnalysisApplication =
                    base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
                   RptTrainingFreqAnalysisPage_Resource_ApplicationName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptTrainingFreqAnalysisPage",
                "GetTrainingFrequencyAnalysisSecondApplicationName",
         base.IsTakeScreenShotDuringEntryExit);
            return getTrainingAnalysisApplication;
        }

        /// <summary>
        /// Verify SIM Percentage in Report Generated.
        /// </summary>
        /// <returns>Percentage</returns>
        public string GetTrainingFrequencyAnalysisSecondQuestionPercentage()
        {
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage",
                "GetTrainingFrequencyAnalysisSecondQuestionPercentage",
         base.IsTakeScreenShotDuringEntryExit);
            string getTrainingAnalysisPercentage = string.Empty;
            try
            {
                this.SelectWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
                   RptTrainingFreqAnalysisPage_Resource_QuestionPercentage));
                //Get SIM Percentage
                getTrainingAnalysisPercentage =
                    base.GetElementTextByXPath(RptTrainingFreqAnalysisPageResource.
                   RptTrainingFreqAnalysisPage_Resource_QuestionPercentage);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptTrainingFreqAnalysisPage",
                "GetTrainingFrequencyAnalysisSecondQuestionPercentage",
        base.IsTakeScreenShotDuringEntryExit);
            return getTrainingAnalysisPercentage;
        }

        /// <summary>
        /// Verify the Question name.
        /// </summary>
        /// <param name="questionName">This is a question name.</param>
        /// <returns>Question name.</returns>
        public Boolean IsQuestionPresent(string questionName)
        {
            //Verify the Question name
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage", "IsQuestionPresent",
                base.IsTakeScreenShotDuringEntryExit);
            bool isQuestionPresent = false;
            string getQuestionName = string.Empty;
            //Select reports window
            this.SelectWindow();
            try
            {
                base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
                    RptTrainingFreqAnalysisPage_Resource_QuestionCount_Xpath_Locator));
                //Get the count of the total questions displayed
                int getQuestionCount = base.GetElementCountByXPath(RptTrainingFreqAnalysisPageResource.
                    RptTrainingFreqAnalysisPage_Resource_QuestionCount_Xpath_Locator);
                for (int questionSearch = 1; questionSearch <= getQuestionCount; questionSearch++)
                {
                    //Get the question name
                    getQuestionName = base.GetElementTextByXPath(string.
                       Format(RptTrainingFreqAnalysisPageResource.
                       RptTrainingFreqAnalysisPage_Resource_QuestionName_Xpath_Locator,
                       questionSearch));
                    if (getQuestionName == questionName)
                    {
                        isQuestionPresent = true;
                        break;
                    }
                    questionSearch++;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptTrainingFreqAnalysisPage", "IsQuestionPresent",
                base.IsTakeScreenShotDuringEntryExit);
            return isQuestionPresent;
        }

        /// <summary>
        /// Verify the Question details in Exam frequency analysis report.
        /// </summary>
        /// <param name="questionName">This is a question name.</param>
        /// <param name="questionColumnData">This is question detail column.</param>
        /// <returns>Question details.</returns>
        public string GetQuestionDetails(string questionName, int questionColumnData)
        {
            // //Verify the Question details in Exam frequency analysis report
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage", "GetQuestionDetails",
                   base.IsTakeScreenShotDuringEntryExit);
            //Intialize the variable
            string getQuestionName = string.Empty;
            string getQuestionDetails = string.Empty;
            this.SelectWindow();
            try
            {
                //Verify the Question details in Exam frequency analysis report.
                base.WaitForElement(By.XPath(RptTrainingFreqAnalysisPageResource.
                    RptTrainingFreqAnalysisPage_Resource_QuestionCount_Xpath_Locator));
                //Get the count of the questions present
                int getCount = base.GetElementCountByXPath(RptTrainingFreqAnalysisPageResource.
                    RptTrainingFreqAnalysisPage_Resource_QuestionCount_Xpath_Locator);
                for (int questionSearch = 1; questionSearch <= getCount; questionSearch++)
                {
                    //Fetch the question name
                    getQuestionName = base.GetElementTextByXPath(
                        String.Format(RptTrainingFreqAnalysisPageResource.
                       RptTrainingFreqAnalysisPage_Resource_QuestionName_Xpath_Locator,
                       questionSearch));
                    if (getQuestionName == questionName)
                    {
                        base.WaitForElement(By.XPath(String.Format(RptTrainingFreqAnalysisPageResource.
                            RptTrainingFreqAnalysisPage_Resource_QuestionDetails_Xpath_Locator, 
                            questionSearch, questionColumnData)));
                        //Get the question details
                        getQuestionDetails = base.GetElementTextByXPath(String.
                            Format(RptTrainingFreqAnalysisPageResource.
                            RptTrainingFreqAnalysisPage_Resource_QuestionDetails_Xpath_Locator,
                            questionSearch, questionColumnData));
                        break;
                    }
                    questionSearch++;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptTrainingFreqAnalysisPage", "GetQuestionDetails",
                    base.IsTakeScreenShotDuringEntryExit);
            return getQuestionDetails;
        }
    }
}

