﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.1.84
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.225
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Pegasus.Integration.MGM.Tests.IntegrationAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.1.84")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PEGASUS_10477EnablingTheSkillsStandardsAddingTheSkillFrameworkForTheCourseFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PEGASUS-10477.Integration.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PEGASUS-10477: Enabling the Skills & Standards & adding the skill framework for t" +
                    "he course", "As an Ws Instructor\r\nI want to enable MGM preference in work space\r\nso that MGM c" +
                    "an be launched successfully.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "PEGASUS-10477: Enabling the Skills & Standards & adding the skill framework for t" +
                            "he course")))
            {
                Pegasus.Integration.MGM.Tests.IntegrationAcceptanceTestFeatures.PEGASUS_10477EnablingTheSkillsStandardsAddingTheSkillFrameworkForTheCourseFeature.FeatureSetup(null);
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
testRunner.Given("I browsed the login url for \"WsTeacher\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("I login to Pegasus as \"WsTeacher\" in \"WorkSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Set Skills & Standard Related Preferences In Master Course")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PEGASUS-10477: Enabling the Skills & Standards & adding the skill framework for t" +
            "he course")]
        public virtual void ToSetSkillsStandardRelatedPreferencesInMasterCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Set Skills & Standard Related Preferences In Master Course", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 15
testRunner.When("I enter in the \"MasterLibrary\" as \"WsTeacher\" from the Global Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.And("I navigate to the \"Preferences\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.Then("I should be on the \"Preferences\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
testRunner.When("I set the Standards and Skills preference in the Mastercourse for MGM", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
testRunner.Then("I should see the successfull message \"Preferences updated successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
testRunner.When("I \"Sign out\" from the \"WsTeacher\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
