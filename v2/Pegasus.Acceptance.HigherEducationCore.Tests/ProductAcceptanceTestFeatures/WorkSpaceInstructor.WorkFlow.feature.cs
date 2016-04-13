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
namespace Pegasus.Acceptance.HigherEducation.WL.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WorkSpaceInstructorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "WorkSpaceInstructor.WorkFlow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "WorkSpaceInstructor", "               As a Ws Instructor \r\n\t\t\tI want to manage all the workspace Instruc" +
                    "tor related usecases \r\n\t\t\tso that I would validate all the workspace Instructor " +
                    "scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "WorkSpaceInstructor")))
            {
                Pegasus.Acceptance.HigherEducation.WL.Tests.ProductAcceptanceTestFeatures.WorkSpaceInstructorFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Verify Copy of content across the course")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructor")]
        public virtual void ToVerifyCopyOfContentAcrossTheCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Verify Copy of content across the course", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
testRunner.When("I navigate to \"Preferences\" tab of the \"Preferences\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.Then("I should be on the \"Preferences\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
testRunner.When("I navigate to the \"Copy Content\" tab in Preferences Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
testRunner.Then("I should be on the \"Copy Content\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
testRunner.When("I enable the \'Copy Content\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
testRunner.And("I save the Preferences", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
testRunner.And("I navigate back to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.Then("I should see the \"Change Source\" option displayed in the \'Course Materials\' tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
testRunner.When("I click on the \'Change Source\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
testRunner.Then("I should see the \"MySpanishLabMaster\" source course in the dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
testRunner.When("I click on the \"MySpanishLabMaster\" source course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
testRunner.And("I select the \"PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentacion" +
                    "es\" activity in source course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.And("I click on the Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.And("I add the Activity to Course Content in target course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
testRunner.Then("I should see the successfull message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
testRunner.And("I should see \"PA-01 Span Practice- Vocabulary: Saludos, despedidas y presentacion" +
                    "es\" activity in course content in target course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Create Test with Basic Random Activity By WS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructor")]
        public virtual void ToCreateTestWithBasicRandomActivityByWSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Create Test with Basic Random Activity By WS Instructor", ((string[])(null)));
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
testRunner.When("I navigate to \"Course Materials\" tab of the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
testRunner.When("I click on the \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
testRunner.And("I click on the \"Test\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
testRunner.Then("I should be on the \"Create activity\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
testRunner.When("I create \"Test\" type activity of behavioral mode \'BasicRandom\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
testRunner.Then("I should see the successfull message \"Activity added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
testRunner.When("I associate the \"Test\" activity Content Library to MyCourse frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("I should see the successfull message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Create Homework with Basic Random Activity By WS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructor")]
        public virtual void ToCreateHomeworkWithBasicRandomActivityByWSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Create Homework with Basic Random Activity By WS Instructor", ((string[])(null)));
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
testRunner.When("I navigate to \"Course Materials\" tab of the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
testRunner.When("I click on the \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
testRunner.And("I click on the \"Homework\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
testRunner.Then("I should be on the \"Create activity\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
testRunner.When("I create \"HomeWork\" type activity of behavioral mode \'BasicRandom\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
testRunner.Then("I should see the successfull message \"Activity added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
testRunner.When("I associate the \"HomeWork\" activity Content Library to MyCourse frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
testRunner.Then("I should see the successfull message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Create Quiz with Manual Gradable Activity By WS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructor")]
        public virtual void ToCreateQuizWithManualGradableActivityByWSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Create Quiz with Manual Gradable Activity By WS Instructor", ((string[])(null)));
#line 55
this.ScenarioSetup(scenarioInfo);
#line 56
testRunner.When("I navigate to \"Course Materials\" tab of the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
testRunner.When("I click on the \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
testRunner.And("I click on the \"Quiz\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
testRunner.Then("I should be on the \"Create activity\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
testRunner.When("I create \"Quiz\" activity of behavioral mode type using Essay question", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
testRunner.Then("I should see the successfull message \"Activity added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 63
testRunner.When("I associate the \"Quiz\" activity Content Library to MyCourse frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
testRunner.Then("I should see the successfull message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Create The Page By Ws Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructor")]
        public virtual void ToCreateThePageByWsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Create The Page By Ws Instructor", ((string[])(null)));
#line 68
this.ScenarioSetup(scenarioInfo);
#line 69
testRunner.When("I navigate to \"Course Materials\" tab of the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
testRunner.When("I click on the \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
testRunner.And("I click on the \"Add Page\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
testRunner.Then("I should be on the \"Create page\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
testRunner.When("I create the \"Page\" activity in Content Library", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
testRunner.Then("I should see the successfull message \"Page saved successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
testRunner.When("I associate the \"Page\" activity Content Library to MyCourse frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
testRunner.Then("I should see the successfull message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Create The File By Ws Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructor")]
        public virtual void ToCreateTheFileByWsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Create The File By Ws Instructor", ((string[])(null)));
#line 81
this.ScenarioSetup(scenarioInfo);
#line 82
testRunner.When("I navigate to \"Course Materials\" tab of the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 83
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
testRunner.When("I click on the \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
testRunner.And("I click on the \"Add File\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
testRunner.Then("I should be on the \"Add File\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 87
testRunner.When("I create the \"File\" activity in Content Library", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
testRunner.Then("I should see the successfull message \"File saved successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
testRunner.When("I associate the \"File\" activity Content Library to MyCourse frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
testRunner.Then("I should see the successfull message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Create The Link By Ws Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructor")]
        public virtual void ToCreateTheLinkByWsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Create The Link By Ws Instructor", ((string[])(null)));
#line 94
this.ScenarioSetup(scenarioInfo);
#line 95
testRunner.When("I navigate to \"Course Materials\" tab of the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
testRunner.When("I click on the \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
testRunner.And("I click on the \"Add Link\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
testRunner.Then("I should be on the \"Add link\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 100
testRunner.When("I create the \"Link\" activity in Content Library", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 101
testRunner.Then("I should see the successfull message \"Link saved successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
testRunner.When("I associate the \"Link\" activity Content Library to MyCourse frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
testRunner.Then("I should see the successfull message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Create The Discussion Topic By Ws Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructor")]
        public virtual void ToCreateTheDiscussionTopicByWsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Create The Discussion Topic By Ws Instructor", ((string[])(null)));
#line 107
this.ScenarioSetup(scenarioInfo);
#line 108
testRunner.When("I navigate to \"Course Materials\" tab of the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
testRunner.When("I click on the \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 111
testRunner.And("I click on the \"Add Discussion Topic\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
testRunner.Then("I should be on the \"Add Discussion Topic\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
testRunner.When("I create the \"DiscussionTopic\" activity in Content Library", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 114
testRunner.Then("I should see the successfull message \"Discussion topic saved successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 115
testRunner.When("I associate the \"DiscussionTopic\" activity Content Library to MyCourse frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
testRunner.Then("I should see the successfull message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create SkillStudyPlan in Content Library By Ws Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructor")]
        public virtual void CreateSkillStudyPlanInContentLibraryByWsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create SkillStudyPlan in Content Library By Ws Instructor", ((string[])(null)));
#line 120
this.ScenarioSetup(scenarioInfo);
#line 121
testRunner.When("I navigate to \"Course Materials\" tab of the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 122
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 123
testRunner.When("I click on the \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
testRunner.And("I click on the \"Add Skill Study Plan\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
testRunner.Then("I should be on the \"Create Skill Study Plan\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 126
testRunner.When("I create \"SkillStudyPlan\" activity in \"HedWsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 127
testRunner.Then("I should see the successfull message \"Study Plan added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
testRunner.When("I associate the \"SkillStudyPlan\" activity Content Library to MyCourse frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 129
testRunner.Then("I should see the successfull message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creation of folder in Course Materials")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructor")]
        public virtual void CreationOfFolderInCourseMaterials()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creation of folder in Course Materials", ((string[])(null)));
#line 132
this.ScenarioSetup(scenarioInfo);
#line 133
testRunner.When("I navigate to \"Course Materials\" tab of the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 134
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
testRunner.When("I click on the \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 136
testRunner.And("I click on the \"Add Folder\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
testRunner.Then("I should be on the \"Create New Folder\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 138
testRunner.When("I create \"Folder\" type Folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 139
testRunner.Then("I should see the successfull message \"Folder saved successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 140
testRunner.When("I associate the \"Folder\" activity Content Library to MyCourse frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 141
testRunner.Then("I should see the successfull message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Verify Tab Navigation By Ws Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructor")]
        public virtual void ToVerifyTabNavigationByWsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Verify Tab Navigation By Ws Instructor", ((string[])(null)));
#line 144
this.ScenarioSetup(scenarioInfo);
#line 145
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 146
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 147
testRunner.When("I navigate to \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 148
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 149
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Workspace Instructor enable General preference for SAM activity type")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructor")]
        public virtual void WorkspaceInstructorEnableGeneralPreferenceForSAMActivityType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Workspace Instructor enable General preference for SAM activity type", ((string[])(null)));
#line 154
this.ScenarioSetup(scenarioInfo);
#line 155
testRunner.When("I navigate to \"Preferences\" tab of the \"Preferences\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 156
testRunner.Then("I should be on the \"Preferences\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 157
testRunner.When("I click on the \"Activities\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 158
testRunner.And("I Create a new \"RegSAMActivity\" SAM activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
testRunner.Then("I should see the successfull message \"preferences updated successfully\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 160
testRunner.When("I click on \"RegSAMActivity\" edit link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 161
testRunner.Then("I should see the \"Default preferences\" popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 162
testRunner.When("I set the \"General\" preference for \"RegSAMActivity\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 163
testRunner.And("I set the \"Messages\" preference for \"RegSAMActivity\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 164
testRunner.And("I set the \"Timing\" preference for \"RegSAMActivity\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 165
testRunner.And("I set the \"Feedback\" preference for \"RegSAMActivity\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 166
testRunner.And("I set the \"Res. Toolbar\" preference for \"RegSAMActivity\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 167
testRunner.And("I set the \"Grading\" preference for \"RegSAMActivity\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 168
testRunner.And("I set the \"Sections\" preference for \"RegSAMActivity\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 169
testRunner.And("I set the \"Video Chat\" preference for \"RegSAMActivity\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 170
testRunner.And("I click on \"Save\" button for \"RegSAMActivity\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 171
testRunner.Then("I should see the successfull message \"Preference settings updated for selected ac" +
                    "tivity type.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
