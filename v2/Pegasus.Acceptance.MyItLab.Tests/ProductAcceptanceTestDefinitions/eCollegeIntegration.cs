using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    class eCollegeIntegration : BasePage
    {
        private static Logger logger = Logger.GetInstance(typeof(eCollegeIntegration));
    
 //Given I am on the home PSH of eCollege

    [Given(@"I am on the home PSH of eCollege")]

    public void HomePSHOfECollege()
    {
        
        logger.LogMethodEntry("eCollegeIntegration", "HomePSHOfECollege",
                base.IsTakeScreenShotDuringEntryExit);
        try
           {

               base.WaitForElementDisplayedInUi(By.CssSelector(".BannerColor>td>center>a>font"));

               bool foundPSH = base.IsElementPresent(By.CssSelector(".BannerColor>td>center>a>font"));
        
              logger.LogAssertion("VerifyHomePage",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreNotEqual(false, foundPSH));
           }

        catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("eCollegeIntegration", "HomePSHOfECollege",
              base.IsTakeScreenShotDuringEntryExit);
    }


    //When I select "Academics PSH" link

    [When(@"I select ""(.*)"" link")]
    public void SelectAcademicPSH(string p0)
    {
        logger.LogMethodEntry("eCollegeIntegration", "SelectAcademicPSH",
                base.IsTakeScreenShotDuringEntryExit);
       
        try
        {

            base.WaitForElementDisplayedInUi(By.CssSelector(".BannerColor>td>center>a>font"));

            bool foundPSH = base.IsElementPresent(By.CssSelector(".BannerColor>td>center>a>font[color='BLACK']"),10);


            /*logger.LogAssertion("VerifyHomePage",
              ScenarioContext.Current.ScenarioInfo.Title, () =>
                  Assert.AreNotEqual(false, foundPSH)); */

            IWebElement academicsPSH = base.GetWebElementPropertiesByCssSelector(".BannerColor>td>center>a>font[color='BLACK']");

            string linkText = academicsPSH.Text;
            if(p0==linkText)
            base.ClickByJavaScriptExecutor(academicsPSH);
        }

        catch (Exception e)
        {
            ExceptionHandler.HandleException(e);
        }

        logger.LogMethodEntry("eCollegeIntegration", "SelectAcademicPSH",
          base.IsTakeScreenShotDuringEntryExit);

    }

    [Then(@"I should see ""(.*)"" Page contents")]
    public void AcademicPageContents(string p0)
    {
        logger.LogMethodEntry("eCollegeIntegration", "AcademicPageContents",
                base.IsTakeScreenShotDuringEntryExit);

        try
        {

            base.WaitUntilWindowLoads(p0);

            string wName = base.GetWindowTitleByJavaScriptExecutor();

            logger.LogAssertion("AcademicPageContents",
              ScenarioContext.Current.ScenarioInfo.Title, () =>
                  Assert.AreEqual(p0, wName));

        }

        catch (Exception e)
        {
            ExceptionHandler.HandleException(e);
        }

        logger.LogMethodEntry("eCollegeIntegration", "AcademicPageContents",
          base.IsTakeScreenShotDuringEntryExit);
    }


    }

}
