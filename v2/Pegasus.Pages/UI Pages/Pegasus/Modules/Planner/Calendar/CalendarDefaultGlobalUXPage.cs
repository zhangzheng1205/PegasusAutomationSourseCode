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
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Planner.Calendar;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentSchedule;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium.Interactions;



namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles CalendarDefaultGlobalUXPage Actions
    /// </summary>
    public class CalendarDefaultGlobalUXPage : BasePage
    {
        // <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(CalendarDefaultGlobalUXPage));

        /// <summary>
        /// Time out value fetched from the app config
        /// </summary>
        int minutesToWait = Int32.Parse(ConfigurationManager.
             AppSettings["AssignedToCopyInterval"]);

        /// <summary>
        /// Search Asset in Planner Tab
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        public void SearchAssetInPlannerTab(string activityName)
        {
            //Search Asset in Planner Tab
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "SearchAssetInPlannerTab",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Selects Window and switch To Frame
                this.SelectWindowAndSwitchToFrame();
                //Check Activity Assign To Copy State In Planner Tab
                this.CheckActivityAssignToCopyStateInPlannerTab(activityName);
                //Enter Asset Name 
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SearchTextBox_Id_Locator));
                base.ClearTextByID(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SearchTextBox_Id_Locator);
                base.FillTextBoxByID(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SearchTextBox_Id_Locator, activityName);
                //Click on Search Button
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SearchButton_Id_Locator));
                IWebElement getSearchButton = base.GetWebElementPropertiesById(
                    CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SearchButton_Id_Locator);
                base.ClickByJavaScriptExecutor(getSearchButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "SearchAssetInPlannerTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selects Window and switch To Frame
        /// </summary>
        private void SelectWindowAndSwitchToFrame()
        {
            //Selects Window and switch To Frame
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "SelectWindowAndSwitchToFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Select Planner Window
            base.WaitUntilWindowLoads(CalendarDefaultGlobalUXPageResource.
                CalendarDefaultGlobalUX_Page_Window_TitleName);
            base.SelectWindow(CalendarDefaultGlobalUXPageResource.
                CalendarDefaultGlobalUX_Page_Window_TitleName);
            //Switch to Frame
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource.
                CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator));
            base.SwitchToIFrame(CalendarDefaultGlobalUXPageResource.
                CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator);
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "SelectWindowAndSwitchToFrame",
                base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Get Asset Name
        /// </summary>
        /// <returns>This is Asset Name</returns>
        public String GetAssetName()
        {
            //Get Asset Name
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "GetAssetName",
                   base.isTakeScreenShotDuringEntryExit);
            //Initialize variable
            String getAssetName = string.Empty;
            try
            {
                base.SelectWindow(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Window_TitleName);
                //Switch to Frame
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator));
                base.SwitchToIFrame(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator);
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_ClearResultLink_Id_Locator));
                base.WaitForElement(By.XPath(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SearchedAssetName_Xpath_Locator));
                //Get Asset Name From Application
                getAssetName = base.GetTitleAttributeValueByXPath(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SearchedAssetName_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "GetAssetName",
                  base.isTakeScreenShotDuringEntryExit);
            return getAssetName;
        }

        /// <summary>
        /// Clear Searched Result
        /// </summary>
        public void ClearSearchedResult()
        {
            //Clear Searched Result
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ClearSearchedResult",
                   base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Window_TitleName);
                //Selects Window
                base.SelectWindow(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Window_TitleName);
                //Switch to Frame
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator));
                base.SwitchToIFrame(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator);
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_ClearResultLink_Id_Locator));
                IWebElement getClearResult = base.GetWebElementPropertiesById
                    (CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_ClearResultLink_Id_Locator);
                //Click on Clear Results Link
                ClickByJavaScriptExecutor(getClearResult);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ClearSearchedResult",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check If Searched Result Present
        /// </summary>
        /// <returns>This is Searched Element Present or Not</returns>
        public Boolean CheckClearResultLinkPresent()
        {
            //Check If Searched Result Present
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "CheckClearResultLinkPresent",
                   base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            Boolean isSearchedElementPresent = false;
            try
            {
                base.RefreshTheCurrentPage();
                Thread.Sleep(Convert.ToInt32(CalendarDefaultGlobalUXPageResource.
               CalendarDefaultGlobalUX_Page_TimeThread_Value));
                //Wait for the window
                base.WaitUntilWindowLoads(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Window_TitleName);
                base.SelectWindow(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Window_TitleName);
                //Switch to Frame
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator));
                base.SwitchToIFrame(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator);
                //Check If Clear Results Link Present 
                isSearchedElementPresent = base.IsElementPresent(By.Id(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_ClearResultLink_Id_Locator),
                        Convert.ToInt32(CalendarDefaultGlobalUXPageResource.
                        CalendarDefaultGlobalUX_Page_CustomTimeToWait_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "CheckClearResultLinkPresent",
                   base.isTakeScreenShotDuringEntryExit);
            return isSearchedElementPresent;
        }

        /// <summary>
        /// Click on Advanced Search Link
        /// </summary>
        public void ClickOnAdvancedSearchLink()
        {
            //Click on Advanced Search Link
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ClickOnAdvancedSearchLink",
                  base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Curriculum Window
                base.WaitUntilWindowLoads(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Window_TitleName);
                base.SelectWindow(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Window_TitleName);
                //Switch to Frame
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator));
                base.SwitchToIFrame(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator);
                //Click on Advanced Search Link
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_AdvancedSearchLink_Id_Locator));
                base.ClickLinkById(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_AdvancedSearchLink_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ClickOnAdvancedSearchLink",
                  base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Configure calendar set up
        /// </summary>
        /// <param name="orgClassName">This is the class name</param>
        /// <param name="courseName">This is the course name</param>
        public void ConfigureCalendarSetUp(string orgClassName, string courseName)
        {
            // Configure the calendar 
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ConfigureCalendarSetUp",
                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Configure general preference on calendar lightbox
                ConfigureGeneralPreferences();
                // Configure schedule class on calendar lightbox
                ConfigureScheduleClasses(orgClassName, courseName);
                // Configure classes periods
                ConfigureClassesPeriods();
                // configure block out description
                ConfigureBlockOutDescription();
                // Configure block out date
                ConfigureBlockOutDate();
                // Save Calendar
                SelectSaveCalendarButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ConfigureCalendarSetUp",
                 base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Configure the blockout day
        /// </summary>
        private void ConfigureBlockOutDescription()
        {
            // Configure block out day on calendar light box
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ConfigureBlockOutDay",
                 base.isTakeScreenShotDuringEntryExit);
            // Enter description
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_BlockOutday_Description_Textbox));
            base.FillTextBoxByID(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_BlockOutday_Description_Textbox
             , CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_BlockOutday_Description);
            // Classes affeceted drop down
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_ClassesAffected_TriangleButton));
            base.ClickButtonByID(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_ClassesAffected_TriangleButton);
            // Click on all check box
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_CheckboxAll_ID));
            base.ClickButtonByID(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_CheckboxAll_ID);
            // Select ok button
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_ClassesAffected_OkButton_Id));
            base.ClickButtonByID(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_ClassesAffected_OkButton_Id);
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ConfigureBlockOutDay",
        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Configure the block out date in calendar set up
        /// </summary>
        private void ConfigureBlockOutDate()
        {
            // Configure block out date in calendar set up 
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ConfigureBlockOutDate",
                 base.isTakeScreenShotDuringEntryExit);
            // Wait for start date text box
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                   .CalendarDefaultGlobalUX_Page_BlockOut_StartDate_Id));
            // Get start date and end date
            string getStartDate = DateTime.Now.AddDays(5).ToString(
                CalendarDefaultGlobalUXPageResource
            .CalendarDefaultGlobalUX_Page_DateFormat);
            string getEndDate = DateTime.Now.AddDays(10).ToString(
                CalendarDefaultGlobalUXPageResource
            .CalendarDefaultGlobalUX_Page_DateFormat);
            // Clear and enter start date
            base.ClearTextByID(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_BlockOut_StartDate_Id);
            base.FillTextBoxByID(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_BlockOut_StartDate_Id, getStartDate);
            // Clear and enter End date
            base.ClearTextByID(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_BlockOut_EndDate_Id);
            base.FillTextBoxByID(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_BlockOut_EndDate_Id, getEndDate);
            // Configure schedule class set up on the calendar light box
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ConfigureBlockOutDate",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Configure the schedule class
        /// </summary>
        /// <param name="orgClassName">This is the class name</param>
        /// <param name="courseName">This is the course name</param>
        private void ConfigureScheduleClasses(string orgClassName, string courseName)
        {
            // Configure schedule class set up on the calendar light box
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ConfigureScheduleClasses",
                 base.isTakeScreenShotDuringEntryExit);
            // Wait for the class name dropdown
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                   .CalendarDefaultGlobalUX_Page_ClassDropDown_Id_Locator));
            // Select class name in drop down
            base.SelectDropDownValueThroughTextById(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_ClassDropDown_Id_Locator, orgClassName);
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_CourseDropDown_Id_Locator));
            // Select course name in drop down
            base.SelectDropDownValueThroughTextById(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_CourseDropDown_Id_Locator, courseName);
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
            .CalendarDefaultGlobalUX_Page_DisplayName_Id_Locator));
            // Enter the display name
            base.ClearTextByID(CalendarDefaultGlobalUXPageResource
           .CalendarDefaultGlobalUX_Page_DisplayName_Id_Locator);
            base.FillTextBoxByID(CalendarDefaultGlobalUXPageResource
           .CalendarDefaultGlobalUX_Page_DisplayName_Id_Locator, CalendarDefaultGlobalUXPageResource
            .CalendarDefaultGlobalUX_Page_DisplayNameText_Value);
            // Select order in order drop down
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_Order_DropDown_Id));
            base.SelectDropDownValueThroughIndexById(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_Order_DropDown_Id, Convert.ToInt32
            (CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_Order_DropDown_Value));
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ConfigureScheduleClasses",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Configure the general preference
        /// </summary>
        private void ConfigureGeneralPreferences()
        {
            // Set general preference on the calendar light box
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ConfigureGeneralPreferences",
                 base.isTakeScreenShotDuringEntryExit);
            // Select Default window
            base.SwitchToDefaultPageContent();
            base.SelectWindow(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_Window_TitleName);
            // Switch calendar light box frame
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                    .CalendarDefaultGlobalUX_Page_LightBoxFrame_Id_Locator));
            base.SwitchToIFrame(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_LightBoxFrame_Id_Locator);
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_LightBoxInsideFrame_Id_Locator));
            base.SwitchToIFrame(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_LightBoxInsideFrame_Id_Locator);
            // Select timezone value in timezone drop down
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
            .CalendarDefaultGlobalUX_Page_TimeZone_DropDown_Id));
            base.SelectDropDownValueThroughTextById(CalendarDefaultGlobalUXPageResource
            .CalendarDefaultGlobalUX_Page_TimeZone_DropDown_Id,
            CalendarDefaultGlobalUXPageResource
            .CalendarDefaultGlobalUX_Page_TimeZone_DropDown_Value);
            // Wait and click on the schedule class button
            base.WaitForElement(By.CssSelector(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_ScheduleClassButton_CSS_Locator));
            base.ClickButtonByCssSelector(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_ScheduleClassButton_CSS_Locator);
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ConfigureGeneralPreferences",
        base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on save calendar button
        /// </summary>
        public void SelectSaveCalendarButton()
        {
            // Click on save calendar button in calendar frame
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "SelectSaveCalendarButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Wait and click on the save calendar button
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                    .CalendarDefaultGlobalUX_Page_SaveCalendar_Button_Id));
                base.ClickButtonByID(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_SaveCalendar_Button_Id);
                // Click on exit button
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_ExitButton_Id));
                base.ClickButtonByID(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_ExitButton_Id);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "SelectSaveCalendarButton",
                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assign activity and Set the due date in assign window
        /// </summary>
        /// <param name="activityName">This is the activity name</param>
        /// <param name="className">This is the class name</param>
        public void SetDueDateOfActivity(string activityName, string className)
        {

            // Assign activity from left frame
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "SetDueDateOfActivity",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Search the asset in left frame
                SearchAssetInPlannerTab(activityName);
                // locate assign option for the activity name
                LocateAssignOption();
                // Select class radio button
                new AssignContentPage().SelectClassOnAssignWindow(className);
                // Configure the due date on assign window 
                new AssignContentPage().ConfigureDueDate();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "SetDueDateOfActivity",
                  base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Locate the assign option by mouse over activity
        /// </summary>
        private void LocateAssignOption()
        {
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "LocateAssignOption",
                 base.isTakeScreenShotDuringEntryExit);
            //Switch to default window
            base.SwitchToDefaultPageContent();
            base.SelectWindow(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_Window_TitleName);
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator));
            // switch to frame
            base.SwitchToIFrame(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator);
            base.WaitForElement(By.ClassName(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_Activity_ClassName_td));
            // Get activity title row
            IWebElement activityTitle = base.GetWebElementPropertiesByClassName(
                CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_Activity_ClassName_td);
            // perform mouse over
            base.PerformMouseHoverAction(activityTitle);
            IWebElement imageTriangle = base.GetWebElementPropertiesByXPath(
                CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_ActivityName_TriangleImage);
            //perform mouse over on triangle button
            base.PerformClickAction(imageTriangle);
            base.WaitForElement(By.PartialLinkText(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_AssignPartialText));
            // Click assign partial link text
            base.ClickButtonByPartialLinkText(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_AssignPartialText);
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "LocateAssignOption",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Configure classes periods on calendar frame
        /// </summary>
        private void ConfigureClassesPeriods()
        {
            // configure the classes periods
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ConfigureClassesPeriods",
                 base.isTakeScreenShotDuringEntryExit);
            // Wait for monday label
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_MondayLabel_Id));
            // Click on monday 
            base.ClickButtonByID(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_MondayLabel_Id);
            // Click on Tuesday 
            base.ClickButtonByID(CalendarDefaultGlobalUXPageResource
              .CalendarDefaultGlobalUX_Page_TuesdayLabel_Id);
            // Click on wednesday
            base.ClickButtonByID(CalendarDefaultGlobalUXPageResource
              .CalendarDefaultGlobalUX_Page_WednesdayLabel_Id);
            // Click on thursday
            base.ClickButtonByID(CalendarDefaultGlobalUXPageResource
              .CalendarDefaultGlobalUX_Page_ThursdayLabel_Id);
            // Click on Friday
            base.ClickButtonByID(CalendarDefaultGlobalUXPageResource
              .CalendarDefaultGlobalUX_Page_FridayLabel_Id);
            // Click on Saturday
            base.ClickButtonByID(CalendarDefaultGlobalUXPageResource
              .CalendarDefaultGlobalUX_Page_SaturdayLabel_Id);
            // Click on Sunday
            base.ClickButtonByID(CalendarDefaultGlobalUXPageResource
              .CalendarDefaultGlobalUX_Page_SundayLabel_Id);
            // Wait and click on the important dates button
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
            .CalendarDefaultGlobalUX_Page_ImportantDatesButton_Id_Locator));
            base.ClickButtonByID(CalendarDefaultGlobalUXPageResource
            .CalendarDefaultGlobalUX_Page_ImportantDatesButton_Id_Locator);
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ConfigureClassesPeriods",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check Activity Assign To Copy State
        /// </summary>
        /// <param name="activityName">Activity Name</param>
        public void CheckActivityAssignToCopyStateInPlannerTab(String activityName)
        {
            //Check Activity Assign To Copy State
            logger.LogMethodEntry("ContentLibraryPage",
                "CheckActivityAssignToCopyStateInPlannerTab",
                   base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Selects Window and Switch to Frame
                this.SelectWindowAndSwitchToFrame();
                //Get all the Asset Names
                string getAssetNames = base.GetElementTextByID(
                    CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_Div_Id_Locator);
                if (getAssetNames.Contains(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Activity_AssignToCopy_Message))
                {
                    //Activity Count
                    int getActivityCount = base.GetElementCountByXPath(
                        CalendarDefaultGlobalUXPageResource.
                        CalendarDefaultGlobalUX_Page_Assets_Xpath_Locator);
                    //Refresh The Page If Required Activity is Present
                    this.RefreshThePageRequiredActivityPresent(activityName, getActivityCount);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryPage",
                "CheckActivityAssignToCopyStateInPlannerTab",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Refresh The Page If Required Activity is Present
        /// </summary>
        /// <param name="activityName">Activity Name</param>
        /// <param name="getActivityCount">Activity Count</param>
        private void RefreshThePageRequiredActivityPresent(String activityName, int getActivityCount)
        {
            //Refresh The Page If Required Activity is Present
            logger.LogMethodEntry("ContentLibraryPage", "RefreshThePageRequiredActivityPresent",
                   base.isTakeScreenShotDuringEntryExit);

            for (int rowCount = Convert.ToInt32(CalendarDefaultGlobalUXPageResource.
                CalendarDefaultGlobalUX_Page_ForLoopInitialization_Value);
                rowCount < getActivityCount; rowCount++)
            {
                //Get Activity Name
                string getActivityName = base.GetElementTextByXPath(string.Format
                    (CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_AssetName_Xpath_Locator, rowCount));
                if (activityName == getActivityName)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    //Initialize Variable
                    string message = string.Empty;
                    do
                    {
                        //Refresh The Current Page
                        base.RefreshTheCurrentPage();
                        this.SelectWindowAndSwitchToFrame();
                        //Get Activity Assign To Copy Message
                        message = base.GetElementTextByXPath(string.Format
                            (CalendarDefaultGlobalUXPageResource.
                            CalendarDefaultGlobalUX_Page_AssetCopyMessage_XpathLocator, rowCount));
                    } while (message == CalendarDefaultGlobalUXPageResource.
                      CalendarDefaultGlobalUX_Activity_AssignToCopy_Message &&
                        stopwatch.Elapsed.TotalSeconds < minutesToWait);
                    break;
                }
            }
            logger.LogMethodExit("ContentLibraryPage", "RefreshThePageRequiredActivityPresent",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assign activity to calendar through drag and drop
        /// </summary>
        public void AssignActivityToCalendar(string activityName)
        {
            //Drag and drop the activity on calendar frame
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "AssignActivityToCalendar",
                   base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Selects Window and switch To Frame
                SelectWindowAndSwitchToFrame();
                // Drag and drop the activity
                DragAndDropTheActivity(activityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "AssignActivityToCalendar",
                      base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Drag and drop the activity on the calendar date
        /// </summary>
        private void DragAndDropTheActivity(string activityName)
        {
            //Drag and drop the activity on calendar frame
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "DragAndDropTheActivity",
                   base.isTakeScreenShotDuringEntryExit);
            // Wait for the activity name 
            base.WaitForElement(By.XPath(CalendarDefaultGlobalUXPageResource
                 .CalendarDefaultGlobalUX_Page_ActivityName_Td_Drag));
            //Drag the activity
            IWebElement dragActivity = base.GetWebElementPropertiesByXPath
                (CalendarDefaultGlobalUXPageResource
               .CalendarDefaultGlobalUX_Page_ActivityName_Td_Drag);
            Thread.Sleep(Convert.ToInt32(CalendarDefaultGlobalUXPageResource.
                CalendarDefaultGlobalUX_Page_TimeThread_Value));
            // drop the activity to calendar
            IWebElement dropActivity = base.GetWebElementPropertiesByClassName
                (CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_DropFrame_ClassName);
            // Drag and drop operation
            new Actions(base.WebDriver).DragAndDrop(dragActivity, dropActivity).Build().Perform();
            //Drag and drop the activity on calendar frame
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "DragAndDropTheActivity",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the processing text from the calendar frame
        /// </summary>
        /// <returns>Content Copy text</returns>
        public Boolean IsAssignedTextPresent()
        {
            //Drag and drop the activity on calendar frame
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "IsAssignedTextPresent",
                   base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Select default window
                base.SwitchToDefaultPageContent();
                base.SelectWindow(CalendarDefaultGlobalUXPageResource
                    .CalendarDefaultGlobalUX_Page_Window_TitleName);
                // switch to planner frame
                base.SwitchToIFrame(CalendarDefaultGlobalUXPageResource
                    .CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator);
                base.WaitForElement(By.ClassName(CalendarDefaultGlobalUXPageResource
                    .CalendarDefaultGlobalUX_Page_DropFrame_ClassName));
                // Verify the content is being prepared text on the calendar
                VerifyAssignedTextOnCalendar();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Drag and drop the activity on calendar frame
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "IsAssignedTextPresent",
                   base.isTakeScreenShotDuringEntryExit);
            return true;
        }

        /// <summary>
        /// Verify the "content is being" text on the calendar frame
        /// </summary>
        private void VerifyAssignedTextOnCalendar()
        {
            // verify the activity processing text on calendar frame
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "VerifyAssignedTextOnCalendar",
                  base.isTakeScreenShotDuringEntryExit);
            // initiate the stop watch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (stopWatch.Elapsed.Minutes < minutesToWait)
            {
                // Get the calendar text from where activity is dropped
                IWebElement getCalendarText = base.GetWebElementPropertiesByClassName
                    (CalendarDefaultGlobalUXPageResource
                     .CalendarDefaultGlobalUX_Page_DropFrame_ClassName);
                if (getCalendarText.Text.Contains(CalendarDefaultGlobalUXPageResource
               .CalendarDefaultGlobalUX_Page_DropActivityFrame_Text))
                {
                    Thread.Sleep(Convert.ToInt32(CalendarDefaultGlobalUXPageResource
                        .CalendarDefaultGlobalUX_Page_TwentySecsThread_Value));
                    // refresh the frame and switch to window
                    base.SwitchToDefaultPageContent();
                    base.RefreshIFrameByJavaScriptExecutor(CalendarDefaultGlobalUXPageResource
                    .CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator);
                    base.WaitUntilWindowLoads(CalendarDefaultGlobalUXPageResource
                    .CalendarDefaultGlobalUX_Page_Window_TitleName);
                    base.SelectWindow(CalendarDefaultGlobalUXPageResource
                    .CalendarDefaultGlobalUX_Page_Window_TitleName);
                    // switch to planner frame
                    base.SwitchToIFrame(CalendarDefaultGlobalUXPageResource
                        .CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator);
                }
                else
                { break; }
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "VerifyAssignedTextOnCalendar",
                  base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// This function verifies the calendar title on the calendar frame
        /// </summary>
        /// <returns>Calendar header text</returns>
        public String GetCalendarTitle()
        {
            // verify the calendar header text
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "GetCalendarTitle",
                  base.isTakeScreenShotDuringEntryExit);
            // initialize calendar title
            string getCalendarTitle = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(CalendarDefaultGlobalUXPageResource
                        .CalendarDefaultGlobalUX_Page_Window_TitleName);
                // Switch to planner window
                base.SelectWindow(CalendarDefaultGlobalUXPageResource
                    .CalendarDefaultGlobalUX_Page_Window_TitleName);
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                    .CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator));
                // Switch to planner frame
                base.SwitchToIFrame(CalendarDefaultGlobalUXPageResource
                    .CalendarDefaultGlobalUX_Page_Planner_Frame_Id_Locator);
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_CalendarTitleHeader_Id));
                // get the calendar title text 
                getCalendarTitle = base.GetElementTextByID
                      (CalendarDefaultGlobalUXPageResource
                      .CalendarDefaultGlobalUX_Page_CalendarTitleHeader_Id);
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            // verify the calendar header text
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "GetCalendarTitle",
                  base.isTakeScreenShotDuringEntryExit);
            return getCalendarTitle;
        }

    }
}
