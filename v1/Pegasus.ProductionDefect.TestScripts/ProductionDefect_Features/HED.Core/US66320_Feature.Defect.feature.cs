﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Pegasus.ProductionDefect.TestScripts.ProductionDefect_Features.HED_Core
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class US66320Feature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "US66320_Feature.Defect.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "US66320", "In order to verify the defect #US66320 \r\nAs a CS Instructor\r\nI want to verify the" +
                    " expected result(s) at different access point(s) in pegasus", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "US66320")))
            {
                Pegasus.ProductionDefect.TestScripts.ProductionDefect_Features.HED_Core.US66320Feature.FeatureSetup(null);
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
#line 9
testRunner.Given("Authored course copy already created if not then create the authored course copy");
#line 12
testRunner.Given("Authored course copy is already published if not then publish the authored course" +
                    " copy");
#line 15
testRunner.Given("Autohored course is already approved in the course space if not then approve the " +
                    "authored course in course space");
#line 18
testRunner.Given("HED program is already created if not then create the HED program");
#line 21
testRunner.Given("HED general type product is already created if not then create a new general type" +
                    " product");
#line 24
testRunner.Given("Program type product is already created if not then create a new program type pro" +
                    "duct");
#line 27
testRunner.Given("Course association to general type product is already created if not then create " +
                    "association");
#line 30
testRunner.Given("Course association to program type product is already created if not then create " +
                    "association");
#line 33
testRunner.Given("SMS user is already created if not then create SMS user");
#line 36
testRunner.Given("SMS user is already enrolled into the instructor course if not then enroll the SM" +
                    "S user in instructor course");
#line 40
testRunner.Given("Activity is already submitted by the student if not then submit the activity by t" +
                    "he student");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("US66320_Mouse hover in HTML Editor for Essay Question")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "US66320")]
        public virtual void US66320_MouseHoverInHTMLEditorForEssayQuestion()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("US66320_Mouse hover in HTML Editor for Essay Question", ((string[])(null)));
#line 43
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 44
testRunner.Given("I have browsed url for \"CsSmsInstructor\"");
#line 45
testRunner.When("I have logged into the course space as SMS Instructor");
#line 46
testRunner.Then("It should show the \"Global Home\" page");
#line 47
testRunner.When("I select the course from Global home page");
#line 48
testRunner.When("I navigate to the \"Gradebook\" Tab");
#line 49
testRunner.And("I  click on the c-menu icon of activity column which has essay submitted and sele" +
                    "ct view all submission");
#line 50
testRunner.When("I entered the text in HTML editor where student submitted answers displays of fir" +
                    "st essay question");
#line 51
testRunner.Then("It should display blue colour Instructor comments and upon placing cursor the col" +
                    "our of student answer should not change for first essay question");
#line 54
testRunner.And("I clicked on the Logout link to get logged out from the application");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
