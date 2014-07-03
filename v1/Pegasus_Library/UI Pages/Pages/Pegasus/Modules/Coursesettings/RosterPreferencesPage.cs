using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;
namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Coursesettings
{
    public  class RosterPreferencesPage: BasePage
    {
        //Purpose: To Enable Roster Preserence
        public void EnableRoster()
        {
            GenericHelper.WaitUntilElement(By.PartialLinkText("Enrollments"));
            WebDriver.FindElement(By.PartialLinkText("Enrollments")).Click();
            GenericHelper.WaitUntilElement(By.PartialLinkText("Groups"));
            if (!GenericHelper.IsElementPresent(By.PartialLinkText("Roster")))
            {
                GenericHelper.WaitUntilElement(By.PartialLinkText("Preferences"));
                WebDriver.FindElement(By.PartialLinkText("Preferences")).Click();
                // Prpose: To Select Roster Preference Option
                GenericHelper.SelectWindow("Preferences");
                GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
                WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
                WebDriver.SwitchTo().ActiveElement();
                GenericHelper.WaitUntilElement(By.Id("atdContnet20"));
                IWebElement rostersubTab = WebDriver.FindElement(By.Id("atdContnet20"));
                new Actions(WebDriver).Click(rostersubTab).Perform();
                Thread.Sleep(2000);
                // Purpose: To Check Roster Checkbox
         
                GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
                WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
                WebDriver.SwitchTo().ActiveElement();
                GenericHelper.WaitUntilElement(By.Id("_ctl0_ContentHolderArea_chkRosterManager"));
                WebDriver.FindElement(By.Id("_ctl0_ContentHolderArea_chkRosterManager")).Click();
                WebDriver.SwitchTo().DefaultContent();
                GenericHelper.SelectWindow("Preferences");              
                WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
                GenericHelper.WaitUntilElement(By.Id("_ctl0_ContentHolderHeader_lbtnSavePrefHeader"));
                WebDriver.FindElement(By.Id("_ctl0_ContentHolderHeader_lbtnSavePrefHeader")).Click();
                GenericHelper.SelectDefaultWindow();
            }            
        }
    }
}
