﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.3.0
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34003
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceInstructorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceProgramAdmin.Workflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceInstructor", "               As a CS Program Admin\r\n\t\t\tI want to manage all the coursespace ins" +
                    "tructor related usecases \r\n\t\t\tso that I would validate all the coursespace instr" +
                    "uctor scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestFeatures.CourseSpaceInstructorFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add Instructor Course From Catalog by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void AddInstructorCourseFromCatalogBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Instructor Course From Catalog by SMS Instructor", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
testRunner.When("I add Product Course type \"MyItLabSIM5MasterCourse\" course from Search Catalog", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
testRunner.Then("I should see \"MyItLabInstructorCourse\" course on the Global Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate Instructor Course To Get Out From Assigned To Copy State")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void ValidateInstructorCourseToGetOutFromAssignedToCopyState()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Instructor Course To Get Out From Assigned To Copy State", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
testRunner.When("I select course to validate Inactive State to Active State on Global Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
testRunner.Then("I should see \"MyItLabInstructorCourse\" on the Global Home page in Active State", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add Program Course From Catalog by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void AddProgramCourseFromCatalogBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add Program Course From Catalog by SMS Instructor", ((string[])(null)));
#line 17
this.ScenarioSetup(scenarioInfo);
#line 18
testRunner.When("I add product type \"MyITLabForOffice2013Program\" from search catalog", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
testRunner.Then("I should see \"MyITLabOffice2013Program\" course on the Global Home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate Template To Get Out From Assigned To Copy State")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void ValidateTemplateToGetOutFromAssignedToCopyState()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Template To Get Out From Assigned To Copy State", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
testRunner.When("I navigate to \"Templates\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
testRunner.When("I verify the \"MyITLabForOffice2013Master\" course Template for AssignedToCopy stat" +
                    "e", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
testRunner.Then("I should see the \"MyITLabForOffice2013Master\" course Template to be successfully " +
                    "out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Section by Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CreateSectionByProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Section by Program Admin", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
testRunner.When("I click on Add Sections link from the Program Administration page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
testRunner.And("I create Section from \"MyITLabForOffice2013Master\" Template as a Program Admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Section by Program Admin for Course Creation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CreateSectionByProgramAdminForCourseCreation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Section by Program Admin for Course Creation", ((string[])(null)));
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
testRunner.When("I click on Add Sections link from the Program Administration page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
testRunner.And("I create Section from \"MyITLabForOffice2013MasterCourseCreation\" Template as a Pr" +
                    "ogram Admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
testRunner.When("I verify the Section created from \"MyITLabOffice2013ProgramCourseCreation\" course" +
                    " Template for AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
testRunner.Then("I should see the Section created from \"MyITLabOffice2013ProgramCourseCreation\" co" +
                    "urse Template to be successfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
testRunner.When("I filter the template \"MyITLabForOffice2013MasterCourseCreation\" using \'Parent Te" +
                    "mplate\' dropdown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
testRunner.Then("I should see the new section created usign \"MyITLabOffice2013ProgramCourseCreatio" +
                    "n\" in the section list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate Section To Get Out From Assigned To Copy State")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void ValidateSectionToGetOutFromAssignedToCopyState()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Section To Get Out From Assigned To Copy State", ((string[])(null)));
#line 53
this.ScenarioSetup(scenarioInfo);
#line 54
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
testRunner.When("I verify the Section created from \"MyITLabOffice2013Program\" course Template for " +
                    "AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
testRunner.Then("I should see the Section created from \"MyITLabOffice2013Program\" course Template " +
                    "to be successfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Filter Section by Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void FilterSectionByProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Filter Section by Program Admin", ((string[])(null)));
#line 61
this.ScenarioSetup(scenarioInfo);
#line 62
testRunner.When("I filter the template \"MyITLabForOffice2013Master\" using \'Parent Template\' dropdo" +
                    "wn", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
testRunner.Then("I should see the new section created usign \"MyITLabOffice2013Program\" in the sect" +
                    "ion list", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Copying Section As Section")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CopyingSectionAsSection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Copying Section As Section", ((string[])(null)));
#line 66
this.ScenarioSetup(scenarioInfo);
#line 67
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
testRunner.When("I search the section of \"MyITLabOffice2013Program\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
testRunner.And("I click the \"Copy as Section\" c-menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
testRunner.Then("I should be on the \"Copy as Section\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
testRunner.When("I click Copy/Save button to copy", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
testRunner.Then("I should see the successfull message \"Section Copied Successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
testRunner.When("I verify the Section copied from \"MyITLabOffice2013Program\" section for AssignedT" +
                    "oCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
testRunner.Then("I should see the Section copied from \"MyITLabOffice2013Program\" section to be suc" +
                    "cessfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Template by Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CreateTemplateByProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Template by Program Admin", ((string[])(null)));
#line 78
this.ScenarioSetup(scenarioInfo);
#line 79
testRunner.When("I navigate to \"Templates\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
testRunner.And("I create Template using \"MyITLabForOffice2013Master\" course as a program admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Template by Program Admin for Course Creation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CreateTemplateByProgramAdminForCourseCreation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Template by Program Admin for Course Creation", ((string[])(null)));
#line 84
this.ScenarioSetup(scenarioInfo);
#line 85
testRunner.When("I navigate to \"Templates\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 86
testRunner.And("I create Template using \"MyITLabForOffice2013MasterCourseCreation\" course as a pr" +
                    "ogram admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Fresh Template by Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CreateFreshTemplateByProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Fresh Template by Program Admin", ((string[])(null)));
#line 89
this.ScenarioSetup(scenarioInfo);
#line 90
testRunner.When("I navigate to \"Templates\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
testRunner.And("I create Template using \"MyItLabSIM5MasterCourse\" course as a program admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
testRunner.When("I navigate to \"Templates\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
testRunner.When("I verify the \"MyItLabSIM5MasterCourse\" course Template for AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
testRunner.Then("I should see the \"MyItLabSIM5MasterCourse\" course Template to be successfully out" +
                    " of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate Template To Get Out From Assigned To Copy State for Course Creation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void ValidateTemplateToGetOutFromAssignedToCopyStateForCourseCreation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate Template To Get Out From Assigned To Copy State for Course Creation", ((string[])(null)));
#line 100
this.ScenarioSetup(scenarioInfo);
#line 101
testRunner.When("I navigate to \"Templates\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
testRunner.When("I verify the \"MyITLabForOffice2013MasterCourseCreation\" course Template for Assig" +
                    "nedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
testRunner.Then("I should see the \"MyITLabForOffice2013MasterCourseCreation\" course Template to be" +
                    " successfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Shared Library Copy of Template")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CreateSharedLibraryCopyOfTemplate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Shared Library Copy of Template", ((string[])(null)));
#line 107
this.ScenarioSetup(scenarioInfo);
#line 108
testRunner.When("I navigate to \"Templates\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
testRunner.When("I search the template of \"MyITLabForOffice2013MasterCourseCreation\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 111
testRunner.And("I click the \"Copy as Shared Library\" c-menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
testRunner.Then("I should be on the \"Copy as Shared Library\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
testRunner.When("I create Shared Library from \"MyITLabForOffice2013MasterCourseCreation\" Template " +
                    "as a Program Admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 114
testRunner.And("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
testRunner.When("I verify the shared library created from \"MyITLabForOffice2013MasterCourseCreatio" +
                    "n\" course Template for AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
testRunner.Then("I should see the shared library created from \"MyITLabForOffice2013MasterCourseCre" +
                    "ation\" course Template to be successfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Template Copy of Template")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CreateTemplateCopyOfTemplate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Template Copy of Template", ((string[])(null)));
#line 119
this.ScenarioSetup(scenarioInfo);
#line 120
testRunner.When("I navigate to \"Templates\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 121
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 122
testRunner.When("I search the template of \"MyITLabForOffice2013MasterCourseCreation\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 123
testRunner.And("I click the \"Copy as Template\" c-menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
testRunner.Then("I should be on the \"Copy as Template\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
testRunner.When("I create Template from \"MyITLabForOffice2013MasterCourseCreation\" Template as a P" +
                    "rogram Admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 126
testRunner.When("I verify the \"MyITLabForOffice2013MasterCourseCreation\" course Copy Template for " +
                    "AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 127
testRunner.Then("I should see the \"MyITLabForOffice2013MasterCourseCreation\" course Copy Template " +
                    "to be successfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Template Copy of SLC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CreateTemplateCopyOfSLC()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Template Copy of SLC", ((string[])(null)));
#line 130
this.ScenarioSetup(scenarioInfo);
#line 131
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 132
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 133
testRunner.When("I search the shared library of \"MyITLabForOffice2013MasterCourseCreation\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 134
testRunner.And("I click the \"Copy as Template\" c-menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
testRunner.Then("I should be on the \"Copy as Template\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 136
testRunner.When("I create Template from \"MyITLabForOffice2013MasterCourseCreation\" Shared Lirary a" +
                    "s a Program Admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 137
testRunner.When("I navigate to \"Templates\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 138
testRunner.When("I verify the \"MyITLabForOffice2013MasterCourseCreation\" Shared Library Copy Templ" +
                    "ate for AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 139
testRunner.Then("I should see the \"MyITLabForOffice2013MasterCourseCreation\" Shared Library Copy T" +
                    "emplate to be successfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Template Copy of fresh SLC or existing SLC")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CreateTemplateCopyOfFreshSLCOrExistingSLC()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Template Copy of fresh SLC or existing SLC", ((string[])(null)));
#line 143
this.ScenarioSetup(scenarioInfo);
#line 144
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 145
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 146
testRunner.And("I create Template copy of  fresh or existing \"MyITLabForOffice2013MasterCourseCre" +
                    "ation\" shared library", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
testRunner.Then("I should be on the \"Copy as Template\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 148
testRunner.When("I create Template from \"MyITLabForOffice2013MasterCourseCreation\" Shared Lirary a" +
                    "s a Program Admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 149
testRunner.When("I navigate to \"Templates\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
testRunner.When("I verify the \"MyITLabForOffice2013MasterCourseCreation\" Shared Library Copy Templ" +
                    "ate for AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 151
testRunner.Then("I should see the \"MyITLabForOffice2013MasterCourseCreation\" Shared Library Copy T" +
                    "emplate to be successfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Copying Section As Section for Course Creation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CopyingSectionAsSectionForCourseCreation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Copying Section As Section for Course Creation", ((string[])(null)));
#line 154
this.ScenarioSetup(scenarioInfo);
#line 155
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 156
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 157
testRunner.When("I search the section of \"MyITLabOffice2013ProgramCourseCreation\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 158
testRunner.And("I click the \"Copy as Section\" c-menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
testRunner.Then("I should be on the \"Copy as Section\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 160
testRunner.When("I click Copy/Save button to copy", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 161
testRunner.Then("I should see the successfull message \"Section Copied Successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 162
testRunner.When("I verify the Section copied from \"MyITLabOffice2013ProgramCourseCreation\" section" +
                    " for AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 163
testRunner.Then("I should see the Section copied from \"MyITLabOffice2013ProgramCourseCreation\" sec" +
                    "tion to be successfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Section using Fresh Template by Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructor")]
        public virtual void CreateSectionUsingFreshTemplateByProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Section using Fresh Template by Program Admin", ((string[])(null)));
#line 166
this.ScenarioSetup(scenarioInfo);
#line 167
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 168
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 169
testRunner.When("I click on Add Sections link from the Program Administration page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 170
testRunner.And("I create Section from \"MyItLabSIM5MasterCourse\" Template as a Program Admin", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 171
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 172
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 173
testRunner.When("I verify the Section created from \"MyITLabOffice2013ProgramCourseCreation\" course" +
                    " Template for AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 174
testRunner.Then("I should see the Section created from \"MyITLabOffice2013ProgramCourseCreation\" co" +
                    "urse Template to be successfully out of AssignedToCopy state", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
