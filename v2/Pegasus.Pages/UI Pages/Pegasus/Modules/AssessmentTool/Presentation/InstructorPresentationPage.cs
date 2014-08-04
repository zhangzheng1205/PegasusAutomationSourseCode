using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool.Presentation;
using System.Threading;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the activity presentation page actions.
    /// </summary>
    public class InstructorPresentationPage : BasePage
    {
        /// <summary>
        /// This is the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(InstructorPresentationPage));

        /// <summary>
        /// Launch Study Plan Activity.
        /// </summary>
        /// <returns>True if the element is found in the presentation 
        /// page otherwise false.</returns>
        public bool IsPostTestActivityLaunched()
        {
            //Verify Activity Launched
            logger.LogMethodEntry("InstructorPresentationPage", "IsPostTestActivityLaunched",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Bool Variable
            bool isActivityFinishButtonPresent = false;
            try
            {
                // Wait and Select Window
                base.WaitUntilWindowLoads(InstructorPresentationPageResource.
                    InstructorPresentationPage_Test_WindowName);
                base.SelectWindow(InstructorPresentationPageResource.
                    InstructorPresentationPage_Test_WindowName);
                //Start Activity
                new InstructionsPage().ClickTestStartButton();
                //Wait For Element
                WaitForElement(By.Id(InstructorPresentationPageResource.
                                         InstructorPresentation_Page_Question_Frame_Id_Locator));
                //Is Element Present on Presentation Window
                isActivityFinishButtonPresent = base.IsElementPresent
                    (By.Id(InstructorPresentationPageResource.
                               InstructorPresentation_Page_ActivityFinish_Button_Id_Locator));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("InstructorPresentationPage", "IsPostTestActivityLaunched",
          base.IsTakeScreenShotDuringEntryExit);
            return isActivityFinishButtonPresent;
        }

        /// <summary>
        /// Close Activity Presentaion Window.
        /// </summary>
        public void CloseActivityPresentationWindow()
        {
            logger.LogMethodEntry("InstructorPresentationPage", "CloseActivityPresentationWindow",
           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                base.CloseBrowserWindow();
                Thread.Sleep(Convert.ToInt32(InstructorPresentationPageResource.
                    InstructorPresentation_Page_Sleep_Value));
                //Used SendKeys to Close modal pop up
                SendKeys.SendWait(StudentPresentationPageResource.
                    StudentPresentation_Page_EnterKey_Value);
                base.SelectDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("InstructorPresentationPage", "CloseActivityPresentationWindow",
         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Is PostTest Activity Launched In Content Page
        /// </summary>
        /// <returns>True if the element is found in the presentation 
        /// page otherwise false.</returns>
        public bool IsPostTestActivityLaunchedInContentPage()
        {
            //Is PostTest Activity Launched In Content Page
            logger.LogMethodEntry("InstructorPresentationPage", "IsPostTestActivityLaunchedInContentPage",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize Bool Variable
            bool isActivityCloseButtonPresent = false;
            try
            {
                // Wait and Select Window
                base.WaitUntilWindowLoads(InstructorPresentationPageResource.
                    InstructorPresentation_Page_StudyPlanTypeActivity_PostTest_Window_Title_Name);
                base.SelectWindow(InstructorPresentationPageResource.
                    InstructorPresentation_Page_StudyPlanTypeActivity_PostTest_Window_Title_Name);
                //Is Element Present on Presentation Window
                isActivityCloseButtonPresent = base.IsElementPresent
                    (By.Id(InstructionsPageResource
                    .Instructions_Page_ActivityClose_Button_Id_Locator));
                // Wait For Stop Button
                base.WaitForElement(By.Id(InstructionsPageResource
                    .Instructions_Page_ActivityClose_Button_Id_Locator));
                //Get Stop Button Properties
                IWebElement getActivityStartButtonProperties =
                    base.GetWebElementPropertiesById(InstructionsPageResource
                    .Instructions_Page_ActivityClose_Button_Id_Locator);
                //Click on Button
                base.ClickByJavaScriptExecutor(getActivityStartButtonProperties);               
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("InstructorPresentationPage", "IsPostTestActivityLaunchedInContentPage",
          base.IsTakeScreenShotDuringEntryExit);
            return isActivityCloseButtonPresent;
        }
    }
}
