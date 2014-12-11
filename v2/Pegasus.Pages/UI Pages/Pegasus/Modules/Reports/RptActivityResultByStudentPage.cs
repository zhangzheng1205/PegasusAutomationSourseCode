﻿using System.Collections.Generic;
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
    /// This class handles Activity Resukt by Student Page Actions.  
    /// </summary>
    public class RptActivityResultByStudentPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(
            typeof(RptActivityResultByStudentPage));

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("RptActivityResultByStudentPage", "SelectWindow"
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait Until Window
            base.WaitUntilWindowLoads(
                RptActivityResultByStudentPageRecource.
                RptActivityResultByStudentPage_WindowName);
            //Selecting the 'Activity Result By Student' window                
            base.SelectWindow(
                RptActivityResultByStudentPageRecource.
                RptActivityResultByStudentPage_WindowName);
            logger.LogMethodExit("RptActivityResultByStudentPage", "SelectWindow"
               , base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Get Activity Details In Report
        /// </summary>
        /// <param name="reportDetails"></param>
        /// <returns></returns>
        public string GetActivityDetailsInReport(int reportDetails)
        {
            logger.LogMethodEntry("RptActivityResultByStudentPage", "GetActivityDetailsInReport",
                base.IsTakeScreenShotDuringEntryExit);
            string getActivityDetails = string.Empty;
            //this.SelectWindow();
            base.SwitchToLastOpenedWindow();
            base.WaitForElement(By.XPath(string.Format(
                RptActivityResultByStudentPageRecource.
                RptActivityResultByStudentPage_ActivityDetails_XPath_Locator,
                reportDetails)));
            getActivityDetails = base.GetElementTextByXPath(string.Format(
                RptActivityResultByStudentPageRecource.
                RptActivityResultByStudentPage_ActivityDetails_XPath_Locator,
                reportDetails)).Trim();
            logger.LogMethodExit("RptActivityResultByStudentPage", "GetActivityDetailsInReport",
                 base.IsTakeScreenShotDuringEntryExit);
            return getActivityDetails;
        }
        /// <summary>
        /// Get Average Score In The Report
        /// </summary>
        /// <returns></returns>
        public string GetAverageScoreInTheReport()
        {
            logger.LogMethodEntry("RptActivityResultByStudentPage", "GetAverageScoreInTheReport",
                base.IsTakeScreenShotDuringEntryExit);
            string getAverageScore = string.Empty;
            base.SwitchToLastOpenedWindow();
            //this.SelectWindow();
            base.SwitchToLastOpenedWindow();
            base.WaitForElement(By.XPath(
                RptActivityResultByStudentPageRecource.
                RptActivityResultByStudentPage_ActivityAverage_XPath_Locator));
            getAverageScore = base.GetElementTextByXPath(RptActivityResultByStudentPageRecource.
                RptActivityResultByStudentPage_ActivityAverage_XPath_Locator).Trim();
            logger.LogMethodExit("RptActivityResultByStudentPage", "GetAverageScoreInTheReport",
                 base.IsTakeScreenShotDuringEntryExit);
            return getAverageScore;
        }
        /// <summary>
        /// Get Student Name In Activity Result By Student
        /// </summary>
        /// <param name="studentName"></param>
        /// <returns></returns>
        public bool GetStudentNameInActivityResultByStudent(string studentName)
        {
            logger.LogMethodEntry("RptActivityResultByStudentPage",
                "GetStudentNameInActivityResultByStudent",
                base.IsTakeScreenShotDuringEntryExit);
            bool isStudentPresent = false;
            string getStudentName = string.Empty;
            base.SwitchToLastOpenedWindow();
            base.WaitForElement(By.XPath(
                RptActivityResultByStudentPageRecource.
                RptActivityResultByStudentPage_ActivityStudentCount_XPath_Locator));
            int getStudentNameCount = base.GetElementCountByXPath(
                RptActivityResultByStudentPageRecource.
                RptActivityResultByStudentPage_ActivityStudentCount_XPath_Locator);
            for (int i = 1; i <= getStudentNameCount; i++)
            {
                base.WaitForElement(By.XPath(string.Format(
                    RptActivityResultByStudentPageRecource.
                    RptActivityResultByStudentPage_ActivityStudentName_XPath_Locator, i)), 10);
                getStudentName = base.GetElementTextByXPath(string.Format(
                     RptActivityResultByStudentPageRecource.
                    RptActivityResultByStudentPage_ActivityStudentName_XPath_Locator, i)).Trim();
                if (getStudentName == studentName)
                {
                    isStudentPresent = true;
                    break;
                }
                i++;
            }
            logger.LogMethodExit("RptActivityResultByStudentPage",
            "GetStudentNameInActivityResultByStudent",
                 base.IsTakeScreenShotDuringEntryExit);
            return isStudentPresent;
        }
        /// <summary>
        /// Get Student Score In Activity Result By Student
        /// </summary>
        /// <param name="scoreRow"></param>
        /// <returns></returns>
        public string GetStudentScoreInActivityResultByStudent(int scoreRow)
        {
            logger.LogMethodEntry("RptActivityResultByStudentPage",
                "GetStudentScoreInActivityResultByStudent",
                base.IsTakeScreenShotDuringEntryExit);
            string getScore = string.Empty;
            base.SwitchToLastOpenedWindow();
            bool jh = base.IsElementPresent(By.XPath(string.Format(
                RptActivityResultByStudentPageRecource.
                RptActivityResultByStudentPage_ActivityStudentScore_XPath_Locator, scoreRow)), 10);
            base.WaitForElement(By.XPath(string.Format(
                RptActivityResultByStudentPageRecource.
                RptActivityResultByStudentPage_ActivityStudentScore_XPath_Locator, scoreRow)), 10);
            getScore = base.GetElementTextByXPath(string.Format(
                RptActivityResultByStudentPageRecource.
                RptActivityResultByStudentPage_ActivityStudentScore_XPath_Locator, scoreRow));
            string studentPercentage = getScore.Split(' ')[0].Trim();
            logger.LogMethodExit("RptActivityResultByStudentPage",
                "GetStudentScoreInActivityResultByStudent",
                     base.IsTakeScreenShotDuringEntryExit);
            return studentPercentage;
        }

    }
}
