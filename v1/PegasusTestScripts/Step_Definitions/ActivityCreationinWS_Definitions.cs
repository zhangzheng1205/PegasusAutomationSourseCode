using System;
using System.Linq;
using System.Threading;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Activity;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool;
using Pegasus_DataAccess;
using Framework.Common;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.SkillStandardIntegration;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TeachingPlan;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Coursesettings;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.DRT;

namespace PegasusTestScripts.Step_Definitions
{
    [Binding]
    public class ActivityCreationinWsDefinitions : BaseTestScript
    {
        // Calling of other classes
        private readonly MyPegasusUxPage _objUxPage = new MyPegasusUxPage();
        private readonly ContentLibraryUxPage _objContent = new ContentLibraryUxPage();
        private readonly MultipleChoicePage _objMultiple = new MultipleChoicePage();
        private Pegasus.LoginPage.LoginPage _loginPage = new Pegasus.LoginPage.LoginPage();
        private readonly FillInTheBlanksPage _objFillinTheBlank = new FillInTheBlanksPage();
        private readonly RandomAssessmentPage _assessmentPage = new RandomAssessmentPage();
        private readonly AlignContentsToSkillPage _alignContentsToSkillPage = new AlignContentsToSkillPage();
        private readonly TeachingplanUXPage _contentPage = new TeachingplanUXPage();
        private readonly StandardSkillPreferencesPage _skillPreferencesPage = new StandardSkillPreferencesPage();
        private readonly SpreadSheetImportPage _toImportFile = new SpreadSheetImportPage();
        private readonly ContentBrowserUXPage _toimportThroughRepo = new ContentBrowserUXPage();
        private readonly QLGridUXPage _toSelectSearchView = new QLGridUXPage();
        private readonly GeneralPreferencesPage _generalPreferencesPage = new GeneralPreferencesPage();
        private readonly DRTDefaultUXPage _drtDefaultUxPage = new DRTDefaultUXPage();

        [When(@"I select the created 'Master Library Course'")]
        public void WhenISelectTheCreatedMasterLibraryCourse()
        {
            ScenarioContext.Current.Pending();
        }

        // Step 2 - When I select the course name 
        [When(@"I select the course name with prefix (.*)")]
        public void SelectTheCourseNameWithPrefix(String coursename)
        {
            try
            {
                GenericHelper.SelectWindow("Global Home");
                _objUxPage.ToSelectMasterLibrary(coursename);

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }

        }

