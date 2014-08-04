using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.ContentTool;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Creation of Page.
    /// </summary>
    public class PegasusHTMLUXPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(PegasusHTMLUXPage));

        /// <summary>
        /// Create Page Asset.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        public void CreatePageAsset(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Create Page Asset.
            logger.LogMethodEntry("PegasusHTMLUXPage", "CreatePageAsset",
                      base.IsTakeScreenShotDuringEntryExit);
            //Intialize Guid for Page Asset
            Guid newPageAsset = Guid.NewGuid();
            //Generate New Guid Page Name
            Guid newHTMLDiscription = Guid.NewGuid();
            try
            {
                //Enter Page Name and Description Fields
                this.EnterPageNameAndDescirptionFields(newPageAsset, newHTMLDiscription);
                //Store the link Asset
                this.StoreThePageAsset(newPageAsset, activityTypeEnum);
                //Click The Add Button
                this.ClickTheCreateButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PegasusHTMLUXPage", "CreatePageAsset",
                     base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enter Page Name and Description Fields.
        /// </summary>
        /// <param name="newPageAsset">This is Page Name.</param>
        /// <param name="newHTMLDiscription">This is Page Discription.</param>
        private void EnterPageNameAndDescirptionFields(Guid newPageAsset, Guid newHTMLDiscription)
        {
            //Select the window
            this.SelectCreatePageWindow();
            //Wait for the element
            base.WaitForElement(By.Id(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Title_Id_Locator));
            //Fill the page Name in textbox
            base.FillTextBoxById(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Title_Id_Locator,
                newPageAsset.ToString());
            //Fill The HTML Description
            this.FillTheHTMLDescription(newHTMLDiscription.ToString());
        }

        /// <summary>
        /// Fill The HTML Description.
        /// </summary>
        /// <param name="newHTMLDiscription">This is HTML Description.</param>
        private void FillTheHTMLDescription(string newHTMLDiscription)
        {
            //Fill The HTML Description
            logger.LogMethodEntry("PegasusHTMLUXPage", "FillTheHTMLDescription",
                      base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Sourse_Id_Locator));
            // Click on ShowHTML button
            base.FocusOnElementById(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Sourse_Id_Locator);
            IWebElement getHTMLSourceButton = base.GetWebElementPropertiesById
                (PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Sourse_Id_Locator);
            //Click the sourse link
            base.ClickByJavaScriptExecutor(getHTMLSourceButton);
            //Wait For HTML Editor
            base.WaitForElement(By.Id(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_TextArea_Id_Locator));
            // Fill Description text in HTMLEditor textbox
            base.FillTextBoxById(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_TextArea_Id_Locator,
                newHTMLDiscription.ToString());
            base.SwitchToDefaultPageContent();
            logger.LogMethodExit("PegasusHTMLUXPage", "FillTheHTMLDescription",
                     base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select Create Page Window.
        /// </summary>
        private void SelectCreatePageWindow()
        {
            //Select Create Page Window
            logger.LogMethodEntry("PegasusHTMLUXPage", "SelectCreatePageWindow",
                      base.IsTakeScreenShotDuringEntryExit);
            //Select the window
            base.WaitUntilWindowLoads(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Window_Name);
            base.SelectWindow(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Window_Name);
            logger.LogMethodExit("PegasusHTMLUXPage", "SelectCreatePageWindow",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Create Button
        /// </summary>
        private void ClickTheCreateButton()
        {
            //Click The Create Button
            logger.LogMethodEntry("PegasusHTMLUXPage", "ClickTheCreateButton",
                      base.IsTakeScreenShotDuringEntryExit);
            //Wait For create button
            base.WaitForElement(By.Id(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Create_Button_Id_Locator));
            IWebElement getCreateButton=base.GetWebElementPropertiesById
                (PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Create_Button_Id_Locator);
            //Click on the create button
            base.ClickByJavaScriptExecutor(getCreateButton);
            logger.LogMethodExit("PegasusHTMLUXPage", "ClickTheCreateButton",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store The Page Asset.
        /// </summary>
        /// <param name="newPageAsset">This is Page Name.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        private void StoreThePageAsset(Guid newPageAsset,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            logger.LogMethodEntry("PegasusHTMLUXPage", "StoreThePageAsset",
                      base.IsTakeScreenShotDuringEntryExit);
            //Overloaded Method To Differentiate Normal Page and Audio Page
            StoreThePageAsset(newPageAsset, activityTypeEnum, string.Empty);
            logger.LogMethodExit("PegasusHTMLUXPage", "StoreThePageAsset",
                    base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Store The Audio Page Asset.
        /// </summary>
        /// <param name="newPageAsset">This is Page Name.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        private void StoreThePageAsset(Guid newPageAsset,
            Activity.ActivityTypeEnum activityTypeEnum, string PageAssetID)
        {
            //Store The Audio Page Asset
            logger.LogMethodEntry("PegasusHTMLUXPage", "StoreTheAudioPageAsset",
                      base.IsTakeScreenShotDuringEntryExit);
            //Store the Page in memory
            Activity newPage = new Activity
            {
                ActivityID = PageAssetID,
                Name = newPageAsset.ToString(),
                ActivityType = activityTypeEnum,
                IsCreated = true,
            };
            newPage.StoreActivityInMemory();
            logger.LogMethodExit("PegasusHTMLUXPage", "StoreTheAudioPageAsset",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Audio Page Asset.
        /// </summary>
        /// <param name="pageAssetTypeEnum">This is Page Asset Type Enum.</param>
        public void RecordAudioFromPageAssetType(Activity.ActivityTypeEnum pageAssetTypeEnum)
        {
            // Create Page Asset.
            logger.LogMethodEntry("PegasusHTMLUXPage", "RecordAudioFromPageAssetType",
                      base.IsTakeScreenShotDuringEntryExit);
            //Intialize Guid for Page Asset
            Guid newPageAsset = Guid.NewGuid();
            //Generate New Guid Page Name
            Guid newHTMLDiscription = Guid.NewGuid();
            try
            {
                //Record Audio In Page
                new AudioRecorderPage().RecordAudio();
                //Enter Page Name and Description Fields
                this.EnterPageNameAndDescirptionFields(newPageAsset, newHTMLDiscription);
                //Store the link Asset
                this.StoreThePageAsset(newPageAsset, pageAssetTypeEnum, CommonResource.CommonResource.HigherEdCore_Audio_PageAseet_UC1);
                //Click The Add Button
                this.ClickTheCreateButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PegasusHTMLUXPage", "RecordAudioFromPageAssetType",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the HTML Page with Resource ID.
        /// </summary>
        public void SearchForAudioHTMLPage()
        {
            //Search the HTML Page with Resource ID
            logger.LogMethodEntry("PegasusHTMLUXPage", "SearchForHTMLPage",
                      base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get The Page Name with ID resource
                Activity pageAsset = Activity.Get(CommonResource.CommonResource.HigherEdCore_Audio_PageAseet_UC1);
                //Select Left Frame in Course Materials
                new ContentLibraryUXPage().SelectLeftFrameInContentWindow();
                //Search the HTML Page with Name Details
                new ContentLibraryUXPage().SearchTheActivity(pageAsset.Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PegasusHTMLUXPage", "SearchForHTMLPage",
                     base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select The HTML Page Preview Window.
        /// </summary>
        public void SelectHTMLPreviewPage()
        {
            // Select The HTML Page Preview Window
            logger.LogMethodEntry("PegasusHTMLUXPage", "SelectHTMLPreviewPage",
                      base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToLastOpenedWindow();
                //Select The Page Preview Window Title
                string getPageWindowName = base.GetPageTitle;
                //Wait for Window
                base.WaitUntilWindowLoads(getPageWindowName);
                //select Page Preview Window
                base.SelectWindow(getPageWindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PegasusHTMLUXPage", "SelectHTMLPreviewPage",
                     base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click The HTML Page Audio Play Button.
        /// </summary>
        public void ClickTheHTMLPlayButton()
        {
            // Click The HTML Page Audio Play Button
            logger.LogMethodEntry("PegasusHTMLUXPage", "ClickTheHTMLPlayButton",
                      base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait For Element
                base.WaitForElement(By.XPath(
                    PegasusHTMLUXPageResource.PegasusHTMLUXPageResource_HTML_Play_Button_XPath_Locator));
                IWebElement getPlayButton = base.GetWebElementPropertiesByXPath(
                    PegasusHTMLUXPageResource.PegasusHTMLUXPageResource_HTML_Play_Button_XPath_Locator);
                //Click On Play Button
                base.ClickByJavaScriptExecutor(getPlayButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PegasusHTMLUXPage", "ClickTheHTMLPlayButton",
                     base.IsTakeScreenShotDuringEntryExit);

        }
        /// <summary>
        /// Verify Player Working Scenario.
        /// </summary>
        public void VerifyTheAudioPlayer()
        {
            // Verify Player Working Scenario
            logger.LogMethodEntry("PegasusHTMLUXPage", "VerifyTheAudioPlayer",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait For Element
                base.WaitForElement(By.ClassName(
                    PegasusHTMLUXPageResource.PegasusHTMLUXPageResource_Start_PlayBack_ID_Locator));
                IWebElement getStartButton = base.GetWebElementPropertiesByClassName(
                    PegasusHTMLUXPageResource.PegasusHTMLUXPageResource_Start_PlayBack_ID_Locator);
                //Click On Start PlayBack Button
                base.ClickByJavaScriptExecutor(getStartButton);
                //Play Audio for 20 seconds
                PlayAudioForFewSeconds();
                //Stop Audio Player
                base.ClickByJavaScriptExecutor(getStartButton);
                //Close Audio Player Window
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PegasusHTMLUXPage", "VerifyTheAudioPlayer",
                     base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Play Audio For Few Seconds.
        /// </summary>
        private void PlayAudioForFewSeconds()
        {
            // Play Audio For 20 Seconds
            logger.LogMethodEntry("EssayPage", "PlayAudioForFewSeconds",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Current Time 
                base.WaitForElement(By.ClassName(
                    PegasusHTMLUXPageResource.PegasusHTMLUXPageResource_Audio_CurrentTime));
                string getAudioCurretTime = base.GetElementTextByClassName(
                    PegasusHTMLUXPageResource.PegasusHTMLUXPageResource_Audio_CurrentTime);
                //Reccursive Method To Play Audio For 20 Seconds
                if (Convert.ToInt32(getAudioCurretTime.Split(':')[1]) >=
                    Convert.ToInt32(PegasusHTMLUXPageResource.PegasusHTMLUXPageResource_Audio_Play_Time))
                {
                    return;
                }
                else
                {
                    PlayAudioForFewSeconds();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EssayPage", "PlayAudioForFewSeconds",
               base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
