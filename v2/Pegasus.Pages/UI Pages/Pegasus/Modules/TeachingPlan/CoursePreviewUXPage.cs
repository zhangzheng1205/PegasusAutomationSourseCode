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
               tooldropDownPres= base.IsElementPresent (toolDropDown, 10);
               if(tooldropDownPres)
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
                   if(span)
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

    }
}
