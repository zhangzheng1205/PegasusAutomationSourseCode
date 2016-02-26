using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.D2L;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Globalization;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
   [Binding]

   public class D2LIntegration : BasePage
    {
       private static Logger logger = Logger.GetInstance(typeof(D2LCourseAction));

// #Feature: Instructor selecting a Pegasus course link in home Page
// Scenario: D2L Instructor selecting a Pegasus course link in home Page
// Given I am on the home page of DesiretoLearn

       [Given(@"I am on the home page of DesiretoLearn")]
        public void HomePageOfDesiretoLearn()
        {
            logger.LogMethodEntry("D2LIntegration", "HomePageOfDesiretoLearn",
                base.IsTakeScreenShotDuringEntryExit);

                       
            logger.LogAssertion("VerifyHomePage",
                ScenarioContext.Current.ScenarioInfo.Title, () =>
                    Assert.AreNotEqual(false, new D2LLoginPage().IsUserLoggedInSuccessFully())); 
                      
            logger.LogMethodEntry("D2LIntegration", "HomePageOfDesiretoLearn",
              base.IsTakeScreenShotDuringEntryExit);
            
        }


 // When I select "D2L Kiosk Integration for Automation - Pegasus" course link in Select Courses
        [When(@"I select ""(.*)"" course link in Select Courses")]
        public void SelectCourses(string courseLink)
        {
            logger.LogMethodEntry("D2LIntegration", "HomePageOfDesiretoLearn",
                  base.IsTakeScreenShotDuringEntryExit);

            new D2LCourseAction().D2LCourseSelect(courseLink);

            logger.LogMethodEntry("D2LIntegration", "HomePageOfDesiretoLearn",
              base.IsTakeScreenShotDuringEntryExit);
        }

 // Then I should see an MMND link page to Pegasus
        [Then(@"I should see ""(.*)"" Page")]
        [Given(@"User is on the ""(.*)"" page")]
        [Given(@"User is on the ""(.*)"" Page")]
       public void MMNDLinkPageToPegasus(string expectedPageTitle)
        {
            logger.LogMethodEntry("D2LIntegration", "MMNDLinkPageToPegasus",
                 base.IsTakeScreenShotDuringEntryExit);

         
            base.WaitUntilWindowLoads(expectedPageTitle);
            base.SelectWindow(expectedPageTitle);

            string actualPageTitle = WebDriver.Title.ToString(CultureInfo.InvariantCulture);

            logger.LogAssertion("verifyPageTitle",
            ScenarioContext.Current.ScenarioInfo.
                 Title, () => Assert.AreEqual(expectedPageTitle, actualPageTitle));

            logger.LogMethodEntry("D2LIntegration", "MMNDLinkPageToPegasus",
              base.IsTakeScreenShotDuringEntryExit);
        }

       

//When I select "Pearson's Mylab and Mastering" course link 

        [When(@"I select ""(.*)"" course link")]
        public void SelectCourseLink(string MMNDLink)
        {
            logger.LogMethodEntry("D2LIntegration", "SelectCourseLink",
                 base.IsTakeScreenShotDuringEntryExit);
            
            base.SwitchToIFrameByIndex(0);

            string c = base.GetElementInnerTextByCssSelector(".pure-menu.pure-menu-open>ul>li>a");
            base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByCssSelector(".pure-menu.pure-menu-open>ul>li>a"));

            logger.LogMethodEntry("D2LIntegration", "SelectCourseLink",
              base.IsTakeScreenShotDuringEntryExit);
        }

