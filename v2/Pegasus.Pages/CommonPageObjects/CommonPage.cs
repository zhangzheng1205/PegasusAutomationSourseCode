using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using System.Globalization;
using Pegasus.Pages.UI_Pages;
using System.Diagnostics;
using System.Configuration;

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
                                            (CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_BackIcon_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.NavigateToAccessChapter1SimulationActivitiesFolder
                                            (CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_BackIcon_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Excel Chapter 1 Skill-Based Training":
                                        this.NavigateToExcelChapter1SimulationActivitiesFolder
                                            (CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_BackIcon_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "PowerPoint Chapter 1 Skill-Based Training":
                                        this.NavigateToPowerPointChapter1SimulationActivitiesFolder
                                            (CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_BackIcon_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                }
                                break;
                            case "Course Materials":
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                    case "Word Chapter 1 Study Plan [Skill-Based]: Training > Post-Test":
                                        this.NavigateToWordChapter1SimulationActivitiesFolder
                                            (CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                            break;
                                    case "Access Chapter 1 Skill-Based Training":
                                    case "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                    case "Access Chapter 1 Study Plan [Skill-Based]: Training > Post-Test":
                                        this.NavigateToAccessChapter1SimulationActivitiesFolder
                                            (CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Excel Chapter 1 Skill-Based Training":
                                    case "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test":
                                        this.NavigateToExcelChapter1SimulationActivitiesFolder
                                            (CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "PowerPoint Chapter 1 Skill-Based Training":
                                        this.NavigateToPowerPointChapter1SimulationActivitiesFolder
                                            (CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    // Grader IT for Excel Activity
                                    case "Excel Chapter 1 Grader Project [Homework 3]":
                                    case "Excel Chapter 1 Grader Project [Homework 3] (Project G)":
                                        this.NavigateToExcelChapter1GraderActivitiesFolder
                                            (CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    // Grader IT for PowerPoint Activity
                                    case "PowerPoint Chapter 1 Grader Project [Homework 3]":
                                    case "PowerPoint Chapter 1 Grader Project [Homework 3] (Project G)":
                                        this.NavigateToPowerPointChapter1GraderActivitiesFolder
                                            (CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    // Grader IT for Word Activty
                                    case "Word Chapter 1 Grader Project [Assessment 3]":
                                        this.NavigateToWordChapter1GraderActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    // Grader IT for Access Activty
                                    case "Access Chapter 1 Grader Project [Assessment 3]":
                                        this.NavigateAccessChapter1GraderActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Amplifire Study Module 0P: Vocabulario en contexto":
                                        this.NavigateToAmplifierFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;

                                }
                                break;
                        }
                        break;
                    case User.UserTypeEnum.CsSmsInstructor:
                    case User.UserTypeEnum.AmpCsSmsInstructor:
                    case User.UserTypeEnum.HSSCsSmsInstructor:
                    case User.UserTypeEnum.HedProgramAdmin:
                    case User.UserTypeEnum.AmpProgramAdmin:
                        // folder navigation based on Tab name
                        switch (activityUnderTabName)
                        {
                            case "Course Materials":
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.NavigateToWordChapter1SimulationActivitiesFolder
                                            (CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Word Chapter 1 Grader Project [Assessment 3]":
                                        this.NavigateToWordChapter1GraderActivitiesFolder
                                            (CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Excel Chapter 1 Skill-Based Training":
                                    case "Excel Chapter 1 Skill-Based Exam (Scenario 1)":
                                    case "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test":
                                    case "Excel Chapter 1 Project 1A Skill-Based Training":
                                    case "Excel Chapter 1 Project 1A Skill-Based Exam (Scenario 1) ":
                                        this.NavigateToExcelChapter1SimulationActivitiesFolder
                                            (CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Access Chapter 1 Skill-Based Training":
                                    case "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.NavigateToAccessChapter1SimulationActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    //HSS activity
                                    case "Review the Chapter 1 Learning Objectives":
                                    case "Read the eText: Chapter 1":
                                        this.NavigateToAccessChapter4BrainAndNervousSystemFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "PowerPoint Chapter 1 Skill-Based Training":
                                    case "PowerPoint Chapter 1 Skill-Based Exam (Scenario 1)":
                                        this.NavigateToPowerPointChapter1SimulationActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Amplifier":
                                        this.NavigateToSectionAmplifierFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Capítulo preliminar: Bienvenidos a Unidos":
                                    case "¡Comprueba lo que sabes!":
                                    case "Amplifire Study Module 0P: Vocabulario en contexto":
                                        this.NavigateToAmplifierFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName, activityName);
                                        break;
                                }
                                break;
                            case "Gradebook":
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.SelectWordActivityFolderNavigationInInstructorGradebook(CommonPageResource.
                                            CommonPage_Gradebook_BackArrow_Id_Locator, userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.SelectAccessActivityFolderNavigationInInstructorGradebook(CommonPageResource.
                                            CommonPage_Gradebook_BackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "PowerPoint Chapter 1 Skill-Based Training":
                                    case "PowerPoint Chapter 1 Skill-Based Exam (Scenario 1)":
                                        this.SelectPowerPointActivityFolderNavigationInInstructorGradebook(CommonPageResource.
                                            CommonPage_Gradebook_BackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Excel Chapter 1 Skill-Based Training":
                                    case "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test":
                                        this.SelectExcelActivityFolderNavigationInInstructorGradebook(CommonPageResource.
                                            CommonPage_Gradebook_BackArrow_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                }
                                break;
                            case "Calendar":
                                switch (activityName)
                                {
                                    //Folder navigation for Word based on activity name
                                    case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.SelectWordActivityFolderNavigationInInstructorCalendar(CommonPageResource.
                                            CommonPage_Instructor_Calendar_Content_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    //Folder navigation for Access
                                    case "Access Chapter 1 Skill-Based Training":
                                    case "Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                        this.SelectAccessActivityFolderNavigationInInstructorCalendar(CommonPageResource.
                                            CommonPage_Instructor_Calendar_Content_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    //Folder navigation for powerpoint
                                    case "PowerPoint Chapter 1 Skill-Based Training":
                                    case "PowerPoint Chapter 1 Skill-Based Exam (Scenario 1)":
                                        this.SelectPowerPointActivityFolderNavigationInInstructorCalendar(CommonPageResource.
                                            CommonPage_Instructor_Calendar_Content_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;
                                    //Folder navigation for Excel
                                    case "Excel Chapter 1 Skill-Based Training":
                                    case "Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test":
                                        this.SelectExcelActivityFolderNavigationInInstructorCalendar(CommonPageResource.
                                            CommonPage_Instructor_Calendar_Content_Id_Locator,
                                            userTypeEnum, activityUnderTabName);
                                        break;

                                }
                                break;
                            case "TodaysView":
                                {
                                    switch (activityName)
                                    {
                                        case "Word Chapter 1 Skill-Based Training":
                                        case "Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)":
                                            this.NavigateToWordChapter1SimulationActivitiesFolder
                                                (CommonPageResource.CommonPage_CoursePerformance_Table_Id_Locator,
                                                userTypeEnum, activityUnderTabName);
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
        /// Navigate To Access Coursespace Section Amplifier Folder.
        /// </summary>
        private void NavigateToSectionAmplifierFolder(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            // navigate inside Access Coursespace Section Amplifier Folder
            Logger.LogMethodEntry("CommonPage",
                "NavigateToSectionAmplifierFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_SectionAmplifier_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "NavigateToSectionAmplifierFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Access Chapter1 Grader Activities Folder.
        /// </summary>
        private void NavigateToAmplifierFolder(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            // navigate inside access chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage",
                "NavigateToAmplifierFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_Amplifier_FolderName, webElementToWait);
            //click folder second leve
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_Amplifier_FolderName1, webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "NavigateToAmplifierFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Access Chapter1 Grader Activities Folder.
        /// </summary>
        private void NavigateToAmplifierFolder(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName, string folderName)
        {
            // navigate inside access chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToAmplifierFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(folderName, webElementToWait);
            //click folder second leve
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            Logger.LogMethodExit("CommonPage", "NavigateToAmplifierFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate inside the folder based on user.
        /// </summary>
        /// <param name="FolderName">This is the folder.</param>
        /// <param name="userTypeEnum">This is the user type.</param>
        public void NavigateInsideTheFolder(string FolderName, User.UserTypeEnum userTypeEnum)
        {
            // Navigate inside the folder based on user
            Logger.LogMethodEntry("CommonPage", "NavigateInsideTheFolder",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SelectWindow(CommonPageResource.ComonPage_Course_TabName);
                //Switch to the iframe usertype is WS instructor
                if (User.UserTypeEnum.AmpWSInstructor.Equals(userTypeEnum))
                {
                    base.SwitchToIFrameById(CommonPageResource.
                        ComonPage_MainCourse_FrameID);
                }
                //Switch to the iframe if usertype is other than WS instructor. 
                else
                {
                    base.SwitchToIFrameById(CommonPageResource.
                        CommonPage_Course_Materials_iFrame);
                }
                //Click on the folder link
                base.WaitForElement(By.PartialLinkText(FolderName));
                IWebElement getFolderLink = base.
                    GetWebElementPropertiesByPartialLinkText(FolderName);
                base.ClickByJavaScriptExecutor(getFolderLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage", "NavigateInsideTheFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Navigate To Chapter 04: The Brain and Nervous System Folder.
        /// </summary>
        private void NavigateToAccessChapter4BrainAndNervousSystemFolder(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            // navigate inside Chapter 4: Consciousness: Sleep, Dreams, Hypnosis, and Drugs Folder
            Logger.LogMethodEntry("CommonPage", "NavigateToExcelChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level 
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_Chapter1TheScienceofPsychology_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage", "NavigateToExcelChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Navigate To Excel Chapter 1 Grader Activities.
        /// </summary>
        private void NavigateToExcelChapter1GraderActivitiesFolder(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            // navigate inside power point chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToPowerPointExcelChapter1GraderActivitiesFolder",
             base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_Excel2013_FolderName,
                webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_ExcelChapter1CreatingAWorksheetAndChartingData_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_ExcelChapter1Activities_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                ComonPage_ExcelChapter1GraderActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage", "NavigateToPowerPointExcelChapter1GraderActivitiesFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Power Point Chapter1 Grader Activities Folder.
        /// </summary>
        private void NavigateToPowerPointChapter1GraderActivitiesFolder(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            // navigate inside power point chapter1 Grader activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToPowerPointChapter1GraderActivitiesFolder",
             base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.ComonPage_PowerPoint2013_FolderName,
                webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_PowerPointChapter1GettingStartedWithMicrosoftPowerPoint_FolderName,
                webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_PowerPointChapter1Activities_FolderName,
                webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_PowerPointChapter1GraderActivities_FolderName,
                webElementToWait);
            Logger.LogMethodExit("CommonPage", "NavigateToPowerPointChapter1GraderActivitiesFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Word Chapter1 Grader Activities Folder.
        /// </summary>
        private void NavigateToWordChapter1GraderActivitiesFolder(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            // navigate inside word chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToWordChapter1GraderActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_Word2013_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1CreatingDocumentsWithMicrosoftWord2013_FolderName,
                webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1Activities_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1GraderActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage", "NavigateToWordChapter1GraderActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Access Chapter1 Grader Activities Folder.
        /// </summary>
        private void NavigateAccessChapter1GraderActivitiesFolder(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            // navigate inside access chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateToAccessChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_Access2013_FolderName,
                webElementToWait);
            //Click on folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_AccessChapter1GettingStartedWithMicrosoftAccess2013_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_AccessChapter1Activities_FolderName,
                webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
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
            (string webElementToWait, User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            //Word Excel Folder Navigation In Instructor Calendar
            Logger.LogMethodEntry("CommonPage",
                "SelectExcelActivityFolderNavigationInInstructorCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_Excel2013_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_ExcelChapter1CreatingAWorksheetAndChartingData_FolderName,
                webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_ExcelChapter1Activities_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
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
            (string webElementToWait, User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            //Word Power Point Folder Navigation In Instructor Calendar
            Logger.LogMethodEntry("CommonPage",
                "SelectPowerPointActivityFolderNavigationInInstructorCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                ComonPage_PowerPoint2013_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_PowerPointChapter1GettingStartedWithMicrosoftPowerPoint_FolderName,
                webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_PowerPointChapter1Activities_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
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
            (string webElementToWait, User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            //Word Activity Folder Navigation In Instructor Calendar
            Logger.LogMethodEntry("CommonPage",
                "SelectAccessActivityFolderNavigationInInstructorCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_Access2013_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_AccessChapter1GettingStartedWithMicrosoftAccess2013_FolderName,
                webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_AccessChapter1Activities_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
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
           string webElementToWait, User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            //Word Activity Folder Navigation In Instructor Calendar
            Logger.LogMethodEntry("CommonPage",
                "SelectWordActivityFolderNavigationInInstructorCalendar",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_Word2013_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_WordChapter1CreatingDocumentsWithMicrosoftWord2013_FolderName,
                webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorCalendar(CommonPageResource.
                CommonPage_WordChapter1Activities_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
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
                case User.UserTypeEnum.AmpCsSmsStudent:
                case User.UserTypeEnum.HSSCsSmsStudent:
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
                case User.UserTypeEnum.AmpCsSmsInstructor:
                case User.UserTypeEnum.HSSCsSmsInstructor:
                case User.UserTypeEnum.HedProgramAdmin:
                case User.UserTypeEnum.AmpProgramAdmin:
                case User.UserTypeEnum.WLCsSmsInstructor:
                    switch (activityUnderTabName)
                    {
                        //Generate Activity Result by Student Report
                        case "Course Materials":
                            this.SelectWindowNameForFoldernavigation(activityUnderTabName,
                                CommonPageResource.CommonPage_CoursePreviewFrame_Id_Locator);
                            break;
                        case "Gradebook":
                            this.SelectWindowNameForFoldernavigation(activityUnderTabName,
                                CommonPageResource.
                                CommonPage_InstructorLeftNavigationFrame_Id_Locator);
                            break;
                        case "Calendar":
                            this.SelectWindowNameForFoldernavigation(activityUnderTabName);
                            break;
                        case "TodaysView":
                            this.SelectWindowNameForFoldernavigation(CommonPageResource.
                                CommonPage_TodaysView_WindowTitle_Value);
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
            Logger.LogMethodEntry("CommonPage",
                "SelectWindowNameForFoldernavigation",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(windowName);
            // select window
            base.SelectWindow(windowName);
            if (frameName != "Default Value")
            {
                // switch To Frame
                base.SwitchToIFrame(frameName);
            }
            Logger.LogMethodExit("CommonPage",
                "SelectWindowNameForFoldernavigation",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Power Point Chapter1 Simulation Activities Folder.
        /// </summary>
        private void NavigateToPowerPointChapter1SimulationActivitiesFolder(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            // navigate inside power point chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage",
                "NavigateToPowerPointChapter1SimulationActivitiesFolder",
             base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.ComonPage_PowerPoint2013_FolderName,
                webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_PowerPointChapter1GettingStartedWithMicrosoftPowerPoint_FolderName,
                webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_PowerPointChapter1Activities_FolderName,
                webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_PowerPointChapter1SimulationActivities_FolderName,
                webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "NavigateToPowerPointChapter1SimulationActivitiesFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Excel Chapter1 Simulation Activities Folder.
        /// </summary>
        private void NavigateToExcelChapter1SimulationActivitiesFolder(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            // navigate inside excel chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage",
                "NavigateToExcelChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_Excel2013_FolderName,
                webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_ExcelChapter1CreatingAWorksheetAndChartingData_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_ExcelChapter1Activities_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_ExcelChapter1SimulationActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "NavigateToExcelChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Access Chapter1 Simulation Activities Folder.
        /// </summary>
        private void NavigateToAccessChapter1SimulationActivitiesFolder(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            // navigate inside access chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage",
                "NavigateToAccessChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_Access2013_FolderName,
                webElementToWait);
            //click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_AccessChapter1GettingStartedWithMicrosoftAccess2013_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.CommonPage_AccessChapter1Activities_FolderName,
                webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_AccessChapter1SimulationActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "NavigateToAccessChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Word Chapter1 Simulation Activities Folder.
        /// </summary>
        private void NavigateToWordChapter1SimulationActivitiesFolder(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            // navigate inside word chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage",
                "NavigateToWordChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_Word2013_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1CreatingDocumentsWithMicrosoftWord2013_FolderName,
                webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1Activities_FolderName, webElementToWait);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                CommonPage_WordChapter1SimulationActivities_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage",
                "NavigateToWordChapter1SimulationActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Activity Folder Navigation Under Tab.
        /// </summary>
        /// <param name="activityFolderName">This is activity folder name.</param>
        /// <param name="webElementToWait">This is web element name to wait 
        /// wile navigtion inside folder.</param>
        private void NavigateInsideActivityFolderUnderTab(string activityFolderName,
            string webElementToWait)
        {
            // activity folder navigation
            Logger.LogMethodEntry("CommonPage",
                "NavigateInsideActivityFolderUnderTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.LinkText(activityFolderName));
            IWebElement getFolderLink = base.GetWebElementPropertiesByLinkText
                (activityFolderName);
            //Click the link
            base.PerformMouseClickAction(getFolderLink);
            Thread.Sleep(Convert.ToInt32(CommonPageResource.
                CommonPage_FolderNavigation_Sleep_Time));
            Logger.LogMethodExit("CommonPage",
                "NavigateInsideActivityFolderUnderTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Activity Folder Navigation Under Tab by instructor.
        /// </summary>
        /// <param name="activityFolderName">This is activity folder name.</param>
        /// <param name="webElementToWait">This is web element name to wait 
        /// wile navigtion inside folder.</param>
        private void NavigateInsideActivityFolderUnderTabByInstructor(
            string activityFolderName, string webElementToWait)
        {
            // activity folder navigation
            Logger.LogMethodEntry("CommonPage",
                "NavigateInsideActivityFolderUnderTabByInstructor",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            int getFolderCount = Convert.ToInt32(CommonPageResource.
               ComonPage_Folder_Count_Initial_Value);
            string getFolderName = string.Empty;
            //Get Folder Count
            getFolderCount = base.GetElementCountByXPath(
                CommonPageResource.ComonPage_InstructorRowCount);
            for (int i = 1; i <= getFolderCount; i++)
            {
                //Get Folder Text
                getFolderName = base.GetElementTextByXPath(string.Format(
                    CommonPageResource.
                    ComonPage_InstructorRow_Text_XPath_Locator, i));
                if (getFolderName == activityFolderName)
                {
                    IWebElement expandFolder = base.GetWebElementPropertiesByXPath(string.Format(
                        CommonPageResource.
                    ComonPage_InstructorRow_Text_XPath_Locator, i));
                    base.ClickByJavaScriptExecutor(expandFolder);
                    break;
                }
            }
            Thread.Sleep(Convert.ToInt32(CommonPageResource.CommonPage_FolderNavigation_Sleep_Time));
            Logger.LogMethodExit("CommonPage",
                "NavigateInsideActivityFolderUnderTabByInstructor",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        ///Select Word Activity Folder Navigation In Instructor Gradebook.
        /// </summary>
        /// <param name="webElementToWait">This is wait element.</param>
        private void SelectWordActivityFolderNavigationInInstructorGradebook(
          string webElementToWait, User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            //Word Activity Folder Navigation In Instructor Gradebook
            Logger.LogMethodEntry("CommonPage",
                "SelectWordActivityFolderNavigationInInstructorGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_Word2013_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_WordChapter1CreatingDocumentsWithMicrosoftWord2013_FolderName,
                webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_WordChapter1Activities_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
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
            (string webElementToWait, User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            //Word Activity Folder Navigation In Instructor Gradebook
            Logger.LogMethodEntry("CommonPage",
                "SelectAccessActivityFolderNavigationInInstructorGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_Access2013_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_AccessChapter1GettingStartedWithMicrosoftAccess2013_FolderName,
                webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_AccessChapter1Activities_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
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
            (string webElementToWait, User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            //Word Excel Folder Navigation In Instructor Gradebook
            Logger.LogMethodEntry("CommonPage",
                "SelectExcelActivityFolderNavigationInInstructorGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_Excel2013_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_ExcelChapter1CreatingAWorksheetAndChartingData_FolderName,
                webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_ExcelChapter1Activities_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
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
            (string webElementToWait, User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            //Word Power Point Folder Navigation In Instructor Gradebook
            Logger.LogMethodEntry("CommonPage",
                "SelectPowerPointActivityFolderNavigationInInstructorGradebook",
               base.IsTakeScreenShotDuringEntryExit);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_GOWithMicrosoftOffice2013Volume1_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                ComonPage_PowerPoint2013_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_PowerPointChapter1GettingStartedWithMicrosoftPowerPoint_FolderName,
                webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateToActivityFolderInInstructorGradebook(CommonPageResource.
                CommonPage_PowerPointChapter1Activities_FolderName, webElementToWait);
            //Navigate Inside the SubFolder Folder
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
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
            base.WaitForElement(By.XPath(CommonPageResource.
               ComonPage_Folder_Count_Xpath_Locator));
            getFolderCount = base.GetElementCountByXPath(CommonPageResource.
                ComonPage_Folder_Count_Xpath_Locator);
            for (int i = Convert.ToInt32(CommonPageResource.
                ComonPage_Loop_Initializer); i <= getFolderCount; i++)
            {
                //Get Folder Text
                base.WaitForElement(By.XPath(string.Format(
                    CommonPageResource.ComonPage_Folder_Text_Xpath_Locator, i)));
                getFolderText = base.GetElementTextByXPath(string.Format(
                    CommonPageResource.ComonPage_Folder_Text_Xpath_Locator, i));
                if (getFolderText == folderName)
                {
                    //Click on Folder
                    base.WaitForElement(By.XPath(
                        string.Format(CommonPageResource.
                        ComonPage_Folder_Name_Xpath_Locator, i)));
                    IWebElement getFolderNameProperty = base.GetWebElementPropertiesByXPath(
                        string.Format(CommonPageResource.
                        ComonPage_Folder_Name_Xpath_Locator, i));
                    Thread.Sleep(Convert.ToInt32(CommonPageResource.
                        ComonPage_Wait_Time));
                    base.ClickByJavaScriptExecutor(getFolderNameProperty);
                    Thread.Sleep(7000);
                    // base.WaitForElement(By.Id(webElementToWait));
                    break;
                }
            }
            Logger.LogMethodExit("CommonPage",
                "NavigateToActivityFolderInInstructorGradebook",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Returns the folder name.
        /// </summary>
        /// <param name="folderName">This is the folder name</param>
        /// <returns></returns>
        public string GetFolderNameByXpath(string folderName)
        {
            Logger.LogMethodEntry("CommonPage",
                "GetFolderNameByXpath",
               base.IsTakeScreenShotDuringEntryExit);

            string ActualFolderName = String.Empty;
            switch (folderName)
            {
                case "Capítulo preliminar: Bienvenidos a Unidos":
                    base.SelectWindow(CommonPageResource.
                        CommonPage_Course_Materials);
                    base.SwitchToIFrameById(CommonPageResource.
                        CommonPage_Course_Materials_iFrame);
                    base.WaitForElement(By.XPath(CommonPageResource.
                        AmplifierFolderOneXpath));
                    ActualFolderName = base.GetElementInnerTextByXPath(CommonPageResource.
                        AmplifierFolderOneXpath);
                    break;
                case "¡Comprueba lo que sabes!":
                    base.SelectWindow(CommonPageResource.
                        CommonPage_Course_Materials);
                    base.SwitchToIFrameById(CommonPageResource.
                        CommonPage_Course_Materials_iFrame);
                    base.WaitForElement(By.XPath(CommonPageResource.
                        AmplifierFolderTwoXpath));
                    ActualFolderName = base.GetElementInnerTextByXPath(CommonPageResource.
                        AmplifierFolderTwoXpath);
                    break;
            }
            Logger.LogMethodExit("CommonPage",
                "GetFolderNameByXpath",
              base.IsTakeScreenShotDuringEntryExit);
            return ActualFolderName;
        }

        /// <summary>
        /// To get Breath crumb selected item in course Materials.
        /// </summary>
        /// <remarks>Return selected folder name</remarks>
        public string GetBreathCrumbItemSelected()
        {
            Logger.LogMethodEntry("CommonPage",
                "GetBreathCrumbItemSelected",
               base.IsTakeScreenShotDuringEntryExit);

            string ActualFolderName = String.Empty;

            base.SelectWindow(CommonPageResource.
                CommonPage_Course_Materials);
            base.SwitchToIFrameById(CommonPageResource.
                CommonPage_Course_Materials_iFrame);
            base.WaitForElement(By.XPath(CommonPageResource.
                CommonPage_BreathCrumbItemSelected));
            ActualFolderName = base.GetElementInnerTextByXPath(CommonPageResource.
                CommonPage_BreathCrumbItemSelected);

            Logger.LogMethodExit("CommonPage",
                "GetBreathCrumbItemSelected",
              base.IsTakeScreenShotDuringEntryExit);

            return ActualFolderName;
        }

        /// <summary>
        /// Returns boolean value for window launch.
        /// </summary>
        /// <returns>Boolean value.</returns>
        public Boolean IsPageOpened(string amplifierUrlText)
        {
            // Returns boolean value for window launch
            Logger.LogMethodEntry("CommonPage",
                "IsPageOpened",
                base.IsTakeScreenShotDuringEntryExit);
            Boolean IsPageOpened = false;
            try
            {

                Thread.Sleep(Convert.ToInt32(CommonPageResource.
                             ComonPage_Amplifier_Launch_Wait_Time));
                //Switch to window
                base.SwitchToLastOpenedWindow();
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                string getTheUrl = base.GetCurrentUrl;
                while (!IsPageOpened)
                {

                    if (stopWatch.Elapsed.TotalMinutes < 2 == false) break;

                    {
                        IsPageOpened = getTheUrl.Contains(amplifierUrlText);

                    }
                }
                stopWatch.Stop();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage",
                "IsPageOpened",
                base.IsTakeScreenShotDuringEntryExit);
            return IsPageOpened;
        }


        /// <summary>
        /// Method to fetch current URL.
        /// </summary>
        /// <returns>Current Url.</returns>
        public string GetCurrentURL()
        {
            Logger.LogMethodEntry("CommonPage", "GetCurrentURL",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            String getCurrentURL = string.Empty;
            try
            {
                //set current window URL
                getCurrentURL = base.GetCurrentUrl;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage", "GetCurrentURL",
                base.IsTakeScreenShotDuringEntryExit);
            return getCurrentURL;
        }

        /// <summary>
        ///Verify a text in the launched  page .
        /// </summary>
        /// <param name="expectedText">This is the text value to be searched.</param>
        /// <returns></returns>
        public Boolean IsTextPresentInPageSource()
        {
            //Verify a text in the launched  page 
            Logger.LogMethodEntry("CommonPage",
               "IsTextPresentInPageSource",
              base.IsTakeScreenShotDuringEntryExit);
            bool isTextPresent = false;
            //Start Stop Watch 
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            try
            {
                switch (Environment.GetEnvironmentVariable(CommonPageResource.
                    PEG_AUTOMATION_TEST_ENVIRONMENT_KEY.ToUpper())
                  ?? ConfigurationManager.AppSettings[CommonPageResource.
                  TestEnvironment_Key].ToUpper())
                {
                    case "PROD":
                        while (!isTextPresent)
                        {

                            if (stopWatch.Elapsed.TotalMinutes < 2 == false) break;

                            isTextPresent = WebDriver.PageSource.Contains(CommonPageResource.
                            CommonPage_Amplifire_Production_Book_Content);
                        }
                        break;

                    case "VCD":
                    case "CGIE":
                        while (!isTextPresent)
                        {

                            if (stopWatch.Elapsed.TotalMinutes < 2 == false) break;
                            isTextPresent = WebDriver.PageSource.Contains(CommonPageResource.
                            CommonPage_Amplifire_General_Book_Content);
                        }
                        break;
                }
                stopWatch.Stop();
                //Verify a text in the launched page 

            }
            catch (Exception)
            {

                throw;
            }
            Logger.LogMethodExit("CommonPage",
               "IsTextPresentInPageSource",
             base.IsTakeScreenShotDuringEntryExit);
            return isTextPresent;

        }

        /// <summary>
        /// Gets the text displayed in the window.
        /// </summary>
        /// <param name="Text">The text displayed in window.</param>
        /// <returns></returns>
        public string GetTextByXpath()
        {
            // Gets the text displayed in the window
            Logger.LogMethodEntry("CommonPage",
                "GetTextByXpath",
               base.IsTakeScreenShotDuringEntryExit);
            string getActualContent = String.Empty;
            try
            {
                base.SwitchToLastOpenedWindow();
                base.WaitForElement(By.XPath(CommonPageResource.
                    ComonPage_BookTitle_For_Amplifire));
                getActualContent = base.GetElementInnerTextByXPath(CommonPageResource.
                    ComonPage_BookTitle_For_Amplifire).Trim();
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage",
                "GetTextByXpath",
              base.IsTakeScreenShotDuringEntryExit);
            // Returns the text displayed in the window
            return getActualContent;
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
            Logger.LogMethodEntry("CommonPage",
                "ManageTheActivityFolderLevelNavigationHEDCore",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window With Frame For Folder Navigation
                this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
                // folder navigation based on user type
                switch (userTypeEnum)
                {
                    case User.UserTypeEnum.CsSmsInstructor:
                    case User.UserTypeEnum.HSSCsSmsInstructor:
                    case User.UserTypeEnum.WLCsSmsInstructor:
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

                                    case "SAM 01-05 Heritage Language: tu español. [Vocabulario 1. La familia]":
                                    case "SAM 01-19 Singular y plural.  [Gramática 3. Sustantivos singulares y plurales] Voice Recording.":
                                        this.NavigateToActivityFolderInInstructorGradebook(
                                            "Capítulo 01: ¿Quiénes somos? (ORGANIZED BY CONTENT TYPE)",
                                            CommonPageResource.CommonPage_Gradebook_BackArrow_Id_Locator);
                                        this.NavigateToActivityFolderInInstructorGradebook(
                                           "STUDENT ACTIVITIES MANUAL",
                                           CommonPageResource.CommonPage_Gradebook_BackArrow_Id_Locator);
                                        break;
                                }
                                break;

                            case "Course Materials":
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Review the Chapter 4 Learning Objectives":
                                        this.NavigateToChapter4ExamActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                                    userTypeEnum, activityUnderTabName);
                                        break;

                                }
                                break;

                            case "Calendar":
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Review the Chapter 1 Learning Objectives":
                                        this.NavigateToChapter1ActivitiesFolder(
                                           CommonPageResource.
                                           CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                                   userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Complete the Chapter 1 Study Plan":
                                        this.NavigateToChapter1ActivitiesFolder(
                                           CommonPageResource.
                                           CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                                   userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Take the Chapter 2 Exam":
                                        this.NavigateToChapter2ExamActivitiesFolder(
                                           CommonPageResource.
                                           CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                                   userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Take the Chapter 3 Exam":
                                        this.NavigateToChapter3ExamActivitiesFolder(
                                           CommonPageResource.
                                           CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                                   userTypeEnum, activityUnderTabName);
                                        break;
                                    case "Review the Chapter 5 Learning Objectives":
                                    case "Read the eText: Chapter 5":
                                        this.NavigateToChapter5ExamActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                                    userTypeEnum, activityUnderTabName);
                                        break;
                                    case "SAM 02-02 ¿Qué clases tienen? [Vocabulario 1. Las materias y las especialidades]":
                                        this.NavigateToCapítulo02ActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                                    userTypeEnum, activityUnderTabName);
                                        break;
                                    case "SAM 03-01 ¿Qué hacemos en casa? [Vocabulario 1. La casa]":
                                        this.NavigateToCapítulo03ActivitiesFolder(CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                                    userTypeEnum, activityUnderTabName);
                                        break;
                                    case "SAM 05-01 Artistas famosos. [Vocabulario 1. El mundo de la música]":
                                        this.NavigateToCapítulo05ActivitiesFolder(CommonPageResource.
                                           CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                                   userTypeEnum, activityUnderTabName);
                                        break;
                                    case "SAM 06-01 Descripciones. [Review: Capítulos Preliminar A,  1 y 2]":
                                        this.NavigateToCapítulo06ActivitiesFolder(CommonPageResource.
                                           CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                                   userTypeEnum, activityUnderTabName);
                                        break;
                                }
                                break;

                        }
                        break;
                    case User.UserTypeEnum.HSSCsSmsStudent:
                    case User.UserTypeEnum.CsSmsStudent:
                    case User.UserTypeEnum.WLCsSmsStudent:
                        switch (activityUnderTabName)
                        {
                            case "Course Materials":
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Take the Chapter 1 Exam":
                                        this.NavigateToChapter1ExamActivitiesFolder(
                                            CommonPageResource.
                                            CommonPage_BackToPreviousContentFolder_ImageBackArrow_Id_Locator,
                                                    userTypeEnum, activityUnderTabName);
                                        break;
                                }
                                break;
                            case "Gradebook":
                                switch (activityName)
                                {
                                    // folder navigation based on activity name
                                    case "Take the Chapter 1 Exam":
                                        this.NavigateToChapter1ExamGradeFolder(
                                            CommonPageResource.
                                            CommonPage_Chapter1TheScienceofPsychology_FolderName);
                                        break;
                                    case "Complete the Chapter 1 Study Plan":
                                        this.NavigateToChapter1StudyPlanGradeFolder(
                                            CommonPageResource.
                                            CommonPage_Chapter1TheScienceofPsychology_FolderName,
                                            activityName);
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
                "ManageTheActivityFolderLevelNavigationHEDCore",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Capítulo 02 folder in WL.
        /// </summary>
        /// <param name="webElementToWait">This is the web elemnet to wait.</param>
        /// <param name="userTypeEnum">This is the user.</param>
        /// <param name="activityUnderTabName">This is the tab name.</param>
        public void NavigateToCapítulo02ActivitiesFolder(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            Logger.LogMethodEntry("CommonPage", "NavigateToCapítulo02ActivitiesFolder",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // click folder level
                this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
                this.NavigateInsideActivityFolderUnderTabByInstructor(
                    CommonPageResource.ComonPage_Capítulo02_WLFolderName,
                webElementToWait);
                this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
                this.NavigateInsideActivitySubFolder();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage", "NavigateToCapítulo02ActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to sub folder 'STUDENT ACTIVITIES MANUAL' in WL.
        /// </summary>
        private void NavigateInsideActivitySubFolder()
        {
            // Activity sub folder navigation
            Logger.LogMethodEntry("CommonPage",
                "NavigateInsideActivityFolderUnderTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            bool dfjgh = base.IsElementPresent(By.CssSelector(CommonPageResource.
                ComonPage_WL_SubFolder_Name));
            IWebElement getFolderLink = base.GetWebElementPropertiesByCssSelector(
                CommonPageResource.
                ComonPage_WL_SubFolder_Name);
            base.ClickByJavaScriptExecutor(getFolderLink);
            Thread.Sleep(Convert.ToInt32(CommonPageResource.
                CommonPage_FolderNavigation_Sleep_Time));
            Logger.LogMethodExit("CommonPage",
                "NavigateInsideActivityFolderUnderTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Chapter 1 Study Plan Grade Folder 
        /// </summary>
        /// <param name="folderName">This is the folderName.</param>
        /// <param name="activityName">This is the activityName.</param>
        private void NavigateToChapter1StudyPlanGradeFolder
            (string folderName, string activityName)
        {
            Logger.LogMethodEntry("CommonPage",
                "NavigateToChapter1StudyPlanGradeFolder",
            base.IsTakeScreenShotDuringEntryExit);
            this.NavigateToChapter1ExamGradeFolder(folderName);
            try
            {
                new GBInstructorUXPage().SelectGradebookFrame();
                base.WaitForElement(By.LinkText(activityName));
                IWebElement assetElement = base.GetWebElementPropertiesByLinkText(activityName);
                base.ClickByJavaScriptExecutor(assetElement);
                Thread.Sleep(Convert.ToInt32(CommonPageResource.
               CommonPage_FolderNavigation_Sleep_Time));
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage",
                "NavigateToChapter1StudyPlanGradeFolder",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Chapter 1 Exam Grade Folder 
        /// </summary>
        /// <param name="folderName">This is the folderName.</param>
        private void NavigateToChapter1ExamGradeFolder(string folderName)
        {
            Logger.LogMethodEntry("CommonPage",
                "NavigateToChapter1ExamGradeFolder",
            base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(folderName));
            IWebElement courseName = base.
                GetWebElementPropertiesByPartialLinkText(folderName);
            base.ClickByJavaScriptExecutor(courseName);
            Thread.Sleep(Convert.ToInt32(CommonPageResource.
                CommonPage_FolderNavigation_Sleep_Time));
            Logger.LogMethodExit("CommonPage",
                "NavigateToChapter1ExamGradeFolder",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Chapter 1 Folder and launch the activity
        /// </summary>
        /// <param name="webElementToWait">This is the element to wait.</param>
        /// <param name="userTypeEnum">This is the type of user.</param>
        /// <param name="activityUnderTabName">This is the tabname.</param>
        private void NavigateToChapter1ActivitiesFolder(string webElementToWait,
                User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            Logger.LogMethodEntry("CommonPage",
                "NavigateToChapter1ExamActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // click folder level
                this.SelectWindowWithFrameForFolderNavigation(userTypeEnum,
                    activityUnderTabName);
                this.NavigateInsideActivityFolderUnderTabByInstructor(
                    CommonPageResource.CommonPage_HssChapter1Activities_FolderName,
                    webElementToWait);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage",
                "NavigateToChapter1ExamActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Chapter 1 Folder and launch the activity
        /// </summary>
        /// <param name="webElementToWait">This is the element to wait.</param>
        /// <param name="userTypeEnum">This is the type of user.</param>
        /// <param name="activityUnderTabName">This is the tabname.</param>
        private void NavigateToChapter1ExamActivitiesFolder(string webElementToWait,
                User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            Logger.LogMethodEntry("CommonPage",
                "NavigateToChapter1ExamActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // click folder level
                this.SelectWindowWithFrameForFolderNavigation(userTypeEnum,
                    activityUnderTabName);
                this.NavigateInsideActivityFolderUnderTab(
                    CommonPageResource.CommonPage_HssChapter1Activities_FolderName,
                    webElementToWait);
                this.SelectWindowWithFrameForFolderNavigation(userTypeEnum,
                    activityUnderTabName);
                this.NavigateInsideActivityFolderUnderTab(
                    CommonPageResource.CommonPage_HssChapter1ExamActivities_Link,
                    webElementToWait);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage",
                "NavigateToChapter1ExamActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Navigate to Chapter 2 folder.
        /// </summary>
        /// <param name="webElementToWait">This is the element to wait.</param>
        /// <param name="userTypeEnum">This is the type of user.</param>
        /// <param name="activityUnderTabName">This is the tabname.</param>
        private void NavigateToChapter2ExamActivitiesFolder(string webElementToWait,
                User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            //Navigate to Chapter 2 folder
            Logger.LogMethodEntry("CommonPage",
                "NavigateToChapter2ExamActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // click folder level
                this.SelectWindowWithFrameForFolderNavigation
                    (userTypeEnum, activityUnderTabName);
                this.NavigateInsideActivityFolderUnderTabByInstructor(CommonPageResource.
                    CommonPage_Chapter2TheBiologicalPerspective_FolderName, webElementToWait);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage",
                "NavigateToChapter2ExamActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Chapter 3 folder.
        /// </summary>
        /// <param name="webElementToWait">This is the element to wait.</param>
        /// <param name="userTypeEnum">This is the type of user.</param>
        /// <param name="activityUnderTabName">This is the tabname.</param>
        private void NavigateToChapter3ExamActivitiesFolder(string webElementToWait,
                User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            Logger.LogMethodEntry("CommonPage",
                "NavigateToChapter3ExamActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // click folder level
                this.SelectWindowWithFrameForFolderNavigation(userTypeEnum,
                    activityUnderTabName);
                this.NavigateInsideActivityFolderUnderTabByInstructor(CommonPageResource.
                    CommonPage_Chapter3_Sensation_and_Perception_FolderName, webElementToWait);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage",
                "NavigateToChapter3ExamActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Chapter 4 folder.
        /// </summary>
        /// <param name="webElementToWait">This is the element to wait.</param>
        /// <param name="userTypeEnum">This is the type of user.</param>
        /// <param name="activityUnderTabName">This is the tabname.</param>
        private void NavigateToChapter4ExamActivitiesFolder(string webElementToWait,
                User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            Logger.LogMethodEntry("CommonPage",
                "NavigateToChapter4ExamActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // click folder level
                this.SelectWindowWithFrameForFolderNavigation
                    (userTypeEnum, activityUnderTabName);
                this.NavigateInsideActivityFolderUnderTabByInstructor
                    (CommonPageResource.CommonPage_HssChapter4Activities_FolderName,
                    webElementToWait);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage",
                "NavigateToChapter4ExamActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Chapter 5 folder.
        /// </summary>
        /// <param name="webElementToWait">This is the element to wait.</param>
        /// <param name="userTypeEnum">This is the type of user.</param>
        /// <param name="activityUnderTabName">This is the tabname.</param>
        private void NavigateToChapter5ExamActivitiesFolder(string webElementToWait,
                User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            Logger.LogMethodEntry("CommonPage", "NavigateToChapter5ExamActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // click folder level
                this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
                this.NavigateInsideActivityFolderUnderTabByInstructor("Chapter 5: Learning", webElementToWait);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage", "NavigateToChapter5ExamActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate inside the  access chapter 1 folder
        /// </summary>
        /// <param name="FolderName"></param>
        /// <param name="UserType"></param>
        public void NavigateInsideTheFolderUnderMycourse(string FolderName,
            User.UserTypeEnum UserType)
        {
            // navigate inside access chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage",
                "NavigateInsideTheFolderUnderMycourse",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // click folder level
                base.SelectWindow(CommonPageResource.ComonPage_Course_TabName);
                base.SwitchToIFrameById(CommonPageResource.
                    ComonPage_MainCourse_FrameID);
                base.WaitForElement(By.PartialLinkText(FolderName));
                IWebElement getFolderLink = base.
                    GetWebElementPropertiesByPartialLinkText
                    (FolderName);
                base.ClickByJavaScriptExecutor(getFolderLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CommonPage",
                "NavigateInsideTheFolderUnderMycourse",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifies the display of amplifier link.
        /// </summary>
        /// <param name="linkname">This is the amplifier link name.</param>
        /// <param name="userTypeEnum">This is usertype enum.</param>
        /// <returns>This is the boolean vaue.</returns>
        public Boolean IsAmplifireLinkPresent(string linkname, User.UserTypeEnum userTypeEnum)
        {
            // Verifies the display of amplifier link
            Logger.LogMethodEntry("CommonPage",
                "IsAmplifireLinkPresent",
               base.IsTakeScreenShotDuringEntryExit);
            bool isAmplifireLinkPresent = false;
            switch (userTypeEnum)
            {
                //Verify the link in workspace
                case User.UserTypeEnum.AmpWSInstructor:
                    base.SelectWindow(CommonPageResource.ComonPage_Course_TabName);
                    base.SwitchToIFrameById(CommonPageResource.
                       ComonPage_MainCourse_FrameID);
                    string amplifierIconClassWS = this.GetAmplifierIconClassAsInsturctor(linkname);
                    if (amplifierIconClassWS == CommonPageResource.
                        CommonPage_Workspace_AmplifierIcon_Classname_Value)
                    {
                        isAmplifireLinkPresent = true;
                    }
                    break;
                //Verify the link in course space
                case User.UserTypeEnum.CsSmsInstructor:
                case User.UserTypeEnum.HedProgramAdmin:
                case User.UserTypeEnum.AmpProgramAdmin:
                case User.UserTypeEnum.AmpCsSmsInstructor:
                    base.SelectWindow(CommonPageResource.ComonPage_Course_TabName);
                    base.SwitchToIFrameById(CommonPageResource.
                        CommonPage_Course_Materials_iFrame);
                    string amplifierIconClassCSInstructor = this.
                        GetAmplifierIconClassAsInsturctor(linkname);

                    if (amplifierIconClassCSInstructor == CommonPageResource.
                        CommonPage_CourseSpace_AmplifierIcon_Classname_Value)
                    {
                        isAmplifireLinkPresent = true;
                    }
                    break;
                //Verify the link in course space
                case User.UserTypeEnum.CsSmsStudent:
                case User.UserTypeEnum.AmpCsSmsStudent:
                    base.SelectWindow(CommonPageResource.ComonPage_Course_TabName);
                    base.SwitchToIFrameById(CommonPageResource.
                        CommonPage_Course_Materials_iFrame);
                    string amplifierIconClassCSStudent = this.
                        GetAmplifierIconClassAsStudent(linkname);
                    if (amplifierIconClassCSStudent == CommonPageResource.
                        CommonPage_CourseSpace_AmplifierIcon_Classname_Value)
                    {
                        isAmplifireLinkPresent = true;
                    }
                    break;

            }
            Logger.LogMethodExit("CommonPage",
               "IsAmplifireLinkPresent",
              base.IsTakeScreenShotDuringEntryExit);
            return isAmplifireLinkPresent;
        }

        /// <summary>
        /// This returns the amplifier icon class name when user is student.
        /// </summary>
        /// <param name="linkname">This is amplifer link name.</param>
        /// <returns>The amplifier icon class name.</returns>
        private string GetAmplifierIconClassAsStudent(string linkname)
        {
            // This returns the amplifier icon class name when user is student
            Logger.LogMethodEntry("CommonPage",
               "GetAmplifierIconClassAsStudent",
              base.IsTakeScreenShotDuringEntryExit);
            string linkId = base.GetWebElementPropertiesByLinkText(linkname).
                GetAttribute(CommonPageResource.
                CommonPage_WebElement_Property_Id);
            string amplifierIconId = CommonPageResource.
                CommonPage_AmplifierIcon_ClassName_PartialString_Value + linkId.Split('_')[1];

            string amplifierIconClass = base.GetWebElementPropertiesByXPath(string.
                Format(CommonPageResource.
                CommonPage_AmpliferIcon_Xpath_Value, amplifierIconId)).
                GetAttribute(CommonPageResource.
                CommonPage_WebElement_Property_Class);
            // This returns the amplifier icon class name when user is student
            Logger.LogMethodExit("CommonPage",
              "GetAmplifierIconClassAsStudent",
             base.IsTakeScreenShotDuringEntryExit);
            return amplifierIconClass;
        }

        /// <summary>
        /// This returns the amplifier icon class name when user is instructor.
        /// </summary>
        /// <param name="linkname">This is amplifer link name.</param>
        /// <returns>The amplifier icon class name.</returns>
        private string GetAmplifierIconClassAsInsturctor(string linkname)
        {
            // This returns the amplifier icon class name when user is instructor
            Logger.LogMethodEntry("CommonPage",
              "GetAmplifierIconClassAsInsturctor",
             base.IsTakeScreenShotDuringEntryExit);
            string linkId = base.GetWebElementPropertiesByLinkText(linkname).
                GetAttribute(CommonPageResource.
                CommonPage_WebElement_Property_Id);
            string amplifierIconId = CommonPageResource.
                CommonPage_Instructor_AmplifierIcon_ClassName_PartialString_Value + linkId.Split('_')[1];
            string amplifierIconClass = base.GetWebElementPropertiesByXPath(string.
                Format(CommonPageResource.
                CommonPage_Instructor_AmpliferIcon_Xpath_Value, amplifierIconId)).
                GetAttribute(CommonPageResource.
                CommonPage_WebElement_Property_Class);
            // This returns the amplifier icon class name when user is instructor
            Logger.LogMethodExit("CommonPage",
             "GetAmplifierIconClassAsInsturctor",
            base.IsTakeScreenShotDuringEntryExit);
            return amplifierIconClass;
        }

        /// <summary>
        /// Navigate To 'Review the Chapter 4 Learning Objectives' HSS activity.
        /// </summary>
        /// <param name="webElementToWait">This is the web element to wait.</param>
        /// <param name="userTypeEnum">This is the user type.</param>
        /// <param name="activityUnderTabName">This is the tab name.</param>
        private void NavigateReviewChapter4LearningObjectives(string webElementToWait,
            User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            // navigate inside access chapter1 simulation activities folder
            Logger.LogMethodEntry("CommonPage", "NavigateReviewChapter4LearningObjectives",
               base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTab(CommonPageResource.
                ComonPage_HSS_Chapter4_FolderName, webElementToWait);
            Logger.LogMethodExit("CommonPage", "NavigateReviewChapter4LearningObjectives",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Capitulo 03 folder in WL.
        /// </summary>
        /// <param name="webElementToWait">This is the web element to wait.</param>
        /// <param name="userTypeEnum">This is the user type.</param>
        /// <param name="activityUnderTabName">This is the tab name.</param>
        private void NavigateToCapítulo03ActivitiesFolder(string webElementToWait,
           User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            Logger.LogMethodEntry("CommonPage", "NavigateToCapítulo03ActivitiesFolder",
           base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTabByInstructor(
                    CommonPageResource.
                    ComonPage_Capítulo03_WLFolderName, webElementToWait);
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivitySubFolder();
            Logger.LogMethodExit("CommonPage", "NavigateToCapítulo03ActivitiesFolder",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to Capitulo 06 folder in WL.
        /// </summary>
        /// <param name="webElementToWait">This is the web element to wait.</param>
        /// <param name="userTypeEnum">This is the user type.</param>
        /// <param name="activityUnderTabName">This is the tab name.</param>
        private void NavigateToCapítulo06ActivitiesFolder(string webElementToWait,
           User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            Logger.LogMethodEntry("CommonPage", "NavigateToCapítulo06ActivitiesFolder",
           base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTabByInstructor(
                    CommonPageResource.
                    ComonPage_Capítulo06_WLFolderName, webElementToWait);
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum, activityUnderTabName);
            this.NavigateInsideActivitySubFolder();
            Logger.LogMethodExit("CommonPage", "NavigateToCapítulo06ActivitiesFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Navigate to Capitulo 05 folder in WL.
        /// </summary>
        /// <param name="webElementToWait">This is the web element to wait.</param>
        /// <param name="userTypeEnum">This is the user type.</param>
        /// <param name="activityUnderTabName">This is the tab name.</param>
        private void NavigateToCapítulo05ActivitiesFolder(string webElementToWait,
           User.UserTypeEnum userTypeEnum, string activityUnderTabName)
        {
            Logger.LogMethodEntry("CommonPage", "NavigateToCapítulo05ActivitiesFolder",
           base.IsTakeScreenShotDuringEntryExit);
            // click folder level
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum,
                      activityUnderTabName);
            this.NavigateInsideActivityFolderUnderTabByInstructor(
                      CommonPageResource.
                      ComonPage_Capítulo05_WLFolderName,
                      webElementToWait);
            this.SelectWindowWithFrameForFolderNavigation(userTypeEnum,
                      activityUnderTabName);
            this.NavigateInsideActivitySubFolder();
            Logger.LogMethodExit("CommonPage", "NavigateToCapítulo05ActivitiesFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }



    }
}



