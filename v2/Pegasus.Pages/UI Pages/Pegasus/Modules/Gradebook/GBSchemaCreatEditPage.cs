using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Gradebook;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class handles the GBSchemaCreateEdit Page Actions
    /// </summary>
    public class GBSchemaCreatEditPage : BasePage
    {
        /// <summary>
        /// The Static Instance of the Logger for the Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(GBSchemaCreatEditPage));

        /// <summary>
        /// Edit and Update Schema
        /// </summary>
        public void EditAndUpdateSchema()
        {
            //Edit and Update Schema
            logger.LogMethodEntry("GBSchemaCreatEditPage", "EditAndUpdateSchema",
             base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Update Schema Window
                this.SelectUpdateSchemaWindow();
                //Click On Add Grade Option
                this.ClickOnAddGradeOption();
                //Update To Score Value
                this.UpdateScoreToValueofGradeB();
                //Enter Grade Value
                this.EnterGradeValueG();
                //Enter Score From Value
                this.EnterScoreFromValueForGradeG();
                //Enter Score To Value
                this.EnterScoreToValueForGradeG();
                //Enter FeedBack
                this.EnterFeedbackForGradeG();
                //Click On Save and Close Button
                this.ClickOnSaveAndCloseButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("GBSchemaCreatEditPage", "EditAndUpdateSchema",
             base.isTakeScreenShotDuringEntryExit);
        }        

        /// <summary>
        /// Enter Feedback For Grade ValueG.
        /// </summary>
        private void EnterFeedbackForGradeValueG()
        {
            //Enter Feedback For Grade ValueG
            logger.LogMethodEntry("GBSchemaCreatEditPage", "EnterFeedbackForGradeValueG",
             base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_FeedbackValue_Xpath_Locator));
            base.ClearTextByXPath(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_FeedbackValue_Xpath_Locator);
            //Enter Feedback for Grade G
            base.FillTextBoxByXPath(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_FeedbackValue_Xpath_Locator,
                GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeG_Feedback_Value);
            logger.LogMethodExit("GBSchemaCreatEditPage", "EnterFeedbackForGradeValueG",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Grade Schema ValueG.
        /// </summary>
        private void EnterGradeSchemaValueG()
        {
            //Edit and Update Schema
            logger.LogMethodEntry("GBSchemaCreatEditPage", "EditAndUpdateSchema",
             base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeValue_Id_Locator));
            base.ClearTextById(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeValue_Id_Locator);
            //Enter Grade Value G
            base.FillTextBoxById(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeValue_Id_Locator, 
                GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_Grade_Value);
            logger.LogMethodExit("GBSchemaCreatEditPage", "EditAndUpdateSchema",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Update Schema Window
        /// </summary>
        private void SelectUpdateSchemaWindow()
        {
            //Select Update Schema Window
            logger.LogMethodEntry("GBSchemaCreatEditPage", "SelectUpdateSchemaWindow",
             base.isTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(GBSchemaCreatEditPageResource.
                GBSchemaCreatEdit_Page_UpdateSchema_Window_Name);
            //Select Update Schema Window
            base.SelectWindow(GBSchemaCreatEditPageResource.
                GBSchemaCreatEdit_Page_UpdateSchema_Window_Name);
            logger.LogMethodExit("GBSchemaCreatEditPage", "SelectUpdateSchemaWindow",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Grade Option
        /// </summary>
        private void ClickOnAddGradeOption()
        {
            //Click On Add Grade Option
            logger.LogMethodEntry("GBSchemaCreatEditPage", "ClickOnAddGradeOption",
             base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_AddGrade_Button_Id_Locator));
            //Get Add Grade Button Property
            IWebElement getAddGradeButtonProperty = base.GetWebElementPropertiesById(
                GBSchemaCreatEditPageResource.GBSchemaCreateEdit_Page_AddGrade_Button_Id_Locator);
            //Click On Add Grade Button
            base.ClickByJavaScriptExecutor(getAddGradeButtonProperty);
            logger.LogMethodExit("GBSchemaCreatEditPage", "ClickOnAddGradeOption",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Update To Score Value for Grade B
        /// </summary>
        private void UpdateScoreToValueofGradeB()
        {
            //Update To Score Value for Grade B
            logger.LogMethodEntry("GBSchemaCreatEditPage", "UpdateScoreToValueofGradeB",
             base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeB_ToScore_Id_Locator));
            base.ClearTextById(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeB_ToScore_Id_Locator);
            //Enter Grade B To Score Value
            base.FillTextBoxById(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeB_ToScore_Id_Locator,
                GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeB_ToScore_Value);
            logger.LogMethodExit("GBSchemaCreatEditPage", "UpdateScoreToValueofGradeB",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Grade Value G
        /// </summary>
        private void EnterGradeValueG()
        {
            //Enter Grade Value G
            logger.LogMethodEntry("GBSchemaCreatEditPage", "EnterGradeValueG",
             base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_Grade_Id_Locator));
            base.ClearTextById(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_Grade_Id_Locator);
            //Enter Grade Value G
            base.FillTextBoxById(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_Grade_Id_Locator, GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_Grade_Value);
            logger.LogMethodExit("GBSchemaCreatEditPage", "EnterGradeValueG",
             base.isTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enter Score From Value For Grade G
        /// </summary>
        private void EnterScoreFromValueForGradeG()
        {
            //Enter Score From Value For Grade G
            logger.LogMethodEntry("GBSchemaCreatEditPage", "EnterScoreFromValueForGradeG",
             base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeG_FromScore_Id_Locator));
            base.ClearTextById(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeG_FromScore_Id_Locator);
            //Enter From value for Grade G
            base.FillTextBoxById(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeG_FromScore_Id_Locator,
                GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeG_FromScore_Value);
            logger.LogMethodExit("GBSchemaCreatEditPage", "EnterScoreFromValueForGradeG",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Score To Value For Grade G
        /// </summary>
        private void EnterScoreToValueForGradeG()
        {
            logger.LogMethodEntry("GBSchemaCreatEditPage", "EnterScoreToValueForGradeG",
             base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GrabeG_ToScore_Id_Locator));
            base.ClearTextById(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GrabeG_ToScore_Id_Locator);
            //Enter To Score Value for Grade G
            base.FillTextBoxById(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GrabeG_ToScore_Id_Locator,
                GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeG_ToScore_Value);
            logger.LogMethodExit("GBSchemaCreatEditPage", "EnterScoreToValueForGradeG",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter FeedBack for Grade G
        /// </summary>
        private void EnterFeedbackForGradeG()
        {
            //Enter Feedback for Grade G
            logger.LogMethodEntry("GBSchemaCreatEditPage", "EnterFeedbackForGradeG",
             base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.Id(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeG_Feedback_Id_Locator));
            base.ClearTextById(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeG_Feedback_Id_Locator);
            //Enter Feedback for Grade G
            base.FillTextBoxById(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeG_Feedback_Id_Locator,
                GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Input_GradeG_Feedback_Value);
            logger.LogMethodExit("GBSchemaCreatEditPage", "EnterFeedbackForGradeG",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Save and Close Button
        /// </summary>
        private void ClickOnSaveAndCloseButton()
        {
            //Click On Save and Close Button
            logger.LogMethodEntry("GBSchemaCreatEditPage", "ClickOnSaveAndCloseButton",
             base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Button_SaveAndClose_Id_Locator));
            //Get Save and Close Button Property
            IWebElement getSaveAndCloseButton =
                base.GetWebElementPropertiesById(GBSchemaCreatEditPageResource.
                GBSchemaCreateEdit_Page_Button_SaveAndClose_Id_Locator);
            //Click On Save and Close Button
            base.ClickByJavaScriptExecutor(getSaveAndCloseButton);
            logger.LogMethodExit("GBSchemaCreatEditPage", "ClickOnSaveAndCloseButton",
             base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Edit And Update The ApplyGradeSchema.
        /// </summary>
        public void EditAndUpdateTheApplyGradeSchema()
        {
            //Edit and Update Schema
            logger.LogMethodEntry("GBSchemaCreatEditPage",
                "EditAndUpdateTheApplyGradeSchema",
             base.isTakeScreenShotDuringEntryExit);
            //Select Update Schema Window
            this.SelectUpdateSchemaWindow();
            //Click On Add Grade Option
            this.ClickOnAddGradeOption();
            //Update To Score Value
            this.UpdateScoreToValueofGradeB();
            //Enter Grade Schema ValueG
            this.EnterGradeSchemaValueG();
            //Enter Score From Value
            this.EnterScoreFromValueForGradeG();
            //Enter Score To Value
            this.EnterScoreToValueForGradeG();
            //Enter FeedBack
            this.EnterFeedbackForGradeValueG();
            //Click On Save and Close Button
            this.ClickOnSaveAndCloseButton();
            logger.LogMethodExit("GBSchemaCreatEditPage",
                "EditAndUpdateTheApplyGradeSchema",
             base.isTakeScreenShotDuringEntryExit);
        }
    }
}
