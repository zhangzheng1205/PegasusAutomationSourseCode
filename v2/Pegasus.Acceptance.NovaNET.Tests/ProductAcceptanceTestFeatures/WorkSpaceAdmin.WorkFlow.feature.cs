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
namespace Pegasus.Acceptance.NovaNET.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class WorkSpaceAdminFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "WorkSpaceAdmin.WorkFlow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "WorkSpaceAdmin", "               As a WS Admin \r\n\t\t\tI want to manage all the workspace admin relate" +
                    "d usecases \r\n\t\t\tso that I would validate all the workspace admin scenarios are w" +
                    "orking fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "WorkSpaceAdmin")))
            {
                Pegasus.Acceptance.NovaNET.Tests.ProductAcceptanceTestFeatures.WorkSpaceAdminFeature.FeatureSetup(null);
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
testRunner.Given("I browsed the login url for \"NovaNETWsAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("I login to Pegasus as \"NovaNETWsAdmin\" in \"WorkSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should be logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.Given("I am on the \"Course Enrollment\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Master Course by WS Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void CreateMasterCourseByWSAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Master Course by WS Admin", ((string[])(null)));
#line 14
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 15
testRunner.When("I click on the \"Create New Courses\" link in \"right\" frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.Then("I should see the \"Create New Courses\" popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
testRunner.When("I create a new \"NovaNETMasterLibrary\" course by selecting \"General Course\" format" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.Then("I should see the successfull message \"New course created successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
testRunner.When("I search \"NovaNETMasterLibrary\" course in workspace by \"CourseName\" and \"Equals\" " +
                    "dropdown option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
testRunner.Then("I should see the searched \"NovaNETMasterLibrary\" course in Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
testRunner.When("I \"Sign out\" from the \"NovaNETWsAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Empty Course by Ws Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void CreateEmptyCourseByWsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Empty Course by Ws Admin", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 26
testRunner.When("I click on the \"Create New Courses\" link in \"right\" frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
testRunner.Then("I should see the \"Create New Courses\" popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
testRunner.When("I create a new \"EmptyClass\" course by selecting \"General Course\" format", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
testRunner.Then("I should see the successfull message \"New course created successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
testRunner.When("I search \"EmptyClass\" course in workspace by \"CourseName\" and \"Equals\" dropdown o" +
                    "ption", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
testRunner.Then("I should see the searched \"EmptyClass\" course in Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
testRunner.When("I \"Sign out\" from the \"NovaNETWsAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Container Course by Ws Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void CreateContainerCourseByWsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Container Course by Ws Admin", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 37
testRunner.When("I click on the \"Create New Courses\" link in \"right\" frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
testRunner.Then("I should see the \"Create New Courses\" popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
testRunner.When("I create a new \"Container\" course by selecting \"General Course\" format", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.Then("I should see the successfull message \"New course created successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
testRunner.When("I search \"Container\" course in workspace by \"CourseName\" and \"Equals\" dropdown op" +
                    "tion", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
testRunner.Then("I should see the searched \"Container\" course in Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
testRunner.When("I \"Sign out\" from the \"NovaNETWsAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Teacher by WS Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void CreateTeacherByWSAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Teacher by WS Admin", ((string[])(null)));
#line 47
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 48
testRunner.When("I click on the \"Create New User\" link in \"left\" frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
testRunner.Then("I should see the \"Create New User\" popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
testRunner.When("I create a new \"WsTeacher\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
testRunner.Then("I should see the successfull message \"New user created successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
testRunner.When("I search the created \"WsTeacher\" in  Manage Users frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
testRunner.Then("I should see the \"WsTeacher\" in Manage Users frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
testRunner.When("I \"Sign out\" from the \"NovaNETWsAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Enroll the User to the Empty Course by Ws Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void EnrollTheUserToTheEmptyCourseByWsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Enroll the User to the Empty Course by Ws Admin", ((string[])(null)));
#line 58
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 59
testRunner.When("I search \"EmptyClass\" course in workspace by \"CourseName\" and \"Equals\" dropdown o" +
                    "ption", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
testRunner.Then("I should see the searched \"EmptyClass\" course in Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 61
testRunner.When("I select the created \"EmptyClass\" course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
testRunner.And("I select the \"WsTeacher\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
testRunner.And("I enroll the \"WsTeacher\" in the selected course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
testRunner.Then("I should see the successfull message \"Teachers enrolled successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
testRunner.And("I should see the enrolled \"WsTeacher\" in the Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
testRunner.When("I \"Sign out\" from the \"NovaNETWsAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Enroll the User to the Container Course by Ws Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void EnrollTheUserToTheContainerCourseByWsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Enroll the User to the Container Course by Ws Admin", ((string[])(null)));
#line 70
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 71
testRunner.When("I search \"Container\" course in workspace by \"CourseName\" and \"Equals\" dropdown op" +
                    "tion", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
testRunner.Then("I should see the searched \"Container\" course in Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
testRunner.When("I select the created \"Container\" course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
testRunner.And("I select the \"WsTeacher\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
testRunner.And("I enroll the \"WsTeacher\" in the selected course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
testRunner.Then("I should see the successfull message \"Teachers enrolled successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
testRunner.And("I should see the enrolled \"WsTeacher\" in the Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
testRunner.When("I \"Sign out\" from the \"NovaNETWsAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Enroll the User to the NovaNetMasterLibrary Course by Ws Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void EnrollTheUserToTheNovaNetMasterLibraryCourseByWsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Enroll the User to the NovaNetMasterLibrary Course by Ws Admin", ((string[])(null)));
#line 82
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 83
testRunner.When("I search \"NovaNETMasterLibrary\" course in workspace by \"CourseName\" and \"Equals\" " +
                    "dropdown option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
testRunner.Then("I should see the searched \"NovaNETMasterLibrary\" course in Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 85
testRunner.When("I select the created \"NovaNETMasterLibrary\" course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 86
testRunner.And("I select the \"WsTeacher\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
testRunner.And("I enroll the \"WsTeacher\" in the selected course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
testRunner.Then("I should see the successfull message \"Teachers enrolled successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
testRunner.And("I should see the enrolled \"WsTeacher\" in the Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
testRunner.When("I \"Sign out\" from the \"NovaNETWsAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Publish Empty Course by WsAdmin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void PublishEmptyCourseByWsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Publish Empty Course by WsAdmin", ((string[])(null)));
#line 94
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 95
testRunner.When("I search \"EmptyClass\" course in workspace by \"CourseName\" and \"Equals\" dropdown o" +
                    "ption", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
testRunner.Then("I should see the searched \"EmptyClass\" course in Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
testRunner.When("I publish the \"EmptyClass\" course in workspace as \"Master Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
testRunner.Then("I should see the successfull message \"Course published successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
testRunner.When("I \"Sign out\" from the \"NovaNETWsAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Publish Container Course by WsAdmin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void PublishContainerCourseByWsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Publish Container Course by WsAdmin", ((string[])(null)));
#line 103
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 104
testRunner.When("I search \"Container\" course in workspace by \"CourseName\" and \"Equals\" dropdown op" +
                    "tion", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 105
testRunner.Then("I should see the searched \"Container\" course in Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 106
testRunner.When("I publish the \"Container\" course in workspace as \"Master Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 107
testRunner.Then("I should see the successfull message \"Course published successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 108
testRunner.When("I \"Sign out\" from the \"NovaNETWsAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Publish Master Library by WsAdmin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void PublishMasterLibraryByWsAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Publish Master Library by WsAdmin", ((string[])(null)));
#line 112
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 113
testRunner.When("I search \"NovaNETMasterLibrary\" course in workspace by \"CourseName\" and \"Equals\" " +
                    "dropdown option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 114
testRunner.Then("I should see the searched \"NovaNETMasterLibrary\" course in Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 115
testRunner.When("I publish the \"NovaNETMasterLibrary\" course in workspace as \"Master Library\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
testRunner.Then("I should see the successfull message \"Course published successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 117
testRunner.When("I \"Sign out\" from the \"NovaNETWsAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete The Created Empty Course by WS Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void DeleteTheCreatedEmptyCourseByWSAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete The Created Empty Course by WS Admin", ((string[])(null)));
#line 121
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 122
testRunner.When("I search \"EmptyClass\" course in workspace by \"CourseName\" and \"Equals\" dropdown o" +
                    "ption", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 123
testRunner.Then("I should see the searched \"EmptyClass\" course in Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 124
testRunner.When("I select the course to delete in manage course frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 125
testRunner.Then("I should see the successfull message \"\"Courses deleted successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 126
testRunner.When("I search \"EmptyClass\" course in workspace by \"CourseName\" and \"Equals\" dropdown o" +
                    "ption", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 127
testRunner.Then("I should see the \"There are no courses. To add courses, click Create New Course.\"" +
                    " message in Manage Course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete The Created Container Course by WS Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void DeleteTheCreatedContainerCourseByWSAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete The Created Container Course by WS Admin", ((string[])(null)));
#line 130
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 131
testRunner.When("I search \"Container\" course in workspace by \"CourseName\" and \"Equals\" dropdown op" +
                    "tion", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 132
testRunner.Then("I should see the searched \"Container\" course in Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 133
testRunner.When("I select the course to delete in manage course frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 134
testRunner.Then("I should see the successfull message \"\"Courses deleted successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
testRunner.When("I search \"Container\" course in workspace by \"CourseName\" and \"Equals\" dropdown op" +
                    "tion", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 136
testRunner.Then("I should see the \"There are no courses. To add courses, click Create New Course.\"" +
                    " message in Manage Course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete The Created Master Course by WS Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void DeleteTheCreatedMasterCourseByWSAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete The Created Master Course by WS Admin", ((string[])(null)));
#line 139
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 140
testRunner.When("I search \"NovaNETMasterLibrary\" course in workspace by \"CourseName\" and \"Equals\" " +
                    "dropdown option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 141
testRunner.Then("I should see the searched \"NovaNETMasterLibrary\" course in Manage Courses frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 142
testRunner.When("I select the course to delete in manage course frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 143
testRunner.Then("I should see the successfull message \"\"Courses deleted successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 144
testRunner.When("I search \"NovaNETMasterLibrary\" course in workspace by \"CourseName\" and \"Equals\" " +
                    "dropdown option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 145
testRunner.Then("I should see the \"There are no courses. To add courses, click Create New Course.\"" +
                    " message in Manage Course", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete The Created User by WS admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "WorkSpaceAdmin")]
        public virtual void DeleteTheCreatedUserByWSAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete The Created User by WS admin", ((string[])(null)));
#line 148
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 149
testRunner.When("I search the created \"WsTeacher\" in  Manage Users frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
testRunner.Then("I should see the \"WsTeacher\" in Manage Users frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 151
testRunner.When("I click the user cmenu option in manage user frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 152
testRunner.And("I select the Cmenu option \"Delete\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
testRunner.And("I select \'OK\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 154
testRunner.Then("I should see the successfull message \"Users deleted successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
