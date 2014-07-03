#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.Contineo.Tests.
    ContineoAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles Search User Page Actions.
    /// </summary>
    [Binding]
    public class SearchUsers : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(SearchUsers));


        /// <summary>
        /// Search the User in Coursespace.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="tabName">This is Tab Name.</param>
        [When(@"I search the created ""(.*)"" in ""(.*)"" subtab")]
        public void SearchEnrolledUsersInCourseSpace
            (User.UserTypeEnum userTypeEnum, String tabName)
        {
            //Search Enrolled Users In CourseSpace
            Logger.LogMethodEntry("SearchUsers", "SearchEnrolledUsersInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
            //Search Enrolled Users In Course Space
            new ManageUserPage().SearchUserInCourseSpace(userTypeEnum,
                (ManageUserPage.CreateUserTab)Enum.Parse(typeof
                (ManageUserPage.CreateUserTab), tabName));
            Logger.LogMethodExit("SearchUsers", "SearchEnrolledUsersInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Searched User.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="tabName">This is Tab Name.</param>
        [Then(@"I should see the ""(.*)"" in ""(.*)"" subtab")]
        public void VerifyUserNameInCourseSpace
            (User.UserTypeEnum userTypeEnum, String tabName)
        {
            //Verify the Searched User
            Logger.LogMethodEntry("SearchUsers", "VerifyUserNameInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
            //Get the User Name
            User user = User.Get(userTypeEnum);
            //Verify the Searched User
            Logger.LogAssertion("VerifyUserName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(user.Name,
                    new ManageUserPage().GetSearchedUserInCourseSpace
                    ((ManageUserPage.CreateUserTab)Enum.
                    Parse(typeof(ManageUserPage.CreateUserTab), tabName))));
            Logger.LogMethodExit("SearchUsers", "VerifyUserNameInCourseSpace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Class Cmenu Option.
        /// </summary>
        /// <param name="cMenuOptionName">This is Class CMenu Option Name.</param>
        /// <param name="classTypeEnum">This is Class Type Enum.</param>
        [When(@"I select the ""(.*)"" from ""(.*)"" cmenu options")]
        public void SelectTheClassCmenuOption(String cMenuOptionName,
            Class.ClassTypeEnum classTypeEnum)
        {
            //Select The Class Cmenu Option
            Logger.LogMethodEntry("SearchUsers", "SelectTheClassCmenuOption",
                base.isTakeScreenShotDuringEntryExit);
            //Get the Class Name from Memory
            Class className = Class.Get(classTypeEnum);
            ManageClassManagementPage manageClassManagement =
                new ManageClassManagementPage();
            //Search the Class
            manageClassManagement.ClassSearchInCoursespace(className.Name);
            //Click on the cmenu option
            manageClassManagement.SelectTheCMenuOption(cMenuOptionName);
            Logger.LogMethodExit("SearchUsers", "SelectTheClassCmenuOption",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display Of 'Manage Students' Page.
        /// </summary>
        [Then(@"I should be on the 'Manage Students' page")]
        public void VerifyDisplayOfManageStudentsPage()
        {
            //Verify Display Of 'Manage Students' Page
            Logger.LogMethodEntry("SearchUsers", "VerifyDisplayOfManageStudentsPage",
                base.isTakeScreenShotDuringEntryExit);
            //Verify Display Of 'Manage Students' Page
            Logger.LogAssertion("VerifyDisplayOfManageStudentsPage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(SearchUsersResource.SearchUsersPage_ManageStudents_Window_Title,
                    new ManageStudentsDefaultPage().GetManageStudentsPage()));
            Logger.LogMethodExit("SearchUsers", "VerifyDisplayOfManageStudentsPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Enrolled User In 'Manage Student' Page.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should see the ""(.*)"" user in the 'Manage Students' page")]
        public void DisplayOfEnrolledUserInManageStudentPage
            (User.UserTypeEnum userTypeEnum)
        {
            //Verify Verify the Enrolled User
            Logger.LogMethodEntry("SearchUsers", "DisplayOfEnrolledUserInManageStudentPage",
                base.isTakeScreenShotDuringEntryExit);
            //Get the User Name
            User user = User.Get(userTypeEnum);
            //Verify the Enrolled User
            Logger.LogAssertion("VerifyEnrolledUserName", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(user.Name,
                    new ManageStudentsDefaultPage().GetEnrolledUser(user.Name)));
            Logger.LogMethodExit("SearchUsers", "DisplayOfEnrolledUserInManageStudentPage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Message
        /// </summary>
        /// <param name="message">This is Message</param>
        [Then(@"I should see the message ""(.*)""")]
        public void VerifyTheMessage(String message)
        {
            //Verify the Message
            Logger.LogMethodEntry("SearchUsers", "VerifyTheMessage",
                base.isTakeScreenShotDuringEntryExit);
            //Verify the Message
            Logger.LogAssertion("VerifyTheMessage", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(message, new ManageUserPage().GetMessage()));
            Logger.LogMethodExit("SearchUsers", "VerifyTheMessage",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Un Enrolled User In 'Manage Student' Page
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum</param>
        [Then(@"I should see the ""(.*)"" unenroll in the 'Manage Students' page")]
        public void VerifyTheUnEnrolledUserInManageStudentPage(
            User.UserTypeEnum userTypeEnum)
        {
            //Verify The Un Enrolled User In 'Manage Student' Page
            Logger.LogMethodEntry("SearchUsers", "VerifyTheUnEnrolledUserInManageStudentPage",
                base.isTakeScreenShotDuringEntryExit);
            //Get the User Name
            User user = User.Get(userTypeEnum);
            //Verify the Enrolled User
            Logger.LogAssertion("VerifyUnEnrolledUserName",
                ScenarioContext.Current.ScenarioInfo.Title, () => Assert.AreEqual(
                    SearchUsersResource.SearchUsersPage_UnenrolledText,
                    new ManageStudentsDefaultPage().GetUnenrolledText(user.Name)));
            Logger.LogMethodExit("SearchUsers", "VerifyTheUnEnrolledUserInManageStudentPage",
                base.isTakeScreenShotDuringEntryExit);
        }

    }
}
