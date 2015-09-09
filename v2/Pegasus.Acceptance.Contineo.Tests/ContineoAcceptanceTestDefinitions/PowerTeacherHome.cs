#region

using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Integration.Contineo;
using Pegasus.Pages.UI_Pages;

#endregion

namespace Pegasus.Acceptance.Contineo.
    Tests.ContineoAcceptanceTestDefinitions
{
    /// <summary>
    /// This class contains the common feature steps
    /// that can be reuse while verifying
    /// the scenarios.
    /// </summary>
    [Binding]
    public class PowerTeacherHome : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PowerTeacherHome));
        
        /// <summary>
        /// Click on the Applications Icon as Power School Teacher
        /// </summary>
        /// <param name="userTypeEnum">This is the user role by user type</param>
        [When(@"I click on Applications icon as ""(.*)""")]
        public void ClickOnApplicationsIcon(User.UserTypeEnum userTypeEnum)
        {
            //Click on the Applications Icon as Power School Teacher
            Logger.LogMethodEntry("PowerTeacherHome", "ClickOnApplicationsIcon",
                IsTakeScreenShotDuringEntryExit);
            //Click on the link
            new PowerTeacherHomePage().ClickApplicationsIcon(userTypeEnum);
            Logger.LogMethodExit("PoswerTeacherHome", "ClickOnApplicationsIcon",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Pearson Courses link is present
        /// </summary>
        [Then(@"I should see the Pearson Courses link displayed in the Applications Drawer Panel")]
        public void VerifyPearsonCoursesLink()
        {
            //Verify Pearson Courses link is present
            Logger.LogMethodEntry("PowerTeacherHome", "VerifyPearsonCoursesLink",
                IsTakeScreenShotDuringEntryExit);
            //Verify the link
            Logger.LogAssertion("VerifyPearsonCoursesLink",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new PowerTeacherHomePage().IsPearsonCoursesLinkPresent()));
            //new PowerTeacherHomePage().IsPearsonCoursesLinkPresent();
            Logger.LogMethodExit("PowerTeacherHome", "VerifyPearsonCoursesLink",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Pearson Courses link
        /// </summary>
        [When(@"I click on Pearson Courses link")]
        public void ClickOnPearsonCourses()
        {
            Logger.LogMethodEntry("PowerTeacherHome", "ClickOnPearsonCourses",
                IsTakeScreenShotDuringEntryExit);
            new PowerTeacherHomePage().ClickPearsonCourses();
            Logger.LogMethodExit("PowerTeacherHome", "ClickOnPearsonCourses",
                IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Sign Out as Contineo Teacher from Power School
        /// </summary>
        /// <param name="userTypeEnum">This is user type based on user role</param>
        [When(@"I 'Sign Out' from Power School as ""(.*)""")]
        public void SignOutAsContineoTeacher(User.UserTypeEnum userTypeEnum)
        {
            //Sign Out as Contineo Teacher from Power School
            Logger.LogMethodEntry("PowerTeacherHome", "SignOutAsContineoTeacher",
               IsTakeScreenShotDuringEntryExit);
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.ContineoTeacher:
                    //Close the Application Drawer Panel
                    new PowerTeacherHomePage().CloseApplicationsDrawerPanel();
                    //Sign Out from Power School.
                    new PowerTeacherHomePage().SignOutfromPowerSchool(userTypeEnum);
                    break;
                case User.UserTypeEnum.ContineoStudent:
                    //Sign Out from Power School.
                    new PowerTeacherHomePage().SignOutfromPowerSchool(userTypeEnum);
                    break;
            }
            
            Logger.LogMethodExit("PowerTeacherHome", "SignOutAsContineoTeacher",
                IsTakeScreenShotDuringEntryExit);
        }

    }
}
