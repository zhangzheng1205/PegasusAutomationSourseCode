using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Pegasus_Library.Code_Base;
using OpenQA.Selenium;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.QuestionLibrary
{
    public class TrueFalsePage : BasePage 
    {
        
        /// Purpose : To Create TrueFalse question 
        
        public string CreateTrueFalseQuestion()
        {
            try
            {
            string questionName = GenericHelper.GenerateUniqueVariable("TF");
            GenericHelper.WaitUtilWindow("Create True/False");
            GenericHelper.SelectWindow("Create True/False");
            WebDriver.FindElement(By.Id("_ctl1_txtQuestionLabel")).SendKeys(questionName);
            WebDriver.SwitchTo().Frame("_ctl1_ifrmEditor_A");
            WebDriver.FindElement(By.Id("viewsource")).Click();
            WebDriver.FindElement(By.Id("ucEditorA_textarea")).SendKeys("TF");
            GenericHelper.SelectWindow("Create True/False");
            WebDriver.FindElement(By.Id("imgReturnh")).Click();
                Thread.Sleep(4000);
            GenericHelper.IsPopUpClosed(2);
                GenericHelper.SelectDefaultWindow();
            if (GenericHelper.VerifySuccesfullMessage("Question created successfully."))
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

        public string CreateTrueFalseQuestionForPostTest()
        {
            try
            {
                string questionName = GenericHelper.GenerateUniqueVariable("TF");
                GenericHelper.WaitUtilWindow("Create True/False");
                GenericHelper.SelectWindow("Create True/False");
                WebDriver.FindElement(By.Id("_ctl1_txtQuestionLabel")).SendKeys(questionName);
                WebDriver.SwitchTo().Frame("_ctl1_ifrmEditor_A");
                WebDriver.FindElement(By.Id("viewsource")).Click();
                WebDriver.FindElement(By.Id("ucEditorA_textarea")).SendKeys("TF");
                GenericHelper.SelectWindow("Create True/False");
                WebDriver.FindElement(By.Id("imgReturnh")).Click();
                
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
    }
}
