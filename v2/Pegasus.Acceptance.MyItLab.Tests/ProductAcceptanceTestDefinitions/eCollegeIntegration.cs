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
        string t = "";
        try
        {
           
            base.SwitchToIFrameById("srcGBFrame");

            base.WaitForElement(By.Id("GBGridHeaderTable"));

            int nuOfRows = base.GetElementCountByCssSelector("#FirstTr>td");

            IWebElement c,d,position,cmenu;
           
            for (int i = 1; i < nuOfRows; i++)
			{

                c = base.GetWebElementPropertiesByCssSelector
                    (string.Format("#GBGridHeaderTable #FirstTr>td:nth-child({0})>span>a", i));

                d = base.GetWebElementPropertiesByCssSelector
                     (string.Format("#GBGridHeaderTable #FirstTr>td:nth-child({0})>div", i));

                t = c.GetAttribute("title");
                if (t == p0)
                {
                    position = c;
                    cmenu = d;
                    cmenu.Click();
                    break;
                }

			}
            
            if(t!=p0)
            {
                throw new ArgumentException("Activity not found!");
            }
        }

        catch (Exception e)
        {
            ExceptionHandler.HandleException(e);
        }

        logger.LogAssertion("verifyPegasusActivity",
    ScenarioContext.Current.ScenarioInfo.
         Title, () => Assert.AreEqual(p0, t));

        logger.LogMethodEntry("eCollegeIntegration", "ActivityOnPegasusGradebookPage",
            base.IsTakeScreenShotDuringEntryExit);
    }
