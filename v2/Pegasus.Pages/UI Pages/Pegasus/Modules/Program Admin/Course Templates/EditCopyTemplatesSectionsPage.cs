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
        /// 

        private enum DateType
        {
            StartDate=1,
            EndDate=2
        }

        public void ClickToCreateUpdate()
        {
            //Copy as shared library
            logger.LogMethodEntry("EditCopyTemplatesSectionsPage", "ClickToCreateUpdate",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click save button.
                base.WaitForElement(By.Id(EditCopyTemplatesSectionsResource.SaveButton_Id_for_SharedLibrary_Create));
                base.ClickButtonById(EditCopyTemplatesSectionsResource.SaveButton_Id_for_SharedLibrary_Create);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EditCopyTemplatesSectionsPage", "ClickToCreateUpdate",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click save button in the popup window to start create shared library
        /// </summary>
        public void CreateSharedLibrary()
        {
            //TO select the pop window so as to set focus to its elements.
            base.SelectWindow(EditCopyTemplatesSectionsResource.CopyAsSharedLibrary_Page_Window_Page_Title);
            //wait for the required element to come up and then populate it.
            base.WaitForElement(By.Id(EditCopyTemplatesSectionsResource.SL_create_start_date));
            base.FillTextBoxById(EditCopyTemplatesSectionsResource.SL_create_start_date, GetDateValue(DateType.StartDate));
            //Prepare the enddate/time with required format by adding 90 days to the current date.
            //String getSLEndDate = DateTime.Now.AddDays(90).ToString(
            //base.GetElementInnerTextById("txtStartDateId_lblDateFormat").ToLower());
            //Populate the enddate
            base.WaitForElement(By.Id(EditCopyTemplatesSectionsResource.SL_create_end_date));
            base.FillTextBoxById(EditCopyTemplatesSectionsResource.SL_create_end_date, GetDateValue(DateType.EndDate));
            ClickToCreateUpdate();
        }

        /// <summary>
        /// To get the date value
        /// <parameter Name="DateType">0 for startdate, 1 for end date</parameter>
        /// </summary>
        private String GetDateValue(DateType DateType)
        {
            String OriginalDateFormat = base.GetElementInnerTextById(EditCopyTemplatesSectionsResource.DateFormat_Id_Locator);
            String RequiredDateFormat = String.Empty;
            String getStartDate = string.Empty;
            String getEndDate = string.Empty;

            switch (OriginalDateFormat)
            {
                case "MM/DD/YYYY":
                    RequiredDateFormat = EditCopyTemplatesSectionsResource.DateFormat_Type_1;
                    break;
                case "DD/MM/YYYY":
                    RequiredDateFormat = EditCopyTemplatesSectionsResource.DateFormat_Type_2;
                    break;
                case "DD/MM/YY":
                    RequiredDateFormat = EditCopyTemplatesSectionsResource.DateFormat_Type_3;
                    break;
                case "DD-MM-YY":
                    RequiredDateFormat = EditCopyTemplatesSectionsResource.DateFormat_Type_4;
                    break;
                case "DD-MM-YYYY":
                    RequiredDateFormat = EditCopyTemplatesSectionsResource.DateFormat_Type_5;
                    break;
                case "YYYY-MM-DD":
                    RequiredDateFormat = EditCopyTemplatesSectionsResource.DateFormat_Type_6;
                    break;
                    
            }
            if(DateType==DateType.StartDate)
                return getStartDate = DateTime.Now.ToString(RequiredDateFormat);
            else
                return getEndDate = DateTime.Now.AddDays(90).ToString(RequiredDateFormat);
        }


        /// <summary>
        /// Click Copy button in the popup window to copy section from section
        /// </summary>
        public void CopySection()
        {
            //TO select the pop window so as to set focus to its elements.
            base.SelectWindow(EditCopyTemplatesSectionsResource.CopyAsSection_Page_Window_Page_Title);
            //To set the start date to current date/time with required format.
            String getSLStartDate = GetDateValue(DateType.StartDate);            
            //wait for the required element to come up and then populate it.
            base.WaitForElement(By.Id(EditCopyTemplatesSectionsResource.SL_create_start_date));
            base.ClearTextById(EditCopyTemplatesSectionsResource.SL_create_start_date);
            base.FillTextBoxById(EditCopyTemplatesSectionsResource.SL_create_start_date, getSLStartDate);
            //Prepare the enddate/time with required format by adding 90 days to the current date.
            String getSLEndDate = GetDateValue(DateType.EndDate);
            //Populate the enddate
            base.WaitForElement(By.Id(EditCopyTemplatesSectionsResource.SL_create_end_date));
            base.ClearTextById(EditCopyTemplatesSectionsResource.SL_create_end_date);
            base.FillTextBoxById(EditCopyTemplatesSectionsResource.SL_create_end_date, getSLEndDate);
            ClickToCreateUpdate();
        }
        
        /// <summary>
        ///  Validate The Message On the Copy as Section Popup Page
        /// </summary>

        public Boolean ToValidateTheMessageOnPopupPage(string message)
        {
            //To Validate The Message On the Copy as Section Popup Page
            logger.LogMethodEntry("EditCopyTemplatesSectionsPage", "ToValidateTheMessageOnPopupPage",
            base.IsTakeScreenShotDuringEntryExit);

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
            base.IsTakeScreenShotDuringEntryExit);

            return IsTrue;
        }

        /// <summary>
        /// Get the Section popup check box status
        /// </summary>
        public Boolean CopyMyCourseContentCheckBoxStatus()
        {
            //To get the Section popup check box status
            logger.LogMethodEntry("EditCopyTemplatesSectionsPage", "CopyMyCourseContentCheckBoxStatus",
            base.IsTakeScreenShotDuringEntryExit);

            //Variable Initialization
            bool IsChecked = false;
            try
            {
                //TO select the pop window so as to set focus to its elements.
                base.SelectWindow(EditCopyTemplatesSectionsResource.CopyAsSection_Page_Window_Page_Title);
                base.WaitForElement(By.Id(EditCopyTemplatesSectionsResource.
                    CopyAsSection_PopUpPage_Page_CheckBox_Id_Locator));
                //Fetch the check box selection property
                IsChecked = base.GetWebElementPropertiesById(EditCopyTemplatesSectionsResource.
                    CopyAsSection_PopUpPage_Page_CheckBox_Id_Locator).Selected;
            }
            //Exception Handling
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("EditCopyTemplatesSectionsPage", "CopyMyCourseContentCheckBoxStatus",
            base.IsTakeScreenShotDuringEntryExit);

            return IsChecked;
        }
    }
}
