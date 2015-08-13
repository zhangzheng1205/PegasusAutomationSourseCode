using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus.Pages.CommonPageObjects;
using Pegasus.Automation.DataTransferObjects;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using System.Configuration;
using Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Discussion;
using Pegasus.Pages.UI_Pages.Integration.PCT;


namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class contains the definitions for PCT Click Scenario.
    /// </summary>
    [Binding]
    public class PCTToolLaunch : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PCTToolLaunch));

        /// <summary>
        /// Open PCT Tools DropDown.
        /// </summary>
        [When(@"I click on Tools DropDown")]
        public void OpenToolsDropDown()
        {
            // Method to launch the PCT URL
            Logger.LogMethodEntry("PCTToolLaunch", "OpenToolsDropDown",
                base.IsTakeScreenShotDuringEntryExit);

            // Open the PCT Tools drop down from resource tool bar
            new TodaysViewUxPage().OpenPctToolsDropDown();

            Logger.LogMethodExit("PCTToolLaunch", "OpenToolsDropDown",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// When I Click On PCT Tool In Tools DropDown.
        /// </summary>
        [When(@"I click ""(.*)"" link")]
        public void ClickOnPctToolInDropDown(string pctToolName)
        {
            // Method to launch the PCT URL
            Logger.LogMethodEntry("PCTToolLaunch", "ClickOnPctToolInDropDown",
                IsTakeScreenShotDuringEntryExit);
            new TodaysViewUxPage().LaunchPctFromDropDown(pctToolName);
            Logger.LogMethodExit("PCTToolLaunch", "ClickOnPctToolInDropDown",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click create link in the Project creation tool page
        /// </summary>
        [When(@"I click on Create link")]
        public void ClickCreateLinkPCTPage()
        {
            // Click create PCT tool link
            Logger.LogMethodEntry("PCTToolLaunch", "ClickCreateLinkPCTPage", base.IsTakeScreenShotDuringEntryExit);
            new PCTProjectListPage().CSInsClickCreateLinkPCT();
            Logger.LogMethodExit("PCTToolLaunch", "ClickCreateLinkPCTPage", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the project type to be created in project creation tool page.
        /// </summary>
        /// <param name="projectType">This is a project type</param>
        [When(@"I select ""(.*)"" project type")]
        public void SelectProjectTypeInPCT(string projectType)
        {
            // Select project type in Project creation page
            Logger.LogMethodEntry("PCTToolLaunch", "SelectProjectTypeInPCT", base.IsTakeScreenShotDuringEntryExit);
            new PCTProjectListPage().SelectPCTProjectType(projectType);
            Logger.LogMethodExit("PCTToolLaunch", "SelectProjectTypeInPCT", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter project name in PCT tool page
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum</param>
        [When(@"I enter project name of ""(.*)""")]
        public void EnterProjectNamePCT(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Enter PCT project name
            Logger.LogMethodEntry("PCTToolLaunch", "EnterProjectNamePCT", base.IsTakeScreenShotDuringEntryExit);
            new PCTProjectListPage().EnterProjectName(activityTypeEnum);
            Logger.LogMethodExit("PCTToolLaunch", "EnterProjectNamePCT", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Done button in PCT page
        /// </summary>
        [When(@"I Click on Done button")]
        public void ClickDoneButtonPCT()
        {
            // Click Done button
            Logger.LogMethodEntry("PCTToolLaunch", "ClickDoneButtonPCT", base.IsTakeScreenShotDuringEntryExit);
            new PCTProjectListPage().ClickDoneButtonPCT();
            Logger.LogMethodExit("PCTToolLaunch", "ClickDoneButtonPCT", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click upload icon to upload the file
        /// </summary>
        /// <param name="FileUploadOptionName">This is file upload option name.</param>
        [When(@"I click on upload icon of ""(.*)""")]
        public void ClickOnUploadIconPCT(string FileUploadOptionName)
        {
            // Click upload icon for file upload
            Logger.LogMethodEntry("PCTToolLaunch", "ClickOnUploadIconPCT", base.IsTakeScreenShotDuringEntryExit);
            new PCTProjectListPage().ClickUploadIconPCT(FileUploadOptionName);
            Logger.LogMethodExit("PCTToolLaunch", "ClickOnUploadIconPCT", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Upload file in project creation tool
        /// </summary>
        /// <param name="uploadFileName">File name to upload</param>
        [When(@"I upload the file ""(.*)""")]
        public void UploadFileInPCT(string uploadFileName)
        {
            // Upload document
            Logger.LogMethodEntry("PCTToolLaunch",
                "UploadFileInPCT",
                base.IsTakeScreenShotDuringEntryExit);
            new PCTProjectListPage().UploadFileInPCT(uploadFileName);
            Logger.LogMethodExit("PCTToolLaunch", "UploadFileInPCT",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Map skill instruction
        /// </summary>
        /// <param name="skillName">This is the skill name.</param>
        /// <param name="folderName">This is the folder name where skill is placed</param>
        [When(@"I map skill ""(.*)"" from ""(.*)""")]
        public void MapSkillToInstruction(string skillName, string folderName)
        {
            // Upload document
            Logger.LogMethodEntry("PCTToolLaunch",
                "UploadFileInPCT",
                base.IsTakeScreenShotDuringEntryExit);
            new PCTProjectListPage().MapSkillToInstruction(skillName, folderName);
            Logger.LogMethodExit("PCTToolLaunch", "UploadFileInPCT",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Validate the file uploade status
        /// </summary>
        /// <param name="p0"></param>
        [Then(@"I should see file ""(.*)"" uploaded sucessfully in ""(.*)"" frame")]
        public void ValidateFileUploadedSucessfully(string fileName, string frameName)
        {
            //Check If Expected Page Is Opened
            Logger.LogMethodEntry("PCTToolLaunch", "ValidateFileUploadedSucessfully",
                IsTakeScreenShotDuringEntryExit);
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(fileName, new PCTProjectListPage().GetUploadedFileName(frameName)));
            Logger.LogMethodExit("PCTToolLaunch", "ValidateFileUploadedSucessfully",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Publish the project in project creation tool page.
        /// </summary>
        [When(@"I publish the project in project creation tool page")]
        public void PublishTheProjectInProjectCreationToolPage()
        {
            Logger.LogMethodEntry("PCTToolLaunch", "PublishTheProjectInProjectCreationToolPage",
                IsTakeScreenShotDuringEntryExit);
            new PCTProjectListPage().PublishProjectInPCT();
            Logger.LogMethodExit("PCTToolLaunch", "PublishTheProjectInProjectCreationToolPage",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create GraderIT question using newly created PCT project
        /// </summary>
        /// <param name="questionTypeEnum">This is question type enum</param>
        /// <param name="activityTypeEnum">This is activity type enum</param>
        [When(@"I create ""(.*)"" question with ""(.*)"" project")]
        public void CreateGraderITQuestionInCourseSpace(Question.QuestionTypeEnum questionTypeEnum, Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Create Grader IT Question In Manage Question Bank
            Logger.LogMethodEntry("PCTToolLaunch",
                "CreateGraderITQuestionInManageQuestionBank",
                 base.IsTakeScreenShotDuringEntryExit);
            //Create The GraderIT Question In Manage Question Bank
            new AutoGraderPage().
                CSTeacherCreateGraderITQuestion(questionTypeEnum, activityTypeEnum);
            Logger.LogMethodExit("PCTToolLaunch",
                "CreateGraderITQuestionInManageQuestionBank",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// SMS Instructor close project creation tool page
        /// </summary>
        [When(@"I close Project creation tool popup")]
        public void CloseProjectCreationToolPopup()
        {
            //Close PCT popup
            Logger.LogMethodEntry("PCTToolLaunch", "CloseProjectCreationToolPopup", base.IsTakeScreenShotDuringEntryExit);
            new PCTProjectListPage().ClosePCTToolPopup();
            Logger.LogMethodExit("PCTToolLaunch", "CloseProjectCreationToolPopup", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}