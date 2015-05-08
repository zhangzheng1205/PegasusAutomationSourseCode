﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.EnhancedSearch;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Advanced Search Page Actions
    /// </summary>
    public class AdvancedSearchPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger Logger = Logger.
            GetInstance(typeof(AdvancedSearchPage));

        /// <summary>
        /// These are the available tabs for teacher
        /// </summary>
        public enum SearchTab
        {
            /// <summary>
            /// Curriculum Tab
            /// </summary>
            Curriculum = 1,
            /// <summary>
            /// Planner Tab
            /// </summary>
            Planner,
        }

        /// <summary>
        /// Search Asset Using Advanced Search
        /// </summary>
        ///  <param name="activityName">This is Activity Name</param>
        ///   ///  <param name="tabName">This is Search Tab Enum</param>
        public void SearchAssetUsingAdvancedSearch(string activityName, SearchTab tabName)
        {
            //Search Asset Using Advanced Search
            Logger.LogMethodEntry("AdvancedSearchPage", "SearchAssetUsingAdvancedSearch",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Curriculum or Planner Tab
                this.ClickonAdvancedSearchLink(activityName, tabName);
                Thread.Sleep(Convert.ToInt32(AdvancedSearchPageResource.
                    AdvancedSearch_Page_Window_TimeValue));
                //Switch to Advanced Search LightBox Frame
                base.WaitForElement(By.Id(AdvancedSearchPageResource.
                    AdvancedSearch_Page_AdvancedSearch_Frame_Id_Locator));
                base.SwitchToIFrame(AdvancedSearchPageResource.
                    AdvancedSearch_Page_AdvancedSearch_Frame_Id_Locator);
                //Clear TextBox
                base.WaitForElement(By.Id(AdvancedSearchPageResource.
                    AdvancedSearch_Page_TextBox_Id_Locator));
                base.ClearTextById(AdvancedSearchPageResource.
                    AdvancedSearch_Page_TextBox_Id_Locator);
                //Enter Search Text
                base.FillTextBoxById(AdvancedSearchPageResource.
                    AdvancedSearch_Page_TextBox_Id_Locator, activityName);
                //Click on Search Button
                base.ClickButtonById(AdvancedSearchPageResource.
                    AdvancedSearch_Page_Search_Button_Id_Locator);
                base.WaitUntilWindowLoads(AdvancedSearchPageResource.AdvancedSearch_Page_Window_TitleName);
                base.SelectWindow(AdvancedSearchPageResource.AdvancedSearch_Page_Window_TitleName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdvancedSearchPage", "SearchAssetUsingAdvancedSearch",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on AdvancedSearch Link
        /// </summary>
        /// <param name="tabName">This is Search Tab enum</param>
        private void ClickonAdvancedSearchLink(string activityName, SearchTab tabName)
        {
            //Click on AdvancedSearch Link
            Logger.LogMethodEntry("AdvancedSearchPage", "ClickonAdvancedSearchLink",
                base.IsTakeScreenShotDuringEntryExit);
            switch (tabName)
            {
                //Click on AdvancedSearch Link in Curriculum Tab
                case SearchTab.Curriculum:
                    //Check Activity Assign To Copy State
                    new ContentLibraryPage().
                        CheckActivityAssignToCopyStateInCurriculumTab(activityName);
                    //Click on Advanced Search Link
                    new ContentLibraryPage().ClickOnAdvancedSearchLink();
                    //Select Curriculum Window
                    base.WaitUntilWindowLoads(AdvancedSearchPageResource.
                        AdvancedSearch_Page_Window_TitleName);
                    base.SelectWindow(AdvancedSearchPageResource.
                        AdvancedSearch_Page_Window_TitleName);
                    //Switch to Frame
                    base.WaitForElement(By.Id(AdvancedSearchPageResource.
                        AdvancedSearch_Page_Frame_Id_Locator));
                    base.SwitchToIFrame(AdvancedSearchPageResource.
                        AdvancedSearch_Page_Frame_Id_Locator);
                    break;
                //Click on AdvancedSearch Link in Planner Tab
                case SearchTab.Planner:
                    //Check Activity Assign To Copy State
                    new CalendarDefaultGlobalUXPage().
                        CheckActivityAssignToCopyStateInPlannerTab(activityName);
                    //Click on Advanced Search Link
                    new CalendarDefaultGlobalUXPage().ClickOnAdvancedSearchLink();
                    //Select Planner Window
                    base.WaitUntilWindowLoads(AdvancedSearchPageResource.
                        AdvancedSearch_Page_PlannerWindow_TitleName);
                    base.SelectWindow(AdvancedSearchPageResource.
                        AdvancedSearch_Page_PlannerWindow_TitleName);
                    //Switch to Frame
                    base.WaitForElement(By.Id(AdvancedSearchPageResource.
                        AdvancedSearch_Page_PlannerFrame_Id_Locator));
                    base.SwitchToIFrame(AdvancedSearchPageResource.
                         AdvancedSearch_Page_PlannerFrame_Id_Locator);
                    break;
            }
            Logger.LogMethodExit("AdvancedSearchPage", "ClickonAdvancedSearchLink",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Asset Name In Text Box and Click On Search Button
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        public void FillAssetNameInTextBoxAndClickSearchButton(string assetName)
        {
            //Fill Asset Name In Text Box and Click On Search Button
            Logger.LogMethodEntry("AdvancedSearchPage",
                "FillAssetNameInTextBoxAndClickSearchButton",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Middle Frame
                this.SelectAdvanceSearchFrame();
                //Fill Asset Name In Text Box
                this.FillAssetNameInTextBox(assetName);
                //Click On Search Button
                this.ClickOnSearchButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdvancedSearchPage",
                "FillAssetNameInTextBoxAndClickSearchButton",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Middle Frame.
        /// </summary>
        public void SelectAdvanceSearchFrame()
        {
            //Select Middle Frame
            Logger.LogMethodEntry("AdvancedSearchPage",
                "SelectAdvanceSearchFrame", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(AdvancedSearchPageResource.
                    AdvancedSearch_Page_AdvancedSearchLightBoxFrame_Id_Locator));
                //Switch To Middle Frame
                base.SwitchToIFrame(AdvancedSearchPageResource.
                    AdvancedSearch_Page_AdvancedSearchLightBoxFrame_Id_Locator);
            }
            catch (Exception e)
            {
               ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdvancedSearchPage", "SelectAdvanceSearchFrame",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Asset Name In Text Box
        /// </summary>
        /// <param name="assetname">This is Asset Name</param>
        private void FillAssetNameInTextBox(string assetname)
        {
            //Fill Asset Name In Text Box
            Logger.LogMethodEntry("AdvancedSearchPage",
                "FillAssetNameInTextBox",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AdvancedSearchPageResource.
                AdvancedSearch_Page_TextBox_Id_Locator));
            //Clear Text Box
            base.ClearTextById(AdvancedSearchPageResource.
                AdvancedSearch_Page_TextBox_Id_Locator);
            //Fill Asset Name In Text Box
            base.FillTextBoxById(AdvancedSearchPageResource.
                AdvancedSearch_Page_TextBox_Id_Locator, assetname);
            Logger.LogMethodExit("AdvancedSearchPage",
              "FillAssetNameInTextBox",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Search Button
        /// </summary>
        private void ClickOnSearchButton()
        {
            //Click On Search Button
            Logger.LogMethodEntry("AdvancedSearchPage", "ClickOnSearchButton",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AdvancedSearchPageResource.
                AdvancedSearch_Page_Search_Button_Id_Locator));
            //Get Search Button Property
            IWebElement getSearchButtonProperty = base.
                GetWebElementPropertiesById(AdvancedSearchPageResource.
                AdvancedSearch_Page_Search_Button_Id_Locator);
            //Click On Search Button
            base.ClickByJavaScriptExecutor(getSearchButtonProperty);
            Logger.LogMethodExit("AdvancedSearchPage", "ClickOnSearchButton",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Advanced Search Close Button.
        /// </summary>
        public void ClickOnAdvancedSearchCloseButton()
        {
            //Click On Advanced Search Close Button
            Logger.LogMethodEntry("AdvancedSearchPage", 
                "ClickOnAdvancedSearchCloseButton",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //wait for the element
                base.WaitForElement(By.Id(AdvancedSearchPageResource.
                    AdvancedSearch_Page_Close_Button_Id_Locator));
                //Get Search Button Property
                IWebElement getCloseButtonProperty = base.
                    GetWebElementPropertiesById(AdvancedSearchPageResource.
                    AdvancedSearch_Page_Close_Button_Id_Locator);
                //Click On Advanced Search Close Button
                base.ClickByJavaScriptExecutor(getCloseButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdvancedSearchPage", 
                "ClickOnAdvancedSearchCloseButton",
             base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