//--------------------------------------------------------
    //When Instructor edits "Chapter 1 Exam" assessment to 70%
   [When(@"instructor sets score for ""(.*)"" activity for ""(.*)""")]
    public void EditsAssessmentScore(string p0, User.UserTypeEnum userName)

    {
        logger.LogMethodEntry("eCollegeIntegration", "EditsAssessmentScore",
             base.IsTakeScreenShotDuringEntryExit);

        bool editPopup = true;
        try
        {

            User user = User.Get(userName);
            string fullName = string.Format(user.FirstName + ","+" " + user.LastName);

            base.WaitForElementDisplayedInUi(By.Id("_ctl0_InnerPageContent_lbleditgrades2"));

            IWebElement editGrade = base.GetWebElementPropertiesById("_ctl0_InnerPageContent_lbleditgrades2");

            base.ClickByJavaScriptExecutor(editGrade);

            base.WaitUntilPopUpLoads("Edit Grades", 30);

            base.SelectWindow("Edit Grades");


            bool r = base.IsElementDisplayedById("Grid1$contentCntr");

            int rows1 = base.GetElementCountByCssSelector("#Grid1 >tbody >tr");

            int columns1 = base.GetElementCountByCssSelector("#Grid1 >tbody >tr > td");

            IWebElement studentName, studentScore, studentGrade, studentMaxScore;

            bool rr = base.IsElementPresent(By.CssSelector("#Grid1 >tbody >tr:nth-child(1) >td"), 10);

            for (int ab = 1; ab <= rows1; ab++)
            {
                studentName = base.GetWebElementPropertiesByCssSelector(string.Format("#Grid1 >tbody >tr:nth-child({0})", ab));

                IWebElement spantag = studentName.FindElement(By.TagName("span"));

                string myName = spantag.GetAttribute("title");

                if (myName == fullName)
                {
                    studentScore = base.GetWebElementPropertiesByCssSelector(string.Format("#Grid1 >tbody >tr:nth-child({0})>td:nth-child({1})", ab, ab + 1));

                    studentGrade = studentName.FindElement(By.Name("txtedit"));
                    studentMaxScore= studentName.FindElement(By.Name("txteditMS"));

                    studentGrade.Clear();
                    studentGrade.SendKeys("8");

                    studentMaxScore.Clear();
                    studentMaxScore.SendKeys("10");
                    
                    IWebElement save = base.GetWebElementPropertiesById("btnSave");
                    base.ClickByJavaScriptExecutor(save);

                    base.WaitUntilWindowLoads("Gradebook");

                    editPopup = base.IsWindowsExists("Edit Grades",60);
                    

                    break;
                }
            }

            


        }

        catch (Exception e)
        {
            ExceptionHandler.HandleException(e);
        }

       finally
        {
            base.SwitchToDefaultPageContent();
        }

        logger.LogAssertion("verifyGradeEdit",
     ScenarioContext.Current.ScenarioInfo.
          Title, () => Assert.AreEqual(false, editPopup));
       
        logger.LogMethodEntry("eCollegeIntegration", "EditsAssessmentScore",
             base.IsTakeScreenShotDuringEntryExit);
    }


   [Then(@"I should see edited score for ""(.*)"" in Gradebook for ""(.*)""")]
   public void EditedScoreInGradebook(string p0, User.UserTypeEnum userName)
   {
       logger.LogMethodEntry("eCollegeIntegration", "EditedScoreInGradebook",
             base.IsTakeScreenShotDuringEntryExit);

       int checkGrade = 0;
      
       string fullName = null;
      
       bool found= false;

       try
       {
           base.SwitchToIFrameById("srcGBFrame");

           base.WaitForElement(By.Id("GBGridHeaderTable"));

           int nuOfRows = base.GetElementCountByCssSelector("#FirstTr>td");

           IWebElement c, d, gradeLocation; string t = "";
           int columnPosition = 0;
           User user = User.Get(userName);
          fullName = string.Format(user.FirstName + "," + " " + user.LastName);
           //find activity
           for (int i = 1; i < nuOfRows; i++)
           {

               c = base.GetWebElementPropertiesByCssSelector
                   (string.Format("#GBGridHeaderTable #FirstTr>td:nth-child({0})>span>a", i));

               
               d = base.GetWebElementPropertiesByCssSelector
                    (string.Format("#GBGridHeaderTable #FirstTr>td:nth-child({0})>div", i));

               t = c.GetAttribute("title");
               if (t == p0)
               {
                   columnPosition = i;
                   break;
               }

               

           }

           if(t!= p0)
           {
               columnPosition = 0;
               throw new ArgumentException("Could not find the activity in the page");
           }


           int nuOfStudents = base.GetElementCountByCssSelector("#GBGridDataTable tr");

           IWebElement trial = base.GetWebElementPropertiesByCssSelector("#GBGridDataTable");

           

           //match row with column

          
           for (int counter = 1; counter < nuOfStudents; counter++)
           {
               
               if (counter % 2 == 0)
               {
                   c = trial.FindElement(By.CssSelector(string.Format("tr.odd:nth-child({0})", counter)));
                  
                }
             

               else
               {
                   c = trial.FindElement(By.CssSelector(string.Format("tr.odd:nth-child({0})", counter)));
                  
               }
                   
               d = c.FindElement(By.CssSelector(string.Format("td:nth-child({0})", columnPosition)));
               gradeLocation = d.FindElement(By.TagName("div"));

               checkGrade = int.Parse(gradeLocation.Text);

               if (checkGrade == 80 )
               {
                  found= StudentExist(counter,fullName);

                  if (found == true) ;
                  break;
                 
               }
           }

       }

          
       catch (Exception e)
       {
           ExceptionHandler.HandleException(e);
       }

   
       logger.LogAssertion("verifyGradeEdit",
     ScenarioContext.Current.ScenarioInfo.
          Title, () => Assert.AreEqual(true, found));

        logger.LogMethodEntry("eCollegeIntegration", "EditedScoreInGradebook",
              base.IsTakeScreenShotDuringEntryExit);
    }
   
        //When instructor closes "Gradebook" page
   [When(@"instructor closes ""(.*)"" page")]
   public void ClosePegasusWindow(string p0)
   {
       logger.LogMethodEntry("eCollegeIntegration", "ClosePegasusWindow",
              base.IsTakeScreenShotDuringEntryExit);

       base.SwitchToDefaultPageContent();

       bool checkWindow = base.IsWindowsExists(p0);

       base.WaitForElementDisplayedInUi(By.Id("_ctl0__ctl0_phHeader__ctl0_ucs_HelloObject_testLogOut"));

       base.IsElementPresent(By.Id("_ctl0__ctl0_phHeader__ctl0_ucs_HelloObject_testLogOut"));

       IWebElement close = base.GetWebElementPropertiesById("_ctl0__ctl0_phHeader__ctl0_ucs_HelloObject_testLogOut");

       base.ClickByJavaScriptExecutor(close);
       
       
       logger.LogMethodEntry("eCollegeIntegration", "ClosePegasusWindow",
              base.IsTakeScreenShotDuringEntryExit);
   }

       // Then I should not see "Gradebook" page opened

   [Then(@"I should not see ""(.*)"" page opened")]
   public void CheckWindowClosed(string p0)
   {
       logger.LogMethodEntry("eCollegeIntegration", "CheckWindowClosed",
              base.IsTakeScreenShotDuringEntryExit);
       bool checkWindow = base.IsWindowsExists(p0,20);

       logger.LogAssertion("verifyGradebookClosed",
     ScenarioContext.Current.ScenarioInfo.
          Title, () => Assert.AreEqual(false, checkWindow));
       
       logger.LogMethodEntry("eCollegeIntegration", "CheckWindowClosed",
              base.IsTakeScreenShotDuringEntryExit);
   }

 //Given I am on the dotNextLaunch page of eCollege
   [Given(@"I am on the ""(.*)"" page of eCollege")]
   public void DotNextLaunchPageOfECollege(string p0)
   {
       logger.LogMethodEntry("eCollegeIntegration", "DotNextLaunchPageOfECollege",
               base.IsTakeScreenShotDuringEntryExit);

      
       base.SwitchToDefaultWindow();
       base.SwitchToDefaultPageContent();
       string currentURL = base.GetCurrentUrl;

       bool correctPage = currentURL.Contains(p0);

       logger.LogAssertion("verifyGradebookClosed",
    ScenarioContext.Current.ScenarioInfo.
         Title, () => Assert.AreEqual(true, correctPage));

       logger.LogMethodEntry("eCollegeIntegration", "DotNextLaunchPageOfECollege",
               base.IsTakeScreenShotDuringEntryExit);
   }

   //When I select "Gradebook" of eCollege

   [When(@"I select ""(.*)"" of eCollege")]
   public void eCollegeGradebook(string p0)
   {
       logger.LogMethodEntry("eCollegeIntegration", "eCollegeGradebook",
               base.IsTakeScreenShotDuringEntryExit);
       base.SwitchToDefaultPageContent();
       base.IsElementDisplayedById("Main");

       base.IsElementPresent(By.Id("Main"));

       base.SwitchToIFrameById("Main");
       base.IsElementDisplayedInPage(By.Id("Top"),true);
       
       base.SwitchToIFrameById("Top");

       base.IsElementDisplayedById("GRADEBOOK");

       IWebElement Gradebook = base.GetWebElementPropertiesById("GRADEBOOK");

       base.ClickByJavaScriptExecutor(Gradebook);


       logger.LogMethodEntry("eCollegeIntegration", "eCollegeGradebook",
            base.IsTakeScreenShotDuringEntryExit);
   }


   //Then I should see grade synch for student "ECollegeStudent"
   [Then(@"I should see grade synch for student ""(.*)""")]
   public void GradeSynchForStudent(User.UserTypeEnum userName)
   {
       logger.LogMethodEntry("eCollegeIntegration", "GradeSynchForStudent",
               base.IsTakeScreenShotDuringEntryExit);

       base.SwitchToDefaultPageContent();

       base.IsElementDisplayedById("Main");

       base.IsElementPresent(By.Id("Main"));

       base.SwitchToIFrameById("Main");

       base.WaitForElementDisplayedInUi(By.Id("Content"));

       base.IsElementDisplayedById("Content");

       base.IsElementPresent(By.Id("Content"));

       base.SwitchToIFrameById("Content");

       //base.IsElementDisplayedById("Content");

       //base.IsElementPresent(By.Id("Content"));

       //base.SwitchToIFrameById("Content");

       base.WaitForElementDisplayedInUi(By.Id("mainTable"));

       base.IsElementDisplayedById("mainTable");

       base.IsElementPresent(By.Id("mainTable"));


       IWebElement mainTable = base.GetWebElementPropertiesById("mainTable");

       IWebElement mainTableNav = mainTable.FindElement(By.CssSelector("tbody>tr>td>table"));

       IWebElement actualEle = mainTableNav.FindElement(By.CssSelector("tbody>tr>td>a"));

       string studentName = actualEle.Text;

       User user = User.Get(userName);
       string fullName = string.Format(user.FirstName + "," + user.LastName);

       IWebElement Sco = mainTableNav.FindElement(By.CssSelector("tbody>tr>td:nth-child(2)>a"));

       string actualScore = Sco.Text;
       if(actualScore=="8/100")
       logger.LogAssertion("verifyStudentExist",
  ScenarioContext.Current.ScenarioInfo.
       Title, () => Assert.AreEqual(fullName, studentName));

       logger.LogMethodEntry("eCollegeIntegration", "GradeSynchForStudent",
              base.IsTakeScreenShotDuringEntryExit);
   }




//resuable function to be moved to page object
//finds the student name for the row given and returns status as true or false
        public bool StudentExist(int rowNumber, string userName)
        {

            bool studentfound = false;
            IWebElement c,d;
            string studentIdentity="";
           
            base.SwitchToDefaultPageContent();

            base.WaitForElement(By.Id("srcGBFrame"), 20);
           base.SwitchToIFrameById("srcGBFrame");

           base.WaitForElement(By.CssSelector("#GBGridLeftDataTableHolder"),20);
          
           IWebElement studentTable=base.GetWebElementPropertiesById("GBGridLeftTableHolder");

            if (rowNumber % 2 == 0)
               {
                   c = studentTable.FindElement(By.CssSelector(string.Format("tr.odd:nth-child({0})", rowNumber)));
                }
             
               else
               {
                   c = studentTable.FindElement(By.CssSelector(string.Format("tr.odd:nth-child({0})", rowNumber)));
                   
               }
             
               d = c.FindElement(By.Id("tdusername"));
               studentIdentity = d.GetAttribute("title");

            if (studentIdentity==userName)
                studentfound=true;

            return studentfound;
        }
    }

}
