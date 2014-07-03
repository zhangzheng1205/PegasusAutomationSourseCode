using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports
{
    /// <summary>
    /// This class is responsible for handling Course section usage report
    /// </summary>
    public class RptCourseUsagePage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptStudentUsagePage));

        /// <summary>
        /// To get section name in the report
        /// </summary>
        /// <returns>Result of Section Text</returns>
        public string GetSectionText()
        {
            logger.LogMethodEntry("RptStudentUsagePage", "GetSectionText",
                base.isTakeScreenShotDuringEntryExit);
            string getSectionText = string.Empty;
            try
            {
                // Select window title
                base.WaitUntilWindowLoads(RptCourseUsagePageResource
                           .RptCourseUsagePage_WindowTitleName);
                base.SelectWindow(RptCourseUsagePageResource
                                .RptCourseUsagePage_WindowTitleName);
                getSectionText = base.GetElementTextByXPath(RptCourseUsagePageResource
                    .RptCourseUsagePage_SectionName_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentUsagePage", "GetSectionText",
                base.isTakeScreenShotDuringEntryExit);
            return getSectionText;
        }


        /// <summary>
        /// To get section status text in the report
        /// </summary>
        /// <returns>Status text</returns>
        public string GetSectionStatusText()
        {
            logger.LogMethodEntry("RptStudentUsagePage", "GetSectionText",
                base.isTakeScreenShotDuringEntryExit);
            string getSectionStatusText = string.Empty;
            try
            {
                // Select window title
                base.WaitUntilWindowLoads(RptCourseUsagePageResource
                           .RptCourseUsagePage_WindowTitleName);
                base.SelectWindow(RptCourseUsagePageResource
                                .RptCourseUsagePage_WindowTitleName);
                // Get status text
                getSectionStatusText = base.GetElementTextByXPath(RptCourseUsagePageResource
                    .RptCourseUsagePage_StatusText_Xpath_Locator);
                // Close pop up and select main window
                base.CloseBrowserWindow();
                base.WaitUntilWindowLoads(RptCourseUsagePageResource
                    .RptCourseUsagePage_WindowTitle_Main);
                base.SelectWindow(RptCourseUsagePageResource
                .RptCourseUsagePage_WindowTitle_Main);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptStudentUsagePage", "GetSectionText",
                base.isTakeScreenShotDuringEntryExit);
            return getSectionStatusText;
        }
    }
}
