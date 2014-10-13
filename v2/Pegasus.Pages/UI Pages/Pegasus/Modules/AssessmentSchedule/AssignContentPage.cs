using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentSchedule;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This page handles functionality of the Assign window.
    /// </summary>
    public class AssignContentPage : BasePage
    {
        // <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(AssignContentPage));

        /// <summary>
        /// Configure the due date on assign window
        /// </summary>
        public void ConfigureDueDate()
        {
            // configure the classes periods
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "ConfigureDueDate",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get the due date
                string getDueDate = DateTime.Now.AddDays(50).ToString
                    (AssignContentPageResource.AssignContent_Page_DateFormat);
                // Enter the due date in due date text box
                base.WaitForElement(By.Id(AssignContentPageResource
               .AssignContent_Page_DueDate_TextBox_Id_Locator));
                base.ClearTextById(AssignContentPageResource
               .AssignContent_Page_DueDate_TextBox_Id_Locator);
                base.FillTextBoxById(AssignContentPageResource
                .AssignContent_Page_DueDate_TextBox_Id_Locator, getDueDate);
                // Click on save and close button
                base.WaitForElement(By.CssSelector(AssignContentPageResource
                .AssignContent_Page_SaveandAssign_Button_CssSelector));
                base.ClickButtonByCssSelector(AssignContentPageResource
                .AssignContent_Page_SaveandAssign_Button_CssSelector);
                // Click on Ok Button
                base.WaitForElement(By.XPath(AssignContentPageResource
                .AssignContent_Page_OkButton_Xpath));
                //Get Element Property
                IWebElement getOkButton = base.GetWebElementPropertiesByXPath(AssignContentPageResource
               .AssignContent_Page_OkButton_Xpath);
                //Click on OK button
                base.ClickByJavaScriptExecutor(getOkButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "ConfigureDueDate",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the class on assign window
        /// </summary>
        /// <param name="className">This is the class name</param>
        public void SelectClassOnAssignWindow(string className)
        {
            // configure the classes periods
            logger.LogMethodEntry("CalendarDefaultGlobalUXPage", "SelectClassOnAssignWindow",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                int rowCount = 1;
                //Select Assign Window
                this.SelectAssignWindow();
                // Fetch all attributes of class div
                IWebElement classDivElement = base.GetWebElementPropertiesById
                    (AssignContentPageResource.AssignContent_Page_SelectClasses_Div_Id);
                while (classDivElement.Text.Contains(className))
                {
                    // get the class name as per the row
                    string getClassName = base.GetElementTextByXPath
                        (string.Format(AssignContentPageResource
                    .AssignContent_Page_ClassesRow, rowCount));
                    if (getClassName.Contains(className))
                    {
                        IWebElement getClassSelector = base.GetWebElementPropertiesByXPath
                            (string.Format
                        (AssignContentPageResource
                        .AssignContent_Page_ClassesRadioButton_Td, rowCount));
                        // Click on select class radio button
                        base.ClickByJavaScriptExecutor(getClassSelector);
                        break;
                    }
                    else
                    {
                        // increase row count by one
                        rowCount = rowCount + 1;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CalendarDefaultGlobalUXPage", "SelectClassOnAssignWindow",
               base.IsTakeScreenShotDuringEntryExit);


        }

        /// <summary>
        /// Assign The Activity On Current Date
        /// </summary>
        public void AssignTheActivityOnCurrentDate()
        {
            //Assign The Activity On Current Date
            logger.LogMethodEntry("AssignContentPage", "AssignTheActivityOnCurrentDate",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                //Check the Assignd Radio Button
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_RadioButton_Assigned_Id_Locator));
                base.ClickButtonById(AssignContentPageResource.
                    AssignContent_Page_RadioButton_Assigned_Id_Locator);
                //Click on the Save button
                base.FocusOnElementById(AssignContentPageResource.
                    AssignContent_Page_Button_SaveAndAssign_Id_Locator);
                base.ClickButtonById(AssignContentPageResource.
                    AssignContent_Page_Button_SaveAndAssign_Id_Locator);
                //Check for the Window to Close
                base.IsPopUpClosed(Convert.ToInt32(AssignContentPageResource.
                    AssignContent_Page_Window_Count));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "AssignTheActivityOnCurrentDate",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Assign Window.
        /// </summary>
        private void SelectAssignWindow()
        {
            //Select Assign Window
            logger.LogMethodEntry("AssignContentPage", "SelectAssignWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for Assign Window
            base.WaitUntilWindowLoads(AssignContentPageResource.
                AssignContent_Page_WindowTitle_Name);
            base.SelectWindow(AssignContentPageResource.
                AssignContent_Page_WindowTitle_Name);
            logger.LogMethodExit("AssignContentPage", "SelectAssignWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Due Date of Activity
        /// </summary>
        /// <returns>Due Date Of Activity</returns>
        public String getDueDateOfActivity()
        {
            logger.LogMethodEntry("AssignContentPage", "getDueDateOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getDueDate = string.Empty;
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                //Get Due Date Of Assigned Activity
                getDueDate = GetDueDateOfAssignedActivity(getDueDate);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "getDueDateOfActivity",
                base.IsTakeScreenShotDuringEntryExit);
            return new CalendarHedDefaultUxPage().GetConvertedDate(getDueDate);

        }

        /// <summary>
        /// Get Due Date Of Assigned Activity.
        /// </summary>
        /// <param name="getDueDate">This is Due Date.</param>
        /// <returns>Due Date.</returns>
        private string GetDueDateOfAssignedActivity(string getDueDate)
        {
            //Get Due Date Of Assigned Activity
            logger.LogMethodEntry("AssignContentPage", "GetDueDateOfAssignedActivity",
               base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AssignContentPageResource.
                AssignContent_Page_DueDate_TextBox_Id_Locator));
            //Get Due Date Of Activity
            getDueDate = base.GetWebElementPropertiesById(AssignContentPageResource.
                AssignContent_Page_DueDate_TextBox_Id_Locator).GetAttribute(AssignContentPageResource.
                AssignContent_Page_DueDate_Value);
            //wait for 5 seconds
            Thread.Sleep(Convert.ToInt32(AssignContentPageResource.
                AssignContent_Page_SleepTime_Value));
            //Close the Browser Window
            base.CloseBrowserWindow();
            //Wait for Window
            base.WaitUntilWindowLoads(AssignContentPageResource.
                AssignContent_Page_Calendar_Window_Name);
            //Select Window
            base.SelectWindow(AssignContentPageResource.
                AssignContent_Page_Calendar_Window_Name);
            logger.LogMethodExit("AssignContentPage", "GetDueDateOfAssignedActivity",
                base.IsTakeScreenShotDuringEntryExit);
            return getDueDate;
        }

        /// <summary>
        /// Select Set Avalability Date Range Radiobutton.
        /// </summary>
        public void SelectSetAvalabilityDateRangeRadiobutton()
        {
            //Select Set Avalability Date Range Radiobutton
            logger.LogMethodEntry("AssignContentPage", "SelectSetAvalabilityDateRangeRadiobutton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                //Check the Set Availability Date Range Radio Button
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_SetAvailabilityDateRange_Radiobutton_Id_Locator));
                //Select Set Avalability Date Range Radiobutton
                base.ClickButtonById(AssignContentPageResource.
                    AssignContent_Page_SetAvailabilityDateRange_Radiobutton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "SelectSetAvalabilityDateRangeRadiobutton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check Start And End Date Fields Present.
        /// </summary>
        /// <returns>Status Of Start And End Date Fields.</returns>
        public bool IsStartEndDateFieldPresent()
        {
            //Check Start And End Date Fields Present
            logger.LogMethodEntry("AssignContentPage", "IsStartEndDateFieldPresent",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isStartEndDateFieldsPresent = false; ;
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                //Check Status Of Start And End Date Fields
                isStartEndDateFieldsPresent = base.IsElementPresent(By.Id(AssignContentPageResource.
                    AssignContent_Page_FromDate_TextField_Id_Locator)) &&
                base.IsElementPresent(By.Id(AssignContentPageResource.
                AssignContent_Page_ToDate_TextField_Id_Locator)) &&
                base.IsElementPresent(By.XPath(AssignContentPageResource.
                AssignContent_Page_From_Calendar_Xpath_Locator)) &&
                base.IsElementPresent(By.XPath(AssignContentPageResource.
                AssignContent_Page_To_Calendar_Xpath_Locator)) &&
                base.IsElementPresent(By.Id(AssignContentPageResource.
                AssignContent_Page_From_Hours_Id_Locator)) &&
                base.IsElementPresent(By.Id(AssignContentPageResource.
                AssignContent_Page_From_Minutes_Id_Locator)) &&
                base.IsElementPresent(By.Id(AssignContentPageResource.
                AssignContent_Page_To_Hours_Id_Locator)) &&
                base.IsElementPresent(By.Id(AssignContentPageResource.
                AssignContent_Page_To_Minutes_Id_Locator)) &&
                base.IsElementPresent(By.Id(AssignContentPageResource.
                AssignContent_Page_FromAMPM_Id_Locator)) &&
                base.IsElementPresent(By.Id(AssignContentPageResource.
                AssignContent_Page_ToAMPM_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "IsStartEndDateFieldPresent",
                base.IsTakeScreenShotDuringEntryExit);
            return isStartEndDateFieldsPresent;
        }

        /// <summary>
        /// Get Timezone.
        /// </summary>
        /// <returns>Timezone Value.</returns>
        public String GetTimezone()
        {
            //Get Timezone
            logger.LogMethodEntry("AssignContentPage", "GetTimezone",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getTimeZone = string.Empty;
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                IWebElement getTimezoneLink = base.GetWebElementPropertiesById(AssignContentPageResource.
                    AssignContent_Page_TimezoneIcon_Id_Locator);
                base.PerformMouseHoverByJavaScriptExecutor(getTimezoneLink);
                //Get Timezone
                getTimeZone = base.GetTitleAttributeValueById(AssignContentPageResource.
                    AssignContent_Page_TimezoneIcon_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "GetTimezone",
                base.IsTakeScreenShotDuringEntryExit);
            return getTimeZone;
        }

        /// <summary>
        /// Select Not Assigned Radiobutton.
        /// </summary>
        public void SelectNotAssignedRadiobutton()
        {
            //Select Not Assigned Radiobutton
            logger.LogMethodEntry("AssignContentPage", "SelectNotAssignedRadiobutton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                //Wait For Element
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_NotAssigned_Radiobutton_Id_Locator));
                if (!base.IsElementSelectedById(AssignContentPageResource.
                    AssignContent_Page_NotAssigned_Radiobutton_Id_Locator))
                {
                    //Select Radiobutton
                    base.SelectRadioButtonById(AssignContentPageResource.
                    AssignContent_Page_NotAssigned_Radiobutton_Id_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "SelectNotAssignedRadiobutton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check Status Of 'Set End Date As Due Date' Option.
        /// </summary>
        /// <returns>Status Of Set End Date As Due Date Option.</returns>
        public bool IsStatusOfSetEndDateAsDueDateOptionDisabled()
        {
            //Check Status Of 'Set End Date As Due Date' Option
            logger.LogMethodEntry("AssignContentPage",
                "IsStatusOfSetEndDateAsDueDateOptionDisabled",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            bool isElementEnabled = false;
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                //Wait For Element
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_SetEndDateAsDueDate_Checkbox_Id_Locator));
                if (base.IsElementEnabledById(AssignContentPageResource.
                    AssignContent_Page_SetEndDateAsDueDate_Checkbox_Id_Locator))
                {
                    isElementEnabled = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage",
                "IsStatusOfSetEndDateAsDueDateOptionDisabled",
                base.IsTakeScreenShotDuringEntryExit);
            return isElementEnabled;
        }

        /// <summary>
        /// Get Start End Date Text.
        /// </summary>
        /// <returns>Start End Date Text.</returns>
        public String GetStartEndDateText()
        {
            //Get Start End Date Text
            logger.LogMethodEntry("AssignContentPage", "GetStartEndDateText",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            string getStartEndDateText = string.Empty;
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                base.WaitForElement(By.XPath(AssignContentPageResource.
                    AssignContent_Page_StartDate_Text_Xpath_Locator));
                //Get Start End Date Text
                getStartEndDateText = base.GetElementTextByXPath(AssignContentPageResource.
                    AssignContent_Page_StartDate_Text_Xpath_Locator) +
                    base.GetElementTextByXPath(AssignContentPageResource.
                    AssignContent_Page_EndDate_Text_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "GetStartEndDateText",
                base.IsTakeScreenShotDuringEntryExit);
            return getStartEndDateText;
        }

        /// <summary>
        /// Verify Checkboxes Present In Restrict Availability Frame.
        /// </summary>
        /// <returns>Status Of Checkboxes In Restrict Availability Frame.</returns>
        public bool IsCheckboxesPresentInRestrictAvailabilityFrame()
        {
            //Verify Checkboxes Present In Restrict Availability Frame
            logger.LogMethodEntry("AssignContentPage",
                "IsCheckboxesPresentInRestrictAvailabilityFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            bool isCheckboxesPresent = false;
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                //Check Status Of Checkboxes
                isCheckboxesPresent = base.IsElementPresent(By.Id(
                    AssignContentPageResource.AssignContent_Page_First_Checkbox_Id_Locator)) &&
                    base.IsElementPresent(By.Id(AssignContentPageResource.
                    AssignContent_Page_Second_Checkbox_Id_Locator)) &&
                    base.IsElementPresent(By.Id(AssignContentPageResource.
                    AssignContent_Page_Third_Checkbox_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage",
                "IsCheckboxesPresentInRestrictAvailabilityFrame",
                base.IsTakeScreenShotDuringEntryExit);
            return isCheckboxesPresent;
        }

        /// <summary>
        /// Click On Button In Assign Window.
        /// </summary>
        /// <param name="buttonName">This is Button Name.</param>
        public void ClickOnButtonInAssignWindow(string buttonName)
        {
            //Click On Button In Assign Window
            logger.LogMethodEntry("AssignContentPage", "ClickOnButtonInAssignWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                base.WaitForElement(By.PartialLinkText(buttonName));
                //Click On Button
                base.ClickButtonByPartialLinkText(buttonName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "ClickOnButtonInAssignWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Display Of 'All Students' and 'Selected Students' Radiobuttons.
        /// </summary>
        /// <returns>Display Status Of 'All Students' and 'Selected Students' Radiobuttons.</returns>
        public bool IsAllStudentsSelectedStudentsOptionsPresent()
        {
            //Verify Display Of 'All Students' and 'Selected Students' Radiobuttons
            logger.LogMethodEntry("AssignContentPage",
                "IsAllStudentsSelectedStudentsOptionsPresent",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            bool isOptionsPresent = false;
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                //Check Display Of 'All Students' and 'Selected Students' Radiobuttons
                isOptionsPresent = base.IsElementPresent(By.Id(AssignContentPageResource.
                    AssignContent_Page_AllStudents_Radiobutton_Id_Locator)) &&
                    base.IsElementPresent(By.Id(AssignContentPageResource.
                    AssignContent_Page_SelectedStudents_Radiobutton_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage",
                "IsAllStudentsSelectedStudentsOptionsPresent",
                base.IsTakeScreenShotDuringEntryExit);
            return isOptionsPresent;
        }

        /// <summary>
        /// Select 'Selected Students' Option.
        /// </summary>
        public void SelectSelectedStudentsOption()
        {
            //Select 'Selected Students' Option
            logger.LogMethodEntry("AssignContentPage",
                "SelectSelectedStudentsOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_SelectedStudents_Radiobutton_Id_Locator));
                //Select 'Selected Students' Radiobutton
                base.SelectRadioButtonById(AssignContentPageResource.
                    AssignContent_Page_SelectedStudents_Radiobutton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage",
                "SelectSelectedStudentsOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Text In Assign Window.
        /// </summary>
        /// <returns>This is Text In Assign Window.</returns>
        public String GetTextInAssignWindow()
        {
            //Get Text In Assign Window
            logger.LogMethodEntry("AssignContentPage",
                "GetTextInAssignWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getText = string.Empty;
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                //Get Text
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_Text_Id_Locator));
                //Get Text
                getText = base.GetElementTextById(AssignContentPageResource.
                    AssignContent_Page_Text_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage",
                "GetTextInAssignWindow",
                base.IsTakeScreenShotDuringEntryExit);
            return getText;
        }

        /// <summary>
        /// Get Student In 'View by' Frame.
        /// </summary>
        /// <returns>Student Name.</returns>
        public String GetStudentInViewbyFrame()
        {
            //Get Student In 'View by' Frame
            logger.LogMethodEntry("AssignContentPage",
                "GetStudentInViewbyFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getUserName = string.Empty;
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_Viewby_Dropdown_Id_Locator));
                //Get Dropdown Default Value
                string getDropdownDefaultOption = base.GetValueAttributeByXPath(
                    AssignContentPageResource.
                    AssignContent_Page_DropDown_Default_Option_Xpath_Locator);
                //Get Student Name
                getUserName = this.GetStudentName(getDropdownDefaultOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage",
                "GetStudentInViewbyFrame",
                base.IsTakeScreenShotDuringEntryExit);
            return getUserName;
        }

        /// <summary>
        /// Get Student Name
        /// </summary>        
        /// <param name="getDropdownDefaultOption">This is Dropdown Default Option.</param>
        /// <returns>Student Name.</returns>
        private string GetStudentName(string getDropdownDefaultOption)
        {
            //Get Student Name
            logger.LogMethodEntry("AssignContentPage", "GetStudentName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getUserName = string.Empty;
            if (getDropdownDefaultOption == AssignContentPageResource.
                AssignContent_Page_Dropdown_Default_Option_Value)
            {
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_Viewby_Frame_Id_Locator));
                base.SwitchToIFrame(AssignContentPageResource.
                    AssignContent_Page_Viewby_Frame_Id_Locator);
                //Get Student Count
                int getStudentCount = base.GetElementCountByXPath(AssignContentPageResource.
                    AssignContent_Page_StudentCount_Xpath_Locator);
                for (int rowCount = 1; rowCount <= getStudentCount; getStudentCount++)
                {
                    //Get Student Name
                    string getName = base.GetElementTextByXPath(string.Format(
                        AssignContentPageResource.
                        AssignContent_Page_StudentName_Xpath_Locator, rowCount));
                    if (getName == AssignContentPageResource.
                        AssignContent_Page_User_Name_Value)
                    {
                        //Get User Name
                        getUserName = base.GetElementTextByXPath(string.Format(
                            AssignContentPageResource.
                            AssignContent_Page_UserName_Xpath_Locator, rowCount));
                        break;
                    }
                }
            }

            else
            {
                getUserName = string.Empty;
            }
            logger.LogMethodExit("AssignContentPage", "GetStudentName",
               base.IsTakeScreenShotDuringEntryExit);
            return getUserName;
        }

        /// <summary>
        /// Get Content In Select Students Frame.
        /// </summary>
        /// <returns>Content In Select Students Frame.</returns>
        public String GetContentInSelectStudentsFrame()
        {
            //Get Content In Select Students Frame
            logger.LogMethodEntry("AssignContentPage",
                "GetStudentInViewbyFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getContent = string.Empty;
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_Selected_Frame_Id_Locator));
                //Select Frame
                base.SwitchToIFrame(AssignContentPageResource.
                    AssignContent_Page_Selected_Frame_Id_Locator);
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_SelectedFrame_Content_Id_Locator));
                //Get Content
                getContent = base.GetElementTextById(AssignContentPageResource.
                    AssignContent_Page_SelectedFrame_Content_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage",
                "GetStudentInViewbyFrame",
                base.IsTakeScreenShotDuringEntryExit);
            return getContent;
        }

        /// <summary>
        /// Get Group Name.
        /// </summary>
        /// <returns>Group Name.</returns>
        public String GetGroupName()
        {
            //Get Group Name
            logger.LogMethodEntry("AssignContentPage", "GetGroupName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getGroupName = string.Empty;
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_Viewby_Dropdown_Id_Locator));
                //Select Dropdown Value
                base.SelectDropDownValueThroughTextById(AssignContentPageResource.
                    AssignContent_Page_Viewby_Dropdown_Id_Locator,
                    AssignContentPageResource.AssignContent_Page_Dropdown_Option_Value);
                this.SelectAssignWindow();
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_Viewby_Frame_Id_Locator));
                //Select Frame
                base.SwitchToIFrame(AssignContentPageResource.
                    AssignContent_Page_Viewby_Frame_Id_Locator);
                base.WaitForElement(By.XPath(AssignContentPageResource.
                    AssignContent_Page_GroupName_Viewby_Frame_Xpath_Locator));
                //Get Group Name
                getGroupName = base.GetElementTextByXPath(AssignContentPageResource.
                    AssignContent_Page_GroupName_Viewby_Frame_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "GetGroupName",
                base.IsTakeScreenShotDuringEntryExit);
            return getGroupName;
        }

        /// <summary>
        /// Get Due Date Of Assigned Content.
        /// </summary>
        /// <returns>Due Date.</returns>
        public String GetDueDateOfAssignedContent()
        {
            //Get Due Date Of Assigned Content
            logger.LogMethodEntry("AssignContentPage", "GetDueDateOfAssignedContent",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getDueDate = string.Empty;
            try
            {
                //Select Properties Window
                this.SelectPropertiesWindow();
                //Get Due Date Of Assigned Activity
                getDueDate = GetDueDateOfAssignedActivity(getDueDate);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "GetDueDateOfAssignedContent",
                base.IsTakeScreenShotDuringEntryExit);
            return getDueDate;
        }

        /// <summary>
        /// Select Properties Window.
        /// </summary>
        private void SelectPropertiesWindow()
        {
            //Select Properties Window
            logger.LogMethodEntry("AssignContentPage", "SelectPropertiesWindow",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(AssignContentPageResource.
                AssignContent_Page_Properties_WindowTitle_Name);
            //Select Window
            base.SelectWindow(AssignContentPageResource.
                AssignContent_Page_Properties_WindowTitle_Name);
            logger.LogMethodExit("AssignContentPage", "SelectPropertiesWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Select 'Assigned' Radiobutton.
        /// </summary>
        public void SelectAssignedRadiobutton()
        {
            //Select 'Assigned' Radiobutton
            logger.LogMethodEntry("AssignContentPage", "SelectAssignedRadiobutton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Properties Window
                this.SelectPropertiesWindow();
                //Check the Assignd Radio Button               
                IWebElement getRadioButton = base.GetWebElementPropertiesById(
                    AssignContentPageResource.AssignContent_Page_RadioButton_Assigned_Id_Locator);
                base.ClickByJavaScriptExecutor(getRadioButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "SelectAssignedRadiobutton",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select 'Set availability date range' Radiobutton.
        /// </summary>
        public void SelectSetavailabilitydaterangeRadiobutton()
        {
            //Select 'Set availability date range' Radiobutton
            logger.LogMethodEntry("AssignContentPage",
                "SelectSetavailabilitydaterangeRadiobutton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get the Current date
                string getCurrentDate = DateTime.Now.ToString
                    (AssignContentPageResource.AssignContent_Page_DateFormat);
                //Select Properties Window
                this.SelectPropertiesWindow();
                //Check the Set Availability Date Range Radio Button
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_SetAvailabilityDateRange_Radiobutton_Id_Locator));
                //Select Set Avalability Date Range Radiobutton
                base.ClickButtonById(AssignContentPageResource.
                    AssignContent_Page_SetAvailabilityDateRange_Radiobutton_Id_Locator);
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_FromDate_TextField_Id_Locator));
                base.ClearTextById(AssignContentPageResource.
                    AssignContent_Page_FromDate_TextField_Id_Locator);
                //Enter Current Date
                base.FillTextBoxById(AssignContentPageResource.
                    AssignContent_Page_FromDate_TextField_Id_Locator, getCurrentDate);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage",
                "SelectSetavailabilitydaterangeRadiobutton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Do Not Provide An End Date' Option.
        /// </summary>
        public void SelectDoNotProvideEndDateOption()
        {
            //Select 'Do Not Provide An End Date' Option
            logger.LogMethodEntry("AssignContentPage",
                "SelectDoNotProvideEndDateOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Properties Window
                this.SelectPropertiesWindow();
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_First_Checkbox_Id_Locator));
                //Select 'Do Not Provide An End Date' Option
                base.SelectCheckBoxById(AssignContentPageResource.
                    AssignContent_Page_First_Checkbox_Id_Locator);
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_Button_SaveAndAssign_Id_Locator));
                //Click on 'Save' Button
                base.ClickButtonById(AssignContentPageResource.
                    AssignContent_Page_Button_SaveAndAssign_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage",
                "SelectDoNotProvideEndDateOption",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Set Activity Property Settings.
        /// </summary>
        /// <param name="assetName">This is activity name.</param>
        public void SetActivityPropertiesSettings(string assetName)
        {
            // set activity properties
            logger.LogMethodEntry("AssignContentPage", "SetActivityPropertiesSettings",
                base.IsTakeScreenShotDuringEntryExit);
            switch (assetName)
            {

                case "Access Chapter 1: End-of-Chapter Quiz":
                    this.SelectPropertiesWindow();
                    base.WaitForElement(By.Id(AssignContentPageResource.
                        AssignContent_Page_DateAssigned_RadioButton_Id_Locator));
                    bool isActivityAssigned = base.IsElementSelectedById(AssignContentPageResource.
                        AssignContent_Page_DateAssigned_RadioButton_Id_Locator);
                    // is activity already assigned
                    if (!isActivityAssigned)
                    {
                        base.SelectRadioButtonById(AssignContentPageResource.
                        AssignContent_Page_DateAssigned_RadioButton_Id_Locator);
                    }
                    base.WaitForElement(By.Id(AssignContentPageResource.AssignContent_Page_DueDate_TextBox_Id_Locator));
                    // select current date
                    base.FillTextBoxById(AssignContentPageResource.AssignContent_Page_DueDate_TextBox_Id_Locator,
                        DateTime.Now.ToString(AssignContentPageResource.AssignContent_Page_DateFormat));
                    base.ClearTextById(AssignContentPageResource.AssignContent_Page_Hours_TextBox_Id_Locator);
                    // enter current hours
                    base.FillTextBoxById(AssignContentPageResource.AssignContent_Page_Hours_TextBox_Id_Locator,
                        DateTime.Now.Hour.ToString());
                    base.ClearTextById(AssignContentPageResource.AssignContent_Page_Minutes_TextBox_Id_Locator);
                    // enter after 3 minutes from current minute value
                    base.FillTextBoxById(AssignContentPageResource.AssignContent_Page_Minutes_TextBox_Id_Locator,
                        DateTime.Now.AddMinutes(4).Minute.ToString());
                    // click on save button
                    base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByPartialLinkText
                        (AssignContentPageResource.AssignContent_Page_Button_Save_Id_Locator));
                    break;
            }
            logger.LogMethodExit("AssignContentPage", "SetActivityPropertiesSettings",
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Get due date and fill that is duedate field
        /// </summary>
        public void GetAndFillDueDate()
        {
            logger.LogMethodEntry("AssignContentPage", "GetAndFillDueDate",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get the due date
                DateTime getDueDate = DateTime.Now.AddMinutes(5);

                // Enter the due date in due date text box
                base.WaitForElement(By.Id(AssignContentPageResource
               .AssignContent_Page_DueDate_TextBox_Id_Locator));
                base.ClearTextById(AssignContentPageResource
               .AssignContent_Page_DueDate_TextBox_Id_Locator);
                base.FillTextBoxById(AssignContentPageResource
                .AssignContent_Page_DueDate_TextBox_Id_Locator, getDueDate.ToString(AssignContentPageResource.AssignContent_Page_DateFormat));
                //clear current hours
                base.ClearTextById(AssignContentPageResource
                    .AssignContent_Page_Hours_TextBox_Id_Locator);
                // enter current hours
                base.FillTextBoxById(AssignContentPageResource
                    .AssignContent_Page_Hours_TextBox_Id_Locator, String.Format("{0:h }", getDueDate).Trim());
                base.ClearTextById(AssignContentPageResource
                    .AssignContent_Page_Minutes_TextBox_Id_Locator);
                // enter after 3 minutes from current minute value
                base.FillTextBoxById(AssignContentPageResource
                    .AssignContent_Page_Minutes_TextBox_Id_Locator, String.Format("{0:m }", getDueDate).Trim());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "GetAndFillDueDate",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Set the duedate and save the settings.
        /// </summary>
        public void SaveProperties()
        {

            logger.LogMethodEntry("AssignContentPage", "SaveProperties",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on save button
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByPartialLinkText
                        (AssignContentPageResource.AssignContent_Page_Button_Save_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "SaveProperties",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Sets start date and end date 
        /// </summary>
        public void SetStartAndEndDate()
        {
            logger.LogMethodEntry("AssignContentPage", "SetStartAndEndDate",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectSetavailabilitydaterangeRadiobutton();

                string dueDate = base.GetWebElementPropertiesById(AssignContentPageResource.
                    AssignContent_Page_DueDate_TextBox_Id_Locator).GetAttribute(AssignContentPageResource.
                    AssignContent_Page_DueDate_Value);

                DateTime endDate = Convert.ToDateTime(dueDate).AddDays(5);

                base.WaitForElement(By.Id(AssignContentPageResource.
                  AssignContent_Page_ToDate_TextField_Id_Locator));
                base.ClearTextById(AssignContentPageResource.
                AssignContent_Page_ToDate_TextField_Id_Locator);
                base.FillTextBoxById(AssignContentPageResource.
                AssignContent_Page_ToDate_TextField_Id_Locator, endDate.ToString
                        (AssignContentPageResource.AssignContent_Page_DateFormat));

                //Click on save button
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByPartialLinkText
                        (AssignContentPageResource.AssignContent_Page_Button_Save_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "SetStartAndEndDate",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Assign Radio button.
        /// </summary>
        public void SelectAssignRadiobutton()
        {
            //Select Assigned Radiobutton
            logger.LogMethodEntry("AssignContentPage", "SelectAssignRadiobutton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Assign Window
                this.SelectAssignWindow();
                //Wait For Element
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_RadioButton_Assigned_Id_Locator));
                if (!base.IsElementSelectedById(AssignContentPageResource.
                    AssignContent_Page_RadioButton_Assigned_Id_Locator))
                {
                    //Select Radiobutton
                    base.SelectRadioButtonById(AssignContentPageResource.
                    AssignContent_Page_RadioButton_Assigned_Id_Locator);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "SelectAssignRadiobutton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To click on the current date.
        /// </summary>
        public void SelectCurrentDate()
        {
            logger.LogMethodEntry("AssignContentPage", "SelectCurrentDate",
                         base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Properties Window
                this.SelectPropertiesWindow();
                //Get current date property
                IWebElement getCurrentDate = base.GetWebElementPropertiesByClassName(
                    AssignContentPageResource.
                    AssignContent_Page_CurrentDate_ClassName_Locator);
                //Click on the current date
                base.ClickByJavaScriptExecutor(getCurrentDate);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "SelectCurrentDate",
                            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///To click on save.
        /// </summary>
        public void ClickOnSave()
        {
            logger.LogMethodEntry("AssignContentPage", "ClickOnSave",
                        base.IsTakeScreenShotDuringEntryExit);
            IWebElement clickSave = base.GetWebElementPropertiesById("Save");
            base.ClickByJavaScriptExecutor(clickSave);
            logger.LogMethodExit("AssignContentPage", "ClickOnSave",
                            base.IsTakeScreenShotDuringEntryExit);
        }

      

        /// <summary>
        /// To click on the current date in Assign Window.
        /// </summary>
        public void SelectCurrentDateInAssignWindow()
        {
            logger.LogMethodEntry("AssignContentPage", "SelectCurrentDateInAssignWindow",
                         base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Properties Window
                this.SelectAssignWindow();
                Thread.Sleep(Convert.ToInt32(AssignContentPageResource.
                    AssignContent_Page_SleepTime_Value));
                int calendarRowCount = base.GetElementCountByXPath(AssignContentPageResource.
                    AssignContent_Page_Calendar_RowCount_Xpath_Locator);
                for (int i = 1; i <= calendarRowCount; i++)
                {
                    int calendarColumnCount = base.GetElementCountByXPath(String.
                        Format(AssignContentPageResource.
                        AssignContent_Page_Calendar_ColumnCount_Xpath_Locator, i));
                    for (int j = 1; j <= calendarColumnCount; j++)
                    {
                        //Verify if date value is present or blank in a cell in calendar
                        bool dayValuePresent = base.IsElementPresent(By.XPath(String.
                            Format(AssignContentPageResource.
                            AssignContent_Page_Calendar_DateValueInColumn_Xpath_Locator, i, j)), 3);
                        if (dayValuePresent)
                        {
                            //Gets the date value from calendar
                            IWebElement getDateValue = base.GetWebElementPropertiesByXPath(String
                                .Format(AssignContentPageResource.
                                AssignContent_Page_Calendar_DateValueInColumn_Xpath_Locator, i, j));
                            //Get the class name of the date 
                            string dateClass = getDateValue.GetAttribute("class");
                            if (dateClass == AssignContentPageResource.
                                AssignContent_Page_CurrentDate_ClassName_Locator)
                            {
                                Thread.Sleep(Convert.ToInt32(AssignContentPageResource.
                                    AssignContent_Page_SleepTime_Value));
                                switch (base.Browser)
                                {
                                    //Double click on date if 'Chrome' or 'Firefox' browser
                                    case PegasusBaseTestFixture.Chrome:
                                    case PegasusBaseTestFixture.FireFox:
                                        base.DoubleClickByJavaScriptExecuter(getDateValue);
                                        break;
                                    //Double click on date if 'IE' browser
                                    case PegasusBaseTestFixture.InternetExplorer:
                                        base.DoubleClickInIEByJavaScriptExecuter(getDateValue);
                                        break;
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "SelectCurrentDateInAssignWindow",
                            base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Sets start date and end date 
        /// </summary>
        public void SetStartAndEndDateAssignWindow()
        {
            logger.LogMethodEntry("AssignContentPage", "SetStartAndEndDateAssignWindow",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Enters the start date
                this.SelectSetavailabilitydaterangeRadiobuttonAssignWindow();
                //Select 'Set End Date as Due Date'
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_SetEndDateAsDueDate_Checkbox_Id_Locator));
                base.SelectCheckBoxById(AssignContentPageResource.
                    AssignContent_Page_SetEndDateAsDueDate_Checkbox_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "SetStartAndEndDateAssignWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        public void SelectSetavailabilitydaterangeRadiobuttonAssignWindow()
        {

            //Select 'Set availability date range' Radiobutton
            logger.LogMethodEntry("AssignContentPage",
                "SelectSetavailabilitydaterangeRadiobuttonAssignWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get the Current date
                string getCurrentDate = DateTime.Now.ToString
                    (AssignContentPageResource.AssignContent_Page_DateFormat);
                //Select Properties Window
                this.SelectAssignWindow(); 
                    //Check the Set Availability Date Range Radio Button
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_SetAvailabilityDateRange_Radiobutton_Id_Locator));
                //Select Set Avalability Date Range Radiobutton
                base.ClickButtonById(AssignContentPageResource.
                    AssignContent_Page_SetAvailabilityDateRange_Radiobutton_Id_Locator);
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_FromDate_TextField_Id_Locator));
                base.ClearTextById(AssignContentPageResource.
                    AssignContent_Page_FromDate_TextField_Id_Locator);
                //Enter Current Date
                base.FillTextBoxById(AssignContentPageResource.
                    AssignContent_Page_FromDate_TextField_Id_Locator, getCurrentDate);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage",
                "SelectSetavailabilitydaterangeRadiobuttonAssignWindow",
                base.IsTakeScreenShotDuringEntryExit);
        
        }



        /// <summary>
        /// Selects availability notifuication check box.
        /// </summary>
        public void CheckAvailabilityNotification()
        {
            // Selects availability notifuication check box
            logger.LogMethodEntry("AssignContentPage",
                "CheckAvailabilityNotificatio",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                this.SelectAssignWindow();
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_Third_Checkbox_Id_Locator));
                // Selects availability notifuication check box
                base.SelectCheckBoxById(AssignContentPageResource.
                    AssignContent_Page_Third_Checkbox_Id_Locator);
                base.WaitForElement(By.Id(AssignContentPageResource.
                    AssignContent_Page_Button_SaveAndAssign_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage",
                "CheckAvailabilityNotificatio",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select 'Assigned' Radiobutton.
        /// </summary>
        public void SelectAssignRadiobuttonInAssignWindow()
        {
            //Select 'Assigned' Radiobutton
            logger.LogMethodEntry("AssignContentPage", "SelectAssignedRadiobutton",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Properties Window
                this.SelectAssignWindow();
                //Check the Assignd Radio Button               
                IWebElement getRadioButton = base.GetWebElementPropertiesById(
                    AssignContentPageResource.AssignContent_Page_RadioButton_Assigned_Id_Locator);
                base.ClickByJavaScriptExecutor(getRadioButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AssignContentPage", "SelectAssignedRadiobutton",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }

}

