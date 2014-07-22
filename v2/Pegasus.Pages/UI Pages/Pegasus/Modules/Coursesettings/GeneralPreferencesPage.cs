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
    /// This Class Handles General Preferences Page Actions.
    /// </summary>
    public class GeneralPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class.
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(GeneralPreferencesPage));

        public enum StudyPlanEnum
        {
            PreTest,
            PostTest
        }

        /// <summary>
        /// Click on Roster Preference.
        /// </summary>
        public void ClickonRosterPreference()
        {
            //Click on Roster Preference
            logger.LogMethodEntry("GeneralPreferencesPage", "ClickonRosterPreference",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select window
                base.SelectWindow(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Window_Title);
                //Wait for element
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Frame_Id_Locator));
                //Switch to frame
                base.SwitchToIFrame(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Frame_Id_Locator);
                //Wait for element
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Roster_Preference_Id_Locator));
                //Get element property
                IWebElement getRosterPreference = base.GetWebElementPropertiesById
                    (GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Roster_Preference_Id_Locator);
                //Click Roster Preference
                base.ClickByJavaScriptExecutor(getRosterPreference);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage", "ClickonRosterPreference",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On the Subtab.
        /// </summary>
        /// <param name="subtabName">This is Subtab Name.</param>
        public void ClickOntheSubtab(string subtabName)
        {
            //Click On the Subtab
            logger.LogMethodEntry("GeneralPreferencesPage", "ClickOntheSubtab",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select window
                base.WaitUntilWindowLoads(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Window_Title);
                base.SelectWindow(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Window_Title);
                //Select The Main Frame
                this.SelectThePreferenceWindowWithFrame();
                //Wait for Sub Tab
                base.WaitForElement(By.PartialLinkText(subtabName));
                //Get Sub Tab Property
                IWebElement getSubtabProperty = base.
                    GetWebElementPropertiesByPartialLinkText(subtabName);
                //Click On Sub Tab
                base.ClickByJavaScriptExecutor(getSubtabProperty);
                //Switch To Default Content Page
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage", "ClickOntheSubtab",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select The Preference with Frame.
        /// </summary>
        public void SelectThePreferenceWindowWithFrame()
        {
            //Select The Preference with Frame
            logger.LogMethodEntry("GeneralPreferencesPage",
                "SelectThePreferenceWindowWithFrame",
                base.isTakeScreenShotDuringEntryExit);
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
            logger.LogMethodExit("GeneralPreferencesPage",
                "SelectThePreferenceWindowWithFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Selected Subtab Name.
        /// </summary>
        /// <returns>Selected Subtab Name.</returns>
        public String GetSelectedSubtabName()
        {
            //Get Selected Subtab Name
            logger.LogMethodEntry("GeneralPreferencesPage", "GetSelectedSubtabName",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getSubtabName = string.Empty;
            try
            {
                //Select window
                base.WaitUntilWindowLoads(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Window_Title);
                //Select The Main Frame
                this.SelectThePreferenceWindowWithFrame();
                //get the Selected tabname
                base.WaitForElement(By.ClassName(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Selected_Subtab_ClassName_Locator));
                getSubtabName = base.GetElementTextByClassName(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Selected_Subtab_ClassName_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage", "GetSelectedSubtabName",
                base.isTakeScreenShotDuringEntryExit);
            return getSubtabName;
        }

        /// <summary>
        /// Save Preferences.
        /// </summary>
        public void SavePreferences()
        {
            //Save Preferences
            logger.LogMethodEntry("GeneralPreferencesPage", "SavePreferences",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select The Main Frame
                this.SelectThePreferenceWindowWithFrame();
                //Wait For Save Preferences Button
                base.WaitForElement(By.PartialLinkText(GeneralPreferencesPageResource.
                        GeneralPreferences_Page_SavePreferences_Button_PartialText_Locator));
                base.FocusOnElementByPartialLinkText(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_SavePreferences_Button_PartialText_Locator);
                //Click on the Save Preferences
                base.ClickByJavaScriptExecutor(base.
                    GetWebElementPropertiesByPartialLinkText(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_SavePreferences_Button_PartialText_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage", "SavePreferences",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On the Subtab.
        /// </summary>
        /// <param name="subtabName">This is Subtab Name.</param>
        public void ClickonSubTabofPreference(string subTabName)
        {
            // Select the preferance sub tab
            logger.LogMethodEntry("GeneralPreferencesPage", "ClickonSubTabofPreference",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Select The Main Frame
                this.SelectThePreferenceWindowWithFrame();
                // Delay given for preferance page load
                base.WaitForElement(By.PartialLinkText(subTabName));
                IWebElement getActivitiesTab = base.GetWebElementPropertiesByPartialLinkText
                    (subTabName);
                // Click on given preferance sub tab
                base.ClickByJavaScriptExecutor(getActivitiesTab);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            // Select the preferance sub tab
            logger.LogMethodExit("GeneralPreferencesPage", "ClickonSubTabofPreference",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Title value will be verified here
        /// </summary>
        /// <returns>Title Value</returns>
        public string GetTitleValueInHomePage()
        {
            //Get the title value in home page
            logger.LogMethodEntry("GeneralPreferencesPage", "GetTitleValueInHomePage",
                base.isTakeScreenShotDuringEntryExit);
            //Initialized variable
            string getPageTitle = string.Empty;
            try
            {
                //Select window
                base.SelectWindow(GeneralPreferencesPageResource.
                       GeneralPreferences_Page_Window_Title);
                //Switch to Iframe
                base.SwitchToIFrame(GeneralPreferencesPageResource.
                       GeneralPreferences_Page_Frame_Id_Locator);
                //Wait for element              
                base.WaitForElement(By.XPath(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_First_Title_By_XPath_Locator));
                getPageTitle = base.GetElementTextByXPath(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_First_Title_By_XPath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage", "GetTitleValueInHomePage",
                 base.isTakeScreenShotDuringEntryExit);
            return getPageTitle;
        }

        /// <summary>
        /// Title value will be verified here
        /// </summary>
        /// <returns>given element text value</returns>
        public string GetElementTextDisplayed()
        {
            // Get the title value in home page
            logger.LogMethodEntry("GeneralPreferencesPage", "GetElementTextDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            // Initialized variable
            string text = string.Empty;
            try
            {
                // Select main preferance window
                this.SelectThePreferenceWindowWithFrame();
                // Wait till given element load      
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPreference_SP_CustomizeStudyPlan));
                // Get the text from given element
                text = base.GetElementTextByID(GeneralPreferencesPageResource.
                    GeneralPreference_SP_CustomizeStudyPlan);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            // Get the title value in home page
            logger.LogMethodExit("GeneralPreferencesPage", "GetElementTextDisplayed",
                 base.isTakeScreenShotDuringEntryExit);
            // Return element text
            return text;
        }

        /// <summary>
        /// Check the Enable badge check box
        /// </summary>
        public void CheckEnableBadgeCheckBox()
        {
            // check the Enable Badge check box
            logger.LogMethodEntry("GeneralPreferencesPage", "CheckEnableBadgeCheckBox",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //select window
                base.SelectWindow(GeneralPreferencesPageResource.
                       GeneralPreferences_Page_Window_Title);
                //switch to Iframe
                base.SwitchToIFrame(GeneralPreferencesPageResource.
                       GeneralPreferences_Page_Frame_Id_Locator);
                //wait for element                
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_CheckBox_Id_Locator));
                base.ClickCheckBoxById(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_CheckBox_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage", "CheckEnableBadgeCheckBox",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Select Content Button Enabled option
        /// </summary>
        /// <returns>null status if button enabled</returns>
        public String GetSelectContentButtonStatus()
        {
            // Get the Select Content Button Status 
            logger.LogMethodEntry("GeneralPreferencesPage", "GetSelectContentButtonEnabled",
                base.isTakeScreenShotDuringEntryExit);
            //Initialized variable
            string getSelectContentButtonStatus = string.Empty;
            try
            {
                //wait for select content button element
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                      GeneralPreferences_Page_SelectContent_Button_Id_Locator));
                getSelectContentButtonStatus = WebDriver.FindElement(By.Id(
                      GeneralPreferencesPageResource.
                      GeneralPreferences_Page_SelectContent_Button_Id_Locator)).
                      GetAttribute(GeneralPreferencesPageResource.
                      GeneralPreference_Page_Button_AttributeValue);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage", "GetSelectContentButtonEnabled",
                 base.isTakeScreenShotDuringEntryExit);
            return getSelectContentButtonStatus;
        }

        /// <summary>
        /// Enter the Value in TextBox Fields
        /// </summary>
        public void EnterValueinTextBoxFields()
        {
            // Enter the Value in TextBox Fields
            logger.LogMethodEntry("GeneralPreferencesPage", "EnterValueinTextBoxFields",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Enter TemplateID text field
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPreference_Page_TemplateID_By_ID_Locator));
                base.FillTextBoxByID(GeneralPreferencesPageResource.
                    GeneralPreference_Page_TemplateID_By_ID_Locator,
                    GeneralPreferencesPageResource.
                    GeneralPreference_Page_TemplateID_Value);
                //Enter the Badge Threshold Text field
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPreference_Page_BadgeThreshold_By_ID_Locator));
                base.FillTextBoxByID(GeneralPreferencesPageResource.
                     GeneralPreference_Page_BadgeThreshold_By_ID_Locator,
                     GeneralPreferencesPageResource.
                     GeneralPreference_Page_BadgeThreshold_Value);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage", "EnterValueinTextBoxFields",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click the Select Content button   
        /// </summary>
        public void ClickTheSelectContentButton()
        {
            // Click the Select Content button   
            logger.LogMethodEntry("GeneralPreferencesPage", "ClickTheSelectContentButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on Select content button
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPreference_Page_Select_Content_Btn_ID_Locotor));
                IWebElement getSelectButton = base.GetWebElementPropertiesById
                    (GeneralPreferencesPageResource.
                    GeneralPreference_Page_Select_Content_Btn_ID_Locotor);
                base.ClickByJavaScriptExecutor(getSelectButton);
                //Select Pop up window
                base.WaitUntilWindowLoads(GeneralPreferencesPageResource.
                    GeneralPreference_Page_Badge_Assignment_Selection_Window_Name);
                base.SelectWindow(GeneralPreferencesPageResource.
                    GeneralPreference_Page_Badge_Assignment_Selection_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage", "ClickTheSelectContentButton",
                 base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Single activity from pop up       
        /// </summary>
        /// <param name="activityName">This is activity name</param>
        public void SelectSingleActivityFromPopUP(string activityName)
        {
            //Select the Single activity from pop up
            logger.LogMethodEntry("GeneralPreferencesPage", "SelectSingleActivityFromPopUP",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get the total activity count
                int getActivityCount = this.GetActivityCount();
                //Write a for loop for selecting the checkboxes
                for (int initialCount = Convert.ToInt32(GeneralPreferencesPageResource.
                    GeneralPreference_Page_Initial_Value); initialCount <= getActivityCount;
                    initialCount++)
                {
                    if (base.IsElementPresent(By.XPath(string.Format(GeneralPreferencesPageResource.
                         GeneralPreference_Page_ActivityNameText_Xpath_Locator, initialCount)),
                         Convert.ToInt32(GeneralPreferencesPageResource.
                         GeneralPreferences_Page_WaitTime_Value)))
                    {
                        string getActivityName = base.GetElementTextByXPath(string.
                            Format(GeneralPreferencesPageResource.
                             GeneralPreference_Page_ActivityNameText_Xpath_Locator, initialCount));
                        //check for activity
                        if (getActivityName.Contains(activityName))
                        {
                            this.SelectTheActivityCheckBox(initialCount);
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage", "SelectSingleActivityFromPopUP",
                 base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Get Activity Count
        /// </summary>
        /// <returns>The Total Activity count</returns>
        private int GetActivityCount()
        {
            logger.LogMethodEntry("GeneralPreferencesPage", "GetActivityCount",
                base.isTakeScreenShotDuringEntryExit);
            //select window
            base.SelectWindow(GeneralPreferencesPageResource.
                GeneralPreference_Page_Badge_Assignment_Selection_Window_Name);
            // switch to iframe
            base.SwitchToIFrame(GeneralPreferencesPageResource.
                GeneralPreference_Page_IFrame_Left_ID_Locator);
            //Wait for element
            base.WaitForElement(By.XPath(GeneralPreferencesPageResource.
                   GeneralPreference_Page_ActivityCount_Xpath_Locator));
            int getActivityCount = base.GetElementCountByXPath(GeneralPreferencesPageResource.
                GeneralPreference_Page_ActivityCount_Xpath_Locator);
            logger.LogMethodExit("GeneralPreferencesPage", "GetActivityCount",
                base.isTakeScreenShotDuringEntryExit);
            return getActivityCount;
        }

        /// <summary>
        /// Select The Activity CheckBox
        /// </summary>
        /// <param name="rowCount">This is the row count of the Activity</param>
        private void SelectTheActivityCheckBox(int rowCount)
        {
            //Select activities from Left Iframe 
            logger.LogMethodEntry("GBInstuctorPage", "SelectTheActivityCheckBox",
                base.isTakeScreenShotDuringEntryExit);
            //Select The Activity CheckBox
            base.FocusOnElementByXPath(string.Format(GeneralPreferencesPageResource.
               GeneralPreference_Page_ActivityNameText_Xpath_Locator, rowCount));
            //select checkbox box of activity
            base.SelectCheckBoxByXPath(string.Format(GeneralPreferencesPageResource.
                GeneralPreference_Page_Activity_Checkbox_XPath_Locator, rowCount));
            Thread.Sleep(Convert.ToInt32(GeneralPreferencesPageResource.
                GeneralPreference_Page_ActivitySelect_Thread_Time_Value));
            logger.LogMethodExit("GBInstructorPage", "SelectTheActivityCheckBox",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This will add the selected activity to SelectContent Text field
        /// </summary>
        public void AddActivityToSelectContentTextField()
        {
            //Add the selected activity to SelectContent Text field
            logger.LogMethodEntry("GBInstuctorPage", "AddActivityToSelectContentTextField",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //select window
                base.SelectWindow(GeneralPreferencesPageResource.
                    GeneralPreference_Page_Badge_Assignment_Selection_Window_Name);
                //Click on And And Close button
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPreference_Page_AddAndClose_Btn_By_ID_Locator));
                base.ClickButtonByID(GeneralPreferencesPageResource.
                    GeneralPreference_Page_AddAndClose_Btn_By_ID_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBInstructorPage", "AddActivityToSelectContentTextField",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Activity name from Select Content textbox field
        /// </summary>
        /// <returns>This will return the Activity name</returns>
        public string getActivityNameInSelectContentTextbox()
        {
            //Get the Activity name from Select Content textbox field
            logger.LogMethodEntry("GeneralPreferencesPage", "getActivityNameInSelectContentTextbox",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getActivityName = string.Empty;
            try
            {
                //Select window
                base.WaitUntilWindowLoads(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Window_Title);
                //Select The Main Frame
                this.SelectThePreferenceWindowWithFrame();
                //get the Select Content TextBox field
                base.WaitForElement(By.XPath(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Select_Content_Text_By_Xpath_Locator));
                getActivityName = base.GetValueAttributeByXPath(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_Select_Content_Text_By_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage", "getActivityNameInSelectContentTextbox",
                base.isTakeScreenShotDuringEntryExit);
            return getActivityName;
        }

        /// <summary>
        /// Click on given link in Course preference page
        /// </summary>
        /// <param name="studyPlanEnum">This is study plan Enum</param>        
        public void ClickOnLink(StudyPlanEnum studyPlanEnum)
        {
            // Fire click event on given link
            logger.LogMethodEntry("GeneralPreferencesPage", "ClickOnLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                string linkID = GetStudyPlanTestType(studyPlanEnum);
                // To select the iframe of Preference window
                this.SelectThePreferenceWindowWithFrame();
                // Giving delay till given link element load
                base.WaitForElement(By.Id(linkID));
                // Click event get fire on given link, based on thier ID
                base.ClickLinkById(linkID);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            // Fire click event on given link
            logger.LogMethodExit("GeneralPreferencesPage", "ClickOnLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To search the given text in page
        /// </summary>
        /// <param name="searchText">Which need to check in page</param>
        /// <returns>Searched text</returns>
        public string GetGivenTextFromPage(string searchText)
        {
            // Check is given text presents in the page
            logger.LogMethodEntry("GeneralPreferencesPage", "GetGivenTextFromPage",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Wait for the element to check the given text presents
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPreference_SP_Property_Timing));
                // Check is given text presents in the element
                searchText = (base.GetElementTextByID(GeneralPreferencesPageResource.
                    GeneralPreference_SP_Property_Timing).Contains(searchText) ? searchText : string.Empty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            // Check is given text presents in the page
            logger.LogMethodExit("GeneralPreferencesPage", "GetGivenTextFromPage",
                base.isTakeScreenShotDuringEntryExit);
            // Returning given element text
            return searchText;
        }

        /// <summary>
        /// To click on given button
        /// </summary>
        /// <param name="buttonName">buttonName which need to click</param>
        /// <param name="sourcePageTitle">sourcePage in which page button should click</param>
        public void ClickOnLinkTypeButton(string buttonText, string sourcePageTitle)
        {
            // Click on pegasus button, which is created using customize button
            logger.LogMethodEntry("GeneralPreferencesPage", "ClickOnLinkTypeButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                // Select given sourcePage
                base.SelectWindow(sourcePageTitle);
                // Giving delay till given element load
                base.WaitForElement(By.PartialLinkText(buttonText));
                // Click event get fire on given button, based on thier ID
                IWebElement cancelButtonProperties = base.GetWebElementPropertiesByPartialLinkText(buttonText);
                base.ClickByJavaScriptExecutor(cancelButtonProperties);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            // Click on pegasus button, which is created using customize button
            logger.LogMethodExit("GeneralPreferencesPage", "ClickOnLinkTypeButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To get edit link id based on the study plan test type
        /// </summary>
        /// <param name="studyPlanEnum">This is study plan Enum</param>
        /// <returns>"Edit" link id</returns>
        private string GetStudyPlanTestType(StudyPlanEnum studyPlanEnum)
        {
            // Get edit link id based on the study plan test type
            logger.LogMethodEntry("GeneralPreferencesPage", "GetStudyPlanTestType",
                base.isTakeScreenShotDuringEntryExit);
            // Initializing variable
            string editLinkID = string.Empty;
            switch (studyPlanEnum)
            {
                case StudyPlanEnum.PreTest:
                    editLinkID = GeneralPreferencesPageResource.GeneralPreference_SP_EditPreTest;
                    break;
                case StudyPlanEnum.PostTest:
                    editLinkID = GeneralPreferencesPageResource.GeneralPreference_SP_EditPostTest;
                    break;
            }
            // Get edit link id based on the study plan test type
            logger.LogMethodExit("GeneralPreferencesPage", "GetStudyPlanTestType",
                base.isTakeScreenShotDuringEntryExit);
            return editLinkID;
        }

        // Enable General Tab Embedded Report Preference Settings.
        public void EnableGeneralTabEmbeddedReportPreferenceSettings()
        {
            //Enable General Tab Embedded Report Preference Settings
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnableGeneralTabEmbeddedReportPreferenceSettings",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Enable Embedded report Preference                
                this.EnableGeneralPreferenceSettings(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_Embeddedreport_LockIcon_Id_Locator,
                    GeneralPreferencesPageResource.
                      GeneralPreferences_Page_CheckBox_EmbeddedReporting_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnableGeneralTabEmbeddedReportPreferenceSettings",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Character Palate Check Box
        /// </summary>
        public void EnableCharacterPalateCheckBox()
        {
            //Enable Character Palate Check Box
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnableCharacterPalateCheckBox", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Main Frame
                this.SelectThePreferenceWindowWithFrame();
                //Wait For Checkbox 
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_CharaceterPalate_CheckBox_Id_Locator));
                //Check if Checkbox is Selected
                if (!base.IsElementSelectedById(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_CharaceterPalate_CheckBox_Id_Locator))
                {
                    //Get Character palate checkbox property
                    IWebElement getCharacterPalateCheckBoxProperty = base.
                        GetWebElementPropertiesById(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_CharaceterPalate_CheckBox_Id_Locator);
                    //Click On Check Box
                    base.ClickByJavaScriptExecutor(getCharacterPalateCheckBoxProperty);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnableCharacterPalateCheckBox", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable General Preference Settings.
        /// </summary>
        public void EnableGeneralPreferenceSettings()
        {
            //Enable General Preference Settings
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnableGeneralPreferenceSettings", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Main Frame
                this.SelectThePreferenceWindowWithFrame();
                //Enable BlackBoard IM Preference
                this.EnableBlackBoardIMPreference();
                //Enable Calendar Preference
                this.EnableGeneralTabCalendarPreferenceSettings();
                //Enable Allow Student Send Mail Preference
                this.EnableAllowStudentSendMailPreference();
                //Enable the General Tab Embedded Reporting
                this.EnableGeneralTabEmbeddedReportPreferenceSettings();
                //Enable Student Resource Toolbar Preferences
                this.EnableStudentResourceToolbarPreferences();
                //Enable Instructor Resource Toolbar Preferences
                this.EnalbleInsResToolbarLaunchPreferences();

                //Save Preferences
                this.SavePreferences();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnableGeneralPreferenceSettings", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Student Resource Toolbar Preferences.
        /// </summary>
        private void EnableStudentResourceToolbarPreferences()
        {
            //Enable Student Resource Toolbar Preferences
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnableStudentResourceToolbarPreferences", base.isTakeScreenShotDuringEntryExit);
            //Enable Glossary Preference                
            this.EnableGeneralPreferenceSettings(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_GlossaryPreference_LockIcon_Id_Locator,
                GeneralPreferencesPageResource.
                GeneralPrefernces_Page_GlossaryPreference_Checkbox_Id_Locator);
            //Enable Student Resource Toolbar Preference                
            this.EnableGeneralPreferenceSettings(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_StudentResourceToolbarPreference_LockIcon_Id_Locator,
                GeneralPreferencesPageResource.
                GeneralPrefernces_Page_StudentResourceToolbar_Preference_Checkbox_Id_Locator);
            //Enable Display Glossary Preference                
            this.EnableGeneralPreferenceSettings(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_StudentGlossaryPreference_LockIcon_Id_Locator,
                GeneralPreferencesPageResource.
                GeneralPrefernces_Page_StudentGlossary_Preference_Checkbox_Id_Locator);
            //Enable Display Verb Chart Preference            
            this.EnableGeneralPreferenceSettings(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_StudentVerbChartPreference_LockIcon_Id_Locator,
                GeneralPreferencesPageResource.
                GeneralPrefernces_Page_StudentVerbChart_Preference_Checkbox_Id_Locator);
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnableStudentResourceToolbarPreferences", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable General Preference Settings.
        /// </summary>
        /// <param name="lockIconIdProperty">This is LockId.</param>
        /// <param name="preferenceSelectorIdProperty">This is CheckboxId.</param>
        public void EnableGeneralPreferenceSettings(
            string lockIconIdProperty, string preferenceSelectorIdProperty)
        {
            //Enable General Preference Settings
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnableGeneralPreferenceSettings", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Get Lock Icon Status
                base.WaitForElement(By.Id(lockIconIdProperty));
                base.FocusOnElementByID(lockIconIdProperty);
                string getPreferenceLockIconStatus =
                    base.GetClassAttributeValueById(lockIconIdProperty);
                if (getPreferenceLockIconStatus == GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_LockIcon_Status_Value)
                {
                    IWebElement getLockIdPropety = base.GetWebElementPropertiesById
                        (lockIconIdProperty);
                    //Click On Lock Icon
                    base.ClickByJavaScriptExecutor(getLockIdPropety);
                }
                if (!base.IsElementSelectedById(preferenceSelectorIdProperty))
                {
                    IWebElement getCheckboxId = base.GetWebElementPropertiesById
                        (preferenceSelectorIdProperty);
                    //Enable Preference
                    base.ClickByJavaScriptExecutor(getCheckboxId);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnableGeneralPreferenceSettings", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Allow Student Send Mail Preference.
        /// </summary>
        private void EnableAllowStudentSendMailPreference()
        {
            //Enable Allow Student Send Mail Preference
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnableAllowStudentSendMailPreference", base.isTakeScreenShotDuringEntryExit);
            //Get Lock Icon Status
            base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_AllowStudentSendMail_Lock_Id_Locator));
            string getAllowStudentToSendMailLockIconStatus =
                base.GetClassAttributeValueById(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_AllowStudentSendMail_Lock_Id_Locator);
            if (getAllowStudentToSendMailLockIconStatus == GeneralPreferencesPageResource.
                GeneralPrefernces_Page_LockIcon_Status_Value)
            {
                //Click On Lock Icon
                base.ClickButtonByID(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_AllowStudentSendMail_Lock_Id_Locator);
            }
            if (!base.IsElementSelectedById(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_StudentMail_Checkbox_Id_Locator))
            {
                //Enable Allow Student To Send mail
                base.ClickCheckBoxById(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_StudentMail_Checkbox_Id_Locator);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnableAllowStudentSendMailPreference", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable General Tab Calendar Preference Settings.
        /// </summary>
        public void EnableGeneralTabCalendarPreferenceSettings()
        {
            //Enable General Tab Calendar Preference Settings
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnableGeneralTabCalendarPreferenceSettings",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Enable Calendar Preference checkbox             
                this.EnableGeneralPreferenceSettings(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_Calendar_Lock_Id_Locator,
                    GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_Calendar_Checkbox_Id_Locator);
                //Enable HED Calendar layout Preference                
                this.EnableGeneralPreferenceSettings(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_HEDCalendar_Lock_Id_Locator,
                    GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_HEDCalendar_Checkbox_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnableGeneralTabCalendarPreferenceSettings",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable BlackBoard IM Preference.
        /// </summary>
        private void EnableBlackBoardIMPreference()
        {
            //Enable BlackBoard IM Preference
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnableBlackBoardIMPreference", base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_BlackBoard_IM_Lock_Id_Locator));
            //Enable BlackBoard IM Preference           
            this.EnableGeneralPreferenceSettings(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_BlackBoard_IM_Lock_Id_Locator,
                GeneralPreferencesPageResource.
                GeneralPrefernces_Page_BlackBoardIM_Checkbox_Id_Locator);
            //Fill Black board Fname Lname Email TextBoxes
            this.EnterBlackBoardIMDetails();
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnableBlackBoardIMPreference", base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Fill Firstname Lastname Email TextBoxes
        /// </summary>
        public void EnterBlackBoardIMDetails()
        {
            // Fill Firstname Lastname Email TextBoxes
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnterBlackBoardIMDetails", base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
               GeneralPrefernces_Page_FirstLast_Name_Textbox_Id_Locator));
                //Enter First And Last Name
                base.ClearTextByID(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_FirstLast_Name_Textbox_Id_Locator);
                base.FillTextBoxByID(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_FirstLast_Name_Textbox_Id_Locator,
                    GeneralPreferencesPageResource.GeneralPrefernces_Page_FirstLast_Name_Value);
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_Email_Textbox_Id_Locator));
                //Enter Mail And Business Unit
                this.EnterMailAndBusinessUnit();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("GeneralPreferencesPage",
            "EnterBlackBoardIMDetails", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Mail And Business Unit.
        /// </summary>
        private void EnterMailAndBusinessUnit()
        {
            //Enter Mail And Business Unit
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnterMailAndBusinessUnit", base.isTakeScreenShotDuringEntryExit);
            //Enter Email
            base.ClearTextByID(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_Email_Textbox_Id_Locator);
            base.FillTextBoxByID(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_Email_Textbox_Id_Locator,
                GeneralPreferencesPageResource.GeneralPrefernces_Page_Email_Value);
            base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_Businessunit_Textbox_Id_Locator));
            //Enter Business Unit
            base.ClearTextByID(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_Businessunit_Textbox_Id_Locator);
            base.FillTextBoxByID(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_Businessunit_Textbox_Id_Locator,
                GeneralPreferencesPageResource.GeneralPrefernces_Page_BusinessUnit_Value);
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnterMailAndBusinessUnit", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Instructor Resource Toolbar Preference.
        /// </summary>
        public void EnableInstructorResourceToolbarPreference()
        {
            //Enable Instructor Resource Toolbar Preference
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnableInstructorResourceToolbarPreference",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Main Frame
                this.SelectThePreferenceWindowWithFrame();
                //Select 'Enable Instructor Resource Toolbar For Course' Checkbox
                this.SelectInstructorResourceToolbarCheckbox();
                //Select Display Checkbox And Enter Pct URL
                this.SelectDisplayCheckboxAndEnterPctUrl();
                //Save Preferences
                this.SavePreferences();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnableInstructorResourceToolbarPreference",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Display Checkbox And Enter Pct URL.
        /// </summary>
        private void SelectDisplayCheckboxAndEnterPctUrl()
        {
            //Select Display Checkbox And Enter Pct URL
            logger.LogMethodEntry("GeneralPreferencesPage",
                "SelectDisplayCheckboxAndEnterPctUrl",
                base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_Display_Checkbox_Id_Locator));
            if (!base.IsElementSelectedById(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_Display_Checkbox_Id_Locator))
            {
                //Select Display Checkbox
                base.ClickCheckBoxById(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_Display_Checkbox_Id_Locator);
                //Wait For Display textbox
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_Display_Textbox_Id_locator));
                base.ClearTextByID(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_Display_Textbox_Id_locator);
                //Enter Display Name
                base.FillTextBoxByID(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_Display_Textbox_Id_locator,
                    GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_Display_Name_Value);
                //Wait For Pct URL Textbox
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_PctUrl_Textbox_Id_Locator));
                base.ClearTextByID(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_PctUrl_Textbox_Id_Locator);
                //Enter Pct Url
                base.FillTextBoxByID(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_PctUrl_Textbox_Id_Locator,
                    GeneralPreferencesPageResource.GeneralPrefernces_Page_PctUrl_Value);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
             "EnableInstructorResourceToolbarPreference",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Enable Instructor Resource Toolbar For Course' Checkbox.
        /// </summary>
        private void SelectInstructorResourceToolbarCheckbox()
        {
            //Select 'Enable Instructor Resource Toolbar For Course' Checkbox
            logger.LogMethodEntry("GeneralPreferencesPage",
            "SelectInstructorResourceToolbarCheckbox",
            base.isTakeScreenShotDuringEntryExit);
            //Wait For 'Enable Instructor Resource Toolbar For Course' Checkbox
            base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_InstructorResource_Checkbox_Id_Locator));
            if (!base.IsElementSelectedById(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_InstructorResource_Checkbox_Id_Locator))
            {
                //Select 'Enable Instructor Resource Toolbar For Course' Checkbox
                base.ClickCheckBoxById(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_InstructorResource_Checkbox_Id_Locator);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "SelectInstructorResourceToolbarCheckbox",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Calendar General Preference Settings.
        /// </summary>
        public void EnableCalendarGeneralPreferenceSettings()
        {
            //Enable Calendar General Preference Settings
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnableCalendarGeneralPreferenceSettings",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Selct window and frame
                this.SelectThePreferenceWindowWithFrame();
                //Enable Calendar Preference
                this.EnableGeneralTabCalendarPreferenceSettings();
                //Save Preferences
                this.SavePreferences();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnableCalendarGeneralPreferenceSettings",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify Calendar Preferences Unchecked and Disabled.
        /// </summary>
        /// <returns>Calendar Preferences Status.</returns>
        public bool IsCalendarPreferencesUncheckedDisabled()
        {
            // Verify Calendar Preferences Unchecked and Disabled
            logger.LogMethodEntry("GeneralPreferencesPage",
            "IsCalendarPreferencesUncheckedDisabled",
            base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            bool isCalendarPreferencesUncheckedDisabled = false;
            try
            {
                //Selct window and frame
                this.SelectThePreferenceWindowWithFrame();
                //Click On 'Enable Calendar' Preference Checkbox
                this.EnableGeneralPreferenceSettings(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_Calendar_Lock_Id_Locator,
                    GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_Calendar_Checkbox_Id_Locator);
                //Status Of 'HED Calendar Layout' and 'Skip Calendar Setup' Preferences Unchecked and Disabled
                isCalendarPreferencesUncheckedDisabled =
                    base.IsElementEnabledByID(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_HEDCalendar_Checkbox_Id_Locator)
                    && base.IsElementSelectedById(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_HEDCalendar_Checkbox_Id_Locator) &&
                    base.IsElementEnabledByID(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_SkipCalendarSetup_Checkbox_Id_Locator)
                    && base.IsElementSelectedById(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_SkipCalendarSetup_Checkbox_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "IsCalendarPreferencesUncheckedDisabled",
            base.isTakeScreenShotDuringEntryExit);
            return isCalendarPreferencesUncheckedDisabled;
        }

        /// <summary>
        /// Verify Calendar Preferences Lock Status.
        /// </summary>
        /// <returns>Preference Lock Status.</returns>
        public bool IsCalendarPreferencesLockStatus()
        {
            //Verify Calendar Preferences Lock Status
            logger.LogMethodEntry("GeneralPreferencesPage",
            "IsCalendarPreferencesLockStatus",
            base.isTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string gethedCalendarPreferenceLockStatus = string.Empty;
            string getskipCalendarPreferenceLockStatus = string.Empty;
            bool isPreferencesLocked = false;
            try
            {
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_HEDCalendar_Lock_Id_Locator));
                //Get 'HED Calendar Layout' Lock Status
                gethedCalendarPreferenceLockStatus =
                    base.GetClassAttributeValueById(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_HEDCalendar_Lock_Id_Locator);
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_SkipCalendar_Lock_Id_Locator));
                //Get 'Skip Calendar Setup' Lock Status
                getskipCalendarPreferenceLockStatus =
                    base.GetClassAttributeValueById(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_SkipCalendar_Lock_Id_Locator);
                if (gethedCalendarPreferenceLockStatus == GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_LockIcon_Status_Value &&
                    getskipCalendarPreferenceLockStatus == GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_LockIcon_Status_Value)
                {
                    isPreferencesLocked = true;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "IsCalendarPreferencesLockStatus",
            base.isTakeScreenShotDuringEntryExit);
            return isPreferencesLocked;
        }

        /// <summary>
        /// Disable 'HED Calendar' Preference.
        /// </summary>       
        public void DisableHedCalendarPreference()
        {
            // Disable 'HED Calendar' Preference
            logger.LogMethodEntry("GeneralPreferencesPage",
            "DisableHEDCalendarPreference",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Selct window and frame
                this.SelectThePreferenceWindowWithFrame();
                if (base.IsElementSelectedById(GeneralPreferencesPageResource.
                GeneralPrefernces_Page_Calendar_Checkbox_Id_Locator))
                {
                    //Disable Calendar
                    base.ClickCheckBoxById(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_Calendar_Checkbox_Id_Locator);
                    if (base.GetClassAttributeValueById(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_HEDCalendar_Lock_Id_Locator) ==
                    GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_LockIcon_Open_Status_Value)
                    {
                        //Click On 'Skip Calendar' Lock Icon
                        base.ClickLinkById(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_HEDCalendar_Lock_Id_Locator);
                    }
                    if (base.GetClassAttributeValueById(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_SkipCalendar_Lock_Id_Locator) ==
                    GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_LockIcon_Open_Status_Value)
                    {
                        //Click On 'Skip Calendar' Lock Icon
                        base.ClickLinkById(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_SkipCalendar_Lock_Id_Locator);
                    }
                }
                //Save Preferences
                this.SavePreferences();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "DisableHEDCalendarPreference",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Blackboard IM Preference Settings.
        /// </summary>
        public void EnableBlackboardIMPreferenceSettings()
        {
            //Enable Blackboard IM Preference Settings
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnableBlackboardIMPreferenceSettings",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Enable Blackboard IM Preference Settings          
                this.EnableBlackBoardIMPreference();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnableBlackboardIMPreferenceSettings",
            base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable Character Palate Preference Settings.
        /// </summary>
        public void EnableCharacterPalatePreferenceSettings()
        {
            //Enable Character Palate Preference Settings
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnableCharacterPalatePreferenceSettings",
            base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Enable Character Palate Preference                
                this.EnableGeneralPreferenceSettings(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_CharacterPalate_LockIcon_Id_Locator,
                    GeneralPreferencesPageResource.
                      GeneralPrefernces_Page_CharaceterPalate_CheckBox_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GeneralPreferencesPage",
            "EnableCharacterPalatePreferenceSettings",
            base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enable Instructor Resource Toolbar Preference for Launch.
        /// </summary>
        public void EnalbleInsResToolbarLaunchPreferences()
        {
            logger.LogMethodEntry("GeneralPreferencesPage",
            "EnalbleInsResToolbarLaunchPreferences",
            base.isTakeScreenShotDuringEntryExit);

            try
            {
                // unlock Instructor resource toolbar preference and click checkbox
                this.EnableGeneralPreferenceSettings(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_InstructorResourceToolbar_LockIcon_Id_Locator,
                    GeneralPreferencesPageResource.
                      GeneralPreferences_Page_InstructorResourceToolbar_CheckBox_Id_Locator);

                //wait for element                
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_InstructorResourceToolbar_Display1_CheckBox_Id_Locator));
                // click checkbox
                base.ClickCheckBoxById(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_InstructorResourceToolbar_Display1_CheckBox_Id_Locator);

                //wait for element                
                base.WaitForElement(By.Id(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_InstructorResourceToolbar_Display2_CheckBox_Id_Locator));
                // click checkbox
                base.ClickCheckBoxById(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_InstructorResourceToolbar_Display2_CheckBox_Id_Locator);

                // call method to Assign appropriate values to text boxes
                this.AssignPctLaunchValue();

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("GeneralPreferencesPage",
            "EnalbleInsResToolbarLaunchPreferences",
            base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Assign appropriate values to text boxes for Instructor 
        /// Resource Tool Bar in Preferences Tab.
        /// </summary>
        private void AssignPctLaunchValue()
        {
            // Assign Values to PCT Tool Txt Boxes in General Preferences tab
            logger.LogMethodEntry("GeneralPreferencesPage",
            "AssignPCTLaunchValue", base.isTakeScreenShotDuringEntryExit);

            // Wait for Title1 text box, clear it and fill text box from resource file 
            AssignPctLaunchValuestoPreferenceTextBoxes(GeneralPreferencesPageResource.
                    GeneralPreferences_Page_InstructorResourceToolbar_Title1_TextBox_Id_Locator,
                    GeneralPreferencesPageResource.PCT_Display1);
            // Wait for URL1 text box, clear it and fill text box from resource file
            AssignPctLaunchValuestoPreferenceTextBoxes(GeneralPreferencesPageResource.
                GeneralPreferences_Page_InstructorResourceToolbar_URL1_TextBox_Id_Locator,
                AutomationConfigurationManager.PctInstructorResourceToolsUrl);
            // Wait for Title2 text box, clear it and fill text box from resource file
            AssignPctLaunchValuestoPreferenceTextBoxes(GeneralPreferencesPageResource.
                GeneralPreferences_Page_InstructorResourceToolbar_Title2_TextBox_Id_Locator,
                GeneralPreferencesPageResource.PCT_Display2);
            // Wait for URL2 text box, clear it and fill text box from resource file
            AssignPctLaunchValuestoPreferenceTextBoxes(GeneralPreferencesPageResource.
                GeneralPreferences_Page_InstructorResourceToolbar_URL2_TextBox_Id_Locator,
                AutomationConfigurationManager.PctInstructorResourceToolsUrl);

            logger.LogMethodExit("GeneralPreferencesPage",
            "AssignPCTLaunchValue", base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Assign PCT Launch Values to General Preference Instructor Resource Toolbar TextBoxes
        /// </summary>
        /// <param name="elementId"></param>
        /// <param name="value"></param>
        private void AssignPctLaunchValuestoPreferenceTextBoxes(string elementId, string value)
        {
            logger.LogMethodExit("GeneralPreferencesPage",
            "AssignPCTLaunchValuestoPreferenceTextBoxes", base.isTakeScreenShotDuringEntryExit);

            // wait for element
            base.WaitForElement(By.Id(elementId));
            // clear text of element
            base.ClearTextByID(elementId);
            // fill desired text in element provided as argument to the method
            base.FillTextBoxByID(elementId, value);

            logger.LogMethodExit("GeneralPreferencesPage",
            "AssignPCTLaunchValuestoPreferenceTextBoxes", base.isTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Enable the 'Enable Blackboard Collaborate Voice Authoring' Option
        /// </summary>
        public void EnableBlackBoardCollaborateVoiceAuthoring()
        {
            //Enable The 'Enable Blackboard Collaborate Voice Authoring' Option 
            logger.LogMethodEntry("GradingPreferencesPage",
           "EnableBlackBoardCollaborateVoiceAuthoring",
           base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Enable Blackboard Collaborate Voice Authoring Preference                
                this.EnableGeneralPreferenceSettings(GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_EnableBlackBoardVoiceAuthoring_Checkbox_Id_Locator,
                    GeneralPreferencesPageResource.
                    GeneralPrefernces_Page_EnableBlackBoardVoiceAuthoring_Checkbox_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GradingPreferencesPage",
              "EnableBlackBoardCollaborateVoiceAuthoring",
              base.isTakeScreenShotDuringEntryExit);
        }
    }
}
