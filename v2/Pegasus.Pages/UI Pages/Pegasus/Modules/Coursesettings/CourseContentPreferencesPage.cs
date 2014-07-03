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
    ///  This class handles Pegasus Course Content Preferences Page Actions
    /// </summary>
    public class CourseContentPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(CourseContentPreferencesPage));

        /// <summary>
        /// Set The Content Preferences
        /// </summary>
        public void SetTheContentPreferences()
        {
            //Set The Content Preferences
            logger.LogMethodEntry("CourseContentPreferencesPage", "SetTheContentPreferences",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the Content Link
                this.ClickOnContentLink();
                //Select the Main Preferences
                new CourseCopyPreferencesPage().SelectTheMainPreferencesFrame();
                //Selects the Content Preferences
                this.ContentPreferencesOptions();
                //Save the Preferences
                new ActivitiesPreferencesPage().SaveActivityPreferences();
            }
            catch ( Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseContentPreferencesPage", "SetTheContentPreferences",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Sets Content Preferences Options
        /// </summary>
        private void ContentPreferencesOptions()
        {
            //Sets Content Preferences Options
            logger.LogMethodEntry("CourseContentPreferencesPage", "ContentPreferencesOptions",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for "Enable Assign/Unassign" option
            base.WaitForElement(By.Id(CourseContentPreferencesPageResource.
                CourseContentPreferencesPage_Checkbox_EnableAssignUnassign_Id_Locator));
            if ( !(base.GetWebElementPropertiesById(CourseContentPreferencesPageResource.
                CourseContentPreferencesPage_Checkbox_EnableAssignUnassign_Id_Locator).Selected) )
            {
                IWebElement getAssignUnAssign=base.GetWebElementPropertiesById
                    (CourseContentPreferencesPageResource.
                CourseContentPreferencesPage_Checkbox_EnableAssignUnassign_Id_Locator);
                //Clicks on the Enable Assign / Unassign option
                base.ClickByJavaScriptExecutor(getAssignUnAssign);
            }            
            //"Display only to selected students/groups"
            if ( !(base.GetWebElementPropertiesById(CourseContentPreferencesPageResource.
                CourseContentPreferencesPage_Checkbox_DisplayOnlyToSelectedStudents_Id_Locator)
                .Selected) )
            {
                IWebElement getSelectOnlyStudent=base.GetWebElementPropertiesById
                    (CourseContentPreferencesPageResource.
                CourseContentPreferencesPage_Checkbox_DisplayOnlyToSelectedStudents_Id_Locator);
                base.ClickByJavaScriptExecutor(getSelectOnlyStudent);
            }
            //Click the Hide my course content
            if (!(base.GetWebElementPropertiesById(CourseContentPreferencesPageResource.
                CourseContentPreferences_Page_HideCourse_Content_Id_Locator)
                .Selected))
            {
                IWebElement getHideCourseContent=base.GetWebElementPropertiesById
                    (CourseContentPreferencesPageResource.
                CourseContentPreferences_Page_HideCourse_Content_Id_Locator);
                base.ClickByJavaScriptExecutor(getHideCourseContent);
            }
            logger.LogMethodExit("CourseContentPreferencesPage", "ContentPreferencesOptions",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Content Link
        /// </summary>
        private void ClickOnContentLink()
        {
            //Click on the Content Link
            logger.LogMethodEntry("CourseContentPreferencesPage", "ClickOnContentLink",
                base.isTakeScreenShotDuringEntryExit);
            //Select the Main Preferences
            new CourseCopyPreferencesPage().SelectTheMainPreferencesFrame();
            //Wait for the Content Link
            base.WaitForElement(By.Id(CourseContentPreferencesPageResource.
                CourseContentPreferencesPage_Link_Content_Id_Locator));
            IWebElement getContentLink=base.GetWebElementPropertiesById
                (CourseContentPreferencesPageResource.
                CourseContentPreferencesPage_Link_Content_Id_Locator);
            //Click on the Content Link
            base.ClickByJavaScriptExecutor(getContentLink);
            logger.LogMethodExit("CourseContentPreferencesPage", "ClickOnContentLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set The Content Preferences For ContainerCourse
        /// </summary>
        public void SetTheContentPreferencesForContainerCourse()
        {
            //Set The Content Preferences For ContainerCourse
            logger.LogMethodEntry("CourseContentPreferencesPage",
                "SetTheContentPreferencesForContainerCourse",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the Content Link
                this.ClickOnContentLink();
                //Select the Main Preferences
                new CourseCopyPreferencesPage().SelectTheMainPreferencesFrame();
                //Click the Hide my course content
                if (!(base.GetWebElementPropertiesById(CourseContentPreferencesPageResource.
                    CourseContentPreferences_Page_HideCourse_Content_Id_Locator)
                    .Selected))
                {
                    base.ClickCheckBoxById(CourseContentPreferencesPageResource.
                    CourseContentPreferences_Page_HideCourse_Content_Id_Locator);
                }
                //Save the Preferences
                new ActivitiesPreferencesPage().SaveActivityPreferences();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CourseContentPreferencesPage",
                "SetTheContentPreferencesForContainerCourse",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
