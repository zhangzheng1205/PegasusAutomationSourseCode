using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.User;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.OrganizationManagement;
using System.Configuration;
using System.Threading;
using System.IO;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains the details of Bulk User Upload
    /// </summary>
    public class BulkUploadQueuePage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(BulkUploadQueuePage));

        /// <summary>
        /// Delete Older Uploaded Files
        /// </summary>
        public void DeleteOlderUploadedFiles()
        {
            //Delete the Older files
            logger.LogMethodEntry("BulkUploadQueuePage", "DeleteOlderUploadedFiles",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the Users tab
                new ManageUserPage().ClickOnUsersTab();
                //Select Manage Organization Window
                new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
                //Switch to the Frame
                base.SwitchToIFrame(ManageUserPageResource.ManageUser_Page_Iframe_Id_Locator);
                if ( base.IsElementPresent(By.Id(ManageUserPageResource.
                    ManageUser_Page_BulkRegistration_ViewRegistration_Data_Id_Locator), 
                    Convert.ToInt32(BulkUploadQueuePageResource.
                    BulkUploadQueue_Page_Customized_Wait_Time)) )
                {                    
                    //Remove the Older Files
                    this.RemoveTheOlderFiles();
                }
                //Select Manage Organization Window
                new ManageOrganisationToolBarPage().SelectManageOrganizationWindow();
                //Refresh the Page                
                base.RefreshTheCurrentPage();                
            }
            catch ( Exception e)
            {
                ExceptionHandler.HandleException(e);
            }         
            logger.LogMethodExit("BulkUploadQueuePage", "DeleteOlderUploadedFiles",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Remove The Older Files
        /// </summary>
        private void RemoveTheOlderFiles()
        {
            //Remove The Older Files
            logger.LogMethodEntry("BulkUploadQueuePage", "RemoveTheOlderFiles",
                base.isTakeScreenShotDuringEntryExit);
            //Click on the Registration Queue
            base.ClickButtonById(ManageUserPageResource.
                ManageUser_Page_BulkRegistration_ViewRegistration_Data_Id_Locator);
            base.WaitUntilWindowLoads(BulkUploadQueuePageResource.
                BulkUploadQueue_Page_Window_Title);
            base.SelectWindow(BulkUploadQueuePageResource.BulkUploadQueue_Page_Window_Title);
            //Check the Select all Checkbox
            base.SelectCheckBoxById(BulkUploadQueuePageResource.
                BulkUploadQueue_Page_SelectAll_CheckBox_Id_Locator);
            if ( base.IsElementPresent(By.Id(BulkUploadQueuePageResource.
                BulkUploadQueue_Page_Remove_Link_Id_Locator)) )
            {
                //Click on the Remove link
                base.ClickLinkById(BulkUploadQueuePageResource.
                    BulkUploadQueue_Page_Remove_Link_Id_Locator);
                base.CloseBrowserWindow();
            }
            logger.LogMethodExit("BulkUploadQueuePage", "RemoveTheOlderFiles",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Delete Older Uploaded File In 'Manage Students' Window
        /// </summary>
        public void DeleteOlderUploadedFileInManageStudentsWindow()
        {
            //Delete Older Uploaded File In 'Manage Students' Window
            logger.LogMethodEntry("BulkUploadQueuePage", 
                "DeleteOlderUploadedFileInManageStudentsWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Window
                base.WaitUntilWindowLoads(BulkUploadQueuePageResource.
                    BulkUploadQueue_Page_Window_Title);
                base.SelectWindow(BulkUploadQueuePageResource.
                    BulkUploadQueue_Page_Window_Title);
                //Check the Select all Checkbox
                base.SelectCheckBoxById(BulkUploadQueuePageResource.
                    BulkUploadQueue_Page_SelectAll_CheckBox_Id_Locator);
                //Click on the Remove link
                base.WaitForElement(By.Id(BulkUploadQueuePageResource.
                    BulkUploadQueue_Page_Remove_Link_Id_Locator));
                base.ClickLinkById(BulkUploadQueuePageResource.
                    BulkUploadQueue_Page_Remove_Link_Id_Locator);
                base.CloseBrowserWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("BulkUploadQueuePage", 
                "DeleteOlderUploadedFileInManageStudentsWindow",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
