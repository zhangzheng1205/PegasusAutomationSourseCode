using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.MyPrefernce;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Coursesettings;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TeachingPlan;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.DRT;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.QuestionLibrary;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Planner.Calendar;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.GradeBook;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Common;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentSchedule;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TodaysView;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool.Presentation;

namespace Pegasus.ProductionDefect.TestScripts.ProductionDefect_StepDefinitions 
{
    [Binding]
    public class US66343_StepDefiniton : BaseTestScript
    {
        // declaring variable for study plan name
      //  private readonly string _studyplan = GenericHelper.GenerateUniqueVariable("SP");//"SP2012117174834";

        readonly private StandardSkillPreferencesPage _standardSkillPreferencesPage = new StandardSkillPreferencesPage();
        private readonly ContentLibraryUXPage _contentLibraryUxPage = new ContentLibraryUXPage();
        readonly private  GeneralPreferencesPage _generalPreferencesPage =new GeneralPreferencesPage();
        readonly private DRTDefaultUXPage _drtDefaultUxPage =new DRTDefaultUXPage();
        readonly private AddAssessmentPage _addAssessmentPage = new AddAssessmentPage();
        readonly private RandomAssessmentPage _randomAssessmentPage =new RandomAssessmentPage();
        readonly private SelectQuestionTypePage _selectQuestionTypePage=new SelectQuestionTypePage();
        readonly private RandomTopicListPage  _randomTopicListPage =new RandomTopicListPage();
        readonly private TrueFalsePage _trueFalsePage =new TrueFalsePage();
        readonly private CalendarHEDDefaultUXPage _calendarHedDefaultUxPage=new CalendarHEDDefaultUXPage();
        readonly private HEDCalenderMonthPopUpPage _calenderMonthPopUpPage =new HEDCalenderMonthPopUpPage();
        readonly private GBInstructorUXPage _gbInstructorUxPage=new GBInstructorUXPage();
        readonly private  GBDefaultUXPage _gbDefaultUxPage =new GBDefaultUXPage();
        private readonly ShowMessagePage _showMessagePage = new ShowMessagePage();
        private readonly AssignContentPage _assignContentPage=new AssignContentPage();
        private readonly TodaysViewPage _todaysViewPage =new TodaysViewPage();
        private readonly StudTodoDonePage _studTodoDonePage =new StudTodoDonePage();
        private readonly StudentPresentationPage _studentPresentationPage =new StudentPresentationPage();
        MyAccountSettingPage _myAccountSettingPage = new MyAccountSettingPage();
        ShowAssignedContentListPage _showAssignedContentListPage =new ShowAssignedContentListPage();

