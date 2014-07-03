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
namespace Pegasus.Acceptance.HigherEducationCore.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceAdminFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceAdmin.WorkFlow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceAdmin", "\t\t\tAs a CS Admin \r\n\t\t\tI want to manage all the coursespace admin related usecases" +
                    " \r\n\t\t\tso that I would validate all the coursespace admin scenarios are working f" +
                    "ine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceAdmin")))
            {
                Pegasus.Acceptance.HigherEducationCore.Tests.ProductAcceptanceTestFeatures.CourseSpaceAdminFeature.FeatureSetup(null);
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
testRunner.Given("I browsed the login url for \"HedCsAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("I logged into the Pegasus as \"HedCsAdmin\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Approve Master Course by Cs Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAdmin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ApproveCourse")]
        public virtual void ApproveMasterCourseByCsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Approve Master Course by Cs Admin", new string[] {
                        "ApproveCourse"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 15
testRunner.Given("I am on the \"Course Enrollment\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
testRunner.When("I navigate to the \"Publishing\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.And("I select the \"Manage Products\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
testRunner.Then("I should be on the \"Manage Products\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
testRunner.When("I search the \"MySpanishLabMaster\" course in coursespace", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
testRunner.Then("I should be able to see the searched \"MySpanishLabMaster\" course in the left fram" +
                    "e", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
testRunner.When("I click on \"Approve\" cmenu option of course in coursespace", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
testRunner.Then("I should see the successfull message \"Published course marked as Approved.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Program Creation In CourseSpace by Cs Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAdmin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreateProgram")]
        public virtual void ProgramCreationInCourseSpaceByCsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Program Creation In CourseSpace by Cs Admin", new string[] {
                        "CreateProgram"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 28
testRunner.Given("I am on the \'Manage Programs\' Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
testRunner.When("I click on the Create New Program  Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
testRunner.And("I create the \"HedCore\" Program in coursespace", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
testRunner.Then("I should see the successfull message \"Program created successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create General Product by Cs Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAdmin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreateProduct")]
        public virtual void CreateGeneralProductByCsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create General Product by Cs Admin", new string[] {
                        "CreateProduct"});
#line 36
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 37
testRunner.Given("I am on the \'Manage Products\' Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
testRunner.When("I click on the \'Create New Product\' Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
testRunner.And("I create \"HedCoreGeneral\" type product using \"HedCore\" program type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
testRunner.Then("I should see the successfull message \"New product created successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Program Product by Cs Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAdmin")]
        public virtual void CreateProgramProductByCsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Program Product by Cs Admin", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 45
testRunner.Given("I am on the \'Manage Products\' Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
testRunner.When("I click on the \'Create New Product\' Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
testRunner.And("I create \"HedCoreProgram\" type product using \"HedCore\" program type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
testRunner.Then("I should see the successfull message \"New product created successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Associate Course to the General Product by Cs Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAdmin")]
        public virtual void AssociateCourseToTheGeneralProductByCsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Associate Course to the General Product by Cs Admin", ((string[])(null)));
#line 52
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 53
testRunner.Given("I am on the \'Manage Products\' Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 54
testRunner.When("I search the \"MySpanishLabMaster\" course in coursespace", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
testRunner.Then("I should be able to see the searched \"MySpanishLabMaster\" course in the left fram" +
                    "e", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
testRunner.When("I select course in left frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
testRunner.And("I select product type \"HedCoreGeneral\" in right frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
testRunner.When("I associate the course to Pegasus product", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
testRunner.Then("I should see the successfull message \"Approved courses programmed successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Associate Course to the Program Type Product by Cs Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAdmin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("AssociateToProgram")]
        public virtual void AssociateCourseToTheProgramTypeProductByCsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Associate Course to the Program Type Product by Cs Admin", new string[] {
                        "AssociateToProgram"});
#line 64
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 65
testRunner.Given("I am on the \'Manage Products\' Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 66
testRunner.When("I search the \"MySpanishLabMaster\" course in coursespace", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
testRunner.Then("I should be able to see the searched \"MySpanishLabMaster\" course in the left fram" +
                    "e", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 68
testRunner.When("I select course in left frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
testRunner.And("I select product type \"HedCoreProgram\" in right frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
testRunner.When("I associate the course to Pegasus product", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
testRunner.Then("I should see the successfull message \"Approved courses programmed successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create System Announcement by CS Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAdmin")]
        public virtual void CreateSystemAnnouncementByCSAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create System Announcement by CS Admin", ((string[])(null)));
#line 75
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 76
testRunner.Given("I am on the \"Course Enrollment\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 77
testRunner.When("I change the WS Admin Time Zone to Indian GMT in MyProfile", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
testRunner.And("I navigate to the \"Announcement\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
testRunner.When("I create \"CsSystem\" Announcement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
testRunner.Then("I should see the successfull message \"Announcement created successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete the Created General Type Product by CS Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAdmin")]
        public virtual void DeleteTheCreatedGeneralTypeProductByCSAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete the Created General Type Product by CS Admin", ((string[])(null)));
#line 83
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 84
testRunner.Given("I am on the \"Course Enrollment\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 85
testRunner.When("I navigate to the \"Publishing\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 86
testRunner.And("I select the \"Manage Products\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
testRunner.Then("I should be on the \"Manage Products\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
testRunner.When("I search the product type \"HedCoreGeneral\" in right frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 89
testRunner.And("I click on \"Delete\" cmenu option of product in coursespace", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
testRunner.Then("I should see the successfull message \"Products deleted successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete the Created Program Type Product by CS Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAdmin")]
        public virtual void DeleteTheCreatedProgramTypeProductByCSAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete the Created Program Type Product by CS Admin", ((string[])(null)));
#line 93
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 94
testRunner.Given("I am on the \"Course Enrollment\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 95
testRunner.When("I navigate to the \"Publishing\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
testRunner.And("I select the \"Manage Products\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
testRunner.Then("I should be on the \"Manage Products\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 98
testRunner.When("I search the product type \"HedCoreProgram\" in right frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 99
testRunner.And("I click on \"Delete\" cmenu option of product in coursespace", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
testRunner.Then("I should see the successfull message \"Products deleted successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Approve Empty Course by Cs Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAdmin")]
        public virtual void ApproveEmptyCourseByCsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Approve Empty Course by Cs Admin", ((string[])(null)));
#line 103
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 104
testRunner.Given("I am on the \"Course Enrollment\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 105
testRunner.When("I navigate to the \"Publishing\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
testRunner.And("I select the \"Manage Products\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
testRunner.Then("I should be on the \"Manage Products\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 108
testRunner.When("I search the \"HedEmptyClass\" course in coursespace", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
testRunner.Then("I should be able to see the searched \"HedEmptyClass\" course in the left frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
testRunner.When("I click on \"Approve as Empty Class\" cmenu option of course in coursespace", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 111
testRunner.Then("I should see the successfull message \"Published course marked as Approved.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
