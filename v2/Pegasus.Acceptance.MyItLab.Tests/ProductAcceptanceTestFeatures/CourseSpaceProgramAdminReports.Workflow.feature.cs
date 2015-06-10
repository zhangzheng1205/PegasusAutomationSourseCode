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
namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceProgramAdminReportFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceProgramAdminReports.Workflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceProgramAdminReport", "          As a Program Admin\n\t   I want to manage all the coursespace admin repor" +
                    "t related usecases \n\t   so that I would validate all the coursespace admin repor" +
                    "t related scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceProgramAdminReport")))
            {
                Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestFeatures.CourseSpaceProgramAdminReportFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Activity Result (Multiple students and activities) report generation and data ver" +
            "ification by Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceProgramAdminReport")]
        public virtual void ActivityResultMultipleStudentsAndActivitiesReportGenerationAndDataVerificationByProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Activity Result (Multiple students and activities) report generation and data ver" +
                    "ification by Program Admin", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
testRunner.When("I navigate to \"Reports\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
testRunner.When("I click on \"Activity Result (Multiple students and activities)\" report link as \"H" +
                    "edProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
testRunner.Then("I should open \"Options for Activity Results (Multiple students and activities)\" c" +
                    "riteria page as \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
testRunner.When("I select \"MyITLabOffice2013Program\" section under \"MyITLabForOffice2013Master\" te" +
                    "mplate in \'Section Options\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
testRunner.And("I select \"Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)\" asset in \"Sele" +
                    "ct Activities\" by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
testRunner.And("I \'Select All\' in \'Student Options\' by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.And("I select \'save settings to My Reports\' option by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
testRunner.And("I click on the \"Run Report\" button in reports by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.Then("I should be on the \"Save settings to My Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
testRunner.When("I select \"Createnewreport\" radiobutton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
testRunner.And("I enter the \"MyItLabActivityResultsMultipleStudentsAdActivities\" report name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.And("I click on \"SaveandRun\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.Then("I should see the \"Activities: Word Chapter 1 Project 1A Skill-Based Exam (Scenari" +
                    "o 1)\" with average score \"50%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.And("I should see \'Zero\' \"CsSmsStudent\" along with section \"MyITLabOffice2013Program\" " +
                    "attempt as \"1\" submitted as score as \"0%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
testRunner.And("I should see the \"CsSmsStudent\" along with section \"MyITLabOffice2013Program\" att" +
                    "empt as \"2\" submitted as score as \"100%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
testRunner.When("I close the \"Activity Results (Multiple students and activities)\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
testRunner.And("I click on the \"Cancel\" button in reports by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.And("I select \"Run Report\" for \"MyItLabActivityResultsMultipleStudentsAdActivities\" re" +
                    "port in \'My Reports\' grid by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
testRunner.Then("I should be on the \"Activity Results (Multiple students and activities)\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
testRunner.And("I close the \"Activity Results (Multiple students and activities)\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To run and save \"Training Frequency Analysis\" Report by Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceProgramAdminReport")]
        public virtual void ToRunAndSaveTrainingFrequencyAnalysisReportByProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To run and save \"Training Frequency Analysis\" Report by Program Admin", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 36
testRunner.When("I navigate to \"Reports\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
testRunner.When("I click on \"Training Frequency Analysis\" report link as \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
testRunner.Then("I should open \"Options for Training Frequency Analysis\" criteria page as \"HedProg" +
                    "ramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
testRunner.When("I select \"MyITLabOffice2013Program\" section under \"MyITLabForOffice2013Master\" te" +
                    "mplate in \'Section Options\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
testRunner.And("I select \"Excel Chapter 1 Skill-Based Training\" asset in \"Select Trainings\" by \"H" +
                    "edProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
testRunner.And("I select \'save settings to My Reports\' option by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
testRunner.And("I click on the \"Run Report\" button in reports by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
testRunner.Then("I should be on the \"Save settings to My Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
testRunner.When("I select \"Createnewreport\" radiobutton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 46
testRunner.And("I enter the \"MyITLabTrainingFrequencyAnalysis\" report name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
testRunner.And("I click on \"SaveandRun\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
testRunner.Then("I should be on the \"Training Frequency Analysis\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
testRunner.And("I should see the \"Excel Chapter 1 Skill-Based Training\" along with average score " +
                    "\"50%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
testRunner.And("I should see the question details \"XL Activity 1.01: Starting Excel, Navigating E" +
                    "xcel, and Naming and Saving a Workbook\" \"MyITLabOffice2013Program\" \"Excel 2013\" " +
                    "\"50.00%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
testRunner.And("I should see the question details \"XL Activity 1.02: Entering Text, Using AutoCom" +
                    "plete, and Using the Name Box to Select a Cell\" \"MyITLabOffice2013Program\" \"Exce" +
                    "l 2013\" \"50.00%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
testRunner.When("I close the \"Activity Results (Multiple students and activities)\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
testRunner.And("I click on the \"Cancel\" button in reports by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
testRunner.And("I select \"Run Report\" for \" MyITLabTrainingFrequencyAnalysis\" report in \'My Repor" +
                    "ts\' grid by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
testRunner.Then("I should be on the \"Training Frequency Analysis\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
testRunner.When("I close the \"Training Frequency Analysis\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To run and save \"Exam Frequency Analysis\" Report by Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceProgramAdminReport")]
        public virtual void ToRunAndSaveExamFrequencyAnalysisReportByProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To run and save \"Exam Frequency Analysis\" Report by Program Admin", ((string[])(null)));
#line 61
this.ScenarioSetup(scenarioInfo);
#line 62
testRunner.When("I navigate to \"Reports\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
testRunner.When("I click on \"Exam Frequency Analysis\" report link as \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
testRunner.Then("I should open \"Options for Exam Frequency Analysis\" criteria page as \"HedProgramA" +
                    "dmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
testRunner.When("I select \"MyITLabOffice2013Program\" section under \"MyITLabForOffice2013Master\" te" +
                    "mplate in \'Section Options\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
testRunner.And("I select \"Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)\" asset in \"Sele" +
                    "ct Exams\" by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
testRunner.And("I select \'save settings to My Reports\' option by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
testRunner.And("I click on the \"Run Report\" button in reports by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
testRunner.Then("I should be on the \"Save settings to My Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 71
testRunner.When("I select \"Createnewreport\" radiobutton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
testRunner.And("I enter the \" MyITLabExamFrequencyAnalysis\" report name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
testRunner.And("I click on \"SaveandRun\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
testRunner.Then("I should be on the \"Exam Frequency Analysis\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
testRunner.And("I should see the \"Word Chapter 1 Project 1A Skill-Based Exam (Scenario 1)\" along " +
                    "with average score \"50%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
testRunner.And("I should see details of the question \"WD Activity 1.01: Starting a New Word Docum" +
                    "ent\" \"MyITLabOffice2013Program\" \"SIM5 Question\" \"Word 2013\" \"50.00%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
testRunner.And("I should see details of the question \"WD Activity 1.02: Inserting Text from Anoth" +
                    "er Document\" \"MyITLabOffice2013Program\" \"SIM5 Question\" \"Word 2013\" \"50.00%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
testRunner.When("I close the \"Exam Frequency Analysis\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
testRunner.And("I click on the \"Cancel\" button in reports by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
testRunner.And("I select \"Run Report\" for \" MyITLabExamFrequencyAnalysis\" report in \'My Reports\' " +
                    "grid by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
testRunner.Then("I should be on the \"Exam Frequency Analysis\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
testRunner.And("I close the \"Exam Frequency Analysis\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To run and save \"Learning Aid Usage\" Report by Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceProgramAdminReport")]
        public virtual void ToRunAndSaveLearningAidUsageReportByProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To run and save \"Learning Aid Usage\" Report by Program Admin", ((string[])(null)));
#line 87
this.ScenarioSetup(scenarioInfo);
#line 88
testRunner.When("I navigate to \"Reports\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 89
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 90
testRunner.When("I click on \"Learning Aid Usage\" report link as \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
testRunner.Then("I should open \"Options for Learning Aid Usage\" criteria page as \"HedProgramAdmin\"" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 92
testRunner.When("I select \"MyITLabOffice2013Program\" section under \"MyITLabForOffice2013Master\" te" +
                    "mplate in \'Section Options\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
testRunner.And("I select the \"PowerPoint Chapter 1 Skill-Based Training\" asset in\'Select Activity" +
                    "\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
testRunner.And("I select \'save settings to My Reports\' option by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
testRunner.And("I click on the \"Run Report\" button in reports by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
testRunner.Then("I should be on the \"Save settings to My Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
testRunner.When("I select \"Createnewreport\" radiobutton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
testRunner.And("I enter the \" MyITLabExamFrequencyAnalysis\" report name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
testRunner.And("I click on \"SaveandRun\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
testRunner.Then("I should see  \"PowerPoint Chapter 1 Skill-Based Training\" along with average scor" +
                    "e \"0.00%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
testRunner.And(@"I should see for Question ""PP Activity 1.01: Creating a New Presentation and Identifying Parts of the PowerPoint Window"" of Type ""SIM5"" under section ""MyITLabOffice2013Program"" for Application ""PPT 2013"" PracticeScore ""0.00"" and VideoScore ""0.00"" and eTextScore ""0.00""", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
testRunner.When("I close the \"Learning Aid Usage\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
testRunner.And("I click on the \"Cancel\" button in reports by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
testRunner.And("I select \"Run Report\" for \" MyITLabExamFrequencyAnalysis\" report in \'My Reports\' " +
                    "grid by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
testRunner.And("I click  \"Close\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To generate and save the \"Integrity Violation\" Report by Program Admin")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceProgramAdminReport")]
        public virtual void ToGenerateAndSaveTheIntegrityViolationReportByProgramAdmin()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To generate and save the \"Integrity Violation\" Report by Program Admin", ((string[])(null)));
#line 111
this.ScenarioSetup(scenarioInfo);
#line 112
testRunner.When("I navigate to \"Reports\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 114
testRunner.When("I click on \"Integrity Violation\" report link as \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 115
testRunner.Then("I should open \"Options for Integrity Violation\" criteria page as \"HedProgramAdmin" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 116
testRunner.When("I select \"MyITLabOffice2013Program\" section under \"MyITLabForOffice2013Master\" te" +
                    "mplate in \'Section Options\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 117
testRunner.And("I click on the \"Run Report\" button in reports by \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
testRunner.Then("I should see in row \"7\" for \"CsSmsStudent\" Expected Student for the Activity \"Exc" +
                    "el Chapter 1 Grader Project [Homework 3]\" Integrity Violation is \"Yes\" for \"Docu" +
                    "ment Level\" Integrity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 119
testRunner.And("I should see in row \"8\" for \"CsSmsStudent\" Expected Student for the Activity \"Exc" +
                    "el Chapter 1 Grader Project [Homework 3]\" Integrity Violation is \"Yes\" for \"Cont" +
                    "ent Level\" Integrity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
testRunner.And("I close the \"Student Integrity Violation\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To View Availability of \'Certificate of Completion (Custom) Report Link Under Rep" +
            "ort Tab")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceProgramAdminReport")]
        public virtual void ToViewAvailabilityOfCertificateOfCompletionCustomReportLinkUnderReportTab()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To View Availability of \'Certificate of Completion (Custom) Report Link Under Rep" +
                    "ort Tab", ((string[])(null)));
#line 125
this.ScenarioSetup(scenarioInfo);
#line 126
testRunner.When("I navigate to \"Reports\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 127
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
testRunner.And("I should see \"Certificate of Completion (Custom)\" report under report page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
testRunner.When("I click on \"Certificate of Completion (Custom)\" report link as \"HedProgramAdmin\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 130
testRunner.Then("I should see \"Options for Certificate of Completion (Custom)\" header present", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
