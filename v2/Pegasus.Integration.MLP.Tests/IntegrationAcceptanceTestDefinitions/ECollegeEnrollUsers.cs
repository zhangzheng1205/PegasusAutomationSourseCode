using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MLP.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class handle Enrollment of 
    /// ECollege users into ECollege Course.
    /// </summary>
    [Binding]
   public class ECollegeEnrollUsers:PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger =
            Logger.GetInstance(typeof(ECollegeEnrollUsers));

        /// <summary>
        /// Enroll ECollge User into Course.
        /// </summary>
        /// <param name="userTypeEnum"> This is user Type Enum.</param>
        /// <param name="courseTypeEnum">This is Course type Enum.</param>
        [When(@"I enroll ""(.*)"" to ""(.*)"" course of term")]
        public void EnrollToECollegeCourse(User.UserTypeEnum userTypeEnum,
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Enroll user into course
            logger.LogMethodEntry("ECollegeEnrollUsers", "EnrollToECollegeCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Instance of Manage Users Content Page to search users
            new ManageUsersContentPage().SearchECollegeUsers(userTypeEnum);
            //Instance of Enroll CourseTop to enroll users
            new EnrollCourseTop().EnrollUserToECollegeCourse(userTypeEnum, courseTypeEnum);
            logger.LogMethodExit("ECollegeEnrollUsers", "EnrollToECollegeCourse",
                base.IsTakeScreenShotDuringEntryExit);
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
