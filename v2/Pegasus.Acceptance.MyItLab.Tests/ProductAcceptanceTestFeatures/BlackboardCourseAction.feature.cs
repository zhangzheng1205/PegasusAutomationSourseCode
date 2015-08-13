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
    public partial class BlackboardInstructorCourseActionFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BlackboardCourseAction.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BlackboardInstructorCourseAction", "               As a BB Instructor \r\n\t\t\tI want to manage all the Blackboard course" +
                    " management usecases \r\n\t\t\tso that I would validate all the course mana scenarios" +
                    " are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "BlackboardInstructorCourseAction")))
            {
                Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestFeatures.BlackboardInstructorCourseActionFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Blackboard Instructor validate startsync and stop sync")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BlackboardInstructorCourseAction")]
        public virtual void BlackboardInstructorValidateStartsyncAndStopSync()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Blackboard Instructor validate startsync and stop sync", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.When("I select the cmenu \"StopLMSSynchronization\" of asset \"GO! Excel Chapter 1 Skill-B" +
                    "ased Exam (Scenario 1)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
testRunner.Then("I should see the successfull message \"LMS Synchronization is stopped\" in \"Gradebo" +
                    "ok\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
testRunner.When("I select the cmenu \"SynchronizewithLMS\" of asset \"GO! Excel Chapter 1 Skill-Based" +
                    " Exam (Scenario 1)\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.Then("I should see the successfull message \"LMS Synchronization is enabled\" in \"Gradebo" +
                    "ok\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Blackboard instructor Edit Grade in Pegasus")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BlackboardInstructorCourseAction")]
        public virtual void BlackboardInstructorEditGradeInPegasus()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Blackboard instructor Edit Grade in Pegasus", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
testRunner.When("I enter into blackboard course \"BBCourse\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.Then("I should be displayed with \"Home Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
testRunner.When("I click on the \"Content\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
testRunner.And("I click on the \"Gradebook\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
testRunner.When("I select \"Word Chapter 1 Grader Project [Assessment 3]\" in \"Gradebook\" by \"CsSmsI" +
                    "nstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
testRunner.And("I click on Edit Grade \"PegasusEditedGrade\" of \"BBEditActivity\" activity for \"BBSt" +
                    "udent\" in Pegasus", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.Then("I should see the score \"PegasusEditedGrade\" of \"Word Chapter 1 Grader Project [Ho" +
                    "mework 3] (Project G)\" activity for \"BBStudent\" in Pegasus", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.When("I \"Close\" from the \"BBInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.And("I click on the \"Grade Center\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
testRunner.And("I click on the \"Full Grade Center\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
testRunner.When("I select option \"Pearson Custom Tools\" form \"Manage\" dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
testRunner.And("I click on the \"Refresh Pearson Grades\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
testRunner.When("I click on submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
testRunner.And("I click on the \"Full Grade Center\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
testRunner.Then("I should see the score \"PegasusEditedGrade\" for \"Word Chapter 1 Grader Project [H" +
                    "omework 3] (Project G)\" activity for \"BBStudent\" in BlackBoard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("BBStudent submit activity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BlackboardInstructorCourseAction")]
        public virtual void BBStudentSubmitActivity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("BBStudent submit activity", ((string[])(null)));
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
testRunner.When("I enter into blackboard course \"BBCourse\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
testRunner.Then("I should be displayed with \"Home Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
testRunner.When("I click on the \"Content\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.And("I click on the \"Grades\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.And("I select \"Word Chapter 1 Grader Project [Assessment 3]\" in \"Course Materials\" by " +
                    "\"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
testRunner.And("I open the activity named as \"Word Chapter 1 Grader Project [Assessment 3]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
testRunner.Then("I should see a \"Test Presentation\" pop up displayed with \"Download Files\" button " +
                    "and \"Upload Completed File\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
testRunner.When("I click on Download Files button on Test Presentation pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
testRunner.And("I click on download icon of \"go_w01_grader_a3.docx\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
testRunner.And("I click on Close and Return button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
testRunner.Then("I should see a \"Test Presentation\" pop up displayed with \"Download Files\" button " +
                    "and \"Upload Completed File\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
testRunner.When("I click on Upload Completed File button on Test Presentation pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
testRunner.And("I upload the downloaded file \"Grader Word file for 100%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
testRunner.Then("I should see message \"Your completed file has been successfully uploaded.\" on \"Te" +
                    "st Presentation\" popup page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
testRunner.When("I submit \"Word Chapter 1 Grader Project [Assessment 3]\" activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
testRunner.Then("I should see message \"Your file, go_w01_grader_a3.docx, has been successfully rec" +
                    "eived by myitlab:grader.\" on \"Test Feedback\" popup page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
testRunner.When("I click on Return To Course button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
testRunner.When("I select \"Word Chapter 1 Grader Project [Assessment 3]\" in \"Course Materials\" by " +
                    "\"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
testRunner.Then("I should see a \"Passed\" status for the activity \"Word Chapter 1 Grader Project [A" +
                    "ssessment 3]\" in \"Course Materials\" by \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
testRunner.And("I should see \"100\" score \"PegasusNewGrade\" for the activity \"Word Chapter 1 Grade" +
                    "r Project [Assessment 3]\" in course material page in Pegasus", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
testRunner.When("I \"Close\" from the \"BBStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
testRunner.When("I logout of Pegasus", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("BBInstructor validate new activity submission in Pegasus")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BlackboardInstructorCourseAction")]
        public virtual void BBInstructorValidateNewActivitySubmissionInPegasus()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("BBInstructor validate new activity submission in Pegasus", ((string[])(null)));
#line 61
this.ScenarioSetup(scenarioInfo);
#line 62
testRunner.When("I login to Blackboard Cert as \"BBInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
testRunner.Then("I should be logged in successfully as \"BBInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
testRunner.When("I enter into blackboard course \"BBCourse\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
testRunner.Then("I should be displayed with \"Home Page\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
testRunner.When("I click on the \"Content\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
testRunner.And("I click on the \"Gradebook\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
testRunner.When("I select \"Word Chapter 1 Grader Project [Assessment 3]\" in \"Gradebook\" by \"CsSmsI" +
                    "nstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
testRunner.Then("I should see GBSync icon for \"Word Chapter 1 Grader Project [Assessment 3]\" activ" +
                    "ity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
testRunner.And("I should see the score \"PegasusNewGrade\" of \"Word Chapter 1 Grader Project [Asses" +
                    "sment 3]\" activity for \"BBStudent\" in Pegasus", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
testRunner.When("I \"Close\" from the \"BBInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("BBInstructor validate newly sync grades in Blackboard")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BlackboardInstructorCourseAction")]
        public virtual void BBInstructorValidateNewlySyncGradesInBlackboard()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("BBInstructor validate newly sync grades in Blackboard", ((string[])(null)));
#line 75
this.ScenarioSetup(scenarioInfo);
#line 76
testRunner.When("I click on the \"Grade Center\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
testRunner.And("I click on the \"Full Grade Center\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
testRunner.When("I select option \"Pearson Custom Tools\" form \"Manage\" dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
testRunner.And("I click on the \"Refresh Pearson Grades\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
testRunner.And("I click on submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
testRunner.And("I click on the \"Full Grade Center\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
testRunner.Then("I should see the score \"PegasusNewGrade\" for \"Word Chapter 1 Grader Project [Asse" +
                    "ssment 3]\" activity for \"BBStudent\" in BlackBoard", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
