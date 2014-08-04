using System;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.eText;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles the Launch eText Page actions.
    /// </summary>
    public class LauncheTextPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger.
        /// </summary>
        private static readonly Logger Logger = Logger.
            GetInstance(typeof(LauncheTextPage));

        /// <summary>
        /// Get Launched eText URL.
        /// </summary>
        /// <returns>Launched eText URL.</returns>
        public String GetLaunchedeTextURL()
        {
            //Get Launched eText URL
            Logger.LogMethodEntry("LauncheTextPage", "GetLaunchedeTextURL",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            String getETextURL;
            try
            {
                //Select Window
                this.SelectPearsonETextWindow();
                //Get the URL
                getETextURL = base.GetCurrentUrl;
                string[] getSplitURL = getETextURL.Split(Convert.ToChar(LauncheTextPageResource.
                    LauncheText_Page_SpecialCharacter_Value));
                getETextURL = getSplitURL[Convert.ToInt32(LauncheTextPageResource.
                    LauncheText_Page_GetURL_Split_Value)];
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
                throw;
            }
            Logger.LogMethodExit("LauncheTextPage", "GetLaunchedeTextURL",
               base.IsTakeScreenShotDuringEntryExit);
            return getETextURL;
        }

        /// <summary>
        /// Selects EText Lauch Window.
        /// </summary>
        private void SelectPearsonETextWindow()
        {
            //Select Window
            Logger.LogMethodEntry("LauncheTextPage", "SelectPearsonETextWindow",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait for Window
            base.WaitUntilWindowLoads(LauncheTextPageResource.
                                          LauncheText_Page_Window_Name);
            //Select Window
            base.SelectWindow(LauncheTextPageResource.
                                  LauncheText_Page_Window_Name);
            Logger.LogMethodExit("LauncheTextPage", "SelectPearsonETextWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Find EText Flash element Present In The Launched Window.
        /// </summary>
        /// <returns></returns>
        public Boolean IsETextFlashElementPresent()
        {
            //Find EText Activity Present In Launch Window
            Logger.LogMethodEntry("LauncheTextPage", "IsETextFlashElementPresent",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isETextActivityPresent = false;
            try
            {
                //Wait for FLash ELement
                base.WaitForElement(By.Id(LauncheTextPageResource.
                        LauncheText_Page_Flash_Id_Locator));
                isETextActivityPresent = base.IsElementPresent(By.Id(
                    LauncheTextPageResource.
                    LauncheText_Page_Flash_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LauncheTextPage", "IsETextFlashElementPresent",
               base.IsTakeScreenShotDuringEntryExit);
            return isETextActivityPresent;
        }
    }
}
