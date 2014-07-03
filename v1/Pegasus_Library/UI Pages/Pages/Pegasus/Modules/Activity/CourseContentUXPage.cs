using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Activity
{
   public class CourseContentUXPage:BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];
       /// <summary>
       /// This method is for selecting the submitted activity from TA role
       /// </summary>
       public void ToSelectSubmittedActivityFromTa()
       {
           GenericHelper.SelectWindow("Course Materials");
           GenericHelper.WaitUntilElement(By.Id("ifrmRight"));
           WebDriver.SwitchTo().Frame("ifrmRight");
           GenericHelper.WaitUntilElement(By.PartialLinkText("Capítulo Preliminar 0A: Para empezar"));
           WebDriver.FindElement(By.PartialLinkText("Capítulo Preliminar 0A: Para empezar")).Click();
           GenericHelper.WaitUntilElement(By.PartialLinkText("STUDENT ACTIVITIES MANUAL"));
           WebDriver.FindElement(By.PartialLinkText("STUDENT ACTIVITIES MANUAL")).Click();
           GenericHelper.WaitUntilElement(By.PartialLinkText("SAM 0A-33 El mundo hispano."));
           WebDriver.FindElement(By.PartialLinkText("SAM 0A-33 El mundo hispano.")).SendKeys("");
           // To hover over sam activity in right frame
          IWebElement samActivityLinkText = WebDriver.FindElement(By.PartialLinkText("SAM 0A-33 El mundo hispano."));
           new Actions(WebDriver).MoveToElement(samActivityLinkText).Build().Perform();
           // Java script function to click cmenu
           //Java script to click on the cmenu
           IWebElement samActivity33ImgMenu = WebDriver.FindElement(By.XPath("//table[@id='grdCourseContent$contentCntr']/tbody/tr/td/table/tbody/tr[34]/descendant::img[@class='CC_icn_down_opt']"));
        //   IWebElement element = WebDriver.FindElement(By.CssSelector("img.CC_icn_down_opt"));
           IJavaScriptExecutor executor = (IJavaScriptExecutor)WebDriver;
           executor.ExecuteScript("arguments[0].click();", samActivity33ImgMenu);

           // To Select View submission text
           GenericHelper.WaitUntilElement(By.PartialLinkText("View Submissions"));
           WebDriver.FindElement(By.PartialLinkText("View Submissions")).Click();


       }
    }
}
