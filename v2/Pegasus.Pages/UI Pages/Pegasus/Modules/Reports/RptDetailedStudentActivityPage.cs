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
    /// This class handles Student Activity Actions.
    /// The Class Name is bad as per Pegasus page name.
    /// </summary>
    public class RptDetailedStudentActivityPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptDetailedStudentActivityPage));

        /// <summary>
        /// Verify The Grade Displayed.
        /// </summary>
        /// <returns>Activity Score.</returns>
        public String VerifyTheGradeDisplayed()
        {
            //Verify The Grade Displayed
            logger.LogMethodEntry("RptDetailedStudentActivityPage",
                 "VerifyTheGradeDisplayed",
                 base.IsTakeScreenShotDuringEntryExit);
            //Intializing the variable
            string getActivityScore = string.Empty;
            try
            {
                //Select the window
                base.SelectWindow(RptDetailedStudentActivityPageResource.
                       RptDetailedStudentActivity_Page_Window_Name);
                //Wait for the element
                base.WaitForElement(By.XPath(RptDetailedStudentActivityPageResource.
                    RptDetailedStudentActivity_Page_TotalDivCount_Xpath_Locator));
                int totalDivCount = base.GetElementCountByXPath(
                    RptDetailedStudentActivityPageResource.
                    RptDetailedStudentActivity_Page_TotalDivCount_Xpath_Locator);
                for (int rowCount = 0; rowCount < totalDivCount; rowCount++)
                {
                    //Click The Expand Link
                    this.ClickTheExpandLink(rowCount);
                    if (base.IsElementPresent(By.XPath(string.Format(
                        RptDetailedStudentActivityPageResource.
                        RptDetailedStudentActivity_Page_Report_Table_Score_Xpath_Locator, rowCount))))
                    {
                        getActivityScore = base.GetElementTextByXPath(string.Format(
                            RptDetailedStudentActivityPageResource.
                            RptDetailedStudentActivity_Page_Report_Score_Xpath_Locator,rowCount));
                        break;
                    }
                }
                getActivityScore = getActivityScore.TrimEnd
                    (Convert.ToChar(RptDetailedStudentActivityPageResource.
                    RptDetailedStudentActivity_Page_Studyplan_Score_Symbol));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptDetailedStudentActivityPage",
                "VerifyTheGradeDisplayed",
                base.IsTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Click The Expand Link.
        /// </summary>
        /// <param name="rowCount">This is RowCount.</param>
        public void ClickTheExpandLink(int rowCount)
        {
            //Click The Expand Link
            logger.LogMethodEntry("RptDetailedStudentActivityPage",
                 "VerifyTheGradeDisplayed",
                 base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(string.Format(RptDetailedStudentActivityPageResource.
                RptDetailedStudentActivity_Page_ExpandColaps_Id_Locator, rowCount)));
            IWebElement getExpandLink = base.
                GetWebElementPropertiesById(string.Format(RptDetailedStudentActivityPageResource.
                RptDetailedStudentActivity_Page_ExpandColaps_Id_Locator, rowCount));
            //Click the Expandbutton
            base.ClickByJavaScriptExecutor(getExpandLink);
            Thread.Sleep(Convert.ToInt32(RptStudentActivityPageResource.
                RptStudentActivity_Page_SelectDetail_link_TimeValue));            
            logger.LogMethodExit("RptDetailedStudentActivityPage",
               "VerifyTheGradeDisplayed",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Detailed Student Activity Close Button
        /// </summary>
        public void DetailedStudentActivityCloseButton()
        {
            //Detailed Student Activity Close Button
            logger.LogMethodEntry("RptDetailedStudentActivityPage",
                "DetailedStudentActivityCloseButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.ClassName(RptDetailedStudentActivityPageResource.
                    RptDetailedStudentActivity_Page_CloseButton_ClassName));
                base.FocusOnElementByClassName(RptDetailedStudentActivityPageResource.
                    RptDetailedStudentActivity_Page_CloseButton_ClassName);
                //Get web element
                IWebElement getCloseButton = base.
                    GetWebElementPropertiesByClassName(RptDetailedStudentActivityPageResource.
                    RptDetailedStudentActivity_Page_CloseButton_ClassName);
                //Click the "Close" button
                base.ClickByJavaScriptExecutor(getCloseButton);
                Thread.Sleep(Convert.ToInt32(RptStudentActivityPageResource.
                    RptStudentActivity_Page_SelectDetail_link_TimeValue));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptDetailedStudentActivityPage",
               "DetailedStudentActivityCloseButton",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close Report Button In Organization Admin
        /// </summary>
        public void CloseReportButtonInOrganizationAdmin()
        {
            //Close Report Button In Organization Admin
            logger.LogMethodEntry("RptDetailedStudentActivityPage",
                "CloseReportButtonInOrganizationAdmin",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the close buton element
                base.WaitForElement(By.ClassName(RptDetailedStudentActivityPageResource.
                    RptDetailedStudentActivity_Page_CloseButton_Report_ClassName));
                base.FocusOnElementByClassName(RptDetailedStudentActivityPageResource.
                    RptDetailedStudentActivity_Page_CloseButton_Report_ClassName);
                //Get web element
                IWebElement getCloseBtnProperty = base.GetWebElementPropertiesByClassName
                    (RptDetailedStudentActivityPageResource.
                    RptDetailedStudentActivity_Page_CloseButton_Report_ClassName);
                //Click on the close button
                base.ClickByJavaScriptExecutor(getCloseBtnProperty);
                Thread.Sleep(Convert.ToInt32(RptStudentActivityPageResource.
                        RptStudentActivity_Page_SelectDetail_link_TimeValue));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptDetailedStudentActivityPage",
               "CloseReportButtonInOrganizationAdmin",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the data in generated detailed student activity report.
        /// </summary>
        /// <param name="columnName">Column name in generated report.</param>
        /// <returns>Boolean value based on the data existance.</returns>
        public bool GetStudentDataFromDetailedStudentActivityReport(string columnName)
        {
            logger.LogMethodEntry("RptDetailedStudentActivityPage",
                "GetStudentDataFromDetailedStudentActivityReport",
                base.IsTakeScreenShotDuringEntryExit);
            bool isDataExists = false;
            string getColumnData = null;
            try
            {


                base.WaitForElement(By.XPath(RptDetailedStudentActivityPageResource.
                    RptDetailedStudentActivity_Page_ReportTable_Xpath_Locator));
                switch (columnName)
                {
                    case "Date":
                        getColumnData = base.GetElementTextByXPath(RptDetailedStudentActivityPageResource.
                            RptDetailedStudentActivity_Page_DateColumnData_Xpath_Locator);
                        if (getColumnData.Equals("--"))
                        {
                            isDataExists = false;
                        }
                        else
                        {
                            isDataExists = true;
                        }
                        break;
                    case "Sign On":
                        getColumnData = base.GetElementTextByXPath(RptDetailedStudentActivityPageResource.
                            RptDetailedStudentActivity_Page_SignOnColumnData_Xpath_Locator);
                        if (getColumnData.Equals("--"))
                        {
                            isDataExists = false;
                        }
                        else
                        {
                            isDataExists = true;
                        }
                        break;
                    case "Sign Off":
                        getColumnData = base.GetElementTextByXPath(RptDetailedStudentActivityPageResource.
                            RptDetailedStudentActivity_Page_SignOffColumnData_Xpath_Locator);
                        if (getColumnData.Equals("--"))
                        {
                            isDataExists = false;
                        }
                        else
                        {
                            isDataExists = true;
                        }
                        break;
                    case "Session Duration":
                        getColumnData = base.GetElementTextByXPath(RptDetailedStudentActivityPageResource.
                            RptDetailedStudentActivity_Page_SessionDurationColumnData_Xpath_Locator);
                        if (getColumnData.Equals("--"))
                        {
                            isDataExists = false;
                        }
                        else
                        {
                            isDataExists = true;
                        }
                        break;
                    case "Activity":
                        getColumnData = base.GetElementTextByXPath(RptDetailedStudentActivityPageResource.
                            RptDetailedStudentActivity_Page_ActivityColumnData_Xpath_Locator);
                        if (getColumnData.Equals("--"))
                        {
                            isDataExists = false;
                        }
                        else
                        {
                            isDataExists = true;
                        }
                        break;
                    case "Time":
                        getColumnData = base.GetElementTextByXPath(RptDetailedStudentActivityPageResource.
                            RptDetailedStudentActivity_Page_TimeColumnData_Xpath_Locator);
                        if (getColumnData.Equals("--"))
                        {
                            isDataExists = false;
                        }
                        else
                        {
                            isDataExists = true;
                        }
                        break;
                    case "Start Time":
                        getColumnData = base.GetElementTextByXPath(RptDetailedStudentActivityPageResource.
                            RptDetailedStudentActivity_Page_StartTimeColumnData_Xpath_Locator);
                        if (getColumnData.Equals("--"))
                        {
                            isDataExists = false;
                        }
                        else
                        {
                            isDataExists = true;
                        }
                        break;
                    case "End Time":
                        getColumnData = base.GetElementTextByXPath(RptDetailedStudentActivityPageResource.
                            RptDetailedStudentActivity_Page_EndTimeColumnData_Xpath_Locator);
                        if (getColumnData.Equals("--"))
                        {
                            isDataExists = false;
                        }
                        else
                        {
                            isDataExists = true;
                        }
                        break;
                    case "Activity Status":
                        getColumnData = base.GetElementTextByXPath(RptDetailedStudentActivityPageResource.
                            RptDetailedStudentActivity_Page_ActivityStatusColumnData_Xpath_Locator);
                        if (getColumnData.Equals("--"))
                        {
                            isDataExists = false;
                        }
                        else
                        {
                            isDataExists = true;
                        }
                        break;
                    case "Score":
                        getColumnData = base.GetElementTextByXPath(RptDetailedStudentActivityPageResource.
                            RptDetailedStudentActivity_Page_ScoreColumnData_Xpath_Locator);
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
            logger.LogMethodExit("RptDetailedStudentActivityPage",
               "GetStudentDataFromDetailedStudentActivityReport",
               base.IsTakeScreenShotDuringEntryExit);
            return isDataExists;
        }
    }
}
