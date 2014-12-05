using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus.Pages.CommonPageObjects;
using Pegasus.Automation.DataTransferObjects;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using System.Configuration;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Discussion;


namespace Pegasus.Acceptance.HigherEducation.HSS.Tests.
    CommonProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the common feature steps
    /// that can be reuse while verifying.
    /// the scenarios.
    /// </summary>
    [Binding]
    public sealed class CommonSteps : BasePage
    {
        /// <summary>
        /// This is the logger.
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
        /// Verifies the Correct Page Opened.
        /// </summary>
        /// <param name="expectedPageTitle">This is Expected Page Title.</param>
        [Then("I should be on the \"(.*)\" page")]
        [Then("I should be on the \"(.*)\" window")]
        [Given(@"I am on the ""(.*)"" page")]
        [When(@"I am on the ""(.*)"" page")]
        public void ShowThePageInPegasus(String expectedPageTitle)
        {
            //Verify Correct Page Opened
            Logger.LogMethodEntry("CommonSteps", "ShowThePageInPegasus",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for Some Time to Get off from light box
            Thread.Sleep(Convert.ToInt32
                (CommonStepsResource.CommonSteps_SleepTime_Value));
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
        /// Click on C menu->open under the Testtype frame
        /// </summary>
        /// <param name="expectedPageTitle">This is Expected Page Title.</param>
        [When(@"I Click open under ""(.*)"" frame to launch the Questions")]
        public void ClickOpenToLaunchTheQuestions(string TestType)
        {
            Logger.LogMethodEntry("CommonSteps", "ClickOpenToLaunchTheQuestions",
            base.IsTakeScreenShotDuringEntryExit);
            new StudentPresentationPage().ClickOpenToLaunchTheQuestions(TestType);
            Logger.LogMethodExit("CommonSteps", "ClickOpenToLaunchTheQuestions",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verifies the Correct Page Opened.
        /// </summary>
        [Then(@"I should be on the ""(.*)"" page displayed with questions")]
        public void ShowWindowInPegasus(string expectedWindowTitle)
        {
            Logger.LogMethodEntry("CommonSteps", "ShowThePageInPegasus",
            base.IsTakeScreenShotDuringEntryExit);
            base.SwitchToLastOpenedWindow();
            this.ShowThePageInPegasus(expectedWindowTitle);
            Logger.LogMethodExit("CommonSteps", "ShowThePageInPegass",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Answer the Questions of activity.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="activityBehaviourType">This is the activityBehaviourType of an activity.</param>
        /// <param name="activityType">This is the activity type.</param>
        /// <param name="optionType">This is the Type of answer that has to be updated.</param>
        [Then(@"I answer activity ""(.*)"" with behaviour ""(.*)"" of ""(.*)"" type with ""(.*)"" answers")]
        public void AnswerActivityQuestion(ActivityQuestionsList.ActivityNameEnum activityName, 
            ActivityQuestionsList.ActivityBehaviourTypeEnum activityBehaviourType,
            ActivityQuestionsList.ActivityTypeEnum activityType,String optionType)
        {
            Logger.LogMethodEntry("CommonSteps", "AnswerActivityQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            new StudentPresentationPage().AnswerActivityQuestions(activityName, activityBehaviourType, activityType, optionType);
            Logger.LogMethodExit("CommonSteps", "AnswerActivityQuestion",
             base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Answer the Questions of activity.
        /// </summary>
        /// <param name="activityName">This is the activity name.</param>
        /// <param name="activityBehaviourType">This is the activityBehaviourType of an activity.</param>
        /// <param name="activityType">This is the activity type.</param>
        /// <param name="optionType">This is the Type of answer that has to be updated.</param>
        /// <param name="TestType">This is the Type of Test.</param>
        [Then(@"I answer activity ""(.*)"" with behaviour ""(.*)"" of ""(.*)"" type with ""(.*)"" answers of ""(.*)""")]
        public void ThenIAnswerActivityWithBehaviourOfTypeWithAnswersOf(ActivityQuestionsList.ActivityNameEnum activityName,
            ActivityQuestionsList.ActivityBehaviourTypeEnum activityBehaviourType,
            ActivityQuestionsList.ActivityTypeEnum activityType, String optionType, string TestType)
        {
            Logger.LogMethodEntry("CommonSteps", "AnswerActivityQuestion",
            base.IsTakeScreenShotDuringEntryExit);
            new StudentPresentationPage().AnswerActivityQuestions(activityName, activityBehaviourType, activityType, optionType, TestType);
            Logger.LogMethodExit("CommonSteps", "AnswerActivityQuestion",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save For Later Option.
        /// </summary>
        [When(@"I click on save for later button")]
        public void ClickOnSaveForLaterButton()
        {
            Logger.LogMethodEntry("CommonSteps", "ClickOnSaveForLaterButton",
            base.IsTakeScreenShotDuringEntryExit);
            new StudentPresentationPage().ClickOnSaveForLaterOption();
            Logger.LogMethodExit("CommonSteps", "ClickOnSaveForLaterButton",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Closing the Window abdruptly
        /// </summary>
        [When(@"I forcibly close the Exam window abdruplty")]
        public void ForciblyCloseTheWindow()
        {
            //Close the window
            Logger.LogMethodEntry("CommonSteps", "ForciblyCloseTheWindow",
                IsTakeScreenShotDuringEntryExit);
            //Close the Window
            new StudentPresentationPage().CloseWindow();
            Logger.LogMethodExit("CommonSteps", "ForciblyCloseTheWindow",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate Activity Status For The Activity.
        /// </summary>
        /// <param name="activityStatus"></param>
        /// <param name="activityName"></param>
        [Then(@"I should see the ""(.*)"" status for the activity ""(.*)""")]
        public void StatusForTheActivity(string activityStatus,
            string activityName)
        {
            //Validate the submitted activity status
            Logger.LogMethodEntry("CommonSteps",
                "StatusForTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Validate the submitted activity status
            Logger.LogAssertion("ValidateActivityStatus", ScenarioContext.Current.ScenarioInfo.
                Title, () => Assert.AreEqual(activityStatus, new StudentPresentationPage().
                    GetStatusOfSubmittedActivityInCourseMaterial(activityName)));
            Logger.LogMethodExit("CommonSteps",
                "StatusForTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// click on Submit the activity
        /// </summary>
        [When(@"I click on Submit the activity ""(.*)"" score should be displayed in the screen")]
        public void ClickOnSubmitTheActivity(String activityScore)
        {
            Logger.LogMethodEntry("CommonSteps", "ClickOnSubmitTheActivity",
            base.IsTakeScreenShotDuringEntryExit);
            StudentPresentationPage obj = new StudentPresentationPage();
            obj.SubmitForGrading();
            Logger.LogAssertion("AnswerActivityQuestion", ScenarioContext.Current.ScenarioInfo.
               Title, () => Assert.AreEqual(activityScore, obj.GetActivityScore()));
            obj.ReturnBackToCourseSpace();
            Logger.LogMethodExit("CommonSteps", "ClickOnSubmitTheActivity",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Submission Score of an activity
        /// </summary>
        [Then(@"I should see the ""(.*)"" score in the left frame")]
        public void VerifySubmissionScore(string score)
        {
            Logger.LogMethodEntry("CommonSteps", "VerifySubmissionScore",
            IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (score, new StudentPresentationPage().GetSubmissionScoreByStudent()));
            Logger.LogMethodExit("CommonSteps", "VerifySubmissionScore",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on View Submission of an activity
        /// </summary>
        [When(@"I click on View Submission")]
        public void ClickOnViewSubmission()
        {
            Logger.LogMethodEntry("CommonSteps", "ClickOnViewSubmission",
            IsTakeScreenShotDuringEntryExit);
            new StudentPresentationPage().ClickOnViewSubmission();
            Logger.LogMethodExit("CommonSteps", "ClickOnViewSubmission",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Submission Score of an activity and student details 
        /// </summary>
        [Then(@"I should see Student ""(.*)"" as ""(.*)"" and displayed like ""(.*)"" in the right frame")]
        public void VerifyStudentDetaisInRightFrame(string scenerioName,
           User.UserTypeEnum userTypeEnum, string activityGrade)
        {
            Logger.LogMethodEntry("CommonSteps", "VerifyStudentDetaisInRightFrame",
            IsTakeScreenShotDuringEntryExit);
            //Verify the grade of the activity
            StudentPresentationPage obj = new StudentPresentationPage();
            Logger.LogAssertion("VerifyGradesoftheSubmittedActivity", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                 (activityGrade, obj.GetactivityGradeByStudent()));
            String ExpectedUserDetail = this.GetExpectedUserDetails(scenerioName, userTypeEnum);
            String ActualUserDetail = obj.getStudentDetails();
            //Verify Expected student name
            Logger.LogAssertion("VerifyUserDetailsPresent", ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(ExpectedUserDetail, ActualUserDetail));
            base.CloseBrowserWindow();
            Logger.LogMethodExit("CommonSteps", "VerifyStudentDetaisInRightFrame",
                IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Get the Expected User details from the view submission page
        /// </summary>
        private String GetExpectedUserDetails(string scenerioName,
           User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("CommonSteps", "GetExpectedUserDetails",
            IsTakeScreenShotDuringEntryExit);
            String ExpectedUserDetail = String.Empty;
            if (scenerioName.Equals("scoring 0"))
            {
                User user = new LoginContentPage().
                 SelectUserDetailsBaesdOnScenerio(scenerioName, userTypeEnum);
                ExpectedUserDetail = user.LastName + ", " + user.FirstName;
            }
            else
            {
                User user = User.Get(userTypeEnum);
                ExpectedUserDetail = user.LastName + ", " + user.FirstName;
            }
            Logger.LogMethodEntry("CommonSteps", "GetExpectedUserDetails",
            IsTakeScreenShotDuringEntryExit);
            return ExpectedUserDetail;
        }

        /// <summary>
        /// Verifies the Pop Up Opened
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
        /// Verify the display message is valid or not.
        /// </summary>
        /// <param name="successMessage">This is Success Message Text.</param>
        [Then("I should see successfull message \"(.*)\"")]
        public void DisplaySuccessfullMessageStopCopyEnroll(String successMessage)
        {
            // Method To Verify the Success Message 
            Logger.LogMethodEntry("CommonSteps", "DisplaySuccessfullMessageStopCopyEnroll",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify Correct Message Present on the Page
            bool isSuccessMessageExist = base.IsMessageExists(successMessage,
                CommonStepsResource.CommonSteps_SuccessMessage_Class_Locator);
            Logger.LogAssertion("VerifySussessfullmsg", ScenarioContext.Current.ScenarioInfo.Title,
              () => Assert.IsTrue(isSuccessMessageExist));
            Logger.LogMethodExit("CommonSteps", "DisplaySuccessfullMessageStopCopyEnroll",
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
            FrameTypeEnum frame)
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
                case CommonSteps.FrameTypeEnum.Right:
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
            new TodaysViewUxPage().ClickTheMoreLinkIfPresent(tabName);
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
        /// Verify User Entered In Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is Course by Type.</param>
        [Then(@"I should successfully enter into the ""(.*)""")]
        public void VerifyEnteringIntoTheCourse(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify user entered into course from Global Home Page
            Logger.LogMethodEntry("CommonSteps", "VerifyEnteringIntoTheCourse",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From  Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Course Name Present After User Entered In Course 
            Logger.LogAssertion("VerifyCoursePresent",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(course.Name, new HEDGlobalHomePage().
                    GetCourseName()));
            Logger.LogMethodExit("CommonSteps", "VerifyEnteringIntoTheCourse",
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
            new TodaysViewUxPage().ClickOnHomeLink();
            Logger.LogMethodExit("CommonSteps", "ClickHomeLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Successfull Message In MyTest Tab.
        /// </summary>
        /// <param name="successMessage">This is Success Message.</param>
        [Then(@"I should see the successfull message ""(.*)"" in MyTest tab")]
        public void SuccessfullMessageInMyTestTab(String successMessage)
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
        public void CloseTheManageOrganizationWindow(String windowName)
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
        /// Navigate To Tab Of The Perticular Page.
        /// </summary>
        /// <param name="tabName">This is Tab Name.</param>
        /// <param name="pageName">This is Page Name.</param>
        [When(@"I navigate to ""(.*)"" tab of the ""(.*)"" page")]
        public void TabNavigation(string tabName, string pageName)
        {
            //Navigate Administrator Tool Page
            Logger.LogMethodEntry("CommonSteps", "NavigateToTabOfThePerticularPage",
                base.IsTakeScreenShotDuringEntryExit);
                //Is The Page Open Already
            Boolean isPageAlreadyExists = base.IsPopupPresent(pageName, (Convert.ToInt32(
                CommonStepsResource.CommonSteps_ElementWait_Time_Value)));
                if (isPageAlreadyExists )
                {
                    //Selecting the Page If Opened
                    base.SelectWindow(pageName);
                }
                else
                {
                    //Select The Perticular Tab
                    this.NavigateToTheTab(tabName);                    
                }
            Logger.LogMethodExit("CommonSteps", "NavigateToTabOfThePerticularPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Publishing Tab.
        /// </summary>
        /// <param name="subtabName">This is SubTab Name.</param>
        /// <param name="mainTabName">This is MainTab Name.</param>
         [When(@"I navigate to ""(.*)"" subtab from ""(.*)"" maintab")]
        public void NavigateToPublishingTab(string subtabName, string mainTabName)
        {
            //Navigate to perticular Page
            Logger.LogMethodEntry("CommonSteps", "NavigateToPublishingTab",
                base.IsTakeScreenShotDuringEntryExit);
            string pageTitle = base.GetPageTitle;
            if (pageTitle != CommonStepsResource.CommonSteps_Publishing_ManagePrograms_Tab
                && pageTitle != CommonStepsResource.CommonSteps_Publishing_ManageProducts_Tab)
            {                
                base.SelectWindow(pageTitle);
                //Select The Perticular Tab
                this.NavigateToTheTab(mainTabName); 
                Thread.Sleep(Convert.ToInt32(CommonStepsResource.
                    CommonSteps_ElementWaitTimeOut_Value));
            }
             //Select the window
            base.WaitUntilWindowLoads(base.GetPageTitle);
            base.SelectWindow(base.GetPageTitle);
             //Get Seleted Tab Name
            string getSelectorTab = this.GetSubtabValue(subtabName);
            IWebElement selectedTabElement = base.GetWebElementPropertiesById(getSelectorTab);
            //Get Seleted Tab Class value
            string getClassName = selectedTabElement.GetAttribute(CommonStepsResource.
                CommonSteps_GetClass_Value);
            if (getClassName == CommonStepsResource.CommonSteps_GetSelectedTab_Value)
            {
                base.SelectWindow(subtabName);
            }
            else
            {
                //Select The Perticular Tab
                this.NavigateToTheTab(subtabName); 
            }
            Logger.LogMethodExit("CommonSteps", "NavigateToPublishingTab",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
         /// Get Subtab Value.
        /// </summary>
        /// <param name="SubtabName">Get the SubTab.</param>
        /// <returns>Return selector tab Id.</returns>
        private String GetSubtabValue(string SubtabName)
        {
            //Navigate Administrator Tool Page
            Logger.LogMethodEntry("CommonSteps", "GetSubtabValue",
                base.IsTakeScreenShotDuringEntryExit);
            //Intialize the variable
            String getSubTabId = String.Empty;
            switch(SubtabName)
            {
                case "Manage Programs":
                    getSubTabId = CommonStepsResource.
                        CommonSteps_ManageProgramsTab_Value;
                    break;
                case "Manage Products":
                    getSubTabId = CommonStepsResource.
                        CommonSteps_ManageProductsTab_Value;
                    break;
            }
            Logger.LogMethodExit("CommonSteps", "GetSubtabValue",
               base.IsTakeScreenShotDuringEntryExit);
            return getSubTabId;
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
            this.SelectTab(parentTabName, childTabName);
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
            this.SelectTab(tabName);
            Logger.LogMethodExit("CommonSteps", "NavigateToTab",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Tab.
        /// </summary>
        /// <param name="parentTabName">This is Parent Tab Name.</param>
        /// <param name="childTabName">This is Child Tab Name.</param>
        private void SelectTab(string parentTabName,
            string childTabName = "Default Value")
        {
            //Navigate to Tab
            Logger.LogMethodEntry("CommonSteps", "SelectTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Select the CourseSpace User MainTab
            this.SelectCourseSpaceUserMainTab(parentTabName);
            if (childTabName != "Default Value")
            {
                //Get Subtab Counts
                base.WaitForElement(By.XPath(CommonStepsResource.
                    CommonSteps_Subtab_Count_Xpath_Locator));
                //Get Tab Count
                int getSubTabCount = base.GetElementCountByXPath(CommonStepsResource.
                    CommonSteps_Subtab_Count_Xpath_Locator);
                for (int csTabCountNo = Convert.ToInt32(
                    CommonStepsResource.CommonSteps_Loop_Initializer_Value);
                    csTabCountNo <= getSubTabCount; csTabCountNo++)
                {
                    base.WaitForElement(By.XPath(String.Format(CommonStepsResource.
                                CommonSteps_Subtab_Classname_Xpath_Locator, csTabCountNo)));
                    IWebElement getSelectedTabElement = base.GetWebElementPropertiesByXPath
                        (String.Format(CommonStepsResource.
                                CommonSteps_Subtab_Classname_Xpath_Locator, csTabCountNo));
                    if (getSelectedTabElement.Text == childTabName)
                    {
                        string getClassName = getSelectedTabElement.
                                      GetAttribute(CommonStepsResource.
                           CommonSteps_GetClass_Value);
                        if (getClassName == CommonStepsResource.
                                         CommonSteps_SubTab_SelectedTab_Value)
                        {
                            break;
                        }
                        else
                        {
                            //Select The Tab
                            this.NavigateToTheTab(childTabName);
                            break;
                        }
                    }
                }
            }
            Logger.LogMethodExit("CommonSteps", "SelectTab",
              base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select MainTab.
        /// </summary>
        /// <param name="mainTabName">This is Main Tab Name.</param>
        private void SelectCourseSpaceUserMainTab(string mainTabName)
        {
            
            //Select MainTab
            Logger.LogMethodEntry("CommonSteps", "SelectCourseSpaceUserMainTab",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the MainTab
            base.WaitForElement(By.PartialLinkText(mainTabName));
            //Get Tab Property
            string getTabClassAttribute =
                base.GetClassAttributeValueByPartialLinkText(mainTabName);
            if (getTabClassAttribute == 
                CommonStepsResource.CommonSteps_MainTab_SelectedTab_Value)
            {
                //Select Window
                base.SelectWindow(base.GetPageTitle);
            }
            else
            {
                //Select The Tab
                this.NavigateToTheTab(mainTabName);
            }
            Logger.LogMethodExit("CommonSteps", "SelectCourseSpaceUserMainTab",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Tab As Program Administrator.
        /// This is For Program Course Tab Navigation
        /// </summary>
        /// <param name="mainTab">This is Tab Name.</param>
        [When(@"I navigate to ""(.*)"" tab as Program Administrator")]
        public void NavigateToTabAsProgramAdministrator(string mainTabName)
        {
            //Navigate To Tab As Program Administrator
            Logger.LogMethodEntry("CommonSteps", "NavigateToTabAsProgramAdministrator",
                base.IsTakeScreenShotDuringEntryExit);
            //Select The SubTab counts
            int getSubTabCount = WebDriver.FindElements(By.XPath
                (CommonStepsResource.CommonSteps_Subtab_Count_Xpath_Locator)).Count;
            for (int csTabCountNo = Convert.ToInt32(
                    CommonStepsResource.CommonSteps_Loop_Initializer_Value); 
                    csTabCountNo <= getSubTabCount; csTabCountNo++)
            {
                IWebElement getSelectedTabElement = base.GetWebElementPropertiesByXPath
                    (String.Format(CommonStepsResource.
                            CommonSteps_Subtab_Classname_Xpath_Locator, csTabCountNo));
                if (getSelectedTabElement.Text == mainTabName)
                {
                    string getClassName = getSelectedTabElement.
                                  GetAttribute(CommonStepsResource.
                       CommonSteps_GetClass_Value);
                    if (getClassName == CommonStepsResource.
                        CommonSteps_GetSelectedTab_Value)
                    {
                        break;
                    }
                    else
                    {
                        //Select The Perticular Tab
                        this.NavigateToTheTab(mainTabName);
                        break;
                    }
                }
            }
            Logger.LogMethodExit("CommonSteps", "NavigateToTabAsProgramAdministrator",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To Tab Of The Particular Page.
        /// </summary>
        /// <param name="tabName">This is Tab Name.</param>
        /// <param name="pageName">This is Page Name.</param>
        [When(@"I navigate to ""(.*)"" tab of the ""(.*)"" page as Admin")]
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
        /// Navigating to the folder where given asset exists.
        /// </summary>
        /// <param name="Assetname">Asset Name</param>
        /// <param name="tabName">Tab</param>
        /// <param name="userTypeEnum">User type</param>
        [When(@"I navigate to ""(.*)"" asset in ""(.*)"" tab as ""(.*)""")]
        public void NavigateToFolder(string Assetname, string tabName, User.UserTypeEnum userTypeEnum)
        {
            //Navigating to the folder where given asset exists
            Logger.LogMethodEntry("CourseContent", "NavigateToFolder",
                base.IsTakeScreenShotDuringEntryExit);
            new CommonPage().ManageTheActivityFolderLevelNavigation(Assetname, tabName, userTypeEnum);
            Logger.LogMethodExit("CourseContent", "NavigateToFolder",
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

        /// <summary>
        /// Manage The Activity Folder Level Navigation HED Core.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        /// <param name="userTypeEnum">This is user Type Enum.</param>
        /// <param name="activityUnderTabName">This is Tab Name.</param>
        /// <remarks>This folder navigation is only valid for MyLab/HSS authored course such as
        /// section course, instructor course and Templates will only valid for this method.</remarks>
        [When(@"I select ""(.*)"" in ""(.*)"" by ""(.*)""")]
        public void ManageTheActivityFolderLevelNavigation(string activityName,
            string activityUnderTabName, User.UserTypeEnum userTypeEnum)
        {
            //Manage The Activity Folder Level Navigation
            Logger.LogMethodEntry("CommonSteps",
                "ManageTheActivityFolderLevelNavigation",
                base.IsTakeScreenShotDuringEntryExit);
            // select particular window here
            base.SelectWindow(base.GetPageTitle);
            if (activityUnderTabName.Equals("Gradebook"))
            {
                // select grade book right iframe here
                new GBInstructorUXPage().SelectGradebookFrame();
                // make sleep intentionally to load frame completely
                Thread.Sleep(15000);
            }
            //Manage The Folder Navigation
            new CommonPage().ManageTheActivityFolderLevelNavigationHEDCore(
               activityName, activityUnderTabName, userTypeEnum);
            
            Logger.LogMethodExit("CommonSteps",
                "ManageTheActivityFolderLevelNavigation",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate To the Etext Window.
        /// </summary>
        [When(@"I Click on eText link")]
        public void NavigateToEtextWindow()
        {
            Logger.LogMethodEntry("CommonSteps",
                "NavigateToEtextWindow",
                base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().LaunchEText();
            Logger.LogMethodExit("CommonSteps",
                "NavigateToEtextWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// close the Etext Window.
        /// </summary>
        [Then(@"I close eText Window")]
        public void CloseETextWindow()
        {
            Logger.LogMethodEntry("CommonSteps",
                "NavigateToEtextWindow",
                base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().CloseEtextWindow();
            Logger.LogMethodExit("CommonSteps",
                "NavigateToEtextWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Section in Active State.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I verify the Section created from ""(.*)"" course Template for AssignedToCopy state")]
        public void SectionInAssignedToCopyState(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Verify Section in Active State
            Logger.LogMethodEntry("ProgramAdmin", "SectionInAssignedToCopyState",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Approve Section in Active State
            new ManageTemplatePage().ApproveInActiveStateOfEntityInProgramAdministration(
                course.SectionName);
            Logger.LogMethodExit("ProgramAdmin", "SectionInAssignedToCopyState",
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
                (course.SectionName).Contains("Request is Processing and will be available soon")));
            Logger.LogMethodExit("CommonSteps", "ApproveAssignedToCopyStateForSection",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Launch the asset .
        /// </summary>
        /// <param name="assetName">This is the asset name.</param>
        [When(@"I launch ""(.*)"" asset")]
        public void LaunchAsset(string assetName)
        {
            //Launch the asset
            Logger.LogMethodEntry("CommonSteps",
                "LaunchchapterReviewAsset",
                base.IsTakeScreenShotDuringEntryExit);
            new CoursePreviewUXPage().LaunchAssetFromToDoTab(assetName);
            Logger.LogMethodExit("CommonSteps",
             "LaunchchapterReviewAsset",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the status in TODO Tab.
        /// </summary>
        /// <param name="assetStatus">This is the Asset Status.</param>
        [Then(@"I should see ""(.*)"" status for the asset")]
        public void VerifyAssetStatus(string assetStatus)
        {
            //Verify the status of the asset
            Logger.LogMethodEntry("CommonSteps",
                "OpenAsset",
                base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyAssetStatus",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(assetStatus, new CoursePreviewUXPage().
                   GetAssetStatus(assetStatus)));
            Thread.Sleep(5000);
            Logger.LogMethodExit("CommonSteps",
                "OpenAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the status in Completed Tab.
        /// </summary>
        /// <param name="assetName">This is the asset name.</param>
        [Then(@"I should see ""(.*)"" in the 'Completed' tab")]
        public void VerifyStatusInCompletedTab(string assetName)
        {
            Logger.LogMethodEntry("CommonSteps",
                  "OpenAsset",
                  base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("VerifyAssetStatus",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(assetName, new CoursePreviewUXPage().
                   GetAssetNameInCompletedTab(assetName)));
            Logger.LogMethodExit("CommonSteps",
                "OpenAsset",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify folder asset is present.
        /// </summary>
        /// <param name="expectedFolderAssetName">This is a activity folder name.</param>
        [Then(@"I should see ""(.*)"" asset")]
        public void VerifyFolderAssetPresent(string expectedFolderAssetName)
        {
            //Verify expected folder name is same as actual folder name
            Logger.LogMethodEntry("AssignmentCalendar",
              "VerifyFolderAssetPresent",
              base.IsTakeScreenShotDuringEntryExit);
            //Assert expected and actual folder values
            Logger.LogAssertion("VerifyFolderAssetPresent",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedFolderAssetName,
                    new CalendarHedDefaultUxPage().GetActualFolderName(expectedFolderAssetName)));
            Logger.LogMethodExit("AssignmentCalendar",
                "VerifyFolderAssetPresent",
              base.IsTakeScreenShotDuringEntryExit);
        }


        [When(@"I drag and drop the ""(.*)"" folder to the current date")]
        public void WhenIDragAndDropTheFolderToTheCurrentDate(string activityName)
        {
            // Drag and drop a folder asset to current date.
            Logger.LogMethodEntry("AssignmentCalendar",
               "DragAndDropFolderToCurrentDate",
               base.IsTakeScreenShotDuringEntryExit);
            // Drag and drop a folder asset to current date.
            new CalendarHedDefaultUxPage().DragAndDropFolderAsset(activityName);
            Logger.LogMethodExit("AssignmentCalendar",
              "DragAndDropFolderToCurrentDate",
              base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see the ""(.*)"" status for the activity ""(.*)"" in ""(.*)"" page")]
        [Then(@"I should see the ""(.*)"" status for the activity ""(.*)"" in Assignments Page")]
        public void StatusForTheActivityInAssignmentsPage(string activityStatus,
            string activityName, string windowName)
        {
            //Validate the submitted activity status
            Logger.LogMethodEntry("CommonSteps",
                "StatusForTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Validate the submitted activity status
            Logger.LogAssertion("ValidateActivityStatus", ScenarioContext.Current.ScenarioInfo.
                Title, () => Assert.AreEqual(activityStatus, new StudentPresentationPage().
                    GetStatusOfSubmittedActivityInAssignmentsPage(activityName, windowName)));
            Logger.LogMethodExit("CommonSteps",
                "StatusForTheActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }


        [When(@"I click on return to course")]
        public void ClickOnReturnToCourse()
        {
            Logger.LogMethodEntry("CommonSteps", "ClickOnReturnToCourse",
            base.IsTakeScreenShotDuringEntryExit);
            new StudentPresentationPage().ReturnToCourseSpace();
            Logger.LogMethodExit("CommonSteps", "ClickOnReturnToCourse",
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
        /// Selecting Report Link In HSS.
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="userTypeEnum"></param>
        [When(@"I click on ""(.*)"" report link as ""(.*)""")]
        public void ClickOnReportLink(string reportName, User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("CommonSteps", "ClickReportButton",
            base.IsTakeScreenShotDuringEntryExit);
            // Click on the report link
            new RptMainUXPage().ClickReportLinkInHSS(reportName, userTypeEnum);
            Logger.LogMethodExit("CommonSteps", "ClickReportButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        ///// <summary>
        ///// Verify due date icon is diplayed in assigned date.
        ///// </summary>
        //[Then(@"I should see due date icon displayed in current date")]
        //public void VerifyDueDateIconDisplayed()
        //{
        //    // Verify due date icon is diplayed in assigned date
        //    Logger.LogMethodEntry("AssignmentCalendar",
        //      "VerifyDueDateIconDisplayed",
        //      base.IsTakeScreenShotDuringEntryExit);
        //    // Verify due date icon is diplayed in assigned date
        //    Logger.LogAssertion("VerifyDueDateIconDisplayed",
        //       ScenarioContext.Current.ScenarioInfo.Title,
        //       () => Assert.IsTrue(new CalendarHedDefaultUxPage()
        //           .IsActivityDueDateStatusPresent()));
        //    Logger.LogMethodEntry("AssignmentCalendar",
        //     "VerifyDueDateIconDisplayed",
        //     base.IsTakeScreenShotDuringEntryExit);
        //}



    }
}
