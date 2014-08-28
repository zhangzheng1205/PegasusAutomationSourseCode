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
    public partial class CourseSpaceInstructorTodaysViewFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceInstructorTodaysView.Workflow.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceInstructorTodaysView", "\t\t\tAs a CS Instructor \r\n\t\t\tI want to manage all the Coursespace Instructor Today\'" +
                    "s View related usecases \r\n\t\t\tso that I would validate all the coursespace instru" +
                    "ctor Today\'s View related scenarios are working fine.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceInstructorTodaysView")))
            {
                Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestFeatures.CourseSpaceInstructorTodaysViewFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To verify the functionality of alert listed in New Grades By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorTodaysView")]
        public virtual void ToVerifyTheFunctionalityOfAlertListedInNewGradesBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To verify the functionality of alert listed in New Grades By SMS Instructor", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 12
testRunner.And("I should successfully see the alert for New Grades", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
testRunner.When("I click New Grades alert option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Create Test with Basic Random Activity By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorTodaysView")]
        public virtual void ToCreateTestWithBasicRandomActivityBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Create Test with Basic Random Activity By SMS Instructor", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
testRunner.When("I click on the \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
testRunner.And("I click on the \"Test\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.Then("I should be on the \"Create activity\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.When("I create \"Test\" type activity of behavioral mode \'BasicRandom\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.Then("I should see the successfull message \"Activity added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Create Homework with Basic Random Activity By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorTodaysView")]
        public virtual void ToCreateHomeworkWithBasicRandomActivityBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Create Homework with Basic Random Activity By SMS Instructor", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line 31
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
testRunner.When("I click on the \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
testRunner.And("I click on the \"Homework\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
testRunner.Then("I should be on the \"Create activity\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
testRunner.When("I create \"HomeWork\" type activity of behavioral mode \'BasicRandom\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
testRunner.Then("I should see the successfull message \"Activity added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Set Feedback Preference for Homework with Basic Random Activity By SMS Instruc" +
            "tor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorTodaysView")]
        public virtual void ToSetFeedbackPreferenceForHomeworkWithBasicRandomActivityBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Set Feedback Preference for Homework with Basic Random Activity By SMS Instruc" +
                    "tor", ((string[])(null)));
#line 42
this.ScenarioSetup(scenarioInfo);
#line 43
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 45
testRunner.And("I should see \"HomeWork\" activity in the Content Library Frame", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
testRunner.When("I click on \"Edit\" cmenu option of activity in \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
testRunner.And("I set the feedback preference", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
testRunner.Then("I should see the successfull message \"Activity updated successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("To Create Quiz with Manual Gradable Activity By SMS Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorTodaysView")]
        public virtual void ToCreateQuizWithManualGradableActivityBySMSInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("To Create Quiz with Manual Gradable Activity By SMS Instructor", ((string[])(null)));
#line 53
this.ScenarioSetup(scenarioInfo);
#line 54
testRunner.When("I navigate to \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
testRunner.When("I click on the \'Add Course Materials\' option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 57
testRunner.And("I click on the \"Quiz\" activity type", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
testRunner.Then("I should be on the \"Create activity\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
testRunner.When("I create \"Quiz\" activity of behavioral mode \"BasicRandom\" type using Essay questi" +
                    "on", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
testRunner.Then("I should see the successfull message \"Activity added successfully.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor views Alert update in idle students channel of Todays View page")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorTodaysView")]
        public virtual void InstructorViewsAlertUpdateInIdleStudentsChannelOfTodaysViewPage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor views Alert update in idle students channel of Todays View page", ((string[])(null)));
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
testRunner.Then("I should see the \"Notifications\" channels in \'Todays view\' page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
testRunner.And("I should see the alert count updated as \"1\" in \"Idle Students\" channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
testRunner.When("I click on the \"Idle Students\" option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
testRunner.Then("I should see \"1\" Idle Student \"Stud , Mail\" in \"Idle Students\" channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor views Alert update in Not Passed channel of Todays View page for Activ" +
            "ity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorTodaysView")]
        public virtual void InstructorViewsAlertUpdateInNotPassedChannelOfTodaysViewPageForActivity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor views Alert update in Not Passed channel of Todays View page for Activ" +
                    "ity", ((string[])(null)));
#line 79
this.ScenarioSetup(scenarioInfo);
#line 80
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 81
testRunner.Then("I should see the \"Notifications\" channels in \'Todays view\' page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
testRunner.And("I should see the alert count updated as \"1\" in \"Not Passed\" channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
testRunner.When("I click on the \"Not Passed\" option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
testRunner.Then("I should see \"1\" activity in the \"Not Passed\" channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor views Alert update in Past Due Not Submitted channel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorTodaysView")]
        public virtual void InstructorViewsAlertUpdateInPastDueNotSubmittedChannel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor views Alert update in Past Due Not Submitted channel", ((string[])(null)));
#line 91
this.ScenarioSetup(scenarioInfo);
#line 92
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
testRunner.Then("I should see the \"Notifications\" channels in \'Todays view\' page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 94
testRunner.And("I should see the alert count updated as \"69\" in \"Past Due: Not Submitted\" channel" +
                    "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
testRunner.When("I click on the \"Past Due: Not Submitted\" option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
testRunner.Then("I should see \"69\" activity in the Past Due: Not Submitted channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor validates grade display in Student performance channel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorTodaysView")]
        public virtual void InstructorValidatesGradeDisplayInStudentPerformanceChannel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor validates grade display in Student performance channel", ((string[])(null)));
#line 103
this.ScenarioSetup(scenarioInfo);
#line 104
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 105
testRunner.Then("I should see the \"Notifications\" channels in \'Todays view\' page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 106
testRunner.When("I click on the \"Student Performance\" option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 107
testRunner.Then("I should see \"6.57%\" as overall Grade in \"Student Performance\" alert channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor views Alert update in Past Due Submitted channel")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorTodaysView")]
        public virtual void InstructorViewsAlertUpdateInPastDueSubmittedChannel()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor views Alert update in Past Due Submitted channel", ((string[])(null)));
#line 114
this.ScenarioSetup(scenarioInfo);
#line 115
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
testRunner.Then("I should see the \"Notifications\" channels in \'Todays view\' page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 117
testRunner.And("I should see the alert count updated as \"1\" in \"Past Due: Submitted\" channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
testRunner.When("I click on the \"Past Due: Submitted\" option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
testRunner.Then("I should see student First, Last name \"ln, fn\" in Past Due: Submitted channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 120
testRunner.When("I click on the expand icon of student", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 121
testRunner.Then("I should see the activity name \"Training [Skill-Based]: Word Chapter 1 Skill-Base" +
                    "d Training\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor accepts past due submission from past due submitted channel of activit" +
            "y")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorTodaysView")]
        public virtual void InstructorAcceptsPastDueSubmissionFromPastDueSubmittedChannelOfActivity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor accepts past due submission from past due submitted channel of activit" +
                    "y", ((string[])(null)));
#line 128
this.ScenarioSetup(scenarioInfo);
#line 129
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 130
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 131
testRunner.When("I click on the \"Past Due: Submitted\" link in notifications channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 132
testRunner.Then("I should see First name, Last name of \"CsSmsStudent\" who has submitted the past d" +
                    "ue activity in the right frame along with expand icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 133
testRunner.When("I click on expand icon displayed against student name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 134
testRunner.And("I selected the check box of the past due activity submitted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
testRunner.Then("I should see \"CsSmsStudent\" name and \"Training [Skill-Based]: Excel Chapter 1 Ski" +
                    "ll-Based Training\" activity name and due date and time and submitted date and ti" +
                    "me which is submitted post due date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 136
testRunner.And("I should be able to select the past due activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
testRunner.When("I click on \"Accept\" activities past due date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 138
testRunner.Then("I should see the successfull message \"All of the late submissions have been accep" +
                    "ted. The grades for these submissions will now appear in the Gradebook.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Instructor decline past due submission from past due submitted channel of activit" +
            "y")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorTodaysView")]
        public virtual void InstructorDeclinePastDueSubmissionFromPastDueSubmittedChannelOfActivity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Instructor decline past due submission from past due submitted channel of activit" +
                    "y", ((string[])(null)));
#line 144
this.ScenarioSetup(scenarioInfo);
#line 145
testRunner.When("I navigate to \"Today\'s View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 146
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 147
testRunner.When("I click on the \"Past Due: Submitted\" link in notifications channel", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 148
testRunner.Then("I should see First name, Last name of \"CsSmsStudent\" who has submitted the past d" +
                    "ue activity in the right frame along with expand icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 149
testRunner.When("I click on expand icon displayed against student name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
testRunner.And("I selected the check box of the past due activity submitted", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 151
testRunner.Then("I should see \"CsSmsStudent\" name and \"Training [Skill-Based]: Excel Chapter 1 Ski" +
                    "ll-Based Training\" activity name and due date and time and submitted date and ti" +
                    "me which is submitted post due date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 152
testRunner.And("I should be able to select the past due activity", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
testRunner.When("I click on \"Accept\" activities past due date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 154
testRunner.Then("I should see the successfull message \"All of the late submissions have been decli" +
                    "ned. These submissions will receive a zero in the Gradebook.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
