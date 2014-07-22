using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class defines the actions of right activity frame of report student studyplan.
    /// </summary>
    public class RptStuStudyPlanPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(RptStuStudyPlanPage));

        /// <summary>
        /// Click The View Button In Report.
        /// </summary>
        public void ClickTheViewButtonInReport()
        {
            //Click The View Button In Report
            logger.LogMethodEntry("RptStuStudyPlanPage", "ClickTheViewButtonInReport",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the StudyPlan Summary Report Window
                this.SelectStudyplanSummaryReportWindow();
                //Fetch the data from memory
                Activity activity = Activity.Get(Activity.ActivityTypeEnum.Sim5PreTest);
                //Get The Activity Count In Report
                int getActivityColumnCount = this.GetTheActivityCountInReport(activity.Name);
                //Click The View Button
                this.ClickTheViewButton(getActivityColumnCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStuStudyPlanPage", "ClickTheViewButtonInReport",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The View Button.
        /// </summary>
        /// <param name="getActivityColumnCount">This is Column Count Of Activity.</param>
        private void ClickTheViewButton(int getActivityColumnCount)
        {
            //Click The View Button
            logger.LogMethodEntry("RptStuStudyPlanPage", "ClickTheViewButton",
              base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.XPath(string.Format
             (RptStuStudyPlanPageResource.
                RptStuStudyPlanPage_ViewButton_Xpath_Locator, 
                getActivityColumnCount)));
            IWebElement getViewButton=base.GetWebElementPropertiesByXPath
              (string.Format(RptStuStudyPlanPageResource.
                RptStuStudyPlanPage_ViewButton_Xpath_Locator,
                getActivityColumnCount));
            //Click the view button
            base.ClickByJavaScriptExecutor(getViewButton);  
            logger.LogMethodExit("RptStuStudyPlanPage", "ClickTheViewButton",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Get The Activity Count In Report.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>This is Activity Column Number.</returns>
        private int GetTheActivityCountInReport(string activityName)
        {
            //Get Activity Column Count
            logger.LogMethodEntry("GBInstructorUXPage", "GetActivityColumnCount",
            base.isTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            string getActivityName = string.Empty;
            //Initialize VariableVariable
            int activityColumnNumber = 0;
            //Getting the counts of Activity                    
            int getActivityCount = base.GetElementCountByXPath(
                RptStuStudyPlanPageResource.
               RptStuStudyPlanPage_Activity_Totalcount_Xpath_Locator);
            for (int columnCount = 1; columnCount <= getActivityCount;
                columnCount++)
            {
                //Wait for Element
                base.WaitForElement(By.XPath(string.Format(RptStuStudyPlanPageResource.
                    RptStuStudyPlanPage_Activity_Name_Xpath_Locator, columnCount)));
                //Getting the Activity name
                getActivityName = base.GetElementTextByXPath
                    (string.Format(RptStuStudyPlanPageResource.
                    RptStuStudyPlanPage_Activity_Name_Xpath_Locator, columnCount));
                if (getActivityName.Contains(activityName))
                {
                    activityColumnNumber = columnCount;
                    break;
                }
            }
            logger.LogMethodExit("GBInstructorUXPage", "GetActivityColumnCount",
             base.isTakeScreenShotDuringEntryExit);
            return activityColumnNumber;
        }

        /// <summary>
        /// Select the StudyPlan Summary Report Window.
        /// </summary>
        private void SelectStudyplanSummaryReportWindow()
        {
            //Select the StudyPlan Summary Report Window
            logger.LogMethodEntry("RptStuStudyPlanPage", 
                "SelectStudyplanSummaryReportWindow",
             base.isTakeScreenShotDuringEntryExit);
            //StudyPlan Summary Report
            base.WaitUntilWindowLoads(RptStuStudyPlanPageResource.
                RptStuStudyPlanPage_Studyplan_WindowName);
            base.SelectWindow(RptStuStudyPlanPageResource.
                RptStuStudyPlanPage_Studyplan_WindowName);
            logger.LogMethodExit("RptStuStudyPlanPage",
                "SelectStudyplanSummaryReportWindow",
              base.isTakeScreenShotDuringEntryExit);  
        }

        /// <summary>
        /// Click On Close Button In Report Page.
        /// </summary>
        public void ClickOnCloseButtonInReportPage()
        {
            //Click On Close Button In Report Page
            logger.LogMethodEntry("RptStuStudyPlanPage",
                "ClickOnCloseButtonInReportPage",
             base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select StudyPlan Summary Report window
                this.SelectStudyplanSummaryReportWindow();
                //Wait for the element
                base.WaitForElement(By.Id(RptStuStudyPlanPageResource.
                    RptStuStudyPlanPage_CloseButton_IdLocator));
                IWebElement getCloseButton = base.GetWebElementPropertiesById
                    (RptStuStudyPlanPageResource.
                    RptStuStudyPlanPage_CloseButton_IdLocator);
                //Click on Close button
                base.ClickByJavaScriptExecutor(getCloseButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStuStudyPlanPage",
                "ClickOnCloseButtonInReportPage",
              base.isTakeScreenShotDuringEntryExit);              
        }

        /// <summary>
        ///Get The Student Name In Report.
        /// </summary>
        /// <param name="activityName">This is Student Name.</param>
        /// <returns>This is Student Name.</returns>
        public String GetStudentName()
        {
            //Get Student Name
            logger.LogMethodEntry("RptStuStudyPlanPage", "GetStudentName"
                , base.isTakeScreenShotDuringEntryExit);
            //Intialized Get Student Name Variable
            string getStudentName = string.Empty;
            try
            {
                //Select Window
                this.SelectStudyPlanResultsWindow();
                //Get Student Name In Report
                getStudentName = this.GetStudentNameInStudyPlanReport(getStudentName);
                base.WaitUntilWindowLoads(RptMainPageResource
                    .RptMain_Page_WindowName_Title);
                base.SelectWindow(RptMainPageResource
                    .RptMain_Page_WindowName_Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStuStudyPlanPage", "GetStudentName"
               , base.isTakeScreenShotDuringEntryExit);
            //Name of the Student
            return getStudentName;
        }

        /// <summary>
        ///Get The StudyPlan In Report.
        /// </summary>
        /// <param name="activityName">This is StudyPlan Name.</param>
        /// <returns>This is StudyPlan Name.</returns>
        public String GetStudyPlanName()
        {
            //Get StudyPlan Name
            logger.LogMethodEntry("RptStuStudyPlanPage", "GetStudyPlanName"
                , base.isTakeScreenShotDuringEntryExit);
            //Intialized Get Studyplan Name Variable
            string getStudyPlanName = string.Empty;
            try
            {
                //Select Study Plan Results Report Window
                this.SelectStudyPlanResultsWindow();
                //Get StudyPlan In Report
                getStudyPlanName = this.GetStudyPlanNameInStudyPlanReport(getStudyPlanName);
                base.WaitUntilWindowLoads(RptMainPageResource
                    .RptMain_Page_WindowName_Title);
                base.SelectWindow(RptMainPageResource
                    .RptMain_Page_WindowName_Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStuStudyPlanPage", "GetStudyPlanName"
               , base.isTakeScreenShotDuringEntryExit);
            //Name of the studyplan
            return getStudyPlanName;
        }

        /// <summary>
        /// Select Study Plan Results Report Window.
        /// </summary>
        private void SelectStudyPlanResultsWindow()
        {           
            logger.LogMethodEntry("RptStuStudyPlanPage",
                "SelectStudyPlanResultsWindow"
                , base.isTakeScreenShotDuringEntryExit);
            //Wait Until Window
            base.WaitUntilWindowLoads(RptStuStudyPlanPageResource
                    .RptStuStudyPlanPage_StudyplanResults_WindowName);
            //Selecting the Study Plan Results Report window
            base.SelectWindow(RptStuStudyPlanPageResource
                .RptStuStudyPlanPage_StudyplanResults_WindowName);
            logger.LogMethodExit("RptStuStudyPlanPage",
                "SelectStudyPlanResultsWindow"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Get The Average Score In Report.
        /// </summary>
        /// <param></param>
        /// <returns>This is Study plan average score.</returns>
        public String GetAverageScore()
        {
            logger.LogMethodEntry("RptStuStudyPlanPage", "GetAverageScore"
                , base.isTakeScreenShotDuringEntryExit);
            //Intialized Get average score Variable
            string getAverageScore = string.Empty;
            try
            {              
                this.SelectStudyPlanResultsWindow();
                //Get Average Score In Report
                getAverageScore = this.GetAverageScoreInStudyPlanReport(getAverageScore);
                this.CloseStudyPlanResultsWindow();
                base.WaitUntilWindowLoads(RptMainPageResource
                    .RptMain_Page_WindowName_Title);
                base.SelectWindow(RptMainPageResource
                    .RptMain_Page_WindowName_Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStuStudyPlanPage", "GetAverageScore"
               , base.isTakeScreenShotDuringEntryExit);
            //Name of the Student
            return getAverageScore;
        }

        /// <summary>
        /// Get Student Name In Report.
        /// </summary>
        /// <param name="getStudentName">This is Student Name.</param>
        /// <returns>Student Name.</returns>
        private string GetStudentNameInStudyPlanReport(string getStudentName)
        {
            logger.LogMethodEntry("RptStuStudyPlanPage", "GetStudentNameInStudyPlanReport"
                , base.isTakeScreenShotDuringEntryExit);
            //Get Student Name in (Lname, Fname) format
            getStudentName = base.GetElementTextByXPath(RptStuStudyPlanPageResource.
                 RptStuStudyPlanResultsPage_Student_Name_Xpath_Locator);
            string[] name = getStudentName.Split(Convert.ToChar(RptStuStudyPlanPageResource.
                RptStuStudyPlanPage_Student_Name_SplittingCharacter));
            //Read only Last Name
            getStudentName = name[Convert.ToInt32(
                RptStuStudyPlanPageResource.RptStuStudyPlanPage_Ins_Score_Value)];
            logger.LogMethodExit("RptStuStudyPlanPage", "GetStudentNameInStudyPlanReport"
               , base.isTakeScreenShotDuringEntryExit);
            return getStudentName;
        }

        /// <summary>
        /// Get Study Plan Name In Report.
        /// </summary>
        /// <param name="getStudentName">This is StudyPlan Name.</param>
        /// <returns>StudyPlan Name.</returns>
        private string GetStudyPlanNameInStudyPlanReport(string studyPlanName)
        {
            //Get Study Plan In Report
            logger.LogMethodEntry("RptStuStudyPlanPage", "GetStudyPlanNameInStudyPlanReport"
                , base.isTakeScreenShotDuringEntryExit);
            //Get Study Plan Name
            studyPlanName = base.GetElementTextByXPath(RptStuStudyPlanPageResource.
                 RptStuStudyPlanResultsPage_StudyPlan_Name_Xpath_Locator);
            logger.LogMethodExit("RptStuStudyPlanPage", "GetStudyPlanNameInStudyPlanReport"
               , base.isTakeScreenShotDuringEntryExit);
            return studyPlanName;
        }

        /// <summary>
        /// Get Average Score In Report.
        /// </summary>
        /// <param name="getStudentName">This is Average score.</param>
        /// <returns>Average Score.</returns>
        private string GetAverageScoreInStudyPlanReport(string getAverageScore)
        {
            logger.LogMethodEntry("RptStuStudyPlanPage", "GetAverageScoreInStudyPlanReport"
                , base.isTakeScreenShotDuringEntryExit);
            //Get Student score in % format
            getAverageScore = base.GetElementTextByXPath(RptStuStudyPlanPageResource.
                 RptStuStudyPlanResultsPage_Student_Score_Xpath_Locator);
            string[] name = getAverageScore.Split(Convert.ToChar(RptStuStudyPlanPageResource.
                RptStuStudyPlanPage_Student_Score_SplittingCharacter));
            //Read only score (truncate '%' symbol)
            getAverageScore = name[Convert.ToInt32(
                RptStuStudyPlanPageResource.RptStuStudyPlanPage_Ins_Score_Value)];            
            logger.LogMethodExit("RptStuStudyPlanPage", "GetAverageScoreInStudyPlanReport"
               , base.isTakeScreenShotDuringEntryExit);
            return getAverageScore;
        }

        /// <summary>
        /// Close Study Plan Results Report Window.
        /// </summary>
        private void CloseStudyPlanResultsWindow()
        {
            logger.LogMethodEntry("RptStuStudyPlanPage", "CloseStudyPlanResultsWindow"
                , base.isTakeScreenShotDuringEntryExit);
            //click on close button in the report window
            base.WaitForElement(By.PartialLinkText(RptStuStudyPlanPageResource.
                RptStuStudyPlanPage_Close_Link_Locator));
            base.FocusOnElementByPartialLinkText(RptStuStudyPlanPageResource.
                RptStuStudyPlanPage_Close_Link_Locator);
            //Click on Close Button
            base.ClickButtonByPartialLinkText(RptStuStudyPlanPageResource.
                RptStuStudyPlanPage_Close_Link_Locator);
            base.IsPopUpClosed(2);
            logger.LogMethodExit("RptStuStudyPlanPage", "CloseStudyPlanResultsWindow"
               , base.isTakeScreenShotDuringEntryExit);
        }
        
    }
}
