#region

using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handles Edit User actions.
    /// </summary>
    [Binding]
    public class EditUser : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = 
            Logger.GetInstance(typeof(EditUser));

        /// <summary>
        /// Login as Workspace Teacher.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="passwordTypeEnum"></param>
        [When(@"I login to Pegasus as ""(.*)"" with ""(.*)"" password")]
        public void LoginToPegasusAsWorkspaceTeacher(
            User.UserTypeEnum userTypeEnum,
            string passwordTypeEnum)
        {
            //Login as Workspace Teacher
            Logger.LogMethodEntry("LoginLogout", "LoginToPegasusAsWorkspaceTeacher",
               base.isTakeScreenShotDuringEntryExit);
            //Get the User From Memory
            User user = User.Get(userTypeEnum);
            //Login as Workspace Teacher
            new BrowsePegasusUserURL(userTypeEnum).
                LoginAsWorkspaceTeacher((BrowsePegasusUserURL.PasswordTypeEnum)Enum.
                Parse(typeof(BrowsePegasusUserURL.PasswordTypeEnum), passwordTypeEnum), user.Name);
            Logger.LogMethodExit("LoginLogout", "LoginToPegasusAsWorkspaceTeacher",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit the User Details.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I edit the details of ""(.*)""")]
        public void EditTheDetailsOfUser(
            User.UserTypeEnum userTypeEnum)
        {
            //Edit the Details of User
            Logger.LogMethodEntry("CreateUser", "EditTheDetailsOfUser",
            base.isTakeScreenShotDuringEntryExit);
            //Edit the Details of User
            new NewUserPage().EditWorkSpaceUserDetails();
            Logger.LogMethodExit("CreateUser", "EditTheDetailsOfUser",
            base.isTakeScreenShotDuringEntryExit);
        }
    }
}
