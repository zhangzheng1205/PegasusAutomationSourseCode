using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.ContentTool;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Creation of Link Custom Content
    /// </summary>
    public class UploadFilePage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(UploadFilePage));

        /// <summary>
        /// Create File Asset.
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity Type.</param>
        public void CreateFileAsset(Activity.ActivityTypeEnum activityTypeEnum)
        {
            // Create File Asset
            logger.LogMethodEntry("UploadFilePage", "CreateFileAsset",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Intialize Guid for File Asset
                Guid newFileName = Guid.NewGuid();
                //Select the window
                base.WaitUntilWindowLoads(UploadFilePageResource.
                    UploadFilePageResourse_File_Window_Name);
                base.SelectWindow(UploadFilePageResource.
                    UploadFilePageResourse_File_Window_Name);
                //Upload The Image File
                this.UploadTheImageFile();
                //Wait for the element
                base.WaitForElement(By.Id(UploadFilePageResource.
                    UploadFilePageResourse_File_TextBox_Id_Locator));
                //Fill the FileName text
                base.FillTextBoxByID(UploadFilePageResource.
                    UploadFilePageResourse_File_TextBox_Id_Locator,
                    newFileName.ToString());
                //Store the link Asset
                this.StoreTheFileAsset(newFileName, activityTypeEnum);
                //Click On Add Button
                this.ClickOnAddButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UploadFilePage", "CreateFileAsset",
              base.isTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Click On Add Button.
        /// </summary>
        private void ClickOnAddButton()
        {
            //Click On Add Button
            logger.LogMethodEntry("UploadFilePage", "ClickOnAddButton",
              base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(UploadFilePageResource.
                UploadFilePageResourse_File_Add_button_Id_Locator));
            base.FocusOnElementByID(UploadFilePageResource.
                UploadFilePageResourse_File_Add_button_Id_Locator);
            //Get the web element
            IWebElement getAddButton = base.GetWebElementPropertiesById
                (UploadFilePageResource.
                UploadFilePageResourse_File_Add_button_Id_Locator);
            //Click the "Add" button
            base.ClickByJavaScriptExecutor(getAddButton);
            Thread.Sleep(Convert.ToInt32(UploadFilePageResource.
                UploadFilePageResourse_File_ThreadTime));
            logger.LogMethodExit("UploadFilePage", "ClickOnAddButton",
              base.isTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Upload The Image File.
        /// </summary>
        private void UploadTheImageFile()
        {
            //Upload The Image File
            logger.LogMethodEntry("UploadFilePage", "UploadTheImageFile",
                 base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(UploadFilePageResource.
                UploadFilePageResourse_Browse_Button_Id_Locator));
            //Get the file Image File Path
            string getFileImageFilePath = 
                (AutomationConfigurationManager.TestDataPath + 
                UploadFilePageResource.UploadFilePageResourse_ImgUpload).
                Replace("file:\\", "");
            //Upload the image
            base.UploadFile(getFileImageFilePath,By.Id(UploadFilePageResource.
                UploadFilePageResourse_Browse_Button_Id_Locator));
            logger.LogMethodExit("UploadFilePage", "UploadTheImageFile",
              base.isTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Store The File Asset.
        /// </summary>
        /// <param name="newFileName">This is File Name.</param>
        /// <param name="activityTypeEnum">This is Activity Type.</param>
        private void StoreTheFileAsset(Guid newFileName,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Store The File Asset
            logger.LogMethodEntry("UploadFilePage", "StoreTheFileAsset",
                 base.isTakeScreenShotDuringEntryExit);
            //Store the File in memory
            Activity newFile = new Activity
            {
                Name = newFileName.ToString(),
                ActivityType = activityTypeEnum,
                IsCreated = true,
            };
            newFile.StoreActivityInMemory();
            logger.LogMethodExit("UploadFilePage", "StoreTheFileAsset",
                 base.isTakeScreenShotDuringEntryExit); 
        }
    }
}
