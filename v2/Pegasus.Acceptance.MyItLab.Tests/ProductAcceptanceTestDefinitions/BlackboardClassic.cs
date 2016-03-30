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
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Collections.ObjectModel;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    class BlackboardClassic : BasePage
    {
        private static Logger logger = Logger.GetInstance(typeof(BlackboardClassic));

        //Given I am on the "My Institution" page of Blackboard
        [Given(@"I am on the ""(.*)"" page of Blackboard")]
        public void MyInstitution(string p0)
        {
            logger.LogMethodEntry("BlackboardClassic", "MyInstitution",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
      
                base.WaitForElementDisplayedInUi(By.Id("MyInstitution.label"));
                IWebElement x = base.GetWebElementPropertiesById(("MyInstitution.label"));
                IWebElement z = x.FindElement(By.CssSelector("a>span"));

                string y = z.Text;
               
               logger.LogAssertion("MyInstitution",
                ScenarioContext.Current.ScenarioInfo.
                Title, ()=>Assert.AreEqual(y, p0));

            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("BlackboardClassic", "MyInstitution",
                base.IsTakeScreenShotDuringEntryExit);
        }

       //When I Select PegasusCourse link
       //Add switch case for PPE and Prod once available

        [When(@"I Select PegasusCourse link")]
        public void SelectPegasusCourseLink()
        {

            logger.LogMethodEntry("BlackboardClassic", "SelectPegasusCourseLink",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {

                string env = AutomationConfigurationManager.GetApplicationTestEnvironment();
                

                switch(env)
                {
                    case "CGIE":

                        string cgie = "CGIE MIL Course";
                        findCourse(cgie);
                        break;

                    case "VCD":

                        string vcd = "VCD MIL Course1";
                        findCourse(vcd);
                        break;

                   

                    default: throw new Exception("Environment not found");
                }
            }


           catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("BlackboardClassic", "SelectPegasusCourseLink",
                base.IsTakeScreenShotDuringEntryExit);

        }


        //Then I should see "Content" links for Pegasus
        [Then(@"I should see ""(.*)"" links for Pegasus")]
        public void LinksForPegasus(string p0)
        {
            logger.LogMethodEntry("BlackboardClassic", "LinksForPegasus",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {
                base.WaitForElementDisplayedInUi(By.Id("courseMenuPalette_contents"));
                bool content = base.IsElementDisplayedByPartialLinkText(p0);

                logger.LogAssertion("LinksForPegasus",
               ScenarioContext.Current.ScenarioInfo.
               Title, () => Assert.AreEqual(true, content));

            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("BlackboardClassic", "LinksForPegasus",
                base.IsTakeScreenShotDuringEntryExit);
            
        }




        //a small method that finds the course name in Myinstitution page

        public void findCourse(string courseTitle)

        {

            base.WaitForElementDisplayedInUi(By.Id("_4_1termCourses_noterm"));
            IWebElement courseLists = base.GetWebElementPropertiesById("_4_1termCourses_noterm");
            int count = base.GetElementCountByCssSelector("#_4_1termCourses_noterm>ul>li");

            for (int i = 1; i <= count; i++)
            {

                IWebElement courseList = courseLists.FindElement(By.CssSelector(string.Format("ul>li:nth-child({0})", i)));
                IWebElement courseName = courseList.FindElement(By.TagName("a"));

                string course = courseName.Text;

                if (CourseName == course)
                {
                    base.ClickByJavaScriptExecutor(courseName);
                    break;
                }

             }
        }




    }
}
