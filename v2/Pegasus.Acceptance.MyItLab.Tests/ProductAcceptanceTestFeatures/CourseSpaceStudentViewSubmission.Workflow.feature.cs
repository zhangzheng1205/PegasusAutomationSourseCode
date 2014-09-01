﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.1.84
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.17929
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.1.84")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceStudentViewSubmissionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceStudentViewSubmission.Workflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceStudentViewSubmission", "\t\t\tAs a CS Student \r\n\t\t\tI want to manage all the coursespace student Submission r" +
                    "elated usecases \r\n\t\t\tso that I would validate all the coursespace student Submis" +
                    "sion scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceStudentViewSubmission")))
            {
                Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestFeatures.CourseSpaceStudentViewSubmissionFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the Basic Random Activity of “Submit for grading” button in presentation w" +
            "indow By SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentViewSubmission")]
        public virtual void VerifyTheBasicRandomActivityOfSubmitForGradingButtonInPresentationWindowBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the Basic Random Activity of “Submit for grading” button in presentation w" +
                    "indow By SMS Student", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
testRunner.When("I open the activity named as \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
testRunner.And("I submit the \"Test\" activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
testRunner.Then("I should see the \"Feedback\" in the \'Test Presentation Page\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
testRunner.When("I close the Test Presentation Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.Then("I should see the \"Passed\" status of the \"Test\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To verify the functionality of View Submission status of Activity in student side" +
            " By SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentViewSubmission")]
        public virtual void ToVerifyTheFunctionalityOfViewSubmissionStatusOfActivityInStudentSideBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To verify the functionality of View Submission status of Activity in student side" +
                    " By SMS Student", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.When("I open the activity named as \"HomeWork\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.And("I submit the activity \"HomeWork\" save for later", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
testRunner.Then("I should see the \"In Progress\" status of the \"HomeWork\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
testRunner.And("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.When("I navigate to the \"Grades\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
testRunner.And("I click on cmenu \"View Submissions\" of asset \"HomeWork\" in grades tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
testRunner.And("I should see the message \"Activity has been started and saved for later but not y" +
                    "et submitted.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Status of Manual Gradable Activity By SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentViewSubmission")]
        public virtual void StatusOfManualGradableActivityBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Status of Manual Gradable Activity By SMS Student", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
testRunner.And("I should see the \"Not started\" status of the \"Quiz\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
testRunner.When("I open the activity named as \"Quiz\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
testRunner.And("I submit the activity \"Quiz\" save for later", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
testRunner.Then("I should see the \"In Progress\" status of the \"Quiz\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
testRunner.When("I open the activity named as \"Quiz\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
testRunner.And("I submit the manual gradable \"Quiz\" activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
testRunner.Then("I should see the \"Submitted\" status of the \"Quiz\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Check the Status of Edited Instructor Manual Gradable Activity By SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentViewSubmission")]
        public virtual void CheckTheStatusOfEditedInstructorManualGradableActivityBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Check the Status of Edited Instructor Manual Gradable Activity By SMS Student", ((string[])(null)));
#line 50
this.ScenarioSetup(scenarioInfo);
#line 51
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
testRunner.And("I should see the \"Passed\" status of the \"Quiz\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sim5 assessment launch when \"Trap ALT + TAB\" is disabled")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentViewSubmission")]
        public virtual void Sim5AssessmentLaunchWhenTrapALTTABIsDisabled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sim5 assessment launch when \"Trap ALT + TAB\" is disabled", ((string[])(null)));
#line 57
this.ScenarioSetup(scenarioInfo);
#line 58
testRunner.When("I navigate to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
testRunner.When("I open the activity named as \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
testRunner.Then("I should see the activity successfully launched in browser normal mode", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
testRunner.When("I close the \"Launch\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To verify the attempts for past due activity by SMS student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentViewSubmission")]
        public virtual void ToVerifyTheAttemptsForPastDueActivityBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To verify the attempts for past due activity by SMS student", ((string[])(null)));
#line 65
this.ScenarioSetup(scenarioInfo);
#line 66
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
testRunner.When("I launch the activity named as \"Chapter 1 Check Your Understanding: Part 1\" in Co" +
                    "urse Materials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
testRunner.Then("I should be on the \"Objective-Based Question Only\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
testRunner.And("I should see the message \"This activity is past due.\" in activity presentation pa" +
                    "ge", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
testRunner.When("I submit the past due \"Objective-Based Question Only\" activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
testRunner.Then("I should see the message \"You submitted this activity after the due date. Your in" +
                    "structor must accept the submission before it is included in the gradebook or co" +
                    "unted in any course scores.\" in activity presentation page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
testRunner.And("I should return to parent window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To verify the functionality of View Submission status of Activity  for save for l" +
            "ater in student side By SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentViewSubmission")]
        public virtual void ToVerifyTheFunctionalityOfViewSubmissionStatusOfActivityForSaveForLaterInStudentSideBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To verify the functionality of View Submission status of Activity  for save for l" +
                    "ater in student side By SMS Student", ((string[])(null)));
#line 77
this.ScenarioSetup(scenarioInfo);
#line 79
testRunner.When("I navigate to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
testRunner.When("I open the activity named as \"ObjectiveBasedQuestionOnly\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
testRunner.And("I submit the activity \"ObjectiveBasedQuestionOnly\" for save for later", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
testRunner.Then("I should see the \"In Progress\" status of the \"ObjectiveBasedQuestionOnly\" activit" +
                    "y type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
testRunner.When("I click on cmenu \"ViewSubmissions\" of asset \"ObjectiveBasedQuestionOnly\" for save" +
                    " for later", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 86
testRunner.When("I click on submission list for save for later", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
testRunner.Then("I should see the message \"Activity has been started and saved for later but not y" +
                    "et submitted.\" for save for later", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
testRunner.And("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
testRunner.When("I navigate to the \"Assignments\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 92
testRunner.When("I click on cmenu \"ViewSubmissions\" of asset \"ObjectiveBasedQuestionOnly\" for save" +
                    " for later", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
testRunner.When("I click on submission list for save for later", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
testRunner.Then("I should see the message \"Activity has been started and saved for later but not y" +
                    "et submitted.\" for save for later", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 96
testRunner.And("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
testRunner.When("I navigate to the \"To Do\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 99
testRunner.Then("I should be on the \"Assignments - To Do\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 100
testRunner.When("I click on cmenu \"ViewSubmissions\" of asset \"ObjectiveBasedQuestionOnly\" for save" +
                    " for later", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 101
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
testRunner.When("I click on submission list for save for later", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
testRunner.Then("I should see the message \"Activity has been started and saved for later but not y" +
                    "et submitted.\" for save for later", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 104
testRunner.And("I should be on the \"Assignments - To Do\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Student validating score in gradebook for SIM5 Excel activity By SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentViewSubmission")]
        public virtual void StudentValidatingScoreInGradebookForSIM5ExcelActivityBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Student validating score in gradebook for SIM5 Excel activity By SMS Student", ((string[])(null)));
#line 109
this.ScenarioSetup(scenarioInfo);
#line 110
testRunner.When("I navigate to \"Grades\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 111
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 112
testRunner.When("I select \"Excel Chapter 1 Skill-Based Training\" in \"Gradebook\" by \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
testRunner.Then("I should see the activity \"Excel Chapter 1 Skill-Based Training\" score \"100\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 114
testRunner.When("I click on cmenu \"View Submissions\" of asset \"Excel Chapter 1 Skill-Based Trainin" +
                    "g\" in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 115
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 116
testRunner.And("I should see \"100\" score in view submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
testRunner.When("I close the \"View Submission\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
testRunner.Then("I click on \'My Course\' link in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Student validating score in gradebook for SIM5 PowerPoint activity By SMS Student" +
            "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentViewSubmission")]
        public virtual void StudentValidatingScoreInGradebookForSIM5PowerPointActivityBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Student validating score in gradebook for SIM5 PowerPoint activity By SMS Student" +
                    "", ((string[])(null)));
#line 123
this.ScenarioSetup(scenarioInfo);
#line 124
testRunner.When("I navigate to \"Grades\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 125
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 126
testRunner.When("I select \"PowerPoint Chapter 1 Skill-Based Training\" in \"Gradebook\" by \"CsSmsStud" +
                    "ent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 127
testRunner.Then("I should see the activity \"PowerPoint Chapter 1 Skill-Based Training\" score \"100\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
testRunner.When("I click on cmenu \"View Submissions\" of asset \"PowerPoint Chapter 1 Skill-Based Tr" +
                    "aining\" in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 129
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
testRunner.And("I should see \"100\" score in view submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
testRunner.When("I close the \"View Submission\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 132
testRunner.Then("I click on \'My Course\' link in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Student validating score in gradebook for SIM5 Word activity By SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentViewSubmission")]
        public virtual void StudentValidatingScoreInGradebookForSIM5WordActivityBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Student validating score in gradebook for SIM5 Word activity By SMS Student", ((string[])(null)));
#line 137
this.ScenarioSetup(scenarioInfo);
#line 138
testRunner.When("I navigate to \"Grades\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 139
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 140
testRunner.When("I select \"Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)\" in \"Gradebook\"" +
                    " by \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 141
testRunner.Then("I should see the activity \"Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1" +
                    ")\" score \"0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 142
testRunner.When("I click on cmenu \"View Submissions\" of asset \"Word Chapter 1 Project 1A Skill-Bas" +
                    "ed Exam (Scenario 1)\" in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 143
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 144
testRunner.And("I should see \"0\" score in view submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 145
testRunner.When("I close the \"View Submission\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 146
testRunner.Then("I click on \'My Course\' link in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Student validating score in gradebook for SIM5 Access activity By SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentViewSubmission")]
        public virtual void StudentValidatingScoreInGradebookForSIM5AccessActivityBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Student validating score in gradebook for SIM5 Access activity By SMS Student", ((string[])(null)));
#line 151
this.ScenarioSetup(scenarioInfo);
#line 152
testRunner.When("I navigate to \"Grades\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 153
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 154
testRunner.When("I select \"Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)\" in \"Gradeboo" +
                    "k\" by \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 155
testRunner.Then("I should see the activity \"Access Chapter 1 Project 1A Skill-Based Exam (Scenario" +
                    " 1)\" score \"100\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 156
testRunner.When("I click on cmenu \"View Submissions\" of asset \"Access Chapter 1 Project 1A Skill-B" +
                    "ased Exam (Scenario 1)\" in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 157
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 158
testRunner.And("I should see \"100\" score in view submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
testRunner.When("I close the \"View Submission\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 160
testRunner.Then("I click on \'My Course\' link in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
