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
    public partial class CourseSpaceAssignsContentFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceAssignsContent.WorkFlow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceAssignsContent", "                  As a CS Instructor \r\n\t\t\tI want to manage all the coursespace as" +
                    "sign content usecases \r\n\t\t\tso that I would validate all the assign content scena" +
                    "rios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceAssignsContent")))
            {
                Pegasus.Acceptance.HigherEducation.HSS.Tests.ProductAcceptanceTestFeatures.CourseSpaceAssignsContentFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor drag and drop a folder in assignment calendar by Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void InstructorDragAndDropAFolderInAssignmentCalendarByInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor drag and drop a folder in assignment calendar by Instructor", ((string[])(null)));
#line 10
this.ScenarioSetup(scenarioInfo);
#line 11
testRunner.When("I navigate to the \"Assignment Calendar\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
testRunner.Then("I should be on the \"Calendar\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 13
testRunner.And("I should see \"Chapter 1: The Science of Psychology\" asset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
testRunner.And("I should see the current date highlighted in the calendar frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
testRunner.When("I drag and drop the \"Chapter 1: The Science of Psychology\" folder to the current " +
                    "date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
testRunner.Then("I should see due date icon displayed in current date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign more than one content using Assign Unassign link by Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void AssignMoreThanOneContentUsingAssignUnassignLinkByInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign more than one content using Assign Unassign link by Instructor", ((string[])(null)));
#line 24
this.ScenarioSetup(scenarioInfo);
#line 25
testRunner.When("I navigate to the \"Assignment Calendar\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
testRunner.Then("I should be on the \"Calendar\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 27
testRunner.When("I select \"Take the Chapter 2 Exam\" in \"Calendar\" by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
testRunner.And("I select the check box of any 2 activities in \"Chapter 2: The Biological Perspect" +
                    "ive\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
testRunner.Then("I should see Assign/Unassign link in active state on the content frame header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
testRunner.When("I click on assign/Unassign link displayed in content frame header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
testRunner.Then("I should see the check mark in assigned status column next to the assets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 32
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Assign one content using Assign Unassign link by Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void AssignOneContentUsingAssignUnassignLinkByInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Assign one content using Assign Unassign link by Instructor", ((string[])(null)));
#line 41
this.ScenarioSetup(scenarioInfo);
#line 42
testRunner.When("I navigate to the \"Assignment Calendar\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
testRunner.Then("I should be on the \"Calendar\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
testRunner.When("I select \"Take the Chapter 3 Exam\" in \"Calendar\" by \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
testRunner.And("I select the check box of any 1 activities in \"Chapter 3: Sensation and Perceptio" +
                    "n\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
testRunner.Then("I should see Assign/Unassign link in active state on the content frame header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 47
testRunner.When("I click on assign/Unassign link displayed in content frame header", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
testRunner.Then("I should see the check mark in assigned status column next to the assets", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Drag and drop the more than one assets to current date in Assignment calendar")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void DragAndDropTheMoreThanOneAssetsToCurrentDateInAssignmentCalendar()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Drag and drop the more than one assets to current date in Assignment calendar", ((string[])(null)));
#line 56
this.ScenarioSetup(scenarioInfo);
#line 57
testRunner.When("I navigate to the \"Assignment Calendar\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
testRunner.Then("I should be on the \"Calendar\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
testRunner.And("I should see the current date highlighted in the calendar frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
testRunner.When("I select \"Review the Chapter 5 Learning Objectives\" in \"Calendar\" by \"HSSCsSmsIns" +
                    "tructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
testRunner.And("I select the check box of any 2 activities in \"Chapter 5: Learning\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
testRunner.And("I should drag and drop multiple assets along with \"Review the Chapter 5 Learning " +
                    "Objectives\" to the current date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
testRunner.Then("I should see due date icon displayed in current date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To validate the display of start date icon in calendar frame by Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void ToValidateTheDisplayOfStartDateIconInCalendarFrameByInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To validate the display of start date icon in calendar frame by Instructor", ((string[])(null)));
#line 71
this.ScenarioSetup(scenarioInfo);
#line 72
testRunner.Given("I browsed the login url for \"HSSCsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 73
testRunner.When("I logged into the Pegasus as \"HSSCsSmsInstructor\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
testRunner.Then("I should logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 76
testRunner.When("I enter in the \"HSSMyPsychLabProgram\" from the Global Home page as \"HSSCsSmsInstr" +
                    "uctor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
testRunner.When("I navigate to the \"Assignment Calendar\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
testRunner.Then("I should be on the \"Calendar\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 79
testRunner.And("I should see \"Chapter 1: The Science of Psychology\" asset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
testRunner.And("I should see the current date highlighted in the calendar frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
testRunner.And("I should see the startdate Icon in calendar frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To check the current date assigned content in the calendar by Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void ToCheckTheCurrentDateAssignedContentInTheCalendarByInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To check the current date assigned content in the calendar by Instructor", ((string[])(null)));
#line 86
this.ScenarioSetup(scenarioInfo);
#line 87
testRunner.When("I navigate to the \"Assignment Calendar\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
testRunner.Then("I should be on the \"Calendar\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
testRunner.And("I should see \"Chapter 1: The Science of Psychology\" asset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
testRunner.And("I should see the current date highlighted in the calendar frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
testRunner.When("I select the current date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
testRunner.Then("I should see the assigned content \"Complete the Chapter 1 Study Plan\" in the day " +
                    "view", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor assign the asset with duedate in Managecoursework")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void InstructorAssignTheAssetWithDuedateInManagecoursework()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor assign the asset with duedate in Managecoursework", ((string[])(null)));
#line 100
this.ScenarioSetup(scenarioInfo);
#line 101
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Course Materials\" subta" +
                    "b", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
testRunner.When("I select \"Review the Chapter 4 Learning Objectives\" in \"Course Materials\" by \"HSS" +
                    "CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
testRunner.And("I click on \"Properties\" option in c menu of \"Review the Chapter 4 Learning Object" +
                    "ives\" asset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
testRunner.Then("I should be on the \"Properties\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 106
testRunner.When("I assign asset with due date and save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 107
testRunner.Then("I should see the successfull message \"Properties updated successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 108
testRunner.And("I should see assigned icon for \"Review the Chapter 4 Learning Objectives\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor assign the content with assign the content with due date ,startdate an" +
            "d endate")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceAssignsContent")]
        public virtual void InstructorAssignTheContentWithAssignTheContentWithDueDateStartdateAndEndate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor assign the content with assign the content with due date ,startdate an" +
                    "d endate", ((string[])(null)));
#line 114
this.ScenarioSetup(scenarioInfo);
#line 115
testRunner.When("I navigate to \"Course Materials\" tab and selected \"Manage Course Materials\" subta" +
                    "b", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 117
testRunner.When("I select \"Complete the Chapter 1 Study Plan\" in \"Course Materials\" by \"HSSCsSmsIn" +
                    "structor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
testRunner.And("I click on \"Properties\" option in c menu of \"Complete the Chapter 1 Study Plan\" a" +
                    "sset", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
testRunner.Then("I should be on the \"Properties\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
testRunner.And("I assign the asset for current date in the properties popup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
testRunner.Then("I should see the duedate icon along with the checkmark in the calendar beside act" +
                    "ivity \"Complete the Chapter 1 Study Plan\" under \"Chapter 1: The Science of Psych" +
                    "ology\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
