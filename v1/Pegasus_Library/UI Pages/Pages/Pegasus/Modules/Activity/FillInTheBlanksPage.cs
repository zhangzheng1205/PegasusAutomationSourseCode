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
    public class FillInTheBlanksPage : BasePage
    {
        // Calling of other classes

        private string _strConnection =
            ConfigurationManager.ConnectionStrings["Pegasus_SpecFlow.Properties.Settings.BDD_DBConnectionString"].
                ConnectionString;

        // method to fill the details for multiple choice questions
        public void ToCreateFillInTheBlanks()
        {
            try
            {
                

                GenericHelper.SelectWindow("Create Fill in the Blank");
                GenericHelper.WaitUntilElement(By.Id("_ctl1_txtQuestionLabel"));
                string questionName = GenericHelper.GenerateUniqueVariable("FillintheBlank");
                DatabaseTools.UpdateQuestions(Enumerations.QuestionType.FillInTheBlank, questionName);
               
                WebDriver.FindElement(By.Id("_ctl1_txtQuestionLabel")).SendKeys(questionName);
              
                GenericHelper.WaitUntilElement(By.XPath("//div[@id='cmdAddblank']/img[contains(@src,'/images/QuestionLibrary/icn_add.gif')]"));
                WebDriver.FindElement(By.XPath("//div[@id='cmdAddblank']/img[contains(@src,'/images/QuestionLibrary/icn_add.gif')]")).Click();
                GenericHelper.WaitUntilElement(By.LinkText("Add at Bottom"));
                WebDriver.FindElement(By.LinkText("Add at Bottom")).Click();
                
                GenericHelper.WaitUntilElement(By.XPath("//img[@src='../../images/QuestionLibrary/icn_add.gif']"));
                WebDriver.FindElement(By.XPath("//img[@src='../../images/QuestionLibrary/icn_add.gif']")).Click();
                GenericHelper.WaitUntilElement(By.LinkText("Add at Top"));
                WebDriver.FindElement(By.LinkText("Add at Top")).Click();
                GenericHelper.WaitUntilElement(By.Id("_ctl1_dgdChoices__ctl2_txtText"));
                WebDriver.FindElement(By.Id("_ctl1_dgdChoices__ctl2_txtText")).SendKeys("WebDriver is the father of");
                GenericHelper.WaitUntilElement(By.Id("_ctl1_dgdChoices__ctl3_txtText"));
                WebDriver.FindElement(By.Id("_ctl1_dgdChoices__ctl3_txtText")).SendKeys("Remote Control");
                
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.WaitUntilElement(By.Id("imgReturnf"));
                WebDriver.FindElement(By.Id("imgReturnf")).Click();
               // GenericHelper.IsPopUpClosed("Create Fill in the Blank");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
            }
        }
    }
}

