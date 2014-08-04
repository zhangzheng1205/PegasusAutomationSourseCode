using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles the, action of different level's of Organization.
    /// </summary>
    [Binding]
    public class CreateOrganization : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CreateOrganization));

        /// <summary>
        /// Navigate to  Organization Management Page.
        /// </summary>
        [Given(@"I am on the 'Organization Management' page")]
        public void NavigateToOrganizationManagementPage()
        {
            //Manage to navigate Organization Management Page
            Logger.LogMethodEntry("CreateOrganization",
                "NavigateToOrganizationManagementPage",
                base.IsTakeScreenShotDuringEntryExit);
            //Navigate to Organization Management Page
            new AdminToolPage().NavigateOrganizationManagementPage();
            Logger.LogMethodExit("CreateOrganization",
                "NavigateToOrganizationManagementPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the "Create New Organization" link.
        /// </summary>
        [When(@"I click on the Create New Organization link")]
        public void ClickTheCreateNewOrganizationLink()
        {
            //Click on the'Create New Organization' link
            Logger.LogMethodEntry("CreateOrganization",
                "ClickTheCreateNewOrganizationLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Click the 'Create New Organization' link          
            new OrganizationManagementPage().
                ClickOnTheCreateNewOrganizationLink();
            Logger.LogMethodExit("CreateOrganization",
                "ClickTheCreateNewOrganizationLink",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create the different levels of organization.
        /// </summary>
        /// <param name="organizationLevelEnum">This is the 
        /// organization level by type Enum.</param> 
        /// <param name="organizationCreationCondition">This is Organization Creation Condition.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        [When(@"I create the ""(.*)"" level organization ""(.*)"" in ""(.*)""")]
        public void CreateTheOrganizationInProductForDifferentLevels
            (Organization.OrganizationLevelEnum organizationLevelEnum,
            string organizationCreationCondition,
           Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Create the organization level
            Logger.LogMethodEntry("CreateOrganization",
                "CreateTheOrganizationInProductForDifferentLevels",
                base.IsTakeScreenShotDuringEntryExit);
            //Create organization based on level
            new CreateOrganizationPage().
                CreateOrganizationInProductBasedOnLevel(
                organizationLevelEnum, organizationTypeEnum,
                organizationCreationCondition);
            Logger.LogMethodExit("CreateOrganization",
                "CreateTheOrganizationInProductForDifferentLevels",
                base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Create The Multiple Level Organization.
        /// </summary>
        /// <param name="organizationLevelEnum">This is Multiple level 
        /// school organization type enum.</param>
        [When(@"I create the multiple ""(.*)""")]
        public void CreateTheMultipleLevelOrganization(
            Organization.OrganizationLevelEnum organizationLevelEnum)
        {
            //Create The Multiple Level Organization
            Logger.LogMethodEntry("CreateOrganization",
                "CreateTheMultipleLevelOrganization",
                base.IsTakeScreenShotDuringEntryExit);
            //Create The Multiple Level Organization
            new CreateOrganizationPage().
                CreateMultipleLevelOrganization(organizationLevelEnum);
            Logger.LogMethodExit("CreateOrganization",
                "CreateTheMultipleLevelOrganization",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Searching the Organization.
        /// </summary>
        /// <param name="organizationLevelEnum">This is the 
        /// organization level by type Enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        [When(@"I search the ""(.*)"" level Organization in ""(.*)""")]
        public void SearchTheOrganization
            (Organization.OrganizationLevelEnum organizationLevelEnum,
            Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Search the searched organization
            Logger.LogMethodEntry("CreateOrganization", "SearchTheOrganization",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the organization name 
            Organization organization = Organization.Get(organizationLevelEnum,
                organizationTypeEnum);
            //Searched organization         
            new OrganizationManagementPage().
                SearchTheOrganization(organization.Name);
            Logger.LogMethodExit("CreateOrganization", "SearchTheOrganization",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the display search result.
        /// </summary>
        /// <param name="organizationLevelEnum">This is organization 
        /// level by type enum.</param>
        /// <param name="organizationTypeEnum">This is organization type eum.</param>
        [Then(@"I should see the ""(.*)"" level organization name in ""(.*)""")]
        public void VerifyTheDisplaySearchOrganization
            (Organization.OrganizationLevelEnum organizationLevelEnum,
           Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Verify the display searched Organization
            Logger.LogMethodEntry("CreateOrganization",
                "VerifyTheDisplaySearchOrganization",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the organization name 
            Organization organization = Organization.Get(
                organizationLevelEnum, organizationTypeEnum);
            // Assert for search organization 
            Logger.LogAssertion("VerifySearchOrganization", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(organization.Name,
                    new OrganizationManagementPage().GetDisplayofSearchedOrganization()));
            Logger.LogMethodExit("CreateOrganization", "VerifyTheDisplaySearchOrganization",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the 'Select Organization' link.
        /// </summary>
        [When(@"I click on the Select Organization link")]
        public void ClickTheSelectOrganizationLink()
        {
            //Click on the 'Select Organization' link
            Logger.LogMethodEntry("CreateOrganization", "ClickTheSelectOrganizationLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the 'Select Organization' link
            new OrganizationSearchPage().ClickOnTheSelectOrganizationLink();
            Logger.LogMethodExit("CreateOrganization", "ClickTheSelectOrganizationLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Delete Organization.
        /// </summary>
        [When(@"I delete the organization")]
        public void DeleteTheOrganization()
        {
            //Delete Organization
            Logger.LogMethodEntry("CreateOrganization", "DeleteTheOrganization",
                base.IsTakeScreenShotDuringEntryExit);
            //Delete Organization
            new OrganizationManagementPage().DeleteOrganization();
            Logger.LogMethodExit("CreateOrganization", "DeleteTheOrganization",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Deleted Organization.
        /// </summary>
        /// <param name="message">This is Message on Searching Deleted Organization.</param>
        [Then(@"I should see the message ""(.*)""")]
        public void VerifyDeletedOrganization(string message)
        {
            //Verify Deleted Organization
            Logger.LogMethodEntry("CreateOrganization", "VerifyDeletedOrganization",
                base.IsTakeScreenShotDuringEntryExit);
            // Assert Deleted organization 
            Logger.LogAssertion("VerifySearchOrganization", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(message,
                    new OrganizationManagementPage().
                    GetValidationMessageonSearchingDeletedOrganization()));
            Logger.LogMethodExit("CreateOrganization", "VerifyDeletedOrganization",
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
