﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.1.84
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.17929
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Pegasus.Acceptance.NovaNET.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.1.84")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceStudentFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceStudent.WorkFlow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceStudent", "               As a CS Student \r\n\t\t\tI want to manage all the coursespace student " +
                    "related usecases \r\n\t\t\tso that I would validate all the coursespace student scena" +
                    "rios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceStudent")))
            {
                Pegasus.Acceptance.NovaNET.Tests.ProductAcceptanceTestFeatures.CourseSpaceStudentFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Lauch Activity by CS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent")]
        public virtual void LauchActivityByCSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Lauch Activity by CS Student", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
testRunner.When("I navigate to \"Content\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should be on the \"Content\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.When("I open the activity named as \"NNTest\" in \"ViewAllContent\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
testRunner.Then("I should see the activity launched successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Activity Submission by CS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent")]
        public virtual void ActivitySubmissionByCSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Activity Submission by CS Student", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
testRunner.When("I navigate to \"Content\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.Then("I should be on the \"Content\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
testRunner.When("I open the activity named as \"NNTest\" in \"ViewAllContent\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
testRunner.And("I submit the activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
testRunner.Then("I should see the status of \"NNTest\" assets as \"Passed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("View Activity Score by CS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent")]
        public virtual void ViewActivityScoreByCSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Activity Score by CS Student", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
testRunner.When("I navigate to \"Grades\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
testRunner.And("I select \'Grades\' subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
testRunner.Then("I should see the grade \"100\" of the submitted activity named as \"NNTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Student views the View submission from Gradebook by CS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent")]
        public virtual void StudentViewsTheViewSubmissionFromGradebookByCSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Student views the View submission from Gradebook by CS Student", ((string[])(null)));
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
testRunner.When("I navigate to \"Grades\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
testRunner.And("I select \'Grades\' subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
testRunner.When("I click the \"NNTest\" activity of cmneu \"View Submission\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
testRunner.Then("I should see the grade \"100\" in view submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
testRunner.When("I close the \"View Submission\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Verify the tab navigation by CS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudent")]
        public virtual void ToVerifyTheTabNavigationByCSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Verify the tab navigation by CS Student", ((string[])(null)));
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
testRunner.When("I navigate to \"Grades\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
testRunner.When("I navigate to the \"Overview\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
testRunner.Then("I should be on the \"Overview\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
