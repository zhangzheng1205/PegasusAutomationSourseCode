using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pegasus_Library.Code_Base;
using OpenQA.Selenium;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.MyPrefernce
{
    public class MyAccountSettingPage: BasePage
    {

        
        public string GetMyProfileDate()
        {          
          try 
           {
            IWebElement dropdown = WebDriver.FindElement(By.Id("cmbDateFormat2"));
            SelectElement select = new SelectElement(dropdown);
            String wantedText = select.SelectedOption.Text;
              
               return wantedText;
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }


        public string GetMyProfileTime()
        {
            try
            {
                IWebElement dropdown = WebDriver.FindElement(By.Id("cmbTimeFormat2"));
                SelectElement select = new SelectElement(dropdown);
                String wantedText = select.SelectedOption.Text;

                return wantedText;
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
        }



        public void ClickCancel()
        {
            WebDriver.FindElement(By.Id("imgbtnCancel")).SendKeys("");
            WebDriver.FindElement(By.Id("imgbtnCancel")).Click();
        }

         public void SelectFrame()
         {
             GenericHelper.SelectWindow("Calendar");
             IWebElement frame = WebDriver.FindElement(By.XPath("//iframe[@src='/Pegasus/Modules/MyPrefernce/frmMyAccountSetting.aspx?mode=1']"));
             WebDriver.SwitchTo().Frame(frame);
         }
    }
}
