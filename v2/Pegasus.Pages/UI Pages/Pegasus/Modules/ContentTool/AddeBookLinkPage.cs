using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.ContentTool;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
   public class AddeBookLinkPage:BasePage
    {
       /// <summary>
       /// The static instance of the logger for the class.
       /// </summary>
       private static Logger logger = Logger.GetInstance(typeof(AddeBookLinkPage));

       /// <summary>
       /// Create eText Link Asset
       /// </summary>
       /// <param name="activityTypeEnum">This is activity type</param>
       public void CreateeTextLinkAsset(Activity.ActivityTypeEnum activityTypeEnum)
       {
           //Create eText Link Asset
           logger.LogMethodEntry("AddeBookLinkPage", "CreateeTextLinkAsset",
               base.isTakeScreenShotDuringEntryExit);
           try
           {
               //Select eText Window
               this.SelecteTextWindow();              
               base.WaitForElement(By.Id(AddeBookLinkPageResource.AddeBookLink_Page_eTextTitle_Id_Locator));
               //Guid for eText the Activity
               Guid eText = Guid.NewGuid();
               //Fill Text Box With eText Name
               base.FillTextBoxById(AddeBookLinkPageResource.AddeBookLink_Page_eTextTitle_Id_Locator,
               eText.ToString());
               //Wait for the select book textbox
               base.WaitForElement(By.Id(AddeBookLinkPageResource.AddeBookLink_Page_SelectBook_Id_Locator));                 
               base.SelectDropDownValueThroughIndexById
                   (AddeBookLinkPageResource.AddeBookLink_Page_SelectBook_Id_Locator,
                 Convert.ToInt32(AddeBookLinkPageResource.AddeBookLink_Page_SelectBook_Dropdown_Value));
               //Wait for the add button
               base.WaitForElement(By.Id(AddeBookLinkPageResource.AddeBookLink_Page_AddButton_Id_Locator));
               IWebElement ClickAddButtonProperty = base.GetWebElementPropertiesById
                   (AddeBookLinkPageResource.AddeBookLink_Page_AddButton_Id_Locator);
               //Click the add button
               base.ClickByJavaScriptExecutor(ClickAddButtonProperty);
               //Save eTextLink in Memory
               this.StoreETextLinkAssetDetailsInMemory(eText.ToString(), activityTypeEnum);
               //Select The Save Copy To Window
               this.SelectTheSaveCopyToWindow();               
           }
           catch (Exception e)
           {
               ExceptionHandler.HandleException(e);
           }
           logger.LogMethodExit("AddeBookLinkPage", "CreateeTextLinkAsset",
               base.isTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Select The Save Copy To Window
       /// </summary>
       private void SelectTheSaveCopyToWindow()
       {
           //Select The Save Copy To Window
           logger.LogMethodEntry("AddeBookLinkPage", "SelectTheSaveCopyToWindow",
               base.isTakeScreenShotDuringEntryExit);
           //Wait for the window loads
           base.WaitUntilWindowLoads(AddeBookLinkPageResource.AddeBookLink_Page_SaveCopy_Window_Name);
           base.SelectWindow(AddeBookLinkPageResource.AddeBookLink_Page_SaveCopy_Window_Name);
           //Wait for the element
           base.WaitForElement(By.Id(AddeBookLinkPageResource.
               AddeBookLink_Page_AddCloseButton_Id_Locator));
           IWebElement AddAndCloseButton = base.GetWebElementPropertiesById
               (AddeBookLinkPageResource.AddeBookLink_Page_AddCloseButton_Id_Locator);
           //Click the add and close button
           base.ClickByJavaScriptExecutor(AddAndCloseButton);
           logger.LogMethodExit("AddeBookLinkPage", "SelectTheSaveCopyToWindow",
               base.isTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Select eText Window
       /// </summary>
       private void SelecteTextWindow()
       {
           //Select eText Window
           logger.LogMethodEntry("AddeBookLinkPage", "SelecteTextWindow",
               base.isTakeScreenShotDuringEntryExit);
           base.WaitUntilWindowLoads(AddeBookLinkPageResource.AddeBookLink_Page_AddeText_Window_Name);
           //Select the eText window
           base.SelectWindow(AddeBookLinkPageResource.AddeBookLink_Page_AddeText_Window_Name);
           logger.LogMethodExit("AddeBookLinkPage", "SelecteTextWindow",
               base.isTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Store EText Link Asset Details In Memory
       /// </summary>
       /// <param name="activityName">This is activity name</param>
       /// <param name="activityTypeEnum">This is activity type enum</param>
       private void StoreETextLinkAssetDetailsInMemory(string activityName, Activity.ActivityTypeEnum activityTypeEnum)
       {
           //Store EText Link Asset Details In Memory
           logger.LogMethodEntry("AddeBookLinkPage", "StoreETextLinkAssetDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
           Activity eTextlink = new Activity
           {
               Name = activityName,
               ActivityType = activityTypeEnum,
               IsCreated = true,
           };          
           //Save Activity Name to Memory
           eTextlink.StoreActivityInMemory();
           logger.LogMethodExit("AddeBookLinkPage", "StoreETextLinkAssetDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
       }
    }
}
