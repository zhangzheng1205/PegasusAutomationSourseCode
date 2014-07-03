using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;


namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool
{
    public class RandomTopicListPage:BasePage
    {
        //Purpose : To Click AddQuestions
        public void ClickAddQuestions()
        {
            try
            {
                GenericHelper.WaitUntilElement(By.Id("frmTopic"));
              WebDriver.SwitchTo().Frame("frmTopic");
              GenericHelper.WaitUntilElement(By.Id("cmdadd"));
              WebDriver.FindElement(By.Id("cmdadd")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose : To Click Create New Question
        public void ClickCreateNewQuestion()
        {
            try
            {
            WebDriver.FindElement(By.XPath("//img[contains(@src,'images/TeachingPlan/icn_questionSmall.gif')]")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

    }
}
