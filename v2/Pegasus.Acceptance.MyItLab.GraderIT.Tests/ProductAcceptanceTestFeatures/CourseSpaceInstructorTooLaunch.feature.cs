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
namespace Pegasus.Acceptance.MyITLab.GraderIT.Tests.ProductAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.3.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CourseSpaceInstructorPreferenceFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CourseSpaceInstructorTooLaunch.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CourseSpaceInstructorPreference", "    As a Cs Instructor \r\nI want to launch the PCT Tool Link from Instructor Resou" +
                    "rce Tool Bar\r\nso that I can enable the user to crossover to PCT Link.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "CourseSpaceInstructorPreference")))
            {
                Pegasus.Acceptance.MyITLab.GraderIT.Tests.ProductAcceptanceTestFeatures.CourseSpaceInstructorPreferenceFeature.FeatureSetup(null);
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
#line 6
#line 8
testRunner.Given("I browsed the login url for \"CsSmsInstructor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
testRunner.When("I logged into the Pegasus as \"CsSmsInstructor\" in \"CourseSpace\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should logged in successfully", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.Given("I am on the \"Global Home\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("PCT launch from resource tool bar from CourseSpace Instructor")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CourseSpaceInstructorPreference")]
        public virtual void PCTLaunchFromResourceToolBarFromCourseSpaceInstructor()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PCT launch from resource tool bar from CourseSpace Instructor", ((string[])(null)));
#line 13
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 14
testRunner.When("I enter in the \"MyItLabInstructorCourse\" from the Global Home page as \"CsSmsInstr" +
                    "uctor\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
testRunner.And("I click on the \"PCTLink1\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
testRunner.And("I click on the \"PCTLink2\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
testRunner.Then("I should be on the \"Today\'s View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
testRunner.When("I navigate to the \"Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
testRunner.And("I click on the \"PCTLink1\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 33
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
testRunner.And("I click on the \"PCTLink2\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
testRunner.When("I navigate to the \"Manage Course Materials\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
testRunner.And("I click on the \"PCTLink1\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
testRunner.Then("I should be on the \"Course Materials\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
testRunner.And("I click on the \"PCTLink2\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
testRunner.When("I navigate to the \"Media Library\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
testRunner.And("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
testRunner.And("I click on the \"PCTLink1\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 58
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
testRunner.And("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
testRunner.And("I click on the \"PCTLink2\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 63
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
testRunner.When("I navigate to the \"Manage Question Bank\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 67
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 68
testRunner.And("I click on the \"PCTLink1\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 70
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 72
testRunner.Then("I should be on the \"Question Bank\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
testRunner.And("I click on the \"PCTLink2\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
testRunner.When("I navigate to the \"Assignment Calendar\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
testRunner.Then("I should be on the \"Calendar\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 81
testRunner.And("I click on the \"PCTLink1\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 83
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
testRunner.Then("I should be on the \"Calendar\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 86
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
testRunner.And("I click on the \"PCTLink2\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 89
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
testRunner.When("I navigate to the \"Gradebook\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
testRunner.And("I click on the \"PCTLink1\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 96
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
testRunner.Then("I should be on the \"Gradebook\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
testRunner.And("I click on the \"PCTLink2\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 102
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
testRunner.When("I navigate to the \"Custom View\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 105
testRunner.Then("I should be on the \"Custom View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 106
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 107
testRunner.And("I click on the \"PCTLink1\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 110
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 111
testRunner.Then("I should be on the \"Custom View\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 112
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
testRunner.And("I click on the \"PCTLink2\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 115
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 117
testRunner.When("I navigate to the \"Reports\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
testRunner.Then("I should be on the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 119
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 120
testRunner.And("I click on the \"PCTLink1\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 122
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
testRunner.Then("I should be on the \"Reports\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 126
testRunner.And("I click on the \"PCTLink2\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 128
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 130
testRunner.When("I navigate to the \"Enrollments\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 131
testRunner.Then("I should be on the \"Enrollments\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 132
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 133
testRunner.And("I click on the \"PCTLink1\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 137
testRunner.Then("I should be on the \"Enrollments\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 138
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 139
testRunner.And("I click on the \"PCTLink2\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 141
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 143
testRunner.When("I navigate to the \"Preferences\" tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 144
testRunner.Then("I should be on the \"Preferences\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 145
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 146
testRunner.And("I click on the \"PCTLink1\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 148
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
testRunner.Then("I should be on the \"Preferences\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 151
testRunner.When("I click on PCT in Tools DropDown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 152
testRunner.And("I click on the \"PCTLink2\" link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
testRunner.Then("I should be on the \"Project Creation Tool\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 154
testRunner.And("I should see the window size is \"900\" by \"700\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 155
testRunner.When("I close the \"Project Creation Tool\" window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
