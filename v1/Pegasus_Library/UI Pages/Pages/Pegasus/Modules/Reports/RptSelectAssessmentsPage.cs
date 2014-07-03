using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Reports
{
    public class RptSelectAssessmentsPage : BasePage 
    {

        public void SelectStudyPlan(string studyPlan)
        {
            try
            {
            GenericHelper.WaitUntilElement(By.Id("AssessmentGrid"));
            int rowCnt = WebDriver.FindElements(By.XPath("//table[@id='AssessmentGrid']/tbody/tr")).Count;
            string Sp = string.Empty;

            for (int i = 1; i <= rowCnt; i++)
            {
               Sp = WebDriver.FindElement(By.XPath("//table[@id='AssessmentGrid']/tbody/tr[" + i.ToString() +"]/td[2]/span")).GetAttribute("title");

                if(Sp.Contains(studyPlan))
                {
                    WebDriver.FindElement(By.XPath("//table[@id='AssessmentGrid']/tbody/tr[" + i.ToString() + "]/td/input")).Click();
                    break;
                }

            }
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }


        public void ClickAddButton()
        {
          try 
             {
             WebDriver.FindElement(By.PartialLinkText("Add")).Click();
             }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }            
        }

    }
}
