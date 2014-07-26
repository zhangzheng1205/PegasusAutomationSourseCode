using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Users;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus RptSaveReport Page Actions
    /// The class name is bad because as in Pegasus
    /// </summary>
    public class RptSaveReportPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptSaveReportPage));

        /// <summary>
        /// This is the enum available for Section Status RadioButtons.
        /// </summary>
        public enum SectionStatusRadioButtonTypeEnum
        {
            /// <summary>
            /// Inactive Status RadioButton
            /// </summary>
            Inactive = 1,
            /// <summary>
            /// All Statuses RadioButton
            /// </summary>
            AllStatuses = 2
        }
      
        /// <summary>
        /// Click on the Select Students button.
        /// </summary>
        public void ClickOnSelectStudentButton()
        {
            //Click on Select Students Button
            logger.LogMethodEntry("RptSaveReportPage", "ClickOnSelectStudentButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window And Frame
                this.SelectWindowAndFrame();
                // Click SelectStudents button
                base.WaitForElement(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_SelectStudents_Button_Id_Locator));
                //Click on Button
                base.ClickButtonById(RptSaveReportPageResource.
                    RptSaveReport_Page_SelectStudents_Button_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "ClickOnSelectStudentButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Select Sections button.
        /// </summary>
        public void SelectSectionToGenerateReport()
        {
            //Click on the Select Sections Button
            logger.LogMethodEntry("RptSaveReportPage", "SelectSectionToGenerateReport",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window And Frame
                this.SelectWindowAndFrame();
                // Click SelectSections button
                base.WaitForElement(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_SelectSections_Button_Id_Locator));
                base.ClickButtonById(RptSaveReportPageResource.
                    RptSaveReport_Page_SelectSections_Button_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "SelectSectionToGenerateReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window And Frame.
        /// </summary>
        public void SelectWindowAndFrame()
        {
            //Select Window And Frame
            logger.LogMethodEntry("RptSaveReportPage", "SelectWindowAndFrame",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.SelectWindow(RptSaveReportPageResource
                    .RptSaveReport_Page_Window_Title);
                //Select top frame
                base.WaitForElement(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_Middle_Frame_Id_Locator));
                base.SwitchToIFrame(RptSaveReportPageResource.
                    RptSaveReport_Page_Middle_Frame_Id_Locator);
                //Select frame
                base.WaitForElement(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_Main_Frame_Id_Locator));
                base.SwitchToIFrame(RptSaveReportPageResource.
                    RptSaveReport_Page_Main_Frame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "SelectWindowAndFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the button In Reports.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        public void ClickOnButtonInReports(string buttonName)
        {
            //Click on the button In Reports
            logger.LogMethodEntry("RptSaveReportPage", "ClickOnButtonInReports",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Click Run Report button
                base.WaitForElement(By.PartialLinkText(buttonName));
                // Focus on RunReport_Button
                base.FocusOnElementByPartialLinkText((buttonName));
                //Click On Button
                IWebElement getButton = 
                    base.GetWebElementPropertiesByPartialLinkText(buttonName);
                base.ClickByJavaScriptExecutor(getButton);
                Thread.Sleep(Convert.ToInt32(RptSaveReportPageResource
                .RptSaveReport_Page_ThreadTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "ClickOnButtonInReports",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Section Status Radio Button.
        /// </summary>
        /// <param name="statusRadioButtonName">
        /// This is Section Status RadioButton Name.</param>
        public void SelectSectionStatusRadioButton(
            SectionStatusRadioButtonTypeEnum SectionStatusRadioButtonTypeEnum)
        {
            //Select Section Status Radio Button
            logger.LogMethodEntry("RptSaveReportPage", "SelectSectionStatusRadioButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (SectionStatusRadioButtonTypeEnum)
                {
                    case SectionStatusRadioButtonTypeEnum.Inactive:
                        //Select Inactive RadioButton
                        this.SelectInactiveRadioButton();
                        break;
                    case SectionStatusRadioButtonTypeEnum.AllStatuses:
                        //Select All Statuses RadioButton
                        this.SelectAllStatusesRadioButton();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "SelectSectionStatusRadioButton",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select AllStatuses RadioButton.
        /// </summary>
        private void SelectAllStatusesRadioButton()
        {
            //Select AllStatuses RadioButton
            logger.LogMethodEntry("RptSaveReportPage", "SelectAllStatusesRadioButton",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window And Frame
            this.SelectWindowAndFrame();
            //Wait For 'AllStatuses' RadioButton
            base.WaitForElement(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_AllStatuses_RadioButton_Id_Locator));
            //Select 'AllStatuses' RadioButton
            base.SelectRadioButtonById(RptSaveReportPageResource.
                RptSaveReport_Page_AllStatuses_RadioButton_Id_Locator);
            logger.LogMethodExit("RptSaveReportPage", "SelectAllStatusesRadioButton",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Inactive RadioButton.
        /// </summary>
        private void SelectInactiveRadioButton()
        {
            //Select Inactive RadioButton
            logger.LogMethodEntry("RptSaveReportPage", "SelectInactiveRadioButton",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window And Frame
            this.SelectWindowAndFrame();
            //Wait For 'Inactive' RadioButton
            base.WaitForElement(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_Inactive_RadioButton_Id_Locator));
            //Select 'Inactive' RadioButton
            base.SelectRadioButtonById(RptSaveReportPageResource.
                RptSaveReport_Page_Inactive_RadioButton_Id_Locator);
            logger.LogMethodExit("RptSaveReportPage", "SelectInactiveRadioButton",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Save Settings To My Reports Checkbox.
        /// </summary>
        public void SelectSaveSettingsToMyReportsCheckbox()
        {
            //Select Save Settings To My Reports Checkbox
            logger.LogMethodEntry("RptSaveReportPage", "SelectSaveSettingsToMyReportsCheckbox",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window And Frame
                this.SelectWindowAndFrame();
                base.WaitForElement(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_SaveSettingsToMyReports_Checkbox_Id_Locator));
                //Select 'save settings to My Reports' Checkbox
                base.SelectCheckBoxById(RptSaveReportPageResource.
                    RptSaveReport_Page_SaveSettingsToMyReports_Checkbox_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "SelectSaveSettingsToMyReportsCheckbox",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Save Settings To My Reports Checkbox.
        /// </summary>
        public void SelectSaveSettingsToMyReportsOption()
        {
            //Select Save Settings To My Reports Checkbox
            logger.LogMethodEntry("RptSaveReportPage", "SelectSaveSettingsToMyReportsOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_SaveSettingsToMyReports_Option_Id_Locator));
                //Select 'save settings to My Reports' Checkbox
                base.SelectCheckBoxById(RptSaveReportPageResource.
                    RptSaveReport_Page_SaveSettingsToMyReports_Option_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "SelectSaveSettingsToMyReportsOption",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Section Options Fields.
        /// </summary>
        /// <returns>Section Options Frame Fields Text.</returns>
        public String GetSectionOptionsFields()
        {
            //Get Section Options Fields
            logger.LogMethodEntry("RptSaveReportPage", "GetSectionOptionsFields",
                 base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAllFieldsText = string.Empty;
            try
            {
                //Select Window
                this.SelectWindowAndFrame();
                //Get All Section Options Fields
                getAllFieldsText = GetAllSectionOptionsFields();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "GetSectionOptionsFields",
                  base.isTakeScreenShotDuringEntryExit);
            return getAllFieldsText;
        }

        /// <summary>
        /// Get All Section Options Fields.
        /// </summary>       
        /// <returns>Section Options Fields.</returns>
        private string GetAllSectionOptionsFields()
        {
            //Get Section Options Fields
            logger.LogMethodEntry("RptSaveReportPage", "GetAllSectionOptionsFields",
                 base.isTakeScreenShotDuringEntryExit);
            string getAllFieldsText = string.Empty;
            //Get Select Sections Text
            string getSelectSectionsText = base.GetElementTextById(RptSaveReportPageResource.
                RptSaveReport_Page_SelectSections_Button_Id_Locator);
            //Get Active Radiobutton Text
            string getActiveRadiobuttonText = base.GetElementTextById(RptSaveReportPageResource.
                RptSaveReport_Page_Active_Text_Id_Locator);
            //Get Inactive Radiobutton Text
            string getInActiveRadiobuttonText = base.GetElementTextById(RptSaveReportPageResource.
                RptSaveReport_Page_Inactive_Text_Id_Locator);
            //Get AllStatuses Radiobutton Text
            string getAllStatusRadiobuttonText = base.GetElementTextById(RptSaveReportPageResource.
                RptSaveReport_Page_AllStatuses_Text_Id_Locator);
            //Get Show All Link Text
            string getShowAllLinkText = base.GetElementTextById(RptSaveReportPageResource.
                RptSaveReport_Page_ShowCollapse_Link_Id_Locator);
            //Click On Show All Link
            base.ClickLinkById(RptSaveReportPageResource.
                RptSaveReport_Page_ShowCollapse_Link_Id_Locator);
            //Get Collapse Link Text
            string getCollapseLinkText = base.GetElementTextById(RptSaveReportPageResource.
                RptSaveReport_Page_ShowCollapse_Link_Id_Locator);
            //Get Placeholder Textbox Text
            string getPlaceHolderTextboxText = GetValueAttributeByXPath(RptSaveReportPageResource.
                RptSaveReport_Page_PlaceHolder_Textbox_Xpath_Locator);
            //Get Section Options Fields Text
            getAllFieldsText = getSelectSectionsText + getActiveRadiobuttonText
                + getInActiveRadiobuttonText + getAllStatusRadiobuttonText
                + getShowAllLinkText + getCollapseLinkText + getPlaceHolderTextboxText;
            logger.LogMethodExit("RptSaveReportPage", "GetAllSectionOptionsFields",
                 base.isTakeScreenShotDuringEntryExit);
            return getAllFieldsText;            
        }

        /// <summary>
        /// Check Student Options Fields Present.
        /// </summary>
        /// <returns>Status Of Student Options Frame Fields.</returns>
        public bool IsStudentOptionsFieldsPresent()
        {
            //Check Student Options Fields Present
            logger.LogMethodEntry("RptSaveReportPage", "IsStudentOptionsFieldsPresent",
                 base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isAllStudentOptionsFieldsPresent = false;
            try
            {
                //Select Window
                this.SelectWindowAndFrame();
                //Check All Field is Student Options Present
                isAllStudentOptionsFieldsPresent = base.IsElementPresent(By.Id(
                    RptSaveReportPageResource.
                    RptSaveReport_Page_SelectStudents_Button_Id_Locator)) &&
                    base.IsElementPresent(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_Textbox_StudentOptions_Id_Locator));                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "IsStudentOptionsFieldsPresent",
                  base.isTakeScreenShotDuringEntryExit);
            return isAllStudentOptionsFieldsPresent;
        }

        /// <summary>
        /// Check Date Options Fields Present.
        /// </summary>
        /// <returns>Status Of Date Options Frame Fields.</returns>
        public bool IsDateOptionsFieldsPresent()
        {
            //Check Date Options Fields Present
            logger.LogMethodEntry("RptSaveReportPage", "IsDateOptionsFieldsPresent",
                 base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isAllDateOptionsFieldsPresent = false;
            try
            {
                //Select Window
                this.SelectWindowAndFrame();
                //Check All Fields In Date Options Frame Present
                isAllDateOptionsFieldsPresent =
                    base.IsElementPresent(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_AllDates_Radiobutton_Id_Locator)) &&
                base.IsElementPresent(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_FromDate_Radiobutton_Id_Locator)) &&
                base.IsElementPresent(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_FromDate_Textbox_Id_Locator)) &&
                base.IsElementPresent(By.ClassName(RptSaveReportPageResource.
                RptSaveReport_Page_Calendar_Image_Classname_Locator)) &&
                base.IsElementPresent(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_ToDate_Textbox_Id_Locator));                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "IsDateOptionsFieldsPresent",
                  base.isTakeScreenShotDuringEntryExit);
            return isAllDateOptionsFieldsPresent;
        }

        /// <summary>
        /// Check Paging Options Fields Present.
        /// </summary>
        /// <returns>Status Of Paging Options Frame Fields.</returns>
        public bool IsPagingOptionsFieldsPresent()
        {
            //Check Paging Options Fields Present
            logger.LogMethodEntry("RptSaveReportPage", "IsPagingOptionsFieldsPresent",
                 base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isAllPagingOptionsFieldsPresent = false;
            try
            {
                //Select Window
                this.SelectWindowAndFrame();
                //Check All Fields In Paging Options Frame Present
                isAllPagingOptionsFieldsPresent =
                    base.IsElementPresent(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_ResultsPerPage_Id_Locator)) &&
                base.IsElementPresent(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_AllResults_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "IsPagingOptionsFieldsPresent",
                  base.isTakeScreenShotDuringEntryExit);
            return isAllPagingOptionsFieldsPresent;
        }

        /// <summary>
        /// Select Activities.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SelectActivities(string activityName)
        {
            //Select Activities
            logger.LogMethodEntry("RptSaveReportPage", "SelectActivities",
                 base.isTakeScreenShotDuringEntryExit);            
            try
            {                
                //Select Window And Frame
                this.SelectWindowAndFrame();
                //Click On Select Activity Button
                this.ClickOnSelectActivityButton();
                base.WaitForElement(By.XPath(RptSaveReportPageResource.
                    RptSaveReport_Page_Activity_Count_Xpath_Locator));
                //Get Activity Count
                int getActivityCount = base.GetElementCountByXPath(RptSaveReportPageResource.
                    RptSaveReport_Page_Activity_Count_Xpath_Locator);
                for (int rowCount = Convert.ToInt32(RptSaveReportPageResource.
                    RptSaveReport_Page_Loop_Initializer_Value);
                    rowCount <= getActivityCount; rowCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(
                        RptSaveReportPageResource.
                        RptSaveReport_Page_Activity_Name_Xpath_Locator, rowCount)));
                    //Get Activity Name
                    string getActivityName = base.GetElementTextByXPath(string.Format(
                        RptSaveReportPageResource.
                        RptSaveReport_Page_Activity_Name_Xpath_Locator, rowCount));
                    if (getActivityName == activityName)
                    {
                        base.WaitForElement(By.XPath(string.Format(RptSaveReportPageResource.
                            RptSaveReport_Page_Activity_Checkbox_Xpath_Locator, rowCount)));
                        //Select Checkbox
                        base.SelectCheckBoxByXPath(string.Format(RptSaveReportPageResource.
                            RptSaveReport_Page_Activity_Checkbox_Xpath_Locator, rowCount));
                        break;
                    }
                }
                //Click On Add Button
                this.ClickOnAddButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "SelectActivities",
                  base.isTakeScreenShotDuringEntryExit);            
        }

        /// <summary>
        /// Click On Select Activity Button.
        /// </summary>
        private void ClickOnSelectActivityButton()
        {
            //Click On Select Activity Button
            logger.LogMethodEntry("RptSaveReportPage", "ClickOnSelectActivityButton",
                 base.isTakeScreenShotDuringEntryExit);          
            base.WaitForElement(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_Select_Activities_Button_Id_Locator));
            //Click On 'Select Activities' Button
            base.ClickButtonById(RptSaveReportPageResource.
                RptSaveReport_Page_Select_Activities_Button_Id_Locator);
            //Wait For Window
            base.WaitUntilWindowLoads(RptSelectAssessmentsResource.
                   RptSelectAssessments_Page_Ins_SelectActivities_Window_Title_Name);
            base.SelectWindow(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_SelectActivities_Window_Title_Name);
            logger.LogMethodExit("RptSaveReportPage", "ClickOnSelectActivityButton",
                  base.isTakeScreenShotDuringEntryExit);       
        }

        /// <summary>
        /// Click On Add Button.
        /// </summary>
        private void ClickOnAddButton()
        {
            //Click On Add Button
            logger.LogMethodEntry("RptSaveReportPage", "ClickOnAddButton",
                 base.isTakeScreenShotDuringEntryExit);       
            base.WaitForElement(By.PartialLinkText(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_Add_Link_Locator));
            //Click on Add Button
            base.ClickButtonByPartialLinkText(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_Add_Link_Locator);
            base.IsPopUpClosed(Convert.ToInt32(RptSelectAssessmentsResource.
               RptSelectAssessments_Page_Ins_Window_Count));
            logger.LogMethodExit("RptSaveReportPage", "ClickOnAddButton",
                  base.isTakeScreenShotDuringEntryExit);    
        }

        /// <summary>
        /// Select Date.
        /// </summary>
        public void SelectDate()
        {
            //Select Date
            logger.LogMethodEntry("RptSaveReportPage", "SelectDate",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get Date
                string date = DateTime.Now.ToString(RptSaveReportPageResource.
                    RptSaveReport_Page_Date_Format_Value);
                base.WaitForElement(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_Date_Radiobutton_Id_Locator));
                //Select Date Radiobutton
                base.SelectRadioButtonById(RptSaveReportPageResource.
                    RptSaveReport_Page_Date_Radiobutton_Id_Locator);
                //Enter From and To Date
                this.EnterFromToDate(date);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "SelectDate",
                  base.isTakeScreenShotDuringEntryExit);            
        }

        /// <summary>
        /// Enter From and To Date.
        /// </summary>
        /// <param name="date">This is Current Date.</param>
        private void EnterFromToDate(string date)
        {
            //Enter From and To Date
            logger.LogMethodEntry("RptSaveReportPage", "EnterFromToDate",
                 base.isTakeScreenShotDuringEntryExit);
            //Enter From Date
            base.WaitForElement(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_FromDate_Textbox_Id_Locator));
            base.FillTextBoxById(RptSaveReportPageResource.
                RptSaveReport_Page_FromDate_Textbox_Id_Locator, date);
            //Enter To Date
            base.WaitForElement(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_ToDate_Textbox_Id_Locator));
            base.FillTextBoxById(RptSaveReportPageResource.
                RptSaveReport_Page_ToDate_Textbox_Id_Locator, date);
            logger.LogMethodExit("RptSaveReportPage", "EnterFromToDate",
                  base.isTakeScreenShotDuringEntryExit);       
        }

        /// <summary>
        /// Create Study Plan Report.
        /// </summary>
        public void CreateStudyPlanReport()
        {
            //Create Study Plan Report
            logger.LogMethodEntry("RptSaveReportPage", "CreateStudyPlanReport",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Report Window and Frame
                this.SelectReportWindowAndFrame();
                //Select Student In Report
                this.SelectStudentInReport();
                //Select Sim Study Plan In Report
                this.SelectSimStudyPlanInReport();
                //Select Date In Report
                this.SelectDateInReport();
                //Select Report Window and Frame
                this.SelectReportWindowAndFrame();
                base.WaitForElement(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_SaveSettings_Checkbox_Id_Locator));
                //Select 'save settings to My Reports' Checkbox
                base.SelectCheckBoxById(RptSaveReportPageResource.
                    RptSaveReport_Page_SaveSettings_Checkbox_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "CreateStudyPlanReport",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Date In Report.
        /// </summary>
        private void SelectDateInReport()
        {
            //Select Date In Report
            logger.LogMethodEntry("RptSaveReportPage", "SelectDateInReport",
                 base.isTakeScreenShotDuringEntryExit);
            //Get Date
            string date = DateTime.Now.ToString(RptSaveReportPageResource.
                RptSaveReport_Page_Date_Format_Value);
            //Select Report Window and Frame
            this.SelectReportWindowAndFrame();
            base.WaitForElement(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_DateRadioButton_Id_Locator));
            //Select Date Radiobutton
            base.SelectRadioButtonById(RptSaveReportPageResource.
                RptSaveReport_Page_DateRadioButton_Id_Locator);
            this.EnterFromToDate(date);
            logger.LogMethodExit("RptSaveReportPage", "SelectDateInReport",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Sim Study Plan In Report.
        /// </summary>
        private void SelectSimStudyPlanInReport()
        {
            //Select Sim Study Plan In Report
            logger.LogMethodEntry("RptSaveReportPage", "SelectSimStudyPlanInReport",
               base.isTakeScreenShotDuringEntryExit);
            //Click On 'Select Sim Study Plan' Button
            this.ClickOnSelectSimStudyPlanButton();
            //Select 'Sim Study Plan' Window
            this.SelectSimStudyPlanWindow();
            //Get Activity
            Activity activity = Activity.Get(Activity.ActivityTypeEnum.SIM5StudyPlan,
                Activity.ActivityBehavioralModesEnum.SkillBased);                
            //Get Count of Total StudyPlan
            base.WaitForElement(By.XPath(RptSaveReportPageResource.
                RptSaveReport_Page_StudyPlan_Count_Xpath_Locator));
            //Get Total StudyPlan Count
            int getStudyPlanCount = base.GetElementCountByXPath(RptSaveReportPageResource.
                RptSaveReport_Page_StudyPlan_Count_Xpath_Locator);
            // To select checkbox for required StudyPlan
            for (int initialCount = Convert.ToInt32(RptSaveReportPageResource.
                RptSaveReport_Page_Loop_Initializer_Value);
                initialCount <= getStudyPlanCount; initialCount++)
            {
                //Get text of StudyPlan
                string getStudyPlanTextValue = base.GetElementTextByXPath(string.Format(
                    RptSaveReportPageResource.
                    RptSaveReport_Page_StudyPlan_Text_Value, initialCount));
                if (getStudyPlanTextValue.Contains(activity.Name))
                {
                    base.WaitForElement(By.XPath(string.Format(RptSaveReportPageResource.
                        RptSaveReport_Page_StudyPlan_RadioButton_Xpath_Locator, initialCount)));
                    //Click on Radiobutton of the StudyPlan Name
                    base.SelectRadioButtonByXPath(string.Format(RptSaveReportPageResource.
                        RptSaveReport_Page_StudyPlan_RadioButton_Xpath_Locator, initialCount));
                    //Click on Add Button In Select Activity Window
                    this.ClickonAddButtonInSelectActivityWindow();                    
                    base.IsPopUpClosed(Convert.ToInt32(RptSelectStudentsResource.
               RptSelectStudents_Page_Ins_Window_Count));
                    break;
                }
            }
            logger.LogMethodExit("RptSaveReportPage", "SelectSimStudyPlanInReport",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Button In Select Activity Window.
        /// </summary>
        private void ClickonAddButtonInSelectActivityWindow()
        {
            //Click on Add Button In Select Activity Window
            logger.LogMethodEntry("RptSaveReportPage",
                "ClickonAddButtonInSelectActivityWindow",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(RptSaveReportPageResource.
              RptSaveReport_Page_StudyPlan_Add_Button_Id_Locator));
            IWebElement getAddButton=base.GetWebElementPropertiesById
                (RptSaveReportPageResource.
              RptSaveReport_Page_StudyPlan_Add_Button_Id_Locator);
            //Click On Add Button
            base.ClickByJavaScriptExecutor(getAddButton);
            logger.LogMethodExit("RptSaveReportPage",
                "ClickonAddButtonInSelectActivityWindow",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Select Sim StudyPlan Button.
        /// </summary>
        private void ClickOnSelectSimStudyPlanButton()
        {
            //Click On Select Sim StudyPlan Button
            logger.LogMethodEntry("RptSaveReportPage", "ClickOnSelectSimStudyPlanButton",
               base.isTakeScreenShotDuringEntryExit);
            //Select Report Window and Frame
            this.SelectReportWindowAndFrame();
            base.WaitForElement(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_SelectSimStudyPlan_Button_Id_Locator));
            //Click On 'Select Sim Study Plan' Button
            base.ClickButtonById(RptSaveReportPageResource.
                RptSaveReport_Page_SelectSimStudyPlan_Button_Id_Locator);
            logger.LogMethodExit("RptSaveReportPage", "ClickOnSelectSimStudyPlanButton",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Sim StudyPlan Window.
        /// </summary>
        private void SelectSimStudyPlanWindow()
        {
            //Select Sim StudyPlan Window
            logger.LogMethodEntry("RptSaveReportPage", "SelectSimStudyPlanWindow",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(RptSaveReportPageResource.
                RptSaveReport_Page_SimStudyPlan_Window);
            //Select 'Sim StudyPlan' Window
            base.SelectWindow(RptSaveReportPageResource.
                RptSaveReport_Page_SimStudyPlan_Window);
            logger.LogMethodExit("RptSaveReportPage", "SelectSimStudyPlanWindow",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student In Report.
        /// </summary>
        private void SelectStudentInReport()
        {
            //Select Student In Report
            logger.LogMethodEntry("RptSaveReportPage", "SelectStudentInReport",
               base.isTakeScreenShotDuringEntryExit);
            //Select Student Button In Report
            this.SelectStudentButtonInReport();
            //Select 'Select Student' Window
            new RptSelectStudentsPage().SelectStudentWindow();
            //Get Count of Total Students
            base.WaitForElement(By.XPath(RptSaveReportPageResource.
                RptSaveReport_Page_StudentCount_Xpath_Locator));
            //Get Total Student Count
            int getStudentCount = base.GetElementCountByXPath(RptSaveReportPageResource.
                RptSaveReport_Page_StudentCount_Xpath_Locator);
            // To select checkbox for required student
            for (int initialCount = Convert.ToInt32(RptSaveReportPageResource.
                RptSaveReport_Page_LoopInitializer_Value);
                initialCount <= getStudentCount; initialCount++)
            {
                //Get text of student
                base.WaitForElement(By.XPath(string.Format(
                    RptSaveReportPageResource.
                    RptSaveReport_Page_StudentText_Xpath_Locator, initialCount)));
                string getStudentTextValue = base.GetElementTextByXPath(string.Format(
                    RptSaveReportPageResource.
                    RptSaveReport_Page_StudentText_Xpath_Locator, initialCount));
                if (getStudentTextValue.Contains(RptSaveReportPageResource.
                    RptSaveReport_Page_StudentName_Value))
                {
                    base.WaitForElement(By.XPath(string.Format(RptSaveReportPageResource.
                        RptSaveReport_Page_Student_Radiobutton_Xpath_Locator, initialCount)));
                    //Click on Radiobutton of the Student Name
                    base.SelectRadioButtonByXPath(string.Format(RptSaveReportPageResource.
                        RptSaveReport_Page_Student_Radiobutton_Xpath_Locator, initialCount));
                    break;
                }
            }
            //Click On Add Button
            new RptSelectStudentsPage().ClickOnAddButton();
            logger.LogMethodExit("RptSaveReportPage", "SelectStudentInReport",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Report Window And Frame.
        /// </summary>
        public void SelectReportWindowAndFrame()
        {
            //Select Report Window And Frame
            logger.LogMethodEntry("RptSaveReportPage", "SelectReportWindowAndFrame",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(RptSaveReportPageResource.
                        RptSaveReport_Page_Report_Window_Title);
                //Select Window
                base.SelectWindow(RptSaveReportPageResource.
                    RptSaveReport_Page_Report_Window_Title);
                //Select frame
                base.WaitForElement(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_Main_Frame_Id_Locator));
                base.SwitchToIFrame(RptSaveReportPageResource.
                    RptSaveReport_Page_Main_Frame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "SelectReportWindowAndFrame",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the button In Reports.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        public void ClickOnTheButtonInReports(string buttonName)
        {
            //Click on the button In Reports
            logger.LogMethodEntry("RptSaveReportPage", "ClickOnTheButtonInReports",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Report Window and Frame
                this.SelectReportWindowAndFrame();            
                base.WaitForElement(By.PartialLinkText(buttonName));
                // Focus on Element
                base.FocusOnElementByPartialLinkText((buttonName));
                //Click On Button
                IWebElement getButton =
                    base.GetWebElementPropertiesByPartialLinkText(buttonName);
                base.ClickByJavaScriptExecutor(getButton);
                Thread.Sleep(Convert.ToInt32(RptSaveReportPageResource
                .RptSaveReport_Page_ThreadTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "ClickOnTheButtonInReports",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Data In Fields To Generate Report.
        /// </summary>
        public void EnterDataInFieldsToGenerateReport()
        {
            //Enter Data In Fields To Generate Report
            logger.LogMethodEntry("RptSaveReportPage", "EnterDataInFieldsToGenerateReport",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on Select Training Button and Select Training
                this.ClickonSelectTrainingButtonandSelectTraining();
                //Close The Select Activity Add Button
                this.ClickonAddButtonInSelectActivityWindow();    
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "EnterDataInFieldsToGenerateReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Select Training Button and Select Training.
        /// </summary>
        private void ClickonSelectTrainingButtonandSelectTraining()
        {
            //Click on Select Training Button and Select Training
            logger.LogMethodEntry("RptSaveReportPage",
                "ClickonSelectTrainingButtonandSelectTraining",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window and Frame
            this.SelectReportWindowAndFrame();            
            base.WaitForElement(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_SelectTraining_Button_Id_Locator));
            //Click On 'Select Training' Button
            base.ClickButtonById(RptSaveReportPageResource.
                RptSaveReport_Page_SelectTraining_Button_Id_Locator);
            //Select 'Select Training' Window
            this.SelectTrainingWindow();
            base.WaitForElement(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_Training_Checkbox_Id_Locator));
            //Select Training
            base.SelectCheckBoxById(RptSaveReportPageResource.
                RptSaveReport_Page_Training_Checkbox_Id_Locator);
            logger.LogMethodExit("RptSaveReportPage",
                "ClickonSelectTrainingButtonandSelectTraining",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Training Most Recent RadioButton.
        /// </summary>
        public void SelectTrainingMostRecentRadioButton()
        {
            //Select Training Most Recent RadioButton
            logger.LogMethodEntry("RptSaveReportPage",
                "SelectTrainingMostRecentRadioButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window and Frame
                this.SelectReportWindowAndFrame();  
                //Wait for the element
                base.WaitForElement(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_Training_MostButton_Id_Locator));
                //Wait for the element
                IWebElement getMostRecentButton = base.GetWebElementPropertiesById
                    (RptSaveReportPageResource.
                    RptSaveReport_Page_Training_MostButton_Id_Locator);
                //Click the radio button
                base.ClickByJavaScriptExecutor(getMostRecentButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage",
                "SelectTrainingMostRecentRadioButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Select Training' Window.
        /// </summary>
        private void SelectTrainingWindow()
        {
            //Select 'Select Training' Window
            logger.LogMethodEntry("RptSaveReportPage", "SelectTrainingWindow",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(RptSaveReportPageResource.
                RptSaveReport_Page_SelectTraining_Window_Title);
            //Select 'Select Training' Window
            base.SelectWindow(RptSaveReportPageResource.
                RptSaveReport_Page_SelectTraining_Window_Title);
            logger.LogMethodExit("RptSaveReportPage", "SelectTrainingWindow",
                base.isTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Select Student CheckBox.
        /// </summary>
        /// <param name="getActivityColumnCount">This is Activity Column Count.</param>
        public void SelectStudentCheckBox(int getActivityColumnCount)
        {
            //Select Student CheckBox
            logger.LogMethodEntry("RptSaveReportPage", "SelectStudentCheckBox",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.XPath(String.Format(RptSaveReportPageResource.
                    RptSaveReport_Page_SelectActivity_Checkbox_Xpath_Locator,
                    getActivityColumnCount)));
                IWebElement getSelectStudentCheckbox = base.GetWebElementPropertiesByXPath
                (String.Format(RptSaveReportPageResource.
                    RptSaveReport_Page_SelectActivity_Checkbox_Xpath_Locator,
                    getActivityColumnCount));
                //Click the Select Student Link
                base.ClickByJavaScriptExecutor(getSelectStudentCheckbox);
                //Close The Select Activity Add Button
                this.ClickonAddButtonInSelectActivityWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }   
            logger.LogMethodExit("RptSaveReportPage", "SelectStudentCheckBox",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Get Activity Column Count.
        /// </summary>
        /// <param name="activityName">Activity Name.</param>
        /// <returns>Column Count.</returns>
        public int GetActivityColumnCount(string activityName)
        {
            //Get Activity Column Count
            logger.LogMethodEntry("RptSaveReportPage", "GetActivityColumnCount",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getActivityName = string.Empty;
            //Initialize Variable
            int activityColumnNumber = Convert.ToInt32(RptSaveReportPageResource.
                RptSaveReport_Page_Column_InitialCount);
            try
            {
                //Get Activity Count
                int activityCount = base.GetElementCountByXPath(RptSaveReportPageResource.
                        RptSaveReport_Page_Activity_TotalCount);
                for (int rowCount = Convert.ToInt32(RptSaveReportPageResource.
                    RptSaveReport_Page_Loop_Initializer_Value);
                    rowCount <= activityCount; rowCount++)
                {
                    //Wait for the element
                    base.WaitForElement(By.XPath(string.Format(RptSaveReportPageResource.
                       RptSaveReport_Page_Activity_Name_Xpath_Locator, rowCount)));
                    //Get Activity Name
                    getActivityName = base.GetElementTextByXPath(string.Format(
                        RptSaveReportPageResource.
                        RptSaveReport_Page_Activity_Name_Xpath_Locator, rowCount));
                    if (getActivityName.Contains(activityName))
                    {
                        activityColumnNumber = rowCount;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage", "GetActivityColumnCount",
                  base.isTakeScreenShotDuringEntryExit);
            return activityColumnNumber;
        }

        /// <summary>
        /// Click The Select Activities Button.
        /// </summary>
        private void ClickTheSelectActivitiesButton()
        {
            //Click The Select Activities Button
            logger.LogMethodEntry("RptSaveReportPage", "ClickTheSelectActivitiesButton",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(RptSaveReportPageResource.
                    RptSaveReport_Page_SelectTraining_Button_Id_Locator));
            IWebElement getSelectActivityButton = base.GetWebElementPropertiesById
                (RptSaveReportPageResource.
                    RptSaveReport_Page_SelectTraining_Button_Id_Locator);
            //Click On 'Select Training' Button
            base.ClickByJavaScriptExecutor(getSelectActivityButton);
            logger.LogMethodExit("RptSaveReportPage", "ClickTheSelectActivitiesButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student Redio Button.
        /// </summary>
        private void SelectStudentRedioButton()
        {
            // Select Student Redio Button
            logger.LogMethodEntry("RptSaveReportPage", "SelectStudentRedioButton",
                base.isTakeScreenShotDuringEntryExit);    
            //Wait for the element
            base.WaitForElement(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_SelectStudent_RadioButton_Id_Locator));
            IWebElement getSelectStudentButton = base.GetWebElementPropertiesById
               (RptSaveReportPageResource.
                RptSaveReport_Page_SelectStudent_RadioButton_Id_Locator);
            //Click the Select Student Link
            base.ClickByJavaScriptExecutor(getSelectStudentButton);
            //Click on Add Button
            this.ClickonAddButtonInReport();
            logger.LogMethodExit("RptSaveReportPage", "SelectStudentRedioButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Button In Report.
        /// </summary>
        private void ClickonAddButtonInReport()
        {
            // Click on Add Button In Report
            logger.LogMethodEntry("RptSaveReportPage", "ClickonAddButtonInReport",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(RptSaveReportPageResource.
                RptSaveReport_Page_AddSection_Button_Id_Locator));
            IWebElement getAddButton = base.GetWebElementPropertiesById
                (RptSaveReportPageResource.
                RptSaveReport_Page_AddSection_Button_Id_Locator);
            //Click on Add Button
            base.ClickByJavaScriptExecutor(getAddButton);
            logger.LogMethodExit("RptSaveReportPage", "ClickonAddButtonInReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student Button In Report.
        /// </summary>
        private void SelectStudentButtonInReport()
        {
            //Select 'Select Training' Window
            logger.LogMethodEntry("RptSaveReportPage", "SelectStudentButtonInReport",
                base.isTakeScreenShotDuringEntryExit);
            // Click SelectStudents button
            base.WaitForElement(By.Id(RptSaveReportPageResource.
               RptSaveReport_Page_SelectStudent_Button_Id_Locator));
            IWebElement getSelectStudentButton=base.GetWebElementPropertiesById
                (RptSaveReportPageResource.
               RptSaveReport_Page_SelectStudent_Button_Id_Locator); 
            //Click on Button
            base.ClickByJavaScriptExecutor(getSelectStudentButton);
            logger.LogMethodExit("RptSaveReportPage", "SelectStudentButtonInReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Data In Fields To Generate Certificate.
        /// </summary>
        public void EnterDataInFieldsToGenerateCertificate()
        {
            //Enter Data In Fields To Generate Certificate
            logger.LogMethodEntry("RptSaveReportPage",
                "EnterDataInFieldsToGenerateCertificate",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                RptSelectStudentsPage rptSelectStudentsPage = new RptSelectStudentsPage();
                //Click on Select Training Button and Select Training
                this.ClickonSelectTrainingButtonandSelectTraining();
                //Close The Select Activity Add Button
                this.ClickonAddButtonInSelectActivityWindow();
                //Select Window and Frame
                this.SelectReportWindowAndFrame();
                //Select Student Button In Report
                this.SelectStudentButtonInReport();
                //Select 'Select Students' Window
                rptSelectStudentsPage.SelectStudentsWindow();
                //Select Student
                rptSelectStudentsPage.SelectStudentToGenerateReport(
                    RptSaveReportPageResource.RptSaveReport_Page_StudentName_Value);
                //Click on Add Button
                this.ClickonAddButtonInReport();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage",
                "EnterDataInFieldsToGenerateCertificate",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Data Fields To Generate Exam Report.
        /// </summary>
        public void EnterTheDataFieldsToGenerateExamReport()
        {
            //Enter The Data Fields To Generate Exam Report
            logger.LogMethodEntry("RptSaveReportPage",
                 "EnterDataInFieldsToGenerateCertificate",
                       base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click The Select Activities Button
                this.ClickTheSelectActivitiesButton();
                //Select the Exam Window
                this.SelectExamWindowInReport();
                //Get Activity From Memory
                Activity activity = Activity.Get(Activity.ActivityTypeEnum.Test);
                //Get Activity Column Count
                int getActivityColumnCount = this.GetActivityColumnCount(activity.Name);
                //Select Student CheckBox
                this.SelectStudentCheckBox(getActivityColumnCount);
                //Select the window
                this.SelectReportWindowAndFrame();
                //Select Student Button In Report
                this.SelectStudentButtonInReport();
                //Select 'Select Students' window
                this.SelectStudentsWindow();
                //Select Student Redio Button
                this.SelectStudentRedioButton();
            }
            catch (Exception e)
            {
             ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage",
                   "EnterDataInFieldsToGenerateCertificate",
                        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Students Window.
        /// </summary>
        private void SelectStudentsWindow()
        {
            //Select Students Window
            logger.LogMethodEntry("RptSaveReportPage", "SelectStudentsWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Window
            base.WaitUntilWindowLoads(RptSaveReportPageResource.
                RptSaveReport_Page_SelectStudents_Window);
            //Select the window
            base.SelectWindow(RptSaveReportPageResource.
                RptSaveReport_Page_SelectStudents_Window);
            logger.LogMethodExit("RptSaveReportPage", "SelectStudentsWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Exam Window.
        /// </summary>
        private void SelectExamWindowInReport()
        {
            //Select the Exam Window
            logger.LogMethodEntry("RptSaveReportPage", "SelectExamWindowInReport",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Window
            base.WaitUntilWindowLoads(RptSaveReportPageResource.
                RptSaveReport_Page_SelectExam_Window);
            base.SelectWindow(RptSaveReportPageResource.
                RptSaveReport_Page_SelectExam_Window);
            logger.LogMethodExit("RptSaveReportPage", "SelectExamWindowInReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Options to Generate Activity Result By Single Student Report.
        /// </summary>
        /// <param name="activtyName">This is Activity Name.</param>
        public void SelectOptionstoGenerateActivityResultReport(string activtyName)
        {
            //Select Options to Generate Activity Result By Single Student Report
            logger.LogMethodEntry("RptSaveReportPage",
                "SelectOptionstoGenerateActivityResultReport",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                RptMainUXPage rptMainUXPage = new RptMainUXPage();
                //Select Reports Window and Frame
                rptMainUXPage.SelectReportsWindowandFrame();
                //Select Student Button In Report
                this.SelectStudentButtonInReport();
                //Select Window
                new RptSelectStudentsPage().SelectStudentWindow();
                //Select Student Radio Button
                this.SelectStudentRedioButton();
                //Select Reports Window and Frame
                rptMainUXPage.SelectReportsWindowandFrame();
                //Click The Select Activities Button
                this.ClickTheSelectActivitiesButton();
                //Select 'Select Activities' Window
                this.SelectActivitiesWindow();
                //Get Activity Column Count
                int getActivityColumnCount = this.GetActivityColumnCount(activtyName);
                //Select Student CheckBox
                this.SelectStudentCheckBox(getActivityColumnCount);   
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSaveReportPage",
                "SelectOptionstoGenerateActivityResultReport",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Select Activities' Window.
        /// </summary>
        private void SelectActivitiesWindow()
        {
            //Select 'Select Activities' Window
            logger.LogMethodEntry("RptSaveReportPage",
                "SelectActivitiesWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Window
            base.WaitUntilWindowLoads(RptSelectAssessmentsResource.
                   RptSelectAssessments_Page_Ins_SelectActivities_Window_Title_Name);
            //Select Window
            base.SelectWindow(RptSelectAssessmentsResource.
                RptSelectAssessments_Page_Ins_SelectActivities_Window_Title_Name);
            logger.LogMethodExit("RptSaveReportPage",
                "SelectActivitiesWindow",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
