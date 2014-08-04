using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Automation.DataTransferObjects;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Location;


namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handels the Mac Address Details Page action
    /// </summary>
    public class MacAddressDetailsPage : BasePage
    {
        // <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(MacAddressDetailsPage));


        /// <summary>
        /// Add Computer Mac Address
        /// </summary>
        public void AddComputerMacAddress()
        {
            //Add Computer Mac Address
            logger.LogMethodEntry("MacAddressDetailsPage", "AddComputerMacAddress",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Prefernce Window
                this.SelectPreferencesWindow();
                //Switch To Outer Frame
                this.SwitchToOuterIFrame();
                //Switch To Inner Frame
                this.SwitchToInnerIFrame();
                //Switch To Left Frame
                this.SwitchToLeftFrame();
                //Click On Add Computer
                this.ClickOnAddComputer();
                //Select Add Computer Window
                this.SelectAddComputerWindow();
                //Enter Computer Name
                this.EnterComputerName();
                //Click On Add Button
                this.ClickOnAddButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MacAddressDetailsPage", "AddComputerMacAddress",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Preferences Window
        /// </summary>
        private void SelectPreferencesWindow()
        {
            //Select Preferences Window
            logger.LogMethodEntry("MacAddressDetailsPage", "SelectPreferencesWindow",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait fot Window
            base.WaitUntilWindowLoads(MacAddressDetailsPageResource.
                MacAddressDetails_Page_Prefernces_Window_Name);
            //Select Window
            base.SelectWindow(MacAddressDetailsPageResource.
                MacAddressDetails_Page_Prefernces_Window_Name);
            logger.LogMethodExit("MacAddressDetailsPage", "SelectPreferencesWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to Outer IFrame
        /// </summary>
        private void SwitchToOuterIFrame()
        {
            //Switch To Outer IFrame
            logger.LogMethodEntry("MacAddressDetailsPage", "SwitchToOuterIFrame",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait for the Frame
            base.WaitForElement(By.Id(MacAddressDetailsPageResource.
                MacAddressDetails_Page_OuterFrame_Id_Locator));
            //Switch To IFrame
            base.SwitchToIFrameById(MacAddressDetailsPageResource.
                MacAddressDetails_Page_OuterFrame_Id_Locator);
            logger.LogMethodExit("MacAddressDetailsPage", "SwitchToOuterIFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch To Inner IFrame
        /// </summary>
        private void SwitchToInnerIFrame()
        {
            //Switch To Inner IFrame
            logger.LogMethodEntry("MacAddressDetailsPage", "SwitchToInnerIFrame",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MacAddressDetailsPageResource.
                MacAddressDetails_Page_InnerFrame_Id_Locator));
            //Switch To Inner IFrame
            base.SwitchToIFrameById(MacAddressDetailsPageResource.
                MacAddressDetails_Page_InnerFrame_Id_Locator);
            logger.LogMethodExit("MacAddressDetailsPage", "SwitchToInnerIFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch To Left Frame
        /// </summary>
        private void SwitchToLeftFrame()
        {
            //Switch To Left Frame
            logger.LogMethodEntry("MacAddressDetailsPage", "SwitchToLeftFrame",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MacAddressDetailsPageResource.
                MacAddressDetails_Page_LeftFrame_Id_Locator));
            //Switch To Left Frame
            base.SwitchToIFrameById(MacAddressDetailsPageResource.
                MacAddressDetails_Page_LeftFrame_Id_Locator);
            logger.LogMethodExit("MacAddressDetailsPage", "SwitchToLeftFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch To Right Frame
        /// </summary>
        private void SwitchToRightFrame()
        {
            //Switch To Right Frame
            logger.LogMethodEntry("MacAddressDetailsPage", "SwitchToRightFrame",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MacAddressDetailsPageResource.
                MacAddressDetails_Page_RightFrame_Id_Locator));
            //Switch To Right Frame
            base.SwitchToIFrameById(MacAddressDetailsPageResource.
                MacAddressDetails_Page_RightFrame_Id_Locator);
            logger.LogMethodExit("MacAddressDetailsPage", "SwitchToRightFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Computer 
        /// </summary>
        private void ClickOnAddComputer()
        {
            //Click On Add Computer
            logger.LogMethodEntry("MacAddressDetailsPage", "ClickOnAddComputer",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MacAddressDetailsPageResource.
                MacAddressDetails_Page_AddComputer_Id_Locator));
            //Get Add Computer Property
            IWebElement getAddComputerProperty = base.GetWebElementPropertiesById(MacAddressDetailsPageResource.
                MacAddressDetails_Page_AddComputer_Id_Locator);
            //Click On Add Computer
            base.ClickByJavaScriptExecutor(getAddComputerProperty);
            logger.LogMethodExit("MacAddressDetailsPage", "ClickOnAddComputer",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Add Computer Window
        /// </summary>
        private void SelectAddComputerWindow()
        {
            //Select Add Computer Window
            logger.LogMethodEntry("MacAddressDetailsPage", "SelectAddComputerWindow",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(MacAddressDetailsPageResource.
                MacAddressDetails_Page_AddComputer_Window_Name);
            //Select Add Computer Window
            base.SelectWindow(MacAddressDetailsPageResource.
                MacAddressDetails_Page_AddComputer_Window_Name);
            logger.LogMethodExit("MacAddressDetailsPage", "SelectAddComputerWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Address CheckBox
        /// </summary>
        private void SelectAddressCheckBox()
        {
            //Select Address CheckBox
            logger.LogMethodEntry("MacAddressDetailsPage", "SelectAddressCheckBox",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MacAddressDetailsPageResource.
                MacAddressDetails_Page_AddressCheckBox_Id_Locator));
            //Get Address CheckBox
            IWebElement getAddressCheckBox = base.GetWebElementPropertiesById(
                MacAddressDetailsPageResource.MacAddressDetails_Page_AddressCheckBox_Id_Locator);
            //Click On Address Checkbox
            base.ClickByJavaScriptExecutor(getAddressCheckBox);
            logger.LogMethodExit("MacAddressDetailsPage", "SelectAddressCheckBox",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Mac Address
        /// </summary>
        private void EnterMacAddress()
        {
            //Enter Mac Address
            logger.LogMethodEntry("MacAddressDetailsPage", "EnterMacAddress",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Name(MacAddressDetailsPageResource.
                MacAddressDetails_Page_InputAddressDetails_Name_Locator));
            //FIll Mac Address
            base.FillTextBoxByName(MacAddressDetailsPageResource.
                MacAddressDetails_Page_InputAddressDetails_Name_Locator,
                MacAddressDetailsPageResource.MacAddressDetails_Page_MacAddress_Value);
            logger.LogMethodExit("MacAddressDetailsPage", "EnterMacAddress",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Computer Name
        /// </summary>
        private void EnterComputerName()
        {
            //Enter Computer Name
            logger.LogMethodEntry("MacAddressDetailsPage", "EnterComputerName",
              base.IsTakeScreenShotDuringEntryExit);
            //Generate GUID for Computer Name
            Guid computerName = Guid.NewGuid();
            base.WaitForElement(By.Id(MacAddressDetailsPageResource.
                MacAddressDetails_Page_InputComputerName_Id_locator));
            //Enter Computer Name
            base.FillTextBoxById(MacAddressDetailsPageResource.
                MacAddressDetails_Page_InputComputerName_Id_locator, computerName.ToString());
            logger.LogMethodExit("MacAddressDetailsPage", "EnterComputerName",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Button
        /// </summary>
        private void ClickOnAddButton()
        {
            //Click On Add Button
            logger.LogMethodEntry("MacAddressDetailsPage", "ClickOnAddButton",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.LinkText(MacAddressDetailsPageResource.
                MacAddressDetails_Page_Add_LinkText_Locator));
            //Get Add Button Property
            IWebElement getAddButtonProperty = base.GetWebElementPropertiesByLinkText(
                MacAddressDetailsPageResource.MacAddressDetails_Page_Add_LinkText_Locator);
            //Click On Add Button
            base.ClickByJavaScriptExecutor(getAddButtonProperty);
            logger.LogMethodExit("MacAddressDetailsPage", "ClickOnAddButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add Location
        /// </summary>
        public void AddLocation()
        {
            //Add Location
            logger.LogMethodEntry("MacAddressDetailsPage", "AddLocation",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select prefernces Window
                this.SelectPreferencesWindow();
                //Switch To Outer Frame
                this.SwitchToOuterIFrame();
                //Switch To Inner Frame
                this.SwitchToInnerIFrame();
                //Switch To Right Frame
                this.SwitchToRightFrame();
                //Click On Add Location
                this.ClickOnAddLocation();
                //Select Add Location Window
                this.SelectAddLocationWindow();
                //Enter Location
                this.EnterLocation();
                //Click On Add Button
                this.ClickOnAddButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MacAddressDetailsPage", "AddLocation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Location 
        /// </summary>
        private void ClickOnAddLocation()
        {
            //Click On Add Location 
            logger.LogMethodEntry("MacAddressDetailsPage", "ClickOnAddLocation",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MacAddressDetailsPageResource.
                MacAddressDetails_Page_AddLocation_Id_Locator));
            //Get Add Location Property
            IWebElement getAddLocationProperty = base.GetWebElementPropertiesById(
                MacAddressDetailsPageResource.MacAddressDetails_Page_AddLocation_Id_Locator);
            //Click on Add Lcoation 
            base.ClickByJavaScriptExecutor(getAddLocationProperty);
            logger.LogMethodExit("MacAddressDetailsPage", "ClickOnAddLocation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Add Location Window
        /// </summary>
        private void SelectAddLocationWindow()
        {
            //Select Add Location Window
            logger.LogMethodEntry("MacAddressDetailsPage", "SelectAddLocationWindow",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(MacAddressDetailsPageResource.
                MacAddressDetails_Page_AddLocation_Window_Name);
            //Select Add Lcoation Window
            base.SelectWindow(MacAddressDetailsPageResource.
                MacAddressDetails_Page_AddLocation_Window_Name);
            logger.LogMethodExit("MacAddressDetailsPage", "SelectAddLocationWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Location 
        /// </summary>
        private void EnterLocation()
        {
            //Enter Location 
            logger.LogMethodEntry("MacAddressDetailsPage", "EnterLocation",
              base.IsTakeScreenShotDuringEntryExit);
            //Generate Guid for Location Name
            Guid locatioName = Guid.NewGuid();
            base.WaitForElement(By.Id(MacAddressDetailsPageResource.
                MacAddressDetails_Page_InputLocation_Id_Locator));
            //Fill Location Name
            base.FillTextBoxById(MacAddressDetailsPageResource.
                MacAddressDetails_Page_InputLocation_Id_Locator, locatioName.ToString());
            logger.LogMethodExit("MacAddressDetailsPage", "EnterLocation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Associate Computer To Location 
        /// </summary>
        public void AssociateComputerToLocation()
        {
            //Associate Computer to Location 
            logger.LogMethodEntry("MacAddressDetailsPage", "AssociateComputerToLocation",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Prefernces Window
                this.SelectPreferencesWindow();
                //Select Outer Frame
                this.SwitchToOuterIFrame();
                //Select Inner Frame
                this.SwitchToInnerIFrame();
                //Select Right Frame
                this.SwitchToRightFrame();
                //Select Location
                this.SelectLocation();
                //Select Prefernces Window
                this.SelectPreferencesWindow();
                //Select Outer Frame
                this.SwitchToOuterIFrame();
                //Select Inner Frame
                this.SwitchToInnerIFrame();
                //Switch To Left Frame
                this.SwitchToLeftFrame();
                //Select Computer
                this.SelectComputer();
                //Select Prefernces Window
                this.SelectPreferencesWindow();
                //Switch To Outer Frame
                this.SwitchToOuterIFrame();
                //Switch To Inner Frame
                this.SwitchToInnerIFrame();
                //Click On Add Image Button
                this.ClickOnAddImage();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MacAddressDetailsPage", "AssociateComputerToLocation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Location
        /// </summary>
        private void SelectLocation()
        {
            //Select Location
            logger.LogMethodEntry("MacAddressDetailsPage", "SelectLocation",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.ClassName(MacAddressDetailsPageResource.
                MacAddressDetails_Page_SelectLocation_ClassName_Locator));
            //Get Location Property
            IWebElement getLocationProperty = base.GetWebElementPropertiesByClassName(
                MacAddressDetailsPageResource.MacAddressDetails_Page_SelectLocation_ClassName_Locator);
            //Click On Location
            base.ClickByJavaScriptExecutor(getLocationProperty);
            logger.LogMethodExit("MacAddressDetailsPage", "SelectLocation",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Computer
        /// </summary>
        private void SelectComputer()
        {
            //Select Computer
            logger.LogMethodEntry("MacAddressDetailsPage", "SelectComputer",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MacAddressDetailsPageResource.
                MacAddressDetails_Page_SelectComputer_Id_Locator));
            //Get Computer Property
            IWebElement getComputerCheckBoxProperty = base.GetWebElementPropertiesById(
                MacAddressDetailsPageResource.MacAddressDetails_Page_SelectComputer_Id_Locator);
            //Click On Computer
            base.ClickByJavaScriptExecutor(getComputerCheckBoxProperty);
            logger.LogMethodExit("MacAddressDetailsPage", "SelectComputer",
              base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Click On Add Image Button
        /// </summary>
        private void ClickOnAddImage()
        {
            //Click On Add Image Button
            logger.LogMethodEntry("MacAddressDetailsPage", "ClickOnAddImage",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(MacAddressDetailsPageResource.
                MacAddressDetails_Page_ImageAddButton_Id_Locator));
            //Get Add Image Property
            IWebElement getAddButtonProperty = base.GetWebElementPropertiesById(
                MacAddressDetailsPageResource.MacAddressDetails_Page_ImageAddButton_Id_Locator);
            //Click On Add Image Button
            base.ClickByJavaScriptExecutor(getAddButtonProperty);
            logger.LogMethodExit("MacAddressDetailsPage", "ClickOnAddImage",
              base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
