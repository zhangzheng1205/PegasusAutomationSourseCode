﻿using System;
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
    /// This Class Handles Creation of Link Custom Content
    /// </summary>
  public class AddUrlPage :BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
      private static Logger logger = Logger.GetInstance(typeof(AddUrlPage));
      
      /// <summary>
      /// Create Link Asset
      /// </summary>
      /// <param name="activityTypeEnum">This is Activity Type.</param>
      public void CreateLinkAsset(Activity.ActivityTypeEnum activityTypeEnum)
      {
          //Create Link Asset
          logger.LogMethodEntry("AddUrlPage", "CreateLinkAsset",
            base.IsTakeScreenShotDuringEntryExit);              
          //Intialize Guid for Link Asset
          Guid newLinkAsset = Guid.NewGuid();
          try
          {
              //Select the window
              base.WaitUntilWindowLoads(AddUrlPageResource.
                     AddUrl_Page_Link_window_Name);  
              base.SelectWindow(AddUrlPageResource.
                     AddUrl_Page_Link_window_Name);            
              //Wait for the element
              base.WaitForElement(By.Id(AddUrlPageResource.
                  AddUrl_Page_Link_TitleName_Textbox_Id_Locator));
              //Fill the link Name in textbox
              base.FillTextBoxById(AddUrlPageResource.
                  AddUrl_Page_Link_TitleName_Textbox_Id_Locator, 
                  newLinkAsset.ToString());
              //Store the link Asset
              this.StoreTheLinkAsset(newLinkAsset,activityTypeEnum);
              //Click The Add Button
              this.ClickTheAddButton();
          }
          catch (Exception e)
          {
              ExceptionHandler.HandleException(e);
          }
          logger.LogMethodExit("AddUrlPage", "CreateLinkAsset",
        base.IsTakeScreenShotDuringEntryExit); 
      }

      /// <summary>
      /// Click The Add Button.
      /// </summary>
      private void ClickTheAddButton()
      {
          //Click The Add Button
          logger.LogMethodEntry("AddUrlPage", "ClickTheAddButton",
            base.IsTakeScreenShotDuringEntryExit);
          //Fill the URL text
          base.FillTextBoxById(AddUrlPageResource.
              AddUrl_Page_URL_Textbox_Id_Locator, AddUrlPageResource.
              AddUrl_Page_URL_Textbox_Id_Locator_Value);         
          //Wait for the element
          base.WaitForElement(By.Id(AddUrlPageResource.
              AddUrl_Page_Link_CreateButton_Id_Locator));
          base.FocusOnElementById(AddUrlPageResource.
              AddUrl_Page_Link_CreateButton_Id_Locator);
          //Click the "Add" button
          base.ClickButtonById(AddUrlPageResource.
              AddUrl_Page_Link_CreateButton_Id_Locator);
          logger.LogMethodExit("AddUrlPage", "ClickTheAddButton",
       base.IsTakeScreenShotDuringEntryExit); 
      }

      /// <summary>
      /// Store the asset
      /// </summary>
      /// <param name="newLinkAsset">This is Link Asset Guid</param>
      /// <param name="activityTypeEnum">This is Activity Type enum.</param>
      private void StoreTheLinkAsset(Guid newLinkAsset,
          Activity.ActivityTypeEnum activityTypeEnum)
      {
          //Store the asset 
         logger.LogMethodEntry("AddUrlPage", "StoreTheLinkAsset",
            base.IsTakeScreenShotDuringEntryExit);
           //Store the Link in memory
         Activity newLink=new Activity
         {
             ActivityId=CommonResource.CommonResource.DigitalPath_Activity_Link_UC4,
             Name=newLinkAsset.ToString(),
             ActivityType = activityTypeEnum,
             IsCreated=true,
         };
         newLink.StoreActivityInMemory();
         logger.LogMethodExit("AddUrlPage", "StoreTheLinkAsset",
           base.IsTakeScreenShotDuringEntryExit); 
      }
    }
}
