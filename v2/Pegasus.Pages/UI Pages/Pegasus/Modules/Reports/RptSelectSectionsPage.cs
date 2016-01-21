using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus RptSelectSections Page Actions
    /// </summary>
    public class RptSelectSectionsPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(RptSelectSectionsPage));

        /// <summary>
        /// This is the enum available for Buttons in Select Sections Popup
        /// </summary>
        public enum SelectSectionsPopupButtonTypeEnum
        {
            /// <summary>
            /// 'Add Sections' Button In Select Sections Popup
            /// </summary>
            AddSections = 1,
            /// <summary>
            /// 'Add and Close' Button In Select Sections Popup
            /// </summary>
            AddandClose = 2,
            /// <summary>
            /// 'Cancel' Button In Select Sections Popup
            /// </summary>
            Cancel = 3
        }

        /// <summary>
        /// To select the section.
        /// </summary>
        /// <param name="sectionName">This is Section Name.</param>
        public void SelectSection(string sectionName)
        {
            logger.LogMethodEntry("RptSelectSectionsPage", "SelectSection"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectWindow();
                //Click On Expand Link
                this.ClickOnExpandLink();
                // Get Section rows count
                base.WaitForElement(By.XPath(RptSelectSectionsPageResource.
                         RptSelectSections_Page_SectionName_Rows_Xpath_Locator));
                int getSectionCount = base.GetElementCountByXPath(RptSelectSectionsPageResource.
                   RptSelectSections_Page_SectionName_Rows_Xpath_Locator);
                // To find required section
                for (int initialCount = Convert.ToInt32(RptSelectSectionsPageResource.
                    RptSelectSections_Page_Loop_Initializer_Value);
                    initialCount <= getSectionCount; initialCount++)
                {
                    // Get section Name
                    string getSectionName = base.GetElementTextByXPath(
                            RptSelectSectionsPageResource.
                            RptSelectSections_Page_SectionName_Xpath_Locator);
                    if (getSectionName.Contains(sectionName))
                    {
                        // Check checkbox of section      
                        IWebElement clickCheckBox = base.WebDriver.FindElement
                            (By.XPath(RptSelectSectionsPageResource.
                            RptSelectSections_Page_Section_CheckBox_Xpath_Locator));
                        base.ClickByJavaScriptExecutor(clickCheckBox);
                     
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectSectionsPage", "SelectSection"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Expand Link.
        /// </summary>
        public void ClickOnExpandLink()
        {
            //Click On Expand Link
            logger.LogMethodEntry("RptSelectSectionsPage", "ClickOnExpandLink"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.XPath(RptSelectSectionsPageResource.
                       RptSelectSections_Page_Expand_Image_Xpath_Locator));
                //Click On Expand Link
                base.ClickImageByXPath(RptSelectSectionsPageResource.
                    RptSelectSections_Page_Expand_Image_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectSectionsPage", "ClickOnExpandLink"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Collapse Link.
        /// </summary>
        public void ClickOnCollapseLink()
        {
            //Click On Collapse Link
            logger.LogMethodEntry("RptSelectSectionsPage", "ClickOnCollapseLink"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.XPath(RptSelectSectionsPageResource.
                    RptSelectSections_Page_Collapse_Image_Xpath_Locator));
                //Click On Collapse Link
                base.ClickImageByXPath(RptSelectSectionsPageResource.
                    RptSelectSections_Page_Collapse_Image_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectSectionsPage", "ClickOnCollapseLink"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window.
        /// </summary>
        private void SelectWindow()
        {
            //Select Window
            logger.LogMethodEntry("RptSelectSectionsPage", "SelectWindow"
                , base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitUntilWindowLoads(RptSelectSectionsPageResource.
                RptSelectSections_Page_Window_Title);
            //Select Window
            base.SelectWindow(RptSelectSectionsPageResource.
                RptSelectSections_Page_Window_Title);
            logger.LogMethodExit("RptSelectSectionsPage", "SelectWindow"
                , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the AddandClose button.
        /// </summary>
        public void ClickAddandCloseButton()
        {
            //Click on the AddandClose button
            logger.LogMethodEntry("RptSelectSectionsPage", "ClickAddandCloseButton"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Click Add and Close button
                base.WaitForElement(By.Id(RptSelectSectionsPageResource.
                    RptSelectSections_Page_AddandClose_Button_Id_Locator));
                //Focus on AddandClose Button
                base.FocusOnElementById(RptSelectSectionsPageResource.
                      RptSelectSections_Page_AddandClose_Button_Id_Locator);
                //Click on AddandClose Button
                base.ClickButtonById(RptSelectSectionsPageResource.
                    RptSelectSections_Page_AddandClose_Button_Id_Locator);
                //Check Select sections popup closed                
                IsPopUpClosed(Convert.ToInt32(RptSelectSectionsPageResource.
                    RptSelectSections_Page_Window_Count));
                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectSectionsPage", "ClickAddandCloseButton"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add Sections button.
        /// </summary>
        public void ClickAddSectionsButton()
        {
            //Click on Add Sections button
            logger.LogMethodEntry("RptSelectSectionsPage", "ClickAddSectionsButton"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {   
                //Wait for Add Sections Button
                base.WaitForElement(By.Id(RptSelectSectionsPageResource.
                    RptSelectSections_Page_AddSections_Button_Id_Locator));
                //Focus on Add Sections Button
                base.FocusOnElementById(RptSelectSectionsPageResource.
                    RptSelectSections_Page_AddSections_Button_Id_Locator);
                //Click on Add Sections Button
                base.ClickButtonById(RptSelectSectionsPageResource.
                    RptSelectSections_Page_AddSections_Button_Id_Locator);                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectSectionsPage", "ClickAddSectionsButton"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on the Cancel button.
        /// </summary>
        public void ClickOnCancelButton()
        {
            logger.LogMethodEntry("RptSelectSectionsPage", "ClickOnCancelButton"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Click on the Cancel button
                base.WaitForElement(By.Id(RptSelectSectionsPageResource.
                    RptSelectSections_Page_CancelButton_Id_locator));
                //Focus on Cancel Button
                base.FocusOnElementById(RptSelectSectionsPageResource.
                    RptSelectSections_Page_CancelButton_Id_locator);
                //Click on Cancel Button
                base.ClickButtonById(RptSelectSectionsPageResource.
                    RptSelectSections_Page_CancelButton_Id_locator);
                //Check Select sections popup closed                
                IsPopUpClosed(Convert.ToInt32(RptSelectSectionsPageResource.
                    RptSelectSections_Page_Window_Count));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectSectionsPage", "ClickOnCancelButton"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Show/Hide Sections Link.
        /// </summary>        
        public void ClickOnShowHideSectionLink()
        {
            //Click On Show/Hide Sections Link
            logger.LogMethodEntry("RptSelectSectionsPage", "ClickOnShowHideSectionLink"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectWindow();
                //Wait For Element
                base.WaitForElement(By.Id(RptSelectSectionsPageResource.
                    RptSelectSections_Page_ShowHide_Link_Id_Locator));
                //Get Element Property
                IWebElement getSectionLink =
                    base.GetWebElementPropertiesById(RptSelectSectionsPageResource.
                    RptSelectSections_Page_ShowHide_Link_Id_Locator);
                //Click On Link
                base.ClickByJavaScriptExecutor(getSectionLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectSectionsPage", "ClickOnShowHideSectionLink"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Section Name Dispaly or Not.
        /// </summary>        
        /// <param name="sectionName">This is Section Name.</param>
        /// <returns>Section Display Status.</returns>
        public bool IsSectionNameDisplay(string sectionName)
        {
            //Verify Section Name Dispaly or Not
            logger.LogMethodEntry("RptSelectSectionsPage", "IsSectionNameDisplay"
                , base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getSectionName = string.Empty;
            bool sectionDisplayStatus = false;
            try
            {
                //Select Window
                this.SelectWindow();
                //Get Section Count
                int getSectionCount = base.GetElementCountByXPath(RptSelectSectionsPageResource.
                    RptSelectSections_Page_SectionCount_Xpath_Locator);
                for (int sectionCount = Convert.ToInt32(RptSelectSectionsPageResource.
                    RptSelectSections_Page_Loop_Initializer_Value);
                    sectionCount <= getSectionCount; sectionCount++)
                {
                    base.WaitForElement(By.XPath(string.Format(RptSelectSectionsPageResource.
                        RptSelectSections_Page_Section_Name_Xpath_Locator, sectionCount)));
                    //Get Section Name
                    getSectionName = base.GetElementTextByXPath(string.Format(
                        RptSelectSectionsPageResource.
                        RptSelectSections_Page_Section_Name_Xpath_Locator,sectionCount));
                    if (getSectionName == sectionName)
                    {
                        sectionDisplayStatus = true;
                        break;
                    }
                }                
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectSectionsPage", "IsSectionNameDisplay"
               , base.IsTakeScreenShotDuringEntryExit);
            return sectionDisplayStatus;
        }

        /// <summary>
        /// Verify Section Present Or Not.
        /// </summary>
        /// <returns>Display Status Of Section.</returns>
        public bool IsSectionPresent()
        {
            logger.LogMethodEntry("RptSelectSectionsPage", "IsSectionPresent"
                , base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isSectionNamePresent = false;
            try
            {
                //Select Window
                this.SelectWindow();
                //Display Status Of Section
                isSectionNamePresent =
                    base.GetWebElementPropertiesByXPath(RptSelectSectionsPageResource.
                        RptSelectSections_Page_Section_Xpath_Locator).Displayed;
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }       
            logger.LogMethodExit("RptSelectSectionsPage", "IsSectionPresent"
               , base.IsTakeScreenShotDuringEntryExit);
            return isSectionNamePresent;
        }

        /// <summary>
        /// Get Expand/Collapse Button Title.
        /// </summary>
        /// <returns>Expand/Collapse Button Title.</returns>
        public String GetExpandCollapseButtonTitle()
        {
            //Get Expand/Collapse Button Title
            logger.LogMethodEntry("RptSelectSectionsPage", "GetExpandCollapseButtonTitle"
                , base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getButtonTitle = string.Empty;
            try
            {
                //Select Window
                this.SelectWindow();
                base.WaitForElement(By.XPath(RptSelectSectionsPageResource.
                    RptSelectSections_Page_ShowHide_Section_Link_Image_Xpath_Locator));
                //Get Expand/Collapse Button Title
                getButtonTitle = base.GetTitleAttributeValueByXPath(RptSelectSectionsPageResource.
                    RptSelectSections_Page_ShowHide_Section_Link_Image_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectSectionsPage", "GetExpandCollapseButtonTitle"
               , base.IsTakeScreenShotDuringEntryExit);
            return getButtonTitle;
        }

        /// <summary>
        /// Get Select Sections Popup Message.
        /// </summary>
        /// <returns>Message in Select Sections Popup.</returns>
        public String GetSelectSectionsPopupMessage()
        {
            //Get Select Sections Popup Message
            logger.LogMethodEntry("RptSelectSectionsPage", "GetSelectSectionsPopupMessage"
                , base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getMessage = string.Empty;
            try
            {
                //Select Window
                this.SelectWindow();
                base.WaitForElement(By.Id(RptSelectSectionsPageResource.
                    RptSelectSections_Page_Message_Id_Locator));
                //Get Message
                getMessage = base.GetElementTextById(RptSelectSectionsPageResource.
                    RptSelectSections_Page_Message_Id_Locator);        
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectSectionsPage", "GetSelectSectionsPopupMessage"
               , base.IsTakeScreenShotDuringEntryExit);
            return getMessage;
        }

        /// <summary>
        /// Click On The Button In Select Sections Popup.
        /// </summary>
        /// <param name="selectSectionsPopupButtonTypeEnum">
        /// This is Button Type Enum In Select Sections Popup.</param>        
        public void ClickOnTheButtonInSelectSectionsPopup(
            SelectSectionsPopupButtonTypeEnum selectSectionsPopupButtonTypeEnum)
        {
            //Click On The Button In Select Sections Popup
            logger.LogMethodEntry("RptSelectSectionsPage",
                "ClickOnTheButtonInSelectSectionsPopup"
                 , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (selectSectionsPopupButtonTypeEnum)
                {
                    case SelectSectionsPopupButtonTypeEnum.Cancel:
                        //Click On Cancel Button
                        this.ClickOnCancelButton();
                        break;
                    case SelectSectionsPopupButtonTypeEnum.AddSections:
                        //Click On Add Sections Button
                        this.ClickAddSectionsButton();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("RptSelectSectionsPage",
                "ClickOnTheButtonInSelectSectionsPopup"
               , base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Section And Click On Add Button
        /// </summary>
        /// <param name="sectionName">This is Section Name</param>
        public void SelectSectionAndClickAddButton(string sectionName)
        {
            //Select Section And Click Add Button
            logger.LogMethodEntry("RptSelectSectionsPage",
               "SelectSectionAndClickAddButton"
                , base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Section
                this.SelectSection(sectionName);
                // Click AddandClose button to close SelectSections PopUp
                this.ClickAddandCloseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                
            }
            logger.LogMethodExit("RptSelectSectionsPage",
                "SelectSectionAndClickAddButton"
               , base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
