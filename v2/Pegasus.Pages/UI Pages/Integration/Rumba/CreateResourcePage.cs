using System;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Integration.Rumba;
using System.Configuration;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles create resource page actions.
    /// </summary>
    public class CreateResourcePage : BasePage
    {
        // Static instance of the logger.
        private static readonly Logger logger = Logger.
            GetInstance(typeof(CreateResourcePage));

        /// <summary>
        /// Creates Rumba Resource.
        /// </summary>
        public void CreateRumbaResource()
        {
            //Creates Resource
            logger.LogMethodEntry("CreateResourcePage", "CreateRumbaResource",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generating new guid for resource name
                Guid resourcename = Guid.NewGuid();
                //Enter the Resource Details
                this.EnterResourceDetails(resourcename);
                //Enter The Display Information
                this.EnterTheDisplayInformation();
                //Wait For Element
                base.WaitForElement(By.Id(CreateResourcePageResource.
                    CreateResource_Page_CreateResource_Button_Id_Locator));
                IWebElement getCreateresourceButton=base.GetWebElementPropertiesById
                    (CreateResourcePageResource.
                    CreateResource_Page_CreateResource_Button_Id_Locator);
                //Click on Create Resource
                base.ClickByJavaScriptExecutor(getCreateresourceButton);
                base.SelectWindow(CreateResourcePageResource.
                    CreateResource_Page_Window_PartialTitle_Name + resourcename);
                //Gets the Resource Id
                int resourceID = GetRumbaResourceId();
                //Save the Resource Id in Memory
                StoreRumbaResourceIdInMemory(resourceID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateResourcePage", "CreateRumbaResource",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter The Display Information.
        /// </summary>
        private void EnterTheDisplayInformation()
        {
           //Enter The Display Information
            logger.LogMethodEntry("CreateResourcePage", "EnterTheDisplayInformation",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(CreateResourcePageResource.
                CreateResource_Page_DisplayInformation_Image_Xpath_Locator));
            IWebElement getDisplayInformation = base.GetWebElementPropertiesByXPath
                (CreateResourcePageResource.
                CreateResource_Page_DisplayInformation_Image_Xpath_Locator);
            //Click the Display Information
            base.ClickByJavaScriptExecutor(getDisplayInformation);
            //Wait for the element
            base.WaitForElement(By.XPath(CreateResourcePageResource.
                CreateResource_Page_DefaultLanguage_Image_Xpath_Locator));
            IWebElement getDefaultLanguages = base.GetWebElementPropertiesByXPath
                (CreateResourcePageResource.
                CreateResource_Page_DefaultLanguage_Image_Xpath_Locator);
            //Click the Default Languages
            base.ClickByJavaScriptExecutor(getDefaultLanguages);
            //Enter The Display Information Details
            new CreateProductPage().EnterTheDisplayInformationDetails();
            logger.LogMethodExit("CreateResourcePage", "EnterTheDisplayInformation",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Resource Details.
        /// </summary>
        /// <param name="resourcename">This is Resource Name.</param>
        private void EnterResourceDetails(Guid resourcename)
        {
            // Enter Resource Details
            logger.LogMethodEntry("CreateResourcePage", "EnterResourceDetails",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(CreateResourcePageResource.
                CreateResource_Page_Window_Title_Name);
            //Selects the Window
            base.SelectWindow(CreateResourcePageResource.
                CreateResource_Page_Window_Title_Name);
            base.WaitForElement(By.Id(CreateResourcePageResource.
                CreateResource_Page_Resourcename_Text_Id_Locator));
            //Enter Name, Description And Url
            this.EnterNameDescriptionAndUrl(resourcename);
            //Wait For Element
            base.WaitForElement(By.Id(CreateResourcePageResource.
                CreateResource_Page_BusinessUnit_Id_Locator));
            //Selects School Curiculum
            IWebElement getAutocompleteText = base.GetWebElementPropertiesById
                (CreateResourcePageResource.
                CreateResource_Page_BusinessUnit_Id_Locator);
            //Perform Element Focus
            base.PerformMoveToElementAction(getAutocompleteText);
            //Select Business Unit
            SelectRumbaBusinessUnitFromAutoFill(getAutocompleteText);
            logger.LogMethodExit("CreateResourcePage", "EnterResourceDetails",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Rumba Business Unit.
        /// </summary>
        /// <param name="getAutocompleteText">This is AutoFill Menu Item.</param>
        private void SelectRumbaBusinessUnitFromAutoFill(IWebElement getAutocompleteText)
        {
            //Select Pearson Business Unit Menu Item
            logger.LogMethodEntry("CreateResourcePage", "SelectRumbaBusinessUnitFromAutoFill",
               base.IsTakeScreenShotDuringEntryExit);
            //Clear Text Box Pre Filled Value
            base.ClearTextById(CreateResourcePageResource.
                CreateResource_Page_BusinessUnit_Id_Locator);
            getAutocompleteText.SendKeys(CreateResourcePageResource.
                CreateResource_Page_BusinessUnit_Value);
            Thread.Sleep(Convert.ToInt32(CreateResourcePageResource.
                CreateResource_Page_ThreadTime_Value));
            //Wait for Element
            base.WaitForElement(By.CssSelector(CreateResourcePageResource.
                CreateResource_Page_BusinessUnit_CssSelector));
            //Get AutoFill Menu Item
            IWebElement getAutoFillElement = WebDriver.FindElement(By.CssSelector
                (CreateResourcePageResource.CreateResource_Page_BusinessUnit_CssSelector));
            getAutoFillElement.Click();
            base.FocusOnElementById(CreateResourcePageResource.
                CreateResource_Page_AuthorizationContextName_Id_Locator);
            //Select AutoFill Menu Item
            base.SelectDropDownValueThroughTextById(CreateResourcePageResource.
                CreateResource_Page_AuthorizationContextName_Id_Locator,
                CreateResourcePageResource.CreateResource_Page_AuthorizationContextName_SelectText);
            logger.LogMethodExit("CreateResourcePage", "SelectRumbaBusinessUnitFromAutoFill",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Name Description And Url.
        /// </summary>
        /// <param name="resourceName">This Is Resource Name.</param>
        private void EnterNameDescriptionAndUrl(Guid resourceName)
        {
            //Enter Name Description And Url
            logger.LogMethodEntry("CreateResourcePage", "EnterNameDescriptionAndUrl",
                base.IsTakeScreenShotDuringEntryExit);
            //Fills the Resource Name
            base.FillTextBoxById(CreateResourcePageResource.
                CreateResource_Page_Resourcename_Text_Id_Locator, resourceName.ToString());
            base.WaitForElement(By.Id(CreateResourcePageResource.
                CreateResource_Page_InternalDescription_Text_Id_Locator));
            //Fills the Description
            base.FillTextBoxById(CreateResourcePageResource.
                CreateResource_Page_InternalDescription_Text_Id_Locator,
                resourceName.ToString());
            base.WaitForElement(By.Id(CreateResourcePageResource.
                CreateResource_Page_DigitAssetURL_Text_Id_Locator));
            //Get Digit Asset URL
            string getDigitAssetUrl = AutomationConfigurationManager.CourseSpaceUrlRoot +
                CreateResourcePageResource.CreateResource_Page_DigitAssetURL_Url;
            //Fills the Url
            base.FillTextBoxById(CreateResourcePageResource.
                CreateResource_Page_DigitAssetURL_Text_Id_Locator, getDigitAssetUrl);
            logger.LogMethodExit("CreateResourcePage", "EnterNameDescriptionAndUrl",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save the Rumba Resource Id in Memory.
        /// </summary>
        /// <param name="resourceID">This is Resource Id.</param>
        private void StoreRumbaResourceIdInMemory(int resourceID)
        {
            //Save the Resource Id in Memory
            logger.LogMethodEntry("CreateResourcePage", "StoreRumbaResourceIdInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            //Store the Resource Details in Memory
            License license = License.Get(License.LicenseTypeEnum.Rumba);
            license.ResourceID = resourceID;
            logger.LogMethodExit("CreateResourcePage", "StoreRumbaResourceIdInMemory",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get The Rumba Resource ID.
        /// </summary>
        /// <returns>Resource ID.</returns>
        public int GetRumbaResourceId()
        {
            //Get The Resource ID
            logger.LogMethodEntry("CreateResourcePage", "GetRumbaResourceId",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            int getResourceId = Convert.ToInt32(CreateResourcePageResource.
                CreateResource_Page_ResourceId_DefaultValue);
            try
            {
                //Get Resource Id 
                string getresourceID = base.GetElementTextByXPath(CreateResourcePageResource.
                        CreateResource_Page_GetResourceId_Xpath);
                string[] splitResourseID = getresourceID.Split(Convert.ToChar
                    (CreateResourcePageResource.CreateResource_Page_Split_Space_Value));
                // Convert And Get Resource ID
                getResourceId = Convert.ToInt32(splitResourseID[2]);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateResourcePage", "GetRumbaResourceId",
                base.IsTakeScreenShotDuringEntryExit);
            return getResourceId;
        }
    }
}
