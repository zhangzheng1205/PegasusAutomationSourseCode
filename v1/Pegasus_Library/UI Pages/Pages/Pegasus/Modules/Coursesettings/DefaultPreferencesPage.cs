using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Coursesettings
{
    public class DefaultPreferencesPage:BasePage
    {
        ///Purpose : To Set Question Count
        public void SetQuestionCount(string count)
        {
            try 
            {
            WebDriver.FindElement(By.Id("txtDisplayPerPage")).Clear();
            WebDriver.FindElement(By.Id("txtDisplayPerPage")).SendKeys(count);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        ///Purpose : To Set Attempts
        public void SetAttempts(string attempt)
        {
            try 
            {
            WebDriver.FindElement(By.Id("txtAllowAttempts")).Clear();
            WebDriver.FindElement(By.Id("txtAllowAttempts")).SendKeys(attempt);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        /// Purpose: To Select MSL100 Style Sheet
        public void SelectMsl100StyleSheet()
        {
            try
            {
            WebDriver.FindElement(By.Id("listDefaultStyle")).SendKeys("");
            new SelectElement(WebDriver.FindElement(By.Id("listDefaultStyle"))).SelectByText("MSL100");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        /// Purpose: To click Timing link
        public void SelectTiming()
        {
            try 
            {
            WebDriver.FindElement(By.Id("RptToolItems__ctl2_lnk")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

       ///Purpose : To Select ActivityLevel Radio Button under preferences 
        public void SelectActivityLevelRadioButton()
        {
            try 
            {
            GenericHelper.WaitUntilElement(By.Id("rdoAssessment"));
            WebDriver.FindElement(By.Id("rdoAssessment")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        ///Purpose: To Set Hours
        public void SetHours(string hour)
        {
            try 
            {
            WebDriver.FindElement(By.Id("txtHour")).Clear();
            WebDriver.FindElement(By.Id("txtHour")).SendKeys(hour);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        /// Purpose: To click Grading link
        public void SelectGrading()
        {
            try 
            {
            WebDriver.FindElement(By.Id("RptToolItems__ctl5_lnk")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Set ThresholdScore
        public void SetThresholdScore(string score)
        {
            try
            {
            GenericHelper.WaitUntilElement(By.Id("txtThresholdScore"));
            WebDriver.FindElement(By.Id("txtThresholdScore")).Clear();
            WebDriver.FindElement(By.Id("txtThresholdScore")).SendKeys(score);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To click on apply to all
        public void ClickApplyToAll()
        {
            try 
            {
            WebDriver.FindElement(By.Id("ibtnApplyAll")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
             
        }

    }
}
