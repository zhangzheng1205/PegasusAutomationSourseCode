using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Planner.Calendar;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TodaysView;
using Pegasus.Pages.Exceptions;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains details of Assignment Calender tab
    /// </summary>
    public class CalendarHEDDefaultUXPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(CalendarHEDDefaultUXPage));

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
            ItemsAssigned=2,
            /// <summary>
            /// Show option for 'Shown Items' type
            /// </summary>
            ShownItems=3,
            /// <summary>
            /// Show option for 'Instructor Graded' type
            /// </summary>
            InstructorGraded=4,
        }

        /// <summary>
        /// Clicks on the Todays View Option
        /// </summary>
        /// <param name="optionName">This is Option Name</param>
        public void ClickOnTodaysViewOption(string optionName)
        {
            //Clicking Todays View Option form then 'More' DropDown
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnTodaysViewOption",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //If More button Exist then Click
                if (base.IsElementPresent(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Button_More_Id_Locator),
                    Convert.ToInt32(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_TimeToWaitForElement)))
                {
                    //Click on the More Drop Down
                    base.ClickButtonByID(CalendarHEDDefaultUXPageResource.
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The Activity.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SearchTheActivity(String activityName)
        {
            //Search The Activity
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SearchTheActivity",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Content.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        public void SearchContent(String activityName)
        {
            //Search Content
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SearchContent",
                base.isTakeScreenShotDuringEntryExit);
            try
            {               
                //Enter text in the Search Text box
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Textbox_Search_Id_Locator));
                //Focus on the Text box
                base.FocusOnElementByID(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPage_Textbox_Search_Id_Locator);
                base.FillTextBoxByID(CalendarHEDDefaultUXPageResource.
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
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Searched Activity Name.
        /// </summary>
        /// <returns>Searched Activity Name.</returns>
        public String GetSearchedActivityName()
        {
            //Get Searched Activity
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetSearchedActivityName",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            return getAssignedActivityName;
        }

        /// <summary>
        /// Accept The Alert.
        /// </summary>
        private void AcceptTheAlert()
        {
            //Accept The Alert
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "AcceptTheAlert",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Day View For Assigned Activity.
        /// </summary>
        public void EnterTheDayViewForAssignedActivity()
        {
            //Enter The Day View For Assigned Activity
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "EnterTheDayViewForAssignedActivity",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Assign Activity Through Cmenu Option
        /// </summary>        
        public void AssignActivityThroughCmenuOption()
        {
            //Assign Activity Through Cmenu Option
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "AssignActivityThroughCmenuOption",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'Assignment Properties'.
        /// </summary>
        public void ClickOnAssignmentProperties()
        {
            //Click On 'Assignment Properties'
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnAssignmentProperties",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Click The Support Link In Global Homepage
        /// </summary>
        /// <param name="userTypeEnum">This is User type</param>
        public void ClickTheSuportLinkInGlobalHomepage(User.UserTypeEnum userTypeEnum)
        {
            // Click The Support Link In Global Homepage
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickTheSuportLinkInGlobalHomepage",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get UserName In Support Popup
        /// </summary>
        /// <returns>User name</returns>
        public String GetUserNameInSupportPopup()
        {
            //Get UserName In Support Popup
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetUserNameInSupportPopup",
                base.isTakeScreenShotDuringEntryExit);
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
                getUserName = base.GetElementTextByID
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
                base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                switch (userType)
                {
                    case User.UserTypeEnum.CsSmsInstructor:
                        //Select Calendar Window
                        this.SelectCalendarWindow();
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
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Mutiple Assets
        /// </summary>
        public void SelectMultipleAssetsToDragAndDrop()
        {
            //Select Multiple Assets to Drag and Drop
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectMultipleAssetsToDragAndDrop",
              base.isTakeScreenShotDuringEntryExit);
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
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside Folder And SubFolder.
        /// </summary>
        private void NavigateInsideFolderAndSubFolder()
        {
            //Navigate Inside Folder And SubFolder
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "NavigateInsideFolderAndSubFolder",
              base.isTakeScreenShotDuringEntryExit);
            //Click On Asset Root Folder
            this.ClickOnAsset(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_ActivityRootFolder_XPath_Locator);
            //Click On Asset Sub Folder
            this.ClickOnAsset(CalendarHEDDefaultUXPageResource.
                CalendarHEDDefaultUXPage_ActivitySubFolder_Xpath_Locator);
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "NavigateInsideFolderAndSubFolder",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Drag and Drop Multiple Assets
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        private void DragAndDropMultipleAssets(string assetName)
        {
            //Select Drag and Drop of Multiple Assets
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "DragAndDropMultipleAssets",
              base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Asset Row Count.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        /// <returns>Asset Row Count.</returns>
        private int GetAssetRowCount(string assetName)
        {
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetAssetRowCount",
              base.isTakeScreenShotDuringEntryExit);
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
             base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
            //Wait for Xpath
            base.WaitForElement(By.XPath(locatorXpath));
            IWebElement getAssetProperty = base.GetWebElementPropertiesByXPath
                (locatorXpath);
            //Click on Asset
            base.ClickByJavaScriptExecutor(getAssetProperty);
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "ClickOnAsset",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get My Profile Date
        /// </summary>
        /// <returns>My Profile Date</returns>
        public String GetMyProfileProfileDate()
        {
            //Get My Profile Date
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetMyProfileProfileDate",
              base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                  base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
             base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Calendar Window
                this.SelectCalendarWindow();
                //Wait For Element
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_ViewBy_Dropdown_Id_Locator));
                //Select Option In View By Dropdown
                base.SelectDropDownValueThroughTextByID(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_ViewBy_Dropdown_Id_Locator,
                    viewByDropdownOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage", "SelectOptionInViewByDropdown",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Calendar Window.
        /// </summary>
        public void SelectCalendarWindow()
        {
            //Select Calendar Window
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectCalendarWindow",
             base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Option In Show DropDown.
        /// </summary>
        /// <param name="showDropdownOption">This is Show Dropdown Option.</param>
        public void SelectOptionInShowDropDown(string showDropdownOption)
        {
            //Select Option In Show DropDown
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "SelectOptionInShowDropDown",
              base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Contents Order In Course Content.
        /// </summary>
        /// <returns>Contents Name.</returns>
        public String GetContentsOrderInCourseContent()
        {
            //Get Contents Order In Course Content
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "GetContentsOrderInCourseContent",
               base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check Expand Button And Navigate Inside Folders
        /// </summary>
        private void CheckExpandButtonAndNavigateInsideFolders()
        {
            //Check Expand Button And Navigate Inside Folders
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "CheckExpandButtonAndNavigateInsideFolders",
               base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button In Calendar.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        public void ClickOnButtonInCalendar(string buttonName)
        {
            //Click On Button In Calendar
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnButtonInCalendar",
                base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
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
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
                "ClickOnViewAdvancedCalendar",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Current Date.
        /// </summary>
        public void SelectCurrentDateFromCalendar()
        {
            //Select Current Date
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "SelectCurrentDateFromCalendar",
               base.isTakeScreenShotDuringEntryExit);
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
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
             "SelectCurrentDateFromCalendar",
          base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssignCourseMaterialsText = string.Empty;
            try
            {
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AssignCourseMaterials_Id_Locator));
                //Get Assign Course Materials Text
                getAssignCourseMaterialsText = base.GetElementTextByID(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AssignCourseMaterials_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
             "GetAssignCourseMaterialsText",
          base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
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
                getdayText = base.GetElementTextByID(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Day_Id_Locator);
                //Get Week Text
                getWeekText = base.GetElementTextByID(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Week_Id_Locator);
                //Get Month Text
                getMonthText = base.GetElementTextByID(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_Month_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
             "getDayWeekMonthText",
          base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssignedCountWithText = string.Empty;
            try
            {
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AssignedCountText_Id_Locator));
                //Get Assinged Count with Text
                getAssignedCountWithText = base.
                    GetElementTextByID(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AssignedCountText_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
             "getAssignedCountwithText",
          base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getAssignedTextInCalendarFrame = string.Empty;
            try
            {
                base.WaitForElement(By.Id(CalendarHEDDefaultUXPageResource.
                        CalendarHEDDefaultUXPageResource_AssignedText_Id_Locator));
                //Get Assigned Text In Calendar Frame
                getAssignedTextInCalendarFrame = base.
                    GetElementTextByID(CalendarHEDDefaultUXPageResource.
                    CalendarHEDDefaultUXPageResource_AssignedText_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarHEDDefaultUXPage",
             "getAssignedTextInCalendarFrame",
          base.isTakeScreenShotDuringEntryExit);
            return getAssignedTextInCalendarFrame;
        }

        /// <summary>
        /// Get Add Note Text.
        /// </summary>
        /// <returns>Add Note Text</returns>
        public String GetAddNoteText()
        {
            //Get Add Note Text
            logger.LogMethodEntry("CalendarHEDDefaultUXPage","GetAddNoteText",
               base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("CalendarHEDDefaultUXPage","GetAddNoteOption",
              base.isTakeScreenShotDuringEntryExit);
            return getAddNoteText;
        }

        /// <summary>
        /// Click On Calendar Icon
        /// </summary>
        public void ClickOnCalendarIcon()
        {
            //Click On Calendar Icon
            logger.LogMethodEntry("CalendarHEDDefaultUXPage", "ClickOnCalendarIcon",
               base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Set Scheduling Options' Cmenu.
        /// </summary>
        public void SelectSetSchedulingOptionsCmenu()
        {
            //Select 'Set Scheduling Options' Cmenu
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                "SelectSetSchedulingOptionsCmenu",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Instructor Graded option.
        /// </summary>
        private void SelectInstructorGradedOption()
        {
            //Select Instructor Graded option
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "SelectInstructorGradedOption",
                  base.isTakeScreenShotDuringEntryExit);
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
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Shown Items option.
        /// </summary>
        private void SelectShownItemsOption()
        {
            //Select Shown Items option
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "SelectShownItemsOption",
                  base.isTakeScreenShotDuringEntryExit);
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
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Items Assigned Option.
        /// </summary>
        private void SelectItemsAssignedOption()
        {
            //Select Items Assigned Option
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "SelectItemsAssignedOption",
                  base.isTakeScreenShotDuringEntryExit);
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
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Apply Button.
        /// </summary>
        private void ClickTheApplyButton()
        {
            //Click The Apply Button
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "ClickTheApplyButton",
                  base.isTakeScreenShotDuringEntryExit);
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
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select All Items Option.
        /// </summary>
        private void SelectAllItemsOption()
        {
            //Select All Items Option
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
               "SelectAllItemsOption",
                  base.isTakeScreenShotDuringEntryExit);
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
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Show Dropdown.
        /// </summary>
        private void ClickTheShowDropdown()
        {
            //Click The Show Dropdown
            logger.LogMethodEntry("CalendarHEDDefaultUXPage",
                  "ClickTheShowDropdown",
                         base.isTakeScreenShotDuringEntryExit);
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
                         base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
            base.isTakeScreenShotDuringEntryExit);
            return getMessageValidate;
        }
    }
}
