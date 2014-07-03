using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.ContentTool;
using System.Configuration;
using System.Threading;
using System.IO;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class details for Importing the MGM Cartridge 
    /// </summary>
    public class ImportCartridgePage : BasePage
    {
        /// <summary>
        /// This is the static instance of logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ImportCartridgePage));

        /// <summary>
        /// Imports MGM Cartridge
        /// </summary>
        public void ImportMGMCartridge()
        {
            //Imports the MGM Cartridge
            logger.LogMethodEntry("ImportCartridgePage", "ImportMGMCartridge",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the Import LTI Activity Links option
                new ContentLibraryUXPage().ClickOnImportLTIActivityLinksOption();
                //Uploades the MGM Cartridge
                this.UploadMGMCartridge();
                //To Wait till Upload is in Progress
                base.WaitUntilFileUploadInProgress(ImportCartridgePageResource.
                    ImportCartridgePage_Iframe_Id_Locator, By.Id(ImportCartridgePageResource.
                    ImportCartridgePage_FileUpload_InProgress_Id_Locator));
                //Select the Default Window
                base.SelectDefaultWindow();
                base.WaitForElement(By.Id(ImportCartridgePageResource.
                ImportCartridgePage_Iframe_Id_Locator));
                //Wait for the IFrame
                base.WaitForElement(By.Id(ImportCartridgePageResource.
                ImportCartridgePage_Iframe_Id_Locator));
                //Switch to the IFrame
                base.SwitchToIFrame(ImportCartridgePageResource.
                ImportCartridgePage_Iframe_Id_Locator);                
                //Wait for the Button
                base.WaitForElement(By.Id(ImportCartridgePageResource.
                    ImportCartridgePage_Button_OK_Cancel_Id_Locator));
                IWebElement getOkButton = base.GetWebElementPropertiesById
                    (ImportCartridgePageResource.
                    ImportCartridgePage_Button_OK_Cancel_Id_Locator);
                //Click on the OK Button
                base.ClickByJavaScriptExecutor(getOkButton);
                base.SelectDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ImportCartridgePage", "ImportMGMCartridge",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Upload MGM Cartridge
        /// </summary>
        private void UploadMGMCartridge()
        {
            //Uploads the MGM Cartridge
            logger.LogMethodEntry("ImportCartridgePage", "UploadMGMCartridge",
                base.isTakeScreenShotDuringEntryExit);
            base.SelectDefaultWindow();
            //Wait for the Frame
            base.WaitForElement(By.Id(ImportCartridgePageResource.
                ImportCartridgePage_Iframe_Id_Locator));
            //Switch to the IFrame
            base.SwitchToIFrame(ImportCartridgePageResource.
                ImportCartridgePage_Iframe_Id_Locator);
            //Wait for the Browse Button
            base.WaitForElement(By.Id(ImportCartridgePageResource.
                ImportCartridgePage_Button_Browse_Id_Locator));
            //Get the MGM Cartridge File Path
            string uploadCartridgeFilePath = (AutomationConfigurationManager.TestDataPath +
                ImportCartridgePageResource.
                ImportCartridgePage_MgmCartridge_Path).Replace("file:\\", "");
            //Upload the Zip File
            base.UploadFile(uploadCartridgeFilePath, By.Id(ImportCartridgePageResource.
                ImportCartridgePage_Button_Browse_Id_Locator));
            //Get Button Property
            IWebElement getImportButtonProperty = base.GetWebElementPropertiesById
                (ImportCartridgePageResource.ImportCartridgePage_Button_Import_Id_Locator);
            //Click on the Import button 
            base.ClickByJavaScriptExecutor(getImportButtonProperty);
            //Switch To Default Page Content
            base.SwitchToDefaultPageContent();
            logger.LogMethodExit("ImportCartridgePage", "UploadMGMCartridge",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
