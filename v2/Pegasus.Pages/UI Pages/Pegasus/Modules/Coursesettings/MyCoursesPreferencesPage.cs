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
    ///  This class handles Pegasus My Courses Preferences Page Actions
    /// </summary>
    public class MyCoursesPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(MyCoursesPreferencesPage));

        /// <summary>
        /// Sets 'My Courses' Preferences
        /// </summary>
        public void SetMyCoursesPreferences()
        {
            //Set My Courses Preferences
            logger.LogMethodEntry("MyCoursesPreferencesPage", "SetMyCoursesPreferences",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the My Courses Link
                this.ClickOnMyCoursesLink();
                //Select the Main Preferences frame
                new CourseCopyPreferencesPage().SelectTheMainPreferencesFrame();
                //Enables My Courses Preferences Options
                this.MyCoursesPreferencesOptions();
                //Save the Preferences
                new ActivitiesPreferencesPage().SaveActivityPreferences();
            }
            catch ( Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MyCoursesPreferencesPage", "SetMyCoursesPreferences",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enables My Courses Preferences Options
        /// </summary>
        private void MyCoursesPreferencesOptions()
        {
            //Selects My Courses Preferences Options
            logger.LogMethodEntry("MyCoursesPreferencesPage", "MyCoursesPreferencesOptions",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the "Automatically enroll all students" checkbox
            base.WaitForElement(By.Id(MyCoursesPreferencesPageResource.
                MyCoursesPreferencesPage_CheckBox_AutomaticallyEnrollAllStudents_Id_Locator));
            if ( !(base.GetWebElementPropertiesById(MyCoursesPreferencesPageResource.
                MyCoursesPreferencesPage_CheckBox_AutomaticallyEnrollAllStudents_Id_Locator)
                .Selected) )
            {
                IWebElement getEnrollStudent=base.GetWebElementPropertiesById
                    (MyCoursesPreferencesPageResource.
                    MyCoursesPreferencesPage_CheckBox_AutomaticallyEnrollAllStudents_Id_Locator);
                base.ClickByJavaScriptExecutor(getEnrollStudent);
            }
            //Wait for the "Group Creation and Enrollment for the class" 
            //checkbox to be enabled for 2 Secs
            Thread.Sleep(Convert.ToInt32(MyCoursesPreferencesPageResource.
                MyCoursesPreferencesPage_Wait_Time));
            if ( !(base.GetWebElementPropertiesById(MyCoursesPreferencesPageResource.
                MyCoursesPreferencesPage_CheckBox_GroupCreationAndEnrollmentForClass_Id_Locator)
                .Selected) )
            {
                IWebElement getGroupCreation=base.GetWebElementPropertiesById
                    (MyCoursesPreferencesPageResource.
                MyCoursesPreferencesPage_CheckBox_GroupCreationAndEnrollmentForClass_Id_Locator);
                base.ClickByJavaScriptExecutor(getGroupCreation);
            }
            logger.LogMethodExit("MyCoursesPreferencesPage", "MyCoursesPreferencesOptions",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Clicks on the 'My Courses' Link
        /// </summary>
        private void ClickOnMyCoursesLink()
        {
            //Click on the My Courses Link
            logger.LogMethodEntry("MyCoursesPreferencesPage", "ClickOnMyCoursesLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Select the Main Preferences frame
            new CourseCopyPreferencesPage().SelectTheMainPreferencesFrame();
            //Wait for the element
            base.WaitForElement(By.Id(MyCoursesPreferencesPageResource.
                MyCoursesPreferencesPage_Link_MyCourses_Id_Locator));
            IWebElement getMyCourseLink=base.GetWebElementPropertiesById
                (MyCoursesPreferencesPageResource.
                MyCoursesPreferencesPage_Link_MyCourses_Id_Locator);
            //Click on the My Courses Link
            base.ClickByJavaScriptExecutor(getMyCourseLink);
            logger.LogMethodExit("MyCoursesPreferencesPage", "ClickOnMyCoursesLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
