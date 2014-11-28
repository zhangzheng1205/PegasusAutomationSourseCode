using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducation.HSS.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of User Enrollment in Pegasus
    /// </summary>
    [Binding]
    public class CourseSpaceEnrollments : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CourseSpaceEnrollments));


        /// <summary>
        /// Enroll SMS Instructor in course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I enroll SMS Instructor in ""(.*)""")]
        public void EnrollSmsInstructorInCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("UserEnrollment", "EnrollSmsInstructorInCourse",
                base.IsTakeScreenShotDuringEntryExit);
            // Click 'Enroll In a Course' Button 
            new HEDGlobalHomePage().ClickOnEnrollInCourseButton();
            // To Enroll Instructor depending on the course
            new SelfEnrollmentPage().SmsStudentEnrolledInCourse(courseTypeEnum);
            Logger.LogMethodExit("UserEnrollment", "EnrollSmsInstructorInCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify section displays in global home page.
        /// </summary>
        [Then(@"I should see enrolled ""(.*)"" Section in Global Home Page")]
        public void DisplayOfEnrolledSectionInGlobalHomePage(Course.CourseTypeEnum courseTypeEnum)
        {
            //Section Display in Global Home Page
            Logger.LogMethodEntry("UserEnrollment",
                "DisplayOfEnrolledSectionInGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            bool isCourseVisibleInGlobalHomePage = new HEDGlobalHomePage().
                   GetCoursePresentInGlobalHomePage().Contains(course.SectionName);
            //Assert section displays in global home page           
            Logger.LogAssertion("VerifySmsStudentEnrollInCourse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue(isCourseVisibleInGlobalHomePage));
            Logger.LogMethodExit("UserEnrollment",
                "DisplayOfEnrolledSectionInGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enroll SMS student in course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I enroll SMS Student in ""(.*)""")]
        public void EnrollSmsStudentInCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("UserEnrollment", "EnrollSmsStudentInCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert student Help Text Window Closed
            new StudentHelpTextPage().ManageStudentHelpTextWindow();
            //Closing the Announcement(s)
            new AnnouncementPopUpLightBoxUXPage().CloseAnnouncementPopUp();
            // Click 'Enroll In a Course' Button 
            new HEDGlobalHomePage().ClickOnEnrollInCourseButton();
            // To Enroll student depending on the course
            new SelfEnrollmentPage().SmsStudentEnrolledInCourse(courseTypeEnum);
            Logger.LogMethodExit("UserEnrollment", "EnrollSmsStudentInCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseTypeEnum"></param>
        [Then(@"I should see enrolled ""(.*)"" Section course in Global Home Page")]
        public void VerifyTheDisplayOfEnrolledSectionCourseInGlobalHomePage
            (Course.CourseTypeEnum courseTypeEnum)
        {
            //Section Display in Global Home Page
            Logger.LogMethodEntry("UserEnrollment",
                "VerifyTheDisplayOfEnrolledSectionCourseInGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            bool isCourseVisibleInGlobalHomePage = new HEDGlobalHomePage().
                   IsCoursePresentInGlobalHomePage(course.SectionName);
            //Assert section displays in global home page           
            Logger.LogAssertion("VerifySmsStudentEnrollInCourse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.IsTrue(isCourseVisibleInGlobalHomePage));
            Logger.LogMethodExit("UserEnrollment",
                "VerifyTheDisplayOfEnrolledSectionCourseInGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
