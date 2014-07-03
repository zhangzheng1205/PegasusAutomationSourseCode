using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Framework.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Common;
using TechTalk.SpecFlow;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Reports;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool.Presentation;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.DRT;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TeachingPlan;

namespace Pegasus.ProductionDefect.TestScripts.ProductionDefect_StepDefinitions
{
    [Binding]
    public class US66321_StepDefinition : BaseTestScript
    {
        //Purpose: Calling Methods from Page Class
        RptCommonCriteriaPage _rptCommonCriteriaPage =new RptCommonCriteriaPage();
        RptGCOptionsUXPage _rptGcOptionsUxPage = new RptGCOptionsUXPage();
        RptMainPage _rptMainPage =new RptMainPage();
        RptSelectAssessmentsPage _rptSelectAssessmentsPage =new RptSelectAssessmentsPage();
        private RptSelectStudentsPage _rptSelectStudentsPage = new RptSelectStudentsPage();
        ReportsDRTModulePage _reportsDrtModulePage =new ReportsDRTModulePage();
        StudentPresentationPage _studentPresentationPage=new StudentPresentationPage();
        DRTDefaultUXPage _drtDefaultUxPage =new DRTDefaultUXPage();
        private readonly ShowMessagePage _showMessagePage = new ShowMessagePage();
        DRTStudentUXPage _drtStudentUxPage =new DRTStudentUXPage();
        CoursePreviewMainUXPage _coursePreviewMainUxPage = new CoursePreviewMainUXPage();

        //Purpose: Get the Data from DB
        readonly string _courseName = DatabaseTools.GetCourse(Enumerations.CourseType.InstructorCourse).Trim();

