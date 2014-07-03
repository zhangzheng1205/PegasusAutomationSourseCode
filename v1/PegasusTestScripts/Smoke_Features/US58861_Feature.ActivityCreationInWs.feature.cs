﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.1.84
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.269
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace PegasusTestScripts.Smoke_Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.1.84")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class US58861_ManageActivityCreationAndAssociationFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "US58861_Feature.ActivityCreationInWs.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "US58861 - Manage Activity Creation and Association", "In order to Create Activity\r\nAs a WS Teacher\r\nI want to create a activity and ass" +
                    "ociate into MyCourse frame", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "US58861 - Manage Activity Creation and Association")))
            {
                PegasusTestScripts.Smoke_Features.US58861_ManageActivityCreationAndAssociationFeature.FeatureSetup(null);
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
#line 9
#line 10
testRunner.Given("I have browsed url for \"WSTeacher\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
testRunner.When("I have logged into the work space as WS Teacher", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
testRunner.Then("It should show the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Skill study plan in the Add Content from Library")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US58861 - Manage Activity Creation and Association")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("initial_setup")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreateSkillStudyPlan")]
        public virtual void CreateSkillStudyPlanInTheAddContentFromLibrary()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Skill study plan in the Add Content from Library", new string[] {
                        "initial_setup",
                        "CreateSkillStudyPlan",
                        "ignore"});
#line 16
this.ScenarioSetup(scenarioInfo);
#line 9
this.FeatureBackground();
#line 17
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
testRunner.When("I select the course name with prefix BDDML", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
testRunner.Then("It should show the \"Overview\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
testRunner.And("I navigate to the \"Preference\" Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
testRunner.When("I selected the \'Standards and Skills\' sub tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
testRunner.And("I Add new frameworks", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.Then("It should display successful message \"Selected frameworks successfully added to c" +
                    "urrent course.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.And("I saved the preferences", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
testRunner.Then("It should display successful message \"Preferences updated successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
testRunner.And("I navigate to the \"Content\" Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
testRunner.When("I selected the \'More\' dropdown link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
testRunner.And("I selected the \"Map Questions to Skills\" sub tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
testRunner.And("Map the questions to the skill", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
testRunner.And("I select the \"Add Content from Library\" sub tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
testRunner.When("I select \'Skill Study Plan\' activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
testRunner.And("I create \'Skill Study Plan - Pre test / Post test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
testRunner.Then("It should display successful message \"Study Plan added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
testRunner.And("I select the Home button to go back on Global Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Associate Activity to My Course frame")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US58861 - Manage Activity Creation and Association")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AssociateActivityToMyCourseFrame")]
        public virtual void AssociateActivityToMyCourseFrame()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Associate Activity to My Course frame", new string[] {
                        "AssociateActivityToMyCourseFrame",
                        "ignore"});
#line 39
this.ScenarioSetup(scenarioInfo);
#line 9
this.FeatureBackground();
#line 40
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
testRunner.When("I select the course name with prefix BDDML", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
testRunner.Then("It should show the \"Overview\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
testRunner.And("I navigate to the \"Content\" Tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
testRunner.When("I select the MathXL activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
testRunner.And("I Click on the Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
testRunner.Then("It should display successful message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
testRunner.When("I clicked on the Search/View button in \"ifrmRight\" frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
testRunner.When("I unhide the activity from right frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
testRunner.And("I clicked on the Logout link to get logged out from the application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
