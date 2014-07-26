using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Coursesettings;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    ///  This class handles Pegasus LTIToolsPreferences Page Actions.
    /// This class name is bad because as it so in Pegasus.
    /// </summary>

    public class LTIToolsPreferencesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class.
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(LTIToolsPreferencesPage));

        /// <summary>
        /// Enable MGM MathXL In LTITools.
        /// </summary>
        public void EnableMGMMathXlInLtiTools()
        {
            // To Enable MGM MathXL In LTITools
            Logger.LogMethodEntry("LTIToolsPreferencesPage",
               "EnableMGMMathXlInLtiTools", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Preferences Window
                this.SelectPreferencesWindow();
                //Select Iframe
                this.SwitchToIFrame();
                //Wait For The LTI Tools Link
                base.WaitForElement(By.PartialLinkText(LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_LTITools_Link_PartialText_Locator),
                    Convert.ToInt32(LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_TimeToWait_Value));
                //Get HTML Element Property for Cmenu
                IWebElement getLtiToolsProperty = base.GetWebElementPropertiesByPartialLinkText
                    (LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_LTITools_Link_PartialText_Locator);
                getLtiToolsProperty.SendKeys(string.Empty);
                //Click on the Course CMenu 
                base.ClickByJavaScriptExecutor(getLtiToolsProperty);
                //Select Preferences Window
                this.SelectPreferencesWindow();
                //Select Iframe
                this.SwitchToIFrame();
                //Enable LTI Preference
                this.EnableLTIPreference();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LTIToolsPreferencesPage",
               "EnableMGMMathXlInLtiTools", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Preferences Window.
        /// </summary>
        private void SelectPreferencesWindow()
        {
            //Select Default window
            Logger.LogMethodEntry("LTIToolsPreferencesPage",
               "SelectPreferencesWindow", base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_WindowName);
            //Select Default Window
            base.SelectWindow(LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_WindowName);
            Logger.LogMethodExit("LTIToolsPreferencesPage",
               "SelectPreferencesWindow", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to Iframe.
        /// </summary>
        private void SwitchToIFrame()
        {
            //Switch to Iframe
            Logger.LogMethodEntry("LTIToolsPreferencesPage",
               "SwitchToIFrame", base.isTakeScreenShotDuringEntryExit);
            //Switch to Iframe
            base.WaitForElement(By.Id(LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_PreferencesPage_Iframe_Id_Locator));
            base.SwitchToIFrame(LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_PreferencesPage_Iframe_Id_Locator);
            Logger.LogMethodExit("LTIToolsPreferencesPage",
               "SwitchToIFrame", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable LTI Preference.
        /// </summary>
        private void EnableLTIPreference()
        {
            //Enable LTI Preference
            Logger.LogMethodEntry("LTIToolsPreferencesPage",
               "EnableLTIPreference", base.isTakeScreenShotDuringEntryExit);
            //Initializing the Variable
            string getStatus = string.Empty;
            //Get the total Tool Displayed
            int getToolCount = base.GetElementCountByXPath(LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_MGMMathXLforSchool_DisplayedTool_XPath_Locator);
            for (int rowCount = Convert.ToInt32(LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_Loop_Initializer_Value); 
                rowCount <= getToolCount;rowCount++ )
            {                
                //Wait For The MGM MathXL for School Status
                base.WaitForElement(By.XPath(String.Format(LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_MGMMathXLforSchoolStatus_Xpath_Locator,
                    rowCount)),
                    Convert.ToInt32(LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_TimeToWait_Value));
                //Get The MGM MathXL for School Option Status                
                getStatus = base.GetElementTextByXPath(String.
                    Format(LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_MGMMathXLforSchoolStatus_Xpath_Locator,
                    rowCount));
                if (getStatus == LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_MGMMathXLforSchoolStatus_Value)
                {                    
                    break;
                }
            }            
            //Enable The MGM MathXL for School option If It Is Not Enabled
            this.EnableLtiForMGM(getStatus);
            //Save Preferences
            this.SaveLTIPreferences();
            Logger.LogMethodExit("LTIToolsPreferencesPage",
               "EnableLTIPreference", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Save LTI Preferences.
        /// </summary>
        private void SaveLTIPreferences()
        {
            //Save LTI Preferences
            Logger.LogMethodEntry("LTIToolsPreferencesPage",
               "SaveLTIPreferences", base.isTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(Convert.ToInt32(StandardSkillPreferencesPageResource.
                    StandardSkillPreferences_Page_ThreadSleep_Value));
                //Select Preferences Window
                this.SelectPreferencesWindow();
                //Select Iframe
                base.SwitchToIFrame(LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_PreferencesPage_Iframe_Id_Locator);
                //Wait For Save Preferences Button
                base.WaitForElement(By.PartialLinkText(LTIToolsPreferencesPageResource.
                        LTIToolsPreferences_Page_SavePreferences_Button_PartialText_Locator),
                        Convert.ToInt32(LTIToolsPreferencesPageResource.
                        LTIToolsPreferences_Page_TimeToWait_Value));
                //Get HTML Element Property for Cmenu
                IWebElement getSavePreferencesProperty = base.GetWebElementPropertiesByPartialLinkText
                 (LTIToolsPreferencesPageResource.
                        LTIToolsPreferences_Page_SavePreferences_Button_PartialText_Locator);
                getSavePreferencesProperty.SendKeys(string.Empty);
                //Click on the Course CMenu 
                base.ClickByJavaScriptExecutor(getSavePreferencesProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LTIToolsPreferencesPage",
               "SaveLTIPreferences", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable The MGM MathXL for School option If It Is Not Enabled.
        /// </summary>
        /// <param name="schoolOptionStatus">Status Of The MGM MathXL for School Option.</param>
        private void EnableLtiForMGM(string schoolOptionStatus)
        {
            //Enable The MGM MathXL for School option If It Is Not Enabled
            Logger.LogMethodEntry("LTIToolsPreferencesPage",
               "EnableLtiForMGM", base.isTakeScreenShotDuringEntryExit);
            if (schoolOptionStatus != LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_MGMMathXLforSchoolStatus_Value)
            {
                //Wait For The MGM MathXL for School Option
                base.WaitForElement(By.XPath(LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_MGMMathXLforSchool_Xpath_Locator),
                Convert.ToInt32(LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_TimeToWait_Value));
                IWebElement getMGMOption=base.GetWebElementPropertiesByXPath
                    (LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_MGMMathXLforSchool_Xpath_Locator);
                //Click on The MGM MathXL for School Option
                ClickByJavaScriptExecutor(getMGMOption);
                //Wait For Enable Tools CheckBox
                base.WaitForElement(By.Id(LTIToolsPreferencesPageResource.
               LTIToolsPreferences_Page_EnableTools_CheckBox_Id_Locator),
               Convert.ToInt32(LTIToolsPreferencesPageResource.
               LTIToolsPreferences_Page_TimeToWait_Value));
                do
                {
                    IWebElement getEnableOption=base.GetWebElementPropertiesById
                        (LTIToolsPreferencesPageResource.
                        LTIToolsPreferences_Page_EnableTools_CheckBox_Id_Locator);
                    // Check The Enable Tools CheckBox
                    ClickByJavaScriptExecutor(getEnableOption);
                }
                while (!base.IsElementSelectedById(LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_EnableTools_CheckBox_Id_Locator));
            }
            Logger.LogMethodExit("LTIToolsPreferencesPage",
               "EnableLtiForMGM", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the avialability of eText In LTITools with enable status in LTI tab.
        /// </summary>
        /// <returns>LTI Tool status</returns>
        public string GetEnabledLTITools(String integrationToolType)
        {
            // To Veifiy the avialability of Etext Toll with enbale status in LTITools.
            Logger.LogMethodEntry("LTIToolsPreferencesPage",
               "EnableETextlinLtiTools", base.isTakeScreenShotDuringEntryExit);
            // Initialize the variable to store Tool status
            string getEtextStatus = string.Empty;
            try
            {
                //Select Default Window
                SelectLTIToolWidnow();
                //Select Iframe
                base.WaitForElement(By.Id(LTIToolsPreferencesPageResource.LTITool_Pane_IframeID));
                base.SwitchToIFrame(LTIToolsPreferencesPageResource.
                    LTITool_Pane_IframeID);
                //Find All available Deployed Tools in LTI Tool
                getEtextStatus = VerifyEnabledLTITool(getEtextStatus, integrationToolType);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LTIToolsPreferencesPage",
               "EnableETextlinLtiTools", base.isTakeScreenShotDuringEntryExit);
            // return the status of eText tool 
            return getEtextStatus;
        }

        /// <summary>
        /// Get Status of the LTI Tool.
        /// </summary>
        /// <param name="lTiToolStatus">This is LTI Tool Status.</param>
        /// <param name="lTiToolType">This is LTI Tool Type.</param>
        /// <returns>LTI Tool status</returns>
        private string VerifyEnabledLTITool(string lTiToolStatus,
            string lTiToolType)
        {
            Logger.LogMethodEntry("LTIToolsPreferencesPage", "VerifyEnabledLTITool",
                base.isTakeScreenShotDuringEntryExit);
            IList<IWebElement> getAllToolRow = WebDriver.FindElements(
                By.ClassName(LTIToolsPreferencesPageResource.
                LTIToolsPreference_Page_ToolRow_ClassID));
            if (getAllToolRow.Count > 0)
            {
                //Initialize Counter Value
                int initializeToolCounter = 1;
                //Get Tool Text From Each Row
                foreach (IWebElement lTiToolelement in getAllToolRow)
                {
                    string getToolText = lTiToolelement.Text;
                    // Match LTI Tool In The Table 
                    if (getToolText.Contains(lTiToolType))
                    {
                        //Wait For Element 
                        base.IsElementPresent(By.ClassName(LTIToolsPreferencesPageResource.
                            LTIToolsPreference_Page_Tool_Td_Class_Name_Locator));
                        //Get Status Of Tool
                        string getAvailableToolsStatus =
                           base.GetElementTextById(string.Format(LTIToolsPreferencesPageResource.
                           LTIToolsPreferences_Page_LTI_Tool_Status_ID_Locator,
                           initializeToolCounter));
                        //Get the Enable Status of LTI Tool
                        if (getAvailableToolsStatus == LTIToolsPreferencesPageResource.
                            LTIToolsPreferences_Page_ToolEnable_Text)
                        {
                            //Get Tool Status
                            lTiToolStatus = getAvailableToolsStatus;
                            break;
                        }
                    }
                    initializeToolCounter++;
                }
            }
            Logger.LogMethodExit("LTIToolsPreferencesPage", "VerifyEnabledLTITool",
            base.isTakeScreenShotDuringEntryExit);
            return lTiToolStatus;
        }

        /// <summary>
        /// Select LTI Tool Window. 
        /// </summary>
        private void SelectLTIToolWidnow()
        {
            //Method Entry Log
            Logger.LogMethodEntry("LTIToolsPreferencesPage", "SelectLTIToolWidnow",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Window
            base.WaitUntilWindowLoads(LTIToolsPreferencesPageResource.LTITool_Tab_WindowName);
            base.SelectWindow(LTIToolsPreferencesPageResource.LTITool_Tab_WindowName);
            //Method Exit Log
            Logger.LogMethodExit("LTIToolsPreferencesPage", "SelectLTIToolWidnow",
                                  base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enable the EText Tool in Master Course LTI Preference.
        /// </summary>
        /// <param name="lTiToolType">This is LTI Tool Type.</param>
        public void GetLTIToolStatus(string lTiToolType)
        {
            // To Verify the avialability of Etext Tool with enbale status in LTITools.
            Logger.LogMethodEntry("LTIToolsPreferencesPage",
               "EnableEtextTool", base.isTakeScreenShotDuringEntryExit);
            // Initialize the variable to store Tool status
            string getEtextStatus = string.Empty;
            try
            {
                //Select Preference Window
                base.SelectWindow(LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_WindowName);
                //Wait For Element
                base.WaitForElement(By.Id(LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_Tool_WS_Tool_IFrame_ID_Locator));
                //Switch To IFrame
                base.SwitchToIFrame(LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_Tool_WS_Tool_IFrame_ID_Locator);
                //Get eText Status
               this.GetETexTltiToolStatus(lTiToolType);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("LTIToolsPreferencesPage",
               "EnableEtextTool", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get EText Status.
        /// </summary>
        /// <param name="eTextTool">This is eText Tool.</param>
        private void GetETexTltiToolStatus(string eTextTool)
        {
            Logger.LogMethodEntry("LTIToolsPreferencesPage",
                "VerifyETextEnabledLTITool", base.isTakeScreenShotDuringEntryExit);
            //Wait For Element 
            base.WaitForElement(By.ClassName
                (LTIToolsPreferencesPageResource.
            LTIToolsPreference_Page_Tool_WS_Tool_Div_ClassName_Locator));
            IList<IWebElement> getAllToolRow1 = WebDriver.FindElements(
                By.ClassName(LTIToolsPreferencesPageResource.
                LTIToolsPreference_Page_Tool_WS_Row_Class_Name_Locator));
            if (getAllToolRow1.Count > 0)
            {
                //Initialize Counter Value
                int initializeToolCounter = 1;
                //Get Tool Text From Each Row
                foreach (IWebElement getToolRowProperty in getAllToolRow1)
                {
                    string getToolText = getToolRowProperty.Text;
                    // Match LTI Tool In The Table 
                    if (getToolText.Contains(eTextTool))
                    {
                        //Enable Tool Status
                        this.EnableTheToolStatus(initializeToolCounter);
                        base.SwitchToDefaultWindow();
                        // Click on Save Preference to save eText 
                        new GeneralPreferencesPage().SavePreferences();
                    }
                    initializeToolCounter++;
                }
            }
           
            Logger.LogMethodExit("LTIToolsPreferencesPage", 
                "VerifyETextEnabledLTITool",
            base.isTakeScreenShotDuringEntryExit);
          }

        /// <summary>
        /// Enable the tool status.
        /// </summary>
        /// <param name="initializeToolCounter">This is tool row counter.</param>
        private void EnableTheToolStatus(int initializeToolCounter)
        {
            Logger.LogMethodEntry("LTIToolsPreferencesPage", "EnableTheToolStatus",
          base.isTakeScreenShotDuringEntryExit);
            ////Wait For Element 
            //base.WaitForElement(By.ClassName
            //    (LTIToolsPreferencesPageResource.
            //LTIToolsPreference_Page_Tool_WS_Tool_Div_ClassName_Locator));

            base.IsElementPresent(By.ClassName(LTIToolsPreferencesPageResource.
            LTIToolsPreference_Page_Tool_WS_Tool_Div_ClassName_Locator),3);
            // Store Tool Row text that will use to clcik 
            String getETextTollStatus = base.GetInnerTextAttributeValueByXPath(string.Format
                (LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_Tool_WS_ETextTool_Status_Xpath_Locator,
                initializeToolCounter)).TrimEnd();
            if (getETextTollStatus == LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_Tool_WS_ETextTool_Status_Disabled_Text)
            {
                //Get the HTML peroperty of eText Row
                IWebElement getToolsRowTextProperty = base.
                    GetWebElementPropertiesByXPath(string.Format
                    (LTIToolsPreferencesPageResource.
                    LTIToolsPreferences_Page_Tool_WS_ETextTool_Row_Xpath_Locator,
                    initializeToolCounter));
                // Click on eText Row 
                base.ClickByJavaScriptExecutor(getToolsRowTextProperty);
                // Enable chekbox of e text 
                base.WaitForElement(By.Id(LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_Tool_WS_ETextTool_CheckBox_ID_Locator));
                //Get HTML property of check box
                IWebElement getPropertyofCheckbox = base.
                    GetWebElementPropertiesById(LTIToolsPreferencesPageResource.
                LTIToolsPreferences_Page_Tool_WS_ETextTool_CheckBox_ID_Locator);
                base.ClickByJavaScriptExecutor(getPropertyofCheckbox);
                
            }
            Logger.LogMethodExit("LTIToolsPreferencesPage", "EnableTheToolStatus",
          base.isTakeScreenShotDuringEntryExit);
        }
    }
}
