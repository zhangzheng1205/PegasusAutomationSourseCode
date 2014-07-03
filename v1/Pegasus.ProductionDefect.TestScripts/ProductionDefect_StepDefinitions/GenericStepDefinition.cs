using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
namespace Pegasus.ProductionDefect.TestScripts.ProductionDefect_StepDefinitions
{
    [Binding]
    public class GenericStepDefinition : BaseTestScript
    {
        //Purpose: Constant Declaration
        public IWebDriver Webd;
        private static readonly LoginPage.LoginPage LoginPage = new LoginPage.LoginPage();
        static readonly string Browser = ConfigurationSettings.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        // Purpose : Step Definition to Browse Url  for Pegasus User(s)     
        [Given("I have browsed url for \"(.*)\"")]
        [Then("I have browsed url for \"(.*)\"")]
        public static void BrowsedUrlForPegasusUser(string usertype)
        {
            try
            {
                GenericTestStep.StepToBrowsedUrlForPegasusUser(usertype);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Definition To Login as WS Teacher
        [When(@"I have logged into the work space as WS Teacher")]
        public static void WhenIHaveLoggedIntoTheWorkspaceAsWsTeacher()
        {
            try
            {
                GenericTestStep.StepToLoggedIntoTheWorkspaceAsWsTeacher();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step To Login as WS Admin
        [When(@"I have logged into the work space as WSAdmin")]
        public static void WhenIHaveLoggedIntoTheWorkspaceAsWsAdmin()
        {
            try
            {
                GenericTestStep.StepToLoggedIntoTheWorkspaceAsWsAdmin();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To Login as HED WS Admin
        [When(@"I have logged into the work space as HEDWSAdmin")]
        public static void WhenIHaveLoggedIntoTheWorkspaceAsHedWsAdmin()
        {
            try
            {
                GenericTestStep.StepToLoggedIntoTheWorkspaceAsHedWsAdmin();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To Login as CS Admin
        [Given(@"I have logged into the Course space as CSAdmin")]
        [When(@"I have logged into the Course space as CSAdmin")]
        public void WhenIHaveLoggedIntoTheCourseSpaceAsCSAdmin()
        {
            try
            {
                GenericTestStep.StepToLoggedIntoTheCourseSpaceAsCSAdmin();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To Login as HED CS Admin
        [Given(@"I have logged into the Course space as HEDCSAdmin")]
        [When(@"I have logged into the Course space as HEDCSAdmin")]
        public static void WhenIHaveLoggedIntoTheCourseSpaceAsHedCSAdmin()
        {
            try
            {
                GenericTestStep.StepToLoggedIntoTheCourseSpaceAsHedCSAdmin();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step Definition To Verify Page is Opened 
        [Given("Im on the \"(.*)\" page")]
        [Then("It should show the \"(.*)\" page")]
        [Then("It should be on \"(.*)\" page")]
        public static void ThenItShouldBeOnPage(string pageName)
        {
            try
            {
                GenericTestStep.StepToItShouldBeOnPage(pageName);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step Definition To Verify Page Name   
        [Then("I should see the \"(.*)\" popup")]
        public static void ThenIShouldSeeTheNewPopup(string pageName)
        {
            try
            {
                GenericTestStep.StepToIShouldSeeTheNewPopup(pageName);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step To Verify Success Message  in Work Space
        [Then("It should display successful message \"(.*)\"")]
        public static void ThenItShouldDisplaySuccessfulMessage(string successMsg)
        {
            try
            {
                GenericTestStep.StepToItShouldDisplaySuccessfulMessage(successMsg);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
            }
        }

        // Purpose : Step Definition To Verify Success Message  in Course Space
        [Then("It should display successful message \"(.*)\" in \"(.*)\" page")]
        public void ThenItShouldDisplaySuccessfulMessageInPage(string successMsg, string page)
        {
            try
            {
                GenericTestStep.StepToItShouldDisplaySuccessfulMessageInPage(successMsg, page);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                bool isManageOrganizationWindowPresent = GenericHelper.IsPopUpWindowPresent("Manage Organization");
                if (isManageOrganizationWindowPresent)
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }
                ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step Definition To Click on Logout Link From Ws
        [Then(@"I clicked on the Logout link to get logged out from the application")]
        public static void ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication()
        {
            try
            {
                GenericTestStep.StepToIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step Definition To Click on Logout Link From Ws
        [When(@"I clicked on the Logout link to get logged out from the application")]
        public static void ClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication()
        {
            try
            {
                GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : Step Definition to Select the specified tab or subtab
        [Given("I selected the \"(.*)\" sub tab")]
        [When("I selected the \"(.*)\" sub tab")]
        [Then("I selected the \"(.*)\" sub tab")]
        [Given("I navigate to the \"(.*)\" Tab")]
        [Then("I navigate to the \"(.*)\" Tab")]
        [When("I navigate to the \"(.*)\" Tab")]
        public static void GivenINavigateToTheTab(string tab)
        {
            try
            {
                GenericTestStep.StepToNavigateToTheTab(tab);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : Step Definition to Select the specified tab or subtab
        [When("I select the \"(.*)\" sub tab")]
        [When("I navigate to the \"(.*)\" tab")]
        [Then("I navigate to the \"(.*)\" tab")]
        public static void NavigateToTheTab(string tab)
        {
            try
            {
                GenericTestStep.StepToSwitchToTheTab(tab);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : Step Definition to Select the course in globalhome of workspace
        [Given("I select the created \"(.*)\"")]
        public static void WhenISelectTheCreatedCourse(string course)
        {
            try
            {
                GenericTestStep.StepToSelectTheCreatedCourse(course);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : Step Definition To Click on a particular link
        [Then("I Click on the \"(.*)\" link")]
        public static void ThenIClickOnTheLink(String linkName)
        {
            try
            {
                GenericTestStep.StepToClickOnTheLink(linkName);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : Step Definition To Verify ST Environment Working Fine
        [Then(@"I should be able to access (.*) pages")]
        [Then("I should be able to access \"(.*)\" pages")]
        public static void SetupSTEnvironment(string sTUrl)
        {
            try
            {
                GenericTestStep.StepToSetupSTEnvironment(sTUrl);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step Definition To verify the page name
        [Given("I am on the \"(.*)\" page")]
        public static void GivenIAmOnThePage(string pageName)
        {
            try
            {
                GenericTestStep.StepToIAmOnThePage(pageName);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To verify UserCreation/Course creation page is present
        [Given(@"I am on the Course Creation page")]
        [Given(@"I am on the User Creation Page")]
        public static void GivenIAmOnTheUserCreationPage()
        {
            try
            {
                GenericTestStep.StepToIAmOnTheUserCreationPage();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To click CreateNewUser/CreateNewCourse link 
        [Given("I clicked on the \"(.*)\" link in \"(.*)\" frame")]
        public static void WhenIClickedOnTheCreateNewLink(string linkName, string frame)
        {
            try
            {
                GenericTestStep.StepToClickedOnTheLink(linkName, frame);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step Definition To Select Home Button
        [When(@"I select the Home button to go back on Global Home page")]
        public static void WhenIselectHomeButton()
        {
            try
            {
                GenericTestStep.StepToSelectHomeButton();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step Definition To Select Global Home Button
        [Then(@"I select the Home button to go back on Global Home page")]
        public static void ThenIselectHomeButton()
        {
            try
            {
                GenericTestStep.StepTonIselectGlobalHomeButton();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To click on specified link
        [Then("I clicked on the \"(.*)\" link")]
        [Given("I clicked on the \"(.*)\" link")]
        public void WhenIClickedOnTheApproveCourseLink(string linktext)
        {
            try
            {
                GenericTestStep.StepToClickedOnTheApproveCourseLink(linktext);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To Click on the search/view button
        [When("I clicked on the Search/View button in \"(.*)\" frame")]
        public void ClickedOnSearchViewButton(string frameId)
        {
            try
            {
                GenericTestStep.StepToClickedOnSearchViewButton(frameId);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To Search any Level of Organization from the Organization Tab
        [When("I search the \"(.*)\" level organization")]
        public void IsearchTheOrganization(string levelName)
        {
            try
            {
                GenericTestStep.StepToSearchTheOrganization(levelName);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To close the Manage Organization Window and log out from the application
        [Then(@"I close the Manage Organization Window and log out from the application")]
        [When(@"I close the Manage Organization Window and log out from the application")]
        public static void WhenIClosetheManageOrganizationAndLogOutFromTheApplication()
        {
            try
            {
                GenericTestStep.StepToClosetheManageOrganizationAndLogOutFromTheApplication();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To login as CS student
        [When(@"I have logged into the course space as CS Student")]
        public void WhenIHaveLoggedIntoTheCourseSpaceAsCSStudent()
        {
            try
            {
                GenericTestStep.StepToLoggedIntoTheCourseSpaceAsCSStudent();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To login as CS student
        [When(@"I have logged into the work space as HEDTeacher")]
        public void WhenIHaveLoggedIntoTheworkSpaceAsHEDTeacher()
        {
            try
            {
                GenericTestStep.StepToLoggedIntoTheCourseSpaceAsHEDTeacher();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }


        //Purpose: Step Definition To login as CS Teacher
        [When(@"I have logged into the course space as CS Teacher")]
        public void WhenIHaveLoggedIntoTheCourseSpaceAsCSTeacher()
        {
            try
            {
                GenericTestStep.StepToLoggedIntoTheCourseSpaceAsCSTeacher();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To login as SMS Instructor
        [When(@"I have logged into the course space as SMS Instructor")]
        public void WhenIHaveLoggedIntoTheCourseSpaceAsSmsInstructor()
        {
            try
            {
                GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSInstructor();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To login as SMS Instructor
        [When(@"I have logged into the course space as HED Teaching Assistant")]
        public void WhenIHaveLoggedIntoTheCourseSpaceAsTeachingAssistant()
        {
            try
            {
                GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsStudent");
                GenericTestStep.StepToLoggedIntoTheCourseSpaceAsTeachingAssistant();
                GenericTestStep.StepToCloseStudentHelpTextWindow();
               }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To login as SMS Instructor
        [When(@"I have logged into the course space as SMS Student")]
        public void WhenIHaveLoggedIntoTheCourseSpaceAsSmsStudent()
        {
            try
            {
                GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSStudent();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To verify the courses for student after TA
        [Then(@"It should display the courses")]
        public void ThenItshoulddisplaythecourses()
        {
            try
            {
                GenericTestStep.StepToVerifyCoursesforTA();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: Step Definition To update the preference status of course
        [Then(@"Update the preference status in DB for (.*)")]
        public void ThenUpdateThePreferenceStatusInDBForBDDCC(string course)
        {
            try
            {
                GenericTestStep.StepToUpdateThePreferenceStatusInDBForBDDCC(course);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To update the Publish status of course
        [Then(@"I Update the publish status in DB for (.*)")]
        public void ThenUpdateThePublishStatusOfTheCourseInDB(string course)
        {
            try
            {
                GenericTestStep.SteptToUpdateThePublishStatusOfTheCourseInDB(course);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Step Definition To update the Publish status of course
        [Then("I Update the Enroll status in DB for \"(.*)\" Enrollment")]
        public void ThenUpdateTheEnrollStatusOfTheUserInDB(string user)
        {
            try
            {
                GenericTestStep.StepToUpdateTheEnrollStatusOfTheUserInDB(user);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        [Then("It should display successful message \"(.*)\" with no exception")]
        public void ThenItShouldDisplaySuccessfulMessageStudyPlanUpdatedSuccessfullyWithNoException(string sucessMessage)
        {
            GenericTestStep.StepToVerifySuccessfulMessageForEditStudyPlan(sucessMessage);
        }

        // Verificatino of template under the template tab
          [Then(@"I verify the Template under the Template tab")]
        public void WhenIverifyTheTemplateUndertheTemplateTab()
        {
            try
            {
                GenericHelper.ToVerifyTemplateInactiveState();
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.SelectWindow("Program Administration");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
           
        }
    }
}