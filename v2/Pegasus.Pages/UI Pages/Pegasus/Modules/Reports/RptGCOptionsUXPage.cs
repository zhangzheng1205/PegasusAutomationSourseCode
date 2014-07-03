using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.Exceptions;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus RptGCOptionsUX Page Actions
    /// </summary>
    public class RptGCOptionsUXPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptGCOptionsUXPage));

        /// <summary>
        /// Check for Select Activity Button
        /// </summary>
        public void SelectActivityButton()
        {
            //Select Activity Button 
            logger.LogMethodEntry("RptGCOptionsUXPage", "SelectActivityButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Select Activity Button
                base.WaitForElement(By.PartialLinkText(RptGCOptionsUXPageResource.
                    RptGCOptionsUX_Page_SelectActivity_Link_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptGCOptionsUXPage", "SelectActivityButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Select Activity Button
        /// </summary>
        public void SelectActivity()
        {
            //Click on Select Activity Button
            logger.LogMethodEntry("RptGCOptionsUXPage", "SelectActivity",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on Select Activity
                this.ClickonSelectActivity();
                //Selecting the Activity
                new RptSelectAssessmentsPage().SelectActivityToGenerateInstructorReport();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptGCOptionsUXPage", "SelectActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Select Activity.
        /// </summary>
        public void ClickonSelectActivity()
        {
            //Click on Select Activity
            logger.LogMethodEntry("RptGCOptionsUXPage", "ClickonSelectActivity",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.PartialLinkText(RptGCOptionsUXPageResource.
                        RptGCOptionsUX_Page_SelectActivity_Link_Locator));
                //Click on Select Activity Button
                base.ClickButtonByPartialLinkText(RptGCOptionsUXPageResource.
                    RptGCOptionsUX_Page_SelectActivity_Link_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptGCOptionsUXPage", "ClickonSelectActivity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Select Student Button
        /// </summary>
        public void SelectStudent(RptMainUXPage.PegasusInstructorReportEnum reportTypeEnum)
        {
            //Click on Select Student Button
            logger.LogMethodEntry("RptGCOptionsUXPage", "SelectStudent",
                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.SelectWindow(RptMainPageResource
                    .RptMain_Page_WindowName_Title);
                //Click on Select Student
                this.ClickonSelectStudent();
                //Selecting the Student
                new RptSelectStudentsPage().SelectStudentInInstructorReport(reportTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptGCOptionsUXPage", "SelectStudent",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Select Student.
        /// </summary>
        public void ClickonSelectStudent()
        {
            //Click on Select Student
            logger.LogMethodEntry("RptGCOptionsUXPage", "ClickonSelectStudent",
                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Frame
                base.WaitForElement(By.Id(RptMainUXPageResource.RptMain_Page_Frame_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(RptMainUXPageResource.RptMain_Page_Frame_Id_Locator);
                base.WaitForElement(By.PartialLinkText(RptGCOptionsUXPageResource.
                    RptGCOptionsUX_Page_SelectStudents_Link_Locator));
                //Click on Select Student Button
                base.ClickButtonByPartialLinkText(RptGCOptionsUXPageResource.
                    RptGCOptionsUX_Page_SelectStudents_Link_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptGCOptionsUXPage", "ClickonSelectStudent",
               base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Generate Activity Report
        /// </summary>
        public void GenerateReport()
        {
            //Generate Activity Result By Student Report
            logger.LogMethodEntry("RptGCOptionsUXPage", "GenerateReport",
                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.SelectWindow(RptMainPageResource.RptMain_Page_WindowName_Title);
                //Click on Generate Report
                this.ClickonGenerateReport();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptGCOptionsUXPage", "GenerateReport",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Generate Report.
        /// </summary>
        public void ClickonGenerateReport()
        {
            //Click on Generate Report
            logger.LogMethodEntry("RptGCOptionsUXPage", "ClickonGenerateReport",
                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Frame
                base.WaitForElement(By.Id(RptMainUXPageResource.RptMain_Page_Frame_Id_Locator));
                base.SwitchToIFrame(RptMainUXPageResource.RptMain_Page_Frame_Id_Locator);
                //Wait for RunReport Link
                base.WaitForElement(By.PartialLinkText(RptGCOptionsUXPageResource.
                    RptGCOptionsUX_Page_RunReport_Link_Locator));
                base.FocusOnElementByPartialLinkText(RptGCOptionsUXPageResource.
                    RptGCOptionsUX_Page_RunReport_Link_Locator);
                //Click On Run Report Button
                base.ClickButtonByPartialLinkText(RptGCOptionsUXPageResource.
                    RptGCOptionsUX_Page_RunReport_Link_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptGCOptionsUXPage", "ClickonGenerateReport",
                 base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select Students In Student Results By Activity Report
        /// </summary>
        /// <param name="reportTypeEnum">This is Report Type</param>
        public void SelectStudentInStudentResultByActivityReport(
            RptMainUXPage.PegasusInstructorReportEnum reportTypeEnum)
        {
            //Select Student In Student Results By Activity Report
            logger.LogMethodEntry("RptGCOptionsUXPage",
                "SelectStudentInStudentResultByActivityReport",
                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Report Window
                base.SelectWindow(RptMainPageResource
                        .RptMain_Page_WindowName_Title);
                //Wait for Frame
                base.WaitForElement(By.Id(RptGCOptionsUXPageResource.
                    RptGCOptionsUX_Page_Frame_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(RptGCOptionsUXPageResource.
                    RptGCOptionsUX_Page_Frame_Id_Locator);
                base.WaitForElement(By.PartialLinkText(RptGCOptionsUXPageResource.
                    RptGCOptionsUX_Page_SelectStudent_Link_Locator));
                //Click on Select Student Button
                base.ClickButtonByPartialLinkText(RptGCOptionsUXPageResource.
                    RptGCOptionsUX_Page_SelectStudent_Link_Locator);
                //Select the Student
                new RptSelectStudentsPage().SelectStudentInInstructorReport(reportTypeEnum);
                base.IsPopUpClosed(Convert.ToInt32(RptGCOptionsUXPageResource
                    .RptGCOptionsUX_Page_NumberOfWindow));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptGCOptionsUXPage",
                "SelectStudentInStudentResultByActivityReport",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Select Button In Report.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        public void SelectButtonInReport(string buttonName)
        {
            //Click on Select Button In Report
            logger.LogMethodEntry("RptGCOptionsUXPage", "SelectButtonInReport",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.PartialLinkText(buttonName));
                //Click on Select Button
                base.ClickButtonByPartialLinkText(buttonName);                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptGCOptionsUXPage", "SelectButtonInReport",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
