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
    public partial class CourseSpaceGradeBookFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceGradeBook.WorkFlow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceGradeBook", "                   As a CS Instructor \n\t\t\tI want to manage all the coursespace gr" +
                    "adebook related usecases \n\t\t\tso that I would validate all the gradebook scenario" +
                    "s are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceGradeBook")))
            {
                Pegasus.Acceptance.HigherEducation.WL.Tests.ProductAcceptanceTestFeatures.CourseSpaceGradeBookFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("View Activity Grade by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void ViewActivityGradeBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("View Activity Grade by SMS Instructor", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.And("I should see the grades for submitted activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Manually Grade the Activity by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void ManuallyGradeTheActivityBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Manually Grade the Activity by SMS Instructor", ((string[])(null)));
#line 15
this.ScenarioSetup(scenarioInfo);
#line 16
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
testRunner.When("I manually grade the activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
testRunner.Then("I should see the successfull message \"Batch update completed successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Verify GradeBook Page is Loaded Successfully")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void ToVerifyGradeBookPageIsLoadedSuccessfully()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Verify GradeBook Page is Loaded Successfully", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
testRunner.And("I should see GradeBook page loaded successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
testRunner.When("I navigate to CustomView sub tab in a Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
testRunner.Then("I should be on CustomView in a GradeBook Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
testRunner.When("I navigate to Grades Subtab in a GradeBook Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
testRunner.Then("I should see GradeBook page loaded successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To check the display of Activities in Gradebook by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void ToCheckTheDisplayOfActivitiesInGradebookBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To check the display of Activities in Gradebook by SMS Instructor", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
testRunner.Then("I should see the \"Test\" activity in Gradebook for all the enrollled \"CsSmsStudent" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To check the display of SkillStudyPlan in Gradebook by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void ToCheckTheDisplayOfSkillStudyPlanInGradebookBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To check the display of SkillStudyPlan in Gradebook by SMS Instructor", ((string[])(null)));
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
testRunner.Then("I should see the \"SkillStudyPlan\" activity in Gradebook for all the enrollled \"Cs" +
                    "SmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Verify the functionality of Apply Grade Schema in gradebook")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void ToVerifyTheFunctionalityOfApplyGradeSchemaInGradebook()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Verify the functionality of Apply Grade Schema in gradebook", ((string[])(null)));
#line 51
this.ScenarioSetup(scenarioInfo);
#line 52
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 54
testRunner.When("I navigate to the subfolder \"ADDITIONALPRACTICE\" of asset in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
testRunner.And("I click on cmenu \"ApplyGradeSchema\" of asset \"PA-01 Span Practice- Vocabulary: Sa" +
                    "ludos, despedidas y presentaciones\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
testRunner.Then("I should be on the \"Gradebook schema\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
testRunner.When("I \'Apply\' the grade schema for the submitted activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
testRunner.Then("I should see the successfull message \"Schema applied successfully.\" in \"Gradebook" +
                    "\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
testRunner.Then("I should see the updated schema value \"F\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
testRunner.When("I click on cmenu \"ModifyGradeSchema\" of asset \"PA-01 Span Practice- Vocabulary: S" +
                    "aludos, despedidas y presentaciones\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
testRunner.When("I update the schema of the submitted activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
testRunner.Then("I should see the successfull message \"Grade schema updated successfully.\" in \"Gra" +
                    "debook schema\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 63
testRunner.When("I save the Updated schema", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
testRunner.Then("I should see the successfull message \"Schema applied successfully.\" in \"Gradebook" +
                    "\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
testRunner.When("I click on cmenu \"RemoveGradeSchema\" of asset \"PA-01 Span Practice- Vocabulary: S" +
                    "aludos, despedidas y presentaciones\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
testRunner.Then("I should see the successfull message \"Grade schema removed successfully.\" in \"Gra" +
                    "debook\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 67
testRunner.Then("I should see the updated schema value \"11,1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the functionality of Remove from custom view option By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void VerifyTheFunctionalityOfRemoveFromCustomViewOptionBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the functionality of Remove from custom view option By SMS Instructor", ((string[])(null)));
#line 72
this.ScenarioSetup(scenarioInfo);
#line 73
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
testRunner.When("I click on cmenu \"SavetoCustomView\" of asset \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
testRunner.Then("I should see the successfull message \"Column successfully saved to Custom View.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
testRunner.And("I should see cmenu \"Remove from Custom View\" of asset \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
testRunner.When("I navigate to CustomView sub tab in a Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
testRunner.Then("I should be on the \"Custom View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
testRunner.When("I click on cmenu \"RemovefromCustomView\" of asset \"Test\" in Custom View", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 81
testRunner.Then("I should see the successfull message \"Column successfully removed from Custom Vie" +
                    "w.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the functionality of \"View All Submission\" option by SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void VerifyTheFunctionalityOfViewAllSubmissionOptionBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the functionality of \"View All Submission\" option by SMS Instructor", ((string[])(null)));
#line 86
this.ScenarioSetup(scenarioInfo);
#line 87
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
testRunner.When("I click on cmenu \"ViewAllSubmissions\" of asset \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
testRunner.Then("I should see all submission for that particular activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 91
testRunner.When("I close the \"View Submission\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Display of Grade cell C-menu options for the activity under Gradebook by SMS Inst" +
            "ructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void DisplayOfGradeCellC_MenuOptionsForTheActivityUnderGradebookBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Display of Grade cell C-menu options for the activity under Gradebook by SMS Inst" +
                    "ructor", ((string[])(null)));
#line 96
this.ScenarioSetup(scenarioInfo);
#line 97
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
testRunner.When("I click on the Grade cell cmenu of \"Test\" activity in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
testRunner.Then("I should see the cmenu under grade cell activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Verify The functionality of Grade cell cmenu option\'Edit Grades\'")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void ToVerifyTheFunctionalityOfGradeCellCmenuOptionEditGrades()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Verify The functionality of Grade cell cmenu option\'Edit Grades\'", ((string[])(null)));
#line 105
this.ScenarioSetup(scenarioInfo);
#line 106
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 107
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 108
testRunner.When("I navigate to the subfolder \"ADDITIONALPRACTICE\" of asset in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
testRunner.And("I click on Grade cell cmenu options of asset \"PA-01 Span Practice- Vocabulary: Sa" +
                    "ludos, despedidas y presentaciones\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
testRunner.And("I select the \"EditGrade\" in grade cell cmenu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 111
testRunner.And("I update the grade for the submitted activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
testRunner.Then("I should see the updated grade \"50\" for the asset \"PA-01 Span Practice- Vocabular" +
                    "y: Saludos, despedidas y presentaciones\" for \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
testRunner.And("I should see the grade icon of \"PA-01 Span Practice- Vocabulary: Saludos, despedi" +
                    "das y presentaciones\" for \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the functionality of options displayed when Grade cell cmenu is View Grade" +
            "/Submission By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void VerifyTheFunctionalityOfOptionsDisplayedWhenGradeCellCmenuIsViewGradeSubmissionBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the functionality of options displayed when Grade cell cmenu is View Grade" +
                    "/Submission By SMS Instructor", ((string[])(null)));
#line 118
this.ScenarioSetup(scenarioInfo);
#line 119
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 120
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 121
testRunner.When("I navigate to the subfolder \"ADDITIONALPRACTICE\" of asset in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 122
testRunner.And("I click on Grade cell cmenu options of asset \"PA-01 Span Practice- Vocabulary: Sa" +
                    "ludos, despedidas y presentaciones\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
testRunner.And("I select the \"ViewGradeSubmission\" in grade cell cmenu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
testRunner.And("I should see the edited grade \"50\" in view submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
testRunner.When("I close the \"View Submission\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Verify the functionality of options displayed when Grade cell cmenu is View Grade" +
            " History By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void VerifyTheFunctionalityOfOptionsDisplayedWhenGradeCellCmenuIsViewGradeHistoryBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify the functionality of options displayed when Grade cell cmenu is View Grade" +
                    " History By SMS Instructor", ((string[])(null)));
#line 131
this.ScenarioSetup(scenarioInfo);
#line 132
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 133
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 134
testRunner.When("I navigate to the subfolder \"ADDITIONALPRACTICE\" of asset in gradebook", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 135
testRunner.And("I click on Grade cell cmenu options of asset \"PA-01 Span Practice- Vocabulary: Sa" +
                    "ludos, despedidas y presentaciones\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
testRunner.And("I select the \"ViewGradeHistory\" in grade cell cmenu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
testRunner.Then("I should be on the \"Grade history\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 138
testRunner.And("I should see the score by \"CsSmsInstructor\" in grade history page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
testRunner.When("I close the \"Grade history\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Check the functionality of total weight field By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void ToCheckTheFunctionalityOfTotalWeightFieldBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Check the functionality of total weight field By SMS Instructor", ((string[])(null)));
#line 144
this.ScenarioSetup(scenarioInfo);
#line 145
testRunner.When("I navigate to \"Course Materials\" tab of the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 146
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 147
testRunner.When("I associate the \"Test\" activity of behavioral mode \"Assignment\" to MyCourse frame" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 148
testRunner.Then("I should see the successfull message \"Content item is added to My Course\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 149
testRunner.When("I navigate to the \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
testRunner.And("I click on the \'Create Column\' drop down", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 151
testRunner.Then("I should be on the \"Create Total Column\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 152
testRunner.When("I select checkbox of \"Test\" activity of behavioral mode \"BasicRandom\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 153
testRunner.And("I select checkbox of \"Test\" activity of behavioral mode \"Assignment\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 154
testRunner.And("I should click on Add button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 155
testRunner.And("I have entered \"50\" and \"30\" into weight box", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
testRunner.Then("I should able to see the result in Total Weight is \"80\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Display of Total weight percentage column for SMS instructor and its functionalit" +
            "y By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void DisplayOfTotalWeightPercentageColumnForSMSInstructorAndItsFunctionalityBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Display of Total weight percentage column for SMS instructor and its functionalit" +
                    "y By SMS Instructor", ((string[])(null)));
#line 161
this.ScenarioSetup(scenarioInfo);
#line 162
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 163
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 164
testRunner.When("I click on the \'Create Column\' drop down", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 165
testRunner.Then("I should be on the \"Create Total Column\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 166
testRunner.And("I should see the \'Total Weight\' field with value \"0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor Validating student grade in instructor grade book By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void InstructorValidatingStudentGradeInInstructorGradeBookBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor Validating student grade in instructor grade book By SMS Instructor", ((string[])(null)));
#line 172
this.ScenarioSetup(scenarioInfo);
#line 173
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 174
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 175
testRunner.When("I select \"Take the Chapter 1 Exam\" in \"Gradebook\" by \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 176
testRunner.And("I click on cmenu option \"ViewAllSubmissions\" of asset \"Take the Chapter 1 Exam\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 177
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 178
testRunner.And("I should see \"100\" score in view submission page for a student \"CsSmsStudent\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor Validating forcefull submission of saved activity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceGradeBook")]
        public virtual void InstructorValidatingForcefullSubmissionOfSavedActivity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor Validating forcefull submission of saved activity", ((string[])(null)));
#line 184
this.ScenarioSetup(scenarioInfo);
#line 185
testRunner.When("I navigate to \"Gradebook\" tab of the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 186
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 187
testRunner.When("I select \"Take the Chapter 3 Exam\" in \"Gradebook\" by \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 188
testRunner.And("I click on cmenu option \"ViewAllSubmissions\" of asset \"Take the Chapter 3 Exam\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 189
testRunner.Then("I should be on the \"View Submission\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 190
testRunner.And("I should search student \"CsSmsStudent\" from student frame in view submission page" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 191
testRunner.Then("I should see \"Decline\" and \"Accept\" options in instructor view submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 192
testRunner.When("I select the option \"Accept\" in view submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 193
testRunner.Then("I should see \"32\" score in view submission page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
