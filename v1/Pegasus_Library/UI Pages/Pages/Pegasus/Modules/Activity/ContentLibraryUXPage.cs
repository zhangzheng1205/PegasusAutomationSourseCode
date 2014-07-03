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
    public class ContentLibraryUxPage : BasePage
    {
        //Pupose: Run code on the basis of Browser Selected
        static readonly string Browser = ConfigurationManager.AppSettings["browser"];

        //Pupose: Initiate WebDriver Capability
        public void Startup()
        {
            var cap = new DesiredCapabilities();
        }

        //Purpose: Method To Click Add Content Button
        public void ToSelectAddContent()
        {
            WebDriver.SwitchTo().DefaultContent();
            Thread.Sleep(1000);
            GenericHelper.WaitUntilElement(By.Id("frmQuestionLibrary"));
            WebDriver.SwitchTo().Frame("frmQuestionLibrary");
            GenericHelper.WaitUntilElement(By.PartialLinkText("Add Content"));
            WebDriver.FindElement(By.PartialLinkText("Add Content")).Click();
            WebDriver.SwitchTo().ActiveElement().Click();
        }

        //Purpose: Method to Select Multiple Choice()
        public void MultipleChoiceQuestion()
        {

            Thread.Sleep(1000);
            GenericHelper.WaitUntilElement(By.LinkText("Multiple Choice"));
            WebDriver.FindElement(By.LinkText("Multiple Choice")).Click();
            WebDriver.SwitchTo().DefaultContent();
        }

        //Purpose: Method to Select Fill in the blan
        public void FillIntheBlank()
        {
            Thread.Sleep(1000);
            GenericHelper.WaitUntilElement(By.LinkText("Fill in the Blank"));
            WebDriver.FindElement(By.LinkText("Fill in the Blank")).Click();
            WebDriver.SwitchTo().DefaultContent();
        }

        //Purpose: Method to Select SCO META DATA
        public void ImportScoMetaData()
        {
            Thread.Sleep(1000);
            GenericHelper.WaitUntilElement(By.XPath("//a[contains(text(),'Import SCO Metadata')]"));
            WebDriver.FindElement(By.XPath("//a[contains(text(),'Import SCO Metadata')]")).Click();
            WebDriver.SwitchTo().DefaultContent();
        }

        //Purpose: Method to Select Browse Repository
        public void SelectBrowseRepository()
        {

            Thread.Sleep(1000);
            GenericHelper.WaitUntilElement(By.XPath("//a[contains(text(),'Browse Repository')]"));
            WebDriver.FindElement(By.XPath("//a[contains(text(),'Browse Repository')]")).Click();
            WebDriver.SwitchTo().DefaultContent();
        }

        //Purpose: Method to select a folder type activity (benchmark for authored) in the left frame after scrolling
        public void ToSelectMathXl()
        {
            int rowNo = 2;
            WebDriver.SwitchTo().Frame("ifrmleft");
            string folderNameFromDb = DatabaseTools.GetActivityName(Enumerations.ActivityType.Folder).Trim();
            string folderNameFromFrame =
                WebDriver.FindElement(
                    By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + rowNo + "]")).Text.Trim();
            if (folderNameFromDb == folderNameFromFrame)
            {
                WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + rowNo + "]//img[contains(@src,'/Pegasus/images/spacer.gif')]")).Click();
                GenericHelper.Logs("Folder has been successfully selected", "passed");
            }
            while (folderNameFromDb != folderNameFromFrame)
            {
                rowNo = rowNo + 1;
                folderNameFromFrame = WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + rowNo + "]")).Text.Trim();
                if (folderNameFromDb == folderNameFromFrame)
                {
                    var js = WebDriver as IJavaScriptExecutor;
                    if (js != null)
                    {
                        var title = (string)js.ExecuteScript("window.scrollBy(0,200)", "");
                    }
                    IWebElement menu = WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + rowNo + "]//img[contains(@src,'/Pegasus/images/spacer.gif')]"));
                    var builder = new Actions(WebDriver);
                    builder.MoveToElement(menu).Build().Perform();
                    WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + rowNo + "]//img[contains(@src,'/Pegasus/images/spacer.gif')]")).Click();
                    GenericHelper.Logs("Folder has been successfully selected", "passed");
                }
            }

            // Below code is to select the home work type activity
            int rowNoHomework = 2;
            Thread.Sleep(4000);
            WebDriver.SwitchTo().ActiveElement();
            string homeworkName = DatabaseTools.GetActivityName(Enumerations.ActivityType.Homework).Trim();
            GenericHelper.WaitUntilElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + rowNoHomework + "]"));
            string homeworkNamefromFrame = WebDriver.FindElement(
                    By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + rowNoHomework + "]")).Text.Trim();
            if (homeworkName == homeworkNamefromFrame)
            {
                WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + rowNoHomework + "]//INPUT[@id='grdContentLibrary$_ctrl1']")).Click();
                GenericHelper.Logs("Homework Type activity has been successfully selected", "passed");
            }
            while (homeworkName != homeworkNamefromFrame)
            {
                rowNoHomework = rowNoHomework + 1;
                homeworkNamefromFrame = WebDriver.FindElement(
                    By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + rowNoHomework + "]")).Text.Trim();

                if (homeworkName == homeworkNamefromFrame)
                {
                    WebDriver.FindElement(By.XPath("//table[@id='grdContentLibrary']/tbody/tr[" + rowNoHomework + "]//INPUT[@id='grdContentLibrary$_ctrl1']")).Click();
                    GenericHelper.Logs("Homework Type activity has been successfully selected", "passed");
                }
                WebDriver.SwitchTo().DefaultContent();
            }
        }

        //Purpose : Method to Perform Show Hide Functionality 
        public void ToPerformShowHide()
        {
            WebDriver.SwitchTo().ActiveElement();
            string mlName = DatabaseTools.GetCourse(Enumerations.CourseType.MasterLibrary);
            WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_ucSearchPanel_txtSearch")).SendKeys(mlName);
            WebDriver.FindElement(By.Id("_ctl0_InnerPageContent_ucSearchPanel_cmdSearchGo")).Click();
            WebDriver.SwitchTo().ActiveElement();

            if (WebDriver.FindElement(By.XPath("//table[@id='grdCourseContent']/tbody/tr[2]")).Text.Contains("Shown"))
            {
            }
            {
                GenericHelper.Logs("Show/Hide has been clicked from the Cmenu option", "Passed");
                WebDriver.SwitchTo().DefaultContent();
                return;
            }
        }

        //Purpose - Move the ML to the right frame
        public void MoveToRightFrame()
        {
            try
            {
                GenericHelper.SelectWindow("Content");
                WebDriver.SwitchTo().Frame("ifrmLeft");
                WebDriver.SwitchTo().ActiveElement();
                GenericHelper.WaitUntilElement(By.XPath("//table[@id='grdCourseContent']/tbody/tr[2]//INPUT[@id='grdCourseContent$_ctrl1']"));
                WebDriver.FindElement(By.XPath("//table[@id='grdCourseContent']/tbody/tr[2]//INPUT[@id='grdCourseContent$_ctrl1']")).Click();
                GenericHelper.Logs("Master Library has been successfully selected under the content frame.", "passed");
                WebDriver.SwitchTo().DefaultContent();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                if (GenericHelper.IsPopUpWindowPresent("Content"))
                {
                    GenericHelper.SelectWindow("Content");
                    WebDriver.Close();
                }
                if (GenericHelper.IsPopUpWindowPresent("Overview"))
                {
                    GenericHelper.SelectWindow("Overview");
                    WebDriver.Close();
                }
                throw new Exception(e.ToString());
            }
        }

        //Purpose: Method to close the window
        public void ClosetheWindow()
        {
            WebDriver.Close();
        }
    }
}


