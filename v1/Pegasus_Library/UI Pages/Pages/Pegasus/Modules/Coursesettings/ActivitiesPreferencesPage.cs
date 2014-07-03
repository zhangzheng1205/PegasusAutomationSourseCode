using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pegasus_Library.Code_Base;
using Pegasus_Library.Library;

namespace Pegasus_Library.UI_Pages.Pages.Pegasus.Modules.Coursesettings
{
    public class ActivitiesPreferencesPage : BasePage
    {
        //Purpose :To Click Edit Link of Preferences
        public void ClickFirstPreferencesEditLink()
        {
            try 
            {
            GenericHelper.SelectDefaultWindow();
            GenericHelper.WaitUntilElement(By.Id("_ctl0__ctl0_phBody_PageContent_ifrmPreferences"));
            WebDriver.SwitchTo().Frame("_ctl0__ctl0_phBody_PageContent_ifrmPreferences");
            GenericHelper.WaitUntilElement(By.XPath("//table[@id='tblActivities']/tbody/tr/td[7]/a[@id='lnkPreferences']"));
            WebDriver.FindElement(By.XPath("//table[@id='tblActivities']/tbody/tr/td[7]/a[@id='lnkPreferences']")).SendKeys("");
            WebDriver.FindElement(By.XPath("//table[@id='tblActivities']/tbody/tr/td[7]/a[@id='lnkPreferences']")).Click();
            }
            catch (Exception e)
            {
                GenericHelper.Logs(e.ToString(), "FAILED");
                throw new Exception(e.ToString());
            }
            
        }

    }
}
