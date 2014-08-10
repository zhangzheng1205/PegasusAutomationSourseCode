using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.CommonPageObjects
{
    /// <summary>
    /// This class handles the common UI actions 
    /// which is not specific to any page.
    /// </summary>
    public class CommonPage : BasePage
    {
        /// <summary>
        /// This is static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CommonPage));

        /// <summary>
        /// Manage The Activity Folder Level Navigation.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// <param name="userTypeEnum">This is user Type Enum.</param>
        /// <param name="activityUnderTabName">This is Tab Name.</param>
        public void ManageTheActivityFolderLevelNavigation(string activityName,
            string activityUnderTabName, User.UserTypeEnum userTypeEnum)
        {
            //Manage The Activity Folder Level Navigation
            Logger.LogMethodEntry("CommonPage",
                "ManageTheActivityFolderLevelNavigation",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // folder navigation based on user type
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.CsSmsStudent:
                        // folder navigation based on Tab name
                        switch (activityUnderTabName)
                        {
                            case "Gradebook":
                                // select window
                                this.SelectWindowForFolderNavigation(activityUnderTabName);
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        NavigateToWordChapter1SimulationActivitiesFolder();
                                        break;
                                    case "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        NavigateToAccessChapter1SimulationActivitiesFolder();
                                        break;
                                    case "Excel Chapter 1 Skill-Based Training":
                                        NavigateToExcelChapter1SimulationActivitiesFolder();
                                        break;
                                    case "PowerPoint Chapter 1 Skill-Based Training":
                                        NavigateToPowerPointChapter1SimulationActivitiesFolder();
                                        break;
                                }
                                break;
                        }
                        break;
                    case User.UserTypeEnum.CsSmsInstructor:
                        // folder navigation based on Tab name
                        switch (activityUnderTabName)
                        {
                            case "Manage Course Materials":
                                // select window
                                this.SelectWindowForFolderNavigation(activityUnderTabName);
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        // add code
                                        break;
                                    case "Excel Chapter 1 Skill-Based Training":
                                    case "Excel Chapter 1 Skill-Based Exam (Scenario 1)":
                                    case "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test":
                                    case "Excel Chapter 1 Project 1A Skill-Based Training":
                                    case "Excel Chapter 1 Project 1A Skill-Based Exam (Scenario 1) ":
                                        // add code
                                        break;
                                    case "Access Chapter 1 Skill-Based Training ":
                                        // add code
                                        break;
                                    case "PowerPoint Chapter 1 Skill-Based Training":
                                    case "PowerPoint Chapter 1 Skill-Based Exam (Scenario 1)":
                                        // add code
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage",
                "ManageTheActivityFolderLevelNavigation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Power Point Chapter1 Simulation Activities Folder.
        /// </summary>
        private void NavigateToPowerPointChapter1SimulationActivitiesFolder()
        {
            // navigate inside power point chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToPowerPointChapter1SimulationActivitiesFolder",
             base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.ComonPage_PowerPoint2013_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_PowerPointChapter1GettingStartedWithMicrosoftPowerPoint_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_PowerPointChapter1Activities_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_PowerPointChapter1SimulationActivities_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            Logger.LogMethodExit("CommonPage", "NavigateToPowerPointChapter1SimulationActivitiesFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Excel Chapter1 Simulation Activities Folder.
        /// </summary>
        private void NavigateToExcelChapter1SimulationActivitiesFolder()
        {
            // navigate inside excel chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToExcelChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_Excel2013_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_ExcelChapter1CreatingAWorksheetAndChartingData_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_ExcelChapter1Activities_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_ExcelChapter1SimulationActivities_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            Logger.LogMethodExit("CommonPage", "NavigateToExcelChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Access Chapter1 Simulation Activities Folder.
        /// </summary>
        private void NavigateToAccessChapter1SimulationActivitiesFolder()
        {
            // navigate inside access chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToAccessChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_Access2013_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_AccessChapter1GettingStartedWithMicrosoftAccess2013_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_AccessChapter1Activities_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_AccessChapter1SimulationActivities_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            Logger.LogMethodExit("CommonPage", "NavigateToAccessChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Word Chapter1 Simulation Activities Folder.
        /// </summary>
        private void NavigateToWordChapter1SimulationActivitiesFolder()
        {
            // navigate inside word chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToWordChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_Word2013_FolderName, CommonPageResource.
                    CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1CreatingDocumentsWithMicrosoftWord2013_FolderName,
                CommonPageResource.CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1Activities_FolderName, CommonPageResource.
                    CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1SimulationActivities_FolderName, CommonPageResource.
                    CommonPage_BackToPreviousContentFolder_LinkedIcon_Id_Locator);
            Logger.LogMethodExit("CommonPage", "NavigateToWordChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Activity Folder Navigation Under Tab.
        /// </summary>
        /// <param name="activityFolderName">This is activity folder name.</param>
        /// <param name="webElementToWait">This is web element name to wait 
        /// wile navigtion inside folder.</param>
        private void NavigateInsideActivityFolderUnderTab(string activityFolderName, string webElementToWait)
        {
            // activity folder navigation
            Logger.LogMethodEntry("CommonPage", "NavigateInsideActivityFolderUnderTab",
                base.IsTakeScreenShotDuringEntryExit);
            base.ClickButtonByPartialLinkText(activityFolderName);
            Thread.Sleep(Convert.ToInt32(CommonPageResource.CommonPage_FolderNavigation_Sleep_Time));
            // wait for element
            base.WaitForElement(By.Id(webElementToWait));
            Logger.LogMethodExit("CommonPage", "NavigateInsideActivityFolderUnderTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window For Folder Navigation.
        /// </summary>
        /// <param name="activityUnderTabName">This is Tab ame same name as window Title.</param>
        private void SelectWindowForFolderNavigation(string activityUnderTabName)
        {
            // select window
            Logger.LogMethodEntry("CommonPage", "SelectWindowForFolderNavigation",
                base.IsTakeScreenShotDuringEntryExit);
            // select window
            base.SelectWindow(activityUnderTabName);
            // switch To Frame
            base.SwitchToIFrame(CommonPageResource
                .CommonPage_LeftNavigationFrame_Id_Locator);
            Logger.LogMethodExit("CommonPage", "SelectWindowForFolderNavigation",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}



