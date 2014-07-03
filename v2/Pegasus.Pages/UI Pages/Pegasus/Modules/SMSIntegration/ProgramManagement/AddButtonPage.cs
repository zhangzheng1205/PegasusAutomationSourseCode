using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.SMSIntegration.ProgramManagement;
using Pegasus.Pages.Exceptions;
namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Add Enrol Button Page Actions.
    /// </summary>
    public class AddButtonPage : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(AddButtonPage));

        /// <summary>
        /// Click's To Course Enrollment Button to Associate Course to Product.
        /// </summary>
        public void ClickProgramCoursesAddButton()
        {
            //Click To Course Enrollment Button to Associate Course to Product
            Logger.LogMethodEntry("AddButtonPage", "ClickProgramCoursesAddButton",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                this.SelectManageProductsWindow();
                //Select IFrame
                this.SelectWorkSpaceIFrame();
                //Select Middle IFrame
                this.SelectMiddleIFrame();
                //Select the Add Button - Browser Specific
                this.SelectAddButtonInMiddleFrame();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AddButtonPage", "ClickProgramCoursesAddButton",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Middle IFrame.
        /// </summary>
        private void SelectMiddleIFrame()
        {
            //Select Middle IFrame
            Logger.LogMethodEntry("AddButtonPage", "SelectMiddleIFrame",
               base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(AddButtonPageResource.
                                          AddButton_Page_iFrameMiddle_Id_Locator));
            //Switch To Frame
            base.SwitchToIFrame(AddButtonPageResource.
                                    AddButton_Page_iFrameMiddle_Id_Locator);
            Logger.LogMethodExit("AddButtonPage", "SelectMiddleIFrame",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select WorkSpace IFrmrame.
        /// </summary>
        private void SelectWorkSpaceIFrame()
        {
            //Select IFrame
            Logger.LogMethodEntry("AddButtonPage", "SelectWorkSpaceIFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(AddButtonPageResource.
                                          AddButton_Page_WorkspaceiFrame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(AddButtonPageResource.
                                    AddButton_Page_WorkspaceiFrame_Id_Locator);
            Logger.LogMethodExit("AddButtonPage", "SelectWorkSpaceIFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Manage Products Window.
        /// </summary>
        private void SelectManageProductsWindow()
        {
            //Select Manage Products Window
            Logger.LogMethodEntry("AddButtonPage", "SelectManageProductsWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Select Window
            base.SelectWindow(AddButtonPageResource.
                                  AddButton_Page_Window_Title_Page);
            Logger.LogMethodExit("AddButtonPage", "SelectManageProductsWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Add button in Middle Frame.
        /// </summary>
        private void SelectAddButtonInMiddleFrame()
        {
            //Select Add Button
            Logger.LogMethodEntry("AddButtonPage", "SelectAddButtonInMiddleFrame",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(AddButtonPageResource.
                  AddButton_Page_ProgramCourses_Button_Id_Locator));
            switch (base.Browser)
            {
                //Perform Click Add Button In FireFox
                case PegasusBaseTestFixture.FireFox:
                    this.ClickAddButtonInFireFox();
                    break;
                //Perform Click Add Button In Internet Explorer
                case PegasusBaseTestFixture.InternetExplorer:
                    ClickAddButonInInternetExplorer();
                    break;
                //Perform Click Add Button In Chrome
                case PegasusBaseTestFixture.Chrome:
                    this.ClickAddButtonInChrome();
                    break;
            }
            Logger.LogMethodExit("AddButtonPage", "SelectAddButtonInMiddleFrame",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Add Button In Chrome Browser.
        /// </summary>
        private void ClickAddButtonInChrome()
        {
            //Click Add Button in Chrome
            Logger.LogMethodEntry("AddButtonPage", "ClickAddButtonInChrome",
               base.isTakeScreenShotDuringEntryExit);
            //Get Add Button Properties
            IWebElement buttonProgramCoursesinChrome =
                base.GetWebElementPropertiesById(AddButtonPageResource.
                                                     AddButton_Page_ProgramCourses_Button_Id_Locator);
            buttonProgramCoursesinChrome.Click();
            Logger.LogMethodExit("AddButtonPage", "ClickAddButtonInChrome",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Add Button In IE Browser.
        /// </summary>
        private void ClickAddButonInInternetExplorer()
        {
            //Click Add Button In IE
            Logger.LogMethodEntry("AddButtonPage", "ClickAddButonInInternetExplorer",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(AddButtonPageResource.
                     AddButton_Page_ProgramCourses_Button_Id_Locator));
            //Select Add Button
            IWebElement buttonProgramCourse = base.GetWebElementPropertiesById
                (AddButtonPageResource.
                     AddButton_Page_ProgramCourses_Button_Id_Locator);
            base.ClickByJavaScriptExecutor(buttonProgramCourse);
            Logger.LogMethodExit("AddButtonPage", "ClickAddButonInInternetExplorer",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click Add Button In Firefox Browser.
        /// </summary>
        private void ClickAddButtonInFireFox()
        {
            //Click Add Button In Fire Fox
            Logger.LogMethodEntry("AddButtonPage", "ClickAddButtonInFireFox",
                base.isTakeScreenShotDuringEntryExit);
            //Get Add Button Properties
            IWebElement buttonProgramCoursesinFirefox =
                base.GetWebElementPropertiesById(AddButtonPageResource.
                                                     AddButton_Page_ProgramCourses_Button_Id_Locator);
            buttonProgramCoursesinFirefox.Click();
            Logger.LogMethodExit("AddButtonPage", "ClickAddButtonInFireFox",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
