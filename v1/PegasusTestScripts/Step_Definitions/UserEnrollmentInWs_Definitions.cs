using System;
using System.Configuration;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus.AdminToolPage;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class UserEnrollmentInWsDefinitions : BaseTestScript
    {
        //Purpose: Calling Page Class
        private readonly AdminToolPage _wSEnrollmentpage = new AdminToolPage();
        //Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        //Purpose: To verify 'Course Enrollment' page
        [Given(@"I am on the User Enrollment Page")]
        public void GivenIAmOnTheUserEnrollmentPage()
        {
            try
            {
                string browserName = WebDriver.Title;
                if (browserName == "Course Enrollment")
                    GenericHelper.Logs("WS Course Enrollment Page is dispalyed", "PASSED");
                else
                    GenericHelper.Logs("WS Course Enrollment Page is not dispalyed", "FAILED");
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

        //Purpose: To search and open the course
        [When("I selected the created \"(.*)\" Course")]
        [Given("I selected the created \"(.*)\" Course")]
        public void GivenISelectedTheCreatedCourse(string courseType)
        {
            // course will be fetched fm db
            try
            {
                _wSEnrollmentpage.SelectCourse(courseType);
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

        //Purpose: To select the user
        [When(@"I select the WsUser")]
        public void WhenISelectTheWsUser()
        {
            try
            {
                string username = DatabaseTools.GetUsername(Enumerations.UserType.WsTeacher);
                _wSEnrollmentpage.SelectUser(username);
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

        //Purpose: To enrolled the user as Teacher to Course
        [When(@"I enrolled the user as Teacher in the Empty course")]
        [When(@"I enrolled the user as Teacher in the Container course")]
        [When(@"I enrolled the user as Teacher in the Master Library course")]
        public void WhenIEnrolledTheUserAsTeacherInTheCourse()
        {
            try
            {
               _wSEnrollmentpage.EnrollUserAsTeacher();
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

        //Purpose: To verify enrolled is user present with role name
        [Then(@"I should see the enrolled ""Teacher"" should present in Right frame as a Role Name as ''Teacher""")]
        public void ThenIShouldSeeTheEnrolledTeacherShouldPresentInRightFrameAsARoleNameAsTeacher()
        {
            try
            {
                _wSEnrollmentpage.VerifyEnrolledUser();
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
    }
}
