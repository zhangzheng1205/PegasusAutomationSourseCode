using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Planner.Calendar;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TodaysView;
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
        private static Logger logger = Logger.GetInstance(typeof(CalendarHedDefaultUxPage));

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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnTodaysViewOption",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOnTodaysViewOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SearchTheActivity(String activityName)
        {
            //Search The Activity
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SearchTheActivity",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "SearchTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Content.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SearchContent(String activityName)
        {
            //Search Content
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SearchContent",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Enter text in the Search Text box
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Textbox_Search_Id_Locator));
                //Focus on the Text box
                base.FocusOnElementById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Textbox_Search_Id_Locator);
                base.FillTextBoxById(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Textbox_Search_Id_Locator, activityName);
                //Click on the GO Button
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Button_GO_Id_Locator));
                IWebElement GoButtonProperty = base.GetWebElementPropertiesById
                    (CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Button_GO_Id_Locator);
                base.ClickByJavaScriptExecutor(GoButtonProperty);
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SleepTime));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "SearchContent",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Searched Activity Name.
        /// </summary>
        /// <returns>Searched Activity Name.</returns>
        public String GetSearchedActivityName()
        {
            //Get Searched Activity
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetSearchedActivityName",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetSearchedActivityName",
                base.IsTakeScreenShotDuringEntryExit);
            return getSearchedActivityName;
        }

        /// <summary>
        /// 'Drag And Drop' Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void DragAndDropActivity(String activityName)
        {
            //'Drag And Drop' Activity
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "DragAndDropActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
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
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "DragAndDropActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Assigned Activity Name On Current Day.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <returns>Assigned Activity Name.</returns>
        public String GetAssignedActivityNameOnCurrentDay(string activityName)
        {
            //Get Assigned Activity
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetAssignedActivityNameOnCurrentDay",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetAssignedActivityNameOnCurrentDay",
                base.IsTakeScreenShotDuringEntryExit);
            return getAssignedActivityName;
        }

        /// <summary>
        /// Accept The Alert.
        /// </summary>
        private void AcceptTheAlert()
        {
            //Accept The Alert
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "AcceptTheAlert",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "AcceptTheAlert",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Day View For Assigned Activity.
        /// </summary>
        public void EnterTheDayViewForAssignedActivity()
        {
            //Enter The Day View For Assigned Activity
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assign Activity Through Cmenu Option
        /// </summary>        
        public void AssignActivityThroughCmenuOption()
        {
            //Assign Activity Through Cmenu Option
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "AssignActivityThroughCmenuOption",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "AssignActivityThroughCmenuOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'Assignment Properties'.
        /// </summary>
        public void ClickOnAssignmentProperties()
        {
            //Click On 'Assignment Properties'
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnAssignmentProperties",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOnAssignmentProperties",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Click The Support Link In Global Homepage
        /// </summary>
        /// <param name="userTypeEnum">This is User type</param>
        public void ClickTheSuportLinkInGlobalHomepage(User.UserTypeEnum userTypeEnum)
        {
            // Click The Support Link In Global Homepage
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickTheSuportLinkInGlobalHomepage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickTheSuportLinkInGlobalHomepage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get UserName In Support Popup
        /// </summary>
        /// <returns>User name</returns>
        public String GetUserNameInSupportPopup()
        {
            //Get UserName In Support Popup
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetUserNameInSupportPopup",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetUserNameInSupportPopup",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnMyProfileLink",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOnMyProfileLink",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Mutiple Assets
        /// </summary>
        public void SelectMultipleAssetsToDragAndDrop()
        {
            //Select Multiple Assets to Drag and Drop
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectMultipleAssetsToDragAndDrop",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectMultipleAssetsToDragAndDrop",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside Folder And SubFolder.
        /// </summary>
        private void NavigateInsideFolderAndSubFolder()
        {
            //Navigate Inside Folder And SubFolder
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "NavigateInsideFolderAndSubFolder",
              base.IsTakeScreenShotDuringEntryExit);
            //Click On Asset Root Folder
            this.ClickOnAsset(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_ActivityRootFolder_XPath_Locator);
            //Click On Asset Sub Folder
            this.ClickOnAsset(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_ActivitySubFolder_Xpath_Locator);
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "DragAndDropMultipleAssets",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "DragAndDropMultipleAssets",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Asset Row Count.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        /// <returns>Asset Row Count.</returns>
        private int GetAssetRowCount(string assetName)
        {
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetAssetRowCount",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetAssetRowCount",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnAsset",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait for Xpath
            base.WaitForElement(By.XPath(locatorXpath));
            IWebElement getAssetProperty = base.GetWebElementPropertiesByXPath
                (locatorXpath);
            //Click on Asset
            base.ClickByJavaScriptExecutor(getAssetProperty);
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOnAsset",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get My Profile Date
        /// </summary>
        /// <returns>My Profile Date</returns>
        public String GetMyProfileProfileDate()
        {
            //Get My Profile Date
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetMyProfileProfileDate",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetMyProfileProfileDate",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetConvertedDate",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variables
            int getDateString = Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_DueDate_Row_Value);
            string[] getDateValues = null;
            try
            {
                //Check if date contains backword slash
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetConvertedDate",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "IsActivityDueDateStatusPresent",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool IsActivityDueDateStatusPresent = false;
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                IsActivityDueDateStatusPresent = base.IsElementPresent(
                    By.ClassName(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_ActivityStatus_ClassName_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "IsActivityDueDateStatusPresent",
              base.IsTakeScreenShotDuringEntryExit);
            return IsActivityDueDateStatusPresent;
        }

        /// <summary>
        /// Select Option In View By Dropdown.
        /// </summary>
        /// <param name="viewByDropdownOption">This is View By Dropdown Option.</param>
        public void SelectOptionInViewByDropdown(string viewByDropdownOption)
        {
            //Select Option In View By Dropdown
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectOptionInViewByDropdown",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectOptionInViewByDropdown",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Calendar Window.
        /// </summary>
        public void SelectCalendarWindow()
        {
            //Select Calendar Window
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectCalendarWindow",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectCalendarWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Option In Show DropDown.
        /// </summary>
        /// <param name="showDropdownOption">This is Show Dropdown Option.</param>
        public void SelectOptionInShowDropDown(string showDropdownOption)
        {
            //Select Option In Show DropDown
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectOptionInShowDropDown",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectOptionInShowDropDown",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Show Dropdown And Get Option Count.
        /// </summary>
        /// <returns>Show Dropdown Option Count.</returns>
        private int ClickOnShowDropdownAndGetOptionCount()
        {
            //Click On Show Dropdown And Get Option Count
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectTheContentType",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectTheContentType",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Contents Order In Course Content.
        /// </summary>
        /// <returns>Contents Name.</returns>
        public String GetContentsOrderInCourseContent()
        {
            //Get Contents Order In Course Content
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetContentsOrderInCourseContent",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetContentsOrderInCourseContent",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetOrderOfAssignedActivities",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetOrderOfAssignedActivities",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectContentInCalendar",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectContentInCalendar",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check Expand Button And Navigate Inside Folders
        /// </summary>
        private void CheckExpandButtonAndNavigateInsideFolders()
        {
            //Check Expand Button And Navigate Inside Folders
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnButtonInCalendar",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOnButtonInCalendar",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetContentStatus",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetContentStatus",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "IsAssignUnassignButtonDisabled",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "IsAssignUnassignButtonDisabled",
              base.IsTakeScreenShotDuringEntryExit);
            return isAssignUnassignButtonDisabled;
        }

        /// <summary>
        /// Click On View Advanced Calendar.
        /// </summary>
        public void ClickOnViewAdvancedCalendar()
        {
            //Click On View Advanced Calendar
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "ClickOnViewAdvancedCalendar",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Current Date.
        /// </summary>
        public void SelectCurrentDateFromCalendar()
        {
            //Select Current Date
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "SelectCurrentDateFromCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.XPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_CurrentDate_Xpath_Locator));
                //Get Current Date Cell Property
                IWebElement getCurrentCellProperty = base.
                    GetWebElementPropertiesByXPath(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_CurrentDate_Xpath_Locator);
                //Click On Current Date Cell Property
                base.ClickByJavaScriptExecutor(getCurrentCellProperty);
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Element_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
             "GetAssignCourseMaterialsText",
          base.IsTakeScreenShotDuringEntryExit);
            return getAssignCourseMaterialsText;

        }

        /// <summary>
        /// Get Day Month Week Text.
        /// </summary>
        /// <returns>Day Month Week Text</returns>
        public String getDayWeekMonthText()
        {
            // Get Day Month Week Text
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "getDayWeekMonthText",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable for Day
            string getdayText = string.Empty;
            //Initialize Variable for Week
            string getWeekText = string.Empty;
            //Initialize variable for Month
            string getMonthText = string.Empty;
            //Initialize variable for Day,week and month
            string getDayWeekMonthText = string.Empty;
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
             "getDayWeekMonthText",
          base.IsTakeScreenShotDuringEntryExit);
            return getDayWeekMonthText = getdayText + getWeekText + getMonthText;
        }

        /// <summary>
        /// Get Assigned Count with Text.
        /// </summary>
        /// <returns>Assigned Count with Text.</returns>
        public String getAssignedCountwithText()
        {
            //Get Assigned Count with Text
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "getAssignedCountwithText",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
             "getAssignedCountwithText",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetAddNoteText",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "GetAddNoteOption",
              base.IsTakeScreenShotDuringEntryExit);
            return getAddNoteText;
        }

        /// <summary>
        /// Click On Calendar Icon
        /// </summary>
        public void ClickOnCalendarIcon()
        {
            //Click On Calendar Icon
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnCalendarIcon",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOnCalendarIcon",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Set Scheduling Options' Cmenu.
        /// </summary>
        public void SelectSetSchedulingOptionsCmenu()
        {
            //Select 'Set Scheduling Options' Cmenu
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "SelectTheContentTypeFromShowDropdown",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Instructor Graded option.
        /// </summary>
        private void SelectInstructorGradedOption()
        {
            //Select Instructor Graded option
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "SelectInstructorGradedOption",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Shown Items option.
        /// </summary>
        private void SelectShownItemsOption()
        {
            //Select Shown Items option
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "SelectShownItemsOption",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Items Assigned Option.
        /// </summary>
        private void SelectItemsAssignedOption()
        {
            //Select Items Assigned Option
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "SelectItemsAssignedOption",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Apply Button.
        /// </summary>
        private void ClickTheApplyButton()
        {
            //Click The Apply Button
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "ClickTheApplyButton",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select All Items Option.
        /// </summary>
        private void SelectAllItemsOption()
        {
            //Select All Items Option
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "SelectAllItemsOption",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Show Dropdown.
        /// </summary>
        private void ClickTheShowDropdown()
        {
            //Click The Show Dropdown
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "ExpandNode",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(string.Format(CalendarHEDDefaultUXPageResource
                .CalendarHEDDefaultUXPage_ContainerAssets_Title_Xpath_Locator, nodeId)));
            IWebElement nodeLink = base.GetWebElementPropertiesByXPath(string
                .Format(CalendarHEDDefaultUXPageResource
                .CalendarHEDDefaultUXPage_ContainerAssets_Title_Xpath_Locator, nodeId));
            base.ClickByJavaScriptExecutor(nodeLink);

            logger.LogMethodExit("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "IsAssignedUnAssignedButtonEnabled",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource
                .CalendarHEDDefaultUXPage_AssignUnAssign_Link_Id_Locator));
            return base.IsElementEnabledById(CalendarHEDDefaultUXPageResource
                  .CalendarHEDDefaultUXPage_AssignUnAssign_Link_Id_Locator);
        }

        /// <summary>
        /// Selects the checkbox of the activity.
        /// </summary>
        /// <param name="assetCount">Number of activities to be selected.</param>
        /// <param name="containerNodeId">Node Id of the container node.</param>
        public void SelectCheckBoxOfActivity(int assetCount, string containerNodeId)
        {
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
                base.ClickByJavaScriptExecutor(checkBox);
                this.StoreAssignUnAssignActivityInMemory(
                    checkBoxId.Split('_')[1]);
                ++counter;
                if (counter >= assetCount) break;
            }

            logger.LogMethodExit("CalendarHEDDefaultUXPage",
               "SelectCheckBoxOfActivity",
           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on Assign/Unassign link button.
        /// </summary>
        public void ClickOnAssignUnassignButton()
        {
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "ClickOnAssignUnassignButton",
               base.IsTakeScreenShotDuringEntryExit);

            base.ClickButtonById(CalendarHEDDefaultUXPageResource
                .CalendarHEDDefaultUXPage_AssignUnAssign_Link_Id_Locator);

            logger.LogMethodExit("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "IsAssetAssigned",
               base.IsTakeScreenShotDuringEntryExit);

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
            else
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "IsCurrentDayHighlighted",
               base.IsTakeScreenShotDuringEntryExit);
            //Declaring a variable
            bool isCurrentDateHighlighted = false;
            try
            {
                //Select the calendar window
                this.SelectCalendarWindow();
                base.WaitForElement(By.XPath
                      (CalendarHEDDefaultUXPageResource.
                       CalendarHEDDefaultUXPageResource_CurrentDate_Xpath_Locator));
                isCurrentDateHighlighted = base.IsElementPresent(By.XPath
                      (CalendarHEDDefaultUXPageResource.
                       CalendarHEDDefaultUXPageResource_CurrentDate_Xpath_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "IsCurrentDayHighlighted",
                base.IsTakeScreenShotDuringEntryExit);
            return isCurrentDateHighlighted;
        }

        /// <summary>
        /// Get the Folder Name.
        /// </summary>
        /// <returns>Asset Name.</returns>    
        public string GetActualFolderName()
        {
            //Get the Folder Name
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "GetActualFolderName",
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize getStatusText variable
            IWebElement actualFolderAssetName = null;
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                //Get the inner text of the folder
                actualFolderAssetName =
                    GetWebElementPropertiesByXPath(CalendarHEDDefaultUXPageResource
                    .CalendarHEDDefaultUXPage_GOwithMicrosoftOffice2013Volume1_Folder_XPath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentPresentationPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "DragAndDropWordFolderAsset",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "DragAndDropWordFolderAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifying Start Date Flag Element Present or not.
        /// </summary>
        /// <returns>Start date value.</returns>
        public Boolean IsStartDateFlagDisplayed()
        {
            //Verifying Start Date Flag Element Present or not
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "IsStartDateFlagDisplayed",
                base.IsTakeScreenShotDuringEntryExit);
            //Intialize the value
            Boolean IsStartDateFlagDisplayed = false;
            try
            {
                //Select the calendar window
                this.SelectCalendarWindow();
                base.WaitForElement(By.ClassName(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_FlagImage_Class_Locator));
                // Verify Start Date Icon by Is True Assert
                IsStartDateFlagDisplayed = base.IsElementPresent(By.ClassName
                    (CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_FlagImage_Class_Locator));

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                           "IsStartDateFlagDisplayed",
                           base.IsTakeScreenShotDuringEntryExit);
            return IsStartDateFlagDisplayed;
        }

        /// <summary>
        /// Drag and Drop selected 'Excel Chapter 1: Simulation Activities' assets to current date. 
        /// </summary>
        public void DragAndDropMultipleExcelActivities()
        {
            //Drag and Drop selected 'Excel Chapter 1: Simulation Activities' assets to current date
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "DragAndDropMultipleExcelActivities",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                Thread.Sleep(3000);
                //Wait for the element
                IWebElement element = WebDriver.FindElement(By.XPath("//div[@title='Excel Chapter 1 Skill-Based Training']"));
                IWebElement target = WebDriver.FindElement(By.XPath("//td[@class='HighlightTodayCell']"));
                base.PerformDragAndDropAction(element, target);
                Thread.Sleep(Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_SleepTime));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "DragAndDropMultipleExcelActivities",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Cmenu of the activity.
        /// </summary>
        /// <param name="cmenuOption">This is the Cmenu option.</param>
        /// <param name="assetName">This is the name of the asset.</param>
        public void SelectActivityCmenu(string cmenuOption, string assetName)
        {
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectActivityCmenu",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Calendar window
                this.SelectCalendarWindow();
                //Get the Asset property
                IWebElement getAssetName = base.GetWebElementPropertiesByXPath(
                    CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Asset_XPath_Locator);
                //Mouseover on the asset
                base.PerformMouseHoverAction(getAssetName);
                //Click on cmenu of the asset
                base.ClickByJavaScriptExecutor
                    (base.GetWebElementPropertiesByXPath(
                    CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Cmenu_XPath_Locator));
                //Click On 'Set Scheduling option' in cmenu
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByXPath(
                    CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_CmenuOption_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectActivityCmenu",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Due Date Icon Dispaly.
        /// </summary>
        /// <returns>Display of icon in calendar.</returns>
        public Boolean IsDueDateIconPresentInCalendar()
        {
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
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
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "GetAssignAssetText",
              base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            try
            {
                bool jdg = base.IsElementPresent(By.XPath(String.Format("//div[@id='ctl00_ctl00_phBody_PageContent_calendarContainer_ucHEDDayView_RptPeriods_ctl00_dvDueAssignmentsToday']/div[2]/div")), 10);
                //Get the total no of assets assigned count
                int getRowCount = base.GetElementCountByXPath("//div[@id='ctl00_ctl00_phBody_PageContent_calendarContainer_ucHEDDayView_RptPeriods_ctl00_dvDueAssignmentsToday']/div[2]/div");
                for (int row = 0; row <= getRowCount; row++)
                {
                    bool yy = base.IsElementPresent(By.XPath(String.Format("//div[@id='ctl00_ctl00_phBody_PageContent_calendarContainer_ucHEDDayView_RptPeriods_ctl00_dvDueAssignmentsToday'/div/div//div/span")), 10);

                    base.WaitForElement(By.XPath(String.Format("//div[@id='ctl00_ctl00_phBody_PageContent_calendarContainer_dvContainer'/div/div/div/span", row)));
                    //Get the asset inner text
                    getActivityName = base.GetElementInnerTextByXPath(String.Format
                        (CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AssetInnerText_XPath_Locator, row));
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
               "GetAssignAssetText",
              base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }
    }
}
