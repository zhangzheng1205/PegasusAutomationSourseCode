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

namespace Pegasus.Acceptance.HigherEducation.WL.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
   public class Amplifire : BasePage
    {
        
        
        [When(@"enter into ""(.*)"" course")]
        public void EnterIntoCourse(string p0)
        {
            new HEDGlobalHomePage().OpenTheCourse(p0);
        }


        [Then(@"I should see ""(.*)"" link in iframe")]
        public void ThenIShouldSeeLinkInIframe(string p0)
        {
            new CourseMaterialPage().ManageMaterials(p0);
        }



    }
}
