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
    public partial class CourseSpaceInstructorViewSubmissionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceInstructor.Workflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceInstructorViewSubmission", "As a CS Instructor \r\n\t\t\tI want to manage all the coursespace instructor workflow " +
                    "related usecases \r\n\t\t\tso that I would validate all the coursespace instructor wo" +
                    "rkflow related scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceInstructorViewSubmission")))
            {
                Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestFeatures.CourseSpaceInstructorViewSubmissionFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Set Time limit for SIM Study Plan Pre test as SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorViewSubmission")]
        public virtual void SetTimeLimitForSIMStudyPlanPreTestAsSMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Set Time limit for SIM Study Plan Pre test as SMS Instructor", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Add from Library\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.And("I should see \"SIM5StudyPlan\" activity in the Content Library Frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
testRunner.When("I click on \"Edit\" cmenu option of activity in \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
testRunner.And("I edit the \"PreTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
testRunner.Then("I should be on the \"Create Pre-test:\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
testRunner.When("I Click on \"Preferences\" Tab of Edit SIM PreTest", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.And("I enter \"02\" minute in Set time limit for activity preference", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.Then("I should see the successfull message \"Myitlab Study Plan updated successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Set Feedback Preference for Test with Basic Random Activity By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorViewSubmission")]
        public virtual void ToSetFeedbackPreferenceForTestWithBasicRandomActivityBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Set Feedback Preference for Test with Basic Random Activity By SMS Instructor", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
testRunner.And("I should see \"Test\" activity in the Content Library Frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
testRunner.When("I click on \"Edit\" cmenu option of activity in \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
testRunner.And("I set the feedback correct answer preference", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.Then("I should see the successfull message \"Activity updated successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor assign the asset with duedate in Managecoursework")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorViewSubmission")]
        public virtual void InstructorAssignTheAssetWithDuedateInManagecoursework()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor assign the asset with duedate in Managecoursework", ((string[])(null)));
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Course Materials\" subta" +
                    "b", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
testRunner.When("I navigate to \"Excel Chapter 1 Project 1A Skill-Based Training\" asset in \"Course " +
                    "Materials\" tab as \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.And("I click on \"SetSchedulingOptions\" option in c menu of \"Excel Chapter 1 Project 1A" +
                    " Skill-Based Training\" asset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
testRunner.Then("I should be on the \"Properties\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
testRunner.When("I assign asset with due date and save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
testRunner.Then("I should see the successfull message \"Properties updated successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
testRunner.And("I should see assigned icon for \"Excel Chapter 1 Project 1A Skill-Based Training\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
testRunner.When("I navigate to \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor assign the assets with duedate,startdate and endate in Managecoursewor" +
            "k")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorViewSubmission")]
        public virtual void InstructorAssignTheAssetsWithDuedateStartdateAndEndateInManagecoursework()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor assign the assets with duedate,startdate and endate in Managecoursewor" +
                    "k", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Course Materials\" subta" +
                    "b", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
testRunner.When("I navigate to \"Excel Chapter 1 Project 1A Skill-Based Training\" asset in \"Course " +
                    "Materials\" tab as \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
testRunner.When("I click on \"SetSchedulingOptions\" option in c menu of \"Excel Chapter 1 Project 1A" +
                    " Skill-Based Exam (Scenario 1)\" asset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
testRunner.Then("I should be on the \"Properties\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
testRunner.When("I assign and schedule the asset and save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
testRunner.Then("I should see the successfull message \"Properties updated successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
testRunner.And("I should see assigned icon for \"Excel Chapter 1 Project 1A Skill-Based Exam (Scen" +
                    "ario 1)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
testRunner.And("I should see scheduled icon for \"Excel Chapter 1 Project 1A Skill-Based Exam (Sce" +
                    "nario 1)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor validating the grade of student in view submission page By Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorViewSubmission")]
        public virtual void InstructorValidatingTheGradeOfStudentInViewSubmissionPageByInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor validating the grade of student in view submission page By Instructor", ((string[])(null)));
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Course Materials\" subta" +
                    "b", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
testRunner.When("I select \"Word Chapter 1 Grader Project [Assessment 3]\" in \"Course Materials\" by " +
                    "\"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
testRunner.And("I click on \"ViewSubmissions\" option in c menu of \"Word Chapter 1 Grader Project [" +
                    "Assessment 3]\" asset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
testRunner.Then("I should see the \"100\" score in view submission page for a \"ZeroScore\" with \"CsSm" +
                    "sStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
testRunner.And("I close the \"View Submission\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
