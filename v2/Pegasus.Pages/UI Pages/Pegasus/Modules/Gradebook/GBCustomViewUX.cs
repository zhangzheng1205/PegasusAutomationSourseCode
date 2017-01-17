using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using Pegasus.Pages.UI_Pages;
using Pegasus.Automation.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus GBCustomViewUX Page Actions
    /// </summary>
    public class GBCustomViewUX : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(GBCustomViewUX));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expectedOption"></param>
        /// <param name="userTypeEnum"></param>
        /// <returns></returns>
        public String GetCustomViewTabDisplayItems(string expectedOption, User.UserTypeEnum userTypeEnum)
        {
            String optionDisplayText = String.Empty;
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.CsSmsInstructor:
                    break;

                case User.UserTypeEnum.CsSmsStudent:
                    switch (expectedOption)
                    {
                        case "Custom View":
                            //Wait for the sub menu element to be loaded
                            base.WaitForElement(By.Id(
                                "_ctl0__ctl0_phHeader__ctl0_ucs_Toolbar_subMenuText"));
                            optionDisplayText = base.GetElementInnerTextById(
                                "_ctl0__ctl0_phHeader__ctl0_ucs_Toolbar_subMenuText");
                            break;

                        case "Activity":
                        case "Grade":
                            base.WaitForElement(By.PartialLinkText(expectedOption));
                            optionDisplayText = base.GetElementTextByPartialLinkText(expectedOption);
                            break;
                    }
                    break;
            }
            return optionDisplayText;
        }

        public string GetActivitySavedInCustomView(String activityName,
            User.UserTypeEnum userTypeEnum)
        {
            String actualActivityName = String.Empty;
            switch (userTypeEnum)
            {
                case User.UserTypeEnum.CsSmsInstructor:
                    break;

                case User.UserTypeEnum.CsSmsStudent:
                   actualActivityName = this.GetStudentCustomViewActivityName(activityName);
                    break;
            }
            return actualActivityName;
        }

        private string GetStudentCustomViewActivityName(String activityName)
        {
            String activityNameInCustomView = String.Empty;
            base.SwitchToActivePageElement();
            bool hgp = base.IsElementPresent(By.Id("GridStudent$divRoot"), 10);
            
            bool hg = base.IsElementPresent(By.XPath("//div[@id='GridStudent$divRoot']/div[2]/table/tbody/tr/td/table/tbody/tr"), 10);
            base.WaitForElement(By.XPath("//table[@id='GridStudent']/tbody/tr"));
            int getActivityCount = base.GetElementCountByXPath("//table[@id='GridStudent']/tbody/tr");
            for(int i=1; i<=getActivityCount;i++)
            {
                base.WaitForElement(By.XPath("//table[@id='GridStudent']/tbody/tr[{0}]/td[2]/span/span/a"), i);
                activityNameInCustomView = base.GetElementTextById(string.Format("//table[@id='GridStudent']/tbody/tr[{0}]/td[2]/span/span/a", i));
                if (activityNameInCustomView == activityName)
                {
                    break; 
                }               
            }
            return activityNameInCustomView;
        }

    }
}
