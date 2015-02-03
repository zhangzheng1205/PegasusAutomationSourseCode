using System;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;
using System.Collections.Generic;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeachingPlan;
using Pegasus.Pages.CommonPageObjects;
using System.Configuration;
using System.Diagnostics;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Course Preview Page Actions.
    /// </summary>
    public class CoursePreviewUXPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = Logger.GetInstance(typeof(CoursePreviewUXPage));

        /// <summary>
        /// Get To Do Page window Title.
        /// If Window is accessible then window title should be as expected.
        /// </summary>
        /// <param name="tabName">This is name of the tab.</param>
        /// <returns>True if window title found as expected otherwirse false.</returns>
        public String GetToDoTabWindowTitle(string tabName)
        {
            //Get Window Title 
            Logger.LogMethodEntry("CoursePreviewUXPage", "GetToDoTabWindowTitle",
               base.IsTakeScreenShotDuringEntryExit);
            //Initializing the variable
            string newTabName = tabName;
            if (tabName == CoursePreviewUXPageResource.
                CouresPreviewUX_Page_ToDo_Window_Title)
            {
                newTabName = CoursePreviewUXPageResource.
                    CouresPreviewUX_Page_AssignmentsToDo_Window_Title;
            }
            //Wait For Page To Get Switched
            base.WaitUntilPageGetSwitchedSuccessfully(newTabName);
            //Get Page Title
            string getWindowTitle = base.GetPageTitle;
            Logger.LogMethodEntry("CoursePreviewUXPage", "GetToDoTabWindowTitle",
               base.IsTakeScreenShotDuringEntryExit);
            return getWindowTitle;
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectCourseMaterialsWindow()
        {
            //Select Window
            Logger.LogMethodEntry("CoursePreviewUXPage", "SelectCourseMaterialsWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_Window_Title_Name_HED);
            base.SelectWindow(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_Window_Title_Name_HED);
            Logger.LogMethodExit("CoursePreviewUXPage", "SelectCourseMaterialsWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Assignments To Do Window.
        /// </summary>
        private void SelectAssignmentsToDoWindow()
        {
            //Select Window
            Logger.LogMethodEntry("CoursePreviewUXPage", "SelectAssignmentsToDoWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                CouresPreviewUX_Page_AssignmentsToDo_Window_Title);
            base.SelectWindow(CoursePreviewUXPageResource.
                CouresPreviewUX_Page_AssignmentsToDo_Window_Title);
            Logger.LogMethodExit("CoursePreviewUXPage", "SelectAssignmentsToDoWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch To Course Preview IFrame.
        /// </summary>
        private void SwitchToCoursePreviewIFrame()
        {
            //Switch To IFrame
            Logger.LogMethodEntry("CoursePreviewUXPage", "SwitchToCoursePreviewIFrame",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_CoursePreview_IFrame_Id_Locator));
            //Switch To Frame
            base.SwitchToIFrame(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_CoursePreview_IFrame_Id_Locator);
            Logger.LogMethodExit("CoursePreviewUXPage", "SwitchToCoursePreviewIFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Activity Name In Course Materials Tab.
        /// </summary>
        /// <param name="assetName">This is Activity Name.</param>
        /// <returns>Activity Name</returns>
        public String GetActivityNameInCourseMaterialsTab(string assetName)
        {
            // Get Activity Name In Course Materials Tab
            Logger.LogMethodEntry("CoursePreviewUXPage", "GetActivityNameInCourseMaterialsTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize getActivityText variable
            string getActivityName = string.Empty;
            try
            {
                //Select the window
                this.SelectCourseMaterialsWindow();
                //Siwtch to Iframe
                this.SwitchToCoursePreviewIFrame();
                Thread.Sleep(Convert.ToInt32(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Sleep_Time));
                base.WaitForElement(By.XPath(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Assets_Count_Xpath_Locator));
                //Total Row count of the Assets
                int getTotalRowCount = base.GetElementCountByXPath(
                    CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Assets_Count_Xpath_Locator);
                for (int setRowCount = Convert.ToInt32(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Loop_Initialization_Value);
                    setRowCount <= getTotalRowCount; setRowCount++)
                {
                    Thread.Sleep(Convert.ToInt32(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Sleep_Time));
                    base.WaitForElement(By.XPath(string.Format(CoursePreviewUXPageResource.
                     CoursePreviewUX_Page_Assets_Name_Xpath_Locator, setRowCount)));
                    //Getting the assets name               
                    getActivityName = base.GetElementTextByXPath
                     (string.Format(CoursePreviewUXPageResource.
                     CoursePreviewUX_Page_Assets_Name_Xpath_Locator, setRowCount));
                    if (getActivityName == assetName)
                    {
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);

            }
            Logger.LogMethodEntry("CoursePreviewUXPage", "GetActivityNameInCourseMaterialsTab",
               base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Launches the Etext Window.
        /// </summary>
        public void LaunchEText()
        {
            // Launches the Etext Window
            Logger.LogMethodEntry("CoursePreviewUXPage", "LaunchEText",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_Etext_Link));
                IWebElement etextLink = base.GetWebElementPropertiesById(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_Etext_Link);
                // Launches the Etext Window
                base.ClickByJavaScriptExecutor(etextLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage", "LaunchEText",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// close the 'Etext' window.
        /// </summary>
        public void CloseEtextWindow()
        {
            // close the 'Etext' window
            Logger.LogMethodEntry("CoursePreviewUXPage", "CloseEtextWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToLastOpenedWindow();
                // close the 'Etext' window
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage", "CloseEtextWindow",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait for past due date icon to be displayed.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="activityUnderTabName">This is the Tab name.</param>
        /// <param name="userType">This is the user type enum.</param>
        public void WaitForPastDueDateIcon(string activityName,
            string activityUnderTabName, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("CoursePreviewUXPage", "WaitForPastDueDateIcon",
                base.IsTakeScreenShotDuringEntryExit);
            // Wait for past due date icon to be displayed
            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                // Wait till entity enters from inactive state to active state
                int minutesToWait = Int32.Parse(ConfigurationManager.
                    AppSettings["AssignedToCopyInterval"]);
                while (stopwatch.Elapsed.TotalMinutes < 15)
                {
                    StudentPresentationPage studentPresentationPage =
                    new StudentPresentationPage();
                    //Select Window And Frame
                    studentPresentationPage.SelectWindowAndFrame();
                    //Get the class name of the icon
                    string dueDateClass = this.GetActivityClassName(activityName);
                    //Verify if Past Due date icon is displayed.
                    if (dueDateClass == CoursePreviewUXPageResource.
                        CoursePreviewUX_Page_PastDueDateIcon_Class_Id_Locator) break;
                    {
                        //Search the Entity
                        new TodaysViewUxPage().SelectTab(CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_Window_Title_Name_HED);
                        new CommonPage().ManageTheActivityFolderLevelNavigation(
                        activityName, activityUnderTabName, userType);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage", "WaitForPastDueDateIcon",
               base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Returns the class name of the icon of the activity.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <returns></returns>
        private string GetActivityClassName(string activityName)
        {
            // Returns the class name of the icon of the activity
            Logger.LogMethodEntry("CoursePreviewUXPage", "GetActivityClassName",
            base.IsTakeScreenShotDuringEntryExit);
            // Returns the class name of the icon of the activity
            string activityLinkId = base.GetWebElementPropertiesByLinkText(activityName)
                .GetAttribute(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_Activity_WebElement_Property_Name);
            string pastDueDateIconId = CoursePreviewUXPageResource.
                CoursePreviewUX_Page_PastDueDateIcon_WebelementProperty_Id_PartialValue
                + activityLinkId.Split('_')[1];
            // Returns the class name of the icon of the activity
            string pastDueDateClass = base.GetWebElementPropertiesByXPath(string.
                Format(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_PastDueDateIcon_Xpath_Locator, pastDueDateIconId)).
                GetAttribute("class");
            Logger.LogMethodExit("CoursePreviewUXPage", "GetActivityClassName",
                base.IsTakeScreenShotDuringEntryExit);
            return pastDueDateClass;
        }

        /// <summary>
        /// Launch the asset from To Do Tab.
        /// </summary>        
        /// <param name="assetName">This is the asset name.</param>
        public void LaunchAssetFromToDoTab(string assetName)
        {
            //Launch the asset from To Do Tab
            Logger.LogMethodEntry("LauncheTextPage", "LaunchAssetFromToDoTab",
                        base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to Iframe
                base.SwitchToIFrame(CoursePreviewUXPageResource.
                          CouresPreviewUX_Page_TodoPage_Iframe_Name);
                //Get the count of assets
                int getCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                    CouresPreviewUX_Page_TodoPage_AssetCount_XPath_Locator);
                for (int assetSearch = 2; assetSearch <= getCount; assetSearch++)
                {
                    //Get asset name     
                    string getAssetName = base.GetElementTextByXPath(String.Format(CoursePreviewUXPageResource.
                        CouresPreviewUX_Page_TodoPage_AssetName_XPathLocator, assetSearch));
                    if (getAssetName == assetName)
                    {
                        base.WaitForElement(By.XPath(String.Format(CoursePreviewUXPageResource.
                               CouresPreviewUX_Page_TodoPage_AssetName_XPathLocator, assetSearch)));
                        IWebElement selectAsset = base.GetWebElementPropertiesByXPath(String.Format(
                               CoursePreviewUXPageResource.
                              CouresPreviewUX_Page_TodoPage_AssetName_XPathLocator, assetSearch));
                        base.ClickByJavaScriptExecutor(selectAsset);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LauncheTextPage", "LaunchAssetFromToDoTab",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the status of the asset from ToDO  Tab.
        /// </summary>
        /// <param name="assetStatus">This is the asset name.</param>
        /// <returns>The asset status.</returns>
        public string GetAssetStatus(string assetStatus)
        {
            //Get the status of the asset
            Logger.LogMethodEntry("LauncheTextPage", "GetAssetStatus",
                    base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToIFrame(CoursePreviewUXPageResource.
                        CouresPreviewUX_Page_TodoPage_Iframe_Name);
                int getCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                    CouresPreviewUX_Page_TodoPage_AssetCount_XPath_Locator);
                for (int statusSearch = 2; statusSearch <= getCount; statusSearch++)
                {
                    base.WaitForElement(By.XPath(String.Format(CoursePreviewUXPageResource.
                        CouresPreviewUX_Page_TodoPage_AssetStatus_XPathLocator, statusSearch)));
                    string getAssetStatus = base.GetElementTextByXPath(String.Format(
                        CoursePreviewUXPageResource.
                            CouresPreviewUX_Page_TodoPage_AssetStatus_XPathLocator, statusSearch));
                    if (getAssetStatus == assetStatus)
                    {
                        base.WaitForElement(By.XPath(string.Format(CoursePreviewUXPageResource.
                    CouresPreviewUX_Page_TodoPage_ImDone_XPath_Locator, statusSearch)));
                        IWebElement getImDone = base.GetWebElementPropertiesByXPath(string.Format(CoursePreviewUXPageResource.
                    CouresPreviewUX_Page_TodoPage_ImDone_XPath_Locator, statusSearch));
                        //Click on 'I'm Done' button
                        base.ClickByJavaScriptExecutor(getImDone);
                    }
                }



            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LauncheTextPage", "GetAssetStatus",
                  base.IsTakeScreenShotDuringEntryExit);
            return assetStatus;
        }

        /// <summary>
        /// Get the asset name from Completed tab.
        /// </summary>
        /// <param name="assetName">This is the asset name.</param>
        /// <returns>The asset name.</returns>
        public string GetAssetNameInCompletedTab(string assetName)
        {
            Logger.LogMethodEntry("LauncheTextPage", "GetAssetStatus",
                    base.IsTakeScreenShotDuringEntryExit);
            string assetNameInCompleted = string.Empty;
            //Click on Completed tab
            IWebElement getCompleted = base.GetWebElementPropertiesByPartialLinkText(
                CoursePreviewUXPageResource.CouresPreviewUX_Page_TodoPage_Completed_PartialLinkText);
            base.ClickByJavaScriptExecutor(getCompleted);
            //Switch to Iframe
            base.SwitchToIFrame(CoursePreviewUXPageResource.
                CouresPreviewUX_Page_TodoPage_Iframe_Name);
            //Count the number of assets
            int getCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                CouresPreviewUX_Page_TodoPage_AssetCount_XPath_Locator);
            for (int assetSearch = 2; assetSearch <= getCount; assetSearch++)
            {
                //Get asset name     
                assetNameInCompleted = base.GetElementTextByXPath(String.Format(CoursePreviewUXPageResource.
                    CouresPreviewUX_Page_TodoPage_AssetName_XPathLocator, assetSearch));
                if (assetNameInCompleted == assetName)
                {
                    break;
                }

            }
            //Select main Window
            base.SelectWindow("Course Materials");
            Logger.LogMethodExit("LauncheTextPage", "GetAssetStatus",
                             base.IsTakeScreenShotDuringEntryExit);
            return assetNameInCompleted;


        }

        /// <summary>
        /// Student launch the activity from Course Material tab.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        public void SelectActivityByStudentInWorldLanguage(string activityName)
        {
            //Student launch the activity from Course Material tab
            Logger.LogMethodEntry("CoursePreviewUXPage", "SelectActivityByStudentInWorldLanguage",
                        base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select window
                new StudentPresentationPage().SelectWindowAndFrame();
                //Click on the activity
                IWebElement getactivityName = base.
                    GetWebElementPropertiesByPartialLinkText(activityName);
                base.ClickByJavaScriptExecutor(getactivityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("CoursePreviewUXPage", "SelectActivityByStudentInWorldLanguage",
                         base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Get The Asset Name Displayed Under Tab.
        /// </summary>
        /// <param name="underTabName">This is Tab name.</param>
        /// <returns>Asset Name.</returns>
        public string GetAssetNameDisplayedUnderTab(string underTabName)
        {
            Logger.LogMethodEntry("CoursePreviewUXPage", "GetAssetNameDisplayedUnderTab",
                        base.IsTakeScreenShotDuringEntryExit);
            // asset web element
            IWebElement webElementToDoList = null;
            try
            {
                // name of tab
                switch (underTabName)
                {
                    case "To Do":
                        this.SelectAssignmentsToDoWindow();
                        this.SwitchToCoursePreviewIFrame();
                        base.WaitForElementDisplayedInUi(By.Id(CoursePreviewUXPageResource
                              .CoursePreviewUX_Page_ToDoList_Div_Id_Locator));
                        webElementToDoList = base.GetWebElementPropertiesById
                            (CoursePreviewUXPageResource.CoursePreviewUX_Page_ToDoList_Div_Id_Locator);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage", "GetAssetNameDisplayedUnderTab",
                         base.IsTakeScreenShotDuringEntryExit);
            return webElementToDoList.Text.Replace("\r\n", " ");
        }

        /// <summary>
        /// Click On The Button Next To The Asset.
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        /// <param name="assetName">This is asset name.</param>
        public void ClickOnButtonNextToTheAsset(string buttonName, string assetName)
        {
            Logger.LogMethodEntry("CoursePreviewUXPage", "ClickOnButtonNextToTheAsset",
                      base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (buttonName)
                {
                    case "Start":
                        base.WaitForElementDisplayedInUi(By.XPath(CoursePreviewUXPageResource
                            .CouresPreviewUX_Page_TodoList_XPath_Locator));
                        int divTodoListNodes = base.GetElementCountByXPath(CoursePreviewUXPageResource
                            .CouresPreviewUX_Page_TodoList_XPath_Locator);
                        for (int countDivTodoList = 1; countDivTodoList <= divTodoListNodes; countDivTodoList++)
                        {
                            IWebElement webElementToDoList = base.GetWebElementPropertiesByXPath
                                (string.Format(CoursePreviewUXPageResource
                                .CouresPreviewUX_Page_DivTodoListNodes_XPath_Locator, divTodoListNodes));
                            if (webElementToDoList.Text.Replace("\r\n", " ").Contains(assetName))
                            {
                                base.ClickButtonByXPath(string.Format
                                    (CoursePreviewUXPageResource.CouresPreviewUX_Page_TodoListNodes_XPath_Locator, divTodoListNodes));
                                break;
                            }
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage", "ClickOnButtonNextToTheAsset",
                         base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
