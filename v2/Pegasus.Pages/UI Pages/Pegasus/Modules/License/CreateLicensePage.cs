using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Templates;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes.Channels;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.License;
using Pegasus.Pages.Exceptions;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class handles Create License Page actions
    /// </summary>
    public class CreateLicensePage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(CreateLicensePage));


        /// <summary>
        /// Enter License Details
        /// </summary>
        public void EnterLicenseDetail(Product.ProductTypeEnum productType)
        {
            //Enter License Details
            logger.LogMethodEntry("CreateLicensePage", "EnterLicenseDetail",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get Start Date Value
                string getStartDate = DateTime.Now.ToString(CreateLicensePageResource.
                       CreateLicense_Page_FromDate_Value);
                //Get End Date Value
                string getEndDate = DateTime.Now.AddDays(90).ToString(CreateLicensePageResource.
                    CreateLicense_Page_ToDate_Value);
                //Wait for Create License Window
                base.WaitUntilWindowLoads(CreateLicensePageResource.CreateLicense_Page_Window_Title);
                base.SelectWindow(CreateLicensePageResource.CreateLicense_Page_Window_Title);
                base.WaitForElement(By.Id(CreateLicensePageResource.
                    CreateLicense_Page_FromDate_Input_Id_Locator));
                //Fill Start Date Value
                base.FillTextBoxById(CreateLicensePageResource.
                    CreateLicense_Page_FromDate_Input_Id_Locator, getStartDate);
                base.WaitForElement(By.Id(CreateLicensePageResource.
                    CreateLicense_Page_ToDate_Input_Id_Locator));
                //Fill End Date Value
                base.FillTextBoxById(CreateLicensePageResource.
                    CreateLicense_Page_ToDate_Input_Id_Locator, getEndDate);
                base.WaitForElement(By.Id(CreateLicensePageResource.
                    CreateLicense_Page_Quantity_Input_Id_Locator));
                //Fill License Qunatity
                base.FillTextBoxById(CreateLicensePageResource.
                    CreateLicense_Page_Quantity_Input_Id_Locator, CreateLicensePageResource.
                    CreateLicense_Page_Quantity_Input_Value);
                //Click on Save and Return Button
                this.ClickOnSaveAndReturnButton();
                //Wait to pop up get close
                if (base.IsPopUpClosed(3))
                {
                    //Store License Details In Memory
                    StoreTheLicenseDetailsInMemory(getStartDate, getEndDate, Convert.ToInt32(CreateLicensePageResource.
                    CreateLicense_Page_Quantity_Input_Value), productType);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateLicensePage", "EnterLicenseDetail",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Save and Return Button
        /// </summary>
        private void ClickOnSaveAndReturnButton()
        {
            //Click on Save and Return button
            logger.LogMethodEntry("CreateLicensePage", "ClickOnSaveAndReturnButton",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CreateLicensePageResource.
                CretaeLicense_Page_SaveandReturn_Id_Locator));
            //Get Save and Finish Button Property
            IWebElement getSaveandFinishButtonProperty = base.GetWebElementPropertiesById(CreateLicensePageResource.
                CretaeLicense_Page_SaveandReturn_Id_Locator);
            //Click on Save and Finish Button
            base.ClickByJavaScriptExecutor(getSaveandFinishButtonProperty);
            logger.LogMethodExit("CreateLicensePage", "ClickOnSaveAndReturnButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store License Details In Memory.
        /// </summary>
        /// <param name="startDate">This is license start date.</param>
        /// <param name="endDate">This is license end date.</param>
        /// <param name="licenseQuantity">This is license quantity.</param>
        private void StoreTheLicenseDetailsInMemory(string startDate, string endDate, int licenseQuantity, Product.ProductTypeEnum productType)
        {
            //Store the Activity content
            logger.LogMethodEntry("AddAssessmentPage", "StoreTheLicenseDetailsInMemory",
                 base.isTakeScreenShotDuringEntryExit);
            //Get product from memory
            Product product = Product.Get(productType);
            //Store the activity in memory
            License newLicense = new License
            {
                Name = product.Name,
                StartDate = startDate,
                EndDate = endDate,
                LicenseQuantity = licenseQuantity,
                LicenseType = License.LicenseTypeEnum.Pegasus,
                IsCreated = true,
            };
            newLicense.StoreLicenseInMemory();
            logger.LogMethodExit("AddAssessmentPage", "StoreTheLicenseDetailsInMemory",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
