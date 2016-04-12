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


        //When I Select "Content" links for Pegasus
        [When(@"I Select ""(.*)"" links for Pegasus")]
        public void SelectLinksForPegasus(string p0)
        {
            logger.LogMethodEntry("BlackboardClassic", "SelectLinksForPegasus",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {
                base.SwitchToDefaultPageContent();
                base.WaitForElementDisplayedInUi(By.Id("courseMenuPalette_contents"));
                bool content = base.IsElementDisplayedByPartialLinkText(p0);
                IWebElement selectContentLink = base.GetWebElementPropertiesByPartialLinkText(p0);
                base.ClickByJavaScriptExecutor(selectContentLink);

             }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("BlackboardClassic", "SelectLinksForPegasus",
                base.IsTakeScreenShotDuringEntryExit);
        }

        //Then I should see "Gradebook" link for Pegasus
        [Then(@"I should see ""(.*)"" link for Pegasus")]
        public void PegasusLinks(string p0)
        {
            logger.LogMethodEntry("BlackboardClassic", "PegasusLinks",
               base.IsTakeScreenShotDuringEntryExit);

            try
            {
                base.SwitchToDefaultPageContent();
                base.WaitUntilWindowLoadsPartialTitle("Content");
                base.WaitForElementDisplayedInUi(By.Id("content_listContainer"));
                bool content = base.IsElementDisplayedByPartialLinkText(p0);
                IWebElement selectContentLink = base.GetWebElementPropertiesByPartialLinkText(p0);

                base.ClickByJavaScriptExecutor(selectContentLink);

            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("BlackboardClassic", "PegasusLinks",
                base.IsTakeScreenShotDuringEntryExit);
        }

        //Given I am on the "Content" page of blackboard
        [Given(@"I am on the ""(.*)"" page of blackboard")]
        public void ContentPageOfBlackboard(string p0)
        {
            logger.LogMethodEntry("BlackboardClassic", "ContentPageOfBlackboard",
              base.IsTakeScreenShotDuringEntryExit);

            try
            {

                base.SwitchToDefaultWindow();
                base.SwitchToDefaultPageContent();
                base.WaitUntilWindowLoadsPartialTitle(p0,20);
               
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("BlackboardClassic", "ContentPageOfBlackboard",
                base.IsTakeScreenShotDuringEntryExit);
        }


        //When I select "Grade Center" of Blackboard
        [When(@"I select ""(.*)"" of Blackboard")]
        public void GradeCenterOfBlackboard(string p0)
        {
            logger.LogMethodEntry("BlackboardClassic", "GradeCenterOfBlackboard",
              base.IsTakeScreenShotDuringEntryExit);

            try
            {
                base.SwitchToDefaultPageContent();
                base.IsElementPresent(By.Id("menuWrap"));
                base.IsElementPresent(By.Id("controlPanelPalette"));
                base.WaitForElementDisplayedInUi(By.Id("controlpanel.grade.center_groupExpanderLink"));
                base.IsElementPresent(By.Id("controlpanel.grade.center_groupExpanderLink"));
                bool content = base.IsElementDisplayedByPartialLinkText(p0);
                IWebElement selectContentLink = base.GetWebElementPropertiesByPartialLinkText(p0);

                base.ClickByJavaScriptExecutor(selectContentLink);

            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("BlackboardClassic", "GradeCenterOfBlackboard",
                base.IsTakeScreenShotDuringEntryExit);
            
        }

        //Then I should see "Full Grade Center" link
        [Then(@"I should see ""(.*)"" link")]
        public void FullGradeCenter(string p0)
        {
            logger.LogMethodEntry("BlackboardClassic", "FullGradeCenter",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //base.SwitchToDefaultPageContent();
                base.WaitForElementDisplayedInUi(By.Id("controlpanel.grade.center_groupContents"));
                base.WaitForElementDisplayedInUi(By.PartialLinkText(p0));
                //bool content = base.IsElementDisplayedByPartialLinkText(p0);
                IWebElement selectContentLink = base.GetWebElementPropertiesByPartialLinkText(p0);

                base.ClickByJavaScriptExecutor(selectContentLink);
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("BlackboardClassic", "FullGradeCenter",
                base.IsTakeScreenShotDuringEntryExit);
            
        }

        //When I select "Manage" link of GradeCenter
        [When(@"I select ""(.*)"" link of GradeCenter")]
        public void Manage(string p0)
        {
            logger.LogMethodEntry("BlackboardClassic", "Manage",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoadsPartialTitle("Grade Center");
                base.SwitchToDefaultPageContent();
                base.WaitForElementDisplayedInUi(By.Id("nav"));
                base.IsElementPresent(By.Id("nav"));
                //bool content = base.IsElementDisplayedByPartialLinkText(p0);
                IWebElement selectContentLink = base.GetWebElementPropertiesByCssSelector("#nav>li:nth-child(3)>h2>a");
                base.PerformMouseHoverByJavaScriptExecutor(selectContentLink);
               // base.PerformClickAction(selectContentLink);
                //base.MouseOverByJavaScriptExecutor(selectContentLink);
                //base.ClickByJavaScriptExecutor(selectContentLink);
                
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("BlackboardClassic", "Manage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        //Then I should see a menu "Pearson Custom Tools"
        [Then(@"I should see a menu ""(.*)""")]
        public void PearsonCustomTools(string p0)
        {
            logger.LogMethodEntry("BlackboardClassic", "PearsonCustomTools",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToDefaultPageContent();
                base.WaitForElementDisplayedInUi(By.Id("nav"));
                bool content = base.IsElementDisplayedByPartialLinkText(p0);
                //IWebElement selectContentLink = base.GetWebElementPropertiesByCssSelector("#nav>li:nth-child(3)>h2>a");
                IWebElement selectContentLink = base.GetWebElementPropertiesByLinkText(p0);
                base.ClickByJavaScriptExecutor(selectContentLink);
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("BlackboardClassic", "PearsonCustomTools",
                base.IsTakeScreenShotDuringEntryExit);

        }

        //When I select "Refresh Pearson Grades" link of Pearson Custom Integration Tools
        [When(@"I select ""(.*)"" link of Pearson Custom Integration Tools")]
        public void PearsonCustomIntegrationTools(string p0)
        {
            logger.LogMethodEntry("BlackboardClassic", "PearsonCustomIntegrationTools",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElementDisplayedInUi(By.Id("container"));
                bool content = base.IsElementDisplayedByPartialLinkText(p0);
                //IWebElement selectContentLink = base.GetWebElementPropertiesByCssSelector("#nav>li:nth-child(3)>h2>a");
                IWebElement selectContentLink = base.GetWebElementPropertiesByLinkText(p0);
                base.ClickByJavaScriptExecutor(selectContentLink);
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("BlackboardClassic", "PearsonCustomIntegrationTools",
                base.IsTakeScreenShotDuringEntryExit);
        }


        //Then I should be on "Refresh Pearson Grades"
        [Then(@"I should be on ""(.*)""")]
        public void RefreshPearsonGradePage(string p0)
        {
            logger.LogMethodEntry("BlackboardClassic", "RefreshPearsonGradePage",
             base.IsTakeScreenShotDuringEntryExit);

            try
            {

                //base.SwitchToLastOpenedWindow();
                base.WaitUntilWindowLoadsPartialTitle(p0, 20);

            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("BlackboardClassic", "RefreshPearsonGradePage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        //When I see grades for "Access Chapter 1 Grader Project [Assessment 3]" activity
        [When(@"I see grades for ""(.*)"" activity")]
        public void GradesForActivity(string p0)
        {
            logger.LogMethodEntry("BlackboardClassic", "GradesForActivity",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToDefaultPageContent();
                base.WaitForElementDisplayedInUi(By.Id("inventory_list_databody"),20);

                bool content = base.IsElementPresent(By.Id("inventory_list_databody"));
                //IWebElement selectContentLink = base.GetWebElementPropertiesByCssSelector("#nav>li:nth-child(3)>h2>a");
                IWebElement selectContentLink = base.GetWebElementPropertiesById("inventory_list_databody");

                int tableRows = base.GetElementCountByCssSelector("#inventory_list_databody>tr");

                IWebElement tableHeader;
                int i;

                for (i = 1; i <= tableRows; i++)
                {

                    tableHeader = base.GetWebElementPropertiesByCssSelector(string.Format("#inventory_list_databody>tr:nth-child({0})>th",i));
                    if (tableHeader.Text == p0)
                        break;

                }

                if (i > tableRows)
                    throw new NoSuchElementException();
                
               // base.ClickByJavaScriptExecutor(selectContentLink);
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("BlackboardClassic", "GradesForActivity",
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

                if (courseTitle == course)
                {
                    base.ClickByJavaScriptExecutor(courseName);
                    break;
                }

             }
        }




    }
}
