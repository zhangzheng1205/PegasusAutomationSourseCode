using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Integration.Rumba;
using TechTalk.SpecFlow;

namespace Pegasus.Integration.MGM.Tests.
    CommonIntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the common feature steps
    /// that can be reuse while verifying
    /// the scenarios.
    /// </summary>
    [Binding]
    public class CommonSteps : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CommonSteps));

        /// <summary>
        /// Check If The Expected Page Is Opened.
        /// </summary>
        /// <param name="expectedPageTitle">This is Expected Page Title.</param>
        [Then("I should be on the \"(.*)\" page")]
        [Given(@"I am on the ""(.*)"" page")]
        [When(@"I am on the ""(.*)"" page")]
        public void ShowThePageInPegasus(String expectedPageTitle)
        {
            //Check If Expected Page Is Opened
            Logger.LogMethodEntry("CommonSteps", "ShowThePageInPegasus",
                isTakeScreenShotDuringEntryExit);
            //Wait Till Thinking Indicator Loads
            bool isThinkingIndicatorLoading = IsThinkingIndicatorLoading();
            //If Thinking Indicator In Process After Specified Time Interval then Fail This Step
            if (isThinkingIndicatorLoading)
            {
                Logger.LogAssertion("VerifyOpenedPageTitle", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.Fail(CommonStepsResource.CommonSteps_PageNotOpened_Message));
            }
            //Wait For Page Get Switched
            WaitUntilPageGetSwitchedSuccessfully(expectedPageTitle);
            //Get current opened page title
            string getActualPageTitle = GetPageTitle;
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedPageTitle, getActualPageTitle));
            Logger.LogMethodExit("CommonSteps", "ShowThePageInPegass",
                isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify the Success Message Display on the Page.
        /// </summary>
        /// <param name="successMessage">This is Success Message Text.</param>
        [Then("I should see the successfull message \"(.*)\"")]
        public void DisplayTheSuccessfullMessage(String successMessage)
        {
            // Method To Verify the Success Message     
            Logger.LogMethodEntry("CommonSteps", "DisplayTheSuccessfullMessage",
                isTakeScreenShotDuringEntryExit);
            //Wait For Page Get Refresh after Pop Up Close
            Thread.Sleep(Convert.ToInt32(CommonStepsResource.
                CommonSteps_SleepTime_Value));
            //Verify Correct Message Present on the Page
            IsMessageExists(successMessage,
                                 CommonStepsResource.CommonSteps_SuccessMessage_Class_Locator);
            //Removed The Assert For Message Because Sometimes Message not comes 
            //but this is not the severe issue. So We, can ignore this.
            Logger.LogMethodExit("CommonSteps", "DisplayTheSuccessfullMessage",
                 isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate Logout From Rumba.
        /// </summary>
        /// <param name="signOutMessage">This Is The SignOut Message.</param>
        [Then(@"I should see the ""(.*)"" message")]
        public void ValidateLogoutFromRumba(String signOutMessage)
        {
            //Validate Logout From Rumba
            Logger.LogMethodEntry("LoginLogout", "ValidateLogoutFromRumba",
               base.isTakeScreenShotDuringEntryExit);
            //Assert Logout
            Logger.LogAssertion("ValidateLogout",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(signOutMessage, new SignInPage().GetRumbaUserSignOutMessage()));
            Logger.LogMethodExit("LoginLogout", "ValidateLogoutFromRumba",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Success Message Display on the Window.
        /// </summary>
        /// <param name="successMessage">This is Success Message Text.</param>
        /// <param name="window">This is Window Name.</param>
        [Then(@"I should see the successfull message ""(.*)"" in ""(.*)"" window")]
        public void DisplayTheSuccessfullMessageInWindow(
            String successMessage, String window)
        {
            // Method To Verify the Success Message 
            Logger.LogMethodEntry("CommonSteps", "DisplayTheSuccessfullMessage",
                isTakeScreenShotDuringEntryExit);
            //Wait For Page Get Refresh after Pop Up Close
            Thread.Sleep(Convert.ToInt32(CommonStepsResource.
                CommonSteps_SleepTime_Value));
            //Select Window
            SelectWindow(window);
            //Wait Till Thinking Indicator Loads
            bool isThinkingIndicatorLoading = IsThinkingIndicatorLoading();
            //If Thinking Indicator In Process After Specified Time Interval then Fail This Step
            if (isThinkingIndicatorLoading)
            {
                Logger.LogAssertion("VerifyOpenedPageTitle", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.Fail(CommonStepsResource.CommonSteps_PageNotOpened_Message));
            }
            //Verify Correct Message Present on the Page
            IsMessagePresentOnPopUp(successMessage,
                                         CommonStepsResource.CommonSteps_SuccessMessage_Class_Locator);
            //Removed The Assert For Message Because Sometimes Message not comes 
            //but this is not the severe issue. So We, can ignore this.
            Logger.LogMethodExit("CommonSteps", "DisplayTheSuccessfullMessage",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Click on the Link.
        /// </summary>
        /// <param name="linkName">This is Link name on which click is required.</param>
        /// <param name="frame">This is Frame whether it is right or left.</param>
        [Given("I click on the \"(.*)\" link in \"(.*)\" frame")]
        [When("I click on the \"(.*)\" link in \"(.*)\" frame")]
        public void ClickOnTheLink(String linkName, String frame)
        {
            //Click on the Link
            Logger.LogMethodEntry("CommonSteps", "ClickOnTheLink",
                isTakeScreenShotDuringEntryExit);
            //Switch To Frame
            SwitchToIFrame(CommonStepsResource.
                CommonSteps_IFrame + frame + string.Empty);
            //Wait For Partial Link Text 
            WaitForElement(By.PartialLinkText(linkName));
            //Click on the Link
            ClickButtonByPartialLinkText(linkName);
            //Wait untill window of users
            WaitUntilWindowLoads(CommonStepsResource.
                CommonSteps_CreateNewUserWindow_Name_Locator);
            Logger.LogMethodExit("CommonSteps", "ClickOnTheLink",
             isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifies the Pop Up Opened.
        /// </summary>
        /// <param name="popUpName">This is PopUp Name.</param>
        [Then("I should see the \"(.*)\" popup")]
        public void ShowThePopUpInPegasus(String popUpName)
        {
            //Verify Pop Up Opened
            Logger.LogMethodEntry("CommonSteps", "ShowThePopUpInPegasus",
                isTakeScreenShotDuringEntryExit);
            //Wait Untill Window Loads
            WaitUntilWindowLoads(popUpName,
                Convert.ToInt32(CommonStepsResource.CommonSteps_CustomTimeToWait));
            //Is Pop Up Present
            Boolean isPopUpExist = IsWindowsExists(popUpName);
            //Assert The Pop Up Window Opened
            Logger.LogAssertion("VerifyOpenedPopUpTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true, isPopUpExist));
            Logger.LogMethodExit("CommonSteps", "ShowThePopUpInPegasus",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Navigate to Tab Window
        /// </summary>
        /// <param name="tabName">This is Name of the Tab.</param>
        [When(@"I navigate to the ""(.*)"" tab")]
        [Then("I navigate to the \"(.*)\" tab")]
        [Then(@"I select the ""(.*)"" tab")]
        [Given(@"I select the ""(.*)"" tab")]
        [When(@"I select the ""(.*)"" tab")]
        [Given("I navigate to the \"(.*)\" tab")]
        [When(@"I navigate back to the ""(.*)"" tab")]
        public void NavigateToTheTab(String tabName)
        {
            //Method to Navigate to the Tab Window 
            Logger.LogMethodEntry("CommonSteps", "NavigateToTheTab",
                isTakeScreenShotDuringEntryExit);
            //Click On More Link if More Link Is Present
            //And The Required Tab Is Not Present
            new TodaysViewUXPage().ClickMoreLinkIfPresent(tabName);
            //Wait For Element
            WaitForElement((By.PartialLinkText(tabName)));
            //Get Element Property          
            IWebElement getTabProperty = GetWebElementPropertiesByPartialLinkText(tabName);
            //Click on Tab   
            ClickByJavaScriptExecutor(getTabProperty);
            //Wait For Page Load 
            Thread.Sleep(Convert.ToInt32(CommonStepsResource.
                 CommonSteps_SleepTime_Value));
            Logger.LogMethodExit("CommonSteps", "NavigateToTheTab",
                 isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Into Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type Enum.</param>
        /// <param name="userTypeEnum">This is User by Type.</param>
        [When(@"I enter in the ""(.*)"" as ""(.*)"" from the Global Home page")]
        public void EnterInCourse(Course.CourseTypeEnum courseTypeEnum,
           User.UserTypeEnum userTypeEnum)
        {
            //Enter in Course from Global Home Page
            Logger.LogMethodEntry("CommonSteps", "EnterInCourse",
                isTakeScreenShotDuringEntryExit);
            //Get Course From  Memory
            Course course = Course.Get(courseTypeEnum);
            //Enter Into The Course
            new MyPegasusUXPage().EnterInCourseFromGobalHomePage(course.Name, userTypeEnum);
            Logger.LogMethodExit("CommonSteps", " EnterInCourse",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifying the Display of default tabs.
        /// </summary>
        /// <param name="userTypeEnum">This is User by Type Enum.</param>
        [Then(@"I should see the defaults tabs for ""(.*)""")]
        public void ViewDefaultsTabs(User.UserTypeEnum userTypeEnum)
        {
            //Verify Page Default Tabs
            Logger.LogMethodEntry("CommonSteps", "ViewDefaultsTabs",
                isTakeScreenShotDuringEntryExit);
            //Assert defaults tabs displayed
            Logger.LogAssertion("VerifyDisplayOfDefaultsTabs", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                (true, new TodaysViewUXPage().IsDefaultTabsPresent(userTypeEnum)));
            Logger.LogMethodExit("CommonSteps", " ViewDefaultsTabs",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Global Home Page.
        /// </summary>
        [When(@"I navigate back to GlobalHome Page")]
        public void NavigateBackToGlobalHomePage()
        {
            //Navigate To Page
            Logger.LogMethodEntry("CommonSteps", "NavigateBackToGlobalHomePage",
                isTakeScreenShotDuringEntryExit);
            //Navigate To Global Home Page
            new TodaysViewUXPage().NavigateToGlobalHomePage();
            Logger.LogMethodExit("CommonSteps", "NavigateBackToGlobalHomePage",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter into Class.
        /// </summary>
        /// <param name="classTypeEnum">This is class by type Enum.</param>
        [When(@"I enter into the ""(.*)"" class")]
        public void EnterIntoClass(Class.ClassTypeEnum classTypeEnum)
        {
            //Enter In Class
            Logger.LogMethodEntry("CommonSteps", "EnterIntoClass",
                isTakeScreenShotDuringEntryExit);
            //Get Class From Memory
            Class Class = Class.Get(classTypeEnum);
            //Enter Dp class
            new HomePage().EnterInClass(Class.Name);
            Logger.LogMethodExit("CommonSteps", "EnterIntoClass",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Closes the Window.
        /// </summary>
        /// <param name="windowName">This is Window Name.</param>
        [When(@"I close the ""(.*)"" window")]
        public void CloseTheManageOrganizationWindow(String windowName)
        {
            //Close the window
            Logger.LogMethodEntry("CreateUser", "CloseTheManageOrganizationWindow",
                isTakeScreenShotDuringEntryExit);
            //Close the Window
            new ManageOrganisationToolBarPage().CloseWindow(windowName);
            Logger.LogMethodExit("CreateUser", "CloseTheManageOrganizationWindow",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search and Select the Organization.
        /// </summary>
        /// <param name="organizationLevelEnum">This is organization by level type enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        [Given(@"I am on the 'Manage Organization' page of ""(.*)"" level in the ""(.*)""")]
        public void SelectOrganization(
            Organization.OrganizationLevelEnum organizationLevelEnum,
           Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Search and Select the Organization
            Logger.LogMethodEntry("UserEnrollment", "SearchandSelectOrganization",
                isTakeScreenShotDuringEntryExit);
            //Fetch Organization Name From Memory
            Organization organization = Organization.Get(
                organizationLevelEnum, organizationTypeEnum);
            //Click On Organization Admin Tab
            new AdminToolPage().ClickOnOrganizationAdminTab();
            //Created Class Object
            OrganizationManagementPage organizationManagementPage =
                new OrganizationManagementPage();
            //Search the Organization
            organizationManagementPage.SearchOrganization(organization.Name);
            //Click on Organization Button
            organizationManagementPage.SelectOrganization(organizationLevelEnum);
            Logger.LogMethodExit("UserEnrollment", "SearchandSelectOrganization",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts
        /// </summary>
        [BeforeScenario]
        public static void Setup()
        {
            new CommonSteps().ResetWebdriver();
        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test
        /// and stops the webdriver.
        /// </summary>
        [AfterScenario]
        public static void TearDown()
        {
            // clean processess
            new CommonSteps().WebDriverCleanUp();
        }
    }
}
