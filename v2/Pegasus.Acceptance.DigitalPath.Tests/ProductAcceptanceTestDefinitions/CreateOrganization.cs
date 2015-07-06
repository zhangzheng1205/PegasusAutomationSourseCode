#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles the, action of different level's of Organization.
    /// </summary>
    [Binding]
    public class CreateOrganization : BasePage
    {
        /// <summary>
        /// This is the logger
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
            new OrganizationManagementPage().ClickOnTheCreateNewOrganizationLink();
            Logger.LogMethodExit("CreateOrganization",
                "ClickTheCreateNewOrganizationLink",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Searching the Organization.
        /// </summary>
        /// <param name="organizationLevelEnum">This is the organization level type enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        [When(@"I search the ""(.*)"" level Organization in ""(.*)""")]
        public void SearchTheOrganization
            (Organization.OrganizationLevelEnum organizationLevelEnum,
            Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Search the searched organization
            Logger.LogMethodEntry("CreateOrganization", "SearchTheOrganization",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Fetch the organization name 
                Organization organization = Organization.Get(
                    organizationLevelEnum, organizationTypeEnum);
                //Searched organization         
                new OrganizationManagementPage().
                    SearchTheOrganization(organization.Name);
            }
            catch
            {

            }
            Logger.LogMethodExit("CreateOrganization", "SearchTheOrganization",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the display search result.
        /// </summary>
        /// <param name="organizationLevelEnum">This is organization level type enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        [Then(@"I should see the ""(.*)"" level organization name in ""(.*)""")]
        public void VerifyTheDisplaySearchOrganization
            (Organization.OrganizationLevelEnum organizationLevelEnum,
            Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Verify the display searched Organization
            Logger.LogMethodEntry("CreateOrganization", "VerifyTheDisplaySearchOrganization",
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
        /// Click on the 'Select' Button.
        /// </summary>
        [When(@"I click on the Select Button")]
        public void ClickTheSelectButton()
        {
            //Click on the 'select' button
            Logger.LogMethodEntry("CreateOrganization", "ClickTheSelectButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the 'Select' button
            new OrganizationManagementPage().ClickOnTheOrganizationSelectButton();
            Logger.LogMethodExit("CreateOrganization", "ClickTheSelectButton",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Click on the 'Add'_organization link
            new OrganizationSearchPage().ClickOnTheAddOrganizationLink();
            Logger.LogMethodExit("CreateOrganization", "ClickTheAddOrganizationLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create organization based on level.
        /// </summary>
        /// <param name="organizationLevelEnum">
        /// This is the organization level type enum.</param>
        /// <param name="organizationCreationCondition">
        /// This is Organization Creation Condition.</param>
        /// <param name="organizationTypeEnum">
        /// This is organization type enum.</param>
       [When(@"I create the ""(.*)"" level organization ""(.*)"" in ""(.*)""")]
        public void CreateTheOrganizationLevels
            (Organization.OrganizationLevelEnum organizationLevelEnum,
           string organizationCreationCondition,
           Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Create organization
            Logger.LogMethodEntry("CreateOrganization", "CreateTheOrganizationLevels",
                base.IsTakeScreenShotDuringEntryExit);
            //Create organization based on level
            new CreateOrganizationPage().CreateOrganizationInProductBasedOnLevel
                (organizationLevelEnum, organizationTypeEnum, organizationCreationCondition);
            Logger.LogMethodExit("CreateOrganization", "CreateTheOrganizationLevels",
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
        /// Enter the School Level Organization.
        /// </summary>
        [When(@"I enter into the School")]
        public void EnterIntoTheSchool()
        {
            //Enter the School Level Organization
            Logger.LogMethodEntry("CreateOrganization", "EnterIntoTheSchool",
                   base.IsTakeScreenShotDuringEntryExit);
            //Click on the 'Select' button
            new OrganizationManagementPage().ClickOnTheOrganizationSelectButton();
            //Select the Manage Organization window
            new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
            Logger.LogMethodExit("CreateOrganization", "EnterIntoTheSchool",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Properties Sub Tab.
        /// </summary>       
        /// <param name="tabName">This is tab name</param>
        [When(@"I navigate to the ""(.*)"" tab in 'Manage Organization' page")]
        public void NavigateToPropertiesSubTab(String tabName)
        {
            //Navigate To Properties Sub Tab
            Logger.LogMethodEntry("CreateOrganization", "NavigateToPropertiesSubTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Navigate To Properties Sub Tab In Management Organization
            new ManageOrganisationToolBarPage().
                NavigateToPropertiesSubTabInManagementOrganization(tabName);
            Logger.LogMethodExit("CreateOrganization", "NavigateToPropertiesSubTab",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        ///  <summary>
        /// Edit The Organization.
        ///  </summary>
        ///  <param name="organizationLevelEnum">This is organization type enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        [When(@"I edit the ""(.*)"" level Organization in ""(.*)""")]
        public void EditTheOrganization(
            Organization.OrganizationLevelEnum organizationLevelEnum,
            Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Edit The Organization 
            Logger.LogMethodEntry("CreateOrganization", "EditTheOrganization",
                base.IsTakeScreenShotDuringEntryExit);
            //Select The Properties Organization Managment Frame
            new CreateOrganizationPage().SelectThePropertiesOrganizationManagmentFrame();
            //Create And Edit the organization
            new CreateOrganizationPage().CreateNewOrganizationForDifferentLevels(
                organizationLevelEnum, organizationTypeEnum);
            Logger.LogMethodExit("CreateOrganization", "EditTheOrganization",
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
        /// Create District level organization only
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        [When(@"I create ""(.*)"" level organization ""(.*)"" in ""(.*)""")]
        public void CreateTheDistrictOrganizationLevels
            (Organization.OrganizationLevelEnum organizationLevelEnum,
           string organizationCreationCondition,
           Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Create organization
            Logger.LogMethodEntry("CreateOrganization", "CreateTheDistrictOrganizationLevels",
                base.IsTakeScreenShotDuringEntryExit);
            //Create organization based on level
            new CreateOrganizationPage().CreateDistrictOrganizationInProductBasedOnLevel
                (organizationLevelEnum, organizationTypeEnum, organizationCreationCondition);
            Logger.LogMethodExit("CreateOrganization", "CreateTheDistrictOrganizationLevels",
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
