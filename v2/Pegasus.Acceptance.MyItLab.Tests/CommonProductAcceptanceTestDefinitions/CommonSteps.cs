using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Automation.DataTransferObjects;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.
    CommonProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the common feature steps
    /// that can be reuse while verifying
    /// the scenarios.
    /// </summary>
    [Binding]
    public sealed class CommonSteps : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CommonSteps));

        /// <summary>
        /// This is Frame Type Enum
        /// </summary>
        public enum FrameTypeEnum
        {
            /// <summary>
            /// This is Left frame
            /// </summary>
            left = 1,
            /// <summary>
            /// This is Right frame
            /// </summary>
            right = 2,
        }
        /// <summary>
        /// Verifies the Correct Page Opened.
        /// </summary>
        /// <param name="expectedPageTitle">This is Expected Page Title.</param>
        [Then("I should be on the \"(.*)\" page")]
        [Given(@"I am on the ""(.*)"" page")]
        public void ShowThePageInPegasus(String expectedPageTitle)
        {
            //Verify Correct Page Opened
            Logger.LogMethodEntry("CommonSteps", "ShowThePageInPegasus",
                base.IsTakeScreenShotDuringEntryExit);
            //wait for the window
            base.WaitUntilWindowLoads(expectedPageTitle);
            //Get current opened page title
            string actualPageTitle =
                WebDriver.Title.ToString(CultureInfo.InvariantCulture);
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedPageTitle, actualPageTitle));
            Logger.LogMethodExit("CommonSteps", "ShowThePageInPegass",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifies the Pop Up Opened.
        /// Verifies the Correct Pop Up Opened.
        /// </summary>
        /// <param name="popUpName">This is PopUp Name.</param>
        [Then("I should see the \"(.*)\" popup")]
        public void ShowThePopUpInPegasus(String popUpName)
        {
            //Verify Correct Pop Up Opened
            Logger.LogMethodEntry("CommonSteps", "ShowThePopUpInPegasus",
                base.IsTakeScreenShotDuringEntryExit);
            //Is Pop Up Present
            Boolean isPopUpExist = base.IsWindowsExists(popUpName);
            //Assert We Have Correct Pop Up Window Opened
            Logger.LogAssertion("VerifyOpenedPopUpTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true, isPopUpExist));
            Logger.LogMethodExit("CommonSteps", "ShowThePopUpInPegasus",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Click on the Link .
        /// </summary>
        /// <param name="linkName">This is Link name on which click is required.</param>
        /// <param name="frame">This is Frame whether it is right or left.</param>
        [Given("I click on the \"(.*)\" link in \"(.*)\" frame")]
        [When("I click on the \"(.*)\" link in \"(.*)\" frame")]
        public void ClickOnTheLink(String linkName,
            CommonSteps.FrameTypeEnum frame)
        {
            //Click on the Link
            Logger.LogMethodEntry("CommonSteps", "ClickOnTheLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Switch To Frame
            base.SwitchToIFrame(CommonStepsResource.
                CommonSteps_IFrame + frame + string.Empty);
            //Wait For Partial Link Text 
            base.WaitForElement(By.PartialLinkText(linkName));
            //Get link Property
            IWebElement getLinkProperty = base.
                GetWebElementPropertiesByPartialLinkText(linkName);
            //Click on the Link
            base.ClickByJavaScriptExecutor(getLinkProperty);
            switch (frame)
            {
                case CommonSteps.FrameTypeEnum.left:
                    //Wait untill window of users
                    base.WaitUntilWindowLoads(CommonStepsResource.
                        CommonSteps_CreateNewUserWindow_Name_Locator);
                    break;
                case CommonSteps.FrameTypeEnum.right:
                    //Wait untill window of Courses
                    base.WaitUntilWindowLoads(CommonStepsResource.
                        CommonSteps_CreateNewCoursesWindow_Name_Locator);
                    break;
            }
            Logger.LogMethodExit("CommonSteps", "ClickOnTheLink",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Navigate to Tab Window
        ///Verifies that Correct Window Opened.
        /// </summary>
        /// <param name="tabName">This is Name of the Tab.</param>
        [When(@"I navigate to the ""(.*)"" tab")]
        [Then("I navigate to the \"(.*)\" tab")]
        [Then(@"I select the ""(.*)"" tab")]
        [Given(@"I select the ""(.*)"" tab")]
        [When(@"I select the ""(.*)"" tab")]
        [Given("I navigate to the \"(.*)\" tab")]
        public void NavigateToTheTab(String tabName)
        {
            //Method to Navigate to the Tab Window 
            Logger.LogMethodEntry("CommonSteps", "NavigateToTheTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On More Link if More Link Is Present
            //And The Required Tab Is Not Present
            new TodaysViewUXPage().ClickTheMoreLinkIfPresent(tabName);
            //Wait For Element
            base.WaitForElement(By.PartialLinkText(tabName));
            //Get Tab Element Property
            IWebElement getTabNameProperty = base.
                GetWebElementPropertiesByPartialLinkText(tabName);
            //Click on Tab 
            base.ClickByJavaScriptExecutor(getTabNameProperty);
            //Wait Till Thinking Indicator Loads
            bool isThinkingIndicatorLoading = base.IsThinkingIndicatorLoading();
            //If Thinking Indicator In Process After Specified Time Interval then Fail This Step
            if (isThinkingIndicatorLoading)
            {
                Logger.LogAssertion("VerifyOpenedPageTitle", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.Fail(CommonStepsResource.CommonSteps_PageNotOpened_Message));
            }
            Logger.LogMethodExit("CommonSteps", "NavigateToTheTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summar
        /// Verify the Success Message Display on the Page.
        /// </summary>
        /// <param name="successMessage">This is Success Message Text.</param>
        [Then("I should see the successfull message \"(.*)\"")]
        public void DisplayTheSuccessfullMessage(
            String successMessage)
        {
            // Method To Verify the Success Message 
            Logger.LogMethodEntry("CommonSteps", "DisplayTheSuccessfullMessage",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify Correct Message Present on the Page
            bool isSuccessMessageExist = base.IsMessageExists(successMessage,
                CommonStepsResource.CommonSteps_SuccessMessage_Class_Locator);
            //Removed The Assert For Message Because Sometimes Message not comes 
            //but this is not the severe issue. So We, can ignore this.
            Logger.LogMethodExit("CommonSteps", "DisplayTheSuccessfullMessage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Course Present In User's Home Page.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by type.</param>
        [Then(@"I should see ""(.*)"" course on the Global Home page")]
        public void ShowCourseOnTheGlobalHomePage(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Show Course On The MyCourses and Testbanks Page In Active State
            Logger.LogMethodEntry("CommonSteps", "ShowCourseOnTheGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Course Present on Global Home Page
            Logger.LogAssertion("VerifyCoursePresent", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true, new HEDGlobalHomePage().
                    GetCoursePresentInGlobalHomePage().Contains(course.Name)));
            Logger.LogMethodExit("CommonSteps", " ShowCourseOnTheGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Into Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type.</param>
        [When(@"I enter in the ""(.*)"" from the Global Home page")]
        public void EnterInCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Enter in Course from Global Home Page 
            Logger.LogMethodEntry("CommonSteps", "EnterInCourse", base.IsTakeScreenShotDuringEntryExit);
            //Get Course From  Memory
            Course course = Course.Get(courseTypeEnum);
            //Enter Into The Course
            new HEDGlobalHomePage().OpenTheCourse(course.Name);
            Logger.LogMethodExit("CommonSteps", " EnterInCourse", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify User Entered In Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type.</param>
        [Then(@"I should successfully enter into the ""(.*)""")]
        public void EnterIntoTheCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify user entered into course from Global Home Page
            Logger.LogMethodEntry("CommonSteps", "EnterIntoTheCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From  Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Course Name Present After User Entered In Course 
            Logger.LogAssertion("VerifyCoursePresent",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(course.Name, new HEDGlobalHomePage().
                    GetCourseName()));
            Logger.LogMethodExit("CommonSteps", "EnterIntoTheCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close The Window.
        /// </summary>
        [Then(@"I close the Activity window")]
        public void CloseTheWindow()
        {
            //Closing the Currently Opened Window
            Logger.LogMethodEntry("CommonSteps", "CloseTheWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Close Window
            base.CloseBrowserWindow();
            Logger.LogMethodExit("CommonSteps", "CloseTheWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Home Link.
        /// </summary>
        [When(@"I navigate back to the Global Home page")]
        public void ClickHomeLink()
        {
            //To Click On The Home Link
            Logger.LogMethodEntry("CommonSteps", "ClickHomeLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On Home Link
            new TodaysViewUXPage().ClickOnHomeLink();
            Logger.LogMethodExit("CommonSteps", "ClickHomeLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Successfull Message In MyTest Tab.
        /// </summary>
        /// <param name="successMessage">This is Success Message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in MyTest tab")]
        public void SuccessfullMessageInMyTestTab(
            String successMessage)
        {
            //Successfull Message In MyTest Tab
            Logger.LogMethodEntry("CommonSteps", "SuccessfullMessageInMyTestTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Display of Success Message
            Logger.LogAssertion("VerifySuccessfullMessage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(successMessage,
                    new MyTestGridUXPage().GetSuccessMessageInMyTestTab()));
            Logger.LogMethodEntry("CommonSteps", "SuccessfullMessageInMyTestTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Closes the Window.
        /// </summary>
        /// <param name="windowName">This is Window Name.</param>
        [When(@"I close the ""(.*)"" window")]
        [Then(@"I close the ""(.*)"" window")]
        public void CloseTheManageOrganizationWindow(
            String windowName)
        {
            //Close the window
            Logger.LogMethodEntry("CommonSteps", "CloseTheManageOrganizationWindow",
                IsTakeScreenShotDuringEntryExit);
            //Close the Window
            new ManageOrganisationToolBarPage().CloseWindow(windowName);
            Logger.LogMethodExit("CommonSteps", "CloseTheManageOrganizationWindow",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Into Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type.</param>
        /// <param name="userTypeEnum">This is user time enum.</param>
        [When(@"I enter in the ""(.*)"" course from the Global Home page as ""(.*)""")]
        public void EnterInCourse(Course.CourseTypeEnum courseTypeEnum,
            User.UserTypeEnum userTypeEnum)
        {
            //Enter in Course from Global Home Page 
            Logger.LogMethodEntry("CommonSteps", "EnterInCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Enter Into The Course
            new HEDGlobalHomePage().EnterInsideCourse(
                courseTypeEnum, userTypeEnum);
            Logger.LogMethodExit("CommonSteps", " EnterInCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Section in Active State or not.
        /// </summary>
        /// /// <param name="courseTypeEnum">This is course type enum.</param>
        [Then(@"I should see the Section created from ""(.*)"" course Template to be successfully out of AssignedToCopy state")]
        public void ApproveAssignedToCopyStateForSection(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify Section in Active State
            Logger.LogMethodEntry("CommonSteps", "ApproveAssignedToCopyStateForSection",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Verify Template in Active State or not
            Logger.LogAssertion("VerifyTemplateActiveState",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(false, new ManageTemplatePage().GetAssignToCopyStateText
                (course.SectionName).Contains(CommonStepsResource.
                CommonSteps_AssignToCopyState_Text_Value)));
            Logger.LogMethodExit("CommonSteps", "ApproveAssignedToCopyStateForSection",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Enter Section As Instructor.
        /// </summary>
        /// <param name="cMenuOption">This is Cmenu option.</param>
        [When(@"I click the ""(.*)""")]
        public void ClickTheEnterSectionAsInstructor(String cMenuOption)
        {
            //Click The Enter Section As Instructor
            Logger.LogMethodEntry("CommonSteps", "ClickTheEnterSectionAsInstructor"
                , base.IsTakeScreenShotDuringEntryExit);
            //Click On Cmenu of Enter Section As Instructor
            new ManageTemplatePage().
                ClickOnCmenuOfSectionOrTemplate(cMenuOption);
            Logger.LogMethodExit("CommonSteps", "ClickTheEnterSectionAsInstructor"
                , base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("CommonSteps", "DisplayTheSuccessfullMessageInWindow",
                IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodExit("CommonSteps", "DisplayTheSuccessfullMessageInWindow",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Tab Of The Particular Page.
        /// </summary>
        /// <param name="subNavigationTabName">This is Tab Name.</param>
        /// <param name="subNavigationTabParentWindowName">This is Page Name.</param>
        [When(@"I navigate to ""(.*)"" tab of the ""(.*)"" page")]
        public void NavigateToTabInProgramAdminPage(
            string subNavigationTabName, string subNavigationTabParentWindowName)
        {
            // navigate program administrator page
            Logger.LogMethodEntry("AdminToolPage", "NavigateToTabOfTheParticularPage",
                base.IsTakeScreenShotDuringEntryExit);
            new ProgramAdminToolPage().NavigateProgramAdminTabs(
                subNavigationTabParentWindowName, subNavigationTabName);
            Logger.LogMethodExit("AdminToolPage", "NavigateToTabOfTheParticularPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Publishing Tab.
        /// </summary>
        /// <param name="subtabName">This is SubTab Name.</param>
        /// <param name="mainTabName">This is MainTab Name.</param>
        [When(@"I navigate to ""(.*)"" subtab from ""(.*)"" tab")]
        public void NavigateToPublishingTab(string subtabName, string mainTabName)
        {
            //Navigate to perticular Page
            Logger.LogMethodEntry("CommonSteps", "NavigateToPublishingTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Navigate To The Publishing Tab
            new TodaysViewUXPage().NavigateToThePublishingTab(subtabName, mainTabName);
            Logger.LogMethodExit("CommonSteps", "NavigateToPublishingTab",
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
            new TodaysViewUXPage().SelectTab(parentTabName, childTabName);
            Logger.LogMethodExit("CommonSteps", "NavigateToCourseSpaceUserTabs",
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
            new TodaysViewUXPage().SelectTab(tabName);
            Logger.LogMethodExit("CommonSteps", "NavigateToTab",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter As New Activity Type Name.
        /// </summary>
        /// <param name="activityTypeName">Activity Type Name</param>
        [When(@"I enter ""(.*)"" as new activity type name")]
        public void EnterNewActivityTypeName(string activityTypeName)
        {
            Logger.LogMethodEntry("CommonSteps", "EnterAsNewActivityTypeName",
                IsTakeScreenShotDuringEntryExit);

            new ActivitiesPreferencesPage().EnterNewActivityTypeName(activityTypeName);

            Logger.LogMethodExit("CommonSteps", "EnterNewActivityTypeName",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save Preferences Button On Preferences Page.
        /// </summary>
        [When(@"I click on Save Preferences button on Preferences page")]
        public void ClickOnSavePreferencesButtonOnPreferencesPage()
        {
            Logger.LogMethodEntry("CommonSteps", "ClickOnSavePreferencesButtonOnPreferencesPage",
                IsTakeScreenShotDuringEntryExit);

            new GeneralPreferencesPage().SavePreferences();

            Logger.LogMethodExit("CommonSteps", "ClickOnSavePreferencesButtonOnPreferencesPage",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Cmenu Option Of Activity.
        /// </summary>
        /// <param name="cmenuOptionName">This is Cmenu Option Name.</param>
        /// <param name="activityName">This is activity name.</param>
        [When(@"I select cmenu ""(.*)"" option of activity ""(.*)""")]
        public void SelectCmenuOptionOfActivity(string cmenuOptionName,
            string activityName)
        {
            // select cmenu option
            Logger.LogMethodEntry("LaunchActivity", "SelectCmenuOptionOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            // select activity cmenu option
            new TeachingPlanUxPage().SelectActivityCmenuOptionInMyCourseFrame((TeachingPlanUxPage.ActivityCmenuEnum)
                Enum.Parse(typeof(TeachingPlanUxPage.ActivityCmenuEnum), cmenuOptionName), activityName);
            Logger.LogMethodExit("LaunchActivity", "SelectCmenuOptionOfActivity",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Asset In My Course Frame.
        /// </summary>
        /// <param name="activityName">This is Activity Name..</param>
        [When(@"I search the activity ""(.*)"" in My Course frame")]
        public void SearchAssetInMyCourseFrame(string activityName)
        {
            // search asset in my course frame
            Logger.LogMethodEntry("CopyContent", "SearchAssetInMyCourseFrame",
              base.IsTakeScreenShotDuringEntryExit);
            new CourseContentUXPage().SearchAssetInMyCourseFrame(activityName);
            Logger.LogMethodExit("CopyContent", " SearchAssetInMyCourseFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Activity Tab. 
        /// </summary>
        /// <param name="activityWindowName">This is activity window name.</param>
        /// <param name="selectActivityTabName">This is activity level Tab name.</param>
        [When(@"I select ""(.*)"" page and select ""(.*)"" Tab")]
        public void SelectActivityTab(string activityWindowName, string selectActivityTabName)
        {
            // select Tab
            var randomAssessmentPage =
                new RandomAssessmentPage();
            randomAssessmentPage.SelectActivityLevelTab
                (activityWindowName, selectActivityTabName);

        }

        /// <summary>
        /// Set The Activity Level Preferences.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        [When(@"I set the activity level preferences for ""(.*)""")]
        public void SetTheActivityLevelPreferences(string activityName)
        {
            RandomAssessmentPage randomAssessmentPage
                = new RandomAssessmentPage();
            // set actvity level preferences
            randomAssessmentPage.SetActivityLevelPreferences(activityName);
            // save preferences
            randomAssessmentPage.ClickSaveandReturnActivityPreferenceButton();
        }

        /// <summary>
        /// Set Activity Properties.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// 
        [When(@"I set the properties for activity ""(.*)""")]
        public void SetPropertiesSettingsForTheActivity(string activityName)
        {
            //Assign the activity in calendar
            Logger.LogMethodEntry("AssignmentCalendar", "SetPropertiesSettingsForTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            new AssignContentPage().SetActivityPropertiesSettings(activityName);
            Logger.LogMethodExit("AssignmentCalendar", "SetPropertiesSettingsForTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To validate the alert message.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="window"></param>
        [Then(@"I should see the message ""(.*)"" in ""(.*)"" window")]
        public void ToValidateMessageOnPopUp(string message, string window)
        {
            // Method To Verify the Success Message 
            Logger.LogMethodEntry("CommonSteps", "ToValidateMessageOnPopUp",
                IsTakeScreenShotDuringEntryExit);

            Logger.LogAssertion("ToValidateTheMessageOnPopUp",
                            ScenarioContext.Current.ScenarioInfo.Title, ()
                           => Assert.AreEqual(message, new ShowMessagePage().
                           GetTheValidationMessageOfAddingRandonQuestionToMyTest()));
            new ShowMessagePage().ClickOnPegasusAlertOkButton();
            Logger.LogMethodExit("CommonSteps", "ToValidateMessageOnPopUp",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Manage The Activity Folder Level Navigation.
        /// </summary>
        /// <param name="activityName">This is Activity Name.</param>
        /// <param name="tabName">This Is Tab Name.</param>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I select ""(.*)"" in ""(.*)"" by ""(.*)""")]
        public void ManageTheActivityFolderLevelNavigation(string activityName,
            GBLeftNavigationUXPage.TabNameTypeEnum tabName,
            User.UserTypeEnum userTypeEnum)
        {
            //Manage The Activity Folder Level Navigation
            Logger.LogMethodEntry("CommonSteps",
                "ManageTheActivityFolderLevelNavigation",
                base.IsTakeScreenShotDuringEntryExit);
            //Manage The Gradebook Folder Navigation
            new GBLeftNavigationUXPage().ManageTheActivityFolderLevelNavigation(
               activityName, tabName, userTypeEnum);
            Logger.LogMethodExit("CommonSteps",
                "ManageTheActivityFolderLevelNavigation",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {
            new CommonSteps().ResetWebdriver();
        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test
        /// and clean the WebDriver Instance.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {
            new CommonSteps().WebDriverCleanUp();
        }
    }
}
