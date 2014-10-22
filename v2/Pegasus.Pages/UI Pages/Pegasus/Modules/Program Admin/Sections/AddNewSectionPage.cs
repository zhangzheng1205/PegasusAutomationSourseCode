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
                base.IsTakeScreenShotDuringEntryExit);
                string sectionName = string.Empty;
            try
            {
               sectionName= FillingSectionDetails(courseTypeEnum);
                // save and close section
                this.SaveAndCloseAddNewSection();
                // Storing the Section ID
                switch (courseTypeEnum)
                {
                    case Course.CourseTypeEnum.MySpanishLabMaster:
                        new ManageTemplatePage().StoreSectionID(sectionName,
                            Course.CourseTypeEnum.ProgramCourse);
                        break;
                    case Course.CourseTypeEnum.GraderITSIM5Course:
                    case Course.CourseTypeEnum.MyItLabSIM5MasterCourse:
                        new ManageTemplatePage().StoreSectionID(sectionName,
                          Course.CourseTypeEnum.MyItLabProgramCourse);
                        break;
                    case Course.CourseTypeEnum.MyITLabForOffice2013Master:
                        new ManageTemplatePage().StoreSectionID(sectionName,
                            Course.CourseTypeEnum.MyITLabOffice2013Program);
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AddNewSectionPage", "CreateNewSection",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Filter Template Using Parent Template Drop Down
        /// </summary>
        public void FilterTheTemplateUsingParentTemplateDD(Course.CourseTypeEnum courseTypeEnum)
        {
            //Filter Template Using Parent Template Drop Down
            Logger.LogMethodEntry("AddNewSectionPage", "FilterTheTemplateUsingParentTemplateDD",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {                
                //Switch To IFrame
                this.SwitchToIFrame();
                //Wait for Parent Template DropDown
                base.WaitForElement(By.Id(AddNewSectionPageResource.
                    AddNewSection_Page_ParentTemplate_DropDown_ID_Loator));  
               // Get Course Details By Enum Value
                Course course = Course.Get(courseTypeEnum);
                //Select Parent Template DropDown 
                base.SelectDropDownValueThroughTextByName(
                    AddNewSectionPageResource.AddNewSection_Page_ParentTemplate_DropDown_ID_Loator, 
                    course.Name);
                //Switch To IFrame
                this.SwitchToIFrame();      
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AddNewSectionPage", "FilterTheTemplateUsingParentTemplateDD",
               base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Switch To IFrame
        /// </summary>
        private void SwitchToIFrame()
        {
            //Switch To Manage Section IFrame
            Logger.LogMethodEntry("AddNewSectionPage", "FilterTheTemplateUsingParentTemplateDD",
               base.IsTakeScreenShotDuringEntryExit);
            base.SelectWindow(AddNewSectionPageResource
            .AddNewSection_Page_ParentWindow_Page_Title);
            //Switch To IFrame           
            base.SwitchToIFrameById(AddNewSectionPageResource.
                AddNewSection_Page__ctl0_PageContent_iFrameMiddle_Id_Locator);
            Logger.LogMethodExit("AddNewSectionPage", "FilterTheTemplateUsingParentTemplateDD",
              base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Verify Created Section Available in the Filter Section List.
        /// </summary>
        public string VerifyCreatedSectionInFilterTemplateList(string courseName)
        {           
            //Verify Created Section Available in the Filter Section List
            Logger.LogMethodEntry("AddNewSectionPage", "VerifyCreatedSectionInFilterTemplateList",
                base.IsTakeScreenShotDuringEntryExit);
            string sectionName = string.Empty;
            try
            {    
               //get Section Row Count
                int GetSectionRowCount = base.GetElementCountByXPath(
                    AddNewSectionPageResource.AddNewSection_Page_TemplateSection_Table_Id_Locator
                    );
                //Iterate for Respective Section In Table
                for(
                    int setSectionRowCount =
                        Convert.ToInt32(AddNewSectionPageResource.AddNewSection_Page_TemplateList_Index_Value); 
                        setSectionRowCount <=GetSectionRowCount; setSectionRowCount++)
                {
                    //Wait for the element
                    base.WaitForElement(By.XPath(String.Format(
                        AddNewSectionPageResource.AddNewSection_Page_TemplateSection_Span_Text_XPath_Locator,
                        setSectionRowCount)));
                   //Get Section Name From SectionList
                    sectionName =
                        base.GetTitleAttributeValueByXPath(String.Format(
                        AddNewSectionPageResource.AddNewSection_Page_TemplateSection_Span_Text_XPath_Locator,
                        setSectionRowCount));
                    if (sectionName.Contains(courseName))
                    {
                        break;
                    }
                }               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AddNewSectionPage", "VerifyCreatedSectionInFilterTemplateList",
               base.IsTakeScreenShotDuringEntryExit);
            return sectionName;
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
                base.IsTakeScreenShotDuringEntryExit);
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
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Selecting the Add New Section window
        /// </summary>
        private void SelectAddNewSectionWindow()
        {
            //Select Add New Section window
            Logger.LogMethodEntry("AddNewSectionPage", "SelectAddNewSectionWindow",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(AddNewSectionPageResource.
                          AddNewSection_Page_PopUp_Page_Title);
            // Select Window
            base.SelectWindow(AddNewSectionPageResource.
                        AddNewSection_Page_PopUp_Page_Title);
            Logger.LogMethodExit("AddNewSectionPage", "SelectAddNewSectionWindow",
                base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddNewSectionPageResource.
                     AddNewSection_Page_TemplateList_Id_Locator));
            //Get Course Properties
            Course course = Course.Get(courseTypeEnum);
            // Selecting template by index value
            base.SelectDropDownValueThroughTextByName(AddNewSectionPageResource.
                     AddNewSection_Page_TemplateList_Id_Locator, course.Name +
                     AddNewSectionPageResource.AddNewSection_Page_Template_Text_Value);
            Logger.LogMethodExit("AddNewSectionPage", "SelectingTemplateFromDropDown",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close Add Save New Section.
        /// </summary>
        private void SaveAndCloseAddNewSection()
        {
            Logger.LogMethodEntry("AddNewSectionPage", "SaveAndCloseAddNewSection",
                    base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
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
                    base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///  Create section  to validate the section count and give appropriate alert message.
        /// </summary>
        /// <param name="courseTypeEnum"></param>
        /// <param name="sectionCount"></param>
        public void CreateNewSectionWithCount(
            Course.CourseTypeEnum courseTypeEnum, int sectionCount)
        {
            //Create New Section 
            Logger.LogMethodEntry("AddNewSectionPage", "CreateNewSectionWithCount",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string sectionGuid = FillingSectionDetails(courseTypeEnum);
                base.ClearTextById(AddNewSectionPageResource.AddNewSection_Page_NoList_Id_Locator);
                base.FillTextBoxById(AddNewSectionPageResource.
                    AddNewSection_Page_NoList_Id_Locator, sectionCount.ToString());

                OnClickOfSaveAddCloseWithSectionCount();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AddNewSectionPage", "CreateNewSectionWithCount",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To fill the section fields while creating the section.
        /// </summary>
        /// <param name="courseTypeEnum">Template name</param>
        /// <returns>returns the section name</returns>      
        public string FillingSectionDetails(Course.CourseTypeEnum courseTypeEnum)
        {
            //Create New Section 
            Logger.LogMethodEntry("AddNewSectionPage", "FillingSectionDetails",
                base.IsTakeScreenShotDuringEntryExit);
            string sectionName = string.Empty;
            // generate new guid section name
            Guid sectionGuid = Guid.NewGuid();

            try
            {               
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
                    this.AddSectionStartAndEndDate(DateTime.UtcNow.ToString(AddNewSectionPageResource.
                        AddNewSection_Page_Date_Format_DDMMYYYY), DateTime.UtcNow.AddDays(90).
                        ToString(AddNewSectionPageResource.AddNewSection_Page_Date_Format_DDMMYYYY));
                }
                if (getStartDateFormat.Trim().Equals(AddNewSectionPageResource.
                   AddNewSection_Page_Section_Actual_StartDate_Format_MMDDYYYY)
                   && (getEndDateFormat.Trim().Equals(AddNewSectionPageResource.
                   AddNewSection_Page_Section_Actual_EndDate_Format_MMDDYYYY)))
                {
                    // enter section start and end date                           
                    this.AddSectionStartAndEndDate(DateTime.UtcNow.ToString(AddNewSectionPageResource.
                        AddNewSection_Page_Date_Format_MMDDYYYY), DateTime.UtcNow.AddDays(90).
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
            }

            catch (Exception e)
            {

                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AddNewSectionPage", "FillingSectionDetails",
                base.IsTakeScreenShotDuringEntryExit);

            return sectionGuid.ToString();
        }

        /// <summary>
        /// To click the Save and close button
        /// </summary>
        private void OnClickOfSaveAddCloseWithSectionCount()
        {
            Logger.LogMethodEntry("AddNewSectionPage", "SaveAndCloseNewSectionWithCount",
                    base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddNewSectionPageResource.
                AddNewSection_Page_AddClose_Button_Id_Locator));
            //Get Element Property
            IWebElement getCloseElementButtonProperty = base.GetWebElementPropertiesById(
                AddNewSectionPageResource.
                    AddNewSection_Page_AddClose_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getCloseElementButtonProperty);
            Logger.LogMethodExit("AddNewSectionPage", "SaveAndCloseNewSectionWithCount",
                    base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
