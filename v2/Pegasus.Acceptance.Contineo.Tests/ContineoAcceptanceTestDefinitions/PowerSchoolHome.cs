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
    public class PowerSchoolHome : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PowerSchoolHome));

        /// <summary>
        /// Click on Pearson Courses link
        /// </summary>
        [When(@"I click on the Pearson Courses link")]
        public void ClickOnPearsonCourses()
        {
            Logger.LogMethodEntry("PowerSchoolHome", "ClickOnPearsonCourses",
                IsTakeScreenShotDuringEntryExit);
            new PowerSchoolHomePage().ClickPearsonCourses();
            Logger.LogMethodExit("PowerSchoolHome", "ClickOnPearsonCourses",
                IsTakeScreenShotDuringEntryExit);
        }
    }
}