//When Instructor access "MyITLab Course Home" Link
        [When(@"Instructor access ""(.*)"" Link")]
        public void InstructorAccessLink(string p0)
        {
            logger.LogMethodEntry("D2LIntegration", "InstructorAccessLink",
                 base.IsTakeScreenShotDuringEntryExit);
            
            string d = base.GetElementInnerTextByCssSelector("#studlinks>h3>a");
            
            IWebElement c = base.GetWebElementPropertiesByCssSelector("#studlinks>h3>a");
            
            if (d == p0)

                base.ClickByJavaScriptExecutor(c);

            logger.LogMethodEntry("D2LIntegration", "InstructorAccessLink",
              base.IsTakeScreenShotDuringEntryExit);
        }

        //When Instructor clicks "Instructor Tools" Link
        [When(@"Instructor clicks ""(.*)"" Link")]
        public void InstructorLink(string p0)
        {
        
            logger.LogMethodEntry("D2LIntegration", "InstructorLink",
                base.IsTakeScreenShotDuringEntryExit);
            IWebElement c;
            string d = null;

            try
            {

                do
                {

                    
                    base.WaitUntilWindowLoads("Announcements");

                    base.WaitForElementDisplayedInUi(By.CssSelector(".ng-binding"));

                    d = base.GetElementInnerTextByCssSelector(".ng-binding[title='Instructor Tools']");

                    c = base.GetWebElementPropertiesByCssSelector(".ng-binding[title='Instructor Tools']");

                }

                while (d != p0);

                if (d == p0)
                    base.ClickByJavaScriptExecutor(c);

            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("D2LIntegration", "InstructorLink",
              base.IsTakeScreenShotDuringEntryExit);
        }

        //When Instructor selects "Gradebook" Link
        [When(@"Instructor selects ""(.*)"" Link")]
        public void InstructorLinkGB(string p0)
        {
            logger.LogMethodEntry("D2LIntegration", "InstructorLinkGB",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {


                base.SwitchToIFrameById("centerIframe");

                base.WaitForElementDisplayedInUi(By.CssSelector(".mlnd_link_image_list>li>p>a[onclick*='Grades']"));

                string d = base.GetElementInnerTextByCssSelector(".mlnd_link_image_list>li>p>a[onclick*='Grades']");

                IWebElement c = base.GetWebElementPropertiesByCssSelector(".mlnd_link_image_list>li>p>a[onclick*='Grades']");
                
                if (d == p0)

                    base.ClickByJavaScriptExecutor(c);

                
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            finally
            {
                base.SwitchToDefaultPageContent();
                
            }

            logger.LogMethodEntry("D2LIntegration", "InstructorLinkGB",
              base.IsTakeScreenShotDuringEntryExit);
        }

        //Then I should be on the Pegasus Gradebook page
        [Then(@"I should be on the Pegasus Gradebook page")]
        public void PegasusGradebookPage()
        {

            logger.LogMethodEntry("D2LIntegration", "PegasusGradebookPage",
                    base.IsTakeScreenShotDuringEntryExit);

            bool t1 = false;

            try
            {

                //Thread.Sleep(2000);
                
                //base.WaitForElementDisplayedInUi(By.Id("content-frame"));
                //bool rr = base.IsElementDisplayedById("content-area");
                //bool rx = base.IsElementDisplayedById("content-frame");
               // bool x = base.IsElementPresent(By.Id("centerIframe"));
               // base.SwitchToIFrameById("centerIframe");
               // base.Selec

              

               base.SwitchToIFrameById("centerIframe");
              
               bool xe = base.IsElementDisplayedById("srcGBFrame");
               base.WaitForElementDisplayedInUi(By.Id("srcGBFrame"));

               //base.WaitForElementDisplayedInUi(By.CssSelector("#AssignmentStatusCriteria"));

               //base.SwitchToIFrameById("centerIframe");
                    base.WaitForElementDisplayedInUi(By.Id("LeftTD"));
                    base.WaitForElementDisplayedInUi(By.Id("titleSearch"));
                    //t1 = base.IsElementPresent(By.CssSelector("#titleSearch.filterclose"));
                   t1= base.IsElementPresent(By.Id("titleSearch"));

            }

            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogAssertion("verifyPegasusGradebook",
           ScenarioContext.Current.ScenarioInfo.
                Title, () => Assert.AreEqual(true, t1));

            logger.LogMethodEntry("D2LIntegration", "PegasusGradebookPage",
              base.IsTakeScreenShotDuringEntryExit);

        }

        //When Instructor searches "Chapter 1 Exam" assessment
        [When(@"Instructor searches ""(.*)"" assessment")]
        public void InstructorSearchesAssessment(string p0)
        {
            logger.LogMethodEntry("D2LIntegration", "InstructorSearchesAssessment",
                base.IsTakeScreenShotDuringEntryExit);

            try
            {

                base.WaitForElementDisplayedInUi(By.Id("ViewFilterHeader"));
                base.WaitForElementDisplayedInUi(By.Id("titleSearch"));
                IWebElement c = base.GetWebElementPropertiesByCssSelector("#titleSearch.filterclose");

                base.ClickByJavaScriptExecutor(c);

                bool clicksuccess = base.IsElementPresent(By.CssSelector("#titleSearch.filteropen"));

                if (clicksuccess == false)
                {
                    base.ClickByJavaScriptExecutor(c);
                }

                
                base.WaitForElementDisplayedInUi(By.Id("txtSearch"));
                                                     
                IWebElement t = base.GetWebElementPropertiesById("txtSearch");
                
                t.Clear();
                //base.ClearTextById("txtSearch");
                Thread.Sleep(2000);
                t.SendKeys(p0);
                
                Thread.Sleep(2000);
               
                t.SendKeys(Keys.Enter);
                


             }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("D2LIntegration", "InstructorSearchesAssessment",
                base.IsTakeScreenShotDuringEntryExit);

        }

        //Then I should see "Chapter 1 Exam" on Pegasus Gradebook page
        [Then(@"I should see ""(.*)"" on Pegasus Gradebook page")]
        public void ActivityOnPegasusGradebookPage(string p0)
        {
            logger.LogMethodEntry("D2LIntegration", "ActivityOnPegasusGradebookPage",
                base.IsTakeScreenShotDuringEntryExit);
                
            try
            {
                base.WaitForElementDisplayedInUi(By.Id("RightTD"));
              
                base.SwitchToIFrameById("srcGBFrame");
                bool y = base.IsElementPresent(By.CssSelector("a.GbHeaderLink.TextInListViews[title='Chapter 1 Exam']"));

        
                IWebElement g = base.GetWebElementPropertiesByCssSelector("a.GbHeaderLink.TextInListViews[title='Chapter 1 Exam']");

                
                string b0= g.GetAttribute("title");

                

                logger.LogAssertion("verifyPegasusActivity",
        ScenarioContext.Current.ScenarioInfo.
             Title, () => Assert.AreEqual(p0, b0));
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("D2LIntegration", "ActivityOnPegasusGradebookPage",
                base.IsTakeScreenShotDuringEntryExit);
        }

        //When Instructor edits "Chapter 1 Exam" assessment to 70%
        [When(@"Instructor edits ""(.*)"" assessment to (.*)%")]
        public void EditsAssessmentScore(string p0, int p1)
        {
            logger.LogMethodEntry("D2LIntegration", "EditsAssessmentScore",
                 base.IsTakeScreenShotDuringEntryExit);

            try

            {
                
               // IWebElement table = base.GetWebElementPropertiesByCssSelector("#FirstTr");

              

              int columns = base.GetElementCountByCssSelector("#FirstTr>td");
             

                IWebElement position, cmenu, c, d;
                


                for (int i = 1; i <=columns; i++)
                {

                    c = base.GetWebElementPropertiesByCssSelector
                        (string.Format("#GBGridHeaderTable #FirstTr>td:nth-child({0})>span>a",i));

                   d = base.GetWebElementPropertiesByCssSelector
                        (string.Format("#GBGridHeaderTable #FirstTr>td:nth-child({0})>div", i));

                    string t = c.GetAttribute("title");
                    if (t == p0)
                    {
                        position = c;
                        cmenu = d;
                        cmenu.Click();
                        break;
                    }

                }

                base.WaitForElementDisplayedInUi(By.Id("_ctl0_InnerPageContent_lbleditgrades2"));

                IWebElement editGrade = base.GetWebElementPropertiesById("_ctl0_InnerPageContent_lbleditgrades2");

                //IWebElement s = editGrade.FindElement(By.TagName("input"));

                base.ClickByJavaScriptExecutor(editGrade);

                base.WaitUntilPopUpLoads("Edit Grades", 30);

                base.SelectWindow("Edit Grades");


               bool r=  base.IsElementDisplayedById("Grid1$contentCntr");

               int rows1 = base.GetElementCountByCssSelector("#Grid1 >tbody >tr");

               int columns1 = base.GetElementCountByCssSelector("#Grid1 >tbody >tr > td");

               IWebElement studentName, studentScore, studentGrade;

               bool rr = base.IsElementPresent(By.CssSelector("#Grid1 >tbody >tr:nth-child(1) >td"),10);

               for(int ab = 1; ab <= rows1; ab++)
               {
                   studentName = base.GetWebElementPropertiesByCssSelector(string.Format("#Grid1 >tbody >tr:nth-child({0})",ab));

                   IWebElement spantag = studentName.FindElement(By.TagName("span"));

                   string myName = spantag.GetAttribute("title");

                   if (myName == "Kumar, Madhu")
                   
                   {
                       studentScore = base.GetWebElementPropertiesByCssSelector(string.Format("#Grid1 >tbody >tr:nth-child({0})>td:nth-child({1})", ab, ab+1));

                       //studentGrade = studentName.FindElement(By.TagName("input"));

                       studentGrade = studentName.FindElement(By.Name("txtedit"));

                       studentGrade.Clear();
                       studentGrade.SendKeys("8");
                       IWebElement save = base.GetWebElementPropertiesById("btnSave");
                       base.ClickByJavaScriptExecutor(save);


                       break;
                   }
               }

              //  :nth-child({0})


            }

            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodEntry("D2LIntegration", "EditsAssessmentScore",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        [Then(@"I should see (.*)% for ""(.*)"" on Pegasus Gradebook page")]
        public void ThenIShouldSeeForOnPegasusGradebookPage(int p0, string p1)
        {
            try
            {
                base.WaitForElementDisplayedInUi(By.Id("RightTD"));

                base.SwitchToIFrameById("srcGBFrame");



            }

            catch (Exception e)
                {
                    ExceptionHandler.HandleException(e);
                }
            
        }


    }
}
