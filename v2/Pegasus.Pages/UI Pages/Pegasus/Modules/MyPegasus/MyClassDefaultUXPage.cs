using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.MyPegasus;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    // <summary>
    /// This Class Handles MyClassDefaultUX Page Actions
    /// </summary>
    public class MyClassDefaultUXPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(MyClassDefaultUXPage));

        /// <summary>
        /// Click on Create Course Option
        /// </summary>
        public void ClickOnCreateCourseOption()
        {
            //Click on Create Course Option
            logger.LogMethodEntry("MyClassDefaultUXPage", "ClickOnCreateCourseOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.SelectWindow(MyClassDefaultUXPageResource.
                    MyClassDefaultUX_Page_Window_Tittle);
                //Wait for Element
                base.WaitForElement(By.XPath(MyClassDefaultUXPageResource.
                    MyClassDefaultUX_Page_CreateCourseButton_Xpath_Locator));
                //Get Element Property
                IWebElement getCreateCourse = base.GetWebElementPropertiesByXPath
                    (MyClassDefaultUXPageResource.
                    MyClassDefaultUX_Page_CreateCourseButton_Xpath_Locator);
                //Click on Create Course Button
                base.ClickByJavaScriptExecutor(getCreateCourse);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("MyClassDefaultUXPage", "ClickOnCreateCourseOption",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
