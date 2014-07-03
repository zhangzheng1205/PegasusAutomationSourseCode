using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TodaysView;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.MyPegasus;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class TeacherDashboardDefinitions : BaseTestScript
    {
        //Purpose: Calling Other Class
        private readonly TodaysViewPage _todaysViewPage = new TodaysViewPage();
        private readonly MyPegasusPage _myPegasusPage= new MyPegasusPage();
        //Purpose: Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        //Purpose: To verify display of New Grades alert 
        [Then(@"It should display alert for New Grades")]
        public void ThenItShouldDisplayAlertForNewGrades()
        {
            try
            {
                _todaysViewPage.VerifyNewGradesAlert();
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

        //Purpose: To Select New Grades
        [When(@"I select 'New Grades'")]
        public void WhenISelectNewGrades()
        {
            try
            {
                _todaysViewPage.ClickNewGradesLink();
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

        //Purpose: To Verify the Display of Activity Name on Clicking the 'New Grades'
        [Then(@"It should display the name of submitted activity")]
        public void ThenItShouldDisplayTheNameOfSubmittedActivity()
        {
            GenericHelper.SelectWindow("Overview");
            try
            {
                if (GenericHelper.IsElementPresent(By.Id("TodayInsNewGradeDatagrid")))
                {
                    if (WebDriver.FindElement(By.Id("TodayInsNewGradeDatagrid")).Text.Contains("There are no items."))
                    {
                        GenericHelper.Logs("New Alert for Activity is not dispalyed on clicking 'New Grades' Alert", "FAILED");
                        throw new Exception("New Alert for Activity is not dispalyed on clicking 'New Grades' Alert");
                    }
                    else
                    {
                        GenericHelper.Logs("New Alert for Activity is dispalyed on clicking 'New Grades' Alert", "PASSED");
                    }
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
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.SelectWindow("Overview");
        }
    }
}
