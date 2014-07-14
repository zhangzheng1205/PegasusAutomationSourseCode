using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.HigherEducation.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.HigherEducationCore.Tests.
    ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the details Promoted admin use case in Coursespace-administrator tab
    /// Responsible to handle Promoted admin use cases like search user and read cmenu
    /// </summary>
    [Binding]
    public class PromotedAdminUsers : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(PromotedAdminUsers));


        /// <summary>
        /// click on cmenu of user
        /// </summary>
        [When(@"I click on the cmenu option of ""(.*)""")]
        public void ClickCmenuOfPromotedAdmin(
            User.UserTypeEnum userTypeEnum)
        {
            //Checks the display option in Cmenu in coursespace administrator tab right frame
            Logger.LogMethodEntry("PromotedAdminUsers", "ClickCmenuOfPromotedAdmin",
                base.isTakeScreenShotDuringEntryExit);
            //Get User Name from Memory
            User user = User.Get(userTypeEnum);
            // Calling instance of Admin Enrollment Class
            AdminEnrollment adminEnrollment = new AdminEnrollment();
            adminEnrollment.FindPromotedAdminInFrame();
            // Click Cmenu image
            adminEnrollment.ClickCmenuImage(user.LastName);
            Logger.LogMethodExit("PromotedAdminUsers", "ClickCmenuOfPromotedAdmin",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// varify the cmenu value
        /// </summary>
        [Then(@"I should see the ""(.*)"" cmenu")]
        public void ViewCmenu(string cmenuvalue)
        {
            //Verify Cmenu name in coursespace administrator tab right frame          
            Logger.LogMethodEntry("PromotedAdminUsers",
                "ViewCmenu",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string ContextMenuNames = string.Empty;
            // Calling instance of Admin Enrollment Class
            AdminEnrollment adminEnrollment = new AdminEnrollment();
            ContextMenuNames = adminEnrollment.GetCMenuOptionsOfAdmin();
            if (ContextMenuNames.Contains(cmenuvalue)){
                ContextMenuNames = cmenuvalue;
            }
            Logger.LogAssertion("PromotedAdminUsers", ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(cmenuvalue, ContextMenuNames));  
            Logger.LogMethodExit("PromotedAdminUsers",
                "ViewCmenu",
                base.isTakeScreenShotDuringEntryExit);
        }

    }
}
