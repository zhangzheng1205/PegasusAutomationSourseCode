using Pearson.Pegasus.TestAutomation.Frameworks;
using System;
using System.Collections.Generic;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Threading;
using System.Configuration;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.CourseMaterials;
using Pegasus.Automation;
using OpenQA.Selenium;


namespace Pegasus.Acceptance.HigherEducation.HSS.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    class Component:BasePage
    {
        private static readonly Logger Logger = Logger.GetInstance(typeof(Component));

        //When I enter into "HED Components Test Course" from the Global Home page
        [When(@"I enter into ""(.*)"" from the Global Home page")]
        public void EnterInCourse(string p0)
        {
            Logger.LogMethodEntry("Component", "EnterInCourse",
               base.IsTakeScreenShotDuringEntryExit);
            //Enter Into The Course
            try
            {
                new HEDGlobalHomePage().OpenTheCourse(p0);
                
            }

            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("Component", " EnterInCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        //When I click on "Completed" items
        [When(@"I click on ""(.*)"" items")]
        public void CompletedItems(string p0)
        {
            Logger.LogMethodEntry("Component", "CompletedItems",
               base.IsTakeScreenShotDuringEntryExit);
            //Enter Into The Course
            try
            {
                new CourseMaterialPage().clicksubtab(p0);
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("Component", " CompletedItems",
                base.IsTakeScreenShotDuringEntryExit);
        }

        //When I click on "View Submissions" of Take the Chapter 1 Exam test
        [When(@"I click on View Submissions of Take the Chapter Exam test")]
        public void ViewSubmissionofTest()
        {
              Logger.LogMethodEntry("Component", "ViewSubmissionofTest",
               base.IsTakeScreenShotDuringEntryExit);
            //Enter Into The Course
            try
            {
                new CourseMaterialPage().clickSubmission();
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("Component", " ViewSubmissionofTest",
                base.IsTakeScreenShotDuringEntryExit);
        }

        //Scenario: Student Accessing submitted record
        [When(@"I click on submission of Take the Chapter Exam test")]
        public void ViewSubmissionRecord()
        {
            Logger.LogMethodEntry("Component", "ViewSubmissionRecord",
              base.IsTakeScreenShotDuringEntryExit);
            //Enter Into The Course
            try
            {
                new CourseMaterialPage().viewSubmissionRecord();
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("Component", " ViewSubmissionRecord",
                base.IsTakeScreenShotDuringEntryExit);
        }


        [Then(@"I should see submitted answers")]
        public void SeeSubmittedAnswers()
        {
            Logger.LogMethodEntry("Component", "SeeSubmittedAnswers",
            base.IsTakeScreenShotDuringEntryExit);

            bool answerspresent = false;
           
            try
            {
               answerspresent= new CourseMaterialPage().submittedAnswersPresent();
               Assert.AreEqual(true, answerspresent);
            }

                

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("Component", " SeeSubmittedAnswers",
                base.IsTakeScreenShotDuringEntryExit);
        }

        //Scenario: Student Accessing Print tool for a submitted record
        [When(@"I click on print tool")]
        public void PrintTool()
        {
            Logger.LogMethodEntry("Component", "PrintTool",
           base.IsTakeScreenShotDuringEntryExit);

            

            try
            {
                 new CourseMaterialPage().printOption();
                
            }



            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("Component", " PrintTool",
                base.IsTakeScreenShotDuringEntryExit);
        }

        //Scenario: Student Accessing download link of print
//When I click on Download link
        [When(@"I click on Download link")]
        public void DownloadLink()
        {
            Logger.LogMethodEntry("Component", "DownloadLink",
          base.IsTakeScreenShotDuringEntryExit);



            try
            {




                base.SwitchToWindow("Print tool");




                }



            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("Component", " DownloadLink",
                base.IsTakeScreenShotDuringEntryExit);
            
        }

        //Then I should be connected Aspose print tool services
        [Then(@"I should be connected Aspose print tool services")]
        public void AsposePrintToolServices()
        {
            Logger.LogMethodEntry("Component", "AsposePrintToolServices",
        base.IsTakeScreenShotDuringEntryExit);



            try
            {

                IWebElement print = base.GetWebElementPropertiesById("ibtnOk");
                //Thread.Sleep(2000);
                int returnedcode = FiddlerProxy.ClickNavigate(print);
                //Thread.Sleep(2000);
                Assert.AreEqual(200, returnedcode);
                

            }



            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("Component", " AsposePrintToolServices",
                base.IsTakeScreenShotDuringEntryExit);
            
        }
        //When I close Print and View submission page
        [When(@"I close Print and View submission page")]
        public void WhenIClosePrintAndViewSubmissionPage()
        {

            Logger.LogMethodEntry("Component", "WhenIClosePrintAndViewSubmissionPage",
        base.IsTakeScreenShotDuringEntryExit);



            try
            {

                base.SwitchToWindow("Print tool");
                IWebElement cancelbutton = base.GetWebElementPropertiesById("ibtnCancel");
                base.ClickByJavaScriptExecutor(cancelbutton);


                base.SwitchToWindow("View Submission");
                string x = base.GetWindowTitleByJavaScriptExecutor();
                bool a = base.IsElementDisplayedById("_ctl0:PopupPageContent:btnClose");
                IWebElement close = base.GetWebElementPropertiesById("_ctl0:PopupPageContent:btnClose");
                base.ClickByJavaScriptExecutor(close);

                
            }



            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("Component", " WhenIClosePrintAndViewSubmissionPage",
                base.IsTakeScreenShotDuringEntryExit);
            
        }


        [Then(@"I should see parent page of Pegasus")]
        public void ThenIShouldSeeParentPageOfPegasus()
        {
            try
            {

                base.SwitchToWindow("Assignments - Done");
                string primary = WebDriver.Title;

                Assert.AreEqual("Assignments - Done", primary);
            }



            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

    }
}
