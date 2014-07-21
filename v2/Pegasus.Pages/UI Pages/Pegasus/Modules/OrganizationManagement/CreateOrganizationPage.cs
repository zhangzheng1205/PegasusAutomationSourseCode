using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
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
                 base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Remove State Region and District Level Organization.
        /// </summary>
        private void RemoveStateRegionandDistrictLevelOrganization()
        {
            //Remove State Region and District Level Organization
            Logger.LogMethodEntry("CreateOrganizationPage",
                "RemoveStateRegionandDistrictLevelOrganization",
                 base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Organization Management Window.
        /// </summary>
        private void SelectOrganizationManagementWindow()
        {
            //Log Method Entry
            Logger.LogMethodEntry("CreateOrganizationPage",
              "SelectOrganizationManagementWindow",
             base.isTakeScreenShotDuringEntryExit);
            //Wait For Window
            base.WaitUntilPageGetSwitchedSuccessfully(CreateOrganizationPageResource.
                CreateOrganization_Page_OrganizationManagement_Window_Name);
            //Select Organization Window
            base.SelectWindow(CreateOrganizationPageResource.
                CreateOrganization_Page_OrganizationManagement_Window_Name);
            //Log Method Exists
            Logger.LogMethodExit("CreateOrganizationPage",
              "SelectOrganizationManagementWindow",
             base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Organization Name.
        /// </summary>
        /// <param name="organizationNameGuid">This is Organization name guid.</param>
        private void EnterOrganizationName(Guid organizationNameGuid)
        {
            Logger.LogMethodEntry("CreateOrganizationPage", "EnterOrganizationName",
                 base.isTakeScreenShotDuringEntryExit);
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
            base.FocusOnElementByID(CreateOrganizationPageResource.
             CreateOrganization_Page_OrganizationdisplayName_TextBox_Id_Locator);
            Logger.LogMethodExit("CreateOrganizationPage", "EnterOrganizationName",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select School Level Organization.
        /// </summary>
        private void SelectSchoolLevelOrganization()
        {
            //Select School Level Organization
            Logger.LogMethodEntry("CreateOrganizationPage", "SelectSchoolLevelOrganization",
               base.isTakeScreenShotDuringEntryExit);
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
            base.ClickButtonByID(CreateOrganizationPageResource.
                CreateOrganization_Page_RemoveButton_Id_Locator);
            Logger.LogMethodExit("CreateOrganizationPage", "SelectSchoolLevelOrganization",
             base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Country Option For State Level Organization.
        /// </summary>
        private void SelectCountryOptionForStateLevelOrganization()
        {
            //Log Method Entry
            Logger.LogMethodEntry("CreateOrganizationPage",
                "SelectCountryOptionForStateLevelOrganization",
              base.isTakeScreenShotDuringEntryExit);
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
              base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Organization Display Name.
        /// </summary>
        private void FillOrganizationDisplayName()
        {
            //Log Entry of Method
            Logger.LogMethodEntry("CreateOrganizationPage", "FillOrganizationDisplayName",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the Organization display text box element to display
            base.WaitForElement(By.Id(CreateOrganizationPageResource.
                CreateOrganization_Page_OrganizationdisplayName_TextBox_Id_Locator));
            base.GetWebElementPropertiesById(CreateOrganizationPageResource.
                CreateOrganization_Page_OrganizationdisplayName_TextBox_Id_Locator).Clear();
            //Focus on the display name
            base.FocusOnElementByID(CreateOrganizationPageResource.
                CreateOrganization_Page_OrganizationdisplayName_TextBox_Id_Locator);
            //Log Exit of the Method
            Logger.LogMethodExit("CreateOrganizationPage", "FillOrganizationDisplayName",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill Organization Internal Name.
        /// </summary>
        /// <param name="organizationGuid">This is organization name guid.</param>
        private void FillInternalOrganizationName(Guid organizationGuid)
        {
            //Log Entry of the Method
            Logger.LogMethodEntry("CreateOrganizationPage", "FillInternalOrganizationName",
                base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
                "SelectOrganizationTypeCheckBox", base.isTakeScreenShotDuringEntryExit);
            //Select Third Party Check Box
            switch (orgLevelEnum)
            {
                //Check Third Party Check Box for Power School
                case Organization.OrganizationLevelEnum.PowerSchool:
                    base.WaitForElement(By.Id(CreateOrganizationPageResource
                        .CreateOrganization_Page_ThirdPartyCheckBox_Id));
                    base.ClickCheckBoxById(CreateOrganizationPageResource
                        .CreateOrganization_Page_ThirdPartyCheckBox_Id);
                    break;
            }
            Logger.LogMethodExit("CreateOrganizationPage",
                "SelectOrganizationTypeCheckBox", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Button To Save Organization.
        /// </summary>
        private void ClickOnButtonToSaveOrganization()
        {
            //Log Method Entry
            Logger.LogMethodEntry("CreateOrganizationPage",
               "ClickOnButtonToSaveOrganization", base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(CreateOrganizationPageResource.
                CreateOrganization_Page_Save_Button_Id_Locator));
            base.FocusOnElementByID(CreateOrganizationPageResource.
                CreateOrganization_Page_Save_Button_Id_Locator);
            IWebElement getOrganizationName = base.GetWebElementPropertiesById
                (CreateOrganizationPageResource.
                CreateOrganization_Page_Save_Button_Id_Locator);
            //Click on the Save the button
            base.ClickByJavaScriptExecutor(getOrganizationName);
            base.ClickByJavaScriptExecutor(getOrganizationName);
            Thread.Sleep(Convert.ToInt32(CreateOrganizationPageResource.
                CreateOrganization_Page_WaitElement_Time));
            //Log Method Exit
            Logger.LogMethodExit("CreateOrganizationPage",
               "ClickOnButtonToSaveOrganization", base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
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
            base.FillTextBoxByID(CreateOrganizationPageResource.
                CreateOrganization_Page_Zipcode_TextBox_Id_Locator,
                CreateOrganizationPageResource.
                CreateOrganization_Page_Region_Zipcode_TextBox_Id_Locator_Value);
            //Select State
            this.SelectOrganizationState();
            Logger.LogMethodExit("CreateOrganizationPage",
                "FillOrganizationContactDetails",
                base.isTakeScreenShotDuringEntryExit);
        }

        //Selct Organization State
        private void SelectOrganizationState()
        {
            //Log Method Entry
            Logger.LogMethodEntry("CreateOrganizationPage",
              "SelectOrganizationState",
              base.isTakeScreenShotDuringEntryExit);
            //Select the State
            base.SelectDropDownValueThroughIndexById(CreateOrganizationPageResource.
                CreateOrganization_Page_State_dropdown_Id_Locator,
                Convert.ToInt32(CreateOrganizationPageResource.
                    CreateOrganization_Page_State_dropdown_Id_Locator_Value));
            //Log Metod Exit
            Logger.LogMethodExit("CreateOrganizationPage",
              "SelectOrganizationState",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  //Select Create Organization Window.
        /// </summary>
        private void SelectCreateOrganizationWindow()
        {
            //Select Create Organization Frame
            Logger.LogMethodEntry("CreateOrganizationPage",
               "SelectCreateOrganizationWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Wait To Load Window
            base.WaitUntilWindowLoads(OrganizationManagementPageResource.
            OrganizationManagement_Page_CreateOrganizationWindow_Name_Locator);
            //Select the window              
            base.SelectWindow(OrganizationManagementPageResource.
            OrganizationManagement_Page_CreateOrganizationWindow_Name_Locator);
            Logger.LogMethodExit("CreateOrganizationPage",
                 "SelectCreateOrganizationWindow",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Properties Organization Managment Frame.
        /// </summary>
        public void SelectThePropertiesOrganizationManagmentFrame()
        {
            //Select The Properties Organization Managment Frame
            Logger.LogMethodEntry("CreateOrganizationPage",
               "SelectThePropertiesOrganizationManagmentFrame",
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
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
                base.isTakeScreenShotDuringEntryExit);
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
               base.isTakeScreenShotDuringEntryExit);
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
                 base.isTakeScreenShotDuringEntryExit);
            Organization organization = new Organization
            {
                Name = organizationName.ToString(),
                OrganizationLevel = organizationLevelEnum,
                OrganizationType = organizationTypeEnum,
                IsCreated = true,
            };
            organization.StoreOrganizationInMemory();
            Logger.LogMethodExit("CreateOrganizationPage", "StoreTheOrganizationDetails",
            base.isTakeScreenShotDuringEntryExit);
        }
    }
}
