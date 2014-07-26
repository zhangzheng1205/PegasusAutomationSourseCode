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
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Planner.Calendar;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Creation of Periods for Calendar
    /// </summary>
    public class CreatePeriodsPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(CreatePeriodsPage));

        /// <summary>
        /// Create Periods
        /// </summary>
        public void CreatePeriods()
        {
            //Create Periods
            logger.LogMethodEntry("CreatePeriodsPage", "CreatePeriods",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the 'Calendar' window
                base.SelectWindow(EmptyCalendarPageResource.
                    EmptyCalendarPage_Calendar_Window_Title_NN);
                //Switch to Frame
                base.WaitForElement(By.Id(CalendarSetupPageResource.
                    CalendarSetupPage_Main_Iframe_Id_Locator));
                base.SwitchToIFrame(CalendarSetupPageResource.
                    CalendarSetupPage_Main_Iframe_Id_Locator);
                base.WaitForElement(By.Id(CreatePeriodsPageResource.
                    CreatePeriodsPage_Iframe_Id_Locator));
                base.SwitchToIFrame(CreatePeriodsPageResource.
                    CreatePeriodsPage_Iframe_Id_Locator);
                //Select the Order Value And Enter the Period Name
                this.SelectOrderValueAndEnterPeriodName();
                //Selects the Days
                this.SelectTheDays();
                //Select the Associations
                this.ClassAndCourseAssociation();
                //Click on the Save button            
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesById(
                    CreatePeriodsPageResource.CreatePeriodsPage_Button_Save_Id_Locator));
            }
            catch ( Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreatePeriodsPage", "CreatePeriods",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Class And Course Associations
        /// </summary>
        private void ClassAndCourseAssociation()
        {
            //Class And Course Associations
            logger.LogMethodEntry("CreatePeriodsPage", "ClassAndCourseAssociation",
                base.isTakeScreenShotDuringEntryExit);
            //Class Associations            
            if ( base.GetWebElementPropertiesById(CreatePeriodsPageResource.
                CreatePeriodsPage_ClassAssociations_DropDown_Id_Locator).Enabled )
            {
                base.SelectDropDownValueThroughIndexById(CreatePeriodsPageResource.
                CreatePeriodsPage_ClassAssociations_DropDown_Id_Locator,
                Convert.ToInt32(CreatePeriodsPageResource.
                CreatePeriodsPage_ClassAssociations_DropDown_Index_Value));
            }
            //Course Associations
            if ( base.GetWebElementPropertiesById(CreatePeriodsPageResource.
                CreatePeriodsPage_CourseAssociations_DropDown_Id_Locator).Enabled )
            {
                base.SelectDropDownValueThroughIndexById(CreatePeriodsPageResource.
                CreatePeriodsPage_CourseAssociations_DropDown_Id_Locator,
                Convert.ToInt32(CreatePeriodsPageResource.
                CreatePeriodsPage_CourseAssociations_DropDown_Index_Value));
            }
            logger.LogMethodExit("CreatePeriodsPage", "ClassAndCourseAssociation",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Days
        /// </summary>
        private void SelectTheDays()
        {
            //Select the Days
            logger.LogMethodEntry("CreatePeriodsPage", "SelectTheDays",
                base.isTakeScreenShotDuringEntryExit);
            IWebElement getMonday=base.GetWebElementPropertiesById
                (CreatePeriodsPageResource.
                CreatePeriodsPage_Checkbox_Monday_Id_Locator);
            //Select the Checkbox for Monday
            base.ClickByJavaScriptExecutor(getMonday);
           IWebElement getTuesday=base.GetWebElementPropertiesById
               (CreatePeriodsPageResource.
                CreatePeriodsPage_Checkbox_Tuesday_Id_Locator);           
            //Select the Checkbox for Tuesday
           base.ClickByJavaScriptExecutor(getTuesday);
            IWebElement getWednesday=base.GetWebElementPropertiesById
                (CreatePeriodsPageResource.
                CreatePeriodsPage_Checkbox_Wednesday_Id_Locator);
            //Select the Checkbox for Wednesday
            base.ClickByJavaScriptExecutor(getWednesday);
           IWebElement getThursday=base.GetWebElementPropertiesById
               (CreatePeriodsPageResource.
                CreatePeriodsPage_Checkbox_Thursday_Id_Locator);
           //Select the Checkbox for Thursday
           base.ClickByJavaScriptExecutor(getThursday);
           IWebElement getFriday=base.GetWebElementPropertiesById
               (CreatePeriodsPageResource.
                CreatePeriodsPage_Checkbox_Friday_Id_Locator);           
            //Select the Checkbox for Friday
           base.ClickByJavaScriptExecutor(getFriday);
            IWebElement getSaturday=base.GetWebElementPropertiesById
                (CreatePeriodsPageResource.
                CreatePeriodsPage_Checkbox_Saturday_Id_Locator);
            //Select the Checkbox for Saturday
            base.ClickByJavaScriptExecutor(getSaturday);
            IWebElement getSunday=base.GetWebElementPropertiesById
                (CreatePeriodsPageResource.
                CreatePeriodsPage_Checkbox_Sunday_Id_Locator);           
            //Select the Checkbox for Sunday
            base.ClickByJavaScriptExecutor(getSunday);           
            logger.LogMethodExit("CreatePeriodsPage", "SelectTheDays",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Order Value And Enter the Period Name
        /// </summary>
        private void SelectOrderValueAndEnterPeriodName()
        {
            //Select the Order Value And Enter the Period Name
            logger.LogMethodEntry("CreatePeriodsPage", "SelectOrderValueAndEnterPeriodName",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for Drop down
            base.WaitForElement(By.Id(CreatePeriodsPageResource.
                CreatePeriodsPage_Order_DropDown_Id_Locator));
            base.SelectDropDownValueThroughIndexById(CreatePeriodsPageResource.
                CreatePeriodsPage_Order_DropDown_Id_Locator, Convert.ToInt32(
                CreatePeriodsPageResource.CreatePeriodsPage_Order_DropDown_Index_Value));
            //Display Name
            base.FillTextBoxById(CreatePeriodsPageResource.
                CreatePeriodsPage_Textbox_PeriodName_Id_Locator, CreatePeriodsPageResource.
                CreatePeriodsPage_Textbox_PeriodName_Value);
            logger.LogMethodExit("CreatePeriodsPage", "SelectOrderValueAndEnterPeriodName",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
