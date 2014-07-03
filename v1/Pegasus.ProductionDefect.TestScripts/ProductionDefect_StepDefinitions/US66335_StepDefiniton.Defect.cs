using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.PegasusTest;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.QuestionLibrary;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TeachingPlan;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool.Presentation;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Common;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Coursesettings;
using OpenQA.Selenium;
using System.Threading;

namespace Pegasus.ProductionDefect.TestScripts.ProductionDefect_StepDefinitions
{
    [Binding]
    public class US66335_StepDefiniton : BaseTestScript
    {
        readonly MyTestGridUXPage _myTestGridUxPage = new MyTestGridUXPage();
        readonly AssessmentNamePage _assessmentNamePage = new AssessmentNamePage();
        readonly PaperTestUXPage _paperTestUxPage = new PaperTestUXPage();
        readonly TrueFalsePage _trueFalsePage = new TrueFalsePage();
        private readonly ContentLibraryUXPage _contentLibraryUxPage = new ContentLibraryUXPage();
        private readonly RandomAssessmentPage _randomAssessmentPage = new RandomAssessmentPage();
        private readonly InstructorPresentationPage _instructorPresentationPage = new InstructorPresentationPage();
        private readonly TeachingplanUXPage _teachingplanUxPage = new TeachingplanUXPage();
        private readonly CoursePreviewMainUXPage _coursePreviewMainUxPage = new CoursePreviewMainUXPage();
        readonly ShowMessagePage _showMessagePage = new ShowMessagePage();
        readonly ErrorMessagePage _errorMessagePage = new ErrorMessagePage();
        private readonly GeneralPreferencesPage _generalPreferencesPage = new GeneralPreferencesPage();
        readonly ActivitiesPreferencesPage _activitiesPreferencesPage = new ActivitiesPreferencesPage();
        readonly DefaultPreferencesPage _defaultPreferencesPage = new DefaultPreferencesPage();
        readonly AddAssessmentPage _addAssessmentPage = new AddAssessmentPage();
        private readonly StudentPresentationPage _studentPresentationPage = new StudentPresentationPage();





