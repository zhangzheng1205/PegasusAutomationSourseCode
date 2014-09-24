using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;
using System.Threading;
using System.Linq;
using System.Text;
using Pegasus.Pages.UI_Pages;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Configuration;
using Pegasus.Automation.DataTransferObjects;
namespace Pegasus.Pages
{
    /// <summary>
    /// This class handles Pegasus RptAllAssessmentAllStudent Page Actions.
    /// </summary>
    public class RptAllAssessmentAllStudentPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptAllAssessmentAllStudentPage));

        /// <summary>
        /// /// <summary>
        /// Switch to 'Reports' window.
        /// </summary>
        private void SwitchToGeneratedReportWindow(string windowName)
        {
            // Switch to 'Reports' window
            logger.LogMethodEntry("RptAllAssessmentAllStudentPage", "SwitchToGeneratedReportWindow",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(windowName);
            // Switch to 'Reports' window
            base.SelectWindow(windowName);
            logger.LogMethodExit("RptAllAssessmentAllStudentPage", "SwitchToGeneratedReportWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Gets a heading displayed in the 'Activity Results (Multiple students and activities)' report.
        /// </summary>
        /// <returns>Returns a heading.</returns>
        public string GetActivityHeading()
        {
            // Gets the heading displayed in the report
            logger.LogMethodEntry("RptAllAssessmentAllStudentPage",
            "GetActivityHeading",
                  base.IsTakeScreenShotDuringEntryExit);
            string getActualHeading = string.Empty;
            try
            {
                //Switch to report window
                this.SwitchToGeneratedReportWindow(RptAllAssessmentAllStudentPageResource.
                       RptAllAssessmentAllStudent_Page_Window_Title_Locator);
                base.WaitForElement(By.XPath(RptAllAssessmentAllStudentPageResource.
                RptAllAssessmentAllStudent_Page_ActivityHeading_Xpath_Locator));
                //Gets the text from the element
                getActualHeading = base.GetElementInnerTextByXPath
                    (RptAllAssessmentAllStudentPageResource.
                 RptAllAssessmentAllStudent_Page_ActivityHeading_Xpath_Locator);
                Thread.Sleep(Convert.ToInt32(RptAllAssessmentAllStudentPageResource.
                RptAllAssessmentAllStudent_Page_ReportCriteriaPage_WindowTime));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAllAssessmentAllStudentPage",
            "GetActivityHeading",
                        base.IsTakeScreenShotDuringEntryExit);
            return getActualHeading;
        }

        /// <summary>
        /// Gets a section name in the 'Activity Results (Multiple students and activities)' report.
        /// </summary>
        /// <returns>Returns the section name.</returns>
        public string GetSectionName()
        {
            // Gets the section name displayed in the report
            logger.LogMethodEntry("RptAllAssessmentAllStudentPage", "GetSectionName",
                base.IsTakeScreenShotDuringEntryExit);
            string getActualSectionName = string.Empty;
            try
            {
                //Switch to report window
                this.SwitchToGeneratedReportWindow(RptAllAssessmentAllStudentPageResource.
                        RptAllAssessmentAllStudent_Page_Window_Title_Locator);
                base.WaitForElement(By.XPath(RptAllAssessmentAllStudentPageResource.
                RptAllAssessmentAllStudent_Page_SectionName_Xpath_Locator));
                //Gets the text from the element
                getActualSectionName = base.GetElementInnerTextByXPath
                    (RptAllAssessmentAllStudentPageResource.
                 RptAllAssessmentAllStudent_Page_SectionName_Xpath_Locator);
                Thread.Sleep(Convert.ToInt32(RptAllAssessmentAllStudentPageResource.
                RptAllAssessmentAllStudent_Page_ReportCriteriaPage_WindowTime));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAllAssessmentAllStudentPage", "GetSectionName",
                        base.IsTakeScreenShotDuringEntryExit);
            return getActualSectionName;
        }

        /// <summary>
        /// Gets a average score value in the 'Activity Results (Multiple students and activities)' report.
        /// </summary>
        /// <returns>Returns the average score value.</returns>
        public string GetAverageScore()
        {
            // Gets the average score value displayed in the report
            logger.LogMethodEntry("RptAllAssessmentAllStudentPage",
            "GetAverageScore",
                  base.IsTakeScreenShotDuringEntryExit);
            string getActualAverageScore = string.Empty;
            try
            {
                //Switch to report window
                this.SwitchToGeneratedReportWindow(RptAllAssessmentAllStudentPageResource.
                       RptAllAssessmentAllStudent_Page_Window_Title_Locator);
                base.WaitForElement(By.XPath(RptAllAssessmentAllStudentPageResource.
               RptAllAssessmentAllStudent_Page_AverageScoreValue_Xpath_Locator));
                //Gets the text from the element
                getActualAverageScore = base.GetElementInnerTextByXPath
                    (RptAllAssessmentAllStudentPageResource.
                 RptAllAssessmentAllStudent_Page_AverageScoreValue_Xpath_Locator);
                Thread.Sleep(Convert.ToInt32(RptAllAssessmentAllStudentPageResource.
                RptAllAssessmentAllStudent_Page_ReportCriteriaPage_WindowTime));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAllAssessmentAllStudentPage",
            "GetAverageScore",
                        base.IsTakeScreenShotDuringEntryExit);
            return getActualAverageScore;
        }

        /// <summary>
        /// Verifies if the student being searched is present.
        /// </summary>
        /// <returns>Boolean value based on search result.</returns>
        public bool IsStudentPresent(string studentName)
        {
            //Verify Report Displayed In Dropdown
            logger.LogMethodEntry("RptAllAssessmentAllStudentPage", "IsStudentPresent",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isStudentDisplayed = false;
            string getStudentName = string.Empty;
            try
            {
                //Select Window
                this.SwitchToGeneratedReportWindow(RptAllAssessmentAllStudentPageResource.
                       RptAllAssessmentAllStudent_Page_Window_Title_Locator);
                base.WaitForElement(By.XPath(RptAllAssessmentAllStudentPageResource.
                     RptAllAssessmentAllStudent_Page_GridElementsCount_XPath_Locator));
                int getElementCount = base.GetElementCountByXPath(RptAllAssessmentAllStudentPageResource.
                     RptAllAssessmentAllStudent_Page_GridElementsCount_XPath_Locator);
                for (int studentSearch = 1; studentSearch <= getElementCount; studentSearch++)
                {
                    base.WaitForElement(By.XPath(string.Format(RptAllAssessmentAllStudentPageResource.
                    RptAllAssessmentAllStudent_Page_StudentName_XPath_Locator, studentSearch)));
                    getStudentName = base.GetElementTextByXPath(string.
                    Format(RptAllAssessmentAllStudentPageResource.
                    RptAllAssessmentAllStudent_Page_StudentName_XPath_Locator, studentSearch));
                    if (getStudentName == studentName)
                    {
                        isStudentDisplayed = true;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAllAssessmentAllStudentPage", "IsStudentPresent",
                base.IsTakeScreenShotDuringEntryExit);
            return isStudentDisplayed;
        }

        /// <summary>
        /// Gets the number of attemps taken by student.
        /// </summary>
        /// <returns>Number of attempts.</returns>
        public string GetStudentAttempt(string studentName)
        {
            //VGets the number of attemps taken by student 
            logger.LogMethodEntry("RptAllAssessmentAllStudentPage", "GetStudentAttempt",
                base.IsTakeScreenShotDuringEntryExit);
            string getStudentName = string.Empty;
            string getStudentAttempts = string.Empty;
            try
            {
                //Select Window
                this.SwitchToGeneratedReportWindow(RptAllAssessmentAllStudentPageResource.
                       RptAllAssessmentAllStudent_Page_Window_Title_Locator);
                base.WaitForElement(By.XPath(RptAllAssessmentAllStudentPageResource.
                     RptAllAssessmentAllStudent_Page_GridElementsCount_XPath_Locator));
                int getElementCount = base.GetElementCountByXPath(RptAllAssessmentAllStudentPageResource.
                     RptAllAssessmentAllStudent_Page_GridElementsCount_XPath_Locator);
                for (int studentSearch = 1; studentSearch <= getElementCount; studentSearch++)
                {
                    base.WaitForElement(By.XPath(string.Format(RptAllAssessmentAllStudentPageResource.
                    RptAllAssessmentAllStudent_Page_StudentName_XPath_Locator, studentSearch)));
                    getStudentName = base.GetElementTextByXPath(string.
                    Format(RptAllAssessmentAllStudentPageResource.
                    RptAllAssessmentAllStudent_Page_StudentName_XPath_Locator, studentSearch));
                    if (getStudentName == studentName)
                    {
                        base.WaitForElement(By.XPath(string.Format(RptAllAssessmentAllStudentPageResource.
                       RptAllAssessmentAllStudent_Page_StudentName_XPath_Locator, studentSearch)));
                        getStudentAttempts = base.GetElementTextByXPath(string.
                       Format(RptAllAssessmentAllStudentPageResource.
                       RptAllAssessmentAllStudent_Page_StudentAttemptValue_XPath_Locator, studentSearch));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAllAssessmentAllStudentPage", "GetStudentAttempt",
                base.IsTakeScreenShotDuringEntryExit);
            return getStudentAttempts;
        }

        /// <summary>
        /// Get Student Score Percentage.
        /// </summary>
        /// <param name="studentName">This is student name.</param>
        /// <returns>Activity score.</returns>
        public string GetStudentScorePercentage(string studentName)
        {
            //Get Student Score Percentage
            logger.LogMethodEntry("RptAllAssessmentAllStudentPage", "GetStudentScorePercentage",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getStudentName = string.Empty;
            string getStudentScorePercentage = string.Empty;
            try
            {
                //Select Window
                this.SwitchToGeneratedReportWindow(RptAllAssessmentAllStudentPageResource.
                       RptAllAssessmentAllStudent_Page_Window_Title_Locator);
                base.WaitForElement(By.XPath(RptAllAssessmentAllStudentPageResource.
                     RptAllAssessmentAllStudent_Page_GridElementsCount_XPath_Locator));
                int getElementCount = base.GetElementCountByXPath(RptAllAssessmentAllStudentPageResource.
                     RptAllAssessmentAllStudent_Page_GridElementsCount_XPath_Locator);
                for (int studentSearch = 1; studentSearch <= getElementCount; studentSearch++)
                {
                    base.WaitForElement(By.XPath(string.Format(RptAllAssessmentAllStudentPageResource.
                    RptAllAssessmentAllStudent_Page_StudentName_XPath_Locator, studentSearch)));
                    getStudentName = base.GetElementTextByXPath(string.
                    Format(RptAllAssessmentAllStudentPageResource.
                    RptAllAssessmentAllStudent_Page_StudentName_XPath_Locator, studentSearch));
                    if (getStudentName == studentName)
                    {
                        base.WaitForElement(By.XPath(string.Format(RptAllAssessmentAllStudentPageResource.
                       RptAllAssessmentAllStudent_Page_StudentScoreValue_XPath_Locator, studentSearch)));
                        getStudentScorePercentage = base.GetElementTextByXPath(string.
                       Format(RptAllAssessmentAllStudentPageResource.
                       RptAllAssessmentAllStudent_Page_StudentScoreValue_XPath_Locator, studentSearch));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAllAssessmentAllStudentPage", "GetStudentScorePercentage",
                 base.IsTakeScreenShotDuringEntryExit);
            return getStudentScorePercentage;
        }

        /// <summary>
        /// Get ZeroScore User name.
        /// </summary>
        /// <param name="userTypeEnum">This is user type enum.</param>
        /// <returns>Student first and last name.</returns>
        public string GetZeroScoreUsername(User.UserTypeEnum userTypeEnum)
        {
            //Get ZeroScore User name.
            logger.LogMethodEntry("RptAllAssessmentAllStudentPage", "GetZeroScoreUsername",
                base.IsTakeScreenShotDuringEntryExit);
            string zeroScoreStudentName = string.Empty;
            try
            {
                User user = User.Get(CommonResource.CommonResource
                                      .SMS_STU_UC1);
                zeroScoreStudentName = user.LastName + ", " + user.FirstName;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAllAssessmentAllStudentPage", "GetZeroScoreUsername",
                 base.IsTakeScreenShotDuringEntryExit);
            return zeroScoreStudentName;

        }
    }
}