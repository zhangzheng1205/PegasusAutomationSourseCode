using System;
using System.Globalization;
using System.Threading;
using OpenQA.Selenium;
using System.Windows.Forms;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.Rumba;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles place order page actions.
    /// </summary>
    public class PlaceOrderPage : BasePage
    {
        //Static instance of the logger.
        private static readonly Logger Logger = Logger.
             GetInstance(typeof(PlaceOrderPage));

        ///  <summary>
        /// Place An Order for Organization License.
        ///  </summary>
        ///  <param name="organizationLevelEnum">This is organization level enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        public void PlaceOrganizationLicenseOrder(Organization.OrganizationLevelEnum
            organizationLevelEnum, Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Place An Order for Organization License 
            Logger.LogMethodEntry("PlaceOrderPage", "PlaceOrganizationLicenseOrder",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for element
                base.WaitForElement(By.Id(PlaceOrderPageResource.
                        PlaceOrder_Page_Select_OrderingSystem_Id_Locator));
                base.FocusOnElementById(PlaceOrderPageResource.
                    PlaceOrder_Page_Select_OrderingSystem_Id_Locator);
                //Selects the Ordering system
                base.SelectDropDownValueThroughTextById(PlaceOrderPageResource.
                    PlaceOrder_Page_Select_OrderingSystem_Id_Locator,
                    PlaceOrderPageResource.
                    PlaceOrder_Page_Select_OrderingSystem_Value);
                //Wait for element
                base.WaitForElement(By.Id(PlaceOrderPageResource.
                    PlaceOrder_Page_OrderId_Id_Locator));
                base.FocusOnElementById(PlaceOrderPageResource.
                    PlaceOrder_Page_OrderId_Id_Locator);
                //Enter Rumba Lincense Detail
                this.EnterRumbaLicenseDetail(organizationLevelEnum, organizationTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PlaceOrderPage", "PlaceOrganizationLicenseOrder",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Rumba License Details.
        /// </summary>
        /// <param name="organizationLevelEnum">This is organization level enum.</param>
        /// <param name="organizationTypeEnum">This is organization type wnum.</param>
        private void EnterRumbaLicenseDetail(Organization.OrganizationLevelEnum
            organizationLevelEnum, Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Enter License Details
            Logger.LogMethodEntry("PlaceOrderPage", "EnterRumbaLicenseDetail",
                base.isTakeScreenShotDuringEntryExit);
            //Get Rumba License Information
            License license = License.Get(License.LicenseTypeEnum.Rumba);
            //Enter License Order ID
            base.FillTextBoxById(PlaceOrderPageResource.
               PlaceOrder_Page_OrderId_Id_Locator, license.OrderId);
            //Get State Level Organization
            Organization organization = Organization.
                Get(organizationLevelEnum, organizationTypeEnum);
            //Select Organization
            this.SelectOrganization(organization.Name);
            //Enter Line Item Id And License Type
            this.EnterLineItemIDAndLicenseType();
            //Enter License Start Date And End Date and Quantity
            this.EnterlLicenseStartEndDateAndQuantity();
            //Enter Product External Id
            this.EnterProductExternalID();
            //Click On Submit
            this.ClickOnSubmitButton();
            Logger.LogMethodExit("PlaceOrderPage", "EnterRumbaLicenseDetail",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Submit Button.
        /// </summary>
        private void ClickOnSubmitButton()
        {
            //Click On Submit Button
            Logger.LogMethodEntry("PlaceOrderPage", "ClickOnSubmitButton",
                base.isTakeScreenShotDuringEntryExit);
            base.FocusOnElementById(PlaceOrderPageResource.
                PlaceOrder_page_SubmitButton_Id_Locator);
            //Get Button Property
            IWebElement getButtonProperty = base.GetWebElementPropertiesById
                (PlaceOrderPageResource.PlaceOrder_page_SubmitButton_Id_Locator);
            //Click On Submit Button
            base.ClickByJavaScriptExecutor(getButtonProperty);
            Logger.LogMethodExit("PlaceOrderPage", "ClickOnSubmitButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Product External Id.
        /// </summary>
        private void EnterProductExternalID()
        {
            //Enter Product External Id
            Logger.LogMethodEntry("PlaceOrderPage", "EnterProductExternalID",
                base.isTakeScreenShotDuringEntryExit);
            //Get The Order Id From Memory
            License license = License.Get(License.LicenseTypeEnum.Rumba);
            //Wait For Element
            base.WaitForElement(By.Id(PlaceOrderPageResource.
                PlaceOrder_page_ProductExternalId_Id_Locator));
            //Fill 13 Digit Order ID
            base.FillTextBoxById(PlaceOrderPageResource.
                PlaceOrder_page_ProductExternalId_Id_Locator,
                license.OrderId);
            //Sleep for a Time
            Thread.Sleep(Convert.ToInt32(PlaceOrderPageResource.
                PlaceOrder_Page_ThreadSleepTime));
            Logger.LogMethodExit("PlaceOrderPage", "EnterProductExternalID",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Start Date And End Date and License Quantity.
        /// </summary>
        private void EnterlLicenseStartEndDateAndQuantity()
        {
            // Fill Start Date And End Date And License Quantity
            Logger.LogMethodEntry("PlaceOrderPage", "EnterlLicenseStartEndDateAndQuantity",
                base.isTakeScreenShotDuringEntryExit);
            //Get Start Date And End Date
            string date = DateTime.Now.ToLongDateString();
            string[] day = date.Split(Convert.ToChar
                (CreateResourcePageResource.CreateResource_Page_Split_Space_Value));
            string startDate = day[1] + PlaceOrderPageResource.
                PlaceOrder_Page_SpaceValue + day[2] + PlaceOrderPageResource.
                PlaceOrder_Page_SpaceValue + day[3];
            //Get End Year
            int endYear = Convert.ToInt32(day[3]) + 1;
            string endDate = day[1] + string.Empty + day[2] + string.Empty +
                endYear.ToString(CultureInfo.InvariantCulture);
            //Enter Start Date
            base.FillTextBoxById(PlaceOrderPageResource.
                PlaceOrder_Page_StartDate_Id_Locator, startDate);
            //Enter End Date
            base.FillTextBoxById(PlaceOrderPageResource.
                PlaceOrder_Page_EndDate_Id_Locator, endDate);
            //Enter License Quantity
            base.FillTextBoxById(PlaceOrderPageResource.
                PlaceOrder_Page_LicenseQuantity_Id_Locator,
                PlaceOrderPageResource.PlaceOrder_Page_LicenseQuantity_Value);
            Logger.LogMethodExit("PlaceOrderPage", "EnterlLicenseStartEndDateAndQuantity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Line Item Id And License Type.
        /// </summary>
        private void EnterLineItemIDAndLicenseType()
        {
            //Enter Line Item Id And License Type            
            Logger.LogMethodEntry("PlaceOrderPage", "EnterLineItemIDAndLicenseType",
                base.isTakeScreenShotDuringEntryExit);
            //Enter Line Item Id
            base.WaitForElement(By.Id(PlaceOrderPageResource.
                PlaceOrder_Page_LineItemId_Text_Id_Locator));
            base.FillTextBoxById(PlaceOrderPageResource.
                PlaceOrder_Page_LineItemId_Text_Id_Locator,
                PlaceOrderPageResource.PlaceOrder_Page_LineItemId_Value);
            //Enter License Type
            base.FocusOnElementById(PlaceOrderPageResource.
                PlaceOrder_Page_SelectLicenseType_Id_Locator);
            //Select Value
            base.SelectDropDownValueThroughTextById(PlaceOrderPageResource.
                PlaceOrder_Page_SelectLicenseType_Id_Locator,
                PlaceOrderPageResource.PlaceOrder_Page_LicenseTypeValue);
            Logger.LogMethodExit("PlaceOrderPage", "EnterLineItemIDAndLicenseType",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selects Organization.
        /// </summary>
        /// <param name="organizationName">This Is Organization Name.</param>
        private void SelectOrganization(String organizationName)
        {
            //Selects Organization
            Logger.LogMethodEntry("PlaceOrderPage", "SelectOrganization",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(PlaceOrderPageResource.
                PlaceOrder_Page_OrganizationName_Id_Locator));
            //Clear Text Box            
            base.ClearTextById(PlaceOrderPageResource.
                PlaceOrder_Page_OrganizationName_Id_Locator);
            //Get Autocomplete Property
            IWebElement getAutocompleteElement = GetWebElementPropertiesById(PlaceOrderPageResource.
                PlaceOrder_Page_OrganizationName_Id_Locator);
            //Focus on Element
            base.PerformMoveToElementAction(getAutocompleteElement);
            getAutocompleteElement.SendKeys(organizationName);
            //Wait For Element
            base.WaitForElement(By.CssSelector(PlaceOrderPageResource.
                PlaceOrder_Page_Organization_Css_Locator));
            //Get Element Property
            IWebElement autocompleteElement = GetWebElementPropertiesByCssSelector
                (PlaceOrderPageResource.PlaceOrder_Page_Organization_Css_Locator);
            //Clicks on selected text in autocomplete
            autocompleteElement.Click();
            Logger.LogMethodExit("PlaceOrderPage", "SelectOrganization",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Place Order Success Message.
        /// </summary>
        /// <returns>Success Message.</returns>
        public String GetCreateLicenseSuccessMessage()
        {
            // Get Place Order Success Message
            Logger.LogMethodEntry("PlaceOrderPage", "GetCreateLicenseSuccessMessage",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize variable
            string getSuccessMessage = string.Empty;
            try
            {
                //Select Window
                base.SelectWindow(PlaceOrderPageResource.
                    PlaceOrder_Page_Window_Title);
                //Wait for Element
                base.WaitForElement(By.XPath(PlaceOrderPageResource.
                        PlaceOrder_Page_SuccessMessage));
                //Get Create License Success Message
                getSuccessMessage = base.GetElementTextByXPath
                    (PlaceOrderPageResource.PlaceOrder_Page_SuccessMessage);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PlaceOrderPage", "GetCreateLicenseSuccessMessage",
                base.isTakeScreenShotDuringEntryExit);
            return getSuccessMessage;
        }
    }
}
