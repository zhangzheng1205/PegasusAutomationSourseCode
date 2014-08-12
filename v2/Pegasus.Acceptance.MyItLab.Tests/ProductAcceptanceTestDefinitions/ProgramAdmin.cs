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
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Create New Template 
            new ManageTemplatePage().CreatTemplate(course.Name);
            Logger.LogMethodExit("ProgramAdmin", "CreateNewTemplateAsTheProgramAdmin",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Verify Template in Active State
            new ManageTemplatePage().ApproveInActiveStateOfEntityInProgramAdministration(course.Name);
            Logger.LogMethodExit("ProgramAdmin", "TemplateInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Verify Template in Active State or not
            Logger.LogAssertion("VerifyTemplateActiveState",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(false, new ManageTemplatePage().
                GetAssignToCopyStateText(course.Name).Contains(ProgramAdminResource.
                ProgramAdmin_Page_AssignToCopyState_Text_Value)));
            Logger.LogMethodExit("ProgramAdmin", "ApproveAssignedToCopyStateForTemplate",
                base.IsTakeScreenShotDuringEntryExit);
        }
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
        /// Verify Section in Active State.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I verify the Section created from ""(.*)"" course Template for AssignedToCopy state")]
        public void SectionInAssignedToCopyState(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify Section in Active State
            Logger.LogMethodEntry("ProgramAdmin", "SectionInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Approve Section in Active State
            new ManageTemplatePage().ApproveInActiveStateOfEntityInProgramAdministration(
                course.SectionName);
            Logger.LogMethodExit("ProgramAdmin", "SectionInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Filter Template Using  Parent Template Drop Down.
        /// </summary>
        [When(@"I filter the template ""(.*)"" using 'Parent Template' dropdown")]
        public void FilterTheTemplateUsingDropdown(
            Course.CourseTypeEnum courseTypeEnum)
        {
            Logger.LogMethodEntry("ProgramAdmin", "FilterTheTemplateUsingDropdown",
                base.IsTakeScreenShotDuringEntryExit);
            //Filter Template Using  Parent Template Drop Down
            new AddNewSectionPage().FilterTheTemplateUsingParentTemplateDD(courseTypeEnum);
            Logger.LogMethodExit("ProgramAdmin", "FilterTheTemplateUsingDropdown",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify Created Section Available in the Filter Section List.
        /// </summary>
        [Then(@"I should see the new section created usign ""(.*)"" in the section list")]
        public void VerifyTheCreatedSectionInTheSectionList(Course.CourseTypeEnum courseTypeEnum)
        {
            Logger.LogMethodEntry("ProgramAdmin", "VerifyTheCreatedSectionInTheSectionList",
               base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseTypeEnum);
            //Verify Created Section Available in the Filter Section List
            Logger.LogAssertion("CopyMyCourseContentCheckBoxStatus",
                ScenarioContext.Current.ScenarioInfo.Title, ()
               => Assert.AreEqual(course.SectionName,
               new AddNewSectionPage().VerifyCreatedSectionInFilterTemplateList(course.SectionName)));
            Logger.LogMethodExit("ProgramAdmin", "VerifyTheCreatedSectionInTheSectionList",
                base.IsTakeScreenShotDuringEntryExit);
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
                , base.IsTakeScreenShotDuringEntryExit);
            //Click on Cmenu of Section or Template
            new ManageTemplatePage().
                ClickOnCmenuOfSectionOrTemplate(cMenuOption);
            Logger.LogMethodExit("ProgramAdmin", "ClickOnCmenuOfSectionOrTemplate"
                , base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// To Get the CopyMyCourseContentCheckBoxStatus
        /// </summary>
        [Then(@"I should see the ""(.*)"" check box as unchecked")]
        public void CopyMyCourseContentCheckBoxStatus()
        {
            Logger.LogMethodEntry("ProgramAdmin",
               "CopyMyCourseContentCheckBoxStatus",
             base.IsTakeScreenShotDuringEntryExit);
            // To Verify Checkbox Is Not Selected
            Logger.LogAssertion("CopyMyCourseContentCheckBoxStatus",
                ScenarioContext.Current.ScenarioInfo.Title, ()
               => Assert.IsFalse(new EditCopyTemplatesSectionsPage().CopyMyCourseContentCheckBoxStatus()));
            Logger.LogMethodExit("ProgramAdmin",
           "CopyMyCourseContentCheckBoxStatus",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Searching the template inside the program
        /// </summary>
        [When(@"I search the Template of ""(.*)""")]
        public void SearchTemplateCourse(Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify Section in Active State
            Logger.LogMethodEntry("ProgramAdmin", "SearchTemplateCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Search the passed course
            new ManageTemplatePage().SearchEntityInProgramAdministration(course.Name);

            Logger.LogMethodExit("ProgramAdmin", "SearchTemplateCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save Button click to create course Manage Template section
        /// </summary>
        /// <param name=""></param>
        [When(@"I click SAVE button to Copy as Shared Library")]
        public void ClickToCreateUpdate()
        {
            Logger.LogMethodEntry("ProgramAdmin", "ClickSaveToCreateSharedLibrary",
                base.IsTakeScreenShotDuringEntryExit);
            //SaveUpdate method to create or update the course.
            new EditCopyTemplatesSectionsPage().CreateSharedLibrary();

            Logger.LogMethodExit("ProgramAdmin", "ClickSaveToCreateSharedLibrary",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Validate the obtained message on the popup page
        /// </summary>
        [Then(@"I should see the message ""(.*)"" on popup page")]
        public void ToValidateTheMessage(string message)
        {
            Logger.LogMethodEntry("ProgramAdmin",
               "ToValidateTheMessage",
               base.IsTakeScreenShotDuringEntryExit);
            //To Verify The Message In Copy as Section Popup
            Logger.LogAssertion("ToValidateTheMessage",
                            ScenarioContext.Current.ScenarioInfo.Title, ()
                           => Assert.IsTrue(new EditCopyTemplatesSectionsPage().ToValidateTheMessageOnPopupPage(message)));
            Logger.LogMethodExit("ProgramAdmin",
            "ToValidateTheMessage",
              base.IsTakeScreenShotDuringEntryExit);
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
            base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Approve Section in Active State
            new ManageTemplatePage().SearchEntityInProgramAdministration(course.SectionName);
            Logger.LogMethodExit("ProgramAdmin", "SearchSection",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Copying the section from section inside the program
        /// </summary>
        [When(@"I click Copy/Save button to copy")]
        public void ClickonCopySectionButton()
        {
            Logger.LogMethodEntry("ProgramAdmin", "ClickonCopySectionButton",
            base.IsTakeScreenShotDuringEntryExit);
            //SaveUpdate method to create or update the course.
            new EditCopyTemplatesSectionsPage().CopySection();
            Logger.LogMethodExit("ProgramAdmin", "ClickonCopySectionButton",
                base.IsTakeScreenShotDuringEntryExit);
        }


        ///// <summary>
        ///// click on the copy/save button, during the copy of the template/section as template inside the program 
        ///// </summary>
        [When(@"I click Copy/Save button")]
        public void ClickOnCopySaveButton()
        {
            Logger.LogMethodEntry("ProgramAdmin", "ClickOnCopySaveButton",
                base.IsTakeScreenShotDuringEntryExit);
            //SaveUpdate method to create or update the course.
            new EditCopyTemplatesSectionsPage().ClickToCreateUpdate();
            Logger.LogMethodExit("ProgramAdmin", "ClickOnCopySaveButton",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Create New Section 
            new AddNewSectionPage().CreateNewSectionWithCount(courseTypeEnum, count);
            Logger.LogMethodExit("ProgramAdmin", "CreateNewSectionWithCount",
                  base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify copied Section in Active State.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I verify the Section copied from ""(.*)"" section for AssignedToCopy state")]
        public void CopiedSectionInAssignedToCopyState(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify copied Section in Active State
            Logger.LogMethodEntry("ProgramAdmin", "CopiedSectionInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Approve copied Section in Active State
            new ManageTemplatePage().ApproveInActiveStateOfEntityInProgramAdministration(ProgramAdminResource.
                ProgramAdmin_Page_CopyOf_Text_Value + course.SectionName);
            Logger.LogMethodExit("ProgramAdmin", "CopiedSectionInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify copied Section in Active State or not.
        /// </summary>
        /// /// <param name="courseTypeEnum">This is course type enum.</param>
        [Then(@"I should see the Section copied from ""(.*)"" section to be successfully out of AssignedToCopy state")]
        public void ApproveAssignedToCopyStateForCopiedSection(
          Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify Section in Active State
            Logger.LogMethodEntry("ProgramAdmin", "ApproveAssignedToCopyStateForCopiedSection",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Verify copied Section in Active State or not
            Logger.LogAssertion("VerifyCopiedSectionActiveState",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(false, new ManageTemplatePage().GetAssignToCopyStateText
                (ProgramAdminResource.
                ProgramAdmin_Page_CopyOf_Text_Value + course.SectionName).Contains(ProgramAdminResource.
                ProgramAdmin_Page_AssignToCopyState_Text_Value)));
            Logger.LogMethodExit("ProgramAdmin", "ApproveAssignedToCopyStateForCopiedSection",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
