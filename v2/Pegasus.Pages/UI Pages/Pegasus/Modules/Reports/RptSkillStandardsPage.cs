using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains functionalities related to Skills and standard report.
    /// </summary>
    class RptSkillStandardsPage : BasePage
    {

        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptStudentActivityPage));

        private void SwitchToSkillStandardPage()
        {
            base.SwitchToDefaultPageContent();
            base.SwitchToIFrameById(RptMainUXPageResource.
                        RptMainUXPage_ContainerFrame_Id_Locator);
            base.SwitchToIFrameById(RptSkillStandardsPageResource.
                RptSkillStandardsPage_SkillStandardsPage_Iframe_Id_Locator);
        }


    }
}
