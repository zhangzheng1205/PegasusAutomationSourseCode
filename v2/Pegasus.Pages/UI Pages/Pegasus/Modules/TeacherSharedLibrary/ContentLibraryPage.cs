using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegng;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.TeacherSharedLibrary;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using System.Threading;


namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Content Library Page Actions
    /// </summary>
    public class ContentLibraryPage : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ContentLibraryPage));

        //Get the WaitTime
        int getWaitTimeinMinutes = Int32.Parse(ConfigurationManager.
                AppSettings[ContentLibraryPageResource.ContnetLibrary_Page_AssignToCopyInterval]);

        /// <summary>
        /// This are the available search criteria Links for teacher  
        /// </summary>
        public enum SearchCriteriaEnum
        {
            /// <summary>
            /// Search Criteria link of type table of contents 
            /// </summary>
            TableofContents = 1,
            /// <summary>
            /// Search Criteria link of type Skill
            /// </summary>
            Skill =2 ,
            /// <summary>
            /// Search Criteria link of type Content Type
            /// </summary>
            ContentType,
        }

        /// <summary>
        /// Get Product Name
        /// </summary>
        /// <returns>Product Name</returns>
        public String GetProductName()
        {
            //Get Product name
            logger.LogMethodEntry("ContentLibraryPage", "GetProductName",
                   base.IsTakeScreenShotDuringEntryExit);
            //Initialized Class Name Variable
            string getProductName = string.Empty;
            try
            {
                //Select Currriculum Window
                base.SelectWindow(HomePageResource.Home_Page_Curriculum_Window_Title);
                base.WaitForElement(By.Id(ContentLibraryPageResource.
                    ContentLibrary_Page_Frame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(ContentLibraryPageResource.
                    ContentLibrary_Page_Frame_Id_Locator);
                base.WaitForElement(By.XPath(ContentLibraryPageResource.
                    ContnetLibrary_Page_Productname_Name_Xpath_Locator));
                //Get Product name
                getProductName = base.GetElementTextByXPath(ContentLibraryPageResource.
                    ContnetLibrary_Page_Productname_Name_Xpath_Locator);
                base.SelectWindow(HomePageResource.Home_Page_Curriculum_Window_Title);
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryPage", "GetProductName",
                 base.IsTakeScreenShotDuringEntryExit);
            return getProductName;
        }

        /// <summary>
        /// Search the Asset
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        /// <param name="getSearchCriteriaLinkName">This is Search Criteria Link Name Enum</param>
        public void SearchAsset(String activityName, ContentLibraryPage.
            SearchCriteriaEnum getSearchCriteriaLinkName)
        {
            //Search the Asset
            logger.LogMethodEntry("ContentLibraryPage", "SearchAsset",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Selects Window and Switch to Frame
                this.SelectWindowAndFrame();                
                //Click on Skill and Content Type Link
                this.ClickOnSearchCriteriaLink(getSearchCriteriaLinkName);
                //Select Curriculum Window
                base.SelectWindow(ContentLibraryPageResource.
                   ContnetLibrary_Page_Window_TitleName);
                //Switch to Frame
                base.WaitForElement(By.Id(ContentLibraryPageResource.
                    ContentLibrary_Page_Frame_Id_Locator));
                base.SwitchToIFrame(ContentLibraryPageResource.
                    ContentLibrary_Page_Frame_Id_Locator);
                //Enter Search Text
                base.WaitForElement(By.Id(ContentLibraryPageResource.
                    ContnetLibrary_Page_SearchTextBox_Id_Locator));
                base.FillTextBoxById(ContentLibraryPageResource.
                    ContnetLibrary_Page_SearchTextBox_Id_Locator, activityName);
                //Click on Search Button
                base.WaitForElement(By.Id(ContentLibraryPageResource.
                    ContnetLibrary_Page_SearchButton_Id_Locator));                
                base.ClickButtonById(ContentLibraryPageResource.
                    ContnetLibrary_Page_SearchButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryPage", "SearchAsset",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check Activity Assign To Copy State
        /// </summary>
        /// <param name="activityName">Activity Name</param>
        public void CheckActivityAssignToCopyStateInCurriculumTab(String activityName)
        {
            //Check Activity Assign To Copy State
            logger.LogMethodEntry("ContentLibraryPage", "CheckActivityAssignToCopyStateInCurriculumTab",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Selects Window and Switch to Frame
                 this.SelectWindowAndFrame();  
                //Get all the Asset Names
                string getAssetNames = base.GetElementTextById(ContentLibraryPageResource.
                    ContnetLibrary_Page_Div_Id_Locator);
                if (getAssetNames.Contains(ContentLibraryPageResource.
                    ContentLibrary_Page_AssignToCopy_Message))
                {
                    //Activity Count
                    int getActivityCount = base.GetElementCountByXPath(ContentLibraryPageResource.
                        ContentLibrary_Page_Assets_Xpath_Locator);
                    //Refresh The Page If Required Activity Name is Present
                    this.RefreshThePageIfActivityNameNotPresent(activityName, getActivityCount);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryPage", "CheckActivityAssignToCopyStateInCurriculumTab",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Refresh The Page If Required Activity Name is Present
        /// </summary>
        /// <param name="activityName">Activity Name</param>
        /// <param name="getActivityCount">Activity Count</param>
        private void RefreshThePageIfActivityNameNotPresent(String activityName,
            int getActivityCount)
        {
            //Refresh The Page If Required Activity Name is Present
            logger.LogMethodEntry("ContentLibraryPage",
                "RefreshThePageIfActivityNameNotPresent",
                   base.IsTakeScreenShotDuringEntryExit);            
            for (int rowCount = Convert.ToInt32(ContentLibraryPageResource.
                ContentLibrary_Page_ForLoopInitialization_Value);
                rowCount < getActivityCount; rowCount++)
            {
                //Get Activity Name
                string getActivityName = base.GetElementTextByXPath(
                    string.Format(ContentLibraryPageResource.
                    ContentLibrary_Page_AssetName_Xpath_Locator, rowCount));
                if (activityName == getActivityName)
                {  
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    //Initialize Variable
                    string message = string.Empty;
                    do
                    {
                        //Refresh the Frame
                        base.SwitchToDefaultPageContent();                        
                        base.RefreshIFrameByJavaScriptExecutor(ContentLibraryPageResource.
                ContentLibrary_Page_Frame_Id_Locator);
                        Thread.Sleep(Convert.ToInt32(ContentLibraryPageResource.
                            ContnetLibrary_Page_FrameRefresh_CustomTimeToWait_Value));
                        this.SelectWindowAndFrame();
                        //Get Assign To Copy Message
                        message = base.GetElementTextByXPath(string.Format(ContentLibraryPageResource.
                            ContentLibrary_Page_AssetCopyMessage_Xpath_Locator, rowCount));
                    } while (message.Contains(ContentLibraryPageResource.
                        ContentLibrary_Page_AssignToCopy_Message) && 
                        stopwatch.Elapsed.TotalMinutes < getWaitTimeinMinutes);
                    break;
                }
            }
            logger.LogMethodExit("ContentLibraryPage",
                "RefreshThePageIfActivityNameNotPresent",
                   base.IsTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Selects window and Switch to Frame
        /// </summary>
        private void SelectWindowAndFrame()
        {
            //Selects window and Switch to Frame
            logger.LogMethodEntry("ContentLibraryPage", "SelectWindowAndFrame",
                   base.IsTakeScreenShotDuringEntryExit);
            //Select Curriculum Window
            base.WaitUntilWindowLoads(ContentLibraryPageResource.
                ContnetLibrary_Page_Window_TitleName);
            base.SelectWindow(ContentLibraryPageResource.
                ContnetLibrary_Page_Window_TitleName);
            //Switch to Frame
            base.WaitForElement(By.Id(ContentLibraryPageResource.
                ContentLibrary_Page_Frame_Id_Locator));
            base.SwitchToIFrame(ContentLibraryPageResource.
                ContentLibrary_Page_Frame_Id_Locator);
            logger.LogMethodExit("ContentLibraryPage", "SelectWindowAndFrame",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Search Criteria Link
        /// </summary>
        /// <param name="getSearchCriteriaLinkName">This is Search Criteria Link Name Enum</param>
        private void ClickOnSearchCriteriaLink(ContentLibraryPage.SearchCriteriaEnum 
            getSearchCriteriaLinkName)
        {
            //Click On Search Criteria Link
            logger.LogMethodEntry("ContentLibraryPage", "ClickOnSearchCriteriaLink",
                   base.IsTakeScreenShotDuringEntryExit);
            switch (getSearchCriteriaLinkName)
            {
                //Click on Skill Link
                case SearchCriteriaEnum.Skill: 
                    base.WaitForElement(By.Id(ContentLibraryPageResource.
                    ContnetLibrary_Page_SkillLink_Id_Locator));                    
                    base.ClickLinkById(ContentLibraryPageResource.
                        ContnetLibrary_Page_SkillLink_Id_Locator);
                    break;
                //Click on Content Type Link
                case SearchCriteriaEnum.ContentType: 
                    base.WaitForElement(By.Id(ContentLibraryPageResource.
                    ContnetLibrary_Page_ContentTypeLink_Id_Locator));
                    base.ClickLinkById(ContentLibraryPageResource.
                        ContnetLibrary_Page_ContentTypeLink_Id_Locator);
                    break;
            }
            logger.LogMethodExit("ContentLibraryPage", "ClickOnSearchCriteriaLink",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Asset Name
        /// </summary>
        /// <returns>Asset Name</returns>
        public String GetAssetName()
        {
            //Get Asset Name
            logger.LogMethodEntry("ContentLibraryPage", "GetAssetName",
                   base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            String getAssetName = string.Empty;
            try
            {
                //Selects Window and Switch to Frame
                this.SelectWindowAndFrame();
                //Wait For ClearResult Link and Searched Asset Name 
                base.WaitForElement(By.Id(ContentLibraryPageResource.
                    ContnetLibrary_Page_ClearResultLink_Id_Locator));
                base.WaitForElement(By.Id(ContentLibraryPageResource.
                       ContnetLibrary_Page_SearchedAssetName_Id_Locator));
                //Get Asset Name From Application
                getAssetName = base.GetElementTextById(ContentLibraryPageResource.
                    ContnetLibrary_Page_SearchedAssetName_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryPage", "GetAssetName",
                  base.IsTakeScreenShotDuringEntryExit);
            return getAssetName;
        }

        /// <summary>
        /// Clear Searched Result
        /// </summary>
        public void ClearSearchedResult()
        {
            //Clear Searched Result
            logger.LogMethodEntry("ContentLibraryPage", "ClearSearchedResult",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                ////Selects Window and Switch to Frame
                this.SelectWindowAndFrame();
                //Wait for ClearResult Link
                base.WaitForElement(By.Id(ContentLibraryPageResource.
                       ContnetLibrary_Page_ClearResultLink_Id_Locator));
                //Click on Clear Results
                //ClickLinkById(ContentLibraryPageResource.
                //    ContnetLibrary_Page_ClearResultLink_Id_Locator);
                IWebElement clickClearTextLink = base.GetWebElementPropertiesById(ContentLibraryPageResource.
                  ContnetLibrary_Page_ClearResultLink_Id_Locator);
                base.ClickByJavaScriptExecutor(clickClearTextLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryPage", "ClearSearchedResult",
                  base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Check If Searched Result Present
        /// </summary>
        /// <returns>This is Searched Element Present or Not</returns>
        public Boolean CheckClearResultLinkPresent()
        {
            //Check If Searched Result Present
            logger.LogMethodEntry("ContentLibraryPage", "CheckSearchedResultPresent",
                   base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            Boolean isSearchedElementPresent = false;
            try
            {
                //Selects Window and Switch to Frame
                this.SelectWindowAndFrame();
                //Check If Clear Results Link Present 
                isSearchedElementPresent = base.IsElementPresent(By.Id(ContentLibraryPageResource.
                        ContnetLibrary_Page_ClearResultLink_Id_Locator),
                        Convert.ToInt32(ContentLibraryPageResource.
                        ContnetLibrary_Page_CustomTimeToWait_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryPage", "CheckSearchedResultPresent",
                   base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(ContentLibraryPageResource.ContnetLibrary_Page_Window_TitleName);
            base.RefreshTheCurrentPage();
            base.WaitUntilWindowLoads(ContentLibraryPageResource.ContnetLibrary_Page_Window_TitleName);
            return isSearchedElementPresent;
        }

        /// <summary>
        /// Click on Advanced Search Link
        /// </summary>
        public void ClickOnAdvancedSearchLink()
        {
            //Click on Advanced Search Link
            logger.LogMethodEntry("ContentLibraryPage", "ClickOnAdvancedSearchLink",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                ////Selects Window and Switch to Frame
                this.SelectWindowAndFrame();
                //Click on Advanced Search Link
                base.WaitForElement(By.Id(ContentLibraryPageResource.
                    ContnetLibrary_Page_AdvancedSearchLink_Id_Locator));
                //Click link
                base.ClickLinkById(ContentLibraryPageResource.
                    ContnetLibrary_Page_AdvancedSearchLink_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryPage", "ClickOnAdvancedSearchLink",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity Customize Content Cmenu
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        public void ClickOnActivityCustomizeContentCmenu(string activityName)
        {
            //Click On Activity Customize Content Cmenu
            logger.LogMethodEntry("ContentLibraryPage", "ClickOnActivityCustomizeContentCmenu",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Selects Window and Switch to Frame
                this.SelectWindowAndFrame();                
                //MouseHover On Activity
                this.MouseHoverOnActivity();
                //Click On Customize Content Cmenu Option
                this.ClickOnCustomizeContentCmenuOption();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }          
            logger.LogMethodExit("ContentLibraryPage", "ClickOnActivityCustomizeContentCmenu",
                 base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// MouseHover On Activity
        /// </summary>
        private void MouseHoverOnActivity()
        {
            //MouseHover On Activity
            logger.LogMethodEntry("ContentLibraryPage",
                "MouseHoverOnActivity",
                 base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ContentLibraryPageResource.
                ContnetLibrary_Page_SearchedAssetName_Id_Locator));
            //Mouse Hover On Searched Activity Name
            IWebElement testName = base.GetWebElementPropertiesById(ContentLibraryPageResource.
                ContnetLibrary_Page_SearchedAssetName_Id_Locator);
            base.PerformMouseHoverByJavaScriptExecutor(testName);
            logger.LogMethodExit("ContentLibraryPage",
                "MouseHoverOnActivity",
                 base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Click On Customize Content Cmenu Option
        /// </summary>
        private void ClickOnCustomizeContentCmenuOption()
        {
            //Click On Customize Content Cmenu Option
            logger.LogMethodEntry("ContentLibraryPage", 
                "ClickOnCustomizeContentCmenuOption",
                  base.IsTakeScreenShotDuringEntryExit);
            //Click on Activity Cmenu Icon               
            base.WaitForElement(By.CssSelector(ContentLibraryPageResource.
                ContnetLibrary_Page_ContentFrame_Asset_CmenuIcon_CSS_Locator));
            //Get HTML peroperty of Cmenu icon
            IWebElement getPropertyOfCmenuIcon = base.GetWebElementPropertiesByCssSelector(ContentLibraryPageResource.
                ContnetLibrary_Page_ContentFrame_Asset_CmenuIcon_CSS_Locator);
            base.ClickByJavaScriptExecutor(getPropertyOfCmenuIcon);           
            //Click on Customize Content Cmenu Option
            Thread.Sleep(2000);
            base.WaitForElement(By.ClassName(ContentLibraryPageResource.
                ContnetLibrary_Page_ContentFrame_Asset_CmenuOption_Class_Locator));
            base.WaitForElement(By.PartialLinkText(ContentLibraryPageResource.
                ContnetLibrary_Page_ActivityCMenuOptionName));
            IWebElement clickCmenuOption = base.GetWebElementPropertiesByPartialLinkText(ContentLibraryPageResource.
                ContnetLibrary_Page_ActivityCMenuOptionName);
            base.ClickByJavaScriptExecutor(clickCmenuOption);
            logger.LogMethodExit("ContentLibraryPage", 
                "ClickOnCustomizeContentCmenuOption",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Success Message
        /// </summary>
        /// <returns>This is Success Message</returns>
        public string GetSuccessMessage()
        {            
            //Get Success Message
            logger.LogMethodEntry("ContentLibraryPage", "GetSuccessMessage",
                  base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSuccessMessage = string.Empty;
            try
            {
                //Selects Window and Switch to Frame
                this.SelectWindowAndFrame();
                //Get Success Message From Application
                getSuccessMessage = base.GetElementTextByXPath(ContentLibraryPageResource.
                    ContnetLibrary_Page_SuccessMessage_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }            
            logger.LogMethodExit("ContentLibraryPage", "GetSuccessMessage",
                  base.IsTakeScreenShotDuringEntryExit);
            return getSuccessMessage;
        }

        /// <summary>
        /// Click On The CustomContent Link
        /// </summary>
        public void ClickOnCustomContentLink()
        {
            //Click On The CustomContent Link
            logger.LogMethodEntry("ContentLibraryPage", "ClickOnCustomContentLink",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Selects Window and Switch to Frame
                this.SelectWindowAndFrame();
                base.WaitForElement(By.Id(ContentLibraryPageResource.
                    ContnetLibrary_Page_Product_CmenuIcon_Id_Locator));
                //Focus on Cmenu Icon
                base.FocusOnElementById(ContentLibraryPageResource.
                    ContnetLibrary_Page_Product_CmenuIcon_Id_Locator);
                //Click on Cmenu Icon
                base.ClickButtonById(ContentLibraryPageResource.
                    ContnetLibrary_Page_Product_CmenuIcon_Id_Locator);
                base.WaitForElement(By.XPath(ContentLibraryPageResource.
                    ContnetLibrary_Page_CustomContentLink_Xpath_Locator));
                //Click on Custom Content Link
                base.ClickLinkByXPath(ContentLibraryPageResource.
                    ContnetLibrary_Page_CustomContentLink_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryPage", "ClickOnCustomContentLink",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Activity
        /// </summary>
        public void SearchActivity(string activityName)
        {
            //Search Activity
            logger.LogMethodEntry("ContentLibraryPage", "SearchActivity",
                  base.IsTakeScreenShotDuringEntryExit);
            //Selects Window and Switch to Frame
            this.SelectWindowAndFrame();
            Thread.Sleep(3000);
            //Enter Search Text
            base.WaitForElement(By.Id(ContentLibraryPageResource.
                ContnetLibrary_Page_SearchTextBox_Id_Locator));
            //Clear Textbox
            base.ClearTextById(ContentLibraryPageResource.
                ContnetLibrary_Page_SearchTextBox_Id_Locator);
            base.FillTextBoxById(ContentLibraryPageResource.
                ContnetLibrary_Page_SearchTextBox_Id_Locator, activityName);
            //Click on Search Button
            base.WaitForElement(By.Id(ContentLibraryPageResource.
                ContnetLibrary_Page_SearchButton_Id_Locator));
            IWebElement getsearchText=base.GetWebElementPropertiesById
                (ContentLibraryPageResource.
                ContnetLibrary_Page_SearchButton_Id_Locator);
            base.ClickByJavaScriptExecutor(getsearchText);
            Thread.Sleep(5000);
            logger.LogMethodExit("ContentLibraryPage", "SearchActivity",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Asset Cmenu In Table of Content.
        /// </summary>
        /// <param name="activityName">This is Activity Name</param>
        /// <param name="assetCmenu">This is Asset Cmenu.</param>
           public void SelectAssetCmenuInTableOfContent(string activityName, string assetCmenu)
           {
            //Select Asset Cmenu In Table of Content
            logger.LogMethodEntry("ContentLibraryPage", "SelectAssetCmenuInTableofContent",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Selects Window and Switch to Frame
                base.WaitUntilWindowLoads(ContentLibraryPageResource.
                    ContnetLibrary_Page_Window_TitleName);
                this.SelectWindowAndFrame();
                //MouseHover On Activity
                this.MouseHoverOnActivity();
                //Click on Activity Cmenu Icon               
                base.WaitForElement(By.CssSelector(ContentLibraryPageResource.
                    ContnetLibrary_Page_ContentFrame_Asset_CmenuIcon_CSS_Locator));
                //Get HTML peroperty of Cmenu icon
                IWebElement getPropertyOfCmenuIcon = base.GetWebElementPropertiesByCssSelector(ContentLibraryPageResource.
                    ContnetLibrary_Page_ContentFrame_Asset_CmenuIcon_CSS_Locator);
                base.ClickByJavaScriptExecutor(getPropertyOfCmenuIcon);
                //Click on Cmenu Option
                Thread.Sleep(Convert.ToInt32(ContentLibraryPageResource.
                ContnetLibrary_Page_Window_TimeValue));
                base.WaitForElement(By.ClassName(ContentLibraryPageResource.
                    ContnetLibrary_Page_ContentFrame_Asset_CmenuOption_Class_Locator));
                base.WaitForElement(By.PartialLinkText(assetCmenu));
                IWebElement clickCmenuOption = base.GetWebElementPropertiesByPartialLinkText(assetCmenu);
                base.ClickByJavaScriptExecutor(clickCmenuOption);
                base.SwitchToDefaultPageContent();
                //base.SwitchToLastOpenedWindow();
                //String getPopupName = base.GetWindowTitleByJavaScriptExecutor();
                //if (getPopupName.Equals("Alert"))
                //{
                //    base.WaitUntilPopUpLoads("Alert");
                //    base.SwitchToActivePageElement();
                //    base.ClickButtonById("imgOk");
                //}
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryPage", "SelectAssetCmenuInTableofContent",
                 base.IsTakeScreenShotDuringEntryExit);
        }

      
         /// <summary>
        /// Select Asset Cmenu In Table of Content.
        /// </summary>
        /// <param name="activityName">This is Class Name</param>
        public void SetDueDateForActivityInCurriculum(string className)
        {
            //Select Asset Cmenu In Table of Content
            logger.LogMethodEntry("ContentLibraryPage", "SelectAssetCmenuInTableofContent",
                  base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Select class radio button
                new AssignContentPage().SelectClassOnAssignWindow(className);
                // Configure the due date on assign window 
                new AssignContentPage().ConfigureDueDate();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ContentLibraryPage", "SelectAssetCmenuInTableofContent",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Expand the folder in curriculum tab.
        /// </summary>
        /// <param name="folderName">Folder name.</param>
        public void ExpandTheFolderInCurriculumTab(string folderName)
        {
            //Expand the folder in curriculum tab
            logger.LogMethodEntry("ContentLibraryPage", "ExpandTheFolder",
                  base.IsTakeScreenShotDuringEntryExit);
            this.SelectWindowAndFrame();
            //Get the folders count in Curriculum tab
            int getFolderCount = base.GetElementCountByXPath(
                ContentLibraryPageResource.ContentLibrary_Page_Folder_Count_Xpath_Locator);
            for (int i=1; i<= getFolderCount; i++)
            {
                //Get the folder name
                string getFolderName = base.GetElementTextByXPath(string.Format
                    (ContentLibraryPageResource.ContnetLibrary_Page_FolderName_Xpath_Locator, i));
                if(folderName.Equals(getFolderName))
                {
                    IWebElement expandButtonProperties = base.GetWebElementPropertiesByXPath(
                        string.Format(ContentLibraryPageResource.
                        ContnetLibrary_Page_FolderExpandButton_Xpath_Locator, i));
                    base.ClickByJavaScriptExecutor(expandButtonProperties);
                    break;
                }
                
            }
            logger.LogMethodExit("ContentLibraryPage", "SelectAssetCmenuInTableofContent",
                 base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Expand the sub folder in curriculum tab.
        /// </summary>
        /// <param name="subFolderName">Sub folder name.</param>
        public void ExpandSubFolder(string subFolderName)
        {
            //Expand the sub folder
            logger.LogMethodEntry("ContentLibraryPage", "ExpandSubFolder",
                  base.IsTakeScreenShotDuringEntryExit);
            //Get sub folders count
            int getSubFolderCount = base.GetElementCountByXPath(
                ContentLibraryPageResource.ContentLibrary_Page_SubFolder_Count_Xpath_Locator);
            for (int j = 1; j <= getSubFolderCount; j++)
            {
                //Get sub folder name
                string getSubFolderName = base.GetElementTextByXPath(string.
                    Format(ContentLibraryPageResource.ContentLibrary_Page_SubFolder_Name_Xpath_Locator, j));
                if (subFolderName.Equals(getSubFolderName))
                {
                    //Expand sub folder in curriculum tab
                    IWebElement subFolderExpandButton = base.GetWebElementPropertiesByXPath(
                        string.Format(ContentLibraryPageResource.ContnetLibrary_Page_SubFolderExpandButton_Xpath_Locator, j));
                    base.ClickByJavaScriptExecutor(subFolderExpandButton);
                    break;
                }

            }
            logger.LogMethodExit("ContentLibraryPage", "ExpandSubFolder",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Find the activity and click on cmenu option.
        /// </summary>
        /// <param name="cmenuOption">Cmemu option to click.</param>
        /// <param name="activityName">Activity to find.</param>
        public void FindActivityAndClickOnCmenuOption(string cmenuOption, string activityName)
        {
            //Click on cmenu option of Lesson
            logger.LogMethodEntry("ContentLibraryPage", "FindActivityAndClickOnCmenuOption",
                  base.IsTakeScreenShotDuringEntryExit);
            //Get sub folder contents count
            int getSubFolderContentsCount = base.GetElementCountByXPath(
                ContentLibraryPageResource.ContnetLibrary_Page_SubFolderContents_Count_Xpath_Locator);
            for (int k = 1; k <= getSubFolderContentsCount; k++)
            {
                //Get Lesson name
                string getLessonName = base.GetElementTextByXPath(string.Format(
                    ContentLibraryPageResource.ContnetLibrary_Page_LessonName_Xpath_Locator, k));
                if (activityName.Equals(getLessonName))
                {

                    try
                    {
                        //Selects Window and Switch to Frame
                        this.SelectWindowAndFrame();
                        //MouseHover On Activity
                        this.MouseHoverOnActivityInTOC(ContentLibraryPageResource.
                            ContnetLibrary_Page_LessonName_Id_Locator);
                        //Click on Activity Cmenu Icon               
                        base.WaitForElement(By.XPath
                            (string.Format(ContentLibraryPageResource.
                            ContentLibrary_Page_Lessson_CmenuIcon_Xpath_Locator, k)));
                        //Get HTML peroperty of Cmenu icon
                        IWebElement getPropertyOfCmenuIcon =
                            base.GetWebElementPropertiesByXPath(
                            string.Format(ContentLibraryPageResource.
                            ContentLibrary_Page_Lessson_CmenuIcon_Xpath_Locator, k));
                        base.ClickByJavaScriptExecutor(getPropertyOfCmenuIcon);
                        //Wait for Cmenu option to display
                        base.WaitForElement(By.XPath(ContentLibraryPageResource.
                            ContnetLibrary_Page_Lesson_CmenuCount_Xpath_Locator));
                        //Get Cmenu Options
                        this.ClickOnCmenuOptionInCurriculumTab(cmenuOption);
                        base.SwitchToDefaultPageContent();
                    }
                    catch (Exception e)
                    {
                        ExceptionHandler.HandleException(e);
                    }

                    break;
                }

            }
            logger.LogMethodExit("ContentLibraryPage", "FindActivityAndClickOnCmenuOption",
                 base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// MouseHover On Activity in Curriculum
        /// </summary>
        private void MouseHoverOnActivityInTOC(String AssetID)
        {
            //MouseHover On Activity
            logger.LogMethodEntry("ContentLibraryPage",
                "MouseHoverOnActivity",
                 base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AssetID));
            //Mouse Hover On Searched Activity Name
            IWebElement testName = base.GetWebElementPropertiesById(AssetID);
            base.PerformMouseHoverByJavaScriptExecutor(testName);
            logger.LogMethodExit("ContentLibraryPage",
                "MouseHoverOnActivity",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClickOnCmenuOptionInCurriculumTab(string cmenuOption)
        {
            logger.LogMethodEntry("ContentLibraryPage", "GetCmenuOptions",
               base.IsTakeScreenShotDuringEntryExit);
            int getCmenuOptionCount = base.GetElementCountByXPath(
                ContentLibraryPageResource.ContnetLibrary_Page_Lesson_CmenuCount_Xpath_Locator);
            for (int i = 1; i <= getCmenuOptionCount; i++)
            {
                string getCmenuOption = base.GetElementTextByXPath(string.Format(
                    ContentLibraryPageResource.ContnetLibrary_Page_Lesson_CmenuOption_Xpath_Locator, i));
                if (cmenuOption.Equals(getCmenuOption))
                {
                    IWebElement getCmenuProperties = base.GetWebElementPropertiesByXPath(string.Format(
                    ContentLibraryPageResource.ContnetLibrary_Page_Lesson_CmenuOption_Xpath_Locator, i));
                    base.ClickByJavaScriptExecutor(getCmenuProperties);
                    break;
                }

            }

        }

        /// <summary>
        /// Select Digital Path product from Curriculum dropdown
        /// </summary>
        /// <param name="productName">This is the product name.</param>
        public void SelectProductFromCurriculumDropdown(String productName)
        {
            // Select Digital Path product
            logger.LogMethodEntry("ContentLibraryPage", "SelectProductFromCurriculumDropdown",base.IsTakeScreenShotDuringEntryExit);
            base.SelectWindow(ContentLibraryPageResource.ContnetLibrary_Page_Window_TitleName);
            // Switch to iframe
            base.SwitchToIFrameById(ContentLibraryPageResource.ContentLibrary_Page_Frame_Id_Locator);
            // Wait for Curriculum dropdown icon to load
            base.WaitForElement(By.Id(ContentLibraryPageResource.ContnetLibrary_Page_Product_CmenuIcon_Id_Locator));
            base.ClickImageById(ContentLibraryPageResource.ContnetLibrary_Page_Product_CmenuIcon_Id_Locator);
            // Get product count from the curriculum dropdown
            int getProductCount = base.GetElementCountByXPath(ContentLibraryPageResource.ContnetLibrary_Page_ProductCount_Xpath_Locator);
            // Check for the searched product existance
            for (int i = 1; i <= getProductCount; i++)
            {
                string getProductName = base.GetElementTextByXPath(string.Format(ContentLibraryPageResource.
                    ContnetLibrary_Page_GetProductName_Xpath_Locator, i));
                if(productName.Equals(getProductName))
                {
                    IWebElement getProductNameValue = base.GetWebElementPropertiesByXPath(string.Format(ContentLibraryPageResource.
                    ContnetLibrary_Page_GetProductName_Xpath_Locator, i));
                    base.ClickByJavaScriptExecutor(getProductNameValue);
                    break;
                }
            }

            logger.LogMethodExit("ContentLibraryPage", "SelectProductFromCurriculumDropdown", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}