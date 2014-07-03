using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus.NewCoursPage;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class CourseCreationInWsDefinitions : BaseTestScript
    {
        //Purpose: Calling Page Class
        private readonly NewCoursePage _newCoursPage = new NewCoursePage();
        //Purpose: Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        //Purpose : To create course
        [When(@"I create course with course details then verify the course creation successful Message")]
        public void WhenCreateCourseWithDetails(Table table)
        {
            try
            {
            foreach (var tableRow in table.Rows)
            {
                GenericDefinitions.WhenIClickedOnTheCreateNewLink("Create New Courses", "right");
                Thread.Sleep(2000);
                _newCoursPage.CreateCourse(tableRow["Value"]);
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
    }
}
