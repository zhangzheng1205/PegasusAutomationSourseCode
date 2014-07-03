using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
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
    }
}
