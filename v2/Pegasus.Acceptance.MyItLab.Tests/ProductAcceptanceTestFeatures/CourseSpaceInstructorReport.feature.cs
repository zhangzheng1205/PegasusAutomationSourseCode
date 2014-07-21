﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.3.0
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18408
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceInstructorReportFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceInstructorReport.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceInstructorReport", "               As a CS Instructor \r\n\t\t\tI want to manage all the coursespace instr" +
                    "uctor report related usecases \r\n\t\t\tso that I would validate all the coursespace " +
                    "instructor report related scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceInstructorReport")))
            {
                Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestFeatures.CourseSpaceInstructorReportFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Activity Results for Single Student by Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorReport")]
        public virtual void ActivityResultsForSingleStudentByProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Activity Results for Single Student by Program Admin", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
testRunner.When("I navigate to \"Reports\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
testRunner.When("I click on \"Activity Results (Single Student)\" report in \'Activity Reports\' panel" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
testRunner.And("I select options to generate report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
testRunner.And("I click on the \"Run Report\" button in reports", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
testRunner.Then("I should see the score \"100\" of \"SIM5Activity\" activity of behavioral mode \"Skill" +
                    "Based\" type under launched report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Save and Run functionality for Study Plan single student report")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorReport")]
        public virtual void SaveAndRunFunctionalityForStudyPlanSingleStudentReport()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Save and Run functionality for Study Plan single student report", ((string[])(null)));
#line 20
this.ScenarioSetup(scenarioInfo);
#line 21
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
testRunner.When("I navigate to \"Reports\" tab of the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
testRunner.Then("I should be on the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
testRunner.When("I click on \'Study Plan Single Student\' report link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
testRunner.And("I select options to create \'Study Plan Single Student\' report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
testRunner.And("I click on \"Run Report\" button in reports", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.Then("I should be on the \"Save settings to My Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
testRunner.When("I select \"Createnewreport\" radiobutton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
testRunner.And("I enter the \"HedMilStudyPlanSingleStudent\" report name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
testRunner.And("I click on \"SaveOnly\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
testRunner.Then("I should see the \"Save settings to My Reports\" popup closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
testRunner.When("I click on \"Cancel\" button in reports", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.Then("I should see the \"HedMilStudyPlanSingleStudent\" report in \'My Reports\' grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
testRunner.When("I click on \'Study Plan Single Student\' report link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
testRunner.And("I select options to create \'Study Plan Single Student\' report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
testRunner.And("I click on \"Run Report\" button in reports", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
testRunner.Then("I should be on the \"Save settings to My Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
testRunner.When("I select \"Replaceexistingreport\" radiobutton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.Then("I should see \"HedMilStudyPlanSingleStudent\" report in dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
testRunner.When("I click on \"Cancel\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To verify the functionality of \"Run Report\" button in the Options Page (with vali" +
            "d details added in the fields provided)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorReport")]
        public virtual void ToVerifyTheFunctionalityOfRunReportButtonInTheOptionsPageWithValidDetailsAddedInTheFieldsProvided()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To verify the functionality of \"Run Report\" button in the Options Page (with vali" +
                    "d details added in the fields provided)", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
testRunner.When("I navigate to \"Reports\" tab of the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
testRunner.Then("I should be on the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
testRunner.When("I click on \"TrainingFrequencyAnalysis\" report type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
testRunner.And("I enter the valid data in the fields to \'Training Frequency Analysis\' generate re" +
                    "port", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
testRunner.And("I select \'save settings to My Reports\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
testRunner.And("I click on \"Run Report\" button in reports", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
testRunner.Then("I should be on the \"Save settings to My Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
testRunner.When("I select \"Createnewreport\" radiobutton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
testRunner.And("I enter the \"MyItLabTrainingFrequencyAnalysis\" report name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
testRunner.And("I click on \"SaveandRun\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
testRunner.Then("I should see the \"Save settings to My Reports\" popup closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
testRunner.And("I should see the score \"100\" in generated report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
testRunner.When("I close the \"Training Frequency Analysis\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
testRunner.And("I click on \"Cancel\" button in reports", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
testRunner.Then("I should see the \"MyItLabTrainingFrequencyAnalysis\" report in \'My Reports\' grid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Activity Results for Single Student by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorReport")]
        public virtual void ActivityResultsForSingleStudentBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Activity Results for Single Student by SMS Instructor", ((string[])(null)));
#line 68
this.ScenarioSetup(scenarioInfo);
#line 69
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
testRunner.When("I navigate to \"Reports\" tab of the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
testRunner.Then("I should be on the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
testRunner.When("I click on \"ActivityResultsSingleStudent\" report type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
testRunner.And("I select options to generate report by instructor for \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
testRunner.And("I click on \"Run Report\" button in reports", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
testRunner.Then("I should see the score \"100\" in Activity Result Single Student generated report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
testRunner.When("I close the \"Activity Results (Single Student)\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To verify the functionality of \"Most Recent\" radio button by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorReport")]
        public virtual void ToVerifyTheFunctionalityOfMostRecentRadioButtonBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To verify the functionality of \"Most Recent\" radio button by SMS Instructor", ((string[])(null)));
#line 82
this.ScenarioSetup(scenarioInfo);
#line 83
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 85
testRunner.When("I navigate to \"Reports\" tab of the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 86
testRunner.Then("I should be on the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 87
testRunner.When("I click on \"ExamFrequencyAnalysis\" report type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
testRunner.And("I enter the exam frequency analysis valid data in the fields to generate report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
testRunner.And("I click on \"Run Report\" button in reports", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
testRunner.Then("I should see the score \"100\" in Exam Frequency Analysis generated report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 91
testRunner.When("I close the \"Exam Frequency Analysis\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Certificate of Competition Exam based PADMIN")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorReport")]
        public virtual void CertificateOfCompetitionExamBasedPADMIN()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Certificate of Competition Exam based PADMIN", ((string[])(null)));
#line 96
this.ScenarioSetup(scenarioInfo);
#line 97
testRunner.When("I navigate to \"Reports\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
testRunner.When("I click on \"Certificate of Completion (Exam)\" certificate report in \'Activity Rep" +
                    "orts\' panel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
testRunner.And("I select options for \'Certificate of Completion Exam\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
testRunner.And("I click on the \"Run Report\" button in reports", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
testRunner.Then("I should be on the \"Certificate of Completion (Exam)\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
testRunner.And("I should see the exam score \"100.00%\" in \'Certificate of Completion Exam\' page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
testRunner.When("I close the \"Certificate of Completion (Exam)\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Certificate of Competition Training based By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorReport")]
        public virtual void CertificateOfCompetitionTrainingBasedBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Certificate of Competition Training based By SMS Instructor", ((string[])(null)));
#line 109
this.ScenarioSetup(scenarioInfo);
#line 110
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 111
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 112
testRunner.When("I navigate to \"Reports\" tab of the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
testRunner.Then("I should be on the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 114
testRunner.When("I click on \"CertificateofCompletionTraining\" certificate type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 115
testRunner.And("I enter the valid data in the fields to generate certificate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
testRunner.And("I click on \"Run Report\" button in reports", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
testRunner.Then("I should see the training score \"100.00%\" in \'Certificate of Completion Training\'" +
                    " certificate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 118
testRunner.When("I close the \"Certificate of Completion (Training)\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Certificate of Competition Exam based By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorReport")]
        public virtual void CertificateOfCompetitionExamBasedBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Certificate of Competition Exam based By SMS Instructor", ((string[])(null)));
#line 122
this.ScenarioSetup(scenarioInfo);
#line 123
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
testRunner.When("I navigate to \"Reports\" tab of the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 126
testRunner.Then("I should be on the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 127
testRunner.When("I click on \"CertificateofCompletionExam\" certificate type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 128
testRunner.And("I enter the valid data in the fields to generate certificate for Exam report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
testRunner.And("I click on \"Run Report\" button in reports", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
testRunner.Then("I should see the exam score \"100.00%\" in \'Certificate of Completion Exam\' page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 131
testRunner.When("I close the \"Certificate of Completion (Exam)\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
