using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Pearson.Pegasus.TestAutomation.Frameworks;
using System.Configuration;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.MyPegasus;


namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains the details of Student Help Text
    /// window. If this window appears while login by SMS Student
    /// then requires to close it.
    /// </summary>
    public class StudentHelpTextPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(StudentHelpTextPage));

        /// <summary>
        /// To Closing Student Help Text Window if window is present
        /// </summary>
        public void ManageStudentHelpTextWindow()
        {
            logger.LogMethodEntry("StudentHelpTextPage", "ManageStudentHelpTextWindow", 
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                Thread.Sleep(Convert.ToInt32(StudentHelpTextPageResource.
                    StudentHelpText_Page_Sleep_Time));
                base.SwitchToLastOpenedWindow();
                //To check presence of Student Help Text Window
                bool isStudentHelpTextWindowPresent = base.IsWindowsExists(
                    StudentHelpTextPageResource.StudentHelpText_Page_Window_Title_Name,
                    Convert.ToInt32(StudentHelpTextPageResource.
                    StudentHelpText_Page_Custom_Wait_Time_Value));
                // To close the Student Help Text Window if present
                if (isStudentHelpTextWindowPresent)
                {
                    //Close Student Help Text Window
                    CloseStudentHelpTextWindow();
                }
            }
            catch (Exception e)
            {                
               ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("StudentHelpTextPage", "ManageStudentHelpTextWindow",
                base.IsTakeScreenShotDuringEntryExit);          
        }

        /// <summary>
        /// Close Student Help Text Window
        /// </summary>
        private void CloseStudentHelpTextWindow()
        {
            //Close Student Help Text Window
            logger.LogMethodEntry("StudentHelpTextPage", "CloseStudentHelpTextWindow",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(StudentHelpTextPageResource.
                                  StudentHelpText_Page_Window_Title_Name);
            base.SelectWindow(StudentHelpTextPageResource.
                                  StudentHelpText_Page_Window_Title_Name);
            //Wait for Window
            base.WaitForElement(By.Id(StudentHelpTextPageResource.
                                          StudentHelpText_Page_Display_Checkbox_Id_Locator));
            IWebElement getStudentHelpText=base.GetWebElementPropertiesById
                (StudentHelpTextPageResource.
                                       StudentHelpText_Page_Display_Checkbox_Id_Locator);
            base.ClickByJavaScriptExecutor(getStudentHelpText);
            //Wait for Button
            base.WaitForElement(By.Id(StudentHelpTextPageResource.
                                          StudentHelpText_Page_Ok_Button_Id_Locator));
            //Get HTML Element Property
            IWebElement getOkButton = base.GetWebElementPropertiesById(StudentHelpTextPageResource.
                                     StudentHelpText_Page_Ok_Button_Id_Locator);
            //Click on Button
            base.ClickByJavaScriptExecutor(getOkButton);            
            Thread.Sleep(Convert.ToInt32(StudentHelpTextPageResource
                .StudentHelpText_Page_ThreadSleep_Value));
            logger.LogMethodExit("StudentHelpTextPage", "CloseStudentHelpTextWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
