using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.FeedBack;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;

namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// This Class Handles the User Profile Page actions.
    /// </summary>
    [Binding]
    public class UserProfile : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is logger.
        /// </summary>
        private static Logger Logger = Logger.GetInstance(typeof(UserProfile));

        /// <summary>
        /// Click On My Profile Link Option.
        /// </summary>
        ///<param name="userType">This is User type by enum.</param>
        [When(@"I click on 'My Profile' option in ""(.*)""")]
        public void ClickMyProfileLinkOption(
            User.UserTypeEnum userType)
        {
            //Click On My Profile Link Option
            Logger.LogMethodEntry("UserProfile", "ClickMyProfileLinkOption",
                base.IsTakeScreenShotDuringEntryExit);
            //Click On My Profile Link Option
            new CalendarHEDDefaultUXPage().ClickOnMyProfileLink(userType);
            Logger.LogMethodExit("UserProfile", "ClickMyProfileLinkOption",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify My Profile Options
        /// </summary>
        /// <param name="myProfileOptions">This is MyProfile Options</param>
        [Then(@"I should see the ""(.*)"" in 'My Profile'")]
        public void VerifyMyProfile(string myProfileOptions)
        {
            //verify My Profile Options
            Logger.LogMethodEntry("UserProfile", "VerifyMyProfile",
                base.IsTakeScreenShotDuringEntryExit);
            //Assert Created Question 
            Logger.LogAssertion("VerifyMyProfile", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual(myProfileOptions, 
                    new MyAccountSettingPage().GetMyProfileFrameOptions()));
            Logger.LogMethodExit("UserProfile", "VerifyMyProfile",
               base.IsTakeScreenShotDuringEntryExit);            
        }


        /// <summary>
        /// Click On FeedBack Link Option
        /// </summary>
        [When(@"I click on 'Feedback' option")]
        public void ClickOnFeedBackOption()
        {
            //Click On FeedBack Link Option
            Logger.LogMethodEntry("UserProfile", "ClickOnFeedBackOption",
               base.IsTakeScreenShotDuringEntryExit);
            //Click On FeedBack Link Option
            new TodaysViewUXPage().ClickOnFeedBackLink();
            Logger.LogMethodExit("UserProfile", "ClickOnFeedBackOption",
               base.IsTakeScreenShotDuringEntryExit);      
        }


        /// <summary>
        /// Verify Feedback Option Text
        /// </summary>
        /// <param name="feedBackOptionText">This is FeedBack Options Text</param>
        [Then(@"I should see the ""(.*)"" in the 'Feedback' window")]
        public void VerifyFeedbackText(string feedBackOptionText)
        {
            //Get Feedback Options Text
            Logger.LogMethodEntry("UserProfile", "VerifyFeedbackText",
              base.IsTakeScreenShotDuringEntryExit);
            //Verify Feed Back Text
            Logger.LogAssertion("VerifyFeedbackText", ScenarioContext.Current.ScenarioInfo.Title, () =>
                Assert.AreEqual(feedBackOptionText,new FeedbackPage().GetFeedbackOptionsText()));
            Logger.LogMethodExit("UserProfile", "VerifyFeedbackText",
              base.IsTakeScreenShotDuringEntryExit);    
        }
    }
}
