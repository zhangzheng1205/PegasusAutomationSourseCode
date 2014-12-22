using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool;
using TechTalk.SpecFlow;
using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Acceptance.MyTest.Tests.
    ProductAcceptanceTestDefinitions
{

    /// <summary>
    /// This class handle the creation of New Test for MYTest.
    /// </summary>
    [Binding]
    class CreateNewTest : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CreateNewTest));

        /// <summary>
        /// Click on Create New Test under Manage Your Tests Frame.
        /// </summary>
        /// <param name="linkName">This is name of Link.</param>
        /// <param name="questionTypeEnum">This is name of question type enum.</param>
        [When(@"I click on the ""(.*)"" link in Manage Your Tests and created Test using ""(.*)"" question")]
        public void CreateMyTestActivityUsingQuestion(
            String linkName, Question.QuestionTypeEnum questionTypeEnum)
        {
            //Logger entry
            Logger.LogMethodEntry("CreateNewTest", "CreateMyTestActivityUsingQuestion",
                 base.IsTakeScreenShotDuringEntryExit);
            //Create New Test
            new MyTestGridUxPage().ClickOnLinkToSelect();
            //Created Page Class Object
            var paperTestUxPage = new PaperTestUxPage();
            //Select Create Question
            paperTestUxPage.SelectCreateQuestion(questionTypeEnum);
            switch (questionTypeEnum)
            {
                case Question.QuestionTypeEnum.TrueFalse:
                    //Create MyTest True and False Question
                    new TrueFalsePage().CreateMyTestQuestion();
                    break;
                case Question.QuestionTypeEnum.Essay:
                    new EssayPage().CreateEssayQuestion();
                    break;
            }
            //Save The MyTest Activity
            paperTestUxPage.SaveTheMyTestActivity();
            //Logger exit
            Logger.LogMethodExit("CreateNewTest", "CreateMyTestActivityUsingQuestion",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the c-menu of MyTest.
        /// </summary>
        /// <param name="cMenuOptionName">This is name of cmenu option.</param>
        [When(@"I select ""(.*)"" c-menu option from the Test drop down")]
        public void ClickCMenuOptionInTheMyTestActivity(
          String cMenuOptionName)
        {
            //Logger entry
            Logger.LogMethodEntry("CreateNewTest", "ClickCMenuOptionInTheMyTestActivity",
                   base.IsTakeScreenShotDuringEntryExit);
            //Click on cmenu option
            new MyTestGridUxPage().ClickMyTestCMenuOption(cMenuOptionName);
            //Logger exit
            Logger.LogMethodExit("CreateNewTest", "ClickCMenuOptionInTheMyTestActivity",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the c-menu of MyTest In CourseSpce.
        /// </summary>
        /// <param name="cMenuOptionName">This is name of cmenu option.</param>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        [When(@"I select ""(.*)"" c-menu option from ""(.*)"" activity")]
        public void WhenISelectC_MenuOptionFromActivity(string cMenuOptionName,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Logger entry
            Logger.LogMethodEntry("CreateNewTest",
                "ClickCMenuOptionInTheMyTestActivityInCourseSpace",
                   base.IsTakeScreenShotDuringEntryExit);
            //Click on cmenu option in CourseSpace
            new MyTestGridUxPage().ClickMyTestCMenuOptionInCourseSpace
                (cMenuOptionName, activityTypeEnum);
            //Logger exit
            Logger.LogMethodExit("CreateNewTest",
                "ClickCMenuOptionInTheMyTestActivityInCourseSpace",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on link in the manage your test frame.
        /// </summary>
        /// <param name="questionTypeEnum">This is a question ype enum.</param>
        [When(@"I click on ""(.*)"" link in the Manage Your Test frame")]
        public void ClickOnLinkInTheManageYourTestFrame(Question.QuestionTypeEnum
            questionTypeEnum)
        {
            //Logger entry
            Logger.LogMethodEntry("CreateNewTest", "ClickOnLinkInTheManageYourTestFrame",
                   base.IsTakeScreenShotDuringEntryExit);
            //Select Create Question
            new PaperTestUxPage().SelectCreateQuestion(questionTypeEnum);
            //Logger exit
            Logger.LogMethodExit("CreateNewTest", "ClickOnLinkInTheManageYourTestFrame",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Multiple Question.
        /// </summary>
        [When(@"I enter the Question Group title, Add the question from the Questions banks and click on Save and close button in Create Question Group pop up")]
        public void SelectMultipleFromQuestionBank()
        {
            //Logger entry
            Logger.LogMethodEntry("CreateNewTest", "SelectMultipleFromQuestionBank",
                   base.IsTakeScreenShotDuringEntryExit);
            //Create question group
            new QuestionSectionUXPage().CreateQuestionGroup();
            //Click on save button
            new QuestionSectionUXPage().ClickOnSaveAndCloseButton();
            //Logger exit
            Logger.LogMethodExit("CreateNewTest", "SelectMultipleFromQuestionBank",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save Button In Action Row of Manage Your Test Frame.
        /// </summary>
        [When(@"I click on Save button in action row of Manage your test frame")]
        public void ClickOnSaveButtonInActionRowOfManageYourTestFrame()
        {
            //Logger entry
            Logger.LogMethodEntry("CreateNewTest",
                "ClickOnSaveButtonInActionRowOfManageYourTestFrame",
                   base.IsTakeScreenShotDuringEntryExit);
            //Save The MyTest Activity
            new PaperTestUxPage().SaveTheMyTestActivity();
            //Logger exit
            Logger.LogMethodExit("CreateNewTest",
                "ClickOnSaveButtonInActionRowOfManageYourTestFrame",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Close button in action row of Manage your test frame.
        /// </summary>
        [When(@"I click on Close button in action row of Manage your test frame")]
        public void ClickOnCloseButtonInActionRowOfManageYourTestFrame()
        {
            //Logger entry
            Logger.LogMethodEntry("CreateNewTest",
                "ClickOnCloseButtonInActionRowOfManageYourTestFrame",
                   base.IsTakeScreenShotDuringEntryExit);
            //Close The MyTest Activity
            new PaperTestUxPage().CloseTheMyTestActivity();
            //Logger exit
            Logger.LogMethodExit("CreateNewTest",
                "ClickOnCloseButtonInActionRowOfManageYourTestFrame",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select question in Filter Test bank.
        /// </summary>
        /// <param name="randomQuestionNumber">This is number of question.</param>
        [When(@"I Select questions in Filter Test bank Frame and enter ""(.*)"" number in the Number of random questions to add field")]
        public void EnterNumberInTheNumberOfRandomQuestionsToAdd(
            int randomQuestionNumber)
        {
            //Logger entry
            Logger.LogMethodEntry("CreateNewTest",
                "EnterNumberInTheNumberOfRandomQuestionsToAdd",
                   base.IsTakeScreenShotDuringEntryExit);
            PaperTestUxPage paperTextpageObject = new PaperTestUxPage();
            //Enter Random number to add question in My test
            paperTextpageObject.EnterRandomNumberToAddQuestion(
                randomQuestionNumber);
            //Validate popup window
            paperTextpageObject.HandlePopupWindowOnMyTest(CreateNewTestResource.
                CreateNewTest_Popup_Pegasus_Window_Name);
            //Click on save button to save My Test on view all tests pane
            paperTextpageObject.SaveTheMyTestActivity();
            //Logger exit
            Logger.LogMethodExit("CreateNewTest",
                "EnterNumberInTheNumberOfRandomQuestionsToAdd",
                   base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add multiple random number question to MyTest.
        /// </summary>
        /// <param name="questionNumber">Question number.</param>
        [When(@"I Enter ""(.*)"" question to add randon question to MyTest")]
        public void AddRandomQuestionToMyTest(int questionNumber)
        {
            //Logger entry
            Logger.LogMethodEntry("CreateNewTest",
                "AddRandomQuestionToMyTest", base.IsTakeScreenShotDuringEntryExit);
            //Add random question to My test
            new PaperTestUxPage().EnterRandomNumberToAddQuestion(
                questionNumber);
            //Logger exit
            Logger.LogMethodExit("CreateNewTest",
                "AddRandomQuestionToMyTest", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Ok Button In Confirmation Popup.
        /// </summary>
        [When(@"I click on 'OK' button in confirmation popup")]
        public void ClickOkButtonInConfirmationPopup()
        {
            //Click On Ok Button in Confirmation Popup 
            Logger.LogMethodEntry("CreateNewTest", "ClickOkButtonInConfirmationPopup",
               base.IsTakeScreenShotDuringEntryExit);
            //Click the OK button
            new MyTestGridUxPage().ClickTheOkButtonInConfirmationPopup();
            Logger.LogMethodExit("CreateNewTest", "ClickOkButtonInConfirmationPopup",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Expand Button In FiltertestBank.
        /// </summary>
        /// <param name="myQuestionFolder">This is myquestion folder.</param>
        [When(@"I click on expand button of ""(.*)"" in filtertest bank")]
        public void ClickOnExpandButtonInFiltertestBank(String myQuestionFolder)
        {
            //Click On Ok Button in Confirmation Popup 
            Logger.LogMethodEntry("CreateNewTest", "ClickOnExpandButtonInFiltertestBank",
               base.IsTakeScreenShotDuringEntryExit);
            // Click On Expand Button In FiltertestBank
            new PaperTestUxPage().ClickOnExpandButtonInFilterTestBank(myQuestionFolder);
            Logger.LogMethodExit("CreateNewTest", "ClickOnExpandButtonInFiltertestBank",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Question To DragAndDrop In MyTest.
        /// </summary>
        /// <param name="questionType">This is question type</param>
        [When(@"I drag and drop of ""(.*)"" question from Filter Test Bank  to Manage Your Test Frame")]
        public void SelectTheQuestionToDragAndDropInMyTest(Question.QuestionTypeEnum questionType)
        {
            //Select The Question To DragAndDrop In MyTest
            Logger.LogMethodEntry("CreateNewTest", "SelectTheQuestionToDragAndDropInMyTest",
               base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Question question = Question.Get(questionType);
            // Select the question to Drag and drop in Mytest
            new PaperTestUxPage().SelectTheQuestionToDragAndDropToMyTest(question.Name);
            Logger.LogMethodExit("CreateNewTest", "SelectTheQuestionToDragAndDropInMyTest",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Pegasus OK Button.
        /// </summary>
        /// <param name="popupWindowName">This is popup window name.</param>
        [When(@"I click on 'OK' button in ""(.*)"" popup")]
        public void ClickOnPegasusOKButton(String popupWindowName)
        {
            //Click On Pegasus OK Button In MyTest
            Logger.LogMethodEntry("CreateNewTest", "ClickOnPegasusOKButton",
               base.IsTakeScreenShotDuringEntryExit);
            //Handle The Validate popup window
            new PaperTestUxPage().HandlePopupWindowOnMyTest(popupWindowName);
            Logger.LogMethodExit("CreateNewTest", "ClickOnPegasusOKButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Confirmation Message In Pegasus Popup.
        /// </summary>
        /// <param name="confirmationMessage">This is confirmation message</param>
        [Then(@"I should see confirmation message ""(.*)""")]
        public void VerifyConfirmationMessageInPegasusPopup(String confirmationMessage)
        {
            //Successfull Message In Pegasus Popup
            Logger.LogMethodEntry("CreateNewTest", "VerifyConfirmationMessageInPegasusPopup",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert Display of Confirmation Message
            Logger.LogAssertion("VerifyConfirmationMessage",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(confirmationMessage,
                    new PaperTestUxPage().GetConfirmationMessageInPegasusPopup()));
            Logger.LogMethodExit("CreateNewTest", "VerifyConfirmationMessageInPegasusPopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The avialability of Question in My Question Folder on Mytest Page.
        /// </summary>
        /// <param name="questionType">This is question typeEnum.</param>
        [Then(@"I should see the ""(.*)"" question in mytest")]
        public void VerifyTheQuestionInMytest(Question.QuestionTypeEnum questionType)
        {
            //Verify The Question In Mytest
            Logger.LogMethodEntry("CreateNewTest", "VerifyTheQuestionInMytest",
               base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Question question = Question.Get(questionType);
            //Asserts the Question Name
            Logger.LogAssertion("VerifyQuestionName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(question.Name,
                    new PaperTestUxPage().
                    GetQuestionNameInMyTest(question.Name)));
            Logger.LogMethodExit("CreateNewTest", "VerifyTheQuestionInMytest",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display Of Header Options In Manage Your Test.
        /// </summary>
        [Then(@"I should see the Display of Test options headers in manage your tests frame")]
        public void VerifyTheDisplayOfHeaderOptionsInManageYourTest()
        {
            //Verify The Display Of Header Options In Manage Your Test
            Logger.LogMethodEntry("CreateNewTest",
                "VerifyTheDisplayOfHeaderOptionsInManageYourTest",
               base.IsTakeScreenShotDuringEntryExit);
            //Assert Display of Header Options In Manage Your Test
            Logger.LogAssertion("VerifyDisplayOptionsInManageYourTest",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(CreateNewTestResource.
                    CreateNewTest_HeaderOptions_Displayed,
                    new MyTestGridUxPage().
                    GetDisplayOfHeaderOptionsInManageYourTest()));
            Logger.LogMethodExit("CreateNewTest",
                "VerifyTheDisplayOfHeaderOptionsInManageYourTest",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Question In Manage Your Test
        /// </summary>
        /// <param name="questionType">This is Question Type</param>
        [Then(@"I should see the ""(.*)"" question in manage your test")]
        public void VerifyTheQuestionInManageYourTest(
            Question.QuestionTypeEnum questionType)
        {
            //Verify The Question In Manage Your Test
            Logger.LogMethodEntry("CreateNewTest", "VerifyTheQuestionInManageYourTest",
              base.IsTakeScreenShotDuringEntryExit);
            //Fetch the data from memory
            Question question = Question.Get(questionType);
            //Asserts the Question Name
            Logger.LogAssertion("VerifyQuestionName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(question.Name,
                    new PaperTestUxPage().
                    getTheQuestionInManageYourTest(question.Name)));
            Logger.LogMethodExit("CreateNewTest", "VerifyTheQuestionInManageYourTest",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Order Of MyTest Folder In Course Material Library.
        /// </summary>
        /// <param name="myTestFolderName">This is MyTest Folder Name.</param>
        /// <param name="myTestFolderCount">This is Folder Count Order.</param>
        [Then(@"I should see the ""(.*)"" and displayed ""(.*)"" order in add course materials library")]
        public void VerifyTheMyTestFolderInCourseMaterialsLibrary(
            string myTestFolderName, int myTestFolderCount)
        {
            //Verify The Order Of MyTest Folder
            Logger.LogMethodEntry("CreateNewTest",
               "VerifyTheMyTestFolderInCourseMaterialsLibrary",
              base.IsTakeScreenShotDuringEntryExit);
            //Asserts the Folder Name
            Logger.LogAssertion("VerifyFolderName",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(myTestFolderName,
                    new ContentLibraryUXPage().
                    GetMyTestFolderNameInContentLibrary(myTestFolderName)));
            //Asserts the Folder Position
            Logger.LogAssertion("VerifyFolderCount",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(myTestFolderCount,
                    Convert.ToInt16(new ContentLibraryUXPage().
                    GetMyTestFolderpositionInContentLibrary(myTestFolderName))));
            Logger.LogMethodExit("CreateNewTest",
                "VerifyTheMyTestFolderInCourseMaterialsLibrary",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Upgrade To link inside course. 
        /// </summary>
        [When(@"I click on Upgrade to Link inside course")]
        public void ClickOnUpgradeToLinkInsideCourse()
        {
            //Logger Entry
            Logger.LogMethodExit("CreateNewTest",
                "ClickOnUpgradeToLinkInsideCourse",
               base.IsTakeScreenShotDuringEntryExit);
            //Instance of MyTestUXPage.
            new MyTestUxPage().ClickOnUpgradeToTextInsideCourse();
            //Logger Exit
            Logger.LogMethodExit("CreateNewTest",
               "ClickOnUpgradeToLinkInsideCourse",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on View All test button inside test folder.
        /// </summary>
        [When(@"I click on 'View all tests' button inside test")]
        public void ClickOnButtonInsideTest()
        {
            //Logger Entry
            Logger.LogMethodEntry("CreateNewTest",
                "ClickOnButtonInSideTest",
                  base.IsTakeScreenShotDuringEntryExit);
            //Click on View All tests button 
            new PaperTestUxPage().ClickOnViewAllTestButtonInsideTest();
            //Logger Exit
            Logger.LogMethodExit("CreateNewTest",
                "ClickOnButtonInSideTest",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate that user should navigate bakc to 'Manage Your Tests' Frame.
        /// </summary>
        [Then(@"I should navigate back to ""(.*)"" Frame")]
        public void VerifyTheDisplayOfManageYourTestFrame(String elementText)
        {
            //Logger Entry
            Logger.LogMethodEntry("CreateNewTest",
                "ClickOnButtonInSideTest",
                  base.IsTakeScreenShotDuringEntryExit);
            //Validate the display of View All Tests button 
            Logger.LogAssertion("VerifyManageTestYourButton",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.AreEqual(elementText, new MyTestGridUxPage().
                    DisplayOfManageYourTestFrame()));
            //Logger Exit
            Logger.LogMethodExit("CreateNewTest",
                "ClickOnButtonInSideTest",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on button available inside Mytest activity page.
        /// </summary>
        /// <param name="buttonName">Name of button.</param>
        [Then(@"I should see the ""(.*)"" button")]
        public void IsButtonDisplaying(String buttonName)
        {
            //Logger Entry
            Logger.LogMethodEntry("CreateNewTest",
                "IsButtonDisplaying",
                  base.IsTakeScreenShotDuringEntryExit);
            //Validate the display of button inside MyTest activity 
            Logger.LogAssertion("VerifyManageTestYourButton",
                ScenarioContext.Current.ScenarioInfo.Title,
                () => Assert.IsTrue(new PaperTestUxPage().
                    IsButtonDisplayingInsideMyTestActivity(buttonName)));
            //Logger Exit
            Logger.LogMethodExit("CreateNewTest",
                "IsButtonDisplaying",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Download Options.
        /// </summary>
        [When(@"I click on the 'Download' options")]
        public void ClickOnDownloadOptions()
        {
            //Click On Download Options
            Logger.LogMethodEntry("CreateNewTest",
                "ClickOnDownloadOptions",
                  base.IsTakeScreenShotDuringEntryExit);
            //Click The Download Option In ManageYourTest
            new PaperTestUxPage().ClickTheDownloadOptionInManageYourTest();
            Logger.LogMethodExit("CreateNewTest",
                "ClickOnDownloadOptions",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Image CMenu Option From Test DropDown.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        [When(@"I click on c-menu option of ""(.*)"" activity")]
        public void WhenIClickOnC_MenuOptionOfActivity(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Click On Image CMenu Option From Test DropDown
            Logger.LogMethodEntry("CreateNewTest",
                "ClickOnImageCMenuOptionFromTestDropDown",
                base.IsTakeScreenShotDuringEntryExit);
            //Click The Image Cmenu Option From Test DropDown
            new MyTestGridUxPage().ClickTheImageCmenuOptionFromTestDropDown
                (activityTypeEnum);
            Logger.LogMethodExit("CreateNewTest",
                "ClickOnImageCMenuOptionFromTestDropDown",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display Of Download CmenuOptions For Test.
        /// </summary>
        /// <param name="table">This is Table Reference.</param>
        [Then(@"I should able to see Display of Download cmenu options for test")]
        public void VerifyTheDisplayOfDownloadCmenuOptionsForTest(Table table)
        {
            //Verify The Display Of Download CmenuOptions For Test
            Logger.LogMethodEntry("CreateNewTest",
                 "VerifyTheDisplayOfDownloadCmenuOptionsForTest",
                 base.IsTakeScreenShotDuringEntryExit);
            foreach (TableRow tableRow in table.Rows)
            {
                //Assert correct pages are opened
                TableRow row = tableRow;
                Logger.LogAssertion("VerifyCmenuOptions", ScenarioContext.
                    Current.ScenarioInfo.Title,
                () => Assert.AreEqual(row[CreateNewTestResource.
                    CreateNewTest_Expected_Cmenu_Options_Displayed],
                    new MyTestGridUxPage().
                    GetDisplayedCmenuOptionsForDownload(row[CreateNewTestResource.
                    CreateNewTest_Actual_Cmenu_Options_Displayed])));
            }
            Logger.LogMethodExit("CreateNewTest",
                "VerifyTheDisplayOfDownloadCmenuOptionsForTest",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Display Of CmenuOptions For Created Test.
        /// </summary>
        /// <param name="table">This is Table Reference.</param>
        [Then(@"I should able to see Display of cmenu options for test created")]
        public void VerifyTheDisplayOfCmenuOptionsForCreatedTest(Table table)
        {
            //Verify The Display Of CmenuOptions For Created Test
            Logger.LogMethodEntry("CreateNewTest",
                 "VerifyTheDisplayOfCmenuOptionsForCreatedTest",
                 base.IsTakeScreenShotDuringEntryExit);
            foreach (TableRow tableRow in table.Rows)
            {
                //Assert correct pages are opened
                TableRow row = tableRow;
                Logger.LogAssertion("VerifyCmenuOptions", ScenarioContext.
                    Current.ScenarioInfo.Title,
                () => Assert.AreEqual(row[CreateNewTestResource.
                    CreateNewTest_Expected_Cmenu_Options_Displayed],
                    new MyTestGridUxPage().
                    GetDisplayOfCmenuOptionForCreatedTest(row[CreateNewTestResource.
                    CreateNewTest_Actual_Cmenu_Options_Displayed])));
            }
            //Logger Exit
            Logger.LogMethodExit("CreateNewTest",
                "VerifyTheDisplayOfCmenuOptionsForCreatedTest",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Validate the validation message when user add random 500 question to Mytest.
        /// </summary>
        /// <param name="validationMessageText">This is Text of message.</param>
        [Then(@"I should see validation message ""(.*)""")]
        public void ValidateMyTestValidationMessage(String validationMessageText)
        {
            //Logger Entry 
            Logger.LogMethodEntry("CreateNewTest",
                "ValidateMyTestValidationMessage",
                  base.IsTakeScreenShotDuringEntryExit);
            //Validate Message 
            Logger.LogAssertion("ValidateMyTestValidationMessage", ScenarioContext.
                    Current.ScenarioInfo.Title,
                () => Assert.AreEqual(validationMessageText, new
                    ShowMessagePage().
                    GetTheValidationMessageOfAddingRandonQuestionToMyTest()));
            //logger Exit
            Logger.LogMethodExit("CreateNewTest",
                "ValidateMyTestValidationMessage",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Multiple Version of MyTest.
        /// </summary>
        /// <param name="versionNumber">This is version number.</param>
        [When(@"I enter ""(.*)"" in the Create Multiple Versions text box and click on the ok button in Print pop up")]
        public void CreateMultipleVersions(int versionNumber)
        {
            //Logger Entry 
            Logger.LogMethodEntry("CreateNewTest",
                "CreateMultipleVersions",
                  base.IsTakeScreenShotDuringEntryExit);
            //Create Page Class Object
            PrintToolPage printToolPage = new PrintToolPage();
            //Create Multiple Version
            printToolPage.CreateMultipleVersionsTest(versionNumber);
            //Click on Download button
            printToolPage.ClickOnDownloadButton();
            //Logger Exit 
            Logger.LogMethodExit("CreateNewTest",
                "CreateMultipleVersions",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Versions Entered In The Print PopUp.
        /// </summary>
        /// <param name="expectedVersionNumber">This is expected version number.</param>
        [Then(@"I should see ""(.*)"" versions entered in the Print pop up should be displayed in the Multiple version pop up")]
        public void VerifyVersionsEnteredInThePrintPopUp(int expectedVersionNumber)
        {
            //Logger Entry 
            Logger.LogMethodEntry("CreateNewTest",
                "VerifyVersionsEnteredInThePrintPopUp",
                  base.IsTakeScreenShotDuringEntryExit);
            //Validate Message 
            Logger.LogAssertion("ValidateMyTestValidationMessage", ScenarioContext.
                Current.ScenarioInfo.Title,
                () => Assert.AreEqual(expectedVersionNumber, new
                    PrintPopupPage().GetNumberOfVersions()));
            //Logger Exit
            Logger.LogMethodExit("CreateNewTest",
                "VerifyVersionsEnteredInThePrintPopUp",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify The Links You Want To Download Should Be Displayed With Name.
        /// </summary>
        /// <param name="activityTypeEnum">This is activty type enum.</param>
        [Then(@"I should see Select the links you want to download: should be displayed with ""(.*)"" name")]
        public void VerifyTheLinksYouWantToDownloadShouldBeDisplayedWithName(
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Logger Entry 
            Logger.LogMethodEntry("CreateNewTest",
                "VerifyVersionsEnteredInThePrintPopUp",
                  base.IsTakeScreenShotDuringEntryExit);
            Activity activity = Activity.Get(activityTypeEnum);
            //Validate Message 
            Logger.LogAssertion("ValidateMyTestValidationMessage", ScenarioContext.
                Current.ScenarioInfo.Title,
            () => Assert.IsTrue((activity.Name).Contains(new PrintPopupPage().
                GetDownloadVersionName())));
            //Close The Download LightBox
            new PrintToolPage().ClickOnCancelButton();
            //Logger Exit
            Logger.LogMethodExit("CreateNewTest",
                "VerifyVersionsEnteredInThePrintPopUp",
                  base.IsTakeScreenShotDuringEntryExit);
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
