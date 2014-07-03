using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MLP.Tests.
    IntegrationAcceptanceTestDefinitions
{
    [Binding]
    public class ECollegeCourseEnrollment : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ECollegeCourseEnrollment));

        /// <summary>
        /// Associate Course To Product Through ECollege Integration.
        /// </summary>
        [When(@"I associate the course to product by selecting ""(.*)"" delivery preference")]
        public void AssociateTheCourseToPegasusProductBySelectingECollegeDeliveryMode
            (String deliveryMode)
        {
            Logger.LogMethodEntry("ECollegeCourseEnrollment",
                "AssociateTheCourseToPegasusProductBySelectingECollegeDeliveryMode",
                base.isTakeScreenShotDuringEntryExit);
            //Click Program Course Add Button
            new AddButtonPage().ClickProgramCoursesAddButton();
            //Click Enrollment Mode Option
            new AdminToolPage().ClickAddNewCourseEnrollmentModeOption();
            //Create Page Object
            CourseEnrollmentModePage courseEnrollmentModePage =
                new CourseEnrollmentModePage();
            //Save Course Enrollment Mode
            courseEnrollmentModePage.SelectEnrollmentMode();
            //Select Delivery Checbox
            courseEnrollmentModePage.SelectDeliveryPreference((
                    CourseEnrollmentModePage.DeliveryModeTypeEnum)
                    Enum.Parse(typeof(CourseEnrollmentModePage.DeliveryModeTypeEnum),
                    deliveryMode));
            //Click Enrollement Save Button
            courseEnrollmentModePage.ClickEnrollmentSaveButton();
            Logger.LogMethodExit("ECollegeCourseEnrollment",
                "AssociateTheCourseToPegasusProductBySelectingECollegeDeliveryMode",
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
