using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.NovaNET.Tests.Definitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles the template creation actions.
    /// </summary>
    [Binding]
    public class CreateTemplate : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger = 
            Logger.GetInstance(typeof(CreateTemplate));

        /// <summary>
        /// Create Template Using Course by Type.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I create the Template using ""(.*)"" course")]
        public void CreateTheTemplate(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Template 
            Logger.LogMethodEntry("CreateTemplate", "CreateTheTemplate",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Add Template Link
            new ManageTemplateMainPage().ClickTemplateCreateLink();
            //Get Course Name From InMemory
            Course course = Course.Get(courseTypeEnum);
            //Create New Template
            new AddTemplatePage().CreateOrganizationTemplate(course.Name);
            Logger.LogMethodEntry("CreateTemplate", "CreateTheTemplate",
                       base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search The Created Template In Frame.
        /// </summary>
        [When(@"I search the created Template in the frame")]
        public void SearchTheCreatedTemplateInTheFrame()
        {
            //Search Template
            Logger.LogMethodEntry("CreateTemplate", 
                "SearchTheCreatedTemplateInTheFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Get Course Details From InMemory
            Course course = Course.Get(Course.CourseTypeEnum.Container);
            //Search Template by Template Name
            new ManageTemplateMainPage().SearchTemplate(course.TemplateName);
            Logger.LogMethodExit("CreateTemplate","SearchTheCreatedTemplateInTheFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Template Present In The Frame.
        /// </summary>
        [Then(@"I should see the created Template in the frame")]
        public void SeeTheCreatedTemplateInTheFrame()
        {
            //Get The Search Template
            Logger.LogMethodEntry("CreateTemplate", 
                "SeeTheCreatedTemplateInTheFrame",
               base.IsTakeScreenShotDuringEntryExit);
            //Get Course Details From Memory            
            Course course = Course.Get(Course.CourseTypeEnum.Container);
            //Assert Template Created Successfully
            Logger.LogAssertion("VerifyTemplateCreatedSuccessfully", 
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(course.TemplateName + CreateTemplateResource.
                    CreateTemplateResource_Template_Keyword,
                    new FrmManageTemplatePage().GetSearchedTemplate()));
            Logger.LogMethodExit("CreateTemplate", "SeeTheCreatedTemplateInTheFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Template Get Out Of Assigned To Copy State.
        /// </summary>
        [Then(@"I verifiy the Template for Assigned to Copy State")]
        public void VerifiyTheTemplateForAssignedToCopyState()
        {
            //Validate Template From Assigned To Copy State
            Logger.LogMethodEntry("CreateTemplate", 
                "VerifiyTheTemplateForAssignedToCopyState",
               base.IsTakeScreenShotDuringEntryExit);
            //Get Course Details From Memory
            Course course = Course.Get(Course.CourseTypeEnum.Container);
            //Validate For Assigned To Copy State
            new FrmManageTemplatePage().ApproveAssignedToCopyState(course.TemplateName);
            Logger.LogMethodExit("CreateTemplate", 
                "VerifiyTheTemplateForAssignedToCopyState",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Template Out Of Assigned To Copy State.
        /// </summary>
        [Then(@"I should see the created Template out of Assigned to Copy State")]
        public void CreatedTemplateOutOfAssignedToCopyState()
        {
            //Template Out of Assigned o Copy State
            Logger.LogMethodEntry("CreateTemplate", 
                "CreatedTemplateOutOfAssignedToCopyState",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert Template Assigned To Copy Validated
            Logger.LogAssertion("VerifyTemplateAssignedToCopyStateValidated", 
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsFalse(new FrmManageTemplatePage().GetAssignedToCopyStateText().
                    Contains(CreateTemplateResource.CreateTemplateResource_AssignedToCopy_Text), 
                    CreateTemplateResource.
                    CreateTemplateResource_TemplateOutOfAssignedtoCopyState_Message));
            Logger.LogMethodExit("CreateTemplate", "CreatedTemplateOutOfAssignedToCopyState",
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
