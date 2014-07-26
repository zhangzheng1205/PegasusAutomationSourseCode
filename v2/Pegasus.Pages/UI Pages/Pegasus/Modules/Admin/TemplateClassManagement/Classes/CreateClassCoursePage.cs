using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    // <summary>
    /// This Class Handles CreateClassCourse Page Actions
    /// </summary>
    public class CreateClassCoursePage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(CreateClassCoursePage));

        /// <summary>
        /// Create the Course Using Master Library
        /// </summary>
        public void CreatetheCourseUsingMasterLibrary()
        {
            //Create the Course Using Master Library
            logger.LogMethodEntry("CreateClassCoursePage", "CreatetheCourseUsingMasterLibrary",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window Open
                base.WaitUntilWindowLoads(CreateClassCoursePageResource.
                    CreateClassCourse_Page_CreateCourse_Window_Title);
                //Select Window
                base.SelectWindow(CreateClassCoursePageResource.
                    CreateClassCourse_Page_CreateCourse_Window_Title);
                //Wait for Element
                base.WaitForElement(By.Id(CreateClassCoursePageResource.
                    CreateClassCourse_Page_Checkbox_Id_Locator));
                //Click Checkbox
                base.SelectCheckBoxById(CreateClassCoursePageResource.
                    CreateClassCourse_Page_Checkbox_Id_Locator);
                //Wait for Element
                base.WaitForElement(By.PartialLinkText(CreateClassCoursePageResource.
                    CreateClassCourse_Page_SaveButton_PartiallinkText));
                //Get Element Property
                IWebElement getSaveButton = base.GetWebElementPropertiesByPartialLinkText
                    (CreateClassCoursePageResource.
                    CreateClassCourse_Page_SaveButton_PartiallinkText);
                //Click on Save Button
                base.ClickByJavaScriptExecutor(getSaveButton);
                //Wait To Pop Up Get Close
                if (base.IsPopUpClosed(2))
                {
                    //Switch To Global Home Page
                    base.WaitUntilPageGetSwitchedSuccessfully(CreateClassCoursePageResource.
                        CreateClassCourse_Page_GlobalHome_Window_Title);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateClassCoursePage", "CreatetheCourseUsingMasterLibrary",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Successfull Message From Create Class Window.
        /// </summary>
        /// <returns>Successfull Message.</returns>
        public string GetSuccessfullMessageFromCreateClassWindow()
        {
            //Get Successfull Message From Create Class Window.
            logger.LogMethodEntry("CreateClassCoursePage",
                "GetSuccessfullMessageFromCreateClassWindow",
               base.isTakeScreenShotDuringEntryExit);
            //Initializing Variable
            string getSuccessfullMessage = string.Empty;
            try
            {
                //Wait For Create Class Window Loads
                new ClassUserControlsPage().SelectCreateClassWindow();
                //Wait for the element
                base.WaitForElement(By.Id(CreateClassCoursePageResource.
                    CreateClassCourse_Page_Enrollment_Message_Id_Locator));
                getSuccessfullMessage = base.GetElementTextById
                    (CreateClassCoursePageResource.
                    CreateClassCourse_Page_Enrollment_Message_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("CreateClassCoursePage",
                "GetSuccessfullMessageFromCreateClassWindow",
                base.isTakeScreenShotDuringEntryExit);
            return getSuccessfullMessage;
        }
    }
}
