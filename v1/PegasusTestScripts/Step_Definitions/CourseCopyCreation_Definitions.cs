using System;
using System.Configuration;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus.AdminToolPage;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus.NewCoursPage;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class CourseCopyCreationDefinitions : BaseTestScript
    {
        //Purpose: Calling Page Class
        private readonly AdminToolPage _wSEnrollmentpage = new AdminToolPage();
        readonly NewCoursePage _newCoursePage = new NewCoursePage();
        readonly string _copyCourseName = GenericHelper.GenerateUniqueVariable("digits-grade");
        private readonly string _mlName = DatabaseTools.GetCourse(Enumerations.CourseType.AuthoredMasterLibrary);
        //Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        //Purpose: To  Wait for the Authored Course Out From [Assign To Copy State]
        [Then(@"I Wait for the course out from Assign To Copy State")]
        [When(@"I Wait for the course out from Assign To Copy State")]
        [Given(@"I Wait for the course out from Assign To Copy State")]
        public void ThenIWaitForTheCourseOutFromAssignToCopyState()
        {
            try
            {
                WebDriver.SwitchTo().Window("");
                _wSEnrollmentpage.CourseSearch(_mlName);
                _wSEnrollmentpage.CheckAssignedToCopyState(_mlName);
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

        //Purpose: To Copy the Course to Same Workspace
        [Then(@"I Copy the Course to Same Workspace")]
        public void ThenICopyTheCourseInSameWorkspace()
        {
            try
            {
                _newCoursePage.CopyCourse(_copyCourseName);
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
