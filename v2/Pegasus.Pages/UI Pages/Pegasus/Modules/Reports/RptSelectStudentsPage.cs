using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus RptSelectStudents Page Actions
    /// Class Name is bad because as it is in Pegasus
    /// </summary>
    public class RptSelectStudentsPage : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(RptSelectStudentsPage));

        /// <summary>
        /// Selecting Student in Instructor Report
        /// </summary>
        public void SelectStudentInInstructorReport(RptMainUXPage.
            PegasusInstructorReportEnum reportType)
        {
            //Selecting the Student
            logger.LogMethodEntry("RptSelectStudentsPage", "SelectStudentInInstructorReport"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (reportType)
                {
                    case RptMainUXPage.PegasusInstructorReportEnum.ActivityResultsbyStudent:
                        base.WaitUntilWindowLoads(RptSelectStudentsResource.
                        RptSelectStudents_Page_Ins_Window_Name);
                        //Select Select Students Window
                        base.SelectWindow(RptSelectStudentsResource.
                        RptSelectStudents_Page_Ins_Window_Name);
                        //Select the Student
                        this.SelectStudentToGenerateReport(RptSelectStudentsResource
                       .RptSelectStudents_Page_Ins_Student_LastName);                        
                        break;

                    case RptMainUXPage.PegasusInstructorReportEnum.StudentResultsbyActivity:
                        base.WaitUntilWindowLoads(RptSelectStudentsResource.
                            RptSelectStudents_Page_Ins_SelectStudent_Window_Name);
                        //Select Select Student Window
                        base.SelectWindow(RptSelectStudentsResource.
                            RptSelectStudents_Page_Ins_SelectStudent_Window_Name);
                        //Select the Student
                        this.SelectStudentToGenerateReport(RptSelectStudentsResource
                       .RptSelectStudents_Page_Ins_Student_LastName);
                        break;

                    case RptMainUXPage.PegasusInstructorReportEnum.StudyPlanResults:
                        base.WaitUntilWindowLoads(RptSelectStudentsResource.
                        RptSelectStudents_Page_Ins_Window_Name);
                        //Select Select Students Window
                        base.SelectWindow(RptSelectStudentsResource.
                        RptSelectStudents_Page_Ins_Window_Name);
                        //Select the Student
                        this.SelectStudentToGenerateReport(RptSelectStudentsResource
                       .RptSelectStudents_Page_Ins_Student_LastName);                        
                        break;
                }
                base.WaitForElement(By.PartialLinkText(RptSelectStudentsResource.
                    RptSelectStudents_Page_Ins_AddLinkText_Locator));
                //Click on Add Button 
                base.ClickButtonByPartialLinkText(RptSelectStudentsResource.
                    RptSelectStudents_Page_Ins_AddLinkText_Locator);
                //Check If Window is Close
                base.IsPopUpClosed(Convert.ToInt32(RptSelectStudentsResource.
                    RptSelectStudents_Page_Ins_Window_Count));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectStudentsPage", "SelectStudentInInstructorReport"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting Checkbox of the Student As Instructor.
        /// </summary>
        /// <param name="studentName">This is Student Name.</param>
        public void SelectStudentToGenerateReport(string studentName)
        {
            //Selecting Checkbox of the Student As Instructor
            logger.LogMethodEntry("RptSelectStudentsPage", "SelectStudentToGenerateReport"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Count of Total Students
                base.WaitForElement(By.XPath(RptSelectStudentsResource.
                    RptSelectStudents_Page_Ins_StudentCount_Xpath_Locator));
                //Initilazing Student Count
                int getStudentCount = base.GetElementCountByXPath(RptSelectStudentsResource.
                    RptSelectStudents_Page_Ins_StudentCount_Xpath_Locator);
                // To select checkbox for required student
                for (int rowCount = Convert.ToInt32(RptSelectStudentsResource.
                    RptSelectStudents_Page_Ins_Student_RowNo); rowCount <= getStudentCount; rowCount++)
                {
                    //Get text of student row
                    string selectStudentTextValue = base.GetElementTextByXPath(string.Format(
                        RptSelectStudentsResource.RptSelectStudents_Page_Ins_StudentSelect_Xpath_Locator,
                        rowCount));
                    if (selectStudentTextValue.Contains(studentName))
                    {
                        base.WaitForElement(By.XPath(string.Format(RptSelectStudentsResource.
                            RptSelectStudents_Page_Ins_Student_Checkbox_Xpath_Locator, rowCount)));
                        //Select Student Checkbox
                        IWebElement getStudentCheckbox=base.GetWebElementPropertiesByXPath
                            (string.Format(RptSelectStudentsResource.
                            RptSelectStudents_Page_Ins_Student_Checkbox_Xpath_Locator, rowCount));
                        base.ClickByJavaScriptExecutor(getStudentCheckbox);                        
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectStudentsPage", "SelectStudentToGenerateReport"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student for program admin reports.
        /// </summary>
        public void SelectStudentInProgramAdminReport()
        {
            //Select Student for Program Admin Reports
            logger.LogMethodEntry("RptSelectStudentsPage", "SelectStudentInProgramAdminReport"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {              
                //Click on the Expand button
                base.WaitForElement(By.XPath(RptSelectStudentsResource.
                    RptSelectStudents_Page_PgA_Expand_Image_Xpath_Locator));
                base.ClickImageByXPath(RptSelectStudentsResource.
                    RptSelectStudents_Page_PgA_Expand_Image_Xpath_Locator);
                // Check student Check box
                this.SelectStudentToGenerateProgramAdminReport(
                    RptSelectStudentsResource.RptSelectStudents_Page_Ins_Student_LastName);
                //Click On Add Button
                this.ClickOnAddButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectStudentsPage", "SelectStudentInProgramAdminReport"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Button.
        /// </summary>
        public void ClickOnAddButton()
        {
            //Click On Add Button
            logger.LogMethodEntry("RptSelectStudentsPage", "ClickOnAddButton"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click Add button 
                base.FocusOnElementById(RptSelectStudentsResource.
                    RptSelectStudents_Page_PgA_Add_Button_Id_Locator);
                base.ClickButtonById(RptSelectStudentsResource.
                    RptSelectStudents_Page_PgA_Add_Button_Id_Locator);
                //Check 'Select Students' popup closed
                base.IsPopUpClosed(Convert.ToInt32(RptSelectStudentsResource.
                    RptSelectStudents_Page_Ins_Window_Count));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectStudentsPage", "ClickOnAddButton"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student Window.
        /// </summary>
        public void SelectStudentWindow()
        {
            //Select Student Window
            logger.LogMethodEntry("RptSelectStudentsPage", "SelectStudentWindow"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select 'Select Student' window
                base.WaitUntilWindowLoads(RptSelectStudentsResource.
                    RptSelectStudents_Page_Select_Student_Window_Name);
                base.SelectWindow(RptSelectStudentsResource.
                    RptSelectStudents_Page_Select_Student_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectStudentsPage", "SelectStudentWindow"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Students Window.
        /// </summary>
        public void SelectStudentsWindow()
        {
            //Select Student Window
            logger.LogMethodEntry("RptSelectStudentsPage", "SelectStudentsWindow"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select 'Select Students' window
                base.WaitUntilWindowLoads(RptSelectStudentsResource.
                    RptSelectStudents_Page_Ins_Window_Name);
                base.SelectWindow(RptSelectStudentsResource.
                    RptSelectStudents_Page_Ins_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectStudentsPage", "SelectStudentsWindow"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check checkbox in 'Select Students' pop up as program admin
        /// </summary>
        /// <param name="studentName">This is studentName</param>
        private void SelectStudentToGenerateProgramAdminReport(string studentName)
        {
            //Selecting the Checkbox of the Student
            logger.LogMethodEntry("RptSelectStudentsPage",
                "SelectStudentToGenerateProgramAdminReport", base.IsTakeScreenShotDuringEntryExit);
            //Get Count of Total Students
            WaitForElement(By.XPath(RptSelectStudentsResource.
                     RptSelectStudents_Page_PgA_StudentCount_Xpath_Locator));
            //Get Total Student Count
            int getStudentCount = base.GetElementCountByXPath(RptSelectStudentsResource.
                           RptSelectStudents_Page_PgA_StudentCount_Xpath_Locator);
            // To select checkbox for required student
            for (int initialCount = 1; initialCount <= getStudentCount; initialCount++)
            {
                //Get text of student
                string getStudentTextValue = base.GetElementTextByXPath(
                    RptSelectStudentsResource.
                                   RptSelectStudents_Page_PgA_StudentText_Xpath_Locator);
                if (getStudentTextValue.Contains(studentName))
                {
                    base.WaitForElement(By.XPath(string.Format(RptSelectStudentsResource.
                        RptSelectStudents_Page_PgA_Student_Checkbox_Xpath_Locator)));
                    //Click on Checkbox of the Student Name
                    base.SelectCheckBoxByXPath(RptSelectStudentsResource.
                         RptSelectStudents_Page_PgA_Student_Checkbox_Xpath_Locator);
                    break;
                }
            }
            logger.LogMethodExit("RptSelectStudentsPage",
                "SelectStudentToGenerateProgramAdminReport", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  //Check select all in 'Select Students' window.
        /// </summary>
        public void CheckSelectAll()
        {
            //Check select all in 'Select Students' window
            logger.LogMethodEntry("RptSelectStudentsPage",
               "SelectAllStudent", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectStudentsWindow();
                base.WaitForElement(By.Id(RptSelectStudentsResource.
                    RptSelectStudents_Page_SelectAll_Checkbox_Id_Locator));
                //Check select all in 'Select Students' window
                IWebElement selectAll=base.GetWebElementPropertiesById(RptSelectStudentsResource.
                    RptSelectStudents_Page_SelectAll_Checkbox_Id_Locator);
                base.ClickByJavaScriptExecutor(selectAll);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectStudentsPage",
                 "SelectAllStudent", base.IsTakeScreenShotDuringEntryExit);

        }
    }
}
