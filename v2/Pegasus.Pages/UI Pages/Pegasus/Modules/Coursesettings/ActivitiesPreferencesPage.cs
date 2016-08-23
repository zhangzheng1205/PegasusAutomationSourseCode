using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;
using System.Collections.Generic;
using System.Linq;
using Pegasus.Automation.DataTransferObjects;

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
               "SaveActivityPreferences", base.IsTakeScreenShotDuringEntryExit);
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
               "SaveActivityPreferences", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Activity Edit Option.
        /// </summary>
        public void ClickOnActivityEditOption()
        {
            //Click On Activity Edit Option
            logger.LogMethodEntry("ActivitiesPreferencesPage",
                "ClickOnActivityEditOption", base.IsTakeScreenShotDuringEntryExit);
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
               "ClickOnActivityEditOption", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Edit Option.
        /// </summary>
        private void ClickOnEditOption()
        {
            //Click On Edit Option
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "ClickOnEditOption", base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EditButton_Id_Locator));
            //Get Edit Option Property
            IWebElement getEditOptionProperty = base.GetWebElementPropertiesById(
                ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EditButton_Id_Locator);
            //Click On Edit Option
            base.ClickByJavaScriptExecutor(getEditOptionProperty);
            logger.LogMethodExit("ActivitiesPreferencesPage",
                "ClickOnEditOption", base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Assignment Activity Edit Option.
        /// </summary>
        public void ClickOnAssignmentActivityEditOption()
        {
            //Click On Activity Edit Option
            logger.LogMethodEntry("ActivitiesPreferencesPage",
                "ClickOnAssignmentActivityEditOption", base.IsTakeScreenShotDuringEntryExit);
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
               "ClickOnAssignmentActivityEditOption", base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Assignment behavioral activity Edit Option.
        /// </summary>
        private void ClickOnAssignmentEditOption()
        {
            //Click On Edit Option
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "ClickOnAssignmentEditOption", base.IsTakeScreenShotDuringEntryExit);

            // Activity Type Name Collection
            ICollection<IWebElement> activityTypeEditCollection = base.GetWebElementsCollectionById(
                    ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_EditButton_Id_Locator);
            // Activity Type Name corresponding Edit Preferences Link Collection 
            ICollection<IWebElement> activityTypesCollection = base.GetWebElementsCollectionByCssSelector(
                    ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_NewActivityTypeName_CSSSelector);
            
            int i = 0;
            //click on the Edit Preferences Link for the desired Activity Type Name out of the Collection
            foreach (IWebElement activityType in activityTypesCollection)
            {
                i++;

                if (activityType.Enabled && activityType.GetAttribute("value") == 
                    ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_AssignmentActivityTypeName_Value)
                {
                    int j = 0;
                    foreach(IWebElement activityTypeEdit in activityTypeEditCollection)
                    {
                        j++;
                        if(i==j)
                        {
                            base.ClickByJavaScriptExecutor(activityTypeEdit);
                            break;
                        }
                    }                    
                    break;
                }
            }

            logger.LogMethodExit("ActivitiesPreferencesPage",
                "ClickOnAssignmentEditOption", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Allow Activity To Be Used As Pretest Or Posttest' Option.
        /// </summary>
        public void SelectAllowActivityToBeUsedAsPretestOrPosttestOption()
        {
            //Select 'Allow Activity To Be Used As Pretest Or Posttest' Option
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "SelectAllowActivityToBeUsedAsPretestOrPosttestOption", 
               base.IsTakeScreenShotDuringEntryExit);
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
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'MGM Test' Edit Link.
        /// </summary>
        private void ClickOnMGMTestEditLink()
        {
            //Click On 'MGM Test' Edit Link
            logger.LogMethodEntry("ActivitiesPreferencesPage","ClickOnMGMTestEditLink",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the Element
            base.WaitForElement(By.XPath(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EditMathXLTestPreference_Link_Xpath_Locator));
            //Click on the Link
            base.ClickByJavaScriptExecutor(base.
                GetWebElementPropertiesByXPath(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_EditMathXLTestPreference_Link_Xpath_Locator));            
            logger.LogMethodExit("ActivitiesPreferencesPage","ClickOnMGMTestEditLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Preferences Window.
        /// </summary>
        private void SelectPreferencesWindow()
        {
            //Select Preferences window
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "SelectPreferencesWindow", base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Preferences_Window_Name);
            //Select Preferences Window
            base.SelectWindow(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Preferences_Window_Name);
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "SelectPreferencesWindow", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Preferences Main Frame.
        /// </summary>
        private void SelectPreferencesMainFrame()
        {
            //Select Preferences Main Frame.
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "SelectPreferencesMainFrame", base.IsTakeScreenShotDuringEntryExit);
            //Switch to Iframe
            base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Frame_Id_Locator));
            base.SwitchToIFrame(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Frame_Id_Locator);
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "SelectPreferencesMainFrame", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Remove Multiple Attempt CheckBox.
        /// </summary>
        public void ClickTheRemoveMultipleAttemptCheckBox()
        {
            //Click The Remove Multiple Attempt CheckBox
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "ClickTheRemoveMultipleAttemptCheckBox",
               base.IsTakeScreenShotDuringEntryExit);
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
               base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On Messages Sub-Tab.
        /// </summary>
        public void ClickOnMessagesSubTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "ClickOnMessagesSubTab", base.IsTakeScreenShotDuringEntryExit);
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
               "ClickOnMessagesSubTab", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Beginning Of Activity Default And Instructor Messages.
        /// </summary>
        public void EnterBeginningOfActivityDefaultAndInstructorMessages()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "EnterBeginningOfActivityDefaultAndInstructorMessages", base.IsTakeScreenShotDuringEntryExit);

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
               "EnterBeginningOfActivityDefaultAndInstructorMessages", base.IsTakeScreenShotDuringEntryExit);
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
               "EnterEndOfActivityDefaultAndInstructorMessages", base.IsTakeScreenShotDuringEntryExit);

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
               "EnterEndOfActivityDefaultAndInstructorMessages", base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Click On The Save Button in Activity type Default Preferences page.
        /// </summary>
        /// <param name="saveButton">save Button</param>
        public void ClickOnTheSaveButton(string saveButton)
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "ClickOnTheSaveButton", base.IsTakeScreenShotDuringEntryExit);

            // wait for Save button
            base.WaitForElement(By.LinkText(saveButton));

            //Get Save button element
            IWebElement getSaveButton = base.GetWebElementPropertiesByLinkText(saveButton);
            //Focus control on the "Save" button
            base.FocusOnElementByPartialLinkText(saveButton);
            //Click On Save button
            base.ClickByJavaScriptExecutor(getSaveButton);

            logger.LogMethodExit("ActivitiesPreferencesPage",
               "ClickOnTheSaveButton", base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enter New Activity Type Name.
        /// </summary>
        /// <param name="newActivityTypeName">new Activity Type Name</param>
        public void EnterNewActivityTypeName(string newActivityTypeName)
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage",
               "EnterNewActivityTypeName", base.IsTakeScreenShotDuringEntryExit);

            ICollection<IWebElement> getAllAssetsInContentLibrary = base.GetWebElementsCollectionByCssSelector(
                    ActivitiesPreferencesPageResource.ActivitiesPreferences_Page_NewActivityTypeName_CSSSelector);

            IWebElement getLastActivityTypeName = getAllAssetsInContentLibrary.Last();
            getLastActivityTypeName.SendKeys(newActivityTypeName);

            logger.LogMethodExit("ActivitiesPreferencesPage",
               "EnterNewActivityTypeName", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Activity Name Link in ActivityPrefrence page
        /// </summary>
        public void ClickAddActivityNameLinkInActivityPrefrence()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", 
                "ClickAddActivityNameLinkInActivityPrefrence", base.IsTakeScreenShotDuringEntryExit);

            // Wait untill prefrence page loads
            base.WaitUntilWindowLoads(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Preferences_Window_Name);
            base.SelectWindow(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_Preferences_Window_Name);

            //Select Iframe
            base.SwitchToIFrame(LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_PreferencesPage_Iframe_Id_Locator);

            //Click on Add Activity Name link
            base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_AddActivityName_Link_Id_Locator));
            base.ClickLinkById(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_AddActivityName_Link_Id_Locator);

            logger.LogMethodExit("ActivitiesPreferencesPage", 
                "ClickAddActivityNameLinkInActivityPrefrence", base.IsTakeScreenShotDuringEntryExit);

        }


        /// <summary>
        /// Enter activity name and Store Activity In Memory
        /// </summary>
        /// <param name="activityTypeEnum">This is Activity type enum.</param>
        public void EnterActivityNameAndStoreActivityInMemory(Activity.ActivityTypeEnum activityTypeEnum)
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", 
                "EnterActivityNameAndStoreActivityInMemory", base.IsTakeScreenShotDuringEntryExit);

            String ActivityNameText = string.Empty;
            //Get row count
            base.WaitForElement(By.XPath(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_AddActivityName_RowCount_Xpath_Locator));

            int getRowCount = base.GetElementCountByXPath(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_AddActivityName_RowCount_Xpath_Locator);

            // Get the Activity name in the table
            for (int i = 1; i <= getRowCount; i++)
            {
                ActivityNameText = base.GetValueAttributeByXPath(
                    string.Format(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_AddActivityName_GetActivityName_Xpath_Locator, i));

                // Check for Ativity name text box is empty
                if (ActivityNameText == "")
                {
                    // Generate GUID to enter into the activity name text box
                
                    Guid activityType = Guid.NewGuid();
                    String date = DateTime.Now.ToString("yyyy/MM/dd");
                    string randomValue = activityType.ToString().Split('-')[0];
                    string activityTypeName = "Auto-" + date + "-" + randomValue + "-Activity Type";
                 
                    base.FillTextBoxByXPath((string.Format(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_AddActivityName_GetActivityName_Xpath_Locator, i)), activityTypeName.ToString());
                    // Store the GUID enterd as activity name in memory
                    this.StoreActivityInMemory(
                    activityTypeName.ToString(), activityTypeEnum);
                    break;
                }
            }

            //Get HTML Element Property
            IWebElement getSavePreferences = base.GetWebElementPropertiesByPartialLinkText
             (LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_SavePreferences_Button_PartialText_Locator);
            getSavePreferences.SendKeys(string.Empty);
            //Click on the Course CMenu 
            base.ClickByJavaScriptExecutor(getSavePreferences);

            logger.LogMethodExit("ActivitiesPreferencesPage", "EnterActivityNameAndStoreActivityInMemory", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Activity Details In Memory.
        /// </summary>
        /// <param name="activityName">Activity name.</param>
        /// <param name="activityTypeEnum">This is Activity type enum.</param>
        private void StoreActivityInMemory(
            string activityName, Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Store Activity Details In Memory
            logger.LogMethodEntry("DRTDefaultUXPage",
               "StoreActivityInMemory",
               base.IsTakeScreenShotDuringEntryExit);
            Activity activity = new Activity
            {
                Name = activityName,
                ActivityType = activityTypeEnum,
                IsCreated = true,
            };
            //Save Activity Name to Memory
            activity.StoreActivityInMemory();
            logger.LogMethodExit("ActivitiesPreferencesPage",
               "StoreActivityInMemory",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to click on Edit activity preference link of the  activity type
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        public void EditActivityPreference(Activity.ActivityTypeEnum activityTypeEnum)
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "EditActivityPreference",base.IsTakeScreenShotDuringEntryExit);
            
            // Wait for window to load
            base.RefreshTheCurrentPage();
            Thread.Sleep(2000);
            this.SelectThePreferenceWindowWithFrame();


            Activity activity = Activity.Get(activityTypeEnum);
            String generatedActivityName = activity.Name.ToString();

            String ActivityNameText = string.Empty;
            //Get row count
            base.WaitForElement(By.XPath(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_AddActivityName_RowCount_Xpath_Locator));

            int getRowCount = base.GetElementCountByXPath(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_AddActivityName_RowCount_Xpath_Locator);

            // Get the Activity name in the table
            for (int i = 1; i <= getRowCount; i++)
            {
                ActivityNameText = base.GetValueAttributeByXPath(string.Format(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_AddActivityName_GetActivityName_Xpath_Locator, i));

                // Check for Ativity name text box is empty
                if (ActivityNameText == generatedActivityName)
                {
                    // Generate GUID to enter into the activity name text box
                    Guid activityTypeName = Guid.NewGuid();
                    IWebElement getEditLink = base.GetWebElementPropertiesByXPath((string.Format(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_AddActivityName_GetEditLink_Xpath_Locator, i)));
                    base.ClickByJavaScriptExecutor(getEditLink);
                    break;
                }
            }

            logger.LogMethodExit("ActivitiesPreferencesPage", "EditActivityPreference", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select The Preference with Frame.
        /// </summary>
        public void SelectThePreferenceWindowWithFrame()
        {
            //Select The Preference with Frame
            logger.LogMethodEntry("ActivitiesPreferencesPage",
                "SelectThePreferenceWindowWithFrame",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the window loads
                base.WaitUntilWindowLoads(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Window_Title);
                base.SelectWindow(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Window_Title);
                //Wait for the Frame
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Frame_Id_Locator));
                base.SwitchToIFrame(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Frame_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage",
                "SelectThePreferenceWindowWithFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to set preference for the SAM type of activity
        /// </summary>
        /// <param name="activityType">This is activity type enum.</param>
        public void SetActivityPreferenceForSAMAvtivityType(string preferencesName, Activity.ActivityTypeEnum activityType)
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "SetActivityPreferenceForSAMAvtivityType",base.IsTakeScreenShotDuringEntryExit);
            // Wait for popup to load and select the popup
            base.SwitchToLastOpenedWindow();
            base.WaitUntilPopUpLoads(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_ActivityTypePrefernce_Popup_Title);
            base.SelectWindow(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_ActivityTypePrefernce_Popup_Title);
            string getClassName = string.Empty;

            switch (preferencesName)
            {
                case "General":

                    // Click tab name for preference to be enabled
                    base.ClickLinkByPartialLinkText(preferencesName);

                        // Check for BigLock key status
                        this.EnableBigLockKey();

                        // Check for the small key status and unlock
                        this.CheckForKeyStatusAndUnlockGeneralPreferenceTab();

                        // Get the status of checkbox and disable/uncheck the checkbox
                        this.GetCheckBoxStatusAndDisableGeneralPreferenceTab();

                        // Get the status of checkbox and enable/check the checkbox
                        this.GetCheckBoxStatusAndEnableGeneralPreferenceTab();

                        // Select option from dropdown
                        this.selectOptionFromDropdownGeneralPreferenceTab(ActivitiesPreferencesPageResource.
                            ActivitiesPreferences_Page_ActivityTypePrefernce_General_Dropdown_ID, ActivitiesPreferencesPageResource.
                            ActivitiesPreferences_Page_ActivityTypePrefernce_General_DropdownOption_Value);

                        // Enable "Display this number of questions per page" radio button
                        base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                            ActivitiesPreferences_Page_ActivityTypePrefernce_General_Displaythisnumberofquestionsperpage_RadiButton_ID));
                        base.SelectRadioButtonById(ActivitiesPreferencesPageResource.
                            ActivitiesPreferences_Page_ActivityTypePrefernce_General_Displaythisnumberofquestionsperpage_RadiButton_ID);

                        // Fill textbox "Display this number of questions per page" by ID
                        this.FillTextInPreferencePopup(ActivitiesPreferencesPageResource.
                            ActivitiesPreferences_Page_ActivityTypePrefernce_General_Displaythisnumberofquestionsperpage_Textbox_ID, 
                            ActivitiesPreferencesPageResource.
                            ActivitiesPreferences_Page_ActivityTypePrefernce_General_Displaythisnumberofquestionsperpage_Textbox_Value);

                        // Enable "Specify Number Of Attemptse" radio button
                        base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                            ActivitiesPreferences_Page_ActivityTypePrefernce_General_SpecifyNumberOfAttemptse_RadiButton));
                        base.SelectRadioButtonById(ActivitiesPreferencesPageResource.
                            ActivitiesPreferences_Page_ActivityTypePrefernce_General_SpecifyNumberOfAttemptse_RadiButton);

                        // Fill textbox "Specify number of attempts" by ID
                        this.FillTextInPreferencePopup(ActivitiesPreferencesPageResource.
                            ActivitiesPreferences_Page_ActivityTypePrefernce_General_SpecifyNumberOfAttempts_Textbox_ID, 
                            ActivitiesPreferencesPageResource.
                            ActivitiesPreferences_Page_ActivityTypePrefernce_General_SpecifyNumberOfAttempts_Textbox_Value);

                        // Enable "Display this number of questions per page" radio button
                        base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_General_NumberOfAttemptsIsUnlimited_RadiButton_ID));
                        base.SelectRadioButtonById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_General_NumberOfAttemptsIsUnlimited_RadiButton_ID);

                        // Check for the small key status and lock
                        this.CheckForKeyStatusAndlockGeneralPreferenceTab();
                        break;

                case "Messages":

                        // Click tab name for preference to be enabled
                        base.ClickLinkByPartialLinkText(preferencesName);

                        Thread.Sleep(2000);

                        // Check for BigLock key status
                        this.EnableBigLockKey();

                        // Check for lock status in "Messages" preference and unlock 
                        this.CheckForKeyStatusAndUnlockMessagesTab();

                        // Clear text box "Default Message" of Beginning of activity
                        base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_DefaultBeginMessage_Textbox_ID));
                        base.ClearTextById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_DefaultBeginMessage_Textbox_ID);
                        base.FillTextBoxById(ActivitiesPreferencesPageResource.
                           ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_DefaultBeginMessage_Textbox_ID, "Default Begin Message");

                        // Clear text box "Instructor Message"  of Beginning of activity
                        base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_InstructorBeginMessage_Textbox_ID));
                        base.ClearTextById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_InstructorBeginMessage_Textbox_ID);
                        base.FillTextBoxById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_InstructorBeginMessage_Textbox_ID, "Instructor Begin Message");

                        // Clear text box "Default Message" of Beginning of activity
                        base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_DefaultEndMessage_Textbox_ID));
                        base.ClearTextById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_DefaultEndMessage_Textbox_ID);
                        base.FillTextBoxById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_DefaultEndMessage_Textbox_ID, "Default End Message");

                        // Clear text box "Instructor Message"  of End of activity
                        base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_InstructorEndMessage_Textbox_ID));
                        base.ClearTextById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_InstructorEndMessage_Textbox_ID);
                        base.FillTextBoxById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_InstructorEndMessage_Textbox_ID, "Instructor End Message");
                        break;

                case "Timing":

                        // Click tab name for preference to be enabled
                        base.ClickLinkByPartialLinkText(preferencesName);

                        Thread.Sleep(2000);

                        // Check for BigLock key status
                        this.EnableBigLockKey();

                       // Check for lock status in "Messages" preference and unlock 
                        this.CheckForKeyStatusAndUnlockTimingTab();

                        // Enable "Enforce at:" as "None" radio button
                        base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_EnforceToNone_RadioButton_ID));
                        base.SelectRadioButtonById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_EnforceToNone_RadioButton_ID);
                    
                        // Get the status of checkbox and disable/uncheck the checkbox
                        this.GetCheckBoxStatusAndDisableTimingPreferenceTab();

                        // Get the status of checkbox and enable the preference
                        this.GetCheckBoxStatusAndEnableTimingPreferenceTab();
                        break;

                case "Feedback":
                        // Click tab name for preference to be enabled
                        base.ClickLinkByPartialLinkText(preferencesName);
                        Thread.Sleep(2000);

                        // Check for BigLock key status
                        this.EnableBigLockKey();

                        // Check for lock status in "Feedback" preference and unlock 
                        this.CheckForKeyStatusAndUnlockFeedbackTab();

                        // Enable "Show Correct Answer:" as "At attempt:" radio button
                        base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_ShowCorrectAnswe_RadioButton_ID));
                        base.SelectRadioButtonById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_ShowCorrectAnswe_RadioButton_ID);
                    
                        // Enable "Show Need Help" as "At attempt:" radio button
                        base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_ShowNeedHelp_RadioButton_ID));
                        base.SelectRadioButtonById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_ShowNeedHelp_RadioButton_ID);
                    
                        // Enable "Show Feedback" as "At attempt:" radio button
                        base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_ShowFeedback_RadioButton_ID));
                        base.SelectRadioButtonById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_ShowFeedback_RadioButton_ID);
                    
                        // Enable "Display feedback and correct answers:" as "Next to response" radio button
                        base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_DisplayFeedbackAndCorrectAnswers_RadioButton_ID));
                        base.SelectRadioButtonById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_DisplayFeedbackAndCorrectAnswers_RadioButton_ID);
                    
                        // Fill textbox "At attempt:" of "Show Correct Answer:" by ID
                        this.FillTextInPreferencePopup(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_ShowCorrectAnswer_Textbox_ID, 
                        ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_ShowCorrectAnswer_Textbox_Value);
                    
                        // Fill textbox "At attempt:" of "Show Need Help" by ID
                        this.FillTextInPreferencePopup(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_ShowNeedHelp_Textbox_ID, 
                        ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_ShowNeedHelp_Textbox_Value);
                    
                        // Fill textbox "At attempt:" of "Show Feedback" by ID
                        this.FillTextInPreferencePopup(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_ShowFeedback_Textbox_ID, 
                        ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_ShowFeedback_Textbox_Value);
                        break;
                    
                case "Res. Toolbar":
                        // Click tab name for preference to be enabled
                        base.ClickLinkByPartialLinkText(preferencesName);
                        Thread.Sleep(2000);

                        // Check for BigLock key status
                        this.EnableBigLockKey();

                        // Check for lock status in "Res. Toolbar" preference and unlock 
                        this.CheckForKeyStatusAndUnlockResToolbarTab();

                        // Get the status of checkbox and disable/uncheck the checkbox
                        this.GetCheckBoxStatusAndDisableResToolbarTab();

                        // Get the status of checkbox and enable the preference
                        this.GetCheckBoxStatusAndEnableResToolbarTab();
                        break;

                case "Grading":
                        // Click tab name for preference to be enabled
                        base.ClickLinkByPartialLinkText(preferencesName);
                        Thread.Sleep(2000);

                        // Check for BigLock key status
                        this.EnableBigLockKey();

                        // Check for lock status in "Grading" preference and unlock 
                        this.CheckForKeyStatusAndUnlockGradingTab();

                        // Check for lock status in "Grading" preference and unlock 
                        this.GetCheckBoxStatusAndDisableGradingPreferenceTab();

                        // Get the status of checkbox and enable the preference
                        this.GetCheckBoxStatusAndEnableGradingPreferenceTab();

                        // Select option from dropdown
                        this.selectOptionFromDropdownGeneralPreferenceTab(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Dropdown_ID, 
                        ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Dropdown_Value);
                    
                        // Enable "Students will be identified" radio button
                        base.WaitForElement(By.Id(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_RadioButton_ID));
                        base.SelectRadioButtonById(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_RadioButton_ID);
                        break;

                case "Sections":
                        // Click tab name for preference to be enabled
                        base.ClickLinkByPartialLinkText(preferencesName);
                        Thread.Sleep(2000);

                        // Check for BigLock key status
                        this.EnableBigLockKey();

                        // Check for lock status in "Sections" preference and unlock 
                        this.CheckForKeyStatusAndUnlockSectionsTab();

                        // Check for lock status in "Sections" preference and unlock 
                        this.GetCheckBoxStatusAndDisableSectionsPreferenceTab();

                        break;

                case "Video Chat":
                        // Click tab name for preference to be enabled
                        base.ClickLinkByPartialLinkText(preferencesName);
                        Thread.Sleep(2000);

                        // Check for BigLock key status
                        this.EnableBigLockKey();

                        // Check for lock status in "Sections" preference and unlock 
                        this.CheckForKeyStatusAndUnlockVideoChatTab();

                        // Get the status of checkbox and enable the preference
                        this.GetCheckBoxStatusAndEnableVideoChatTab();

                        // Fill text in "Minimum number of participants "
                        this.FillTextInPreferencePopup(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_MinimumNumberOfParticipantsMin_ID, 
                        ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_MinimumNumberOfParticipantsMin_Value);

                        // Fill text in "Minimum number of participants "
                        this.FillTextInPreferencePopup(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_MinimumNumberOfParticipantsMax__ID, 
                        ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_MinimumNumberOfParticipantsMax_Value);
                    
                        // Fill text in textMinimumMinutes " Minimum length of recording"
                        this.FillTextInPreferencePopup(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_textMinimumMinutes_ID, 
                        ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_textMinimumMinutes_Value);
                    
                        // Fill text in textMinimumMinutes "Minimum number of participants "
                        this.FillTextInPreferencePopup(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_textMinimumSeconds_ID, 
                        ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_textMinimumSeconds_Value);

                        // Fill text in "Minimum number of participants"
                        this.FillTextInPreferencePopup(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_textMinutes_ID, 
                        ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_textMinutes_Value);
                    
                        // Fill text in "Maximum length of recording"
                        this.FillTextInPreferencePopup(ActivitiesPreferencesPageResource.
                            ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_textSeconds_ID, 
                            ActivitiesPreferencesPageResource.
                            ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_textSeconds_Value);
                        break;
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "SetActivityPreferenceForSAMAvtivityType", 
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// This mentod checks if the Big Lock key is enabled or disabled
        /// </summary>
        protected void EnableBigLockKey()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "EnableBigLockKey",base.IsTakeScreenShotDuringEntryExit);

            try
            {
                bool getBigLockStatus = base.IsElementPresent(By.ClassName(ActivitiesPreferencesPageResource.
              ActivitiesPreferences_Page_ActivityTypePrefernce_General_BigLock_ClassName), 2);

                if (getBigLockStatus == true)
                {
                    base.WaitForElement(By.ClassName(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_General_BigLock_ClassName));
                    base.ClickImageByClassName(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_General_BigLock_ClassName);
                }
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

           logger.LogMethodExit("ActivitiesPreferencesPage", "EnableBigLockKey", base.IsTakeScreenShotDuringEntryExit);
         }

        /// <summary>
        /// Get the status of small lock and unlock
        /// </summary>
        /// <param name="getClassName"></param>
        protected void GetSmallLockStatusAndUnlock(string getClassName, string lockID)
        {
            // Unlock the locked preference key
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetSmallLockStatusAndUnlock", base.IsTakeScreenShotDuringEntryExit);

            try
            {
                if (getClassName == ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__Close_ClassName)
                {
                    base.WaitForElement(By.ClassName(ActivitiesPreferencesPageResource.
                        ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__Close_ClassName));
                    base.ClickImageById(lockID);
                }
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("ActivitiesPreferencesPage", "GetSmallLockStatusAndUnlock", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the status of small lock and lock
        /// </summary>
        /// <param name="getClassName"></param>
        protected void GetSmallLockStatusAndlock(string getClassName,string lockID)
        {
            // lock the locked preference key
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetSmallLockStatusAndUnlock", base.IsTakeScreenShotDuringEntryExit);

            try
            {
                if (getClassName == ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__Open_ClassName)
                {
                    base.WaitForElement(By.ClassName(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__Open_ClassName));
                    base.ClickImageById(lockID);
                }
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("ActivitiesPreferencesPage", "GetSmallLockStatusAndUnlock", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to get the status of check box and enable
        /// </summary>
        /// <param name="getCheckBoxStatus"></param>
        /// <param name="checkBoxID"></param>
        protected void GetStatusOfCheckBoxAndEnable(bool getCheckBoxStatus, string checkBoxID)
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetStatusOfCheckBoxAndEnable", base.IsTakeScreenShotDuringEntryExit);

            try
            {
                if (getCheckBoxStatus == false)
                {
                    base.WaitForElement(By.Id(checkBoxID));
                    base.SelectCheckBoxById(checkBoxID);
                }
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("ActivitiesPreferencesPage", "GetStatusOfCheckBoxAndEnable", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// This methord is to get the status of check box and disable
        /// </summary>
        /// <param name="getCheckBoxStatus">This is check box status.</param>
        /// <param name="checkBoxID">This is checkbox ID value.</param>
        protected void GetStatusOfCheckBoxAndDisable(bool getCheckBoxStatus, string checkBoxID)
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetStatusOfCheckBoxAndEnable", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                if (getCheckBoxStatus == true)
                {
                    base.WaitForElement(By.Id(checkBoxID));
                    base.SelectCheckBoxById(checkBoxID);
                }
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("ActivitiesPreferencesPage", "GetStatusOfCheckBoxAndEnable", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// This methord is to get the small lock status and unlock the keys
        /// </summary>
        protected void CheckForKeyStatusAndUnlockGeneralPreferenceTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "CheckForKeyStatusAndUnlockGeneralPreferenceTab", base.IsTakeScreenShotDuringEntryExit);

            try
            {
                string getClassName;
                string getLockID;

                // Check for the small key status and unlock "Display this number of questions per page"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__DisplayThisNumberOfQuestionsPerPage_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__DisplayThisNumberOfQuestionsPerPage_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Allow students to skip questions"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__AllowStudentsToSkipQuestions_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__AllowStudentsToSkipQuestions_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock  "Allow student to skip pages"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__AllowStudentToSkipPages_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__AllowStudentToSkipPages_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Show score and/or feedback by submitting each individual question one at a time"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__ShowScoreAndFeedback_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__ShowScoreAndFeedback_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                //Check for the small key status and unlock "Display direction line text on each page"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__DisplayDirectionLineText_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__DisplayDirectionLineText_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
                
                //Check for the small key status and unlock "Allow students to Try Again"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__AllowStudentsToTryAgain_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__AllowStudentsToTryAgain_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
                
                //Check for the small key status and unlock "Require students to answer all questions"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__RequireStudentsToAnswer_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__RequireStudentsToAnswer_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                //Check for the small key status and unlock "Display total possible points for each question"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__DisplayTotalPossiblePoints_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__DisplayTotalPossiblePoints_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                //Check for the small key status and unlock "Remove correct/incorrect indicators in student results view"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__RemoveCorrectIncorrectIndicators_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__RemoveCorrectIncorrectIndicators_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
                
                //Check for the small key status and unlock "Include in course plan scoring"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__IncludeInCoursePlanScoring_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__IncludeInCoursePlanScoring_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);  

                //Check for the small key status and unlock "Default activity style"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__DefaultActivityStyle_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__DefaultActivityStyle_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
                
                //Check for the small key status and unlock "Save response at the end of each page"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__SaveResponse_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__SaveResponse_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                //Check for the small key status and unlock "Allow student to save for later"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__AllowStudentToSaveForLater_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__AllowStudentToSaveForLater_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
                
                //Check for the small key status and unlock "Restrict student from reviewing and changing saved answers"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__RestrictStudentFromReviewing_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__RestrictStudentFromReviewing_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
                
                //Check for the small key status and unlock "Disable Browser Translation"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__DisableBrowserTranslation_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__DisableBrowserTranslation_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("ActivitiesPreferencesPage", "CheckForKeyStatusAndUnlockGeneralPreferenceTab", base.IsTakeScreenShotDuringEntryExit);
            
        }

        /// <summary>
        /// Check for lock status in "Messages" preference and unlock 
        /// </summary>
        protected void CheckForKeyStatusAndUnlockMessagesTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "CheckForKeyStatusAndUnlockMessagesTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                logger.LogMethodExit("ActivitiesPreferencesPage", "GetStatusOfCheckBoxAndEnable", base.IsTakeScreenShotDuringEntryExit);
                string getClassName;
                string getLockID;

                // Check for the small key status and unlock "Beginning of activity"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_SmallLock__BeginningOfActivity);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_SmallLock__BeginningOfActivity;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Display this number of questions per page"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_SmallLock__EndOfActivity_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Messages_SmallLock__EndOfActivity_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "CheckForKeyStatusAndUnlockMessagesTab", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to get the small lock status and unlock the keys
        /// </summary>
        protected void CheckForKeyStatusAndlockGeneralPreferenceTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "CheckForKeyStatusAndlockGeneralPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string getClassName;
                string getLockID;

                // Check for the small key status and lock "Include in course plan scoring"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__IncludeInCoursePlanScoring_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__IncludeInCoursePlanScoring_ID;
                this.GetSmallLockStatusAndlock(getClassName, getLockID);

                // Check for the small key status and lock "Display questions in columns"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__DisplayQuestionsInColumns_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__DisplayQuestionsInColumns_ID;
                this.GetSmallLockStatusAndlock(getClassName, getLockID);

                //Check for the small key status and unlock "Show hints"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__ShowHints_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__ShowHints_ID;
                this.GetSmallLockStatusAndlock(getClassName, getLockID);

                // Check for the small key status and lock " Auto-submit single-SCO activities"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__AutosubmitSingleSCOActivities_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_SmallLock__AutosubmitSingleSCOActivities_ID;
                this.GetSmallLockStatusAndlock(getClassName, getLockID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "CheckForKeyStatusAndlockGeneralPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the status of check box and disable / uncheck the check box
        /// </summary>
        protected void GetCheckBoxStatusAndDisableGeneralPreferenceTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetCheckBoxStatusAndDisableGeneralPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                bool getCheckBoxStatus = false;

                // Check the status of "Allow students to skip questions" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__AllowStudentsToSkipQuestions_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__AllowStudentsToSkipQuestions_ID);
                
                // Check the status of "Allow student to flag questions" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__AllowStudentToFlagQuestions_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__AllowStudentToFlagQuestions_ID);

                // Check the status of "Show score and/or feedback by submitting each individual question one at a time" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__ShowScore_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__ShowScore_ID);

                // Check the status of "Display total possible points for each question" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__DisplayTotalPossiblePoints_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__DisplayTotalPossiblePoints_ID);

                // Check the status of "Remove correct/incorrect indicators in student results view" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__RemoveCorrectIncorrectIndicators_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__RemoveCorrectIncorrectIndicators_ID);
                
                // Check the status of "Include in course plan scoring" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__IncludeInCoursePlanScoring_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__IncludeInCoursePlanScoring_ID);

                // Check the status of "Display questions in columns" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__DisplayQuestionsInColumns_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__DisplayQuestionsInColumns_ID);
                
                // Check the status of "Disable Browser Translation" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__DisableBrowserTranslation_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__DisableBrowserTranslation_ID);

                // Check the status of "Auto-submit single-SCO activities" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__AutoSubmitSingleSCOActivities_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__AutoSubmitSingleSCOActivities_ID);
                
                // Check the status of "Restrict student from reviewing and changing saved answers" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__RestrictStudentFromReviewing_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__RestrictStudentFromReviewing_ID);

                // Check the status of "Restrict student from reviewing and changing saved answers" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_CheckBox__Hits_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_CheckBox__Hits_ID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "GetCheckBoxStatusAndDisableGeneralPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        
        /// <summary>
        /// Get the status of check box and disable / uncheck the check box in "Timing" tab
        /// </summary>
        protected void GetCheckBoxStatusAndDisableResToolbarTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetStatusOfCheckBoxAndEnable", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                bool getCheckBoxStatus = false;

                // Check the status of "Enable Grace Period" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_CheckBox__EnableGracePeriod_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_CheckBox__EnableGracePeriod_ID);

                // Check the status of "Display warning. Number of minutes remaining" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_CheckBox__HideToolLabels_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_CheckBox__HideToolLabels_ID);
                
                // Check the status of "Display warning. Number of minutes remaining" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_CheckBox__chkEnableActivityTool_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_CheckBox__chkEnableActivityTool_ID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "GetStatusOfCheckBoxAndEnable", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Get the status of check box and enable / check the check box
        /// </summary>
        protected void GetCheckBoxStatusAndEnableGeneralPreferenceTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetCheckBoxStatusAndEnableGeneralPreferenceTab",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                bool getCheckBoxStatus = false;

                // Check the status of "Display direction line text on each page" check box and enable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkDirectionLines_ID);
                this.GetStatusOfCheckBoxAndEnable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkDirectionLines_ID);
                
                // Check the status of "Allow students to Try Again" check box and enable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkEnableTryAgain_ID);
                this.GetStatusOfCheckBoxAndEnable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkEnableTryAgain_ID);
               
                // Check the status of "Require students to answer all questions" check box and enable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkAllQuesAnswer_ID);
                this.GetStatusOfCheckBoxAndEnable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkAllQuesAnswer_ID);
                
                // Check the status of "Save response at the end of each page" check box and enable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkSaveResponse_ID);
                this.GetStatusOfCheckBoxAndEnable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkSaveResponse_ID);
                
                // Check the status of "Allow student to save for later" check box and enable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkStudSave_ID);
                this.GetStatusOfCheckBoxAndEnable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkStudSave_ID);
                
                // Check the status of "Enable HelpLinks for this activity" check box and enable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkEnableHelplinks_ID);
                this.GetStatusOfCheckBoxAndEnable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkEnableHelplinks_ID);
                
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "GetCheckBoxStatusAndEnableGeneralPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);   
        }
 
        /// <summary>
        /// Get the status of check box and enable / check the check box
        /// </summary>
        protected void GetCheckBoxStatusAndEnableGradingPreferenceTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetCheckBoxStatusAndEnableGradingPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                bool getCheckBoxStatus = false;

                // Check the status of "Display direction line text on each page" check box and enable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkThresholdScore_ID);
                this.GetStatusOfCheckBoxAndEnable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_General_CheckBox__chkThresholdScore_ID); 
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "GetCheckBoxStatusAndEnableGradingPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);              
        }

        /// <summary>
        /// Get the status of check box and enable / check the check box
        /// </summary>
        protected void GetCheckBoxStatusAndEnableTimingPreferenceTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetCheckBoxStatusAndEnableTimingPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                bool getCheckBoxStatus = false;

                // Check the status of "Display direction line text on each page" check box and enable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_CheckBox__chkEnableLateSubmission_ID);
                this.GetStatusOfCheckBoxAndEnable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_CheckBox__chkEnableLateSubmission_ID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "GetCheckBoxStatusAndEnableTimingPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);   
        }
        
        /// <summary>
        /// Get the status of check box and disable / uncheck the check box in "Timing" tab
        /// </summary>
        protected void GetCheckBoxStatusAndDisableTimingPreferenceTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetStatusOfCheckBoxAndEnable", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                bool getCheckBoxStatus = false;

                // Check the status of "Display warning. Number of minutes remaining" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_CheckBox__chkGracePeriod_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_CheckBox__chkGracePeriod_ID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "GetStatusOfCheckBoxAndEnable", 
                base.IsTakeScreenShotDuringEntryExit);  
        }

        /// <summary>
        /// 
        /// </summary>
        protected void GetCheckBoxStatusAndEnableResToolbarTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetCheckBoxStatusAndEnableResToolbarTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                bool getCheckBoxStatus = false;

                // Check the status of "Display Resource Toolbar" check box and enable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_CheckBox__chkEnableResourceToolbar_ID);
                this.GetStatusOfCheckBoxAndEnable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_CheckBox__chkEnableResourceToolbar_ID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "GetCheckBoxStatusAndEnableResToolbarTab", 
                base.IsTakeScreenShotDuringEntryExit);  
        }

        /// <summary>
        /// Select option from the dropdown
        /// </summary>
        /// <param name="optionName">This is the option name</param>
        protected void selectOptionFromDropdownGeneralPreferenceTab(string dropdownID, string optionName)
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "selectOptionFromDropdownGeneralPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(dropdownID));
                base.SelectDropDownValueThroughTextById(dropdownID, optionName);
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "selectOptionFromDropdownGeneralPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Click button in the Default preference popup
        /// </summary>
        /// <param name="ButtonName">This is the button name.</param>
        /// <param name="activityType">This is activity type enum.</param>
        public void ClickButtonInDefaultPreferencePopup(string ButtonName, Activity.ActivityTypeEnum activityType)
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "ClickButtonInDefaultPreferencePopup", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Select popup
                base.WaitUntilPopUpLoads(ActivitiesPreferencesPageResource.
                ActivitiesPreferences_Page_ActivityTypePrefernce_Popup_Title);
                base.SelectWindow(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Popup_Title);

                base.WaitForElement(By.PartialLinkText(ButtonName));
                base.ClickButtonByPartialLinkText(ButtonName);
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "ClickButtonInDefaultPreferencePopup", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check for lock status in "Timing" preference and unlock 
        /// </summary>
        protected void CheckForKeyStatusAndUnlockTimingTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "selectOptionFromDropdownGeneralPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string getClassName;
                string getLockID;

                // Check for the small key status and unlock "Display this number of questions per page"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_Lock__29_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_Lock__29_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
                
                // Check for the small key status and unlock "Display this number of questions per page"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_Lock__30_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_Lock__30_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Display this number of questions per page"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_Lock__31_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_Lock__31_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Display this number of questions per page"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_Lock__32_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_Lock__32_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Display this number of questions per page"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_Lock__61_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Timing_Lock__61_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "ClickButtonInDefaultPreferencePopup", 
                base.IsTakeScreenShotDuringEntryExit);
        }

         /// <summary>
        /// Check for lock status in "Timing" preference and unlock 
        /// </summary>
        protected void CheckForKeyStatusAndUnlockFeedbackTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "selectOptionFromDropdownGeneralPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string getClassName;
                string getLockID;

                // Check for the small key status and unlock "Allow participant to view summary"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_Lock__33_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_Lock__33_ID;

                // Check for the small key status and unlock "Display correct answers after student submits activity"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_Lock__34_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_Lock__34_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Show Correct Answer"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_Lock__35_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_Lock__35_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Show Need Help"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_Lock__36_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_Lock__36_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Show Feedback"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_Lock__37_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_Lock__37_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Display feedback and correct answers"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_Lock__38_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Feedback_Lock__38_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "ClickButtonInDefaultPreferencePopup", 
                base.IsTakeScreenShotDuringEntryExit);
        }

         /// <summary>
        /// Check for lock status in "Res. Toolbar" preference and unlock 
        /// </summary>
        protected void CheckForKeyStatusAndUnlockResToolbarTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "selectOptionFromDropdownGeneralPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string getClassName;
                string getLockID;

                // Check for the small key status and unlock "Allow participant to view summary"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_Lock__41_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_Lock__41_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
               
                // Check for the small key status and unlock "Display correct answers after student submits activity"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_Lock__56_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_ResToolbar_Lock__56_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "ClickButtonInDefaultPreferencePopup", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check for lock status in "Grading" preference and unlock 
        /// </summary>
        protected void CheckForKeyStatusAndUnlockGradingTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "CheckForKeyStatusAndUnlockGradingTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string getClassName;
                string getLockID;

                // Check for the small key status and unlock "Allow participant to view summary"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__57_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__57_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
                
                // Check for the small key status and unlock "Display correct answers after student submits activity"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__58_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__58_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Display correct answers after student submits activity"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__42_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__42_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Display correct answers after student submits activity"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__43_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__43_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Display correct answers after student submits activity"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__65_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__65_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Display correct answers after student submits activity"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__53_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__53_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                // Check for the small key status and unlock "Display correct answers after student submits activity"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__68_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Lock__68_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "CheckForKeyStatusAndUnlockGradingTab", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check for lock status in "Sections" preference and unlock
        /// </summary>
        protected void CheckForKeyStatusAndUnlockSectionsTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "CheckForKeyStatusAndUnlockSectionsTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string getClassName;
                string getLockID;

                // Check for the small key status and unlock "Allow participant to view summary"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Sections_Lock__44_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Sections_Lock__44_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Sections_Lock__62_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Sections_Lock__62_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "CheckForKeyStatusAndUnlockSectionsTab", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the status of check box and disable / uncheck the check box in "Timing" tab
        /// </summary>
        protected void GetCheckBoxStatusAndDisableGradingPreferenceTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetCheckBoxStatusAndDisableGradingPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                bool getCheckBoxStatus = false;

                // Check the status of "Set activity to practice mode" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Checkbox__chkPracticeMode_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Checkbox__chkPracticeMode_ID);

                // Check the status of "Include in Mastery Report" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Checkbox__chkMasteryReport_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Checkbox__chkMasteryReport_ID);

                // Check the status of "Display icon in student grades area based on threshold/mastery score to pass" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Checkbox__chkDisplayIconOnScore_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Grading_Checkbox__chkDisplayIconOnScore_ID);
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "GetCheckBoxStatusAndDisableGradingPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the status of check box and disable / uncheck the check box in "Sections" tab
        /// </summary>
       protected void GetCheckBoxStatusAndDisableSectionsPreferenceTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetCheckBoxStatusAndDisableSectionsPreferenceTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                bool getCheckBoxStatus = false;

                // Check the status of "Set activity to practice mode" check box and disable
                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Sections_Checkbox__chkShuffleQues_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Sections_Checkbox__chkShuffleQues_ID);

                getCheckBoxStatus = base.IsElementSelectedById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Sections_Checkbox__chkRestartNumbering_ID);
                this.GetStatusOfCheckBoxAndDisable(getCheckBoxStatus, ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_Sections_Checkbox__chkRestartNumbering_ID);

            }
           catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "GetCheckBoxStatusAndDisableSectionsPreferenceTab",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methor is to fill the text in the textbox of activity preference popup
        /// </summary>
        /// <param name="textBoxID">This is text box ID.</param>
        /// <param name="value">This is the value to be entered into Textbox.</param>
        protected void FillTextInPreferencePopup(string textBoxID, string value)
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "FillTextInPreferencePopup",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait for the textbox to load
                base.WaitForElement(By.Id(textBoxID));
                // Clear the text box before filling the value
                base.ClearTextById(textBoxID);
                // Fill the text in text box
                base.FillTextBoxById(textBoxID, value);
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("ActivitiesPreferencesPage", "FillTextInPreferencePopup",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// 
        /// </summary>
        protected void GetCheckBoxStatusAndEnableVideoChatTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "GetCheckBoxStatusAndEnableVideoChatTab", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                bool getCheckBoxStatus = false;

                // Check the status of "Display direction line text on each page" check box and enable
                getCheckBoxStatus = base.IsElementSelectedById("chkSaveTextChats");
                this.GetStatusOfCheckBoxAndEnable(getCheckBoxStatus, "chkSaveTextChats");
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "GetCheckBoxStatusAndEnableVideoChatTab",
            base.IsTakeScreenShotDuringEntryExit);
        }

       /// <summary>
       /// Check for the status of the preference checked and uncheck the preference
       /// </summary>
        protected void CheckForKeyStatusAndUnlockVideoChatTab()
        {
            logger.LogMethodEntry("ActivitiesPreferencesPage", "CheckForKeyStatusAndUnlockVideoChatTab",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                string getClassName;
                string getLockID;

                // Check for the small key status and unlock "Display this number of questions per page"
                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_Lock__72_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_Lock__72_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_Lock__73_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_Lock__73_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_Lock__74_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_Lock__74_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_Lock__75_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_Lock__75_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_Lock__76_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_Lock__76_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);

                getClassName = base.GetClassAttributeValueById(ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_Lock__77_ID);
                getLockID = ActivitiesPreferencesPageResource.
                    ActivitiesPreferences_Page_ActivityTypePrefernce_VideoChat_Lock__77_ID;
                this.GetSmallLockStatusAndUnlock(getClassName, getLockID);
            }
            catch(Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ActivitiesPreferencesPage", "CheckForKeyStatusAndUnlockVideoChatTab",
            base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
