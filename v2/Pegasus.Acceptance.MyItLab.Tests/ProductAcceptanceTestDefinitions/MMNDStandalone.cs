using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pegasus.Pages.Exceptions;
using Pegasus.Automation;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pegasus.Pages.UI_Pages.Integration.MMND;
using Pegasus.Automation.DataTransferObjects;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
   public class MMNDStandalone : PegasusBaseTestFixture
    {
        private static Logger MMNDStandalonelogger = Logger.GetInstance(typeof(MMNDStandalone));
        
        CourseHome CourseHomePage = new CourseHome();
        CourseLinks CourseLinksPage = new CourseLinks();

    
        
        ///Scenario: MMND user access the course link
        

        //Given user access the course link "MMNDCoOrdinate"
        [When(@"user access the course link ""(.*)""")]            
        [Given(@"user access the course link ""(.*)""")]
        public void UserAccessTheCourseLink(Course.CourseTypeEnum p0)
        {
            MMNDStandalonelogger.LogMethodEntry("CommonSteps", "UserAccessTheCourseLink",
              base.IsTakeScreenShotDuringEntryExit);

           
           
            try
            {
                Assert.AreEqual(true,CourseHomePage.clickCourse(p0));
            }

            catch (Exception ex)
            {
                MMNDStandalonelogger.LogMessage("CommonSteps", "UserAccessTheCourseLink", ex.Message, true);
                ExceptionHandler.HandleException(ex);
            }

            MMNDStandalonelogger.LogMethodExit("CommonSteps", "UserAccessTheCourseLink",
                base.IsTakeScreenShotDuringEntryExit);
           
        }

       // Then user should land inside the "MMNDCoOrdinate" course
        [Then(@"user should land inside the ""(.*)"" course")]
        public void InsideTheCourse(Course.CourseTypeEnum p0)
        {
            MMNDStandalonelogger.LogMethodEntry("CommonSteps", "InsideTheCourse",
               base.IsTakeScreenShotDuringEntryExit);



            try
            {
                Assert.AreEqual(true, CourseLinksPage.courseLoggedin(p0));
            }

            catch (Exception ex)
            {
                MMNDStandalonelogger.LogMessage("CommonSteps", "InsideTheCourse", ex.Message, true);
                ExceptionHandler.HandleException(ex);
            }

            MMNDStandalonelogger.LogMethodExit("CommonSteps", "InsideTheCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// Scenario: MMND user access the Pegasus link

        //Given user access the Pegaus link "View_All_Content"

        [Given(@"user access the Pegaus link ""(.*)""")]
        public void UserAccessThePegausLink(string p0)
        {
             MMNDStandalonelogger.LogMethodEntry("CommonSteps", "UserAccessThePegausLink",
               base.IsTakeScreenShotDuringEntryExit);



            try
            {
                CourseLinksPage.clickGivenLink(p0);
            }

            catch (Exception ex)
            {
                MMNDStandalonelogger.LogMessage("CommonSteps", "UserAccessThePegausLink", ex.Message, true);
                ExceptionHandler.HandleException(ex);
            }

            MMNDStandalonelogger.LogMethodExit("CommonSteps", "UserAccessThePegausLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        //Then user should land inside the "View All Course Materials" page
        [Then(@"user should land inside the ""(.*)"" page")]
        public void InsideThePegasusPage(string p0)
        {
            MMNDStandalonelogger.LogMethodEntry("CommonSteps", "InsideThePegasusPage",
             base.IsTakeScreenShotDuringEntryExit);



            try
            {
                Assert.AreEqual(true, CourseLinksPage.viewAllContentPegaus(p0));
            }

            catch (Exception ex)
            {
                MMNDStandalonelogger.LogMessage("CommonSteps", "InsideThePegasusPage", ex.Message, true);
                ExceptionHandler.HandleException(ex);
            }

            MMNDStandalonelogger.LogMethodExit("CommonSteps", "InsideThePegasusPage",
                base.IsTakeScreenShotDuringEntryExit);
        }



        ///Scenario: MMND Instructor access the course link
        //Given user access the course template "PPE Template"

        [Given(@"user access the course template ""(.*)""")]
        public void UserAccessTheCourseTemplate(Course.CourseTypeEnum p0)
        {
            MMNDStandalonelogger.LogMethodEntry("CommonSteps", "UserAccessTheCourseTemplate",
              base.IsTakeScreenShotDuringEntryExit);



            try
            {
                Assert.AreEqual(true, CourseHomePage.clickTemplate(p0));
            }

            catch (Exception ex)
            {
                MMNDStandalonelogger.LogMessage("CommonSteps", "UserAccessTheCourseTemplate", ex.Message, true);
                ExceptionHandler.HandleException(ex);
            }

            MMNDStandalonelogger.LogMethodExit("CommonSteps", "UserAccessTheCourseTemplate",
                base.IsTakeScreenShotDuringEntryExit);
        }


        //Then user should land inside the Grades page
        [Then(@"user should land inside the Grades page")]
        public void TheGradesPage()
        {
             MMNDStandalonelogger.LogMethodEntry("CommonSteps", "TheGradesPage",
              base.IsTakeScreenShotDuringEntryExit);



            try
            {
                Assert.AreEqual(true, CourseLinksPage.gradesInsPage());
            }

            catch (Exception ex)
            {
                MMNDStandalonelogger.LogMessage("CommonSteps", "TheGradesPage", ex.Message, true);
                ExceptionHandler.HandleException(ex);
            }

            MMNDStandalonelogger.LogMethodExit("CommonSteps", "TheGradesPage",
                base.IsTakeScreenShotDuringEntryExit);
        }
        


    }
}
