using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using System.Collections.Generic;
using System.Linq;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    ///  This class handles Pegasus ActivitiesPreferences Page Actions.
    /// </summary>
    public class ActivitiesPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(ActivitiesPreferencesPage));

        /// <summary>
        /// Save Activity Preferences.
        /// </summary>
        public void SaveActivityPreferences()
        {
            //Save Preferences
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "SaveActivityPreferences", base.isTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(Convert.ToInt32(StandardSkillPreferencesPageResource.
                   StandardSkillPreferences_Page_ThreadSleep_Value));
                //Select Default Window
                base.SelectWindow(LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_WindowName);
                //Select Iframe
                base.SwitchToIFrame(LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_PreferencesPage_Iframe_Id_Locator);
                //Wait For Save Preferences Button
                base.WaitForElement(By.PartialLinkText(LTIToolsPreferencesPageResource.
                        LTIToolsPreferences_Page_SavePreferences_Button_PartialText_Locator),
                        Convert.ToInt32(LTIToolsPreferencesPageResource.
                        LTIToolsPreferences_Page_TimeToWait_Value));
                //Get HTML Element Property for Cmenu
                IWebElement getSavePreferences = base.GetWebElementPropertiesByPartialLinkText
                 (LTIToolsPreferencesPageResource.
                        LTIToolsPreferences_Page_SavePreferences_Button_PartialText_Locator);
                getSavePreferences.SendKeys(string.Empty);
                //Click on the Course CMenu 
                base.ClickByJavaScriptExecutor(getSavePreferences);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "SaveActivityPreferences", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity Edit Option.
        /// </summary>
        public void ClickOnActivityEditOption()
        {
            //Click On Activity Edit Option
            logger.LogMethodEntry("ActivitiesPreferencesPage",
                "ClickOnActivityEditOption", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Prefernces Window
                base.SelectWindow(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_Preferences_Window_Name);
                base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_Frame_Id_Locator));
                //Switch to Iframe
                base.SwitchToIFrame(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_Frame_Id_Locator);
                //Click On Edit Option
                this.ClickOnEditOption();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "ClickOnActivityEditOption", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Edit Option.
        /// </summary>
        private void ClickOnEditOption()
        {
            //Click On Edit Option
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "ClickOnEditOption", base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EditButton_Id_Locator));
            //Get Edit Option Property
            IWebElement getEditOptionProperty = base.GetWebElementPropertiesById(
                ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EditButton_Id_Locator);
            //Click On Edit Option
            base.ClickByJavaScriptExecutor(getEditOptionProperty);
            logger.LogMethodExit("ActivitiesPreferencesPage",
                "ClickOnEditOption", base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Assignment Activity Edit Option.
        /// </summary>
        public void ClickOnAssignmentActivityEditOption()
        {
            //Click On Activity Edit Option
            logger.LogMethodEntry("ActivitiesPreferencesPage",
                "ClickOnAssignmentActivityEditOption", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Prefernces Window
                base.SelectWindow(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_Preferences_Window_Name);
                base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_Frame_Id_Locator));
                //Switch to Iframe
                base.SwitchToIFrame(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_Frame_Id_Locator);
                //Click On Edit Option
                this.ClickOnAssignmentEditOption();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "ClickOnAssignmentActivityEditOption", base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Assignment behavioral activity Edit Option.
        /// </summary>
        private void ClickOnAssignmentEditOption()
        {
            //Click On Edit Option
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "ClickOnAssignmentEditOption", base.isTakeScreenShotDuringEntryExit);

            // Activity Type Name Collection
            ICollection<IWebElement> ActivityTypeEditCollection = base.GetWebElementsCollectionById(
                    ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_EditButton_Id_Locator);
            // Activity Type Name corresponding Edit Preferences Link Collection 
            ICollection<IWebElement> ActivityTypesCollection = base.GetWebElementsCollectionByPartialCssSelector(
                    ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_NewActivityTypeName_CSSSelector);
            
            int i = 0;
            //click on the Edit Preferences Link for the desired Activity Type Name out of the Collection
            foreach (IWebElement ActivityType in ActivityTypesCollection)
            {
                i++;

                if (ActivityType.Enabled && ActivityType.GetAttribute("value") == 
                    ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_AssignmentActivityTypeName_Value)
                {
                    int j = 0;
                    foreach(IWebElement ActivityTypeEdit in ActivityTypeEditCollection)
                    {
                        j++;
                        if(i==j)
                        {
                            base.ClickByJavaScriptExecutor(ActivityTypeEdit);
                            break;
                        }
                    }                    
                    break;
                }
            }

            logger.LogMethodExit("ActivitiesPreferencesPage",
                "ClickOnAssignmentEditOption", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Allow Activity To Be Used As Pretest Or Posttest' Option.
        /// </summary>
        public void SelectAllowActivityToBeUsedAsPretestOrPosttestOption()
        {
            //Select 'Allow Activity To Be Used As Pretest Or Posttest' Option
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "SelectAllowActivityToBeUsedAsPretestOrPosttestOption", 
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on the Activities Link
                new GeneralPreferencesPage().ClickonSubTabofPreference(
                    ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_Activities_Link_PartialText_Locator);
                //Select Preferences Window
                this.SelectPreferencesWindow();
                //Select Iframe
                this.SelectPreferencesMainFrame();
                //Click on the MGM Edit Link
                this.ClickOnMGMTestEditLink();
                LTIDefaultPreferencesPage lTIDefaultPrefrences = 
                    new LTIDefaultPreferencesPage();
                //Select the Option            
                lTIDefaultPrefrences.SelectTheLTIOption();
                lTIDefaultPrefrences.ClickOnApplyAllButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage",
                "SelectAllowActivityToBeUsedAsPretestOrPosttestOption", 
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'MGM Test' Edit Link.
        /// </summary>
        private void ClickOnMGMTestEditLink()
        {
            //Click On 'MGM Test' Edit Link
            logger.LogMethodEntry("ActivitiesPreferencesPage","ClickOnMGMTestEditLink",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the Element
            base.WaitForElement(By.XPath(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EditMathXLTestPreference_Link_Xpath_Locator));
            //Click on the Link
            base.ClickByJavaScriptExecutor(base.
                GetWebElementPropertiesByXPath(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EditMathXLTestPreference_Link_Xpath_Locator));            
            logger.LogMethodExit("ActivitiesPreferencesPage","ClickOnMGMTestEditLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Preferences Window.
        /// </summary>
        private void SelectPreferencesWindow()
        {
            //Select Preferences window
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "SelectPreferencesWindow", base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Preferences_Window_Name);
            //Select Preferences Window
            base.SelectWindow(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Preferences_Window_Name);
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "SelectPreferencesWindow", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Preferences Main Frame.
        /// </summary>
        private void SelectPreferencesMainFrame()
        {
            //Select Preferences Main Frame.
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "SelectPreferencesMainFrame", base.isTakeScreenShotDuringEntryExit);
            //Switch to Iframe
            base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Frame_Id_Locator));
            base.SwitchToIFrame(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Frame_Id_Locator);
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "SelectPreferencesMainFrame", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Remove Multiple Attempt CheckBox.
        /// </summary>
        public void ClickTheRemoveMultipleAttemptCheckBox()
        {
            //Click The Remove Multiple Attempt CheckBox
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "ClickTheRemoveMultipleAttemptCheckBox",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Enable 'Remove Multople attempt Preference                
                new GeneralPreferencesPage().EnableGeneralPreferenceSettings
                    (ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_removeMultipleAttempt_Lock_Id_Locator,
                    ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_removeMultipleAttempt_Checkbox_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "ClickTheRemoveMultipleAttemptCheckBox",
               base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Messages Sub-Tab.
        /// </summary>
        public void ClickOnMessagesSubTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "ClickOnMessagesSubTab", base.isTakeScreenShotDuringEntryExit);
            // wait for Messages tab
            base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_MessagesSubTab_Id_Locator));

            //Get Messages sub-tab link
            IWebElement getMessagesSubTab = base.GetWebElementPropertiesById(
                ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_MessagesSubTab_Id_Locator);
            //Click On Messages sub-tab link
            base.ClickByJavaScriptExecutor(getMessagesSubTab);

            logger.LogMethodExit("ActivitiesPreferencesPage",
               "ClickOnMessagesSubTab", base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enter Beginning Of Activity Default And Instructor Messages.
        /// </summary>
        public void EnterBeginningOfActivityDefaultAndInstructorMessages()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "EnterBeginningOfActivityDefaultAndInstructorMessages", base.isTakeScreenShotDuringEntryExit);

            // wait for Begin Default Message text box
            base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_BeginDefaultMessage_Id_Locator));
            // clear Begin Default message text box
            base.ClearTextById(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_BeginDefaultMessage_Id_Locator);
            // fill Begin Default Message text box
            base.FillTextBoxById(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_BeginDefaultMessage_Id_Locator,
                ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_BeginDefaultMessage_Text);

            // wait for Begin Instructor Message text box
            base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_BeginInstructorMessage_Id_Locator));
            // clear Begin Instructor Message text box
            base.ClearTextById(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_BeginInstructorMessage_Id_Locator);
            // fill Begin Instructor Message text box
            base.FillTextBoxById(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_BeginInstructorMessage_Id_Locator,
                ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_BeginInstructorMessage_Text);

            logger.LogMethodExit("ActivitiesPreferencesPage",
               "EnterBeginningOfActivityDefaultAndInstructorMessages", base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// returns Activity Begin Default Message.
        /// </summary>
        /// <returns>string</returns>
        public string returnActivityBeginDefaultMessage()
        { return ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_BeginDefaultMessage_Text; }
        /// <summary>
        /// returns Activity Begin Instructor Message.
        /// </summary>
        /// <returns>string</returns>
        public string returnActivityBeginInstructorMessage()
        { return ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_BeginInstructorMessage_Text; }
        /// <summary>
        /// returns Activity End Default Message.
        /// </summary>
        /// <returns>string</returns>
        public string returnActivityEndDefaultMessage()
        { return ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_EndDefaultMessage_Text; }
        /// <summary>
        /// returns Activity End Instructor Message.
        /// </summary>
        /// <returns>string</returns>
        public string returnActivityEndInstructorMessage()
        { return ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_EndInstructorMessage_Text; }

        /// <summary>
        /// Enter End Of Activity Default And Instructor Messages.
        /// </summary>
        public void EnterEndOfActivityDefaultAndInstructorMessages()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "EnterEndOfActivityDefaultAndInstructorMessages", base.isTakeScreenShotDuringEntryExit);

            // wait for End Default Message text box
            base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EndDefaultMessage_Id_Locator));
            // clear End Default Message text box
            base.ClearTextById(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EndDefaultMessage_Id_Locator);
            // fill End Default Message Text box
            base.FillTextBoxById(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EndDefaultMessage_Id_Locator,
                ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_EndDefaultMessage_Text);

            // wait for End Instructor Message text box
            base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EndInstructorMessage_Id_Locator));
            // clear End Instructor Message text box
            base.ClearTextById(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EndInstructorMessage_Id_Locator);
            // fill End Instructor Message text box
            base.FillTextBoxById(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EndInstructorMessage_Id_Locator,
                ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_EndInstructorMessage_Text);

            logger.LogMethodExit("ActivitiesPreferencesPage",
               "EnterEndOfActivityDefaultAndInstructorMessages", base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On The Save Button in Activity type Default Preferences page.
        /// </summary>
        /// <param name="saveButton">save Button</param>
        public void ClickOnTheSaveButton(string saveButton)
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "ClickOnTheSaveButton", base.isTakeScreenShotDuringEntryExit);

            // wait for Save button
            base.WaitForElement(By.LinkText(saveButton));

            //Get Save button element
            IWebElement getSaveButton = base.GetWebElementPropertiesByLinkText(saveButton);
            //Focus control on the "Save" button
            base.FocusOnElementByPartialLinkText(saveButton);
            //Click On Save button
            base.ClickByJavaScriptExecutor(getSaveButton);

            logger.LogMethodExit("ActivitiesPreferencesPage",
               "ClickOnTheSaveButton", base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enter New Activity Type Name.
        /// </summary>
        /// <param name="newActivityTypeName">new Activity Type Name</param>
        public void EnterNewActivityTypeName(string newActivityTypeName)
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "EnterNewActivityTypeName", base.isTakeScreenShotDuringEntryExit);

            ICollection<IWebElement> getAllAssetsInContentLibrary = base.GetWebElementsCollectionByPartialCssSelector(
                    ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_NewActivityTypeName_CSSSelector);

            IWebElement getLastActivityTypeName = getAllAssetsInContentLibrary.Last();
            getLastActivityTypeName.SendKeys(newActivityTypeName);

            logger.LogMethodExit("ActivitiesPreferencesPage",
               "EnterNewActivityTypeName", base.isTakeScreenShotDuringEntryExit);
        }
    }
}
