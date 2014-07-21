using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Integration.MLP.Tests.CommonIntegrationAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Integration.Hed.MLP.Tests.IntegrationAcceptanceTestDefinitions;

namespace Pegasus.Integration.MLP.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handle the all process of verify ECollege GradeBook.
    /// </summary>
    [Binding]
    public class VerifyECollegeGradeBook : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(VerifyECollegeGradeBook));
        //Instance of UnitView Page
        readonly UnitViewPage unitViewPage = new UnitViewPage();

        /// <summary>
        /// Click on GradeBook tab on ECollege Portal.
        /// </summary>
        /// <param name="optionName">This is name of option.</param>
        [When(@"I select ""(.*)"" option on ECollege Portal")]
        public void SelectOptionOnECollegePortal(string optionName)
        {
            //Click on GradeBook tab on ECollege Portal
            Logger.LogMethodEntry("VerifyECollegeGradeBook",
                "SelectOptionOnECollegePortal", base.isTakeScreenShotDuringEntryExit);
            //Instance of UnitView Page
            unitViewPage.ClickOnGradbookOnECollege(optionName);
            Logger.LogMethodExit("VerifyECollegeGradeBook",
               "SelectOptionOnECollegePortal", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Value from Dropdown.
        /// </summary>
        /// <param name="dropDownItemName">This is name of dropdown Value.</param>
        [When(@"I select ""(.*)"" from dropdown")]
        public void SelectItemFromDropdown(String dropDownItemName)
        {
            //Select value from dropdown 
            Logger.LogMethodEntry("VerifyECollegeGradeBook",
               "SelectItemFromDropdown", base.isTakeScreenShotDuringEntryExit);
            //Instance of UnitView Page
            unitViewPage.SelectDropDownValue(dropDownItemName);
            Logger.LogMethodExit("VerifyECollegeGradeBook",
               "SelectItemFromDropdown", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the Activity's grades on ECollege Gradebook .
        /// </summary>
        [Then(@"I should verify the grades from Item Summary")]
        public void VerifyTheGradesFromItemSummary()
        {
            //Verify grade in Item Summary 
            Logger.LogMethodEntry("VerifyECollegeGradeBook",
               "VerifyTheGradesFromItemSummary", base.isTakeScreenShotDuringEntryExit);
            //Assert activity have correct grade
            Logger.LogAssertion("ViewGrades", ScenarioContext.
                Current.ScenarioInfo.Title, () => Assert.AreEqual
                (VerifyECollegeGradeBookResource.VerifyECollegeGradeBook_Activity_Grade,
                unitViewPage.VerifyGrade()));
            Logger.LogMethodExit("VerifyECollegeGradeBook",
               "VerifyTheGradesFromItemSummary", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts 
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }
    }
}
