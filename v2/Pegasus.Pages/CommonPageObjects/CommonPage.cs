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
        /// <remarks>This folder navigation is only valid for MIL authored course named as
        ///  'MyITLab for Office 2013: GO! Series + Technology in Action [01.01.14] '. The created 
        /// section course, instructor course and Templates will only valid for this method.</remarks>
        public void ManageTheActivityFolderLevelNavigation(string activityName,
            string activityUnderTabName, User.UserTypeEnum userTypeEnum)
        {
            // manage activity folder level navigation
            Logger.LogMethodEntry("CommonPage", "ManageTheActivityFolderLevelNavigation",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window With Frame For Folder Navigation
                this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
                // folder navigation based on user type
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.CsSmsStudent:
                        // folder navigation based on Tab name
                        switch (activityUnderTabName)
                        {
                            case "Gradebook":
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.NavigateToWordChapter1SimulationActivitiesFolder
                                            (CommonPageResource.CommonPage_BackToPreviousContentFolder_BackIcon_Id_Locator);
                                        break;
                                    case "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.NavigateToAccessChapter1SimulationActivitiesFolder
                                            (CommonPageResource.CommonPage_BackToPreviousContentFolder_BackIcon_Id_Locator);
                                        break;
                                    case "Excel Chapter 1 Skill-Based Training":
                                        this.NavigateToExcelChapter1SimulationActivitiesFolder
                                            (CommonPageResource.CommonPage_BackToPreviousContentFolder_BackIcon_Id_Locator);
                                        break;
                                    case "PowerPoint Chapter 1 Skill-Based Training":
                                        this.NavigateToPowerPointChapter1SimulationActivitiesFolder
                                            (CommonPageResource.CommonPage_BackToPreviousContentFolder_BackIcon_Id_Locator);
                                        break;
                                }
                                break;
                            case "Course Materials":
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.NavigateToWordChapter1SimulationActivitiesFolder
                                            (CommonPageResource.CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator);
                                        break;
                                    case "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.NavigateToAccessChapter1SimulationActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator);
                                        break;
                                    case "Excel Chapter 1 Skill-Based Training":
                                        this.NavigateToExcelChapter1SimulationActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator);
                                        break;
                                    case "PowerPoint Chapter 1 Skill-Based Training":
                                        this.NavigateToPowerPointChapter1SimulationActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator);
                                        break;
                                    // Grader IT for Excel Activity
                                    case "Excel Chapter 1 Grader Project [Homework 3]":
                                        this.NavigateToExcelChapter1GraderActivitiesFolder
                                            (CommonPageResource.CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator);
                                        break;
                                    // Grader IT for PowerPoint Activity
                                    case "PowerPoint Chapter 1 Grader Project [Homework 3]":
                                        this.NavigateToPowerPointChapter1GraderActivitiesFolder
                                            (CommonPageResource.CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator);
                                        break;
                                    // Grader IT for Word Activty
                                    case "Word Chapter 1 Grader Project [Assessment 3]":
                                        this.NavigateToWordChapter1GraderActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator);
                                        break;
                                    // Grader IT for Access Activty
                                    case "Access Chapter 1 Grader Project [Assessment 3]":
                                        this.NavigateAccessChapter1GraderActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator);
                                        break;
                                }
                                break;
                        }
                        break;
                    case User.UserTypeEnum.CsSmsInstructor:
                        // folder navigation based on Tab name
                        switch (activityUnderTabName)
                        {
                            case "Course Materials":
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.NavigateToWordChapter1SimulationActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator);
                                        break;
                                    case "Excel Chapter 1 Skill-Based Training":
                                    case "Excel Chapter 1 Skill-Based Exam (Scenario 1)":
                                    case "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test":
                                    case "Excel Chapter 1 Project 1A Skill-Based Training":
                                    case "Excel Chapter 1 Project 1A Skill-Based Exam (Scenario 1) ":
                                        this.NavigateToExcelChapter1SimulationActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator);
                                        break;
                                    case "Access Chapter 1 Skill-Based Training":
                                        this.NavigateToAccessChapter1SimulationActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator);
                                        break;
                                    case "Review the Chapter 04 Learning Objectives":
                                        this.NavigateToAccessChapter4BrainAndNervousSystemFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator);
                                        break;
                                    case "PowerPoint Chapter 1 Skill-Based Training":
                                    case "PowerPoint Chapter 1 Skill-Based Exam (Scenario 1)":
                                        this.NavigateToPowerPointChapter1SimulationActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator);
                                        break;
                                }
                                break;
                            case "Gradebook":
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.SelectWordActivityFolderNavigationInInstructorGradebook(CommonPageResource.
                                            CommonPage_Gradebook_BackArrow_Id_Locator);
                                        break;
                                    case "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.SelectAccessActivityFolderNavigationInInstructorGradebook(CommonPageResource.
                                            CommonPage_Gradebook_BackArrow_Id_Locator);
                                        break;
                                    case "PowerPoint Chapter 1 Skill-Based Training":
                                    case "PowerPoint Chapter 1 Skill-Based Exam (Scenario 1)":
                                        this.SelectPowerPointActivityFolderNavigationInInstructorGradebook(CommonPageResource.
                                            CommonPage_Gradebook_BackArrow_Id_Locator);
                                        break;
                                    case "Excel Chapter 1 Skill-Based Training":
                                    case "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test":
                                        this.SelectExcelActivityFolderNavigationInInstructorGradebook(CommonPageResource.
                                            CommonPage_Gradebook_BackArrow_Id_Locator);
                                        break;
                                }
                                break;
                            case "Calendar":
                                switch (activityName)
                                {
                                    //Folder navigation for Word based on activity name
                                    case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.SelectWordActivityFolderNavigationInInstructorCalendar(CommonPageResource.
                                            CommonPage_Instructor_Calendar_Content_Id_Locator);
                                        break;
                                    //Folder navigation for Access
                                    case "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.SelectAccessActivityFolderNavigationInInstructorCalendar(CommonPageResource.
                                            CommonPage_Instructor_Calendar_Content_Id_Locator);
                                        break;
                                    //Folder navigation for powerpoint
                                    case "PowerPoint Chapter 1 Skill-Based Training":
                                    case "PowerPoint Chapter 1 Skill-Based Exam (Scenario 1)":
                                        this.SelectPowerPointActivityFolderNavigationInInstructorCalendar(CommonPageResource.
                                            CommonPage_Instructor_Calendar_Content_Id_Locator);
                                        break;
                                    //Folder navigation for Excel
                                    case "Excel Chapter 1 Skill-Based Training":
                                    case "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test":
                                        this.SelectExcelActivityFolderNavigationInInstructorCalendar(CommonPageResource.
                                            CommonPage_Instructor_Calendar_Content_Id_Locator);
                                        break;
                                }
                                break;
                            case "Today's View":
                                {
                                    switch (activityName)
                                    {
                                        case "Word Chapter 1 Skill-Based Training":
                                            this.NavigateToWordChapter1SimulationActivitiesFolder
                                                (CommonPageResource.CommonPage_CoursePerformance_Table_Id_Locator);
                                            break;
                                    }

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
            Logger.LogMethodExit("CommonPage", "ManageTheActivityFolderLevelNavigation",
              base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Navigate To Chapter 04: The Brain and Nervous System Folder.
        /// </summary>
        private void NavigateToAccessChapter4BrainAndNervousSystemFolder(string webElementToWait)
        {
            // navigate inside Chapter 4: Consciousness: Sleep, Dreams, Hypnosis, and Drugs Folder
            Logger.LogMethodEntry("CommonPage", "NavigateToExcelChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level 
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_Chapter4BrainAndNervous_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage", "NavigateToExcelChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        } 
        /// <summary>
        /// Navigate To Excel Chapter 1 Grader Activities.
        /// </summary>
        private void NavigateToExcelChapter1GraderActivitiesFolder(string webElementToWait)
        {
            // navigate inside power point chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToPowerPointExcelChapter1GraderActivitiesFolder",
             base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_Excel2013_FolderName,
                webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_ExcelChapter1CreatingAWorksheetAndChartingData_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_ExcelChapter1Activities_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                ComonPage_ExcelChapter1GraderActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage", "NavigateToPowerPointExcelChapter1GraderActivitiesFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Power Point Chapter1 Grader Activities Folder.
        /// </summary>
        private void NavigateToPowerPointChapter1GraderActivitiesFolder(string webElementToWait)
        {
            // navigate inside power point chapter1 Grader activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToPowerPointChapter1GraderActivitiesFolder",
             base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.ComonPage_PowerPoint2013_FolderName,
                webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_PowerPointChapter1GettingStartedWithMicrosoftPowerPoint_FolderName,
                webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_PowerPointChapter1Activities_FolderName,
                webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_PowerPointChapter1GraderActivities_FolderName,
                webElementToWait);
            Logger.LogMethodExit("CommonPage", "NavigateToPowerPointChapter1GraderActivitiesFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Word Chapter1 Grader Activities Folder.
        /// </summary>
        private void NavigateToWordChapter1GraderActivitiesFolder(string webElementToWait)
        {
            // navigate inside word chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToWordChapter1GraderActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_Word2013_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1CreatingDocumentsWithMicrosoftWord2013_FolderName,
                webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1Activities_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1GraderActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage", "NavigateToWordChapter1GraderActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Access Chapter1 Grader Activities Folder.
        /// </summary>
        private void NavigateAccessChapter1GraderActivitiesFolder(string webElementToWait)
        {
            // navigate inside access chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToAccessChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_Access2013_FolderName,
                webElementToWait);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_AccessChapter1GettingStartedWithMicrosoftAccess2013_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_AccessChapter1Activities_FolderName,
                webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_AccessChapter1GraderActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage", "NavigateToAccessChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Excel Activity Folder Navigation In Instructor Calendar.
        /// </summary>
        /// <param name="webElementToWait">This is wait element.</param>
        private void SelectExcelActivityFolderNavigationInInstructorCalendar
            (string webElementToWait)
        {
            //Word Excel Folder Navigation In Instructor Calendar
            Logger.LogMethodEntry("CommonPage",
                "SelectExcelActivityFolderNavigationInInstructorCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_Excel2013_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_ExcelChapter1CreatingAWorksheetAndChartingData_FolderName,
                webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_ExcelChapter1Activities_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_ExcelChapter1SimulationActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "SelectExcelActivityFolderNavigationInInstructorCalendar",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Power Point Activity Folder Navigation In Instructor Calendar.
        /// </summary>
        /// <param name="webElementToWait">This is wait element.</param>
        private void SelectPowerPointActivityFolderNavigationInInstructorCalendar
            (string webElementToWait)
        {
            //Word Power Point Folder Navigation In Instructor Calendar
            Logger.LogMethodEntry("CommonPage",
                "SelectPowerPointActivityFolderNavigationInInstructorCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                ComonPage_PowerPoint2013_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_PowerPointChapter1GettingStartedWithMicrosoftPowerPoint_FolderName,
                webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_PowerPointChapter1Activities_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_PowerPointChapter1SimulationActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "SelectPowerPointActivityFolderNavigationInInstructorCalendar",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Access Activity Folder Navigation In Instructor Calendar.
        /// </summary>
        /// <param name="webElementToWait">This is wait element.</param>
        private void SelectAccessActivityFolderNavigationInInstructorCalendar
            (string webElementToWait)
        {
            //Word Activity Folder Navigation In Instructor Calendar
            Logger.LogMethodEntry("CommonPage",
                "SelectAccessActivityFolderNavigationInInstructorCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_Access2013_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_AccessChapter1GettingStartedWithMicrosoftAccess2013_FolderName,
                webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_AccessChapter1Activities_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_AccessChapter1SimulationActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "SelectAccessActivityFolderNavigationInInstructorCalendar",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Word Activity Folder Navigation In Instructor Calendar.
        /// </summary>
        /// <param name="webElementToWait">This is wait element.</param>
        private void SelectWordActivityFolderNavigationInInstructorCalendar(
                      string webElementToWait)
        {
            //Word Activity Folder Navigation In Instructor Calendar
            Logger.LogMethodEntry("CommonPage",
                "SelectWordActivityFolderNavigationInInstructorCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_Word2013_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_WordChapter1CreatingDocumentsWithMicrosoftWord2013_FolderName,
                webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_WordChapter1Activities_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_WordChapter1SimulationActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "SelectWordActivityFolderNavigationInInstructorCalendar",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Activity Folder In Instructor Calendar.
        /// </summary>
        /// <param name="folderName">This is folder name.</param>
        /// <param name="webElementToWait">This is wait element.</param>
        private void NavigateToActivityFolderInInstructorCalendar(string folderName,
            string webElementToWait)
        {
            //Navigate To Activity Folder In Instructor Calendar
            Logger.LogMethodEntry("CommonPage",
                "NavigateToActivityFolderInInstructorCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(String.Format(CommonPageResource.
                CommonPage_Instructor_CalendarNavigationFolder_Xpath_Locator, folderName)));
            IWebElement getFolderProperty = base.GetWebElementPropertiesByXPath
                (String.Format(CommonPageResource.
                CommonPage_Instructor_CalendarNavigationFolder_Xpath_Locator, folderName));
            //Click on the folder
            base.ClickByJavaScriptExecutor(getFolderProperty);
            Thread.Sleep(Convert.ToInt32(CommonPageResource.
                CommonPage_FolderNavigation_Sleep_Time));
            base.WaitForElement(By.Id(webElementToWait));
            Logger.LogMethodExit("CommonPage",
                "NavigateToActivityFolderInInstructorCalendar",
              base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        ///Select Window With Frame For Folder Navigation .
        /// </summary>
        /// <param name="userTypeEnum">This is User type enum.</param>
        /// <param name="activityUnderTabName">This is tabName.</param>
        private void SelectWindowWithFrameForFolderNavigation(User.UserTypeEnum userTypeEnum,
            string activityUnderTabName)
        {
            //Select Window With Frame For Folder Navigation
            Logger.LogMethodEntry("CommonPage",
                "SelectWindowWithFrameForFolderNavigation",
               base.IsTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                // Get User Type
                case User.UserTypeEnum.CsSmsStudent:
                    switch (activityUnderTabName)
                    {
                        //Generate Activity Result by Student Report
                        case "Course Materials":
                            this.SelectWindowNameForFoldernavigation(activityUnderTabName,
                                CommonPageResource.CommonPage_CoursePreviewFrame_Id_Locator);
                            break;
                        case "Gradebook":
                            this.SelectWindowNameForFoldernavigation(activityUnderTabName,
                                CommonPageResource.CommonPage_LeftNavigationFrame_Id_Locator);
                            break;
                    }
                    break;
                case User.UserTypeEnum.CsSmsInstructor:
                    switch (activityUnderTabName)
                    {
                        //Generate Activity Result by Student Report
                        case "Course Materials":
                            this.SelectWindowNameForFoldernavigation(activityUnderTabName,
                                CommonPageResource.CommonPage_CoursePreviewFrame_Id_Locator);
                            break;
                        case "Gradebook":
                            this.SelectWindowNameForFoldernavigation(activityUnderTabName,
                                CommonPageResource.CommonPage_InstructorLeftNavigationFrame_Id_Locator);
                            break;
                        case "Calendar":
                            this.SelectWindowNameForFoldernavigation(activityUnderTabName);
                            break;
                    }
                    break;
            }
            Logger.LogMethodExit("CommonPage",
                "SelectWindowWithFrameForFolderNavigation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window Name For Folder navigation.
        /// </summary>
        /// <param name="windowName">This is Window Name.</param>
        /// <param name="frameName">This is Frame Name</param>
        private void SelectWindowNameForFoldernavigation(string windowName,
            string frameName = "Default Value")
        {
            //Select Window Name For Folder navigation
            Logger.LogMethodEntry("CommonPage", "SelectWindowNameForFoldernavigation",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(windowName);
            // select window
            base.SelectWindow(windowName);
            if (frameName != "Default Value")
            {
                // switch To Frame
                base.SwitchToIFrame(frameName);
            }
            Logger.LogMethodExit("CommonPage", "SelectWindowNameForFoldernavigation",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Power Point Chapter1 Simulation Activities Folder.
        /// </summary>
        private void NavigateToPowerPointChapter1SimulationActivitiesFolder(string webElementToWait)
        {
            // navigate inside power point chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToPowerPointChapter1SimulationActivitiesFolder",
             base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.ComonPage_PowerPoint2013_FolderName,
                webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_PowerPointChapter1GettingStartedWithMicrosoftPowerPoint_FolderName,
                webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_PowerPointChapter1Activities_FolderName,
                webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_PowerPointChapter1SimulationActivities_FolderName,
                webElementToWait);
            Logger.LogMethodExit("CommonPage", "NavigateToPowerPointChapter1SimulationActivitiesFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Excel Chapter1 Simulation Activities Folder.
        /// </summary>
        private void NavigateToExcelChapter1SimulationActivitiesFolder(string webElementToWait)
        {
            // navigate inside excel chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToExcelChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_Excel2013_FolderName,
                webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_ExcelChapter1CreatingAWorksheetAndChartingData_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_ExcelChapter1Activities_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_ExcelChapter1SimulationActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage", "NavigateToExcelChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Access Chapter1 Simulation Activities Folder.
        /// </summary>
        private void NavigateToAccessChapter1SimulationActivitiesFolder(string webElementToWait)
        {
            // navigate inside access chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToAccessChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_Access2013_FolderName,
                webElementToWait);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_AccessChapter1GettingStartedWithMicrosoftAccess2013_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_AccessChapter1Activities_FolderName,
                webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_AccessChapter1SimulationActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage", "NavigateToAccessChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Word Chapter1 Simulation Activities Folder.
        /// </summary>
        private void NavigateToWordChapter1SimulationActivitiesFolder(string webElementToWait)
        {
            // navigate inside word chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToWordChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_Word2013_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1CreatingDocumentsWithMicrosoftWord2013_FolderName,
                webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1Activities_FolderName, webElementToWait);
            // click folder level
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1SimulationActivities_FolderName, webElementToWait);
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
            //Wait for the element
            base.WaitForElement(By.PartialLinkText(activityFolderName));
            IWebElement getFolderLink = base.GetWebElementPropertiesByPartialLinkText
                (activityFolderName);
            //Click the link
            base.ClickByJavaScriptExecutor(getFolderLink);
            Thread.Sleep(Convert.ToInt32(CommonPageResource.CommonPage_FolderNavigation_Sleep_Time));
            //Wait for element
            base.WaitForElement(By.Id(webElementToWait));
            Logger.LogMethodExit("CommonPage", "NavigateInsideActivityFolderUnderTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Word Activity Folder Navigation In Instructor Gradebook.
        /// </summary>
        /// <param name="webElementToWait">This is wait element.</param>
        private void SelectWordActivityFolderNavigationInInstructorGradebook(
                      string webElementToWait)
        {
            //Word Activity Folder Navigation In Instructor Gradebook
            Logger.LogMethodEntry("CommonPage",
                "SelectWordActivityFolderNavigationInInstructorGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_Word2013_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_WordChapter1CreatingDocumentsWithMicrosoftWord2013_FolderName,
                webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_WordChapter1Activities_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_WordChapter1SimulationActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "SelectWordActivityFolderNavigationInInstructorGradebook",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Access Activity Folder Navigation In Instructor Gradebook.
        /// </summary>
        /// <param name="webElementToWait">This is wait element.</param>
        private void SelectAccessActivityFolderNavigationInInstructorGradebook
            (string webElementToWait)
        {
            //Word Activity Folder Navigation In Instructor Gradebook
            Logger.LogMethodEntry("CommonPage",
                "SelectAccessActivityFolderNavigationInInstructorGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_Access2013_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_AccessChapter1GettingStartedWithMicrosoftAccess2013_FolderName,
                webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_AccessChapter1Activities_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_AccessChapter1SimulationActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "SelectAccessActivityFolderNavigationInInstructorGradebook",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Excel Activity Folder Navigation In Instructor Gradebook.
        /// </summary>
        /// <param name="webElementToWait">This is wait element.</param>
        private void SelectExcelActivityFolderNavigationInInstructorGradebook
            (string webElementToWait)
        {
            //Word Excel Folder Navigation In Instructor Gradebook
            Logger.LogMethodEntry("CommonPage",
                "SelectExcelActivityFolderNavigationInInstructorGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_Excel2013_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_ExcelChapter1CreatingAWorksheetAndChartingData_FolderName,
                webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_ExcelChapter1Activities_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_ExcelChapter1SimulationActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "SelectExcelActivityFolderNavigationInInstructorGradebook",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Select Power Point Activity Folder Navigation In Instructor Gradebook.
        /// </summary>
        /// <param name="webElementToWait">This is wait element.</param>
        private void SelectPowerPointActivityFolderNavigationInInstructorGradebook
            (string webElementToWait)
        {
            //Word Power Point Folder Navigation In Instructor Gradebook
            Logger.LogMethodEntry("CommonPage",
                "SelectPowerPointActivityFolderNavigationInInstructorGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                ComonPage_PowerPoint2013_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_PowerPointChapter1GettingStartedWithMicrosoftPowerPoint_FolderName,
                webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_PowerPointChapter1Activities_FolderName, webElementToWait);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_PowerPointChapter1SimulationActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "SelectPowerPointActivityFolderNavigationInInstructorGradebook",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Activity Folder In Instructor Gradebook.
        /// </summary>
        /// <param name="folderName">This is folder name.</param>
        /// <param name="webElementToWait">This is wait element.</param>
        private void NavigateToActivityFolderInInstructorGradebook(string folderName,
            string webElementToWait)
        {
            //Navigate To Activity Folder In Instructor Gradebook
            Logger.LogMethodEntry("CommonPage",
                "NavigateToActivityFolderInInstructorGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            int getFolderCount = Convert.ToInt32(CommonPageResource.
                ComonPage_Folder_Count_Initial_Value);
            string getFolderText = string.Empty;
            //Get Folder Count
            getFolderCount = base.GetElementCountByXPath(CommonPageResource.
                ComonPage_Folder_Count_Xpath_Locator);
            for (int i = Convert.ToInt32(CommonPageResource.
                ComonPage_Loop_Initializer); i <= getFolderCount; i++)
            {
                //Get Folder Text
                getFolderText = base.GetElementTextByXPath(string.Format(
                    CommonPageResource.ComonPage_Folder_Text_Xpath_Locator, i));
                if (getFolderText == folderName)
                {
                    //Click on Folder
                    IWebElement getFolderNameProperty = base.GetWebElementPropertiesByXPath(
                        string.Format(CommonPageResource.
                        ComonPage_Folder_Name_Xpath_Locator, i));
                    base.ClickByJavaScriptExecutor(getFolderNameProperty);
                    Thread.Sleep(Convert.ToInt32(CommonPageResource.
                        ComonPage_Wait_Time));
                    base.WaitForElement(By.Id(webElementToWait));
                    break;
                }
            }
            Logger.LogMethodExit("CommonPage",
                "NavigateToActivityFolderInInstructorGradebook",
              base.IsTakeScreenShotDuringEntryExit);
        }

        
        /// <summary>
        /// Manage The Activity Folder Level Navigation HED Core.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// <param name="userTypeEnum">This is user Type Enum.</param>
        /// <param name="activityUnderTabName">This is Tab Name.</param>
        /// <remarks>This folder navigation is only valid for MyLab authored course such as
        /// section course, instructor course and Templates will only valid for this method.</remarks>
        public void ManageTheActivityFolderLevelNavigationHEDCore(string activityName,
            string activityUnderTabName, User.UserTypeEnum userTypeEnum)
        {
            // manage activity folder level navigation
            Logger.LogMethodEntry("CommonPage", "ManageTheActivityFolderLevelNavigationHEDCore",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window With Frame For Folder Navigation
                this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
                // folder navigation based on user type
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.CsSmsInstructor:
                        // folder navigation based on Tab name
                        switch (activityUnderTabName)
                        {
                            case "Gradebook":
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Take the Chapter 1 Exam":
                                        this.NavigateToActivityFolderInInstructorGradebook(
                                            CommonPageResource.CommonPage_Chapter1TheScienceofPsychology_FolderName
                                          , CommonPageResource.CommonPage_Gradebook_BackArrow_Id_Locator);
                                        break;
                                    case "Take the Chapter 3 Exam":
                                        this.NavigateToActivityFolderInInstructorGradebook(
                                            CommonPageResource.CommonPage_Chapter3_Sensation_and_Perception_FolderName,
                                            CommonPageResource.CommonPage_Gradebook_BackArrow_Id_Locator);
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
            Logger.LogMethodExit("CommonPage", "ManageTheActivityFolderLevelNavigationHEDCore",
              base.IsTakeScreenShotDuringEntryExit);
        }
    }
}



