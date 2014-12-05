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
namespace Pegasus.Acceptance.HigherEducation.HSS.Tests.CommonProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CommonUserLoginLogOutFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CommonUserLoginLogOut.feature"
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
                Pegasus.Acceptance.HigherEducation.HSS.Tests.CommonProductAcceptanceTestFeatures.CommonUserLoginLogOutFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User Login As HSSProgramAdmin and Navigate To HSSMyPsychLabProgram Course")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonUserLoginLogOut")]
        public virtual void UserLoginAsHSSProgramAdminAndNavigateToHSSMyPsychLabProgramCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User Login As HSSProgramAdmin and Navigate To HSSMyPsychLabProgram Course", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.Given("I browsed the login url for \"HSSProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("I logged into the Pegasus as \"HSSProgramAdmin\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
testRunner.When("I enter in the \"HSSMyPsychLabProgram\" from the Global Home page as \"HSSProgramAdm" +
                    "in\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User Login As HSSCsSMSInstructor and navigate to HSSMyPsychLabProgram Course")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonUserLoginLogOut")]
        public virtual void UserLoginAsHSSCsSMSInstructorAndNavigateToHSSMyPsychLabProgramCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User Login As HSSCsSMSInstructor and navigate to HSSMyPsychLabProgram Course", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
testRunner.Given("I browsed the login url for \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
testRunner.When("I logged into the Pegasus as \"HSSCsSmsInstructor\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.Then("I should logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
testRunner.When("I enter in the \"HSSMyPsychLabProgram\" from the Global Home page as \"HSSCsSmsInstr" +
                    "uctor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User Login As HSSCsSMSStudent")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonUserLoginLogOut")]
        public virtual void UserLoginAsHSSCsSMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User Login As HSSCsSMSStudent", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
testRunner.Given("I browsed the login url for \"HSSCsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
testRunner.When("I logged into the Pegasus as \"HSSCsSmsStudent\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
testRunner.Then("I should logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User Login As HSSCsSMSStudent and navigate to HSSMyPsychLabProgram Course")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonUserLoginLogOut")]
        public virtual void UserLoginAsHSSCsSMSStudentAndNavigateToHSSMyPsychLabProgramCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User Login As HSSCsSMSStudent and navigate to HSSMyPsychLabProgram Course", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
testRunner.Given("I browsed the login url for \"HSSCsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 32
testRunner.When("I logged into the Pegasus as \"HSSCsSmsStudent\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
testRunner.Then("I should logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 35
testRunner.When("I enter in the \"HSSMyPsychLabProgram\" from the Global Home page as \"HSSCsSmsStude" +
                    "nt\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User login as HSSCsSMSStudent student to score zero percent")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonUserLoginLogOut")]
        public virtual void UserLoginAsHSSCsSMSStudentStudentToScoreZeroPercent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User login as HSSCsSMSStudent student to score zero percent", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
testRunner.Given("I browsed the login url for \"HSSCsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
testRunner.When("I login as \"scoring 0\" into the pegasus as \"HSSCsSmsStudent\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
testRunner.Then("I should logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User login as HSSCsSMSStudent student to score zero percent and navigate to instr" +
            "uctor course")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonUserLoginLogOut")]
        public virtual void UserLoginAsHSSCsSMSStudentStudentToScoreZeroPercentAndNavigateToInstructorCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User login as HSSCsSMSStudent student to score zero percent and navigate to instr" +
                    "uctor course", ((string[])(null)));
#line 45
this.ScenarioSetup(scenarioInfo);
#line 46
testRunner.Given("I browsed the login url for \"HSSCsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
testRunner.When("I login as \"scoring 0\" into the pegasus as \"HSSCsSmsStudent\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
testRunner.Then("I should logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 50
testRunner.When("I enter in the \"HSSMyPsychLabProgram\" from the Global Home page as \"HSSCsSmsStude" +
                    "nt\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User LogOut As HSSCsSMSInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonUserLoginLogOut")]
        public virtual void UserLogOutAsHSSCsSMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User LogOut As HSSCsSMSInstructor", ((string[])(null)));
#line 53
this.ScenarioSetup(scenarioInfo);
#line 54
testRunner.When("I \"Sign out\" from the \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User LogOut As HSSCsSMSStudent")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonUserLoginLogOut")]
        public virtual void UserLogOutAsHSSCsSMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User LogOut As HSSCsSMSStudent", ((string[])(null)));
#line 58
this.ScenarioSetup(scenarioInfo);
#line 59
testRunner.When("I \"Sign out\" from the \"HSSCsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User LogOut As HSSCourseSpaceAdmin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonUserLoginLogOut")]
        public virtual void UserLogOutAsHSSCourseSpaceAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User LogOut As HSSCourseSpaceAdmin", ((string[])(null)));
#line 63
this.ScenarioSetup(scenarioInfo);
#line 64
testRunner.When("I \"Sign out\" from the \"HSSProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User Login As HSSCsSMSInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonUserLoginLogOut")]
        public virtual void UserLoginAsHSSCsSMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User Login As HSSCsSMSInstructor", ((string[])(null)));
#line 69
this.ScenarioSetup(scenarioInfo);
#line 70
testRunner.Given("I browsed the login url for \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 71
testRunner.When("I logged into the Pegasus as \"HSSCsSmsInstructor\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
testRunner.Then("I should logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("User Login Program Admin and Navigate MyITLabOffice2013Section Course")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CommonUserLoginLogOut")]
        public virtual void UserLoginProgramAdminAndNavigateMyITLabOffice2013SectionCourse()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User Login Program Admin and Navigate MyITLabOffice2013Section Course", ((string[])(null)));
#line 77
this.ScenarioSetup(scenarioInfo);
#line 78
testRunner.Given("I browsed the login url for \"HSSProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 79
testRunner.When("I logged into the Pegasus as \"HSSProgramAdmin\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
testRunner.Then("I should logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
testRunner.When("I enter in the \"HSSMyPsychLabProgram\" from the Global Home page as \"HSSCsSmsInstr" +
                    "uctor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 83
testRunner.When("I navigate to \"Sections\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 85
testRunner.When("I search the \"HSSMyPsychLabProgram\" first section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 86
testRunner.And("I click the \"Enter Section as Instructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
