using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pegasus_Library.Code_Base;
using System.Threading;
using OpenQA.Selenium;
using Pegasus_Library.Library;
using Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TeachingPlan;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool
{
    public class SelectQuestionTypePage: BasePage
    {
        ContentBrowserMainUXPage _contentBrowserMainUxPage =new ContentBrowserMainUXPage();

        /// Purpose : To Select TrueFalse question type
        public void SelectTrueFalse()
        {
          try
          {
            GenericHelper.WaitUntilElement(By.Id("frmSelectQuestion"));
            WebDriver.SwitchTo().Frame("frmSelectQuestion");
            GenericHelper.WaitUntilElement(By.PartialLinkText("True/False"));
            WebDriver.FindElement(By.PartialLinkText("True/False")).Click(); 
           }
           catch (Exception e)
           {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
           }
        }

        /// Purpose : To Select TrueFalse question type For PostTest
        public void SelectTrueFalseForPostTest()
        {
            try
            {
              //  GenericHelper.WaitUntilElement(By.Id("frmSelectQuestion"));
               // WebDriver.SwitchTo().Frame("frmSelectQuestion");
                GenericHelper.WaitUntilElement(By.PartialLinkText("True/False"));
                WebDriver.FindElement(By.PartialLinkText("True/False")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        /// Purpose : To Create TrueFalse question 

        public string CreateTrueFalseQuestion()
        {
            try
            {
                string questionName = GenericHelper.GenerateUniqueVariable("TF");
                GenericHelper.WaitUntilElement(By.Id("_ctl1_txtQuestionLabel"));
                WebDriver.FindElement(By.Id("_ctl1_txtQuestionLabel")).SendKeys(questionName);
                WebDriver.SwitchTo().Frame("_ctl1_ifrmEditor_A");
                GenericHelper.WaitUntilElement(By.Id("viewsource"));
                WebDriver.FindElement(By.Id("viewsource")).Click();
                WebDriver.FindElement(By.Id("ucEditorA_textarea")).SendKeys("TF");
                GenericHelper.SelectWindow("Create New Question");
                WebDriver.SwitchTo().Frame("frmSelectQuestion");
                WebDriver.FindElement(By.Id("imgReturnh")).SendKeys("");
                WebDriver.FindElement(By.Id("imgReturnh")).Click();
                _contentBrowserMainUxPage.ClickAddAndClose();
                
                if (GenericHelper.IsPopUpClosed(2))
                {
                    return questionName;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

        //Purpose: To Click Add And Close

        public void ClickAddAndClose()
        {
            try 
            {

            GenericHelper.WaitUntilElement(By.Id("_ctl0_PopupPageContent_imgBtnAdd_Close"));
            WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_imgBtnAdd_Close")).SendKeys("");
            WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_imgBtnAdd_Close")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }

    }
}
