using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.NovaNET.Tests.Definitions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles User Enrollment actions
    /// </summary>
    [Binding]
    public class UserEnrollment : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(UserEnrollment));

        /// <summary>
        ///Select Course To Enroll Users
        /// </summary>
        /// <param name="courseTypeEnum">This is Course 
        /// Type Enum.</param>
        [When(@"I select the created ""(.*)"" course")]
        public void SelectCourseToEnrollUsers(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("UserEnrollment", 
                "SelectCourseToEnrollUsers",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch course name from memory
            Course course = Course.Get(courseTypeEnum);
            //Selection of course in right frame
            new ManageCoursesPage().SelectCourse(course.Name);
            Logger.LogMethodExit("UserEnrollment", 
                "SelectCourseToEnrollUsers",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select WS user from the left frame.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I select the ""(.*)"" user")]
        public void SelectWsUserInLeftFrame(
            User.UserTypeEnum userTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("UserEnrollment",
                "SelectWSUserInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch user name from memory
            User user = User.Get(userTypeEnum);
            // User search in left frame
            new AdminToolPage().UserSearch(user.Name);
            //Select User
            new ManageUsersPage().SelectUser(user.Name);
            Logger.LogMethodExit("UserEnrollment", 
                "SelectWSUserInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enroll user to the Course.
        /// </summary>
        /// <param name="userTypeEnum">This is 
        /// User Type Enum.</param>
        [When(@"I enroll the ""(.*)"" in the selected course")]
        public void EnrollTheUserInTheCourse(
            User.UserTypeEnum userTypeEnum)
        {
            //Enroll User to Course
            Logger.LogMethodEntry("UserEnrollment", 
                "EnrollTheUserInTheCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Enroll user to the course
            new AdminToolPage().EnrollUserInCourse(userTypeEnum);
            Logger.LogMethodExit("UserEnrollment", 
                "EnrollTheUserInTheCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// See The Enrolled User In The Manage Courses Frame.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should see the enrolled ""(.*)"" in the Manage Courses frame")]
        public void CheckEnrolledUserInsideCourse(
            User.UserTypeEnum userTypeEnum)
        {
            //See The Enrolled User Inside The Course
            Logger.LogMethodEntry("UserEnrollment", 
                "CheckEnrolledUserInsideCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch User's Last Name From Memory
            User user = User.Get(userTypeEnum);
            //Asert The Last Name Of The User
            Logger.LogAssertion("VerifyUserEnrollment",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(user.LastName,
            new UserEnrollmentPage().
            GetEnrolledUserLastName(user.LastName)));
            Logger.LogMethodExit("UserEnrollment", 
                "CheckEnrolledUserInsideCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This function verifies the availability of the master library in right frame.
        /// </summary>
        /// <param name="classTypeEnum">This is the class type enum.</param>
        [When(@"I select the ""(.*)"" class")]
        public void SelectMasterLibraryClass(
            Class.ClassTypeEnum classTypeEnum)
        {
            //Select master library class in right frame
            Logger.LogMethodEntry("UserEnrollment", "SelectMasterLibraryClass",
                base.isTakeScreenShotDuringEntryExit);
            //Select Master library class on the right frame
            new OrgAdminEnrollClassesPage().
                SelectMasterLibraryClass(classTypeEnum);
            Logger.LogMethodExit("UserEnrollment", "SelectMasterLibraryClass",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select users under the user frame in Enrollment.
        /// </summary>
        /// <param name="userTypeEnum">This is the user type enum.</param>
        [When(@"I select the ""(.*)"" under User Frame")]
        public void SelectUserInLeftFrame(User.UserTypeEnum userTypeEnum)
        {
            //Select users in left frame
            Logger.LogMethodEntry("UserEnrollment", "SelectUserInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
            // Get the user
            User user = User.Get(userTypeEnum);
            // Select the user in left frame
            new OrgAdminUserEnrollmentPage().SelectUserInLeftFrame(user.Name);
            Logger.LogMethodExit("UserEnrollment", "SelectUserInLeftFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Enroll button in middle frame.
        /// </summary>
        [When(@"I select the Enroll button")]
        public void SelectEnrollButton()
        {
            //Select enroll button
            Logger.LogMethodEntry("UserEnrollment", "SelectEnrollButton",
                base.isTakeScreenShotDuringEntryExit);
            // Click on enroll button in middle frame
            new OrgEnrollmentPage().SelectEnrollButton();
            Logger.LogMethodExit("UserEnrollment", "SelectEnrollButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check user enrolled successfully message.
        /// </summary>
        [Then(@"I should see the successfull message 'Users enrolled successfully'")]
        public void CheckEnrollmentSuccessfullMessage()
        {
            //Select enroll button
            Logger.LogMethodEntry("UserEnrollment", 
                "CheckEnrollmentSuccessfullMessage",
                base.isTakeScreenShotDuringEntryExit);
            //Assert we have correct message displayed
            Logger.LogAssertion("VerifySuccessMessageDisplay",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true, new OrgAdminUserEnrollmentPage()
                    .GetSuccessfulMessageText().Contains(UserEnrollmentResource.
                    UserEnrollment_Enrollment_SuccessMessage_Text)));
            Logger.LogMethodExit("UserEnrollment", 
                "CheckEnrollmentSuccessfullMessage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }

    }
}
