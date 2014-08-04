using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool
{
    /// <summary>
    /// This class handle the all action on download page.
    /// </summary>
    public class PrintPopupPage : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
             Logger.GetInstance(typeof(PrintPopupPage));

        /// <summary>
        /// Get the number of version rows from the table.
        /// </summary>
        /// <returns>Nuber of version rows.</returns>
        public int GetNumberOfVersions()
        {
            //Logger Entry
            Logger.LogMethodEntry("PrintPopupPage", "GetNumberOfVersions",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialized Variable
            int getVersionNumberOfRows = 0;
            try
            {
                //Sleep Time
                Thread.Sleep(Convert.ToInt16(PrintPopupPageResource.
                    PrintPopup_Page_Sleep_Time_Value));
                //Select LightBox
                this.SelectDownloadLightBoxIFrame();
                //Wait for Element
                base.WaitForElement(By.Id(PrintPopupPageResource.
                    PrintPopup_Page_CreateNewTest_Table_Id_Locator));
                //Sleep Time
                Thread.Sleep(Convert.ToInt16(PrintPopupPageResource.
                    PrintPopup_Page_Sleep_Time_Value));
                //Get Version Rows Inside Table
                getVersionNumberOfRows = base.GetElementCountByXPath(
                    PrintPopupPageResource.
                    PrintPopup_Page_CreateNewTest_Version_Row_XPath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("PrintPopupPage", "GetNumberOfVersions",
                base.IsTakeScreenShotDuringEntryExit);
            return getVersionNumberOfRows;
        }

        /// <summary>
        /// Select Download Lightbox.
        /// </summary>
        private void SelectDownloadLightBoxIFrame()
        {
            //Logger Entry
            Logger.LogMethodEntry("PrintPopupPage", "SelectDownloadLightBoxIFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Switch To Default Page Content
            base.SwitchToDefaultPageContent();
            //Wait for Iframe 
            base.WaitForElement(By.Id(PrintPopupPageResource.
                PrintPopup_Page_Iframe_Id_Locator));
            //switch to Iframe
            base.SwitchToIFrameById(PrintPopupPageResource.
                PrintPopup_Page_Iframe_Id_Locator);
            //Logger Exit
            Logger.LogMethodExit("PrintPopupPage", "SelectDownloadLightBoxIFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Download Version Number.
        /// </summary>
        /// <returns>Version Title.</returns>
        public String GetDownloadVersionName()
        {
            //Logger Entry
            Logger.LogMethodEntry("PrintPopupPage", "GetDownloadVersionName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialized variable
            String getDownloadVersionNameFromTableRow = string.Empty;
            try
            {
                //Select LightBox
                this.SelectDownloadLightBoxIFrame();
                //Wait for Element
                base.WaitForElement(By.XPath(PrintPopupPageResource.
                    PrintPopup_Page_CreateNewTest_Version_Title_XPath_Locator),5);
                //Get Download File Name
                getDownloadVersionNameFromTableRow = base.GetTitleAttributeValueByXPath(
                    PrintPopupPageResource.
                    PrintPopup_Page_CreateNewTest_Version_Title_XPath_Locator).Replace(
                    PrintPopupPageResource.PrintPopup_Page_Dot_Character, string.Empty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            Logger.LogMethodExit("PrintPopupPage", "GetDownloadVersionName",
                base.IsTakeScreenShotDuringEntryExit);
            return getDownloadVersionNameFromTableRow;
        }
    }
}
