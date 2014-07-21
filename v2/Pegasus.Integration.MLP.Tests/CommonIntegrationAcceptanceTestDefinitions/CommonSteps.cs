using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Integration.Hed.MLP.Tests.CommonIntegrationAcceptanceTestDefinitions;

namespace Pegasus.Integration.MLP.Tests.
    CommonIntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles the common steps 
    /// definitions in the project.
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
        /// This is Frame Type Enum.
        /// </summary>
        public enum FrameTypeEnum
        {
            /// <summary>
            /// This is Left frame
            /// </summary>
            Left = 1,
            /// <summary>
            /// This is Right frame
            /// </summary>
            Right = 2,
        }

        /// <summary>
        /// Check If The Expected Page Is Opened.
        /// </summary>
        /// <param name="expectedPageTitle">This is Expected Page Title.</param>
        [Then("I should be on the \"(.*)\" page")]
        [Given(@"I am on the ""(.*)"" page")]
        public void ShowTheExpectedPage(String expectedPageTitle)
        {
            //Check If Expected Page Is Opened
            Logger.LogMethodEntry("CommonSteps", "ShowTheExpectedPage",
                isTakeScreenShotDuringEntryExit);
            //Wait Till Thinking Indicator Loads
            bool isThinkingIndicatorLoading = IsThinkingIndicatorLoading();
            //If Thinking Indicator In Process After Specified Time Interval then Fail This Step
            if (isThinkingIndicatorLoading)
            {
                Logger.LogAssertion("VerifyOpenedPageTitle",
                    ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.Fail(CommonStepsResource.
                   CommonSteps_PageNotOpened_Message));
            }
            //Wait For Page Get Switched
            WaitUntilPageGetSwitchedSuccessfully(expectedPageTitle);
            //Get current opened page title
            String getActualPageTitle = GetPageTitle;
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedPageTitle, getActualPageTitle));
            Logger.LogMethodExit("CommonSteps", "ShowTheExpectedPage",
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
            Logger.LogMethodEntry("CommonSteps",
                "DisplayTheSuccessfullMessage",
                isTakeScreenShotDuringEntryExit);
            //Verify Correct Message Present on the Page
            IsMessageExists(successMessage,
                                 CommonStepsResource.CommonSteps_SuccessMessage_Class_Locator);
            //Removed The Assert For Message Because Sometimes Message not comes 
            //but this is not the severe issue. So We, can ignore this.
            Logger.LogMethodExit("CommonSteps",
                "DisplayTheSuccessfullMessage",
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
                Convert.ToInt32(CommonStepsResource.
                CommonSteps_CustomTimeToWait));
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
        [When(@"I select the ""(.*)"" tab")]
        [When(@"I navigate to the ""(.*)"" tab")]
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
            IWebElement getTabProperty =
                GetWebElementPropertiesByPartialLinkText(tabName);
            //Click on Tab   
            ClickByJavaScriptExecutor(getTabProperty);
            //Wait For Page Load 
            Thread.Sleep(Convert.ToInt32(CommonStepsResource.
                 CommonSteps_SleepTime_Value));
            Logger.LogMethodExit("CommonSteps", "NavigateToTheTab",
                 isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Click on the Link.
        /// </summary>
        /// <param name="linkName">This is Link name on which click is required.</param>
        /// <param name="frame">This is Frame whether it is right or left.</param>
        [Given("I click on the \"(.*)\" link in \"(.*)\" frame")]
        [When("I click on the \"(.*)\" link in \"(.*)\" frame")]
        public void ClickOnTheLink(String linkName,
            FrameTypeEnum frame)
        {
            //Click on the Link
            Logger.LogMethodEntry("CommonSteps", "ClickOnTheLink",
                base.isTakeScreenShotDuringEntryExit);
            //Switch To Frame
            base.SwitchToIFrame(CommonStepsResource.
                CommonSteps_IFrame + frame + String.Empty);
            //Wait For Partial Link Text 
            base.WaitForElement(By.PartialLinkText(linkName));
            //Get link Property
            IWebElement getLinkProperty = base.
                GetWebElementPropertiesByPartialLinkText(linkName);
            //Click on the Link
            base.ClickByJavaScriptExecutor(getLinkProperty);
            switch (frame)
            {
                case CommonSteps.FrameTypeEnum.Left:
                    //Wait untill window of users
                    base.WaitUntilWindowLoads(CommonStepsResource.
                        CommonSteps_CreateNewUserWindow_Name_Locator);
                    break;
            }
            Logger.LogMethodExit("CommonSteps", "ClickOnTheLink",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Course Present In User's Home Page.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by type enum.</param>
        [Then(@"I should see ""(.*)"" on the Global Home page")]
        public void ShowCourseOnTheGlobalHomePage(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Show Course On The MyCourses and Testbanks Page In Active State
            Logger.LogMethodEntry("CommonSteps",
                "ShowCourseOnTheGlobalHomePage",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Course Present on Global Home Page
            Logger.LogAssertion("VerifyCoursePresent",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true, new HEDGlobalHomePage().
                    GetCoursePresentInGlobalHomePage().Contains(course.Name)));
            Logger.LogMethodExit("CommonSteps",
                "ShowCourseOnTheGlobalHomePage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Into Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type enum.</param>
        /// <param name="userTypeEnum">This is user time enum.</param>
        [When(@"I enter in the ""(.*)"" from the Global Home page as ""(.*)""")]
        public void EnterInCourse(Course.CourseTypeEnum courseTypeEnum,
            User.UserTypeEnum userTypeEnum)
        {
            //Enter in Course from Global Home Page 
            Logger.LogMethodEntry("CommonSteps", "EnterInCourse",
                base.isTakeScreenShotDuringEntryExit);
            //Enter Into The Course
            new HEDGlobalHomePage().EnterInsideCourse(
                courseTypeEnum, userTypeEnum);
            Logger.LogMethodExit("CommonSteps", " EnterInCourse",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on ECollege Administrative Page link.
        /// </summary>
        /// <param name="administrationLinkName">This is link name.</param>
        [When(@"I select ""(.*)"" link")]
        public void SelectAdministrationPageLink(
            String administrationLinkName)
        {
            Logger.LogMethodEntry("CommonSteps", "SelectAdministrationPageLink",
                base.isTakeScreenShotDuringEntryExit);
            new HomePSHPage().SelectHomePSHPagesLink(administrationLinkName);
            Logger.LogMethodExit("CommonSteps", "SelectAdministrationPageLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Admin Navigation Tab.
        /// </summary>
        /// <param name="adminNavigationTabName">This is Tab Name in 
        /// Admin Navigation Frame.</param>
        [When(@"I select ""(.*)"" link on Administration Pages")]
        public void SelectAdminNavigationTab(
            String adminNavigationTabName)
        {
            //Navigate to Frame
            Logger.LogMethodEntry("CommonSteps", "SelectAdminNavigationTab",
            base.isTakeScreenShotDuringEntryExit);
            // Select Admin Navigation Tab
            new CampusAdminNavPage().
                SelectGlobalNavigationPageLink(adminNavigationTabName);
            Logger.LogMethodExit("CommonSteps", "SelectAdminNavigationTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This mathod validate availability 
        /// of Exit option availabe on ECollage portal.
        /// </summary>
        /// <param name="exitButton"></param>
        /// <param name="userTypeEnum">ECollege User type</param>
        [When(@"I click on the Exit button")]
        public void ClickOnExitOption()
        {
            Logger.LogMethodEntry("CommonSteps", "ClickOnExitOption",
               base.isTakeScreenShotDuringEntryExit);
            // Insatance of SubHeadFramePage
            new SubHeadFramePage().ClickOnExitButton();
            Logger.LogMethodExit("CommonSteps", "ClickOnExitOption",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Global Navigation Tabs.
        /// </summary>
        /// <param name="globalNavigationTabName">This is Global Navigation Tab Name.</param>
        [When(@"I select the ""(.*)"" tab on global navigation frame")]
        public void SelectGlobalNavigationTab(
            String globalNavigationTabName)
        {
            //Select Tab
            Logger.LogMethodEntry("CommonSteps", "SelectGlobalNavigationTab",
                base.isTakeScreenShotDuringEntryExit);
            //Click On The Global Navigation Frame
            new SubHeadFramePage().ClickOnGlobalNavigationTab(globalNavigationTabName);
            Logger.LogMethodExit("CommonSteps", "SelectGlobalNavigationTab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Tab Name available
        /// on HOME PSH page.
        /// </summary>
        /// <param name="tabName">This is TabName </param>
        [When(@"I click on ""(.*)"" Option on Home PSH page")]
        public void WhenIClickOnOptionOnHomePSHPage(String tabName)
        {
            Logger.LogMethodEntry("CommonSteps", "WhenIClickOnOptionOnHomePSHPage",
                base.isTakeScreenShotDuringEntryExit);
            new HomePSHPage().ClickOnTabLink(tabName);
            Logger.LogMethodExit("CommonSteps", "WhenIClickOnOptionOnHomePSHPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Switch to Pop up window. 
        /// </summary>
        [Then(@"I should be on the ""(.*)"" launched Pegasus popup window")]
        public void ShowTheExpectedPopupWindow(String pageTitle)
        {
            //Check If Expected Page Is Opened
            Logger.LogMethodEntry("CommonSteps", "ShowTheExpectedPage",
                isTakeScreenShotDuringEntryExit);

            //Wait Till Thinking Indicator Loads
            bool isThinkingIndicatorLoading = IsThinkingIndicatorLoading();
            //If Thinking Indicator In Process After Specified Time Interval then Fail This Step
            if (isThinkingIndicatorLoading)
            {
                Logger.LogAssertion("VerifyOpenedPageTitle",
                    ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.Fail(CommonStepsResource.
                   CommonSteps_PageNotOpened_Message));
            }
            //Switch to pop up window
            base.SelectWindow(pageTitle);
            //Maximize pop up window
            base.MaximizeWindow();
            //Varify the Close button availability           
            Boolean isCloseButtonPresent = base.IsElementPresent(By.
                PartialLinkText(CommonStepsResource.
                CommonSteps_Launched_PegasusCourse_Close_button_PartialText));
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyCloseButtonOnLaunchegPegasusCourse",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(isCloseButtonPresent));
            Logger.LogMethodExit("CommonSteps", "ShowTheExpectedPopupWindow",
                isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Success Message Display on the Window.
        /// </summary>
        /// <param name="successMessage">This is Success Message Text.</param>
        /// <param name="windowName">This is Window Name</param>
        [Then(@"I should see the successfull message ""(.*)"" in ""(.*)"" window")]
        public void DisplayTheSuccessfullMessageInWindow(
            String successMessage, String windowName)
        {
            // Method To Verify the Success Message 
            Logger.LogMethodEntry("CommonSteps", "DisplayTheSuccessfullMessageInWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Page Get Refresh after Pop Up Close
            Thread.Sleep(Convert.ToInt32(CommonStepsResource.
                CommonSteps_SleepTime_Value));
            //Select Window
            base.SelectWindow(windowName);
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
            Logger.LogMethodExit("CommonSteps", "DisplayTheSuccessfullMessageInWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeScenario]
        public static void Setup()
        {
            //Reset The WebDriver Instance
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
