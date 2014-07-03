using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pegasus_Library.Code_Base;
using System.Threading;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Library;
using OpenQA.Selenium;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.TeachingPlan
{
    public class CoursePreviewMainUXPage:BasePage 
    {
        //Purpose : To Open particular asset or folder
        public void OpenAsset(string assetName)
        {
            GenericHelper.SelectDefaultWindow();
            GenericHelper.WaitUntilElement(By.Id("ifrmCoursePreview"));
            WebDriver.SwitchTo().Frame("ifrmCoursePreview");
            GenericHelper.WaitUntilElement(By.PartialLinkText(assetName));
            WebDriver.FindElement(By.PartialLinkText(assetName)).Click();
            Thread.Sleep(2000);
        }
    }
}
