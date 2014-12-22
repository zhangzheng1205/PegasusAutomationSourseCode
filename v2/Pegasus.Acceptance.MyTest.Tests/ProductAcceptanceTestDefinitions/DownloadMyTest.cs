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
    class DownloadMyTest : PegasusBaseTestFixture
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
                base.IsTakeScreenShotDuringEntryExit);
            //Verift the display of print default settign details on download popup
            Logger.LogAssertion("VerifyCoursePresent",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsFalse(new PrintToolPage().
                   IsPrintOptionsPresentOnPrintPage()));
            //Looger Exit
            Logger.LogMethodExit("DownloadMyTest",
               "DisplayOfPrintDetailsOnMyTestDownloadPopup",
               base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Select checkbox of print option
            new PrintToolPage().SelectCheckboxOfPrintOption(printOptionName);
            //Looger Exit
            Logger.LogMethodExit("DownloadMyTest",
               "SelectTheCheckboxOnMyTestDownload",
               base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Verify the status of radio button.
            Logger.LogAssertion("IsRadiobuttonSelectedBydefault",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new PrintToolPage().
                   IsRadioButtonChecked(nameOfRadioButtonOption)));
            //Looger Exit
            Logger.LogMethodExit("DownloadMyTest",
               "IsRadiobuttonSelectedBydefault",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the selected dropdown option in Create Multiple Versions section.
        /// </summary>
        /// <param name="dropDownOptionName">This is name of dropdown option</param>
        [Then(@"I should see ""(.*)"" dropdown option is selected bydefault")]
        public void IsDropDownOptionSeletced(string dropDownOptionName)
        {
            //Logger Entry
            Logger.LogMethodEntry("DownloadMyTest",
                "IsDropDownOptionSeletced",
                base.IsTakeScreenShotDuringEntryExit);
            //Verify the selected dropdown element in Create Multiple Versions section
            Logger.LogAssertion("VerifyCoursePresent",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(dropDownOptionName, new PrintToolPage()
                   .GetTextOfSelectedDropDownOption()));
            //Logger Exit
            Logger.LogMethodExit("DownloadMyTest",
                "IsDropDownOptionSeletced", base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            //Verify the status of expected radio button.
            Logger.LogAssertion("IsIncludeAnswerKeyRadioOptionSelected",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.IsTrue(new PrintToolPage().
                   IsFileRadioButtonChecked(nameOfRadioButtonOption)));
            //Logger Exit
            Logger.LogMethodExit("DownloadMyTest",
                "IsDropDownOptionSeletced", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on cancel button on MY test download popup.
        /// </summary>
        [When(@"I click on cancel button on MyTest download popup")]
        public void ClickOnCancelButtonOnMyTestDownloadPopup()
        {
            //Logger Entry
            Logger.LogMethodEntry("DownloadMyTest",
                "ClickOnCancelButtonOnMyTestDownloadPopup",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on available button on MY test download popup.
            new PrintToolPage().ClickOnCancelButton();
            //Logger Exit
            Logger.LogMethodExit("DownloadMyTest",
                "ClickOnCancelButtonOnMyTestDownloadPopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Download Button On MyTest Download Popup.
        /// </summary>
        [When(@"I click on download button on MyTest download popup")]
        public void ClickOnDownloadButtonOnMyTestDownloadPopup()
        {
            // logger entry
            Logger.LogMethodEntry("DownloadMyTest",
                "ClickOnDownloadButtonOnMyTestDownloadPopup",
                base.IsTakeScreenShotDuringEntryExit);
            new MyTestUxPage().ClickToDownloadButton();
            // logger exit
            Logger.LogMethodExit("DownloadMyTest",
                "ClickOnDownloadButtonOnMyTestDownloadPopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Print Download Button In Download Popup.
        /// </summary>
        [When(@"I click on print download button in download popup")]
        public void ClickOnPrintDownloadButtonInDownloadPopup()
        {
            // logger exit
            Logger.LogMethodEntry("DownloadMyTest",
                "ClickOnPrintDownloadButtonInDownloadPopup",
                base.IsTakeScreenShotDuringEntryExit);
            new MyTestUxPage().ClickToDownloadAllZipButton();
            // logger exit
            Logger.LogMethodExit("DownloadMyTest",
                "ClickOnPrintDownloadButtonInDownloadPopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify File Extention In The Dowloaded Folder.
        /// </summary>
        /// <param name="downloadedFileExtention">This is expected file extention.</param>
        [Then(@"I should see ""(.*)"" file in the dowloaded folder")]
        public void VerifyFileInTheDowloadedFolder(string downloadedFileExtention)
        {
            // logger entry
            Logger.LogMethodEntry("DownloadMyTest","VerifyFileInTheDowloadedFolder",
                base.IsTakeScreenShotDuringEntryExit);
            String[] downloadedFilesExtentionInFolder = new MyTestUxPage().GetFileExtentionsFromDownloadedFolder();
            foreach (var downloadedFileExtentionInFolder in downloadedFilesExtentionInFolder)
            {
                //Verify the extention of downloded files
                string currentFileExtention = downloadedFileExtentionInFolder;
                Logger.LogAssertion("VerifyFileInTheDowloadedFolder",
               ScenarioContext.Current.ScenarioInfo.Title,
               () => Assert.AreEqual(downloadedFileExtention, currentFileExtention));
            }
            // logger exit
            Logger.LogMethodExit("DownloadMyTest","VerifyFileInTheDowloadedFolder", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Question Order Option In DropDown For Test Download.
        /// </summary>
        /// <param name="dropdownTextForQuestionOrder">This is question order dropdown value.</param>
        [When(@"I select the ""(.*)"" option in drop down")]
        public void SelectTheOptionInDropDownForTestDownload(string dropdownTextForQuestionOrder)
        {
            // logger entry
            Logger.LogMethodEntry("DownloadMyTest", "SelectTheOptionInDropDownForTestDownload",
                base.IsTakeScreenShotDuringEntryExit);
            new MyTestUxPage().SelectQuestionOrderForDownloadTest(dropdownTextForQuestionOrder);
            // logger exit
            Logger.LogMethodExit("DownloadMyTest", "SelectTheOptionInDropDownForTestDownload",
                base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
