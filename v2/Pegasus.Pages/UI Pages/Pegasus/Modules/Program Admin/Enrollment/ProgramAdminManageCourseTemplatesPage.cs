using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Course_Templates;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Enrollment;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Program Admin Manage Course Templates Page Actions
    /// </summary>
    public class ProgramAdminManageCourseTemplatesPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.
            GetInstance(typeof(ProgramAdminManageCourseTemplatesPage));

        /// <summary>
        /// Search Section
        /// </summary>
        /// <param name="sectionName">This is Section Name</param>
        public void SearchSection(string sectionName)
        {
            //Search Section
            logger.LogMethodEntry("ProgramAdminManageCourseTemplatesPage",
                "SearchSection", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Switch To Default Page
                base.SwitchToDefaultPageContent();                
                //Select top frame
                new ProgramAdminToolPage().SelectFrame();
                //Select Right Frame
                SelectRightFrame();
                //Click search link
                ClickSearchLink();
                base.SwitchToActivePageElement();
                // Select contains option in dropdown menu
                this.SelectContainsValueInDropDown();
                // Enter section name search textbox field
                this.EnterSectionNameInTextbox(sectionName);
                //Click on search button
                this.ClickSearchButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProgramAdminManageCourseTemplatesPage",
                "SearchSection", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Extract method of search Section for Click on Search Button
        /// </summary>
        private void ClickSearchButton()
        {
            //Clicking on the Search Button
            logger.LogMethodExit("ProgramAdminManageCourseTemplatesPage",
                "ClickSearchButton",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ProgramAdminManageCourseTemplatesPageResource.
                ProgramAdminManageCourseTemplates_Page_Search_Button_Id_Locator));
            //Click on Search button
            base.ClickButtonByID(ProgramAdminManageCourseTemplatesPageResource.
                ProgramAdminManageCourseTemplates_Page_Search_Button_Id_Locator);
            logger.LogMethodExit("ProgramAdminManageCourseTemplatesPage",
                "ClickSearchButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Extract method of search Section for Clicking the Search Link
        /// </summary>
        private void ClickSearchLink()
        {
            //Clicking on the Search Link
            logger.LogMethodEntry("ProgramAdminManageCourseTemplatesPage",
                "ClickSearchLink", base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(ManageTemplatePageResource.
                ManageTemplate_Page_Search_Link_Locator));
            // Click on Search link
            base.ClickButtonByPartialLinkText(ProgramAdminManageCourseTemplatesPageResource.
                ProgramAdminManageCourseTemplates_Page_Search_Link_Locator);
            logger.LogMethodExit("ProgramAdminManageCourseTemplatesPage",
                "ClickSearchLink", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Extract method of search Section for  selecting Right Frame
        /// </summary>
        private void SelectRightFrame()
        {
            //Selecting the Right Frame
            logger.LogMethodEntry("ProgramAdminManageCourseTemplatesPage",
                "SelectRightFrame", base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ProgramAdminManageCourseTemplatesPageResource.
                ProgramAdminManageCourseTemplates_Page_RightFrame_Id_Locator));
            //Select right frame
            base.SwitchToIFrame(ProgramAdminManageCourseTemplatesPageResource.
                ProgramAdminManageCourseTemplates_Page_RightFrame_Id_Locator);
            logger.LogMethodExit("ProgramAdminManageCourseTemplatesPage",
                "SelectRightFrame", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Extract method of search Section for  Entering the SectionName
        /// </summary>
        /// <param name="sectionName">This is Section Name</param>
        private void EnterSectionNameInTextbox(string sectionName)
        {
            //Search of Section Name
            logger.LogMethodEntry("ProgramAdminManageCourseTemplatesPage",
                "EnterSectionNameInTextbox", base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ProgramAdminManageCourseTemplatesPageResource.
                ProgramAdminManageCourseTemplates_Page_SectionDetail_TextBox_Id_Locator));
            // Enter section name search textbox field
            base.ClearTextByID(ProgramAdminManageCourseTemplatesPageResource.
                ProgramAdminManageCourseTemplates_Page_SectionDetail_TextBox_Id_Locator);
            //Enter Section Name
            base.FillTextBoxByID(ProgramAdminManageCourseTemplatesPageResource.
                ProgramAdminManageCourseTemplates_Page_SectionDetail_TextBox_Id_Locator,
                sectionName);
            logger.LogMethodExit("ProgramAdminManageCourseTemplatesPage",
                "EnterSectionNameInTextbox", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Extract method of search Section for  selecting 'contains' value from dropdown  
        /// </summary>
        private void SelectContainsValueInDropDown()
        {
            //Search Section for Selecting 'contains' value from dropdown
            logger.LogMethodEntry("ProgramAdminManageCourseTemplatesPage",
                "SelectContainsValueInDropDown", base.isTakeScreenShotDuringEntryExit);
            //Select contains option in dropdown menu
            base.WaitForElement(By.Id(ProgramAdminManageCourseTemplatesPageResource.
                ProgramAdminManageCourseTemplates_Page_SearchCondition_DropDown_Id_Locator));
            logger.LogMethodExit("ProgramAdminManageCourseTemplatesPage",
      "SelectContainsValueInDropDown", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Get searched Section Text.
        /// </summary>
        /// <returns>Search Section result</returns>
        public String GetSearchedSection()
        {
            //Search Section Text
            logger.LogMethodEntry("ProgramAdminManageCourseTemplatesPage",
                "GetSearchedSection",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Section Name
            string getSectionName = string.Empty;
            try
            {                
                //Select top frame
                new ProgramAdminToolPage().SelectFrame();
                //Select Left Frame
                base.WaitForElement(By.Id(ProgramAdminManageCourseTemplatesPageResource.
                    ProgramAdminManageCourseTemplates_Page_RightFrame_Id_Locator));
                base.SwitchToIFrame(ProgramAdminManageCourseTemplatesPageResource.
                    ProgramAdminManageCourseTemplates_Page_RightFrame_Id_Locator);
                //Get the section name text   
                getSectionName = base.GetTitleAttributeValueByXPath(
                    ProgramAdminManageCourseTemplatesPageResource.
                      ProgramAdminManageCourseTemplates_Page_SearchedSection_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProgramAdminManageCourseTemplatesPage",
                "GetSearchedSection",
                base.isTakeScreenShotDuringEntryExit);
            return getSectionName;
        }

        /// <summary>
        /// Enter searched section.
        /// </summary>
        public void EnterIntoSection()
        {
            //Clicking on Searched Section
            logger.LogMethodEntry("ProgramAdminManageCourseTemplatesPage", "EnterSection",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Click on searched section link
                base.ClickLinkByXPath(ProgramAdminManageCourseTemplatesPageResource.
                              ProgramAdminManageCourseTemplates_Page_SearchedSection_Xpath_Locator);
                Thread.Sleep(Convert.ToInt32(ProgramAdminManageCourseTemplatesPageResource
                    .ProgramAdminManageCourseTemplates_Page_ThreadTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProgramAdminManageCourseTemplatesPage", "EnterSection",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check Teaching Assistant present in section
        /// </summary>
        /// <returns>This is the Presence of Teaching Assistant</returns>
        public bool IsTeachingAssistantPresentinSection()
        {
            //Check Teaching Assistant present in section
            logger.LogMethodEntry("ProgramAdminManageCourseTemplatesPage",
                "IsTeachingAssistantPresentinSection",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isTeachingAssistantPresent = false;
            try
            {
                //Select Window
                base.SelectWindow(ProgramAdminManageCourseTemplatesPageResource.
                        ProgramAdminManageCourseTemplates_Page_Window_Title_Name);
                //Select top frame
                new ProgramAdminToolPage().SelectFrame();
                //Select Right Frame
                SelectRightFrame();
                base.WaitForElement(By.Id(ProgramAdminManageCourseTemplatesPageResource.
                    ProgramAdminManageCourseTemplates_Page_Dropdown_Id_Locator));
                //Select Option in Dropdown
                base.SelectDropDownValueThroughIndexById
                    (ProgramAdminManageCourseTemplatesPageResource.
                    ProgramAdminManageCourseTemplates_Page_Dropdown_Id_Locator,
                    Convert.ToInt32(ProgramAdminManageCourseTemplatesPageResource.
                    ProgramAdminManageCourseTemplates_Page_Dropdown_Value));                
                Thread.Sleep(Convert.ToInt32(ProgramAdminManageCourseTemplatesPageResource.
                    ProgramAdminManageCourseTemplates_Page_ThreadTime_Value));
                // Check Teaching Assistant Present
                isTeachingAssistantPresent = base.IsElementPresent(By.XPath
                    (ProgramAdminManageCourseTemplatesPageResource.
                    ProgramAdminManageCourseTemplates_Page_TAPresenceinSection_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }           
            logger.LogMethodExit("ProgramAdminManageCourseTemplatesPage",
                "IsTeachingAssistantPresentinSection",
                base.isTakeScreenShotDuringEntryExit);
            return isTeachingAssistantPresent;
        }
    }
}
