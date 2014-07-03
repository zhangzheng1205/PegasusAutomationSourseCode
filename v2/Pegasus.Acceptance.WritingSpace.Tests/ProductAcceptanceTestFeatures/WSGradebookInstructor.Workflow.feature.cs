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
namespace Pegasus.Acceptance.WritingSpace.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.1.84")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WSGradebookInstructorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "WSGradebookInstructor.Workflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "WS Gradebook Instructor", "\t\tAs a MMND Instructor \r\n\t\tI want to manage all the MMND Instructor Gradebook rel" +
                    "ated usecases \r\n\t\tso that I would validate all the MMND Instructor Gradebook sce" +
                    "narios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "WS Gradebook Instructor")))
            {
                Pegasus.Acceptance.WritingSpace.Tests.ProductAcceptanceTestFeatures.WSGradebookInstructorFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Writingspace Activity Displayed in Gradebook by MMND Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WS Gradebook Instructor")]
        public virtual void WritingspaceActivityDisplayedInGradebookByMMNDInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Writingspace Activity Displayed in Gradebook by MMND Instructor", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
testRunner.When("I click on \"Course Home\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.And("I click the \"Grades\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
testRunner.Then("I should see the \"WritingSpace\" activity in Gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
testRunner.And("I should see the \"WritingSpace\" activity with grade for the enrollled \"MMNDStuden" +
                    "t\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Display Of Cmenu Options For Writing Space Activity by MMND Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WS Gradebook Instructor")]
        public virtual void DisplayOfCmenuOptionsForWritingSpaceActivityByMMNDInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Display Of Cmenu Options For Writing Space Activity by MMND Instructor", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
testRunner.When("I click the \"WritingSpace\" activity cmenu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ExpectedResult",
                        "ActualResult"});
            table1.AddRow(new string[] {
                        "Apply Grade Schema",
                        "Apply Grade Schema"});
            table1.AddRow(new string[] {
                        "Hide for Student",
                        "Hide for Student"});
            table1.AddRow(new string[] {
                        "Synchronize with LMS",
                        "Synchronize with LMS"});
            table1.AddRow(new string[] {
                        "Export",
                        "Export"});
            table1.AddRow(new string[] {
                        "Save to Custom View",
                        "Save to Custom View"});
#line 17
testRunner.Then("I should able to see the Display of c-menu options for activity", ((string)(null)), table1, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Verify the functionality of Hide For Student Cmenu Option by MMND Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WS Gradebook Instructor")]
        public virtual void ToVerifyTheFunctionalityOfHideForStudentCmenuOptionByMMNDInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Verify the functionality of Hide For Student Cmenu Option by MMND Instructor", ((string[])(null)));
#line 26
this.ScenarioSetup(scenarioInfo);
#line 27
testRunner.When("I click the \"Grades\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
testRunner.And("I click on cmenu \"HideforStudent\" of \"WritingSpace\" Activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
testRunner.Then("I should see the successfull message \"Column successfully hidden.\" in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Verify the functionality of Save to Custom View Cmenu Option by MMND Instructo" +
            "r")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WS Gradebook Instructor")]
        public virtual void ToVerifyTheFunctionalityOfSaveToCustomViewCmenuOptionByMMNDInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Verify the functionality of Save to Custom View Cmenu Option by MMND Instructo" +
                    "r", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
testRunner.When("I click on cmenu \"SavetoCustomView\" of \"WritingSpace\" Activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.Then("I should see the successfull message \"Column successfully saved to Custom View.\" " +
                    "in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
testRunner.When("I click on \"Course Home\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
testRunner.And("I click the \"Custom_View\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
testRunner.When("I click on cmenu \"RemovefromCustomView\" of asset \"WritingSpace\" in Custom View", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("I should see the successfull message \"Column successfully removed from Custom Vie" +
                    "w.\" in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify Display of Grade Cmenu Option in Gradebook by MMND Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WS Gradebook Instructor")]
        public virtual void VerifyDisplayOfGradeCmenuOptionInGradebookByMMNDInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify Display of Grade Cmenu Option in Gradebook by MMND Instructor", ((string[])(null)));
#line 41
this.ScenarioSetup(scenarioInfo);
#line 42
testRunner.When("I click on \"WritingSpace\" Activity grade cmenu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
testRunner.Then("I should be able to see \"View Grade History\" grade cmenu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the functionality of Apply Grade Schema Activity Cmenu in Gradebook by MMN" +
            "D Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WS Gradebook Instructor")]
        public virtual void VerifyTheFunctionalityOfApplyGradeSchemaActivityCmenuInGradebookByMMNDInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the functionality of Apply Grade Schema Activity Cmenu in Gradebook by MMN" +
                    "D Instructor", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
testRunner.When("I click on cmenu \"ApplyGradeSchema\" of \"WritingSpace\" Activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
testRunner.And("I \'Apply\' the grade schema for the submitted activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
testRunner.Then("I should see the successfull message \"Schema applied successfully.\" in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
testRunner.When("I click on cmenu \"RemoveGradeSchema\" of \"WritingSpace\" Activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
testRunner.Then("I should see the successfull message \"Grade schema removed successfully.\" in grad" +
                    "ebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
