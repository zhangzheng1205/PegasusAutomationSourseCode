using System;
using Framework.Common;
using OpenQA.Selenium;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Create_Class;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Activity;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TeachingPlan;
using TechTalk.SpecFlow;
namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class ClassCreationInCSDefinitions : BaseTestScript
    {
        //Purpose: Calling of Page Class Methods
        private readonly ManageOrganizationPage _objManageOrg = new ManageOrganizationPage();
        private readonly ManageClassManagementPage _objClassCreate = new ManageClassManagementPage();
        private readonly CreateNewClassPage _objClassCreation = new CreateNewClassPage();
        private readonly ContentLibraryUxPage _objcontentLibrary = new ContentLibraryUxPage();
        private readonly TeachingplanUXPage _contentPage = new TeachingplanUXPage();

        // Purpose - To select Classes tab
        [Given("I select the Classes Tab")]
        [Then("I select the Classes Tab")]
        public void ThenISelectClassesTab()
        {
            try
            {
                _objManageOrg.SelectClassesTab();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose - To select add class button
        [Given(@"I select the Add Classes button")]
        public void SelectAddClassesButton()
        {
            try
            {
                _objClassCreate.ToselectAddClass();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose - To select add class button
        [Then(@"I select the Add Classes button")]
        public void ThenISelectAddClassesButton()
        {
            try
            {
                _objClassCreate.ToselectAddClass();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose - To create class using template option
        [When("I create the Class using Template option")]
        public void CreateClassUsingTemplateOption()
        {
            try
            {
                GenericHelper.SelectWindow("Create Class");
                bool isCreateClassWindowOpened = GenericHelper.WaitUtilWindow("Create Class");
                if (isCreateClassWindowOpened)
                {
                    _objClassCreation.ToCreateClass();
                }
                else
                {
                    GenericHelper.Logs("'Create Class' pop-up not opened for creation of class using template.", "FAILED");
                    throw new NoSuchWindowException("'Create Class' pop-up not opened for creation of class using template.");
                }
                GenericHelper.SelectWindow("Manage Organization");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");

                if (GenericHelper.IsPopUpWindowPresent("Manage Organization"))
                {
                    GenericHelper.SelectWindow("Manage Organization");
                    WebDriver.Close();
                }

                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose - To create class using ML option
        [When("I create the Class using ML option")]
        public void CreateTheClassUsingMl()
        {
            try
            {
                _objClassCreation.ToCreateClassUsingML();
                GenericHelper.Logs("Class Has been created using the 2nd option (Master Library)", "Passed");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericHelper.SelectWindow("Manage Organization");
                WebDriver.Close();
                GenericHelper.SelectWindow("Organization Management");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose - To search class 
        [Given(@"I search the Class in order to add courses")]
        public void GivenISearchTheClassToAddCourse()
        {
            try
            {
                _objClassCreation.ToSearchForAssigned(Enumerations.ClassType.NovaNETTemplate);
                GenericHelper.Logs("Class Has been searched successfully in order to add the courses", "Passed");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose - To add course
        [When("I add the course in the class")]
        public void WhenIAddTheCourse()
        {
            try
            {
                _objClassCreation.AddCourseInClass();
                GenericHelper.Logs("course has been successfully added in the class", "Passed");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose - To enter the class as teacher and unhide the ML
        [When("I enter the class as teacher")]
        public void WhenIEnterTheClassasTeacher()
        {
            try
            {
                _objClassCreation.EnterClassAsTeacherToUnhide();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // purpose - I move the ML to the right frame
        [When(@"I move the ML to right frame")]
        public void MoveTheMLtoRightFrame()
        {
            try
            {
                _objcontentLibrary.MoveToRightFrame();
                GenericHelper.Logs("User selected the ML checkebox in left frame after entering class as teacher", "Passed");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose - I close the content window
        [Then(@"I close the Content window")]
        public void CloseTheContentWindow()
        {
            try
            {
                _objcontentLibrary.ClosetheWindow();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //purpose- I select the home button
        [Then(@"I select the Home button")]
        public void ThenISelectHomeButton()
        {
            try
            {
                _objManageOrg.ToSelectBackButton();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");

                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        //Purpose - To search for assigned to copy class and get out of assigned to copy state
        [Then(@"I wait to get out of assigned to copy state")]
        public void ThenIWaitToGetOutOfAssignedToCopyState()
        {
            try
            {
                _objClassCreation.ToSearchForAssigned((Enumerations.ClassType.NovaNETTemplate));

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }


        //Purpose - ToWait Class Gets in Available State
        [Then(@"I wait for the class to get in available state")]
        public void ThenIWaitForTheClassToGetInAvailableState()
        {
            _contentPage.WaitMLToGetInPrepareState();
        }
    }
}
