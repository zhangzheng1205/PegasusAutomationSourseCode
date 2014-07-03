﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.1.84
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.261
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.1.84")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WorkSpaceInstructorTodaysViewFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "WorkSpaceInstructorTodaysView.Workflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "WorkSpaceInstructorTodaysView", "       As a Ws Instructor \r\n    I want to manage all the workspace Instructor rel" +
                    "ated usecases \r\n so that I would validate all the workspace Instructor scenarios" +
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "WorkSpaceInstructorTodaysView")))
            {
                Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestFeatures.WorkSpaceInstructorTodaysViewFeature.FeatureSetup(null);
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
        
        public virtual void FeatureBackground()
        {
#line 6
#line 8
testRunner.Given("I browsed the login url for \"HedWsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("I logged into the Pegasus as \"HedWsInstructor\" in \"WorkSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To check the Default view of Todays View Channel displayed for Workspace Instruct" +
            "or")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructorTodaysView")]
        public virtual void ToCheckTheDefaultViewOfTodaysViewChannelDisplayedForWorkspaceInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To check the Default view of Todays View Channel displayed for Workspace Instruct" +
                    "or", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 15
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
testRunner.When("I enter in the \"MyItLabSIM5MasterCourse\" from the Global Home page as \"HedWsInstr" +
                    "uctor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
testRunner.And("I should see the \"CalendarNotificationsAnnouncements\" channels in \'Todays view\' p" +
                    "age", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.When("I \"Sign out\" from the \"HedWsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To verify the tab navigation inside the course for Workspace Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceInstructorTodaysView")]
        public virtual void ToVerifyTheTabNavigationInsideTheCourseForWorkspaceInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To verify the tab navigation inside the course for Workspace Instructor", ((string[])(null)));
#line 24
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 25
testRunner.When("I enter in the \"MyItLabSIM5MasterCourse\" from the Global Home page as \"HedWsInstr" +
                    "uctor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
testRunner.When("I navigate to the \"MyTest\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
testRunner.Then("I should be on the \"MyTest\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
testRunner.When("I navigate to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "SubtabName",
                        "WindowTitle"});
            table1.AddRow(new string[] {
                        "Add from Library",
                        "Course Materials"});
            table1.AddRow(new string[] {
                        "Manage Course Materials",
                        "Course Materials"});
            table1.AddRow(new string[] {
                        "Map Learning Objectives",
                        "Course Materials"});
            table1.AddRow(new string[] {
                        "Media Library",
                        "Media Library Page"});
            table1.AddRow(new string[] {
                        "Map Learning Objectives to Questions",
                        "Question Bank"});
            table1.AddRow(new string[] {
                        "Manage Question Bank",
                        "Question Bank"});
#line 30
testRunner.Then("I should see the following subtabs under Course Materials page", ((string)(null)), table1, "Then ");
#line 38
testRunner.When("I navigate to the \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "SubtabName",
                        "WindowTitle"});
            table2.AddRow(new string[] {
                        "Grades",
                        "Gradebook"});
            table2.AddRow(new string[] {
                        "Custom View",
                        "Custom View"});
            table2.AddRow(new string[] {
                        "Learner Settings",
                        "Learner Settings"});
            table2.AddRow(new string[] {
                        "Reports",
                        "Reports"});
#line 39
testRunner.Then("I should see the following subtabs under Gradebook page", ((string)(null)), table2, "Then ");
#line 45
testRunner.When("I navigate to the \"Enrollments\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "SubtabName",
                        "WindowTitle"});
            table3.AddRow(new string[] {
                        "Manage Roster",
                        "Roster"});
            table3.AddRow(new string[] {
                        "Manage Groups",
                        "Enrollments"});
#line 46
testRunner.Then("I should see the following subtabs in Enrollments page", ((string)(null)), table3, "Then ");
#line 50
testRunner.When("I navigate to the \"Communicate\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "SubtabName",
                        "WindowTitle"});
            table4.AddRow(new string[] {
                        "Mail",
                        "Course Mail"});
            table4.AddRow(new string[] {
                        "Chat",
                        "Communicate"});
#line 51
testRunner.Then("I should see the following subtabs under Communicate page", ((string)(null)), table4, "Then ");
#line 55
testRunner.When("I navigate to the \"Preferences\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
testRunner.Then("I should be on the \"Preferences\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
testRunner.When("I \"Sign out\" from the \"HedWsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
