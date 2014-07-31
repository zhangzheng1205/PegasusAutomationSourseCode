using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
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
        private static readonly Logger logger = Logger.GetInstance(typeof(GBLeftNavigationUXPage));

        /// <summary>
        /// This is the Pegasus Intructor Certificate Types.
        /// </summary>
        public enum MILAuthoredCourseFolderLelevlTypeEnum
        {
            /// <summary>
            /// 'Certificate of Completion(Training)' Certificate Type
            /// </summary>
            Excel = 1,
            PowerPoint = 2,
            Word=3,
            Access=4
        }

        /// <summary>
        /// Navigate inside the Activity folder
        /// </summary>
        public void NavigateToActivityFolder()
        {
            //Navigate Inside The Folder
            logger.LogMethodEntry("GBLeftNavigationUXPage", "NavigateToActivityFolder",
                                 base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Select Gradebook window
                base.WaitUntilWindowLoads(GBLeftNavigationUXPageResource
                     .GBLeftNavigationUXPage_WindowName_Title);
                //Select Left Navigation Frame
                this.SelectLeftNavigationFrame();
                // Click on Root Folder
               IWebElement activityFolder =  base.WebDriver.FindElement(By
                   .PartialLinkText(GBLeftNavigationUXPageResource
                    .GBLeftNavigationUXPage_ActivityFolder_LinkText_Locator));
               base.ClickByJavaScriptExecutor(activityFolder);         
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBLeftNavigationUXPage", "NavigateToActivityFolder",
                             base.isTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Select Left Navigation Frame
        /// </summary>
        private void SelectLeftNavigationFrame()
        {
            //Select Left Navigation Frame
            logger.LogMethodEntry("GBLeftNavigationUXPage", "SelectLeftNavigationFrame",
                                 base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilPopUpLoads(GBLeftNavigationUXPageResource
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
            logger.LogMethodExit("GBLeftNavigationUXPage", "SelectLeftNavigationFrame",
                                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate In Activity Folder.
        /// </summary>
        /// <param name="folderName">This is Folder Name.</param>
        private void NavigateInsideActivityFolder(string folderName)
        {
            //Navigate Inside Activity Folder
            logger.LogMethodEntry("GBLeftNavigationUXPage", "NavigateInsideActivityFolder",
                            base.isTakeScreenShotDuringEntryExit);
            //Select Left Navigation Frame
            this.SelectLeftNavigationFrame();
            // Click on Additional practice
            base.WaitForElement(By.PartialLinkText(folderName));
           IWebElement getFolderName =  base.WebDriver.FindElement
               (By.PartialLinkText(folderName));
           base.ClickByJavaScriptExecutor(getFolderName);
            Thread.Sleep(Convert.ToInt32(GBLeftNavigationUXPageResource
                .GBLeftNavigationUXPage_ElementTime_Value));            
            logger.LogMethodExit("GBLeftNavigationUXPage", "NavigateInsideActivityFolder",
                           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside the Folder
        /// </summary>
        public void NavigateInsideFolderHED( )
        {
            //Navigate Inside Folder
            logger.LogMethodEntry("GBLeftNavigationUXPage", "NavigateInsideFolderHED",
                            base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("GBLeftNavigationUXPage", "NavigateInsideFolderHED",
                           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter inside Asset
        /// </summary>
        /// <param name="assetName">This is Asset Name</param>
        private void EnterInsideAsset(string assetName)
        {
            //Enter inside Asset
            logger.LogMethodEntry("GBLeftNavigationUXPage", "EnterInsideAsset",
                            base.isTakeScreenShotDuringEntryExit);
            //Wait for Some Time
            Thread.Sleep(Convert.ToInt32(GBLeftNavigationUXPageResource
                .GBLeftNavigationUXPage_ThreadTime_Value));
            base.WaitForElement(By.PartialLinkText(assetName));
            IWebElement getAssetProperty = 
                base.GetWebElementPropertiesByPartialLinkText(assetName);
            //Click on Asset Name
            base.ClickByJavaScriptExecutor(getAssetProperty);
            logger.LogMethodExit("GBLeftNavigationUXPage", "EnterInsideAsset",
                           base.isTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Manage The Gradebook Folder Navigation.
        /// </summary>
        /// <param name="mILAuthoredCourseFolderLelevlTypeEnum">This is MIL Folder Navigation Type Enum.</param>
        public void ManageTheGradebookFolderNavigation(MILAuthoredCourseFolderLelevlTypeEnum 
            mILAuthoredCourseFolderLelevlTypeEnum)
        {
            //Manage The Gradebook Folder Navigation
            logger.LogMethodEntry("GBLeftNavigationUXPage","ManageTheGradebookFolderNavigation",
               base.isTakeScreenShotDuringEntryExit);
            //Select Folder level type           
            try
            {
                //Report Type
                switch (mILAuthoredCourseFolderLelevlTypeEnum)
                {
                    //Generate Activity Result by Student Report
                    case MILAuthoredCourseFolderLelevlTypeEnum.Word:
                        break;
                    case MILAuthoredCourseFolderLelevlTypeEnum.Access:
                        break;
                    case MILAuthoredCourseFolderLelevlTypeEnum.Excel:
                        break;
                    case MILAuthoredCourseFolderLelevlTypeEnum.PowerPoint:
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBLeftNavigationUXPage","ManageTheGradebookFolderNavigation",
              base.isTakeScreenShotDuringEntryExit);
        }
    }
}
