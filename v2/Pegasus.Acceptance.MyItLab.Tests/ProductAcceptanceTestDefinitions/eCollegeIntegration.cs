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
using System.Configuration;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using Pegasus.Pages.UI_Pages;


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

    //Then I should see "Academics PSH" Page contents
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


        //When I select "VCD_ MIL_Course" link

    [When(@"I select ""(.*)"" Pegasus course")]
    public void SelectPegasusCourse(string p0)
    {
        logger.LogMethodEntry("eCollegeIntegration", "SelectPegasusCourse",
                base.IsTakeScreenShotDuringEntryExit);

        try
        {

            
            string env = ConfigurationManager.AppSettings["TestEnvironment"];


            switch(env)
            {
                case "VCD":
                    base.WaitForElementDisplayedInUi
                        (By.CssSelector(string.Format("a.MainContentLink[title*='{0}']",p0)));

                    bool e= base.IsElementPresent(By.CssSelector("a.MainContentLink[title^='VCD_ MIL']"));
                    IWebElement VCDCourse = base.GetWebElementPropertiesByCssSelector("a.MainContentLink[title^='VCD_ MIL']");
                    base.ClickByJavaScriptExecutor(VCDCourse);

                    break;

                case "CGIE":
                    base.WaitForElementDisplayedInUi
                        (By.CssSelector(string.Format("a.MainContentLink[title*='{0}']",p0)));

                    IWebElement CGIECourse = base.GetWebElementPropertiesByCssSelector("a.MainContentLink[title^='CGIE_MIL']");
                    base.ClickByJavaScriptExecutor(CGIECourse);
                    break;

                default: throw new ArgumentException("This environment is not available for eCollege");
                   

            }
            
        }

        catch (Exception e)
        {
            ExceptionHandler.HandleException(e);
        }

        logger.LogMethodEntry("eCollegeIntegration", "SelectPegasusCourse",
          base.IsTakeScreenShotDuringEntryExit);
        
    }


    //Then I should see "MIL_Course" contents

    [Then(@"I should see ""(.*)"" contents")]
    public void CourseLinks(string p0)
    {
        logger.LogMethodEntry("eCollegeIntegration", "CourseLinks",
                base.IsTakeScreenShotDuringEntryExit);

        try
        {
            string wTitle= GetWindowTitleByJavaScriptExecutor();

            base.WaitUntilWindowLoads(wTitle);

            base.WaitForElementDisplayedInUi(By.Id("Main"));
            base.IsElementPresent(By.Id("Main"));
            base.SwitchToIFrameById("Main");

            base.WaitForElementDisplayedInUi(By.Id("Content"));
            base.IsElementPresent(By.Id("Content"));
            base.SwitchToIFrameById("Content");

           base.WaitForElementDisplayedInUi(By.CssSelector("#frmCourseHome  radeditor>p>a"));

           IWebElement grades = base.GetWebElementPropertiesByCssSelector("#frmCourseHome  radeditor>p>a");

           string grade = grades.Text;


           logger.LogAssertion("AcademicPageContents",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(grade, "Grades"));
        }

        catch(Exception e)
        {
            ExceptionHandler.HandleException(e);
        }

        finally
        {
            SwitchToDefaultWindow();
        }

        logger.LogMethodEntry("eCollegeIntegration", "CourseLinks",
                base.IsTakeScreenShotDuringEntryExit);
    }


    //When I select "Grades" of Pegasus course
    [When(@"I select ""(.*)"" of Pegasus course")]
    public void PegasusCourse(string p0)
    {
        logger.LogMethodEntry("eCollegeIntegration", "PegasusCourse",
                base.IsTakeScreenShotDuringEntryExit);

        try
        {
            
            base.WaitForElementDisplayedInUi(By.Id("Main"));
            base.IsElementPresent(By.Id("Main"));
            base.SwitchToIFrameById("Main");

            base.WaitForElementDisplayedInUi(By.Id("Content"));
            base.IsElementPresent(By.Id("Content"));
            base.SwitchToIFrameById("Content");

            IWebElement grades = base.GetWebElementPropertiesByLinkText("Grades");
            base.ClickByJavaScriptExecutor(grades);
            
        }

        catch (Exception e)
        {
            ExceptionHandler.HandleException(e);
        }

        logger.LogMethodEntry("eCollegeIntegration", "PegasusCourse",
                base.IsTakeScreenShotDuringEntryExit);
    }


        //Then I should see Pegasus "Gradebook"

    [Then(@"I should see Pegasus ""(.*)""")]
    public void PegasusGradebook(string p0)
    {
        logger.LogMethodEntry("eCollegeIntegration", "PegasusGradebook",
                base.IsTakeScreenShotDuringEntryExit);

        try
        {
            base.WaitUntilWindowLoads(p0);

            string check = base.GetWindowTitleByJavaScriptExecutor();

            new GBDefaultUXPage().GetActivityNameInGradebook("Access Chapter 1 Grader Project [Assessment 3]");

               
        }

        catch(Exception e)
        {
            ExceptionHandler.HandleException(e);
        }


        logger.LogMethodEntry("eCollegeIntegration", "PegasusGradebook",
                base.IsTakeScreenShotDuringEntryExit);
    }

    }

}
