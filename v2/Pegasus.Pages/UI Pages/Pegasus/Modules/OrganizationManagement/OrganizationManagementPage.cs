using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Diagnostics;
using System.Configuration;
using System.Threading;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.OrganizationManagement;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the, action of different level's of Organization
    /// </summary>
    public class OrganizationManagementPage : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(OrganizationManagementPage));

        /// <summary>
        /// Click on the 'Create New Organization' link
        /// </summary>
        public void ClickOnTheCreateNewOrganizationLink()
        {
            //Click on the'Create New Organization' link
            logger.LogMethodEntry("OrganizationManagementPage",
                "ClickOnTheCreateNewOrganizationLink",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the frame
                base.SwitchToIFrame(OrganizationManagementPageResource.
                    OrganizationManagement_Page_Frame_Id_Locator);
                //Wait for Create New Organization' link opened
                base.WaitForElement(By.Id(OrganizationManagementPageResource.
                    OrganizationManagement_Page_CreateNewOrganization_Link_Id_Locator));
                IWebElement getCreateOrganizationlink = base.GetWebElementPropertiesById
                    (OrganizationManagementPageResource.
                    OrganizationManagement_Page_CreateNewOrganization_Link_Id_Locator);
                //Click on the Create New Organization' link button
                base.ClickByJavaScriptExecutor(getCreateOrganizationlink);
                base.WaitUntilWindowLoads(OrganizationManagementPageResource.
                    OrganizationManagement_Page_CreateOrganizationWindow_Name_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrganizationManagementPage",
                "ClickOnTheCreateNewOrganizationLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the different levels of Organization
        /// </summary>
        /// <param name="organizationName">This is organization by name.</param>
        public void SearchTheOrganization(string organizationName)
        {
            //Search the organization
            logger.LogMethodEntry("OrganizationManagementPage", "SearchTheOrganization",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Refresh The Page
                base.RefreshTheCurrentPage();
                //Time Sleep To Page Get Refreshed
                Thread.Sleep(Convert.ToInt32(OrganizationManagementPageResource.
                    OrganizationManagement_Page_ThreadTime_Value));
                //Wait for the window open
                base.SelectWindow(OrganizationManagementPageResource.
                    OrganizationManagement_Page_OrganizationAdminWindow_Name);
                //Checking the frame is present                
                base.WaitForElement(By.Id(OrganizationManagementPageResource.
                      OrganizationManagement_Page_Frame_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(OrganizationManagementPageResource.
                     OrganizationManagement_Page_Frame_Id_Locator);
                //Enter Organization Name To Search
                EnterOrganizationNameToSearch(organizationName);
                //Wait for the element
                base.WaitForElement(By.Id(OrganizationManagementPageResource.
                    OrganizationManagement_Page_Search_Button_Id_Locator));
                IWebElement getSearchedOrganizationName=base.GetWebElementPropertiesById
                    (OrganizationManagementPageResource.
                    OrganizationManagement_Page_Search_Button_Id_Locator);
                //Click on the search button
                base.ClickByJavaScriptExecutor(getSearchedOrganizationName);
                Thread.Sleep(Convert.ToInt32(OrganizationManagementPageResource.
                    OrganizationManagement_Page_ThreadTime_Value));
                base.SelectWindow(OrganizationManagementPageResource.
                    OrganizationManagement_Page_OrganizationAdminWindow_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrganizationManagementPage", "SearchTheOrganization",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Organization Name to Search 
        /// </summary>
        /// <param name="organizationName">This is organization Name.</param>
        private void EnterOrganizationNameToSearch(string organizationName)
        {
            logger.LogMethodEntry("OrganizationManagementPage", "EnterOrganizationNameToSearch",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element to display
            base.WaitForElement(By.Id(OrganizationManagementPageResource.
                OrganizationManagement_Page_Search_Organization_RadioButton_Id_Locator));
            //Click on the radio button
            base.SelectRadioButtonById(OrganizationManagementPageResource.
                OrganizationManagement_Page_Search_Organization_RadioButton_Id_Locator);
            //Clear the Text
            base.FillEmptyTextById(OrganizationManagementPageResource.
                OrganizationManagement_Page_Search_DisplayName_Textbox_Id_Locator);
            //Filling the text 
            base.FillTextBoxById(OrganizationManagementPageResource.
                OrganizationManagement_Page_Search_DisplayName_Textbox_Id_Locator,
                organizationName);
            logger.LogMethodExit("OrganizationManagementPage", "EnterOrganizationNameToSearch",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verift the display Searched Organization result 
        /// </summary>
        /// <returns> Get Organization Name</returns>
        public string GetDisplayofSearchedOrganization()
        {
            //Get display of Searched organization result
            logger.LogMethodEntry("OrganizationManagementPage", "GetDisplayofSearchedOrganization",
                base.IsTakeScreenShotDuringEntryExit);
            //Variable Declaration of organization 
            string getOrganizationName = string.Empty;
            try
            {
                //Wait for the window open
                base.WaitUntilWindowLoads(OrganizationManagementPageResource.
                    OrganizationManagement_Page_OrganizationAdminWindow_Name);
                base.SelectWindow(OrganizationManagementPageResource.
                    OrganizationManagement_Page_OrganizationAdminWindow_Name);
                base.WaitForElement(By.Id(OrganizationManagementPageResource.
                    OrganizationManagement_Page_Frame_Id_Locator));
                //Switch The Frame
                base.SwitchToIFrame(OrganizationManagementPageResource.
                    OrganizationManagement_Page_Frame_Id_Locator);
                //Get the searched organization
                getOrganizationName = base.GetElementTextByClassName
                    (OrganizationManagementPageResource.
                    OrganizationManagement_Page_SearchResult_Table_ClassName_Locator).Trim();
                base.SelectWindow(OrganizationManagementPageResource.
                    OrganizationManagement_Page_OrganizationAdminWindow_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrganizationManagementPage", "GetDisplayofSearchedOrganization",
                   base.IsTakeScreenShotDuringEntryExit);
            return getOrganizationName;
        }

        /// <summary>
        /// Click on the Organization 'Select' button
        /// </summary>
        public void ClickOnTheOrganizationSelectButton()
        {
            //Click on the 'Select' button link
            logger.LogMethodEntry("OrganizationManagementPage", "ClickOnTheOrganizationSelectButton",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select The Main Window
                base.SelectWindow(OrganizationManagementPageResource.
                    OrganizationManagement_Page_OrganizationAdminWindow_Name);
                //Select The Iframe
                base.SwitchToIFrame(OrganizationManagementPageResource.
                     OrganizationManagement_Page_Frame_Id_Locator);
                // Wait for select link opened
                base.WaitForElement(By.XPath(OrganizationManagementPageResource.
                    OrganizationManagement_Page_Select_Button_Xpath_Locator));
                IWebElement getSelectButton=base.GetWebElementPropertiesByXPath
                    (OrganizationManagementPageResource.
                    OrganizationManagement_Page_Select_Button_Xpath_Locator);
                //Click on the 'Select' Button link
                base.ClickByJavaScriptExecutor(getSelectButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrganizationManagementPage", "ClickOnTheOrganizationSelectButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the Organization.
        /// </summary>
        /// <param name="organizationName">This is Organization Name.</param>
        public void SearchOrganization(string organizationName)
        {
            //Search the Organization
            logger.LogMethodEntry("OrganizationManagementPage", "SearchOrganization",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                if (!base.IsPopupPresent(OrganizationManagementPageResource
                            .OrganizationManagement_Page_ManageOrganization_Window_Name_Locator, 
                            Convert.ToInt32(OrganizationManagementPageResource.
                            OrganizationManagement_Page_Custom_Wait_Time_Value)))
                {
                    //Search the organization
                    SearchTheOrganization(organizationName);
                    Thread.Sleep(Convert.ToInt32(OrganizationManagementPageResource
                             .OrganizationManagement_Page_ThreadTime_Value));
                    //Switch to frame
                    base.WaitForElement(By.Id(OrganizationManagementPageResource
                        .OrganizationManagement_Page_Frame_Id_Locator));
                    //Switch To Frame
                    base.SwitchToIFrame(OrganizationManagementPageResource
                        .OrganizationManagement_Page_Frame_Id_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrganizationManagementPage", "SearchOrganization",
                    base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on the Organization 'Select' button
        /// </summary>
        /// <param name="organizationLevelEnum">This is organization by type level. </param>
        public void SelectOrganization(Organization.OrganizationLevelEnum
            organizationLevelEnum)
        {
            //Click on the 'Select' button link
            logger.LogMethodEntry("OrganizationManagementPage", "ClickOnTheSelectButtonofOrganization",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select The Main Window
                base.SelectWindow(OrganizationManagementPageResource.
                    OrganizationManagement_Page_OrganizationAdminWindow_Name);
                //Select The Iframe
                base.SwitchToIFrame(OrganizationManagementPageResource.
                     OrganizationManagement_Page_Frame_Id_Locator);               
                // Wait for select link opened
                base.WaitForElement(By.XPath(OrganizationManagementPageResource.
                    OrganizationManagement_Page_Select_Button_Xpath_Locator));
                IWebElement getSelectBtn = base.GetWebElementPropertiesByXPath
                    (OrganizationManagementPageResource.
                    OrganizationManagement_Page_Select_Button_Xpath_Locator);
                //Click on the 'Select' Button link
                base.ClickByJavaScriptExecutor(getSelectBtn); 
                switch (organizationLevelEnum)
                {
                    case Organization.OrganizationLevelEnum.School:
                    case Organization.OrganizationLevelEnum.PowerSchool:
                        //Wait For Window
                        base.WaitUntilWindowLoads(OrganizationManagementPageResource
                        .OrganizationManagement_Page_ManageOrganization_Window_Name_Locator);
                        //Select manage organization window
                        base.SelectWindow(OrganizationManagementPageResource
                        .OrganizationManagement_Page_ManageOrganization_Window_Name_Locator);
                        break;
                    case Organization.OrganizationLevelEnum.State:
                        //Wait For Window
                        base.WaitUntilWindowLoads(OrganizationManagementPageResource.
                            OrganizationManagement_Page_OrganizationAdminWindow_Name);
                        //Select manage organization window
                        base.SelectWindow(OrganizationManagementPageResource.
                            OrganizationManagement_Page_OrganizationAdminWindow_Name);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrganizationManagementPage", "ClickOnTheSelectButtonofOrganization",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Delete Organization.
        /// </summary>
        public void DeleteOrganization()
        {
            logger.LogMethodEntry("OrganizationManagementPage", "DeleteOrganization",
                   base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Organization Management Window and Frame
                this.SelectOrganizationManagementWindowandFrame();
                //Select Organization Checkbox
                base.WaitForElement(By.XPath(OrganizationManagementPageResource.
                    OrganizationManagement_Page_Organization_Checkbox_Id_Locator));
                base.SelectCheckBoxByXPath(OrganizationManagementPageResource.
                    OrganizationManagement_Page_Organization_Checkbox_Id_Locator);
                base.WaitForElement(By.Id(OrganizationManagementPageResource.
                    OrganizationManagement_Page_Remove_Button_Id_Locator));
                //Select Remove Button
                IWebElement getRemoveButtonProperty = 
                    base.GetWebElementPropertiesById(OrganizationManagementPageResource.
                    OrganizationManagement_Page_Remove_Button_Id_Locator);
                base.ClickByJavaScriptExecutor(getRemoveButtonProperty);
                //Select Ok Button
                this.SelectOkButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrganizationManagementPage", "DeleteOrganization",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Ok Button.
        /// </summary>
        private void SelectOkButton()
        {
            //Select Ok Button
            logger.LogMethodEntry("OrganizationManagementPage", "SelectOkButton",
                   base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(OrganizationManagementPageResource.
                OrganizationManagement_Pegasus_Window_Name);
            //Sekect Pegasus Window
            base.SelectWindow(OrganizationManagementPageResource.
                OrganizationManagement_Pegasus_Window_Name);
            base.WaitForElement(By.Id(OrganizationManagementPageResource.
                OrganizationManagement_Ok_Button_Id_Locator));
            //Select Ok Button
            IWebElement getOkButton = 
                base.GetWebElementPropertiesById(OrganizationManagementPageResource.
                OrganizationManagement_Ok_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(getOkButton);
            logger.LogMethodExit("OrganizationManagementPage", "SelectOkButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Organization Management Window and Frame.
        /// </summary>
        private void SelectOrganizationManagementWindowandFrame()
        {
            //Select Organization Management Window and Frame
            logger.LogMethodEntry("OrganizationManagementPage",
                "SelectOrganizationManagementWindowandFrame",
                   base.IsTakeScreenShotDuringEntryExit);
            //Wait For Window
            base.WaitUntilWindowLoads(OrganizationManagementPageResource.
                OrganizationManagement_Page_OrganizationAdminWindow_Name);
            //Select manage organization window
            base.SelectWindow(OrganizationManagementPageResource.
                OrganizationManagement_Page_OrganizationAdminWindow_Name);
            //Checking the frame is present                
            base.WaitForElement(By.Id(OrganizationManagementPageResource.
                  OrganizationManagement_Page_Frame_Id_Locator));
            //Switch To Frame
            base.SwitchToIFrame(OrganizationManagementPageResource.
                 OrganizationManagement_Page_Frame_Id_Locator);
            logger.LogMethodExit("OrganizationManagementPage",
                "SelectOrganizationManagementWindowandFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Validation Message on Searching Deleted Organization.
        /// </summary>
        /// <returns>This returns Validation Message.</returns>
        public String GetValidationMessageonSearchingDeletedOrganization()
        {
            logger.LogMethodEntry("OrganizationManagementPage",
                "GetValidationMessageonSearchingDeletedOrganization",
                   base.IsTakeScreenShotDuringEntryExit);
            //Initialize String Variable
            string getMessage = string.Empty;
            try
            {
                //Select Organization Management Window and Frame
                this.SelectOrganizationManagementWindowandFrame();
                base.WaitForElement(By.Id(OrganizationManagementPageResource.
                    OrganizationManagement_NoRecordFound_Message_Id_Locator));
                //Get Validation Message
                getMessage = base.GetElementTextById(OrganizationManagementPageResource.
                    OrganizationManagement_NoRecordFound_Message_Id_Locator);                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("OrganizationManagementPage",
                "GetValidationMessageonSearchingDeletedOrganization",
                base.IsTakeScreenShotDuringEntryExit);
            return getMessage;
        }
    }
}
