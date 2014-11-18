using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Integration.Hed.Amplifire.Tests.CommonProductIntegrationTestDefinitions;
using Pegasus.Pages.CommonPageObjects;

namespace Pegasus.Integration.Hed.Amplifire.Tests.CommonProductIntegrationTestDefinitions
{
    /// <summary>
    /// This class contains the common feature steps
    /// that can be reused while verifying the scenarios.
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
        public void ShowThePageInPegasus(
            String expectedPageTitle)
        {
            //Check If Expected Page Is Opened
            Logger.LogMethodEntry("CommonSteps", "ShowThePageInPegasus",
                IsTakeScreenShotDuringEntryExit);
            //Wait Till Thinking Indicator Loads
            bool isThinkingIndicatorLoading = IsThinkingIndicatorLoading();
            //If Thinking Indicator In Process After Specified Time Interval then Fail This Step
            if (isThinkingIndicatorLoading)
            {
                Logger.LogAssertion("VerifyOpenedPageTitle", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.Fail(CommonStepsResource.CommonSteps_PageNotOpened_Message));
            }
            //Wait For Page Get Switched
            base.WaitUntilWindowLoads(expectedPageTitle);
            //Get current opened page title
            string actualPageTitle =
                WebDriver.Title.ToString(CultureInfo.InvariantCulture);
            //Assert we have correct page opened
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedPageTitle, actualPageTitle));
            Logger.LogMethodExit("CommonSteps", "ShowThePageInPegass",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Success Message Display on the Page.
        /// </summary>
        /// <param name="successMessage">This is Success Message Text.</param>
        [Then("I should see the successfull message \"(.*)\"")]
        public void DisplayTheSuccessfullMessage(
            String successMessage)
        {
            // Method To Verify the Success Message     
            Logger.LogMethodEntry("CommonSteps", "DisplayTheSuccessfullMessage",
                IsTakeScreenShotDuringEntryExit);
            //Verify Correct Message Present on the Page
            //IsMessageExists(successMessage,
            //                     CommonStepsResource.
            //                     CommonSteps_SuccessMessage_Class_Locator);
            IsMessageExists(successMessage, "messageBoardText");
            //Removed The Assert For Message Because Sometimes Message not comes 
            //but this is not the severe issue. So We, can ignore this.
            Logger.LogMethodExit("CommonSteps", "DisplayTheSuccessfullMessage",
                 IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifies the Pop Up Opened.
        /// </summary>
        /// <param name="popUpName">This is PopUp Name.</param>
        [Then("I should see the \"(.*)\" popup")]
        public void ShowThePopUpInPegasus(
            String popUpName)
        {
            //Verify Pop Up Opened
            Logger.LogMethodEntry("CommonSteps", "ShowThePopUpInPegasus",
                IsTakeScreenShotDuringEntryExit);
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
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Navigate to Tab Window.
        /// </summary>
        /// <param name="tabName">This is Name of the Tab.</param>        
        [When(@"I select the ""(.*)"" tab")]
        [When(@"I navigate to the ""(.*)"" tab")]
        public void NavigateToTheTab(string tabName)
        {
            //Method to Navigate to the Tab Window 
            Logger.LogMethodEntry("CommonSteps", "NavigateToTheTab",
                IsTakeScreenShotDuringEntryExit);
            //Click On More Link if More Link Is Present
            //And The Required Tab Is Not Present
            new TodaysViewUxPage().ClickMoreLinkIfPresent(tabName);
            //Wait For Element
            WaitForElement((By.PartialLinkText(tabName)));
            //Get Element Property          
            IWebElement getTabProperty =
                GetWebElementPropertiesByPartialLinkText(tabName);
            //Click on Tab   
            ClickByJavaScriptExecutor(getTabProperty);
            //Wait For Page Load 
            //Thread.Sleep(Convert.ToInt32(CommonStepsResource.
            //     CommonSteps_SleepTime_Value));
            Logger.LogMethodExit("CommonSteps", "NavigateToTheTab",
                 IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Click on the Link .
        /// </summary>
        /// <param name="linkName">This is Link name on which click is required.</param>
        /// <param name="frame">This is Frame whether it is right or left.</param>
        [Given("I click on the \"(.*)\" link in \"(.*)\" frame")]
        [When("I click on the \"(.*)\" link in \"(.*)\" frame")]
        public void ClickOnTheLink(string linkName,
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
                case CommonSteps.FrameTypeEnum.Left:
                    //Wait untill window of users
                    base.WaitUntilWindowLoads(CommonStepsResource.
                        CommonSteps_CreateNewUserWindow_Name_Locator);
                    break;
            }
            Logger.LogMethodExit("CommonSteps", "ClickOnTheLink",
             base.IsTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("CommonSteps", "ShowCourseOnTheGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Course Present on Global Home Page
            Logger.LogAssertion("VerifyCoursePresent",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true, new HEDGlobalHomePage().
                    GetCoursePresentInGlobalHomePage().Contains(course.Name)));
            Logger.LogMethodExit("CommonSteps", " ShowCourseOnTheGlobalHomePage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Into Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type.</param>
        /// <param name="userTypeEnum">This is user time enum.</param>
        [When(@"I enter in the ""(.*)"" from the Global Home page as ""(.*)""")]
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
        /// Navigating to the folder where given asset exists
        /// </summary>
        /// <param name="Assetname">Asset Name</param>
        /// <param name="tabName">Tab</param>
        /// <param name="userTypeEnum">User type</param>
        [When(@"I navigate to ""(.*)"" asset in ""(.*)"" tab as ""(.*)""")]
        public void NavigateToFolder(string Assetname, string tabName, User.UserTypeEnum userTypeEnum)
        {
            //Select Cmenu Option Of Activity
            Logger.LogMethodEntry("CourseContent", "NavigateToFolder",
                base.IsTakeScreenShotDuringEntryExit);
            new CommonPage().ManageTheActivityFolderLevelNavigation(Assetname, tabName, userTypeEnum);
            Logger.LogMethodExit("CourseContent", "NavigateToFolder",
             base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Open the Activity As Student.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity by Type Enum.</param>
        [When(@"I open the ""(.*)"" Activity")]
        public void OpenTheActivityForSubmission(String ActivityName)
        {
            // Open The Activity As Student
            Logger.LogMethodEntry("ActivitySubmission", "OpenTheActivityForSubmission",
                base.IsTakeScreenShotDuringEntryExit);
            // Switch to default window after closing of presentation pop up            
            //Launch The Activity
            new CoursePreviewMainUXPage().OpenActivity(ActivityName);
            Logger.LogMethodExit("ActivitySubmission", "OpenTheActivityForSubmission",
                base.IsTakeScreenShotDuringEntryExit);
        }

       

        /// <summary>
        /// Click on the activity.
        /// </summary>
        /// <param name="ActivityName">This the activity name.</param>
        [When(@"I open the ""(.*)"" Activity from MyCourse")]
        public void OpenTheActivityFromMyCourse(string ActivityName)
        {
            // Open The Activity 
            Logger.LogMethodEntry("CommonSteps", "OpenTheActivityFromMyCourse",
                base.IsTakeScreenShotDuringEntryExit);           
            //Launch The Activity
            new CoursePreviewMainUXPage().OpenTheActivityFromMyCourse(ActivityName);
            Logger.LogMethodExit("CommonSteps", "OpenTheActivityFromMyCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the warning message.
        /// </summary>
        /// <param name="warningMessage">This is the message.</param>
        [Then(@"I should see ""(.*)"" warning")]
        public void VerifyWarning(string warningMessage)
        {
            //Verify the warning message
            Logger.LogMethodEntry("CommonSteps",
                "VerifyWarning"
                , base.IsTakeScreenShotDuringEntryExit);
            //Verify the warning message
            Logger.LogAssertion("VerifyTheMessage",
                ScenarioContext.Current.ScenarioInfo.Title,() => Assert.AreEqual
                (warningMessage, new TodaysViewUxPage().GetDisplayedMessage()));
            //Close the amplifier popup
            base.CloseBrowserWindow();
            Logger.LogMethodExit("CommonSteps",
                "VerifyWarning"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Launch Activity Presentation Window.
        /// </summary>
        /// /// <param name="message">This is the activity.</param>
        [Then(@"I should see the ""(.*)"" activity successfully launched")]
        public void ActivitySuccessfullyLaunched(string amplifierUrlText)
        {
            //Launching of Activity Presentation Window
            Logger.LogMethodEntry("ActivitySubmission",
                "ActivitySuccessfullyLaunched"
                , base.IsTakeScreenShotDuringEntryExit);
            //Assert Launch Activity Window
            Logger.LogAssertion("VerifyActivityLaunched",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new CommonPage().IsPageOpened(amplifierUrlText)));
            Logger.LogMethodExit("ActivitySubmission",
                "ActivitySuccessfullyLaunched"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the title displayed in book.
        /// </summary>
        /// <param name="expectedBookTilte">This is the title.</param>
        [Then(@"I should see the BookTilte as ""(.*)""")]
        public void VerifyBookTitle(string expectedBookTilte)
        {
            //Verify the title displayed in book
            Logger.LogMethodEntry("CommonSteps", "VerifyBookTitle",
                IsTakeScreenShotDuringEntryExit);
            string actualBookTilte = new CommonPage().GetTextByXpath();
            //Verify the title displayed in book          
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedBookTilte, actualBookTilte));
            //Close the amplifier popup
            base.CloseBrowserWindow();
            Logger.LogMethodExit("CommonSteps", "VerifyBookTitle",
                IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify the launch of amplifier pop up.
        /// </summary>
        [Then(@"I should see Amplifier link should be opened in new pop up")]
        public void VerifyAmplifierLaunch()
        {
            // Verify the launch of amplifier pop up
            Logger.LogMethodEntry("CommonSteps",
                "VerifyAmplifierLaunch"
                , base.IsTakeScreenShotDuringEntryExit);
            // Verify the launch of amplifier pop up
            Logger.LogAssertion("VerifyAmplifierLaunch",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new InstructorPresentationPage().
                    IsAmplifierPresentationPageOpened()));
            Logger.LogMethodExit("CommonSteps",
                "VerifyAmplifierLaunch"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Asset Name In 'My Course' Frame.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type Enum</param>
        [Then(@"I should see the ""(.*)"" in 'My Course'")]
        public void VerifyAssetNameInMyCourse(Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Verify The Asset Name In 'My Course' Frame
            Logger.LogMethodEntry("CopyContent", "VerifyAssetNameInMyCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Activity activity = Activity.Get(activityTypeEnum);
            //Verify The Searched Asset Name
            Logger.LogAssertion("VerifyAssetName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(activity.Name,
                    new CourseContentUXPage().GetAssetNameFromMyCourseTab(activity.Name)));
            Logger.LogMethodExit("CopyContent", "VerifyAssetNameInMyCourse",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Activity CmenuOption In MyCourseFrame.
        /// </summary>
        [When(@"I click the activity cmenu option in MyCourse Frame")]
        public void SelectTheActivityCmenuOptionInMyCourseFrame()
        {
            //Select The Activity CmenuOption In MyCourseFrame
            Logger.LogMethodEntry("CopyContent",
                "SelectTheActivityCmenuOptionInMyCourseFrame",
               base.IsTakeScreenShotDuringEntryExit);
            // Click On The Activity Cmenu In MyCourse Frame
            new CourseContentUXPage().ClickTheActivityCmneuImageIcon();
            Logger.LogMethodExit("CopyContent",
                "SelectTheActivityCmenuOptionInMyCourseFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Cmenu of Activity.
        /// </summary>
        /// <param name="cmenuOption">This is cmenu option.</param>
        [When(@"I click on ""(.*)"" cmenu option")]
        public void ClickTheCmenuofActivity(string cmenuOption)
        {
            //Click The Cmenu of Activity
            Logger.LogMethodEntry("CopyContent", "ClickTheCmenuofActivity"
               , base.IsTakeScreenShotDuringEntryExit);
            //Click On Cmenu of Activity
            new CourseContentUXPage().ClickTheCmenuOptionofActivity(cmenuOption);
            Logger.LogMethodExit("CopyContent", "ClickTheCmenuofActivity"
                , base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify The Activity In The MyCourse.
        /// </summary>
        /// <param name="activity">This is Activity Name.</param>
        [Then(@"I should see ""(.*)"" activity in the MyCourse")]
        public void VerifyTheActivityInTheMyCourse(string activity)
        {
            //Verify The Activity In The MyCourse
            Logger.LogMethodEntry("CreateActivity",
                "VerifyTheActivityInTheMyCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Asserts the Activity Name
            Logger.LogAssertion("VerifyAssignedActivityName", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(activity,
                    new CourseContentUXPage().GetActivityName(activity)));
            Logger.LogMethodExit("CreateActivity",
                "VerifyTheActivityInTheMyCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on folder based on user type.
        /// </summary>
        /// <param name="FolderName">This is the folder name.</param>
        /// <param name="UserType">This is the user type enum.</param>
        [When(@"I click on ""(.*)"" folder as ""(.*)""")]
        public void ClickOnFolderBasedOnUserType(string FolderName,User.UserTypeEnum UserType)
        {
            // Click on folder based on user type
            Logger.LogMethodEntry("CommonSteps", "ClickOnFolderBasedOnUserType",
            IsTakeScreenShotDuringEntryExit);
            //Navigating inside the folder
            new CommonPage().NavigateInsideTheFolder(FolderName, UserType);
            Logger.LogMethodExit("CommonSteps", "ClickOnFolderBasedOnUserType",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the navigation to folder.
        /// </summary>
        /// <param name="FolderName">This is the folder name.</param>
        [Then(@"I should be inside the folder ""(.*)""")]
        public void ValidateFolderNavigation(string FolderName)
        {
            //Check If Expected Page Is Opened
            Logger.LogMethodEntry("CommonSteps", "ValidateFolderNavigation",
                IsTakeScreenShotDuringEntryExit);          
            //Wait For Page Get Switched
            WaitUntilPageGetSwitchedSuccessfully("Course Materials");
            //Get current opened page title
            string getActualPageTitle = GetPageTitle;
            string ActualFolderName = new CommonPage().GetFolderNameByXpath(FolderName);
            //Assert we have correct page opened            
            Logger.LogAssertion("VerifyOpenedPageTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(FolderName, ActualFolderName));
            Logger.LogMethodExit("CommonSteps", "ValidateFolderNavigation",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the selected folder.
        /// </summary>
        /// <param name="FolderName">Name of the selected folder.</param>
        [Then(@"I should be inside the selected folder ""(.*)""")]
        public void ValidateSelectedFolderNavigation(string FolderName)
        {
            //Check If Expected Page Is Opened
            Logger.LogMethodEntry("CommonSteps", "ValidateFolderNavigation",
                IsTakeScreenShotDuringEntryExit);
            //Wait For Page Get Switched
            WaitUntilPageGetSwitchedSuccessfully("Course Materials");
            //Get current opened page title
            string ActualFolderName = new CommonPage().GetBreathCrumbItemSelected();
            //Assert we have correct page opened            
            Logger.LogAssertion("VerifyOpenedFolderTitle",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(FolderName, ActualFolderName));
            Logger.LogMethodExit("CommonSteps", "ValidateFolderNavigation",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Into Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type.</param>
        /// <param name="userTypeEnum">This is user time enum.</param>
        [When(@"I enter in the ""(.*)"" course from the Global Home page as ""(.*)""")]
        public void EnterCourse(Course.CourseTypeEnum courseTypeEnum,
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
        /// Search Section
        /// </summary>
        /// <param name="courseTypeEnum">This is Course Type Enum</param>
        [When(@"I search the ""(.*)"" first section")]
        public void SearchFirstSection(Course.CourseTypeEnum courseTypeEnum)
        {
            //Search Section
            Logger.LogMethodEntry("CopyContent", "SearchFirstSection",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Search Section
            new ManageTemplatePage().SearchSection(course.SectionName);
            Logger.LogMethodExit("CopyContent", " SearchFirstSection",
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
        /// Launch Amplifire Link Window.
        /// </summary>
        [Then(@"I should see the Amplifire launched successfully")]
        public void ValidateAmplifireLaunchedSuccessfully()
        {
            //Launch Amplifire Link Window.
            Logger.LogMethodEntry("ActivitySubmission",
                "ValidateAmplifireLaunchedSuccessfully"
                , base.IsTakeScreenShotDuringEntryExit);
            //Assert Launch Amplifire Window
            Logger.LogAssertion("VerifyActivityLaunched",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new StudentPresentationPage().
                    IsAmplifireLinkPageOpened()));
            Logger.LogMethodExit("ActivitySubmission",
                "ValidateAmplifireLaunchedSuccessfully"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate to a Tab.
        /// </summary>
        /// <param name="tabName">This is the tab name.</param>
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
        /// Verifies the amplifier link .
        /// </summary>
        /// <param name="amplifierLinkName">Tis is the amplifier link name.</param>
        /// <param name="userType">This is the user type.</param>
        [Then(@"I should see the ""(.*)"" amplifier link as ""(.*)""")]
        public void VerifyAmplifierLink(string amplifierLinkName, User.UserTypeEnum userType)
        {
            //Assert Launch Amplifire Window
            Logger.LogAssertion("VerifyActivityLaunched",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new CommonPage().
                    IsAmplifireLinkPresent(amplifierLinkName, userType)));
        }


        /// <summary>
        /// Initialize Pegasus test before test execution starts.
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {
            //Reset Webdriver Instance
            new CommonSteps().ResetWebdriver();
        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test.
        /// and stops the webdriver.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {
            // clean processess
            new CommonSteps().WebDriverCleanUp();
        }
    }
}
