using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using System.Threading;
using System.IO;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles Catalog Preferences Page Actions.
    /// </summary>
    public class CatalogPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(CatalogPreferencesPage));

        /// <summary>
        /// Enable Catalog Preference Settings.
        /// </summary>
        public void EnableCatalogPreferenceSettings()
        {
            //Enable Catalog Preference Settings
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnableCatalogPreferenceSettings", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window And Main Frame
                this.SelectWindowAndMainFrame();
                //Upload Course Icon Image
                this.UploadCourseIconImage();
                //Enter Text Book Title And ISBN
                this.EnterTextBookTitleAndISBN();
                //Enter Text Book Author First Last Name
                this.EnterTextBookAuthorFirstLastName();
                //Select Publisher And Discipline Dropdown Value
                this.SelectPublisherAndDisciplineDropdownValue(); 
                //Save Preferences
                new GeneralPreferencesPage().SavePreferences();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnableCatalogPreferenceSettings", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Publisher And Discipline Dropdown Value.
        /// </summary>
        private void SelectPublisherAndDisciplineDropdownValue()
        {
            //Select Publisher And Discipline Dropdown Value
            logger.LogMethodEntry("GeneralPreferencesPage",
            "SelectPublisherAndDisciplineDropdownValue",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Publisher Dropdown Value
            base.WaitForElement(By.Id(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_Publisher_Dropdown_Id_Locator));
            base.FocusOnElementById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_Publisher_Dropdown_Id_Locator);
            base.SelectDropDownValueThroughTextById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_Publisher_Dropdown_Id_Locator,
                CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_Publisher_Dropdown_Value);
            //Select Discipline Dropdown Value
            base.WaitForElement(By.Id(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_Discipline_Dropdown_Id_Locator));
            base.FocusOnElementById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_Discipline_Dropdown_Id_Locator);
            base.SelectDropDownValueThroughTextById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_Discipline_Dropdown_Id_Locator,
                CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_Discipline_Dropdown_Value);
            logger.LogMethodExit("GeneralPreferencesPage",
            "SelectPublisherAndDisciplineDropdownValue",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Text Book Author First Last Name.
        /// </summary>
        private void EnterTextBookAuthorFirstLastName()
        {
            //Enter Text Book Author First Last Name
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnterTextBookAuthorFirstLastName", base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_TextBook_Author_Firstname_Text_Id_Locator));
            base.ClearTextById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_TextBook_Author_Firstname_Text_Id_Locator);
            //Enter Text Book Author First Name
            base.FillTextBoxById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_TextBook_Author_Firstname_Text_Id_Locator,
                CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_TextBook_Author_Firstname_Value);
            base.WaitForElement(By.Id(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_TextBook_Author_Lastname_Text_Id_Locator));
            base.ClearTextById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_TextBook_Author_Lastname_Text_Id_Locator);
            //Enter Text Book Author Last Name
            base.FillTextBoxById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_TextBook_Author_Lastname_Text_Id_Locator,
                CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_TextBook_Author_Lastname_Value);
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnterTextBookAuthorFirstLastName", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Text Book Title And ISBN.
        /// </summary>
        private void EnterTextBookTitleAndISBN()
        {
            //Enter Text Book Title And ISBN
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnterTextBookTitleAndISBN", base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_TextBookTitle_Text_Id_Locator));
            base.ClearTextById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_TextBookTitle_Text_Id_Locator);
            Thread.Sleep(Convert.ToInt32(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_Wait_Time_Value));
            //Enter Text Book Title
            base.FillTextBoxById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_TextBookTitle_Text_Id_Locator,
                CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_TextBookTitle_Value);
            base.WaitForElement(By.Id(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_ISBN10_Text_Id_Locator));
            base.ClearTextById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_ISBN10_Text_Id_Locator);
            //Enter 10 Digit ISBN
            base.FillTextBoxById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_ISBN10_Text_Id_Locator,
                CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_ISBN10_Value);
            base.WaitForElement(By.Id(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_ISBN13_Text_Id_Locator));
            base.ClearTextById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_ISBN13_Text_Id_Locator);
            //Enter 13 Digit ISBN
            base.FillTextBoxById(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_ISBN13_Text_Id_Locator,
                CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_ISBN13_Value);
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnterTextBookTitleAndISBN", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Upload Course Icon Image.
        /// </summary>
        private void UploadCourseIconImage()
        {
            //Upload Course Icon Image
            logger.LogMethodEntry("GeneralPreferencesPage",
            "UploadCourseIconImage", base.IsTakeScreenShotDuringEntryExit);
            //Wait for the upload button
            base.WaitForElement(By.Id(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_CatalogIcon_Browse_Button_Id_Locator));
            //Get the Course Icon Image File Path
            string getCourseIconImageFilePath = (AutomationConfigurationManager.TestDataPath
            + CatalogPreferencesPageResource.CatalogPreferences_Page_Resource_CourseIcon_Path).
                Replace("file:\\", "");
            //Upload the Course Icon image
            base.UploadFile(getCourseIconImageFilePath,
                By.Id(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_CatalogIcon_Browse_Button_Id_Locator));
            logger.LogMethodExit("GeneralPreferencesPage",
            "UploadCourseIconImage", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Window And Main Frame.
        /// </summary>
        private void SelectWindowAndMainFrame()
        {
            //Select Window And Main Frame
            logger.LogMethodEntry("GeneralPreferencesPage", "SelectTheMainFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Window
            base.WaitUntilWindowLoads(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_Window_Title);
            base.SelectWindow(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_Window_Title);
            //Wait for the Frame
            base.WaitForElement(By.Id(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_Page_MiddleFrame_Id_Locator));
            base.SwitchToIFrame(CatalogPreferencesPageResource.
                CatalogPreferences_Page_Resource_Page_MiddleFrame_Id_Locator);
            logger.LogMethodExit("GeneralPreferencesPage", "SelectTheMainFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