        //Purpose:  Step Definition To do submissions of study plans
        [Given(@"Student has already submitted the StudyPlans if not then Submit the StudyPlans")]
        public void GivenStudentHasAlreadySubmittedTheStudyPlansIfNotThenSubmitTheStudyPlans()
        {
            try 
            {
            bool SubmissionStatus1 = true;
            bool SubmissionStatus2 = true;
            bool SubmissionStatus3 = true;

            bool SubmissionStatus = true;

            string isSpAlreadySubmitted1 = DatabaseTools.GetSubmissionStatusOfActivity(Enumerations.ActivityType.SpWith1Rem);
            if (isSpAlreadySubmitted1 == null || isSpAlreadySubmitted1.Equals("False") || isSpAlreadySubmitted1.Equals(""))
            {
                SubmissionStatus1 = false;
            }
            string isSpAlreadySubmitted2 = DatabaseTools.GetSubmissionStatusOfActivity(Enumerations.ActivityType.Sp1With3Rem);
            if (isSpAlreadySubmitted2 == null || isSpAlreadySubmitted2.Equals("False") || isSpAlreadySubmitted2.Equals(""))
            {
                SubmissionStatus2 = false;
            }
            string isSpAlreadySubmitted3 = DatabaseTools.GetSubmissionStatusOfActivity(Enumerations.ActivityType.Sp2With3Rem);
            if (isSpAlreadySubmitted3 == null || isSpAlreadySubmitted3.Equals("False") || isSpAlreadySubmitted3.Equals(""))
            {
                SubmissionStatus3 = false;
            }

            SubmissionStatus = SubmissionStatus1 && SubmissionStatus2;

            if((SubmissionStatus && SubmissionStatus3)==false)
            {                          
            string isSpAlreadySubmitted = DatabaseTools.GetSubmissionStatusOfActivity(Enumerations.ActivityType.SpWith1Rem);
             if (isSpAlreadySubmitted == null || isSpAlreadySubmitted.Equals("False") || isSpAlreadySubmitted.Equals(""))
             {
                 string _SpName = DatabaseTools.GetActivityName(Enumerations.ActivityType.SpWith1Rem);

                 GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsStudent");
                 GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSStudent();
                 GenericTestStep.StepToCloseStudentHelpTextWindow();
                 GenericTestStep.StepToIAmOnThePage("Global Home");
                 GenericTestStep.StepToSelectTheCreatedCourse(_courseName);
                 GenericTestStep.StepToItShouldBeOnPage("Today's View");
                 GenericTestStep.StepToNavigateToTheTab("Course Materials");

                 if (_SpName != null) _coursePreviewMainUxPage.OpenAsset(_SpName);
                 GenericHelper.WaitUtilWindow("Open Study Plan");
                 _drtDefaultUxPage.ClickBegin();
                 _showMessagePage.ClickContinue();
                 GenericHelper.SelectWindow("Pre Test");
                 _studentPresentationPage.AnswerFalse();
                 _studentPresentationPage.SubmitActivity();
                 WebDriver.Close();
                 GenericHelper.SelectWindow("Open Study Plan");
                 WebDriver.Navigate().Refresh();
                 Thread.Sleep(4000);

                 // studymaterial presentation
                 GenericHelper.WaitUtilWindow("Open Study Plan");
                 GenericHelper.SelectWindow("Open Study Plan");
                 _drtStudentUxPage.SelectAllAvailableStudyMaterial();
                 _drtStudentUxPage.SelectFrame();
                 _drtStudentUxPage.OpenFirstStudyMaterial();
                 Thread.Sleep(2000);
                 GenericHelper.SelectWindow("Web Activity");
                 _studentPresentationPage.AnswerTrue();
                 _studentPresentationPage.SubmitActivity();
                 WebDriver.Close();
                 GenericHelper.SelectWindow("Open Study Plan");
                // WebDriver.Navigate().Refresh();
                 //Thread.Sleep(4000);
                 _drtDefaultUxPage.ClickReturnToCourse();
                 Thread.Sleep(4000);
                 DatabaseTools.UpdateSubmissionStatusOfActivity(_SpName);

             }

             string isSp2AlreadySubmitted = DatabaseTools.GetSubmissionStatusOfActivity(Enumerations.ActivityType.Sp1With3Rem);
             if (isSp2AlreadySubmitted == null || isSp2AlreadySubmitted.Equals("False") || isSp2AlreadySubmitted.Equals(""))
             {
                 string _SpName = DatabaseTools.GetActivityName(Enumerations.ActivityType.Sp1With3Rem);

                 GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsStudent");
                 GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSStudent();
                 GenericTestStep.StepToCloseStudentHelpTextWindow();
                 GenericTestStep.StepToIAmOnThePage("Global Home");
                 GenericTestStep.StepToSelectTheCreatedCourse(_courseName);
                 GenericTestStep.StepToItShouldBeOnPage("Today's View");
                 GenericTestStep.StepToNavigateToTheTab("Course Materials");

                 if (_SpName != null) _coursePreviewMainUxPage.OpenAsset(_SpName);
                 GenericHelper.WaitUtilWindow("Open Study Plan");
                 _drtDefaultUxPage.ClickBegin();
                 _showMessagePage.ClickContinue();
                 GenericHelper.SelectWindow("Pre Test");
                 _studentPresentationPage.AnswerFalse();
                 _studentPresentationPage.SubmitActivity();
                 WebDriver.Close();
                 GenericHelper.SelectWindow("Open Study Plan");
                 WebDriver.Navigate().Refresh();
                 Thread.Sleep(4000);


                 // studymaterial presentation
                 // first studymaterial 
                 GenericHelper.WaitUtilWindow("Open Study Plan");
                 GenericHelper.SelectWindow("Open Study Plan");
                 _drtStudentUxPage.SelectAllAvailableStudyMaterial();
                 _drtStudentUxPage.SelectFrame();
                 _drtStudentUxPage.OpenFirstStudyMaterial();
                 Thread.Sleep(2000);
                 GenericHelper.SelectWindow("Web Activity");
                 _studentPresentationPage.AnswerFalse();
                 _studentPresentationPage.SubmitActivity();
                 WebDriver.Close();
                 GenericHelper.SelectWindow("Open Study Plan");
                  WebDriver.Navigate().Refresh();
                 Thread.Sleep(4000);

                 // Second studymaterial 
                 GenericHelper.WaitUtilWindow("Open Study Plan");
                 GenericHelper.SelectWindow("Open Study Plan");
                 _drtStudentUxPage.SelectFrame();
                 _drtStudentUxPage.OpenSecondStudyMaterial();
                 Thread.Sleep(2000);
                 GenericHelper.SelectWindow("Web Activity");
                 _studentPresentationPage.AnswerTrue();
                 _studentPresentationPage.SubmitActivity();
                 WebDriver.Close();
                 GenericHelper.SelectWindow("Open Study Plan");
                 WebDriver.Navigate().Refresh();
                 Thread.Sleep(4000);

                 // Third studymaterial 
                 GenericHelper.WaitUtilWindow("Open Study Plan");
                 GenericHelper.SelectWindow("Open Study Plan");
                 _drtStudentUxPage.SelectFrame();
                 _drtStudentUxPage.OpenThirdStudyMaterial();
                 Thread.Sleep(2000);
                 GenericHelper.SelectWindow("Web Activity");
                 _studentPresentationPage.AnswerTrue();
                 _studentPresentationPage.SubmitActivity();
                 WebDriver.Close();
                 GenericHelper.SelectWindow("Open Study Plan");
                 WebDriver.Navigate().Refresh();
                 Thread.Sleep(4000);
                 _drtDefaultUxPage.ClickReturnToCourse();
                 Thread.Sleep(4000);
                 DatabaseTools.UpdateSubmissionStatusOfActivity(_SpName);
             }

             string isSp3AlreadySubmitted = DatabaseTools.GetSubmissionStatusOfActivity(Enumerations.ActivityType.Sp2With3Rem);
             if (isSp3AlreadySubmitted == null || isSp3AlreadySubmitted.Equals("False") || isSp3AlreadySubmitted.Equals(""))
             {
                 string _SpName = DatabaseTools.GetActivityName(Enumerations.ActivityType.Sp2With3Rem);

                 GenericTestStep.StepToBrowsedUrlForPegasusUser("CsSmsStudent");
                 GenericTestStep.StepToLoggedIntoTheCourseSpaceAsSMSStudent();
                 GenericTestStep.StepToCloseStudentHelpTextWindow();
                 GenericTestStep.StepToIAmOnThePage("Global Home");
                 GenericTestStep.StepToSelectTheCreatedCourse(_courseName);
                 GenericTestStep.StepToItShouldBeOnPage("Today's View");
                 GenericTestStep.StepToNavigateToTheTab("Course Materials");

                 if (_SpName != null) _coursePreviewMainUxPage.OpenAsset(_SpName);
                 GenericHelper.WaitUtilWindow("Open Study Plan");
                 _drtDefaultUxPage.ClickBegin();
                 _showMessagePage.ClickContinue();
                 GenericHelper.SelectWindow("Pre Test");
                 _studentPresentationPage.AnswerFalse();
                 _studentPresentationPage.SubmitActivity();
                 WebDriver.Close();
                 GenericHelper.SelectWindow("Open Study Plan");
                 WebDriver.Navigate().Refresh();
                 Thread.Sleep(4000);


                 // studymaterial presentation
                 // first studymaterial 
                 GenericHelper.WaitUtilWindow("Open Study Plan");
                 GenericHelper.SelectWindow("Open Study Plan");
                 _drtStudentUxPage.SelectAllAvailableStudyMaterial();
                 _drtStudentUxPage.SelectFrame();
                 _drtStudentUxPage.OpenFirstStudyMaterial();
                 Thread.Sleep(2000);
                 GenericHelper.SelectWindow("Web Activity");
                 _studentPresentationPage.AnswerFalse();
                 _studentPresentationPage.SubmitActivity();
                 WebDriver.Close();
                 GenericHelper.SelectWindow("Open Study Plan");
                 WebDriver.Navigate().Refresh();
                 Thread.Sleep(4000);

                 // Second studymaterial 
                 GenericHelper.WaitUtilWindow("Open Study Plan");
                 GenericHelper.SelectWindow("Open Study Plan");
                 _drtStudentUxPage.SelectFrame();
                 _drtStudentUxPage.OpenSecondStudyMaterial();
                 Thread.Sleep(2000);
                 GenericHelper.SelectWindow("Web Activity");
                 _studentPresentationPage.AnswerTrue();
                 _studentPresentationPage.SubmitActivity();
                 WebDriver.Close();
                 GenericHelper.SelectWindow("Open Study Plan");
                 WebDriver.Navigate().Refresh();
                 Thread.Sleep(4000);

                 // Third studymaterial 
                 GenericHelper.WaitUtilWindow("Open Study Plan");
                 GenericHelper.SelectWindow("Open Study Plan");
                 _drtStudentUxPage.SelectFrame();
                 _drtStudentUxPage.OpenThirdStudyMaterial();
                 Thread.Sleep(2000);
                 GenericHelper.SelectWindow("Web Activity");
                 _studentPresentationPage.AnswerTrue();
                 _studentPresentationPage.SubmitActivity();
                 WebDriver.Close();
                 GenericHelper.SelectWindow("Open Study Plan");
                 WebDriver.Navigate().Refresh();
                 Thread.Sleep(4000);

                 _drtDefaultUxPage.ClickReturnToCourse();
                 Thread.Sleep(4000);
                 DatabaseTools.UpdateSubmissionStatusOfActivity(_SpName);
             }
                GenericTestStep.StepToClickedOnTheLogoutLinkToGetLoggedOutFromTheApplication();
            }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose:  Step Definition To Select Study Plan Results Option
        [When(@"I Select Study Plan Results Option")]
        public void WhenISelectStudyPlanResultsOption()
        {
            try 
            {
            _rptMainPage.SelectStudyPlanResults();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose:  Step Definition To generate report by selecting single study plan which having single remediation
        [When(@"I generate report by selecting single study plan which having single remediation")]
        public void WhenIGenerateReportBySelectingSingleStudyPlanWhichHavingSingleRemediation()
        {
            try 
            {
            GenericHelper.SelectWindow("Reports");
            _rptGcOptionsUxPage.ClickSelectStudyPlans();
           
            GenericHelper.SelectWindow("Select Study Plan");

            string sp = DatabaseTools.GetActivityName(Enumerations.ActivityType.SpWith1Rem);
            _rptSelectAssessmentsPage.SelectStudyPlan(sp);
            _rptSelectAssessmentsPage.ClickAddButton();

            GenericHelper.SelectWindow("Reports");
            string stu = DatabaseTools.GetUsername(Enumerations.UserType.CsSmsStudent);

            _rptGcOptionsUxPage.ClickSelectStudents();
            GenericHelper.SelectWindow("Select Students");
            _rptSelectStudentsPage.SelectStudent(stu);
            _rptSelectStudentsPage.ClickAddButton();

            _rptCommonCriteriaPage.RunReport();

            GenericHelper.WaitUtilWindow("Study Plan Results");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose:  Step Definition To verify Study material Average
        [Then(@"Study material Average Should be Calculated based on the Raw Score")]
        public void ThenStudyMaterialAverageShouldBeCalculatedBasedOnTheRawScore()
        {
            try 
            {
            GenericHelper.SelectWindow("Study Plan Results");
            string classAvg = _reportsDrtModulePage.GetClassAvg();
            string UserAvg = _reportsDrtModulePage.GetUserAvg();
            if (((Convert.ToInt32(classAvg)) != null) && ((Convert.ToInt32(UserAvg)) != null))
            {
                GenericHelper.Logs(" class avg is " + classAvg + " and user avg is " + UserAvg + " are displayed","PASSED");
            }
            else
            {
                GenericHelper.Logs(" class avg is " + classAvg + " and user avg is " + UserAvg + " are not displayed","FAILED");
                throw new Exception(" class avg is " + classAvg + " and user avg is " + UserAvg + " are not displayed");
            }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose:  Step Definition To verify Study Material Average of User level and the class level should display the same values
        [Then(@"Study Material Average of User level and the class level should display the same values")]
        public void ThenStudyMaterialAverageOfUserLevelAndTheClassLevelShouldDisplayTheSameValues()
        {
            try 
            {
            GenericHelper.SelectWindow("Study Plan Results");
            string classAvg = _reportsDrtModulePage.GetClassAvg();
            string UserAvg = _reportsDrtModulePage.GetUserAvg();
            if ((Convert.ToInt32(classAvg)) == (Convert.ToInt32(UserAvg)))
            {
                GenericHelper.Logs(" class avg is " + classAvg + " and user avg is " + UserAvg + " both are displayed as same ", "PASSED");
            }
            else
            {
                GenericHelper.Logs(" class avg is " + classAvg + " and user avg is " + UserAvg + " both are not displayed as same", "FAILED");
                throw new Exception(" class avg is " + classAvg + " and user avg is " + UserAvg +
                                    " both are not displayed as same");

            }

            if (classAvg == "100" && UserAvg == "100")
            {
                GenericHelper.Logs(" class avg is " + classAvg + " and user avg is " + UserAvg + " both are displayed as excepted ", "PASSED");
            }
            else
            {
                GenericHelper.Logs(" class avg is " + classAvg + " and user avg is " + UserAvg + " both are not displayed as excepted(classavg and useravg = 100) ", "FAILED");
                throw new Exception(" class avg is " + classAvg + " and user avg is " + UserAvg + " both are not displayed as excepted(classavg and useravg = 100) ");
            }
            WebDriver.Close();
            GenericHelper.SelectWindow("Reports");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose:  Step Definition To generate report by selecting two study plan
        [Then(@"I generate report by selecting two study plan")]
        public void ThenIGenerateReportBySelectingTwoStudyPlan()
        {
            try 
            {
            GenericHelper.SelectWindow("Reports");
            _rptGcOptionsUxPage.ClickSelectStudyPlans();

            GenericHelper.SelectWindow("Select Study Plan");

            string sp1 = DatabaseTools.GetActivityName(Enumerations.ActivityType.Sp1With3Rem);
            _rptSelectAssessmentsPage.SelectStudyPlan(sp1);
            string sp2 = DatabaseTools.GetActivityName(Enumerations.ActivityType.Sp2With3Rem);
            _rptSelectAssessmentsPage.SelectStudyPlan(sp2);

            _rptSelectAssessmentsPage.ClickAddButton();

            GenericHelper.SelectWindow("Reports");
            string stu = DatabaseTools.GetUsername(Enumerations.UserType.CsSmsStudent);//"SMSUSER";//

            _rptGcOptionsUxPage.ClickSelectStudents();
            GenericHelper.SelectWindow("Select Students");
            _rptSelectStudentsPage.SelectStudent(stu);
            _rptSelectStudentsPage.ClickAddButton();

            _rptCommonCriteriaPage.RunReport();

            GenericHelper.WaitUtilWindow("Study Plan Results");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

        //Purpose:  Step Definition To verify Study Material Average at both Class level and User level should display the different values
        [Then(@"Study Material Average at both Class level and User level should display the different values")]
        public void ThenStudyMaterialAverageAtBothClassLevelAndUserLevelShouldDisplayTheDifferentValues()
        {
            try 
            {
            GenericHelper.SelectWindow("Study Plan Results");
            string classAvg = _reportsDrtModulePage.GetClassAvg();
            string UserAvg = _reportsDrtModulePage.GetUserAvg();
            if ((Convert.ToDecimal(classAvg))!= (Convert.ToDecimal(UserAvg)))
            {
                GenericHelper.Logs(" class avg is " + classAvg + " and user avg is " + UserAvg + " both are displayed as different ", "PASSED");
            }
            else
            {
                GenericHelper.Logs(" class avg is " + classAvg + " and user avg is " + UserAvg + " both are not displayed as different", "FAILED");
                throw new Exception(" class avg is " + classAvg + " and user avg is " + UserAvg +
                                    " both are not displayed as different");
            }

            if (classAvg=="11.1" && UserAvg=="66.7")
            {
                GenericHelper.Logs(" class avg is " + classAvg + " and user avg is " + UserAvg + " both are displayed as excepted ", "PASSED");
            }
            else
            {
                GenericHelper.Logs(" class avg is " + classAvg + " and user avg is " + UserAvg + " both are not displayed as excepted(classavg=11.1,useravg=66.7)", "FAILED");
                throw new Exception(" class avg is " + classAvg + " and user avg is " + UserAvg +
                                    "both are not displayed as excepted(classavg=11.1,useravg=66.7)");
            }

            string classAvg1 = _reportsDrtModulePage.GetClassAvgOfSecondSp();
            string UserAvg1 = _reportsDrtModulePage.GetUserAvgOfSecondSp();

            if ((Convert.ToDecimal(classAvg1)) != (Convert.ToDecimal(UserAvg1)))
            {
                GenericHelper.Logs(" class avg is " + classAvg1 + " and user avg is " + UserAvg1 + " both are displayed as different for 2nd study plan", "PASSED");
            }
            else
            {
                GenericHelper.Logs(" class avg is " + classAvg1 + " and user avg is " + UserAvg1 + " both are not displayed as different for 2nd study plan", "FAILED");
                throw new Exception(" class avg is " + classAvg1 + " and user avg is " + UserAvg1 +
                                    " both are not displayed as different");
            }

            if (classAvg1 == "11.1" && UserAvg1 == "66.7")
            {
                GenericHelper.Logs(" class avg is " + classAvg1 + " and user avg is " + UserAvg1 + " both are displayed as excepted for 2nd study plan", "PASSED");
            }
            else
            {
                GenericHelper.Logs(" class avg is " + classAvg1 + " and user avg is " + UserAvg1 + " both are not displayed as excepted(classavg=11.1,useravg=66.7) for 2nd study plan", "FAILED");
                throw new Exception(" class avg is " + classAvg1 + " and user avg is " + UserAvg1 +
                                    " both are not displayed as excepted(classavg=11.1,useravg=66.7) for 2nd study plan");
            }
            WebDriver.Close();
            GenericHelper.SelectWindow("Reports");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Assert.Fail(e.ToString());
            }
        }

    }
}
