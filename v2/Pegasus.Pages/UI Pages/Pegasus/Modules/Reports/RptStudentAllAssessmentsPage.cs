using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus RptStudentAllAssessments Page Actions
    /// </summary>
    public class RptStudentAllAssessmentsPage:BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = 
            Logger.GetInstance(typeof(RptStudentAllAssessmentsPage));

        /// <summary>
        /// Get Activity Result Single Student Score In Report.
        /// </summary> 
        /// <returns>Activity Score.</returns>
        public string GetActivityResultSingleStudentScoreInReport()
        {
            //Get Activity Result Single Student Score In Report
            logger.LogMethodEntry("RptStudentAllAssessmentsPage", 
                "GetActivityResultSingleStudentScoreInReport",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialized Activity Score Variable
            string getActivityScore = string.Empty;
            try
            {
                //Select Activity Results Window
                this.SelectActivityResultsWindow();
                //Wait for the element
                base.WaitForElement(By.Id(RptStudentAllAssessmentsPageResource.
                    RptStudentAllAssessmentsPage_ActivityResult_Score_Id_Locator));
                //Get Activity Score
                getActivityScore = base.GetElementTextById(
                    RptStudentAllAssessmentsPageResource.
                    RptStudentAllAssessmentsPage_ActivityResult_Score_Id_Locator);
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
            logger.LogMethodExit("RptStudentAllAssessmentsPage",
                "GetActivityResultSingleStudentScoreInReport",
                base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Select Activity Results Window.
        /// </summary>
        private void SelectActivityResultsWindow()
        {
            //Select Activity Results Window
            logger.LogMethodEntry("RptStudentAllAssessmentsPage",
               "SelectActivityResultsWindow",
               base.IsTakeScreenShotDuringEntryExit);
            //Select the window
            base.WaitUntilWindowLoads(RptStudentAllAssessmentsPageResource.
                RptStudentAllAssessmentsPage_ActivityResult_Window_name);
            base.SelectWindow(RptStudentAllAssessmentsPageResource.
                RptStudentAllAssessmentsPage_ActivityResult_Window_name);
            logger.LogMethodExit("RptStudentAllAssessmentsPage",
                "SelectActivityResultsWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
