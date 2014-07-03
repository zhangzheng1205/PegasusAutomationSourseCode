﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Course_Templates;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Sections;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains Template Details
    /// </summary>
    public class ManageTemplatePage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ManageTemplatePage));

        /// <summary>
        /// Create New Template
        /// </summary>
        /// <param name="courseName">This is Course Name</param>
        public void CreatTemplate(String courseName)
        {
            // Create Template
            Logger.LogMethodEntry("ManageTemplatePage", "CreatTemplate",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Selecting the Program Administration window
                base.WaitUntilWindowLoads(ManageTemplatePageResource.
                    ManageTemplate_Page_Window_Title_Name);
                base.SelectWindow(ManageTemplatePageResource.
                    ManageTemplate_Page_Window_Title_Name);
                base.WaitForElement(By.Id(ManageTemplatePageResource.
                    ManageTemplate_Page_IFrame_Middle_Name_Id_Locator));
                //Swith To Frame
                base.SwitchToIFrame(ManageTemplatePageResource.
                    ManageTemplate_Page_IFrame_Middle_Name_Id_Locator);
                base.WaitForElement(By.Id(ManageTemplatePageResource.
                    ManageTemplate_Page_TemplateSection__DivContent_Id_Locator));
                //To get template name if present
                String getCourseText = base.GetElementTextByID(ManageTemplatePageResource.
                        ManageTemplate_Page_TemplateSection__DivContent_Id_Locator);
                if (!getCourseText.Contains(courseName))
                {
                    //Creating Template if not Present
                    this.TemplateCreation();
                }
                base.SelectWindow(ManageTemplatePageResource.
                  ManageTemplate_Page_Window_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageTemplatePage", "CreatTemplate",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Extract Method From GetCreatedTemplate
        /// </summary>
        private void TemplateCreation()
        {
            //Create Template
            Logger.LogMethodEntry("ManageTemplatePage", "TemplateCreation",
                base.isTakeScreenShotDuringEntryExit);
            //Create New Template 
            base.SwitchToDefaultWindow();
            base.SelectWindow(ManageTemplatePageResource.
                ManageTemplate_Page_Window_Title_Name);
            base.WaitForElement(By.Id(ManageTemplatePageResource.
                ManageTemplate_Page_IFrame_Middle_Name_Id_Locator));
            //Switching to Frame
            base.SwitchToIFrame(
                ManageTemplatePageResource.ManageTemplate_Page_IFrame_Middle_Name_Id_Locator);
            base.WaitForElement(By.XPath(ManageTemplatePageResource.
                ManageTemplate_Page_CursorHand_XPath_Locator));
            base.ClickButtonByXPath(ManageTemplatePageResource.
                ManageTemplate_Page_CursorHand_XPath_Locator);
            //Create New Template
            new AddNewTemplatePage().CreateNewTemplate();
            Logger.LogMethodExit("ManageTemplatePage", "TemplateCreation",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Validate Entity in Active State.
        /// </summary>
        /// <param name="entityName">This is the Entity Name.</param>
        public void ApproveInActiveStateOfEntityInProgramAdministration(
            String entityName)
        {
            // To validate assign to copy state of template/section 
            Logger.LogMethodEntry("ManageTemplatePage",
                "ApproveInActiveStateOfEntityInProgramAdministration",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window And Frame
                this.SelectMiddleFrame();
                //Waits till the Entity is Active
                ApproveEntityInProgramAdministration(entityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageTemplatePage",
                "ApproveInActiveStateOfEntityInProgramAdministration",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Approve the Entity in Active State.
        /// </summary>
        /// <param name="entityName">This is Entity Name.</param>
        private void ApproveEntityInProgramAdministration(
            String entityName)
        {
            //Approve Entity in Active State
            Logger.LogMethodEntry("ManageTemplatePage", "ApproveEntityInProgramAdministration",
                base.isTakeScreenShotDuringEntryExit);
            // To start stopwatch
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            // Wait till entity enters from inactive state to active state
            int minutesToWait = Int32.Parse(ConfigurationManager.
                AppSettings["AssignedToCopyInterval"]);
            while (stopwatch.Elapsed.TotalMinutes < minutesToWait)
            {
                base.WaitForElement(By.XPath(ManageTemplatePageResource.
                    ManageTemplate_Page_TemplateSection_Grid_Xpath_Locator));
                //Get the Text of the Entity
                String getAssignedToCopyText =
                    base.GetWebElementPropertiesByXPath(ManageTemplatePageResource.
                    ManageTemplate_Page_TemplateSection_Grid_Xpath_Locator).Text;
                if (getAssignedToCopyText.Contains(ManageTemplatePageResource.
                    ManageTemplate_Page_AssignToCopyState_Text) == false) break;
                {
                    //Search the Entity
                    SearchEntityInProgramAdministration(entityName);
                    Thread.Sleep(Convert.ToInt32(ManageTemplatePageResource.
                        ManageTemplate_Page_Thread_Sleep_Time));
                }
            }
            Logger.LogMethodExit("ManageTemplatePage", "ApproveEntityInProgramAdministration",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Program Admin Entity.
        /// </summary>
        /// <param name="entityName">This is Entity Name.</param>
        public void SearchEntityInProgramAdministration(
            String entityName)
        {
            //Search Entity
            Logger.LogMethodEntry("ManageTemplatePage", "SearchEntityInProgramAdministration",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToDefaultPageContent();
                //Select Window And Frame
                this.SelectMiddleFrame();
                base.WaitForElement(By.PartialLinkText(ManageTemplatePageResource.
                    ManageTemplate_Page_Search_Link_Locator));
                //Get Element Property
                IWebElement getLinkProperty = base.GetWebElementPropertiesByLinkText
                    (ManageTemplatePageResource.
                    ManageTemplate_Page_Search_Link_Locator);
                //Click on The Search Link
                base.ClickByJavaScriptExecutor(getLinkProperty);
                base.WaitForElement(By.Id(ManageTemplatePageResource.
                 ManageTemplate_Page_SearchCondition_DropDown_Id_Locator));
                //Selecting the Entity by entity details
                SelectTemplate(entityName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageTemplatePage", "SearchEntityInProgramAdministration",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the Program Admin Entity.
        /// </summary>
        /// <param name="entityName">This is Entity Name.</param>
        private void SelectTemplate(String entityName)
        {
            //Search Program Admin Entity
            Logger.LogMethodEntry("ManageTemplatePage", "SelectTemplate",
                base.isTakeScreenShotDuringEntryExit);
            //Select the 'Contains' Drop Down value
            base.WebDriver.FindElement(By.Id(ManageTemplatePageResource
            .ManageTemplate_Page_SearchCondition_DropDown_Id_Locator))
            .SendKeys(ManageTemplatePageResource
            .ManageTemplate_Page_SearchLocation_DropDown_Value);
            base.WaitForElement(By.Id(ManageTemplatePageResource.
                ManageTemplate_Page_SectionDetail_TextBox_Id_Locator));
            //Clear the Text of the Text box 'Section Detail'
            base.ClearTextByID(ManageTemplatePageResource.
                ManageTemplate_Page_SectionDetail_TextBox_Id_Locator);
            //Enter the Entity Name
            base.FillTextBoxByID(ManageTemplatePageResource.
                ManageTemplate_Page_SectionDetail_TextBox_Id_Locator, entityName);
            base.WaitForElement(By.Id(ManageTemplatePageResource.
                ManageTemplate_Page_Search_Button_Id_Locator));
            //Click on the Search
            base.ClickButtonByID(ManageTemplatePageResource.
                ManageTemplate_Page_Search_Button_Id_Locator);
            Logger.LogMethodExit("ManageTemplatePage", "SelectTemplate",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Template in Active State or not.
        /// </summary>
        /// <param name="entityName">This is Entity Name.</param>
        /// <returns>Result of assign to copy state.</returns>
        public String GetAssignToCopyStateText(
            String entityName)
        {
            //Check Template in Activite State or not
            Logger.LogMethodEntry("ManageTempaltePage", "GetAssignToCopyStateText",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            String getAssignedToCopyText = String.Empty;
            try
            {
                // To verify template/section is in active state
                SearchEntityInProgramAdministration(entityName);
                Thread.Sleep(Convert.ToInt32(ManageTemplatePageResource.
                    ManageTemplate_Page_Thread_Sleep_Time));
                getAssignedToCopyText =
                        base.GetWebElementPropertiesByXPath(ManageTemplatePageResource.
                        ManageTemplate_Page_TemplateSection_Grid_Xpath_Locator).Text;
                // Set focus on the default window
                base.SwitchToDefaultPageContent();
                base.SelectWindow(ManageTemplatePageResource
                    .ManageTemplate_Page_Window_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageTempaltePage", "GetAssignToCopyStateText",
                base.isTakeScreenShotDuringEntryExit);
            return getAssignedToCopyText;
        }

        /// <summary>
        /// Click Add New Section Link
        /// </summary>        
        public void ClickOnAddNewSectionsLink()
        {
            //Click Add Sections Link
            Logger.LogMethodEntry("ManageTemplatePage", "ClickOnAddNewSectionsLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Program Administration Window
                base.SelectWindow(ManageTemplatePageResource.
                    ManageTemplate_Page_Window_Title_Name);
                base.WaitForElement(By.Id(ManageTemplatePageResource.
                    ManageTemplate_Page_IFrame_Middle_Name_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(ManageTemplatePageResource.
                    ManageTemplate_Page_IFrame_Middle_Name_Id_Locator);
                base.WaitForElement(By.XPath(ManageTemplatePageResource.
                    ManageTemplate_Page_CursorHand_XPath_Locator));
                IWebElement getSectionTab = base.GetWebElementPropertiesByXPath
                    (ManageTemplatePageResource.
                    ManageTemplate_Page_CursorHand_XPath_Locator);
                //Click on the Create Section Link
                base.ClickByJavaScriptExecutor(getSectionTab);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageTemplatePage", "ClickOnAddNewSectionsLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Program Admin Section
        /// </summary>
        /// <param name="sectionName">This is section Name</param>
        public void SearchSection(String sectionName)
        {
            // Search Section
            Logger.LogMethodEntry("ManageTemplatePage", "SearchEntity",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.SwitchToDefaultPageContent();
                //Select Window And Frame
                this.SelectMiddleFrame();
                //Click on The Search Link
                this.ClickSearchLinkForSectionSearch();
                base.WaitForElement(By.Id(ManageTemplatePageResource.
                 ManageTemplate_Page_SearchCondition_DropDown_Id_Locator));
                //Select the 'Contains' Drop Down value
                base.WebDriver.FindElement(By.Id(ManageTemplatePageResource
                .ManageTemplate_Page_SearchCondition_DropDown_Id_Locator))
                .SendKeys(ManageTemplatePageResource
                .ManageTemplate_Page_SearchLocation_DropDown_Value);
                // Enter section Name for Search
                this.EnterValueInSectionSearchTextBox(sectionName);
                // Click Search button
                this.ClickSearchButtonForSectionSearch();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageTemplatePage", "SearchEntity",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click search Button. 
        /// </summary>
        private void ClickSearchButtonForSectionSearch()
        {
            //Click on Search button for searching section
            Logger.LogMethodEntry("ManageTemplatePage", "ClickSearchButtonForSectionSearch",
                base.isTakeScreenShotDuringEntryExit);
            // Click on Search button
            base.WaitForElement(By.Id(ManageTemplatePageResource.
                          ManageTemplate_Page_Search_Button_Id_Locator));
            base.ClickButtonByID(ManageTemplatePageResource.
                          ManageTemplate_Page_Search_Button_Id_Locator);
            Logger.LogMethodExit("ManageTemplatePage", "ClickSearchButtonForSectionSearch",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill section name in section search text box.
        /// </summary>
        /// <param name="sectionName">This is section Name.</param>
        private void EnterValueInSectionSearchTextBox(
            String sectionName)
        {
            //Enter section Name for Search
            Logger.LogMethodEntry("ManageTemplatePage", "EnterValueInSectionSearchTextBox",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ManageTemplatePageResource.
                         ManageTemplate_Page_SectionDetail_TextBox_Id_Locator));
            base.ClearTextByID(ManageTemplatePageResource.
                         ManageTemplate_Page_SectionDetail_TextBox_Id_Locator);
            // Fill section name in Text box
            base.FillTextBoxByID(ManageTemplatePageResource.
                         ManageTemplate_Page_SectionDetail_TextBox_Id_Locator, sectionName);
            Logger.LogMethodExit("ManageTemplatePage", "EnterValueInSectionSearchTextBox",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Extract Method of SearchSection To click search link.
        /// </summary>
        private void ClickSearchLinkForSectionSearch()
        {
            //Clicking the Search Link for Searching Section 
            Logger.LogMethodEntry("ManageTemplatePage", "ClickSearchLinkForSectionSearch",
                base.isTakeScreenShotDuringEntryExit);
            //Click search link
            base.WaitForElement(By.PartialLinkText(ManageTemplatePageResource.
                             ManageTemplate_Page_Search_Link_Locator));
            base.ClickButtonByPartialLinkText(ManageTemplatePageResource.
                             ManageTemplate_Page_Search_Link_Locator);
            Logger.LogMethodExit("ManageTemplatePage", "ClickSearchLinkForSectionSearch",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Section ID.
        /// </summary>
        /// <param name="sectionName">This is section name.</param>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        public void StoreSectionID(String sectionName, Course.CourseTypeEnum courseTypeEnum)
        {
            //Store Section ID
            Logger.LogMethodEntry("ManageTemplatePage", "StoreSectionID",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Search section 
                SearchSection(sectionName);
                base.WaitForElement(By.Id(ManageTemplatePageResource.
                    ManageTemplate_Page_TemplateSection_Grid_Id_Locator));
                // Getting Section id to store
                String getSectionID = base.GetElementTextByXPath(ManageTemplatePageResource.
                    ManageTemplate_Page_TemplateSectionGrid_XPath_Locator);
                WebDriver.SwitchTo().DefaultContent();
                //Check Section Id is not null
                if (getSectionID != null)
                {
                    //Store Section ID
                    StoreSectionNameInMemory(getSectionID, sectionName, courseTypeEnum);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageTemplatePage", "StoreSectionID",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Save Section ID in memory
        /// </summary>
        /// <param name="sectionID">This is section id</param>
        /// <param name="courseTypeEnum">This is Course type name.</param>
        /// <param name="sectionName">This is Section Name</param>
        private void StoreSectionNameInMemory(
            String sectionID, String sectionName, Course.CourseTypeEnum courseTypeEnum)
        {
            //Save Section Name in Memory
            Logger.LogMethodEntry("ManageTemplatePage", "StoreSectionNameInMemory",
                base.isTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseTypeEnum);
            //Store Section Details
            course.SectionId = sectionID;
            course.SectionName = sectionName;
            Logger.LogMethodExit("ManageTemplatePage", "StoreSectionNameInMemory",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Cmenu of Section or Template.
        /// </summary>
        /// <param name="cMenuOption">This is cmenu option.</param>
        public void ClickOnCmenuOfSectionOrTemplate(String cMenuOption)
        {
            //Click On Cmenu of Section or Template.
            Logger.LogMethodEntry("ManageTemplatePage", "ClickOnCmenuOfSectionOrTemplate",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Middle Frame
                this.SelectMiddleFrame();
                //Wait for the element
                base.WaitForElement(By.XPath(ManageTemplatePageResource.
                    ManageTemplate_Page_SectionName_XPath_Locator));
                IWebElement getMouseHoverProperty = base.GetWebElementPropertiesByXPath
                    (ManageTemplatePageResource.ManageTemplate_Page_SectionName_XPath_Locator);
                //Perform mouse over on section name
                base.PerformMouseHoverByJavaScriptExecutor(getMouseHoverProperty);
                //Wait for the image option element
                base.WaitForElement(By.ClassName(ManageTemplatePageResource.
                    ManageTemplate_Page_SectionName_Img_ClassNmae));
                IWebElement getImageOption = base.GetWebElementPropertiesByClassName
                    (ManageTemplatePageResource.ManageTemplate_Page_SectionName_Img_ClassNmae);
                //Click on the image option
                base.ClickByJavaScriptExecutor(getImageOption);
                //Select the cmenu option
                IWebElement getCmenuOption =
                    base.GetWebElementPropertiesByPartialLinkText(cMenuOption);
                base.ClickByJavaScriptExecutor(getCmenuOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageTemplatePage", "ClickOnCmenuOfSectionOrTemplate",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Middle Frame
        /// </summary>
        private void SelectMiddleFrame()
        {
            //Select Middle Frame
            Logger.LogMethodEntry("ManageTemplatePage", "SelectMiddleFrame",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(ManageTemplatePageResource
                   .ManageTemplate_Page_Window_Title_Name);
            //Select Window
            base.SelectWindow(ManageTemplatePageResource.
                ManageTemplate_Page_Window_Title_Name);
            base.WaitForElement(By.Id(ManageTemplatePageResource.
                ManageTemplate_Page_IFrame_Middle_Name_Id_Locator));
            //Switch to IFrame
            base.SwitchToIFrame(ManageTemplatePageResource.
                ManageTemplate_Page_IFrame_Middle_Name_Id_Locator);
            Logger.LogMethodExit("ManageTemplatePage", "SelectMiddleFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Derive Section From Parent Section.
        /// </summary>
        public void DeriveSectionFromParentSection()
        {
            //Derive Section From Parent Section
            Logger.LogMethodEntry("ManageTemplatePage", "DeriveSectionFromParentSection",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Generate GUID For Section Name
                Guid sectionName = Guid.NewGuid();
                //Select 'Copy As Section' Window
                this.SelectCopyasSectionWindow();
                base.WaitForElement(By.Id(ManageTemplatePageResource.
                    ManageTemplate_Page_SectionName_Textbox_Id_Locator));
                base.ClearTextByID(ManageTemplatePageResource.
                    ManageTemplate_Page_SectionName_Textbox_Id_Locator);
                //Enter Section Name
                base.FillTextBoxByID(ManageTemplatePageResource.
                    ManageTemplate_Page_SectionName_Textbox_Id_Locator,
                    sectionName.ToString());
                //Enter Section Start And End Date And Save
                this.EnterSectionStartEndDateAndSave();
                //Store Section Details In Memory
                this.StoreSectionID(sectionName.ToString(),
                    Course.CourseTypeEnum.MySpanishLabMaster);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("ManageTemplatePage", "DeriveSectionFromParentSection",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Section Start And End Date And Save.
        /// </summary>
        private void EnterSectionStartEndDateAndSave()
        {
            //Enter Section Start And End Date And Save
            Logger.LogMethodEntry("ManageTemplatePage", "EnterSectionStartEndDateAndSave",
                base.isTakeScreenShotDuringEntryExit);
            //Getting the Date in Proper Format
            String getSectionStartDate = DateTime.Now.ToString(ManageTemplatePageResource.
                ManageTemplate_Page_SectionStartEndDate_Format);
            String getSectionEndDate = DateTime.Now.ToString(ManageTemplatePageResource.
                ManageTemplate_Page_SectionStartEndDate_Format);
            base.WaitForElement(By.Id(AddNewSectionPageResource.
                                     AddNewSection_Page_StartDate_TextBox_Id_Locator));
            base.ClearTextByID(AddNewSectionPageResource.
                                     AddNewSection_Page_StartDate_TextBox_Id_Locator);
            //Enter Start Date
            base.FillTextBoxByID(AddNewSectionPageResource.
                                     AddNewSection_Page_StartDate_TextBox_Id_Locator,
                                     getSectionStartDate);
            base.WaitForElement(By.Id(AddNewSectionPageResource.
                                          AddNewSection_Page_EndDate_TextBox_Id_Locator));
            base.ClearTextByID(AddNewSectionPageResource.
                                     AddNewSection_Page_EndDate_TextBox_Id_Locator);
            //Enter End Date
            base.FillTextBoxByID(AddNewSectionPageResource.
                                     AddNewSection_Page_EndDate_TextBox_Id_Locator,
                                     getSectionEndDate);
            base.WaitForElement(By.Id(ManageTemplatePageResource.
                ManageTemplate_Page_Save_Button_Id_Locator));
            IWebElement getSaveButton =
                base.GetWebElementPropertiesById(ManageTemplatePageResource.
                ManageTemplate_Page_Save_Button_Id_Locator);
            //Click On Save Button
            base.ClickByJavaScriptExecutor(getSaveButton);
            //Wait for the Popup to Close
            base.IsPopUpClosed(Convert.ToInt32(AddNewSectionPageResource.
                AddNewSection_Page_NumberOfWindows_Value));
            Logger.LogMethodExit("ManageTemplatePage", "EnterSectionStartEndDateAndSave",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Copy As Section' Window.
        /// </summary>
        private void SelectCopyasSectionWindow()
        {
            //Select 'Copy As Section' Window
            Logger.LogMethodEntry("ManageTemplatePage", "SelectCopyasSectionWindow",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(ManageTemplatePageResource.
                ManageTemplate_Page_CopySection_Window_Title_Name);
            //Select Window
            base.SelectWindow(ManageTemplatePageResource.
                ManageTemplate_Page_CopySection_Window_Title_Name);
            Logger.LogMethodExit("ManageTemplatePage", "SelectCopyasSectionWindow",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
