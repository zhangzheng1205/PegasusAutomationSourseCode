using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
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
        /// Create Template as a Program Admin.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I create Template using ""(.*)"" course as a program admin")]
        public void CreateNewTemplateAsProgramAdmin(
             Course.CourseTypeEnum courseTypeEnum)
        {
            //Create New Template
            Logger.LogMethodEntry("ProgramAdmin", "CreateNewTemplateAsTheProgramAdmin",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Create New Template 
            new ManageTemplatePage().CreatTemplate(course.Name);
            Logger.LogMethodExit("ProgramAdmin", "CreateNewTemplateAsTheProgramAdmin",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Template in Active State.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I verify the ""(.*)"" course Template for AssignedToCopy state")]
        public void TemplateInAssignedToCopyState(
            Course.CourseTypeEnum courseTypeEnum)
        {
            Logger.LogMethodEntry("ProgramAdmin", "TemplateInAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Verify Template in Active State
            new ManageTemplatePage().ApproveInActiveStateOfEntityInProgramAdministration(course.Name);
            Logger.LogMethodExit("ProgramAdmin", "TemplateInAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Template in Active State or not.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [Then(@"I should see the ""(.*)"" course Template to be successfully out of AssignedToCopy state")]
        public void ApproveAssignedToCopyStateForTemplate(
            Course.CourseTypeEnum courseTypeEnum)
        {
            Logger.LogMethodEntry("ProgramAdmin", "ApproveAssignedToCopyStateForTemplate",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Verify Template in Active State or not
            Logger.LogAssertion("VerifyTemplateActiveState",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(false, new ManageTemplatePage().
                GetAssignToCopyStateText(course.Name).Contains(ProgramAdminResource.
                ProgramAdmin_Page_AssignToCopyState_Text_Value)));
            Logger.LogMethodExit("ProgramAdmin", "ApproveAssignedToCopyStateForTemplate",
                base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click on the Add Sections Link.
        /// </summary>
        [When(@"I click on Add Sections link from the Program Administration page")]
        public void ClickOnAddSectionsLink()
        {
            //Click on 'Add Sections' Link
            Logger.LogMethodEntry("ProgramAdmin", "ClickOnAddSectionsLink",
                base.isTakeScreenShotDuringEntryExit);
            //Click on Add New Sections Link
            new ManageTemplatePage().ClickOnAddNewSectionsLink();
            Logger.LogMethodExit("ProgramAdmin", "ClickOnAddSectionsLink",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Create New Section 
            new AddNewSectionPage().CreateNewSection(courseTypeEnum);
            Logger.LogMethodExit("ProgramAdmin", "CreateSectionAsProgramAdmin",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Section in Active State.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I verify the Section created from ""(.*)"" course Template for AssignedToCopy state")]
        public void SectionInAssignedToCopyState(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify Section in Active State
            Logger.LogMethodEntry("ProgramAdmin", "SectionInAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Approve Section in Active State
            new ManageTemplatePage().ApproveInActiveStateOfEntityInProgramAdministration(
                course.SectionName);
            Logger.LogMethodExit("ProgramAdmin", "SectionInAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Cmenu of Section or Template.
        /// </summary>
        /// <param name="cMenuOption">This is Cmenu option.</param>
        [Then(@"I click the ""(.*)"" c-menu option")]
        [When(@"I click the ""(.*)"" option")]
        [When(@"I click the ""(.*)"" c-menu option")]
        public void ClickOnCmenuOfSectionOrTemplate(String cMenuOption)
        {
            //Click on Cmenu of Section or Template
            Logger.LogMethodEntry("ProgramAdmin", "ClickOnCmenuOfSectionOrTemplate"
                , base.isTakeScreenShotDuringEntryExit);
            //Click on Cmenu of Section or Template
            new ManageTemplatePage().
                ClickOnCmenuOfSectionOrTemplate(cMenuOption);
            Logger.LogMethodExit("ProgramAdmin", "ClickOnCmenuOfSectionOrTemplate"
                , base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// To Get the CopyMyCourseContentCheckBoxStatus
        /// </summary>
        [Then(@"I should see the ""(.*)"" check box as unchecked")]
        public void CopyMyCourseContentCheckBoxStatus()
        {
            Logger.LogMethodEntry("ProgramAdmin",
               "CopyMyCourseContentCheckBoxStatus",
             base.isTakeScreenShotDuringEntryExit);
            // To Verify Checkbox Is Not Selected
            Logger.LogAssertion("CopyMyCourseContentCheckBoxStatus",
                ScenarioContext.Current.ScenarioInfo.Title, ()
               => Assert.IsFalse(new EditCopyTemplatesSectionsPage().CopyMyCourseContentCheckBoxStatus()));
            Logger.LogMethodExit("ProgramAdmin",
           "CopyMyCourseContentCheckBoxStatus",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Searching the template inside the program
        /// </summary>
        [When(@"I search the Template of ""(.*)""")]
        public void SearchTemplateCourse(Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify Section in Active State
            Logger.LogMethodEntry("ProgramAdmin", "SearchTemplateCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Search the passed course
            new ManageTemplatePage().SearchEntityInProgramAdministration(course.Name);

            Logger.LogMethodExit("ProgramAdmin", "SearchTemplateCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save Button click to create course Manage Template section
        /// </summary>
        /// <param name=""></param>
        [When(@"I click SAVE button to Copy as Shared Library")]
        public void ClickToCreateUpdate()
        {
            Logger.LogMethodEntry("ProgramAdmin", "ClickSaveToCreateSharedLibrary",
                base.isTakeScreenShotDuringEntryExit);
            //SaveUpdate method to create or update the course.
            new EditCopyTemplatesSectionsPage().CreateSharedLibrary();

            Logger.LogMethodExit("ProgramAdmin", "ClickSaveToCreateSharedLibrary",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Validate the obtained message on the popup page
        /// </summary>
        [Then(@"I should see the message ""(.*)"" on popup page")]
        public void ToValidateTheMessage(string message)
        {
            Logger.LogMethodEntry("ProgramAdmin",
               "ToValidateTheMessage",
               base.isTakeScreenShotDuringEntryExit);
            //To Verify The Message In Copy as Section Popup
            Logger.LogAssertion("ToValidateTheMessage",
                            ScenarioContext.Current.ScenarioInfo.Title, ()
                           => Assert.IsTrue(new EditCopyTemplatesSectionsPage().ToValidateTheMessageOnPopupPage(message)));
            Logger.LogMethodExit("ProgramAdmin",
            "ToValidateTheMessage",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To search the section
        /// </summary>
        /// <param name="courseTypeEnum"></param>
        [When(@"I search the section of ""(.*)""")]
        public void SearchSection(Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify Section in Active State
            Logger.LogMethodEntry("ProgramAdmin", "SearchSection",
            base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Approve Section in Active State
            new ManageTemplatePage().SearchEntityInProgramAdministration(course.SectionName);
            Logger.LogMethodExit("ProgramAdmin", "SearchSection",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Copying the section from section inside the program
        /// </summary>
        [When(@"I click Copy/Save button to copy")]
        public void ClickonCopySectionButton()
        {
            Logger.LogMethodEntry("ProgramAdmin", "ClickonCopySectionButton",
            base.isTakeScreenShotDuringEntryExit);
            //SaveUpdate method to create or update the course.
            new EditCopyTemplatesSectionsPage().CopySection();
            Logger.LogMethodExit("ProgramAdmin", "ClickonCopySectionButton",
                base.isTakeScreenShotDuringEntryExit);
        }


        ///// <summary>
        ///// click on the copy/save button, during the copy of the template/section as template inside the program 
        ///// </summary>
        [When(@"I click Copy/Save button")]
        public void ClickOnCopySaveButton()
        {
            Logger.LogMethodEntry("ProgramAdmin", "ClickOnCopySaveButton",
                base.isTakeScreenShotDuringEntryExit);
            //SaveUpdate method to create or update the course.
            new EditCopyTemplatesSectionsPage().ClickToCreateUpdate();
            Logger.LogMethodExit("ProgramAdmin", "ClickOnCopySaveButton",
                base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Create section  to validate the section count and give appropriate alert message.
        /// </summary>
        /// <param name="courseTypeEnum"></param>
        /// <param name="count"></param>
        [When(@"I create Section from ""(.*)"" Template with section count as ""(.*)""")]
        public void CreateNewSectionWithCount(Course.CourseTypeEnum courseTypeEnum, int count)
        {
            Logger.LogMethodEntry("ProgramAdmin", "CreateNewSectionWithCount",
                base.isTakeScreenShotDuringEntryExit);
            //Create New Section 
            new AddNewSectionPage().CreateNewSectionWithCount(courseTypeEnum, count);
            Logger.LogMethodExit("ProgramAdmin", "CreateNewSectionWithCount",
                  base.isTakeScreenShotDuringEntryExit);
        }

    }
}
