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
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Discussion;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Creation of Link Custom Content
    /// </summary>
    public class AddDiscussionTopicPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(AddDiscussionTopicPage));

        /// <summary>
        /// Create Discussion Topic Asset.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type.</param>
        public void CreateDiscussionTopicAsset(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Create Discussion Topic Asset
            // Create File Asset
            logger.LogMethodEntry("AddDiscussionTopicPage",
                "CreateDiscussionTopicAsset",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Intialize Guid for File Asset
                Guid newDiscussionTopicName = Guid.NewGuid();
                //Select the window
                base.WaitUntilWindowLoads(AddDiscussionTopicPageResource.
                    AddDiscussionTopicPageResource_Window_Name);
                base.SelectWindow(AddDiscussionTopicPageResource.
                    AddDiscussionTopicPageResource_Window_Name);
                //Wait for the element
                base.WaitForElement(By.Id(AddDiscussionTopicPageResource.
                    AddDiscussionTopicPageResource_Title_Textbox_Id_Locator));
                //Fill the FileName text
                base.FillTextBoxByID(AddDiscussionTopicPageResource.
                    AddDiscussionTopicPageResource_Title_Textbox_Id_Locator,
                    newDiscussionTopicName.ToString());
                //Fill The HTML Description
                this.FillTheHTMLDescription(newDiscussionTopicName.ToString());
                //Store the Discussion topic Asset
                this.StoreTheDiscussionTopicAsset(newDiscussionTopicName, activityTypeEnum);
                //Click On Add Button
                this.ClickOnSaveCloseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddDiscussionTopicPage",
                "CreateDiscussionTopicAsset",
              base.isTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Fill The HTML Description.
        /// </summary>
        /// <param name="newHTMLDiscription">This is HTML Discription.</param>
        private void FillTheHTMLDescription(string newHTMLDiscription)
        {
            //Fill The HTML Description
            logger.LogMethodEntry("AddDiscussionTopicPage", "FillTheHTMLDescription",
                      base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(AddDiscussionTopicPageResource.
                AddDiscussionTopicPageResource_HTML_Sourse_Id_Locator));
            // Click on ShowHTML button
            base.FocusOnElementByID(AddDiscussionTopicPageResource.
                AddDiscussionTopicPageResource_HTML_Sourse_Id_Locator);
            //Click the sourse link
            base.ClickButtonByID(AddDiscussionTopicPageResource.
                AddDiscussionTopicPageResource_HTML_Sourse_Id_Locator);
            //Wait For HTML Editor
            base.WaitForElement(By.Id(AddDiscussionTopicPageResource.
                AddDiscussionTopicPageResource_HTML_TextArea_Id_Locator));
            // Fill Description text in HTMLEditor textbox
            base.FillTextBoxByID(AddDiscussionTopicPageResource.
                AddDiscussionTopicPageResource_HTML_TextArea_Id_Locator,
                newHTMLDiscription.ToString());
            base.SwitchToDefaultPageContent();
            logger.LogMethodExit("AddDiscussionTopicPage", "FillTheHTMLDescription",
                     base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save And Close Button.
        /// </summary>
        private void ClickOnSaveCloseButton()
        {
            //Click On Save And Close Button
            logger.LogMethodEntry("AddDiscussionTopicPage", "ClickOnSaveCloseButton",
              base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(AddDiscussionTopicPageResource.
                AddDiscussionTopicPageResource_SaveClose_Button_Id_Locator));
            base.FocusOnElementByID(AddDiscussionTopicPageResource.
                AddDiscussionTopicPageResource_SaveClose_Button_Id_Locator);
            //Get the web element
            IWebElement getSaveCloseButton = base.GetWebElementPropertiesById
                (AddDiscussionTopicPageResource.
                AddDiscussionTopicPageResource_SaveClose_Button_Id_Locator);
            //Click the "Save" button
            base.ClickByJavaScriptExecutor(getSaveCloseButton);
            Thread.Sleep(Convert.ToInt32(AddDiscussionTopicPageResource.
                AddDiscussionTopicPageResource_Time_Value));
            logger.LogMethodExit("AddDiscussionTopicPage", "ClickOnSaveCloseButton",
              base.isTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Store the Discussion topic Asset.
        /// </summary>
        /// <param name="newDiscussionTopicName">This is discussion Topic Name.</param>
        /// <param name="activityTypeEnum">This is Activity Type.</param>
        private void StoreTheDiscussionTopicAsset(Guid newDiscussionTopicName,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Store the Discussion topic Asset
            logger.LogMethodEntry("AddDiscussionTopicPage", 
                "StoreTheDiscussionTopicAsset",
                 base.isTakeScreenShotDuringEntryExit);
            //Store the Discussion Topic in memory
            Activity newFile = new Activity
            {
                Name = newDiscussionTopicName.ToString(),
                ActivityType = activityTypeEnum,
                IsCreated = true,
            };
            newFile.StoreActivityInMemory();
            logger.LogMethodExit("AddDiscussionTopicPage", 
                "StoreTheDiscussionTopicAsset",
                 base.isTakeScreenShotDuringEntryExit); 
        }
    }
}
