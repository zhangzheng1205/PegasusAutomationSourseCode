using System;
using System.Configuration;
using System.Threading;
using Framework.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_DataAccess;
using Pegasus_DataAccess.Database_Support;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference
{
    public class SharedLibraryPreferencePage : BasePage
    {
        //To Select Shared Library Subtab
        public void ToSelectSharedLibrarySubtab()
        {
            GenericHelper.SelectWindow("Preferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.Id("atdContnet23"));
            IWebElement pageContentifrmPreferences = WebDriver.FindElement(By.Id("atdContnet23"));
            new Actions(WebDriver).Click(pageContentifrmPreferences).Perform();
            WebDriver.SwitchTo().DefaultContent();
        }

        // Method to set SharedLibrary Preference

        public void ToSetSharedLibrary()
        {
            GenericHelper.SelectWindow("Preferences");
            WebDriver.SwitchTo().ActiveElement();
            // Purpose: Fetching Course Type: Master Library from DB           
            string libraryName = DatabaseTools.GetEnabledCourse(Enumerations.CourseType.AuthoredMasterLibrary);
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            bool isFrameDisplyed = GenericHelper.IsElementPresent(By.Id("_ctl0_ContentHolderArea_txtSCLCourse"));
            if (!isFrameDisplyed)
            {
                GenericHelper.SelectWindow("Preferences");
                GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
                WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
                GenericHelper.WaitUntilElement(By.Id("atdContnet23"));
                IWebElement pageContentifrmPreferences = WebDriver.FindElement(By.Id("atdContnet23"));
                new Actions(WebDriver).Click(pageContentifrmPreferences).Perform();
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
                WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            }
            if (WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_txtSCLCourse")).Displayed)
            {
                WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_txtSCLCourse")).SendKeys(libraryName);
                GenericHelper.WaitUntilElement(By.Id("_ctl0:ContentHolderArea:btnSearch"));
                IWebElement txtSCLCourse = WebDriver.FindElement(By.Id("_ctl0:ContentHolderArea:btnSearch"));
                new Actions(WebDriver).Click(txtSCLCourse).Perform();
                Thread.Sleep(3000);
                GenericHelper.WaitUntilElement(By.Id("leftSCLFrame"));
                WebDriver.SwitchTo().Frame("leftSCLFrame");
                // Purpose: Verify Approved Master Library Displayed or Not
                GenericHelper.WaitUntilElement(By.Id("grdSCLCourse$divContent"));
                string leftFrameText = WebDriver.FindElement(By.Id("grdSCLCourse$divContent")).Text;
                if (leftFrameText.Contains("There are no courses"))
                {
                    GenericHelper.Logs("Courses are not displayed in left frame", "Failed");
                    throw new Exception("Courses are not displayed in left frame");
                }
                else
                {
                    GenericHelper.Logs("Courses are displayed in left frame to associate in the CCourse", "PASSED");
                }
                GenericHelper.WaitUntilElement(By.Id("grdSCLCourse$_ctrl1"));
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
                WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
                WebDriver.SwitchTo().Frame("rightSCLFrame");
                bool toverifytheName = WebDriver.FindElement(By.Id("grdSCLCourse$contentCntr")).Text.Contains(libraryName);
                if (toverifytheName)
                {
                    GenericHelper.Logs("Shared Library is already added", "Passed");
                    WebDriver.SwitchTo().DefaultContent();
                    WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
                    GenericHelper.WaitUntilElement(By.Id("_ctl0_ContentHolderHeader_lbtnSavePrefHeader"));
                    IWebElement lbtnSavePrefHeader = WebDriver.FindElement(By.Id("_ctl0_ContentHolderHeader_lbtnSavePrefHeader"));
                    new Actions(WebDriver).Click(lbtnSavePrefHeader).Perform();
                }
                else
                {
                    WebDriver.SwitchTo().DefaultContent();
                    GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
                    WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
                    WebDriver.SwitchTo().Frame("leftSCLFrame");
                    GenericHelper.WaitUntilElement(By.Id("grdSCLCourse$_ctrl1"));
                    IWebElement phBodyPageContent = WebDriver.FindElement(By.Id("grdSCLCourse$_ctrl1"));
                    new Actions(WebDriver).Click(phBodyPageContent).Perform();
                    WebDriver.SwitchTo().DefaultContent();
                    GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
                    WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
                    GenericHelper.WaitUntilElement(By.Id("btnSCLEnroll"));
                    IWebElement btnSCLEnroll = WebDriver.FindElement(By.Id("btnSCLEnroll"));
                    new Actions(WebDriver).Click(btnSCLEnroll).Perform();
                    GenericHelper.Logs("Shared Library is successfully added to the right frame", "Passed");
                    WebDriver.SwitchTo().DefaultContent();
                    GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
                    WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
                    GenericHelper.WaitUntilElement(By.Id("_ctl0_ContentHolderHeader_lbtnSavePrefHeader"));
                    IWebElement lbtnSavePrefHeader = WebDriver.FindElement(By.Id("_ctl0_ContentHolderHeader_lbtnSavePrefHeader"));
                    new Actions(WebDriver).Click(lbtnSavePrefHeader).Perform();
                }
            }
        }
    }
}

