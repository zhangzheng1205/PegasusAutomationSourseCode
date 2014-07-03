#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
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

        /// <summary>
        /// Update The Created Workspace.
        /// </summary>
        /// <param name="workspaceTypeEnum">This is workspace type enum.</param>
        /// <param name="adminType">This is admin workspace</param>
        [When(@"I search the ""(.*)"" and click on the ""(.*)"" cmenu link")]
        public void UpdateAndCreatedWorkspace(
            WorkSpace.WorkSpaceTypeEnum workspaceTypeEnum, String adminType)
        {
            //Update The Created Workspace
            Logger.LogMethodEntry("CreateWorkspace", "UpdateAndCreatedWorkspace",
                base.isTakeScreenShotDuringEntryExit);
            //Fetch the workspace name 
            WorkSpace worspaceName = WorkSpace.Get(workspaceTypeEnum);
            //Searched created workspace 
            new AdminToolPage().SearchCreatedWorkspace(
                (AdminToolPage.AdminWorkspaceTypeEnum)Enum.Parse
                (typeof(AdminToolPage.AdminWorkspaceTypeEnum),
                adminType), worspaceName.Name);
            Logger.LogMethodExit("CreateWorkspace", "UpdateAndCreatedWorkspace",
               base.isTakeScreenShotDuringEntryExit);
        }
      
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
                ScenarioContext.Current.ScenarioInfo.Title,()=> Assert.IsTrue(
                    new AdminToolPage().IsDefaultTabsDisplayedForCtgPublisherAdmin()));
            Logger.LogMethodExit("CreateWorkspace", "DisplayOfPreferenceAndWorkspacesTabs",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display Of Cmenu Options.
        /// </summary>
        [Then(@"I should see the cmenu options")]
        public void DisplayOfCmenuOptions()
        {
            //Display Of Cmenu Options
            Logger.LogMethodEntry("CreateWorkspace", "DisplayOfCmenuOptions",
                base.isTakeScreenShotDuringEntryExit);
            //Assert the Display Of cmenu options in Workspace for CTG Publisher Admin
            Logger.LogAssertion("VerifyDisplayOfCmenuOptionsInWorkspace",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new AdminToolPage().IsDisplayedTheCmenuOptions()));           
            Logger.LogMethodExit("CreateWorkspace", "DisplayOfCmenuOptions",
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
                ScenarioContext.Current.ScenarioInfo.Title, () =>Assert.IsTrue(
                    new ManageWorkspacesPage().IsTheDefaultContentsInWorkspacesTabDisplayed()));
            Logger.LogMethodEntry("CreateWorkspace", "DisplayOfDefaultContentsOfWorkspaceTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Edit Workspace Cmenu Option.
        /// </summary>
        [When(@"I click on the 'Edit Workspace info' cmenu option")]
        public void ClickOnTheEditWorkspaceCmenuOption()
        {
            //Click On The Edit Workspace Cmenu Option
            Logger.LogMethodEntry("CreateWorkspace", "ClickOnTheEditWorkspaceCmenuOption",
                base.isTakeScreenShotDuringEntryExit);
            // Click Edit Workspace info CmenuOption
            new AdminToolPage().ClickEditWorkspaceinfoCmenuOption();
            Logger.LogMethodEntry("CreateWorkspace", "ClickOnTheEditWorkspaceCmenuOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Displayed Textbox Fields In EditWorkspace.
        /// </summary>
        [Then(@"I should see the displayed Textbox fields")]
        public void DisplayedTextboxFieldsInEditWorkspace()
        {
            //Displayed Textbox Fields In EditWorkspace
            Logger.LogMethodEntry("CreateWorkspace", "DisplayedTextboxFieldsInEditWorkspace",
                base.isTakeScreenShotDuringEntryExit);
            //Assert the Display Of TextboxFields in Workspace for CTG Publisher Admin
            Logger.LogAssertion("VerifyDisplayOftextboxFieldsInEditWorkspace",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new NewWorkspacePage().IsDisplayedOfTextboxInEditWorkspace()));
            Logger.LogMethodExit("CreateWorkspace", "DisplayedTextboxFieldsInEditWorkspace",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Workspace Delete Link.
        /// </summary>
        [When(@"I click the delete link")]
        public void ClickTheWorkspaceDeleteLink()
        {
            //Click The Workspace Delete Link
            Logger.LogMethodEntry("CreateWorkspace", "ClickTheWorkspaceDeleteLink",
                base.isTakeScreenShotDuringEntryExit);
            //Click On Delete Link In CTGPublisher Admin
            new AdminToolPage().ClickOnDeleteLinkInCtgPublisherAdmin();
            Logger.LogMethodExit("CreateWorkspace", "ClickTheWorkspaceDeleteLink",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Verify the Contents Displayed In Preferences Page.
        /// </summary>
        [Then(@"I should see all the default contents in the 'Preferences' page")]
        public void VerifyTheContentsDisplayedInPreferencesPage()
        {
            //Verify the Contents Displayed In Preferences Page
            Logger.LogMethodEntry("CreateWorkspace",
                "VerifyTheContentsDisplayedInPreferencesPage",
                base.isTakeScreenShotDuringEntryExit);
            //Assert the Display Of Default contents in Preference page
            Logger.LogAssertion("VerifyDisplayOfDefaultcontentsinPreferencepage",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.IsTrue(
                    new PublisherCustomizationPage().
                    IsDefaultContentsDisplayedInPreferencesPage()));       
            Logger.LogMethodExit("CreateWorkspace",
                "VerifyTheContentsDisplayedInPreferencesPage",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Upload The Branding Image.
        /// </summary>
        [When(@"I upload the branding Image")]
        public void UploadTheBrandingImage()
        {
            //Upload The Branding Image
            Logger.LogMethodEntry("CreateWorkspace","UploadTheBrandingImage",
                base.isTakeScreenShotDuringEntryExit);
            //Upload The Branding Image In Preference
            new PublisherCustomizationPage().UploadBrandingImageInPreference();
            Logger.LogMethodExit("CreateWorkspace", "UploadTheBrandingImage",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Welcome Text And Registration URL.
        /// </summary>
        [When(@"I enter the Welcome text and Registration URL")]
        public void EnterTheWelcomeTextAndRegistrationURL()
        {
            //Enter The Welcome Text And Registration URL
            Logger.LogMethodEntry("CreateWorkspace",
                "EnterTheWelcomeTextAndRegistrationURL",
                base.isTakeScreenShotDuringEntryExit);
            //Fill Welcome Text And URL
            new PublisherCustomizationPage().FillWelcomeTextAndURL();
            Logger.LogMethodExit("CreateWorkspace", 
                "EnterTheWelcomeTextAndRegistrationURL",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On The Save Button in Preference.
        /// </summary>
        [When(@"I click on the Save button")]
        public void ClickOnTheSaveButtonInPreference()
        {
            //Click On The Save Button in Preference
            Logger.LogMethodEntry("CreateWorkspace",
                "ClickOnTheSaveButtonInPreference",
                base.isTakeScreenShotDuringEntryExit);
            //Click The Save Button In Preference tab
            new PublisherCustomizationPage().ClickTheSaveButtonInPreferenceTab();
            Logger.LogMethodExit("CreateWorkspace", 
                "ClickOnTheSaveButtonInPreference",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Welcome Text Displayed In Login Page.
        /// </summary>
        [Then(@"I should see the Welcome text displayed in login page")]
        public void WelcomeTextDisplayedInLoginPage()
        {
            //Welcome Text Displayed In Login Page
            Logger.LogMethodEntry("CreateWorkspace",
                "WelcomeTextDisplayedInLoginPage",
                base.isTakeScreenShotDuringEntryExit);
            //Assert for Welcome Message Displayed In Login Page
            Logger.LogAssertion("VerifyWelcomeMessageInLoginPage",
               ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(
                   CreateWorkspaceResource.
                   CreateWorkspace_Workspaces_LoginPage_WelocmeMessage_Text,
                   new PublisherCustomizationPage().WelcomeMessageDisplayedInLoginPage()));
            Logger.LogMethodExit("CreateWorkspace",
                "WelcomeTextDisplayedInLoginPage",
              base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Initialize Test before Test execution starts
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// Deinitialize Test after the execution of Test
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
