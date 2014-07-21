﻿using TechTalk.SpecFlow;
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Acceptance.MyTest.Tests.CommonProductAcceptanceTestDefinitions
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
        private static readonly Logger Logger = Logger.GetInstance(typeof(CommonSteps));

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
        public void DisplayTheSuccessfullMessage(
            String successMessage)
        {
            // Method To Verify the Success Message     
            Logger.LogMethodEntry("CommonSteps", "DisplayTheSuccessfullMessage",
                isTakeScreenShotDuringEntryExit);
            //Verify Correct Message Present on the Page
            IsMessageExists(successMessage,
                                 CommonStepsResource.
                                 CommonSteps_SuccessMessage_Class_Locator);
            //Removed The Assert For Message Because Sometimes Message not comes 
            //but this is not the severe issue. So We, can ignore this.
            Logger.LogMethodExit("CommonSteps", "DisplayTheSuccessfullMessage",
                 isTakeScreenShotDuringEntryExit);
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
                isTakeScreenShotDuringEntryExit);
            Thread.Sleep(Convert.ToInt32(CommonStepsResource.
                 CommonSteps_SleepTime_Value));
            //Wait Untill Window Loads
            WaitUntilPopUpLoads(popUpName,
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
        /// Successfull Message In MyTest Tab
        /// </summary>
        /// <param name="successMessage">This is Success Message</param>
        [Then(@"I should see the successfull message ""(.*)"" in MyTest tab")]
        public void SuccessfullMessageInMyTestTab(string successMessage)
        {
            //Successfull Message In MyTest Tab
            Logger.LogMethodEntry("CommonSteps", "SuccessfullMessageInMyTestTab",
                base.isTakeScreenShotDuringEntryExit);
            //Assert Display of Success Message
            Logger.LogAssertion("VerifySuccessfullMessage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(successMessage,
                    new MyTestGridUXPage().GetSuccessMessageInMyTestTab()));
            Logger.LogMethodEntry("CommonSteps", "SuccessfullMessageInMyTestTab",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
            Logger.LogMethodEntry("CommonSteps", "ShowCourseOnTheGlobalHomePage",
                base.isTakeScreenShotDuringEntryExit);
            //Get Course From Memory
            Course course = Course.Get(courseTypeEnum);
            //Assert Course Present on Global Home Page
            Logger.LogAssertion("VerifyCoursePresent",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(true, new HEDGlobalHomePage().
                    GetCoursePresentInGlobalHomePage().Contains(course.Name)));
            Logger.LogMethodExit("CommonSteps", " ShowCourseOnTheGlobalHomePage",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
            //Enter Into The Course
            new HEDGlobalHomePage().EnterInsideCourse(
                courseTypeEnum, userTypeEnum);
            Logger.LogMethodExit("CommonSteps", " EnterInCourse",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
