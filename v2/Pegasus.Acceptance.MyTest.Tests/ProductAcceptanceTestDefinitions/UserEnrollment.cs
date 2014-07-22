using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyTest.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of User Enrollment in Pegasus
    /// </summary>
    [Binding]
    public class UserEnrollment : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(UserEnrollment));

        /// <summary>
        /// Enroll WS instructor in course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I select the created ""(.*)"" course")]
        public void EnrollWsInstructorInCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("UserEnrollment", "EnrollWSInstructorInCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch course name from memory
            Course course = Course.Get(courseTypeEnum);
            //Selection of course in right frame
            new ManageCoursesPage().SelectCourse(course.Name);
            Logger.LogMethodExit("UserEnrollment", "EnrollWSInstructorInCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select WS user from the left frame.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When("I select the \"(.*)\"")]
        public void SelectWsUserInLeftFrame(
            User.UserTypeEnum userTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("UserEnrollment", "SelectWSUserInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch user name from memory
            User user = User.Get(userTypeEnum);
            // User search in left frame
            new AdminToolPage().UserSearch(user.Name);
            //Select user
            new ManageUsersPage().SelectUser(user.Name);
            Logger.LogMethodExit("UserEnrollment", "SelectWSUserInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enroll user to the master course.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When("I enrolled the \"(.*)\" in the Master course")]
        public void EnrollTheUserAsTeacherInTheCourse(
            User.UserTypeEnum userTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("UserEnrollment",
                "EnrollTheUserAsTeacherInTheCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Enroll user to the course
            new AdminToolPage().EnrollUserInCourse(userTypeEnum);
            Logger.LogMethodExit("UserEnrollment",
                "EnrollTheUserAsTeacherInTheCourse",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
