using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Activity;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Calendar;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class CalendarCreationInCSDefinitions:BaseTestScript
    {
        //Purpose: Calling Other Page Classe(s)
        readonly private MyPegasusUxPage _objMyPeg = new MyPegasusUxPage();
        readonly private CalendarDefaultUX _objCal = new CalendarDefaultUX();
        //Purpose: Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        // Purpose - TO select class name from the global home page
        [When(@"I select the class name as CSteacher")]
        public void WhenISelectTheClassNameasCsTeacher()
        {
            try
            {
                _objMyPeg.ToSelectClassName();
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

        // Purpose - To set up view calendar format
        [When(@"I Setup the view calendar format")]
        public void WhenISetupViewCalenderFormat()
        {
            try
            {
                _objCal.ToSelectCalendarSetupButton();
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

        // Purpose - TO drag and drop the activity to the calendar
        [When(@"I drag and drop the activity to the calendar")]
        public void WhenIDragAndDropTheActivityToTheCalendar()
        {
            try
            {
                _objCal.ToDragAndDrop();
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

        // Purpose - TO verify whethar the activity was moved to the right frame of calendar
        [Then(@"Activity should be successfully assigned to the calendar")]
        [When(@"Activity should be successfully assigned to the calendar")]
        public void WhenActivityShouldSuccessfullyAssignedtoTheCalendar()
        {
            try
            {
                _objCal.ToVerifyTheActivity();
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

        // purpose- to go back from calendar home page - locator was different so dint use the generic definition method

        [Then(@"I select the Home button to go back from Calendar page")]
        public void ThenIselecttheHomebuttontogobackfromCalendarPage()
        {
            try
            {
                _objCal.ToGoBackFromCalendar();
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
         [When(@"I move to the Calendar Tab")]
        public void WhenImovetotheCalendar()
         {
             try
             {
                 GenericHelper.SelectWindow("Content");
                 GenericHelper.WaitUntilElement(By.PartialLinkText("Calendar"));
                 WebDriver.FindElement(By.PartialLinkText("Calendar")).Click();
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