        //Purpose: To create Test under Test bank
        [When(@"I create a Test under Test bank")]
        public void WhenICreateATestUnderTestBank()
        {
            try
            {
                string testName = GenericHelper.GenerateUniqueVariable("Test");

                _myTestGridUxPage.ClickCreateNewTest();
                _assessmentNamePage.CreateTest(testName);
                for (int i = 1; i <= 5; i++)
                {
                    _paperTestUxPage.SelectTrueFalseQuestion();
                    if (_trueFalsePage.CreateTrueFalseQuestion() != null)
                    {
                        GenericHelper.Logs("TF question created in Test", "PASSED");
                    }
                    else
                    {
                        GenericHelper.Logs("TF question not created in Test", "FAILED");
                        throw new Exception("TF question not created in Test");
                    }
                }
                if (_paperTestUxPage.SaveTest())
                {
                    GenericHelper.Logs("Test Saved Successfully", "PASSED");
                    DatabaseTools.UpdateActivity(Enumerations.ActivityType.MyTest, testName);
                }
                else
                {
                    GenericHelper.Logs("Test not Saved Successfully", "FAILED");
                    throw new Exception("Test not Saved Successfully");
                }

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To navigate to My Tests Folder in Course Materials
        [When(@"I navigate to My Tests Folder")]
        public void WhenINavigateToMyTestsFolder()
        {
            try
            {

                _contentLibraryUxPage.OpenMyTestsFolder();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To select Edit option of Activity
        [When(@"I select Edit option of Activity")]
        public void WhenISelectEditOptionOfActivity()
        {
            try
            {

                string actName = DatabaseTools.GetActivityName(Enumerations.ActivityType.MyTest);
                _contentLibraryUxPage.ClickActivityCmenu(actName);
                _contentLibraryUxPage.SelectEditCmenuOption();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To change the Value of "Time required to complete the activity" in activity preferences
        [When(@"I changed the Value of ""Time required to complete the activity""")]
        public void WhenIChangedTheValueOfTimeRequiredToCompleteTheActivity()
        {
            try
            {
                _randomAssessmentPage.SelectActivityLevelRadioButton();
                _randomAssessmentPage.SetHours("2");

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To Save the activity
        [When(@"I Save the activity and return to the Course materials")]
        [Then(@"I Save the activity and return to the Course materials")]
        public void WhenISaveTheActivityAndReturnToTheCourseMaterial()
        {
            try
            {

                _randomAssessmentPage.ClickSaveAndReturnAtPreferences();
                GenericHelper.WaitUtilWindow("Course Materials");
                GenericHelper.SelectDefaultWindow();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To Preview the Activity
        [When(@"I Preview the Activity")]
        [Then(@"I Preview the Activity")]
        public void WhenIPreviewTheActivity()
        {
            try
            {
                //string actName = DatabaseTools.GetActivityName(Enumerations.ActivityType.MyTest);
                _contentLibraryUxPage.GetControlToLeftFrame();
                _contentLibraryUxPage.ClickActivityLink("Test201324125450");

                
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To verify the Specified time value in the activity preview
        [Then(@"It should show Specified time value in the activity preview")]
        public void ThenItShouldShowSpecifiedTimeValueInTheActivity()
        {
            try
            {
               
                if (_instructorPresentationPage.GetTimeDisplayValue().Contains("01:59:"))
                {
                    GenericHelper.Logs("Specified Time displayed in Instructor Activity Preview", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Specified Time not displayed in Instructor Activity Preview", "FAILED");
                    throw new Exception("Specified Time not displayed in Instructor Activity Preview");
                }
                // WebDriver.Close();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        //Purpose: To Edit the activity and navigate to preferences tab
        [When(@"I Edit the activity and navigate to preferences tab")]
        [Then(@"I Edit the activity and navigate to preferences tab")]
        public void ThenIEditTheActivityAndNavigateToPreferencesTab()
        {
            try
            {

                GenericHelper.WaitUtilWindow("Course Materials");
                GenericHelper.SelectWindow("Course Materials");
                _contentLibraryUxPage.GetControlToLeftFrame();
                string actName = DatabaseTools.GetActivityName(Enumerations.ActivityType.MyTest);
                _contentLibraryUxPage.ClickActivityCmenu("Test201324125450");
                _contentLibraryUxPage.SelectEditCmenuOption();
                GenericHelper.WaitUtilWindow("Edit Random activity");
                _randomAssessmentPage.NavigatePreferencesTab();

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        //Purpose: To Edit the activity and navigate to grades tab
        [Then(@"I Edit the activity and navigate to grades tab")]
        [When(@"I Edit the activity and navigate to grades tab")]
        public void ThenIEditTheActivityAndNavigateToGradesTab()
        {
            try
            {
                GenericHelper.WaitUtilWindow("Course Materials");
                GenericHelper.SelectWindow("Course Materials");
                _contentLibraryUxPage.GetControlToLeftFrame();
                string actName = DatabaseTools.GetActivityName(Enumerations.ActivityType.MyTest);
                _contentLibraryUxPage.ClickActivityCmenu(actName);
                _contentLibraryUxPage.SelectEditCmenuOption();
                _randomAssessmentPage.NavigateGradesTab();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To  navigate to grades tab in the edit activity page
        [When(@"I navigate to grades tab in the edit activity page")]
        public void WhenINavigateToGradesTabInTheEditActivityPage()
        {
            try
            {
                _randomAssessmentPage.NavigateGradesTab();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To navigate to preferences tab in the edit activity page
        [Then(@"I navigate to preferences tab in the edit activity page")]
        public void ThenINavigateToPreferencesTabInTheEditActivityPage()
        {
            try
            {
                _randomAssessmentPage.NavigatePreferencesTab();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To verify Specified time value in the edit activity page
        [Then(@"It should display Specified time value in the edit activity page")]
        public void ThenItShouldDisplaySpecifiedTimeValueInTheEditActivityPage()
        {
            try
            {
                if (_randomAssessmentPage.GetTimeValue() == "02")
                {
                    GenericHelper.Logs("Specified Time Value displayed in the Edit Activity Page", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Specified Time Value not displayed in the Edit Activity Page", "FAILED");
                    throw new Exception("Specified Time Value not displayed in the Edit Activity Page");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }

        }

        //Purpose: To changed the Value of "Display this number of questions per page" activity preferences
        [Then(@"I changed the Value of ""Display this number of questions per page""")]
        [When(@"I changed the Value of ""Display this number of questions per page""")]
        public void ThenIChangedTheValueOfDisplayThisNumberOfQuestionsPerPage()
        {
            try
            {
                _randomAssessmentPage.SetQuestionsCount("2");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }

        }

        //Purpose: To verify specified number of questions in the activity preview
        [Then(@"It should display specified number of questions in the presentation")]
        public void ThenItShouldDisplaySpecifiedNumberOfQuestionsInThePresentation()
        {
            try
            {
                string questionCount = _instructorPresentationPage.QuestionsDisplayedPerPage();
                if (questionCount == "2")
                {
                    GenericHelper.Logs("Specified No of questions displayed in the  Instructor Activity Preview", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Specified No of questions not displayed in the Instructor Activity Preview", "FAILED");
                    throw new Exception("Specified No of questions not displayed in the Instructor Activity Preview");
                }
                //WebDriver.Close();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To verify specified question count value in the edit activity page
        [Then(@"It should remains same as Specified question count value in the edit activity page")]
        public void ThenItShouldRemainsSameAsSpecifiedQuestionCountValueInTheEditActivityPage()
        {
            try
            {
                if (_randomAssessmentPage.GetQuestionsCount() == "2")
                {
                    GenericHelper.Logs("Specified question count value remained same in the edit activity page", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Specified question count value not remained same in the edit activity page", "FAILED");
                    throw new Exception("Specified question count value not remained same in the edit activity page");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To change the Value of "Select style sheet" in the edit activity page
        [When(@"I changed the Value of ""Select style sheet"" in the edit activity page")]
        [Then(@"I changed the Value of ""Select style sheet"" in the edit activity page")]
        public void ThenIChangedTheValueOfSelectStyleSheetInTheEditActivityPage()
        {
            _randomAssessmentPage.SelectDefaultStyleSheet();
        }

        //Purpose: To verify changed style applied for the activity presentation
        [Then(@"It should display changed style applied for the activity presentation")]
        public void ThenItShouldDisplayChangedStyleAppliedForTheActivityPresentation()
        {
            try
            {
                if (_instructorPresentationPage.VerifyDefaultSheetStyle())
                {
                    GenericHelper.Logs("Changed default Sheet Style displayed in the  Instructor Activity Preview", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Changed default Sheet Style not displayed in the  Instructor Activity Preview", "FAILED");
                  //  throw new Exception("Changed default Sheet Style not displayed in the  Instructor Activity Preview");
                }
                WebDriver.Close();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To verify changed style remained same in the edit activity page
        [Then(@"It should display recently changed style sheet  value for the ""Select style sheet"" preference options")]
        public void ThenItShouldDisplayRecentlyChangedStyleSheetValueForTheSelectStyleSheetPreferenceOptions()
        {
            try
            {
                if (_randomAssessmentPage.verifyDefaultStyleSheetSelected() == "Default")
                {
                    GenericHelper.Logs("recently changed drop down style sheet value remained same in the edit activity page", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("recently changed drop down style sheet value not remained same in the edit activity page", "FAILED");
                    throw new Exception("recently changed drop down style sheet value not remained same in the edit activity page");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To verify default value in grades tab for 'select grade schema'
        [Then(@"It should not show grade schema ""Default"" value for ""Select grade schema"" unless and until user selects the schema")]
        public void ThenItShouldNotShowGradeSchemaDefaultValueForSelectGradeSchemaUnlessAndUntilUserSelectsTheSchema()
        {
            try
            {
                if (_randomAssessmentPage.verifyGradeSchemaSelected() == "<-- Select -->")
                {
                    GenericHelper.Logs("By default No Grade Schema Selected in the edit activity page", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("By default Grade Schema Selected in the edit activity page", "FAILED");
                    throw new Exception("By default Grade Schema Selected in the edit activity page");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To select Default Schema for "Select grade schema"
        [Then(@"I select Default Schema for ""Select grade schema""")]
        public void ThenISelectDefaultSchemaForSelectGradeSchema()
        {
            try
            {
                _randomAssessmentPage.SelectDefaultGradeSchema();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To set the value for Specify number of attempts in edit activity page
        [Then(@"I changed the Value as (.*) for 'Specify number of attempts'")]
        [When(@"I changed the Value as (.*) for 'Specify number of attempts'")]
        public void ThenIChangedTheValueAs1ForSpecifyNumberOfAttempts(string attempts)
        {
            try
            {
                _randomAssessmentPage.SetNumberOfAttempts(attempts);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To Save the activity in grades tab
        [Then(@"I Save the activity in grades tab and return to the Course material")]
        public void ThenISaveTheActivityInGradesTabAndReturnToTheCourseMaterial()
        {
            try
            {
                _randomAssessmentPage.ClickSaveAndReturnAtGrades();
                GenericHelper.WaitUtilWindow("Course Materials");
                GenericHelper.SelectDefaultWindow();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To verify display of recent value provided for 'Specify number of attempts' in the edit activity page 
        [Then(@"It should display recent value provided for 'Specify number of attempts' in the edit activity page")]
        public void ThenItShouldDisplayRecentValueProvidedForSpecifyNumberOfAttemptsInTheEditActivityPage()
        {
            try
            {
                if (_randomAssessmentPage.GetValueOfSpecifyNumberOfAttempts() == "1")
                {
                    GenericHelper.Logs("Retained recent value provided for 'Specify number of attempts' in the edit activity page", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Not Retained recent value provided for 'Specify number of attempts' in the edit activity page", "FAILED");
                    throw new Exception("Not Retained recent value provided for 'Specify number of attempts' in the edit activity page");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose: To verify display of Default Schema for "Select grade schema"
        [Then(@"It should display Default Schema for ""Select grade schema""")]
        public void ThenItShouldDisplayDefaultSchemaForSelectGradeSchema()
        {
            try
            {

                if (_randomAssessmentPage.verifyGradeSchemaSelected() == "Default")
                {
                    GenericHelper.Logs("Default Grade Schema Selected in the edit activity page", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Default Grade Schema not Selected in the edit activity page", "FAILED");
                    throw new Exception("Default Grade Schema not Selected in the edit activity page");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        //[Then(@"I Add the Activity to MyCourse")]
        //public void ThenIAddTheActivityToMyCourse()
        //{
        //    string actName = DatabaseTools.GetActivityName(Enumerations.ActivityType.MyTest);
        //    _contentLibraryUxPage.SelectAsset(actName);
        //    GenericHelper.SelectDefaultWindow();
        //    _teachingplanUxPage.ClickAddButton();

        //}

        //[Then(@"It should be allowed to attempt activity for specified number of times")]
        //public void WhenItShouldBeAllowedToAttemptActivityForSpecifiedNumberOfTimes()
        //{
        //     string actName = DatabaseTools.GetActivityName(Enumerations.ActivityType.MyTest);
        //    _coursePreviewMainUxPage.OpenAsset(actName);
        //    _showMessagePage.ClickContinue();
        //    GenericHelper.WaitUtilWindow("Web Activity");
        //    GenericHelper.SelectWindow("Web Activity");
        //    WebDriver.Close();
        //    _coursePreviewMainUxPage.OpenAsset(actName);

        //    if(_errorMessagePage.VerifyErrorMessage())
        //    {
        //        GenericHelper.Logs("Error message displayed On attempting the activity more than specified attempt","PASSED");
        //    }
        //    else
        //    {
        //        GenericHelper.Logs("Error message not displayed On attempting the activity more than specified attempt", "FAILED");
        //        throw new Exception("Error message not displayed On attempting the activity more than specified attempt");
        //    }
        //    WebDriver.Close();
        //}


        //Purpose :To verify allowed to attempt activity for specified number of times for student
        [Then(@"It should be allowed to attempt activity for specified number of times for student")]
        public void ThenItShouldBeAllowedToAttemptActivityForSpecifiedNumberOfTimesForStudent()
        {
            try
            {
                GenericHelper.SelectDefaultWindow();
                //_contentLibraryUxPage.GetControlToLeftFrame();
                //string actName = DatabaseTools.GetActivityName(Enumerations.ActivityType.MyTest);
                //GenericTestStep.StepToAddTheActivityToMyCourse(actName);
                GenericStepDefinition.ClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
                GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSStudent();
                GenericTestStep.StepToItShouldBeOnPage("Global Home");
                GenericTestStep.StepToselectthecoursefromGlobalhomepage();
                GenericTestStep.StepToNavigateToTheTab("Course Materials");

                //string actName = DatabaseTools.GetActivityName(Enumerations.ActivityType.MyTest);
                _coursePreviewMainUxPage.OpenAsset("Test201324125450");
                //_showMessagePage.ClickContinue();
                GenericHelper.WaitUtilWindow("Web Activity");
                GenericHelper.SelectWindow("Web Activity");
                _studentPresentationPage.SubmitActivity();
                WebDriver.Close();
                //_coursePreviewMainUxPage.OpenAsset(actName);


                //if (_errorMessagePage.VerifyErrorMessage())
                //{
                //    GenericHelper.Logs("Error message displayed On attempting the activity more than specified attempt", "PASSED");
                //}
                //else
                //{
                //    GenericHelper.Logs("Error message not displayed On attempting the activity more than specified attempt", "FAILED");
                //    throw new Exception("Error message not displayed On attempting the activity more than specified attempt");
                //}
                //WebDriver.Close();
                GenericHelper.SelectDefaultWindow();
                GenericStepDefinition.ClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose :To edit the activity type and change the values of the preferences sets and clicked on 'Apply to all'
        [When(@"I edit the activity type and change the values of the preferences sets and clicked on 'Apply to all'")]
        public void WhenIEditTheActivityTypeAndChangeTheValuesOfThePreferencesSetsAndClickOnApplyToAll()
        {
            try
            {
                _generalPreferencesPage.SelectActivities();

                _activitiesPreferencesPage.ClickFirstPreferencesEditLink();
                GenericHelper.WaitUtilWindow("Default preferences");
                GenericHelper.SelectWindow("Default preferences");

                //set question count
                _defaultPreferencesPage.SetQuestionCount("2");
                //set attempts
              //  _defaultPreferencesPage.SetAttempts("4");
                // select activity style sheet
                _defaultPreferencesPage.SelectMsl100StyleSheet();

                //set time limit
                _defaultPreferencesPage.SelectTiming();
                _defaultPreferencesPage.SelectActivityLevelRadioButton();
                _defaultPreferencesPage.SetHours("2");

                //set threshold score
                _defaultPreferencesPage.SelectGrading();
                _defaultPreferencesPage.SetThresholdScore("60");
                _defaultPreferencesPage.ClickApplyToAll();
                _showMessagePage.ClickOk();

                if (GenericHelper.IsPopUpClosed(2))
                {
                    GenericHelper.Logs("Default Preferences Page closed on clicking Apply to all and ok button in pegasus pop up", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Default Preferences Page not closed on clicking Apply to all and ok button in pegasus pop up", "FAILED");
                    throw new Exception("Default Preferences Page not closed on clicking Apply to all and ok button in pegasus pop up");
                }

                GenericHelper.SelectDefaultWindow();
                if (GenericHelper.VerifySuccesfullMessage(
                    "Preference settings updated for all existing and future activities of the selected activity type"))
                {
                    GenericHelper.Logs("On doing Apply To All of Default Preferences Sucessfull message displayed", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("On doing Apply To All of Default Preferences Sucessfull message not displayed", "FAILED");
                    throw new Exception("On doing Apply To All of Default Preferences Sucessfull message not displayed");
                }

            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        //Purpose : To verify Changes done in the default preferences of the activity for the existing activity
        [Then(@"It should shown up  the Changes done in the default preferences of the activity for the existing activity")]
        public void ThenItShouldShownUpTheChangesDoneInTheDefaultPreferencesOfTheActivityForTheExistingActivity()
        {
            try
            {
                GenericTestStep.StepToNavigateToTheTab("Course Materials");
                _contentLibraryUxPage.OpenMyTestsFolder();
                ThenIEditTheActivityAndNavigateToPreferencesTab();

               if (_randomAssessmentPage.GetQuestionsCount() == "3" && _randomAssessmentPage.GetValueOfSpecifyNumberOfAttempts() == "4")
                {
                    GenericHelper.Logs("Changes done for 'questions per page' and 'SpecifyNumberOfAttempts' in the default preferences are reflected for the existing activity", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Changes done for 'questions per page' and 'SpecifyNumberOfAttempts' in the default preferences are not reflected for the existing activity", "PASSED");
                    throw new Exception("Changes done for 'questions per page' and 'SpecifyNumberOfAttempts' in the default preferences are not reflected for the existing activity");
                }

                if (_randomAssessmentPage.verifyDefaultStyleSheetSelected() == "MSL100" && _randomAssessmentPage.GetTimeValue() == "03")
                {
                    GenericHelper.Logs("Changes done for 'style sheet ' and 'Time required to complete the activity' in the default preferences are reflected for the existing activity", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Changes done for 'style sheet ' and 'Time required to complete the activity' in the default preferences are not reflected for the existing activity", "PASSED");
                    throw new Exception("Changes done for 'style sheet ' and 'Time required to complete the activity' in the default preferences are not reflected for the existing activity");
                }
                if (_randomAssessmentPage.GetValueOfThresholdScore() == "60")
                {
                    GenericHelper.Logs("Changes done for 'Threshold Score' in the default preferences are reflected for the existing activity", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Changes done for 'ThresholdScore'  in the default preferences are not reflected for the existing activity", "PASSED");
                    throw new Exception("Changes done for 'ThresholdScore' and  in the default preferences are not reflected for the existing activity");
                }

                WhenISaveTheActivityAndReturnToTheCourseMaterial();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose : To verify Changes done in the default preferences of the activity for the newly created activity
        [Then(@"It should shown up  the Changes done in the default preferences of the activity for the newly created activity")]
        public void ThenItShouldShownUpTheChangesDoneInTheDefaultPreferencesOfTheActivityForTheNewlyCreatedActivity()
        {
            try
            {
                GenericTestStep.StepToNavigateToTheTab("Course Materials");
                string newTest = GenericHelper.GenerateUniqueVariable("NewTest");
                GenericHelper.SelectWindow("Course Materials");
                _contentLibraryUxPage.ClickAddCourseMaterialsButton();
                _contentLibraryUxPage.SelectWebActivity();
                GenericHelper.WaitUtilWindow("Create activity");
                GenericHelper.SelectDefaultWindow();
                _addAssessmentPage.EnterActivityName(newTest);
                _addAssessmentPage.SelectRandomActivity();
                _addAssessmentPage.ClickSaveAndContinue();
                _randomAssessmentPage.NavigatePreferencesTab();
                if (_randomAssessmentPage.GetQuestionsCount() == "2")
                {
                    GenericHelper.Logs("Changes done for 'questions per page' and 'SpecifyNumberOfAttempts' in the default preferences are reflected for the new activity", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Changes done for 'questions per page' and 'SpecifyNumberOfAttempts' in the default preferences are not reflected for the new activity", "PASSED");
                    throw new Exception("Changes done for 'questions per page' and 'SpecifyNumberOfAttempts' in the default preferences are not reflected for the new activity");
                }

                if (_randomAssessmentPage.verifyDefaultStyleSheetSelected() == "MSL100" && _randomAssessmentPage.GetTimeValue() == "02")
                {
                    GenericHelper.Logs("Changes done for 'style sheet ' and 'Time required to complete the activity' in the default preferences are reflected for the new activity", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Changes done for 'style sheet ' and 'Time required to complete the activity' in the default preferences are not reflected for the new activity", "PASSED");
                    throw new Exception("Changes done for 'style sheet ' and 'Time required to complete the activity' in the default preferences are not reflected for the new activity");
                }
                if (_randomAssessmentPage.GetValueOfThresholdScore() == "60")
                {
                    GenericHelper.Logs("Changes done for 'Threshold Score' in the default preferences are reflected for the new activity", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("Changes done for 'ThresholdScore'  in the default preferences are not reflected for the new activity", "PASSED");
                    throw new Exception("Changes done for 'ThresholdScore' and  in the default preferences are not reflected for the new activity");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

    }
}