        //Purpose : to create study plan from course materials tab
        [Then(@"I create study plan from course materials tab")]
        public void ThenICreateStudyPlanFromCourseMaterialTab()
        {
            try 
            {
             GenericHelper.WaitUtilWindow("Course Materials");
            _contentLibraryUxPage.ClickAddCourseMaterialsButton();
            if(!_contentLibraryUxPage.IsStudyPlanOptionPresent())
            {
                GenericTestStep.StepToNavigateToTheTab("Preferences");
                _generalPreferencesPage.SelectSkillsAndStandards();
                _standardSkillPreferencesPage.SelectNeitherRadioButtonAndSave();
                GenericTestStep.StepToNavigateToTheTab("Course Materials");
                _contentLibraryUxPage.GetControlToLeftFrame();
                _contentLibraryUxPage.ClickAddCourseMaterialsButton();
            }

            //create study plan
            string studyPlanName = GenericHelper.GenerateUniqueVariable("SP");
            _contentLibraryUxPage.StudyPlanCreation(studyPlanName);
            _contentLibraryUxPage.GetControlToLeftFrame();
            string SPName = DatabaseTools.GetActivityName(Enumerations.ActivityType.StudyPlan);
            GenericTestStep.StepToAddTheActivityToMyCourse(SPName);
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        //Purpose : To select the study plan and assign to any due date says nth date
        [Then(@"I select the study plan and assign to any due date says nth date")]
        public void ThenISelectTheStudyPlanAndAssignToAnyDueDateSaysNthDate()
        {         
            try 
            {
            string SPName = DatabaseTools.GetActivityName(Enumerations.ActivityType.StudyPlan);
            _calendarHedDefaultUxPage.AssignActivityToCurrentDate(SPName);
            //_showAssignedContentListPage.ClickYesButton();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose : To click on “View Advance calendar” and select current date
        [Then(@"I clicked on “View Advance calendar”,it will open a calendar wizard and click on nth date")]
        public void ThenIClickedOnViewAdvanceCalendarItWillOpenACalendarWizardAndClickOnNthDate()
        {
            try 
            {
           _calendarHedDefaultUxPage.ClickViewAdvancedCalendar();
            _calendarHedDefaultUxPage.ClickOnCurrentDateInAdvancedCalendar();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose : To Select the study plan
        [Then(@"I Select the study plan and can find Move button in top of the calendar")]
        public void ThenISelectTheStudyPlanAndCanFindMoveButtonInTopOfTheCalendar()
        {
            try 
            {
            string SPName = DatabaseTools.GetActivityName(Enumerations.ActivityType.StudyPlan);
            _calendarHedDefaultUxPage.SelectCheckBoxOfActivityInAdvanceView(SPName);
            if(_calendarHedDefaultUxPage.VerifyIsMoveButtonEnabled())
            {
                GenericHelper.Logs("Move button is Enabled","PASSED");

            }
            else
            {
                GenericHelper.Logs("Move button is not Enabled", "FAILED");
                throw new Exception("Move button is not Enabled");

            }
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose : To Click on Move button , and to select N+1th date
        [When(@"I Click on Move button, it opens calendar pop-up and select n\+1 the date")]
        [Then(@"I Click on Move button, it opens calendar pop-up and select n\+1 the date")]
        public void WhenIClickOnMoveButtonItOpensCalendarPopUpAndSelectN1TheDate()
        {
            try 
            {
            _calendarHedDefaultUxPage.ClickMoveButton();
            _calenderMonthPopUpPage.SelectTommorowDate();
            Thread.Sleep(1000);
            GenericHelper.ThinkingIndicatorProcessing();
            GenericHelper.SelectDefaultWindow();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose : To Click "View Grades" of the study plan column
        [Then(@"I clicked on the ""View Grades"" of the study plan column")]
        public void ThenIClickedOnTheViewGradesOfTheStudyPlanColumn()
        {
            try
            {

            string spName = DatabaseTools.GetActivityName(Enumerations.ActivityType.StudyPlan);
            _gbDefaultUxPage.SearchActivityByTitle(spName);
            _gbInstructorUxPage.ClickViewGrades(spName);
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose : To Click "View Grades" of the study plan column where study assigned through Properties Window
        [Then(@"I clicked on the ""View Grades"" of the study plan column where study assigned through Properties Window")]
        public void ThenIClickedOnTheViewGradesOfTheStudyPlanColumnWhereStudyAssignedThroughPropertiesWindow()
        {
            try 
            {
            string spName = DatabaseTools.GetActivityName(Enumerations.ActivityType.StudyPlan); //_studyplan;//"Readiness Check Ch04";
            _gbDefaultUxPage.SearchActivityByTitle(spName);
            _gbInstructorUxPage.ClickViewGrades(spName);
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose : verify due dates in gradebook tab
        [Then(@"Due dates should show same time at study plan level and which should match with due dates of pre-test and post-test")]
        public void ThenDueDatesShouldShowSameTimeAtStudyPlanLevelAndWhichShouldMatchWithDueDatesOfPre_TestAndPost_Test()
        {
            try 
            {
            DateTime dateTime = new DateTime();
            string Tomorrow = DateTime.Today.AddDays(1).ToShortDateString();

            if(_gbInstructorUxPage.VerifyDate(Tomorrow))
            {
                GenericHelper.Logs("due dates are correct", "PASSED");
            }
            else
            {
                GenericHelper.Logs("due dates are correct", "FAILED");
                throw new Exception("due dates are incorrect");
            }

            GenericHelper.SelectDefaultWindow();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        // Purspose: to unassigning the activity
        [Then(@"I unassign the Studyplan")]
        public void ThenIUnassignTheStudyplan()
        {
            try 
            {
            string SPName = DatabaseTools.GetActivityName(Enumerations.ActivityType.StudyPlan);
            _calendarHedDefaultUxPage.UnAssignActivity(SPName);
            _showMessagePage.ClickOk();
            Thread.Sleep(2000);
            GenericHelper.SelectDefaultWindow();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        // Purspose: to  assign activity and sp
        [Then(@"I assigned any activity along with study plan to any due date say n is the date")]
        public void ThenIAssignedAnyActivityAlongWithStudyPlanToAnyDueDateSayNIsTheDate()
        {
            try 
            {
            string SPName = DatabaseTools.GetActivityName(Enumerations.ActivityType.StudyPlan);
            _calendarHedDefaultUxPage.AssignActivityToCurrentDate(SPName);

            _showAssignedContentListPage.ClickYesButton();
            
            
            string Actname = "03-01 Span Practice- Vocabulary: La casa";
            _calendarHedDefaultUxPage.SearchActivty(Actname);
            _calendarHedDefaultUxPage.UnAssignActivityInSearchView(Actname);
            _calendarHedDefaultUxPage.AssignActivityToCurrentDateInSearchView("03-01 Span Practice- Vocabulary: La casa");
            _showAssignedContentListPage.ClickYesButton();
            GenericHelper.SelectDefaultWindow();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }

        }

        // Purspose: to Select the study plan and  Acitivity and click on the move button in advance calender view
        [Then(@"I Select the study plan and  Acitivity and can find Move button in top of the calendar")]
        public void ThenISelectTheStudyPlanAndAcitivityAndCanFindMoveButtonInTopOfTheCalendar()
        {
            try 
            {
            string SPName = DatabaseTools.GetActivityName(Enumerations.ActivityType.StudyPlan);
            _calendarHedDefaultUxPage.SelectCheckBoxOfActivityInAdvanceView(SPName);
            _calendarHedDefaultUxPage.SelectCheckBoxOfActivityInAdvanceView("03-01 Span Practice- Vocabulary: La casa");
            if (_calendarHedDefaultUxPage.VerifyIsMoveButtonEnabled())
            {
                GenericHelper.Logs("Move button is Enabled", "PASSED");

            }
            else
            {
                GenericHelper.Logs("Move button is not Enabled", "FAILED");
                throw new Exception("Move button is not Enabled");
            }
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        // Purspose: to verify due dates should show same time at study plan level and contents of SP when assigned with activity
        [Then(@"Due dates should show same time at study plan level and which should match with due dates of pre-test and post-test when assigned with activity")]
        public void ThenDueDatesShouldShowSameTimeAtStudyPlanLevelAndWhichShouldMatchWithDueDatesOfPre_TestAndPost_TestWhenAssignedWithActivity()
        {
            try 
            {
            DateTime dateTime = new DateTime();
            string Tomorrow = DateTime.Today.AddDays(1).ToShortDateString();

            if (_gbInstructorUxPage.VerifyDate(Tomorrow))
            {
                GenericHelper.Logs("due dates are correct when SP assigned with Activity", "PASSED");
            }
            else
            {
                GenericHelper.Logs("due dates are correct when SP assigned with Activity", "FAILED");
                throw new Exception("due dates are incorrect when SP assigned with Activity");
            }
            GenericHelper.SelectDefaultWindow();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        // Purspose: to assign the study plan , such that it should be past due

        [Then(@"I assign the study plan to nth date and ensure that it is past due")]
        public void ThenIAssignTheStudyPlanToNthDateAndEnsureThatItIsPastDue()
        {
            try 

            {
            GenericHelper.WaitUntilElement(By.XPath("//td[@class='HighlightTodayCell']"));
         

             string SPName = DatabaseTools.GetActivityName(Enumerations.ActivityType.StudyPlan);

            _calendarHedDefaultUxPage.AssignActivityToPreviousDate(SPName);
            _showAssignedContentListPage.ClickYesButton();
            GenericHelper.SelectDefaultWindow();
            
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        // Purspose: to verify Contents of the container study plan should shown past due date for Instructor
        [Then(@"Contents of the container study plan should shown past due to the same nth date for Instructor")]
        public void ThenContentsOfTheContainerStudyPlanShouldShownPastDueToTheSameNthDateForInstructor()
        {
            try 
            {
            DateTime dateTime = new DateTime();
            string yesterday = DateTime.Today.AddDays(-1).ToShortDateString();

            if (_gbInstructorUxPage.VerifyDate(yesterday))
            {
                GenericHelper.Logs("due dates are correct when SP is past due for Instructor", "PASSED");
            }
            else
            {
                GenericHelper.Logs("due dates are incorrect when SP is past due for Instructor", "FAILED");
                throw new Exception("due dates are incorrect when SP is past due for Instructor");
            }
            GenericHelper.SelectDefaultWindow();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        // Purspose: to Today's View tab
        [Then(@"I Navigate to Today's View tab")]
        public void ThenINavigateToTodaySViewTab()
        {
            try 
            {
            _calendarHedDefaultUxPage.NavigateToTodaysViewTab();

             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        // Purspose: to Past due Not Submitted channel
        [Then(@"I go to Past due Not Submitted channel")]
        public void ThenIGoToPastDueNotSubmittedChannel()
        {
            try 
            {
            _todaysViewPage.ClickPastDueNotSubmittedLink();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        // Purspose: to verify contents of SP in Not Submitted Past due channel
        [Then(@"Not Submitted Past due study plan's Pre test,Post test should appear immediately once the study plan is past due")]
        public void ThenNotSubmittedPastDueStudyPlanSPreTestPostTestShouldAppearImmediatelyOnceTheStudyPlanIsPastDue()
        {
            try 
            {
            GenericHelper.SelectDefaultWindow();
            if(_todaysViewPage.IsPostTestPresent() && _todaysViewPage.IsPreTestPresent())
            {
                GenericHelper.Logs("pretest and posttest displayed in Past due Not Submitted channel","PASSED");
            }
            else
            {
                GenericHelper.Logs("pretest and posttest not displayed in Past due Not Submitted channel", "FAILED");
                throw new Exception("pretest and posttest not displayed in Past due Not Submitted channel");
            }
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        // Purspose: to verify PastDue Message
        [Then(@"On Launching PreTest and PostTest PastDue Message Should Display for Past Due StudyPlan and submit Pretest and Post")]
        public void ThenOnLaunchingPreTestAndPostTestPastDueMessageShouldDisplayForPastDueStudyPlanAndSubmitPretestAndPost()
        {
            try 
            {
            string sp = DatabaseTools.GetActivityName(Enumerations.ActivityType.StudyPlan);
            _studTodoDonePage.OpenStudyPlan(sp);
            GenericHelper.WaitUtilWindow("Open Study Plan");
            GenericHelper.SelectWindow("Open Study Plan");
            _drtDefaultUxPage.ClickBegin();
            GenericHelper.WaitUtilWindow("Pre Test");
            GenericHelper.SelectWindow("Pre Test");
            if(_studentPresentationPage.VerifyPastDueMsg())
            {
                GenericHelper.Logs("on launching pretest Past due message displayed ", "PASSED");
            }
            else
            {
                GenericHelper.Logs("on launching pretest Past due message not displayed", "PASSED");
                throw new Exception("on launching pretest Past due message not displayed");
            }
            _studentPresentationPage.AnswerTrue();
            _studentPresentationPage.SubmitActivity();
            WebDriver.Close();
            GenericHelper.SelectWindow("Open Study Plan");
            WebDriver.Navigate().Refresh();
            Thread.Sleep(4000);
            GenericHelper.WaitUtilWindow("Open Study Plan");
            GenericHelper.SelectWindow("Open Study Plan");

            _drtDefaultUxPage.ClickBeginForPostTest();
            GenericHelper.WaitUtilWindow("Post Test");
            GenericHelper.SelectWindow("Post Test");
            if (_studentPresentationPage.VerifyPastDueMsg())
            {
                GenericHelper.Logs("on launching posttest Past due message displayed ", "PASSED");
            }
            else
            {
                GenericHelper.Logs("on launching posttest Past due message not displayed", "PASSED");
                throw new Exception("on launching posttest Past due message not displayed");
            }
            _studentPresentationPage.AnswerTrue();
            _studentPresentationPage.SubmitActivity();
            WebDriver.Close();
            GenericHelper.WaitUtilWindow("Open Study Plan");
            GenericHelper.SelectWindow("Open Study Plan");
            _drtDefaultUxPage.BackToPreviousFolder();

             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        // Purspose: to click Past due Submitted link
        [Then(@"I go to Past due Submitted channel")]
        public void ThenIGoToPastDueSubmittedChannel()
        {
            try 
            {
            _todaysViewPage.ClickPastDueSubmittedLink();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        // Purspose: to verify pretest and posttest displayed in Past due Submitted channel
        [Then(@"Submitted Past due study plan's Pre test,Post test should appear immediately once the study plan is past due")]
        public void ThenSubmittedPastDueStudyPlanSPreTestPostTestShouldAppearImmediatelyOnceTheStudyPlanIsPastDue()
        {
            try 
            {
            _todaysViewPage.ClickExpandImage();
            if (_todaysViewPage.IsPastDueSubmittedPreTestPostTestPresent())
            {
                GenericHelper.Logs("pretest and posttest displayed in Past due Submitted channel", "PASSED");
            }
            else
            {
                GenericHelper.Logs("pretest and posttest not displayed in Past due Submitted channel", "FAILED");
                throw new Exception("pretest and posttest not displayed in Past due Submitted channel");
            }
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }


        // Purspose: to assign the study plan through Properties Window as Past due
        [Then(@"I assign the study plan to nth date and ensure that it is past due through Properties Window")]
        public void ThenIAssignTheStudyPlanToNthDateAndEnsureThatItIsPastDueThroughPropertiesWindow()
        {
            try 
            {
            string Actname = DatabaseTools.GetActivityName(Enumerations.ActivityType.StudyPlan);// "SP2012118115736 ";// _studyplan;// "Readiness Check Ch04";

            _calendarHedDefaultUxPage.ClickMyProfile();


            _myAccountSettingPage.SelectFrame();

            string Date = _myAccountSettingPage.GetMyProfileDate();
            string Time = _myAccountSettingPage.GetMyProfileTime();

            _myAccountSettingPage.ClickCancel();

            GenericHelper.SelectDefaultWindow();
            _calendarHedDefaultUxPage.SearchActivty(Actname);
            _calendarHedDefaultUxPage.ClickActivityCmenuInSearchView(Actname);
            _calendarHedDefaultUxPage.SelectAssignmentPropertiesCmenuOption();
            _assignContentPage.SetDateAndTime(Date, Time);
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        // Purspose: to verify PastDue Message
        [Then(@"On Launching PreTest and PostTest PastDue Message Should Display for StudyPlan done Past Due through Properties Window")]
        public void ThenOnLaunchingPreTestAndPostTestPastDueMessageShouldDisplayForStudyPlanDonePastDueThroughPropertiesWindow()
        {
            try 
            {
            string sp = DatabaseTools.GetActivityName(Enumerations.ActivityType.StudyPlan); //_studyplan;// "Readiness Check Ch04";
            _studTodoDonePage.OpenStudyPlan(sp);
            GenericHelper.WaitUtilWindow("Open Study Plan");
            GenericHelper.SelectWindow("Open Study Plan");
            _drtDefaultUxPage.ClickBegin();
            GenericHelper.WaitUtilWindow("Pre Test");
            GenericHelper.SelectWindow("Pre Test");
            if (_studentPresentationPage.VerifyPastDueMsg())
            {
                GenericHelper.Logs("on launching pretest Past due message displayed ", "PASSED");
            }
            else
            {
                GenericHelper.Logs("on launching pretest Past due message not displayed", "PASSED");
                throw new Exception("on launching pretest Past due message not displayed");
            }
            _studentPresentationPage.AnswerTrue();
            _studentPresentationPage.SubmitActivity();
            WebDriver.Close();
            GenericHelper.SelectWindow("Open Study Plan");
            WebDriver.Navigate().Refresh();
            Thread.Sleep(4000);
            GenericHelper.WaitUtilWindow("Open Study Plan");
            GenericHelper.SelectWindow("Open Study Plan");

            _drtDefaultUxPage.ClickBeginForPostTest();
            GenericHelper.WaitUtilWindow("Post Test");
            GenericHelper.SelectWindow("Post Test");
            if (_studentPresentationPage.VerifyPastDueMsg())
            {
                GenericHelper.Logs("on launching posttest Past due message displayed ", "PASSED");
            }
            else
            {
                GenericHelper.Logs("on launching posttest Past due message not displayed", "PASSED");
                throw new Exception("on launching posttest Past due message not displayed");
            }
            _studentPresentationPage.AnswerTrue();
            _studentPresentationPage.SubmitActivity();
            WebDriver.Close();
            GenericHelper.WaitUtilWindow("Open Study Plan");
            GenericHelper.SelectWindow("Open Study Plan");
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

    }
}
