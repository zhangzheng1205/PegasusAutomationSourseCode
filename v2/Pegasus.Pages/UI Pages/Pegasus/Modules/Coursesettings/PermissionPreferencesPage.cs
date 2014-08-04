using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    ///  This class handles Pegasus Permission Preferences Page Actions
    /// </summary>    
    public class PermissionPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(PermissionPreferencesPage));
       
        /// <summary>
        /// Enable Permission Preferences
        /// </summary>
        public void EnablePermissionPreferences()
        {
            //Enable Permission Preferences
            logger.LogMethodEntry("PermissionPreferencesPage","EnablePermissionPreferences",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Preferences Window
                this.SelectPreferencesWindow();  
                //Enable Activity Permission Preferences
                this.EnableActivityPermissionPreferences();
                //Enable Gradebook Permission Preferences
                this.EnableGradebookPermissionPreferences();
                base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_PerformanceButton_Id_Locator));
                //Click on Performance Expand Button
                base.ClickButtonById(PermissionPreferencesPageResource.
                    PermissionPreferencesPage_Resource_PerformanceButton_Id_Locator);
                //Enable Performance Permission Preferences
                this.EnablePerformancePermissionPreferences();
                //Enable Question Analysis Permission Preference
                this.EnableQuestionAnalysisPermissionPreference();
                //Enable Submissions Permission Preferences
                this.EnableSubmissionsPermissionPreferences();
                base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                    PermissionPreferencesPage_Resource_SavePreferences_Id_Locator));
                //Click on Save Preferences
                base.ClickButtonById(PermissionPreferencesPageResource.
                    PermissionPreferencesPage_Resource_SavePreferences_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PermissionPreferencesPage","EnablePermissionPreferences",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Activity Permission Preferences
        /// </summary>
        private void EnableActivityPermissionPreferences()
        {
            //Enable Activity Permission Preferences
            logger.LogMethodEntry("PermissionPreferencesPage","EnableActivityPermissionPreferences",
                base.IsTakeScreenShotDuringEntryExit);                    
            base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_ShowHideContent_Checkbox_Id_Locator));
            if (!base.IsElementSelectedById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_ShowHideContent_Checkbox_Id_Locator))
            {
                //Enable show/Hide Content in MyCourse Permission
                base.SelectCheckBoxById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_ShowHideContent_Checkbox_Id_Locator);
            }
            logger.LogMethodExit("PermissionPreferencesPage","EnableActivityPermissionPreferences",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Preferences Window
        /// </summary>
        private void SelectPreferencesWindow()
        {
            //Select Preferences Window
            logger.LogMethodEntry("PermissionPreferencesPage", "SelectPreferencesWindow",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(PermissionPreferencesPageResource.
               PermissionPreferencesPage_Resource_Window_Name);
            //Select Window
            base.SelectWindow(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_Window_Name);
            base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_Frame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_Frame_Id_Locator);
            logger.LogMethodExit("PermissionPreferencesPage", "SelectPreferencesWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Gradebook Permission Preferences
        /// </summary>
        private void EnableGradebookPermissionPreferences()
        {
            //Enable Gradebook Permission Preferences
            logger.LogMethodEntry("PermissionPreferencesPage","EnableGradebookPermissionPreferences",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_ViewGradebook_Checkbox_Id_Locator));
            if (!base.IsElementSelectedById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_ViewGradebook_Checkbox_Id_Locator))
            {
                //Enable View Gradebook Permission
                base.SelectCheckBoxById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_ViewGradebook_Checkbox_Id_Locator);
            }
            logger.LogMethodExit("PermissionPreferencesPage","EnableGradebookPermissionPreferences",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Performance Permission Preferences
        /// </summary>
        private void EnablePerformancePermissionPreferences()
        {
            //Enable Performance Permission Preferences
            logger.LogMethodEntry("PermissionPreferencesPage","EnablePerformancePermissionPreferences", 
                base.IsTakeScreenShotDuringEntryExit);            
            base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_ActivityResult_Checkbox_Id_Locator));
            if (!base.IsElementSelectedById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_ActivityResult_Checkbox_Id_Locator))
            {
                //Enable Activity Results by Student Permission
                base.SelectCheckBoxById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_ActivityResult_Checkbox_Id_Locator);
            }
            base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_StudentResult_Checkbox_Id_Locator));
            if (!base.IsElementSelectedById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_StudentResult_Checkbox_Id_Locator))
            {
                //Enable Student Results by Activity Permission
                base.SelectCheckBoxById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_StudentResult_Checkbox_Id_Locator);
            }
            base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_StudyPlanResults_Checkbox_Id_Locator));
            if (!base.IsElementSelectedById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_StudyPlanResults_Checkbox_Id_Locator))
            {
                //Enable Study Plan Results Permission
                base.SelectCheckBoxById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_StudyPlanResults_Checkbox_Id_Locator);
            }
            base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_AssignmentDetails_Checkbox_Id_Locator));
            if (!base.IsElementSelectedById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_AssignmentDetails_Checkbox_Id_Locator))
            {
                //Enable Assignment Details Permission
                base.SelectCheckBoxById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_AssignmentDetails_Checkbox_Id_Locator);
            }            
            logger.LogMethodExit("PermissionPreferencesPage","EnablePerformancePermissionPreferences",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Question Analysis Permission Preference
        /// </summary>
        private void EnableQuestionAnalysisPermissionPreference()
        {
            //Enable Question Analysis Permission Preference
            logger.LogMethodEntry("PermissionPreferencesPage",
                "EnableQuestionAnalysisPermissionPreference",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_OthersExpand_Button_Id_Locator));
            //Click on 'Others' Expand Button
            base.ClickButtonById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_OthersExpand_Button_Id_Locator);
            base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_QuestionAnalysis_Checkbox_Id_Locator));
            if (!base.IsElementSelectedById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_QuestionAnalysis_Checkbox_Id_Locator))
            {
                //Enable Question Analysis Permission
                base.SelectCheckBoxById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_QuestionAnalysis_Checkbox_Id_Locator);
            }
            logger.LogMethodExit("PermissionPreferencesPage",
                "EnableQuestionAnalysisPermissionPreference",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Submissions Permission Preferences
        /// </summary>
        private void EnableSubmissionsPermissionPreferences()
        {
            //Enable Submissions Permission Preferences
            logger.LogMethodEntry("PermissionPreferencesPage",
                "EnableSubmissionsPermissionPreferences", 
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element View Student Submission Permission
            base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_ViewStudentSubmission_Checkbox_Id_Locator));
            if (!base.IsElementSelectedById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_ViewStudentSubmission_Checkbox_Id_Locator))
            {
                //Enable View Student Submission Permission
                base.SelectCheckBoxById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_ViewStudentSubmission_Checkbox_Id_Locator);
            }
            //Wait for the element Download and Print Student Submission Permission
            base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_DownloadPrintStudentSubmission_Checkbox_Id_Locator));
            if (!base.IsElementSelectedById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_DownloadPrintStudentSubmission_Checkbox_Id_Locator))
            {
                //Enable Download and Print Student Submission Permission
                base.SelectCheckBoxById(PermissionPreferencesPageResource.
                PermissionPreferencesPage_Resource_DownloadPrintStudentSubmission_Checkbox_Id_Locator);
            }
            logger.LogMethodExit("PermissionPreferencesPage",
                "EnableSubmissionsPermissionPreferences",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable 'Schedule Activities' Permission Preferences.
        /// </summary>
        public void EnableScheduleActivitiesPermission()
        {
            //Enable 'Schedule Activities' Permission Preferences
            logger.LogMethodEntry("PermissionPreferencesPage",
                "EnableScheduleActivitiesPermission",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(PermissionPreferencesPageResource.
                    PermissionPreferencesPage_Resource_ScheduleActivities_Permission_Id_Locator));
                if (!base.IsElementSelectedById(PermissionPreferencesPageResource.
                    PermissionPreferencesPage_Resource_ScheduleActivities_Permission_Id_Locator))
                {
                    //Enable 'Schedule Activities' Permission Preferences
                    base.SelectCheckBoxById(PermissionPreferencesPageResource.
                    PermissionPreferencesPage_Resource_ScheduleActivities_Permission_Id_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("PermissionPreferencesPage",
                "EnableScheduleActivitiesPermission",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
