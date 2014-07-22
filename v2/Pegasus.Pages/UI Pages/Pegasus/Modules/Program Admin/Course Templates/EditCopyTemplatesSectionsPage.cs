using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Course_Templates;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    public class EditCopyTemplatesSectionsPage : BasePage
    {
        private static Logger logger = Logger.GetInstance(typeof(EditCopyTemplatesSectionsPage));

        /// <summary>
        /// Cick save button in the popup window to start copy as shared library
        /// </summary>
        /// <returns>Returns text of Successfull message. </returns>
        public void ClickToCreateUpdate()
        {
            //Copy as shared library
            logger.LogMethodEntry("CopyAsSharedLibraryPage", "ClickToCreateUpdate",
                base.isTakeScreenShotDuringEntryExit);
            try
            {    
                //TO select the pop window so as to set focus to its elements.
                base.SelectWindow(EditCopyTemplatesSectionsResource.CopyAsSharedLibrary_Page_Window_Page_Title);
                //To set the start date to current date/time with required format.
                String getSLStartDate = DateTime.Now.ToString(
                    EditCopyTemplatesSectionsResource.CopyAsSharedLibrary_Page_Date_Format);
                //wait for the required element to come up and then populate it.
                base.WaitForElement(By.Id(EditCopyTemplatesSectionsResource.SL_create_start_date));
                base.FillTextBoxByID(EditCopyTemplatesSectionsResource.SL_create_start_date, getSLStartDate);
                //Prepare the enddate/time with required format by adding 90 days to the current date.
                String getSLEndDate = DateTime.Now.AddDays(90).ToString(
                EditCopyTemplatesSectionsResource.CopyAsSharedLibrary_Page_Date_Format);
                //Populate the enddate
                base.WaitForElement(By.Id(EditCopyTemplatesSectionsResource.SL_create_end_date));
                base.FillTextBoxByID(EditCopyTemplatesSectionsResource.SL_create_end_date, getSLEndDate);
                //Click save button.
                base.WaitForElement(By.Id(EditCopyTemplatesSectionsResource.SaveButton_Id_for_SharedLibrary_Create));
                base.ClickButtonByID(EditCopyTemplatesSectionsResource.SaveButton_Id_for_SharedLibrary_Create);                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CopyAsSharedLibraryPage", "ClickToCreateUpdate",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
