using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.MMND.VizedHtmlContent.Main.AuthorMode.NonManagedVizedHtmlProf;
using System.Configuration;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles MMND Base Page actions
    /// </summary>
    public class ManagePage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ManagePage));

        /// <summary>
        /// Get Instructor Asset Id from Appconfig File
        /// </summary>
        readonly string getInstructorAssetId = ConfigurationManager.AppSettings
            [ManagePageResource.ManagePage_InstructorAssetId_AppSettings_Key_Value];

        /// <summary>
        /// Get Student Asset Id from Appconfig File
        /// </summary>
        readonly string getStudentAssetId = ConfigurationManager.AppSettings[
            ManagePageResource.ManagePage_StudentAssetId_AppSettings_Key_Value];

        /// <summary>
        /// Paste The CBOM Request
        /// </summary>
        /// <param name="subtabLinkName">This is Tool/Asset launch Subtab Link Name</param>
        public void PasteTheCBOMRequest(string subtabLinkName)
        {
            //Paste The CBOM Request
            logger.LogMethodEntry("ManagePage", "PasteTheCBOMRequest",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click On the Tool Launch Subtab
                new PostIndexMixedPage().ClickOnToolLaunchSubtab(subtabLinkName);
                //Click On Manage Option
                new PostIndexMixedPage().ClickOnManageOption(subtabLinkName);
                //Wait for the window
                base.WaitUntilWindowLoads(subtabLinkName + ManagePageResource.
                    ManagePage_Text_Appended_To_Window_Title);
                base.SelectWindow(subtabLinkName + ManagePageResource.
                    ManagePage_Text_Appended_To_Window_Title);
                //Wait for the Frame
                base.WaitForElement(By.Id(ManagePageResource.
                    ManagePage_Frame_CenterIFrame_Id_Locator));
                base.SwitchToIFrame(ManagePageResource.
                    ManagePage_Frame_CenterIFrame_Id_Locator);
                //Wait for the HTML button
                base.WaitForElement(By.PartialLinkText(ManagePageResource.
                    ManagePage_HTML_PratialLinkText_Locator_Value));
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByPartialLinkText(
                    ManagePageResource.ManagePage_HTML_PratialLinkText_Locator_Value));
                //Enter the CBOM Request                
                base.WaitForElement(By.XPath(ManagePageResource.
                    ManagePage_HTML_Textarea_Xpath_Locator));
                base.FillTextBoxByXPath(ManagePageResource.
                    ManagePage_HTML_Textarea_Xpath_Locator,
                    ManagePageResource.ManagePage_CBOM_Request_Text);
                //Click on the Save Changes button                
                base.ClickByJavaScriptExecutor(base.GetWebElementPropertiesByClassName(
                    ManagePageResource.ManagePage_AddSubtab_Close_Button_ClassName_Locator));
                //Accept The Alert Displayed
                this.AcceptTheAlertDisplayed();
                //View The Links 
                this.ViewTheLinksFromCBOMRequest(subtabLinkName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManagePage", "PasteTheCBOMRequest",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Accept The Alert Displayed
        /// </summary>
        private void AcceptTheAlertDisplayed()
        {
            //Accept the Alert
            logger.LogMethodEntry("ManagePage", "AcceptTheAlertDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variables
            bool isAlertPresent = false;
            int getTimeElapsed = Convert.ToInt32(ManagePageResource.ManagePage_Alert_Sleep_Time);
            //Loop until the Alert is Displayed or time is over
            while (!isAlertPresent && getTimeElapsed <= Convert.ToInt32(ManagePageResource.
                ManagePage_Alert_Maximum_Time))
            {
                try
                {                    
                    isAlertPresent = true;
                    //Accept The Alert
                    base.AcceptAlert();
                }
                catch
                {
                    isAlertPresent = false;
                    //Wait for 1 sec
                    Thread.Sleep(Convert.ToInt32(ManagePageResource.
                        ManagePage_Alert_Sleep_Time));
                    getTimeElapsed = getTimeElapsed + Convert.ToInt32(ManagePageResource.
                        ManagePage_Alert_Sleep_Time);
                }
            }
            logger.LogMethodExit("ManagePage", "AcceptTheAlertDisplayed",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// View The Links From CBOM Request
        /// </summary>
        /// <param name="subtabLinkName">This is Tool/Asset launch Subtab Link Name</param>
        private void ViewTheLinksFromCBOMRequest(string subtabLinkName)
        {
            //View The Links From CBOM Request
            logger.LogMethodEntry("ManagePage", "ViewTheLinksFromCBOMRequest",
                base.isTakeScreenShotDuringEntryExit);
            //Wait for the Window
            base.WaitUntilWindowLoads(subtabLinkName + ManagePageResource.
                ManagePage_Text_Appended_To_Window_Title);
            base.SelectWindow(subtabLinkName + ManagePageResource.
                ManagePage_Text_Appended_To_Window_Title);
            //Click on the Modify Link
            base.WaitForElement(By.Id(ManagePageResource.ManagePage_Right_Modify_Id_Locator));
            base.ClickLinkByID(ManagePageResource.ManagePage_Right_Modify_Id_Locator);
            //Click on the View Link
            base.WaitForElement(By.XPath(ManagePageResource.
                ManagePage_Modify_View_Option_Xpath_Locator));
            base.ClickLinkByXPath(ManagePageResource.
                ManagePage_Modify_View_Option_Xpath_Locator);
            logger.LogMethodExit("ManagePage", "ViewTheLinksFromCBOMRequest",
                base.isTakeScreenShotDuringEntryExit);
        }


    }
}
