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
        /// Click save button in the popup window to start copy as template
        /// </summary>
        /// <returns></returns>
        public void ClickToCreateUpdate()
        {
            //Copy as shared library
            logger.LogMethodEntry("EditCopyTemplatesSectionsPage", "ClickToCreateUpdate",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click save button.
                base.WaitForElement(By.Id(EditCopyTemplatesSectionsResource.SaveButton_Id_for_SharedLibrary_Create));
                base.ClickButtonByID(EditCopyTemplatesSectionsResource.SaveButton_Id_for_SharedLibrary_Create);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EditCopyTemplatesSectionsPage", "ClickToCreateUpdate",
                base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click save button in the popup window to start create shared library
        /// </summary>
        public void CreateSharedLibrary()
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
            ClickToCreateUpdate();
        }

        /// <summary>
        /// Click Copy button in the popup window to copy section from section
        /// </summary>
        public void CopySection()
        {
            //TO select the pop window so as to set focus to its elements.
            base.SelectWindow(EditCopyTemplatesSectionsResource.CopyAsSection_Page_Window_Page_Title);
            //To set the start date to current date/time with required format.
            String getSLStartDate = DateTime.Now.ToString(
                EditCopyTemplatesSectionsResource.CopyAsSharedLibrary_Page_Date_Format);
            //wait for the required element to come up and then populate it.
            base.WaitForElement(By.Id(EditCopyTemplatesSectionsResource.SL_create_start_date));
            base.ClearTextByID(EditCopyTemplatesSectionsResource.SL_create_start_date);
            base.FillTextBoxByID(EditCopyTemplatesSectionsResource.SL_create_start_date, getSLStartDate);
            //Prepare the enddate/time with required format by adding 90 days to the current date.
            String getSLEndDate = DateTime.Now.AddDays(90).ToString(
            EditCopyTemplatesSectionsResource.CopyAsSharedLibrary_Page_Date_Format);
            //Populate the enddate
            base.WaitForElement(By.Id(EditCopyTemplatesSectionsResource.SL_create_end_date));
            base.ClearTextByID(EditCopyTemplatesSectionsResource.SL_create_end_date);
            base.FillTextBoxByID(EditCopyTemplatesSectionsResource.SL_create_end_date, getSLEndDate);
            ClickToCreateUpdate();
        }
        
        /// <summary>
        ///  Validate The Message On the Copy as Section Popup Page
        /// </summary>

        public Boolean ToValidateTheMessageOnPopupPage(string message)
        {
            //To Validate The Message On the Copy as Section Popup Page
            logger.LogMethodEntry("EditCopyTemplatesSectionsPage", "ToValidateTheMessageOnPopupPage",
            base.isTakeScreenShotDuringEntryExit);

            //Initialize Variable
            bool IsTrue = false; ;
            try
            {
                //TO select the pop window so as to set focus to its elements.
                base.SelectWindow(EditCopyTemplatesSectionsResource.CopyAsSection_Page_Window_Page_Title);

                //Check the message excpected and obtained are same
                IsTrue = base.IsElementContainsTextById(EditCopyTemplatesSectionsResource.CopyAsSection_Table_Id_Locator, message);
            }
            //Exception Handling
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("EditCopyTemplatesSectionsPage", "ToValidateTheMessageOnPopupPage",
            base.isTakeScreenShotDuringEntryExit);

            return IsTrue;
        }

        /// <summary>
        /// Get the Section popup check box status
        /// </summary>
        public Boolean IsVerifyCheckBoxStatusNotSelected()
        {
            //To get the Section popup check box status
            logger.LogMethodEntry("EditCopyTemplatesSectionsPage", "IsVerifyCheckBoxStatusNotSelected",
            base.isTakeScreenShotDuringEntryExit);

            //Variable Initialization
            bool IsChecked = false;
            try
            {
                //TO select the pop window so as to set focus to its elements.
                base.SelectWindow(EditCopyTemplatesSectionsResource.CopyAsSection_Page_Window_Page_Title);

                //Fetch the check box selection property
                IsChecked = base.GetWebElementPropertiesById(EditCopyTemplatesSectionsResource.
                    CopyAsSection_PopUpPage_Page_CheckBox_Id_Locator).Selected;
            }
            //Exception Handling
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("EditCopyTemplatesSectionsPage", "IsVerifyCheckBoxStatusNotSelected",
            base.isTakeScreenShotDuringEntryExit);

            return IsChecked;
        }
    }
}
