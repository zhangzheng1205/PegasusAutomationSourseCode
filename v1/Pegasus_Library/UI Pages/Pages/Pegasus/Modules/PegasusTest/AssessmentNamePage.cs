using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pegasus_Library.Code_Base;
using OpenQA.Selenium;
using Pegasus_Library.Library;
using Framework.Common;
using Pegasus_DataAccess.Database_Support;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.PegasusTest
{
    public class AssessmentNamePage : BasePage
    {

        // Purpose: to create test
        public void CreateTest(string testName)
        {         
            GenericHelper.SelectWindow("Create New Test");
            WebDriver.FindElement(By.Id("txtName")).SendKeys(testName);
            WebDriver.FindElement(By.Id("btnsaveandclose")).Click();
           
        }



    }
}
