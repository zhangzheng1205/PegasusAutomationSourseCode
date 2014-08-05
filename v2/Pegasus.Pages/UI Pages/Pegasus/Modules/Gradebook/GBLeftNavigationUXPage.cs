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
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(GBLeftNavigationUXPage));

        /// <summary>
        /// This is the Pegasus Intructor Certificate Types.
        /// </summary>
        public enum MilAuthoredCourseFolderLelevlTypeEnum
        {
            /// <summary>
            /// 'Certificate of Completion(Training)' Certificate Type.
            /// </summary>
            Excel = 1,
            PowerPoint = 2,
            Word=3,
            Access=4
        }

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
            Logger.LogMethodExit("GBLeftNavigationUXPage", "NavigateToActivityFolder",
                             base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Select Left Navigation Frame.
        /// </summary>
        private void SelectLeftNavigationFrame()
        {
            //Select Left Navigation Frame
            Logger.LogMethodEntry("GBLeftNavigationUXPage", "SelectLeftNavigationFrame",
                                 base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("GBLeftNavigationUXPage", "SelectLeftNavigationFrame",
                                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate In Activity Folder.
        /// </summary>
        /// <param name="folderName">This is Folder Name.</param>
        private void NavigateInsideActivityFolder(string folderName)
        {
            //Navigate Inside Activity Folder
            Logger.LogMethodEntry("GBLeftNavigationUXPage", "NavigateInsideActivityFolder",
                            base.IsTakeScreenShotDuringEntryExit);
            //Select Left Navigation Frame
            this.SelectLeftNavigationFrame();
            // Click on Additional practice
            base.WaitForElement(By.PartialLinkText(folderName));
           IWebElement getFolderName =  base.WebDriver.FindElement
               (By.PartialLinkText(folderName));
           base.ClickByJavaScriptExecutor(getFolderName);
            Thread.Sleep(Convert.ToInt32(GBLeftNavigationUXPageResource
                .GBLeftNavigationUXPage_ElementTime_Value));            
            Logger.LogMethodExit("GBLeftNavigationUXPage", "NavigateInsideActivityFolder",
                           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Inside the Folder.
        /// </summary>
        public void NavigateInsideFolderHed( )
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

        /// <summary>
        /// Manage The Gradebook Folder Navigation.
        /// </summary>
        /// <param name="milAuthoredCourseFolderLelevlTypeEnum">This is MIL Folder Navigation Type Enum.</param>
        public void ManageTheGradebookFolderNavigation(MilAuthoredCourseFolderLelevlTypeEnum 
            milAuthoredCourseFolderLelevlTypeEnum)
        {
            //Manage The Gradebook Folder Navigation
            Logger.LogMethodEntry("GBLeftNavigationUXPage","ManageTheGradebookFolderNavigation",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Folder level type           
            try
            {
                //Report Type
                switch (milAuthoredCourseFolderLelevlTypeEnum)
                {
                    //Generate Activity Result by Student Report
                    case MilAuthoredCourseFolderLelevlTypeEnum.Word:
                        break;
                    case MilAuthoredCourseFolderLelevlTypeEnum.Access:
                        break;
                    case MilAuthoredCourseFolderLelevlTypeEnum.Excel:
                        break;
                    case MilAuthoredCourseFolderLelevlTypeEnum.PowerPoint:
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("GBLeftNavigationUXPage","ManageTheGradebookFolderNavigation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Manage Instructor Gradebook Folder Navigation.
        /// </summary>
        /// <param name="mILAuthoredCourseFolderLelevlTypeEnum">
        /// This is MIL Folder Navigation Type Enum.</param>
        public void ManageInstructorGradebookFolderNavigation(
            MilAuthoredCourseFolderLelevlTypeEnum mILAuthoredCourseFolderLelevlTypeEnum)
        {
            //Manage Instructor Gradebook Folder Navigation
            Logger.LogMethodEntry("GBLeftNavigationUXPage",
                "ManageInstructorGradebookFolderNavigation",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (mILAuthoredCourseFolderLelevlTypeEnum)
                {
                    //Select Folder level of type Word
                    case MilAuthoredCourseFolderLelevlTypeEnum.Word:
                        this.WordActivityFolderNavigationInInstructorGradebook();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("GBLeftNavigationUXPage",
                "ManageInstructorGradebookFolderNavigation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Word Activity Folder Navigation In Instructor Gradebook.
        /// </summary>
        private void WordActivityFolderNavigationInInstructorGradebook()
        {
            //Word Activity Folder Navigation In Instructor Gradebook
            Logger.LogMethodEntry("GBLeftNavigationUXPage",
                "WordActivityFolderNavigationInInstructorGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.NavigateToActivityFolderInInstructorGradebook(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Activity_Root_Folder_Name);
            this.NavigateToActivityFolderInInstructorGradebook(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Word_FolderLevel1_Name);
            this.NavigateToActivityFolderInInstructorGradebook(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Word_FolderLevel2_Name);
            this.NavigateToActivityFolderInInstructorGradebook(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Word_FolderLevel3_Name);
            this.NavigateToActivityFolderInInstructorGradebook(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Word_FolderLevel4_Name);
            Logger.LogMethodExit("GBLeftNavigationUXPage",
                "WordActivityFolderNavigationInInstructorGradebook",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Activity Folder In Instructor Gradebook.
        /// </summary>
        private void NavigateToActivityFolderInInstructorGradebook(string folderName)
        {
            //Navigate To Activity Folder In Instructor Gradebook
            Logger.LogMethodEntry("GBLeftNavigationUXPage",
                "NavigateToActivityFolderInInstructorGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            int getFolderCount = Convert.ToInt32(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_Folder_Count_Initial_Value);
            string getFolderText = string.Empty;
            //Get Folder Count
            getFolderCount = base.GetElementCountByXPath(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_Folder_Count_Xpath_Locator);
            for (int i = Convert.ToInt32(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_Loop_Initializer); i <= getFolderCount; i++)
            {
                //Get Folder Text
                getFolderText = base.GetElementTextByXPath(string.Format(
                    GBLeftNavigationUXPageResource.GBLeftNavigationUXPage_Folder_Text_Xpath_Locator, i));
                if (getFolderText == folderName)
                {
                    //Click on Folder
                    IWebElement getFolderNameProperty = base.GetWebElementPropertiesByXPath(
                        string.Format(GBLeftNavigationUXPageResource.
                        GBLeftNavigationUXPage_Folder_Name_Xpath_Locator, i));
                    base.ClickByJavaScriptExecutor(getFolderNameProperty);
                    Thread.Sleep(Convert.ToInt32(GBLeftNavigationUXPageResource.
                        GBLeftNavigationUXPage_Wait_Time));
                    break;
                }
            }
            Logger.LogMethodExit("GBLeftNavigationUXPage",
                "NavigateToActivityFolderInInstructorGradebook",
              base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
