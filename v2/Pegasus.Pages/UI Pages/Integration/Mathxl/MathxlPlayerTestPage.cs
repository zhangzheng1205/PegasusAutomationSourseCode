using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.Mathxl;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the PlayerTest Page Flash/Ui Actions.
    /// </summary>
    public class MathxlPlayerTestPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger Logger = Logger.GetInstance(typeof(MathxlPlayerTestPage));

        /// <summary>
        /// Attempt Mgm Activity.
        /// </summary>
        /// <param name="assetName">This is asset name.</param>
        /// <param name="scoreToAchieve">This is score percentage value.</param>
        public void AttemptMgmActivity(string assetName, string scoreToAchieve)
        {
            // attempt mgm activity
            Logger.LogMethodEntry("MathxlPlayerTestPage", "AttemptMgmActivity",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                const int screenWidth = 800;
                const int screenHeight = 800;
                // setting the screen size and position
                base.SetWindowSize(screenWidth, screenHeight);
                base.SetWindowPosition(Screen.PrimaryScreen.WorkingArea.Width - screenWidth
                    , Screen.PrimaryScreen.WorkingArea.Height - screenHeight);
                switch (assetName)
                {
                    case "Topic 1 Test with Study Plan":
                        switch (scoreToAchieve)
                        {
                            case "0%":
                                Process.Start((AutomationConfigurationManager.TestDataPath
                                    + MathxlPlayerTestPageResource.MathxlPlayerTest_Page_Topic1TestWithStudyPlan0Percent_File_Path).Replace("file:\\", ""));
                                break;
                        }
                        break;
                    case "1-1 Homework":
                        switch (scoreToAchieve)
                        {
                            case "0%":
                                Process.Start((AutomationConfigurationManager.TestDataPath
                                  + MathxlPlayerTestPageResource.MathxlPlayerTest_Page_11Homework0Percent_File_Path).Replace("file:\\", ""));
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("MathxlPlayerTestPage", "AttemptMgmActivity",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