        // Step 6 - I Click on the "Add Content" button
        [When(@"I click on the 'Add Content' button")]
        [Then(@"I click on the 'Add Content' button")]
        public void ThenIClickAddContentButton()
        {
            try
            {

                _objContent.ToSelectAddContent();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        // Step 7 - I select the 'Multiple Choice' question option
        [When(@"I select the 'Multiple Choice' question option")]
        public void WhenISelectTheMultipleChoiceQuestion()
        {
            try
            {
                _objContent.MultipleChoiceQuestion();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        // Step 8 - I create the 'Multiple Choice' question
        [When(@"I create the 'Multiple Choice' question")]
        public void CreateTheMultipleChoiceQuestion()
        {
            try
            {

                GenericHelper.SelectWindow("Create Multiple Choice");
                _objMultiple.ToFillTheDetailsForMultiple();
                GenericHelper.SelectWindow("Question Library");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        // Step  - I select the 'Fill in the Blank' question option
        [When(@"I select the 'Fill in the Blank' question option")]
        public void WhenISelectTheFillInTheBlankQuestion()
        {
            try
            {
                _objContent.FillIntheBlank();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }


        // Step - I create the 'Fill in the Blank' question
        [When(@"I create the 'Fill in the Blank' question")]
        public void CreateTheFillInTheBlank()
        {
            try
            {
                _objFillinTheBlank.ToCreateFillInTheBlanks();
            }
            catch (Exception e)
            {
                {
                    GenericHelper.Logs(e.ToString(), "FAILED");
                    throw e;
                }
            }
        }

        //Purpose: to select Standards and Skills tab in preferences
        [When(@"I selected the 'Standards and Skills' sub tab")]
        public void WhenISelectedTheStandardsAndSkillsSubTab()
        {
            try
            {
                _generalPreferencesPage.SelectSkillsAndStandards();

            }
            catch (Exception e)
            {
                {
                    GenericHelper.Logs(e.ToString(), "FAILED");
                    throw e;
                }
            }
        }

        //Purpose: to add new skill framework
        [When(@"I Add new frameworks")]
        public void WhenIAddNewFrameworks()
        {
            try
            {
                _skillPreferencesPage.AddNewSkillFrameWork();
            }
            catch (Exception e)
            {
                {
                    GenericHelper.Logs(e.ToString(), "FAILED");
                    throw e;
                }

            }
        }

        //Purpose: to save the preferences
        [Then(@"I saved the preferences")]
        public void ThenISavedThePreferences()
        {
            try
            {
                _skillPreferencesPage.SavePreferences();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        //Purpose: to click on 'More' dropdown link
        [When(@"I selected the 'More' dropdown link")]
        public void WhenISelectedTheMoreDropdownLink()
        {
            try
            {
                _contentPage.ClickMoreNavigation();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        //Purpose: to map questions to the skill
        [When(@"Map the questions to the skill")]
        public void WhenMapTheQuestionsToTheSkill()
        {
            try
            {
                // Purpose: Open Skill(s)
                _alignContentsToSkillPage.OpenTheSkillInRightFrame();
                _alignContentsToSkillPage.SelectLeftFrame();


                // Purpose: Select Questions To Map in Skill
                _alignContentsToSkillPage.SelectQuestionInLeftFrame(DatabaseTools.GetQuestionName(Enumerations.QuestionType.FillInTheBlank));
                _alignContentsToSkillPage.SelectQuestionInLeftFrame(DatabaseTools.GetQuestionName(Enumerations.QuestionType.MultipleChoice));
                _alignContentsToSkillPage.SelectQuestionInLeftFrame(DatabaseTools.GetQuestionName(Enumerations.QuestionType.SCO));
                WebDriver.SwitchTo().Window("");

                //  Purpose:  Add Selected Questions to Skill
                _alignContentsToSkillPage.ClickAddButton();
                GenericHelper.VerifySuccesfullMessage("Content item is added to Skill");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        //Purpose: to select 'Skill Study Plan' option in content tab
        [When(@"I select 'Skill Study Plan' activity type")]
        public void WhenISelectSkillStudyPlanActivityType()
        {
            try
            {
                _contentPage.ClickAddContentButton();
                _contentPage.SelectAddSkillStudyPlan();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        //Purpose: To create Skill Study Plan
        [When(@"I create 'Skill Study Plan - Pre test / Post test")]
        public void WhenICreateSkillStudyPlanPreTestPostTest()
        {
            try
            {
                string sppName = GenericHelper.GenerateUniqueVariable("SSP");
                _drtDefaultUxPage.EnterSSPName(sppName);

                //Purpose: PreTest Creation
                _drtDefaultUxPage.ClickCreateTestForPretest();

                _assessmentPage.CreatePreTestSsp(GenericHelper.GenerateUniqueVariable("BDD_pretest"));

                //-------Purpose: PostTest Creation : We are not adding Post Test usecase as it is not necessary--------//
                //GenericHelper.WaitUntilElement(By.ClassName("DRT_addSmal1"));
                //WebDriver.FindElement(By.ClassName("DRT_addSmal1")).Click();
                //WebDriver.FindElement(By.ClassName("DRT_addSmal1")).SendKeys(" ");
                //Thread.Sleep(3000);
                //_assessmentPage.CreatePostTestSsp(GenericHelper.GenerateUniqueVariable("BDD_posttest"));
                //-------Purpose: PostTest Creation : We are not adding Post Test usecase as it is not necessary--------//

                //Purpose: Saving SSP
                _drtDefaultUxPage.SaveSSP();
                DatabaseTools.UpdateActivity(Enumerations.ActivityType.SkillStudyPlan, sppName);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        // To select Import SCO meta data button
        [When(@"I select the 'Import SCO Metadata' option")]
        public void WhenISelectTheImportScoMetaData()
        {
            try
            {
                _objContent.SelectBrowseRepository();
                GenericHelper.Logs("User has successfully clicked on the Import SCO Metadata option", "Passed");


            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        [When(@"I select the 'Browse Repository' option")]
        public void SelectBrowseRepository()
        {
            try
            {
                _objContent.SelectBrowseRepository();
                GenericHelper.Logs("User has successfully selected browse repository option", "Passed");


            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }
        [When(@"I import the 'SCO' question through browse repository")]
        public void ImportThroughBrowseRepository()
        {
            try
            {

                _toimportThroughRepo.ImportThroughBrowseRepository();
                GenericHelper.Logs("User has successfully uploaded the SCO Metadata", "Passed");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        // Import SCO metadata 
        [When(@"I import the 'SCO' question")]
        public void WhenIImportScoQuestion()
        {
            try
            {

                _toImportFile.ImportScoMetaData();
                GenericHelper.Logs("User has successfully uploaded the SCO Metadata", "Passed");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        //Purpose: to check select all check box for activity selection
        [When(@"I select the all created activity")]
        public void WhenISelectTheAllCreatedActivity()
        {
            try
            {
                _contentPage.CheckSelectAllCheckbox();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }

        }
        //Purpose: to check math xl activity from the left frame of content library
        [When(@"I select the MathXL activity")]
        public void WhenISelecttheMathXLactivity()
        {
            try
            {
                _objContent.ToSelectMathXl();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        //Purpose: to click on Add button
        [When(@"I Click on the Add button")]
        public void WhenClickOnTheAddButton()
        {
            try
            {
                WebDriver.SwitchTo().DefaultContent();
                _contentPage.ClickAddButton();
                WebDriver.SwitchTo().ActiveElement();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                GenericDefinitions.ThenIClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                throw new Exception(e.ToString());
            }
        }

        // Purpose -  To preview SCO questions in manage question library
        [When(@"I preview the 'SCO' question")]
        public void PreviewScoQuestion()
        {
            try
            {
                _toSelectSearchView.ToClickSearchViewbutton();

                // GenericHelper.IsPopUpClosed("Tryout");
                WebDriver.WindowHandles.Any(item => WebDriver.SwitchTo().Window(item).Title == "Question Library");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }

        [When(@"I unhide the activity from right frame")]
        public void WhenIUnhideTheActivity()
        {
            try
            {
                _objContent.ToPerformShowHide();
                GenericHelper.Logs("Activity's status has been changed to shown after selecting show/hide", "Passed");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw e;
            }
        }
    }
}

