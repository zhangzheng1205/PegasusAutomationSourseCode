using System;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.MMND.LTISettings.Main.AdminMode.LTICourseToolSettings;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class Handles ManageCourseToolSettingsViewPage actions
    /// </summary>    
    public class ManageCourseToolSettingsViewPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger logger = 
            Logger.GetInstance(typeof(ManageCourseToolSettingsViewPage));


        /// <summary>
        /// Insert Integration point Id.
        /// </summary>
        ///<param name="integrationPointId">This is Integration PointId.</param>
        public void InsertIntegrationPointId(string integrationPointId)
        {
            //Insert Integration Point Id
            logger.LogMethodEntry("ManageCourseToolSettingsViewPage", "InsertIntegrationPointId",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Administrative Pages Window
                base.SelectWindow(ManageCourseToolSettingsViewPageResource.
                       ManageCourseToolSettingsView_Page_Window_Name);
                base.WaitForElement(By.Name(ManageCourseToolSettingsViewPageResource.
                    ManageCourseToolSettingsView_Page_Frame_Name_Locator));
                //Switch to Frame
                base.SwitchToIFrame(ManageCourseToolSettingsViewPageResource.
                    ManageCourseToolSettingsView_Page_Frame_Name_Locator);
                base.WaitForElement(By.XPath(ManageCourseToolSettingsViewPageResource.
                    ManageCourseToolSettingsView_Page_Input_IntructorId_Xpath_Locator));
                //Clear Integration Point id TextBox
                base.ClearTextByXPath(ManageCourseToolSettingsViewPageResource.
                    ManageCourseToolSettingsView_Page_Input_IntructorId_Xpath_Locator);
                IWebElement getCourseTextBoxProperty = base.GetWebElementPropertiesByXPath(
                    ManageCourseToolSettingsViewPageResource.
                    ManageCourseToolSettingsView_Page_Input_IntructorId_Xpath_Locator);
                //Fill Integration Id
                getCourseTextBoxProperty.SendKeys(integrationPointId);
                Thread.Sleep(Convert.ToInt32(ManageCourseToolSettingsViewPageResource.
                    ManageCourseToolSettingsView_Page_TimeValue));
                base.WaitForElement(By.Id(ManageCourseToolSettingsViewPageResource.
                    ManageCourseToolSettingsView_Page_SaveButton_Id_Locator));
                IWebElement getSaveButton=base.GetWebElementPropertiesById
                    (ManageCourseToolSettingsViewPageResource.
                    ManageCourseToolSettingsView_Page_SaveButton_Id_Locator);
                //Click on Save Button
                base.ClickByJavaScriptExecutor(getSaveButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                   
                throw;
            }
            logger.LogMethodExit("ManageCourseToolSettingsViewPage", "InsertIntegrationPointId",
            base.IsTakeScreenShotDuringEntryExit);
        }

    }
}
