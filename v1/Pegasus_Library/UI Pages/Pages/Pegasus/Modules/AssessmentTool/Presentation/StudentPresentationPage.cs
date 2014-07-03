using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;


namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool.Presentation
{
    public class StudentPresentationPage : BasePage 
    {

        public void SubmitActivity()
        {
            GenericHelper.WaitUntilElement(By.Id("_ctl0:btnMasterFinish"));
            WebDriver.FindElement(By.Id("_ctl0:btnMasterFinish")).Click();
            GenericHelper.WaitUntilElement(By.Id("_ctl0:APH:btnfinish"));
            WebDriver.FindElement(By.Id("_ctl0:APH:btnfinish")).Click();
        }

        public bool VerifyPastDueMsg()
        {
            bool pastDueMsg = false;
            GenericHelper.WaitUntilElement(By.Id("_ctl0_lateSubText"));
             string msg=WebDriver.FindElement(By.Id("_ctl0_lateSubText")).GetAttribute("innerText");
             if (msg.Contains("This activity is past due."))
             {
                 pastDueMsg = true;
             }
             else
             {
                 pastDueMsg = false;
             }
            return pastDueMsg;
        }

        public  void AnswerTrue()
        {
            WebDriver.FindElement(By.XPath("//input[contains(@id,'radio_T')]")).Click();
        }

        public void AnswerFalse()
        {
            WebDriver.FindElement(By.XPath("//input[contains(@id,'radio_F')]")).Click();
        }
    }
}
