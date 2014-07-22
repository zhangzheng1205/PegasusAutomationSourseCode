#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Actions Related to Workspaces.
    /// </summary>
    [Binding]
    public class CreateWorkspace : PegasusBaseTestFixture
    {

        /// <summary>
        /// This is static instance of logger.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CreateWorkspace));

        /// <summary>
        /// Display Of Preference And Workspaces Tabs.
        /// </summary>
        [Then(@"I should see Preference and Workspaces Tabs")]
        public void DisplayOfPreferenceAndWorkspacesTabs()
        {
            //Display Of Preference And Workspaces Tabs
            Logger.LogMethodEntry("CreateWorkspace", "DisplayOfPreferenceAndWorkspacesTabs",
                base.isTakeScreenShotDuringEntryExit);
            //Assert the Display Of Preference And Workspaces Tabs for CTG Publisher Admin
            Logger.LogAssertion("VerifyDisplayOfPreferenceAndWorkspacesTabs",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new AdminToolPage().IsDefaultTabsDisplayedForCtgPublisherAdmin()));
            Logger.LogMethodExit("CreateWorkspace", "DisplayOfPreferenceAndWorkspacesTabs",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Default View As Workspaces Tab for CTG Publisher Admin.
        /// </summary>
        [Then(@"I should see default view as Workspaces tab")]
        public void DefaultViewForCtgPublisherAdmin()
        {
            //Default View As Workspaces Tab for CTG Publisher Admin
            Logger.LogMethodEntry("CreateWorkspace", "DefaultViewForCtgPublisherAdmin",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Default View As Workspaces Tab for CTG Publisher Admin
            Logger.LogAssertion("VerifyDefaultViewForCTGPublisherAdmin",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(
                    CreateWorkspaceResource.CreateWorkspace_Workspaces_Window_Title,
                    new ManageWorkspacesPage().GetThePageTitle()));
            Logger.LogMethodExit("CreateWorkspace", "DefaultViewForCtgPublisherAdmin",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Default Contents Of Workspace Tab.
        /// </summary>
        [Then(@"I should see the default contents of Workspace tab")]
        public void DisplayOfDefaultContentsOfWorkspaceTab()
        {
            //Display Of Default Contents Of Workspace Tab
            Logger.LogMethodEntry("CreateWorkspace", "DisplayOfDefaultContentsOfWorkspaceTab",
                base.isTakeScreenShotDuringEntryExit);
            //Assert the Display Of Default Contents Of Workspace Tab for CTG Publisher Admin
            Logger.LogAssertion("VerifyDefaultViewForCTGPublisherAdmin",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new ManageWorkspacesPage().IsTheDefaultContentsInWorkspacesTabDisplayed()));
            Logger.LogMethodEntry("CreateWorkspace", "DisplayOfDefaultContentsOfWorkspaceTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create The New Workspace.
        /// </summary>
        /// <param name="workspaceName">This is workspace type by enum.</param>
        /// <param name="adminType">This is workspace type.</param>
        [When(@"I ""(.*)"" the new ""(.*)"" admin")]
        public void CreateTheNewWorkspace(String adminType,
            WorkSpace.WorkSpaceTypeEnum workspaceName)
        {
            //Create The New Workspace
            Logger.LogMethodEntry("CreateWorkspace", "CreateTheNewWorkspace",
                base.isTakeScreenShotDuringEntryExit);
            // Click the Create New Workspace
            new AdminToolPage().ClickTheCreateNewWorkspaceLink(
                (AdminToolPage.AdminWorkspaceTypeEnum)Enum.Parse
                (typeof(AdminToolPage.AdminWorkspaceTypeEnum), adminType));
            //Create And Update Workspace           
            new NewWorkspacePage().CreateAndUpdateTheWorkspace(
                (AdminToolPage.AdminWorkspaceTypeEnum)Enum.Parse
                (typeof(AdminToolPage.AdminWorkspaceTypeEnum),
                adminType), workspaceName);            
            Logger.LogMethodExit("CreateWorkspace", "CreateTheNewWorkspace",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
