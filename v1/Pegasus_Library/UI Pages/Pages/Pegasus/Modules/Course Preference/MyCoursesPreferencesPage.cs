using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Course_Preference
{
    public class MyCoursesPreferencesPage : BasePage
    {
        // To select my course subtab
        public void ToCheckMyCourseSubtab()
        {
            GenericHelper.SelectWindow("Preferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.Id("atdContnet18"));
            IWebElement checkMyCourseSubtab = WebDriver.FindElement(By.Id("atdContnet18"));
            new Actions(WebDriver).Click(checkMyCourseSubtab).Perform();
        }

        // Method to set my course preference
        public void ToCheckMyCourse()
        {
            GenericHelper.SelectWindow("Preferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.Id("_ctl0_ContentHolderArea_chkAutomaticEnrollment"));
            if (!WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkAutomaticEnrollment")).Selected)
            {
                IWebElement chkAutomaticEnrollment = WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkAutomaticEnrollment"));
                new Actions(WebDriver).Click(chkAutomaticEnrollment).Perform();
            }
            if (!WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkGroupCreation")).Selected)
            {
                GenericHelper.WaitUntilElement(By.Id("_ctl0_ContentHolderArea_chkGroupCreation"));
                IWebElement chkGroupCreation = WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkGroupCreation"));
                new Actions(WebDriver).Click(chkGroupCreation).Perform();
            }
            WebDriver.SwitchTo().DefaultContent();
            new CourseCopyPreferencesPage().ToSelectSaveButton();
        }
    }
}


