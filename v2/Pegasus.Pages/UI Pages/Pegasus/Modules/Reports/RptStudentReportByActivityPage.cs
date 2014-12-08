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
using System;


namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports
{
        /// <summary>
    /// This class handles Student Report by Activity report Page Actions.  
    /// </summary>
    public class RptStudentReportByActivityPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(
            typeof(RptStudentReportByActivityPage));

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("RptStudentReportByActivityPage", "SelectWindow"
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait Until Window
            base.WaitUntilWindowLoads(
                RptStudentReportByActivityPageResource.
                RptStudentReportPage_WindowName);
            //Selecting the 'Student Results by Activity' window                
            base.SelectWindow(RptStudentReportByActivityPageResource.
                RptStudentReportPage_WindowName);
            logger.LogMethodExit("RptStudentReportByActivityPage", "SelectWindow"
               , base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Get Student User name.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        /// <returns>Student first and last name.</returns>
        public string GetStudentUsername(User.UserTypeEnum userTypeEnum)
        {
            //Get  User name.
            logger.LogMethodEntry("RptStudentReportByActivityPage", "GetStudentUsername",
                base.IsTakeScreenShotDuringEntryExit);
            string studentName = string.Empty;
            try
            {
                User user = User.Get(userTypeEnum);
                studentName = user.LastName + ", " + user.FirstName;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentReportByActivityPage", "GetStudentUsername",
                 base.IsTakeScreenShotDuringEntryExit);
            return studentName;
        }
        /// <summary>
        /// Get Student And Section Name In Report
        /// </summary>
        /// <param name="reportDetails"></param>
        /// <returns></returns>
        public string GetStudentAndSectionNameInReport(int reportDetails)
        {
            logger.LogMethodEntry("RptStudentReportByActivityPage", 
                "GetStudentAndSectionNameInReport",
                base.IsTakeScreenShotDuringEntryExit);
            string getStudentReportName = String.Empty;
            base.SwitchToLastOpenedWindow();
            base.WaitForElement(By.XPath(String.Format(
                RptStudentReportByActivityPageResource.
                RptStudentReportPage_StudentDetails_XPath_Locator,
                reportDetails)));
            getStudentReportName = base.GetElementTextByXPath(String.Format(
                RptStudentReportByActivityPageResource.
                RptStudentReportPage_StudentDetails_XPath_Locator,
                reportDetails));
            logger.LogMethodExit("RptStudentReportByActivityPage", 
                "GetStudentAndSectionNameInReport",
                 base.IsTakeScreenShotDuringEntryExit);
            return getStudentReportName;
        }
        /// <summary>
        /// Get Average Score In Report
        /// </summary>
        /// <returns></returns>
        public string GetAverageScoreInReport()
        {
            logger.LogMethodEntry("RptStudentReportByActivityPage", "GetAverageScoreInReport",
                base.IsTakeScreenShotDuringEntryExit);
            string getAverageScore = String.Empty;
            //this.SelectWindow();
            base.SwitchToLastOpenedWindow();
            bool gf = base.IsElementPresent(By.XPath(
                RptStudentReportByActivityPageResource.
                RptStudentReportPage_StudentScore_XPath_Locator), 10);
            base.WaitForElement(By.XPath(
                RptStudentReportByActivityPageResource.
                RptStudentReportPage_StudentScore_XPath_Locator));
            getAverageScore = base.GetElementTextByXPath(
                RptStudentReportByActivityPageResource.
                RptStudentReportPage_StudentScore_XPath_Locator);
            logger.LogMethodExit("RptStudentReportByActivityPage", "GetAverageScoreInReport",
                 base.IsTakeScreenShotDuringEntryExit);
            return getAverageScore;
        }
        /// <summary>
        /// Click On Select Student
        /// </summary>
        /// <param name="studentButtonName"></param>
        public void ClickOnSelectStudent(string studentButtonName)
        {
            logger.LogMethodEntry("RptStudentReportByActivityPage", "ClickOnSelectStudent",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {

                base.SwitchToIFrameById(
                    RptStudentReportByActivityPageResource.
                    RptStudentReportPage_StudentReport_Iframe_Id);
                base.WaitForElement(By.XPath(String.Format(
                    RptStudentReportByActivityPageResource.
                    RptStudentReportPage_StudentButton_XPath_Locator, studentButtonName)));
                IWebElement getStudentButton = base.GetWebElementPropertiesByXPath(string.
                        Format(RptStudentReportByActivityPageResource.
                    RptStudentReportPage_StudentButton_XPath_Locator, studentButtonName));
                //Click assesment button
                base.ClickByJavaScriptExecutor(getStudentButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentReportByActivityPage", "ClickOnSelectStudent",
                 base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Get Report Details
        /// </summary>
        /// <param name="reportColumn"></param>
        /// <returns></returns>
       public string GetReportDetails(int reportColumn)
        {
            logger.LogMethodEntry("RptStudentReportByActivityPage", "GetReportDetails",
                base.IsTakeScreenShotDuringEntryExit);
            string getReportDetails = String.Empty;
            //this.SelectWindow();
            base.SwitchToLastOpenedWindow();          
            base.WaitForElement(By.XPath(String.Format(
                RptStudentReportByActivityPageResource.
                RptStudentReportPage_ReportDetails_XPath_Locator,
                reportColumn)));
            getReportDetails = base.GetElementTextByXPath(
                String.Format(RptStudentReportByActivityPageResource.
                RptStudentReportPage_ReportDetails_XPath_Locator,
                reportColumn));
            logger.LogMethodExit("RptStudentReportByActivityPage", "GetReportDetails",
                 base.IsTakeScreenShotDuringEntryExit);
            return getReportDetails;
        }

        /// <summary>
        /// Add Student To Report
        /// </summary>
        public void AddStudentToReport(string studentButtonName, User.UserTypeEnum userTypeEnum)
        {
            logger.LogMethodEntry("RptStudentReportByActivityPage",
                "AddStudentToReport",
               base.IsTakeScreenShotDuringEntryExit);
            //Click on 'Select Student' button
            this.ClickOnSelectStudent(studentButtonName);
            //Expand the students link
            bool jdfh = base.IsElementPresent(By.XPath(
                RptStudentReportByActivityPageResource.
                RptStudentReportPage_AddStudent_XPath_Locator), 10);
            IWebElement expandStudent = base.GetWebElementPropertiesByXPath(
                RptStudentReportByActivityPageResource.
                RptStudentReportPage_AddStudent_XPath_Locator);
            base.ClickByJavaScriptExecutor(expandStudent);
            this.SelectSingleStudent(userTypeEnum);
            logger.LogMethodExit("RptStudentReportByActivityPage",
                "AddStudentToReport",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select Single Student
        /// </summary>
        /// <param name="userTypeEnum"></param>
       public void SelectSingleStudent(User.UserTypeEnum userTypeEnum)
        {
            logger.LogMethodEntry("RptStudentReportByActivityPage",
                "SelectSingleStudent",
               base.IsTakeScreenShotDuringEntryExit);
            string getStudentName = string.Empty;
            User user = User.Get(userTypeEnum);
            string studentName = user.LastName + ", " + user.FirstName;
            //Expand the students link
            int getStudentListCount = base.GetElementCountByXPath(
                RptStudentReportByActivityPageResource.RptStudentReportPage_StudentCount_XPath_Locator);
            for (int i = 1; i <= getStudentListCount; i++)
            {
                getStudentName = base.GetElementTextByXPath(String.Format(
                    "//table[@id='radPAdimStudents__ctl1__ctl6_Detail10']/tbody/tr[{0}]/td[2]", i));
                if (getStudentName == studentName)
                {
                    IWebElement getStudent = base.GetWebElementPropertiesByXPath(
                        String.Format(RptStudentReportByActivityPageResource.RptStudentReportPage_StudentName_XPath_Locator, i));
                    base.ClickByJavaScriptExecutor(getStudent);
                    break;
                }
            }
            logger.LogMethodExit("RptStudentReportByActivityPage",
                "SelectSingleStudent",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
