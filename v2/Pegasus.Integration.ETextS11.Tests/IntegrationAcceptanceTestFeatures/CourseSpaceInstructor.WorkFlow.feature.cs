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
namespace Pegasus.Integration.Hed.ETextS11.Tests.IntegrationAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceInstructorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceInstructor.WorkFlow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceInstructor", "               As a CS Instructor \r\n\t\t\tI want to manage all the coursespace instr" +
                    "uctor related usecases \r\n\t\t\tso that I would validate all the coursespace instruc" +
                    "tor scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceInstructor")))
            {
                Pegasus.Integration.Hed.ETextS11.Tests.IntegrationAcceptanceTestFeatures.CourseSpaceInstructorFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add Instructor Course From Catalog by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("InsCourse")]
        public virtual void AddInstructorCourseFromCatalogBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Instructor Course From Catalog by SMS Instructor", new string[] {
                        "InsCourse"});
#line 15
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 16
testRunner.When("I add Product Course type \"MySpanishLabMaster\" course from Search Catalog", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.Then("I should see \"InstructorCourse\" on the Global Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
testRunner.When("I \"Sign out\" from the \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate Instructor Course To Get Out From Assigned To Copy State")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void ValidateInstructorCourseToGetOutFromAssignedToCopyState()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Instructor Course To Get Out From Assigned To Copy State", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 22
testRunner.When("I select course to validate Inactive State to Active State on Global Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
testRunner.Then("I should see \"InstructorCourse\" on the Global Home page in Active State", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.When("I \"Sign out\" from the \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add Program Course From Catalog by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ProgramCreation")]
        public virtual void AddProgramCourseFromCatalogBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Program Course From Catalog by SMS Instructor", new string[] {
                        "ProgramCreation"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 30
testRunner.When("I add Product type \"HedCoreProgram\" from Search Catalog", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
testRunner.Then("I should see \"ProgramCourse\" on the Global Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
testRunner.When("I \"Sign out\" from the \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Template by Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CreateTemplateByProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Template by Program Admin", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 37
testRunner.When("I enter in the \"ProgramCourse\" from the Global Home page as \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
testRunner.And("I create Template as a Program Admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
testRunner.And("I \"Sign out\" from the \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate Template To Get Out From Assigned To Copy State")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void ValidateTemplateToGetOutFromAssignedToCopyState()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Template To Get Out From Assigned To Copy State", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 45
testRunner.When("I enter in the \"ProgramCourse\" from the Global Home page as \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
testRunner.And("I verify the Template for AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
testRunner.Then("I should see the Template to be successfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
testRunner.And("I \"Sign out\" from the \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Section by Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CreateSectionByProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Section by Program Admin", ((string[])(null)));
#line 53
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 54
testRunner.When("I enter in the \"ProgramCourse\" from the Global Home page as \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
testRunner.When("I select the \"Sections\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
testRunner.And("I click on Add Sections link from the Program Administration page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
testRunner.And("I create Section from \"MySpanishLabMaster\" Template as a Program Admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
testRunner.And("I \"Sign out\" from the \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate Section To Get Out From Assigned To Copy State")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void ValidateSectionToGetOutFromAssignedToCopyState()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Section To Get Out From Assigned To Copy State", ((string[])(null)));
#line 63
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 64
testRunner.When("I enter in the \"ProgramCourse\" from the Global Home page as \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
testRunner.When("I select the \"Sections\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
testRunner.And("I verified the Section for AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
testRunner.Then("I should see the Section to be successfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
testRunner.And("I \"Sign out\" from the \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
