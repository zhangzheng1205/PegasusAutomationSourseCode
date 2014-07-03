using System;
using System.Configuration;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Activity
{
    public class MultipleChoicePage : BasePage
    {
        // Calling of other classes

        private string _strConnection =
            ConfigurationManager.ConnectionStrings["Pegasus_SpecFlow.Properties.Settings.BDD_DBConnectionString"].
                ConnectionString;

        // method to fill the details for multiple choice questions
        public void ToFillTheDetailsForMultiple()
        {
            try
            {
                
                GenericHelper.SelectWindow("Create Multiple Choice");
                GenericHelper.WaitUntilElement(By.Id("_ctl1_txtQuestionLabel"));
                string questionName = GenericHelper.GenerateUniqueVariable("Multiple_Choice");
                DatabaseTools.UpdateQuestions(Enumerations.QuestionType.MultipleChoice, questionName);
                WebDriver.FindElement(By.Id("_ctl1_txtQuestionLabel")).SendKeys(questionName);
                WebDriver.SwitchTo().Frame("_ctl1_ifrmEditor_A");
                GenericHelper.WaitUntilElement(By.Id("viewsource"));
                WebDriver.FindElement(By.Id("viewsource")).Click();
                GenericHelper.WaitUntilElement(By.Id("ucEditorA_textarea"));
                WebDriver.FindElement(By.Id("ucEditorA_textarea")).SendKeys("Which is the best framework for automation testing");
               
                GenericHelper.WaitUntilElement(By.Id("viewsource"));
                WebDriver.FindElement(By.Id("viewsource")).Click();
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.WaitUntilElement(By.Id("spnAnswer"));
                WebDriver.FindElement(By.Id("spnAnswer")).Click();
                
                GenericHelper.WaitUntilElement(By.Id("_ctl1_dgdChoices__ctl2_txtChoice"));
                WebDriver.FindElement(By.Id("_ctl1_dgdChoices__ctl2_txtChoice")).SendKeys("BDD");
                WebDriver.FindElement(By.Id("_ctl1_dgdChoices__ctl3_txtChoice")).SendKeys("TDD");
                WebDriver.FindElement(By.Id("_ctl1_dgdChoices__ctl4_txtChoice")).SendKeys("ATDD");
                WebDriver.FindElement(By.Id("_ctl1_dgdChoices__ctl5_txtChoice")).SendKeys("New One");
                WebDriver.SwitchTo().DefaultContent();
                WebDriver.FindElement(By.Id("imgReturnf")).Click();
                //GenericHelper.IsPopUpClosed("Create Multiple Choice");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
            }
        }
    }
}
