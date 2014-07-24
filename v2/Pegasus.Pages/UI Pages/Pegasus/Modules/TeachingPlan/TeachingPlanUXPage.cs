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

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles TeachingPlanUX Page Actions
    /// </summary>
    public class TeachingPlanUxPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(TeachingPlanUxPage));

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
                                   base.isTakeScreenShotDuringEntryExit);
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
                                       base.isTakeScreenShotDuringEntryExit);
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
                                   base.isTakeScreenShotDuringEntryExit);
            //Wait for Element
            base.WaitForElement(By.PartialLinkText(tabName));
            //Focus on Element
            base.FocusOnElementByPartialLinkText(tabName);
            //Click on Tab
            IWebElement getSubTabName = base.GetWebElementPropertiesByPartialLinkText(tabName);
            base.ClickByJavaScriptExecutor(getSubTabName);
            Logger.LogMethodExit("TeachingPlanUXPage", "NavigateToTabs",
                                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The 'Copy Content' Option Text Displayed
        /// </summary>
        /// <returns>'Copy Content' Option Text Displayed</returns>
        public String GetTheCopyContentOptionTextDisplayed()
        {
            //Get The 'Copy Content' Option Text Displayed
            Logger.LogMethodEntry("TeachingPlanUXPage", "GetTheCopyContentOptionTextDisplayed",
                base.isTakeScreenShotDuringEntryExit);
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
                getCopyContentTextDisplayed = base.GetElementTextByID(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_CopyContent_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TeachingPlanUXPage", "GetTheCopyContentOptionTextDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            return getCopyContentTextDisplayed;
        }

        /// <summary>
        /// Click On The 'Change Source' Option
        /// </summary>
        public void ClickOnTheChangeSourceOption()
        {
            //Click On The 'Change Source' Option
            Logger.LogMethodEntry("TeachingPlanUXPage", "ClickOnTheChangeSourceOption",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On The 'specific  Activity' for Editing.
        /// </summary>
        /// <param name="activityName">This is name of the Activity.</param>
        public void ClickOnActivity(string activityName)
        {
            //Click On The 'specific  Activity' for Editing
            Logger.LogMethodEntry("TeachingPlanUXPage", "ClickOnActivity",
                base.isTakeScreenShotDuringEntryExit);
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
                     TeachingPlanUX_Page_Course_Content_Iframe_Id));
                //Switch to Content Frame
                base.SwitchToIFrame(TeachingPlanUXPageResource.
                    TeachingPlanUX_Page_Course_Content_Iframe_Id);
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
                base.isTakeScreenShotDuringEntryExit);

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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(TeachingPlanUXPageResource.
                        TeachingPlanUX_Page_HomeButton_Id_Locator));
                //Get Home Button Property
                IWebElement getHomeButtonProperty = base.GetWebElementPropertiesById(
                    TeachingPlanUXPageResource.TeachingPlanUX_Page_HomeButton_Id_Locator);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        public void SelectWindow()
        {
            //Select Window
            Logger.LogMethodExit("TeachingPlanUXPage", "SelectWindow",
              base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            try
            {
                string getPageTitle = base.GetPageTitle;
                //Select Window
                base.SelectWindow(getPageTitle);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("TeachingPlanUXPage", "SelectWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        public void SelectActivityInCourseMaterialsLibraryFrame(string activityName)
        {
            switch (activityName)
            {
                case "Access Chapter 1: End-of-Chapter Quiz":

                    //Wait for the Window
                    base.WaitUntilWindowLoads(TeachingPlanUXPageResource.
                        TeachingPlanUX_Page_CourseMaterials_WindowName);
                    base.SelectWindow(TeachingPlanUXPageResource.
                        TeachingPlanUX_Page_CourseMaterials_WindowName);
                    base.SwitchToIFrameById("ifrmLeft");
                    base.WaitForElement(By.PartialLinkText("GO! with Microsoft Access 2013 Comprehensive"));
                    base.ClickLinkByPartialLinkText("GO! with Microsoft Access 2013 Comprehensive");

                    base.WaitForElement(By.PartialLinkText("Access Chapter 1: Getting Started with Microsoft Access 2013"));
                    base.ClickLinkByPartialLinkText("Access Chapter 1: Getting Started with Microsoft Access 2013");

                    base.WaitForElement(By.PartialLinkText("Access Chapter 1: Activities"));
                    base.ClickLinkByPartialLinkText("Access Chapter 1: Activities");



                    base.WaitForElement(By.PartialLinkText("Access Chapter 1: End-of-Chapter Activities"));
                    base.ClickLinkByPartialLinkText("Access Chapter 1: End-of-Chapter Activities");

                    string isRequiredAssetPresent = base.GetElementTextByID("grdContentLibrary$divContent");
                    if (isRequiredAssetPresent.Contains(activityName))
                    {
                        base.WaitForElement((By.Id("grdContentLibrary$_ctrl0")));
                        base.ClickCheckBoxById("grdContentLibrary$_ctrl0");

                    }

                    
                    base.SwitchToDefaultPageContent();

                    base.WaitForElement(By.Id("_ctl0:_ctl0:phBody:PageContent:imgbtnAddContent"));
                    base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesById("_ctl0:_ctl0:phBody:PageContent:imgbtnAddContent"));
                    


                    break;
            }
        }
    }
}
