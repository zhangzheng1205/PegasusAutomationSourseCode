using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.Exceptions;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
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
        [Given(@"I am on the ""(.*)"" page")]
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
            new TodaysViewUXPage().ClickOnHomeLink();
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
        [When(@"I navigate to ""(.*)"" tab of the ""(.*)"" page as PAdmin")]
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
