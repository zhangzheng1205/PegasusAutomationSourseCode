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
                base.SelectWindow("Print tool");
                ClickByJavaScriptExecutor(base.GetWebElementPropertiesById("ibtnOk"));

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

               
                

            }



            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("Component", " AsposePrintToolServices",
                base.IsTakeScreenShotDuringEntryExit);
            
        }


        
    }
}
