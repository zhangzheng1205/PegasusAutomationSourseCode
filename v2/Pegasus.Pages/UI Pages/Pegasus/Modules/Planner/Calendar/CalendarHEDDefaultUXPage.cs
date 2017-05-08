using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Planner.Calendar;
using Pegasus.Pages.Exceptions;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains details of Assignment Calender tab
    /// </summary>
    public class CalendarHedDefaultUxPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = Logger.GetInstance(typeof(CalendarHedDefaultUxPage));

        /// <summary>
        /// This the enum available for Show Dropdown type Enum
        /// </summary>
        public enum ShowDropdownTypeEnum
        {
            /// <summary>
            /// Show option for 'All Items' type
            /// </summary>
            AllItems = 1,
            /// <summary>
            /// Show option for 'Items Assigned' type
            /// </summary>
            ItemsAssigned = 2,
            /// <summary>
            /// Show option for 'Shown Items' type
            /// </summary>
            ShownItems = 3,
            /// <summary>
            /// Show option for 'Instructor Graded' type
            /// </summary>
            InstructorGraded = 4,
        }

        /// <summary>
        /// Clicks on the Todays View Option
        /// </summary>
        /// <param name="optionName">This is Option Name</param>
        public void ClickOnTodaysViewOption(string optionName)
        {
            //Clicking Todays View Option form then 'More' DropDown
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnTodaysViewOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //If More button Exist then Click
                if (base.IsElementPresent(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Button_More_Id_Locator),
                    Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_TimeToWaitForElement)))
                {
                    //Click on the More Drop Down
                    base.ClickButtonById(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_Button_More_Id_Locator);
                }
                //Click on the Drop Down Option Link
                base.ClickButtonByPartialLinkText(optionName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOnTodaysViewOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SearchTheActivity(String activityName)
        {
            //Search The Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SearchTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.RefreshTheCurrentPage();
                //Select Calendar Window
                this.SelectCalendarWindow();
                //Search Content
                this.SearchContent(activityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "SearchTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Content.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SearchContent(String activityName)
        {
            //Search Content
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SearchContent",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //this.EnterTheDayViewForAssignedActivity();
                //Enter text in the Search Text box
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Textbox_Search_Id_Locator));
                //Focus on the Text box
                base.FocusOnElementById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Textbox_Search_Id_Locator);
                base.ClearTextById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Textbox_Search_Id_Locator);
                base.FillTextBoxById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Textbox_Search_Id_Locator, activityName);
                //Click on the GO Button
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Search_Button_Id_Locator));
                IWebElement goButtonProperty = base.GetWebElementPropertiesById
                    (CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Search_Button_Id_Locator);
                base.ClickByJavaScriptExecutor(goButtonProperty);
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SleepTime));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "SearchContent",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Searched Activity Name.
        /// </summary>
        /// <returns>Searched Activity Name.</returns>
        public String GetSearchedActivityName()
        {
            //Get Searched Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetSearchedActivityName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getSearchedActivityName = string.Empty;
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Table_SearchedAssets_Id_Locator));
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator));
                //Get the Searched Activity Name
                getSearchedActivityName =
                    base.GetTitleAttributeValueById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetSearchedActivityName",
                base.IsTakeScreenShotDuringEntryExit);
            return getSearchedActivityName;
        }

        /// <summary>
        /// 'Drag And Drop' Activity to current date
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void DragAndDropActivityCurrentDate(String activityName)
        {
            //'Drag And Drop' Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "DragAndDropActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // this.EnterTheDayViewForAssignedActivity();
                string getAppDate = string.Empty;
                //Select Calendar Window
                this.SelectCalendarWindow();
                //Wait for the element
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator));
                IWebElement sourceActivity = base.
                    GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator);
                //Wait for the element  s
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Current_Day_Xpath_Locator));
                IWebElement destinationActivity = base.
                    GetWebElementPropertiesByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Current_Day_Xpath_Locator);
                base.PerformDragAndDropAction(sourceActivity, destinationActivity);
                //Wait for 10 Secs
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SleepTime));
                bool IframeExist = base.IsElementPresent(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_AssignmentCalendar_PropertiesWindow_Iframe_Id_Locator), 10);
                if (IframeExist == true)
                {
                    // Switch to iframe
                    base.SwitchToIFrameById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_AssignmentCalendar_PropertiesWindow_Iframe_Id_Locator);

                    IWebElement getOkButton = base.GetWebElementPropertiesById("_ctl0_InnerPageContent_btnYes");
                    base.ClickByJavaScriptExecutor(getOkButton);
                }
                //Wait for 10 Secs
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SleepTime));
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "DragAndDropActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// 'Drag And Drop' Activity to current date
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void DragAndDropActivity(String activityName)
        {
            //'Drag And Drop' Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "DragAndDropActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string getAppDate = string.Empty;
                //Select Calendar Window
                this.SelectCalendarWindow();
                //Wait for the element
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator));
                //Drag and Drop
                base.PerformClickAndHoldAction(base.
                    GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator));
                //Wait for the element
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Current_Day_Xpath_Locator));
                base.PerformMoveToElementClickAction(base.
                    GetWebElementPropertiesByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Current_Day_Xpath_Locator));
                //Wait for 10 Secs
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SleepTime));
                bool IframeExist = base.IsElementPresent(By.Id("iframeContentList"), 10);
                if (IframeExist == true)
                {
                    // Switch to iframe
                    base.SwitchToIFrameById("iframeContentList");

                    IWebElement getOkButton = base.GetWebElementPropertiesById("_ctl0_InnerPageContent_btnYes");
                    base.ClickByJavaScriptExecutor(getOkButton);
                }
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SleepTime));

            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "DragAndDropActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// 'Drag And Drop' Activity to current date
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void DragAndDropActivityFutureDate(String activityName)
        {
            //'Drag And Drop' Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "DragAndDropActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string getAppDate = string.Empty;
                //Get Current date
                DateTime date = DateTime.Today;
                string getDate = date.ToString("d");
                //Get the future date
                string getFutureDate = GetFutureDate(date);
                //Get the Total Activities Count
                bool exitLoop = false;
                int getRowCount = base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CalendarFrame_Day_Row_Count_XPathLocator);
                for (int i = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    i <= getRowCount && !exitLoop; ++i)
                {
                    int getColumCount = base.GetElementCountByXPath(string.Format(
                        CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPage_CalendarFrame_Day_Column_Count_XPathLocator, i));
                    for (int j = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                      CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                      j <= getColumCount; ++j)
                    {
                        getAppDate = base.GetTitleAttributeValueByXPath(string.Format(
                            CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPage_CalendarFrame_Date_XPathLocator, i, j));

                        if (getAppDate == getFutureDate)
                        {
                            this.SelectCalendarWindow();
                            base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                              CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator));
                            //Drag and Drop
                            base.PerformClickAndHoldAction(base.
                                GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                                CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator));
                            //Wait for the element
                            base.PerformMoveToElementClickAction(base.
                                GetWebElementPropertiesByXPath(string.Format(
                                CalendarHEDDefaultUXPageResource.
                                CalendarHEDDefaultUXPage_CalendarFrame_ExpectedDate_XPathLocator, i, j)));
                            //Wait for 10 Secs
                            Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                                CalendarHEDDefaultUXPage_SleepTime));
                            bool IframeExist = base.IsElementPresent(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_AssignmentCalendar_PropertiesWindow_Iframe_Id_Locator), 10);
                            if (IframeExist == true)
                            {
                                // Switch to iframe
                                base.SwitchToIFrameById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_AssignmentCalendar_PropertiesWindow_Iframe_Id_Locator);

                                IWebElement getOkButton = base.GetWebElementPropertiesById("_ctl0_InnerPageContent_btnYes");
                                base.ClickByJavaScriptExecutor(getOkButton);
                            }
                            Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                                CalendarHEDDefaultUXPage_SleepTime));
                            exitLoop = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "DragAndDropActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Assigned Activity Name On Current Day.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Assigned Activity Name.</returns>
        public String GetAssignedActivityNameBasedOnDay(string activityName, string dateType)
        {
            //Get Assigned Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetAssignedActivityNameOnCurrentDay",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getAssignedActivityName = string.Empty;
            try
            {
                switch (dateType)
                {
                    case "Current date":
                        //Enter the Day View for current date
                        this.EnterTheDayViewForAssignedActivity();
                        break;

                    case "Future date":
                        //Enter the Day View for future date
                        this.EnterTheDayViewForAssignedActivityForFutureDate();
                        break;

                    case "PastDue date":
                        this.EnterTheDayViewForAssignedActivityForPastDueDate();
                        break;
                }
                getAssignedActivityName = GetAssignedAvtivityNameInCalendarDayFrame(activityName);
                //Refresh Current Page
                base.RefreshTheCurrentPage();
                //Accept the Alert
                //  this.AcceptTheAlert();
                //wait for Calendar Window
                base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Calendar_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetAssignedActivityNameOnCurrentDay",
                base.IsTakeScreenShotDuringEntryExit);
            return getAssignedActivityName;
        }

        /// <summary>
        /// Get  Assigned Avtivity Name In Calendar Day Frame
        /// </summary>
        /// <param name="activityName">This is the Activity name.</param>
        /// <returns></returns>
        public string GetAssignedAvtivityNameInCalendarDayFrame(string activityName)
        {
            string getAssignedActivityName = string.Empty;
            //Get the Assigned Activity Name
            base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_Div_AssignedActivitiesInDayView_Xpath_Locator));
            //Get the Total Activities Count
            int getCountOfActivitiesAssigned =
                base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_Div_AssignedActivitiesInDayView_Xpath_Locator);
            for (int rowCount = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                rowCount <= getCountOfActivitiesAssigned; rowCount++)
            {
                bool hgd = base.IsElementPresent(By.XPath(string.Format(
                    ("//div[starts-with(@id, 'ctl00_ctl00_phBody_PageContent_calendarContainer_ucHEDDayView_RptPeriods_ctl00_Droppable_DivPeriod__')]/div[{0}]/div[1]/table/tbody/tr/td[3]/span"), rowCount)), 10);
                //Get the Activity Name
                getAssignedActivityName = base.GetElementTextByXPath(string.
                    Format("//div[starts-with(@id, 'ctl00_ctl00_phBody_PageContent_calendarContainer_ucHEDDayView_RptPeriods_ctl00_Droppable_DivPeriod__')]/div[{0}]/div[1]/table/tbody/tr/td[3]/span",
                    rowCount));
                if (getAssignedActivityName.Equals(activityName))
                {
                    getAssignedActivityName = activityName;
                    break;
                }
            }
            return getAssignedActivityName;
        }

        /// <summary>
        /// Get Assigned Activity Name On Current Day.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Assigned Activity Name.</returns>
        public String GetAssignedActivityNameOnCurrentDay(string activityName)
        {
            //Get Assigned Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetAssignedActivityNameOnCurrentDay",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getAssignedActivityName = string.Empty;
            try
            {
                //Enter the Day View
                this.EnterTheDayViewForAssignedActivity();
                //Get the Assigned Activity Name
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_AssignedActivitiesInDayView_Xpath_Locator));
                //Get the Total Activities Count
                int getCountOfActivitiesAssigned =
                    base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_AssignedActivitiesInDayView_Xpath_Locator);
                for (int rowCount = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    rowCount <= getCountOfActivitiesAssigned; rowCount++)
                {
                    //Get the Activity Name
                    getAssignedActivityName = base.GetElementTextByXPath(string.
                        Format(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPage_AssignedActivityNameInDayView_Xpath_Locator,
                        rowCount));
                    if (getAssignedActivityName.Contains(activityName))
                    {
                        getAssignedActivityName = activityName;
                        break;
                    }
                }
                //Refresh Current Page
                base.RefreshTheCurrentPage();
                //Accept the Alert
                this.AcceptTheAlert();
                //wait for Calendar Window
                base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Calendar_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetAssignedActivityNameOnCurrentDay",
                base.IsTakeScreenShotDuringEntryExit);
            return getAssignedActivityName;
        }

        /// <summary>
        /// Get Assigned Activity Name On Current Day.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Assigned Activity Name.</returns>
        public String GetAssignedActNameOnCurrentDayInAdvaceCalender(string activityName)
        {
            //Get Assigned Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetAssignedActivityNameOnCurrentDay",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getAssignedActivityName = string.Empty;
            try
            {

                //Get the Assigned Activity Name
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_AssignedActivitiesInDayView_Xpath_Locator));
                //Get the Total Activities Count
                int getCountOfActivitiesAssigned =
                    base.GetElementCountByXPath("//span[@class='dvAssignmentTitleCss']");
                for (int rowCount = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    rowCount <= getCountOfActivitiesAssigned; rowCount++)
                {
                    //Get the Activity Name
                    getAssignedActivityName = base.GetElementTextByXPath(string.
                        Format(CalendarHEDDefaultUXPageResource.CalendarHEDDefaultUXPage_AssignedActivityNameInDayView_Xpath_Locator,
                        rowCount));
                    if (getAssignedActivityName.Contains(activityName))
                    {
                        getAssignedActivityName = activityName;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetAssignedActivityNameOnCurrentDay",
                base.IsTakeScreenShotDuringEntryExit);
            return getAssignedActivityName;
        }

        /// <summary>
        /// Get Assigned Activity Name On Current Day.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Assigned Activity Name.</returns>
        public String GetAssignedActNameOnFutureDateInAdvaceCalender(string activityName)
        {
            //Get Assigned Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetAssignedActivityNameOnCurrentDay",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getAssignedActivityName = string.Empty;
            try
            {

                //Get the Assigned Activity Name
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_AssignedActivitiesInDayView_Xpath_Locator));
                //Get the Total Activities Count
                int getCountOfActivitiesAssigned =
                    base.GetElementCountByXPath("//span[@class='dvAssignmentTitleCss']");
                for (int rowCount = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    rowCount <= getCountOfActivitiesAssigned; rowCount++)
                {
                    //Get the Activity Name
                    getAssignedActivityName = base.GetElementTextByXPath(string.
                        Format(CalendarHEDDefaultUXPageResource.CalendarHEDDefaultUXPage_AssignedActivityNameInDayView_Xpath_Locator,
                        rowCount));
                    if (getAssignedActivityName.Contains(activityName))
                    {
                        getAssignedActivityName = activityName;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetAssignedActivityNameOnCurrentDay",
                base.IsTakeScreenShotDuringEntryExit);
            return getAssignedActivityName;
        }

        /// <summary>
        /// Accept The Alert.
        /// </summary>
        private void AcceptTheAlert()
        {
            //Accept The Alert
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "AcceptTheAlert",
                base.IsTakeScreenShotDuringEntryExit);
            Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_SleepTime));
            try
            {
                //Accept The Alert
                base.AcceptAlert();
            }
            catch
            { }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "AcceptTheAlert",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Day View For Assigned Activity.
        /// </summary>
        public void EnterTheDayViewForAssignedActivity()
        {
            //Enter The Day View For Assigned Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                if (base.IsElementPresent(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_AssignedActivityDay_Xpath_Locator),
                    Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_TimeToWaitForElement)))
                {
                    base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPage_AssignedActivityDay_Xpath_Locator));
                    IWebElement getDayViewImage = base.GetWebElementPropertiesByXPath
                        (CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPage_AssignedActivityDay_Xpath_Locator);
                    //Click on the Date to enter the Day view and see the assignments
                    base.ClickByJavaScriptExecutor(getDayViewImage);
                    Thread.Sleep(4000);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Day View For Assigned Activity.
        /// </summary>
        public void EnterTheDayViewForAssignedActivityAdvCal()
        {
            //Enter The Day View For Assigned Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                // Get the activity count 
                int getActivityCount = base.GetElementCountByXPath("//div[@class='dvDueAssignmentsTodayCss']/div[2]");
                bool test = base.IsElementPresent(By.XPath("//div[@id='ctl00_ctl00_phBody_PageContent_calendarContainer_ucHEDDayView_RptPeriods_ctl00_dvDueAssignmentsToday']/div[2]"), 10);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Day View For Assigned Activity.
        /// </summary>
        public void EnterTheDayViewForAssignedActivityForFutureDate()
        {
            //Enter The Day View For Assigned Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                bool exitLoop = false;
                string getAppDate = string.Empty;
                //Get current date
                DateTime date = DateTime.Today;
                string getDate = date.ToString("d");
                //Get the future date
                string getFutureDate = GetFutureDate(date);
                //Select Calendar Window
                this.SelectCalendarWindow();
                // Get row count
                int getRowCount = base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CalendarFrame_Day_Row_Count_XPathLocator);
                for (int i = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    i <= getRowCount && !exitLoop; i++)
                {
                    // Get the column count 
                    int getColumCount = base.GetElementCountByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CalendarFrame_Day_Column_Count_XPathLocator, i));
                    for (int j = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                      CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                      j <= getColumCount; j++)
                    {
                        // Get date from the application calendar
                        getAppDate = base.GetTitleAttributeValueByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CalendarFrame_Date_XPathLocator, i, j));
                        // Compare application date with the future date
                        if (getAppDate == getFutureDate)
                        {
                            this.SelectCalendarWindow();
                            base.WaitForElement(By.XPath(string.Format(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CalendarFrame_ExpectedDate_XPathLocator, i, j)));
                            IWebElement getDayViewImage = base.GetWebElementPropertiesByXPath
                                (string.Format(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CalendarFrame_ExpectedDate_XPathLocator, i, j));
                            //Click on the Date to enter the Day view and see the assignments
                            base.PerformMouseClickAction(getDayViewImage);
                            exitLoop = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add 5 days to the current date.
        /// </summary>
        /// <param name="date">This is the Current date.</param>
        /// <returns></returns>
        private string GetFutureDate(DateTime date)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "GetFutureDate",
                base.IsTakeScreenShotDuringEntryExit);
            //Add 5 days to current date
            DateTime fDate = date.AddDays(1);
            string getFutureDate = fDate.ToString("d");
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "GetFutureDate",
                base.IsTakeScreenShotDuringEntryExit);
            return getFutureDate;
        }


        /// <summary>
        /// Enter The Day View For Assigned Activity.
        /// </summary>
        public void EnterTheDayViewForAssignedActivityForFutureDateAdvCal()
        {
            //Enter The Day View For Assigned Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                bool exitLoop = false;
                string getAppDate = string.Empty;
                //Get CUrrent date
                DateTime date = DateTime.Today;
                string getDate = date.ToString("d");
                //Get the future date
                string getFutureDate = GetFutureDate(date);
                int getRowCount = base.GetElementCountByXPath("//table[@class ='rsContentTable']/tbody/tr");
                for (int i = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    i <= getRowCount && !exitLoop; i++)
                {
                    int getColumCount = base.GetElementCountByXPath(string.Format("//table[@class ='rsContentTable']/tbody/tr[{0}]/td", i));
                    for (int j = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                      CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                      j <= getColumCount; j++)
                    {
                        getAppDate = base.GetTitleAttributeValueByXPath(string.Format("//table[@class ='rsContentTable']/tbody/tr[{0}]/td[{1}]/div/div/a", i, j));

                        if (getAppDate == getFutureDate)
                        {
                            this.SelectCalendarWindow();

                            base.PerformMoveToElementClickAction(base.
                                GetWebElementPropertiesByXPath(string.Format("//table[@class ='rsContentTable']/tbody/tr[{0}]/td[{1}]", i, j)));
                            base.WaitForElement(By.XPath(string.Format("//table[@class ='rsContentTable']/tbody/tr[{0}]/td[{1}]", i, j)));
                            IWebElement getDayViewImage = base.GetWebElementPropertiesByXPath
                                (string.Format("//table[@class ='rsContentTable']/tbody/tr[{0}]/td[{1}]", i, j));
                            //Click on the Date to enter the Day view and see the assignments
                            base.ClickByJavaScriptExecutor(getDayViewImage);
                            exitLoop = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assign Activity Through Cmenu Option
        /// </summary>        
        public void AssignActivityThroughCmenuOption()
        {
            //Assign Activity Through Cmenu Option
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "AssignActivityThroughCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                //Click On the Assignment Properties
                this.ClickOnAssignmentProperties();
                //Assign the Activity
                new AssignContentPage().AssignTheActivityOnCurrentDate();
                //Select the Calendar Window
                base.SelectWindow(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Calendar_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "AssignActivityThroughCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'Assignment Properties'.
        /// </summary>
        public void ClickOnAssignmentProperties()
        {
            //Click On 'Assignment Properties'
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnAssignmentProperties",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator));
            //Click on the Cmenu Image
            base.PerformMouseHoverAction(base.
                    GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator));
            //Wait for the Cmenu Image            
            base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByClassName(
                CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_Image_Cmenu_Id_Locator));
            //Click On 'Assignment Properties' option            
            base.ClickByJavaScriptExecutor(base.
                GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_AssignmentProperties_Link_Id_Locator));
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOnAssignmentProperties",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Click The Support Link In Global Homepage
        /// </summary>
        /// <param name="userTypeEnum">This is User type</param>
        public void ClickTheSuportLinkInGlobalHomepage(User.UserTypeEnum userTypeEnum)
        {
            // Click The Support Link In Global Homepage
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickTheSuportLinkInGlobalHomepage",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Support_Link_Id_Locator));
                IWebElement getSupportLinkProperty = base.GetWebElementPropertiesById
                    (CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Support_Link_Id_Locator);
                //Click the support link
                base.ClickByJavaScriptExecutor(getSupportLinkProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickTheSuportLinkInGlobalHomepage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get UserName In Support Popup
        /// </summary>
        /// <returns>User name</returns>
        public String GetUserNameInSupportPopup()
        {
            //Get UserName In Support Popup
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetUserNameInSupportPopup",
                base.IsTakeScreenShotDuringEntryExit);
            //Initializing the variable
            String getUserName = string.Empty;
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Support_Window_Name);
                base.SelectWindow(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Support_Window_Name);
                //Wait for the element
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Support_Window_UserName_Id_Locator));
                getUserName = base.GetElementTextById
                     (CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Support_Window_UserName_Id_Locator);
                //Wait for the close button
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Support_Close_Button_Id_Locator));
                IWebElement getCloseButtonProperty = base.GetWebElementPropertiesById
                    (CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Support_Close_Button_Id_Locator);
                //Click the close button
                base.ClickByJavaScriptExecutor(getCloseButtonProperty);
                base.SelectDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetUserNameInSupportPopup",
                base.IsTakeScreenShotDuringEntryExit);
            //Returns User Name
            return getUserName;
        }

        /// <summary>
        /// Click On My Profile Link Option
        /// </summary>
        /// <param name="userType">This is User type</param>
        public void ClickOnMyProfileLink(User.UserTypeEnum userType)
        {
            //Click On My Profile Link Option
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnMyProfileLink",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userType)
                {
                    case User.UserTypeEnum.CsSmsInstructor:
                        base.SelectDefaultWindow();
                        break;
                    case User.UserTypeEnum.CsSmsStudent:
                        //Wait for Today's Veiw Window to Load
                        base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                               CalendarHEDDefaultUXPage_TodaysView_Window_Name);
                        //Select Today's Veiw Window
                        base.SelectWindow(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPage_TodaysView_Window_Name);
                        break;
                }
                //Wait for 10 seconds
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SleepTime));
                base.WaitForElement(By.PartialLinkText(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_MyProfile_Link_Locator));
                //Get My Profile Button Property
                IWebElement getMyProfileButtonProperty = base.
                    GetWebElementPropertiesByPartialLinkText
                    (CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_MyProfile_Link_Locator);
                //Click On My Profile Option
                base.ClickByJavaScriptExecutor(getMyProfileButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOnMyProfileLink",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Mutiple Assets
        /// </summary>
        public void SelectMultipleAssetsToDragAndDrop()
        {
            //Select Multiple Assets to Drag and Drop
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectMultipleAssetsToDragAndDrop",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Fetch SkillStudyplan From Memory
                Activity activityOne = Activity.Get(Activity.ActivityTypeEnum.SkillStudyPlan);
                //Fetch Link From Memory
                Activity activityTwo = Activity.Get(Activity.ActivityTypeEnum.Link);
                //Select Calendar Window
                this.SelectCalendarWindow();
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AssetCount_Xpath_Locator));
                //Get Asset Count
                int getAssetCount = base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AssetCount_Xpath_Locator);
                for (int i = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value); i <= getAssetCount; i++)
                {
                    base.WaitForElement(By.XPath(string.Format(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AssetName_Xpath_Locator, i)));
                    //Get Asset Name
                    string getAssetText =
                        base.GetElementTextByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AssetName_Xpath_Locator, i));
                    if (getAssetText == activityOne.Name || getAssetText == activityTwo.Name)
                    {
                        base.WaitForElement(By.XPath(string.Format(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_AssetName_CheckboxXpath_Locator, i)));
                        //Select Asset Checkbox
                        base.SelectCheckBoxByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_AssetName_CheckboxXpath_Locator, i));
                    }
                }

                //Select Drag and Drop Of Multiple Asset
                this.DragAndDropMultipleAssets(activityOne.Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectMultipleAssetsToDragAndDrop",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside Folder And SubFolder.
        /// </summary>
        private void NavigateInsideFolderAndSubFolder()
        {
            //Navigate Inside Folder And SubFolder
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "NavigateInsideFolderAndSubFolder",
              base.IsTakeScreenShotDuringEntryExit);
            //Click On Asset Root Folder
            this.ClickOnAsset(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_ActivityRootFolder_XPath_Locator);
            //Click On Asset Sub Folder
            this.ClickOnAsset(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_ActivitySubFolder_Xpath_Locator);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "NavigateInsideFolderAndSubFolder",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Drag and Drop Multiple Assets
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        private void DragAndDropMultipleAssets(string assetName)
        {
            //Select Drag and Drop of Multiple Assets
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "DragAndDropMultipleAssets",
              base.IsTakeScreenShotDuringEntryExit);
            //Get Asset Row Count
            int getRowCount = this.GetAssetRowCount(assetName);
            base.WaitForElement(By.XPath(string.Format(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_AssetName_Drag_Xpath_Locator, getRowCount)));
            base.FocusOnElementByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_AssetName_Drag_Xpath_Locator, getRowCount));
            //Perform Click and Hold Action
            base.PerformClickAndHoldAction(base.GetWebElementPropertiesByXPath
               (string.Format(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_AssetName_Drag_Xpath_Locator, getRowCount)));
            //Wait for the element
            base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_Current_Day_Xpath_Locator));
            //Perfofrm Move To Element Click Action
            base.PerformMoveToElementClickAction(base.
                GetWebElementPropertiesByXPath(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_Current_Day_Xpath_Locator));
            //Wait for 5 Secs
            Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_SleepTime));
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "DragAndDropMultipleAssets",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Asset Row Count.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        /// <returns>Asset Row Count.</returns>
        private int GetAssetRowCount(string assetName)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetAssetRowCount",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            int getAssetRowCount = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_DueDate_Row_Value);
            base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                     CalendarHEDDefaultUXPageResource_AssetCount_Xpath_Locator));
            //Get Asset Count
            int getAssetCount = base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_AssetCount_Xpath_Locator);
            for (int i = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value); i <= getAssetCount; i++)
            {
                base.WaitForElement(By.XPath(string.Format(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AssetName_Xpath_Locator, i)));
                //Get Asset Name
                string getAssetText =
                    base.GetElementTextByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AssetName_Xpath_Locator, i));
                if (getAssetText == assetName)
                {
                    getAssetRowCount = i;
                }
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetAssetRowCount",
             base.IsTakeScreenShotDuringEntryExit);
            return getAssetRowCount;
        }

        /// <summary>
        /// Click On Asset.
        /// </summary>
        /// <param name="locatorXpath">This is Xpath Locator.</param>
        private void ClickOnAsset(string locatorXpath)
        {
            //Click On Asset
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnAsset",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait for Xpath
            base.WaitForElement(By.XPath(locatorXpath));
            IWebElement getAssetProperty = base.GetWebElementPropertiesByXPath
                (locatorXpath);
            //Click on Asset
            base.ClickByJavaScriptExecutor(getAssetProperty);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOnAsset",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get My Profile Date
        /// </summary>
        /// <returns>My Profile Date</returns>
        public String GetMyProfileProfileDate()
        {
            //Get My Profile Date
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetMyProfileProfileDate",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getProfileDate = string.Empty;
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_MyProfile_Button_Id_Locator));
                IWebElement getButtonProperty = base.GetWebElementPropertiesById(
                    CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_MyProfile_Button_Id_Locator);
                //Click On My Profile Link
                base.ClickByJavaScriptExecutor(getButtonProperty);
                new MyAccountSettingPage().ChangeLocalePrefernces(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_LocaleOption_EnglishUnitedKingdom_Value);
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_DueDate_TextBox_Xpath_Locator));
                //Get My Profile Date
                getProfileDate = base.GetElementTextByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_DueDate_TextBox_Xpath_Locator);
                //Wait for Cancel Button
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefauktUXPage_CancelButton_Id_Locator));
                IWebElement getCancelButtonProperty = base.GetWebElementPropertiesById(
                    CalendarHEDDefaultUXPageResource.CalendarHEDDefauktUXPage_CancelButton_Id_Locator);
                //Click On Cancel Button
                base.ClickByJavaScriptExecutor(getCancelButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetMyProfileProfileDate",
              base.IsTakeScreenShotDuringEntryExit);
            return this.GetConvertedDate(getProfileDate);
        }

        /// <summary>
        /// Get Converted Date
        /// </summary>
        /// <param name="dateString">This is the Date</param>
        /// <returns>Sum of the Date, Month and Year</returns>
        public string GetConvertedDate(string dateString)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetConvertedDate",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variables
            int getDateString = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_DueDate_Row_Value);
            try
            {
                //Check if date contains backword slash
                string[] getDateValues = null;
                if (dateString.Contains(Convert.ToChar(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Backword_Slash_Character)))
                {
                    //Split based on the Special Character
                    getDateValues = dateString.Split(Convert.ToChar(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPage_Backword_Slash_Character));
                    for (int counter = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPage_DueDate_Row_Value);
                        counter < getDateValues.Length; counter++)
                    {
                        //Get the Sum of the Date,Month and Year 
                        getDateString += Convert.ToInt32(getDateValues[counter]);
                    }
                }
                //Check if date contains hyphen
                if (dateString.Contains(Convert.ToChar(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Hyphen_Character)))
                {
                    //Split based on the Special Character
                    getDateValues = dateString.Split(Convert.ToChar(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPage_Hyphen_Character));
                    for (int counter = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPage_DueDate_Row_Value);
                        counter < getDateValues.Length; counter++)
                    {
                        //Get the Sum of the Date,Month and Year
                        getDateString += Convert.ToInt32(getDateValues[counter]);
                    }

                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetConvertedDate",
                  base.IsTakeScreenShotDuringEntryExit);
            return getDateString.ToString();
        }

        /// <summary>
        /// Is Activity Due Date Status Present.
        /// </summary>
        /// <returns>Returns True if Activity Due Date Status or else False.</returns>
        public Boolean IsActivityDueDateStatusPresent()
        {
            //Is Activity Due Date Status Present
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "IsActivityDueDateStatusPresent",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isActivityDueDateStatusPresent = false;
            try
            {

                //Select Calendar Window
                this.SelectCalendarWindow();
                isActivityDueDateStatusPresent = base.IsElementPresent(
                    By.ClassName(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_ActivityStatus_ClassName_Locator));

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }


            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "IsActivityDueDateStatusPresent",
                   base.IsTakeScreenShotDuringEntryExit);
            return isActivityDueDateStatusPresent;
        }



        /// <summary>
        /// Select Option In View By Dropdown.
        /// </summary>
        /// <param name="viewByDropdownOption">This is View By Dropdown Option.</param>
        public void SelectOptionInViewByDropdown(string viewByDropdownOption)
        {
            //Select Option In View By Dropdown
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectOptionInViewByDropdown",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                //Wait For Element
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_ViewBy_Dropdown_Id_Locator));
                //Select Option In View By Dropdown
                base.SelectDropDownValueThroughTextById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_ViewBy_Dropdown_Id_Locator,
                    viewByDropdownOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectOptionInViewByDropdown",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Calendar Window.
        /// </summary>
        public void SelectCalendarWindow()
        {
            //Select Calendar Window
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectCalendarWindow",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPage_Calendar_WindowName);
                //Select the Window
                base.SelectWindow(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Calendar_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectCalendarWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Option In Show DropDown.
        /// </summary>
        /// <param name="showDropdownOption">This is Show Dropdown Option.</param>
        public void SelectOptionInShowDropDown(string showDropdownOption)
        {
            //Select Option In Show DropDown
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectOptionInShowDropDown",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                //Click On Show Dropdown And Get Option Count
                int getShowDropdownOptionCount = this.ClickOnShowDropdownAndGetOptionCount();
                for (int optionCount = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    optionCount <= getShowDropdownOptionCount; optionCount++)
                {
                    //Get Show Dropdown Option Text
                    string getOptionText = base.GetElementTextByXPath(string.Format(
                        CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_OptionText_Xpath_Locator, optionCount));
                    if (getOptionText == showDropdownOption)
                    {
                        //Select Checkbox
                        base.SelectCheckBoxByXPath(string.Format(
                            CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_Show_Dropdown_OptionCheckbox_Xpath_Locator,
                            optionCount));
                        base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_Apply_Button_Id_Locator));
                        //Click on Apply Button
                        IWebElement getApplyButton =
                            base.GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_Apply_Button_Id_Locator);
                        base.ClickByJavaScriptExecutor(getApplyButton);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectOptionInShowDropDown",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Show Dropdown And Get Option Count.
        /// </summary>
        /// <returns>Show Dropdown Option Count.</returns>
        private int ClickOnShowDropdownAndGetOptionCount()
        {
            //Click On Show Dropdown And Get Option Count
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "ClickOnShowDropdownAndGetOptionCount",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_Show_Dropdown_Id_Locator));
            //Click On Dropdown
            IWebElement getDropdown =
                base.GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_Show_Dropdown_Id_Locator);
            base.ClickByJavaScriptExecutor(getDropdown);
            base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_Show_Dropdown_OptionCount_Xpath_Locator));
            //Get Show Dropdown Option Count
            int getShowDropdownOptionCount =
                base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_Show_Dropdown_OptionCount_Xpath_Locator);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "ClickOnShowDropdownAndGetOptionCount",
              base.IsTakeScreenShotDuringEntryExit);
            return getShowDropdownOptionCount;
        }

        /// <summary>
        /// Select The Content Type.
        /// </summary>
        /// <param name="contentType">This is Content Type.</param>
        public void SelectTheContentType(string contentType)
        {
            //Select The Content Type
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectTheContentType",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Content_Count_Xpath_Locator));
                //Get Content Count
                int getContentCount = base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Content_Count_Xpath_Locator);
                for (int contentCount = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    contentCount <= getContentCount; contentCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_ContentType_Xpath_Locator, contentCount)));
                    //Get Content Type
                    string getContentType = base.GetElementTextByXPath(
                        string.Format(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_ContentType_Xpath_Locator, contentCount));
                    if (getContentType == contentType)
                    {
                        base.WaitForElement(By.XPath(string.Format(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_Content_Checkbox_Xpath_Locator,
                            contentCount)));
                        //Select Checkbox
                        base.SelectCheckBoxByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_Content_Checkbox_Xpath_Locator,
                            contentCount));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectTheContentType",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Contents Order In Course Content.
        /// </summary>
        /// <returns>Contents Name.</returns>
        public String GetContentsOrderInCourseContent()
        {
            //Get Contents Order In Course Content
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetContentsOrderInCourseContent",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getFirstContentName = string.Empty;
            string getSecondContentName = string.Empty;
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                //Navigate Inside Folder And SubFolder
                this.NavigateInsideFolderAndSubFolder();
                //Get First Content Name
                getFirstContentName = base.GetElementTextByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_FirstContent_Xpath_Locator);
                //Get Second Content Name
                getSecondContentName = base.GetElementTextByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_SecondContent_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetContentsOrderInCourseContent",
              base.IsTakeScreenShotDuringEntryExit);
            return (getFirstContentName + getSecondContentName);
        }

        /// <summary>
        /// Get Assigned Contents Order In Calendar.
        /// </summary>
        /// <returns>Assigned Contents Order.</returns>
        public String GetAssignedContentsOrderInCalendar()
        {
            //Get Assigned Content Order In Calendar
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "GetAssignedContentsOrderInCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable            
            string getAssignedContentsOrder = string.Empty;
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                //Get the Assigned Activity Name
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_AssignedActivitiesInDayView_Xpath_Locator));
                //Get the Total Activities Count
                int getCountOfActivitiesAssigned =
                    base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_AssignedActivitiesInDayView_Xpath_Locator);
                //Get The Order Of Assigned Activities
                getAssignedContentsOrder =
                    this.GetOrderOfAssignedActivities(getCountOfActivitiesAssigned);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "GetAssignedContentsOrderInCalendar",
              base.IsTakeScreenShotDuringEntryExit);
            return getAssignedContentsOrder;
        }

        /// <summary>
        /// Get Order Of Assigned Activities.
        /// </summary>
        /// <param name="getCountOfActivitiesAssigned">This is Activity Count.</param>
        /// <returns>Order Of Assigned Activities.</returns>
        private String GetOrderOfAssignedActivities(int getCountOfActivitiesAssigned)
        {
            //Get Order Of Assigned Activities
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetOrderOfAssignedActivities",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable 
            string getAssignedContentsOrder = string.Empty;
            int rowCount = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
           CalendarHEDDefaultUXPage_Loop_Initializer_Value);
            for (rowCount = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                rowCount <= getCountOfActivitiesAssigned; rowCount++)
            {
                //Get the Activity Name
                string getAssignedActivityName = base.GetElementTextByXPath(string.
                    Format(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_AssignedActivityNameInDayView_Xpath_Locator,
                    rowCount));
                if (getAssignedActivityName == CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_FirstActivity_Value)
                {
                    getAssignedContentsOrder = getAssignedActivityName;
                    rowCount++;
                    break;
                }
            }
            //Get Assigned Contents Order
            getAssignedContentsOrder += base.GetElementTextByXPath(string.
                     Format(CalendarHEDDefaultUXPageResource.
                     CalendarHEDDefaultUXPage_AssignedActivityNameInDayView_Xpath_Locator,
                     rowCount));
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetOrderOfAssignedActivities",
              base.IsTakeScreenShotDuringEntryExit);
            return getAssignedContentsOrder;
        }

        /// <summary>
        /// Select Content In Calendar.
        /// </summary>
        /// <param name="contentName">This is Content Name.</param>
        /// <param name="status">This is Status.</param>
        public void SelectContentInCalendar(string contentName, string status)
        {
            //Select Content In Calendar
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectContentInCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Check Expand Button And Navigate Inside Folders
                this.CheckExpandButtonAndNavigateInsideFolders();
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_ContentCount_Xpath_Locator));
                //Get Content Count
                int getContentCount = base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_ContentCount_Xpath_Locator);
                for (int rowCount = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    rowCount <= getContentCount; rowCount++)
                {
                    //Get Content Name
                    string getContentName = base.GetElementTextByXPath(string.Format(
                        CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_ContentName_Xpath_Locator, rowCount));
                    //Get Content Status
                    string getContentStatus = base.GetTitleAttributeValueByXPath(string.Format(
                        CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_ContentStatus_Xpath_Locator, rowCount));
                    if (getContentName == contentName && getContentStatus.Contains(status))
                    {
                        base.FocusOnElementByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_ContentCheckbox_Xpath_Locator, rowCount));
                        //Select Content Checkbox
                        base.SelectCheckBoxByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_ContentCheckbox_Xpath_Locator, rowCount));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectContentInCalendar",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check Expand Button And Navigate Inside Folders
        /// </summary>
        private void CheckExpandButtonAndNavigateInsideFolders()
        {
            //Check Expand Button And Navigate Inside Folders
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "CheckExpandButtonAndNavigateInsideFolders",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Calendar Window
            this.SelectCalendarWindow();
            if (base.IsElementPresent(By.XPath(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_Content_Expand_Button_Xpath_Locator),
                Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_TimeToWaitForElement)))
            {
                //Navigate Inside Folder And SubFolder
                this.NavigateInsideFolderAndSubFolder();
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "CheckExpandButtonAndNavigateInsideFolders",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button In Calendar.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        public void ClickOnButtonInCalendar(string buttonName)
        {
            //Click On Button In Calendar
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnButtonInCalendar",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AssignUnassign_Button_Id_Locator));
                //Click On 'Assign/Unassign' Button
                IWebElement getAssignUnassignButton = base.GetWebElementPropertiesById(
                    CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AssignUnassign_Button_Id_Locator);
                base.ClickByJavaScriptExecutor(getAssignUnassignButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOnButtonInCalendar",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Content Status.
        /// </summary>
        /// <param name="contentName">This is Content Name.</param>
        /// <param name="status">This is Content Status.</param>
        /// <returns>Content Status.</returns>
        public String GetContentStatus(string contentName, string status)
        {
            //Get Content Status
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetContentStatus",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string contentStatus = string.Empty;
            try
            {
                //Get Content Status
                this.SelectCalendarWindow();
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_ContentCount_Xpath_Locator));
                //Get Content Count
                int getContentCount = base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_ContentCount_Xpath_Locator);
                for (int rowCount = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    rowCount <= getContentCount; rowCount++)
                {
                    //Get Content Name
                    string getContentName = base.GetElementTextByXPath(string.Format(
                        CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_ContentName_Xpath_Locator, rowCount));
                    //Get Content Status
                    string getContentStatus = base.GetTitleAttributeValueByXPath(string.Format(
                        CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_ContentStatus_Xpath_Locator, rowCount));
                    if (getContentName == contentName && getContentStatus == status)
                    {
                        contentStatus = getContentStatus;
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetContentStatus",
              base.IsTakeScreenShotDuringEntryExit);
            return contentStatus;
        }

        /// <summary>
        /// Check Assign/Unassign Button Is In Disabled State.
        /// </summary>
        /// <returns>Assign/Unassign Button Status.</returns>
        public bool IsAssignUnassignButtonDisabled()
        {
            //Check Assign/Unassign Button Is In Disabled State
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "IsAssignUnassignButtonDisabled",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isAssignUnassignButtonDisabled = false;
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                if (base.IsElementPresent(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AssignUnassign_Button_DisabledState_Xpath_Locator),
                    Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_TimeToWaitForElement)))
                {
                    isAssignUnassignButtonDisabled = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "IsAssignUnassignButtonDisabled",
              base.IsTakeScreenShotDuringEntryExit);
            return isAssignUnassignButtonDisabled;
        }

        /// <summary>
        /// Click On View Advanced Calendar.
        /// </summary>
        public void ClickOnViewAdvancedCalendar()
        {
            //Click On View Advanced Calendar
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "ClickOnViewAdvancedCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_ViewAdvancedCalendar_Button_Id_Locator));
                //get View Advanced Calendar Button Property
                IWebElement getViewAdvancedCalendarProperty = base.
                    GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_ViewAdvancedCalendar_Button_Id_Locator);
                //Click On View Advanced Calendar Button
                base.ClickByJavaScriptExecutor(getViewAdvancedCalendarProperty);
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Element_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "ClickOnViewAdvancedCalendar",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Current Date.
        /// </summary>
        public void SelectCurrentDateFromCalendar()
        {
            //Select Current Date
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "SelectCurrentDateFromCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get Current Date Cell Property
                IWebElement getCurrentCellProperty = base.GetWebElementPropertiesByCssSelector
                    ("div[eventstartdatetime= '" + DateTime.Now.ToString("MM/dd/yyyy") + " 00:00:00']");
                //Click On Current Date Cell Property
                base.ClickByJavaScriptExecutor(getCurrentCellProperty);
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Element_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
             "SelectCurrentDateFromCalendar",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Assign Course Materials Text.
        /// </summary>
        /// <returns>Assign Course Materials Text</returns>
        public String GetAssignCourseMaterialsText()
        {
            //Get Assign Course Materials Text
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "GetAssignCourseMaterialsText",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssignCourseMaterialsText = string.Empty;
            try
            {
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                       CalendarHEDDefaultUXPageResource_AssignCourseMaterials_Id_Locator));
                //Get Assign Course Materials Text
                getAssignCourseMaterialsText = base.GetElementTextById
                    (CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AssignCourseMaterials_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
             "GetAssignCourseMaterialsText",
          base.IsTakeScreenShotDuringEntryExit);
            return getAssignCourseMaterialsText;

        }

        /// <summary>
        /// Get Day Month Week Text.
        /// </summary>
        /// <returns>Day Month Week Text</returns>
        public String GetDayWeekMonthText()
        {
            // Get Day Month Week Text
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "GetDayWeekMonthText",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable for Day
            string getdayText = string.Empty;
            //Initialize Variable for Week
            string getWeekText = string.Empty;
            //Initialize variable for Month
            string getMonthText = string.Empty;
            //Initialize variable for Day,week and month
            try
            {
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_Day_Id_Locator));
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Week_Id_Locator));
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Month_Id_Locator));
                //Get Day Text
                getdayText = base.GetElementTextById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Day_Id_Locator);
                //Get Week Text
                getWeekText = base.GetElementTextById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Week_Id_Locator);
                //Get Month Text
                getMonthText = base.GetElementTextById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Month_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
             "GetDayWeekMonthText",
          base.IsTakeScreenShotDuringEntryExit);
            return getdayText + getWeekText + getMonthText;
        }

        /// <summary>
        /// Get Assigned Count with Text.
        /// </summary>
        /// <returns>Assigned Count with Text.</returns>
        public String GetAssignedCountWithText()
        {
            //Get Assigned Count with Text
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "GetAssignedCountWithText",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssignedCountWithText = string.Empty;
            try
            {
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AssignedCountText_Id_Locator));
                //Get Assinged Count with Text
                getAssignedCountWithText = base.
                    GetElementTextById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AssignedCountText_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
             "GetAssignedCountWithText",
          base.IsTakeScreenShotDuringEntryExit);
            return getAssignedCountWithText;
        }

        /// <summary>
        /// Get Assigned Text In Calendar Frame.
        /// </summary>
        /// <returns>Assigned Text In Calendar Frame</returns>
        public String getAssignedTextInCalendarFrame()
        {
            //Get Assigned Text In Calendar Frame
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "getAssignedTextInCalendarFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssignedTextInCalendarFrame = string.Empty;
            try
            {
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AssignedText_Id_Locator));
                //Get Assigned Text In Calendar Frame
                getAssignedTextInCalendarFrame = base.
                    GetElementTextById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AssignedText_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
             "getAssignedTextInCalendarFrame",
          base.IsTakeScreenShotDuringEntryExit);
            return getAssignedTextInCalendarFrame;
        }

        /// <summary>
        /// Get Add Note Text.
        /// </summary>
        /// <returns>Add Note Text</returns>
        public String GetAddNoteText()
        {
            //Get Add Note Text
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetAddNoteText",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAddNoteText = string.Empty;
            try
            {
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AddNote_Xpath_Locator));
                //Get Add Note Text
                getAddNoteText = base.GetValueAttributeByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNote_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetAddNoteOption",
              base.IsTakeScreenShotDuringEntryExit);
            return getAddNoteText;
        }

        /// <summary>
        /// Click On Calendar Icon
        /// </summary>
        public void ClickOnCalendarIcon()
        {
            //Click On Calendar Icon
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnCalendarIcon",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.ClassName(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_CalendarIcon_Id_Locator));
                //Get Calendar Icon Property
                IWebElement getCalendarIconProperty = base.GetWebElementPropertiesByClassName(
                    CalendarHEDDefaultUXPageResource.CalendarHEDDefaultUXPageResource_CalendarIcon_Id_Locator);
                //Click On Calendar Icon
                base.ClickByJavaScriptExecutor(getCalendarIconProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOnCalendarIcon",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Set Scheduling Options' Cmenu.
        /// </summary>
        public void SelectSetSchedulingOptionsCmenu()
        {
            //Select 'Set Scheduling Options' Cmenu
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "SelectSetSchedulingOptionsCmenu",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                //Wait for the element
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator));
                //Mouse Hover On Asset
                base.PerformMouseHoverAction(base.
                        GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator));
                //Click on the Cmenu Image        
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByClassName(
                    CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Image_Cmenu_Id_Locator));
                //Click On 'Set Scheduling Options' option            
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_SetSchedulingOptions_Id_Locator));
                //Get Element Property
                IWebElement getCmenuOptionProperty =
                    base.GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_SetSchedulingOptions_Id_Locator);
                //Click On 'Set Scheduling Options' Cmenu Option
                base.ClickByJavaScriptExecutor(getCmenuOptionProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "SelectSetSchedulingOptionsCmenu",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The ContentType From ShowDropdown.
        /// </summary>
        /// <param name="showDropdownTypeEnum">This is Show dropdown option.</param>
        public void SelectTheContentTypeFromShowDropdown(
            ShowDropdownTypeEnum showDropdownTypeEnum)
        {
            //Select The ContentType From ShowDropdown.
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "SelectTheContentTypeFromShowDropdown",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Calendar Window
            this.SelectCalendarWindow();
            //Click The Show Dropdown
            this.ClickTheShowDropdown();
            switch (showDropdownTypeEnum)
            {
                case ShowDropdownTypeEnum.AllItems:
                    //Select All Items option
                    this.SelectAllItemsOption();
                    break;
                case ShowDropdownTypeEnum.ItemsAssigned:
                    //Select Items Assigned option
                    this.SelectItemsAssignedOption();
                    break;
                case ShowDropdownTypeEnum.ShownItems:
                    //Select Shown Items option
                    this.SelectShownItemsOption();
                    break;
                case ShowDropdownTypeEnum.InstructorGraded:
                    //Select Instructor Graded option
                    this.SelectInstructorGradedOption();
                    break;
            }
            //Click The 'Apply' button
            this.ClickTheApplyButton();
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "SelectTheContentTypeFromShowDropdown",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Instructor Graded option.
        /// </summary>
        private void SelectInstructorGradedOption()
        {
            //Select Instructor Graded option
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "SelectInstructorGradedOption",
                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for the 'Instructor Graded' options
            base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_InstructorGraded_Id_Locator));
            IWebElement getAllItems = base.GetWebElementPropertiesById
                (CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_InstructorGraded_Id_Locator);
            //Click on 'Instructor Graded' option
            base.ClickByJavaScriptExecutor(getAllItems);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "SelectInstructorGradedOption",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Shown Items option.
        /// </summary>
        private void SelectShownItemsOption()
        {
            //Select Shown Items option
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "SelectShownItemsOption",
                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for the 'Shown Items' options
            base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_ShownItems_Option_Id_Locator));
            IWebElement getAllItems = base.GetWebElementPropertiesById
                (CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_ShownItems_Option_Id_Locator);
            //Click on 'Shown Items' option
            base.ClickByJavaScriptExecutor(getAllItems);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "SelectShownItemsOption",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Items Assigned Option.
        /// </summary>
        private void SelectItemsAssignedOption()
        {
            //Select Items Assigned Option
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "SelectItemsAssignedOption",
                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for the 'Items Assigned' options
            base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_ItemsAssigned_Option_Id_Locator));
            IWebElement getAllItems = base.GetWebElementPropertiesById
                (CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_ItemsAssigned_Option_Id_Locator);
            //Click on 'Items Assigned' option
            base.ClickByJavaScriptExecutor(getAllItems);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "SelectItemsAssignedOption",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Apply Button.
        /// </summary>
        private void ClickTheApplyButton()
        {
            //Click The Apply Button
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "ClickTheApplyButton",
                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for the 'Apply' options
            base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_Show_Apply_Button_Id_Locator));
            IWebElement getApplyButton = base.GetWebElementPropertiesById
                (CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_Show_Apply_Button_Id_Locator);
            //Click on 'Apply' button
            base.ClickByJavaScriptExecutor(getApplyButton);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "ClickTheApplyButton",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select All Items Option.
        /// </summary>
        private void SelectAllItemsOption()
        {
            //Select All Items Option
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "SelectAllItemsOption",
                  base.IsTakeScreenShotDuringEntryExit);
            //Wait for the 'All Items' options
            base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_AllItems_Option_Id_Locator));
            IWebElement getAllItems = base.GetWebElementPropertiesById
                (CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_AllItems_Option_Id_Locator);
            //Click on 'All Items' option
            base.ClickByJavaScriptExecutor(getAllItems);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "SelectAllItemsOption",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Show Dropdown.
        /// </summary>
        private void ClickTheShowDropdown()
        {
            //Click The Show Dropdown
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                  "ClickTheShowDropdown",
                         base.IsTakeScreenShotDuringEntryExit);
            //Wait for the 'Showdropdown' element
            base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
               CalendarHEDDefaultUXPageResource_Show_Dropdown_Id_Locator));
            IWebElement getShowdropdown = base.GetWebElementPropertiesById
                (CalendarHEDDefaultUXPageResource.
                  CalendarHEDDefaultUXPageResource_Show_Dropdown_Id_Locator);
            //Click on 'Show' dropdown
            base.ClickByJavaScriptExecutor(getShowdropdown);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                   "ClickTheShowDropdown",
                         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Message From Assignment Calendar Tab.
        /// </summary>
        /// <param name="message">this is Display of message.</param>
        /// <returns>Message.</returns>
        public String GetMessageFromAssignmentCalendarTab(string message)
        {
            //Get Message From Assignment Calendar Tab
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "GetMessageFromAssignmentCalendarTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getMessageValidate = string.Empty;
            try
            {
                //Get message
                getMessageValidate = base.GetElementTextByClassName(
                    CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_FailureMessage_Classname_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "GetMessageFromAssignmentCalendarTab",
            base.IsTakeScreenShotDuringEntryExit);
            return getMessageValidate;
        }

        /// <summary>
        /// Expands the node.
        /// </summary>
        /// <param name="nodeId">Id of the node.</param>
        public void ExpandNode(string nodeId)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "ExpandNode",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(string.Format(CalendarHEDDefaultUXPageResource
                .CalendarHEDDefaultUXPage_ContainerAssets_Title_Xpath_Locator, nodeId)));
            IWebElement nodeLink = base.GetWebElementPropertiesByXPath(string
                .Format(CalendarHEDDefaultUXPageResource
                .CalendarHEDDefaultUXPage_ContainerAssets_Title_Xpath_Locator, nodeId));
            base.ClickByJavaScriptExecutor(nodeLink);

            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
               "ExpandNode",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Is node expanded or not.
        /// </summary>
        /// <param name="nodeId">Id of the node.</param>
        /// <returns></returns>
        public bool IsNodeExpanded(string nodeId)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "IsNodeExpanded",
               base.IsTakeScreenShotDuringEntryExit);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
               "IsNodeExpanded",
               base.IsTakeScreenShotDuringEntryExit);
            return base.IsElementEnabledById(CalendarHEDDefaultUXPageResource
               .CalendarHEDDefaultUXPage_ContainerAssets_Id_Locator + nodeId);
        }

        /// <summary>
        /// Is Assigned/Unassigned link button enabled or not.
        /// </summary>
        /// <returns></returns>
        public bool IsAssignedUnAssignedButtonEnabled()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "IsAssignedUnAssignedButtonEnabled",
               base.IsTakeScreenShotDuringEntryExit);
            bool isAssignButtonEnabled = false;
            try
            {
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource
                        .CalendarHEDDefaultUXPage_AssignUnAssign_Link_Id_Locator));
                isAssignButtonEnabled = base.IsElementEnabledById(CalendarHEDDefaultUXPageResource
                      .CalendarHEDDefaultUXPage_AssignUnAssign_Link_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
               "IsAssignedUnAssignedButtonEnabled",
               base.IsTakeScreenShotDuringEntryExit);
            return isAssignButtonEnabled;
        }

        /// <summary>
        /// Selects the checkbox of the activity.
        /// </summary>
        /// <param name="assetCount">Number of activities to be selected.</param>
        /// <param name="containerNodeId">Node Id of the container node.</param>
        public void SelectCheckBoxOfActivity(int assetCount, string containerNodeId)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "SelectCheckBoxOfActivity",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {

                ICollection<IWebElement> checkBoxList = base
                    .GetWebElementsCollectionByXPath(string.Format(
                    CalendarHEDDefaultUXPageResource
                    .CalendarHEDDefaultUXPage_ContainerAssets_Checkbox_Xpath_Locator,
                    containerNodeId));
                if (checkBoxList == null) return;
                int counter = 0;
                foreach (IWebElement checkBox in checkBoxList)
                {
                    string checkBoxId = checkBox.GetAttribute(
                        CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_CheckBox_Attribute_Value);
                    base.FocusOnElementById(checkBoxId);
                    base.ClickByJavaScriptExecutor(checkBox);
                    this.StoreAssignUnAssignActivityInMemory(
                        checkBoxId.Split('_')[1]);
                    ++counter;
                    if (counter >= assetCount) break;
                }

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
               "SelectCheckBoxOfActivity",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on Assign/Unassign link button.
        /// </summary>
        public void ClickOnAssignUnassignButton()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "ClickOnAssignUnassignButton",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement getAssignInassignButton = base.GetWebElementPropertiesById(
                   CalendarHEDDefaultUXPageResource
                       .CalendarHEDDefaultUXPage_AssignUnAssign_Link_Id_Locator);
                base.ClickByJavaScriptExecutor(getAssignInassignButton);
                // accept alert in case appears
                if (base.IsPopupPresent("Pegasus", 5))
                {
                    base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesById("imgOk"));
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
               "ClickOnAssignUnassignButton",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Is asset assigned or not.
        /// </summary>
        /// <param name="assetId">Asset id.</param>
        /// <returns></returns>
        public bool IsAssetAssigned(string assetId)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "IsAssetAssigned",
               base.IsTakeScreenShotDuringEntryExit);
            // select the calendar window
            try
            {
                this.SelectCalendarWindow();
                if (base.IsElementPresent(By.XPath((
                    string.Format(CalendarHEDDefaultUXPageResource
                        .CalendarHEDDefaultUXPage_Asset_AssignStatus_Assigned_Img_Xpath_Locator, assetId)))))
                {
                    IWebElement assignStatusImage = base.GetWebElementPropertiesByXPath(
                        string.Format(CalendarHEDDefaultUXPageResource
                            .CalendarHEDDefaultUXPage_Asset_AssignStatus_Assigned_Img_Xpath_Locator, assetId));
                    if (assignStatusImage == null) return false;
                    string assignStatusCss = assignStatusImage.GetAttribute("class");
                    if (assignStatusCss == CalendarHEDDefaultUXPageResource
                        .CalendarHEDDefaultUXPage_AssignStatus_Assigned_Class_Locator
                        || assignStatusCss == CalendarHEDDefaultUXPageResource
                            .CalendarHEDDefaultUXPage_AssignStatus_AssignedDueDate_Class_Locator)
                        return true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return false;
        }

        /// <summary>
        /// Stores the activity in memory with Assign/Unassigned status.
        /// </summary>
        /// <param name="activityId">Id of the activity.</param>
        private void StoreAssignUnAssignActivityInMemory(string activityId)
        {
            Activity activity = new Activity()
            {
                ActivityId = activityId,
                IsAssigned = IsAssetAssigned(activityId),
                IsCreated = true
            };
            activity.StoreActivityInMemory();

        }

        /// <summary>
        /// Gets the asset id of asset.
        /// </summary>
        /// <param name="assetName">Asset name.</param>
        /// <returns></returns>
        public string GetAssetId(string assetName)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
              "GetAssetId",
              base.IsTakeScreenShotDuringEntryExit);
            return base.GetWebElementPropertiesByXPath(
               string.Format(CalendarHEDDefaultUXPageResource
                 .CalendarHEDDefaultUXPage_Assets_Title_Xpath_Locator, assetName))
                 .FindElement(By.XPath(".."))
                 .GetAttribute(CalendarHEDDefaultUXPageResource
                 .CalendarHEDDefaultUXPage_NodeId_Value);
        }
        /// <summary>
        /// Verify if the current date is highlighted in the calendar frame.
        /// </summary>
        /// <returns>Return the current date value highlighted.</returns>
        public Boolean IsCurrentDateHighlighted()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "IsCurrentDayHighlighted",
               base.IsTakeScreenShotDuringEntryExit);
            //Declaring a variable
            bool isCurrentDateHighlighted = false;
            try
            {
                // select the calendar window
                this.SelectCalendarWindow();
                isCurrentDateHighlighted = base.IsElementPresent(By.CssSelector(".HighlightTodayCell"));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "IsCurrentDayHighlighted",
                base.IsTakeScreenShotDuringEntryExit);
            return isCurrentDateHighlighted;
        }

        /// <summary>
        /// Get the Folder Name.
        /// </summary>
        /// <returns>Asset Name.</returns>    
        public string GetActualFolderName(string folderName)
        {
            //Get the Folder Name
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "GetActualFolderName",
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize getStatusText variable
            IWebElement actualFolderAssetName = null;
            try
            {
                // select Calendar Window
                this.SelectCalendarWindow();
                //Get the inner text of the folder
                actualFolderAssetName =
                    GetWebElementPropertiesByXPath(String.Format(
                    CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_HSS_FoldetName_XPath_Locator,
                    folderName));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("StudentPresentationPage",
              "GetActualFolderName",
                  base.IsTakeScreenShotDuringEntryExit);
            return actualFolderAssetName.Text.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Drag and drop 'Word Chapter 1: Simulation Activities' folder to current date.
        /// </summary>
        public void DragAndDropWordFolderAsset()
        {
            // Drag and drop 'Word Chapter 1: Simulation Activities' folder to current date
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "DragAndDropWordFolderAsset",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                //Wait for the element
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource
                    .CalendarHEDDefaultUXPage_WordChapter1SimulationActivitiesFolder_Xpath_Locator));
                //Drag and Drop
                base.PerformClickAndHoldAction(base.
                    GetWebElementPropertiesByXPath(CalendarHEDDefaultUXPageResource
                    .CalendarHEDDefaultUXPage_WordChapter1SimulationActivitiesFolder_Xpath_Locator));
                //Wait for the element
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Current_Day_Xpath_Locator));
                base.PerformMoveToElementClickAction(base.
                    GetWebElementPropertiesByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Current_Day_Xpath_Locator));
                // Releasing an element after clicking and holding it
                base.PerformReleaseAction();
                //Wait for 5 Secs
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SleepTime));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "DragAndDropWordFolderAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Drag and drop an asset.
        /// </summary>
        public void DragAndDropFolderAsset(string activityName)
        {
            // Drag and drop 'Word Chapter 1: Simulation Activities' folder to current date
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "DragAndDropWordFolderAsset",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                // drag and drop the element
                base.DragAndDropWebElement(base.GetWebElementPropertiesByXPath((String.Format(
                     CalendarHEDDefaultUXPageResource.
                     CalendarHEDDefaultUXPageResource_DragNDrop_Asset_XPath_Locator,
                     activityName))), base.GetWebElementPropertiesByCssSelector
                     ("div[eventstartdatetime= '" + DateTime.Now.ToString("MM/dd/yyyy") + " 00:00:00']"));
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.CalendarHEDDefaultUXPage_SleepTime));

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "DragAndDropWordFolderAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifying Start Date Flag Element Present or not.
        /// </summary>
        /// <returns>Start date value.</returns>
        public Boolean IsStartDateFlagDisplayed()
        {
            //Verifying Start Date Flag Element Present or not
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "IsStartDateFlagDisplayed",
                base.IsTakeScreenShotDuringEntryExit);
            //Intialize the value
            Boolean isStartDateFlagDisplayed = false;
            try
            {
                //Select the calendar window
                base.RefreshTheCurrentPage();
                this.SelectCalendarWindow();
                base.WaitForElement(By.ClassName(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_FlagImage_Class_Locator));
                // Verify Start Date Icon by Is True Assert
                isStartDateFlagDisplayed = base.IsElementPresent(By.ClassName
                    (CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_FlagImage_Class_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                           "IsStartDateFlagDisplayed",
                           base.IsTakeScreenShotDuringEntryExit);
            return isStartDateFlagDisplayed;
        }

        /// <summary>
        /// Drag and Drop selected multiple assets to current date. 
        /// </summary>
        public void DragAndDropMultipleActivities(string activityName)
        {
            //Drag and Drop selected multiple assets to current date
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "DragAndDropMultipleExcelActivities",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SleepTime));
                IWebElement element = WebDriver.FindElement(By.XPath(String.Format(CalendarHEDDefaultUXPageResource.
                      CalendarHEDDefaultUXPageResource_MultipleAsset_Xpath_Locator, activityName)));
                IWebElement target = base.GetWebElementPropertiesByCssSelector
                      ("div[eventstartdatetime= '" + DateTime.Now.ToString("MM/dd/yyyy") + " 00:00:00']");
                //Drag and drop the element
                base.DragAndDropWebElement(element, target);
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SleepTime));

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "DragAndDropMultipleExcelActivities",
                base.IsTakeScreenShotDuringEntryExit);
        }


        public void DragAndDropMultipleExcelActivities()
        {
            //Drag and Drop selected 'Excel Chapter 1: Simulation Activities' assets to current date
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "DragAndDropMultipleExcelActivities",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SleepTime));
                //Wait for the element
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_ExcelSkillBasedTrainingAsset_Xpath_Locator));
                IWebElement element = WebDriver.FindElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_ExcelSkillBasedTrainingAsset_Xpath_Locator));
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPage_Current_Day_Xpath_Locator));
                IWebElement target = WebDriver.FindElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Current_Day_Xpath_Locator));
                //Drag and drop the element
                base.DragAndDropWebElement(element, target);
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SleepTime));

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "DragAndDropMultipleExcelActivities",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Cmenu of the activity.
        /// </summary>
        /// <param name="cmenuOption">This is the Cmenu option.</param>
        /// <param name="assetName">This is the name of the asset.</param>
        public void SelectActivityCmenu(string cmenuOption, string assetName)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectActivityCmenu",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Calendar window
                this.SelectCalendarWindow();
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Element_Time));
                //Focus on the asset
                base.PerformFocusOnElementActionByXPath(String.Format(CalendarHEDDefaultUXPageResource
                 .CalendarHEDDefaultUXPage_Assets_Title_Xpath_Locator, assetName));
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Element_Time));
                //Get the cmenuid of the asset
                string cMenuId = GetCMenuId(assetName);
                // Select an option in cmenu
                this.SelectOptionInCmenu(cmenuOption, cMenuId);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectActivityCmenu",
               base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Select an option in cmenu.
        /// </summary>
        /// <param name="cmenuOption">This is the option to be selected.</param>
        /// <param name="cMenuId">This is the asset's cmenu id.</param>
        private void SelectOptionInCmenu(string cmenuOption, string cMenuId)
        {
            // Select an option in cmenu
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectOptionInCmenu",
              base.IsTakeScreenShotDuringEntryExit);

            IWebElement getCMenu = base.GetWebElementPropertiesByXPath(String.
                Format((CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_Cmenu_XPath_Locator), cMenuId));
            Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
              CalendarHEDDefaultUXPage_Element_Time));
            base.PerformMouseHoverByJavaScriptExecutor(getCMenu);
            base.ClickByJavaScriptExecutor(getCMenu);
            Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
               CalendarHEDDefaultUXPage_Element_Time));
            //Get the ID value of the cmenu

            base.WaitForElement(By.CssSelector(
               "div[class='Classcmenu_main'][style~='absolute;']"));
            IWebElement getCmenuOption = base.GetWebElementPropertiesByCssSelector(
                 "div[class='Classcmenu_main'][style~='absolute;']");
            string idValue = getCmenuOption.GetAttribute(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_Properties_Attribute);
            //Click on activity cmenu option

            base.WaitForElement(By.CssSelector(string.Format(
               "div[id='{0}'] div[id='cmenuCont'] div[title='{1}']",
                idValue, cmenuOption)));
            IWebElement cMenuOption = base.GetWebElementPropertiesByCssSelector(String.
                Format(("div[id='{0}'] div[id='cmenuCont'] div[title='{1}']"),
                idValue, cmenuOption));
            Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_Element_Time));
            base.PerformMouseHoverAction(cMenuOption);
            base.PerformMouseClickAction(cMenuOption);
            //base.ClickByJavaScriptExecutor(cMenuOption);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectOptionInCmenu",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Returns the cmenu id of the asset.
        /// </summary>
        /// <param name="assetName">This is the asset name.</param>
        /// <returns>The cmenu id.</returns>
        private string GetCMenuId(string assetName)
        {
            // Returns the cmenu id of the asset
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetCMenuId",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(string.Format(CalendarHEDDefaultUXPageResource
             .CalendarHEDDefaultUXPage_Assets_Title_Xpath_Locator, assetName)));
            IWebElement getAsset = base.GetWebElementPropertiesByXPath(
           string.Format(CalendarHEDDefaultUXPageResource
             .CalendarHEDDefaultUXPage_Assets_Title_Xpath_Locator, assetName));
            Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
               CalendarHEDDefaultUXPage_Element_Time));
            //Mouseover on the asset
            base.PerformMouseHoverByJavaScriptExecutor(getAsset);
            Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
               CalendarHEDDefaultUXPage_Element_Time));
            //Click on cmenu of the asset
            IWebElement Parent = base.GetWebElementPropertiesByXPath(String
     .Format(CalendarHEDDefaultUXPageResource.
     CalendarHEDDefaultUXPageResource_AssetParentNode_Xpath_Locator, assetName));
            string nodeId = Parent.GetAttribute("nodeid");
            string cMenuId = "cmenuLN_gtRow_" + nodeId;
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetCMenuId",
               base.IsTakeScreenShotDuringEntryExit);
            return cMenuId;
        }

        /// <summary>
        /// Verify the Due Date Icon Dispaly.
        /// </summary>
        /// <returns>Display of icon in calendar.</returns>
        public Boolean IsDueDateIconPresentInCalendar()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "IsDueDateIconPresentInCalendar",
                            base.IsTakeScreenShotDuringEntryExit);
            bool isDueDateIcon = false;
            try
            {
                //Refresh the page
                base.RefreshTheCurrentPage();
                //Select Calendar Window
                this.SelectCalendarWindow();
                //Verify Due date icon display
                isDueDateIcon = base.IsElementPresent(By.XPath(
                    CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaulPageResource_DueDateIcon_Xpath_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "IsDueDateIconPresentInCalendar",
                           base.IsTakeScreenShotDuringEntryExit);
            return isDueDateIcon;
        }

        /// <summary>
        /// Verify the check mark in calendar after assigning.
        /// </summary>
        /// <returns>Display of checkmark.</returns>
        public Boolean IsCheckMarkDisplayedInCalendar()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "IsCheckMarkDisplayedInCalendar",
                            base.IsTakeScreenShotDuringEntryExit);
            bool isCheckMarkIconDisplayed = false;
            try
            {
                this.SelectCalendarWindow();
                isCheckMarkIconDisplayed = base.IsElementPresent(By.XPath
                    (CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaulPageResource_CheckMarkIcon_Xpath));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "IsCheckMarkDisplayedInCalendar",
                           base.IsTakeScreenShotDuringEntryExit);
            return isCheckMarkIconDisplayed;
        }

        /// <summary>
        /// Get the asset inner text.
        /// </summary>
        /// <param name="assetName">This is a asset name.</param>
        /// <returns>Asset inner text assigned.</returns>
        public string GetAssignAssetText(string assetName)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "GetAssignAssetText",
              base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            try
            {

                //Get the total no of assets assigned count
                int getRowCount = base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_DayViewAssetRecords_Xpath_Locator);
                for (int row = 1; row <= getRowCount; row++)
                {

                    base.WaitForElement(By.XPath(String.Format
                        (CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_DayViewAssetName_Xpath_Locator, row)));
                    //Get the asset inner text
                    getActivityName = base.GetElementInnerTextByXPath(String.Format
                        (CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_DayViewAssetName_Xpath_Locator, row));
                    //Compare asset name with the inner text
                    if (getActivityName.Contains(assetName))
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
               "GetAssignAssetText",
              base.IsTakeScreenShotDuringEntryExit);
            return getActivityName.Trim();
        }

        /// <summary>
        /// Selects the checkbox of the activity.
        /// </summary>
        /// <param name="assetCount">Number of activities to be selected.</param>
        /// <param name="containerNodeId">Node Id of the container node.</param>
        public void VerifyAssignCheck(int assetCount, string containerNodeId)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "SelectCheckBoxOfActivity",
               base.IsTakeScreenShotDuringEntryExit);

            ICollection<IWebElement> checkBoxList = base
                .GetWebElementsCollectionByXPath(string.Format(
                CalendarHEDDefaultUXPageResource
                .CalendarHEDDefaultUXPage_ContainerAssets_Checkbox_Xpath_Locator,
                containerNodeId));
            if (checkBoxList == null) return;
            int counter = 0;
            foreach (IWebElement checkBox in checkBoxList)
            {
                string checkBoxId = checkBox.GetAttribute("id");
                base.FocusOnElementById(checkBoxId);
                base.ClickByJavaScriptExecutor(checkBox);
                this.StoreAssignUnAssignActivityInMemory(
                    checkBoxId.Split('_')[1]);
                ++counter;
                if (counter >= assetCount) break;
            }

            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
               "SelectCheckBoxOfActivity",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the schedule checkmark beside the activity name.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="divisionId">This is the HTML division id.</param>
        /// <returns>Bool value for display of schedule checkmark. </returns>
        public bool IsScheduleCheckMarkDisplayedBesideAsset(string activityName, string divisionId)
        {
            // Verify the schedule checkmark beside the activity name
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
              "IsScheduleCheckMarkDisplayedBesideAsset",
              base.IsTakeScreenShotDuringEntryExit);
            bool isPresentScheduleCheck = false;
            try
            {
                int Count = base.GetElementCountByXPath(String.
                       Format(CalendarHEDDefaultUXPageResource.
                       CalendarHEDDefauktUXPage_AssetPropertiesCount_Xpath_Locator, divisionId));
                for (int i = 1; i <= Count; i++)
                {
                    String getActivityName = base.GetTitleAttributeValueByXPath(String.
                        Format(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefauktUXPage_AssetName_Xpath_Locator, divisionId, i));
                    if (getActivityName == activityName)
                    {
                        // Verify the schedule checkmark beside the activity name
                        isPresentScheduleCheck = base.IsElementPresent(By.XPath(String.
                            Format(CalendarHEDDefaultUXPageResource.
                           CalendarHEDDefauktUXPage_AssetScheduleCheckMark_Xpath_Locator, divisionId, i)), 10);
                        break;
                    }
                }
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
               "IsScheduleCheckMarkDisplayedBesideAsset",
           base.IsTakeScreenShotDuringEntryExit);
            //Returns bool value for display of schedule checkmark
            return isPresentScheduleCheck;
        }

        /// <summary>
        /// Verify the due date icon beside the activity name.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="divisionId">This is the HTML division id.</param>
        /// <returns>Bool value for display of due date icon. </returns>
        public bool IsDuedateIconDisplayedBesideAsset(string activityName, string divisionId)
        {
            // Verify the due date icon beside the activity name
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
             "IsDuedateIconDisplayedBesideAsset",
             base.IsTakeScreenShotDuringEntryExit);
            bool isDueDateIconPresent = false;
            try
            {
                int count = base.GetElementCountByXPath(String.
                        Format(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefauktUXPage_AssetPropertiesCount_Xpath_Locator, divisionId));
                for (int i = 1; i <= count; i++)
                {
                    String getActivityName = base.GetTitleAttributeValueByXPath(String.
                        Format(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefauktUXPage_AssetName_Xpath_Locator, divisionId, i));
                    if (getActivityName == activityName)
                    {
                        isDueDateIconPresent = base.IsElementPresent(By.XPath(String
                            .Format(CalendarHEDDefaultUXPageResource.
                           CalendarHEDDefauktUXPage_AssetDueDateIcon_Xpath_Locator, divisionId, i)));
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
              "IsDuedateIconDisplayedBesideAsset",
          base.IsTakeScreenShotDuringEntryExit);
            //Returns bool value for display of due date icon
            return isDueDateIconPresent;
        }

        /// <summary>
        /// Verify the due date icon for the activity.
        /// </summary>
        /// <returns>Due date icon present/Not present.</returns>
        public bool IsActivityDueDateIconPresent()
        {
            //Verify Activity Due Date Icon
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "IsActivityDueDateStatusPresent",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isActivityDueDateIconPresent = false;
            try
            {
                // select window
                this.SelectCalendarWindow();
                isActivityDueDateIconPresent = base.IsElementPresent(
                    By.ClassName(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_HSS_ActivityStatus_ClassName_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }


            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "IsActivityDueDateStatusPresent",
                   base.IsTakeScreenShotDuringEntryExit);
            return isActivityDueDateIconPresent;
        }

        /// <summary>
        /// Search the activity chapter name in gradebook window.
        /// </summary>
        /// <param name="chapterName">This is the chapter name.</param>
        /// <param name="windowName">This is the window name.</param>
        public void SearchActivityInGradebook(string chapterName, string windowName)
        {
            //Search the activity chapter name in gradebook window
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SearchActivityInGradebook",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                new CourseContentUXPage().
                    SelectActivityWindow(windowName);
                // switch frame To load First
                base.SwitchToIFrameById(CalendarHEDDefaultUXPageResource
                    .CalendarHEDDefaultUXPageResource_GradeBook_Frame_Id_Locator);
                base.WaitForElement(By.CssSelector(CalendarHEDDefaultUXPageResource
                    .CalendarHEDDefaultUXPageResource_CreateColumn_Button_CssSelector_Locator));
                base.SwitchToDefaultPageContent();
                // click on 'View Filters'
                this.ClickViewFilterInGradeBook();
                base.FocusOnElementByCssSelector(CalendarHEDDefaultUXPageResource
                    .CalendarHEDDefaultUXPageResource_SearchTitle_CssSelector_Locator);
                IWebElement getTitleSearch = base.GetWebElementPropertiesByCssSelector
                    (CalendarHEDDefaultUXPageResource.CalendarHEDDefaultUXPageResource_SearchTitle_CssSelector_Locator);
                base.ClickByJavaScriptExecutor(getTitleSearch);
                //Enter the 'Chapter name' to search
                base.ClearTextByCssSelector(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_TextSearch_CSS_ID_Locator);
                base.FillTextBoxById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_ChapterName_ID_Locator,
                    chapterName);
                //Press 'ENTER' key             
                base.PressEnterKeyById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_ChapterName_ID_Locator);
                base.WaitUntilWindowLoads(windowName);
                // click on 'View Filters'
                this.ClickViewFilterInGradeBook();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "SearchActivityInGradebook",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on View Filter In Grade Book.
        /// </summary>
        private void ClickViewFilterInGradeBook()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickViewFilterInGradeBook",
           base.IsTakeScreenShotDuringEntryExit);
            //Click on 'View Filter
            base.FocusOnElementByCssSelector(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_ViewFilter_ID_Locator);
            IWebElement getViewFilter = base.
              GetWebElementPropertiesByCssSelector(CalendarHEDDefaultUXPageResource.
              CalendarHEDDefaultUXPageResource_ViewFilter_ID_Locator);
            base.ClickByJavaScriptExecutor(getViewFilter);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickViewFilterInGradeBook",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click option in calendar
        /// </summary>
        /// <param name="optionName">This is option name.</param>
        ///  <param name="pageTitle">This is page title.</param>
        public void ClickOptionInCalendar(string optionName, string pageTitle)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOptionInCalendar",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(pageTitle);
                // Wait for element and click
                base.WaitForElement(By.LinkText(optionName));
                base.ClickLinkByLinkText(optionName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOptionInCalendar",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get option in calender based on the view type
        /// </summary>
        /// <param name="optionName">This is option name.</param>
        /// <param name="calenderType">This is calender type.</param>
        /// <param name="pageTitle">This is page type.</param>
        /// <returns>Return option status.</returns>
        public bool GetOptionExistanceStatus(string optionName, string calenderType, string pageTitle)
        {
            bool getStatus = false;
            calenderType = CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPageResource_AdvanceCalender_Frame_Id_Locator;
            bool getcalenderType = base.IsElementPresent(By.Id(calenderType));
            switch (optionName)
            {
                case "Assignments":
                    base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AssignCourseMaterials_Id_Locator));
                    bool getAssignmentsButtonExistance = base.IsElementPresent(By.Id(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AssignCourseMaterials_Id_Locator));
                    if (getAssignmentsButtonExistance == true && getcalenderType == true)
                    {
                        getStatus = true;
                    }
                    break;

                case "Calendar Widget":
                    base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AdvanceCalender_CalWidget_Id_Locator));
                    bool getCalendarWidgetExistance = base.IsElementPresent(By.Id(CalendarHEDDefaultUXPageResource.
                       CalendarHEDDefaultUXPageResource_AdvanceCalender_CalWidget_Id_Locator));
                    if (getCalendarWidgetExistance == true && getcalenderType == true)
                    {
                        getStatus = true;
                    }
                    break;

                case "Calendar Viewby":
                    base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                       CalendarHEDDefaultUXPageResource_AdvanceCalender_ViewBy_Id_Locator));
                    bool getCalendarViewbytExistance = base.IsElementPresent(By.Id(CalendarHEDDefaultUXPageResource.
                       CalendarHEDDefaultUXPageResource_AdvanceCalender_ViewBy_Id_Locator));
                    if (getCalendarViewbytExistance == true && getcalenderType == true)
                    {
                        getStatus = true;
                    }
                    break;

                case "Month view":
                    base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                      CalendarHEDDefaultUXPageResource_AdvanceCalender_DateDisplay_Id_Locator));
                    bool getCalendarMonthViewtExistance = base.IsElementPresent(By.Id(CalendarHEDDefaultUXPageResource.
                       CalendarHEDDefaultUXPageResource_AdvanceCalender_DateDisplay_Id_Locator));
                    if (getCalendarMonthViewtExistance == true && getcalenderType == true)
                    {
                        getStatus = true;
                    }
                    break;
            }

            return getStatus;
        }

        /// <summary>
        /// Select calender view type
        /// </summary>
        /// <param name="viewType">This is view type</param>
        public void SelectViewType(string viewType)
        {
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Calendar_Window_Name);
                // Wait for view option to be displayed on scree
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
            CalendarHEDDefaultUXPageResource_AdvanceCalender_ViewBy_Id_Locator));
                base.ClickImageById((CalendarHEDDefaultUXPageResource.
            CalendarHEDDefaultUXPageResource_AdvanceCalender_ViewBy_Id_Locator));
                // Click option based on the view type input
                IWebElement getOption = base.GetWebElementPropertiesByLinkText(viewType);
                base.ClickByJavaScriptExecutor(getOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Add notes
        /// </summary>
        public void ClickOptionInDayView(string optionName)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickAddNote", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (optionName)
                {
                    case "Add Notes":
                        // Wait untill window load
                        base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPage_Calendar_Window_Name);
                        // Wait and click on Add note option
                        base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_AddNotes_Button_Id_Locator));
                        IWebElement getNoteElement = base.GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_AddNotes_Button_Id_Locator);
                        base.ClickByJavaScriptExecutor(getNoteElement);
                        break;

                    case "Edit":
                        // Wait untill window load
                        base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPage_Calendar_Window_Name);
                        // Wait and click on Add note option
                        base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_EditNotes_Button_Id_Locator));
                        IWebElement getEditElement = base.GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_EditNotes_Button_Id_Locator);
                        base.ClickByJavaScriptExecutor(getEditElement);
                        break;

                    case "Delete":
                        // Wait untill window load
                        base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPage_Calendar_Window_Name);
                        // Wait and click on Add note option
                        base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_DeleteNotes_Button_Id_Locator));
                        IWebElement getDeleteElement = base.GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_DeleteNotes_Button_Id_Locator);
                        base.ClickByJavaScriptExecutor(getDeleteElement);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickAddNote", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get wizard title of add note
        /// </summary>
        /// <returns></returns>
        public string getNotesWizardTitle()
        {
            string getTitle = string.Empty;
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Calendar_Window_Name);

                // Get wizard title
                base.WaitForElement(By.ClassName(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNotes_Title_ClassName));
                getTitle = base.GetInnerTextAttributeValueByClassName(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNotes_Title_ClassName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return getTitle;
        }

        /// <summary>
        /// Enter notes and save in the "Add notes" wizard
        /// </summary>
        public void EnterNotes()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "EnterNotes", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get current date
                DateTime date = DateTime.Today;
                //Get the future date
                string getFutureDate = GetFutureDate(date);
                string fillText = CalendarHEDDefaultUXPageResource.CalendarHEDDefaultUXPageResource_Notes_Text + " " + getFutureDate;

                // Switch to iframe 
                base.SwitchToIFrameById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNote_Iframe_Id_Locator);

                // Wait untill the text box loads and enter the text
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNote_TextBox_Id_Locator));
                base.ClearTextById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNote_TextBox_Id_Locator);
                base.FillTextBoxById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNote_TextBox_Id_Locator, fillText);

                // Wait untill the text box loads and enter the text
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNote_SaveClose_Id_Locator));
                IWebElement getSaveCloseButton = base.GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNote_SaveClose_Id_Locator);
                base.ClickByJavaScriptExecutor(getSaveCloseButton);

                Logger.LogMethodExit("CalendarHEDDefaultUXPage", "EnterNotes", base.IsTakeScreenShotDuringEntryExit);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Enter notes and save in the "Add notes" wizard
        /// </summary>
        public void EditNotes()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "EnterNotes", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get Current date
                DateTime date = DateTime.Today;
                //Get the future date
                string getFutureDate = GetFutureDate(date);
                string fillText = CalendarHEDDefaultUXPageResource.CalendarHEDDefaultUXPageResource_EditNotes_Text + " " + getFutureDate;

                // Switch to iframe 
                base.SwitchToIFrameById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNote_Iframe_Id_Locator);

                // Wait untill the text box loads and enter the text
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNote_TextBox_Id_Locator));
                base.ClearTextById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNote_TextBox_Id_Locator);
                base.FillTextBoxById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNote_TextBox_Id_Locator, fillText);

                // Wait and click "Save and close" button
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNote_SaveClose_Id_Locator));
                IWebElement getSaveCloseButton = base.GetWebElementPropertiesById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AddNote_SaveClose_Id_Locator);
                base.ClickByJavaScriptExecutor(getSaveCloseButton);
                Logger.LogMethodExit("CalendarHEDDefaultUXPage", "EnterNotes", base.IsTakeScreenShotDuringEntryExit);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }


        /// <summary>
        /// Assign actiivty to previous date.
        /// </summary>
        public void AssignActivityToPreviousDate()
        {
            Logger.LogMethodEntry("PastDueAssignment", "AssignActiivtyToPreviousDate",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the application date
                string getAppDate = string.Empty;
                //Get today's date
                DateTime date = DateTime.Today;
                string getDate = date.ToString(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CurrentCalendarCell_Id_Locator);
                //Decrement the day by 1
                DateTime pDate = date.AddDays(-1);
                string getPreviousDate = pDate.ToString(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CurrentCalendarCell_Id_Locator);
                this.AssignActivity(getPreviousDate);
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PastDueAssignment", "AssignActiivtyToPreviousDate",
            base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Assign the activity to the expected date
        /// </summary>
        /// <param name="expectedDate">This is the expected date to be assigned.</param>
        private void AssignActivity(string expectedDate)
        {
            //Select the Assigned radio button
            base.SwitchToLastOpenedWindow();
            //Switch to Properties popup window
            base.SwitchToIFrameById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_AssignmentCalendar_PropertiesWindow_Iframe_Id_Locator);
            //Select Assign Radiobutton
            base.SelectRadioButtonById(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_AssignedButton_Id_Locator);
            this.CheckAssignWithDueDateCheckbox();
            //Clear the prefilled textbox value
            base.ClearTextById(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_DueDateTextBox_Id_Locator);
            //Enter the stored expected date value
            base.FillTextBoxById(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_DueDateTextBox_Id_Locator, expectedDate);
            //Save the assign details by clicking Save button  
            base.ClickButtonById(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_SaveButton_Id_Locator);
        }

        /// <summary>
        /// Assign actiivty to previous date.
        /// </summary>
        public void AssignActivityToCurrentDate()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "AssignActiivtyToPreviousDate",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string getAppDate = string.Empty;
                //Get today's date
                DateTime date = DateTime.Today;
                string getDate = date.ToString(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CurrentCalendarCell_Id_Locator);
                this.AssignActivity(getDate);                
                }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "AssignActiivtyToPreviousDate",
            base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Assign actiivty to previous date.
        /// </summary>
        public void AssignActivityToFutureDate()
        {
            Logger.LogMethodEntry("PastDueAssignment", "AssignActiivtyToPreviousDate",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the application date
                string getAppDate = string.Empty;
                //Get today's date
                DateTime date = DateTime.Today;
                string getDate = date.ToString(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CurrentCalendarCell_Id_Locator);
                //Increment the day by 1 days
                DateTime pDate = date.AddDays(1);
                string getFutureDate = pDate.ToString(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CurrentCalendarCell_Id_Locator);
                this.AssignActivity(getFutureDate);
            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PastDueAssignment", "AssignActiivtyToPreviousDate",
            base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Check the status of Assign with Due date checkbox and select if it is not selected
        /// </summary>
        private void CheckAssignWithDueDateCheckbox()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "CheckAssignWithDueDateCheckbox",
            base.IsTakeScreenShotDuringEntryExit);
            //Check if "Assign with Due Date" checkbox is selected or not
            bool isTextBoxSelected = base.IsElementSelectedById("ckbAssign");
            if (isTextBoxSelected == false)
            {
                //Select the Assign with due date checkbox
                base.SelectCheckBoxById("ckbAssign");
            }
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "CheckAssignWithDueDateCheckbox",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Assign actiivty to current date.
        /// </summary>
        public void ScheduleActiivtyToCurrentDate()
        {
            Logger.LogMethodEntry("PastDueAssignment", "AssignActiivtyToPreviousDate",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Assigned radio button
                base.SwitchToLastOpenedWindow();

                //Select the Assigned radio button
                base.SelectRadioButtonById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_AssignedButton_Id_Locator);
                //Get the application date
                string getAppDate = string.Empty;
                //Get today's date
                DateTime date = DateTime.Today;
                string getDate = date.ToString(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CurrentCalendarCell_Id_Locator);
                //DateTime pDate = date.Subtract(1);
                //string getFutureDate = pDate.ToString("d");
                string getPreviousDate = date.ToString(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CurrentCalendarCell_Id_Locator);
                bool isTextBoxSelected = base.IsElementSelectedById("ckbAssign");
                if (isTextBoxSelected == false)
                {
                    base.SelectCheckBoxById("ckbAssign");
                }

                //Clear the prefilled textbox value
                base.ClearTextById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_DueDateTextBox_Id_Locator);
                //Enter the stored previous date value
                base.FillTextBoxById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_DueDateTextBox_Id_Locator, getPreviousDate);


                base.SelectRadioButtonById("rdSetAvailableDate");


                base.ClearTextById("txtFromDate");
                //Enter the stored previous date value
                base.FillTextBoxById("txtFromDate", getPreviousDate);
                base.ClearTextById("txtFromHrs");
                base.FillTextBoxById("txtFromHrs", "1");

                base.SelectDropDownValueThroughTextById("cmbFromAMPM", "PM");

                base.ClearTextById("txtToDate");
                //Enter the stored previous date value
                base.FillTextBoxById("txtToDate", getPreviousDate);

                base.ClearTextById("txtToHrs");
                base.FillTextBoxById("txtToHrs", "11");

                base.SelectDropDownValueThroughTextById("cmbToAMPM", "PM");

                base.SelectCheckBoxById("chkBetSDandED");
                base.SelectCheckBoxById("chkCalNotify");

                //Save the assign details by clicking Save button            
                base.ClickButtonById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SaveButton_Id_Locator);

            }
            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PastDueAssignment", "AssignActiivtyToPreviousDate",
            base.IsTakeScreenShotDuringEntryExit);

        }



        /// <summary>
        /// Select the Cmenu of the activity.
        /// </summary>
        /// <param name="cmenuOption">This is the Cmenu option.</param>
        /// <param name="assetName">This is the name of the asset.</param>
        public void SelectActivityCmenuOption(string assetName)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectActivityCmenu",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Calendar window
                this.SelectCalendarWindow();
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator));
                IWebElement getActivity = base.GetWebElementPropertiesById
                    (CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Div_SearchedAssetTitle_Id_Locator);
                //Hover the mouse on the searched actiivty
                base.PerformMouseHoverByJavaScriptExecutor(getActivity);
                //Store the cmenu icon property
                IWebElement getCmenuIcon = base.GetWebElementPropertiesByXPath
                    ("//td[@id='tdContextMenu']/span");
                //Click on cmenu icon
                base.PerformMouseClickAction(getCmenuIcon);
                //Focus on the asset
                base.PerformFocusOnElementActionByXPath(String.Format
                    (CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_FocusOnActivity_XPath_Locator, assetName));
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                   CalendarHEDDefaultUXPage_Element_Time));
                //Get property of set scheduling cmenu option 
                bool hg = base.IsElementPresent(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_ClickOn_SetSchedulingOption_XPath_Locator), 10);
                IWebElement getViewSubmissionLink = base.GetWebElementPropertiesByXPath
                (CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_ClickOn_SetSchedulingOption_XPath_Locator);
                //Click the 'Set Scheduling options' cmenu option
                base.ClickByJavaScriptExecutor(getViewSubmissionLink);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectActivityCmenu",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check the past due icon display status.
        /// </summary>
        public bool PastDueActivityIcon()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "Pastdueactivityicon",
            base.IsTakeScreenShotDuringEntryExit);
            // Return the icon display status
            bool iconDisplayStatus = base.IsElementPresent(By.ClassName("cssPastDueDate"), 10);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "Pastdueactivityicon",
                base.IsTakeScreenShotDuringEntryExit);
            return iconDisplayStatus;
        }

        /// <summary>
        /// Validate the display of notes.
        /// </summary>
        /// <returns>Return notes display status.</returns>
        public bool ValidateNotes()
        {
            bool getStatus = false;
            try
            {
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
            CalendarHEDDefaultUXPage_Div_AssignedActivitiesInDayView_Xpath_Locator));
                ////table[@id='ctl00_ctl00_phBody_PageContent_ucLeftNavigationContainer_ucContentFilter_drdMultiSelect_chkBoxList']/tbody/tr[{0}]
                bool tst = base.IsElementPresent(By.ClassName("divnotetext"), 10);
                //Get the Total Activities Count
                string getText = base.GetInnerTextAttributeValueByClassName("divnotetext");
                // Get Current date
                DateTime date = DateTime.Today;
                //Get the Future date
                string getFutureDate = GetFutureDate(date);
                string getActualText = CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_Notes_Text + " " + getFutureDate;

                if (getText.Equals(getActualText))
                {
                    getStatus = true;
                }
                //Refresh Current Page
                base.RefreshTheCurrentPage();
                //Accept the Alert
                //  this.AcceptTheAlert();
                //wait for Calendar Window
                base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Calendar_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return getStatus;
        }

        /// <summary>
        /// Validate icon existance in calendar frame.
        /// </summary>
        /// <returns>Return icon existance.</returns>
        public bool ValidateOptionInAssignmentCalendar()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ValidateOptionInAssignmentCalendar", base.IsTakeScreenShotDuringEntryExit);
            bool getStatus = false;
            try
            {
                bool exitLoop = false;
                string getAppDate = string.Empty;
                //Get Current date
                DateTime date = DateTime.Today;
                string getDate = date.ToString("d");
                //Get the Future date
                string getFutureDate = GetFutureDate(date);
                int getRowCount = base.GetElementCountByXPath("//table[@class ='rsContentTable']/tbody/tr");
                for (int i = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    i <= getRowCount && !exitLoop; i++)
                {
                    int getColumCount = base.GetElementCountByXPath(string.Format("//table[@class ='rsContentTable']/tbody/tr[{0}]/td", i));
                    for (int j = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                      CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                      j <= getColumCount; j++)
                    {
                        getAppDate = base.GetTitleAttributeValueByXPath(string.Format("//table[@class ='rsContentTable']/tbody/tr[{0}]/td[{1}]/div/div/a", i, j));

                        if (getAppDate == getFutureDate)
                        {
                            this.SelectCalendarWindow();

                            // Get Note icon existance
                            bool getNoteIconStatus = base.IsElementPresent(By.XPath(string.Format("//table[@class ='rsContentTable']/tbody/tr[{0}]/td[{1}]/div[2]/div/div[2]/span", i, j)), 10);

                            // Get due date icon
                            bool getDueDateIconStatus = base.IsElementPresent(By.XPath(string.Format("//table[@class ='rsContentTable']/tbody/tr[{0}]/td[{1}]/div[2]/div/div[1]/div/div/div/span", i, j)), 10);

                            if (getNoteIconStatus && getDueDateIconStatus == true)
                            {
                                getStatus = true;
                                exitLoop = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "ValidateOptionInAssignmentCalendar", base.IsTakeScreenShotDuringEntryExit);
            return getStatus;
        }

        /// <summary>
        /// Click "Ok" button in the confirmation popup
        /// </summary>
        public void ClickOkButton()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOkButton", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Calendar_Window_Name);
                bool hjje = base.IsElementPresent(By.Id("confirm"), 10);
                IWebElement getOkButton = base.GetWebElementProperties(By.Id("confirm"));
                base.PerformMouseClickAction(getOkButton);
                base.ClickButtonById("confirm");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOkButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get assignment count
        /// </summary>
        /// <returns></returns>
        public int GetAssignedItemCount()
        {
            int returnCount = 0;
            try
            {
                // Wait untill window load
                base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Calendar_Window_Name);

                bool exitLoop = false;
                string getAppDate = string.Empty;
                //Get the Current date
                DateTime date = DateTime.Today;
                string getDate = date.ToString("d");
                //Get the Future date
                string getFutureDate = GetFutureDate(date);
                // Get Row count from assignment calendar
                int getRowCount = base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AdvanceCal_MonthView_GetCalRowCount_Xpath);
                for (int i = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    i <= getRowCount && !exitLoop; i++)
                {
                    int getColumCount = base.GetElementCountByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AdvanceCal_MonthView_GetCalColCount_Xpath, i));
                    for (int j = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                      CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                      j <= getColumCount; j++)
                    {
                        //Get date from the calender
                        getAppDate = base.GetTitleAttributeValueByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_AdvanceCal_MonthView_GetCellDate_Xpath, i, j));

                        if (getAppDate == getFutureDate)
                        {
                            this.SelectCalendarWindow();

                            //Get assignment count
                            string assignmentCount = base.GetInnerTextAttributeValueByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                                CalendarHEDDefaultUXPageResource_AdvanceCal_MonthView_GetAssignCount_Xpath, i, j));
                            returnCount = Convert.ToInt32(assignmentCount);

                            exitLoop = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            return returnCount;
        }

        /// <summary>
        /// Enter The Day View For Assigned Activity.
        /// </summary>
        public void ClickAssignmentFuturedateInAdvCal()
        {
            //Enter The Day View For Assigned Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window load
                base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Calendar_Window_Name);

                bool exitLoop = false;
                string getAppDate = string.Empty;
                //Get the Current date
                DateTime date = DateTime.Today;
                string getDate = date.ToString("d");
                //Get the Future date
                string getFutureDate = GetFutureDate(date);
                // Get Row count from assignment calendar
                int getRowCount = base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AdvanceCal_MonthView_GetCalRowCount_Xpath);
                for (int i = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    i <= getRowCount && !exitLoop; i++)
                {
                    int getColumCount = base.GetElementCountByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AdvanceCal_MonthView_GetCalColCount_Xpath, i));
                    for (int j = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                      CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                      j <= getColumCount; j++)
                    {
                        //Get date from the calender
                        getAppDate = base.GetTitleAttributeValueByXPath(string.Format(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPageResource_AdvanceCal_MonthView_GetCellDate_Xpath, i, j));

                        if (getAppDate == getFutureDate)
                        {
                            this.SelectCalendarWindow();

                            base.PerformMoveToElementClickAction(base.
                                GetWebElementPropertiesByXPath(string.Format("//table[@class ='rsContentTable']/tbody/tr[{0}]/td[{1}]", i, j)));
                            base.WaitForElement(By.XPath(string.Format(CalendarHEDDefaultUXPageResource.
                                CalendarHEDDefaultUXPageResource_AdvanceCal_MonthView_GetAssignCount_Xpath, i, j)));

                            IWebElement getDayViewImage = base.GetWebElementPropertiesByXPath
                                (string.Format(CalendarHEDDefaultUXPageResource.
                                CalendarHEDDefaultUXPageResource_AdvanceCal_MonthView_GetAssignCount_Xpath, i, j));
                            //Click on the Date to enter the Day view and see the assignments
                            base.PerformMouseClickAction(getDayViewImage);
                            base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPage_Calendar_Window_Name);
                            exitLoop = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        public void NavigateBetweenMonth(string actionType, string viewType)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "NavigateBetweenMonth",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectViewType(viewType);
                base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Calendar_Window_Name);
                // Click Next icon
                base.WaitForElement(By.Id("ctl00_ctl00_phBody_PageContent_calendarContainer_imgBtnNext"));
                base.ClickImageById("ctl00_ctl00_phBody_PageContent_calendarContainer_imgBtnNext");
                base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Calendar_Window_Name);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "NavigateBetweenMonth",
                base.IsTakeScreenShotDuringEntryExit);
        }

        public string GetDisplayMonth(string viewType)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "GetDisplayMonth",
                base.IsTakeScreenShotDuringEntryExit);
            string getNextMonth = string.Empty;
            getNextMonth = base.GetInnerTextAttributeValueById("ctl00_ctl00_phBody_PageContent_calendarContainer_lblCurrentDate");

            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "GetDisplayMonth",
                base.IsTakeScreenShotDuringEntryExit);

            return getNextMonth;
        }

        /// <summary>
        /// Asset assign with due date
        /// </summary>
        /// <param name="dateType">This is date type.</param>
        /// <param name="activityType">This is activity type.</param>
        public void AssignWithDueDate(string dateType, Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "AssignWithDueDate",
                base.IsTakeScreenShotDuringEntryExit);
            // Get the activity name from inmemeory 
            Activity activity = Activity.Get(activityType);
            string assetName = activity.Name.ToString();

            //Click on cmenu option
            new CalendarHedDefaultUxPage().SelectActivityCmenuOption
                (assetName);

            switch (dateType)
            {
                case "Current Date":
                    this.EnterTheDayViewForAssignedActivity();
                    new CalendarHedDefaultUxPage().AssignActivityToCurrentDate();
                    break;

                case "Future Date":
                    new CalendarHedDefaultUxPage().AssignActivityToFutureDate();
                    break;

                case "Past Date":
                    new CalendarHedDefaultUxPage().AssignActivityToPreviousDate();
                    break;
            }
            base.WaitUntilWindowLoads(CalendarHEDDefaultUXPageResource.
            CalendarHEDDefaultUXPage_Calendar_Window_Name);
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "AssignWithDueDate",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Asset simple assign
        /// </summary>
        /// <param name="dateType">This is date type.</param>
        /// <param name="activityType">This is activity type.</param>
        public void SimpleAssign(string dateType, Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "SimpleAssign",
                base.IsTakeScreenShotDuringEntryExit);
            // Get the activity name from inmemeory 
            Activity activity = Activity.Get(activityType);
            string assetName = activity.Name.ToString();

            //Click on cmenu option
            new CalendarHedDefaultUxPage().SelectActivityCmenuOption
                (assetName);
            //Schedule Actiivty To Current Date
            new CalendarHedDefaultUxPage().ScheduleActiivtyToCurrentDate();
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "SimpleAssign",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Day View For Assigned Activity.
        /// </summary>
        public void EnterTheDayViewForAssignedActivityForPastDueDate()
        {
            //Enter The Day View For Assigned Activity
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                bool exitLoop = false;
                string getAppDate = string.Empty;
                //Get current date
                DateTime date = DateTime.Today;
                string getDate = date.ToString("d");
                //Decrement the day by 1
                DateTime pDate = date.AddDays(-1);
                string getPastDueDate = pDate.ToString();
                string[] fgh = getPastDueDate.Split(' ');
                string pastDate = fgh[0];
                this.SelectCalendarWindow();
                int getRowCount = base.GetElementCountByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_CalendarFrame_Day_Row_Count_XPathLocator);
                for (int i = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                    i <= getRowCount && !exitLoop; i++)
                {
                    int getColumCount = base.GetElementCountByXPath(string.Format(
                        CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPage_CalendarFrame_Day_Column_Count_XPathLocator, i));
                    for (int j = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                      CalendarHEDDefaultUXPage_Loop_Initializer_Value);
                      j <= getColumCount; j++)
                    {
                        getAppDate = base.GetTitleAttributeValueByXPath(string.Format(
                            CalendarHEDDefaultUXPageResource.
                            CalendarHEDDefaultUXPage_CalendarFrame_Date_XPathLocator, i, j));
                        if (getAppDate.Contains(pastDate))
                        {
                            this.SelectCalendarWindow();
                            base.WaitForElement(By.XPath(string.Format(CalendarHEDDefaultUXPageResource.
                                CalendarHEDDefaultUXPage_CalendarFrame_ExpectedDate_XPathLocator, i, j)));
                            IWebElement getDayViewImage = base.GetWebElementPropertiesByXPath
                                (string.Format(CalendarHEDDefaultUXPageResource.
                                CalendarHEDDefaultUXPage_CalendarFrame_ExpectedDate_XPathLocator, i, j));
                            //Click on the Date to enter the Day view and see the assignments
                            base.PerformMouseClickAction(getDayViewImage);
                            exitLoop = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }



        public void ClickBackToButtonLinkInCalendar(string linkName)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "ClickBackToButtonLinkInCalendar",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.PartialLinkText(linkName));
                IWebElement getBackToMonthLink = base.GetWebElementPropertiesByPartialLinkText(linkName);
                base.ClickByJavaScriptExecutor(getBackToMonthLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "ClickBackToButtonLinkInCalendar",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Select Activities To Assign In Calendar
        /// </summary>
        /// <param name="activityCount">This is the number of activities to be selected.</param>
        public void SelectActivitiesToAssignInCalendar(int activityCount)
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "SelectActivitiesToAssignInCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            this.SelectCalendarWindow();
            base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_CalendarFrame_ActivitiesSearched_XPathLocator));
            for (int i = 1; i <= activityCount; i++)
            {               
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_CalendarFrame_ActivityCheckBox_Select_XPathLocator));
                //Select the activity check box
                IWebElement clickActivityCheckBox = base.GetWebElementPropertiesByXPath(
                    string.Format(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_CalendarFrame_ActivityCheckBox_Select_XPathLocator, i));
                base.ClickByJavaScriptExecutor(clickActivityCheckBox);
            }
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "SelectActivitiesToAssignInCalendar",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Assign/UnAssign link in Assignment Calendar tab
        /// </summary>
        public void AssignUnAssignContentsInCalendar()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "AssignUnAssignContentsInCalendar",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Assign/UnAssign link
            base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_CalendarFrame_AssignUnassignLink_ID_Locator));
            IWebElement getAssignUnassignLink = base.GetWebElementPropertiesById(
                CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_CalendarFrame_AssignUnassignLink_ID_Locator);
            base.ClickByJavaScriptExecutor(getAssignUnassignLink);
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "AssignUnAssignContentsInCalendar",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Verify the Assigned status of the Activity in Assignment Calendar tab
        /// </summary>
        /// <returns>True/False.</returns>
        public bool GetActivityStatusInCalendar()
        {
            Logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "GetActivityStatusInCalendar",
                base.IsTakeScreenShotDuringEntryExit);
            bool isActivityAssignedInCaledar = false;
            //Click on the GO Button to update the assigned status[Auto referesh is not yet implemented]
            base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_Search_Button_Id_Locator));
            //Fetch the Activity status from UI
            base.WaitForElement(By.XPath(
                CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_CalendarFrame_Activity_Status_XPath_Locator));
            isActivityAssignedInCaledar = base.IsElementPresent(By.XPath(
                CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_CalendarFrame_Activity_Status_XPath_Locator), 10);
            return isActivityAssignedInCaledar;
            Logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "GetActivityStatusInCalendar",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}