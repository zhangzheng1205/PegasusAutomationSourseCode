using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes.Channels;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Templates;
using Pegasus.Pages.Exceptions;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Select Class Course Folder Page Actions
    /// </summary>
    public class SelectClassCourseFolderPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(SelectClassCourseFolderPage));

        /// <summary>
        /// Enter inside the Course
        /// </summary>
        public void EnterInsideCourse()
        {
            //Enter inside the Course
            logger.LogMethodEntry("SelectClassCourseFolderPage", "EnterInsideCourse",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(SelectClassCourseFolderPageResource.
                        SelectClassCourseFolder_Page_SelectCourse_Window_Locator);
                //Select Select Course Window
                base.SelectWindow(SelectClassCourseFolderPageResource.
                    SelectClassCourseFolder_Page_SelectCourse_Window_Locator);
                base.WaitForElement(By.Name(SelectClassCourseFolderPageResource.
                SelectClassCourseFolder_Page_Course_RadioButton_Name_Locator));
                Thread.Sleep(Convert.ToInt32(SelectClassCourseFolderPageResource.
                 SelectClassCourseFolder_Page_SleepTime_Value));
                base.FocusOnElementByXPath(SelectClassCourseFolderPageResource.
                SelectClassCourseFolder_Page_Course_RadioButton_Xpath_Locator);
                //Click on MasterLibrary Radio Button
                base.ClickButtonByXPath(SelectClassCourseFolderPageResource.
                SelectClassCourseFolder_Page_Course_RadioButton_Xpath_Locator);
                base.WaitForElement(By.PartialLinkText(SelectClassCourseFolderPageResource.
                SelectClassCourseFolder_Page_EnterCourse_Link_Locator));
                //Click on Link Enter Course
                base.ClickButtonByPartialLinkText(SelectClassCourseFolderPageResource.
                SelectClassCourseFolder_Page_EnterCourse_Link_Locator);
                base.IsPopUpClosed(3);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SelectClassCourseFolderPage", "EnterInsideCourse",
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
