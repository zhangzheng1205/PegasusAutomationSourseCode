using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.User;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment;
using System.Configuration;
using System.Threading;
using System.IO;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains the Details of Import User.
    /// </summary>
    public class ImportUsersPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ImportUsersPage));

        /// <summary>
        /// Bulk User Upload
        /// </summary>
        public void UploadBulkUserFile()
        {
            //Bulk User Upload
            logger.LogMethodEntry("ImportUsersPage", "UploadBulkUserFile",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get the Bulk User File Path
                string getBulkUserFilePath = (AutomationConfigurationManager.TestDataPath +
                    ImportUsersPageResource.ImportUsers_Page_BulkUser_File_Path).
                    Replace("file:\\", "");
                //Upload the xls File
                base.UploadFile(getBulkUserFilePath, By.Id(ImportUsersPageResource.
                    ImportUsers_Page_Browse_Button_Id_Locator));
                //Get Save and Return Button Property
                IWebElement getSaveAndReturnButtonProperty = base.GetWebElementPropertiesById(
                    ImportUsersPageResource.ImportUsers_Page_Button_SaveAndReturn_Id_Locator);
                //Click on the Save and Return button 
                base.ClickByJavaScriptExecutor(getSaveAndReturnButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ImportUsersPage", "UploadBulkUserFile",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Import Users'Window
        /// </summary>
        public void SelectImportUsersWindow()
        {
            //Select 'Import Users'Window
            logger.LogMethodEntry("ImportUsersPage", "UploadBulkUserFile",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.WaitUntilWindowLoads(ImportUsersPageResource.ImportUsers_Page_Window_Name);
                //Select Window
                base.SelectWindow(ImportUsersPageResource.ImportUsers_Page_Window_Name);                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ImportUsersPage", "UploadBulkUserFile",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
