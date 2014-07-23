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
namespace Pegasus.Acceptance.MyItLab.Tests.UserStoryAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PEGASUS_27958Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PEGASUS-27958.Acceptance.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PEGASUS-27958", "As a CS Instructor \r\nI want to manage Functionality of Delete / Copy / Cut / Past" +
                    "e in Advanced Content Library\r\nso that I would validate Functionality of Delete " +
                    "/ Copy / Cut / Paste, related scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "PEGASUS-27958")))
            {
                Pegasus.Acceptance.MyItLab.Tests.UserStoryAcceptanceTestFeatures.PEGASUS_27958Feature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete functionality in Advanced Content Library")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PEGASUS-27958")]
        public virtual void DeleteFunctionalityInAdvancedContentLibrary()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete functionality in Advanced Content Library", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
testRunner.When("I navigate to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.When("I select Advanced Options link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
testRunner.And("I select checkbox of 1 assets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
testRunner.Then("\"Delete\" button on Content Library header should get \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
testRunner.When("I select \"Delete\" button on Content Library header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
testRunner.Then("A \"Delete\" confirmation pop up should display with \"OK\" button and \"Cancel\" butto" +
                    "n", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
testRunner.When("I click on OK button on Delete confirmation pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.Then("I should see the successfull message \"Items deleted successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete functionality in Advanced Content Library Multiple Assets")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PEGASUS-27958")]
        public virtual void DeleteFunctionalityInAdvancedContentLibraryMultipleAssets()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete functionality in Advanced Content Library Multiple Assets", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
testRunner.When("I navigate to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
testRunner.When("I select Advanced Options link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
testRunner.And("I select checkbox of 3 assets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
testRunner.Then("\"Delete\" button on Content Library header should get \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
testRunner.When("I select \"Delete\" button on Content Library header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
testRunner.Then("A \"Delete\" confirmation pop up should display with \"OK\" button and \"Cancel\" butto" +
                    "n", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
testRunner.When("I click on OK button on Delete confirmation pop up", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
testRunner.Then("I should see the successfull message \"Items deleted successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cut Paste functionality in Advanced Content Library")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PEGASUS-27958")]
        public virtual void CutPasteFunctionalityInAdvancedContentLibrary()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cut Paste functionality in Advanced Content Library", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
testRunner.When("I navigate to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
testRunner.When("I select Advanced Options link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.And("I select checkbox of 3 assets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
testRunner.Then("\"Cut\" button on Content Library header should get \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
testRunner.When("I select \"Cut\" button on Content Library header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
testRunner.Then("Count 3 should be displayed in Clipboard Items", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
testRunner.And("Asset title should display in \"Red\" color and \"Italic\" style.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
testRunner.When("I select \"Paste\" button on Content Library header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.And("I Select \"PasteAtTop\" on Paste Advanced Options on Content Library", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
testRunner.Then("I should see the successfull message \"Items copied successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
testRunner.And("Asset should should display at \"Top\" place", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Copy Paste functionality in Advanced Content Library")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PEGASUS-27958")]
        public virtual void CopyPasteFunctionalityInAdvancedContentLibrary()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Copy Paste functionality in Advanced Content Library", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
testRunner.When("I navigate to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
testRunner.When("I select Advanced Options link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
testRunner.And("I select checkbox of 1 assets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
testRunner.Then("\"Copy\" button on Content Library header should get \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
testRunner.When("I select \"Copy\" button on Content Library header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
testRunner.Then("Count 1 should be displayed in Clipboard Items", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
testRunner.And("Asset title should display in \"Red\" color and \"Italic\" style.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
testRunner.When("I select \"Paste\" button on Content Library header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
testRunner.And("I Select \"PasteAtTop\" on Paste Advanced Options on Content Library", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
testRunner.Then("I should see the successfull message \"Items copied successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
testRunner.And("Asset should should display at \"Top\" place", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Copy Paste functionality in Advanced Content Library Multiple Assets")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PEGASUS-27958")]
        public virtual void CopyPasteFunctionalityInAdvancedContentLibraryMultipleAssets()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Copy Paste functionality in Advanced Content Library Multiple Assets", ((string[])(null)));
#line 58
this.ScenarioSetup(scenarioInfo);
#line 59
testRunner.When("I navigate to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
testRunner.When("I select Advanced Options link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
testRunner.And("I select checkbox of 1 assets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
testRunner.Then("\"Copy\" button on Content Library header should get \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
testRunner.When("I select checkbox of 4 assets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
testRunner.Then("\"Copy\" button on Content Library header should get \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
testRunner.When("I select \"Copy\" button on Content Library header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
testRunner.Then("Count 3 should be displayed in Clipboard Items", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
testRunner.And("Asset title should display in \"Red\" color and \"Italic\" style.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
testRunner.When("I select \"Paste\" button on Content Library header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
testRunner.And("I Select \"PasteAtTop\" on Paste Advanced Options on Content Library", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
testRunner.Then("I should see the successfull message \"Items copied successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
testRunner.And("Asset should should display at \"Top\" place", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
