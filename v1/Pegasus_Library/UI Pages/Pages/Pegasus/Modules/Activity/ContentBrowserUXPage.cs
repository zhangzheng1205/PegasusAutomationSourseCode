using System;
using System.Net.Mime;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Activity
{
    public class ContentBrowserUXPage : BasePage
    {
        //Purpose : Add Question through browse repository
        public void ImportThroughBrowseRepository()
        {
            GenericHelper.SelectWindow("Select Questions");
            WebDriver.SwitchTo().ActiveElement();
            IWebElement isTextPresent = WebDriver.FindElement(By.TagName("body"));
            if (isTextPresent.Text.Contains("There are no items."))
            {
                GenericHelper.Logs("SCO questions folder is not present in the repository.", "Failed");
            }
            WebDriver.SwitchTo().Frame("_ctl0_PopupPageContent_ifrmLeft");
            WebDriver.FindElement(By.XPath("//img[contains(@src,'/Pegasus/images/spacer.gif')]")).Click();
            Thread.Sleep(2000);
            GenericHelper.SelectWindow("Select Questions");
            WebDriver.SwitchTo().Frame("_ctl0_PopupPageContent_ifrmLeft");
            bool isFolderPresent = WebDriver.FindElement(By.ClassName("ScoRowItemStyle")).Text.Equals("Folder");
            if (isFolderPresent)
            {
                GenericHelper.Logs("SCO Folder is present in the repository", "Passed");
            }
            try
            {
                while (isFolderPresent == true)
                {
                    GenericHelper.SelectWindow("Select Questions");
                    WebDriver.SwitchTo().Frame("_ctl0_PopupPageContent_ifrmLeft");
                    WebDriver.FindElement(By.XPath("//img[contains(@src,'/Pegasus/images/spacer.gif')]")).Click();
                    if (WebDriver.FindElement(By.ClassName("ScoRowItemStyle")).Text.Equals("SCO"))
                    {
                        break;
                    }
                }
                GenericHelper.SelectWindow("Select Questions");
                WebDriver.SwitchTo().Frame("_ctl0_PopupPageContent_ifrmLeft");
                IWebElement isTextPresentforSCO = WebDriver.FindElement(By.TagName("body"));
                if (isTextPresentforSCO.Text.Contains("There are no items."))
                {
                    GenericHelper.Logs("SCO questions are not oresent in the repository.", "FAILED");
                }
                string questionName = WebDriver.FindElement(By.Id("tblID_0")).Text.Trim();
                DatabaseTools.UpdateQuestions(Enumerations.QuestionType.SCO, questionName);
                WebDriver.FindElement(By.Id("grdContentBrowser$_ctrl1")).Click();
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.WaitUntilElement(By.Id("_ctl0_PopupPageContent_imgBtnAdd_Close"));
                WebDriver.FindElement(By.Id("_ctl0_PopupPageContent_imgBtnAdd_Close")).Click();
             //   GenericHelper.IsPopUpClosed("Select Questions");
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "Failed");
            }
        }
    }
}



