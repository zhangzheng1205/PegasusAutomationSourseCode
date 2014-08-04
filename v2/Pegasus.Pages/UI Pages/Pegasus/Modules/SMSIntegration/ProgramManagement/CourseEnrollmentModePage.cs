using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Course Enrollment Mode Page Actions.
    /// </summary>
    public class CourseEnrollmentModePage : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CourseEnrollmentModePage));

        /// <summary>
        /// Course Delevery Mode Options.
        /// </summary>
        public enum DeliveryModeTypeEnum
        {
            //Course Delivery Mode Options
            LMS = 1,
            eCollege = 2,
            CCNG = 3,
            eText = 4
        }

        /// <summary>
        /// Selcting and Saving Course Enrollment Mode For Pegasus Product.
        /// </summary>
        public void SelectEnrollmentMode()
        {
            //Purpose: To Click Save Button to Enroll Course To Product
            Logger.LogMethodEntry("CourseEnrollmentModePage",
                "SelectEnrollmentMode", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectEnrollmentModePopUpWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseEnrollmentModePage",
                "SelectEnrollmentMode", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Enrollment Save Button.
        /// </summary>
        public void ClickEnrollmentSaveButton()
        {
            //Click Save Button
            Logger.LogMethodEntry("CourseEnrollmentModePage",
                "ClickEnrollmentSaveButton", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.Id(CourseEnrollmentModePageResource.
                  CourseEnrollmentMode_Page_SaveButton_Id_Locator));
                //Get HTML Element Property
                IWebElement getEnrollmentModeButtonProperty = base.GetWebElementPropertiesById
                    (CourseEnrollmentModePageResource.
                         CourseEnrollmentMode_Page_SaveButton_Id_Locator);
                //Click Button Save
                base.ClickByJavaScriptExecutor(getEnrollmentModeButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseEnrollmentModePage",
                "ClickEnrollmentSaveButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Enrollment Mode Pop Up Window.
        /// </summary>
        private void SelectEnrollmentModePopUpWindow()
        {
            //Select Window
            Logger.LogMethodEntry("CourseEnrollmentModePage",
               "SelectEnrollmentModePopUpWindow", base.IsTakeScreenShotDuringEntryExit);
            //Wait For Pop Up Window Load
            base.WaitUntilWindowLoads(CourseEnrollmentModePageResource.
              CourseEnrollmentMode_Page_EnrollmentMode_Window_Title_Name);
            //Select Window
            base.SelectWindow(CourseEnrollmentModePageResource.
              CourseEnrollmentMode_Page_EnrollmentMode_Window_Title_Name);
            Logger.LogMethodExit("CourseEnrollmentModePage",
               "SelectEnrollmentModePopUpWindow", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create Product Licensing.
        /// </summary>
        /// <param name="productId">This is rumba product Id.</param>
        /// <param name="resourceId">This is rumba resource Id.</param>
        public void CreateLicensing(int productId, int resourceId)
        {
            //Fill the productId and ResourceId
            Logger.LogMethodEntry("CourseEnrollmentModePage",
                 "CreateLicensing", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Fill Rimba Product Id 
                this.EnterRumbaProductId(productId);
                //Fill Rumba Resource Id
                this.EnterRumbaResourceId(resourceId);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseEnrollmentModePage",
                "CreateLicensing", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Rumba Resource Id.
        /// </summary>
        /// <param name="resourceId">This is resource id.</param>
        private void EnterRumbaResourceId(int resourceId)
        {
            Logger.LogMethodEntry("CourseEnrollmentModePage",
             "EnterRumbaResourceId", base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(CourseEnrollmentModePageResource.
                                     CourseEnrollmentMode_Page_RumbaResourceId_Textbox_Id_Locator));
            //Fill Resourse Id in Text Box
            base.FillTextBoxById(CourseEnrollmentModePageResource.
                                     CourseEnrollmentMode_Page_RumbaResourceId_Textbox_Id_Locator,
                                 resourceId.ToString(CultureInfo.InvariantCulture));
            Logger.LogMethodExit("CourseEnrollmentModePage",
             "EnterRumbaResourceId", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Rumba Product Id.
        /// </summary>
        /// <param name="productId"></param>
        private void EnterRumbaProductId(int productId)
        {
            //Enter Product Id
            Logger.LogMethodEntry("CourseEnrollmentModePage",
        "EnterRumbaProductId", base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(CourseEnrollmentModePageResource.
                                          CourseEnrollmentMode_Page_RumbaProductId_Textbox_Id_Locator));
            //Fill the ProductId
            base.FillTextBoxById(CourseEnrollmentModePageResource.
                                     CourseEnrollmentMode_Page_RumbaProductId_Textbox_Id_Locator,
                                 productId.ToString(CultureInfo.InvariantCulture));
            Logger.LogMethodExit("CourseEnrollmentModePage",
                "EnterRumbaProductId", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Delivery Mode.
        /// </summary>
        /// <param name="deliveryModeTypeEnum">This is delivery type enum.</param>
        public void SelectDeliveryPreference(DeliveryModeTypeEnum
            deliveryModeTypeEnum)
        {
            //Enter Product Id
            Logger.LogMethodEntry("CourseEnrollmentModePage",
        "SelectDeliveryPreference", base.IsTakeScreenShotDuringEntryExit);
            switch (deliveryModeTypeEnum)
            {
                case DeliveryModeTypeEnum.eCollege:
                    //Wait For Element
                    base.WaitForElement(By.Id(CourseEnrollmentModePageResource.
                        CourseEnrollmentMode_Page_DeliveryMode_ECollege_CheckBox_Id_Locator));
                    //Select Delivery Mode Checbox
                    base.SelectCheckBoxById(CourseEnrollmentModePageResource.
                        CourseEnrollmentMode_Page_DeliveryMode_ECollege_CheckBox_Id_Locator);
                    break;
            }
            //Enter Product Id
            Logger.LogMethodEntry("CourseEnrollmentModePage",
        "SelectDeliveryPreference", base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Get ECollege Integration Point Id.
        /// </summary>
        /// <returns>Returns ECollege Integration Point Id else Null.</returns>
        public String GetECollegeTpiIntegrationPointId()
        {
            //Get Integration Point Id
            Logger.LogMethodEntry("CourseEnrollmentModePage",
                "GetECollegeTpiIntegrationPointId", base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            this.SelectEditEnrollmentModePopUpWindow();
            //Wait For Element
            base.WaitForElement(By.Id(CourseEnrollmentModePageResource.
                CourseEnrollmentMode_Page_eCollege_IntegrationPoint_Id_Locator));
            //Get Integration Point Id
            String getECollegeIntegrationPoint = base.GetElementTextById(CourseEnrollmentModePageResource.
                                                                             CourseEnrollmentMode_Page_eCollege_IntegrationPoint_Id_Locator);
            Logger.LogMethodEntry("CourseEnrollmentModePage",
                "GetECollegeTpiIntegrationPointId", base.IsTakeScreenShotDuringEntryExit);
            return getECollegeIntegrationPoint;
        }

        /// <summary>
        /// Select Edit Enrollment Mode Pop Up Window.
        /// </summary>
        private void SelectEditEnrollmentModePopUpWindow()
        {
            //Select Window
            Logger.LogMethodEntry("CourseEnrollmentModePage",
               "SelectEditEnrollmentModePopUpWindow", base.IsTakeScreenShotDuringEntryExit);
            //Wait For Pop Up Window Load
            base.WaitUntilWindowLoads(CourseEnrollmentModePageResource.
              CourseEnrollmentMode_Page_EditEnrollmentMode_Window_Title_Name);
            //Select Window
            base.SelectWindow(CourseEnrollmentModePageResource.
              CourseEnrollmentMode_Page_EditEnrollmentMode_Window_Title_Name);
            Logger.LogMethodExit("CourseEnrollmentModePage",
               "SelectEditEnrollmentModePopUpWindow", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Cancel Button In Enrollment Window.
        /// </summary>
        public void ClickCancelButton()
        {
            Logger.LogMethodEntry("CourseEnrollmentModePage",
               "ClickCancelButton", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.XPath(CourseEnrollmentModePageResource.
                    CourseEnrollmentMode_Page_Cancel_ImageButton_XPath_Locator));
                //Click on Button Cancel
                base.ClickButtonByXPath(CourseEnrollmentModePageResource.
                    CourseEnrollmentMode_Page_Cancel_ImageButton_XPath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseEnrollmentModePage",
               "ClickCancelButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select CCNGIntegration PointID Checkbox.
        /// </summary>
        public void SelectCCNGIntegrationPointIDCheckbox()
        {
            //Select CCNGIntegration PointID Checkbox
            Logger.LogMethodEntry("CourseEnrollmentModePage",
                "SelectCCNGIntegrationPointIDCheckbox",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(CourseEnrollmentModePageResource.
                    CourseEnrollmentMode_Page_CCNGIntegrationPointId_Checkbox_Id_Locator));
                IWebElement getIntegrationPointIDCheckbox = base.GetWebElementPropertiesById
                    (CourseEnrollmentModePageResource.
                    CourseEnrollmentMode_Page_CCNGIntegrationPointId_Checkbox_Id_Locator);
                //Select the CCNG Integration PointID checkbox
                base.ClickByJavaScriptExecutor(getIntegrationPointIDCheckbox);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseEnrollmentModePage",
              "SelectCCNGIntegrationPointIDCheckbox", 
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Hide In Catalog Preference.
        /// </summary>
        public void EnableHideInCatalogPreference()
        {
            //Enable Hide In Catalog Preference
            Logger.LogMethodEntry("CourseEnrollmentModePage",
                "EnableHideInCatalogPreference",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectEditEnrollmentModePopUpWindow();
                base.WaitForElement(By.Id(CourseEnrollmentModePageResource.
                    CourseEnrollmentMode_Page_HideCatalog_Id_Locator));
                //Select 'Hide in Catalog' Preference
                base.SelectCheckBoxById(CourseEnrollmentModePageResource.
                    CourseEnrollmentMode_Page_HideCatalog_Id_Locator);
                base.WaitForElement(By.Id(CourseEnrollmentModePageResource.
                    CourseEnrollmentMode_Page_Update_Button_Id_Locator));
                //Click on Update button
                IWebElement getUpdateButton = 
                    base.GetWebElementPropertiesById(CourseEnrollmentModePageResource.
                    CourseEnrollmentMode_Page_Update_Button_Id_Locator);
                base.ClickByJavaScriptExecutor(getUpdateButton);
                base.SwitchToLastOpenedWindow();        
                if (base.IsWindowsExists(CourseEnrollmentModePageResource.
                CourseEnrollmentMode_Page_Pegasus_Window_Name,
                Convert.ToInt32(CourseEnrollmentModePageResource.
                CourseEnrollmentMode_Page_Wait_Time)))
                {
                    //Select Pegasus Window
                    this.SelectPegasusWindow();
                    base.WaitForElement(By.Id(CourseEnrollmentModePageResource.
                        CourseEnrollmentMode_Page_Ok_Button_Id_Locator));
                    //Click on Ok button in Alert Popup
                    base.ClickButtonById(CourseEnrollmentModePageResource.
                        CourseEnrollmentMode_Page_Ok_Button_Id_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseEnrollmentModePage",
              "EnableHideInCatalogPreference",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Pegasus Window.
        /// </summary>
        private void SelectPegasusWindow()
        {
            //Select Pegasus Window
            Logger.LogMethodEntry("CourseEnrollmentModePage",
                "SelectPegasusWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            base.WaitUntilWindowLoads(CourseEnrollmentModePageResource.
                CourseEnrollmentMode_Page_Pegasus_Window_Name);
            base.SelectWindow(CourseEnrollmentModePageResource.
                CourseEnrollmentMode_Page_Pegasus_Window_Name);
            Logger.LogMethodExit("CourseEnrollmentModePage",
              "SelectPegasusWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

    }
}