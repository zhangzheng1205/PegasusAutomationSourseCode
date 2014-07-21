using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Enrollment;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Program Admin Tool Page Actions.
    /// </summary>
    public class ProgramAdminToolPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ProgramAdminToolPage));

        /// <summary>
        /// Select the Middle frame of Page 
        /// </summary>
        public void SelectFrame()
        {
            //Select Page Content Middle Frame
            logger.LogMethodEntry("ProgramAdminToolPage", "SelectFrame",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.SelectWindow(ProgramAdminManageUsersPageResource
                    .ProgramAdminManageUsers_Page_Window_Title_Name);
                //select the Page Content Middle frame 
                base.SwitchToIFrame(ProgramAdminToolPageResource.
                    ProgramAdminTool_Page_MiddleFrame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProgramAdminToolPage", "SelectFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch To Main Frame
        /// </summary>
        private void SwitchToMainFrame()
        {
            //Switch To Main Frame
            logger.LogMethodEntry("ProgramAdminToolPage", "SwitchToMainFrame",
               base.isTakeScreenShotDuringEntryExit);
            //Select frame
            base.WaitForElement(By.Id(ProgramAdminToolPageResource.
                ProgramAdminTool_Page_Main_Frame_Id_Locator));
            //Switch To Frame
            base.SwitchToIFrame(ProgramAdminToolPageResource.
                ProgramAdminTool_Page_Main_Frame_Id_Locator);
            logger.LogMethodExit("ProgramAdminToolPage", "SwitchToMainFrame",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Select Exam
        /// </summary>
        public void ClickOnSelectExam()
        {
            //Click On Select Exam
            logger.LogMethodEntry("ProgramAdminToolPage", "ClickOnSelectExam",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Frame
                this.SelectFrame();
                //Select frame
                this.SwitchToMainFrame();
                base.WaitForElement(By.Id(ProgramAdminToolPageResource.
                    ProgramAdminTool_Page_Exam_Id_Locator));
                //Get Link Property
                IWebElement getLinkProperty = base.GetWebElementPropertiesById(
                    ProgramAdminToolPageResource.ProgramAdminTool_Page_Exam_Id_Locator);
                //Click On Link
                base.ClickByJavaScriptExecutor(getLinkProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProgramAdminToolPage", "ClickOnSelectExam",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Navigate Program Admin Tabs.
        /// </summary>
        /// <param name="selectWindowName">Current Window Name.</param>
        /// <param name="selectSubNavigationTab">Select Navigation Tab Name.</param>
        public void NavigateProgramAdminTabs(string selectWindowName,
            string selectSubNavigationTab)
        {
            // select program admin sub tabs 
            logger.LogMethodEntry("ProgramAdminToolPage", "NavigateProgramAdminTabs",
               base.isTakeScreenShotDuringEntryExit);
            // wait for window
            base.WaitUntilWindowLoads(selectWindowName);
            // select window
            base.SelectWindow(selectWindowName);
            base.WaitForElement(By.Id(ProgramAdminToolPageResource.ProgramAdminTool_Page_SubNavigationTab_Id_Locator));
            // get sub tab counts
            int getSubNavigationTabCount = base.GetElementCountByXPath(ProgramAdminToolPageResource.
                ProgramAdminTool_Page_SubNavigationTab_Table_XPath_Locator);
            // click not selected expected sub tab
            for (int subNavigationTab = 2; subNavigationTab <= getSubNavigationTabCount; subNavigationTab++)
            {
                base.WaitForElement(By.XPath(string.Format(ProgramAdminToolPageResource.
                    ProgramAdminTool_Page_SubNavigationTab_TableRow_XPath_Locator, subNavigationTab)));
                // get sub tab property
                string getSubNavigationTabSelectedTabProperty = WebDriver.
                    FindElement(By.XPath(string.Format(ProgramAdminToolPageResource.
                    ProgramAdminTool_Page_SubNavigationTab_TableRow_XPath_Locator, subNavigationTab))).GetAttribute("class");
                if (getSubNavigationTabSelectedTabProperty.Trim().Equals
                    (ProgramAdminToolPageResource.ProgramAdminTool_Page_SubNavigationTab_Selected_ClassName_Value))
                {
                    IWebElement getSubNavigationTabName = null;
                    // get sub tab link property
                    getSubNavigationTabName = base.GetWebElementPropertiesByXPath
                        (string.Format(ProgramAdminToolPageResource.
                        ProgramAdminTool_Page_SubNavigationTab_Link_XPath_Locator, subNavigationTab));
                    if (getSubNavigationTabName.Text.Trim().Equals(selectSubNavigationTab))
                    {
                        break;
                    }
                    else
                    {
                        // get sub tab link property
                        getSubNavigationTabName = base.GetWebElementPropertiesByPartialLinkText(selectSubNavigationTab);
                        base.ClickByJavaScriptExecutor(getSubNavigationTabName);
                        break;
                    }
                }
            }
            logger.LogMethodExit("ProgramAdminToolPage", "NavigateProgramAdminTabs",
               base.isTakeScreenShotDuringEntryExit);

        }
    }
}
