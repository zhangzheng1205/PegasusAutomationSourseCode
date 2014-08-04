using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Student activity report Actions
    /// </summary>    
    public class RptPadminCriteriaPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptPadminCriteriaPage));
        
        /// <summary>
        /// Select Add Class
        /// </summary>
        /// <param name="userType">This is user type</param>
        public void SelectAddClass(string userType)
        {
            //Select Add Class
           logger.LogMethodEntry("RptPadminCriteriaPage", "SelectAddClass",
            base.IsTakeScreenShotDuringEntryExit);
           try
           {
               //Select Manage organization Frame
               this.SelectManageorganizationFrame();               
               //Wait for the class element
               base.WaitForElement(By.Id(RptPadminCriteriaPageResource.
                   RptPadminCriteria_Page_Class_Id_Locator));
               base.FocusOnElementById(RptPadminCriteriaPageResource.
                   RptPadminCriteria_Page_Class_Id_Locator);
               //Click the class checkbox
               base.SelectCheckBoxById(RptPadminCriteriaPageResource.
                   RptPadminCriteria_Page_Class_Id_Locator);
               //Wait for the select students
               base.WaitForElement(By.Id(RptPadminCriteriaPageResource.
                   RptPadminCriteria_Page_Select_AllStudent__Button_Id_Locator));
               IWebElement getSelectStudentbutton=base.GetWebElementPropertiesById
                   (RptPadminCriteriaPageResource.
                   RptPadminCriteria_Page_Select_AllStudent__Button_Id_Locator);
               //click on the select student button
               base.ClickByJavaScriptExecutor(getSelectStudentbutton);
               //Select Students Window
               this.SelectStudentsWindow();             
               //Select The Student To View Report
               this.SelectStudentsToViewTheReport(userType);
               //Select Manage organization Frame
               this.SelectManageorganizationFrame();
               //Click the RunReport
               this.ClickRunReportInAdmin();              
           }
           catch (Exception e)
           {
               ExceptionHandler.HandleException(e);
           }
          logger.LogMethodExit("RptPadminCriteriaPage", "SelectAddClass",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Students Window
        /// </summary>
        private void SelectStudentsWindow()
        {
            // Select Students Window
            logger.LogMethodEntry("RptPadminCriteriaPage", "SelectStudentsWindow",
            base.IsTakeScreenShotDuringEntryExit);
            //Select the Select Students window
            base.WaitUntilWindowLoads(RptPadminCriteriaPageResource.
                RptPadminCriteria_Page_SelectStudent_Window_Name);
            base.SelectWindow(RptPadminCriteriaPageResource.
                RptPadminCriteria_Page_SelectStudent_Window_Name);
            //Wait for the search button
            base.WaitForElement(By.Id(RptPadminCriteriaPageResource.
                RptPadminCriteria_Page_SelectStudent_Search_Button_Id_Locator));
            IWebElement getSerachButton = base.GetWebElementPropertiesById
                (RptPadminCriteriaPageResource.
                RptPadminCriteria_Page_SelectStudent_Search_Button_Id_Locator);
            //Click the Search button
            base.ClickByJavaScriptExecutor(getSerachButton);
            Thread.Sleep(Convert.ToInt32(RptPadminCriteriaPageResource.
                RptPadminCriteria_Page_SelectStudent_TimeValue));
            logger.LogMethodExit("RptPadminCriteriaPage", "SelectStudentsWindow",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Click Run Report In Admin
        /// </summary>
        private void ClickRunReportInAdmin()
        {
            // Click Run Report In Admin
            logger.LogMethodEntry("RptPadminCriteriaPage", "ClickRunReportInAdmin",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(RptPadminCriteriaPageResource.
                   RptPadminCriteria_Page_PageSelect_RedioButton_Id_Locator));
            base.FocusOnElementById(RptPadminCriteriaPageResource.
                RptPadminCriteria_Page_PageSelect_RedioButton_Id_Locator);
            //Wait for the runreport element          
            base.WaitForElement(By.Id(RptPadminCriteriaPageResource.
                RptPadminCriteria_Page_RunReport_Id_Locator));
            base.FocusOnElementById(RptPadminCriteriaPageResource.
                RptPadminCriteria_Page_RunReport_Id_Locator);
            IWebElement getRunReport = base.GetWebElementPropertiesById
                (RptPadminCriteriaPageResource.
                RptPadminCriteria_Page_RunReport_Id_Locator);
            //Click the runreport button
            base.ClickByJavaScriptExecutor(getRunReport);
            logger.LogMethodExit("RptPadminCriteriaPage", "ClickRunReportInAdmin",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Manage organization Frame
        /// </summary>
        private void SelectManageorganizationFrame()
        {
            // Select Manage organization Frame
            logger.LogMethodEntry("RptPadminCriteriaPage", "SelectManageorganizationFrame",
            base.IsTakeScreenShotDuringEntryExit);
            //Select the window
            base.SelectWindow(RptMainUXPageResource.
                RptMain_Page_ManageOrg_Window_Name);
            //Select the frames
            base.SwitchToIFrame(RptMainUXPageResource.
                RptMain_Page_ManageOrg_Window_Frame_Name);
            logger.LogMethodExit("RptPadminCriteriaPage", "SelectManageorganizationFrame",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Student To View Report
        /// </summary>
        /// <param name="userType">This is user type</param>
        private void SelectStudentsToViewTheReport(string userType)
        {
            //Select The Student To View Report
            logger.LogMethodEntry("RptPadminCriteriaPage", "SelectStudentsToViewTheReport",
            base.IsTakeScreenShotDuringEntryExit);
            //Get Count of students
            int getStudentCount = base.GetElementCountByXPath
                (RptPadminCriteriaPageResource.RptPadminCriteria_Page_Student_Count_Xpath_Locator);
            for (int rowCount = 1; rowCount <= getStudentCount; rowCount++)
            {
                //Get Student Name
                string getStudentName = base.GetElementTextByXPath
                    (string.Format(RptPadminCriteriaPageResource.
                    RptPadminCriteria_Page_Student_Name_Xpath_Locator, rowCount));
                if (getStudentName.Contains(userType))
                {
                    base.WaitForElement(By.XPath(string.Format(RptPadminCriteriaPageResource.
                        RptPadminCriteria_Page_Select_Student_Checkbox_Xpath_Locator, rowCount)));
                    base.FocusOnElementByXPath(string.Format(RptPadminCriteriaPageResource.
                        RptPadminCriteria_Page_Select_Student_Checkbox_Xpath_Locator, rowCount));
                    //Click on Student checkbox Button
                    base.ClickButtonByXPath(string.Format(RptPadminCriteriaPageResource.
                        RptPadminCriteria_Page_Select_Student_Checkbox_Xpath_Locator, rowCount));
                    break;
                }
            }
            //Click On Add Close Button
            this.ClickOnAddCloseButton();           
            logger.LogMethodExit("RptPadminCriteriaPage", "SelectStudentsToViewTheReport",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click On Add Close Button 
        /// </summary>
        private void ClickOnAddCloseButton()
        {
            //Click On Add Close Button
            logger.LogMethodEntry("RptPadminCriteriaPage", "ClickOnAddCloseButton",
            base.IsTakeScreenShotDuringEntryExit);
            //Wait for the add button
            base.WaitForElement(By.Id(RptPadminCriteriaPageResource.
                RptPadminCriteria_Page_Student_Add_Button_Id_Locator));
            IWebElement getAddButton = base.GetWebElementPropertiesById(RptPadminCriteriaPageResource.
                RptPadminCriteria_Page_Student_Add_Button_Id_Locator);
            //Click the Add button
            base.ClickByJavaScriptExecutor(getAddButton);
            //Wait for the Add And Close button
            base.WaitForElement(By.Id(RptPadminCriteriaPageResource.
                RptPadminCriteria_Page_Student_AddClose_Button_Id_Locator));
            IWebElement getAddCloseButton = base.GetWebElementPropertiesById(RptPadminCriteriaPageResource.
                RptPadminCriteria_Page_Student_AddClose_Button_Id_Locator);
            //Click the Add And Close button
            base.ClickByJavaScriptExecutor(getAddCloseButton);
            logger.LogMethodExit("RptPadminCriteriaPage", "ClickOnAddCloseButton",
          base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
