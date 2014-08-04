﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.MMND.DigitalVellum;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles MMND Post Index Mixed Page Actions
    /// </summary>
    public class PostIndexMixedPage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(PostIndexMixedPage));

        /// <summary>
        /// Add New Tool Launch Subtab
        /// </summary>
        /// <param name="subtabName">This is Tool/Asset launch Subtab Name</param>
        public void AddNewToolLaunchSubtab(string subtabName)
        {
            //Add New Tool Launch Subtab
            logger.LogMethodEntry("PostIndexMixedPage", "AddNewToolLaunchSubtab",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {                
                //Wait and Click on the Modify link
                base.WaitForElement(By.Id(PostIndexMixedPageResource.
                    PostIndexMixedPage_Left_Modify_Id_Locator));
                IWebElement getModifyLink = base.GetWebElementPropertiesById(PostIndexMixedPageResource.
                    PostIndexMixedPage_Left_Modify_Id_Locator);
                base.ClickByJavaScriptExecutor(getModifyLink);                
                //Wait and Click on the Add & Arrange Tab
                base.WaitForElement(By.Id(PostIndexMixedPageResource.
                    PostIndexMixedPage_AddArrange_Subtab_Id_Locator));
                IWebElement getAddArrangeTab = base.GetWebElementPropertiesById(PostIndexMixedPageResource.
                    PostIndexMixedPage_AddArrange_Subtab_Id_Locator);
                base.ClickByJavaScriptExecutor(getAddArrangeTab);                
                //Wait and Click on the Add New subtab Button
                base.WaitForElement(By.Id(PostIndexMixedPageResource.
                    PostIndexMixedPage_Lightbox_AddNewButton_Id_Locator));
                //Focus on the Button
                base.FocusOnElementById(PostIndexMixedPageResource.
                    PostIndexMixedPage_Lightbox_AddNewButton_Id_Locator);
                IWebElement getAddNewItemButton = base.GetWebElementPropertiesById(PostIndexMixedPageResource.
                    PostIndexMixedPage_Lightbox_AddNewButton_Id_Locator);
                base.ClickByJavaScriptExecutor(getAddNewItemButton);
                //Enter the Sub tab Details
                this.EnterSubTabDetails(subtabName);
                //Save The SubTab And Close The Popup
                this.SaveTheSubTabAndCloseThePopup();
                //Store Subtab Link Name In Memory
                this.StoreSubtabLinkNameInMemory(subtabName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PostIndexMixedPage", "AddNewToolLaunchSubtab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Subtab Link Name In Memory
        /// </summary>
        /// <param name="subtabLinkName">This is Tool/Asset launch Subtab Link Name</param>
        private void StoreSubtabLinkNameInMemory(string subtabLinkName)
        {
            //Store Subtab Link Name In Memory
            logger.LogMethodEntry("PostIndexMixedPage", "StoreSubtabLinkNameInMemory",
                base.IsTakeScreenShotDuringEntryExit);            
            MmndToolLinks link = new MmndToolLinks
            {
                Name = subtabLinkName,
                LinkType = MmndToolLinks.LinkTypeEnum.MMND,
                IsCreated = true
            }; 
            link.StoreLinkInMemory();
            logger.LogMethodExit("PostIndexMixedPage", "StoreSubtabLinkNameInMemory",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save The SubTab And Close The Popup
        /// </summary>
        private void SaveTheSubTabAndCloseThePopup()
        {
            //Save The SubTab And Close The Popup
            logger.LogMethodEntry("PostIndexMixedPage", "SaveTheSubTabAndCloseThePopup",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the Save button
            base.ClickLinkById(PostIndexMixedPageResource.
                PostIndexMixedPage_Lightbox_Save_Button_Id_Locator);
            //Wait and Click on the Add New subtab Button
            base.WaitForElement(By.Id(PostIndexMixedPageResource.
                PostIndexMixedPage_Lightbox_AddNewButton_Id_Locator));
            //Wait for the Message
            base.WaitForElement(By.ClassName(PostIndexMixedPageResource.
                PostIndexMixedPage_AddNewSubtab_Notifier_ClassName_Locator));
            string text = base.GetElementTextByClassName(PostIndexMixedPageResource.
                PostIndexMixedPage_AddNewSubtab_Notifier_ClassName_Locator);
            //Wait for 3secs
            Thread.Sleep(Convert.ToInt32(PostIndexMixedPageResource.
                PostIndexMixedPage_Sleep_Time));
            //Click on Close            
            base.ClickByJavaScriptExecutor(base.
                GetWebElementPropertiesByClassName(PostIndexMixedPageResource.
                PostIndexMixedPage_Lightbox_Close_Button_ClassName_Locator));
            logger.LogMethodExit("PostIndexMixedPage", "SaveTheSubTabAndCloseThePopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Sub Tab Details
        /// </summary>
        /// <param name="subtabLinkName">This is Tool/Asset launch Subtab Link Name</param>
        private void EnterSubTabDetails(string subtabLinkName)
        {
            //Enter Subtab Details
            logger.LogMethodEntry("PostIndexMixedPage", "EnterSubTabDetails",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for Drop Down
            base.WaitForElement(By.Id(PostIndexMixedPageResource.
                PostIndexMixedPage_Lightbox_AddContents_Dropdown_Id_Locator));
            //Select the option as 'Content Page'
            base.SelectDropDownValueThroughTextById(PostIndexMixedPageResource.
                PostIndexMixedPage_Lightbox_AddContents_Dropdown_Id_Locator,
                PostIndexMixedPageResource.
                PostIndexMixedPage_Lightbox_AddContent_Dropdown_ContentPage_Value);
            //Wait for Text field
            base.WaitForElement(By.Id(PostIndexMixedPageResource.
                PostIndexMixedPage_Lightbox_AddList_Textfield_Id_Locator));
            //Clear and fill The text
            base.ClearTextById(PostIndexMixedPageResource.
                PostIndexMixedPage_Lightbox_AddList_Textfield_Id_Locator);
            base.FillTextBoxById(PostIndexMixedPageResource.
                PostIndexMixedPage_Lightbox_AddList_Textfield_Id_Locator, subtabLinkName);
            logger.LogMethodExit("PostIndexMixedPage", "EnterSubTabDetails",
                base.IsTakeScreenShotDuringEntryExit);
        }                     

        /// <summary>
        /// Click On Manage Option
        /// </summary>
        /// <param name="subtabLinkName">This is Tool/Asset launch Subtab Link Name</param>
        public void ClickOnManageOption(string subtabLinkName)
        {
            //Click On Manage Option
            logger.LogMethodEntry("PostIndexMixedPage", "ClickOnManageOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the window to load
                base.WaitUntilWindowLoads(subtabLinkName);
                //Select the window
                base.SelectWindow(subtabLinkName);                
                //Click on the Modify Link
                base.WaitForElement(By.Id(PostIndexMixedPageResource.
                    PostIndexMixedPage_Right_Modify_Id_Locator));
                base.ClickLinkById(PostIndexMixedPageResource.
                    PostIndexMixedPage_Right_Modify_Id_Locator);
                //Click on the Manage option from the Drop Down
                base.WaitForElement(By.XPath(PostIndexMixedPageResource.
                    PostIndexMixedPage_Right_Modify_Manage_Option_Xpath_Locator));                
                base.ClickLinkByXPath(PostIndexMixedPageResource.
                    PostIndexMixedPage_Right_Modify_Manage_Option_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PostIndexMixedPage", "ClickOnManageOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Tool Launch Subtab
        /// </summary>
        /// <param name="subtabLinkName">This is Tool/Asset launch Subtab Link Name</param>
        public void ClickOnToolLaunchSubtab(string subtabLinkName)
        {
            //Click On Tool Launch Subtab
            logger.LogMethodEntry("PostIndexMixedPage", "ClickOnToolLaunchSubtab",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the window to load
                base.WaitUntilWindowLoads(PostIndexMixedPageResource.
                    PostIndexMixedPage_Window_CourseHome_Title);
                //Select the window
                base.SelectWindow(PostIndexMixedPageResource.
                    PostIndexMixedPage_Window_CourseHome_Title);
                //Click on the Tool Launch Sub tab
                base.ClickButtonByPartialLinkText(subtabLinkName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PostIndexMixedPage", "ClickOnToolLaunchSubtab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Subtab Link name For Tool/Asset Launch
        /// </summary>
        /// <returns>Subtab Link name For Tool/Asset Launch</returns>
        public String GetSubTabLinkName()
        {
            //Get the Subtab Link name
            logger.LogMethodEntry("PostIndexMixedPage", "GetSubTabLinkName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variables            
            string subTabName = string.Empty;
            MmndToolLinks toolLinkName = null;
            try
            {
                try
                {
                    //Get the Link Name 
                    toolLinkName = MmndToolLinks.Get(MmndToolLinks.LinkTypeEnum.MMND);
                    if (toolLinkName == null)
                    {
                        //Create a new GUID
                        subTabName = Guid.NewGuid().ToString();
                    }
                    else
                    {
                        subTabName = toolLinkName.Name;
                    }
                }
                catch
                {
                    //Create a new GUID
                    subTabName = Guid.NewGuid().ToString();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PostIndexMixedPage", "GetSubTabLinkName",
                base.IsTakeScreenShotDuringEntryExit);
            return subTabName;
        }


    }
}
