using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class defines the actions of left navigation frame of grade
    /// </summary>
    public class GBLeftNavigationUXPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(GBLeftNavigationUXPage));

        /// <summary>
        /// Navigate inside the Activity folder.
        /// </summary>
        public void NavigateToActivityFolder()
        {
            //Navigate Inside The Folder
            Logger.LogMethodEntry("GBLeftNavigationUXPage", "NavigateToActivityFolder",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Select Gradebook window
                base.WaitUntilWindowLoads(GBLeftNavigationUXPageResource
                    .GBLeftNavigationUXPage_WindowName_Title);
                //Select Left Navigation Frame
                this.SelectStudentGradebookLeftNavigationFrame();
                // Click on Root Folder
                IWebElement activityFolder = base.WebDriver.FindElement(By
                    .PartialLinkText(GBLeftNavigationUXPageResource
                        .GBLeftNavigationUXPage_ActivityFolder_LinkText_Locator));
                base.ClickByJavaScriptExecutor(activityFolder);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("GBLeftNavigationUXPage", "NavigateToActivityFolder",
                base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Select Student Gradebook Left Navigation Frame.
        /// </summary>
        private void SelectStudentGradebookLeftNavigationFrame()
        {
            //Select Left Navigation Frame
            Logger.LogMethodEntry("GBLeftNavigationUXPage",
                "SelectStudentGradebookLeftNavigationFrame",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(GBLeftNavigationUXPageResource
                .GBLeftNavigationUXPage_WindowName_Title);
            //Select Window
            base.SelectWindow(GBLeftNavigationUXPageResource
                .GBLeftNavigationUXPage_WindowName_Title);
            //Wait for Element
            base.WaitForElement(By.Id(GBLeftNavigationUXPageResource
                .GBLeftNavigationUXPage_LeftNavigationFrame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(GBLeftNavigationUXPageResource
                .GBLeftNavigationUXPage_LeftNavigationFrame_Id_Locator);
            Logger.LogMethodExit("GBLeftNavigationUXPage",
                "SelectStudentGradebookLeftNavigationFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside the Folder.
        /// </summary>
        public void NavigateInsideFolderHed()
        {
            //Navigate Inside Folder
            Logger.LogMethodEntry("GBLeftNavigationUXPage", "NavigateInsideFolderHed",
                            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Gradebook window
                base.WaitUntilWindowLoads(GBLeftNavigationUXPageResource
                     .GBLeftNavigationUXPage_WindowName_Title);
                base.SelectWindow(GBLeftNavigationUXPageResource
                    .GBLeftNavigationUXPage_WindowName_Title);
                //Wait for Frame
                base.WaitForElement(By.Id(GBLeftNavigationUXPageResource
                    .GBLeftNavigationUXPage_LeftNavigationFrame_Id_Locator));
                base.SwitchToIFrame(GBLeftNavigationUXPageResource
                    .GBLeftNavigationUXPage_LeftNavigationFrame_Id_Locator);
                //Enter inside the Asset
                this.EnterInsideAsset(GBLeftNavigationUXPageResource.
                    GBLeftNavigationUXPage_ActivityFolder_LinkText_Locator);
                //Enter Insdie the Asset
                this.EnterInsideAsset(GBLeftNavigationUXPageResource.
                    GBLeftNavigationUXPage_ChapterResources_LinkText_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("GBLeftNavigationUXPage", "NavigateInsideFolderHed",
                           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter inside Asset.
        /// </summary>
        /// <param name="assetName">This is Asset Name.</param>
        private void EnterInsideAsset(string assetName)
        {
            //Enter inside Asset
            Logger.LogMethodEntry("GBLeftNavigationUXPage", "EnterInsideAsset",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for Some Time
            Thread.Sleep(Convert.ToInt32(GBLeftNavigationUXPageResource
                .GBLeftNavigationUXPage_ThreadTime_Value));
            base.WaitForElement(By.PartialLinkText(assetName));
            IWebElement getAssetProperty =
                base.GetWebElementPropertiesByPartialLinkText(assetName);
            //Click on Asset Name
            base.ClickByJavaScriptExecutor(getAssetProperty);
            Logger.LogMethodExit("GBLeftNavigationUXPage", "EnterInsideAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}