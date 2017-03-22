﻿using System;
using System.Collections;
using System.Linq;
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
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Course Preview Page Actions.
    /// </summary>
    public class CoursePreviewUXPage : BasePage
    {
        //Locators for eText S11 launch at HED
        By toolDropDown = By.CssSelector("a[id*='tools']");
        By eTextDropDownOption = By.CssSelector("div[title='eText']");
        By eTextDirectSpan = By.CssSelector("span[id*='tdHEDEbook']");
        By eTextDirectTd = By.CssSelector("td[id*='tdHEDEbook']");

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
            bool tooldropDownPres = false;
            IWebElement etextLink;
            try
            {
                //Launch Etext via Tool DropDown if present or directly via eText link
                tooldropDownPres = base.IsElementPresent(toolDropDown, 10);
                if (tooldropDownPres)
                {
                    IWebElement dropDown = WebDriver.FindElement(toolDropDown);
                    base.ClickByJavaScriptExecutor(dropDown);
                    base.WaitForElement(eTextDropDownOption);
                    etextLink = WebDriver.FindElement(eTextDropDownOption);
                }

                else
                {
                    base.SwitchToDefaultWindow();
                    //Launch Direct eText link as instructor
                    bool span = base.IsElementPresent(eTextDirectSpan, 10);
                    if (span)
                    {
                        base.WaitForElement(eTextDirectSpan);
                        etextLink = WebDriver.FindElement(eTextDirectSpan);
                    }
                    else
                    //Launch Direct eText link as student
                    {
                        base.WaitForElement(eTextDirectTd);
                        etextLink = WebDriver.FindElement(eTextDirectTd);
                    }

                }
                //Click on link
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
        public void CloseETextWindow()
        {
            // close the 'Etext' window
            Logger.LogMethodEntry("CoursePreviewUXPage", "CloseETextWindow",
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
            Logger.LogMethodExit("CoursePreviewUXPage", "CloseETextWindow",
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
            base.SelectWindow(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_Window_Title_Name_HED);
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
                        ICollection<IWebElement> coloumn2Collections = base.GetWebElementsCollectionByCssSelector
                            (CoursePreviewUXPageResource.CoursePreviewUX_Page_Coloumn2_CssSelector_Locator);
                        int counter = 0;
                        foreach (IWebElement coloumn2 in coloumn2Collections)
                        {
                            if (coloumn2.Text.Replace("\r\n", " ").Contains(assetName))
                            {
                                ICollection<IWebElement> startButtonCollections = base.GetWebElementsCollectionByCssSelector
                                    (CoursePreviewUXPageResource.CoursePreviewUX_Page_StartButton_CssSelector_Locator);
                                startButtonCollections.ElementAt(counter).Click();
                                break;
                            }
                            counter++;
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

        /// <summary>
        /// Get Asset Score.
        /// </summary>
        /// <param name="assetName">This is asset name.</param>
        /// <param name="underTabName">The Tab Name.</param>
        /// <returns>Asset Score.</returns>
        public string GetAssetScore(string assetName, string underTabName)
        {
            Logger.LogMethodExit("CoursePreviewUXPage", "GetAssetScore",
                         base.IsTakeScreenShotDuringEntryExit);
            string currentScore = string.Empty;
            try
            {
                switch (underTabName)
                {
                    case "Assignments - To Do":
                        this.SelectAssignmentsToDoWindow();
                        switch (assetName)
                        {
                            case "1-1 Homework":
                            case "i1-1 Practice":
                                base.SwitchToIFrameById("ifrmCoursePreview");
                                ICollection<IWebElement> coloumn2Collections = base.GetWebElementsCollectionByCssSelector
                                    (CoursePreviewUXPageResource.CoursePreviewUX_Page_Coloumn2_CssSelector_Locator);
                                int counter = 0;
                                foreach (IWebElement coloumn2 in coloumn2Collections)
                                {
                                    if (coloumn2.Text.Replace("\r\n", " ").Contains(assetName))
                                    {
                                        ICollection<IWebElement> scoreObjectCollections = base.GetWebElementsCollectionByCssSelector
                                            (CoursePreviewUXPageResource.CoursePreviewUX_Page_ScoreValue_CssSelector_Locator);
                                        currentScore = scoreObjectCollections.ElementAt(counter).Text;
                                        break;
                                    }
                                    counter++;
                                }
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage", "GetAssetScore",
                         base.IsTakeScreenShotDuringEntryExit);
            return currentScore;
        }

        /// <summary>
        /// Get Try Again Button Text.
        /// </summary>
        /// <returns>Object Text.</returns>
        public string GetTryAgainButtonText()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage", "GetTryAgainButtonText",
                      base.IsTakeScreenShotDuringEntryExit);
            string objectText = string.Empty;
            try
            {
                base.SwitchToDefaultPageContent();
                SelectAssignmentsToDoWindow();
                this.SwitchToIFrameBySource("StudTodoDone.aspx?From=VTD");
                ICollection<IWebElement> objectTryAgainButtonCollections = base.GetWebElementsCollectionByCssSelector
                         (CoursePreviewUXPageResource.CoursePreviewUX_Page_TryAgain_Button_Class_Locator);
                objectText = objectTryAgainButtonCollections.ElementAt(0).Text;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage", "GetTryAgainButtonText",
                      base.IsTakeScreenShotDuringEntryExit);
            return objectText;
        }

        /// <summary>
        /// Get Im Done Button Text.
        /// </summary>
        /// <returns>Object Text.</returns>
        public string GetImDoneButtonText()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage", "GetImDoneButtonText",
                      base.IsTakeScreenShotDuringEntryExit);
            string objectText = string.Empty;
            try
            {
                ICollection<IWebElement> objectImDoneButtonCollections = base.GetWebElementsCollectionByCssSelector(
                    CoursePreviewUXPageResource.CoursePreviewUX_Page_ImDone_Button_Class_Locator);
                objectText = objectImDoneButtonCollections.ElementAt(0).Text;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage", "GetImDoneButtonText",
                      base.IsTakeScreenShotDuringEntryExit);
            return objectText;
        }

        /// <summary>
        /// Click on activity cmenu based on the cemnu option type,page name activity name
        /// </summary>
        /// <param name="assetCmenu">This is activity cmenu option.</param>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        /// <param name="pageName">This is page name.</param>
        public void ClickCmenuOptionOfTheActivity(string assetCmenu, string activityName, string pageName)
        {
            Logger.LogMethodEntry("CoursePreviewUXPage", "ClickCmenuOptionOfTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(pageName);
                base.SelectWindow(pageName);
                switch (pageName)
                {
                    case "Course Materials":
                        base.WaitForElement(By.Id(CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_CoursePreview_IFrame_Id_Locator));
                        //Switch To Frame
                        base.SwitchToIFrame(CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_CoursePreview_IFrame_Id_Locator);
                        //Click on the Next link if Activity Not Present
                        this.ClickOnNextLinkIfActivityNotPresent(activityName);
                        //Select the Activity
                        int getActivityCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_Activity_Count_Xpath_Locator);
                        for (int rowCount = Convert.ToInt32(CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_Activity_Counter); rowCount <= getActivityCount;
                            rowCount++)
                        {
                            //Gets the Activity Name
                            string getActivityName = base.GetElementTextByXPath
                                (string.Format(CoursePreviewUXPageResource.
                                CoursePreviewUX_Page_ActivityName_Xpath_Locator, rowCount)).Trim();
                            if (getActivityName.Contains(activityName))
                            {
                                this.ClickCmenuOptionByStudentOfActivity(assetCmenu, activityName);
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
            Logger.LogMethodExit("CoursePreviewMainUXPage", "ClickCmenuOptionOfTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        public void ClickCmenuOptionOfTheFolder(string assetCmenu, string folderName, string pageName)
        {
            Logger.LogMethodEntry("CoursePreviewUXPage", "ClickCmenuOptionOfTheFolder",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.WaitUntilWindowLoads(pageName);
                base.SelectWindow(pageName);
                switch (pageName)
                {
                    case "Course Materials":
                        base.WaitForElement(By.Id(CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_CoursePreview_IFrame_Id_Locator));
                        //Switch To Frame
                        base.SwitchToIFrame(CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_CoursePreview_IFrame_Id_Locator);
                        //Click on the Next link if Activity Not Present
                        this.ClickOnNextLinkIfActivityNotPresent(folderName);
                        //Select the Activity
                        int getActivityCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_Activity_Count_Xpath_Locator);
                        for (int rowCount = Convert.ToInt32(CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_Activity_Counter); rowCount <= getActivityCount;
                            rowCount++)
                        {
                            //Gets the Activity Name
                            string getFolderName = base.GetElementTextByXPath
                                (string.Format(CoursePreviewUXPageResource.
                                CoursePreviewUX_Page_ActivityName_Xpath_Locator, rowCount)).Trim();
                            if (getFolderName.Contains(folderName))
                            {
                                this.ClickCmenuOptionByStudentOfFolder(assetCmenu, folderName);
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
            Logger.LogMethodExit("CoursePreviewMainUXPage", "ClickCmenuOptionOfTheFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Student click on cmenu option for activity.
        /// </summary>
        /// <param name="assetCmenu">This is Cmenu option.</param>
        /// <param name="activityName">This is activity name.</param>
        private void ClickCmenuOptionByStudentOfActivity(string assetCmenu, string activityName)
        {
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "ClickCmenuOptionByStudentOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(activityName));
            IWebElement getActivityLink = base.GetWebElementPropertiesByPartialLinkText(activityName);
            base.PerformMouseHoverByJavaScriptExecutor(getActivityLink);
            //Get ID of the activity name
            string getCmenuElementID = base.GetIdAttributeValueByPartialLinkText(activityName);
            //Remove the text and get the assetid of the activity
            string cmenuProperty = getCmenuElementID.Remove(0, 8);
            //Generate the asset cmenu icon id by appending the assetID with "tdContext_"
            string cmenuID = "tdContext_" + cmenuProperty;
            string cmenuIconID = cmenuID.Trim();
            // Perform java script mouse click 
            IWebElement getCmenuIcon = base.GetWebElementPropertiesById(cmenuIconID);
            base.PerformMouseClickAction(getCmenuIcon);

            // Launch the cmenu option based on the input provided
            switch (assetCmenu)
            {
                case "View Submissions":
                    //Click on view submission cmenu option
                    IWebElement getViewSubmission = base.GetWebElementPropertiesByXPath(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_ViewSubmissions_Xpath_Locator);
                    base.PerformMouseClickAction(getViewSubmission);
                    break;

                case "Open":
                    //Click on Open cmenu option of activity
                    IWebElement getOpen = base.GetWebElementPropertiesByXPath(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_Open_Xpath_Locator);
                    base.PerformMouseClickAction(getOpen);
                    break;

                case "View Grades":
                    //Click on View Grades cmenu option
                    IWebElement getViewGrades = base.GetWebElementPropertiesByXPath(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_ViewGrades_Xpath_Locator);
                    base.PerformMouseClickAction(getViewGrades);
                    break;
            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "ClickCmenuOptionByStudentOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select c/menu of Folder
        /// </summary>
        /// <param name="assetCmenu">This is the cmenu</param>
        /// <param name="activityName">This is the folder name</param>
        private void ClickCmenuOptionByStudentOfFolder(string assetCmenu, string activityName)
        {
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "ClickCmenuOptionByStudentOfFolder",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(activityName));
            IWebElement getActivityLink = base.GetWebElementPropertiesByPartialLinkText(activityName);
            base.PerformMouseHoverByJavaScriptExecutor(getActivityLink);
            //Get ID of the folder name
            string getCmenuElementID = base.GetIdAttributeValueByPartialLinkText(activityName);
            //Remove the text and get the assetid of the folder
            string cmenuProperty = getCmenuElementID.Remove(0, 8);
            //Generate the asset cmenu icon id by appending the assetID with "tdContext_"
            string cmenuID = "tdContext_" + cmenuProperty;
            string cmenuIconID = cmenuID.Trim();
            // Perform java script mouse click 
            IWebElement getCmenuIcon = base.GetWebElementPropertiesById(cmenuIconID);
            base.PerformMouseClickAction(getCmenuIcon);

            // Launch the cmenu option based on the input provided
            switch (assetCmenu)
            {

                case "Open":
                    //Click on Open cmenu option of Folder
                    IWebElement getOpen = base.GetWebElementPropertiesByXPath(CoursePreviewMainUXPageResource.
                        CoursePreviewMainUX_Page_FolderOpen_Xpath_Locator);
                    base.PerformMouseClickAction(getOpen);
                    break;

            }
            Logger.LogMethodExit("CoursePreviewMainUXPage", "ClickCmenuOptionByStudentOfFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Next link if assesst is not available in current the Page
        /// </summary>
        /// <param name="activityName">This is the activity name</param>
        private void ClickOnNextLinkIfActivityNotPresent(string activityName)
        {
            Logger.LogMethodEntry("CoursePreviewMainUXPage", "ClickOnNextLinkIfActivityNotPresent",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Initialized Variable
                string getTableText = string.Empty;
                do
                {
                    //tblCoursePreview
                    base.WaitForElement(By.Id(CoursePreviewUXPageResource.
                        CoursePreviewUX_Page_CoursePreview_Id_Locator));
                    getTableText = base.GetElementTextById(CoursePreviewUXPageResource.
                        CoursePreviewUX_Page_CoursePreview_Id_Locator);
                    Thread.Sleep(Convert.ToInt32(CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_Search_Time_Value));
                    if (!getTableText.Contains(activityName))
                    {
                        if (base.IsElementPresent(By.Id(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_Searched_Table_Next_Id_Locator), Convert.ToInt32
                            (CoursePreviewUXPageResource.CoursePreviewUX_Page_Customized_TimeOut)))
                        {
                            IWebElement getNextButton = base.GetWebElementPropertiesById
                                (CoursePreviewUXPageResource.
                            CoursePreviewUXPage_Searched_Table_Next_Id_Locator);
                            //Click on the Next
                            base.ClickByJavaScriptExecutor(getNextButton);
                            Thread.Sleep(Convert.ToInt32(CoursePreviewUXPageResource.
                                CoursePreviewUXPage_ElementLoad_Time_Value));
                            //Select Default Window
                            base.SelectDefaultWindow();
                            base.SwitchToIFrame(CoursePreviewUXPageResource.
                                CoursePreviewUX_Page_CoursePreview_IFrame_Id_Locator);
                            getTableText = base.GetElementTextById(CoursePreviewUXPageResource.
                                CoursePreviewUX_Page_CoursePreview_Id_Locator);
                        }
                    }
                } while (!getTableText.Contains(activityName));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ContentLibraryUXPage", "ClickOnNextLinkIfActivityNotPresent",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the display of Congratulation message after submitting badge activity
        /// </summary>
        /// <returns></returns>
        public bool isCongralutionMessageDisplayedforBadge()
        {
            // Validate the Congratulations message is displayed after submitting badged activity
            Logger.LogMethodEntry("CoursePreviewUXPage",
                "isCongralutionMessageDisplayedforBadge",
                base.IsTakeScreenShotDuringEntryExit);
            // Initiate variable
            bool isCongratulationDisplayed = false;
            try
            {
                Thread.Sleep(3000);
                new StudentPresentationPage().SelectWindowAndFrame();
                base.WaitForElementDisplayedInUi(By.Id(
                    CoursePreviewUXPageResource.CoursePreviewUX_Page_Badge_Message_Id_Locator));
                isCongratulationDisplayed = base.IsElementDisplayedInPage(By.Id(
                    CoursePreviewUXPageResource.CoursePreviewUX_Page_Badge_Message_Id_Locator), true, 10);
                //if (isCongratulationDisplayed)
                //{
                //    isbadgepresent = true;
                //}               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage",
                "isCongralutionMessageDisplayedforBadge",
                base.IsTakeScreenShotDuringEntryExit);
            return isCongratulationDisplayed;
        }

        /// <summary>
        /// Click Create new folder in Course Materials tab
        /// </summary>
        public void ClickCreateFolder()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage",
                "ClickCreateFolder",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                // Switch to iframe
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);
                // Wait for Create folder option to load
                base.WaitForElement(By.Id(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CreateNewFolder_Button_Id_Locator));
                // Click Folder option
                IWebElement getCreateFolder = base.GetWebElementProperties(By.Id(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CreateNewFolder_Button_Id_Locator));
                base.PerformMouseClickAction(getCreateFolder);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage",
            "ClickCreateFolder",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Create new folder
        /// </summary>
        public void ClickCreateMaterials()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage",
                "ClickCreateFolder",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window loads
                Thread.Sleep(100);
                base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                // Switch to iframe
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);
                // Wait for Create folder option to load
                base.WaitForElement(By.XPath(
                    CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_CreateMaterials_Button_XPath_Locator));
                // Click Folder option
                IWebElement getCreateFolder = base.GetWebElementProperties(
                    By.XPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_CreateMaterials_Button_XPath_Locator));
                base.PerformMouseClickAction(getCreateFolder);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage",
            "ClickCreateFolder",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Return To Course Materials Button
        /// </summary>
        public void ClickReturnToCourseMaterialsButton(string buttonName)
        {
            Logger.LogMethodEntry("CoursePreviewUXPage",
                "ClickReturnToCourseMaterialsButton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                // Wait for Return to Course Materials button to load
                base.WaitForElement(By.XPath(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_CourseMaterials_ReturnToCourseMaterials_XPath_Locator));
                // Click Return to Course Materials button
                IWebElement getCreateFolder = base.GetWebElementProperties(
                    By.XPath(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_CourseMaterials_ReturnToCourseMaterials_XPath_Locator));
                base.PerformMouseClickAction(getCreateFolder);
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage",
            "ClickReturnToCourseMaterialsButton",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Reorder the asset in course materia page
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        public void ReorderAssetInCourseMaterial(Activity.ActivityTypeEnum activityTypeEnum)
        {
            Logger.LogMethodExit("ContentLibraryUXPage", "ReorderAssetInCourseMaterial",
                base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            Activity activity = Activity.Get(activityTypeEnum);
            string activityName = activity.Name.ToString();
            int pageCount = Convert.ToInt32(0);
            try
            {
                base.WaitUntilWindowLoads("Course Materials");
                base.SelectWindow("Course Materials");
                base.SwitchToIFrameById("ifrmCoursePreview");
                int getActivityCount = base.GetElementCountByXPath("//table[@id='tblCoursePreview']/tbody/tr");

                bool pageNumberExist = base.IsElementPresent(By.XPath("//td[@class='PD_PRdivpagingCenter']/span[4]"), 10);

                if (pageNumberExist == true)
                {
                    string getPageCountDetails = base.GetInnerTextAttributeValueByXPath("//td[@class='PD_PRdivpagingCenter']/span[4]").Trim();
                    string getTotalPageCount = getPageCountDetails.Substring(3);
                    pageCount = Convert.ToInt32(getTotalPageCount);
                }
                else
                {
                    pageCount = Convert.ToInt32(1);
                }
                for (int pageNumber = Convert.ToInt32(1); pageNumber <= pageCount; pageNumber++)
                {
                    for (int rowCount = Convert.ToInt32(1); rowCount <= getActivityCount;
                        rowCount++)
                    {
                        //Gets the Activity Name
                        getActivityName = base.GetElementTextByXPath
                            (string.Format("//table[@id='tblCoursePreview']/tbody/tr[{0}]/td[2]/table/tbody/tr/td[2]", rowCount)).Trim();
                        if (getActivityName.Equals(activityName))
                        {
                            bool tg = base.IsElementPresent(By.XPath("//table[@id='tblCoursePreview']/tbody/tr[1]/td[5]/i"), 5);
                            //Wait for the element
                            base.WaitForElement(By.XPath(string.Format("//table[@id='tblCoursePreview']/tbody/tr[{0}]/td[5]/i", rowCount)));
                            //Drag and Drop
                            base.PerformClickAndHoldAction(base.
                                GetWebElementPropertiesByXPath(string.Format("//table[@id='tblCoursePreview']/tbody/tr[{0}]/td[5]/i", rowCount)));
                            //Wait for the element
                            base.WaitForElement(By.XPath(string.Format("//table[@id='tblCoursePreview']/tbody/tr[{0}]/td[5]/i", rowCount + 1)));
                            //Drag and Drop
                            base.PerformClickAndHoldAction(base.
                                GetWebElementPropertiesByXPath(string.Format("//table[@id='tblCoursePreview']/tbody/tr[{0}]/td[5]/i", rowCount + 1)));
                            return;
                        }
                    }
                    IWebElement getNextIcon = base.GetWebElementPropertiesById("rptCoursePreview$next");
                    base.ClickByJavaScriptExecutor(getNextIcon);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ContentLibraryUXPage", "ReorderAssetInCourseMaterial",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click cmenu optin of asset in managecourse material.
        /// </summary>
        /// <param name="cmenuOptionName">This is cmenu option name.</param>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        public void CourseMaterialCmenuFunctionlaity(string cmenuOptionName, Activity.ActivityTypeEnum activityTypeEnum)
        {
            Logger.LogMethodExit("ContentLibraryUXPage", "ReorderAssetInCourseMaterial",
             base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            Activity activity = Activity.Get(activityTypeEnum);
            string activityName = activity.Name.ToString();
            int pageCount = Convert.ToInt32(0);
            try
            {
                base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_CoursePreview_IFrame_Id_Locator);
                int getActivityCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_GetActivityCount_XPath_Locator);

                bool pageNumberExist = base.IsElementPresent(By.XPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_Pagination_Count_XPath_Locator), 10);

                if (pageNumberExist == true)
                {
                    string getPageCountDetails = base.GetInnerTextAttributeValueByXPath(
                        CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Pagination_Count_XPath_Locator).Trim();
                    string getTotalPageCount = getPageCountDetails.Substring(3);
                    pageCount = Convert.ToInt32(getTotalPageCount);
                }
                else
                {
                    pageCount = Convert.ToInt32(1);
                }
                for (int pageNumber = Convert.ToInt32(1); pageNumber <= pageCount; pageNumber++)
                {
                    for (int rowCount = Convert.ToInt32(1); rowCount <= getActivityCount;
                        rowCount++)
                    {
                        //Gets the Activity Name
                        getActivityName = base.GetElementTextByXPath
                            (string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_GetActivityName_XPath_Locator, rowCount)).Trim();
                        if (getActivityName.Equals(activityName))
                        {
                            switch (cmenuOptionName)
                            {
                                case "Open":
                                    // Click cmenu icon
                                    bool te = base.IsElementPresent(By.XPath(
                                        string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_OpenActivity_CMenu_XPath_Locator,
                                        rowCount)), 10);
                                    IWebElement getCmenuOption = base.GetWebElementPropertiesByXPath(
                                        string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_OpenActivity_CMenu_XPath_Locator, rowCount));
                                    base.PerformMouseClickAction(getCmenuOption);
                                    // Click cmenu option                                    
                                    base.WaitForElement(By.ClassName("cmenu_cont"));
                                    bool ads = base.IsElementPresent(By.LinkText(cmenuOptionName), 10);

                                    break;
                                case "Edit":
                                    break;
                                case "Properties":
                                    break;
                                case "Show/Hide":
                                    break;
                                case "Get Information":
                                    break;
                                case "Remove":
                                    break;
                                case "Delete Assignment":
                                    break;
                            }
                            return;
                        }
                    }
                    IWebElement getNextIcon = base.GetWebElementPropertiesById(CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Searched_Table_Next_Id_Locator);
                    base.ClickByJavaScriptExecutor(getNextIcon);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Get activity display status
        /// </summary>
        /// <param name="tabName"></param>
        public string GetAssetName(string activityName, string tabName)
        {
            Logger.LogMethodExit("ContentLibraryUXPage", "ReorderAssetInCourseMaterial",
             base.IsTakeScreenShotDuringEntryExit);
            int pageCount = Convert.ToInt32(0);
            // Initialize the asset name variable to empty
            string getAssetName = string.Empty;
            string getActivityName = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(tabName);
                base.SelectWindow(tabName);
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);
                int getActivityCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_GetActivityCount_XPath_Locator);
                // Check pagination existance
                pageCount = this.CheckPaginationStatus();
                for (int pageNumber = Convert.ToInt32(1); pageNumber <= pageCount; pageNumber++)
                {
                    for (int rowCount = Convert.ToInt32(1); rowCount <= getActivityCount;
                        rowCount++)
                    {
                        //Gets the Activity Name
                        getActivityName = base.GetElementTextByXPath
                            (string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_GetActivityName_XPath_Locator, rowCount)).Trim();
                        if (getActivityName.Equals(activityName))
                        {
                            return getActivityName;
                        }
                    }
                    bool iconStatus = base.IsElementPresent(By.Id("rptCoursePreview$next"), 10);
                    if (iconStatus == true)
                    {
                        IWebElement getNextIcon = base.GetWebElementPropertiesById("rptCoursePreview$next");
                        base.ClickByJavaScriptExecutor(getNextIcon);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ContentLibraryUXPage", "ReorderAssetInCourseMaterial",
             base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Check paagination existance in Manage course material
        /// </summary>
        public int CheckPaginationStatus()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage", "CheckPaginationStatus",
                base.IsTakeScreenShotDuringEntryExit);
            int pageCount = Convert.ToInt32(0);
            try
            {
                // Get pagination exist status
                bool pageNumberExist = base.IsElementPresent(By.XPath(
                    CoursePreviewUXPageResource.
                    CoursePreviewUXPage_Pagination_Count_XPath_Locator), 5);

                // Check if the page number exist
                if (pageNumberExist == true)
                {
                    // Get page number count
                    string getPageCountDetails = base.GetInnerTextAttributeValueByXPath(
                        CoursePreviewUXPageResource.
                    CoursePreviewUXPage_Pagination_Count_XPath_Locator).Trim();
                    // Trim and get the page total count
                    string getTotalPageCount = getPageCountDetails.Substring(3);
                    // Convert the page number to int
                    pageCount = Convert.ToInt32(getTotalPageCount);
                }
                else
                {
                    pageCount = Convert.ToInt32(1);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("CoursePreviewUXPage", "CheckPaginationStatus",
                base.IsTakeScreenShotDuringEntryExit);
            return pageCount;
        }

        /// <summary>
        /// Check paagination existance in Manage course material
        /// </summary>
        private int CheckPaginationStatusMyCourse()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage", "CheckPaginationStatus",
                base.IsTakeScreenShotDuringEntryExit);
            int pageCount = Convert.ToInt32(0);
            try
            {
                // Get pagination exist status
                bool pageNumberExist = base.IsElementPresent(By.XPath(
                    CoursePreviewUXPageResource.
                    CoursePreviewUXPage_Pagination_Count_MyCourse_XPath_Locator), 5);

                // Check if the page number exist
                if (pageNumberExist == true)
                {
                    // Get page number count
                    string getPageCountDetails = base.GetInnerTextAttributeValueByXPath(
                        CoursePreviewUXPageResource.
                    CoursePreviewUXPage_Pagination_Count_MyCourse_XPath_Locator).Trim();
                    // Trim and get the page total count
                    string getTotalPageCount = getPageCountDetails.Substring(17).Trim();
                    // Convert the page number to int
                    pageCount = Convert.ToInt32(getTotalPageCount);
                }
                else
                {
                    pageCount = Convert.ToInt32(1);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("CoursePreviewUXPage", "CheckPaginationStatus",
                base.IsTakeScreenShotDuringEntryExit);
            return pageCount;
        }
        /// <summary>
        /// Click on show option
        /// </summary>
        /// <param name="actionName">This is action name.</param>
        /// <param name="activityType">This is activity type enum.</param>
        /// <param name="tabName">This is tab name.</param>
        public void ClickShowOption(string actionName, Activity.ActivityTypeEnum activityType,
            string tabName)
        {
            Logger.LogMethodExit("ContentLibraryUXPage", "ReorderAssetInCourseMaterial",
                base.IsTakeScreenShotDuringEntryExit);
            int pageCount = Convert.ToInt32(0);

            // Get the activity name from enum
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();

            // Initialize the asset name variable to empty
            string getAssetName = string.Empty;
            string getActivityName = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(tabName);
                base.SelectWindow(tabName);
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);
                int getActivityCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_GetActivityCount_XPath_Locator);
                // Check pagination existance
                pageCount = this.CheckPaginationStatus();
                for (int pageNumber = Convert.ToInt32(1); pageNumber <= pageCount; pageNumber++)
                {
                    for (int rowCount = Convert.ToInt32(1); rowCount <= getActivityCount;
                        rowCount++)
                    {
                        //Gets the Activity Name
                        getActivityName = base.GetElementTextByXPath
                            (string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_GetActivityName_XPath_Locator, rowCount)).Trim();
                        if (getActivityName.Equals(activityName))
                        {
                            string getActivityStatus = base.GetClassAttributeValueByXPath(
                                string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_GetActivityStatus_XPath_Locator
                                , rowCount));
                            if (getActivityStatus == CoursePreviewUXPageResource.
                            CoursePreviewUXPage_ActualActivityStatus)
                            {
                                base.WaitForElement(By.XPath(string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_SelectActivity_Checkbox_XPath_Locator
                                    , rowCount)));
                                base.SelectCheckBoxByXPath(string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_SelectActivity_Checkbox_XPath_Locator, rowCount));
                                //Click on Show option
                                base.WaitForElement(By.XPath(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_ShowLink_XPath_Locator));
                                IWebElement getShowOption = base.GetWebElementPropertiesByXPath(
                                    CoursePreviewUXPageResource.
                            CoursePreviewUXPage_ShowLink_XPath_Locator);
                                base.ClickByJavaScriptExecutor(getShowOption);
                                return;
                            }
                        }
                    }
                    IWebElement getNextIcon = base.GetWebElementPropertiesById(
                        CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Searched_Table_Next_Id_Locator);
                    base.ClickByJavaScriptExecutor(getNextIcon);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ContentLibraryUXPage", "ReorderAssetInCourseMaterial",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get asset status
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        /// <returns>Return status.</returns>
        public string GetAssetStatus(Activity.ActivityTypeEnum activityType)
        {
            Logger.LogMethodEntry("ContentLibraryUXPage", "GetAssetStatus",
             base.IsTakeScreenShotDuringEntryExit);
            string getAssetStatus = string.Empty;
            // Get the activity name from enum
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();
            int pageCount = Convert.ToInt32(0);
            // Initialize the asset name variable to empty
            string getAssetName = string.Empty;
            string getActivityName = string.Empty;
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                // Switch to iframe
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);
                int getActivityCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_GetActivityCount_XPath_Locator);
                // Check pagination existance
                pageCount = this.CheckPaginationStatus();
                for (int pageNumber = Convert.ToInt32(1); pageNumber <= pageCount; pageNumber++)
                {
                    for (int rowCount = Convert.ToInt32(1); rowCount <= getActivityCount;
                        rowCount++)
                    {
                        //Gets the Activity Name
                        getActivityName = base.GetElementTextByXPath
                            (string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_GetActivityName_XPath_Locator, rowCount)).Trim();
                        if (getActivityName.Equals(activityName))
                        {
                            string getShowToStatus = base.GetInnerTextAttributeValueByXPath
                                (string.Format(CoursePreviewUXPageResource.
                        CoursePreviewUXPage_GetShowStatus_XPath_Locator, rowCount));
                            string getActivity = base.GetClassAttributeValueByXPath
                                (string.Format(CoursePreviewUXPageResource.
                                CoursePreviewUXPage_GetActivityStatus_XPath_Locator, rowCount));
                            if (getActivity.Contains(CoursePreviewUXPageResource.
                                CoursePreviewUXPage_GetActivityStatus) && getShowToStatus == "All")
                            {
                                getAssetStatus = "Show";
                                return getAssetStatus;
                            }
                        }
                    }
                    IWebElement getNextIcon = base.GetWebElementPropertiesById(
                        CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Searched_Table_Next_Id_Locator);
                    base.ClickByJavaScriptExecutor(getNextIcon);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("ContentLibraryUXPage", "GetAssetStatus",
            base.IsTakeScreenShotDuringEntryExit);
            return getAssetStatus;
        }

        /// <summary>
        /// Click copy option in Manage course material page
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        /// <param name="pageTitle">This is page title.</param>
        public void ClickCopyOption(Activity.ActivityTypeEnum activityType, string tabName)
        {
            Logger.LogMethodEntry("ContentLibraryUXPage", "ClickCopyOption",
            base.IsTakeScreenShotDuringEntryExit);
            int pageCount = Convert.ToInt32(0);

            // Get the activity name from enum
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();

            // Initialize the asset name variable to empty
            string getAssetName = string.Empty;
            string getActivityName = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(tabName);
                base.SelectWindow(tabName);
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);
                int getActivityCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_GetActivityCount_XPath_Locator);
                // Check pagination existance
                pageCount = this.CheckPaginationStatus();
                for (int pageNumber = Convert.ToInt32(1); pageNumber <= pageCount; pageNumber++)
                {
                    for (int rowCount = Convert.ToInt32(1); rowCount <= getActivityCount;
                        rowCount++)
                    {
                        //Gets the Activity Name
                        getActivityName = base.GetElementTextByXPath
                            (string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_GetActivityName_XPath_Locator, rowCount)).Trim();
                        if (getActivityName.Equals(activityName))
                        {

                            base.WaitForElement(By.XPath(string.Format(CoursePreviewUXPageResource.
                                CoursePreviewUXPage_SelectActivity_Checkbox_XPath_Locator, rowCount)));
                            base.SelectCheckBoxByXPath(string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_SelectActivity_Checkbox_XPath_Locator, rowCount));
                            base.WaitForElement(By.Id(CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Activity_Copy_XPath_Locator));
                            IWebElement getShowOption = base.GetWebElementPropertiesById(
                                CoursePreviewUXPageResource.
                    CoursePreviewUXPage_Activity_Copy_XPath_Locator);
                            base.ClickByJavaScriptExecutor(getShowOption);
                            return;

                        }
                    }
                    IWebElement getNextIcon = base.GetWebElementPropertiesById(
                        CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Searched_Table_Next_Id_Locator);
                    base.ClickByJavaScriptExecutor(getNextIcon);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("ContentLibraryUXPage", "ClickCopyOption",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get copied asset count.
        /// </summary>
        /// <returns>Return copied asset count.</returns>
        public int GetCopiedAssetCount()
        {
            Logger.LogMethodEntry("ContentLibraryUXPage", "GetCopiedAssetCount",
            base.IsTakeScreenShotDuringEntryExit);
            int getCopiedAssetCount = Convert.ToInt32(0);
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                // Switch to iframe
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);
                string getstringCopiedAssetCount = base.GetInnerTextAttributeValueById(
                    CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_ActivityCopiedCount_Id_Locator);
                getCopiedAssetCount = Convert.ToInt32(getstringCopiedAssetCount);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ContentLibraryUXPage", "GetCopiedAssetCount",
            base.IsTakeScreenShotDuringEntryExit);
            return getCopiedAssetCount;
        }

        /// <summary>
        /// Paste the copied asset in manage course material.
        /// </summary>
        /// <param name="pasteOptionType">This is paste option type.</param>
        public void PasteTheCopiedAsset(string pasteOptionType)
        {
            Logger.LogMethodEntry("ContentLibraryUXPage", "PasteTheCopiedAsset",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                // Switch to iframe
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);
                // Wait for Paste button and click
                base.WaitForElement(By.Id(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_PasteButton_Id_Locator));
                IWebElement getPasteOption = base.GetWebElementPropertiesById(
                    CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_PasteButton_Id_Locator);
                base.PerformMouseClickAction(getPasteOption);
                // Select paste option type
                base.WaitForElement(By.Id(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_SelectPasteButton_Id_Locator));
                // Switch based on the option type 
                switch (pasteOptionType)
                {
                    case "Paste at Bottom":
                        base.WaitForElement(By.XPath(CoursePreviewUXPageResource.
                        CoursePreviewUXPage_CourseMaterial_PasteAtBottom_XPath_Locator));
                        IWebElement getPasteOptionName = base.GetWebElementPropertiesByXPath(
                            CoursePreviewUXPageResource.
                            CoursePreviewUXPage_CourseMaterial_PasteAtBottom_XPath_Locator);
                        base.PerformMouseClickAction(getPasteOptionName);
                        break;

                    case "Paste at Top":
                        base.WaitForElement(By.XPath(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_CourseMaterial_PasteAtTop_XPath_Locator));
                        getPasteOptionName = base.GetWebElementPropertiesByXPath(
                            CoursePreviewUXPageResource.
                            CoursePreviewUXPage_CourseMaterial_PasteAtTop_XPath_Locator);
                        base.PerformMouseClickAction(getPasteOptionName);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ContentLibraryUXPage", "PasteTheCopiedAsset",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click copy option in Manage course material page
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        /// <param name="pageTitle">This is page title.</param>
        public void ClickAssignOption(Activity.ActivityTypeEnum activityType, string tabName)
        {
            Logger.LogMethodEntry("ContentLibraryUXPage", "ClickCopyOption",
            base.IsTakeScreenShotDuringEntryExit);
            int pageCount = Convert.ToInt32(0);

            // Get the activity name from enum
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();

            // Initialize the asset name variable to empty
            string getAssetName = string.Empty;
            string getActivityName = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(tabName);
                base.SelectWindow(tabName);
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);
                int getActivityCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_GetActivityCount_XPath_Locator);
                // Check pagination existance
                pageCount = this.CheckPaginationStatus();
                for (int pageNumber = Convert.ToInt32(1); pageNumber <= pageCount; pageNumber++)
                {
                    for (int rowCount = Convert.ToInt32(1); rowCount <= getActivityCount;
                        rowCount++)
                    {
                        //Gets the Activity Name
                        getActivityName = base.GetElementTextByXPath
                            (string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_GetActivityName_XPath_Locator, rowCount)).Trim();
                        if (getActivityName.Equals(activityName))
                        {
                            base.WaitForElement(By.XPath(string.Format(CoursePreviewUXPageResource.
                                CoursePreviewUXPage_SelectActivity_Checkbox_XPath_Locator, rowCount)));
                            //Select the Checkbox of the activity
                            base.SelectCheckBoxByXPath(string.Format(CoursePreviewUXPageResource.
                                CoursePreviewUXPage_SelectActivity_Checkbox_XPath_Locator, rowCount));
                            base.WaitForElement(By.Id(CoursePreviewUXPageResource.
                                CoursePreviewUXPage_AssignActivity_button_ID_Locator));
                            //Assign the Activity
                            IWebElement getShowOption = base.GetWebElementPropertiesById(
                                CoursePreviewUXPageResource.
                                CoursePreviewUXPage_AssignActivity_button_ID_Locator);
                            base.ClickByJavaScriptExecutor(getShowOption);
                            // Check if the Assign Alert popup if dispalyed
                            base.SwitchToLastOpenedWindow();
                            bool alertPopupExistStatus1 = base.IsElementPresent(By.ClassName(CoursePreviewUXPageResource.
                                CoursePreviewUXPage_CourseMaterials_alertPopup_Classname_Locator), 10);
                            base.SwitchToIFrameById("ifrmCoursePreview");
                            bool alertPopupExistStatus = base.IsElementPresent(By.Id("confimationModal"), 10);
                            if (alertPopupExistStatus == true)
                            {
                                //Click on Ok in confirmation popup
                                bool jui = base.IsElementPresent(By.Id("confirm"), 10);
                                base.ClickButtonById("confirm");
                                //base.ClickButtonById(CoursePreviewUXPageResource.
                                //CoursePreviewUXPage_CourseMaterials_alertPopup_OKButton_ID_Locator);
                            }
                            return;
                        }
                    }
                    IWebElement getNextIcon = base.GetWebElementPropertiesById(CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Searched_Table_Next_Id_Locator);
                    base.ClickByJavaScriptExecutor(getNextIcon);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ContentLibraryUXPage", "ClickCopyOption",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click copy option in Manage course material page
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        /// <param name="pageTitle">This is page title.</param>
        public void ClickDeleteOption(Activity.ActivityTypeEnum activityType, string tabName)
        {
            Logger.LogMethodEntry("ContentLibraryUXPage", "ClickCopyOption",
            base.IsTakeScreenShotDuringEntryExit);
            int pageCount = Convert.ToInt32(0);

            // Get the activity name from enum
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();

            // Initialize the asset name variable to empty
            string getAssetName = string.Empty;
            string getActivityName = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(tabName);
                base.SelectWindow(tabName);
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);
                int getActivityCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_GetActivityCount_XPath_Locator);
                // Check pagination existance
                pageCount = this.CheckPaginationStatus();
                for (int pageNumber = Convert.ToInt32(1); pageNumber <= pageCount; pageNumber++)
                {
                    for (int rowCount = Convert.ToInt32(1); rowCount <= getActivityCount;
                        rowCount++)
                    {
                        //Gets the Activity Name
                        getActivityName = base.GetElementTextByXPath
                            (string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_GetActivityName_XPath_Locator, rowCount)).Trim();
                        if (getActivityName.Equals(activityName))
                        {
                            //Select the Activity checkbox
                            base.WaitForElement(By.XPath(string.Format(CoursePreviewUXPageResource.
                                CoursePreviewUXPage_SelectActivity_Checkbox_XPath_Locator, rowCount)));
                            base.SelectCheckBoxByXPath(string.Format(CoursePreviewUXPageResource.
                                CoursePreviewUXPage_SelectActivity_Checkbox_XPath_Locator, rowCount));
                            base.WaitForElement(By.Id(CoursePreviewUXPageResource.
                                CoursePreviewUXPage_SelectActivity_Delete_button_ID_Locator));
                            IWebElement getShowOption = base.GetWebElementPropertiesById(
                                CoursePreviewUXPageResource.
                                CoursePreviewUXPage_SelectActivity_Delete_button_ID_Locator);
                            base.ClickByJavaScriptExecutor(getShowOption);
                            // W
                            base.SwitchToLastOpenedWindow();
                            bool alertPopupExistStatus = base.IsElementPresent(By.ClassName(
                                CoursePreviewUXPageResource.
                                CoursePreviewUXPage_CourseMaterials_alertPopup_Classname_Locator), 10);
                            base.WaitForElement(By.Id(CoursePreviewUXPageResource.
                                    CoursePreviewUXPage_CourseMaterials_alertPopup_OKButton_ID_Locator));
                            if (alertPopupExistStatus == true)
                            {
                                base.ClickButtonById(CoursePreviewUXPageResource.
                                    CoursePreviewUXPage_CourseMaterials_alertPopup_OKButton_ID_Locator);
                            }
                            return;
                        }
                    }
                    //Click on Next button in the current page
                    IWebElement getNextIcon = base.GetWebElementPropertiesById(CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Searched_Table_Next_Id_Locator);
                    base.ClickByJavaScriptExecutor(getNextIcon);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("ContentLibraryUXPage", "ClickCopyOption",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the assignment status of the asset assigned
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        /// <param name="pageName">This is page name.</param>
        /// <returns>Return assignment status.</returns>
        public bool GetAssignmentStatus(Activity.ActivityTypeEnum activityType, string tabName, string status)
        {
            Logger.LogMethodEntry("ContentLibraryUXPage", "ClickCopyOption",
            base.IsTakeScreenShotDuringEntryExit);
            string getactualAssignmentStatus = string.Empty;
            bool getAssignmentStatus = false;
            int pageCount = Convert.ToInt32(0);
            // Initialize the asset name variable to empty
            string getAssetName = string.Empty;
            string getActivityName = string.Empty;

            // Get the activity name from enum
            Activity activity = Activity.Get(activityType);
            string activityName = activity.Name.ToString();

            try
            {
                base.WaitUntilWindowLoads(tabName);
                base.SelectWindow(tabName);
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);
                int getActivityCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_GetActivityCount_XPath_Locator);
                // Check pagination existance
                pageCount = this.CheckPaginationStatus();
                for (int pageNumber = Convert.ToInt32(1); pageNumber <= pageCount; pageNumber++)
                {
                    for (int rowCount = Convert.ToInt32(1); rowCount <= getActivityCount;
                        rowCount++)
                    {
                        //Gets the Activity Name
                        getActivityName = base.GetElementTextByXPath
                            (string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_GetActivityName_XPath_Locator,
                            rowCount)).Trim();
                        if (getActivityName.Equals(activityName))
                        {
                            base.WaitForElement(By.XPath(string.Format(
                                CoursePreviewUXPageResource.
                            CoursePreviewUXPage_Activity_ExpectedStatus, rowCount)));
                            getactualAssignmentStatus = base.GetInnerTextAttributeValueByXPath(
                                string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUXPage_Activity_ExpectedStatus, rowCount));
                            if (getactualAssignmentStatus.Contains(status))
                            {
                                return getAssignmentStatus = true;
                            }
                        }
                    }
                    IWebElement getNextIcon = base.GetWebElementPropertiesById(
                        CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Searched_Table_Next_Id_Locator);
                    base.ClickByJavaScriptExecutor(getNextIcon);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return getAssignmentStatus;
        }

        /// <summary>
        /// Get success message from application
        /// </summary>
        /// <returns>Return success message.</returns>
        public string GetSuccessMessage(string tabName)
        {
            string successMessage = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(tabName);
                base.SelectWindow(tabName);
                bool asd = base.IsElementPresent(By.ClassName("messagesucessfont"), 10);
                successMessage = base.GetInnerTextAttributeValueByClassName(
                    CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Action_Successful_Classname_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            return successMessage;
        }

        /// <summary>
        /// Click on note icon.
        /// </summary>
        /// <param name="pageName">This is page name.</param>
        public void ClickNoteIcon(string pageName)
        {
            Logger.LogMethodEntry("ContentLibraryUXPage", "ClickCopyOption",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait for page load
                base.WaitUntilWindowLoads(pageName);
                base.SelectWindow(pageName);
                // Switch to iframe
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);
                // Click note icon
                base.WaitForElement(By.XPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_ClickNoteOption_XPath_Locator));
                IWebElement getNoteIcon = base.GetWebElementPropertiesByXPath(
                    CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_ClickNoteOption_XPath_Locator);
                base.ClickByJavaScriptExecutor(getNoteIcon);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ContentLibraryUXPage", "ClickCopyOption",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click edit button in note window
        /// </summary>
        public void ClickEditInNoteWindow()
        {
            Logger.LogMethodEntry("ContentLibraryUXPage", "ClickEditInNoteWindow",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait for page load
                base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                // Switch to iframe
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);

                // Wait for edit button to load and click
                base.WaitForElement(By.XPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_EditNoteOption_XPath_Locator));
                base.ClickButtonByXPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_EditNoteOption_XPath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ContentLibraryUXPage", "ClickEditInNoteWindow",
            base.IsTakeScreenShotDuringEntryExit);
        }


        public string GetActivityInMyCourse(string activityName, string pageName)
        {
            Logger.LogMethodEntry("AddAssessmentPage", "GetActivityName",
            base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            try
            {
                // Wait untill window loads
                base.WaitUntilWindowLoads(pageName);
                base.SelectWindow(pageName);
                // Switch to iframe
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_CoursePreview_IFrame_Id_Locator);

                string getPageCountDetails = base.GetInnerTextAttributeValueByXPath("//td[@class='PD_PRdivpagingCenter']/span[3]").Trim();
                string getTotalPageCount = getPageCountDetails.Substring(17).Trim();
                int pageCount = Convert.ToInt32(getTotalPageCount);
                for (int pageNumber = Convert.ToInt32(1); pageNumber <= pageCount; pageNumber++)
                {
                    // Get activity count
                    int getActivityCount = (base.GetElementCountByXPath(CoursePreviewUXPageResource.
                        CoursePreviewUXPage_GetActivityCount_XPath_Locator)) - 1;
                    for (int rowCount = Convert.ToInt32(3); rowCount <= getActivityCount;
                        rowCount++)
                    {
                        //Gets the Activity Name
                        bool asd = base.IsElementPresent(By.XPath("//table[@id='tblCoursePreview']/tbody/tr[3]/td[2]/table/tbody/tr/td/table/tbody/tr/td/a"), 10);
                        getActivityName = base.GetElementTextByXPath
                            (string.Format("//table[@id='tblCoursePreview']/tbody/tr[{0}]/td[2]/table/tbody/tr/td/table/tbody/tr/td/a", rowCount)).Trim();
                        if (getActivityName.Equals(activityName))
                        {
                            getActivityName = base.GetElementTextByXPath
                                (string.Format("//table[@id='tblCoursePreview']/tbody/tr[{0}]/td[2]/table/tbody/tr/td/table/tbody/tr/td/a", rowCount)).Trim();
                            return getActivityName;
                        }
                    }
                    IWebElement getNextIcon = base.GetWebElementPropertiesByClassName("PD_icn_pageNext");
                    base.ClickByJavaScriptExecutor(getNextIcon);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AddAssessmentPage", "GetActivityName",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Click activity name.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void ClickActivityName(string activityName, string pageName)
        {
            Logger.LogMethodEntry("AddAssessmentPage", "ClickActivityName",
        base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            try
            {
                base.WaitUntilWindowLoads(pageName);
                base.SelectWindow(pageName);
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_CoursePreview_IFrame_Id_Locator);
                int getActivityCount = (base.GetElementCountByXPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_Page_Activity_TotalCount_Xpath_locator)) - 1;

                for (int rowCount = Convert.ToInt32(3); rowCount <= getActivityCount;
                    rowCount++)
                {
                    //Gets the Activity Name
                    getActivityName = base.GetElementTextByXPath
                        (string.Format(CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Page_Activity_ActivityName_Xpath_locator, rowCount)).Trim();
                    if (getActivityName.Equals(activityName))
                    {
                        IWebElement getAssetTitle = base.GetWebElementPropertiesByXPath(string.Format
                            (CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_Assets_Name_Xpath_Locator, rowCount));
                        base.PerformMouseClickAction(getAssetTitle);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AddAssessmentPage", "ClickActivityName",
                    base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the activity status
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// <returns>Return activity status.</returns>
        public string GetActivitySubmittedStatus(string activityName, int activityColumnCount)
        {
            Logger.LogMethodEntry("AddAssessmentPage", "GetActivityStatus",
            base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            string getActivityStatus = string.Empty;
            try
            {
                for (int rowCount = Convert.ToInt32(3); rowCount <= activityColumnCount;
                    rowCount++)
                {
                    //Gets the Activity Name
                    getActivityName = base.GetElementTextByXPath
                        (string.Format(CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Page_Activity_ActivityName_Xpath_locator, rowCount)).Trim();
                    if (getActivityName.Equals(activityName))
                    {
                        getActivityStatus = base.GetElementTextByXPath
                        (string.Format(CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Page_Activity_ActivityStatus_Xpath_locator, rowCount)).Trim();
                        return getActivityStatus;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AddAssessmentPage", "ClickActivityName",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivityStatus;
        }

        /// <summary>
        /// Get the activity status
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// <returns>Return activity status.</returns>
        public string GetGradeCount(string activityName, int activityColumnCount)
        {
            Logger.LogMethodEntry("AddAssessmentPage", "GetActivityStatus",
            base.IsTakeScreenShotDuringEntryExit);
            string getActivityName = string.Empty;
            string getActivityStatus = string.Empty;
            try
            {
                for (int rowCount = Convert.ToInt32(3); rowCount <= activityColumnCount;
                    rowCount++)
                {
                    //Gets the Activity Name
                    getActivityName = base.GetElementTextByXPath
                        (string.Format(CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Page_Activity_ActivityName_Xpath_locator, rowCount)).Trim();
                    if (getActivityName.Equals(activityName))
                    {
                        getActivityStatus = base.GetElementTextByXPath
                        (string.Format(CoursePreviewUXPageResource.
                        CoursePreviewUXPage_Page_Activity_GetGrade_Xpath_locator, rowCount)).Trim();
                        return getActivityStatus;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AddAssessmentPage", "ClickActivityName",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivityStatus;
        }

        /// <summary>
        /// Get Status Of Submitted Grader IT Activity In CourseMaterial.
        /// </summary>
        /// <param name="assetName">This is Activity Name.</param>
        /// <returns>Activity Status.</returns>
        public string GetActivityStatus(string assetName, string activityStatus)
        {
            //Get Status Of Submitted Activity In CourseMaterial
            Logger.LogMethodEntry("StudentPresentationPage",
                "GetStatusOfSubmittedActivityInCourseMaterial",
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize getStatusText variable
            string getActivitySubmittedStatus = string.Empty;
            try
            {
                //Select Window And Frame
                this.SelectWindowAndFrame();
                //Get The Activity Name In CourseMaterial
                int activityColumnCount =
                    this.GetTheActivityCountInCourseMaterial();
                //Get the status text
                getActivitySubmittedStatus = this.GetActivitySubmittedStatus(assetName, activityColumnCount);
                //Start Stop Watch 
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                //Clicks Till Course Gets Out of Inactive State
                //If still time is pending to verify assigned to copy state
                while (getActivitySubmittedStatus != activityStatus)
                {

                    if (stopWatch.Elapsed.TotalMinutes < 10 == false) break;

                    {
                        base.RefreshTheCurrentPage();
                        //new CommonPage().ManageTheActivityFolderLevelNavigation(
                        //assetName, activityUnderTabName, userTypeEnum);
                        //Select Window And Frame
                        this.SelectWindowAndFrame();
                        //Get The Activity Name In CourseMaterial
                        activityColumnCount =
                           this.GetTheActivityCountInCourseMaterial();
                        //Get the status text
                        getActivitySubmittedStatus = this.GetActivitySubmittedStatus(assetName, activityColumnCount);
                        if (getActivitySubmittedStatus == activityStatus)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("StudentPresentationPage",
                "GetStatusOfSubmittedActivityInCourseMaterial",
                    base.IsTakeScreenShotDuringEntryExit);
            return getActivitySubmittedStatus;
        }


        /// <summary>
        /// Select Window And Frame
        /// </summary>
        private void SelectWindowAndFrame()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage",
                "SelectWindowAndFrame",
                    base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                CoursePreviewUX_Page_Window_Title_Name_HED);
                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                // Switch to iframe
                base.SwitchToIFrameById("ifrmCoursePreview");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage",
            "SelectWindowAndFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Return activity column number
        /// </summary>
        /// <returns>return activity column number</returns>
        private int GetTheActivityCountInCourseMaterial()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage",
                "SelectWindowAndFrame",
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize VariableVariable
            int getActivityCount = Convert.ToInt32(StudentPresentationPageResource.
                StudentPresentation_Page_Loop_Initializer_Value);

            try
            {
                //Wait for the element
                base.WaitForElement(By.XPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_Page_Activity_TotalCount_Xpath_locator));
                // Get activity Count
                getActivityCount = (base.GetElementCountByXPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_Page_Activity_TotalCount_Xpath_locator)) - 1;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage",
            "SelectWindowAndFrame",
                base.IsTakeScreenShotDuringEntryExit);
            return getActivityCount;
        }

        /// <summary>
        /// Student launches the Activity in Course materials tab
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        public void StudentLaunchAssetInCourseMaterials(string activityName)
        {
            //Student launches the Activity in Course materials tab
            Logger.LogMethodEntry("ContentLibraryUXPage", "ClickCopyOption",
            base.IsTakeScreenShotDuringEntryExit);
            int pageCount = Convert.ToInt32(0);
            // Initialize the asset name variable to empty
            string getAssetName = string.Empty;
            string getActivityName = string.Empty;
            try
            {
                //Wait for Course Materials tab to load
                base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                //Select Course Materials tab to load
                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUX_Page_Window_Title_Name_HED);
                base.SwitchToIFrameById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_CourseMaterial_iframe_Id_Locator);
                //Fetch the Activity count in Course Materials tab
                int getActivityCount = base.GetElementCountByXPath(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_GetActivityCount_XPath_Locator);
                // Check pagination existance
                pageCount = this.CheckPaginationStatusMyCourse();
                for (int pageNumber = Convert.ToInt32(1); pageNumber <= pageCount; pageNumber++)
                {
                    for (int rowCount = Convert.ToInt32(3); rowCount <= getActivityCount;
                        rowCount++)
                    {
                        //Fetch the Activity Name
                        getActivityName = base.GetElementTextByXPath
                            (string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_Assets_Name_Xpath_Locator, rowCount)).Trim();
                        if (getActivityName.Equals(activityName))
                        {
                            //Click on the Asset
                            IWebElement getAssetLink = base.GetWebElementPropertiesByXPath(
                                string.Format(CoursePreviewUXPageResource.
                            CoursePreviewUX_Page_Assets_Name_Xpath_Locator, rowCount));
                            base.ClickByJavaScriptExecutor(getAssetLink);
                            return;
                        }
                    }
                    //Click on the next page icon
                    IWebElement getNextIcon = base.GetWebElementPropertiesByClassName(
                      CoursePreviewUXPageResource.
                      CoursePreviewUXPage_MyCourse_NextButton_Class_Locator);
                    base.ClickByJavaScriptExecutor(getNextIcon);                
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("ContentLibraryUXPage", "ClickCopyOption",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grade"></param>
        /// <param name="assetName"></param>
        /// <param name="pageName"></param>
        /// <returns></returns>
        public bool GetGradeAndActivityStatus(string grade,
            string assetName, string pageName)
        {
            //Get Status Of Submitted Activity In CourseMaterial
            Logger.LogMethodEntry("StudentPresentationPage",
                "GetStatusOfSubmittedActivityInCourseMaterial",
                    base.IsTakeScreenShotDuringEntryExit);
            //Initialize status variable
            string getGradeStatus = string.Empty;
            bool status = false;
            try
            {
                //Select Window And Frame
                this.SelectWindowAndFrame();

                string submittedGrade = grade + "%";

                //Get The Activity Name In CourseMaterial
                int activityColumnCount =
                    this.GetTheActivityCountInCourseMaterial();
                //Get the status text
                getGradeStatus = this.GetGradeCount(assetName, activityColumnCount);
                //Start Stop Watch 
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                //Clicks Till Course Gets Out of Inactive State
                //If still time is pending to verify assigned to copy state
                while (getGradeStatus != submittedGrade)
                {
                    if (stopWatch.Elapsed.TotalMinutes < 10 == false) break;
                    {
                        base.RefreshTheCurrentPage();
                        //new CommonPage().ManageTheActivityFolderLevelNavigation(
                        //assetName, activityUnderTabName, userTypeEnum);
                        //Select Window And Frame
                        this.SelectWindowAndFrame();
                        //Get The Activity Name In CourseMaterial
                        activityColumnCount =
                           this.GetTheActivityCountInCourseMaterial();
                        //Get the status text
                        getGradeStatus = this.GetGradeCount(assetName, activityColumnCount);
                        if (getGradeStatus == submittedGrade)
                        {
                            status = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("StudentPresentationPage",
                "GetStatusOfSubmittedActivityInCourseMaterial",
                    base.IsTakeScreenShotDuringEntryExit);

            return status;
        }

        /// <summary>
        /// Save Study Plan Details
        /// </summary>
        /// <param name="studyPlanName">This is Study Plan name.</param>
        public void SaveStudyPlanDetails(Activity.ActivityTypeEnum studyPlanName)
        {
            Logger.LogMethodEntry("CoursePreviewUXPage",
                "ClickCreateFolder",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait untill add myitlab study plan window loads
                base.WaitUntilWindowLoads(CoursePreviewUXPageResource.CoursePreviewUXPage_AddStudyPlanPage_Pagename);
                // Generate GUID for course
                Guid assesmentGUID = Guid.NewGuid();
                //Get the system date
                String date = DateTime.Now.ToString("yyyy/MM/dd");
                //Fetch the random value
                string randomValue = assesmentGUID.ToString().Split('-')[0];
                //Store empty value to courseNameGUID variable
                string studyPlanGUID = string.Empty;
                //Append the data and New Course string
                studyPlanGUID = "Auto-" + date + "-" + randomValue + "-Study Plan";
                //Stor Activity Name
                this.StoreStudyPlanDetails(studyPlanName, studyPlanGUID);
                //Fiil study plan name
                base.FillTextBoxById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_StudyPlanName_ID_Locator, studyPlanGUID);
                //Fiil study plan description
                base.FillTextBoxById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_StudyPlanDesc_ID_Locator, studyPlanGUID);
                //Save study plan details page

                base.ClickButtonById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_StudyPlanDetails_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage",
            "ClickCreateFolder",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Activity Details.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        /// <param name="behvioralModeTypeEnum">This is Behavioral Mode Enum.</param>
        /// <param name="activityName">This is Activity Name.</param>
        public void StoreStudyPlanDetails(Activity.ActivityTypeEnum activityTypeEnum,
             String studyPlanGUID)
        {
            Logger.LogMethodEntry("StoreStudyPlanDetails", "StoreActivityDetails",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Store the activity in memory
                Activity newActivityTest = new Activity
                {
                    Name = studyPlanGUID,
                    ActivityType = activityTypeEnum,
                    IsCreated = true,
                };
                newActivityTest.StoreActivityInMemory();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("StoreStudyPlanDetails", "StoreActivityDetails",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to Build study plan tab
        /// </summary>
        public string SwitchToTab()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage",
                "ClickCreateFolder",
                base.IsTakeScreenShotDuringEntryExit);
            string buildSpTab = string.Empty;
            try
            {
                //Wait for the build study plan tab
                base.WaitTillElementFound(By.Id(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_StudyPlanTabName_ID_Locator));
                //Get the build study plan tab name
                buildSpTab = base.GetElementInnerTextById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_StudyPlanTabName_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage",
            "ClickCreateFolder",
            base.IsTakeScreenShotDuringEntryExit);
            //Return the tab name            
            return buildSpTab;
        }

        /// <summary>
        /// Create pre test
        /// </summary>
        public void SavePretest()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage",
                "ClickCreateFolder",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {

                //Switch to create pre test window
                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_StudyPlanPreTestWin_ID_Locator);
                //Save the pretest
                IWebElement saveAndReturn = base.GetWebElementPropertiesById(CoursePreviewUXPageResource.
                CoursePreviewUXPage_StudyPlanSavePreTest_ID_Locator);
                base.ClickByJavaScriptExecutor(saveAndReturn);
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage",
        "ClickCreateFolder",
        base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create post test
        /// </summary>
        public void SavePosttest()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage",
                "ClickCreateFolder",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Switch to create post test window
                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_StudyPlanPostTestWin_ID_Locator);
                //Save the posttest  
                base.ClickButtonById(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_StudyPlanSavePostTest_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage",
            "ClickCreateFolder",
            base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Display of created post test
        /// </summary>
        public string CreatedPreTestName()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage",
                "ClickCreateFolder",
                base.IsTakeScreenShotDuringEntryExit);
            string preTestName = string.Empty;
            try
            {
                //Get the pre test title
                base.SelectWindow(CoursePreviewUXPageResource.
              CoursePreviewUXPage_AddStudyPlanPage_Pagename);
                preTestName = base.GetElementInnerTextById
                    ("_ctl0__ctl0_phBody_PageContent_DTName");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage",
            "ClickCreateFolder",
            base.IsTakeScreenShotDuringEntryExit);
            return preTestName;
        }


        /// <summary>
        /// Display of created post test
        /// </summary>
        public string CreatedPostTestName()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage",
                "ClickCreateFolder",
                base.IsTakeScreenShotDuringEntryExit);
            string postTestName = string.Empty;
            try
            {
                //Get the pre test title

                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_AddStudyPlanPage_Pagename);
                postTestName = base.GetElementInnerTextById
                    ("_ctl0__ctl0_phBody_PageContent_ETName");
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage",
            "ClickCreateFolder",
            base.IsTakeScreenShotDuringEntryExit);
            return postTestName;
        }


        /// <summary>
        /// Display of created post test
        /// </summary>
        public string SaveStudyPlan()
        {
            Logger.LogMethodEntry("CoursePreviewUXPage",
                "ClickCreateFolder",
                base.IsTakeScreenShotDuringEntryExit);
            string postTestName = string.Empty;
            try
            {
                //Get the pre test title
                base.WaitUntilWindowLoads(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_AddStudyPlanPage_Pagename);
                base.SelectWindow(CoursePreviewUXPageResource.
                    CoursePreviewUXPage_AddStudyPlanPage_Pagename);
                base.ClickButtonById(CoursePreviewUXPageResource.
                CoursePreviewUXPage_SaveStudyPlan_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CoursePreviewUXPage",
            "ClickCreateFolder",
            base.IsTakeScreenShotDuringEntryExit);
            return postTestName;
        }
    }
}
