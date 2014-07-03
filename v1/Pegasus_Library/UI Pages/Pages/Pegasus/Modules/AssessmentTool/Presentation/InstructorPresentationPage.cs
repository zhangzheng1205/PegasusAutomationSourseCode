using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using Pegasus_Library.Code_Base;
using System.Threading;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
using OpenQA.Selenium;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool.Presentation
{
    public class InstructorPresentationPage : BasePage
    {
        //Purpose: Run code on the basis of Browser Selected
        private static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        //Purpose: To
        public string GetTimeDisplayValue()
        {
            try 
            {
            string time = null;
            GenericHelper.WaitUntilElement(By.Id("_ctl0_txtTimer1"));
            if (Browser.Equals("FF") || Browser.Equals("GC"))
            {
                time = WebDriver.FindElement(By.Id("_ctl0_txtTimer1")).Text;
            }
            if (Browser.Equals("IE"))
            {
                time = WebDriver.FindElement(By.Id("_ctl0_txtTimer1")).GetAttribute("innerText");
            }
            return time;
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To
        public string QuestionsDisplayedPerPage()
        {
            try 
            {
            int cnt = WebDriver.FindElements(By.XPath("//div[@id='nextQuextion']/div")).Count();
            int questionCountPerPage = 0;
            for (int i = 1; i <= cnt; i++)
            {
                bool questionDisplayed = WebDriver.FindElement(By.XPath("//div[@id='nextQuextion']/div["+i.ToString()+"]")).Displayed;
                if(questionDisplayed)
                {
                    questionCountPerPage++;
                }
            }
            return questionCountPerPage.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To
        public bool VerifyDefaultSheetStyle()
        {   
            try 
            {
            bool MSLSheet = GenericHelper.IsElementPresent(By.XPath("//img[contains(@src,'myspanishlab/arriba/images/left_burst.gif')]"));
            return !MSLSheet;
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }
    }
}
