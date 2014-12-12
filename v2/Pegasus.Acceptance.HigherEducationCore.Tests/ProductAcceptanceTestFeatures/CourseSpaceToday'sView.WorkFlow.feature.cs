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
    public partial class CourseSpaceTodaySViewFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceToday'sView.WorkFlow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceToday\'sView", "               As a CS Instructor \r\n\t\t\tI want to manage all the coursespace Today" +
                    "\'s View related usecases \r\n\t\t\tso that I would validate all the Today\'s View scen" +
                    "arios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceToday\'sView")))
            {
                Pegasus.Acceptance.HigherEducation.WL.Tests.ProductAcceptanceTestFeatures.CourseSpaceTodaySViewFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("View Activity Alerts by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceToday\'sView")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ViewActivityAlert")]
        public virtual void ViewActivityAlertsBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Activity Alerts by SMS Instructor", new string[] {
                        "ViewActivityAlert"});
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
testRunner.When("I navigate to \"Today\'s View\" page by More option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
testRunner.Then("I should successfully see the alert for New Grades", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
testRunner.When("I click New Grades alert option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
testRunner.Then("I should successfully see the submitted activity name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sending Mail Message by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceToday\'sView")]
        public virtual void SendingMailMessageByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sending Mail Message by CS Teacher", ((string[])(null)));
#line 19
this.ScenarioSetup(scenarioInfo);
#line 20
testRunner.When("I navigate to \"Communicate\" tab and selected \"Mail\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
testRunner.Then("I should be on the \"Course Mail\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
testRunner.When("I create a mail by \"CsSmsInstructor\" for \"InstructorCourse\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
testRunner.And("I send the created mail to CourseSpace users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
testRunner.Then("I should see the successfull message \"Your message has been sent.\" in \"Course Mai" +
                    "l\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor should be notified with alert count in \"Instructor Grading\" channel wh" +
            "en student submits Manual Gradable activities")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceToday\'sView")]
        public virtual void InstructorShouldBeNotifiedWithAlertCountInInstructorGradingChannelWhenStudentSubmitsManualGradableActivities()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor should be notified with alert count in \"Instructor Grading\" channel wh" +
                    "en student submits Manual Gradable activities", ((string[])(null)));
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
testRunner.Given("I browsed the login url for \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
testRunner.When("I logged into the Pegasus as \"HSSCsSmsInstructor\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
testRunner.Then("I should logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
testRunner.When("I enter in the \"MySpanishLabProgram\" from the Global Home page as \"HSSCsSmsInstru" +
                    "ctor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
testRunner.Then("I should see the \"Instructor Grading (1)\" channels in \'Todays view\' page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
testRunner.And("I should see the alert count updated as \"1\" in \"Instructor Grading (1)\" channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
testRunner.When("I click on the \"Instructor Grading (1)\" option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
testRunner.Then("I should see the activity \"SAM Activity:SAM 01-05 Heritage Language: tu español. " +
                    "[Vocabulario 1. La familia]\" in the Instructor grading channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
