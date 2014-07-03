using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.StudyMaterialsExplorer;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool.Presentation;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.GradeBook;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.MyPegasus;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TodaysView;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class ViewSubmissionInCSDefinitions : BaseTestScript
    {
        //Purpose: Calling Page Class
        readonly StudentExplorePage _studentExplorePage = new StudentExplorePage();
        readonly PresentationPage _presentationPage = new PresentationPage();
        readonly GBStudentPage _gbStudentPage = new GBStudentPage();
        readonly MyPegasusPage _myPegasusPage = new MyPegasusPage();
        readonly private TodaysViewPage _todaysViewPage = new TodaysViewPage();
        //Purpose: Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        //Purpose : To open the Benchmark Test 1 activity inside the Benchmark Tests folder under Practice Tab 
        [Then(@"I open the 'Activity'")]
        [When(@"I open the 'Activity'")]
        public void WhenIOpenTheActivity()
        {
            try
            {
                _studentExplorePage.NavigateToBenchmarkTest1ActivityAndOpen();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Thread.Sleep(1000);
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To verify activity has launched
        [Then(@"It should launch the activity successfully")]
        public void ThenItShouldLaunchTheActivitySuccessfully()
        {
            try
            {
                _presentationPage.VerifyActivityLaunch();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Thread.Sleep(1000);
                GenericHelper.SelectWindow("Global Home");
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To submit the activity Benchmark Test 1
        [When(@"I submit the activity")]
        public void WhenISubmitTheActivity()
        {
            try
            {
                _presentationPage.SubmittingBenchmarkTest1();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Thread.Sleep(1000);
                GenericHelper.SelectWindow("Gradebook");
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To verify the activity submission
        [Then(@"It should successfully submit the activity for grading")]
        public void ThenItShouldSuccessfullySubmitTheActivityForGrading()
        {
            try
            {
                _presentationPage.ToVerifyActivitySubmission();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Thread.Sleep(1000);
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To select the course on cs student login
        [When("I select the course with prefix \"(.*)\" as CSstudent")]
        public void WhenISelectTheCourseWithPrefixBddmlasCSstudent(string course)
        {
            try
            {
                _myPegasusPage.ClickOnCourseAsStudent();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Thread.Sleep(1000);
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To navigate to the Practice Tab
        [Then(@"I navigate to the Practice Tab")]
        public void ThenINavigateToThePracticeTab()
        {
            try
            {
                _todaysViewPage.SelectPracticeTab();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Thread.Sleep(1000);
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To navigate to the Grades Tab
        [When(@"I navigate to the Grades Tab")]
        [Then(@"I navigate to the Grades Tab")]
        public void ThenINavigateToTheGradesTab()
        {
            try
            {
                _todaysViewPage.NavigateToGradesTab();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Thread.Sleep(1000);
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To open the Benchmark Test 1 activity inside the Benchmark Tests folder under Grades Tab 
        [Then(@"I open the 'Activity' in Grades Tab")]
        public void ThenIOpenTheActivityInGradesTab()
        {
            try
            {
                _gbStudentPage.NavigateToBenchmarkTestsFolderUnderGradesTab();
                _gbStudentPage.OpenBenchmarkTest1ActivityInGradesTab();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Thread.Sleep(1000);
                GenericHelper.SelectWindow("Gradebook");
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }

        }

        //Purose: To verify the grades displayed under Grdes Tab for 'Benchmark Test 1' activity
        [Then(@"It should display the grade under grade column of the submitted activity")]
        public void ThenItShouldDisplayTheGradeUnderGradeColumnOfTheSubmittedActivity()
        {
            try
            {
                _gbStudentPage.NavigateToBenchmarkTestsFolderUnderGradesTab();
                _gbStudentPage.ToVerifyGradesUnderGradeTab();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Thread.Sleep(1000);
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }
    }
}
