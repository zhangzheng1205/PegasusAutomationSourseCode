using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;
using System.Threading;

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
                  base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check For Score in the Generated Report
        /// </summary>
        /// <returns>Activity Score</returns>
        public String GetActivityScore()
        {
            //Get Score Of The Activity
            logger.LogMethodEntry("RptAssessmentAllStudents", "GetActivityScore"
                , base.IsTakeScreenShotDuringEntryExit);
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
                , base.IsTakeScreenShotDuringEntryExit);
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
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait Until Window
            base.WaitUntilWindowLoads(RptAssessmentAllStudentsPageResource
                    .RptAssessmentAllStudent_Page_Window_Name);
            //Selecting the Activity Result by Report window
            base.SelectWindow(RptAssessmentAllStudentsPageResource
                .RptAssessmentAllStudent_Page_Window_Name);
            logger.LogMethodExit("RptAssessmentAllStudents",
                "SelectActivityResultsByStudentWindow"
                , base.IsTakeScreenShotDuringEntryExit);
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
               , base.IsTakeScreenShotDuringEntryExit);
            //Get Activity Score
            getActivityScore = base.GetElementTextByXPath(
                RptAssessmentAllStudentsPageResource.RptAssessmentAllStudent_Page_Score_Xpath_Locator);
            string[] score = getActivityScore.Split(Convert.ToChar(RptAssessmentAllStudentsPageResource.
                RptAssessmentAllStudent_Page_Activity_Score_SplittingCharacter));
            //Score Of The Activity
            getActivityScore = score[Convert.ToInt32(
                RptAssessmentAllStudentsPageResource.RptAssessmentAllStudent_Page_Ins_Score_Value)];
            logger.LogMethodExit("RptAssessmentAllStudents", "GetActivityScoreInReport"
                , base.IsTakeScreenShotDuringEntryExit);
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
                , base.IsTakeScreenShotDuringEntryExit);
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
                , base.IsTakeScreenShotDuringEntryExit);
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
                , base.IsTakeScreenShotDuringEntryExit);
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
               , base.IsTakeScreenShotDuringEntryExit);
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
                , base.IsTakeScreenShotDuringEntryExit);
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
               , base.IsTakeScreenShotDuringEntryExit);
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
                , base.IsTakeScreenShotDuringEntryExit);
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
                , base.IsTakeScreenShotDuringEntryExit);
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
                  base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                , base.IsTakeScreenShotDuringEntryExit);
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
                , base.IsTakeScreenShotDuringEntryExit);
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
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait Until Window
            base.WaitUntilWindowLoads(RptAssessmentAllStudentsPageResource.
                RptAssessmentAllStudent_Page_Activity_Result_Single_window_Name);
            //Selecting the Activity Result by Report window                
            base.SelectWindow(RptAssessmentAllStudentsPageResource.
                RptAssessmentAllStudent_Page_Activity_Result_Single_window_Name);
            logger.LogMethodExit("RptAssessmentAllStudents", "SelectActivityResultWindow"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Gets a average score value in the 'Activity Results (Multiple students)' report.
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
                this.SwitchToGeneratedReportWindow(RptAssessmentAllStudentsPageResource.
                       RptAssessmentAllStudent_Page__Activity_Result_Multiple_Students_Window_Title_Locator);
                base.WaitForElement(By.XPath(RptAssessmentAllStudentsPageResource.
               RptAssessmentAllStudent_Page_AverageScoreValue_Xpath_Locator));
                //Gets the text from the element
                getActualAverageScore = base.GetElementInnerTextByXPath
                    (RptAssessmentAllStudentsPageResource.
                 RptAssessmentAllStudent_Page_AverageScoreValue_Xpath_Locator);
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
                this.SwitchToGeneratedReportWindow(RptAssessmentAllStudentsPageResource.
                       RptAssessmentAllStudent_Page__Activity_Result_Multiple_Students_Window_Title_Locator);
                base.WaitForElement(By.XPath(RptAssessmentAllStudentsPageResource.
                     RptAssessmentAllStudents_Page_GridElementsCount_XPath_Locator));
                int getElementCount = base.GetElementCountByXPath(RptAssessmentAllStudentsPageResource.
                     RptAssessmentAllStudents_Page_GridElementsCount_XPath_Locator);
                for (int studentSearch = 1; studentSearch <= getElementCount; studentSearch++)
                {
                    base.WaitForElement(By.XPath(string.Format(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_StudentsName_XPath_Locator, studentSearch)));
                    getStudentName = base.GetElementTextByXPath(string.
                    Format(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_StudentsName_XPath_Locator, studentSearch));
                    if (getStudentName == studentName)
                    {
                        isStudentDisplayed = true;
                        break;
                    }
                    studentSearch++;
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
                this.SwitchToGeneratedReportWindow(RptAssessmentAllStudentsPageResource.
                       RptAssessmentAllStudent_Page__Activity_Result_Multiple_Students_Window_Title_Locator);
                base.WaitForElement(By.XPath(RptAssessmentAllStudentsPageResource.
                     RptAssessmentAllStudents_Page_GridElementsCount_XPath_Locator));
                int getElementCount = base.GetElementCountByXPath(RptAssessmentAllStudentsPageResource.
                     RptAssessmentAllStudents_Page_GridElementsCount_XPath_Locator);
                for (int studentSearch = 1; studentSearch <= getElementCount; studentSearch++)
                {
                    base.WaitForElement(By.XPath(string.Format(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_StudentsName_XPath_Locator, studentSearch)));
                    getStudentName = base.GetElementTextByXPath(string.
                    Format(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_StudentsName_XPath_Locator, studentSearch));
                    if (getStudentName == studentName)
                    {
                        base.WaitForElement(By.XPath(string.Format(RptAssessmentAllStudentsPageResource.
                       RptAssessmentAllStudent_Page_StudentAttemptValue_XPath_Locator, studentSearch)));
                        getStudentAttempts = base.GetElementTextByXPath(string.
                       Format(RptAssessmentAllStudentsPageResource.
                       RptAssessmentAllStudent_Page_StudentAttemptValue_XPath_Locator, studentSearch));
                        break;
                    }
                    studentSearch++;
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
        public Boolean IsStudentScorePercentagePresent(string scorePercent, string studentName)
        {
            //Get Student Score Percentage
            logger.LogMethodEntry("RptAllAssessmentAllStudentPage", "GetStudentScorePercentage",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getStudentName = string.Empty;
            string getStudentScorePercentage = string.Empty;
            bool scorePresent = false;
            try
            {
                //Select Window
                this.SwitchToGeneratedReportWindow(RptAssessmentAllStudentsPageResource.
                       RptAssessmentAllStudent_Page__Activity_Result_Multiple_Students_Window_Title_Locator);
                base.WaitForElement(By.XPath(RptAssessmentAllStudentsPageResource.
                     RptAssessmentAllStudents_Page_GridElementsCount_XPath_Locator));
                int getElementCount = base.GetElementCountByXPath(RptAssessmentAllStudentsPageResource.
                     RptAssessmentAllStudents_Page_GridElementsCount_XPath_Locator);
                for (int studentSearch = 1; studentSearch <= getElementCount; studentSearch++)
                {
                    base.WaitForElement(By.XPath(string.Format(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_StudentsName_XPath_Locator, studentSearch)));
                    getStudentName = base.GetElementTextByXPath(string.
                    Format(RptAssessmentAllStudentsPageResource.
                    RptAssessmentAllStudent_Page_StudentsName_XPath_Locator, studentSearch));
                    if (getStudentName == studentName)
                    {
                        base.WaitForElement(By.XPath(string.Format(RptAssessmentAllStudentsPageResource.
                       RptAssessmentAllStudent_Page_StudentScoreValue_XPath_Locator, studentSearch)));
                        getStudentScorePercentage = base.GetElementTextByXPath(string.
                       Format(RptAssessmentAllStudentsPageResource.
                       RptAssessmentAllStudent_Page_StudentScoreValue_XPath_Locator, studentSearch));
                        if (getStudentScorePercentage.Contains(scorePercent))
                        {
                            scorePresent = true;
                            break;
                        }

                    }
                    studentSearch++;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptAllAssessmentAllStudentPage", "GetStudentScorePercentage",
                 base.IsTakeScreenShotDuringEntryExit);
            return scorePresent;
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
                this.SwitchToGeneratedReportWindow(RptAssessmentAllStudentsPageResource.
                RptAssessmentAllStudent_Page__Activity_Result_Multiple_Students_Window_Title_Locator);
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
                this.SwitchToGeneratedReportWindow(RptAssessmentAllStudentsPageResource.
                RptAssessmentAllStudent_Page__Activity_Result_Multiple_Students_Window_Title_Locator);
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
    }
}
