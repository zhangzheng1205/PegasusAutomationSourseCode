using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.eCollege;
using Pegasus.Pages.UI_Pages.Integration.eCollege.CampusAdmin;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handle header navigation.
    /// </summary>
    public class SubHeadFramePage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger.
        /// </summary>
        private static readonly Logger Logger = Logger.
            GetInstance(typeof(SubHeadFramePage));

        /// <summary>
        /// Click on Global Home Tab.
        /// </summary>
        public void ClickOnGlobalNavigationTab(String
            globalNavigationTabName)
        {
            Logger.LogMethodEntry("SubHeadFramePage", "ClickOnGlobalNavigationTab",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select to SelectAdministrationPages Window
                this.SelectAdministrationPagesWindow();
                //Switch To Frame
                this.SelectGlobalNavigationIFrame();
                //Wait For Element
                base.WaitForElement(By.PartialLinkText(globalNavigationTabName));
                //Click on manage user
                IWebElement getGlobalTabNameProperty = base.
                    GetWebElementPropertiesByPartialLinkText(globalNavigationTabName);
                //Click On Tab
                base.ClickByJavaScriptExecutor(getGlobalTabNameProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("SubHeadFramePage", "ClickOnGlobalNavigationTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click To Exit Button To Navigate From Page.
        /// </summary>
        public void ClickOnExitButton()
        {
            Logger.LogMethodEntry("SubHeadFramePage",
               "ClickOnExitButton", base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectAdministrationPagesWindow();
            //Select Frame
            this.SelectGlobalNavigationIFrame();
            //Wait for Exit Button 
            base.WaitForElement(By.PartialLinkText(SubHeadFramePageResource.
                SubHeadFrame_Page_ExitButton_PartialLinkText_Locator));
            //Click On Exit Button
            base.ClickButtonByPartialLinkText(SubHeadFramePageResource
                .SubHeadFrame_Page_ExitButton_PartialLinkText_Locator);
            Logger.LogMethodExit("SubHeadFramePage",
               "ClickOnExitButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Administration Pages Window.
        /// </summary>
        private void SelectAdministrationPagesWindow()
        {
            //Select Window
            Logger.LogMethodEntry("SubHeadFramePage",
             "SelectAdministrationPagesWindow", base.IsTakeScreenShotDuringEntryExit);
            //Wait For Window Gets Load
            base.WaitUntilWindowLoads(SubHeadFramePageResource.
                SubHeadFrame_Page_AdministrationPages_Window_Title);
            //Select Administration Pages
            base.SelectWindow(SubHeadFramePageResource.
                SubHeadFrame_Page_AdministrationPages_Window_Title);
            Logger.LogMethodExit("SubHeadFramePage",
             "SelectAdministrationPagesWindow", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Global Navigation IFrame.
        /// </summary>
        private void SelectGlobalNavigationIFrame()
        {
            //Select IFrame
            Logger.LogMethodEntry("SubHeadFramePage",
               "SelectGlobalNavigationIFrame", base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Name(SubHeadFramePageResource.
                SubHeadFrame_Page_GlobalNav_Frame_Name_Locator));
            //Switch To Frame
            base.SwitchToIFrame(SubHeadFramePageResource.
                SubHeadFrame_Page_GlobalNav_Frame_Name_Locator);
            Logger.LogMethodExit("SubHeadFramePage",
               "SelectGlobalNavigationIFrame", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
