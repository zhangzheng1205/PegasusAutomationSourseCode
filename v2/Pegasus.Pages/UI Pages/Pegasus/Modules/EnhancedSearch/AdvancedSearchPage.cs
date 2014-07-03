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
        private static readonly Logger logger = Logger.
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
            logger.LogMethodEntry("AdvancedSearchPage", "SearchAssetUsingAdvancedSearch",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Curriculum or Planner Tab
                this.ClickonAdvancedSearchLink(activityName, tabName);
                //Switch to Advanced Search LightBox Frame
                base.WaitForElement(By.Id(AdvancedSearchPageResource.
                    AdvancedSearch_Page_AdvancedSearch_Frame_Id_Locator));
                base.SwitchToIFrame(AdvancedSearchPageResource.
                    AdvancedSearch_Page_AdvancedSearch_Frame_Id_Locator);
                //Clear TextBox
                base.WaitForElement(By.Id(AdvancedSearchPageResource.
                    AdvancedSearch_Page_TextBox_Id_Locator));
                base.ClearTextByID(AdvancedSearchPageResource.
                    AdvancedSearch_Page_TextBox_Id_Locator);
                //Enter Search Text
                base.FillTextBoxByID(AdvancedSearchPageResource.
                    AdvancedSearch_Page_TextBox_Id_Locator, activityName);
                //Click on Search Button
                base.WaitForElement(By.PartialLinkText(AdvancedSearchPageResource.
                    AdvancedSearch_Page_SearchButton_PartialLinkText_Value));
                base.ClickButtonByPartialLinkText(AdvancedSearchPageResource.
                    AdvancedSearch_Page_SearchButton_PartialLinkText_Value);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AdvancedSearchPage", "SearchAssetUsingAdvancedSearch",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on AdvancedSearch Link
        /// </summary>
        /// <param name="tabName">This is Search Tab enum</param>
        private void ClickonAdvancedSearchLink(string activityName, SearchTab tabName)
        {
            //Click on AdvancedSearch Link
            logger.LogMethodEntry("AdvancedSearchPage", "ClickonAdvancedSearchLink",
                base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("AdvancedSearchPage", "ClickonAdvancedSearchLink",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Asset Name In Text Box and Click On Search Button
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        public void FillAssetNameInTextBoxAndClickSearchButton(string assetName)
        {
            //Fill Asset Name In Text Box and Click On Search Button
            logger.LogMethodEntry("AdvancedSearchPage",
                "FillAssetNameInTextBoxAndClickSearchButton",
              base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("AdvancedSearchPage",
                "FillAssetNameInTextBoxAndClickSearchButton",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Middle Frame.
        /// </summary>
        public void SelectAdvanceSearchFrame()
        {
            //Select Middle Frame
            logger.LogMethodEntry("AdvancedSearchPage",
                "SelectAdvanceSearchFrame", base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("AdvancedSearchPage", "SelectAdvanceSearchFrame",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Asset Name In Text Box
        /// </summary>
        /// <param name="assetname">This is Asset Name</param>
        private void FillAssetNameInTextBox(string assetname)
        {
            //Fill Asset Name In Text Box
            logger.LogMethodEntry("AdvancedSearchPage",
                "FillAssetNameInTextBox",
              base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AdvancedSearchPageResource.
                AdvancedSearch_Page_TextBox_Id_Locator));
            //Clear Text Box
            base.ClearTextByID(AdvancedSearchPageResource.
                AdvancedSearch_Page_TextBox_Id_Locator);
            //Fill Asset Name In Text Box
            base.FillTextBoxByID(AdvancedSearchPageResource.
                AdvancedSearch_Page_TextBox_Id_Locator, assetname);
            logger.LogMethodExit("AdvancedSearchPage",
              "FillAssetNameInTextBox",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Search Button
        /// </summary>
        private void ClickOnSearchButton()
        {
            //Click On Search Button
            logger.LogMethodEntry("AdvancedSearchPage", "ClickOnSearchButton",
             base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AdvancedSearchPageResource.
                AdvancedSearch_Page_Search_Button_Id_Locator));
            //Get Search Button Property
            IWebElement getSearchButtonProperty = base.
                GetWebElementPropertiesById(AdvancedSearchPageResource.
                AdvancedSearch_Page_Search_Button_Id_Locator);
            //Click On Search Button
            base.ClickByJavaScriptExecutor(getSearchButtonProperty);
            logger.LogMethodExit("AdvancedSearchPage", "ClickOnSearchButton",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Advanced Search Close Button.
        /// </summary>
        public void ClickOnAdvancedSearchCloseButton()
        {
            //Click On Advanced Search Close Button
            logger.LogMethodEntry("AdvancedSearchPage", 
                "ClickOnAdvancedSearchCloseButton",
             base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("AdvancedSearchPage", 
                "ClickOnAdvancedSearchCloseButton",
             base.isTakeScreenShotDuringEntryExit);
        }
    }
}
