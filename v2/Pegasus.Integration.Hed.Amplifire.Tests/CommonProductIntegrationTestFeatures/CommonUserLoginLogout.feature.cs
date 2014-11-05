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
namespace Pegasus.Integration.Hed.Amplifire.Tests.CommonProductIntegrationTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CommonUserLoginLogOutFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CommonUserLoginLogout.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CommonUserLoginLogOut", "\t\tAs a Pegasus User\r\n\t\tI want to manage all the Pegasus User related usecases \r\n\t" +
                    "\tso that I would validate all the Pegasus User scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CommonUserLoginLogOut")))
            {
                Pegasus.Integration.Hed.Amplifire.Tests.CommonProductIntegrationTestFeatures.CommonUserLoginLogOutFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User Login as CourseSpace Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonUserLoginLogOut")]
        public virtual void UserLoginAsCourseSpaceProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User Login as CourseSpace Program Admin", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("I browsed the login url for \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("I logged into the Pegasus as \"HedProgramAdmin\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User Login CourseSpace Program Admin and Navigate ProgramCourse Course")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonUserLoginLogOut")]
        public virtual void UserLoginCourseSpaceProgramAdminAndNavigateProgramCourseCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User Login CourseSpace Program Admin and Navigate ProgramCourse Course", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
testRunner.Given("I browsed the login url for \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
testRunner.When("I logged into the Pegasus as \"HedProgramAdmin\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
testRunner.When("I enter in the \"ProgramCourse\" course from the Global Home page as \"HedProgramAdm" +
                    "in\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.When("I search the \"ProgramCourse\" first section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.And("I click the \"Enter Section as Instructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion