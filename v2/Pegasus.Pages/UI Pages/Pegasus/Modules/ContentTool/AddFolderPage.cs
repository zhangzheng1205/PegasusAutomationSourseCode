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
    /// This Class Handles Creation of Custom Content
    /// </summary>
  public class AddFolderPage:BasePage
    {
          /// <summary>
          ///  Static instance of the logger
          /// </summary>
      private static Logger logger = Logger.GetInstance(typeof(AddFolderPage));

     /// <summary>
     /// Create The Folder
     /// </summary>
     /// <param name="activityTypeEnum">This is Activity Type Enum</param>
      public void CreateTheFolder(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Create The Folder
            logger.LogMethodEntry("AddFolderPage", "CreateTheFolder",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Intialize Guid for Folder
                Guid activityFolder = Guid.NewGuid();
                //Select Add Folder Window
                this.SelectAddFolderWindow();
                //Wait for the element
                base.WaitForElement(By.Id(AddFolderPageResource.
                    AddFolder_Page_Fold_Name_Textbox_Id_Locator));
                //Fill the Activity Folder Name in textbox
                base.FillTextBoxById(AddFolderPageResource.
                AddFolder_Page_Fold_Name_Textbox_Id_Locator,
                activityFolder.ToString());
                //Store the Activity Folder content
                this.StoreTheActivityFolderContent(activityFolder,activityTypeEnum);
                if (activityTypeEnum == Activity.ActivityTypeEnum.QuestionFolder)
                {
                    if (!base.IsElementSelectedById(AddFolderPageResource.
                        AddFolder_Page_QuestionFolder_Checkbox_Id_Locator))
                    {
                        base.SelectCheckBoxById(AddFolderPageResource.
                        AddFolder_Page_QuestionFolder_Checkbox_Id_Locator);
                    }
                }
                base.FocusOnElementById(AddFolderPageResource.
                    AddFolder_Page_Folder_Create_Button_Id_Locator);
                //Click the "Create" Button
                base.ClickButtonById(AddFolderPageResource.
                    AddFolder_Page_Folder_Create_Button_Id_Locator);
                Thread.Sleep(Convert.ToInt32(AddFolderPageResource.
            AddFolder_Page_Create_ButtonClick_Time_value));
            }
            catch (Exception e)
            { ExceptionHandler.HandleException(e);
            }
          logger.LogMethodExit("AddFolderPage", "CreateTheFolder",
           base.IsTakeScreenShotDuringEntryExit); 
        }

      /// <summary>
      /// Select Add Folder Window.
      /// </summary>
      private void SelectAddFolderWindow()
      {
          //Select Add Folder Window
          logger.LogMethodEntry("AddFolderPage", "SelectAddFolderWindow",
               base.IsTakeScreenShotDuringEntryExit);
          //Select the folder window
          base.WaitUntilWindowLoads(AddFolderPageResource.
              AddFolder_Page_Folder_Window_Name);
          base.SelectWindow(AddFolderPageResource.
              AddFolder_Page_Folder_Window_Name);
          logger.LogMethodExit("AddFolderPage", "SelectAddFolderWindow",
           base.IsTakeScreenShotDuringEntryExit); 
      }

      /// <summary>
      /// Store The Activity Folder Content
      /// </summary>
      /// <param name="activityFolder">This is Activity Folder Guid</param>
      private void StoreTheActivityFolderContent(Guid activityFolder,
          Activity.ActivityTypeEnum activityTypeEnum)
      {
          //Store The Activity Folder Content
          logger.LogMethodEntry("AddFolderPage",
              "StoreTheActivityFolderContent",
              base.IsTakeScreenShotDuringEntryExit);        
          //Store the activity in memory
          Activity newActivityFolder = new Activity
          {
              Name = activityFolder.ToString(),
              ActivityType = activityTypeEnum,
              IsCreated = true,
          };
          newActivityFolder.StoreActivityInMemory();
          logger.LogMethodExit("AddFolderPage",
              "StoreTheActivityFolderContent",
           base.IsTakeScreenShotDuringEntryExit); 
      }

    }
}
