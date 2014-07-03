using System;
using System.Configuration;
using System.Linq;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus.AdminToolPage;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using TechTalk.SpecFlow;
using Pegasus.PublishingNotesPage;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class PublishCourseInWsDefinitions : BaseTestScript
    {
        //Purpose: Calling Other Class Page Methods
        readonly ListCoursesPage _coursesPage = new ListCoursesPage();
        private readonly AdminToolPage _wSEnrollmentpage = new AdminToolPage();
        readonly PublishingNotesPage _publishingNotesPage = new PublishingNotesPage();
        //Purpose: Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        //Purpose: To Click on Course Cmenu
        [Given(@"I clicked on the Cmenu of Course")]
        [Then(@"I clicked on the Cmenu of Course")]
        public void WhenIClickedOnTheCmenuOfCourse()
        {
            try
            {
                _wSEnrollmentpage.ClickCourseCmenu();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (Browser.Equals("FF") || Browser.Equals("IE"))
                {
                    BackedSelenium.SelectWindow("");
                }
                if (Browser.Equals("GC"))
                {
                    GenericHelper.SelectDefaultWindow();
                }
                IWebElement clickLogoutLink = WebDriver.FindElement((By.XPath(LogOut)));
                if (clickLogoutLink.Displayed && clickLogoutLink.Enabled)
                {
                    WebDriver.SwitchTo().DefaultContent();
                    new Actions(WebDriver).Click(clickLogoutLink).Perform();
                }
                Thread.Sleep(7000);
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To enter Publishing notes
        [Then(@"I enter the Publishing notes")]
        public void GivenIEnterThePublishingNotes()
        {
            # region Handling Session Out Issue in Build
            bool isPegasuLoginWindowPresent = GenericHelper.IsPopUpWindowPresent("Pegasus Login");
            if (isPegasuLoginWindowPresent)
            {
                return;
            }
            #endregion Handling Session Out Issue in Build
            try
            {
                GenericHelper.WaitUntillWindowAndElement("Publishing Notes", By.Id("txtPublishNotes"));
                _publishingNotesPage.EnterPublishNotes();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (Browser.Equals("FF") || Browser.Equals("IE"))
                {
                    BackedSelenium.SelectWindow("");
                }
                if (Browser.Equals("GC"))
                {
                    GenericHelper.SelectDefaultWindow();
                }
                IWebElement clickLogoutLink = WebDriver.FindElement((By.XPath(LogOut)));
                if (clickLogoutLink.Displayed && clickLogoutLink.Enabled)
                {
                    WebDriver.SwitchTo().DefaultContent();
                    new Actions(WebDriver).Click(clickLogoutLink).Perform();
                }
                Thread.Sleep(7000);
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Click on Pulish button
        [Then(@"I clicked on the 'Publish' button")]
        public void GivenIClickedOnThePublishButton()
        {
            # region Handling Session Out Issue in Build
            bool isPegasuLoginWindowPresent = GenericHelper.IsPopUpWindowPresent("Pegasus Login");
            if (isPegasuLoginWindowPresent)
            {
                return;
            }
            #endregion Handling Session Out Issue in Build
            try
            {
                GenericHelper.SelectWindow("Publishing Notes");
                _publishingNotesPage.ClickPublishButton();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (Browser.Equals("FF") || Browser.Equals("IE"))
                {
                    BackedSelenium.SelectWindow("");
                }
                if (Browser.Equals("GC"))
                {
                    GenericHelper.SelectDefaultWindow();
                }
                IWebElement clickLogoutLink = WebDriver.FindElement((By.XPath(LogOut)));
                if (clickLogoutLink.Displayed && clickLogoutLink.Enabled)
                {
                    WebDriver.SwitchTo().DefaultContent();
                    clickLogoutLink.Click();
                }
                Thread.Sleep(7000);
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To search the course
        [Given("I selected the \"(.*)\" Course")]
        [Then("I selected the \"(.*)\" Course")]
        [When("I selected the \"(.*)\" Course")]
        public void GivenISelectedTheEmptyCourse(string courseType)
        {
            // course will be fetched fm db
            try
            {
                switch (courseType)
                {
                    case "Master Library":
                        string masterLibarary = DatabaseTools.GetCourse(Enumerations.CourseType.MasterLibrary);
                        _wSEnrollmentpage.CourseSearch(masterLibarary);
                        break;
                    case "Container":
                        string container = DatabaseTools.GetEnabledPreferenceCourse(Enumerations.CourseType.ContainerCourse);
                        _wSEnrollmentpage.CourseSearch(container);
                        break;
                    case "Empty":
                        string emptyClass = DatabaseTools.GetEnabledPreferenceCourse(Enumerations.CourseType.EmptyCourse);
                        _wSEnrollmentpage.CourseSearch(emptyClass);
                        break;
                    case "Authored Master Library":
                        string authoredMasterLibrary = DatabaseTools.GetCourse(Enumerations.CourseType.AuthoredMasterLibrary);
                        _wSEnrollmentpage.CourseSearch(authoredMasterLibrary);
                        break;
                    case "AuthoredCourse":
                        string authoredCourse = DatabaseTools.GetCourse(Enumerations.CourseType.AuthoredCourse);
                        _wSEnrollmentpage.CourseSearch(authoredCourse);
                        break;
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (Browser.Equals("FF") || Browser.Equals("IE"))
                {
                    BackedSelenium.SelectWindow("");
                }
                if (Browser.Equals("GC"))
                {
                    GenericHelper.SelectDefaultWindow();
                }
                IWebElement clickLogoutLink = WebDriver.FindElement((By.XPath(LogOut)));
                if (clickLogoutLink.Displayed && clickLogoutLink.Enabled)
                {
                    WebDriver.SwitchTo().DefaultContent();
                    new Actions(WebDriver).Click(clickLogoutLink).Perform();
                }
                Thread.Sleep(7000);
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Approve the course
        [Then("I select the \"(.*)\" Course to approve")]
        public void ThenISelectTheEmptyCourseToApprove(string courseType)
        {
            try
            {
                _coursesPage.SearchCourse(courseType);
                _coursesPage.ClickCmenu();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());

            }
        }

        // Purpose - To Check AssignToCopy status for ML
        [Then(@"I Checked AssignedToCopy status for ML")]
        public void ThenICheckedAssignedToCopyStatusForML()
        {
            try
            {
                _wSEnrollmentpage.IsAssignToCopyStatusPresent();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (Browser.Equals("FF") || Browser.Equals("IE"))
                {
                    BackedSelenium.SelectWindow("");
                }
                if (Browser.Equals("GC"))
                {
                    GenericHelper.SelectDefaultWindow();
                }
                IWebElement clickLogoutLink = WebDriver.FindElement((By.XPath(LogOut)));
                if (clickLogoutLink.Displayed && clickLogoutLink.Enabled)
                {
                    WebDriver.SwitchTo().DefaultContent();
                    new Actions(WebDriver).Click(clickLogoutLink).Perform();
                }
                Thread.Sleep(7000);
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To click on specified link
        [Then("I clicked on the \"(.*)\" link for the course")]
        public void WhenIClickedOnTheApproveCourseLink(string linktext)
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("grdCourse"));
                bool isCourseAlreadyPublished = GenericHelper.IsElementPresent(By.XPath("//table[@id='grdCourse']/tbody/tr/td[4]/img[contains(@src,'/images/SMSIntegration/ProgramManagement/icn_approvedStatus.gif')]"));
                if (isCourseAlreadyPublished)
                {
                    return;
                }
                GenericHelper.WaitUntilElement(By.PartialLinkText(linktext));
                IWebElement clickApproveLink = WebDriver.FindElement(By.PartialLinkText(linktext));
                new Actions(WebDriver).MoveToElement(clickApproveLink).Click(clickApproveLink).Perform();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose : Step To Verify Success Message 
        [Then("It should display successful message \"(.*)\" for the published course")]
        public static void ThenItShouldDisplaySuccessfulMessage(string successMsg)
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("grdCourse"));
                bool isCourseAlreadyPublished = GenericHelper.IsElementPresent(By.XPath("//table[@id='grdCourse']/tbody/tr/td[4]/img[contains(@src,'/images/SMSIntegration/ProgramManagement/icn_approvedStatus.gif')]"));
                if (Browser.Equals("FF") || Browser.Equals("IE"))
                {
                    BackedSelenium.SelectWindow("");
                }
                if (Browser.Equals("GC"))
                {
                    GenericHelper.SelectDefaultWindow();
                }
                bool ismessagedisplayed = GenericHelper.VerifySuccesfullMessage(successMsg);
                if (isCourseAlreadyPublished && !ismessagedisplayed)
                {
                    return;
                }
                if (ismessagedisplayed)
                {
                    GenericHelper.Logs(successMsg + " successful message displayed", "PASSED");
                }
                else
                {
                    GenericHelper.Logs(successMsg + " successful message not displayed", "FAILED");
                    throw new Exception(successMsg + " successful message not displayed");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Verify Publishing Notes Pop Up for Container Course
        [Then("I should see the \"(.*)\" popup for Container Course")]
        public void ThenIShouldSeeThePublishingNotesPopupForContainerCourse(string pageName)
        {
            try
            {
                # region Handling Session Out Issue in Build
                bool isPegasuLoginWindowPresent = GenericHelper.IsPopUpWindowPresent("Pegasus Login");
                if (isPegasuLoginWindowPresent)
                {
                    GenericHelper.Logs("Publish container course not able to proceed due to session out 'Pegasus Login' window present.", "FAILED");
                    return;
                }
                #endregion Handling Session Out Issue in Build
                string popupName = null;
                GenericHelper.WaitUtilWindow(pageName);
                popupName = WebDriver.WindowHandles.Last();
                if (popupName == pageName)
                {
                    GenericHelper.Logs(pageName + " popup is displayed.", "PASSED");
                }
                else if (popupName != pageName)
                {
                    popupName = WebDriver.WindowHandles.First();
                    if (popupName == pageName)
                    {
                        GenericHelper.Logs(pageName + " popup is displayed.", "PASSED");
                    }
                }
                else
                {
                    GenericHelper.Logs(pageName + " popup is not displayed.", "FAILED");
                    throw new Exception(pageName + " popup is not displayed.");
                }
            }
            catch (Exception e)
            {
               
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Verify Successful Message for Container Course Publishing
        [Then("It should display successful message \"(.*)\" for Container Course")]
        public void ThenItShouldDisplaySuccessfulMessageCoursePublishedSuccessfullyForContainerCourse(string successMsg)
        {
            # region Handling Session Out Issue in Build
            bool isPegasuLoginWindowPresent = GenericHelper.IsPopUpWindowPresent("Pegasus Login");
            if (isPegasuLoginWindowPresent)
            {
                WebDriver.Close();
                GenericHelper.SelectDefaultWindow();
                return;
            }
            #endregion Handling Session Out Issue in Build
            try
            {
                if (Browser.Equals("FF") || Browser.Equals("IE"))
                {
                    BackedSelenium.SelectWindow("");
                }
                if (Browser.Equals("GC"))
                {
                    GenericHelper.SelectDefaultWindow();
                }
                bool ismessagedisplayed = GenericHelper.VerifySuccesfullMessage(successMsg);
                if (ismessagedisplayed == true)
                {
                    GenericHelper.Logs(successMsg + " successful message displayed", "PASSED");
                }
                else
                {
                    GenericHelper.Logs(successMsg + " successful message not displayed", "FAILED");
                    throw new Exception(successMsg + " successful message not displayed");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }
    }
}
