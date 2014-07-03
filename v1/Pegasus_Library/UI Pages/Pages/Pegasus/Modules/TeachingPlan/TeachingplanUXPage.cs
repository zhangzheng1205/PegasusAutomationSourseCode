using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using System.Linq;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TeachingPlan
{
    public class TeachingplanUXPage : BasePage
    {
        //Purpose : To Click AddContent Button
        public void ClickAddContentButton()
        {
            WebDriver.SwitchTo().Frame("ifrmleft");
            GenericHelper.WaitUntilElement(By.ClassName("btn_AddContent"));
            WebDriver.FindElement(By.ClassName("btn_AddContent")).Click();
        }

        //Purpose : To Select Add Skill StudyPlan option
        public void SelectAddSkillStudyPlan()
        {
            WebDriver.FindElement(By.XPath("//table[@id='tbldivMenu']/tbody/tr[13]/td[@title='Add Skill Study Plan']")).Click();
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());
        }

        //Purpose: To Check ML State for Course is being prepared and will be available soon. 
        public void WaitMLToGetInPrepareState()
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
                while (sw.Elapsed.TotalMinutes < minutesToWait)
                {
                    Thread.Sleep(10000);// This I added because to wait for a page after get refresh
                    GenericHelper.SelectWindow("Content");
                    WebDriver.SwitchTo().Frame("ifrmRight");
                    GenericHelper.WaitUntilElement(By.CssSelector("table#grdCourseContent"));
                    IWebElement iscourseIsBeingPrepareState = WebDriver.FindElement(By.CssSelector("table#grdCourseContent"));
                    if (iscourseIsBeingPrepareState.Text.Contains("Course is being") == false) break;
                    {
                        WebDriver.Navigate().Refresh();
                    }
                }
                GenericHelper.WaitUntilElement(By.CssSelector("table#grdCourseContent"));
                IWebElement iscourseIsStillBeingCopyState = WebDriver.FindElement(By.CssSelector("table#grdCourseContent"));
                if (!iscourseIsStillBeingCopyState.Text.Contains("Course is being"))
                {
                    GenericHelper.Logs(string.Format("'Master Library' successfuly validated from assigned to copy state under time interval '{0}' minutes.", sw.Elapsed.TotalMinutes), "PASSED");
                }
                else
                {
                    GenericHelper.Logs(string.Format("'Master Library' has being still in assigned to copy state till time interval '{0}' minutes.", sw.Elapsed.TotalMinutes), "PASSED");
                    throw new TimeoutException(string.Format("'Master Library' has being still in assigned to copy state till time interval '{0}' minutes.", sw.Elapsed.TotalMinutes));
                }
                GenericHelper.SelectWindow("Content");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Content"))
                {
                    GenericHelper.SelectWindow("Content");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString()); ;
            }
        }

        //Purpose: to click SubNavigationMore link
        public void ClickMoreNavigation()
        {
            GenericHelper.WaitUntilElement(By.ClassName("SubNavigationMore"));
            WebDriver.FindElement(By.ClassName("SubNavigationMore")).Click();
        }

        //Purpose: to check select all check box for activity selection
        public void CheckSelectAllCheckbox()
        {
            WebDriver.SwitchTo().Frame("ifrmleft");
            GenericHelper.WaitUntilElement(By.Id("grdContentLibrary$_ctrl0"));
            WebDriver.FindElement(By.Id("grdContentLibrary$_ctrl0")).Click();
            WebDriver.SwitchTo().Window(WebDriver.WindowHandles.First());

        }

        //Purpose: to click Add Button
        public void ClickAddButton()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.ClassName("btn_add"));
                bool isButtonAddEnabled = WebDriver.FindElement(By.ClassName("btn_add")).Enabled;
                if (isButtonAddEnabled)
                {
                    GenericHelper.Logs("'Button Add' get enabled after selecting the course in left frame.", "PASSED");
                    WebDriver.FindElement(By.ClassName("btn_add")).Click();
                }
                else
                {
                    GenericHelper.Logs("'Button Add' not enabled after selecting the course in left frame.", "FAILED");
                    throw new Exception("'Button Add' not enabled after selecting the course in left frame.");
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Content"))
                {
                    GenericHelper.SelectWindow("Content");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }
    }
}

