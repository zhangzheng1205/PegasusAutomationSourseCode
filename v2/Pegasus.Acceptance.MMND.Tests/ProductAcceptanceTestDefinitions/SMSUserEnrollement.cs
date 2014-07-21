using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MMND.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    ///  This class handles SMS User Enrollment related actions. 
    /// </summary>
    [Binding]
    public class SMSUserEnrollement : PegasusBaseTestFixture
    {

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(SMSUserEnrollement));

        /// <summary>
        /// Select Enroll In Another Course Option.
        /// </summary>
        [When(@"I select enroll in a course option")]
        public void SelectEnrollInAnotherCourseOption()
        {
            //Select Enroll In Another Course Option
            Logger.LogMethodEntry("SMSUserEnrollement", "SelectEnrollInAnotherCourseOption",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Enroll In Another Course Button
            new UserLayoutRootNodePage().ClickOnEnrollInAnotherCourseButton();
            Logger.LogMethodExit("SMSUserEnrollement", "SelectEnrollInAnotherCourseOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Section Id.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I enter the ""(.*)"" section id")]
        public void EnterTheSectionId(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Enter Section Id
            Logger.LogMethodEntry("SMSUserEnrollement", "EnterTheSectionId",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course Id From Memeory
            Course course = Course.Get(courseTypeEnum);
            //Enter Section Id
            new RegisterPage().EnterSectionId(course.ECollegeIntegrationId);
            Logger.LogMethodExit("SMSUserEnrollement", "EnterTheSectionId",
                base.isTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Verify Section Enrollement.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [Then(@"I should see the enrolled ""(.*)"" section")]
        public void VerifySectionEnrollement(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify the Username Text Box
            Logger.LogMethodEntry("SMSUserEnrollement", "VerifySectionEnrollement",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course Id From Memeory
            Course course = Course.Get(courseTypeEnum);
            //Verify The UserName Text
            Logger.LogAssertion("VerifySection",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(
                new RegisterPage().IsSectionNameDisplayed(course.Name)));
            Logger.LogMethodExit("SMSUserEnrollement", "VerifySectionEnrollement",
             base.isTakeScreenShotDuringEntryExit);
            
        }
    }
}
