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
    public partial class CourseSpaceInstructorContentLibraryFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceInstructorContentLibrary.Workflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceInstructorContentLibrary", "    As a Cs Instructor \r\nI want to manage all the coursespace Content Library rel" +
                    "ated usecases \r\nso that I would validate all the coursespace Content Library sce" +
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceInstructorContentLibrary")))
            {
                Pegasus.Acceptance.MyItLab.Tests.ProductAcceptanceTestFeatures.CourseSpaceInstructorContentLibraryFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To save an activity in Content Library with HelpLink")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorContentLibrary")]
        public virtual void ToSaveAnActivityInContentLibraryWithHelpLink()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To save an activity in Content Library with HelpLink", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.When("I navigate to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 10
testRunner.When("I click on the \'Add Course Materials\' option in Content Library", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.And("I click on the \"Homework\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
testRunner.Then("I should be on the \"Create activity\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
testRunner.When("I create \"Homework\" activity of behavioral mode \"BasicRandom\" type using True-Fal" +
                    "se question", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
testRunner.Then("I should see the successfull message \"Activity added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 15
testRunner.When("I \"Sign out\" from the \"HedWsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To edit an activity in Content Library and preview the HelpLink")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorContentLibrary")]
        public virtual void ToEditAnActivityInContentLibraryAndPreviewTheHelpLink()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To edit an activity in Content Library and preview the HelpLink", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
testRunner.When("I navigate to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
testRunner.When("I click on the Activity Name in Content Library frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
testRunner.Then("I should be on the \"Edit Random activity\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.When("I click on the HelpLinks activity subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.Then("I should be on the \"Edit Random activity\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
testRunner.When("I click on the Preview link in c-menu of Helplink", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
testRunner.Then("I should be on the \"Homework\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
testRunner.When("I close the \"Homework\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
testRunner.Then("I should be on the \"Edit Random activity\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
testRunner.When("I click on the \"Cancel\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
testRunner.Then("I should be on the \"Cancel Activity\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
testRunner.When("I click on the \"Don\'t Save\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion