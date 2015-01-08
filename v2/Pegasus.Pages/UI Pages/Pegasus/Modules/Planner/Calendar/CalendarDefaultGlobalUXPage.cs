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

        private static int pixelValueToSrollDown;
        private static string divFolderNodeID;
        private static string divSubFolderNodeID;
        private static string divLeafFolderNodeID;


        /// <summary>
        /// Search Asset in Planner Tab
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        public void SearchAssetInPlannerTab(string activityName)
        {
            //Search Asset in Planner Tab
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "SearchAssetInPlannerTab",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Selects Window and switch To Frame
                this.SelectWindowAndSwitchToFrame();
                //Check Activity Assign To Copy State In Planner Tab
                this.CheckActivityAssignToCopyStateInPlannerTab(activityName);
                //Enter Asset Name 
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SearchTextBox_Id_Locator));
                base.ClearTextById(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SearchTextBox_Id_Locator);
                base.FillTextBoxById(CalendarDefaultGlobalUXPageResource.
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selects Window and switch To Frame
        /// </summary>
        private void SelectWindowAndSwitchToFrame()
        {
            //Selects Window and switch To Frame
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "SelectWindowAndSwitchToFrame",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Get Asset Name
        /// </summary>
        /// <returns>This is Asset Name</returns>
        public String GetAssetName()
        {
            //Get Asset Name
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "GetAssetName",
                   base.IsTakeScreenShotDuringEntryExit);
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
                  base.IsTakeScreenShotDuringEntryExit);
            return getAssetName;
        }

        /// <summary>
        /// Clear Searched Result
        /// </summary>
        public void ClearSearchedResult()
        {
            //Clear Searched Result
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ClearSearchedResult",
                   base.IsTakeScreenShotDuringEntryExit);
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
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ClearSearchedResult",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check If Searched Result Present
        /// </summary>
        /// <returns>This is Searched Element Present or Not</returns>
        public Boolean CheckClearResultLinkPresent()
        {
            //Check If Searched Result Present
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "CheckClearResultLinkPresent",
                   base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
            return isSearchedElementPresent;
        }

        /// <summary>
        /// Click on Advanced Search Link
        /// </summary>
        public void ClickOnAdvancedSearchLink()
        {
            //Click on Advanced Search Link
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ClickOnAdvancedSearchLink",
                  base.IsTakeScreenShotDuringEntryExit);
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
                IWebElement advancedSearchLink=base.GetWebElementPropertiesById(
                    CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_AdvancedSearchLink_Id_Locator);
                Thread.Sleep(3000);
                base.ClickByJavaScriptExecutor(advancedSearchLink);
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ClickOnAdvancedSearchLink",
                  base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Configure the blockout day
        /// </summary>
        private void ConfigureBlockOutDescription()
        {
            // Configure block out day on calendar light box
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ConfigureBlockOutDay",
                 base.IsTakeScreenShotDuringEntryExit);
            // Enter description
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_BlockOutday_Description_Textbox));
            base.FillTextBoxById(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_BlockOutday_Description_Textbox
             , CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_BlockOutday_Description);
            // Classes affeceted drop down
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_ClassesAffected_TriangleButton));
            base.ClickButtonById(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_ClassesAffected_TriangleButton);
            // Click on all check box
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_CheckboxAll_ID));
            base.ClickButtonById(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_CheckboxAll_ID);
            // Select ok button
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_ClassesAffected_OkButton_Id));
            base.ClickButtonById(CalendarDefaultGlobalUXPageResource
             .CalendarDefaultGlobalUX_Page_ClassesAffected_OkButton_Id);
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ConfigureBlockOutDay",
        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Configure the block out date in calendar set up
        /// </summary>
        private void ConfigureBlockOutDate()
        {
            // Configure block out date in calendar set up 
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ConfigureBlockOutDate",
                 base.IsTakeScreenShotDuringEntryExit);
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
            base.ClearTextById(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_BlockOut_StartDate_Id);
            base.FillTextBoxById(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_BlockOut_StartDate_Id, getStartDate);
            // Clear and enter End date
            base.ClearTextById(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_BlockOut_EndDate_Id);
            base.FillTextBoxById(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_BlockOut_EndDate_Id, getEndDate);
            // Configure schedule class set up on the calendar light box
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ConfigureBlockOutDate",
                 base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
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
            base.ClearTextById(CalendarDefaultGlobalUXPageResource
           .CalendarDefaultGlobalUX_Page_DisplayName_Id_Locator);
            base.FillTextBoxById(CalendarDefaultGlobalUXPageResource
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
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Configure the general preference
        /// </summary>
        private void ConfigureGeneralPreferences()
        {
            // Set general preference on the calendar light box
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ConfigureGeneralPreferences",
                 base.IsTakeScreenShotDuringEntryExit);
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
        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on save calendar button
        /// </summary>
        public void SelectSaveCalendarButton()
        {
            // Click on save calendar button in calendar frame
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "SelectSaveCalendarButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait and click on the save calendar button
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                    .CalendarDefaultGlobalUX_Page_SaveCalendar_Button_Id));
                base.ClickButtonById(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_SaveCalendar_Button_Id);
                // Click on exit button
                base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_ExitButton_Id));
                base.ClickButtonById(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_ExitButton_Id);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "SelectSaveCalendarButton",
                  base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
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
                  base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Locate the assign option by mouse over activity
        /// </summary>
        private void LocateAssignOption()
        {
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "LocateAssignOption",
                 base.IsTakeScreenShotDuringEntryExit);
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
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Configure classes periods on calendar frame
        /// </summary>
        private void ConfigureClassesPeriods()
        {
            // configure the classes periods
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ConfigureClassesPeriods",
                 base.IsTakeScreenShotDuringEntryExit);
            // Wait for monday label
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_MondayLabel_Id));
            // Click on monday 
            base.ClickButtonById(CalendarDefaultGlobalUXPageResource
                .CalendarDefaultGlobalUX_Page_MondayLabel_Id);
            // Click on Tuesday 
            base.ClickButtonById(CalendarDefaultGlobalUXPageResource
              .CalendarDefaultGlobalUX_Page_TuesdayLabel_Id);
            // Click on wednesday
            base.ClickButtonById(CalendarDefaultGlobalUXPageResource
              .CalendarDefaultGlobalUX_Page_WednesdayLabel_Id);
            // Click on thursday
            base.ClickButtonById(CalendarDefaultGlobalUXPageResource
              .CalendarDefaultGlobalUX_Page_ThursdayLabel_Id);
            // Click on Friday
            base.ClickButtonById(CalendarDefaultGlobalUXPageResource
              .CalendarDefaultGlobalUX_Page_FridayLabel_Id);
            // Click on Saturday
            base.ClickButtonById(CalendarDefaultGlobalUXPageResource
              .CalendarDefaultGlobalUX_Page_SaturdayLabel_Id);
            // Click on Sunday
            base.ClickButtonById(CalendarDefaultGlobalUXPageResource
              .CalendarDefaultGlobalUX_Page_SundayLabel_Id);
            // Wait and click on the important dates button
            base.WaitForElement(By.Id(CalendarDefaultGlobalUXPageResource
            .CalendarDefaultGlobalUX_Page_ImportantDatesButton_Id_Locator));
            base.ClickButtonById(CalendarDefaultGlobalUXPageResource
            .CalendarDefaultGlobalUX_Page_ImportantDatesButton_Id_Locator);
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ConfigureClassesPeriods",
                 base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Selects Window and Switch to Frame
                this.SelectWindowAndSwitchToFrame();
                //Get all the Asset Names
                string getAssetNames = base.GetElementTextById(
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
                   base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);

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
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assign activity to calendar through drag and drop
        /// </summary>
        public void AssignActivityToCalendar(string activityName)
        {
            //Drag and drop the activity on calendar frame
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "AssignActivityToCalendar",
                   base.IsTakeScreenShotDuringEntryExit);
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
                      base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Drag and drop the activity on the calendar date
        /// </summary>
        private void DragAndDropTheActivity(string activityName)
        {
            //Drag and drop the activity on calendar frame
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "DragAndDropTheActivity",
                   base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the processing text from the calendar frame
        /// </summary>
        /// <returns>Content Copy text</returns>
        public Boolean IsAssignedTextPresent()
        {
            //Drag and drop the activity on calendar frame
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "IsAssignedTextPresent",
                   base.IsTakeScreenShotDuringEntryExit);
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
                   base.IsTakeScreenShotDuringEntryExit);
            return true;
        }

        /// <summary>
        /// Verify the "content is being" text on the calendar frame
        /// </summary>
        public void VerifyAssignedTextOnCalendar()
        {
            // verify the activity processing text on calendar frame
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "VerifyAssignedTextOnCalendar",
                  base.IsTakeScreenShotDuringEntryExit);
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
                  base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// This function verifies the calendar title on the calendar frame
        /// </summary>
        /// <returns>Calendar header text</returns>
        public String GetCalendarTitle()
        {
            // verify the calendar header text
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "GetCalendarTitle",
                  base.IsTakeScreenShotDuringEntryExit);
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
                getCalendarTitle = base.GetElementTextById
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
                  base.IsTakeScreenShotDuringEntryExit);
            return getCalendarTitle;
        }

        /// <summary>
        /// Expand the folder in planner tab.
        /// </summary>
        /// <param name="folderName">Name of the folder to expand.</param>
        public void ExpandFolderInPlannerTab(string folderName)
        {
            
            //Expand the folder in Curriculum tab
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ExpandFolderInPlannerTab",
                  base.IsTakeScreenShotDuringEntryExit);
            this.SelectWindowAndSwitchToFrame();
            //Get the folders count in Planner tab
            int getFolderCount = base.GetElementCountByXPath(
                CalendarDefaultGlobalUXPageResource.CalendarDefaultGlobalUX_Page_Folder_Count_Xpath_Locator);
            //Loop through folders to find the expected folder
            for (int i = 1; i <= getFolderCount; i++)
            {
                //Get the folder name
                string getFolderName = base.GetElementTextByXPath(string.Format
                    (CalendarDefaultGlobalUXPageResource.CalendarDefaultGlobalUX_Page_FolderName_Xpath_Locator, i));
                //Check whether fetched folder name is same as expected folder name
                if (folderName.Equals(getFolderName))
                {
                    IWebElement expandButtonProperties = base.GetWebElementPropertiesByXPath(
                        string.Format(CalendarDefaultGlobalUXPageResource.
                        CalendarDefaultGlobalUX_Page_FolderExpandButton_Xpath_Locator, i));
                    //Expand the folder
                    base.ClickByJavaScriptExecutor(expandButtonProperties);
                    //Store the node ID of folder which needs to be used in order to find sub folder
                    divFolderNodeID = base.GetWebElementPropertiesByXPath(string.Format(CalendarDefaultGlobalUXPageResource.
                        CalendarDefaultGlobalUX_Page_FolderName_Xpath_Locator, i)).GetAttribute("nodeid");
                    break;
                }

            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ExpandFolderInPlannerTab",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Expand the sub folder in planner tab.
        /// </summary>
        /// <param name="subFolderName">Name of the sub folde to expand.</param>
        public void ExpandSubFolderInPlannerTab(string subFolderName)
        {
            //Expand the folder in Curriculum tab
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ExpandSubFolderInPlannerTab",
                  base.IsTakeScreenShotDuringEntryExit);
            //Create the div ID of subfolder
            string subfolderDivId = "ContainerID_" + divFolderNodeID;
            //Get subfolder count
            int getSubFolderCount = base.GetElementCountByXPath(
                string.Format(CalendarDefaultGlobalUXPageResource.
                CalendarDefaultGlobalUX_Page_SubFolder_Count_Xpath_Locator, subfolderDivId));
            //Loop through sub folders to find the expected sub folder
            for (int j = 1; j <= getSubFolderCount; j++)
            
            {
                //Get subfolder name
                string getSubFolderName = base.GetElementTextByXPath(string.
                    Format(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SubFolder_Name_Xpath_Locator,subfolderDivId, j));
                //Check whether fetched sub folder name is same as expected sub folder name
                if (subFolderName.Equals(getSubFolderName))
                {
                    
                    IWebElement subFolderExpandButton = base.GetWebElementPropertiesByXPath(
                        string.Format(CalendarDefaultGlobalUXPageResource.
                        CalendarDefaultGlobalUX_Page_SubFolderExpandButton_Xpath_Locator,subfolderDivId, j));
                    //Expand the sub folder
                    base.ClickByJavaScriptExecutor(subFolderExpandButton);
                    //Store the node ID of sub folder which needs to be used in order to find leaf folder
                    divSubFolderNodeID = base.GetWebElementPropertiesByXPath(string.
                        Format(CalendarDefaultGlobalUXPageResource.
                        CalendarDefaultGlobalUX_Page_SubFolder_Name_Xpath_Locator, subfolderDivId, j)).
                        GetAttribute("nodeid");
                    break;
                }

            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ExpandSubFolderInPlannerTab",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Expand the lead folder in planner tab.
        /// </summary>
        /// <param name="leafFolderName">Name of leaf folder to expan</param>
        public void LeafFolderExpansionInPlannerTab(string leafFolderName)
        {
            //Expand the folder in Curriculum tab
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "LeafFolderExpansionInPlannerTab",
                  base.IsTakeScreenShotDuringEntryExit);
            //Create the div ID of leaf folder
            string leafFolderDivId = "ContainerID_" + divSubFolderNodeID;
            //Get leaf folders count
            int getSubFolderCount = base.GetElementCountByXPath(
                string.Format(CalendarDefaultGlobalUXPageResource.
                CalendarDefaultGlobalUX_Page_SubFolder_Count_Xpath_Locator, leafFolderDivId));
            //Loop through leaf folders to find the expected sub folder
            for (int j = 1; j <= getSubFolderCount; j++)
            {
                try
                {
                    //Check whether Subfolder is visible
                    bool isLeafFolderExpandNameExists = base.IsElementPresent(By.XPath(string.
                    Format(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SubFolder_Name_Xpath_Locator, leafFolderDivId, j)), 5);
                    //Scroll down the frame till subfolder is visible
                    while (isLeafFolderExpandNameExists == false)
                    {
                        IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
                        js.ExecuteScript("arguments[0].scrollTop = arguments[1];", base.
                            GetWebElementPropertiesById("TreeViewContainer"), 100);

                        //base.PressKey(Keys.PageDown);
                        isLeafFolderExpandNameExists = base.IsElementPresent(By.XPath(string.
                Format(CalendarDefaultGlobalUXPageResource.
                CalendarDefaultGlobalUX_Page_SubFolder_Name_Xpath_Locator, leafFolderDivId, j)), 5);
                    }

                    //Get leaf folder name
                    string getLeafFolderName = base.GetElementTextByXPath(string.
                        Format(CalendarDefaultGlobalUXPageResource.
                        CalendarDefaultGlobalUX_Page_SubFolder_Name_Xpath_Locator, leafFolderDivId, j));
                    //Check whether fetched leaf folder name is same as expected sub folder name
                    if (leafFolderName.Equals(getLeafFolderName))
                    {
                        //Store the node ID of leaf folder which needs to be used in order to find activity inside leaf folder
                        divLeafFolderNodeID = base.GetWebElementPropertiesByXPath(string.Format(CalendarDefaultGlobalUXPageResource.
                            CalendarDefaultGlobalUX_Page_SubFolder_Name_Xpath_Locator, leafFolderDivId, j)).
                            GetAttribute("nodeid");
                        IWebElement subFolderExpandButton = base.GetWebElementPropertiesByXPath(
                            string.Format(CalendarDefaultGlobalUXPageResource.
                            CalendarDefaultGlobalUX_Page_SubFolderExpandButton_Xpath_Locator, leafFolderDivId, j));
                        //Expand the leaf folder
                        base.ClickByJavaScriptExecutor(subFolderExpandButton);
                        break;
                    }
                }
                catch (Exception e)
                {
                    ExceptionHandler.HandleException(e);
                }

            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "LeafFolderExpansionInPlannerTab",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Find the activity within leaf folder and click on Cmenu Option.
        /// </summary>
        /// <param name="cmenuOption">Cmenu name.</param>
        /// <param name="activityName">Activity name to find.</param>
        public void FindActivityAndClickOnCmenu(string cmenuOption, string activityName)
        {
            //Find activity in planner tab
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "FindActivityAndClickOnCmenu",
                  base.IsTakeScreenShotDuringEntryExit);
            //Create the div ID of activity
            string activityDivId = "ContainerID_" + divLeafFolderNodeID;
            int getSubFolderContentsCount = base.GetElementCountByXPath(
                string.Format(CalendarDefaultGlobalUXPageResource.
                CalendarDefaultGlobalUX_Page_SubFolder_Count_Xpath_Locator, activityDivId));
            for (int k = 1; k <= getSubFolderContentsCount; k++)
            {
                string getLessonName = base.GetElementTextByXPath(string.
                    Format(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SubFolder_Name_Xpath_Locator, activityDivId, k));
                if (activityName.Equals(getLessonName))
                {

                    try
                    {
                        //MouseHover On Activity
                        this.MouseHoverOnActivityInPlannerTOC(string.
                       Format(CalendarDefaultGlobalUXPageResource.
                       CalendarDefaultGlobalUX_Page_SubFolder_Name_Xpath_Locator, activityDivId, k));
                        //Click on Activity Cmenu Icon               
                        base.WaitForElement(By.XPath
                            (string.Format(CalendarDefaultGlobalUXPageResource.
                            CalendarDefaultGlobalUX_Page_LCC_CmenuIcon_Xpath_Locator, activityDivId, k)));
                        //Get HTML peroperty of Cmenu icon
                        bool activityCmenu = base.IsElementPresent(By.XPath(string.Format(CalendarDefaultGlobalUXPageResource.
                            CalendarDefaultGlobalUX_Page_LCC_CmenuIcon_Xpath_Locator, activityDivId, k)
                            ),5);
                        IWebElement getPropertyOfCmenuIcon =
                            base.GetWebElementPropertiesByXPath(
                            string.Format(CalendarDefaultGlobalUXPageResource.
                            CalendarDefaultGlobalUX_Page_LCC_CmenuIcon_Xpath_Locator, activityDivId, k));
                          base.ClickByJavaScriptExecutor(getPropertyOfCmenuIcon);
                        //Wait for Cmenu option to display
                          this.ClickOnCmenuOptionInPlannerTab(cmenuOption);
                          base.SwitchToDefaultPageContent();
                    }
                    catch (Exception e)
                    {
                        ExceptionHandler.HandleException(e);
                    }

                    break;
                }

            }
        }


        /// <summary>
        /// MouseHover On Activity in Planner
        /// </summary>
        private void MouseHoverOnActivityInPlannerTOC(String assetPath)
        {
            //MouseHover On Activity
            logger.LogMethodEntry("ContentLibraryPage",
                "MouseHoverOnActivity",
                 base.IsTakeScreenShotDuringEntryExit);
            bool isActivityExists = base.IsElementPresent(By.XPath
                (assetPath),5);
            base.WaitForElement(By.XPath(assetPath));
            //Mouse Hover On Searched Activity Name
            IWebElement testName = base.GetWebElementPropertiesByXPath(assetPath);
            base.PerformMouseHoverByJavaScriptExecutor(testName);
            logger.LogMethodExit("ContentLibraryPage",
                "MouseHoverOnActivity",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        public void ClickOnCmenuOptionInPlannerTab(string cmenuOption)
        {
            logger.LogMethodEntry("ContentLibraryPage", "GetCmenuOptions",
               base.IsTakeScreenShotDuringEntryExit);
            int getCmenuOptionCount = base.GetElementCountByXPath(
                CalendarDefaultGlobalUXPageResource.CalendarDefaultGlobalUX_Page_LCC_CmenuCount_Xpath_Locator);
            for (int i = 1; i <= getCmenuOptionCount; i++)
            {
                string getCmenuOption = base.GetElementTextByXPath(string.Format(
                    CalendarDefaultGlobalUXPageResource.CalendarDefaultGlobalUX_Page_Lesson_CmenuOption_Xpath_Locator, i));
                if (cmenuOption.Equals(getCmenuOption))
                {
                    IWebElement getCmenuProperties = base.GetWebElementPropertiesByXPath(string.Format(
                    CalendarDefaultGlobalUXPageResource.CalendarDefaultGlobalUX_Page_Lesson_CmenuOption_Xpath_Locator, i));
                    base.ClickByJavaScriptExecutor(getCmenuProperties);
                    break;
                }

            }

        }

        /// <summary>
        /// Get assigned content displayed in calendar frame in planner tab.
        /// </summary>
        /// <param name="assignedActivityTitle">Activity name.</param>
        /// <returns>Assigned activity name.</returns>
        public string GetAssignedContentTitle(string assignedActivityTitle)
         {
            //Get assigned activity title
             logger.LogMethodEntry("ContentLibraryPage", "GetAssignedContentTitle",
                base.IsTakeScreenShotDuringEntryExit);
             string getAssignedContentTitle = null;
            //Select planner tab.
             this.SelectWindowAndSwitchToFrame();
            //Fetch the contents count in calendar frame
             int getAssignedContentsCount = base.GetElementCountByXPath(
                 CalendarDefaultGlobalUXPageResource.CalendarDefaultGlobalUX_Page_CalendarFrame_AssignedContentCount_Xpath_Locator);
            try{

            for(int i=2; i<=getAssignedContentsCount; i++)
            {
                //Fetch title
                getAssignedContentTitle = base.GetElementTextByXPath(
                   string.Format(CalendarDefaultGlobalUXPageResource.CalendarDefaultGlobalUX_Page_CalendarFrame_AssignedTitle_Xpath_Locator,i));
                if(assignedActivityTitle.Equals(getAssignedContentTitle))
                {
                    break;
                }
            }

                }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryPage",
                "GetAssignedContentTitle",
                 base.IsTakeScreenShotDuringEntryExit);
            return getAssignedContentTitle;
         }

        /// <summary>
        /// Drand and Drop 
        /// </summary>
        /// <param name="activityName"></param>
        public void DragAndDropActivityInPlannerTab(string activityName)
        {

            //Find activity in planner tab
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "FindActivityAndClickOnCmenu",
                  base.IsTakeScreenShotDuringEntryExit);
            //Create the div ID of activity
            string activityDivId = "ContainerID_" + divLeafFolderNodeID;
            int getSubFolderContentsCount = base.GetElementCountByXPath(
                string.Format(CalendarDefaultGlobalUXPageResource.
                CalendarDefaultGlobalUX_Page_SubFolder_Count_Xpath_Locator, activityDivId));
            for (int k = 1; k <= getSubFolderContentsCount; k++)
            {

                bool isContentExists = base.IsElementPresent(By.XPath(string.
                    Format(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SubFolder_Name_Xpath_Locator, activityDivId, k)), 1);
                while (!isContentExists)
                {

                    IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
                    js.ExecuteScript("arguments[0].scrollTop = arguments[1];", base.
                        GetWebElementPropertiesById("TreeViewContainer"), pixelValueToSrollDown);
                    //Scroll the frame
                    isContentExists = base.IsElementPresent(By.XPath(string.
            Format(CalendarDefaultGlobalUXPageResource.
            CalendarDefaultGlobalUX_Page_SubFolder_Name_Xpath_Locator, activityDivId, k)), 1);

                    pixelValueToSrollDown = pixelValueToSrollDown + 100;
                }

                string getLessonName = base.GetElementTextByXPath(string.
                    Format(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SubFolder_Name_Xpath_Locator, activityDivId, k));
                if (activityName.Equals(getLessonName))
                {

                    try
                    {
                        //Drag and drop the activity on calendar frame
                        logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "DragAndDropTheActivity",
                               base.IsTakeScreenShotDuringEntryExit);
                        // Wait for the activity name 
                        base.WaitForElement(By.XPath(string.
                    Format(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SubFolder_Name_Xpath_Locator, activityDivId, k)));
                        //Drag the activity
                        IWebElement dragActivity = base.GetWebElementPropertiesByXPath
                            (string.
                    Format(CalendarDefaultGlobalUXPageResource.
                    CalendarDefaultGlobalUX_Page_SubFolder_Name_Xpath_Locator, activityDivId, k));
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
                               base.IsTakeScreenShotDuringEntryExit);
                    }
                    catch (Exception e)
                    {
                        ExceptionHandler.HandleException(e);
                    }

                    break;
                }

            }
        }
    
    }
}
