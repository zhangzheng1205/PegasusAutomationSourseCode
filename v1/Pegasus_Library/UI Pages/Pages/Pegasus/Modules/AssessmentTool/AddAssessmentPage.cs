using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pegasus_Library.Code_Base;
using OpenQA.Selenium;
using Pegasus_Library.Library;
using System.Threading;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool
{
    public class AddAssessmentPage: BasePage 
    {
        //Purpose: to enter activity name
        public void EnterActivityName(string actName)
        {
            try 
            {
            GenericHelper.WaitUntilElement(By.Id("txtAssname"));
            WebDriver.FindElement(By.Id("txtAssname")).SendKeys(actName);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose :To Select Random Activity
        public void SelectRandomActivity()
        {
            try 
            {
            WebDriver.FindElement(By.Id("radRandom")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose :To click SaveAndContinue
        public void ClickSaveAndContinue()
        {
            try 
            {
            WebDriver.FindElement(By.Id("cmdTabAssessmentNext")).Click();
            Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
