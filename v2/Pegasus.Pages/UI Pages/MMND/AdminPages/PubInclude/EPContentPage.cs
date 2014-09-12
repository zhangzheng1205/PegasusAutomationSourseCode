using System;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.MMND.AdminPages.PubInclude;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the Select MMND course actions.
    /// </summary>
    public class EPContentPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(EPContentPage));

        /// <summary>
        /// Select Course Compass Next Generation.
        /// </summary>
        /// <param name="coursType">This is Course Type.</param>
        public void SelectCourseCompassNextGeneration(string coursType)
        {
            //Select Course Compass Next Generation
            logger.LogMethodEntry("EPContentPage", "SelectCourseCompassNextGeneration",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Administrative Page Window
                this.SelectAdministrativePageWindow();
                base.WaitForElement(By.Name(EPContentPageResource.EPContent_Page_Frame_Name_Locator));
                //Switch to Frame
                base.SwitchToIFrame(EPContentPageResource.EPContent_Page_Frame_Name_Locator);
                base.WaitForElement(By.Name(EPContentPageResource.EPContet_Page_CourseType_DropDown_Name));
                //Select Course Compo Next Generation in Drop Down
                base.SelectDropDownValueThroughTextByName(EPContentPageResource.
                    EPContet_Page_CourseType_DropDown_Name, coursType);
                base.WaitForElement(By.XPath(EPContentPageResource.
                    EPContent_Page_NextButton_Name_Xpath_Locator));
                //Focus on Next Button
                base.FocusOnElementByXPath(EPContentPageResource.
                    EPContent_Page_NextButton_Name_Xpath_Locator);
                IWebElement getNextButtonProperty = base.GetWebElementPropertiesByXPath
                    (EPContentPageResource.EPContent_Page_NextButton_Name_Xpath_Locator);
                //Click On Next Button
                base.ClickByJavaScriptExecutor(getNextButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EPContentPage", "SelectCourseCompassNextGeneration",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Sign Out From Application.
        /// </summary>
        public void SignOutFromApplication()
        {
            //Sign Out From Application
            logger.LogMethodEntry("EPContentPage", "SignOutFromApplication",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Administrative Page Window
                base.SelectWindow(EPContentPageResource.EPContent_Page_Window_Name);
                base.WaitForElement(By.Name(EPContentPageResource.
                    EPContent_Page_HeaderFrame_Name_Locator));
                //Switch to Frame
                base.SwitchToIFrame(EPContentPageResource.
                    EPContent_Page_HeaderFrame_Name_Locator);
                base.WaitForElement(By.PartialLinkText(EPContentPageResource.
                    EPContent_Page_Exit_Link_Locator));
                //Click on Exit Link
                base.ClickButtonByPartialLinkText(EPContentPageResource.
                    EPContent_Page_Exit_Link_Locator);
                //base.WaitUntilWindowLoads(EPContentPageResource.
                //    EPContent_Page_HomePSH_Window_Name);
                ////Select HomePSH Window
                //base.SelectWindow(EPContentPageResource.
                //    EPContent_Page_HomePSH_Window_Name);
                //base.WaitForElement(By.PartialLinkText(EPContentPageResource.
                //    EPContent_Page_Signoff_Link_Locator));
                ////Click On Sign Off Link
                //base.ClickButtonByPartialLinkText(EPContentPageResource.
                //    EPContent_Page_Signoff_Link_Locator);
                //base.WaitUntilWindowLoads(EPContentPageResource.
                //    EPContent_Page_CourseCompassNextGen_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);                
            }
            logger.LogMethodExit("EPContentPage", "SignOutFromApplication",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Administrative Page Window.
        /// </summary>
        private void SelectAdministrativePageWindow()
        {
            //Select Administrative Page Window
            logger.LogMethodEntry("EPContentPage", "SelectAdministrativePageWindow",
            base.IsTakeScreenShotDuringEntryExit);
            //Select Administrative Pages Window
            base.WaitUntilWindowLoads(EPContentPageResource.
             EPContent_Page_AdministrationPages_Window_Name);
            base.SelectWindow(EPContentPageResource.
                EPContent_Page_AdministrationPages_Window_Name);
            logger.LogMethodExit("EPContentPage", "SelectAdministrativePageWindow",
            base.IsTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Verify Exit Link Present On The Page.
        /// </summary>
        /// <returns>Return True if user already logged in otherwise false.</returns>
        public Boolean IsExitButtonDisplayed()
        {
            //Verify Exit Link
            logger.LogMethodEntry("EPContentPage", "IsVerifyExitButton",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialiaze variable
            Boolean isUserLoggedIn = false;
            try
            {
                //Select Default Window
                base.SelectDefaultWindow();
                //Wait For Element
                base.WaitForElement(By.Name(EPContentPageResource.
                    EPContent_Page_HeaderFrame_Name_Locator));
                //Switch to Frame
                base.SwitchToIFrame(EPContentPageResource.EPContent_Page_HeaderFrame_Name_Locator);
                isUserLoggedIn = base.IsElementPresent(By.PartialLinkText(
                    EPContentPageResource.EPContent_Page_Exit_Link_Locator),
                Convert.ToInt32(EPContentPageResource.EPContent_Custom_TimeToWait_Element));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);      
            }
            logger.LogMethodExit("EPContentPage", "IsVerifyExitButton",
            base.IsTakeScreenShotDuringEntryExit);
            return isUserLoggedIn;
        }
    }
}
