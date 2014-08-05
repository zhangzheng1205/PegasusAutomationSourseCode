using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
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
        /// This is the MIL Folder navigation Types.
        /// </summary>
        public enum MilCourseFolderLelevlTypeEnum
        {
            Excel = 1,
            PowerPoint = 2,
            Word=3,
            Access=4
        }

        /// <summary>
        /// This is the Pegasus Tab Types.
        /// </summary>
        public enum TabNameTypeEnum
        {
            Gradebook = 1,
            CourseMaterials = 2
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
                this.SelectStudentGradebookLeftNavigationFrame();
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
        /// Navigate In Activity Folder.
        /// </summary>
        /// <param name="folderName">This is Folder Name.</param>
        private void NavigateInsideActivityFolder(string folderName)
        {
            //Navigate Inside Activity Folder
            Logger.LogMethodEntry("GBLeftNavigationUXPage", "NavigateInsideActivityFolder",
                 base.IsTakeScreenShotDuringEntryExit);            
            // Click on Additional practice
            base.WaitForElement(By.PartialLinkText(folderName));
            base.FocusOnElementByPartialLinkText(folderName);
            IWebElement getFolderName =  base.WebDriver.FindElement
               (By.PartialLinkText(folderName));
            base.ClickByJavaScriptExecutor(getFolderName);
            Thread.Sleep(10000);           
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
        /// Manage Instructor Gradebook Folder Navigation.
        /// </summary>
        /// <param name="mILAuthoredCourseFolderLelevlTypeEnum">
        /// This is MIL Folder Navigation Type Enum.</param>
        public void ManageInstructorGradebookFolderNavigation(
            MilCourseFolderLelevlTypeEnum mILAuthoredCourseFolderLelevlTypeEnum)
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
                    case MilCourseFolderLelevlTypeEnum.Word:
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
       
        /// <summary>
        /// Power Point Activity Folder Navigation. 
        /// </summary>
        private void PowerPointActivityFolderNavigation()
        {
            //Power Point Activity Folder Navigation In Gradebook
            Logger.LogMethodEntry("GBLeftNavigationUXPage",
                "PowerPointActivityFolderNavigation",
               base.IsTakeScreenShotDuringEntryExit);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Activity_Root_Folder_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_PowerPoint_FolderLevel1_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_PowerPoint_FolderLevel2_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_PowerPoint_FolderLevel3_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_PowerPoint_FolderLevel4_Name);
            Logger.LogMethodExit("GBLeftNavigationUXPage",
                "PowerPointActivityFolderNavigation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Excel Activity Folder Navigation. 
        /// </summary>
        private void ExcelActivityFolderNavigation()
        {
            //Excel Activity Folder Navigation In Gradebook.
            Logger.LogMethodEntry("GBLeftNavigationUXPage",
                "ExcelActivityFolderNavigation",
               base.IsTakeScreenShotDuringEntryExit);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Activity_Root_Folder_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Excel_FolderLevel1_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Excel_FolderLevel2_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Excel_FolderLevel3_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Excel_FolderLevel4_Name);
            Logger.LogMethodExit("GBLeftNavigationUXPage",
                "ExcelActivityFolderNavigation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Access Activity Folder Navigation.
        /// </summary>
        private void AccessActivityFolderNavigation()
        {
            //Access Activity Folder Navigation
            Logger.LogMethodEntry("GBLeftNavigationUXPage",
                "AccessActivityFolderNavigation",
               base.IsTakeScreenShotDuringEntryExit);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Activity_Root_Folder_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Access_FolderLevel1_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Access_FolderLevel2_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Access_FolderLevel3_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Access_FolderLevel4_Name);
            Logger.LogMethodExit("GBLeftNavigationUXPage",
                "AccessActivityFolderNavigation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Word Activity Folder Navigation.
        /// </summary>
        private void WordActivityFolderNavigation()
        {
            //Word Activity Folder Navigation
            Logger.LogMethodEntry("GBLeftNavigationUXPage",
                "WordActivityFolderNavigation",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Activity_Root_Folder_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Word_FolderLevel1_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Word_FolderLevel2_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Word_FolderLevel3_Name);
            this.NavigateInsideActivityFolder(GBLeftNavigationUXPageResource.
                GBLeftNavigationUXPage_SIM5_Word_FolderLevel4_Name);
            Logger.LogMethodExit("GBLeftNavigationUXPage",
                "WordActivityFolderNavigation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Manage The Folder Navigation For MIL Course.
        /// </summary>
        /// <param name="navigateMILFolderLevelType">This is Folder Name type.</param>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="tabName">This is Tab Name.</param>
        public void ManageTheFolderNavigationForMILCourse(MilCourseFolderLelevlTypeEnum 
            navigateMILFolderLevelType, TabNameTypeEnum tabName, User.UserTypeEnum userTypeEnum)
        {
            //Manage The Folder Navigation For MIL Course
            Logger.LogMethodEntry("GBLeftNavigationUXPage",
                "ManageTheFolderNavigationForMILCourse",
               base.IsTakeScreenShotDuringEntryExit);
            //Select the Window
            this.SelectWindowForFolderNavigation(userTypeEnum, tabName);
            //Select Folder navigation type
            switch (navigateMILFolderLevelType)
            {
                //Folder navigation
                case MilCourseFolderLelevlTypeEnum.Word:
                    this.WordActivityFolderNavigation();
                    break;
                case MilCourseFolderLelevlTypeEnum.Access:
                    this.AccessActivityFolderNavigation();
                    break;
                case MilCourseFolderLelevlTypeEnum.Excel:
                    this.ExcelActivityFolderNavigation();
                    break;
                case MilCourseFolderLelevlTypeEnum.PowerPoint:
                    this.PowerPointActivityFolderNavigation();
                    break;
            }
            Logger.LogMethodExit("GBLeftNavigationUXPage",
                "ManageTheFolderNavigationForMILCourse",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window For Folder Navigation.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="tabName">This is Tab Name.</param>
        private void SelectWindowForFolderNavigation(User.UserTypeEnum userTypeEnum,
            TabNameTypeEnum tabName)
        {
            //Select Window For Folder Navigation
            Logger.LogMethodEntry("GBLeftNavigationUXPage",
                "SelectWindowForFolderNavigation",
               base.IsTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                // Get User Type
                case User.UserTypeEnum.CsSmsStudent:
                    switch (tabName)
                    {
                        //Generate Activity Result by Student Report
                        case TabNameTypeEnum.CourseMaterials:
                            new CoursePreviewMainUXPage().SelectCourseMaterialsWindow();
                            break;
                        case TabNameTypeEnum.Gradebook:
                            this.SelectStudentGradebookLeftNavigationFrame();
                            break;
                    }
                    break;
            }
            Logger.LogMethodExit("GBLeftNavigationUXPage",
                "SelectWindowForFolderNavigation",
              base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
