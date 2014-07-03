using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Coursesettings
{
    public class GeneralPreferencesPage : BasePage
    {

        //Purpose: to select Standards and Skills tab in preferences
        public void SelectSkillsAndStandards()
        {
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            WebDriver.FindElement(By.Id("atdContnet25")).Click();
        }

        //Purpose: to select Activities tab in preferences
        public void SelectActivities()
        {
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            WebDriver.FindElement(By.Id("atdContnet5")).Click();
        }

    }
}
