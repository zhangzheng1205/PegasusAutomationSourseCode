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
                , base.isTakeScreenShotDuringEntryExit);
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
                , base.isTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("RptTrainingFreqAnalysisPage", "SelectWindow"
                , base.isTakeScreenShotDuringEntryExit);
            //Wait Until Window
            base.WaitUntilWindowLoads(RptTrainingFreqAnalysisPageResource.
                RptTrainingFreqAnalysisPage_Resource_Window_Title);
            //Selecting the 'Training Frequency Analysis' window                
            base.SelectWindow(RptTrainingFreqAnalysisPageResource.
                RptTrainingFreqAnalysisPage_Resource_Window_Title);
            logger.LogMethodExit("RptTrainingFreqAnalysisPage", "SelectWindow"
               , base.isTakeScreenShotDuringEntryExit);
        }
    }
}
