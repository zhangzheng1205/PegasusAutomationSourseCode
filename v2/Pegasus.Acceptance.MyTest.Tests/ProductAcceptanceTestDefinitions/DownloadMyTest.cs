using TechTalk.SpecFlow;
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Acceptance.MyTest.Tests.ProductAcceptanceTestDefinitions
{
    /// <summary>
    /// Thi class handle all action on My Test download.
    /// </summary>
    [Binding]
    class DownloadMyTest:PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CreateNewTest));

        /// <summary>
        /// Validate the default status of print options on MyTest Download page.
        /// </summary>
        [Then(@"I should see print details are in disabled state by default")]
        public void DisplayOfPrintDetailsOnMyTestDownloadPopup()
        {
            //Logger Entry
            Logger.LogMethodEntry("DownloadMyTest",
                "DisplayOfPrintDetailsOnMyTestDownloadPopup",
                base.isTakeScreenShotDuringEntryExit);
            //Verift the display of print default settign details on download popup
            Logger.LogAssertion("VerifyCoursePresent",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsFalse(new PrintToolPage().
                   IsPrintOptionsPresentOnPrintPage()));
            //Looger Exit
            Logger.LogMethodExit("DownloadMyTest",
               "DisplayOfPrintDetailsOnMyTestDownloadPopup",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the checkbox of Print option on MyTest Download page.
        /// </summary>
        /// <param name="printOptionName">This is name of Print Option.</param>
        [When(@"I select the ""(.*)"" checkbox on My Test Download Page")]
        public void SelectTheCheckboxOnMyTestDownload(string printOptionName)
        {
            //Logger Entry
            Logger.LogMethodEntry("DownloadMyTest",
                "SelectTheCheckboxOnMyTestDownload",
                base.isTakeScreenShotDuringEntryExit);
            //Select checkbox of print option
            new PrintToolPage().SelectCheckboxOfPrintOption(printOptionName);
            //Looger Exit
            Logger.LogMethodExit("DownloadMyTest",
               "SelectTheCheckboxOnMyTestDownload",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the status of expected Radio button option in 
        /// 'Include area for student response' section. 
        /// </summary>
        /// <param name="nameOfRadioButtonOption">This is name of radio button Option.</param>
        [Then(@"I should see ""(.*)"" radio is selected bydefault")]
        public void IsRadiobuttonSelectedBydefault(string nameOfRadioButtonOption)
        {
            //Logger Entry
            Logger.LogMethodEntry("DownloadMyTest",
                "IsRadiobuttonSelectedBydefault",
                base.isTakeScreenShotDuringEntryExit);
            //Verify the status of radio button.
            Logger.LogAssertion("IsRadiobuttonSelectedBydefault",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new PrintToolPage().
                   IsRadioButtonChecked(nameOfRadioButtonOption)));
            //Looger Exit
            Logger.LogMethodExit("DownloadMyTest",
               "IsRadiobuttonSelectedBydefault",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the selected dropdown option in Create Multiple Versions section.
        /// </summary>
        /// <param name="dropDownElementName">This is name of dropdown option</param>
        [Then(@"I should see ""(.*)"" dropdown option is selected bydefault")]
        public void IsDropDownOptionSeletced(string dropDownOptionName)
        {
            //Logger Entry
            Logger.LogMethodEntry("DownloadMyTest",
                "IsDropDownOptionSeletced",
                base.isTakeScreenShotDuringEntryExit);
            //Verify the selected dropdown element in Create Multiple Versions section
            Logger.LogAssertion("VerifyCoursePresent",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(dropDownOptionName, new PrintToolPage()
                   .GetTextOfSelectedDropDownOption()));
            //Logger Exit
            Logger.LogMethodExit("DownloadMyTest",
                "IsDropDownOptionSeletced",base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the status of expected Radio button option in 
        /// 'Include answer Key In' section. 
        /// </summary>
        /// <param name="nameOfRadioButtonOption"></param>
        [Then(@"I should see ""(.*)"" radio button is selected bydefault")]
        public void IsIncludeAnswerKeyRadioOptionSelected(string nameOfRadioButtonOption)
        {
            //Logger Entry
            Logger.LogMethodEntry("DownloadMyTest",
                "IsDropDownOptionSeletced",
                base.isTakeScreenShotDuringEntryExit);
            //Verify the status of expected radio button.
            Logger.LogAssertion("IsIncludeAnswerKeyRadioOptionSelected",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new PrintToolPage().
                   IsFileRadioButtonChecked(nameOfRadioButtonOption)));
            //Logger Exit
            Logger.LogMethodExit("DownloadMyTest",
                "IsDropDownOptionSeletced", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on cancel button on MY test download popup.
        /// </summary>
       [When(@"I click On cancel button on MyTest download popup")]
        public void ClickOnCancelButtonOnMyTestDownloadPopup()
        {
            //Logger Entry
            Logger.LogMethodEntry("DownloadMyTest",
                "ClickOnCancelButtonOnMyTestDownloadPopup",
                base.isTakeScreenShotDuringEntryExit);
            //Click on available button on MY test download popup.
            new PrintToolPage().ClickOnCancelButton();
            //Logger Exit
            Logger.LogMethodExit("DownloadMyTest",
                "ClickOnCancelButtonOnMyTestDownloadPopup",
                base.isTakeScreenShotDuringEntryExit);
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
