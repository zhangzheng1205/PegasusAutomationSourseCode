using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Common;
using System.Threading;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation.AutoGrader
{

    public class DownLoadStartingFilesPage : BasePage
    {
        // <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ShowMessagePage));


        /// <summary>
        /// Gets text on Get Download Files button.
        /// </summary>
        /// <returns></returns>

        public void ClickDownloadIconOfTheFile(string fileName)
        {
            logger.LogMethodEntry("DownLoadStartingFilesPage", " ClickDownloadIconOfTheFile",
                   base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilPopUpLoads(DownLoadStartingFilesPageResource
                .DownLoadStartingFilesPage_FileName_Popup_Title);
            // Select Popup
            base.SelectWindow(DownLoadStartingFilesPageResource.
                       DownLoadStartingFilesPage_FileName_Popup_Title);
            //Variable Declaration of Assets     
            string getFileName = string.Empty;
            try
            {
                //Get Assets Count               
                int getFileCount = base.GetElementCountByXPath(DownLoadStartingFilesPageResource.
                 DownLoadStartingFilesPage_FileName_RowCount_Xpath_Locator);
                int x = getFileCount;
                for (int setRowCount = Convert.ToInt32(DownLoadStartingFilesPageResource.
                  DownLoadStartingFilesPage_Initial_Value); setRowCount <= getFileCount; setRowCount++)
                {
                    getFileName = base.GetElementTextByXPath(string.Format
                        ("//table[@id='tblRepeater']/tbody/tr[{0}]",
                            setRowCount));
                    if (getFileName.Contains(fileName))
                    {
                        //Wait for the element
                        base.WaitForElement(By.XPath(string.Format(DownLoadStartingFilesPageResource.
                       DownLoadStartingFilesPage_File_Name_Xpath_Locator, setRowCount)), 10);
                        IWebElement getDownloadIconID = base.GetWebElementPropertiesByXPath
                            (string.Format(DownLoadStartingFilesPageResource.DownLoadStartingFilesPage_DownloadIcon_Xpath_Locator, setRowCount));
                        //Click on Download Icon
                        base.ClickByJavaScriptExecutor(getDownloadIconID);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DownLoadStartingFilesPage", " ClickDownloadIconOfTheFile",
                     base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Close and Return button in Download Starting File Page.
        /// </summary>
        public void ClickOnCloseAndReturnButton()
        {
            logger.LogMethodEntry("DownLoadStartingFilesPage", " ClickOnCloseAndReturnButton",
                            base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilPopUpLoads(DownLoadStartingFilesPageResource
                            .DownLoadStartingFilesPage_FileName_Popup_Title);
            // Select Popup
            base.SelectWindow(DownLoadStartingFilesPageResource.
                       DownLoadStartingFilesPage_FileName_Popup_Title);
            // Wait untill Close and Return button loads
            base.WaitForElement(By.Id(DownLoadStartingFilesPageResource.
                DownLoadStartingFilePage_CloseAndReturn_Button_ID_Value));
            IWebElement closeAndReturnButtonID = base.GetWebElementPropertiesById
                (DownLoadStartingFilesPageResource.
                DownLoadStartingFilePage_CloseAndReturn_Button_ID_Value);
            base.ClickByJavaScriptExecutor(closeAndReturnButtonID);
            logger.LogMethodExit("DownLoadStartingFilesPage", " ClickOnCloseAndReturnButton",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }

}