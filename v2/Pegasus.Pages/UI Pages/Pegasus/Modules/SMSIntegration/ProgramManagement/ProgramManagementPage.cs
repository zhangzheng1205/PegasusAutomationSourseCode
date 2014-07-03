using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the Program Management Page Actions
    /// </summary>
    public class ProgramManagementPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ProgramManagementPage));

        /// <summary>
        /// Clicks on the Create New Program link.
        /// </summary>
        public void ClickOnCreateNewProgramLink()
        {
            //Click on Create New Program Link
            logger.LogMethodEntry("ProgramManagementPage", "ClickOnCreateNewProgramLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.SelectWindow(ProgramManagementPageResource.
                    ProgramManagement_Page_Window_Title_Locator);
                //Wait For Element
                base.WaitForElement(By.Id(ProgramManagementPageResource.
                    ProgramManagement_Page_Frame_Id_Locator));
                //Switch To Window
                base.SwitchToIFrame(ProgramManagementPageResource.
                    ProgramManagement_Page_Frame_Id_Locator);
                base.WaitForElement(By.Id(ProgramManagementPageResource.
                     ProgramManagement_Page_CreateNewProgram_Id_Locator));
                //Get HTML Element Property
                IWebElement manageProgram = base.GetWebElementPropertiesById
                    (ProgramManagementPageResource.
                    ProgramManagement_Page_CreateNewProgram_Id_Locator);
                base.ClickByJavaScriptExecutor(manageProgram);                
                //Switch To Parent Window
                base.SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProgramManagementPage", "ClickOnCreateNewProgramLink",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
