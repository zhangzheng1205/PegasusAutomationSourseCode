using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Planner.Calendar;
using System.Configuration;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class contains Calendar DefaultUX Page Actions
    /// </summary>
    public class CalendarDefaultUXPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(CalendarDefaultUXPage));

        /// <summary>
        /// Get Wait Time From App Config File.
        /// </summary>
        static readonly double getMinutesToWait = Convert.ToDouble
            (ConfigurationManager.AppSettings[CalendarDefaultUXPageResource.
            CalendarDefaultUXPage_AppSettings_AssignedToCopyInterval_Key_Text]);

        /// <summary>
        /// Drag and Drop the Asset to The Calendar
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        public void DragAndDropAsset(String assetName)
        {
            //Drag and Drop the Asset to The Calendar
            logger.LogMethodEntry("CalendarDefaultUXPage", "DragAndDropAsset",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(EmptyCalendarPageResource.
                    EmptyCalendarPage_Calendar_Window_Title_NN);
                //Select the 'Calendar' window
                base.SelectWindow(EmptyCalendarPageResource.
                    EmptyCalendarPage_Calendar_Window_Title_NN);
                //Search the Asset
                this.SearchTheAsset(assetName);
                base.WaitForElement(By.XPath(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_SearchedAssets_Xpath_Locator));
                //Drag and Drop the Asset
                base.PerformClickAndHoldAction(base.
                    GetWebElementPropertiesByXPath(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_SearchedAssets_Xpath_Locator));
                base.WaitForElement(By.XPath(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_Assignments_Xpath_Locator));
                base.PerformMoveToElementClickAction(base.
                    GetWebElementPropertiesByXPath(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_Assignments_Xpath_Locator));
                //Wait for Some Time
                Thread.Sleep(Convert.ToInt32(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_Sleep_Time_Value));
                base.WaitUntilWindowLoads(EmptyCalendarPageResource.
                    EmptyCalendarPage_Calendar_Window_Title_NN);
                //Select the 'Calendar' window
                base.SelectWindow(EmptyCalendarPageResource.
                    EmptyCalendarPage_Calendar_Window_Title_NN);
                base.WaitForElement(By.Id(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_AssignedToCopy_Text_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultUXPage", "DragAndDropAsset",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The Asset
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        private void SearchTheAsset(String assetName)
        {
            //Search The Asset
            logger.LogMethodEntry("CalendarDefaultUXPage", "SearchTheAsset",
                base.isTakeScreenShotDuringEntryExit);
            //Search the asset
            base.WaitForElement(By.Id(CalendarDefaultUXPageResource.
                CalendarDefaultUXPage_Textbox_Search_Id_Locator));
            //Fill textbox
            base.FillTextBoxByID(CalendarDefaultUXPageResource.
                CalendarDefaultUXPage_Textbox_Search_Id_Locator, assetName);
            //Click on the GO button
            base.WaitForElement(By.Id(CalendarDefaultUXPageResource.
                CalendarDefaultUXPage_Button_Go_Id_Locator));
            base.ClickButtonByID(CalendarDefaultUXPageResource.
                CalendarDefaultUXPage_Button_Go_Id_Locator);
            base.WaitForElement(By.Id(CalendarDefaultUXPageResource.
                CalendarDefaultUXPage_Div_SearchedAssets_Id_Locator));
            logger.LogMethodExit("CalendarDefaultUXPage", "SearchTheAsset",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Assigned Asset
        /// </summary>        
        /// <param name="assetName">This is Asset Name</param>
        /// <returns>Assigned Asset Name</returns>
        public String GetAssignedAssetName(string assetName)
        {
            //Display Of Assigned Asset
            logger.LogMethodEntry("CalendarDefaultUXPage", "GetAssignedAssetName",
                base.isTakeScreenShotDuringEntryExit);
            string getAssetName = string.Empty;
            try
            {
                getAssetName = this.GetSearchedAssetName(assetName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("CalendarDefaultUXPage", "GetAssignedAssetName",
                base.isTakeScreenShotDuringEntryExit);
            return getAssetName;
        }

        /// <summary>
        /// Get Searched Asset Name 
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        /// <returns>Searched Asset Name</returns>
        private String GetSearchedAssetName(string assetName)
        {
            //Get Searched Asset Name
            logger.LogMethodEntry("CalendarDefaultUXPage", "GetSearchedAssetName",
                base.isTakeScreenShotDuringEntryExit);
            string getAssetName = string.Empty;
            //Start the StopWatch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (stopWatch.Elapsed.TotalMinutes < getMinutesToWait)
            {
                //Wait for some time
                Thread.Sleep(Convert.ToInt32(CalendarDefaultUXPageResource.
                CalendarDefaultUXPage_Sleep_Time_Value));
                //Select the Window
                base.SelectWindow(EmptyCalendarPageResource.
                    EmptyCalendarPage_Calendar_Window_Title_NN);
                if (base.IsElementPresent(By.Id(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_AssignedToCopy_Text_Id_Locator),
                    Convert.ToInt32(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_Customized_Wait_Time_Value)) &&
                    base.GetElementTextByID(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_AssignedToCopy_Text_Id_Locator) ==
                    CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_AssignedToCopy_Text_Value)
                {
                    //Refresh the Page
                    base.RefreshTheCurrentPage();
                }
                else
                {
                    //Get the Asset name
                    getAssetName = base.GetElementTextByClassName(
                        CalendarDefaultUXPageResource.
                        CalendarDefaultUXPage_Assigned_Asset_Name_Id_Locator);
                    if (getAssetName.Contains(assetName))
                    {
                        getAssetName = assetName;
                    }
                    break;
                }
            }
            logger.LogMethodExit("CalendarDefaultUXPage", "GetSearchedAssetName",
                base.isTakeScreenShotDuringEntryExit);
            return getAssetName;
        }

        /// <summary>
        ///Click The Go to Student View Link In Global HomePage
        /// </summary>
        /// <param name="goToStudentViewLink">This is Go to Student View link</param>
        public void ClickTheGotoStudentViewLinkInGlobalHomePage(string goToStudentViewLink)
        {
            //Click The Go to Student View Link In Global HomePage
            logger.LogMethodEntry("CalendarDefaultUXPage",
                "ClickTheGotoStudentViewLinkInGlobalHomePage",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the 'Go to Student View' link
                base.WaitForElement(By.PartialLinkText(goToStudentViewLink));
                IWebElement getStudentViewLink = base.GetWebElementPropertiesByPartialLinkText
                    (goToStudentViewLink);
                //Click the 'Go to Student View' link
                base.ClickByJavaScriptExecutor(getStudentViewLink);
            }
            catch (Exception e)
            {
              ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultUXPage",
                "ClickTheGotoStudentViewLinkInGlobalHomePage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Assigned Asset Content Message
        /// </summary>
        /// <param name="contentMessage">This is Content Message</param>
        /// <returns>Content message</returns>
        public String GetAssignedAssetContentMessage(string contentMessage)
        {
            //Get Assigned Asset Content Message
            logger.LogMethodEntry("CalendarDefaultUXPage", "GetAssignedAssetContentMessage",
              base.isTakeScreenShotDuringEntryExit);
            string getContentMessage = string.Empty;
            {
                //Select the Window
                base.SelectWindow(EmptyCalendarPageResource.
                    EmptyCalendarPage_Calendar_Window_Title_NN);
                //Wait for the content message
                base.WaitForElement(By.Id
                    (CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_AssignedToCopy_Text_Id_Locator));
                //Get the message
                getContentMessage = base.GetElementTextByID
                    (CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_AssignedToCopy_Text_Id_Locator);              
            }
            logger.LogMethodExit("CalendarDefaultUXPage", "GetAssignedAssetContentMessage",
                base.isTakeScreenShotDuringEntryExit);
            return getContentMessage;
        }

        /// <summary>
        /// Select 'View By' Dropdown Option.
        /// </summary>
        /// <param name="dropdownOption">This is Dropdown Option.</param>
        public void SelectViewByDropdownOption(string dropdownOption)
        {
            //Select 'View By' Dropdown Option
            logger.LogMethodEntry("CalendarDefaultUXPage", "SelectViewByDropdownOption",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                base.WaitForElement(By.Id(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_ViewBy_Dropdown_Id_Locator));
                //Click On 'View By' Dropdown 
                base.ClickButtonByID(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_ViewBy_Dropdown_Id_Locator);                
                //Select 'View By' Dropdown Option
                base.SelectDropDownValueThroughTextByName(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_ViewBy_Dropdown_Name_Locator, dropdownOption);           
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultUXPage", "SelectViewByDropdownOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Calendar Window.
        /// </summary>
        private void SelectCalendarWindow()
        {
            //Select Calendar Window
            logger.LogMethodEntry("CalendarDefaultUXPage", "SelectCalendarWindow",
             base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(CalendarDefaultUXPageResource.
                CalendarDefaultUXPage_Calendar_Window_Name);
            //Select Window
            base.SelectWindow(CalendarDefaultUXPageResource.
                CalendarDefaultUXPage_Calendar_Window_Name);
            logger.LogMethodExit("CalendarDefaultUXPage", "SelectCalendarWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Contents Order In Content Frame.
        /// </summary>
        /// <returns>Assets Name.</returns>
        public String GetContentsOrderInContentFrame()
        {
            //Get Contents Order In Content Frame
            logger.LogMethodEntry("CalendarDefaultUXPage", "GetContentsOrderInContentFrame",
              base.isTakeScreenShotDuringEntryExit);
            //Initialize Variables
            string getAssetsName = string.Empty;
            string getAssetText = string.Empty;
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                base.WaitForElement(By.XPath(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_AssetCount_Xpath_Locator));
                //Get Asset Count
                int assetCount = base.GetElementCountByXPath(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_AssetCount_Xpath_Locator);
                for (int rowCount = Convert.ToInt32(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_Loop_Initializer_Value);
                    rowCount <= assetCount; rowCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(CalendarDefaultUXPageResource.
                        CalendarDefaultUXPage_AssetName_Xpath_Locator, rowCount)));
                    //Get Assets Name
                    getAssetText =
                        base.GetElementTextByXPath(string.Format(CalendarDefaultUXPageResource.
                        CalendarDefaultUXPage_AssetName_Xpath_Locator, rowCount));
                    getAssetsName += getAssetText; 
                }                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultUXPage", "GetContentsOrderInContentFrame",
               base.isTakeScreenShotDuringEntryExit);
            return getAssetsName;
        }

        /// <summary>
        /// Get AssetName In Calendar.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        /// <returns>Asset Name.</returns>
        public String GetAssetNameInCalendar(string assetName)
        {
            //Display Of Assigned Asset
            logger.LogMethodEntry("CalendarDefaultUXPage", "GetAssetNameInCalendar",
                base.isTakeScreenShotDuringEntryExit);
            string getAssetName = string.Empty;
            try
            {
                getAssetName = this.GetAssetNameFromCalendar(assetName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultUXPage", "GetAssetNameInCalendar",
                base.isTakeScreenShotDuringEntryExit);
            return getAssetName;
        }

        /// <summary>
        /// Get AssetName From Calendar.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        /// <returns>Asset Name.</returns>
        private string GetAssetNameFromCalendar(string assetName)
        {
            //Get AssetName From Calendar
            logger.LogMethodEntry("CalendarDefaultUXPage", "GetAssetNameFromCalendar",
              base.isTakeScreenShotDuringEntryExit);
            //Initialize Variables           
            string getAssetText = string.Empty;
            //Select Calendar Window
            this.SelectCalendarWindow();
            base.WaitForElement(By.XPath(CalendarDefaultUXPageResource.
                CalendarDefaultUXPage_AssetCount_Xpath_Locator));
            //Get Asset Count
            int assetCount = base.GetElementCountByXPath(CalendarDefaultUXPageResource.
                CalendarDefaultUXPage_AssetCount_Xpath_Locator);
            for (int rowCount = Convert.ToInt32(CalendarDefaultUXPageResource.
                CalendarDefaultUXPage_Loop_Initializer_Value);
                rowCount <= assetCount; rowCount++)
            {
                base.WaitForElement(By.XPath(string.Format(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_AssetName_Xpath_Locator, rowCount)));
                //Get Assets Name
                getAssetText =
                    base.GetElementTextByXPath(string.Format(CalendarDefaultUXPageResource.
                    CalendarDefaultUXPage_AssetName_Xpath_Locator, rowCount));
                if (getAssetText.Contains(assetName))
                {
                    break;
                }
            }
            logger.LogMethodExit("CalendarDefaultUXPage", "GetAssetNameFromCalendar",
               base.isTakeScreenShotDuringEntryExit);
            return getAssetText;            
        }
    }
}
