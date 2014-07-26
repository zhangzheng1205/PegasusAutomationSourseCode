using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Sections;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles adding new sections action.
    /// </summary>
    public class AddNewSectionPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(AddNewSectionPage));

        /// <summary>
        /// Create New Section
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        public void CreateNewSection(
            Course.CourseTypeEnum courseTypeEnum)
        {
            //Create New Section 
            Logger.LogMethodEntry("AddNewSectionPage", "CreateNewSection",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // generate new guid section name
                Guid sectionGuid = Guid.NewGuid();
                // selecting the create new section window
                this.SelectAddNewSectionWindow();
                base.WaitForElement(By.Id(AddNewSectionPageResource.
                    AddNewSection_Page_CourseName_TextName_Id_Locator));
                // enter the section name
                base.FillTextBoxById(AddNewSectionPageResource.
                  AddNewSection_Page_CourseName_TextName_Id_Locator, sectionGuid.ToString());
                // select template
                this.SelectingTemplateFromDropDown(courseTypeEnum);
                // enter no. of section count in text box 
                this.EnterSectionCount(courseTypeEnum);
                // get date format
                string getStartDateFormat = base.GetElementTextById(AddNewSectionPageResource.
                    AddNewSection_Page_Section_StartDate_Format_Id_Locator);
                string getEndDateFormat = base.GetElementTextById(AddNewSectionPageResource.
                    AddNewSection_Page_Section_EndDate_Format_Id_Locator);

                // select section date based on acceptable format 
                if (getStartDateFormat.Trim().Equals(AddNewSectionPageResource.
                    AddNewSection_Page_Section_Actual_StartDate_Format_DDMMYYYY)
                    && (getEndDateFormat.Trim().Equals(AddNewSectionPageResource.
                    AddNewSection_Page_Section_Actual_EndDate_Format_DDMMYYYY)))
                {
                    // enter section start and end date                           
                    this.AddSectionStartAndEndDate(DateTime.Now.ToString(AddNewSectionPageResource.
                        AddNewSection_Page_Date_Format_DDMMYYYY), DateTime.Now.AddDays(90).
                        ToString(AddNewSectionPageResource.AddNewSection_Page_Date_Format_DDMMYYYY));
                }
                if (getStartDateFormat.Trim().Equals(AddNewSectionPageResource.
                   AddNewSection_Page_Section_Actual_StartDate_Format_MMDDYYYY)
                   && (getEndDateFormat.Trim().Equals(AddNewSectionPageResource.
                   AddNewSection_Page_Section_Actual_EndDate_Format_MMDDYYYY)))
                {
                    // enter section start and end date                           
                    this.AddSectionStartAndEndDate(DateTime.Now.ToString(AddNewSectionPageResource.
                        AddNewSection_Page_Date_Format_MMDDYYYY), DateTime.Now.AddDays(90).
                        ToString(AddNewSectionPageResource.AddNewSection_Page_Date_Format_MMDDYYYY));
                }
                // check copy content check box
                if (base.IsElementSelectedById(AddNewSectionPageResource.
                    AddNewSection_Page_Copycontent_Checkbox_Id_Locator))
                {
                    // uncheck the checkbox
                    IWebElement getCopyContentCheckbox =
                    base.GetWebElementPropertiesById(AddNewSectionPageResource.
                    AddNewSection_Page_Copycontent_Checkbox_Id_Locator);
                    base.ClickByJavaScriptExecutor(getCopyContentCheckbox);
                }
                // save and close section
                this.SaveAndCloseAddNewSection();
                // Storing the Section ID
                switch (courseTypeEnum)
                {
                    case Course.CourseTypeEnum.MySpanishLabMaster:
                        new ManageTemplatePage().StoreSectionID(sectionGuid.ToString(),
                            Course.CourseTypeEnum.ProgramCourse);
                        break;
                    case Course.CourseTypeEnum.GraderITSIM5Course:
                    case Course.CourseTypeEnum.MyItLabSIM5MasterCourse:
                        new ManageTemplatePage().StoreSectionID(sectionGuid.ToString(),
                          Course.CourseTypeEnum.MyItLabProgramCourse);
                        break;
                    case Course.CourseTypeEnum.MyITLabForOffice2013Master:
                        new ManageTemplatePage().StoreSectionID(sectionGuid.ToString(),
                            Course.CourseTypeEnum.MyITLabOffice2013Program);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AddNewSectionPage", "CreateNewSection",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Fill the section count in text box to be created
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        private void EnterSectionCount(
            Course.CourseTypeEnum courseTypeEnum)
        {
            // Enter section count 
            Logger.LogMethodEntry("AddNewSectionPage", "EnterSectionCount",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddNewSectionPageResource.
                     AddNewSection_Page_NoList_Id_Locator));
            switch (courseTypeEnum)
            {
                case Course.CourseTypeEnum.HedMilAcceptanceSIMProgramCourse:
                case Course.CourseTypeEnum.HedMilAcceptanceSIM5ProgramCourse:
                case Course.CourseTypeEnum.MyITLabForOffice2013Master:
                    // Enter section count in Drop Down box
                    base.FillTextBoxById(AddNewSectionPageResource.
                        AddNewSection_Page_NoList_Id_Locator, AddNewSectionPageResource.
                            AddNewSection_Page_MilCourse_Section_NoList_Value);
                    break;
                case Course.CourseTypeEnum.MySpanishLabMaster:
                case Course.CourseTypeEnum.MyItLabSIM5MasterCourse:
                case Course.CourseTypeEnum.GraderITSIM5Course:
                    // Enter section count in Drop Down box
                    base.FillTextBoxById(AddNewSectionPageResource.
                        AddNewSection_Page_NoList_Id_Locator, AddNewSectionPageResource.
                            AddNewSection_Page_CoreCourse_Section_NoList_Fill_Value);
                    break;
            }
            Logger.LogMethodExit("AddNewSectionPage", "EnterSectionCount",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting the Add New Section window
        /// </summary>
        private void SelectAddNewSectionWindow()
        {
            //Select Add New Section window
            Logger.LogMethodEntry("AddNewSectionPage", "SelectAddNewSectionWindow",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(AddNewSectionPageResource.
                          AddNewSection_Page_PopUp_Page_Title);
            // Select Window
            base.SelectWindow(AddNewSectionPageResource.
                        AddNewSection_Page_PopUp_Page_Title);
            Logger.LogMethodExit("AddNewSectionPage", "SelectAddNewSectionWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Template from Drop down.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        private void SelectingTemplateFromDropDown(
            Course.CourseTypeEnum courseTypeEnum)
        {
            // Select Template
            Logger.LogMethodEntry("AddNewSectionPage", "SelectingTemplateFromDropDown",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddNewSectionPageResource.
                     AddNewSection_Page_TemplateList_Id_Locator));
            //Get Course Properties
            Course course = Course.Get(courseTypeEnum);
            // Selecting template by index value
            base.SelectDropDownValueThroughTextByName(AddNewSectionPageResource.
                     AddNewSection_Page_TemplateList_Id_Locator, course.Name +
                     AddNewSectionPageResource.AddNewSection_Page_Template_Text_Value);
            Logger.LogMethodExit("AddNewSectionPage", "SelectingTemplateFromDropDown",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close Add Save New Section.
        /// </summary>
        private void SaveAndCloseAddNewSection()
        {
            Logger.LogMethodEntry("AddNewSectionPage", "SaveAndCloseAddNewSection",
                    base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddNewSectionPageResource.
                AddNewSection_Page_AddClose_Button_Id_Locator));
            //Get Element Property
            IWebElement getCloseElementButtonProperty = base.GetWebElementPropertiesById(
                AddNewSectionPageResource.
                    AddNewSection_Page_AddClose_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getCloseElementButtonProperty);
            //Wait for the Popup to Close
            base.IsPopUpClosed(Convert.ToInt32(AddNewSectionPageResource.
                AddNewSection_Page_NumberOfWindows_Value));
            // Select defalut window
            base.SelectWindow(AddNewSectionPageResource
                .AddNewSection_Page_ParentWindow_Page_Title);
            Logger.LogMethodExit("AddNewSectionPage", "SaveAndCloseAddNewSection",
                    base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enters Start and End Date
        /// </summary>
        /// <param name="sectionStartDate">This is Section Start Date</param>
        /// <param name="sectionEndDate">This is Section End Date</param>
        private void AddSectionStartAndEndDate(
            String sectionStartDate, String sectionEndDate)
        {
            //Enters Start and End Date
            Logger.LogMethodEntry("AddNewSectionPage", "AddSectionStartAndEndDate",
                    base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddNewSectionPageResource.
               AddNewSection_Page_StartDate_TextBox_Id_Locator));
            //Enter Start Date
            base.FillTextBoxById(AddNewSectionPageResource.
                                     AddNewSection_Page_StartDate_TextBox_Id_Locator, sectionStartDate);
            base.WaitForElement(By.Id(AddNewSectionPageResource.
                                          AddNewSection_Page_EndDate_TextBox_Id_Locator));
            //Enter End Date
            base.FillTextBoxById(AddNewSectionPageResource.
                                     AddNewSection_Page_EndDate_TextBox_Id_Locator, sectionEndDate);
            base.WaitForElement(By.Id(AddNewSectionPageResource.
                                          AddNewSection_Page_AddClose_Button_Id_Locator));
            Logger.LogMethodExit("AddNewSectionPage", "AddSectionStartAndEndDate",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
