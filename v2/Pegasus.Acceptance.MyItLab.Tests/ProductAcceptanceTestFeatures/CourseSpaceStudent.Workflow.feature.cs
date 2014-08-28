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
namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceStudentSubmissionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceStudent.Workflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceStudent Submission", "                As a CS Student \r\n\t\t\tI want to manage all the coursespace student" +
                    " Submission related usecases \r\n\t\t\tso that I would validate all the coursespace s" +
                    "tudent Submission scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceStudent Submission")))
            {
                Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestFeatures.CourseSpaceStudentSubmissionFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Activity Submission Inside Instructor Course by SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent Submission")]
        public virtual void ActivitySubmissionInsideInstructorCourseBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Activity Submission Inside Instructor Course by SMS Student", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.When("I submit the \"SIM5Activity\" activity of behavioral mode \"SkillBased\" type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
testRunner.Then("I should see the \"Passed\" status of the \"SIM5Activity\" activity of behavioral mod" +
                    "e \"SkillBased\" type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Check The Student Launch The SIM study Plan PreTest by SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent Submission")]
        public virtual void ToCheckTheStudentLaunchTheSIMStudyPlanPreTestBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Check The Student Launch The SIM study Plan PreTest by SMS Student", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
testRunner.When("I submit the \"SIM5StudyPlan\" pretest activity of behavioral mode type \"SkillBased" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
testRunner.Then("I should see the \"In Progress\" status of the \"SIM5StudyPlan\" activity of behavior" +
                    "al mode \"SkillBased\" type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To check the Student : SIM study Plan  launch (Skill based) and display of Total " +
            "time taken in VS Page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent Submission")]
        public virtual void ToCheckTheStudentSIMStudyPlanLaunchSkillBasedAndDisplayOfTotalTimeTakenInVSPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To check the Student : SIM study Plan  launch (Skill based) and display of Total " +
                    "time taken in VS Page", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
