using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Users;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles the Actions performed on the RptStudentUsage Page
    /// </summary>
    public class RptStudentUsagePage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptStudentUsagePage));


        /// <summary>
        /// ProgramAdminReports
        /// </summary>
        public enum ProgramAdminReportType
        {
            //Student Enrollment Report
            StudentEnrollment = 1,
            //Acivity Result by student
            ActivityResultByStudent = 2,
            //Student activity by result
            StudentActivityByResult = 3,
            //course section usage
            CourseSectionUsage
        }


        /// <summary>
        /// To get the student name in the student enrollment report
        /// </summary>
        /// <returns>Student Name</returns>
        public string GetStudentText()
        {
            logger.LogMethodEntry("RptStudentUsagePage", "GetStudentText",
                base.isTakeScreenShotDuringEntryExit);
            //Initialized Student Name Variable
            string getStudentName = string.Empty;
            try
            {
                // Get Student Name
                getStudentName = base.GetElementTextByXPath(
                        RptStudentUsagePageResource.RptStudentUsage_Page_Student_Text_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentUsagePage", "GetStudentText",
                base.isTakeScreenShotDuringEntryExit);
            return getStudentName;
        }


        /// <summary>
        /// To get section name in the report
        /// </summary>
        /// <param name="reportTypeEnum">This is the report type</param>
        /// <returns>Result of Section Text</returns>
        public string GetSectionName(ProgramAdminReportType reportTypeEnum)
        {
            logger.LogMethodEntry("RptStudentUsagePage", "GetSectionText",
                base.isTakeScreenShotDuringEntryExit);
            //Initialized Section Name Variable
            string getSectionName = string.Empty;
            try
            {
                switch (reportTypeEnum)
                {
                        //This is student enrollment report
                    case ProgramAdminReportType.StudentEnrollment:
                        getSectionName = GetSectionText();
                        break;
                    // This is course section usage report
                    case ProgramAdminReportType.CourseSectionUsage:
                        getSectionName = new RptCourseUsagePage().GetSectionText();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("RptStudentUsagePage", "GetSectionText",
                base.isTakeScreenShotDuringEntryExit);
            return getSectionName;
        }

        /// <summary>
        /// Get Section text from the report window
        /// </summary>
        /// <returns>Section Name</returns>
        private String GetSectionText()
        {
            logger.LogMethodEntry("RptStudentUsagePage", "GetSectionText",
                   base.isTakeScreenShotDuringEntryExit);
            string getSectionName = string.Empty;
            //Select Window
            this.SelectWindow();
            // Get section name text
            getSectionName = base.GetElementTextByXPath(
                RptStudentUsagePageResource.RptStudentUsage_Page_Section_Text_Xpath_Locator);
            logger.LogMethodExit("RptStudentUsagePage", "GetSectionText",
               base.isTakeScreenShotDuringEntryExit);
            return getSectionName;
        }


        /// <summary>
        /// To get Status of student in the report
        /// </summary>
        /// <param name="reportTypeEnum">This is report type</param>
        /// <returns>Result of Status Text</returns>
        public string GetStatusText(ProgramAdminReportType reportTypeEnum)
        {
            logger.LogMethodEntry("RptStudentUsagePage", "GetStatusText",
                base.isTakeScreenShotDuringEntryExit);
            //Initialized Status Variable
            string getStatus = string.Empty;
            try
            {
                switch (reportTypeEnum)
                {
                    // This is student enrollment report
                    case ProgramAdminReportType.StudentEnrollment:
                        getStatus = GetSectionStatusText();
                        break;
                    // This is course section usage report
                    case ProgramAdminReportType.CourseSectionUsage:
                        getStatus = new RptCourseUsagePage().GetSectionStatusText();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("RptStudentUsagePage", "GetStatusText",
                base.isTakeScreenShotDuringEntryExit);
            return getStatus;
        }

        /// <summary>
        /// Get Status of section 
        /// </summary>
        /// <returns>Status text</returns>
        private string GetSectionStatusText()
        {
            logger.LogMethodEntry("RptStudentUsagePage", "GetSectionStatusText",
                base.isTakeScreenShotDuringEntryExit);
            string getStatus = string.Empty;
            //Select Window
            this.SelectWindow();
            // Get Status Text 
            getStatus = base.GetElementTextByXPath(
                RptStudentUsagePageResource.RptStudentUsage_Page_Status_Text_Xpath_Locator);
            base.CloseBrowserWindow();
            base.WaitUntilWindowLoads(ProgramAdminUsersPageResource
                .ProgramAdminUsers_Page_Window_Title_Name);
            base.SelectWindow(ProgramAdminUsersPageResource
            .ProgramAdminUsers_Page_Window_Title_Name);
            logger.LogMethodExit("RptStudentUsagePage", "GetSectionStatusText",
                base.isTakeScreenShotDuringEntryExit);
            return getStatus;
        }

        /// <summary>
        /// Select the Student Enrollment Window
        /// </summary>
        /// <param name="getReportWindowName">This is the report window name</param>
        public void SelectReportWindow(string getReportWindowName)
        {
            logger.LogMethodEntry("RptStudentUsagePage", "SelectReportWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Student Enrollment Window
                base.WaitUntilWindowLoads(getReportWindowName);
                base.SelectWindow(getReportWindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentUsagePage", "SelectReportWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Enrollment Date.
        /// </summary>
        /// <returns>Enrollment Date.</returns>
        public String GetEnrollmentDate()
        {
            //Get Enrollment Date
            logger.LogMethodEntry("RptStudentUsagePage", "GetEnrollmentDate",
                 base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getsplittedEnrollmentDate = string.Empty;
            string getenrollmentDateTime = string.Empty;
            try
            {
                //Select Window
                this.SelectWindow();
                base.WaitForElement(By.XPath(RptStudentUsagePageResource.
                    RptStudentUsage_Page_EnrollmentDate_Xpath_Locator));
                //Get Enrollment Date
                getenrollmentDateTime = base.GetElementTextByXPath(RptStudentUsagePageResource.
                    RptStudentUsage_Page_EnrollmentDate_Xpath_Locator);
                //Split Enrollment Date
                string[] splitEnrollmentDate = getenrollmentDateTime.Split(
                    Convert.ToChar(RptStudentUsagePageResource.RptStudentUsage_Page_SplitValue));
                //Get Splitted Enrollment Date
                getsplittedEnrollmentDate = splitEnrollmentDate[Convert.ToInt32(
                    RptStudentUsagePageResource.RptStudentUsage_Page_Index_Value)];
                //Close Report Window
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentUsagePage", "GetEnrollmentDate",
                base.isTakeScreenShotDuringEntryExit);
            return getsplittedEnrollmentDate;
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("RptStudentUsagePage", "SelectWindow",
                 base.isTakeScreenShotDuringEntryExit);
            //Select window title
            base.WaitUntilWindowLoads(RptStudentUsagePageResource
                            .RptStudentUsage_Page_Window_Title);
            base.SelectWindow(RptStudentUsagePageResource
                            .RptStudentUsage_Page_Window_Title);
            logger.LogMethodExit("RptStudentUsagePage", "SelectWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Last Login Date.
        /// </summary>
        /// <returns>Last Login Date.</returns>
        public String GetLastLoginDate()
        {
            //Get Last Login Date
            logger.LogMethodEntry("RptStudentUsagePage", "GetLastLoginDate",
                 base.isTakeScreenShotDuringEntryExit);
            //Initialize variable
            string getsplittedLastLoginDate = string.Empty;
            string getLastLoginDateTime = string.Empty;
            try
            {
                //Select Window
                this.SelectWindow();
                //Get Last Login DateTime
                getLastLoginDateTime = base.GetElementTextByXPath(
                    RptStudentUsagePageResource.RptStudentUsage_Page_LastLoginDate_Xpath_Locator);
                //Split Last Login DateTime
                string[] splitLastLoginDate = getLastLoginDateTime.Split(
                    Convert.ToChar(RptStudentUsagePageResource.RptStudentUsage_Page_SplitValue));
                //Get Splitted Last Login Date
                getsplittedLastLoginDate = splitLastLoginDate[Convert.ToInt32(
                        RptStudentUsagePageResource.RptStudentUsage_Page_Index_Value)];
                //Close Report Window
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentUsagePage", "GetLastLoginDate",
                base.isTakeScreenShotDuringEntryExit);
            return getsplittedLastLoginDate;
        }
    }
}
