﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceStudentGlobalHomePageFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceStudentGlobalHomePage.Workflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceStudentGlobalHomePage", "              As a CS Student \r\n\t\t   I want to manage all the coursespace student" +
                    " related usecases \r\n\t\t   so that I would validate all the coursespace student sc" +
                    "enarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceStudentGlobalHomePage")))
            {
                Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestFeatures.CourseSpaceStudentGlobalHomePageFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("My Profile Quick links accessibility by SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void MyProfileQuickLinksAccessibilityBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("My Profile Quick links accessibility by SMS Student", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
testRunner.When("I click on \'My Profile\' option in \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.Then("I should see the \"My ProfileMy Pearson accountTime zoneLocalization\" in \'My Profi" +
                    "le\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Feedback Quick links accessibility by SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void FeedbackQuickLinksAccessibilityBySMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Feedback Quick links accessibility by SMS Student", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 17
testRunner.When("I click on \'Feedback\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.Then("I should be on the \"Feedback\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
testRunner.And("I should see the \"General feedbackCourse Materials feedback\" in the \'Feedback\' wi" +
                    "ndow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
testRunner.When("I close the \"Feedback\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate expand and collapse functionaly of \"My Courses and Testbanks\" as CsSmsSt" +
            "udent")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void ValidateExpandAndCollapseFunctionalyOfMyCoursesAndTestbanksAsCsSmsStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate expand and collapse functionaly of \"My Courses and Testbanks\" as CsSmsSt" +
                    "udent", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
testRunner.When("I click on \"Expand\" icon in \"My Courses and Testbanks\" frame as \"CsSmsStudent\" us" +
                    "er", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate enrolled course in \"My Courses and Testbanks\" channel for SMS Student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void ValidateEnrolledCourseInMyCoursesAndTestbanksChannelForSMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate enrolled course in \"My Courses and Testbanks\" channel for SMS Student", ((string[])(null)));
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
testRunner.Then("I should be displayed with \"RegMyITLabNewCourseForEnrollment\" course as \"CsSmsStu" +
                    "dent\" in \"My Courses and Testbanks\" channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
testRunner.When("I click on Open button of \"RegMyITLabNewCourseForEnrollment\" as \"CsSmsStudent\" us" +
                    "er", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CSSMSStudent validate functionality of help link in header on global home")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void CSSMSStudentValidateFunctionalityOfHelpLinkInHeaderOnGlobalHome()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CSSMSStudent validate functionality of help link in header on global home", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
testRunner.When("I click on \"Help\" option in \"Global Home\" tab of \"MyItLabAuthoredCourse\" as \"CsSm" +
                    "sStudent\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.Then("I should be on \"Home Page Help\" page as \"CsSmsStudent\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
testRunner.And("I close the \"Home Page Help\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CSSMSStudent validate Support link functionality on global home")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void CSSMSStudentValidateSupportLinkFunctionalityOnGlobalHome()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CSSMSStudent validate Support link functionality on global home", ((string[])(null)));
#line 46
this.ScenarioSetup(scenarioInfo);
#line 47
testRunner.When("I click on \"Support\" option in \"Global Home\" tab of \"MyItLabAuthoredCourse\" as \"C" +
                    "sSmsStudent\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
testRunner.Then("I should be on \"Pearson Education Customer Technical Support\" page as \"CsSmsStude" +
                    "nt\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
testRunner.When("I close the \"Support\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate user name and welcome message in header of global home for CSSMSStudent")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void ValidateUserNameAndWelcomeMessageInHeaderOfGlobalHomeForCSSMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate user name and welcome message in header of global home for CSSMSStudent", ((string[])(null)));
#line 55
this.ScenarioSetup(scenarioInfo);
#line 56
testRunner.Then("I should be displayed with \"Hi,\" message for \"CsSmsStudent\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CSSMSStudent validate  My Profile link functionality in global home")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void CSSMSStudentValidateMyProfileLinkFunctionalityInGlobalHome()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CSSMSStudent validate  My Profile link functionality in global home", ((string[])(null)));
#line 61
this.ScenarioSetup(scenarioInfo);
#line 62
testRunner.When("I click on \"My Profile\" option in \"Global Home\" tab of \"MyItLabAuthoredCourse\" as" +
                    " \"CsSmsStudent\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
testRunner.Then("I should be displayed with \"My Pearson account\" lightbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CSSMSStudent validate Privacy link functionality in course global home")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void CSSMSStudentValidatePrivacyLinkFunctionalityInCourseGlobalHome()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CSSMSStudent validate Privacy link functionality in course global home", ((string[])(null)));
#line 68
this.ScenarioSetup(scenarioInfo);
#line 69
testRunner.When("I click on \"Privacy\" option in \"Global Home\" tab of \"MyItLabAuthoredCourse\" as \"C" +
                    "sSmsStudent\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
testRunner.Then("I should be on the \"Privacy\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
testRunner.And("I close the \"Privacy\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Logout of Pegasus as CsSmsStudent from global home")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void LogoutOfPegasusAsCsSmsStudentFromGlobalHome()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Logout of Pegasus as CsSmsStudent from global home", ((string[])(null)));
#line 76
this.ScenarioSetup(scenarioInfo);
#line 77
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 78
testRunner.When("I click on \"Sign out\" option in \"Global Home\" tab of \"MyItLabAuthoredCourse\" as \"" +
                    "CsSmsStudent\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
testRunner.Then("I should see the successfull message \"You have been signed out of the application" +
                    ".\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate self enrollment for student")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void ValidateSelfEnrollmentForStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate self enrollment for student", ((string[])(null)));
#line 87
this.ScenarioSetup(scenarioInfo);
#line 88
testRunner.When("I click on \"Enroll in a Course\" button in \"My Courses and Testbanks\" channel as \"" +
                    "CsSmsStudent\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 89
testRunner.Then("I should be displayed with \"Enroll in a course\" lightbox", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 90
testRunner.And("I should be displayed step \"1\" with \"Course ID\" in \"Enroll in a course\" popup as " +
                    "\"CsSmsStudent\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
testRunner.When("I enter \"MyItLabInstructorCourse\" ID and click submit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
testRunner.Then("I should be displayed step \"2\" with \"Confirm Course\" in \"Enroll in a course\" popu" +
                    "p as \"CsSmsStudent\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
testRunner.And("I should be displayed with message \"The Course ID you entered matched the followi" +
                    "ng instructor and course.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
testRunner.And("I should be displayed with the course name \"MyItLabInstructorCourse\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
testRunner.When("I click \"Confirm\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate open button functionallity for course as CsSmsStudent")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void ValidateOpenButtonFunctionallityForCourseAsCsSmsStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate open button functionallity for course as CsSmsStudent", ((string[])(null)));
#line 101
this.ScenarioSetup(scenarioInfo);
#line 102
testRunner.When("I click on Open button of \"MyItLabInstructorCourse\" as \"CsSmsStudent\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
testRunner.Then("I should be displayed with \"MyItLabInstructorCourse\" course information for \"CsSm" +
                    "sStudent\" user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate mark for deletion status for CsSMSStudent")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void ValidateMarkForDeletionStatusForCsSMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate mark for deletion status for CsSMSStudent", ((string[])(null)));
#line 109
this.ScenarioSetup(scenarioInfo);
#line 110
testRunner.Then("I should see the \"Marked for Deletion\" status updated for the \"MyItLabAuthoredCou" +
                    "rse\" course as \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Validate course inactive status for CsSMSStudent")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceStudentGlobalHomePage")]
        public virtual void ValidateCourseInactiveStatusForCsSMSStudent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Validate course inactive status for CsSMSStudent", ((string[])(null)));
#line 116
this.ScenarioSetup(scenarioInfo);
#line 117
testRunner.Then("I should see the \"Course is Inactive\" status updated for the \"MyItLabAuthoredCour" +
                    "se\" course as \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
