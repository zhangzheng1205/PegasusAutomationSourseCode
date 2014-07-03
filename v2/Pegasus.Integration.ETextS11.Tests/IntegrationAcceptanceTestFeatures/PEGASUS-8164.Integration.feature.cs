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
namespace Pegasus.Integration.ETextS11.Tests.IntegrationAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.1.84")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PEGASUS_8164LaunchETextInSectionCourseFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PEGASUS-8164.Integration.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PEGASUS-8164: Launch eText in Section Course", "\t\t\tAs a CS Instructor \r\n\t\t\tI want to manage all the coursespace instructor relate" +
                    "d usecases \r\n\t\t\tso that I would validate all the coursespace instructor scenario" +
                    "s are working fine", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "PEGASUS-8164: Launch eText in Section Course")))
            {
                Pegasus.Integration.ETextS11.Tests.IntegrationAcceptanceTestFeatures.PEGASUS_8164LaunchETextInSectionCourseFeature.FeatureSetup(null);
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
#line 7
#line 8
testRunner.Given("I browsed the login url for \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("I login to Pegasus as \"CsSmsInstructor\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Launch eText in Section Course by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PEGASUS-8164: Launch eText in Section Course")]
        public virtual void LaunchETextInSectionCourseBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Launch eText in Section Course by SMS Instructor", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 15
testRunner.When("I enter in the \"ProgramCourse\" from the Global Home page as \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
testRunner.When("I select the \"Sections\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.Then("I should see the Section to be successfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
testRunner.When("I click the \"Enter Section as Instructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
testRunner.Then("I should be on the \"Calendar\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
testRunner.When("I navigate to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
testRunner.And("I should see \"eText\" Activity in the MyCourse Frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
testRunner.When("I \"Open\" the Activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.Then("I should see the \'etext\' launched successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
testRunner.When("I close etext \"Pearson eText\" presentation window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
testRunner.And("I \"Sign out\" from the \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Launch eText in Section Course for DemoUser by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PEGASUS-8164: Launch eText in Section Course")]
        public virtual void LaunchETextInSectionCourseForDemoUserBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Launch eText in Section Course for DemoUser by SMS Instructor", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 32
testRunner.When("I enter in the \"ProgramCourse\" from the Global Home page as \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
testRunner.When("I select the \"Sections\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
testRunner.Then("I should see the Section to be successfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
testRunner.When("I click the \"Enter Section as Instructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
testRunner.Then("I should be on the \"Calendar\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
testRunner.When("I select the \"Go to Student View\" link in Global Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
testRunner.When("I navigate to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
testRunner.When("I open the \"eText\" Activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
testRunner.Then("I should see the \'etext\' launched successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
testRunner.When("I close etext \"Pearson eText\" presentation window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
testRunner.And("I \"Sign out\" from the \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
