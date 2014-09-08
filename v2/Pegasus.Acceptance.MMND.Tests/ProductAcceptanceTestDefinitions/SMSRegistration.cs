using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MMND.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles SMS Registration Page Actions
    /// also responsible to create SMS user registeration.
    /// </summary>
    [Binding]
    public class SmsRegistration : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(SmsRegistration));

        /// <summary>
        /// Verify is SMS URL browsed successfully.
        /// </summary>
        [Then(@"I should see the SMS registration URL browsed successfully")]
        public void VerifyIsSmsRegistrationUrlBrowsedSuccessfully()
        {
            //Verify is SMS URL browsed successfully
            Logger.LogMethodEntry("SMSRegistration", "VerifyIsSmsRegistrationUrlBrowsedSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert URL browsed Successfully
            Logger.LogAssertion("VerifyBrowsedURL",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.IsTrue(new ConsentPage().IsAcceptButtonPresent()));
            Logger.LogMethodExit("SMSRegistration", "VerifyIsSmsRegistrationUrlBrowsedSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Register a New SMS User.
        /// </summary>
        /// <param name="userTypeEnum">This is SMS User Type Enum.</param>
        [When(@"I register new SMS user as ""(.*)""")]
        public void RegisterNewSmsUser(User.UserTypeEnum userTypeEnum)
        {
            // Create New SMS User
            Logger.LogMethodEntry("SMSRegistration", "RegisterNewSmsUser",
                base.IsTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.MMNDInstructor:
                    //Click I Accept Button
                    new ConsentPage().ClickIAcceptButtonBySMSAdmin();
                    //submit Access Information 
                    new Reg1Page().EnterSmsUserAccessInformation(userTypeEnum);
                    //Submit Account Information
                    new Reg2Page().EnterSmsUserAccountInformation(userTypeEnum);
                    break;
                case User.UserTypeEnum.MMNDStudent:
                    //Enter Access Code
                    new CourseIdInputPage().EnterAccessCode();
                    //Click I Accept Button
                    new ConsentPage().ClickIAcceptButtonBySMSAdmin();
                    //submit Access Information 
                    new Reg1Page().EnterSmsUserAccessInformationforMmndStudent(userTypeEnum);
                    //Submit Account Information
                    new Reg2Page().EnterSmsUserAccountInformation(userTypeEnum);
                    break;
            }
            Logger.LogMethodExit("SMSRegistration", "RegisterNewSmsUser",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Display of SMS User Create Success Message.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type.</param>
        [Then(@"I should see the Confirmation and Summary for ""(.*)"" registeration")]
        public void DisplayTheConfirmationAndSummaryForSmsUserRegisteration
            (User.UserTypeEnum userTypeEnum)
        {
            // SMS User Created with Confirmation and Summary
            Logger.LogMethodEntry("SMSRegistration",
                "DisplayTheConfirmationAndSummaryForSmsUserRegisteration",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert SMS User Created and Saved in Memory
            Logger.LogAssertion("VerifySMSUserCreated",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(SMSRegistrationResource.
                    SMSRegisteration_ConfirmationandSummary_Window_Title_Name,
                    new ConsentPage().GetPageTitle));
            Logger.LogMethodExit("SMSRegistration",
                "DisplayTheConfirmationAndSummaryForSmsUserRegisteration",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify is SMS Student URL Browsed successfully.
        /// </summary>
        [Then(@"I Should see the SMS Student registration URL browsed successfully")]
        public void VerifyIsSmsStudentRegistrationUrlBrowsedSuccessfully()
        {
            //Verify is SMS Student URL Browsed successfully
            Logger.LogMethodEntry("SMSRegistration",
                "VerifyIsSmsStudentRegistrationUrlBrowsedSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Find Course Button
            Logger.LogAssertion("VerifyFindCourseButton",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.IsTrue(new CourseIdInputPage().
                    IsFindCourseButtonPresent()));
            Logger.LogMethodExit("SMSRegistration",
                "VerifyIsSmsStudentRegistrationUrlBrowsedSuccessfully",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Course Id.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type.</param>
        [When(@"I enter the course id of ""(.*)"" course")]
        public void EnterTheCourseId(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Enter Course Id
            Logger.LogMethodEntry("SMSRegistration", "EnterTheCourseId",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course Id From Memeory
            Course course = Course.Get(courseTypeEnum);
            //Enter Course Id
            new CourseIdInputPage().EnterCourseId(course.ECollegeIntegrationId);
            Logger.LogMethodExit("SMSRegistration", "EnterTheCourseId",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Log In Now Button.
        /// </summary>
        [When(@"I login as MMNDStudent")]
        public void LoginAsMmndStudent()
        {
            //Click On Log In Now Button
            Logger.LogMethodEntry("SMSRegistration", "LoginAsMmndStudent",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Log In Now Button
            new Reg3Page().ClickOnLogInNowButton();
            Logger.LogMethodExit("SMSRegistration", "LoginAsMmndStudent",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Course .
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type enum.</param>
        [Then(@"I should the enrolled ""(.*)"" course")]
        public void VerifyTheEnrolledCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify the Enrolled Course
            Logger.LogMethodEntry("SMSRegistration", "VerifyTheEnrolledCourse",
               base.IsTakeScreenShotDuringEntryExit);
            //Get Course Id From Memeory
            Course course = Course.Get(courseTypeEnum);
            //Assert Course
            Logger.LogAssertion("VerifyCourseName",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.IsTrue(new UserLayoutRootNodePage().
                    IsCourseNameDisplayed(course.Name)));
            Logger.LogMethodExit("SMSRegistration", "VerifyTheEnrolledCourse",
           base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
