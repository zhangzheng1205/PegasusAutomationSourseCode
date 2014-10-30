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
namespace Pegasus.Acceptance.DigitalPath.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.1.84")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceTeacherFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceTeacher.WorkFlow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceTeacher", "               As a CS Teacher \n\t\t\tI want to manage all the coursespace teacher  " +
                    "related usecases \n\t\t\tso that I would validate all the coursespace teacher scenar" +
                    "ios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceTeacher")))
            {
                Pegasus.Acceptance.DigitalPath.Tests.ProductAcceptanceTestFeatures.CourseSpaceTeacherFeature.FeatureSetup(null);
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
testRunner.Given("I browsed the login url for \"DPCsTeacher\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("I login to Pegasus as \"DPCsTeacher\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.Given("I am on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("View System Announcement by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void ViewSystemAnnouncementByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View System Announcement by CS Teacher", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 15
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
testRunner.When("I changed the CS User Time Zone to Indian GMT in MyProfile by \"DPCsTeacher\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.And("I click on the Messages and select the View All link by \"DPCsTeacher\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.And("I select \"System Announcements\" in \'View by\' drop down", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
testRunner.Then("I should see the details of  \"CsSystem\" Announcement in Announcement Light box", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Class Announcement by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void CreateClassAnnouncementByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Class Announcement by CS Teacher", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 24
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
testRunner.When("I click on the Messages and select the View All link by \"DPCsTeacher\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
testRunner.And("I create \"CsCourse\" Announcement in coursespace", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.Then("I should see the successfull message \"Announcement created successfully.\" in Anno" +
                    "uncements Frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Course Announcement by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void CreateCourseAnnouncementByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Course Announcement by CS Teacher", ((string[])(null)));
#line 31
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 32
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
testRunner.When("I enter into the \"DigitalPathMasterLibrary\" class", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
testRunner.When("I create CS Course Announcement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
testRunner.Then("I should see the successfull message \"Announcement created successfully.\" in Anno" +
                    "uncements Frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 37
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("View Welcome Message by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void ViewWelcomeMessageByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Welcome Message by CS Teacher", ((string[])(null)));
#line 41
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 42
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
testRunner.Then("I should see the welcome message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
testRunner.When("I close the welcome message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
testRunner.Then("I should see the welcome message popup closed successfully for \"DPCsTeacher\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("View Home Page Tabs by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void ViewHomePageTabsByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Home Page Tabs by CS Teacher", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 50
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
testRunner.Then("I should see the Home Page tabs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("View Enrolled Classes in Classes Frame by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void ViewEnrolledClassesInClassesFrameByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Enrolled Classes in Classes Frame by CS Teacher", ((string[])(null)));
#line 55
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 56
testRunner.When("I navigate to the \"Classes\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
testRunner.Then("I should be on the \"Classes\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 59
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("View Basal Products in the Curriculum Channel by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void ViewBasalProductsInTheCurriculumChannelByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Basal Products in the Curriculum Channel by CS Teacher", ((string[])(null)));
#line 62
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 63
testRunner.When("I navigate to the \"Curriculum\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
testRunner.Then("I should see the \"DigitalPath\" Product in the Curriculum Channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Access Class by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void AccessClassByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Access Class by CS Teacher", ((string[])(null)));
#line 69
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 70
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
testRunner.When("I click on the Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
testRunner.Then("I should be able to see the \"DigitalPath\" product", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 74
testRunner.When("I click on the Cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 75
testRunner.Then("I should able to see the \"DigitalPathMasterLibrary\" class", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
testRunner.When("I enter into the \"DigitalPathMasterLibrary\" class", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
testRunner.Then("I should be on the \"Classes\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 78
testRunner.When("I navigate to the \"Planner\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
testRunner.Then("I should be on the \"Planner\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Basic Search in Curriculum Tab by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void BasicSearchInCurriculumTabByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basic Search in Curriculum Tab by CS Teacher", ((string[])(null)));
#line 82
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 83
testRunner.When("I navigate to the \"Curriculum\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
testRunner.And("I search the asset type \"Test\" by \"TableofContents\" criteria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
testRunner.Then("I should see the searched asset \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 86
testRunner.When("I clear the searched result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
testRunner.Then("I should not see the searched result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
testRunner.When("I search the asset type \"Test\" by \"Skill\" criteria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 89
testRunner.Then("I should see the searched asset \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 90
testRunner.When("I clear the searched result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
testRunner.Then("I should not see the searched result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 92
testRunner.When("I search the asset type \"Test\" by \"ContentType\" criteria", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
testRunner.Then("I should see the searched asset \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
testRunner.When("I clear the searched result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
testRunner.Then("I should not see the searched result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Advanced Search in Curriculum Tab by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void AdvancedSearchInCurriculumTabByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Advanced Search in Curriculum Tab by CS Teacher", ((string[])(null)));
#line 98
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 99
testRunner.When("I navigate to the \"Curriculum\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
testRunner.And("I search the asset type \"Test\" in \"Curriculum\" tab using Advanced Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
testRunner.Then("I should see the searched asset \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
testRunner.When("I clear the searched result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
testRunner.Then("I should not see the searched result", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Basic Search in Planner Tab by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void BasicSearchInPlannerTabByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basic Search in Planner Tab by CS Teacher", ((string[])(null)));
#line 106
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 107
testRunner.When("I navigate to the \"Planner\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
testRunner.And("I search the asset \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
testRunner.Then("I should see the searched asset \"Test\" successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
testRunner.When("I clear the searched result in planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 111
testRunner.Then("I should not see the searched result in planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Advanced Search in Planner Tab by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void AdvancedSearchInPlannerTabByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Advanced Search in Planner Tab by CS Teacher", ((string[])(null)));
#line 114
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 115
testRunner.When("I navigate to the \"Planner\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
testRunner.And("I search the asset type \"Test\" in \"Planner\" tab using Advanced Search", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
testRunner.Then("I should see the searched asset \"Test\" in planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 118
testRunner.When("I clear the searched result in planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
testRunner.Then("I should not see the searched result in planner tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Customize Content In Curriculum Tab by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void CustomizeContentInCurriculumTabByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Customize Content In Curriculum Tab by CS Teacher", ((string[])(null)));
#line 122
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 123
testRunner.When("I navigate to the \"Curriculum\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
testRunner.And("I customize the content \"Test\" in curriculum tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
testRunner.Then("I should see the successfull message \"You have successfully added custom content." +
                    "\" in Curriculum tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 126
testRunner.When("I click on the custom content link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 127
testRunner.Then("I should see the ML in the custom content view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
testRunner.When("I click on the expand button of MasterLibrary in the custom content view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 129
testRunner.Then("I should see the customized \"Test\" content of the ML in the custom content view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 131
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Licenced Assets in Global by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void CreateLicencedAssetsInGlobalByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Licenced Assets in Global by CS Teacher", ((string[])(null)));
#line 134
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 135
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 136
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 137
testRunner.When("I click The \"Custom Content\" link in Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 138
testRunner.Then("I should see the \"MasterLibrary\" course in the custom content view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 139
testRunner.When("I mouseover on the Licensed content", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 140
testRunner.And("I create the global \"Licensed\" content \"Test\" activity and \'TrueFalse\' question i" +
                    "n global", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 141
testRunner.Then("I should see the successfull message \"Activity added successfully.\" in Curriculum" +
                    " tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create NonLicenced TestAssets in Global by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void CreateNonLicencedTestAssetsInGlobalByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create NonLicenced TestAssets in Global by CS Teacher", ((string[])(null)));
#line 144
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 145
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 146
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 147
testRunner.When("I click The \"Custom Content\" link in Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 148
testRunner.Then("I should see the \"MasterLibrary\" course in the custom content view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 149
testRunner.When("I Create the custom content \"Folder\" activity global", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
testRunner.Then("I should see the successfull message \"Folder saved successfully.\" in Curriculum t" +
                    "ab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 151
testRunner.When("I mouseOver on the NonLicensed Assets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 152
testRunner.And("I create the global \"NonLicensed\" content \"Test\" activity and \'TrueFalse\' questio" +
                    "n in global", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
testRunner.Then("I should see the successfull message \"Activity added successfully.\" in Curriculum" +
                    " tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create NonLicenced LinkAssets in Global by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void CreateNonLicencedLinkAssetsInGlobalByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create NonLicenced LinkAssets in Global by CS Teacher", ((string[])(null)));
#line 156
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 157
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 158
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 159
testRunner.When("I click The \"Custom Content\" link in Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 160
testRunner.Then("I should see the \"MasterLibrary\" course in the custom content view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 161
testRunner.When("I create the nonGgadable \"Link\" activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 162
testRunner.Then("I should see the successfull message \"Link saved successfully.\" in Curriculum tab" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Copy paste of Licensed Assets by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void CopyPasteOfLicensedAssetsByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Copy paste of Licensed Assets by CS Teacher", ((string[])(null)));
#line 165
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 166
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 167
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 168
testRunner.When("I click The \"Custom Content\" link in Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 169
testRunner.Then("I should see the \"MasterLibrary\" course in the custom content view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 170
testRunner.When("I click on the expand button of MasterLibrary in the custom content view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 171
testRunner.And("I should able to see the \"Licensed\" customized content \"Test\" Assets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 172
testRunner.And("I select the \"Licensed\" CopyPaste link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 173
testRunner.Then("I should see the successfull message \"Items copied successfully.\" in Curriculum t" +
                    "ab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 174
testRunner.When("I Clear the Clipboard link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 175
testRunner.And("I click on the expand button of MasterLibrary in the custom content view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
testRunner.And("I remove the \"Licensed\" copied content", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 177
testRunner.Then("I should see the successfull message \"Items deleted successfully.\" in Curriculum " +
                    "tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 178
testRunner.When("I should able to see the \"Licensed\" customized content \"Test\" Assets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 179
testRunner.And("I select the \"Licensed\" CutPaste link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
testRunner.Then("I should see the successfull message \"Selected items moved successfully.\" in Curr" +
                    "iculum tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Copy paste of NonLicensed Assets by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void CopyPasteOfNonLicensedAssetsByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Copy paste of NonLicensed Assets by CS Teacher", ((string[])(null)));
#line 183
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 184
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 185
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 186
testRunner.When("I click The \"Custom Content\" link in Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 187
testRunner.Then("I should see the \"MasterLibrary\" course in the custom content view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 188
testRunner.When("I click on the expand button of Non licensed Folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 189
testRunner.And("I should able to see the \"NonLicensed\" customized content \"Test\" Assets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 190
testRunner.And("I select the \"NonLicensed\" CopyPaste link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 191
testRunner.Then("I should see the successfull message \"Items copied successfully.\" in Curriculum t" +
                    "ab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 192
testRunner.When("I Clear the Clipboard link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 193
testRunner.And("I click on the expand button of Non licensed Folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 194
testRunner.And("I remove the \"NonLicensed\" copied content", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 195
testRunner.Then("I should see the successfull message \"Items deleted successfully.\" in Curriculum " +
                    "tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 196
testRunner.When("I should able to see the \"NonLicensed\" customized content \"Test\" Assets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 197
testRunner.And("I select the \"NonLicensed\" CutPaste link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 198
testRunner.Then("I should see the successfull message \"Selected items moved successfully.\" in Curr" +
                    "iculum tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Sending Mail Message by CS Teacher")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceTeacher")]
        public virtual void SendingMailMessageByCSTeacher()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Sending Mail Message by CS Teacher", ((string[])(null)));
#line 201
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 202
testRunner.When("I navigate to the \"Home\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 203
testRunner.Then("I should be on the \"Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 204
testRunner.When("I create mail by \"DPCsTeacher\" in CourseSpace", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 205
testRunner.And("I send created mail to CourseSpace users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 206
testRunner.Then("I should see the successfull message \"Your message has been sent.\" in the send ma" +
                    "il popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 207
testRunner.When("I close the mail popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 208
testRunner.Then("I should see the mail popup closed successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
