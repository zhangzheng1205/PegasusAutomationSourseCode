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
                      base.isTakeScreenShotDuringEntryExit);
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
                     base.isTakeScreenShotDuringEntryExit);
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
                      base.isTakeScreenShotDuringEntryExit);
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
                     base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select Create Page Window.
        /// </summary>
        private void SelectCreatePageWindow()
        {
            //Select Create Page Window
            logger.LogMethodEntry("PegasusHTMLUXPage", "SelectCreatePageWindow",
                      base.isTakeScreenShotDuringEntryExit);
            //Select the window
            base.WaitUntilWindowLoads(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Window_Name);
            base.SelectWindow(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Window_Name);
            logger.LogMethodExit("PegasusHTMLUXPage", "SelectCreatePageWindow",
                     base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Create Button
        /// </summary>
        private void ClickTheCreateButton()
        {
            //Click The Create Button
            logger.LogMethodEntry("PegasusHTMLUXPage", "ClickTheCreateButton",
                      base.isTakeScreenShotDuringEntryExit);
            //Wait For create button
            base.WaitForElement(By.Id(PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Create_Button_Id_Locator));
            IWebElement getCreateButton=base.GetWebElementPropertiesById
                (PegasusHTMLUXPageResource.
                PegasusHTMLUXPageResource_HTML_Create_Button_Id_Locator);
            //Click on the create button
            base.ClickByJavaScriptExecutor(getCreateButton);
            logger.LogMethodExit("PegasusHTMLUXPage", "ClickTheCreateButton",
                     base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store The Page Asset.
        /// </summary>
        /// <param name="newPageAsset">This is Page Name.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        private void StoreThePageAsset(Guid newPageAsset, 
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Store The Page Asset
            logger.LogMethodEntry("PegasusHTMLUXPage", "StoreThePageAsset",
                      base.isTakeScreenShotDuringEntryExit);
            //Store the Page in memory
            Activity newPage = new Activity
            {
                Name = newPageAsset.ToString(),
                ActivityType = activityTypeEnum,
                IsCreated = true,
            };
            newPage.StoreActivityInMemory();
            logger.LogMethodExit("PegasusHTMLUXPage", "StoreThePageAsset",
                     base.isTakeScreenShotDuringEntryExit);
        }      

        /// <summary>
        /// Create Audio Page Asset.
        /// </summary>
        /// <param name="pageAssetTypeEnum">This is Page Asset Type Enum.</param>
        public void RecordAudioFromPageAssetType(Activity.ActivityTypeEnum pageAssetTypeEnum)
        {
            // Create Page Asset.
            logger.LogMethodEntry("PegasusHTMLUXPage", "RecordAudioFromPageAssetType",
                      base.isTakeScreenShotDuringEntryExit);
            //Intialize Guid for Page Asset
            Guid newPageAsset = Guid.NewGuid();
            //Generate New Guid Page Name
            Guid newHTMLDiscription = Guid.NewGuid();
            try
            {
                //Record Audio In Page
                new EssayPage().RecordAudioforEssayQuestion();
                //Enter Page Name and Description Fields
                this.EnterPageNameAndDescirptionFields(newPageAsset, newHTMLDiscription);
                //Store the link Asset
                this.StoreTheAudioPageAsset(newPageAsset, pageAssetTypeEnum);
                //Click The Add Button
                this.ClickTheCreateButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PegasusHTMLUXPage", "RecordAudioFromPageAssetType",
                     base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Store The Audio Page Asset.
        /// </summary>
        /// <param name="newPageAsset">This is Page Name.</param>
        /// <param name="activityTypeEnum">This is Activity Type Enum.</param>
        private void StoreTheAudioPageAsset(Guid newPageAsset,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Store The Audio Page Asset
            logger.LogMethodEntry("PegasusHTMLUXPage", "StoreTheAudioPageAsset",
                      base.isTakeScreenShotDuringEntryExit);
            //Store the Page in memory
            Activity newPage = new Activity
            {
                AudioPageAssetID = CommonResource.CommonResource.HigherEdCore_Audio_PageAseet_UC1,
                Name = newPageAsset.ToString(),
                ActivityType = activityTypeEnum,
                IsCreated = true,
            };
            newPage.StoreActivityInMemory();
            logger.LogMethodExit("PegasusHTMLUXPage", "StoreTheAudioPageAsset",
                     base.isTakeScreenShotDuringEntryExit);
        } 

    }
}
