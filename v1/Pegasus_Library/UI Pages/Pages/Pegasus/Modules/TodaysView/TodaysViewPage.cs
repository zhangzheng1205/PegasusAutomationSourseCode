using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TodaysView
{
    public class TodaysViewPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        // Purpose : To Verify New Grades Alert on Todays's View Page
        public void VerifyNewGradesAlert()
        {
            string newGradeAlert = null;
            GenericHelper.WaitUntilElement(By.PartialLinkText("New Grades"));
            if (Browser.Equals("FF") || Browser.Equals("GC"))
            {
                newGradeAlert = WebDriver.FindElement(By.PartialLinkText("New Grades")).Text;
            }
            if (Browser.Equals("IE"))
            {
                newGradeAlert = WebDriver.FindElement(By.PartialLinkText("New Grades")).GetAttribute("innerText");
            }
            if (newGradeAlert != null)
            {
                string[] newGradeSplit = newGradeAlert.Split(')');
                string alertvalue = newGradeSplit[0].Substring(12);
                int newGradecount = Convert.ToInt32(alertvalue);
                if (newGradecount > 0)
                {
                    GenericHelper.Logs("New grades alert displayed at today's view page.", "PASSED");
                }
                else
                {
                    GenericHelper.Logs("New grades alert not displayed at today's view page.", "FAILED");
                    throw new NoSuchElementException("New grades alert not displayed at today's view page.");
                }
            }
        }

        //Purpose: To navigate to the Grades Tab as Student role
        public void NavigateToGradesTab()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("ancMore"));
                WebDriver.FindElement(By.Id("ancMore")).Click();
                GenericHelper.WaitUntilElement(By.PartialLinkText("Grades"));
                WebDriver.FindElement(By.PartialLinkText("Grades")).Click();
                if (!Browser.Equals("GC"))
                {
                    WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(120));
                }
                if (Browser.Equals("GC"))
                {
                    Thread.Sleep(3000);
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Selecting Practice Tab
        public void SelectPracticeTab()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.PartialLinkText("Practice"));
                WebDriver.FindElement(By.PartialLinkText("Practice")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Select New Grades
        public void ClickNewGradesLink()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.PartialLinkText("New Grades"));
                WebDriver.FindElement(By.PartialLinkText("New Grades")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Thread.Sleep(1000);
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Click on Home Button
        public void ClickHomeButton()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                Thread.Sleep(1000);
                GenericHelper.WaitUntilElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton"));
                WebDriver.FindElement(By.Id("_ctl0:_ctl0:phHeader:ucs_Header:Backbutton")).Click();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("_ctl7:GHPMenuBarUC:btnAddChannels"));
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Select Past Due: Not Submitted
        public void ClickPastDueNotSubmittedLink()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.PartialLinkText("Past Due: Not Submitted"));
                WebDriver.FindElement(By.PartialLinkText("Past Due: Not Submitted")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Select Past Due: Submitted
        public void ClickPastDueSubmittedLink()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.PartialLinkText("Past Due: Submitted"));
                WebDriver.FindElement(By.PartialLinkText("Past Due: Submitted")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        public bool IsPreTestPresent()
        {
            GenericHelper.WaitUntilElement(By.XPath("//div[@id='check']/table"));
           int countRow = WebDriver.FindElements(By.XPath("//div[@id='check']/table/tbody/tr/td/table")).Count;
           bool prestestpresent = false;
            string pretest = string.Empty;

            for (int i = 1; i<=countRow; i++)
            {
                pretest=WebDriver.FindElement(By.XPath("//div[@id='check']/table/tbody/tr/td/table")).GetAttribute("innerText");
                if(pretest.Contains("Pre Test"))
                {
                    prestestpresent = true;
                }
                else
                {
                    prestestpresent = false;
                }

            }
            return prestestpresent;
        }

        public bool IsPostTestPresent()
        {
            GenericHelper.WaitUntilElement(By.XPath("//div[@id='check']/table"));
            int countRow = WebDriver.FindElements(By.XPath("//div[@id='check']/table/tbody/tr/td/table")).Count;
            bool prestestpresent = false;
            string pretest = string.Empty;

            for (int i = 1; i <= countRow; i++)
            {
                pretest = WebDriver.FindElement(By.XPath("//div[@id='check']/table/tbody/tr/td/table[2]")).GetAttribute("innerText");
                if (pretest.Contains("Post Test"))
                {
                    prestestpresent = true;
                }
                else
                {
                    prestestpresent = false;
                }

         
            }
            return prestestpresent;
        }

        public void ClickExpandImage()
        {
            GenericHelper.WaitUntilElement(
                By.Id("_ctl0__ctl0_phBody_PageContent__ctl0__ctl2__ctl0__ctl1__ctl0__ctl3_tvPastDueSubmissionn0"));
            WebDriver.FindElement(
                By.Id("_ctl0__ctl0_phBody_PageContent__ctl0__ctl2__ctl0__ctl1__ctl0__ctl3_tvPastDueSubmissionn0")).Click();

        }


        public bool IsPastDueSubmittedPreTestPostTestPresent()
        {
            GenericHelper.WaitUntilElement(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0__ctl2__ctl0__ctl1__ctl0__ctl3_tvPastDueSubmissionn0Nodes']"));
           // int countRow = WebDriver.FindElements(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0__ctl2__ctl0__ctl1__ctl0__ctl3_tvPastDueSubmissionn0Nodes']")).Count;
            bool prestestpresent = false;
            string pretest = string.Empty;

            //for (int i = 1; i <= countRow; i++)
            //{
            pretest = WebDriver.FindElement(By.XPath("//div[@id='_ctl0__ctl0_phBody_PageContent__ctl0__ctl2__ctl0__ctl1__ctl0__ctl3_tvPastDueSubmissionn0Nodes']")).GetAttribute("innerText");
                if (pretest.Contains("Pre Test") && pretest.Contains("Post Test"))
                {
                    prestestpresent = true;
                }
                else
                {
                    prestestpresent = false;
                }

          //  }
            return prestestpresent;
        }

        /// <summary>
        /// This method is for verification of assignment property by student
        /// </summary>
        public void VerifyAssignmentPropertiesByStudent()
        {
            GenericHelper.SelectWindow("Course Materials");
            WebDriver.SwitchTo().Frame("ifrmCoursePreview");
            GenericHelper.WaitUntilElement(By.PartialLinkText("Capítulo Preliminar 0A: Para empezar"));
            WebDriver.FindElement(By.PartialLinkText("Capítulo Preliminar 0A: Para empezar")).Click();
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.SelectWindow("Course Materials");
            WebDriver.SwitchTo().Frame("ifrmCoursePreview");
            GenericHelper.WaitUntilElement(By.PartialLinkText("READINESS CHECK"));
            WebDriver.FindElement(By.PartialLinkText("READINESS CHECK")).Click();
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.SelectWindow("Course Materials");
            WebDriver.SwitchTo().Frame("ifrmCoursePreview");
            GenericHelper.WaitUntilElement(By.PartialLinkText("Readiness Check ChPA"));
            WebDriver.FindElement(By.PartialLinkText("Readiness Check ChPA")).Click();
            GenericHelper.WaitUtilWindow("Open Study Plan");
            GenericHelper.SelectWindow("Open Study Plan");
            GenericHelper.WaitUntilElement(
                By.XPath(
                    "//a[@id='_ctl0:_ctl0:phBody:PageContent:FrmDRTTestsPanel1:btnimg']"));
            bool isBeginButtonShown = GenericHelper.IsElementPresent(By.XPath(
                "//a[@id='_ctl0:_ctl0:phBody:PageContent:FrmDRTTestsPanel1:btnimg']"));
            if (isBeginButtonShown)
            {
                GenericHelper.Logs("The Begin button should be displayed for the pre-test after the start date and time have passed","Passed");
            }
            else
            {
                GenericHelper.Logs("The Begin button is not displaying for student in pretest", "Failed");
            }
        }
        
    }
}
