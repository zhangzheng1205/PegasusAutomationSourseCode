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
using System;


namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports
{
        /// <summary>
    /// This class handles Study plan Reports Page Actions.  
    /// </summary>
    public class RptStudyPlanReportPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(
            typeof(RptStudyPlanReportPage));

        /// <summary>
        /// Get the Score from the Learning Aid Usage Report.
        /// </summary>
        /// <param name="chapterName">This is the Score.</param>       
        /// <returns>Score.</returns>
        public string GetAverageHSSstudyPlanScoreInReport()
        {
            // Get the details from the learning aid usage report
            logger.LogMethodEntry("RptStudyPlanReportPage",
                "GetLearningAidUsageScoreInReport",
                   base.IsTakeScreenShotDuringEntryExit);
            string getaverageScore = string.Empty;
            base.SwitchToLastOpenedWindow();
            //this.SelectWindow();
            try
            {
                base.WaitForElement(By.XPath(RptStudyPlanReportPageResource.
                    RptStudyPlanReportPage_Average_XPath_Locator));
                getaverageScore = base.GetElementTextByXPath(
                    RptStudyPlanReportPageResource.
                    RptStudyPlanReportPage_Average_XPath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudyPlanReportPage",
               "GetLearningAidUsageScoreInReport",
                   base.IsTakeScreenShotDuringEntryExit);
            return getaverageScore;
        }
        /// <summary>
        /// Get Student Name In Study Plan Activity
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public bool GetStudentNameInStudtPlanActivity(string studentName)
        {
            logger.LogMethodEntry("RptStudyPlanReportPage",
                "GetStudentNameInStudtPlanActivity",
                base.IsTakeScreenShotDuringEntryExit);
            bool isStudentDisplayed = false;
            string getStudentName = string.Empty;
            base.WaitForElement(By.XPath(RptStudyPlanReportPageResource.
                RptStudyPlanReportPage_StudentCount_XPath_Locator));
            int getStudentNameCount = base.GetElementCountByXPath(RptStudyPlanReportPageResource.
                RptStudyPlanReportPage_StudentCount_XPath_Locator);
            for (int i = 1; i <= getStudentNameCount; i++)
            {
                base.WaitForElement(By.XPath(string.Format(
                    RptStudyPlanReportPageResource.
                    RptStudyPlanReportPage_StudentName_XPath_Locator, i)));
                getStudentName = base.GetElementTextByXPath(string.Format(
                     RptStudyPlanReportPageResource.
                    RptStudyPlanReportPage_StudentName_XPath_Locator, i));
                if (getStudentName == studentName)
                {
                    isStudentDisplayed = true;
                    break;
                }
                i++;
            }
            logger.LogMethodExit("RptStudyPlanReportPage",
            "GetStudentNameInStudtPlanActivity",
                 base.IsTakeScreenShotDuringEntryExit);
            return isStudentDisplayed;
        }

        /// <summary>
        /// Gets the number of attemps taken by student.
        /// </summary>
        /// <returns>Number of attempts.</returns>
        public string GetStudentStudyPlanPreTestScore(string studentName, int scoreRow)
        {
            //VGets the number of attemps taken by student 
            logger.LogMethodEntry("RptStudyPlanReportPage", "GetStudentStudyPlanPreTestScore",
                base.IsTakeScreenShotDuringEntryExit);
            string getStudentName = string.Empty;
            string getStudentPreTestScore = string.Empty;
            try
            {               
                base.WaitForElement(By.XPath(RptStudyPlanReportPageResource.
                    RptStudyPlanReportPage_StudentCount_XPath_Locator));
                int getStudentNameCount = base.GetElementCountByXPath(RptStudyPlanReportPageResource.
                    RptStudyPlanReportPage_StudentCount_XPath_Locator);

                for (int i = 1; i <= getStudentNameCount; i++)
                {
                    base.WaitForElement(By.XPath(string.Format(
                        RptStudyPlanReportPageResource.
                    RptStudyPlanReportPage_StudentName_XPath_Locator, i)));
                    getStudentName = base.GetElementTextByXPath(string.Format(
                         RptStudyPlanReportPageResource.
                    RptStudyPlanReportPage_StudentName_XPath_Locator, i));
                    if (getStudentName == studentName)
                    {
                        base.WaitForElement(By.XPath(string.Format(
                            RptStudyPlanReportPageResource.
                            RptStudyPlanReportPage_PreTestScore_XPath_Locator, scoreRow)));

                        getStudentPreTestScore = base.GetElementTextByXPath(string.Format(
                            RptStudyPlanReportPageResource.
                            RptStudyPlanReportPage_PreTestScore_XPath_Locator, scoreRow));
                        break;
                    }
                    i++;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudyPlanReportPage", "GetStudentStudyPlanPreTestScore",
                base.IsTakeScreenShotDuringEntryExit);
            return getStudentPreTestScore;
        }

        /// <summary>
        /// Gets the number of attemps taken by student.
        /// </summary>
        /// <returns>Number of attempts.</returns>
        public string GetStudentStudyPlanPostTestScore(string studentName, int scoreRow)
        {
            //VGets the number of attemps taken by student 
            logger.LogMethodEntry("RptStudyPlanReportPage", "GetStudentAttempt",
                base.IsTakeScreenShotDuringEntryExit);
            string getStudentName = string.Empty;
            string getStudentPostTestScore = string.Empty;
            try
            {                
                base.WaitForElement(By.XPath(RptStudyPlanReportPageResource.
                    RptStudyPlanReportPage_StudentCount_XPath_Locator));
                int getStudentNameCount = base.GetElementCountByXPath(RptStudyPlanReportPageResource.
                    RptStudyPlanReportPage_StudentCount_XPath_Locator);
                for (int i = 1; i <= getStudentNameCount; i++)
                {
                    base.WaitForElement(By.XPath(string.Format(
                        RptStudyPlanReportPageResource.
                    RptStudyPlanReportPage_StudentName_XPath_Locator, i)));
                    getStudentName = base.GetElementTextByXPath(string.Format(
                         RptStudyPlanReportPageResource.
                    RptStudyPlanReportPage_StudentName_XPath_Locator, i));
                    if (getStudentName == studentName)
                    {
                        base.WaitForElement(By.XPath(string.Format(
                            RptStudyPlanReportPageResource.
                            RptStudyPlanReportPage_PostTestScore_XPath_Locator, scoreRow)));

                        getStudentPostTestScore = base.GetElementTextByXPath(string.
                       Format(RptStudyPlanReportPageResource.
                            RptStudyPlanReportPage_PostTestScore_XPath_Locator, scoreRow));
                        break;
                    }
                    i++;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudyPlanReportPage", "GetStudentAttempt",
                base.IsTakeScreenShotDuringEntryExit);
            return getStudentPostTestScore;
        }
    }
}
