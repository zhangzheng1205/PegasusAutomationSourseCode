using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages
{
    /// <summary>
    /// This class handles Pegasus RptAssessmentAllStudents Page Actions
    /// </summary>
    public class RptAssessmentAllStudentsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptAssessmentAllStudentsPage));

        /// <summary>
        /// Check for Activity Result by Student Report Window
        /// </summary>
        public void ActivityReportWindowCheck()
        {
            //Activity Result By Student Report Window Check
            logger.LogMethodEntry("RptAssessmentAllStudentsPage", "ActivityReportWindowCheck",
                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Activity Result By Report Window
                base.WaitUntilWindowLoads(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAssessmentAllStudentsPage", "ActivityReportWindowCheck",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check For Score in the Generated Report
        /// </summary>
        /// <returns>Activity Score</returns>
        public String GetActivityScore()
        {
            //Get Score Of The Activity
            logger.LogMethodEntry("RptAssessmentAllStudents", "GetActivityScore"
                , base.isTakeScreenShotDuringEntryExit);
            //Initialized Activity Score Variable
            string getActivityScore = string.Empty;
            try
            {
                //Select Window
                this.SelectActivityResultsByStudentWindow();
                base.WaitForElement(By.XPath(
                    RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_Score_Xpath_Locator));
                //Get Activity Score In Report
                getActivityScore = this.GetActivityScoreInReport(getActivityScore);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAssessmentAllStudents", "GetActivityScore"
                , base.isTakeScreenShotDuringEntryExit);
            //Score of Activity
            return getActivityScore;
        }

        /// <summary>
        /// Select Activity Results By Student Window.
        /// </summary>
        private void SelectActivityResultsByStudentWindow()
        {
            //Select Activity Results By Student Window
            logger.LogMethodEntry("RptAssessmentAllStudents",
                "SelectActivityResultsByStudentWindow"
                , base.isTakeScreenShotDuringEntryExit);
            //Wait Until Window
            base.WaitUntilWindowLoads(RptAssessmentAllStudentsPageResource
                    .RptAssessmentAllStudent_Page_Window_Name);
            //Selecting the Activity Result by Report window
            base.SelectWindow(RptAssessmentAllStudentsPageResource
                .RptAssessmentAllStudent_Page_Window_Name);
            logger.LogMethodExit("RptAssessmentAllStudents",
                "SelectActivityResultsByStudentWindow"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Score In Report.
        /// </summary>
        /// <param name="getActivityScore">This is Activity Score.</param>
        /// <returns>Activity Score.</returns>
        private string GetActivityScoreInReport(string getActivityScore)
        {
            //Get Activity Score In Report
            logger.LogMethodEntry("RptAssessmentAllStudents", "GetActivityScoreInReport"
               , base.isTakeScreenShotDuringEntryExit);
            //Get Activity Score
            getActivityScore = base.GetElementTextByXPath(
                RptAssessmentAllStudentsPageResource.RptAssessmentAllStudent_Page_Score_Xpath_Locator);
            string[] score = getActivityScore.Split(Convert.ToChar(RptAssessmentAllStudentsPageResource.
                RptAssessmentAllStudent_Page_Activity_Score_SplittingCharacter));
            //Score Of The Activity
            getActivityScore = score[Convert.ToInt32(
                RptAssessmentAllStudentsPageResource.RptAssessmentAllStudent_Page_Ins_Score_Value)];
            logger.LogMethodExit("RptAssessmentAllStudents", "GetActivityScoreInReport"
                , base.isTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Get Writingspace Activity Score.
        /// </summary>
        /// <returns>Writingspace Activity Score.</returns>
        public String GetWritingspaceActivityScore()
        {
            //Get Score Of The Activity
            logger.LogMethodEntry("RptAssessmentAllStudents", "GetWritingspaceActivityScore"
                , base.isTakeScreenShotDuringEntryExit);
            //Initialized Activity Score Variable
            string getActivityScore = string.Empty;
            try
            {
                //Switch to Last Opened Window
                base.SwitchToLastOpenedWindow();
                //Get Activity Score In Report
                getActivityScore = this.GetActivityScoreInReport(getActivityScore);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAssessmentAllStudents", "GetWritingspaceActivityScore"
                , base.isTakeScreenShotDuringEntryExit);
            //Score of Activity
            return getActivityScore;
        }
        /// <summary>
        /// Check for Student Name in the Generated Report
        /// </summary>
        /// <returns>Student Name</returns>
        public String GetStudentName()
        {
            //Get Student Name
            logger.LogMethodEntry("RptAssessmentAllStudents", "GetStudentName"
                , base.isTakeScreenShotDuringEntryExit);
            //Intialized Get Student Name Variable
            string getStudentName = string.Empty;
            try
            {
                //Select Window
                this.SelectActivityResultsByStudentWindow();
                //Get Student Name In Report
                getStudentName = this.GetStudentNameInReport(getStudentName);
                base.WaitUntilWindowLoads(RptMainPageResource
                    .RptMain_Page_WindowName_Title);
                base.SelectWindow(RptMainPageResource
                    .RptMain_Page_WindowName_Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAssessmentAllStudents", "GetStudentName"
               , base.isTakeScreenShotDuringEntryExit);
            //Name of the Student
            return getStudentName;
        }

        /// <summary>
        /// Get Student Name In Report.
        /// </summary>
        /// <param name="getStudentName">This is Student Name.</param>
        /// <returns>Student Name.</returns>
        private string GetStudentNameInReport(string getStudentName)
        {
            //Get Student Name In Report
            logger.LogMethodEntry("RptAssessmentAllStudents", "GetStudentNameInReport"
                , base.isTakeScreenShotDuringEntryExit);
            //Get Student Name
            getStudentName = base.GetElementTextByXPath(RptAssessmentAllStudentsPageResource.
                 RptAssessmentAllStudent_Page_StudentName_Xpath_Locator);
            string[] name = getStudentName.Split(Convert.ToChar(RptAssessmentAllStudentsPageResource.
                RptAssessmentAllStudent_Page_Student_Name_SplittingCharacter));
            getStudentName = name[Convert.ToInt32(
                RptAssessmentAllStudentsPageResource.RptAssessmentAllStudent_Page_Ins_Score_Value)];
            base.WaitForElement(By.PartialLinkText(RptAssessmentAllStudentsPageResource.
                RptAssessmentAllStudent_Page_Close_Link_Locator));
            base.FocusOnElementByPartialLinkText(RptAssessmentAllStudentsPageResource.
                RptAssessmentAllStudent_Page_Close_Link_Locator);
            //Click on Close Button
            base.ClickButtonByPartialLinkText(RptAssessmentAllStudentsPageResource.
                RptAssessmentAllStudent_Page_Close_Link_Locator);
            base.IsPopUpClosed(2);
            logger.LogMethodExit("RptAssessmentAllStudents", "GetStudentNameInReport"
               , base.isTakeScreenShotDuringEntryExit);
            return getStudentName;
        }

        /// <summary>
        /// Get Writingspace Student Name In Report.
        /// </summary>
        /// <returns>Student Name.</returns>
        public String GetWritingspaceStudentNameInReport()
        {
            //Get Writingspace Student Name In Report
            logger.LogMethodEntry("RptAssessmentAllStudents",
                "GetWritingspaceStudentNameInReport"
                , base.isTakeScreenShotDuringEntryExit);
            //Initialized Student Name Variable
            string getStudentName = string.Empty;
            try
            {
                //Switch to Last Opened Window
                base.SwitchToLastOpenedWindow();
                //Get Student Name In Report
                getStudentName = this.GetStudentNameInReport(getStudentName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAssessmentAllStudents",
                "GetWritingspaceStudentNameInReport"
                , base.isTakeScreenShotDuringEntryExit);
            //Student Name
            return getStudentName;
        }

        /// <summary>
        /// Get Manually Graded Score
        /// </summary>
        /// <returns>Manually Graded Activity Score</returns>
        public String GetManuallyGradedScore()
        {
            //Get Manually Graded Score
            logger.LogMethodEntry("RptAssessmentAllStudentsPage", "GetManuallyGradedScore",
                  base.isTakeScreenShotDuringEntryExit);
            //Initialize getManuallyGradedScore Variable
            string getManuallyGradedScore = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(RptAssessmentAllStudentsPageResource.
                        RptAssessmentAllStudent_StudentResultsByActivity_Window_Name);
                //Select Student Result By Activity Report
                base.SelectWindow(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_StudentResultsByActivity_Window_Name);
                base.WaitForElement(By.Id(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_ManualGradeScore_Id_Locator));
                //Get Manually Graded Score 
                getManuallyGradedScore = base.GetElementTextById(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_ManualGradeScore_Id_Locator);
                string[] activityScore = getManuallyGradedScore.Split(
                    Convert.ToChar(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_Activity_Score_SplittingCharacter));
                getManuallyGradedScore = activityScore[Convert.ToInt32(
                    RptAssessmentAllStudentsPageResource.RptAssessmentAllStudent_Page_Ins_Score_Value)];
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAssessmentAllStudentsPage", "GetManuallyGradedScore",
                base.isTakeScreenShotDuringEntryExit);
            return getManuallyGradedScore;
        }

        /// <summary>
        /// Get Activity Name
        /// </summary>
        /// <returns>Activity Name</returns>
        public String GetActivityName()
        {
            //Get Activity Name
            logger.LogMethodEntry("RptAssessmentAllStudentsPage", "GetActivityName",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Get Activity Variable
            string getActivityName = string.Empty;
            try
            {
                //Select Student Results By Activity Report Window
                base.SelectWindow(RptAssessmentAllStudentsPageResource.
                        RptAssessmentAllStudent_StudentResultsByActivity_Window_Name);
                base.WaitForElement(By.XPath(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_ManuallyGradedActivity_Xpath_Locator));
                //Get Activity Name
                getActivityName = base.GetElementTextByXPath(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_ManuallyGradedActivity_Xpath_Locator);
                //Click on Close Button
                base.ClickButtonByPartialLinkText(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_Close_Link_Locator);
                base.SelectWindow(RptMainPageResource.RptMain_Page_WindowName_Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAssessmentAllStudentsPage", "GetActivityName",
                base.isTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Get Submitted Activity Name.
        /// </summary>
        /// <returns>Activity Name.</returns>
        public String GetSubmittedActivityName()
        {
            //Get Activity Name
            logger.LogMethodEntry("RptAssessmentAllStudentsPage", "GetSubmittedActivityName",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Get Activity Variable
            string getActivityName = string.Empty;
            try
            {
                //Select Window
                this.SelectActivityResultWindow();
                base.WaitForElement(By.XPath(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_Activity_Title_Xpath_Locator));
                //Get Activity Name
                getActivityName = base.GetElementTextByXPath(
                    RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_Activity_Title_Xpath_Locator);
                //Close The Report Window
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAssessmentAllStudentsPage", "GetSubmittedActivityName",
                base.isTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Get Submitted Activity Score.
        /// </summary>
        /// <returns>This Is Submitted Score.</returns>
        public String GetSubmittedActivityScore()
        {
            //Get Score Of The Activity
            logger.LogMethodEntry("RptAssessmentAllStudents", "GetSubmittedActivityScore"
                , base.isTakeScreenShotDuringEntryExit);
            //Initialized Activity Score Variable
            string getActivityScore = string.Empty;
            try
            {
                //Select Window
                this.SelectActivityResultWindow();
                base.WaitForElement(By.XPath(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_Activity_Score_Xpath_Locator));
                //Get Activity Score
                getActivityScore = base.GetElementTextByXPath(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_Activity_Score_Xpath_Locator);
                string[] score =
                    getActivityScore.Split(Convert.ToChar(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_Activity_Score_SplittingCharacter));
                //Score Of The Activity
                getActivityScore = score[Convert.ToInt32(
                    RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_Ins_Score_Value)];
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAssessmentAllStudents", "GetSubmittedActivityScore"
                , base.isTakeScreenShotDuringEntryExit);
            //Score of Activity
            return getActivityScore;
        }

        /// <summary>
        /// Select Activity Result Window.
        /// </summary>
        private void SelectActivityResultWindow()
        {
            //Select Activity Result Window
            logger.LogMethodEntry("RptAssessmentAllStudents", "SelectActivityResultWindow"
                , base.isTakeScreenShotDuringEntryExit);
            //Wait Until Window
            base.WaitUntilWindowLoads(RptAssessmentAllStudentsPageResource.
                RptAssessmentAllStudent_Page_Activity_Result_Single_window_Name);
            //Selecting the Activity Result by Report window                
            base.SelectWindow(RptAssessmentAllStudentsPageResource.
                RptAssessmentAllStudent_Page_Activity_Result_Single_window_Name);
            logger.LogMethodExit("RptAssessmentAllStudents", "SelectActivityResultWindow"
                , base.isTakeScreenShotDuringEntryExit);
        }
    }
}
