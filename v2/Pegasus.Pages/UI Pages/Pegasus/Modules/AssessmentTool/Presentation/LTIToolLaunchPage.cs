using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the LTIToolLaunch Page Ui Actions.
    /// </summary>
    public class LTIToolLaunchPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = Logger.GetInstance(typeof(LTIToolLaunchPage));

        /// <summary>
        /// Get The Presentation Page Window Title.
        /// </summary>
        /// <param name="presentationPageTitle">This is Presentation Page Title.</param>
        /// <returns>Selected Window Title.</returns>
        public string GetPresentationPageWindowTitle(string presentationPageTitle)
        {
            Logger.LogMethodEntry("LTIToolLaunchPage",
              "GetPresentationPageWindowTitle", base.IsTakeScreenShotDuringEntryExit);
            string selectedWindowTitle = string.Empty;
            try
            {
                this.SelectPresentationPage(presentationPageTitle);
                selectedWindowTitle = base.GetPageTitle;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LTIToolLaunchPage",
              "GetPresentationPageWindowTitle", base.IsTakeScreenShotDuringEntryExit);
            return selectedWindowTitle;
        }

        /// <summary>
        /// Select Presentation Page.
        /// </summary>
        /// <param name="presentationPageTitle">This is Presentation Page Name.</param>
        private void SelectPresentationPage(string presentationPageTitle)
        {
            Logger.LogMethodExit("LTIToolLaunchPage",
                "SelectPresentationPage", base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(presentationPageTitle);
            base.SelectWindow(presentationPageTitle);
            Logger.LogMethodExit("LTIToolLaunchPage",
                "SelectPresentationPage", base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
