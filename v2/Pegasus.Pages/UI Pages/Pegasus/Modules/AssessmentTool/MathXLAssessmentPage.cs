using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.AssessmentTool;
using System.Diagnostics;
using System.Configuration;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class Handles MathXLAssessmentPage Actions
    /// </summary>
    public class MathXLAssessmentPage : BasePage
    {
        /// <summary>
        ///  Static instance of the logger
        /// </summary>
        private static readonly Logger logger = Logger.
            GetInstance(typeof(MathXLAssessmentPage));

        //Get the WaitTime
        int getWaitTimeinSeconds = Int32.Parse(ConfigurationManager.
                AppSettings[MathXLAssessmentPageResource.MathXLAssessment_Page_ElementFindTimeOutInSeconds]);

        /// <summary>
        /// Customize the Content
        /// </summary>
        /// <param name="activityTypeEnum"> This is activity type enum.</param>
        public void CustomizeTheContentInCurriculumTab(Activity.
            ActivityTypeEnum activityTypeEnum)
        {
            //Customize the Content
            logger.LogMethodEntry("MathXLAssessmentPage", "CustomizeTheContentInCurriculumTab",
                base.IsTakeScreenShotDuringEntryExit);           
            try
            {                
                //Generate GUID for customize Activity Name
                Guid customizeActivityName = Guid.NewGuid();
                //Select Window and Switch To Frame
                this.SelectWindowAndSwitchToFrame();
                //Wait for element 
                base.WaitForElement(By.Id(MathXLAssessmentPageResource.
                MathXLAssessment_Page_ActivityName_TextBox_Id_Locator));
                //Clear TextBox
                base.ClearTextById(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_ActivityName_TextBox_Id_Locator);
                //Fill TextBox
                base.FillTextBoxById(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_ActivityName_TextBox_Id_Locator,
                  customizeActivityName.ToString());
                //Wait for the Copy Message to Disappear
                this.WaitForTheCopyMessageToDisappear();                
                base.WaitForElement(By.Id(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_SaveAndReturn_Button_Id_Locator));
                //Get Button Property     
                IWebElement getSaveandReturnButton = base.GetWebElementPropertiesById
                    (MathXLAssessmentPageResource.
                    MathXLAssessment_Page_SaveAndReturn_Button_Id_Locator);
                //Click on Save and Return Button
                base.ClickByJavaScriptExecutor(getSaveandReturnButton);
                //Update Activity Name In Memory
                this.UpdateActivityNameInMemory(customizeActivityName, activityTypeEnum);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("MathXLAssessmentPage", "CustomizeTheContentInCurriculumTab", 
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Wait For The Copy Message To Disappear.
        /// </summary>
        private void WaitForTheCopyMessageToDisappear()
        {
            //Wait For The Copy Message To Disappear.
            logger.LogMethodEntry("MathXLAssessmentPage", "WaitForTheCopyMessageToDisappear",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize the Stop Watch
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Check if the Copy Message is Present
            while (base.IsElementPresent(By.Id(MathXLAssessmentPageResource.
                MathXLAssessment_Page_Asset_Copy_Message_Id_Locator),
                Convert.ToInt16(MathXLAssessmentPageResource.
                MathXLAssessment_Page_Customized_Time)) && stopWatch.Elapsed.TotalSeconds
                < getWaitTimeinSeconds)
            {
                //Wait for 3 Secs
                Thread.Sleep(Convert.ToInt32(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_Sleep_Time));
            }
            logger.LogMethodExit("MathXLAssessmentPage", "WaitForTheCopyMessageToDisappear",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Customize Skill study Plan in Curriculam Tab.
        /// </summary>
        /// <param name="activityTypeEnum">This is activity type enum.</param>
        public void CustomizeTheSkillStudyPlanInCurriculumTab(Activity.
            ActivityTypeEnum activityTypeEnum)
        {
            //Customize the Content
            logger.LogMethodEntry("MathXLAssessmentPage", 
                "CustomizeTheSkillStudyPlanInCurriculumTab",
                base.IsTakeScreenShotDuringEntryExit); 
             try
            {                
                //Generate GUID for customize Activity Name
                Guid customizeActivityName = Guid.NewGuid();
                //Select Window and Switch To Frame
                this.SelectWindowAndSwitchToFrame();
                //Wait for element 
                base.WaitForElement(By.Id(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_StudyPlanName_TextBox_Id_Locator));
                //Clear TextBox
                base.ClearTextById(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_StudyPlanName_TextBox_Id_Locator);
                //Fill TextBox
                base.FillTextBoxById(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_StudyPlanName_TextBox_Id_Locator,
                  customizeActivityName.ToString());
                //Wait for page
                Thread.Sleep(Convert.ToInt32(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_Sleep_Time));
                base.WaitForElement(By.Id(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_StudyPlanName_SaveButton_ID_Locator));
                //Get Button Property     
                IWebElement getSaveandReturnButton = base.GetWebElementPropertiesById
                    (MathXLAssessmentPageResource.
                    MathXLAssessment_Page_StudyPlanName_SaveButton_ID_Locator);
                //Click on Save and Return Button
                base.ClickByJavaScriptExecutor(getSaveandReturnButton);
                //Update Activity Name In Memory
                this.UpdateActivityNameInMemory(customizeActivityName, activityTypeEnum);
             }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("MathXLAssessmentPage", "CustomizeTheSkillStudyPlanInCurriculumTab", 
                base.IsTakeScreenShotDuringEntryExit);
        }
        /// <summary>
        /// Update Activity Name In Memory
        /// </summary>
        /// <param name="customizeActivityName">Customized Activity Name</param>
        /// <param name="activityTypeEnum"></param>
        private void UpdateActivityNameInMemory(Guid customizeActivityName,
            Activity.ActivityTypeEnum activityTypeEnum)
        {
            //Update Activity Name In Memory
            logger.LogMethodEntry("MathXLAssessmentPage", "UpdateActivityNameInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            Activity activity;

            switch (activityTypeEnum)
            {
                case Activity.ActivityTypeEnum.Test:
                    //Update Customized Activity Name
                    activity = Activity.Get(CommonResource.CommonResource.
                        DigitalPath_Activity_TestData_UC1);
                    activity.Name = customizeActivityName.ToString();
                    activity.UpdateActivityInMemory(activity);
                    break;
                case Activity.ActivityTypeEnum.SkillStudyPlan:
                    //Update Customized Activity Name
                    activity = Activity.Get(CommonResource.CommonResource.
                        DigitalPath_Activity_SkillStudyPlan_UC1);
                    activity.Name = customizeActivityName.ToString();
                    activity.UpdateActivityInMemory(activity);
                    break;
            }
            logger.LogMethodExit("MathXLAssessmentPage", "UpdateActivityNameInMemory",
                base.IsTakeScreenShotDuringEntryExit); 
        }

        /// <summary>
        /// Select Window and Switch To Frame
        /// </summary>
        private void SelectWindowAndSwitchToFrame()
        {
            //Select Window and Switch To Frame
            logger.LogMethodEntry("MathXLAssessmentPage", "SelectWindowAndSwitchToFrame",
                base.IsTakeScreenShotDuringEntryExit);       
            base.WaitUntilWindowLoads(MathXLAssessmentPageResource.
                MathXLAssessment_Page_Window_TitleName);
            //Select Window
            base.SelectWindow(MathXLAssessmentPageResource.
                MathXLAssessment_Page_Window_TitleName);
            base.WaitForElement(By.Id(MathXLAssessmentPageResource.
           MathXLAssessment_Page_Frame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(MathXLAssessmentPageResource.
                MathXLAssessment_Page_Frame_Id_Locator);
           
            logger.LogMethodExit("MathXLAssessmentPage", "SelectWindowAndSwitchToFrame",
                base.IsTakeScreenShotDuringEntryExit);  
        }

        /// <summary>
        /// Customize the Single Content
        /// </summary>
        public void CustomizeTheSingleContent()
        {
            // Customize the Single Content
            logger.LogMethodEntry("MathXLAssessmentPage", "CustomizeTheSingleContent",
                       base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generates GUID
                Guid assetName = Guid.NewGuid();
                base.WaitUntilWindowLoads(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_EditWindow_Title);
                //Select window
                base.SelectWindow(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_EditWindow_Title);
                //Wait for the Element
                base.WaitForElement(By.Id(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_Edit_Textbox_Id_Locator));
                base.GetWebElementPropertiesById(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_Edit_Textbox_Id_Locator).Clear();
                //Fill the Activity name in text box
                base.GetWebElementPropertiesById(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_Edit_Textbox_Id_Locator).SendKeys(assetName.ToString());
                //Click on save button
                base.WaitForElement(By.PartialLinkText(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_SaveButton_PartialLinkText_Locator));
                IWebElement getSaveButton = GetWebElementPropertiesByPartialLinkText(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_SaveButton_PartialLinkText_Locator);
                base.ClickByJavaScriptExecutor(getSaveButton);
                //Select window
                base.SelectWindow(MathXLAssessmentPageResource.
                    MathXLAssessment_Page_Content_WindowName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("MathXLAssessmentPage", "CustomizeTheSingleContent",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
