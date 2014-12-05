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
                getaverageScore = base.GetElementTextByXPath("//*[@id='_ctl3_AveragePlaceHolder']/table/tbody/tr/td[1]/span");
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

        public bool GetStudentNameInStudtPlanActivity(string studentName)
        {
            logger.LogMethodEntry("RptActivityResultByStudentPage",
                "GetActivityDetailsInActivityResultByStudent",
                base.IsTakeScreenShotDuringEntryExit);
            bool isStudentDisplayed = false;
            string getStudentName = string.Empty;
            base.WaitForElement(By.XPath("//*[@id='MainDiv']/table[3]/tbody/tr"));
            int getStudentNameCount = base.GetElementCountByXPath("//*[@id='MainDiv']/table[3]/tbody/tr");
            for (int i = 1; i <= getStudentNameCount; i++)
            {
                base.WaitForElement(By.XPath(string.Format(
                    "//*[@id='MainDiv']/table[3]/tbody/tr[{0}]/td/b", i)), 10);
                getStudentName = base.GetElementTextByXPath(string.Format(
                     "//*[@id='MainDiv']/table[3]/tbody/tr[{0}]/td/b", i));
                if (getStudentName == studentName)
                {
                    isStudentDisplayed = true;
                    break;
                }
                i++;
            }
            logger.LogMethodExit("RptActivityResultByStudentPage",
            "GetActivityDetailsInActivityResultByStudent",
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
            logger.LogMethodEntry("RptAllAssessmentAllStudentPage", "GetStudentAttempt",
                base.IsTakeScreenShotDuringEntryExit);
            string getStudentName = string.Empty;
            string getStudentPreTestScore = string.Empty;
            try
            {
                logger.LogMethodEntry("RptActivityResultByStudentPage",
                 "GetActivityDetailsInActivityResultByStudent",
                 base.IsTakeScreenShotDuringEntryExit);
                base.WaitForElement(By.XPath("//*[@id='MainDiv']/table[3]/tbody/tr"));
                int getStudentNameCount = base.GetElementCountByXPath("//*[@id='MainDiv']/table[3]/tbody/tr");

                for (int i = 1; i <= getStudentNameCount; i++)
                {
                    base.WaitForElement(By.XPath(string.Format(
                        "//*[@id='MainDiv']/table[3]/tbody/tr[{0}]/td/b", i)), 10);
                    getStudentName = base.GetElementTextByXPath(string.Format(
                         "//*[@id='MainDiv']/table[3]/tbody/tr[{0}]/td/b", i));
                    if (getStudentName == studentName)
                    {
                        base.WaitForElement(By.XPath(string.Format(
                            ".//*[@id='MainDiv']/table[3]/tbody/tr[{0}]/td/table/tbody/tr[1]/td[4]/table/tbody/tr/td[2]/a", scoreRow)));

                        getStudentPreTestScore = base.GetElementTextByXPath(string.Format(
                            ".//*[@id='MainDiv']/table[3]/tbody/tr[{0}]/td/table/tbody/tr[1]/td[4]/table/tbody/tr/td[2]/a", scoreRow));
                        break;
                    }
                    getStudentNameCount++;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAllAssessmentAllStudentPage", "GetStudentAttempt",
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
            logger.LogMethodEntry("RptAllAssessmentAllStudentPage", "GetStudentAttempt",
                base.IsTakeScreenShotDuringEntryExit);
            string getStudentName = string.Empty;
            string getStudentPostTestScore = string.Empty;
            try
            {
                logger.LogMethodEntry("RptActivityResultByStudentPage",
                 "GetActivityDetailsInActivityResultByStudent",
                 base.IsTakeScreenShotDuringEntryExit);
                base.WaitForElement(By.XPath("//*[@id='MainDiv']/table[3]/tbody/tr"));
                int getStudentNameCount = base.GetElementCountByXPath("//*[@id='MainDiv']/table[3]/tbody/tr");
                //*[@id='MainDiv']/table[3]/tbody/tr[1]/td/b
                for (int i = 1; i <= getStudentNameCount; i++)
                {
                    base.WaitForElement(By.XPath(string.Format(
                        "//*[@id='MainDiv']/table[3]/tbody/tr[{0}]/td/b", i)), 10);
                    getStudentName = base.GetElementTextByXPath(string.Format(
                         "//*[@id='MainDiv']/table[3]/tbody/tr[{0}]/td/b", i));
                    if (getStudentName == studentName)
                    {
                        base.WaitForElement(By.XPath(string.Format(
                            ".//*[@id='MainDiv']/table[3]/tbody/tr[{0}]/td/table/tbody/tr[1]/td[4]/table/tbody/tr/td[3]/a", scoreRow)));

                        getStudentPostTestScore = base.GetElementTextByXPath(string.
                       Format(".//*[@id='MainDiv']/table[3]/tbody/tr[{0}]/td/table/tbody/tr[1]/td[4]/table/tbody/tr/td[3]/a", scoreRow));
                        break;
                    }
                    getStudentNameCount++;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAllAssessmentAllStudentPage", "GetStudentAttempt",
                base.IsTakeScreenShotDuringEntryExit);
            return getStudentPostTestScore;
        }
    }
}
