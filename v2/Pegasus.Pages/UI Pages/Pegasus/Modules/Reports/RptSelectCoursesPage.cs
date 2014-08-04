using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Reports;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages;

namespace Pegasus.Pages.UI_Pages
{

    /// <summary>
    /// This class handles Custom Report Page Actions
    /// </summary>
   public class RptSelectCoursesPage :BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
       private static Logger logger = Logger.GetInstance(typeof(RptSelectCoursesPage));

       /// <summary>
       /// Select The Course
       /// </summary>
       public void SelectTheCourse()
       {
           //Select The Course
           logger.LogMethodEntry("RptSelectCoursesPage", "SelectTheCourse",
           base.IsTakeScreenShotDuringEntryExit);
           try
           {
               //Select Custom Frame
               new RptMainUXPage().SelectCustomFrame();
               //Wait for the Select course element         
               base.WaitForElement(By.XPath(RptSelectCoursesPageResource.
                   RptSelectCourses_Page_SelectCourse_Btn_Xpath_Locator));
               IWebElement getCourseName = base.GetWebElementPropertiesByXPath
                   (RptSelectCoursesPageResource.
                   RptSelectCourses_Page_SelectCourse_Btn_Xpath_Locator);
               //Click the Select course link
               base.ClickByJavaScriptExecutor(getCourseName);
               Thread.Sleep(Convert.ToInt32(RptSelectCoursesPageResource.
                   RptSelectCourses_Page_SelectCourse_Window_Time));
               //Select Course Window opened
               base.SelectWindow(RptSelectCoursesPageResource.
                   RptSelectCourses_Page_SelectCourse_Window_Name);
               //Wait for the selct option dropdown for class
               base.WaitForElement(By.Id(RptSelectCoursesPageResource.
                   RptSelectCourses_Page_SelectClass_Dropdown_Id_Locator));
               base.SelectDropDownValueThroughIndexById(RptSelectCoursesPageResource.
                   RptSelectCourses_Page_SelectClass_Dropdown_Id_Locator,
                    Convert.ToInt32(RptSelectCoursesPageResource.
                   RptSelectCourses_Page_SelectClass_Dropdown_Value));
               //Wait for delay
               Thread.Sleep(Convert.ToInt32(RptSelectCoursesPageResource.
                   RptSelectCourses_Page_SelectClass_Window_Time));
               //Select Class CheckBox
               this.SelectClassCheckBox();
           }
           catch (Exception e)
           {
               ExceptionHandler.HandleException(e);
           }          
           logger.LogMethodExit("RptSelectCoursesPage", "SelectTheCourse",
             base.IsTakeScreenShotDuringEntryExit);
       }

       /// <summary>
       /// Select Class CheckBox
       /// </summary>
       private void SelectClassCheckBox()
       {
           //Select Class CheckBox
           logger.LogMethodEntry("RptSelectCoursesPage", "SelectClassCheckBox",
           base.IsTakeScreenShotDuringEntryExit);
           //Wait for the Select Class checkbox
           base.WaitForElement(By.Id(RptSelectCoursesPageResource.
               RptSelectCourses_Page_SelectClass_Checkbox_Id_Locator));
           base.FocusOnElementById(RptSelectCoursesPageResource.
               RptSelectCourses_Page_SelectClass_Checkbox_Id_Locator);
           //Get web element
           IWebElement getSelectAllClass = base.GetWebElementPropertiesById
               (RptSelectCoursesPageResource.
               RptSelectCourses_Page_SelectClass_Checkbox_Id_Locator);
           //Click the class checkbox
           base.ClickByJavaScriptExecutor(getSelectAllClass);
           //Wait for the Add Close btn
           base.WaitForElement(By.Id(RptSelectCoursesPageResource.
               RptSelectCourses_Page_SelectClass_CloseBtn_Id_Locator));
           IWebElement getCourseAddCloseBtn = base.GetWebElementPropertiesById
               (RptSelectCoursesPageResource.
               RptSelectCourses_Page_SelectClass_CloseBtn_Id_Locator);
           //Click the AddClose button
           base.ClickByJavaScriptExecutor(getCourseAddCloseBtn);
           Thread.Sleep(Convert.ToInt32(RptSelectCoursesPageResource.
             RptSelectCourses_Page_SelectCourse_Window_Time));
           logger.LogMethodExit("RptSelectCoursesPage", "SelectClassCheckBox",
             base.IsTakeScreenShotDuringEntryExit);
       }
    }
}
