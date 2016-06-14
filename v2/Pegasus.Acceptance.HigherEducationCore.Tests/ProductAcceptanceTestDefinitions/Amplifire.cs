using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.HomePage;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.CourseMaterials;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pegasus.Acceptance.HigherEducation.WL.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
   public class Amplifire : BasePage
    {
        private static readonly Logger logger = Logger.
            GetInstance(typeof(CourseMaterialPage));
        
        [When(@"enter into ""(.*)"" course")]
        public void EnterIntoCourse(string p0)
        {
            new HEDGlobalHomePage().OpenTheCourse(p0);
        }


        [Given(@"I should see ""(.*)"" link in iframe")]
        public void ThenIShouldSeeLinkInIframe(string p0)
        {
            //bool linkfound = new CourseMaterialPage().ManageMaterials(p0);

            logger.LogAssertion("Verify link present",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(true, new CourseMaterialPage().ManageMaterials(p0)));
                                    
        }

        [Then(@"I should be able to launch the ""(.*)"" link")]
        public void AbleToLaunchTheLink(string p0)
        {
           // new CourseMaterialPage().LaunchMaterials(p0);

            logger.LogAssertion("Verify launch success",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreEqual(true, new CourseMaterialPage().LaunchMaterials(p0)));

            new CourseMaterialPage().Amplifire(p0);

            new CourseMaterialPage().CloseAmplifire();
        }


    }
}
