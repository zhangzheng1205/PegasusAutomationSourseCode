using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using OpenQA.Selenium;
using System.Threading;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings
{
    /// <summary>
    /// This Class Handles Course Material Preferences Page Actions.
    /// </summary>
    public class CourseMaterialPreferencePage : BasePage
    {

        /// <summary>
        /// The Static Instance of the Logger for the Class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(CourseMaterialPreferencePage));

        /// <summary>
        /// Setting The EText Preferences.
        /// </summary>
        public void SetETextPreferenceInCourseMaterialTab()
        {
            Logger.LogMethodEntry("CourseMaterialPreferencePage",
                "SetETextPreferenceInCourseMaterialTab",
           base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select window
                this.SelectPreferencesWindow();
                //Switch to frame
                this.SwitchToFrame();
                //Enter EText Linking Content Details
                this.SetETextLinkingContentPreference();
                //Save The Preference
                new GeneralPreferencesPage().SavePreferences();
                //Pause The Execution
                Thread.Sleep(Convert.ToInt32(CourseMaterialPreferencePageResource.
                CourseMaterialPreferences_Page_Thread_Wait_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseMaterialPreferencePage",
                "SetETextPreferenceInCourseMaterialTab",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch To Preference Frame.
        /// </summary>
        private void SwitchToFrame()
        {
            //Switch To Frame
            Logger.LogMethodEntry("CourseMaterialPreferencePage",
              "SwitchToFrame",
         base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(CourseMaterialPreferencePageResource.
                CourseMaterialPreferences_Page_Frame_Id_Locator));
            //Switch To IFrame
            base.SwitchToIFrame(CourseMaterialPreferencePageResource.
                CourseMaterialPreferences_Page_Frame_Id_Locator);
            Logger.LogMethodExit("CourseMaterialPreferencePage",
              "SwitchToFrame",
         base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Preferences Window.
        /// </summary>
        private void SelectPreferencesWindow()
        {
            //Select Window
            Logger.LogMethodEntry("CourseMaterialPreferencePage",
             "SelectPreferencesWindow", base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(CourseMaterialPreferencePageResource.
                CourseMaterialPreferences_Page_Window_Title);
            Logger.LogMethodExit("CourseMaterialPreferencePage",
             "SelectPreferencesWindow", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter EText Linking Content Preferences.
        /// </summary>
        private void SetETextLinkingContentPreference()
        {
            //Enter EText Linking Preference
            Logger.LogMethodEntry("CourseMaterialPreferencePage",
            "SetETextLinkingContentPreference", base.isTakeScreenShotDuringEntryExit);
            //Wait for element
            base.WaitForElement(By.Id(CourseMaterialPreferencePageResource.
                  CourseMaterialPreference_Page_EnableETextLinking_CheckBox_Id_Locator));
            //Pause The Execution
            Thread.Sleep(Convert.ToInt32(CourseMaterialPreferencePageResource.
            CourseMaterialPreferences_Page_Thread_Wait_Time));
            //Validate that Enable eText Linking check box is checked or not 
            if (!base.IsElementSelectedById(CourseMaterialPreferencePageResource.
                  CourseMaterialPreference_Page_EnableETextLinking_CheckBox_Id_Locator))
            {
                //Select EText Linking Checkbox
                this.SelectEnableETextLinkingCheckBox();
                //Enter EText Book Code
                this.EnterETextBookCode();
                //Enter EText Book Id
                this.EnterETextBookID();
                //Enter EText Book Title
                this.EnterETextBookTitle();
                //Select ETetx Linking CheckBox
                this.SelectETextAllowLinkingCheckBox();
            }
            Logger.LogMethodExit("CourseMaterialPreferencePage",
           "SetETextLinkingContentPreference", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter EText Book Code.
        /// </summary>
        private void EnterETextBookCode()
        {
            //Enter EText Book Code
            Logger.LogMethodEntry("CourseMaterialPreferencePage",
           "EnterETextBookCode", base.isTakeScreenShotDuringEntryExit);
            //Fill the "Book Code"
            base.WaitForElement(By.Id(CourseMaterialPreferencePageResource.
                                          CourseMaterialPreference_Page_BookCode_Id_Locator));
            //Enter Book Code
            base.FillTextBoxById(CourseMaterialPreferencePageResource.
                                     CourseMaterialPreference_Page_BookCode_Id_Locator,
                                 CourseMaterialPreferencePageResource.
                                     CourseMaterialPreference_Page_BookCode_Value);
            Logger.LogMethodEntry("CourseMaterialPreferencePage",
           "EnterETextBookCode", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter EText Book Id.
        /// </summary>
        private void EnterETextBookID()
        {
            //Enter Book Id
            Logger.LogMethodEntry("CourseMaterialPreferencePage",
           "EnterETextBookID", base.isTakeScreenShotDuringEntryExit);
            //Fill the "Book Id"
            base.WaitForElement(By.Id(CourseMaterialPreferencePageResource.
                                          CourseMaterialPreference_Page_BookId_Id_Locator));
            //Enter Book Id
            base.FillTextBoxById(CourseMaterialPreferencePageResource.
                                     CourseMaterialPreference_Page_BookId_Id_Locator,
                                 CourseMaterialPreferencePageResource.
                                     CourseMaterialPreference_Page_BookId_Id_Value);
            Logger.LogMethodExit("CourseMaterialPreferencePage",
           "EnterETextBookID", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter EText Book Title.
        /// </summary>
        private void EnterETextBookTitle()
        {
            //Enter Book Title
            Logger.LogMethodEntry("CourseMaterialPreferencePage",
           "EnterETextBookTitle", base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(CourseMaterialPreferencePageResource.
                                          CourseMaterialPreference_Page_BookTitle_Id_Locator));
            //Enter Book Title
            base.FillTextBoxById(CourseMaterialPreferencePageResource.
                                     CourseMaterialPreference_Page_BookTitle_Id_Locator,
                                 CourseMaterialPreferencePageResource.
                                     CourseMaterialPreference_Page_BookTitle_Id_Value);
            Logger.LogMethodEntry("CourseMaterialPreferencePage",
           "EnterETextBookTitle", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select EText Allow Linking CheckBox.
        /// </summary>
        private void SelectETextAllowLinkingCheckBox()
        {
            //Select Checkbox
            Logger.LogMethodEntry("CourseMaterialPreferencePage",
           "SelectETextAllowLinkingCheckBox", base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(CourseMaterialPreferencePageResource.
                                          CourseMaterialPreference_Page_AllowLinking_CheckBox_Id_Locator));
            //Select CheckBox
            base.SelectCheckBoxById(CourseMaterialPreferencePageResource.
                                       CourseMaterialPreference_Page_AllowLinking_CheckBox_Id_Locator);
            Thread.Sleep(Convert.ToInt32(CourseMaterialPreferencePageResource.
                                             CourseMaterialPreferences_Page_Thread_Wait_Time));
            Logger.LogMethodExit("CourseMaterialPreferencePage",
           "SelectETextAllowLinkingCheckBox", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Enable EText Linking Checkbox.
        /// </summary>
        private void SelectEnableETextLinkingCheckBox()
        {
            //Select Checkbox
            Logger.LogMethodEntry("CourseMaterialPreferencePage",
           "SelectEnableETextLinkingCheckBox", base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(CourseMaterialPreferencePageResource.
                 CourseMaterialPreference_Page_EnableETextLinking_CheckBox_Id_Locator));
            //Get Peroperty of EnableETextcheckbox
            IWebElement getPropertyOfEnableETextcheckbox = base.
                GetWebElementPropertiesById(CourseMaterialPreferencePageResource.
                 CourseMaterialPreference_Page_EnableETextLinking_CheckBox_Id_Locator);
            //Select CheckBox
            base.ClickByJavaScriptExecutor(getPropertyOfEnableETextcheckbox);
            Logger.LogMethodExit("CourseMaterialPreferencePage",
           "SelectEnableETextLinkingCheckBox", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Disable Hide MyCourse Materials Preference.
        /// </summary>
        public void DisableHideMyCourseMaterialsPreference()
        {
            //Disable Hide MyCourse Materials Preference
            Logger.LogMethodEntry("CourseMaterialPreferencePage",
           "SelectEnableETextLinkingCheckBox", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select window
                this.SelectPreferencesWindow();
                //Switch to frame
                this.SwitchToFrame();
                //Wait For Element
                base.WaitForElement(By.Id(CourseMaterialPreferencePageResource.
                    CourseMaterialPreferences_Page_HideMyCourseMaterials_Checkbox_Id_Locator));
                if (base.IsElementSelectedById(CourseMaterialPreferencePageResource.
                    CourseMaterialPreferences_Page_HideMyCourseMaterials_Checkbox_Id_Locator))
                {
                    //Uncheck the Preference
                    IWebElement getPreferenceProperty =
                        base.GetWebElementPropertiesById(CourseMaterialPreferencePageResource.
                    CourseMaterialPreferences_Page_HideMyCourseMaterials_Checkbox_Id_Locator);
                    base.ClickByJavaScriptExecutor(getPreferenceProperty);
                }
                //Save The Preference
                new GeneralPreferencesPage().SavePreferences();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("CourseMaterialPreferencePage",
           "SelectEnableETextLinkingCheckBox", base.isTakeScreenShotDuringEntryExit);
        }
    }
}
