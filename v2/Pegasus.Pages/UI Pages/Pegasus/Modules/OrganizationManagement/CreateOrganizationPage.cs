using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.OrganizationManagement;
using Pegasus.Pages.Exceptions;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the, action of different level's of Organization.
    /// </summary>
    public class CreateOrganizationPage : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(CreateOrganizationPage));

        /// <summary>
        /// This the enum available forOrganization level type Enum.
        /// </summary>
        public enum OrganizationMultipleSchoolTypeEnum
        {
            /// <summary>
            ///Organization Multiple School Type Enum
            /// </summary>
            School2 = 1,
            /// <summary>
            /// Organization Multiple School Type Enum
            /// </summary>
            School3,
        }

        /// <summary>
        /// Create Organization Based On Level of Organization.
        /// </summary>
        /// <param name="organizationLevelEnum">This is organization Level Enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        /// <param name="organizationCreationCondition">This is Organization Creation Condition.</param>
        public void CreateOrganizationInProductBasedOnLevel(
            Organization.OrganizationLevelEnum
            organizationLevelEnum,
            Organization.OrganizationTypeEnum organizationTypeEnum,
            string organizationCreationCondition)
        {
            //Create Organization Based On Level of Organization
            Logger.LogMethodEntry("CreateOrganizationPage",
                "CreateOrganizationInProductBasedOnLevel",
                 base.IsTakeScreenShotDuringEntryExit);
            //Guid for Organization Name
            Guid organizationNameGuid = Guid.NewGuid();
            try
            {
                if (organizationCreationCondition == CreateOrganizationPageResource.
                    CreateOrganization_Page_Organization_Creation_Condition_Text)
                {
                    switch (organizationLevelEnum)
                    {   //Create State Level Organization
                        case Organization.OrganizationLevelEnum.State:
                            //Created OrganizationPage Object
                            CreateOrganizationPage createOrganizationPage
                                = new CreateOrganizationPage();
                            //Select Organization Window
                            createOrganizationPage.SelectCreateOrganizationWindow();
                            //Create New Organization
                            createOrganizationPage.CreateNewOrganizationForDifferentLevels
                                (organizationLevelEnum, organizationTypeEnum);
                            break;
                        //Create District and Region Level Organization
                        case Organization.OrganizationLevelEnum.District:
                        case Organization.OrganizationLevelEnum.Region:
                            //Select District Level Organization and Create Region Level Organization
                            this.SelectAndCreateOrganization(organizationLevelEnum, organizationTypeEnum);
                            break;
                        //Create School Level Organization
                        case Organization.OrganizationLevelEnum.School:
                            try
                            {
                                //Select Region Level Organization and Create School level Organization
                                this.SelectAndCreateOrganization(organizationLevelEnum, organizationTypeEnum);
                            }
                            catch
                            {
                                //Click on New Organization Link
                                new OrganizationManagementPage().ClickOnTheCreateNewOrganizationLink();
                                //Create School Level Orgnization
                                this.CreateSchoolLevelOrganization(organizationLevelEnum, organizationTypeEnum);
                            }
                            this.SelectOrganizationManagementWindow();
                            break;
                        //Create School Level Organization
                        case Organization.OrganizationLevelEnum.PowerSchool:
                            //Click on New Organization Link
                            new OrganizationManagementPage().ClickOnTheCreateNewOrganizationLink();
                            //Create School Level Orgnization
                            this.CreateSchoolLevelOrganization(organizationLevelEnum, organizationTypeEnum);
                            //Select Organization Management Window
                            this.SelectOrganizationManagementWindow();
                            break;
                    }
                }
                    else
                    {
                        switch (organizationLevelEnum)
                        {
                            case Organization.OrganizationLevelEnum.School:
                                this.CreateSchoolLevelOrganization(
                                    organizationLevelEnum, organizationTypeEnum, organizationNameGuid);
                                break;
                        }
                    
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CreateOrganizationPage",
                "CreateOrganizationInProductBasedOnLevel",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create School Level Organization.
        /// </summary>
        /// <param name="organizationLevelEnum">This is Organization Level Enum.</param>
        /// <param name="organizationTypeEnum">This is Organization Type Enum.</param>
        /// <param name="organizationNameGuid">This is Organization Name GUID.</param>
        private void CreateSchoolLevelOrganization(
            Organization.OrganizationLevelEnum organizationLevelEnum,
            Organization.OrganizationTypeEnum organizationTypeEnum,
            Guid organizationNameGuid)
        {
            ///Create School Level Organization
            Logger.LogMethodEntry("CreateOrganizationPage", "CreateSchoolLevelOrganization",
                 base.IsTakeScreenShotDuringEntryExit);
            if (organizationTypeEnum != Organization.OrganizationTypeEnum.DigitalPathDemo)
            {
                //Select Organization Management Window
                this.SelectOrganizationManagementWindow();
                //Click on New Organization Link
                new OrganizationManagementPage().ClickOnTheCreateNewOrganizationLink();
                //Select Organization Window
                new CreateOrganizationPage().SelectCreateOrganizationWindow();
            }
            //Select Country
            this.SelectCountryOptionForStateLevelOrganization();
            // Fill Internal Organization Name
            this.FillInternalOrganizationName(organizationNameGuid);
            //Fill Organization Display Name
            FillOrganizationDisplayName();
            if (organizationTypeEnum == Organization.OrganizationTypeEnum.DigitalPathDemo)
            {
                base.WaitForElement(By.Id(CreateOrganizationPageResource.
                    CreateOrganization_Page_DemoOrganisation_CheckBox_Id_Locator));
                //Click Demo Organisation CheckBox
                IWebElement demoOrganizationCheckbox = base.GetWebElementPropertiesById
                    (CreateOrganizationPageResource.CreateOrganization_Page_DemoOrganisation_CheckBox_Id_Locator);
                base.ClickByJavaScriptExecutor(demoOrganizationCheckbox);
            }
            //Fill Organization Contact Details
            this.FillOrganizationContactDetails(organizationNameGuid);
            //Select Organization Type Based on Level
            this.SelectOrganizationTypeCheckBox(organizationLevelEnum);
            //Remove State Region and District Level Organization
            this.RemoveStateRegionandDistrictLevelOrganization();
            //Click on Button To Save Organization
            this.ClickOnButtonToSaveOrganization();
            //Wait Pop Up Get Close
            if (base.IsPopUpClosed(2))
            {
                //Store the organization details
                this.StoreTheOrganizationDetails(organizationNameGuid,
                    organizationLevelEnum, organizationTypeEnum);
            }
            Logger.LogMethodExit("CreateOrganizationPage", "CreateSchoolLevelOrganization",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Remove State Region and District Level Organization.
        /// </summary>
        private void RemoveStateRegionandDistrictLevelOrganization()
        {
            //Remove State Region and District Level Organization
            Logger.LogMethodEntry("CreateOrganizationPage",
                "RemoveStateRegionandDistrictLevelOrganization",
                 base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(CreateOrganizationPageResource.
                CreateOrganization_Page_State_Organization_Checkbox_Xpath_Locator));
            //Select State Level Organization
            base.SelectCheckBoxByXPath(CreateOrganizationPageResource.
                CreateOrganization_Page_State_Organization_Checkbox_Xpath_Locator);
            base.WaitForElement(By.XPath(CreateOrganizationPageResource.
                CreateOrganization_Page_Region_Organization_Checkbox_Xpath_Locator));
            //Select Region Level Organization
            base.SelectCheckBoxByXPath(CreateOrganizationPageResource.
                CreateOrganization_Page_Region_Organization_Checkbox_Xpath_Locator);
            base.WaitForElement(By.XPath(CreateOrganizationPageResource.
                CreateOrganization_Page_District_Organization_Checkbox_Xpath_Locator));
            //Select District Level Organization
            base.SelectCheckBoxByXPath(CreateOrganizationPageResource.
                CreateOrganization_Page_District_Organization_Checkbox_Xpath_Locator);
            base.WaitForElement(By.Id(CreateOrganizationPageResource.
                CreateOrganization_Page_Remove_Button_Id_Locator));
            //Click on Remove Button
            IWebElement getRemoveButton = 
                base.GetWebElementPropertiesById(CreateOrganizationPageResource.
                CreateOrganization_Page_Remove_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(getRemoveButton);
            Logger.LogMethodExit("CreateOrganizationPage",
                "RemoveStateRegionandDistrictLevelOrganization",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Organization Management Window.
        /// </summary>
        private void SelectOrganizationManagementWindow()
        {
            //Log Method Entry
            Logger.LogMethodEntry("CreateOrganizationPage",
              "SelectOrganizationManagementWindow",
             base.IsTakeScreenShotDuringEntryExit);
            //Wait For Window
            base.WaitUntilPageGetSwitchedSuccessfully(CreateOrganizationPageResource.
                CreateOrganization_Page_OrganizationManagement_Window_Name);
            //Select Organization Window
            base.SelectWindow(CreateOrganizationPageResource.
                CreateOrganization_Page_OrganizationManagement_Window_Name);
            //Log Method Exists
            Logger.LogMethodExit("CreateOrganizationPage",
              "SelectOrganizationManagementWindow",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Root Level Organization and Create Organization.
        /// </summary>
        /// <param name="organizationLevelEnum">This is the organization level by type.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        private void SelectAndCreateOrganization(
            Organization.OrganizationLevelEnum organizationLevelEnum,
            Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Select Root Level Organization and Create Organization
            Logger.LogMethodEntry("CreateOrganizationPage", "SelectAndCreateOrganization",
                base.IsTakeScreenShotDuringEntryExit);
            //Click on Select Button Of Organization
            new OrganizationManagementPage().ClickOnTheOrganizationSelectButton();
            //Click on Add Organization Link 
            new OrganizationSearchPage().ClickOnTheAddOrganizationLink();
            //Select the Organization Window
            this.SelectCreateOrganizationWindow();
            //Create New Organization Level
            this.CreateNewOrganizationForDifferentLevels(
                organizationLevelEnum, organizationTypeEnum);
            Logger.LogMethodExit("CreateOrganizationPage", "SelectAndCreateOrganization",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create School Level Organization.
        /// </summary>
        /// <param name="organizationLevelEnum">This is the organization level enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        private void CreateSchoolLevelOrganization(
            Organization.OrganizationLevelEnum
           organizationLevelEnum, Organization.OrganizationTypeEnum
            organizationTypeEnum)
        {
            //Create School Level Organization
            Logger.LogMethodEntry("CreateOrganizationPage", "CreateSchoolLevelOrganization",
                 base.IsTakeScreenShotDuringEntryExit);
            //Intialize Guid for organization
            Guid organizationNameGuid = Guid.NewGuid();
            //Enter Organization Name
            this.EnterOrganizationName(organizationNameGuid);
            //Fill Organization Contact Details
            this.FillOrganizationContactDetails(organizationNameGuid);
            //Select School Level Organization
            this.SelectSchoolLevelOrganization();
            //Select State
            this.SelectOrganizationState();
            //Select Organization Type Based on Level
            this.SelectOrganizationTypeCheckBox(organizationLevelEnum);
            //Click on Save Button
            this.ClickOnButtonToSaveOrganization();
            //Wait Pop Up Get Close
            if (base.IsPopUpClosed(2))
            {
                //Store the organization details
                this.StoreTheOrganizationDetails(organizationNameGuid,
                    organizationLevelEnum, organizationTypeEnum);
            }
            Logger.LogMethodExit("CreateOrganizationPage", "CreateSchoolLevelOrganization",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Organization Name.
        /// </summary>
        /// <param name="organizationNameGuid">This is Organization name guid.</param>
        private void EnterOrganizationName(Guid organizationNameGuid)
        {
            Logger.LogMethodEntry("CreateOrganizationPage", "EnterOrganizationName",
                 base.IsTakeScreenShotDuringEntryExit);
            //Wait for the Internal Organization text box element to display
            base.WaitForElement(By.Id(CreateOrganizationPageResource.
             CreateOrganization_Page_InternalOrganizationName_TextBox_Id_Locator));
            base.GetWebElementPropertiesById(CreateOrganizationPageResource.
            CreateOrganization_Page_InternalOrganizationName_TextBox_Id_Locator).Clear();
            //Fill the Internal Organization name in text box
            base.GetWebElementPropertiesById(CreateOrganizationPageResource.
             CreateOrganization_Page_InternalOrganizationName_TextBox_Id_Locator).
              SendKeys(organizationNameGuid.ToString());
            //Wait for the Organization display text box element to display
            base.WaitForElement(By.Id(CreateOrganizationPageResource.
              CreateOrganization_Page_OrganizationdisplayName_TextBox_Id_Locator));
            base.GetWebElementPropertiesById(CreateOrganizationPageResource.
              CreateOrganization_Page_OrganizationdisplayName_TextBox_Id_Locator).Clear();
            //Focus on the display name
            base.FocusOnElementById(CreateOrganizationPageResource.
             CreateOrganization_Page_OrganizationdisplayName_TextBox_Id_Locator);
            Logger.LogMethodExit("CreateOrganizationPage", "EnterOrganizationName",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select School Level Organization.
        /// </summary>
        private void SelectSchoolLevelOrganization()
        {
            //Select School Level Organization
            Logger.LogMethodEntry("CreateOrganizationPage", "SelectSchoolLevelOrganization",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for State Level CheckBox
            base.WaitForElement(By.XPath(CreateOrganizationPageResource.
                CreateOrganization_Page_StateLevel_CheckBox_Xpath_Locator));
            base.FocusOnElementByXPath(CreateOrganizationPageResource.
                CreateOrganization_Page_StateLevel_CheckBox_Xpath_Locator);
            //Click on Check Box of State Level
            base.ClickButtonByXPath(CreateOrganizationPageResource.
                CreateOrganization_Page_StateLevel_CheckBox_Xpath_Locator);
            //Wait for Region Level CheckBox
            base.WaitForElement(By.XPath(CreateOrganizationPageResource.
                CreateOrganization_Page_RegionLevel_Checkbox_Xpath_Locator));
            base.FocusOnElementByXPath(CreateOrganizationPageResource.
                CreateOrganization_Page_RegionLevel_Checkbox_Xpath_Locator);
            //Click on Check Box of Region Level
            base.ClickButtonByXPath(CreateOrganizationPageResource.
                CreateOrganization_Page_RegionLevel_Checkbox_Xpath_Locator);
            //Wait for District Level Checkbox
            base.WaitForElement(By.XPath(CreateOrganizationPageResource.
                CreateOrganization_Page_DistrictLevel_CheckBox_Xpath_Locator));
            base.FocusOnElementByXPath(CreateOrganizationPageResource.
                CreateOrganization_Page_DistrictLevel_CheckBox_Xpath_Locator);
            base.ClickButtonByXPath(CreateOrganizationPageResource.
                CreateOrganization_Page_DistrictLevel_CheckBox_Xpath_Locator);
            //Wait for Remove Button
            base.WaitForElement(By.Id(CreateOrganizationPageResource.
                CreateOrganization_Page_RemoveButton_Id_Locator));
            //Click On Remove Button
            base.ClickButtonById(CreateOrganizationPageResource.
                CreateOrganization_Page_RemoveButton_Id_Locator);
            Logger.LogMethodExit("CreateOrganizationPage", "SelectSchoolLevelOrganization",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To create And Edit The different Levels of Organization.
        /// </summary>
        /// <param name="organizationLevelEnum">This is the organization level enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        public void CreateNewOrganizationForDifferentLevels
            (Organization.OrganizationLevelEnum organizationLevelEnum,
            Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Create And edit the organization details
            Logger.LogMethodEntry("CreateOrganizationPage",
                "CreateNewOrganizationForDifferentLevels",
                 base.IsTakeScreenShotDuringEntryExit);
            //Guid for Organization Name
            Guid organizationNameGuid = Guid.NewGuid();
            try
            {
                switch (organizationLevelEnum)
                {
                    //Organization Level is State
                    case Organization.OrganizationLevelEnum.State:
                        {
                            //Select Country
                            this.SelectCountryOptionForStateLevelOrganization();
                        }
                        break;
                }
                //Create New Organization Level(s)
                this.FillDetailsForNewOrganizationLevels(
                    organizationNameGuid, organizationLevelEnum);
                //Wait Pop Up Get Close
                if (base.IsPopUpClosed(2))
                {
                    //Store the organization details
                    this.StoreTheOrganizationDetails(organizationNameGuid,
                        organizationLevelEnum, organizationTypeEnum);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CreateOrganizationPage",
                "CreateNewOrganizationForDifferentLevels",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Country Option For State Level Organization.
        /// </summary>
        private void SelectCountryOptionForStateLevelOrganization()
        {
            //Log Method Entry
            Logger.LogMethodEntry("CreateOrganizationPage",
                "SelectCountryOptionForStateLevelOrganization",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(CreateOrganizationPageResource.
                CreateOrganization_Page_Country_dropdown_Id_Locator));
            //Select the Country Details           
            base.SelectDropDownValueThroughIndexById(CreateOrganizationPageResource.
                CreateOrganization_Page_Country_dropdown_Id_Locator,
                Convert.ToInt32(CreateOrganizationPageResource.
                    CreateOrganization_Page_Country_dropdown_Id_Locator_Value));
            //Log Method Exit
            Logger.LogMethodExit("CreateOrganizationPage",
                "SelectCountryOptionForStateLevelOrganization",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Details For New Organization Levels.
        /// </summary>
        /// <param name="organization">This is organization name guid.</param>
        /// <param name="organizationLevelEnum">This is organization level enum.</param>
        private void FillDetailsForNewOrganizationLevels(
            Guid organization, Organization.
            OrganizationLevelEnum organizationLevelEnum)
        {
            //Fill Details For New Organization
            Logger.LogMethodEntry("CreateOrganizationPage", "FillDetailsForNewOrganizationLevels",
                 base.IsTakeScreenShotDuringEntryExit);
            // Fill Internal Organization Name
            this.FillInternalOrganizationName(organization);
            //Fill Organization Display Name
            FillOrganizationDisplayName();
            //Fill Organization Contact Details
            this.FillOrganizationContactDetails(organization);
            //Select Organization Type Based on Level
            this.SelectOrganizationTypeCheckBox(organizationLevelEnum);
            //Click on Button To Save Organization
            this.ClickOnButtonToSaveOrganization();
            Logger.LogMethodExit("CreateOrganizationPage", "FillDetailsForNewOrganizationLevels",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Organization Display Name.
        /// </summary>
        private void FillOrganizationDisplayName()
        {
            //Log Entry of Method
            Logger.LogMethodEntry("CreateOrganizationPage", "FillOrganizationDisplayName",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the Organization display text box element to display
            base.WaitForElement(By.Id(CreateOrganizationPageResource.
                CreateOrganization_Page_OrganizationdisplayName_TextBox_Id_Locator));
            base.GetWebElementPropertiesById(CreateOrganizationPageResource.
                CreateOrganization_Page_OrganizationdisplayName_TextBox_Id_Locator).Clear();
            //Focus on the display name
            base.FocusOnElementById(CreateOrganizationPageResource.
                CreateOrganization_Page_OrganizationdisplayName_TextBox_Id_Locator);
            //Log Exit of the Method
            Logger.LogMethodExit("CreateOrganizationPage", "FillOrganizationDisplayName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Organization Internal Name.
        /// </summary>
        /// <param name="organizationGuid">This is organization name guid.</param>
        private void FillInternalOrganizationName(Guid organizationGuid)
        {
            //Log Entry of the Method
            Logger.LogMethodEntry("CreateOrganizationPage", "FillInternalOrganizationName",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the Internal Organization text box element to display
            base.WaitForElement(By.Id(CreateOrganizationPageResource.
                CreateOrganization_Page_InternalOrganizationName_TextBox_Id_Locator));
            base.GetWebElementPropertiesById(CreateOrganizationPageResource.
                CreateOrganization_Page_InternalOrganizationName_TextBox_Id_Locator).Clear();
            //Fill the Internal Organization name in text box
            base.GetWebElementPropertiesById(CreateOrganizationPageResource.
                CreateOrganization_Page_InternalOrganizationName_TextBox_Id_Locator).
                SendKeys(organizationGuid.ToString());
            //Log Exit of the Method
            Logger.LogMethodExit("CreateOrganizationPage", "FillInternalOrganizationName",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill the Organization Address Details.
        /// </summary>
        /// <param name="orgLevelEnum">This is organization level enum.</param>
        private void SelectOrganizationTypeCheckBox(
            Organization.OrganizationLevelEnum orgLevelEnum)
        {
            //Select Organization Type 
            Logger.LogMethodEntry("CreateOrganizationPage",
                "SelectOrganizationTypeCheckBox", base.IsTakeScreenShotDuringEntryExit);
            //Select Third Party Check Box
            switch (orgLevelEnum)
            {
                //Check Third Party Check Box for Power School
                case Organization.OrganizationLevelEnum.PowerSchool:
                    base.WaitForElement(By.Id(CreateOrganizationPageResource
                        .CreateOrganization_Page_ThirdPartyCheckBox_Id));
                    base.SelectCheckBoxById(CreateOrganizationPageResource
                        .CreateOrganization_Page_ThirdPartyCheckBox_Id);
                    break;
            }
            Logger.LogMethodExit("CreateOrganizationPage",
                "SelectOrganizationTypeCheckBox", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button To Save Organization.
        /// </summary>
        private void ClickOnButtonToSaveOrganization()
        {
            //Log Method Entry
            Logger.LogMethodEntry("CreateOrganizationPage",
               "ClickOnButtonToSaveOrganization", base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(CreateOrganizationPageResource.
                CreateOrganization_Page_Save_Button_Id_Locator));
            base.FocusOnElementById(CreateOrganizationPageResource.
                CreateOrganization_Page_Save_Button_Id_Locator);
            IWebElement getOrganizationName = base.GetWebElementPropertiesById
                (CreateOrganizationPageResource.
                CreateOrganization_Page_Save_Button_Id_Locator);
            //Click on the Save the button
            base.ClickByJavaScriptExecutor(getOrganizationName);
            Thread.Sleep(Convert.ToInt32(CreateOrganizationPageResource.
                CreateOrganization_Page_WaitElement_Time));
            //Log Method Exit
            Logger.LogMethodExit("CreateOrganizationPage",
               "ClickOnButtonToSaveOrganization", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill the organization contact details.
        /// </summary>
        /// <param name="organizationNameGuid">This is organization name guid.</param>
        private void FillOrganizationContactDetails(Guid organizationNameGuid)
        {
            //Fill the organization contact details           
            Logger.LogMethodEntry("CreateOrganizationPage",
                "FillOrganizationContactDetails",
                 base.IsTakeScreenShotDuringEntryExit);
            //Fill the Address Name    
            base.GetWebElementPropertiesById(CreateOrganizationPageResource.
                                     CreateOrganization_Page_Address_TextBox_Id_Locator).Clear();
                                                                                                                                                                   base.GetWebElementPropertiesById(CreateOrganizationPageResource.
                                     CreateOrganization_Page_Address_TextBox_Id_Locator).
                                     SendKeys(organizationNameGuid.ToString());
            //Fill the City Name
            base.GetWebElementPropertiesById(CreateOrganizationPageResource.
                                     CreateOrganization_Page_City_TextBox_Id_Locator).Clear();
            base.GetWebElementPropertiesById(CreateOrganizationPageResource.
                                     CreateOrganization_Page_City_TextBox_Id_Locator).
                                     SendKeys(organizationNameGuid.ToString());
            //Fill the Zip code
            base.GetWebElementPropertiesById(CreateOrganizationPageResource.
                                     CreateOrganization_Page_Zipcode_TextBox_Id_Locator).Clear();
            base.FillTextBoxById(CreateOrganizationPageResource.
                CreateOrganization_Page_Zipcode_TextBox_Id_Locator,
                CreateOrganizationPageResource.
                CreateOrganization_Page_Region_Zipcode_TextBox_Id_Locator_Value);
            //Select State
            this.SelectOrganizationState();
            Logger.LogMethodExit("CreateOrganizationPage",
                "FillOrganizationContactDetails",
                base.IsTakeScreenShotDuringEntryExit);
        }

        //Selct Organization State
        private void SelectOrganizationState()
        {
            //Log Method Entry
            Logger.LogMethodEntry("CreateOrganizationPage",
              "SelectOrganizationState",
              base.IsTakeScreenShotDuringEntryExit);
            //Select the State
            base.SelectDropDownValueThroughIndexById(CreateOrganizationPageResource.
                CreateOrganization_Page_State_dropdown_Id_Locator,
                Convert.ToInt32(CreateOrganizationPageResource.
                    CreateOrganization_Page_State_dropdown_Id_Locator_Value));
            //Log Metod Exit
            Logger.LogMethodExit("CreateOrganizationPage",
              "SelectOrganizationState",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  //Select Create Organization Window.
        /// </summary>
        private void SelectCreateOrganizationWindow()
        {
            //Select Create Organization Frame
            Logger.LogMethodEntry("CreateOrganizationPage",
               "SelectCreateOrganizationWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait To Load Window
            base.WaitUntilWindowLoads(OrganizationManagementPageResource.
            OrganizationManagement_Page_CreateOrganizationWindow_Name_Locator);
            //Select the window              
            base.SelectWindow(OrganizationManagementPageResource.
            OrganizationManagement_Page_CreateOrganizationWindow_Name_Locator);
            Logger.LogMethodExit("CreateOrganizationPage",
                 "SelectCreateOrganizationWindow",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Properties Organization Managment Frame.
        /// </summary>
        public void SelectThePropertiesOrganizationManagmentFrame()
        {
            //Select The Properties Organization Managment Frame
            Logger.LogMethodEntry("CreateOrganizationPage",
               "SelectThePropertiesOrganizationManagmentFrame",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.SelectWindow(ManageOrganisationToolBarPageResource.
                        ManageOrganisationToolBar_Page_Window_Name);
                base.SwitchToIFrame(ManageOrganisationToolBarPageResource.
                   ManageOrganisationToolBar_Page_Iframe_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CreateOrganizationPage",
               "SelectThePropertiesOrganizationManagmentFrame",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create The Multiple Level Organization.
        /// </summary>
        /// <param name="organizationLevelEnum">
        /// This is Multiple level scholl organization type enum.</param>
        public void CreateMultipleLevelOrganization(
            Organization.OrganizationLevelEnum organizationLevelEnum)
        {
            //Create The Multiple Level Organization
            Logger.LogMethodEntry("CreateOrganizationPage",
               "CreateMultipleLevelOrganization",
                base.IsTakeScreenShotDuringEntryExit);
            //Intialize Guid for organization
            Guid organization = Guid.NewGuid();
            try
            {
                switch (organizationLevelEnum)
                {
                    // Fetch the organization name from the memory data base 
                    case Organization.OrganizationLevelEnum.Schools:
                        try
                        {
                            //Click On The Add Organization Link
                            new OrganizationSearchPage().ClickOnTheAddOrganizationLink();
                            //Select the Organization Frame
                            new CreateOrganizationPage().SelectCreateOrganizationWindow();
                            //Create Organization Levels
                            this.FillDetailsForNewOrganizationLevels(organization, organizationLevelEnum);
                            //Click on the 'Select Organization' link
                            new OrganizationSearchPage().ClickOnTheSelectOrganizationLink();
                        }
                        catch (Exception e)
                        {
                            ExceptionHandler.HandleException(e);
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CreateOrganizationPage",
               "CreateMultipleLevelOrganization",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Storing the organization details.
        /// </summary>
        /// <param name="organizationName">This is organization name guid.</param>
        /// <param name="organizationLevelEnum">This is organization level Enum.</param>
        /// <param name="organizationTypeEnum">This is organization type enum.</param>
        private void StoreTheOrganizationDetails(Guid organizationName,
            Organization.OrganizationLevelEnum organizationLevelEnum,
            Organization.OrganizationTypeEnum organizationTypeEnum)
        {
            //Storing the organization details
            Logger.LogMethodEntry("CreateOrganizationPage", "StoreTheOrganizationDetails",
                 base.IsTakeScreenShotDuringEntryExit);
            Organization organization = new Organization
            {
                Name = organizationName.ToString(),
                OrganizationLevel = organizationLevelEnum,
                OrganizationType = organizationTypeEnum,
                IsCreated = true,
            };
            organization.StoreOrganizationInMemory();
            Logger.LogMethodExit("CreateOrganizationPage", "StoreTheOrganizationDetails",
            base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
