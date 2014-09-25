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
    public partial class CourseSpaceQuestionLibraryFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceQuestionLibrary.WorkFlow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceQuestionLibrary", "               As a CsInstructor \r\n\t\t\tI want to manage all the Usecases related t" +
                    "o Question Library \r\n\t\t\tso that I would validate all the Instructor related usec" +
                    "ases for Question Library.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceQuestionLibrary")))
            {
                Pegasus.Acceptance.HigherEducation.WL.Tests.ProductAcceptanceTestFeatures.CourseSpaceQuestionLibraryFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("File upload Question Creation in Question Bank By CsInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceQuestionLibrary")]
        public virtual void FileUploadQuestionCreationInQuestionBankByCsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("File upload Question Creation in Question Bank By CsInstructor", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Question Bank\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
testRunner.When("I select \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
testRunner.And("I select \"File Upload\" question type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
testRunner.Then("I should be on the \"Create File Upload\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
testRunner.When("I create \"FileUpload\" question", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.Then("I should see the successfull message \"Question added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Fill in the blanks Question Creation in Question Bank By CsInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceQuestionLibrary")]
        public virtual void FillInTheBlanksQuestionCreationInQuestionBankByCsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Fill in the blanks Question Creation in Question Bank By CsInstructor", ((string[])(null)));
#line 21
this.ScenarioSetup(scenarioInfo);
#line 22
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Question Bank\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.When("I select \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.And("I select \"Fill in the Blank\" question type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
testRunner.Then("I should be on the \"Create Fill in the Blank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
testRunner.When("I create \"FillInTheBlank\" question", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
testRunner.Then("I should see the successfull message \"Question added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Drop down list  Question Creation in Question Bank By CsInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceQuestionLibrary")]
        public virtual void DropDownListQuestionCreationInQuestionBankByCsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Drop down list  Question Creation in Question Bank By CsInstructor", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Question Bank\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
testRunner.When("I select \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
testRunner.And("I select \"Drop-down List\" question type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
testRunner.Then("I should be on the \"Create Drop-down List\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
testRunner.When("I create \"DropDownList\" question", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
testRunner.Then("I should see the successfull message \"Question added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Entry List Question Creation in Question Bank By CsInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceQuestionLibrary")]
        public virtual void EntryListQuestionCreationInQuestionBankByCsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Entry List Question Creation in Question Bank By CsInstructor", ((string[])(null)));
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Question Bank\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
testRunner.When("I select \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
testRunner.And("I select \"Entry List\" question type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
testRunner.Then("I should be on the \"Create Entry List\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
testRunner.When("I create \"EntryList\" question", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
testRunner.Then("I should see the successfull message \"Question added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Essay Question Creation in Question Bank By CsInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceQuestionLibrary")]
        public virtual void EssayQuestionCreationInQuestionBankByCsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Essay Question Creation in Question Bank By CsInstructor", ((string[])(null)));
#line 54
this.ScenarioSetup(scenarioInfo);
#line 55
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Question Bank\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
testRunner.When("I select \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
testRunner.And("I select \"Essay\" question type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
testRunner.Then("I should be on the \"Create Essay\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
testRunner.When("I create \"Essay\" question", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
testRunner.Then("I should see the successfull message \"Question added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Matching Question Creation in Question Bank By CsInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceQuestionLibrary")]
        public virtual void MatchingQuestionCreationInQuestionBankByCsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Matching Question Creation in Question Bank By CsInstructor", ((string[])(null)));
#line 66
this.ScenarioSetup(scenarioInfo);
#line 67
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Question Bank\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 69
testRunner.When("I select \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
testRunner.And("I select \"Matching\" question type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
testRunner.Then("I should be on the \"Create Matching\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 72
testRunner.When("I create \"Matching\" question", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 73
testRunner.Then("I should see the successfull message \"Question added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Multiple Response Question Creation in Question Bank By CsInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceQuestionLibrary")]
        public virtual void MultipleResponseQuestionCreationInQuestionBankByCsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Multiple Response Question Creation in Question Bank By CsInstructor", ((string[])(null)));
#line 78
this.ScenarioSetup(scenarioInfo);
#line 79
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Question Bank\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 80
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
testRunner.When("I select \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
testRunner.And("I select \"Multiple Response\" question type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
testRunner.Then("I should be on the \"Create Multiple Response\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
testRunner.When("I create \"MultipleResponse\" question", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
testRunner.Then("I should see the successfull message \"Question added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Text Match Question Creation in Question Bank By CsInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceQuestionLibrary")]
        public virtual void TextMatchQuestionCreationInQuestionBankByCsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Text Match Question Creation in Question Bank By CsInstructor", ((string[])(null)));
#line 90
this.ScenarioSetup(scenarioInfo);
#line 91
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Question Bank\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
testRunner.When("I select \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
testRunner.And("I select \"Text Match\" question type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
testRunner.Then("I should be on the \"Create Text Match\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 96
testRunner.When("I create \"TextMatch\" question", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 97
testRunner.Then("I should see the successfull message \"Question added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Numeric Question Creation in Question Bank by CsInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceQuestionLibrary")]
        public virtual void NumericQuestionCreationInQuestionBankByCsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Numeric Question Creation in Question Bank by CsInstructor", ((string[])(null)));
#line 102
this.ScenarioSetup(scenarioInfo);
#line 103
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Question Bank\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
testRunner.When("I select \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
testRunner.And("I select \"Numeric\" question type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
testRunner.Then("I should be on the \"Create Numeric\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 108
testRunner.When("I create \"Numeric\" question", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
testRunner.Then("I should see the successfull message \"Question added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creation of question folder and its accessibility By CsInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceQuestionLibrary")]
        public virtual void CreationOfQuestionFolderAndItsAccessibilityByCsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creation of question folder and its accessibility By CsInstructor", ((string[])(null)));
#line 114
this.ScenarioSetup(scenarioInfo);
#line 115
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Question Bank\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 117
testRunner.When("I select \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
testRunner.And("I select \"Add Folder\" option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
testRunner.Then("I should be on the \"Create New Folder\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
testRunner.When("I create \"QuestionFolder\" type Folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 121
testRunner.Then("I should see the created question \"Folder\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To verify the functionality of accessing the clipboard items in question bank by " +
            "CsInstructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceQuestionLibrary")]
        public virtual void ToVerifyTheFunctionalityOfAccessingTheClipboardItemsInQuestionBankByCsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To verify the functionality of accessing the clipboard items in question bank by " +
                    "CsInstructor", ((string[])(null)));
#line 126
this.ScenarioSetup(scenarioInfo);
#line 127
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Question Bank\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 128
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 129
testRunner.And("I should see the \'Delete\',\'Copy\',\'Cut\',\'Paste\',\'Reports\' action row options", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
testRunner.When("I select the \"MyLanguageLabs Student Quiz q1\" question from question bank", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 131
testRunner.Then("I should see \'Delete\',\'Copy\',\'Cut\' options should get enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 132
testRunner.When("I click on the \'Copy\' clipboard option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 133
testRunner.Then("I should see \'Paste\' options should get enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Accessing the folder c-menu options in question bank folder preferences by CsInst" +
            "ructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceQuestionLibrary")]
        public virtual void AccessingTheFolderC_MenuOptionsInQuestionBankFolderPreferencesByCsInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Accessing the folder c-menu options in question bank folder preferences by CsInst" +
                    "ructor", ((string[])(null)));
#line 138
this.ScenarioSetup(scenarioInfo);
#line 139
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Question Bank\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 140
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 141
testRunner.When("I navigate to folder \"Capítulo 01: ¿Quiénes somos?\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 142
testRunner.And("I set the score \"10\" for questions in \"ADDITIONAL PRACTICE\" folder using \"Questio" +
                    "n Preferences\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
testRunner.Then("I should see the updated score \"10\" for question \"01-01 SPAN PRACTICE q1 VOCABULA" +
                    "RY\" in \"ADDITIONAL PRACTICE\" folder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
