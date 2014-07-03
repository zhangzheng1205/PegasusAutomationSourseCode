using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.AssessmentTool.Presentation
{
    public class ErrorMessagePage : BasePage 
    {
        //Constant Declaration
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        public bool VerifyErrorMessage()
        {
            GenericHelper.WaitUtilWindow("Test Presentation");
            GenericHelper.SelectWindow("Test Presentation");
            string errorMsg=string.Empty;

            if(Browser.Equals("IE"))
            {
                errorMsg = WebDriver.FindElement(By.Id("lblErrorMessage")).GetAttribute("innerText");
            }

            if (Browser.Equals("GC") || Browser.Equals("FF"))
            {
               errorMsg= WebDriver.FindElement(By.Id("lblErrorMessage")).Text;
            }


            if(errorMsg=="There are no more attempts available for this activity.")
            {
                return true;  
            }
            else
            {
                return false;
            }
            

        }
    }
}
