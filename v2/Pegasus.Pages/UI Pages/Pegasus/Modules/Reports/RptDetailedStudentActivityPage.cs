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
                 base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            return getActivityScore;
        }

        /// <summary>
        /// Click The Expand Link.
        /// </summary>
        /// <param name="rowCount">This is RowCount.</param>
        private void ClickTheExpandLink(int rowCount)
        {
            //Click The Expand Link
            logger.LogMethodEntry("RptDetailedStudentActivityPage",
                 "VerifyTheGradeDisplayed",
                 base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Detailed Student Activity Close Button
        /// </summary>
        public void DetailedStudentActivityCloseButton()
        {
            //Detailed Student Activity Close Button
            logger.LogMethodEntry("RptDetailedStudentActivityPage",
                "DetailedStudentActivityCloseButton",
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close Report Button In Organization Admin
        /// </summary>
        public void CloseReportButtonInOrganizationAdmin()
        {
            //Close Report Button In Organization Admin
            logger.LogMethodEntry("RptDetailedStudentActivityPage",
                "CloseReportButtonInOrganizationAdmin",
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
