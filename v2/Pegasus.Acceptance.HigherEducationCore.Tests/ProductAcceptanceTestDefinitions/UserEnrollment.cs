using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
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
        /// Enroll SMS student in course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum.</param>
        [When(@"I enroll SMS Student in ""(.*)""")]
        public void EnrollSMSStudentInCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Add Course From Search Catalog
            Logger.LogMethodEntry("UserEnrollment",
                "EnrollSMSStudentInCourse",
                base.IsTakeScreenShotDuringEntryExit);            
            //Assert student Help Text Window Closed
            new StudentHelpTextPage().ManageStudentHelpTextWindow();
            //Closing the Announcement(s)
            new AnnouncementPopUpLightBoxUXPage().CloseAnnouncementPopUp();
            // Click 'Enroll In a Course' Button 
            new HEDGlobalHomePage().ClickOnEnrollInCourseButton();
            // To Enroll student depending on the course
            new SelfEnrollmentPage().SmsStudentEnrolledInCourse(courseTypeEnum);
            Logger.LogMethodExit("UserEnrollment",
                "EnrollSMSStudentInCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify section displays in global home page.
        /// </summary>
        [Then(@"I should see enrolled Section in Global Home Page")]
        public void DisplayOfEnrolledSectionInGlobalHomePage()
        {
            //Section Display in Global Home Page
            Logger.LogMethodEntry("UserEnrollment", 
                "DisplayOfEnrolledSectionInGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.ProgramCourse);
            //Assert section displays in global home page
            Logger.LogAssertion("VerifySmsStudentEnrollInCourse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(true,
                    new HEDGlobalHomePage().GetCoursePresentInGlobalHomePage().
                    Contains(course.SectionName)));
            Logger.LogMethodExit("UserEnrollment",
                "DisplayOfEnrolledSectionInGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To verify InstructorCourse displays in global home page.
        /// </summary>
        [Then(@"I should see enrolled InstructorCourse in Global Home Page")]
        public void DisplayOfEnrolledInstructorCourseInGlobalHomePage()
        {
            //InstructorCourse Display in Global Home Page
            Logger.LogMethodEntry("UserEnrollment",
               "DisplayOfEnrolledInstructorCourseInGlobalHomePage",
               base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(Course.CourseTypeEnum.InstructorCourse);
            //Assert course displays in global home page
            Logger.LogAssertion("VerifySmsStudentEnrollInCourse", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(true,
                    new HEDGlobalHomePage().GetCoursePresentInGlobalHomePage().
                    Contains(course.Name)));
            Logger.LogMethodExit("UserEnrollment",
                "DisplayOfEnrolledInstructorCourseInGlobalHomePage",
                  base.IsTakeScreenShotDuringEntryExit);
        }

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
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch course name from memory
            Course course = Course.Get(courseTypeEnum);
            //Selection of course in right frame
            new ManageCoursesPage().SelectCourse(course.Name);
            Logger.LogMethodExit("UserEnrollment", "EnrollWSInstructorInCourse",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch user name from memory
            User user = User.Get(userTypeEnum);
            // User search in left frame
            new AdminToolPage().UserSearch(user.Name);
            //Select user
            new ManageUsersPage().SelectUser(user.Name);
            Logger.LogMethodExit("UserEnrollment", "SelectWSUserInLeftFrame",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Enroll user to the course
            new AdminToolPage().EnrollUserInCourse(userTypeEnum);
            Logger.LogMethodExit("UserEnrollment", 
                "EnrollTheUserAsTeacherInTheCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Student As Promote Teacher Assistent
        /// </summary>
        /// <param name="userStudentTypeEnum">This is Student typ Enum.e</param>
        /// <param name="userTeacherAssistentType">This is Teaching Assistent Type Enum.</param>
        [When(@"I select the ""(.*)"" as promoted ""(.*)"" in SMS Instructor")]
        public void SelectTheStudentAsPromotedTa(User.UserTypeEnum userStudentTypeEnum,
            User.UserTypeEnum userTeacherAssistentType)
        {
            //Select The Student As Promote Teacher Assistent
            Logger.LogMethodEntry("UserEnrollment", "SelectTheStudentAsPromotedTa",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch user name from memory
            User user = User.Get(userStudentTypeEnum);  
            //Click Roster Cmenu In SMSInstructor
            new GBRosterGridUXPage().
                ClickRosterCmenuInSMSInstructor(user.Name);
            //Store The TA Details In Memory
            new GBRosterGridUXPage().
                StoreTheTADetailsInMemory(userStudentTypeEnum,
                userTeacherAssistentType);
            Logger.LogMethodExit("UserEnrollment", "SelectTheStudentAsPromotedTa",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Role As Teaching Assistent.
        /// </summary>
        /// <param name="userRole">This is user role</param>
        [Then(@"I should see the role as ""(.*)""")]
        public void VeriftTheRoleAsTeachingAssistent(String userRole)
        {
            //Verify The Role As Teaching Assistent
            Logger.LogMethodEntry("UserEnrollment", 
                "VeriftTheRoleAsTeachingAssistent",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify UserRole name
            Logger.LogAssertion("VerifyUserRole", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(userRole, new GBRosterGridUXPage().GetUserRoleName()));           
            Logger.LogMethodExit("UserEnrollment",
                "VeriftTheRoleAsTeachingAssistent",
                base.IsTakeScreenShotDuringEntryExit);
        }

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
        /// Verify the Display of enrolled section in Homepage.
        /// </summary>
        /// <param name="courseTypeEnum">This is the course type enum.</param>
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

        /// <summary>
        /// This method is called before execution of test.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// This function is called after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
