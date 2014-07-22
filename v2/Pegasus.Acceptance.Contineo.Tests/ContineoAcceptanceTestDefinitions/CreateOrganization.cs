#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.Contineo.Tests.
    ContineoAcceptanceTestDefinitions
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
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CreateOrganization));

        /// <summary>
        /// Navigate to  Organization Management Page.
        /// </summary>
        [Given(@"I am on the 'Organization Management' page")]
        [When(@"I am on the 'Organization Management' page")]
        public void NavigateToOrganizationManagementPage()
        {
            //Manage to navigate Organization Management Page
            Logger.LogMethodEntry("CreateOrganization",
                "NavigateToOrganizationManagementPage",
                base.isTakeScreenShotDuringEntryExit);
            //Navigate to Organization Management Page
            new AdminToolPage().NavigateOrganizationManagementPage();
            Logger.LogMethodExit("CreateOrganization",
                "NavigateToOrganizationManagementPage",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Click the 'Create New Organization' link          
            new OrganizationManagementPage().ClickOnTheCreateNewOrganizationLink();
            Logger.LogMethodExit("CreateOrganization",
                "ClickTheCreateNewOrganizationLink",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Searching the Organization.
        /// </summary>
        /// <param name="organizationLevelEnum">This is the organization level by type.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        [When(@"I search the ""(.*)"" level Organization in ""(.*)""")]
        public void SearchTheOrganization
            (Organization.OrganizationLevelEnum organizationLevelEnum, 
            Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Search the searched organization
            Logger.LogMethodEntry("CreateOrganization", "SearchTheOrganization",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the organization name 
            Organization organization = Organization.Get(
                organizationLevelEnum, organizationTypeEnum);
            //Searched organization         
            new OrganizationManagementPage().
               SearchTheOrganization(organization.Name);
            Logger.LogMethodExit("CreateOrganization", "SearchTheOrganization",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the display search result.
        /// </summary>
        /// <param name="organizationLevelEnum">This is organization level by type.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        [Then(@"I should see the ""(.*)"" level organization name in ""(.*)""")]
        public void VerifyTheDisplaySearchOrganization
            (Organization.OrganizationLevelEnum organizationLevelEnum, 
            Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Verify the display searched Organization
            Logger.LogMethodEntry("CreateOrganization", "VerifyTheDisplaySearchOrganization",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the organization name 
            Organization organization = Organization.Get(
                organizationLevelEnum, organizationTypeEnum);
            // Assert for search organization 
            Logger.LogAssertion("VerifySearchOrganization", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(organization.Name,
                   new OrganizationManagementPage().GetDisplayofSearchedOrganization()));
            Logger.LogMethodExit("CreateOrganization", "VerifyTheDisplaySearchOrganization",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the 'Select' Button.
        /// </summary>
        [When(@"I click on the Select Button")]
        public void ClickTheSelectButton()
        {
            //Click on the 'select' button
            Logger.LogMethodEntry("CreateOrganization", "ClickTheSelectButton",
                base.isTakeScreenShotDuringEntryExit);
            //Click on the 'Select' button
            new OrganizationManagementPage().ClickOnTheOrganizationSelectButton();
            Logger.LogMethodExit("CreateOrganization", "ClickTheSelectButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the different level of 'Add'_organization link.
        /// </summary>
        [When(@"I click on the Add School link")]
        [When(@"I click on the Add District link")]
        [When(@"I click on the Add Region link")]
        public void ClickTheAddOrganizationLink()
        {
            //Click on the different 'Add' organization link
            Logger.LogMethodEntry("CreateOrganization", "ClickTheAddOrganizationLink",
                base.isTakeScreenShotDuringEntryExit);
            //Click on the 'Add'_organization link
            new OrganizationSearchPage().ClickOnTheAddOrganizationLink();
            Logger.LogMethodExit("CreateOrganization", "ClickTheAddOrganizationLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create organization based on level.
        /// </summary>
        /// <param name="organizationLevelEnum">This is the organization level by type.</param>
        /// <param name="organizationCreationCondition">This is Organization Creation Condition.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        [When(@"I create the ""(.*)"" level organization ""(.*)"" in ""(.*)""")]
        public void CreateTheOrganizationLevels
            (Organization.OrganizationLevelEnum organizationLevelEnum,
            string organizationCreationCondition,
            Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Create organization
            Logger.LogMethodEntry("CreateOrganization", "CreateTheOrganizationLevels",
                base.isTakeScreenShotDuringEntryExit);
            //Create organization based on level
            new CreateOrganizationPage().CreateOrganizationInProductBasedOnLevel(
                organizationLevelEnum, organizationTypeEnum, 
                organizationCreationCondition);
            Logger.LogMethodExit("CreateOrganization", "CreateTheOrganizationLevels",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Click on the 'Select Organization' link.
        /// </summary>
        [When(@"I click on the Select Organization link")]
        public void ClickTheSelectOrganizationLink()
        {
            //Click on the 'Select Organization' link
            Logger.LogMethodEntry("CreateOrganization", "ClickTheSelectOrganizationLink",
                base.isTakeScreenShotDuringEntryExit);
            //Click on the 'Select Organization' link
            new OrganizationSearchPage().ClickOnTheSelectOrganizationLink();
            Logger.LogMethodExit("CreateOrganization", "ClickTheSelectOrganizationLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter the School Level Organization.
        /// </summary>
        [When(@"I enter into the School")]
        public void EnterIntoTheSchool()
        {
            //Enter the School Level Organization
            Logger.LogMethodEntry("CreateOrganization", "EnterIntoTheSchool",
                   base.isTakeScreenShotDuringEntryExit);
            //Click on the 'Select' button
            new OrganizationManagementPage().ClickOnTheOrganizationSelectButton();
            //Select the Manage Organization window
            new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
            Logger.LogMethodExit("CreateOrganization", "EnterIntoTheSchool",
                   base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Properties Sub Tab.
        /// </summary>       
        /// <param name="tabName">This is tab name.</param>
        [When(@"I navigate to the ""(.*)"" tab in 'Manage Organization' page")]
        public void NavigateToPropertiesSubTab(String tabName)
        {
            //Navigate To Properties Sub Tab
            Logger.LogMethodEntry("CreateOrganization", "NavigateToPropertiesSubTab",
                base.isTakeScreenShotDuringEntryExit);
            //Navigate To Properties Sub Tab In Management Organization
            new ManageOrganisationToolBarPage().
                NavigateToPropertiesSubTabInManagementOrganization(tabName);
            Logger.LogMethodExit("CreateOrganization", "NavigateToPropertiesSubTab",
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
