﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.3.0
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34003
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Pegasus.Acceptance.DigitalPath.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceAssignsContentFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceAssignsContent.WorkFlow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceAssignsContent", "                As a CS Teacher \r\n\t\t\tI want to manage all the coursespace assign " +
                    "content usecases \r\n\t\t\tso that I would validate all the assign content scenarios " +
                    "are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceAssignsContent")))
            {
                Pegasus.Acceptance.DigitalPath.Tests.ProductAcceptanceTestFeatures.CourseSpaceAssignsContentFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Calendar SetUp by CsTeacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void CalendarSetUpByCsTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Calendar SetUp by CsTeacher", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
testRunner.When("I navigate to the \"Planner\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.Then("I should be on the \"Planner\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
testRunner.When("I click on the Calendar set up button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
testRunner.Then("I should see the calendar configured successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
testRunner.When("I set the due date for the \"Test\" activity in calendar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
testRunner.And("I set the due date for the \"StudyPlan\" activity in calendar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Teacher Enters Curriculum and Performs Actions on Contents")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void TeacherEntersCurriculumAndPerformsActionsOnContents()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher Enters Curriculum and Performs Actions on Contents", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
testRunner.When("I navigate to the \"Curriculum\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
testRunner.And("I select \"Preview\" cmenu option of \"Test\" in table of contents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
testRunner.Then("I should see the \"Start\" button in \'Test\' page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
testRunner.And("I close the \"Test\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.When("I select \"Assign\" cmenu option of \"Test\" in table of contents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 24
testRunner.And("I set the due date for the \"Test\" activity in curriculum", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
testRunner.When("I select \"Print\" cmenu option of \"Test\" in table of contents", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
testRunner.Then("I should see the \"Download\" option in print window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
testRunner.And("I close the \"Print tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Teacher performs simple assign in Curriculum tab for Lesson type activity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void TeacherPerformsSimpleAssignInCurriculumTabForLessonTypeActivity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher performs simple assign in Curriculum tab for Lesson type activity", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
testRunner.When("I navigate to the \"Curriculum\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
testRunner.And("I expand the folder \"Expressions and Equations\" in Curriculum tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
testRunner.And("I expand the sub folder \"Variables and Expressions\" in Curriculum tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
testRunner.And("I select cmenu option \"Assign\" of \"Lesson 1-1: Numerical Expressions\" activity in" +
                    " Curriculum tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
testRunner.Then("I should see \"Assign\" pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
testRunner.When("I select the class \"DigitalPathMasterLibrary\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.And("I select the current date and due date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
testRunner.And("I click on Save and Assign button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
testRunner.And("I click on Ok button in Assign pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
testRunner.Then("I should see Assign pop up closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Setup Calendar In Planner tab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void SetupCalendarInPlannerTab()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Setup Calendar In Planner tab", ((string[])(null)));
#line 45
this.ScenarioSetup(scenarioInfo);
#line 46
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
testRunner.When("I navigate to the \"Planner\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
testRunner.Then("I should be on the \"Planner\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
testRunner.When("I select \"DigitalPath\" Product from the Curriculum dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
testRunner.And("I click on the Calendar set up button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
testRunner.And("I select \"DigitalPath\" Product from the Curriculum dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
testRunner.Then("I should see the \"DigitalPath\" period configured in calendar successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Digital Path teacher assigns Math XL activity to current date")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void DigitalPathTeacherAssignsMathXLActivityToCurrentDate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Digital Path teacher assigns Math XL activity to current date", ((string[])(null)));
#line 57
this.ScenarioSetup(scenarioInfo);
#line 58
testRunner.When("I navigate to the \"Planner\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
testRunner.Then("I should be on the \"Planner\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
testRunner.When("I select \"DigitalPath\" Product from the Curriculum dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
testRunner.When("I expand the folder \"Expressions and Equations\" in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
testRunner.And("I expand the sub folder \"Variables and Expressions\" in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
testRunner.And("I expand the leaf folder \"Topic 1 Test\" in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
testRunner.And("I select cmenu option \"Assign\" of \"Topic 1 Test\" activity in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
testRunner.And("I click on Ok button in Alert pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
testRunner.Then("I should see \"Assign\" pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 67
testRunner.When("I select the class \"DigitalPathMasterLibrary\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
testRunner.And("I select the \"DigitalPath\" period", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
testRunner.And("I select the current date and due date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
testRunner.And("I click on Save and Assign button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
testRunner.And("I click on Ok button in Assign pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
testRunner.Then("I should be on the \"Planner\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
testRunner.And("I should see the assigned asset \"Topic 1 Test\" under the period \"DigitalPath\" in " +
                    "calendar frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Teacher performs simple assign in Planner tab for LCC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void TeacherPerformsSimpleAssignInPlannerTabForLCC()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher performs simple assign in Planner tab for LCC", ((string[])(null)));
#line 77
this.ScenarioSetup(scenarioInfo);
#line 78
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
testRunner.When("I navigate to the \"Planner\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 81
testRunner.Then("I should be on the \"Planner\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
testRunner.When("I select \"DigitalPath\" Product from the Curriculum dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 83
testRunner.When("I expand the folder \"Expressions and Equations\" in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
testRunner.And("I expand the sub folder \"Variables and Expressions\" in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
testRunner.And("I expand the leaf folder \"1-1 Homework\" in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
testRunner.And("I select cmenu option \"Assign\" of \"1-1 Homework\" activity in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
testRunner.And("I click on Ok button in Alert pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
testRunner.Then("I should see \"Assign\" pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
testRunner.When("I select the class \"DigitalPathMasterLibrary\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
testRunner.And("I select the \"DigitalPath\" period", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
testRunner.And("I select the current date and due date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
testRunner.And("I click on Save and Assign button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
testRunner.And("I click on Ok button in Assign pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
testRunner.Then("I should be on the \"Planner\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 95
testRunner.And("I should see the assigned asset \"1-1 Homework\" under the period \"DigitalPath\" in " +
                    "calendar frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Teacher assigns study plan via drag and drop in planner tab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void TeacherAssignsStudyPlanViaDragAndDropInPlannerTab()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher assigns study plan via drag and drop in planner tab", ((string[])(null)));
#line 99
this.ScenarioSetup(scenarioInfo);
#line 100
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 101
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
testRunner.When("I navigate to the \"Planner\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
testRunner.Then("I should be on the \"Planner\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 104
testRunner.When("I select \"DigitalPath\" Product from the Curriculum dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 105
testRunner.When("I expand the folder \"Expressions and Equations\" in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
testRunner.And("I expand the sub folder \"Variables and Expressions\" in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
testRunner.And("I expand the leaf folder \"Topic 1 Test\" in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
testRunner.And("I Drag and drop the study plan \"Topic 1 Test with Study Plan\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
testRunner.And("I refresh the frame till content is copied for \"DigitalPath\" product", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
testRunner.And("I refresh the frame till \"Topic 1 Test with Study Plan\" is displayed in calendar " +
                    "frame under \"DigitalPath\" product", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Teacher assigns study plan via assign window in planner tab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void TeacherAssignsStudyPlanViaAssignWindowInPlannerTab()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Teacher assigns study plan via assign window in planner tab", ((string[])(null)));
#line 115
this.ScenarioSetup(scenarioInfo);
#line 116
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 117
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 118
testRunner.When("I navigate to the \"Planner\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
testRunner.Then("I should be on the \"Planner\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
testRunner.When("I select \"DigitalPath\" Product from the Curriculum dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 121
testRunner.When("I expand the folder \"Expressions and Equations\" in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 122
testRunner.And("I expand the sub folder \"Equivalent Expressions\" in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
testRunner.And("I expand the leaf folder \"Topic 2 Test\" in Planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
testRunner.And("I select cmenu option \"Assign\" of \"Topic 2 Test with Study Plan\" activity in Plan" +
                    "ner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
testRunner.And("I click on Ok button in Alert pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
testRunner.Then("I should see \"Assign\" pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 127
testRunner.When("I select the class \"DigitalPathMasterLibrary\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 128
testRunner.And("I select the \"DigitalPath\" period", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
testRunner.And("I select the current date and due date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
testRunner.And("I click on Save and Assign button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
testRunner.And("I click on Ok button in Assign pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
testRunner.Then("I should be on the \"Planner\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 133
testRunner.And("I should see the assigned asset \"Topic 2 Test with Study Plan\" under the period \"" +
                    "DigitalPath\" in calendar frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
