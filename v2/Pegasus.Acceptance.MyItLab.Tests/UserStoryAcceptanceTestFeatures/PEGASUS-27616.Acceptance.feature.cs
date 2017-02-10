﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Pegasus.Acceptance.MyITLab.Tests.UserStoryAcceptanceTestFeatures
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PEGASUS_27616AutomationAdminModulesCopyingTemplatesSectionsInsideProgramWhenItsParentPMCIsSetWithStopCopy_Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PEGASUS-27616.Acceptance.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "PEGASUS-27616:Automation: (Admin Modules) Copying Templates/ Sections inside Prog" +
                    "ram when its parent PMC is set with Stop Copy.", "\tAs a program admin\r\n\tI want to copy template/section for parent PMC set with sto" +
                    "p copy option\r\n\tso that Program admin will displyed with error message \"You cann" +
                    "ot copy this course due to publisher restrictions.\" and course should not copied" +
                    ".", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "PEGASUS-27616:Automation: (Admin Modules) Copying Templates/ Sections inside Prog" +
                            "ram when its parent PMC is set with Stop Copy.")))
            {
                Pegasus.Acceptance.MyITLab.Tests.UserStoryAcceptanceTestFeatures.PEGASUS_27616AutomationAdminModulesCopyingTemplatesSectionsInsideProgramWhenItsParentPMCIsSetWithStopCopy_Feature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Copying Templates as Tempalate inside Program when its parent PMC is set with Sto" +
            "p Copy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PEGASUS-27616:Automation: (Admin Modules) Copying Templates/ Sections inside Prog" +
            "ram when its parent PMC is set with Stop Copy.")]
        public virtual void CopyingTemplatesAsTempalateInsideProgramWhenItsParentPMCIsSetWithStopCopy()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Copying Templates as Tempalate inside Program when its parent PMC is set with Sto" +
                    "p Copy", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
testRunner.When("I navigate to \"Templates\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
testRunner.When("I search the Template of \"MyITLabForOffice2013Master\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
testRunner.And("I click the \"Copy as Template\" c-menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
testRunner.Then("I should be on the \"Copy as Template\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
testRunner.When("I click Copy/Save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
testRunner.Then("I should see the successfull message \"You cannot copy this course due to publishe" +
                    "r restrictions.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Copy Template as Shared Library inside Program when its parent PMC is set with St" +
            "op Copy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PEGASUS-27616:Automation: (Admin Modules) Copying Templates/ Sections inside Prog" +
            "ram when its parent PMC is set with Stop Copy.")]
        public virtual void CopyTemplateAsSharedLibraryInsideProgramWhenItsParentPMCIsSetWithStopCopy()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Copy Template as Shared Library inside Program when its parent PMC is set with St" +
                    "op Copy", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
testRunner.When("I navigate to \"Templates\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
testRunner.When("I search the Template of \"MyITLabForOffice2013Master\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
testRunner.And("I click the \"Copy as Shared Library\" c-menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
testRunner.Then("I should be on the \"Copy as Shared Library\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
testRunner.When("I click Copy/Save button to copy", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
testRunner.Then("I should see the successfull message \"You cannot copy this course due to publishe" +
                    "r restrictions.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Copy Section as Section inside Program when its parent PMC is set with Stop Copy")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PEGASUS-27616:Automation: (Admin Modules) Copying Templates/ Sections inside Prog" +
            "ram when its parent PMC is set with Stop Copy.")]
        public virtual void CopySectionAsSectionInsideProgramWhenItsParentPMCIsSetWithStopCopy()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Copy Section as Section inside Program when its parent PMC is set with Stop Copy", ((string[])(null)));
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
testRunner.When("I search the section of \"MyITLabOffice2013Program\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
testRunner.And("I click the \"Copy as Section\" c-menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
testRunner.Then("I should be on the \"Copy as Section\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 34
testRunner.When("I click Copy/Save button to copy", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
testRunner.Then("I should see the successfull message \"You cannot copy this course due to publishe" +
                    "r restrictions.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Copy Section as Template inside Program when its parent PMC is set with Stop Copy" +
            "")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "PEGASUS-27616:Automation: (Admin Modules) Copying Templates/ Sections inside Prog" +
            "ram when its parent PMC is set with Stop Copy.")]
        public virtual void CopySectionAsTemplateInsideProgramWhenItsParentPMCIsSetWithStopCopy()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Copy Section as Template inside Program when its parent PMC is set with Stop Copy" +
                    "", ((string[])(null)));
#line 38
this.ScenarioSetup(scenarioInfo);
#line 39
testRunner.When("I navigate to \"Sections\" tab of the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
testRunner.Then("I should be on the \"Program Administration\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
testRunner.When("I search the section of \"MyITLabOffice2013Program\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
testRunner.And("I click the \"Copy as Template\" c-menu option", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
testRunner.Then("I should be on the \"Copy as Template\" page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
testRunner.When("I click Copy/Save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
testRunner.Then("I should see the successfull message \"You cannot copy this course due to publishe" +
                    "r restrictions.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
