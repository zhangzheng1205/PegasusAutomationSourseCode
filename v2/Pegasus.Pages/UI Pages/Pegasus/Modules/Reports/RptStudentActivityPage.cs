using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Student Activity Actions
    /// </summary>
    public class RptStudentActivityPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptStudentActivityPage));

        /// <summary>
        /// //Click The Student Activity Link
        /// </summary>
        public void ClickTheStudentActivityLink()
        {
            //Click The Student Activity           
            logger.LogMethodEntry("RptStudentActivityPage",
                "ClickTheStudentActivityLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Frame
                new RptCommonCriteriaPage().SelectTheReportFrame();
                //Wait for the element
                base.WaitForElement(By.XPath(RptStudentActivityPageResource.
                    RptStudentActivity_Page_SelectActivity_Xpath_Locator));
                base.FocusOnElementByXPath(RptStudentActivityPageResource.
                    RptStudentActivity_Page_SelectActivity_Xpath_Locator);
                IWebElement getStudentLink = base.GetWebElementPropertiesByXPath
                    (RptStudentActivityPageResource.
                    RptStudentActivity_Page_SelectActivity_Xpath_Locator);
                //Click the "Student Activity" Link
                base.ClickByJavaScriptExecutor(getStudentLink);               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            } 
            logger.LogMethodExit("RptStudentActivityPage",
                "ClickTheStudentActivityLink",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Detailed Report
        /// </summary>
        public void SelectDetailedReport()
        {
            //Select Detailed Report
            logger.LogMethodEntry("RptStudentActivityPage",
               "SelectDetailedReport",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Window
                base.SelectWindow(RptStudentActivityPageResource.
                    RptStudentActivity_Page_SelectActivityReport_Window_Name);
                base.WaitForElement(By.ClassName(RptStudentActivityPageResource.
                    RptStudentActivity_Page_SelectDetail_link_ClassName));
                //Get Web Element
                IWebElement getSelectDetail = base.GetWebElementPropertiesByClassName
                    (RptStudentActivityPageResource.
                    RptStudentActivity_Page_SelectDetail_link_ClassName);
                //Click the "Detailed Report"
                base.ClickByJavaScriptExecutor(getSelectDetail);
                Thread.Sleep(Convert.ToInt32(RptStudentActivityPageResource.
                    RptStudentActivity_Page_SelectDetail_link_TimeValue));
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentActivityPage",
                "SelectDetailedReport",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Student Activity Report Close Button
        /// </summary>
        public void StudentActivityReportCloseButton()
        {
            //Student Activity Report Close Button
            logger.LogMethodEntry("RptStudentActivityPage",
              "StudentActivityReportCloseButton",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SelectWindow(RptStudentActivityPageResource.
                        RptStudentActivity_Page_SelectActivityReport_Window_Name);
                //Wait for the element
                base.WaitForElement(By.ClassName(RptStudentActivityPageResource.
                    RptStudentActivity_Page_SelectActivityReport_CloseButton_ClassName));
                base.FocusOnElementByClassName(RptStudentActivityPageResource.
                    RptStudentActivity_Page_SelectActivityReport_CloseButton_ClassName);
                //Get web element
                IWebElement getCloseButton = base.
                 GetWebElementPropertiesByClassName(RptStudentActivityPageResource.
                    RptStudentActivity_Page_SelectActivityReport_CloseButton_ClassName);
                //Click the "Close" button
                base.ClickByJavaScriptExecutor(getCloseButton);
                Thread.Sleep(Convert.ToInt32(RptStudentActivityPageResource.
                 RptStudentActivity_Page_SelectDetail_link_TimeValue));
                base.SelectDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentActivityPage",
               "StudentActivityReportCloseButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close Student Avtivity Report  Button In Organization Admin
        /// </summary>
        public void CloseStudentAvtivityReportButtonInOrganizationAdmin()
        {
            //Close Student Avtivity Report  Btn In Organization Admin
            logger.LogMethodEntry("RptStudentActivityPage",
              "CloseStudentAvtivityReportButtonInOrganizationAdmin",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.SelectWindow(RptStudentActivityPageResource.
                            RptStudentActivity_Page_SelectActivityReport_Window_Name);
                //Wait for the element
                base.WaitForElement(By.ClassName(RptStudentActivityPageResource.
                    RptStudentActivity_Page_StuActivityRpt_CloseBtn_ClassName));
                base.FocusOnElementByClassName(RptStudentActivityPageResource.
                    RptStudentActivity_Page_StuActivityRpt_CloseBtn_ClassName);
                //Get web element
                IWebElement getCloseButton = base.
                 GetWebElementPropertiesByClassName(RptStudentActivityPageResource.
                    RptStudentActivity_Page_StuActivityRpt_CloseBtn_ClassName);
                //Click the "Close" button
                base.ClickByJavaScriptExecutor(getCloseButton);
                Thread.Sleep(Convert.ToInt32(RptStudentActivityPageResource.
                 RptStudentActivity_Page_SelectDetail_link_TimeValue));
                base.SelectDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentActivityPage",
               "CloseStudentAvtivityReportButtonInOrganizationAdmin",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get data from student activity report columns.
        /// </summary>
        /// <param name="columnName">Column name to fetch data.</param>
        /// <returns>True if data found in column or else returns false.</returns>
        public bool GetStudentDataFromStudentActivityReport(string columnName)
        {
            logger.LogMethodEntry("RptStudentActivityPage",
             "GetStudentDataFromStudentActivityReport",
             base.IsTakeScreenShotDuringEntryExit);
            bool isDataExists = false;
            string getColumnData = null;
            try
            {
            base.WaitForElement(By.XPath(RptStudentActivityPageResource.
                RptStudentActivity_Page_StuActivityRpt_StudentData_Xpath_Locator));
            switch(columnName)
            {
                case "Student":
                    getColumnData = base.GetElementTextByXPath(RptStudentActivityPageResource.
                        RptStudentActivity_Page_StuActivityRpt_StudentColumnData_Xpath_Locator);
                    if (getColumnData.Equals("--"))
                    {
                        isDataExists = false;
                    }
                    else
                    {
                        isDataExists = true;
                    }
                    break;
                case "Class":
                    getColumnData = base.GetElementTextByXPath(RptStudentActivityPageResource.
                        RptStudentActivity_Page_StuActivityRpt_ClassColumnData_Xpath_Locator);
                    if (getColumnData.Equals("--"))
                    {
                        isDataExists = false;
                    }
                    else
                    {
                        isDataExists = true;
                    }
                    break;
                case "Course":
                    getColumnData = base.GetElementTextByXPath(RptStudentActivityPageResource.
                        RptStudentActivity_Page_StuActivityRpt_CourseColumnData_Xpath_Locator);
                    if (getColumnData.Equals("--"))
                    {
                        isDataExists = false;
                    }
                    else
                    {
                        isDataExists = true;
                    }
                    break;
                case "Start Date":
                    getColumnData = base.GetElementTextByXPath(RptStudentActivityPageResource.
                        RptStudentActivity_Page_StuActivityRpt_StartDateColumnData_Xpath_Locator);
                    if (getColumnData.Equals("--"))
                    {
                        isDataExists = false;
                    }
                    else
                    {
                        isDataExists = true;
                    }
                    break;
                case "Last Attempt":
                    getColumnData = base.GetElementTextByXPath(RptStudentActivityPageResource.
                        RptStudentActivity_Page_StuActivityRpt_LastAttemptColumnData_Xpath_Locator);
                    if (getColumnData.Equals("--"))
                    {
                        isDataExists = false;
                    }
                    else
                    {
                        isDataExists = true;
                    }
                    break;
                case "Days Online":
                    getColumnData = base.GetElementTextByXPath(RptStudentActivityPageResource.
                        RptStudentActivity_Page_StuActivityRpt_DaysOnlineColumnData_Xpath_Locator);
                    if (getColumnData.Equals("--"))
                    {
                        isDataExists = false;
                    }
                    else
                    {
                        isDataExists = true;
                    }
                    break;
                case "Time on Task":
                    getColumnData = base.GetElementTextByXPath(RptStudentActivityPageResource.
                        RptStudentActivity_Page_StuActivityRpt_TimeOnTaskColumnData_Xpath_Locator);
                    if (getColumnData.Equals("--"))
                    {
                        isDataExists = false;
                    }
                    else
                    {
                        isDataExists = true;
                    }
                    break;

                default:
                    throw new Exception("Column does not exists");
            }
                 }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentActivityPage",
               "GetStudentDataFromStudentActivityReport",
            base.IsTakeScreenShotDuringEntryExit);
             return isDataExists;
        }


    }
}
