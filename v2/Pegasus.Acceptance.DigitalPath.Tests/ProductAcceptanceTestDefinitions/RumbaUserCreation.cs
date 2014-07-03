#region

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

#endregion

namespace Pegasus.Acceptance.DigitalPath.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles the Rumba User Creation actions.
    /// </summary>
    [Binding]
    public class RumbaUserCreation : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(RumbaUserCreation));

        /// <summary>
        /// Create User By Radmin.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        /// <param name="organizationLevelEnum">This is organization level enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        [When(@"I create a ""(.*)"" user as radmin in ""(.*)"" level organization in the ""(.*)""")]
        public void CreateUserByRadmin(User.UserTypeEnum userTypeEnum, 
            Organization.OrganizationLevelEnum organizationLevelEnum, 
            Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Create User As Radmin
            Logger.LogMethodEntry("RumbaUserCreation", "CreateUserByRadmin",
             base.isTakeScreenShotDuringEntryExit);
            //Create a User
            new CreateUserPage().CreateNewUser(userTypeEnum, 
                organizationLevelEnum, organizationTypeEnum);
            Logger.LogMethodExit("RumbaUserCreation", "CreateUserByRadmin",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the User.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [When(@"I search the ""(.*)"" user")]
        public void SearchTheUser(User.UserTypeEnum userTypeEnum)
        {
            //Search the User
            Logger.LogMethodEntry("RumbaUserCreation", "SearchTheUser",
             base.isTakeScreenShotDuringEntryExit);
            //Search the User
            new CreateUserPage().SearchTheUser(userTypeEnum);
            Logger.LogMethodExit("RumbaUserCreation", "SearchTheUser",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the User.
        /// </summary>
        /// <param name="userTypeEnum">This is user Type Enum.</param>
        [Then(@"I should see the created ""(.*)"" user")]
        public void VerifyTheCreatedUser(User.UserTypeEnum userTypeEnum)
        {
            //Verify the User
            Logger.LogMethodEntry("RumbaUserCreation", "VerifyTheCreatedUser",
             base.isTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.RumbaTeacher:
                case User.UserTypeEnum.RumbaNonPSNTeacher:
                    //Verify Teacher Name
                    Logger.LogAssertion("VerifyRumbaTeacherName", ScenarioContext.Current.ScenarioInfo.Title,
                    () => Assert.AreEqual(new CreateUserPage().GetDigitalPathTeacherNameFromMemory(userTypeEnum)
                    , new CreateUserPage().GetUserName()));
                    break;
                case User.UserTypeEnum.RumbaStudent:
                    //Verify Student Name
                    Logger.LogAssertion("VerifyRumbaStudentName", ScenarioContext.Current.ScenarioInfo.Title,
                    () => Assert.AreEqual(new CreateUserPage().GetDigitalPathStudentNameFromMemory()
                    , new CreateUserPage().GetUserName()));
                    break;
            }
            Logger.LogMethodExit("RumbaUserCreation", "VerifyTheCreatedUser",
             base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Verify the Created User In Manage Frame.
        /// </summary>
        /// <param name="userTypeEnum">This is User Type Enum.</param>
        [Then(@"I should see the created ""(.*)"" in manage frame")]
        public void VerifyTheCreatedUserInManageFrame(
            User.UserTypeEnum userTypeEnum)
        {
            //Verify the UserName in Manage Frame.
            Logger.LogMethodEntry("RumbaUserCreation", "VerifyTheCreatedUserInManageFrame",
             base.isTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.RumbaTeacher:
                case User.UserTypeEnum.RumbaNonPSNTeacher:
                    //Verify DP Teacher Name
                    string userNameTeacher = new CreateUserPage().GetDigitalPathTeacherNameFromMemory(userTypeEnum);
                    Logger.LogAssertion("VerifyRumbaTeacherName", ScenarioContext.Current.ScenarioInfo.Title,
                    () => Assert.AreEqual(userNameTeacher
                    , new CreateUserPage().GetUserNameFromManageFrame(userNameTeacher)));
                    break;
                case User.UserTypeEnum.RumbaStudent:
                    //Verify DP Student Name
                    string userNameStudent = new CreateUserPage().GetDigitalPathStudentNameFromMemory();
                    Logger.LogAssertion("VerifyRumbaStudentName", ScenarioContext.Current.ScenarioInfo.Title,
                    () => Assert.AreEqual(userNameStudent
                    , new CreateUserPage().GetUserNameFromManageFrame(userNameStudent)));
                    break;
            }
            Logger.LogMethodExit("RumbaUserCreation", "VerifyTheCreatedUserInManageFrame",
             base.isTakeScreenShotDuringEntryExit);
        }

    }
}
