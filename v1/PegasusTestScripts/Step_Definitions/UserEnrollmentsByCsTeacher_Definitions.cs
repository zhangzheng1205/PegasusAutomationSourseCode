using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Coursesettings;
using Pegasus_DataAccess;
using Framework.Common;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.MyPegasus;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Admin.User;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.GradeBook;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class UserEnrollmentsByCsTeacherDefinitions : BaseTestScript
    {
        // Purpose: Calling of other Classes
        readonly MyPegasusPage _myPegasusPage = new MyPegasusPage();
        readonly RosterPreferencesPage _rosterPreferencesPage = new RosterPreferencesPage();
        readonly AdduserPage _adduserPage = new AdduserPage();
        readonly GBRoasterDefaultPage _gbRoasterDefaultPage = new GBRoasterDefaultPage();
        //Purpose: Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
        private const string LogOut = "//a[substring(@id, string-length(@id) - string-length('_testLogOut')+ 1, string-length(@id))= '_testLogOut']";

        //Purpose : to Select the class created using template option in Global home page
        [When(@"I select the Template Class")]
        public void WhenISelectTheTemplateClass()
        {
            try
            {               
                _myPegasusPage.SelectTemplateClass();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Thread.Sleep(3000);
                throw new Exception(e.ToString());
            }
        }

        // Purpose : To Enable the roster
        [When(@"Enable Roaster in Preferences tab")]
        public void WhenEnableRoasterInPreferecesTab()
        {
            try
            {
                _rosterPreferencesPage.EnableRoster();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Thread.Sleep(3000);
                throw new Exception(e.ToString());
            }
        }

        // Purpose : To create Cs student by Cs Teacher
        [When(@"I create the user as Student")]
        public void WhenICreateTheUserAsStudent(Table table)
        {
            try
            {
                _gbRoasterDefaultPage.VerifyRosterTabClicked();
                _gbRoasterDefaultPage.SelectRoasterStudentOption();
                string username = GenericHelper.GenerateUniqueVariable("CsStud");
                GenericHelper.SelectDefaultWindow();
                _adduserPage.AddUser(table, username);
                bool isCreateUserPopUpclosed = GenericHelper.IsPopUpClosed(2);
                if (isCreateUserPopUpclosed)
                {
                    DatabaseTools.UpdateUserDb(Enumerations.UserType.CsStudent, username, "bdd_pwd123", "user.bdd@excelindia.com", 9, true);
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                Thread.Sleep(3000);
                throw new Exception(e.ToString());
            }
        }
    }
}

