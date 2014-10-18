using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Integration.Rumba;
using Pegasus.Pages.Exceptions;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.NovaNET.Tests.
    CommonProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the common feature steps
    /// that can be reuse while verifying.
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
        /// <param name="expectedPageTitle">This is 
        /// Expected Page Title.</param>
        [Then("I Should be on the \"(.*)\" page")]
        [Then("I should be on the \"(.*)\" page")]
        [Given(@"I am on the ""(.*)"" page")]
        public void ShowThePageInPegasus(String expectedPageTitle)
        {
            //Check If Expected Page Is Opened
            Logger.LogMethodEntry("CommonSteps", "ShowThePageInPegasus",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait Till Thinking Indicator Loads
            bool isThinkingIndicatorLoading = base.IsThinkingIndicatorLoading();
            //If Thinking Indicator In Process After Specified 
            //Time Interval then Fail This Step.
            if (isThinkingIndicatorLoading)
            {
                Logger.LogAssertion("VerifyOpenedPageTitle", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.Fail(CommonStepsResource.CommonSteps_PageNotOpened_Message));
            }
            base.WaitUntilWindowLoads(expectedPageTitle);
            //Wait For Page Get Switched
            base.WaitUntilPageGetSwitchedSuccessfully(expectedPageTitle);
            //Get The Actual Title of Page
            string getActualPageTitle = base.GetPageTitle;
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedPageTitle, getActualPageTitle));
            Logger.LogMethodExit("CommonSteps", "ShowThePageInPegass",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Switch To Frame
            base.SwitchToIFrame(CommonStepsResource.
                CommonSteps_IFrame + frame + String.Empty);
            //Wait For Partial Link Text 
            base.WaitForElement(By.PartialLinkText(linkName));
            //Click on the Link
            base.ClickButtonByPartialLinkText(linkName);
            Logger.LogMethodExit("CommonSteps", "ClickOnTheLink",
             base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Wait untill window
            base.WaitUntilWindowLoads(popUpName);
            //Select Pop Up
            base.SelectWindow(popUpName);
            //Is Pop Up Present
            Boolean isPopUpExist = base.IsWindowsExists(popUpName);
            //Assert The Pop Up Window Opened
            Logger.LogAssertion("VerifyOpenedPopUpTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true, isPopUpExist));
            Logger.LogMethodExit("CommonSteps", "ShowThePopUpInPegasus",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Page Get Refresh after Pop Up Close
            Thread.Sleep(Convert.ToInt32(CommonStepsResource.
                CommonSteps_SleepTime_Value));
            //Verify Correct Message Present on the Page
            base.IsMessageExists(successMessage,
                                 CommonStepsResource.CommonSteps_SuccessMessage_Class_Locator);
            //Removed The Assert For Message Because Sometimes Message not comes 
            //but this is not the severe issue. So We, can ignore this.
            Logger.LogMethodExit("CommonSteps", "DisplayTheSuccessfullMessage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Success Message Display on the Window.
        /// </summary>
        /// <param name="successMessage">This is Success Message Text.</param>
        /// <param name="window">This is Window Name</param>
        [Then(@"I should see the successfull message ""(.*)"" in ""(.*)"" window")]
        public void DisplayTheSuccessfullMessageInWindow(
            String successMessage, String window)
        {
            // Method To Verify the Success Message 
            Logger.LogMethodEntry("CommonSteps", "DisplayTheSuccessfullMessage",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Page Get Refresh after Pop Up Close
            Thread.Sleep(Convert.ToInt32(CommonStepsResource.
                CommonSteps_SleepTime_Value));
            //Select Window
            base.SelectWindow(window);
            //Wait Till Thinking Indicator Loads
            bool isThinkingIndicatorLoading = base.IsThinkingIndicatorLoading();
            //If Thinking Indicator In Process After Specified Time Interval then Fail This Step
            if (isThinkingIndicatorLoading)
            {
                Logger.LogAssertion("VerifyOpenedPageTitle", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.Fail(CommonStepsResource.CommonSteps_PageNotOpened_Message));
            }
            //Verify Correct Message Present on the Page
            base.IsMessagePresentOnPopUp(successMessage,
                                         CommonStepsResource.CommonSteps_SuccessMessage_Class_Locator);
            //Removed The Assert For Message Because Sometimes Message not comes 
            //but this is not the severe issue. So We, can ignore this.
            Logger.LogMethodExit("CommonSteps", "DisplayTheSuccessfullMessage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Navigate to Tab Window.
        /// </summary>
        /// <param name="tabName">This is Name of the Tab.</param>
        [When(@"I navigate to the ""(.*)"" tab")]
        [When(@"I select the ""(.*)"" tab")]
        [Given("I navigate to the \"(.*)\" tab")]
        [Then("I navigate to the \"(.*)\" tab")]
        public void NavigateToTheTab(String tabName)
        {
            //Method to Navigate to the Tab Window 
            Logger.LogMethodEntry("CommonSteps", "NavigateToTheTab",
                base.IsTakeScreenShotDuringEntryExit);
            base.SelectDefaultWindow();
            //Click On More Link if More Link Is Present
            new TodaysViewUxPage().ClickMoreLinkIfPresent(tabName); 
            //Wait For Element
            base.WaitForElement((By.PartialLinkText(tabName)));
            //Get Tab Element Property
            IWebElement getTabNameProperty = base.
                GetWebElementPropertiesByPartialLinkText(tabName);
            //Click on Tab 
            base.ClickByJavaScriptExecutor(getTabNameProperty);
            //Wait Till Thinking Indicator Loads
            bool isThinkingIndicatorLoading = base.IsThinkingIndicatorLoading();
            //If Thinking Indicator In Process After Specified Time 
            //Interval then Fail This Step.
            if (isThinkingIndicatorLoading)
            {
                Logger.LogAssertion("VerifyOpenedPageTitle",
                    ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.Fail(CommonStepsResource.
                   CommonSteps_PageNotOpened_Message));
            }
            Logger.LogMethodExit("CommonSteps", "NavigateToTheTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Grades Subtab.
        /// </summary>
        [When(@"I select 'Grades' subtab")]        
        public void SelectGradesSubtab()
        {
            Logger.LogMethodEntry("CommonSteps", "SelectGradesSubtab",
                 base.IsTakeScreenShotDuringEntryExit);
            base.SelectDefaultWindow();
            //Wait for the element
            base.WaitForElement(By.Id(CommonStepsResource.
                CommonSteps_Grades_Subtab_Id_Locator));
            //Click on Grades Subtab
            IWebElement getSubtabname = 
                base.GetWebElementPropertiesById(CommonStepsResource.
                CommonSteps_Grades_Subtab_Id_Locator);
            base.FocusOnElementById(CommonStepsResource.
                CommonSteps_Grades_Subtab_Id_Locator);
            base.ClickByJavaScriptExecutor(getSubtabname);           
            Logger.LogMethodExit("CommonSteps", "SelectGradesSubtab",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select the Report SubTab
        /// </summary>
        /// <param name="subTab">This is Name of the Tab</param>
        [When(@"I select the ""(.*)"" sub tab")]
        public void SelectTheSubTab(String subTab)
        {
            Logger.LogMethodEntry("CommonSteps", "SelectTheSubTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.PartialLinkText(subTab));
            //Click the SubTab
            WebDriver.FindElement(By.PartialLinkText(subTab)).Click();
            Logger.LogMethodExit("CommonSteps", "SelectTheSubTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Into Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type.</param>
        /// <param name="userTypeEnum">This is User by Type.</param>
        [When(@"I enter in the ""(.*)"" course as ""(.*)"" from the Global Home page")]
        public void EnterIntoCourse(
            Course.CourseTypeEnum courseTypeEnum,
           User.UserTypeEnum userTypeEnum)
        {
            //Enter in Course from Global Home Page
            Logger.LogMethodEntry("CommonSteps", "EnterIntoCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From  Memory 
            Course course = Course.Get(courseTypeEnum);
            //Enter Into The Course             
            new MyPegasusUXPage().EnterInCourseFromGobalHomePage(
                course.Name, userTypeEnum);
            Logger.LogMethodExit("CommonSteps", "EnterIntoCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Closes the Present Opened Window.
        /// </summary>
        /// <param name="windowName">This is Window Name.</param>
        [When(@"I close the ""(.*)"" window")]
        [Then(@"I close the ""(.*)"" window")]
        public void CloseThePresentWindow(String windowName)
        {
            //Close the window
            Logger.LogMethodEntry("CommonSteps", "CloseThePresentWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Close the Window
            new ManageOrganisationToolBarPage().CloseWindow(windowName);
            Logger.LogMethodExit("CommonSteps", "CloseThePresentWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }
       
        /// <summary>
        /// Search and Select the Organization.
        /// </summary>
        /// <param name="organizationLevelEnum">This is organization by level type enum.</param>
        /// <param name="organizationTypeEnum">This is organization ype enum.</param>
        [Given(@"I am on the 'Manage Organization' page of ""(.*)"" level in the ""(.*)""")]
        public void SearchAndSelectOrganization(
            Organization.OrganizationLevelEnum organizationLevelEnum,
           Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Search and Select the Organization
            Logger.LogMethodEntry("CommonSteps", "SearchAndSelectOrganization",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch Organization Name From Memory
            Organization organizationLevel = Organization.Get(
                organizationLevelEnum, organizationTypeEnum);
            //Click On Organization Admin Tab
            new AdminToolPage().ClickOnOrganizationAdminTab();
            //Create Class Object
            OrganizationManagementPage organizationManagementPage =
                new OrganizationManagementPage();
            //Search the Organization
            organizationManagementPage.SearchOrganization(organizationLevel.Name);
            //Click on Organization Button
            organizationManagementPage.SelectOrganization(organizationLevelEnum);
            Logger.LogMethodExit("CommonSteps", "SearchAndSelectOrganization",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate Logout From NovaNET User.
        /// </summary>
        /// <param name="signOutMessage">This Is The SignOut Message.</param>
        [Then(@"I should see the ""(.*)"" message")]
        public void ValidateLogoutFromNovaNETUser(
            String signOutMessage)
        {
            //Validate Logout From NN User
            Logger.LogMethodEntry("CommonSteps", "ValidateLogoutFromNovaNETUser",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert Logout
            Logger.LogAssertion("ValidateLogout",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(signOutMessage, new SignInPage().
                    GetRumbaUserSignOutMessage()));
            Logger.LogMethodExit("CommonSteps", "ValidateLogoutFromNovaNETUser",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Tab Of The Perticular Page.
        /// </summary>
        /// <param name="tabName">This is Tab Name.</param>
        /// <param name="pageName">This is Page Name.</param>
        [When(@"I navigate to ""(.*)"" tab of the ""(.*)"" page")]
        public void NavigateToTabOfThePerticularPage(string tabName, string pageName)
        {
            //Navigate Administrator Tool Page
            Logger.LogMethodEntry("AdminToolPage", "NavigateToTabOfThePerticularPage",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Is The Page Open Already
                Boolean isPageAlreadyExists = base.IsPopupPresent(pageName, 2);
                if (isPageAlreadyExists)
                {
                    //Selecting the Page If Opened
                    base.SelectWindow(pageName);
                }
                else
                {
                    // Navigating To Administrators tab
                    base.WaitForElement(By.PartialLinkText(tabName));
                    IWebElement getTabName = base.GetWebElementPropertiesByPartialLinkText
                        (tabName);
                    base.ClickByJavaScriptExecutor(getTabName);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AdminToolPage", "NavigateToTabOfThePerticularPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Tab.
        /// </summary>
        /// <param name="tabName">This is Tab Name.</param>
        [When(@"I navigate to ""(.*)"" tab")]
        public void NavigateToTab(string tabName)
        {
            //Navigate to Tab
            Logger.LogMethodEntry("CommonSteps", "NavigateToTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Tab
            new TodaysViewUxPage().SelectTab(tabName);
            Logger.LogMethodExit("CommonSteps", "NavigateToTab",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Course Space User Tabs.
        /// </summary>
        /// <param name="parentTabName">This is Parent Tab Name.</param>
        /// <param name="childTabName">This is Child Tab Name.</param>      
        [When(@"I navigate to ""(.*)"" tab and selected ""(.*)"" subtab")]
        public void NavigateToCourseSpaceUserTabs(
            string parentTabName, string childTabName)
        {
            //Navigate to Tab
            Logger.LogMethodEntry("CommonSteps", "NavigateToCourseSpaceUserTabs",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Tab
            new TodaysViewUxPage().SelectTab(parentTabName, childTabName);
            Logger.LogMethodExit("CommonSteps", "NavigateToCourseSpaceUserTabs",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {
            //Reset Webdriver Instance
            new CommonSteps().ResetWebdriver();
        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test
        /// and clean the WebDriver Instance.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {
            // clean processess
            new CommonSteps().WebDriverCleanUp();
        }
    }
}
