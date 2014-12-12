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
namespace Pegasus.Acceptance.HigherEducation.HSS.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceInstructorReportFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceInstructorReport.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceInstructorReport", "               As a HSS CS Instructor \r\n\t\t\tI want to manage all the coursespace i" +
                    "nstructor report related usecases \r\n\t\t\tso that I would validate all the coursesp" +
                    "ace instructor report related scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceInstructorReport")))
            {
                Pegasus.Acceptance.HigherEducation.HSS.Tests.ProductAcceptanceTestFeatures.CourseSpaceInstructorReportFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Generate and save the \"Student Results by Activity\" as a Section Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorReport")]
        public virtual void GenerateAndSaveTheStudentResultsByActivityAsASectionInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate and save the \"Student Results by Activity\" as a Section Instructor", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
testRunner.When("I navigate to \"Gradebook\" tab and selected \"Reports\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
testRunner.Then("I should be on the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
testRunner.When("I click on \"Student Results by Activity\" report link as \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
testRunner.And("I select \"HSSCsSmsStudent\" asset in \"Select Student\" by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
testRunner.And("I select \"Take the Chapter 1 Exam\" asset in \"Select Activities\" by \"HSSCsSmsInstr" +
                    "uctor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
testRunner.And("I select \'save settings to My Reports\' option by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
testRunner.And("I click on the \"Run Report\" button in reports by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
testRunner.Then("I should be on the \"Save settings to My Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
testRunner.When("I select \"Createnewreport\" radiobutton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
testRunner.And("I enter the \"HSSStudentResultsbyActivity\" report name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
testRunner.And("I click on \"SaveandRun\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.Then("I should see the section name \"HSSMyPsychLabProgram\" for \"HSSCsSmsStudent\" with a" +
                    "verage score \"100%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.And("I should see \"Take the Chapter 1 Exam\" \"Exam\" details in the report", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
testRunner.When("I close the \"Report: Student Results by Activity\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
testRunner.When("I click on the \"Cancel\" button in reports by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
testRunner.And("I select \"Run Report\" for \"HSSStudentResultsbyActivity\" report in \'My Reports\' gr" +
                    "id by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
testRunner.Then("I should be on the \"Report: Student Results by Activity\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
testRunner.When("I close the \"Report: Student Results by Activity\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Generate and save the \"Activity Results by Student\" as a Section Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorReport")]
        public virtual void GenerateAndSaveTheActivityResultsByStudentAsASectionInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate and save the \"Activity Results by Student\" as a Section Instructor", ((string[])(null)));
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
testRunner.When("I navigate to \"Gradebook\" tab and selected \"Reports\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
testRunner.And("I click on \"Activity Results by Student\" report link as \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
testRunner.And("I select \"Take the Chapter 1 Exam\" asset in \"Select Activity\" by \"HSSCsSmsInstruc" +
                    "tor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
testRunner.And("I \'Select All\' in \'Student Options\' by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
testRunner.And("I select \'save settings to My Reports\' option by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
testRunner.And("I click on the \"Run Report\" button in reports by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
testRunner.Then("I should be on the \"Save settings to My Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
testRunner.When("I select \"Createnewreport\" radiobutton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
testRunner.And("I enter the \"HSSActivityResultsByStudent\" report name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
testRunner.And("I click on \"SaveandRun\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
testRunner.Then("I should be on the \"Report: Activity Results by Student\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
testRunner.And("I should see the \"Take the Chapter 1 Exam\" with section name \"HSSMyPsychLabProgra" +
                    "m\" with average score \"50%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
testRunner.And("I should see \'Zero\' \"HSSCsSmsStudent\" along with submitted score as \"0%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
testRunner.And("I should see the \"HSSCsSmsStudent\" along with attempt submitted as score as \"100%" +
                    "\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
testRunner.When("I close the \"Report: Activity Results by Student\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
testRunner.And("I click on the \"Cancel\" button in reports by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
testRunner.And("I select \"Run Report\" for \"HSSActivityResultsByStudent\" report in \'My Reports\' gr" +
                    "id by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
testRunner.Then("I should be on the \"Report: Activity Results by Student\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
testRunner.When("I close the \"Report: Activity Results by Student\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Generate and save the  \"Study plan Results report\"  as a Section Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorReport")]
        public virtual void GenerateAndSaveTheStudyPlanResultsReportAsASectionInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Generate and save the  \"Study plan Results report\"  as a Section Instructor", ((string[])(null)));
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
testRunner.When("I navigate to \"Gradebook\" tab and selected \"Reports\" subtab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
testRunner.And("I click on \"Study Plan Results\" report link as \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
testRunner.And("I select \"Complete the Chapter 1 Study Plan\" asset in \"Select Study Plans\" by \"HS" +
                    "SCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
testRunner.And("I \'Select All\' in \'Student Options\' by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
testRunner.And("I select \'save settings to My Reports\' option by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
testRunner.And("I click on the \"Run Report\" button in reports by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
testRunner.Then("I should be on the \"Save settings to My Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
testRunner.When("I select \"Createnewreport\" radiobutton", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
testRunner.And("I enter the \"HSSStudytPlanResults\" report name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
testRunner.And("I click on \"SaveandRun\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
testRunner.Then("I should be on the \"Study Plan Results\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 79
testRunner.And("I should see average score \"36%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
testRunner.And("I should see \'Zero\' \"HSSCsSmsStudent\" along with Pre-test \"0%\" Post-test \"0%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
testRunner.And("I should see the \"HSSCsSmsStudent\" along with  Pre-test \"72%\" Post-test \"72%\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
testRunner.When("I close the \"Study Plan Results\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 83
testRunner.And("I click on the \"Cancel\" button in reports by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
testRunner.And("I select \"Run Report\" for \"HSSStudytPlanResults\" report in \'My Reports\' grid by \"" +
                    "HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
testRunner.Then("I should be on the \"Study Plan Results\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 86
testRunner.When("I close the \"Study Plan Results\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
