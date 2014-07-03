using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.MySpanishLab;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Windows.Forms;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains the details of Verb Chart Page.
    /// </summary>
    public class VerbChartUXPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(VerbChartUXPage));

        /// <summary>
        /// Get Verb Chart Label.
        /// </summary>
        public String GetVerbChartLabel()
        {
            //Get Verb Chart Label
            logger.LogMethodEntry("VerbChartUXPage", "GetVerbChartLabel",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getVerbChartLabel = string.Empty;
            try
            {
                //Switch to Last Opened Window
                base.SwitchToLastOpenedWindow();
                base.WaitForElement(By.Id(VerbChartUXPageResource.
                    VerbChartUX_Page_Resource_VerbChart_Label_Id_Locator));
                //Get Verb Chart Label
                getVerbChartLabel = base.GetElementTextByID(VerbChartUXPageResource.
                    VerbChartUX_Page_Resource_VerbChart_Label_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("VerbChartUXPage", "GetVerbChartLabel",
                base.isTakeScreenShotDuringEntryExit);
            return getVerbChartLabel;
        }
    }
}
