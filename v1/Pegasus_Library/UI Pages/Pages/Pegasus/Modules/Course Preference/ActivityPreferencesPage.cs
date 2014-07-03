using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference
{
    public class ActivityPreferencesPage : BasePage
    {
        // To Select copy content sub tab
        public void ToSelectActivitiesSubtab()
        {
            GenericHelper.WaitUtilWindow("Preferences");
            GenericHelper.SelectWindow("Preferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.Id("atdContnet5"));
            IWebElement contentsubTab = WebDriver.FindElement(By.Id("atdContnet5"));
            contentsubTab.Click();
        }

        // Purpose: To Verify Activity Preference Retained
        public void ToVerifyFeedbackPreference()
        {
            WebDriver.SwitchTo().DefaultContent();
            GenericHelper.SelectWindow("Preferences");
            WebDriver.SwitchTo().ActiveElement();
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.XPath("//table[@id='tblActivities']/tbody/tr[3]/td[7]/a"));
            WebDriver.FindElement((By.XPath("//table[@id='tblActivities']/tbody/tr[3]/td[7]/a"))).Click();
            GenericHelper.SelectWindow("Default preferences");
            Assert.AreEqual("Default preferences", WebDriver.Title);
            GenericHelper.WaitUntilElement(By.PartialLinkText("Feedback"));
            WebDriver.FindElement(By.PartialLinkText("Feedback")).Click();
            GenericHelper.WaitUntilElement(By.Id("rdCorrectAnsAlways"));
            if (WebDriver.FindElement(By.Id("rdCorrectAnsAlways")).Selected)
            {
                GenericHelper.Logs("The radio button for option 'Display correct answers after student submits activity' selected under Feedback preference for a particular activity type has retained in Master course. ", "Passed");
            }
            else
            {
                GenericHelper.Logs("The radio button for option 'Display correct answers after student submits activity' selected under Feedback preference for a particular activity type has not retained in Master course.", "Failed");
                Assert.Fail("The radio button for option 'Display correct answers after student submits activity' selected under Feedback preference for a particular activity type has not retained in Master course.");
            }
            WebDriver.Close();
            GenericHelper.SelectWindow("Preferences");
        }
    }
}
