using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Admin.User;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class UserCreationInWsDefinitions : BaseTestScript
    {
        //Purpose: Calling Page Class
        private readonly NewUserPage _newUserPage = new NewUserPage();
        //Purpose: Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        //Purpose: Step To Create WS user 
        [When(@"I create the user  with user details")]
        public void WhenICreateTheUserWithUserDetails(Table table)
        {
            try
            {
                // Purpose: Username and Password will be written to DB
                string username = string.Empty;
                switch (((string[])(table.Rows[0].Values))[1])
                {
                    case "Teacher":
                        username = GenericHelper.GenerateUniqueVariable("Teach");
                        break;
                    case "Student":
                        username = GenericHelper.GenerateUniqueVariable("Stud");
                        break;
                }
                _newUserPage.AddNewUser(table, username);
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
