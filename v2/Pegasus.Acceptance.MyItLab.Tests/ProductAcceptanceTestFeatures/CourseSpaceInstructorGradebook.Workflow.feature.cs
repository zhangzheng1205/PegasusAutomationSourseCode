﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34003
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceInstructorGradebookFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceInstructorGradebook.Workflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceInstructorGradebook", "               As a Cs Instructor \r\n\t\t\tI want to manage all the coursespace Grade" +
                    "book related usecases \r\n\t\t\tso that I would validate all the coursespace Instruct" +
                    "or Gradebook scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceInstructorGradebook")))
            {
                Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestFeatures.CourseSpaceInstructorGradebookFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Display of Grades in the Gradebook By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorGradebook")]
        public virtual void DisplayOfGradesInTheGradebookBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Display of Grades in the Gradebook By SMS Instructor", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
testRunner.When("I search the \"MyItLabProgramCourse\" first section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
testRunner.And("I click the \"Enter Section as Instructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
testRunner.When("I navigate to the \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
testRunner.And("I should see the score \"100\" of \"SIM5Activity\" activity of behavioral mode \"Skill" +
                    "Based\" type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
testRunner.When("I select \'Home\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Associate Activity From Course Materials Frame To MyCourse")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorGradebook")]
        public virtual void AssociateActivityFromCourseMaterialsFrameToMyCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Associate Activity From Course Materials Frame To MyCourse", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
testRunner.When("I associate the \"SIM5Activity\" activity of behavioral mode \"SkillBased\" to MyCour" +
                    "se frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
testRunner.Then("I should see the successfull message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Associate SIM5 Studyplan From Course Materials Frame To MyCourse")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorGradebook")]
        public virtual void AssociateSIM5StudyplanFromCourseMaterialsFrameToMyCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Associate SIM5 Studyplan From Course Materials Frame To MyCourse", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
testRunner.When("I associate the \"SIM5StudyPlan\" activity of behavioral mode \"SkillBased\" to MyCou" +
                    "rse frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
testRunner.Then("I should see the successfull message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the functionality of \"Apply Grade schema\" in Gradebook by SmsInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorGradebook")]
        public virtual void VerifyTheFunctionalityOfApplyGradeSchemaInGradebookBySmsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the functionality of \"Apply Grade schema\" in Gradebook by SmsInstructor", ((string[])(null)));
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
testRunner.When("I navigate to \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
testRunner.When("I click on view grade \"SIM5StudyPlan\" of behavioral mode type \"SkillBased\" in Gra" +
                    "debook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
testRunner.And("I click on cmenu \"ApplyGradeSchema\" of studyplan Training Material \"Sim5PreTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
testRunner.Then("I should be on the \"Gradebook schema\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
testRunner.When("I \'Apply\' the grade schema for the submitted activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
testRunner.Then("I should see the successfull message \"Schema applied successfully.\" in \"Gradebook" +
                    "\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
testRunner.And("I should see the \"Sim5PreTest\" activity status \"A\" in Gradebook for all the enrol" +
                    "lled \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
testRunner.When("I click on cmenu \"ModifyGradeSchema\" of studyplan Training Material \"Sim5PreTest\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
testRunner.And("I update the schema of the submitted activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
testRunner.Then("I should see the successfull message \"Schema applied successfully.\" in \"Gradebook" +
                    "\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
testRunner.When("I click on cmenu \"RemoveGradeSchema\" of studyplan Training Material \"Sim5PreTest\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
testRunner.Then("I should see the successfull message \"Grade schema removed successfully.\" in \"Gra" +
                    "debook\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
testRunner.And("I should see the \"Sim5PreTest\" activity status \"100\" in Gradebook for all the enr" +
                    "ollled \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Edit Grade in View Submission for Manual Gradable Activity By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorGradebook")]
        public virtual void EditGradeInViewSubmissionForManualGradableActivityBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit Grade in View Submission for Manual Gradable Activity By SMS Instructor", ((string[])(null)));
#line 59
this.ScenarioSetup(scenarioInfo);
#line 60
testRunner.When("I navigate to \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
testRunner.When("I click the cmenu \"ViewAllSubmissions\" of asset \"Quiz\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
testRunner.When("I edit the grade in view submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To check the Gradebook view for multiple visit in same session By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorGradebook")]
        public virtual void ToCheckTheGradebookViewForMultipleVisitInSameSessionBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To check the Gradebook view for multiple visit in same session By SMS Instructor", ((string[])(null)));
#line 69
this.ScenarioSetup(scenarioInfo);
#line 70
testRunner.When("I navigate to \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
testRunner.When("I apply \'Assignment Types\' filter in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
testRunner.And("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
testRunner.And("I navigate to \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
testRunner.Then("I should see the filter selection changes made earlier", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To confirm that edited score of status in course By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorGradebook")]
        public virtual void ToConfirmThatEditedScoreOfStatusInCourseBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To confirm that edited score of status in course By SMS Instructor", ((string[])(null)));
#line 80
this.ScenarioSetup(scenarioInfo);
#line 81
testRunner.When("I navigate to \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 83
testRunner.When("I click the cmenu \"ViewAllSubmissions\" of asset \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 85
testRunner.When("I edit the score in view submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 86
testRunner.Then("I should see the grade under activity column of the submitted \"Test\" activity for" +
                    " \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor Validating student grade in instructor grade book By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorGradebook")]
        public virtual void InstructorValidatingStudentGradeInInstructorGradeBookBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor Validating student grade in instructor grade book By SMS Instructor", ((string[])(null)));
#line 91
this.ScenarioSetup(scenarioInfo);
#line 92
testRunner.When("I navigate to \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
testRunner.When("I select \"Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)\" in \"Gradebook\"" +
                    " by \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
testRunner.Then("I should see score \"0\" of \"Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1" +
                    ")\" activity for \"ZeroScore\"  with \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 96
testRunner.And("I click on \'My Course\' link in gradebook by \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor Validaing student submissin and grade in Instructor Gradebook By SMS I" +
            "nstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorGradebook")]
        public virtual void InstructorValidaingStudentSubmissinAndGradeInInstructorGradebookBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor Validaing student submissin and grade in Instructor Gradebook By SMS I" +
                    "nstructor", ((string[])(null)));
#line 101
this.ScenarioSetup(scenarioInfo);
#line 102
testRunner.When("I navigate to \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 104
testRunner.When("I select \"Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)\" in \"Gradebook\"" +
                    " by \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 105
testRunner.And("I select the cmenu \"ViewAllSubmissions\" of asset \"Word Chapter 1 Project 1A Skill" +
                    "-Based Exam (Scenario 1)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
testRunner.Then("I should see the \"0\" score in view submission page for a \"ZeroScore\" with \"CsSmsS" +
                    "tudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
testRunner.And("I click on \'My Course\' link in gradebook by \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validating Apply GradeSchema in Instructor Gradebook By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorGradebook")]
        public virtual void ValidatingApplyGradeSchemaInInstructorGradebookBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validating Apply GradeSchema in Instructor Gradebook By SMS Instructor", ((string[])(null)));
#line 112
this.ScenarioSetup(scenarioInfo);
#line 113
testRunner.When("I navigate to \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 114
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 115
testRunner.When("I select \"PowerPoint Chapter 1 Skill-Based Training\" in \"Gradebook\" by \"CsSmsInst" +
                    "ructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
testRunner.And("I select the cmenu \"ApplyGradeSchema\" of asset \"PowerPoint Chapter 1 Skill-Based " +
                    "Training\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
testRunner.And("I \'Apply\' the grade schema for the submitted activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
testRunner.Then("I should see the \"PowerPoint Chapter 1 Skill-Based Training\" activity status \"A\" " +
                    "in Gradebook for enrollled \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 119
testRunner.When("I select the cmenu \"RemoveGradeSchema\" of asset \"PowerPoint Chapter 1 Skill-Based" +
                    " Training\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 120
testRunner.Then("I click on \'My Course\' link in gradebook by \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor Validating student Study Plan Grade in Instructor Gradebook By SMS Ins" +
            "tructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorGradebook")]
        public virtual void InstructorValidatingStudentStudyPlanGradeInInstructorGradebookBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor Validating student Study Plan Grade in Instructor Gradebook By SMS Ins" +
                    "tructor", ((string[])(null)));
#line 125
this.ScenarioSetup(scenarioInfo);
#line 126
testRunner.When("I navigate to \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 127
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
testRunner.When("I select \"Excel Chapter 1 Study Plan [Skill-Based]: Training > Post-Test\" in \"Gra" +
                    "debook\" by \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 129
testRunner.And("I click on view grades of \"Excel Chapter 1 Study Plan [Skill-Based]: Training > P" +
                    "ost-Test\" in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
testRunner.Then("I should see the score \"100\" of \"Excel Chapter 1 Skill-Based Training - Pre-test " +
                    "Training\" activity for \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 131
testRunner.And("I should see the score \"100\" of \"Excel Chapter 1 Skill-Based Exam (Scenario 1)-Po" +
                    "st Test\" activity for \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
testRunner.And("I click on \'My Course\' link in gradebook by \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor Accepting Pastdue Submission in Instructor Gradebook By SMS Instructor" +
            "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorGradebook")]
        public virtual void InstructorAcceptingPastdueSubmissionInInstructorGradebookBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor Accepting Pastdue Submission in Instructor Gradebook By SMS Instructor" +
                    "", ((string[])(null)));
#line 137
this.ScenarioSetup(scenarioInfo);
#line 138
testRunner.When("I navigate to \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 139
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 140
testRunner.When("I select \"Excel Chapter 1 Skill-Based Training\" in \"Gradebook\" by \"CsSmsInstructo" +
                    "r\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 141
testRunner.And("I select the cmenu \"ViewAllSubmissions\" of asset \"Excel Chapter 1 Skill-Based Tra" +
                    "ining\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
testRunner.Then("I should see \"Decline\" and \"Accept\" options in view submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 143
testRunner.When("I select the option \"Accept\" in view submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 144
testRunner.And("I close the \"View Submission\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 145
testRunner.Then("I should see the score \"0\" of \"Excel Chapter 1 Skill-Based Training\" activity for" +
                    " \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 146
testRunner.And("I click on \'My Course\' link in gradebook by \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor Validating badge in instructor grade book By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorGradebook")]
        public virtual void InstructorValidatingBadgeInInstructorGradeBookBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor Validating badge in instructor grade book By SMS Instructor", ((string[])(null)));
#line 149
this.ScenarioSetup(scenarioInfo);
#line 150
testRunner.When("I navigate to \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 151
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 152
testRunner.When("I select \"Word Chapter 1 Grader Project [Assessment 3]\" in \"Gradebook\" by \"CsSmsI" +
                    "nstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 153
testRunner.Then("I should see the badge icon for \"Word Chapter 1 Grader Project [Assessment 3]\" as" +
                    " \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
