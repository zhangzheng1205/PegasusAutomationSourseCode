using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.Threading;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.PegasusTest;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles areation of MyTest activity page actions.
    /// </summary>
    public class AssessmentNamePage : BasePage
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(AssessmentNamePage));

        /// <summary>
        ///Create MyTest Activity.
        /// </summary>
        public void CreateMyTestActivity()
        {
            //Create MyTest Activity
            Logger.LogMethodEntry("AssessmentNamePage", "CreateMyTestActivity",
                 base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generate Guid for Activity  Name
                Guid activityNameGuid = Guid.NewGuid();
                //Select Window
                this.SelectCreateNewTestWindow();
                //Wait for the element
                base.WaitForElement(By.Id(AssessmentNamePageResource.
                    AssessmentName_Page_CreateNewTest_Name_Textbox_Id_Locator));
                base.FillTextBoxById(AssessmentNamePageResource.
                     AssessmentName_Page_CreateNewTest_Name_Textbox_Id_Locator,
                     activityNameGuid.ToString());
                //Wait for the "Save" button
                base.WaitForElement(By.Id(AssessmentNamePageResource.
                    AssessmentName_Page_CreateNewTest_SaveButton_Id_Locator));
                base.FocusOnElementById(AssessmentNamePageResource.
                     AssessmentName_Page_CreateNewTest_SaveButton_Id_Locator);
                //Get web element
                IWebElement getSaveButtonProperties = base.GetWebElementPropertiesById
                    (AssessmentNamePageResource.
                     AssessmentName_Page_CreateNewTest_SaveButton_Id_Locator);
                //Click on the "Save" Button
                base.ClickByJavaScriptExecutor(getSaveButtonProperties);
                //Wait for window to Close
                base.IsPopUpClosed(Convert.ToInt32(AssessmentNamePageResource.
                    AssessmentName_Page_Window_Count));
                //Store Activity In Memory
                this.StoreActivityInMemory(activityNameGuid.ToString());
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("AssessmentNamePage", "CreateMyTestActivity",
                 base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create New Test Window.
        /// </summary>
        private void SelectCreateNewTestWindow()
        {
            //This is logger entry
            Logger.LogMethodEntry("AssessmentNamePage", "SelectCreateNewTestWindow",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Pop Up Window
            base.WaitUntilWindowLoads(AssessmentNamePageResource.
                AssessmentName_Page_CreateNewTest_Window_Name);
            //Select Window
            base.SelectWindow(AssessmentNamePageResource.
                AssessmentName_Page_CreateNewTest_Window_Name);
            //This is logger exit
            Logger.LogMethodExit("AssessmentNamePage", "SelectCreateNewTestWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Activity In Memory.
        /// </summary>
        /// <param name="activityName">This is activity name.</param>
        private void StoreActivityInMemory(String activityName)
        {
            // Store the Activity
            Logger.LogMethodEntry("TrueFalsePage", "StoreActivityInMemory",
                   base.IsTakeScreenShotDuringEntryExit);
            //Store the TrueFalse Question
            Activity activity = new Activity
            {
                Name = activityName,
                ActivityType = Activity.ActivityTypeEnum.MyTest,
                IsCreated = true,
            };
            activity.StoreActivityInMemory();
            Logger.LogMethodExit("TrueFalsePage", "StoreActivityInMemory",
                 base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
