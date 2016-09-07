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
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;
using Pegasus.Pages.UI_Pages;
using Pegasus.Automation.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles TeachingPlanUX Page Actions.
    /// </summary>
    public class TeachingPlanUxPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(TeachingPlanUxPage));

        /// <summary>
        /// This is activity cmenu options enum.
        /// </summary>
        public enum ActivityCmenuEnum
        {
            Edit = 1,
            Preview = 2,
            Properties = 3,
            Print = 4,
            ViewGrades = 5,
            ViewSubmissions = 6,
            ShowHide = 7,
            GetInformation = 8
        }

        /// <summary>
        /// Get the Tabs Window Title.
        /// </summary>        
        /// <param name="tabName">This is Tab Name</param>
        /// <param name="windowTitle">This is Window Title</param>
        /// <returns>Window Title</returns>
        public string GetTabsWindowTitle(
            string tabName, string windowTitle)
        {
            //Get the Tabs Window Title
            Logger.LogMethodEntry("TeachingPlanUXPage", "GetTabsWindowTitle",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getWindowTitle = string.Empty;
            try
            {   //Navigate to Tab             
                this.NavigateToTabs(tabName);
                //Wait Time
                Thread.Sleep(Convert.ToInt32(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_TimetoWait));
                base.WaitUntilWindowLoads(windowTitle);
                //Get Window Title
                getWindowTitle = base.GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TeachingPlanUXPage", "GetTabsWindowTitle",
                                       base.IsTakeScreenShotDuringEntryExit);
            //Returns the Window Title
            return getWindowTitle;
        }

        /// <summary>
        /// Navigate to Tabs.
        /// </summary>
        /// <param name="tabName">This is Tab Name</param>
        private void NavigateToTabs(string tabName)
        {
            // Navigate to Tabs
            Logger.LogMethodEntry("TeachingPlanUXPage", "NavigateToTabs",
                                   base.IsTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.PartialLinkText(tabName));
            //Click on Tab
            IWebElement getSubTabName = base.GetWebElementPropertiesByPartialLinkText(tabName);
            base.ClickByJavaScriptExecutor(getSubTabName);
            Logger.LogMethodExit("TeachingPlanUXPage", "NavigateToTabs",
                                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The 'Copy Content' Option Text Displayed
        /// </summary>
        /// <returns>'Copy Content' Option Text Displayed</returns>
        public String GetTheCopyContentOptionTextDisplayed()
        {
            //Get The 'Copy Content' Option Text Displayed
            Logger.LogMethodEntry("TeachingPlanUXPage", "GetTheCopyContentOptionTextDisplayed",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getCopyContentTextDisplayed = string.Empty;
            try
            {
                //Wait for the Window
                base.WaitUntilWindowLoads(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_CourseMaterials_WindowName);
                base.SelectWindow(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_CourseMaterials_WindowName);
                //Get the Copy Content text
                getCopyContentTextDisplayed = base.GetElementTextById(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_CopyContent_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TeachingPlanUXPage", "GetTheCopyContentOptionTextDisplayed",
                base.IsTakeScreenShotDuringEntryExit);
            return getCopyContentTextDisplayed;
        }

        /// <summary>
        /// Click On The 'Change Source' Option
        /// </summary>
        public void ClickOnTheChangeSourceOption()
        {
            //Click On The 'Change Source' Option
            Logger.LogMethodEntry("TeachingPlanUXPage", "ClickOnTheChangeSourceOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the Copy Content Drop Down
                base.WaitForElement(By.Id(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_CopyContent_Id_Locator));
                base.ClickLinkById(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_CopyContent_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TeachingPlanUXPage", "ClickOnTheChangeSourceOption",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On The 'specific  Activity' for Editing.
        /// </summary>
        /// <param name="activityName">This is name of the Activity.</param>
        public void ClickOnActivity(string activityName)
        {
            //Click On The 'specific  Activity' for Editing
            Logger.LogMethodEntry("TeachingPlanUXPage", "ClickOnActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Window
                base.WaitUntilWindowLoads(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_CourseMaterials_WindowName);
                //Navigate 'Add from Library' sub tab
                NavigateToTabs(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_AddFromLibrary_Tab);
                //Wait for Right Iframe
                base.WaitForElement(By.Id(TeachingPlanUXPageResource.
                     TeachingPlanUX_Page_Course_Content_Right_Iframe_Id));
                //Switch to Content Frame
                base.SwitchToIFrame(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_Course_Content_Right_Iframe_Id);
                //Click on The 'specific  Activity'
                base.WaitForElement(By.PartialLinkText(activityName));
                //Get Element Property
                IWebElement getPartialLinkTextProperty =
                    base.GetWebElementPropertiesByPartialLinkText(activityName);
                //Click on Element
                base.ClickByJavaScriptExecutor(getPartialLinkTextProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TeachingPlanUXPage", "ClickOnActivity",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Click on folder under Add Course Materials frame.
        /// </summary>
        /// <param name="expectedFolderName">This is name of folder.</param>
        public void ClickOnFolderInAddCourseMaterialsFrame(
            String expectedFolderName)
        {
            //Logger Entry
            Logger.LogMethodEntry("TeachingPlanUXPage", "ClickOnFolderInAddCourseMaterialsFrame",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Declaration of object
                ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
                //Select Course Materials Window 
                contentLibraryUXPage.SelectTheWindowName(ContentLibraryUXPageResource.
                       ContentLibraryUX_Page_CourseMaterials_Window_Name);
                //Select the window
                contentLibraryUXPage.SelectAndSwitchtoFrame(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_Left_Frame_ID_Locator);
                //Wait for folder 
                base.WaitForElement(By.PartialLinkText(expectedFolderName));
                IWebElement getPropertyOfFolder = base.
                    GetWebElementPropertiesByPartialLinkText(expectedFolderName);
                //Click on Folder 
                base.ClickByJavaScriptExecutor(getPropertyOfFolder);
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }

            //Logger Exist
            Logger.LogMethodExit("TeachingPlanUXPage", "ClickOnFolderInAddCourseMaterialsFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Expected MyTest Assets Name.
        /// </summary>
        /// <param name="expectedActivityName">This is name of MyTest assets.</param>
        /// <returns>name of MyTest Assets.</returns>
        public String GetMyTestAssestsName(String expectedActivityName)
        {
            //Logger Entry
            Logger.LogMethodExit("TeachingPlanUXPage", "GetMyTestAssestsName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            String getMyTestAssetsName = string.Empty;
            try
            {
                //Declaration of object
                ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
                //Select Course Materials Window 
                contentLibraryUXPage.SelectTheWindowName(ContentLibraryUXPageResource.
                       ContentLibraryUX_Page_CourseMaterials_Window_Name);
                //Select the window
                contentLibraryUXPage.SelectAndSwitchtoFrame(ContentLibraryUXPageResource.
                    ContentLibraryUX_Page_Left_Frame_ID_Locator);
                //Click the next button
                new ContentLibraryUXPage().ClickOnNextLinkIfActivityNotPresent(
                    expectedActivityName);
                //Wait untill frame get refreshed  
                Thread.Sleep(Convert.ToInt32(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_TimetoWait));
                //Wait for table that contain all mytest assets
                base.WaitForElement(By.XPath(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_Folder_Row_InCourseConten_Id_Locator));
                //Get the count of row 
                int getTotalRowsCount = base.GetElementCountByXPath(
                    TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_Folder_Row_InCourseConten_Id_Locator);
                //Check expected folder availability in table 
                for (int setRowCount = 1; setRowCount <= getTotalRowsCount;
                    setRowCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(TeachingPlanUXPageResource.
                        TeachingPlanUX_Page_Folder_Row_WithPointer_InCourseConten_Id_Locator,
                        setRowCount)));
                    getMyTestAssetsName = base.GetInnerTextAttributeValueByXPath
                        (string.Format(TeachingPlanUXPageResource.
                        TeachingPlanUX_Page_Folder_Row_WithPointer_InCourseConten_Id_Locator,
                        setRowCount)).Replace(Environment.NewLine, string.Empty).TrimEnd();
                    if (getMyTestAssetsName.Contains(expectedActivityName))
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex);
            }
            //Logger Exist
            Logger.LogMethodExit("TeachingPlanUXPage", "GetMyTestAssestsName",
                base.IsTakeScreenShotDuringEntryExit);
            //return MyTest assets Name
            return getMyTestAssetsName;
        }

        /// <summary>
        /// Click On Home Button
        /// </summary>
        public void ClickOnHomeButton()
        {
            //Click On Home Button
            Logger.LogMethodExit("TeachingPlanUXPage", "ClickOnHomeButton",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.PartialLinkText(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_Home_Link_PartialLinkText));
                //Get Home Button Property
                IWebElement getHomeButtonProperty =
                    base.GetWebElementPropertiesByPartialLinkText(
                    TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_Home_Link_PartialLinkText);
                //Click On Home Button
                base.ClickByJavaScriptExecutor(getHomeButtonProperty);
                base.WaitUntilWindowLoads(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_Section_WindowName);
                base.SelectWindow(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_Section_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TeachingPlanUXPage", "ClickOnHomeButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        public void SelectWindow()
        {
            //Select Window
            Logger.LogMethodExit("TeachingPlanUXPage", "SelectWindow",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            try
            {
                //Select Default Window
                base.SelectDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TeachingPlanUXPage", "SelectWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Select Course Materials Window.
        /// </summary>
        private void SelectCourseMaterialsWindow()
        {
            Logger.LogMethodEntry("TeachingPlanUXPage", "SelectCourseMaterialsWindow",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(TeachingPlanUXPageResource.
                TeachingPlanUX_Page_CourseMaterials_WindowName);
            base.SelectWindow(TeachingPlanUXPageResource.
                TeachingPlanUX_Page_CourseMaterials_WindowName);
            Logger.LogMethodExit("TeachingPlanUXPage", "SelectCourseMaterialsWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To My Course Frame To Select The Activity.
        /// </summary>
        public void NavigateMyCourseFrameToSelectTheActivity()
        {
            Logger.LogMethodEntry("TeachingPlanUXPage", "NavigateMyCourseFrameToSelectTheActivity",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToIFrameById(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_Course_Content_Right_Iframe_Id);
                this.SelectMyCourseCheckBoxForAllAssets();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TeachingPlanUXPage", "NavigateMyCourseFrameToSelectTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Select My Course Check Box For All Assets.
        /// </summary>
        private void SelectMyCourseCheckBoxForAllAssets()
        {
            Logger.LogMethodEntry("TeachingPlanUXPage", "SelectMyCourseCheckBoxForAllAssets",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement((By.Id(TeachingPlanUXPageResource.
                TeachingPlanUX_Page_MyCourse_CheckBox_Id_Locator)));
            // select all content checkbox
            base.SelectCheckBoxById(TeachingPlanUXPageResource.
                TeachingPlanUX_Page_MyCourse_CheckBox_Id_Locator);
            Logger.LogMethodExit("TeachingPlanUXPage", "SelectMyCourseCheckBoxForAllAssets",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Activity Cmenu Option In My Course Frame.
        /// </summary>
        /// <param name="activityCmenuEnum">This is Activity Cmenu Type.</param>
        /// <param name="activityName">This is activity Name.</param>
        public void SelectActivityCmenuOptionInMyCourseFrame
            (ActivityCmenuEnum activityCmenuEnum, String activityName)
        {
            // select activity cmenu option 
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "SelectActivityCmenuOptionInMyCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // select course materials window
                this.SelectCourseMaterialsWindow();
                // click on activity Cmenu
                this.PerformMouseHoverOnActivityCmenu(activityName);
                switch (activityCmenuEnum)
                {
                    case TeachingPlanUxPage.ActivityCmenuEnum.Properties:
                        // click on cmenu option properties
                        this.ClickOnAssetCMenuOptionLink(activityCmenuEnum);
                        break;
                    case TeachingPlanUxPage.ActivityCmenuEnum.Edit:
                        // click on cmenu option edit
                        this.ClickOnAssetCMenuOptionLink(activityCmenuEnum);
                        break;
                    case TeachingPlanUxPage.ActivityCmenuEnum.Preview:
                        // click on cmenu option preview
                        this.ClickOnAssetCMenuOptionLink(activityCmenuEnum);
                        break;
                    case TeachingPlanUxPage.ActivityCmenuEnum.Print:
                        // click on cmenu option print
                        this.ClickOnAssetCMenuOptionLink(activityCmenuEnum);
                        break;
                    case TeachingPlanUxPage.ActivityCmenuEnum.ShowHide:
                        // click on cmenu option showhide
                        this.ClickOnAssetCMenuOptionLink(activityCmenuEnum);
                        break;
                    case TeachingPlanUxPage.ActivityCmenuEnum.ViewGrades:
                        // click on cmenu option view grades
                        this.ClickOnAssetCMenuOptionLink(activityCmenuEnum);
                        break;
                    case TeachingPlanUxPage.ActivityCmenuEnum.ViewSubmissions:
                        // click on cmenu option view submissions
                        this.ClickOnAssetCMenuOptionLink(activityCmenuEnum);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "SelectActivityCmenuOptionInMyCourseFrame",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Perform Mouse Hover On Activity Cmenu.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        private void PerformMouseHoverOnActivityCmenu(String activityName)
        {
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "PerformMouseHoverOnActivityCmenu",
                base.IsTakeScreenShotDuringEntryExit);
            // initialize activity counter variable
            int activityCount;
            // initialize activity name counter variable
            string getActivityName = string.Empty;
            // switch my course frame
            base.WaitForElement(By.Id(TeachingPlanUXPageResource.
                TeachingPlanUX_Page_Course_Content_Right_Iframe_Id));
            base.SwitchToIFrameById(TeachingPlanUXPageResource.
                TeachingPlanUX_Page_Course_Content_Right_Iframe_Id);
            base.WaitForElement(By.Id(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_MyCourse_Table_Locator), 5);
            // get activity count present in frame
            activityCount = base.GetElementCountByXPath(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_MyCourse_CourseContent_Xpath_Locator);
            for (int assetNameCount = 1; assetNameCount <= activityCount; assetNameCount++)
            {
                // get activity name
                getActivityName = base.GetElementTextByXPath
                        (string.Format(TeachingPlanUXPageResource.
                        TeachingPlanUX_Page_MyCourse_Assets_Name_Xpath_Locator, assetNameCount));
                if (getActivityName.Replace("\r\n", " ").Contains(activityName))
                {
                    // activity name element property 
                    IWebElement getActivityProperty = base.GetWebElementPropertiesByXPath
                        (string.Format(TeachingPlanUXPageResource.TeachingPlanUX_Page_ActivityName_Xpath_Locator, activityName));
                    base.PerformMouseHoverByJavaScriptExecutor(getActivityProperty);
                    base.WaitForElement(By.ClassName(TeachingPlanUXPageResource.
                        TeachingPlanUX_Page_Activity_CMenu_Image_ClassName_Locator));
                    // get cmenu element property
                    IWebElement getCmenuProperty = base.GetWebElementPropertiesByClassName(TeachingPlanUXPageResource.
                        TeachingPlanUX_Page_Activity_CMenu_Image_ClassName_Locator);
                    base.ClickByJavaScriptExecutor(getCmenuProperty);
                    break;
                }
                base.SwitchToDefaultPageContent();
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "PerformMouseHoverOnActivityCmenu",
          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Asset CMenu Option Link.
        /// </summary>
        private void ClickOnAssetCMenuOptionLink(ActivityCmenuEnum activityCmenuEnum)
        {
            // click on cmenu option
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "ClickOnAssetCMenuOptionLink",
                    base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(activityCmenuEnum.ToString()));
            // click on cmenu option link
            base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByPartialLinkText
                (activityCmenuEnum.ToString()));
            Logger.LogMethodExit("CoursePreviewMainUXPage", "ClickOnAssetCMenuOptionLink",
                   base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Searching for the activity, open the c menu for that activity and click on the given c menu option.
        /// </summary>
        /// <param name="activityCmenuEnum"></param>
        /// <param name="activityName"></param>
        public void SelectActivityCmenuForInstructor(ActivityCmenuEnum activityCmenuEnum, String activityName)
        {
            //Select Activity 
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "SelectActivityCmenuForInstructor",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Course Materials Window
                this.SelectCourseMaterialsWindow();
                //Click On Activity Cmenu
                this.ClickOnAssetCmenuForInstructor(activityName);  
                switch (activityCmenuEnum)
                {
                    case TeachingPlanUxPage.ActivityCmenuEnum.Properties:
                        //Click On Properties Option
                        this.ClickOnPropertiesOption();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "SelectActivityCmenuForInstructor",
            base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Searching for the activity and opening the cmenu for instructor view
        /// </summary>
        /// <param name="activityName"></param>
        private void ClickOnAssetCmenuForInstructor(String activityName)
        {
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "ClickOnActivityCmenuIns",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            int getActivityCount;
            //Initialize Variable
            string getActivityname = string.Empty;          
            this.SelectCourseMaterialsWindow();
            base.SwitchToIFrame(TeachingPlanUXPageResource.
                TeachingPlanUX_Page_ManageCourseMaterials_Frame_Id_Locator);
            //Get Activity Count
            getActivityCount = base.GetElementCountByXPath(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_Assets_Count_Xpath_Locator);
            for (int initialCount = Convert.ToInt32(CoursePreviewMainUXPageResource.
                   CoursePreviewMainUX_Page_Asset_Loop_Initialization_InstValue);
                   initialCount <= getActivityCount; initialCount++)
            {
                //Get Activity Name
                getActivityname = base.GetElementTextByXPath
                        (string.Format(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Assets_Name_Xpath_Locator_Ins, initialCount));
                if (getActivityname == activityName)
                {
                    IWebElement getActivityProperty = base.GetWebElementPropertiesByXPath(
                        string.Format(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Assets_Name_Xpath_Locator_Ins, initialCount));
                    base.PerformMouseHoverByJavaScriptExecutor(getActivityProperty);
                    //Get Cmenu Property
                     IWebElement getCmenuProperty = base.
                        GetWebElementPropertiesByXPath(string.Format(TeachingPlanUXPageResource.
                        TeachingPlanUX_Page_Activitycmenu_Xpath_Locator_Ins, initialCount));
                     Thread.Sleep(3000);
                    //Click On Cmenu Option
                    base.ClickByJavaScriptExecutor(getCmenuProperty);
                    break;
                }
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "ClickOnActivityCmenuIns",
          base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Properties Option
        /// </summary>
        private void ClickOnPropertiesOption()
        {
            //Click On Properties Option
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "ClickOnPropertiesOption",
                    base.IsTakeScreenShotDuringEntryExit);
            //Get Information Property          
            IWebElement getPropertiesOption = base.
                GetWebElementPropertiesByXPath(TeachingPlanUXPageResource.
                TeachingPlanUX_Page_PropertiesOptions_Xpath_Locator);
            //Click On Properties Link
            base.ClickByJavaScriptExecutor(getPropertiesOption);
            Logger.LogMethodExit("CoursePreviewMainUXPage", "ClickOnPropertiesOption",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        public void SetActivityAsShown(string activityName)
        {
            //Wait for the Window
            base.WaitUntilWindowLoads(TeachingPlanUXPageResource.
                TeachingPlanUX_Page_CourseMaterials_WindowName);
            
            //Wait for Right Iframe
            base.WaitForElement(By.Id(TeachingPlanUXPageResource.
                 TeachingPlanUX_Page_Course_Content_Right_Iframe_Id));
            //Switch to Content Frame
            base.SwitchToIFrame(TeachingPlanUXPageResource.
                TeachingPlanUX_Page_Course_Content_Right_Iframe_Id);
            int count = base.GetElementCountByCssSelector("tr[id*='grdCourseContentmyTR']");
            for(int i=count;i>=1;count--)
            {
                string id="grdCourseContentmyTR_"+count;
                string assetName = base.GetWebElementPropertiesById(id).GetAttribute("assetlinkname");
                if(assetName==activityName)
                {
                    IWebElement activityRow = base.GetWebElementPropertiesById(id);
                    IWebElement activityCheckBox = activityRow.FindElement(By.CssSelector("td > input"));
                    base.ClickByJavaScriptExecutor(activityCheckBox);
                    break;

                }
            }

            base.GetWebElementPropertiesByCssSelector("#_ctl0_InnerPageContent_lnkShowHide").Click();
        }

        /// <summary>
        /// Open the folder in Course Materials tab
        /// </summary>
        /// <param name="activityName">this is the activity name</param>
        /// <param name="frameName">This is the frame in Course Materials tab</param>
        public void OpenFolder(string activityName, string frameName)
        {
            Logger.LogMethodEntry("TeachingPlanUXPage", "OpenFolder",
                    base.IsTakeScreenShotDuringEntryExit);
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            try
            {
                base.WaitUntilWindowLoads(TeachingPlanUXPageResource
                    .TeachingPlanUX_Page__CourseMaterial_Window_Name);
                switch(frameName)
                {
                    case "Course Materials Library":
                        base.SwitchToIFrameById(ContentLibraryUXPageResource.
                            ContentLibraryUX_Page_Left_Frame_ID_Locator);
                        contentLibraryUXPage.ClickOnNextLinkIfActivityNotPresent(activityName);
                        this.OpenFolderinCL(activityName);
                        break;

                    case "My Course":
                        base.SwitchToIFrameById(ContentLibraryUXPageResource.
                            ContentLibraryUX_Page_Right_Frame_ID_Locator);
                        //contentLibraryUXPage.ClickOnNextLinkIfActivityNotPresentMyCourse(activityName);
                        this.OpenFolderinCC(activityName);
                        break;
                }
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TeachingPlanUXPage", "OpenFolder",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open Folder in Course Materials Library frame
        /// </summary>
        /// <param name="activityName">This is the folder name</param>
        private void OpenFolderinCL(string activityName)
        {
            int getActivityCount = base.GetElementCountByXPath(ContentLibraryUXPageResource.
                   ContentLibraryUXPage_SearchedActivityCount_XPath_Locator);
            for (int rowCount = Convert.ToInt32(ContentLibraryUXPageResource.
                ContentLibraryUXPage_Activity_Counter); rowCount <= getActivityCount;
                rowCount++)
            {
                //Gets the Activity Name
                string getActivityName = base.GetWebElementPropertiesByXPath
                    (string.Format(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_ActivityName_Xpath_Locator, rowCount)).GetAttribute("title").Trim();
                if (getActivityName == activityName)
                {
                    IWebElement getActivityNameProperty = base.GetWebElementPropertiesByXPath
                    (string.Format(ContentLibraryUXPageResource.
                    ContentLibraryUXPage_ActivityName_Xpath_Locator, rowCount));
                    base.ClickByJavaScriptExecutor(getActivityNameProperty);
                    Thread.Sleep(5000);
                    break;
                }
            }
        }

        /// <summary>
        /// Open Folder in My Course frame
        /// </summary>
        /// <param name="activityName">This is the folder name</param>
        private void OpenFolderinCC(string activityName)
        {
            Logger.LogMethodEntry("TeachingPlanUXPage", "OpenFolderinCC", 
                base.IsTakeScreenShotDuringEntryExit);
            //bool searchResult = false;
            ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();
            //searchResult = base.IsElementPresent(By.Id(ContentLibraryUXPageResource
            //    .ContentLibraryUXPage_ClearSearch_Id_Locator));
            //if (searchResult)
            //{
            //    base.ClickLinkById(ContentLibraryUXPageResource
            //    .ContentLibraryUXPage_ClearSearch_Id_Locator);
            //}
            contentLibraryUXPage.ClickOnNextLinkIfActivityNotPresentMyCourse(activityName);
            int getActivityCount = base.GetElementCountByXPath(ContentLibraryUXPageResource.
                   CourseContentUXPage_Searched_Activity_Count_InMyCourse_Xpath_Locator);
            for (int rowCount = (Convert.ToInt32(ContentLibraryUXPageResource
                .ContentLibraryUXPage_Activity_Counter)); rowCount <= getActivityCount;
                rowCount++)
            {
                //Gets the Folder Name
                string getActivityName = base.GetWebElementPropertiesByXPath
                    (string.Format(ContentLibraryUXPageResource.
                    CourseContentUXPage_Activity_InMyCourse_Xpath_Locator, rowCount)).GetAttribute("title").Trim();
                //Check if the folder name found matches the expected folder name
                if (getActivityName == activityName)
                {
                    IWebElement getActivityNameProperty = base.GetWebElementPropertiesByXPath
                    (string.Format(ContentLibraryUXPageResource.
                    CourseContentUXPage_Activity_InMyCourse_Xpath_Locator, rowCount));
                    //Click on Folder to Open
                    base.ClickByJavaScriptExecutor(getActivityNameProperty);
                    Thread.Sleep(5000);
                    break;
                }
            }
            Logger.LogMethodExit("TeachingPlanUXPage", "OpenFolderinCC", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Back Arrow icon in Course Materials tab
        /// </summary>
        /// <param name="frameName">this is the frame name</param>
        public void ClickBackArrow(string frameName)
        {
            Logger.LogMethodEntry("TeachingPlanUXPage", "ClickBackArrow", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                ContentLibraryUXPage contentLibraryUXPage = new ContentLibraryUXPage();

                switch(frameName)
                {
                    case "Course Materials Library":
                        base.SwitchToIFrameById(ContentLibraryUXPageResource.
                            ContentLibraryUX_Page_Left_Frame_ID_Locator);
                        break;

                    case "My Course":
                        base.SwitchToIFrameById(ContentLibraryUXPageResource.
                            ContentLibraryUX_Page_Right_Frame_ID_Locator);
                        break;
                }
                IWebElement backArrow = base.GetWebElementPropertiesById(TeachingPlanUXPageResource
                    .TeachingPlanUX_Page_BackArrowIcon_Id_Locator);
                base.ClickByJavaScriptExecutor(backArrow);
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("TeachingPlanUXPage", "ClickBackArrow", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the contents using the select all checkbox
        /// </summary>
        public void SelectAllContents()
        {
            Logger.LogMethodEntry("TeachingPlanUxPage", "SelectAllContents", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement getCheckBox = base.GetWebElementPropertiesById("grdCourseContent$_ctrl0");
                base.ClickByJavaScriptExecutor(getCheckBox);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TeachingPlanUxPage", "SelectAllContents", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Show/Hide the contents in My Course using the Show/Hide button
        /// </summary>
        public void ShowHideInMyCourse()
        {
            Logger.LogMethodEntry("TeachingPlanUxPage", "ShowHideInMyCourse",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                IWebElement getShowHidebutton = base.GetWebElementPropertiesById("_ctl0_InnerPageContent_lnkShowHide");
                base.ClickByJavaScriptExecutor(getShowHidebutton);
                base.WaitUntilWindowLoads(base.GetPageTitle);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TeachingPlanUxPage", "ShowHideInMyCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

      }
}
