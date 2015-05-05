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
            try
            {
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
            }
            catch (System.Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
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
            try
            {
                //this.SelectWindow();
                base.SwitchToLastOpenedWindow();
                base.WaitForElement(By.XPath(
                    RptActivityResultByStudentPageRecource.
                    RptActivityResultByStudentPage_ActivityAverage_XPath_Locator));
                getAverageScore = base.GetElementTextByXPath(RptActivityResultByStudentPageRecource.
                    RptActivityResultByStudentPage_ActivityAverage_XPath_Locator).Trim();
            }
            catch (System.Exception e)
            {
                 ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptActivityResultByStudentPage", "GetAverageScoreInTheReport",
                 base.IsTakeScreenShotDuringEntryExit);
            return getAverageScore;
        }

        /// <summary>
        /// Get Student Name In Activity Result By Student
        /// </summary>
        /// <param name="studentName">This is the student name.</param>
        /// <returns>Student name.</returns>
        public bool GetStudentNameInActivityResultByStudent(string studentName)
        {
            //Get the student name from reports
            logger.LogMethodEntry("RptActivityResultByStudentPage",
                "GetStudentNameInActivityResultByStudent",
                base.IsTakeScreenShotDuringEntryExit);
            bool isStudentPresent = false;
            string getStudentName = string.Empty;
            base.SwitchToLastOpenedWindow();
            try
            {
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
                        RptActivityResultByStudentPage_ActivityStudentName_XPath_Locator, i)));
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
            }
            catch (System.Exception e)
            {
                 ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptActivityResultByStudentPage",
            "GetStudentNameInActivityResultByStudent",
                 base.IsTakeScreenShotDuringEntryExit);
            return isStudentPresent;
        }

        /// <summary>
        /// Get Student Score In Activity Result By Student
        /// </summary>
        /// <param name="scoreRow">This is the student score row number.</param>
        /// <returns>Activity score.</returns>
        public string GetStudentScoreInActivityResultByStudent(int scoreRow)
        {
            logger.LogMethodEntry("RptActivityResultByStudentPage",
                "GetStudentScoreInActivityResultByStudent",
                base.IsTakeScreenShotDuringEntryExit);
            string getScore = string.Empty;
            string studentPercentage = string.Empty;
            base.SwitchToLastOpenedWindow();
            try
            {                
                base.WaitForElement(By.XPath(string.Format(
                    RptActivityResultByStudentPageRecource.
                    RptActivityResultByStudentPage_ActivityStudentScore_XPath_Locator, scoreRow)));
                getScore = base.GetElementTextByXPath(string.Format(
                    RptActivityResultByStudentPageRecource.
                    RptActivityResultByStudentPage_ActivityStudentScore_XPath_Locator, scoreRow));
                 studentPercentage = getScore.Split(' ')[0].Trim();
            }
            catch (System.Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptActivityResultByStudentPage",
                "GetStudentScoreInActivityResultByStudent",
                     base.IsTakeScreenShotDuringEntryExit);
            return studentPercentage;
        }

        /// <summary>
        /// Get Student Score In Activity Result By Student by Admin.
        /// </summary>
        /// <param name="scoreRow">This is the student score row number.</param>
        /// <returns>Activity score.</returns>
        public string GetStudentScoreInActivityResultByStudentByAdmin(int scoreRow)
        {
            //Get Student Score In Activity Result By Student by Admin
            logger.LogMethodEntry("RptActivityResultByStudentPage",
                "GetStudentScoreInActivityResultByStudent",
                base.IsTakeScreenShotDuringEntryExit);
            string getScore = string.Empty;
            string studentPercentage = string.Empty;
            base.SwitchToLastOpenedWindow();
            try
            {
                base.WaitForElement(By.XPath(string.Format(
                       RptActivityResultByStudentPageRecource.
                      RptActivityResultByStudentPage_AdminActivityStudentScore_XPath_Locator,
                       scoreRow)));
                getScore = base.GetElementTextByXPath(string.Format(
                    RptActivityResultByStudentPageRecource.
                   RptActivityResultByStudentPage_AdminActivityStudentScore_XPath_Locator,
                    scoreRow));
                 studentPercentage = getScore.Split(' ')[0].Trim();
            }
            catch (System.Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptActivityResultByStudentPage",
                "GetStudentScoreInActivityResultByStudent",
                     base.IsTakeScreenShotDuringEntryExit);
            return studentPercentage;
        }

        /// <summary>
        /// Get Section Name In Instructor Report.
        /// </summary>
        /// <returns>Section name.</returns>
        public string GetSectionNameInInstructorReport()
        {
            logger.LogMethodEntry("RptActivityResultByStudentPage",
                           "GetSectionNameInInstructorReport",
                          base.IsTakeScreenShotDuringEntryExit);
            string getSection = string.Empty;
            try
            {
                bool ghsd = base.IsElementPresent(By.XPath(
                    RptActivityResultByStudentPageRecource.
                    RptActivityResultByStudentPage_SectionName_XPath_Locator));
                getSection = base.GetElementTextByXPath(
                    RptActivityResultByStudentPageRecource.
                    RptActivityResultByStudentPage_SectionName_XPath_Locator);
            }
            catch (System.Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptActivityResultByStudentPage",
                "GetSectionNameInInstructorReport",
                base.IsTakeScreenShotDuringEntryExit);
            return getSection;
        }

        /// <summary>
        /// Get Class Name In Instructor Report.
        /// </summary>
        /// <returns>Section name.</returns>
        public string GetClassNameInMasteryReport()
        {
            logger.LogMethodEntry("RptActivityResultByStudentPage",
                           "GetClassNameInMasteryReport",
                          base.IsTakeScreenShotDuringEntryExit);
            string getClassName = string.Empty;
            try
            {
                getClassName = base.GetElementTextById("MastryHeaderControl_Listdetails__ctl0_lblNameValue");
            }
            catch (System.Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptActivityResultByStudentPage",
                "GetSectionNameInInstructorReport",
                base.IsTakeScreenShotDuringEntryExit);
            return getClassName;
        }


        /// <summary>
        /// Get Course Name In Instructor Report.
        /// </summary>
        /// <returns>Section name.</returns>
        public string GetCourseNameInMasteryReport()
        {
            logger.LogMethodEntry("RptActivityResultByStudentPage",
                           "GetCourseNameInMasteryReport",
                          base.IsTakeScreenShotDuringEntryExit);
            string getCourseName = string.Empty;
            try
            {
                getCourseName = base.GetElementTextById("MastryHeaderControl_Listdetails__ctl1_lblNameValue");
            }
            catch (System.Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptActivityResultByStudentPage",
                "GetCourseNameInMasteryReport",
                base.IsTakeScreenShotDuringEntryExit);
            return getCourseName;
        }

        /// <summary>
        /// Get Image existance status.
        /// </summary>
        /// <returns>True or False</returns>
        public bool GetGraphExistanceStatus()
        {
            bool getGraphStatus = false;
            logger.LogMethodEntry("RptActivityResultByStudentPage",
                           "GetGraphExistanceStatus",
                          base.IsTakeScreenShotDuringEntryExit);
            try
            {
                getGraphStatus = base.IsElementPresent(By.Id("IndividualMastery_GraphView_GraphButonId"));

            }
            catch (System.Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptActivityResultByStudentPage",
                "GetCourseNameInMasteryReport",
                base.IsTakeScreenShotDuringEntryExit);
            return getGraphStatus;
        }

        public string getScoreClassMastaryReport()
        {
            
            logger.LogMethodEntry("RptActivityResultByStudentPage", "getScoreClassMastaryReport",base.IsTakeScreenShotDuringEntryExit);
            string score = string.Empty;
            base.SelectWindow("Mastery Report");
            
            //score = base.GetValueAttributeById("AssignmentOption").Trim();
           string hhj = base.GetTitleAttributeValueById("AssignmentOption");
           score = base.GetValueAttributeById("AssignmentOption");
           string getScore = score.ToString();
            logger.LogMethodExit("RptActivityResultByStudentPage", "getScoreClassMastaryReport", base.IsTakeScreenShotDuringEntryExit);
            return score;
        }
    }
}