testRunner.When("I open the \"SIM5StudyPlan\" Activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
testRunner.Then("I should be on the \"myitlab Study Plan\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
testRunner.When("I click on Start Pre test button of SIM Study Plan by SMS Student", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
testRunner.And("I Submit the SIM Study Plan \"Sim5PreTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
testRunner.Then("I should see the \"In Progress\" status of the \"SIM5StudyPlan\" activity of behavior" +
                    "al mode \"SkillBased\" type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Check The Student Launch The SIM study Plan Trainig Material by SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent Submission")]
        public virtual void ToCheckTheStudentLaunchTheSIMStudyPlanTrainigMaterialBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Check The Student Launch The SIM study Plan Trainig Material by SMS Student", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
testRunner.When("I submit the \"SIM5StudyPlan\" activity of behavioral mode type \"SkillBased\" using " +
                    "Training Material", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
testRunner.Then("I should see the \"In Progress\" status of the \"SIM5StudyPlan\" activity of behavior" +
                    "al mode \"SkillBased\" type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Display Grades in Gradebook")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent Submission")]
        public virtual void DisplayGradesInGradebook()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Display Grades in Gradebook", ((string[])(null)));
#line 47
this.ScenarioSetup(scenarioInfo);
#line 48
testRunner.When("I navigate to \"Grades\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
testRunner.When("I click on the \"SIM5StudyPlan\" \'View Grades\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
testRunner.Then("I should see the pre test \"Sim5PreTest\" score \"0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
testRunner.When("I click on cmenu \"View Submissions\" of asset \"Sim5PreTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
testRunner.And("I should the status of submitted SIM5 activity question as \"Incomplete\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
testRunner.When("I close the \"View Submission\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Display of View Grades for Students Training materials")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent Submission")]
        public virtual void DisplayOfViewGradesForStudentsTrainingMaterials()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Display of View Grades for Students Training materials", ((string[])(null)));
#line 60
this.ScenarioSetup(scenarioInfo);
#line 61
testRunner.When("I navigate to \"Grades\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 63
testRunner.When("I click on the \"SIM5StudyPlan\" \'View Grades\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
testRunner.Then("I should see the pre test training \"Sim5PreTest\" score \"100\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Student launches a Sim 5 Excel activity and Student scoring a 100% compares the r" +
            "esult and status")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent Submission")]
        public virtual void StudentLaunchesASim5ExcelActivityAndStudentScoringA100ComparesTheResultAndStatus()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Student launches a Sim 5 Excel activity and Student scoring a 100% compares the r" +
                    "esult and status", ((string[])(null)));
#line 69
this.ScenarioSetup(scenarioInfo);
#line 70
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
testRunner.When("I select \"Excel Chapter 1 Skill-Based Training\" in \"Course Materials\" by \"CsSmsSt" +
                    "udent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
testRunner.And("I launch the activity named as \"Excel Chapter 1 Skill-Based Training\" in Course M" +
                    "aterials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
testRunner.And("I should answer activity \"Excel Chapter 1 Skill-Based Training\" correctly and cli" +
                    "ck on Submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
testRunner.When("I click on cmenu \"ViewSubmissions\" of asset \"Excel Chapter 1 Skill-Based Training" +
                    "\" with mode \"SkillBased\" in Course Materials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 78
testRunner.When("I click on the last submission", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
testRunner.Then("I should see the grade is \"7.41%\" in View Submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sim 5 excel activity and Student scoring a Zero.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent Submission")]
        public virtual void Sim5ExcelActivityAndStudentScoringAZero_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sim 5 excel activity and Student scoring a Zero.", ((string[])(null)));
#line 86
this.ScenarioSetup(scenarioInfo);
#line 87
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
testRunner.When("I select \"Excel Chapter 1 Skill-Based Training\" in \"Course Materials\" by \"CsSmsSt" +
                    "udent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
testRunner.And("I launch the activity named as \"Excel Chapter 1 Skill-Based Training\" in Course M" +
                    "aterials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
testRunner.And("I click on submit button answering incorrectly of \"Excel\" type \"Training\" mode ac" +
                    "tivity \"Excel Chapter 1 Skill-Based Training\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
testRunner.And("I should see \"Not passed\" status for the activity \"Excel Chapter 1 Skill-Based Tr" +
                    "aining\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
testRunner.And("I should see \"0.00%\" score for the activity \"Excel Chapter 1 Skill-Based Training" +
                    "\" in course material page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Student scoring 0 in SIM5 Word activity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent Submission")]
        public virtual void StudentScoring0InSIM5WordActivity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Student scoring 0 in SIM5 Word activity", ((string[])(null)));
#line 101
this.ScenarioSetup(scenarioInfo);
#line 102
testRunner.When("I select \"Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)\" in \"Course Mat" +
                    "erials\" by \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
testRunner.And("I launch the activity named as \"Word Chapter 1 Project 1A Skill-Based Exam (Scena" +
                    "rio 1)\" in Course Materials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
testRunner.And("I click on submit button answering incorrectly of \"Word\" type \"Exam\" mode activit" +
                    "y \"Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 106
testRunner.And("I should see \"Not passed\" status for the activity \"Word Chapter 1 Project 1A Skil" +
                    "l-Based Exam (Scenario 1)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
testRunner.And("I should see \"0.00%\" score for the activity \"Word Chapter 1 Project 1A Skill-Base" +
                    "d Exam (Scenario 1)\" in course material page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Student scoring 0 in SIM5 PowerPoint activity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent Submission")]
        public virtual void StudentScoring0InSIM5PowerPointActivity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Student scoring 0 in SIM5 PowerPoint activity", ((string[])(null)));
#line 115
this.ScenarioSetup(scenarioInfo);
#line 116
testRunner.When("I select \"PowerPoint Chapter 1 Skill-Based Training\" in \"Course Materials\" by \"Cs" +
                    "SmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 117
testRunner.And("I launch the activity named as \"PowerPoint Chapter 1 Skill-Based Training\" in Cou" +
                    "rse Materials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
testRunner.And("I click on submit button answering incorrectly of \"PowerPoint\" type \"Training\" mo" +
                    "de activity \"PowerPoint Chapter 1 Skill-Based Training\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
testRunner.And("I should see \"Not passed\" status for the activity \"PowerPoint Chapter 1 Skill-Bas" +
                    "ed Training\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
testRunner.And("I should see \"0.00%\" score for the activity \"PowerPoint Chapter 1 Skill-Based Tra" +
                    "ining\" in course material page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Student scoring 0 in SIM5 Access activity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent Submission")]
        public virtual void StudentScoring0InSIM5AccessActivity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Student scoring 0 in SIM5 Access activity", ((string[])(null)));
#line 129
this.ScenarioSetup(scenarioInfo);
#line 130
testRunner.When("I select \"Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)\" in \"Course M" +
                    "aterials\" by \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 131
testRunner.And("I launch the activity named as \"Access Chapter 1 Project 1A Skill-Based Exam (Sce" +
                    "nario 1)\" in Course Materials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
testRunner.And("I click on submit button answering incorrectly of \"Access\" type \"Exam\" mode activ" +
                    "ity \"Access Chapter 1 Project 1A Skill-Based Exam (Scenario 1)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 134
testRunner.And("I should see \"Not passed\" status for the activity \"Access Chapter 1 Project 1A Sk" +
                    "ill-Based Exam (Scenario 1)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
testRunner.And("I should see \"0.00%\" score for the activity \"Access Chapter 1 Project 1A Skill-Ba" +
                    "sed Exam (Scenario 1)\" in course material page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
