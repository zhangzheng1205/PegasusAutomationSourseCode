﻿using System;
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
            base.SwitchToLastOpenedWindow();
            base.WaitUntilWindowLoads(p0);

            string actualTitle=base.GetWindowTitleByJavaScriptExecutor();

            if (actualTitle!=p0)
            {
                throw new ArgumentException("Something went wrong during cross over to Pegasus");
            }

            logger.LogAssertion("PegasusGradebook",
             ScenarioContext.Current.ScenarioInfo.Title, () =>
                 Assert.AreEqual(actualTitle, p0));
            
           // new GBDefaultUXPage().GetActivityNameInGradebook("Access Chapter 1 Grader Project [Assessment 3]");

               
        }

        catch(Exception e)
        {
            ExceptionHandler.HandleException(e);
        }


        logger.LogMethodEntry("eCollegeIntegration", "PegasusGradebook",
                base.IsTakeScreenShotDuringEntryExit);
    }



    [When(@"I search ""(.*)"" of Pegasus course")]
    public void SearchActivity(string p0)
    {
        logger.LogMethodEntry("eCollegeIntegration", "SearchActivity",
                base.IsTakeScreenShotDuringEntryExit);
        try
        {
            string x = p0.Substring(0, 31);


            base.SwitchToIFrameById("srcGBFrame");
            base.WaitForElement(By.Id("AssignmentStatusCriteria"));

            base.SwitchToDefaultPageContent();

            base.WaitForElementDisplayedInUi(By.Id("LeftTD"));

            base.WaitForElementDisplayedInUi(By.CssSelector("a#viewFilter"));

            base.ClickByJavaScriptExecutor(GetWebElementPropertiesByCssSelector("a#viewFilter"));

            base.WaitForElementDisplayedInUi(By.CssSelector("a#titleSearch.filterclose"));

            base.IsElementPresent(By.CssSelector("a#titleSearch.filterclose"));

            base.ClickByJavaScriptExecutor(GetWebElementPropertiesByCssSelector("a#titleSearch.filterclose"));

            base.WaitForElement(By.Id("txtSearch"));

            //base.ClearTextById("txtSearch");

            IWebElement t = base.GetWebElementPropertiesById("txtSearch");

            t.Clear();

            System.Threading.Thread.Sleep(2000);

            t.SendKeys(x);

            System.Threading.Thread.Sleep(2000);

            t.SendKeys(Keys.Enter);

            base.SwitchToIFrameById("srcGBFrame");

            base.WaitForElement(By.Id("divSearchName"));

            string searchRes = base.GetElementInnerTextById("divSearchName");

            bool foundAct = searchRes.Contains(x);

            logger.LogAssertion("SearchActivity",
                         ScenarioContext.Current.ScenarioInfo.Title, () =>
                             Assert.AreEqual(true, foundAct));

        }

        catch (Exception e)
        {
            ExceptionHandler.HandleException(e);
        }

        finally
        {

            base.SwitchToDefaultPageContent();
        }

        logger.LogMethodEntry("eCollegeIntegration", "SearchActivity",
                base.IsTakeScreenShotDuringEntryExit);
    }

// its my life
    [Then(@"I should see ""(.*)"" in Gradebook")]
    public void ActivityOnPegasusGradebookPage(string p0)
    {
        logger.LogMethodEntry("eCollegeIntegration", "ActivityOnPegasusGradebookPage",
            base.IsTakeScreenShotDuringEntryExit);

        try
        {
            //base.WaitForElementDisplayedInUi(By.Id("RightTD"));

            base.SwitchToIFrameById("srcGBFrame");

            //bool y = base.IsElementPresent(By.CssSelector("a.GbHeaderLink.TextInListViews[title='Chapter 1 Exam']"));

            base.WaitForElement(By.Id("GBGridHeaderTable"));

            int nuOfRows = base.GetElementCountByCssSelector("td.GBcolumnCaptionrow2");

            IWebElement g = base.GetWebElementPropertiesByCssSelector("a.GbHeaderLink.TextInListViews");

            bool v = base.IsElementPresent(By.CssSelector("td.GBcolumnCaptionrow2:nth-child(1)>div>span>a"),20);
            string b0;
            
            for (int i = 1; i < nuOfRows; i++)
			{

                g = base.GetWebElementPropertiesByCssSelector(string.Format("td.GBcolumnCaptionrow2:nth-child({0})>div>span>a",i));
                b0=g.GetAttribute("title");

                if (b0 == p0)
                    break;

			}
            

        }

        catch (Exception e)
        {
            ExceptionHandler.HandleException(e);
        }

        /*logger.LogAssertion("verifyPegasusActivity",
    ScenarioContext.Current.ScenarioInfo.
         Title, () => Assert.AreEqual(p0, b0));*/

        logger.LogMethodEntry("eCollegeIntegration", "ActivityOnPegasusGradebookPage",
            base.IsTakeScreenShotDuringEntryExit);
    }
//--------------------------------------------------------
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



            for (int i = 1; i <= columns; i++)
            {

                c = base.GetWebElementPropertiesByCssSelector
                    (string.Format("#GBGridHeaderTable #FirstTr>td:nth-child({0})>span>a", i));

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


            bool r = base.IsElementDisplayedById("Grid1$contentCntr");

            int rows1 = base.GetElementCountByCssSelector("#Grid1 >tbody >tr");

            int columns1 = base.GetElementCountByCssSelector("#Grid1 >tbody >tr > td");

            IWebElement studentName, studentScore, studentGrade;

            bool rr = base.IsElementPresent(By.CssSelector("#Grid1 >tbody >tr:nth-child(1) >td"), 10);

            for (int ab = 1; ab <= rows1; ab++)
            {
                studentName = base.GetWebElementPropertiesByCssSelector(string.Format("#Grid1 >tbody >tr:nth-child({0})", ab));

                IWebElement spantag = studentName.FindElement(By.TagName("span"));

                string myName = spantag.GetAttribute("title");

                if (myName == "Kumar, Madhu")
                {
                    studentScore = base.GetWebElementPropertiesByCssSelector(string.Format("#Grid1 >tbody >tr:nth-child({0})>td:nth-child({1})", ab, ab + 1));

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

        catch (Exception e)
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
