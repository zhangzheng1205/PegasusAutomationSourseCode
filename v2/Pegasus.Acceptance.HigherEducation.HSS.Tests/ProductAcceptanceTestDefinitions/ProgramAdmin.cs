using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducation.HSS.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details of Program Admin Actions
    /// Resposible to handle template, section, user and user
    /// enrollment in sections.
    /// </summary>
    [Binding]
    public class ProgramAdmin : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ProgramAdmin));

        /// <summary>
        /// Click on the Add Sections Link.
        /// </summary>
        [When(@"I click on Add Sections link from the Program Administration page")]
        public void ClickOnAddSectionsLink()
        {
            //Click on 'Add Sections' Link
            Logger.LogMethodEntry("ProgramAdmin", "ClickOnAddSectionsLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Add New Sections Link
            new ManageTemplatePage().ClickOnAddNewSectionsLink();
            Logger.LogMethodExit("ProgramAdmin", "ClickOnAddSectionsLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create New Section.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I create Section from ""(.*)"" Template as a Program Admin")]
        public void CreateSectionAsProgramAdmin(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Create New Section
            Logger.LogMethodEntry("ProgramAdmin", "CreateSectionAsProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
            //Create New Section 
            new AddNewSectionPage().CreateNewSection(courseTypeEnum);
            Logger.LogMethodExit("ProgramAdmin", "CreateSectionAsProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Section at Enrollment Tab.
        /// Author:Rashmi Shetty.
        /// Date:6/Apr/2016.
        /// </summary>
        /// <param name="courseTypeEnum">Section Name.</param>
        [When(@"I search the section of ""(.*)"" at Enrollments Tab")]
        public void SearchSectionAtEnrollments(Course.CourseTypeEnum courseTypeEnum)
        {
            // Search Section at Enrollment Tab
            Logger.LogMethodEntry("ProgramAdmin", "SearchSectionAtEnrollments",
                base.IsTakeScreenShotDuringEntryExit);
            // Search Section at Enrollment Tab
            new EnrollmentMainPage().SearchSectionAtEnrollmentTab(courseTypeEnum);
            Logger.LogMethodExit("ProgramAdmin", "SearchSectionAtEnrollments",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Student at Enrollment Tab.
        /// Author:Rashmi Shetty.
        /// Date:6/Apr/2016.
        /// </summary>
        /// <param name="StudentType">This is the type of student.</param>
        /// <param name="userTypeEnum">This is student enum type.</param>
        [When(@"I select ""(.*)"" and ""(.*)""student user for enrollment")]
        public void SelectStudentUserForEnrollment(string StudentType,
              User.UserTypeEnum userTypeEnum)
        {
            // Select Student at Enrollment Tab
            Logger.LogMethodEntry("ProgramAdmin", "SelectStudentUserForEnrollment",
                 base.IsTakeScreenShotDuringEntryExit);
            //Get the user of the given type from Memory Data Store
            User user = new LoginContentPage().
                SelectUserDetailsBaesdOnScenerio(StudentType, userTypeEnum);
            //Store Expected UserName in String
            string userName = user.LastName + " " + user.FirstName;
            // Select Student at Enrollment Tab
            new EnrollmentMainPage().SelectUserForEnrollment(userName, userTypeEnum.ToString());
            Logger.LogMethodExit("ProgramAdmin", "SelectStudentUserForEnrollment",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Instructor at Enrollment Tab.
        /// Author:Rashmi Shetty.
        /// Date:7/Apr/2016.
        /// </summary>
        /// <param name="userTypeEnum">This is instructor enum type.</param>
        [When(@"I select ""(.*)"" teacher user for enrollment")]
        public void SelectTeacherUserForEnrollment(User.UserTypeEnum userTypeEnum)
        {
            //  Select Instructor at Enrollment Tab
            Logger.LogMethodEntry("ProgramAdmin", "SelectTeacherUserForEnrollment",
                 base.IsTakeScreenShotDuringEntryExit);
            //Get the user of the given type from Memory Data Store
            User user = User.Get(userTypeEnum);
            //Store Expected UserName in String
            string userName = user.LastName + " " + user.FirstName;
            //  Select Instructor at Enrollment Tab
            new EnrollmentMainPage().SelectUserForEnrollment(userName, userTypeEnum.ToString());
            Logger.LogMethodExit("ProgramAdmin", "SelectTeacherUserForEnrollment",
              base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
