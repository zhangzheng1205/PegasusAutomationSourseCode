using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Common;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the ShowMessage Page Actions
    /// </summary>
    public class ShowMessagePage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ShowMessagePage));

        /// <summary>
        /// Click Continue In Activity Alert
        /// </summary>
        public void ClickContinueInActivityAlert()
        {
            //Click Continue In Activity Alert
            logger.LogMethodEntry("ShowMessagePage", "ClickContinueInActivityAlert",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For The Popup
                base.WaitUntilWindowLoads(ShowMessagePageResource.ShowMessage_page_PageName);
                //Select The Activity Alert
                base.SelectWindow(ShowMessagePageResource.ShowMessage_page_PageName);
                //Wait For Continue Button
                base.WaitForElement(By.Id(ShowMessagePageResource.
                    ShowMessage_Page_Continue_Button_Id_Locator));
                IWebElement getContinueButton = base.GetWebElementPropertiesById
                    (ShowMessagePageResource.
                    ShowMessage_Page_Continue_Button_Id_Locator);
                //Click On Ok Button
                base.ClickByJavaScriptExecutor(getContinueButton);
                //Select Default Window
                base.SelectDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ShowMessagePage", "ClickContinueInActivityAlert",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click on the alert 'OK' button
        /// </summary>
        public void ClickTheAlertOkButton()
        {
            //Click on the alert 'OK' button
            logger.LogMethodEntry("ShowMessagePage",
                "ClickTheAlertOkButton", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.SelectWindow(ShowMessagePageResource.
                       ShowMessage_Page_AlertWindow_Title_Name);
                //Wait For Element
                base.WaitForElement(By.Id(ShowMessagePageResource.
                    ShowMessage_Page_OkButton_Id_Locator));
                //Get HTML Element Property
                IWebElement alertOkButton = base.GetWebElementPropertiesById
                    (ShowMessagePageResource.
                    ShowMessage_Page_OkButton_Id_Locator);
                //Click the alert 'OK' Button 
                base.ClickByJavaScriptExecutor(alertOkButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ShowMessagePage",
                "ClickTheAlertOkButton", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        ///Click on the Pegasus 'OK' button
        /// </summary>
        public void ClickOnPegasusOkButton()
        {
            //Click on the Pegasus 'OK' button
            logger.LogMethodEntry("ShowMessagePage",
                "ClickOnPegasusOkButton", base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Pegasus Window
                base.WaitUntilWindowLoads(ShowMessagePageResource.
                       ShowMessage_Page_Pegasus_Window_Title_Name);
                base.SelectWindow(ShowMessagePageResource.
                       ShowMessage_Page_Pegasus_Window_Title_Name);
                //Click On 'Ok' Button On Pegasus PopUp Window.
                this.ClickOnOkButtonOnPegasusPopUpWindow();
                //Wait for 2 Secs
                Thread.Sleep(Convert.ToInt32(ShowMessagePageResource.
                    ShowMessage_Page_Sleep_Time));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ShowMessagePage",
                "ClickOnPegasusOkButton", base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Handle the pop up window of Adding duplicate test questions into Test.
        /// </summary>
        public void HandleDuplicateTestQuestionsPopupWindow()
        {
            //logger Enrty
            logger.LogMethodEntry("ShowMessagePage",
                "HandleDuplicateTestQuestionsPopupWindow",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for popup window
                if (base.IsPopupPresent(ShowMessagePageResource.
                           ShowMessage_Page_Pegasus_Window_Title_Name,
                           Convert.ToInt32(ShowMessagePageResource.
                               ShowMessage_Page_Wait_Time_InSecond)))
                {
                    //Click On 'Ok' Button On Pegasus PopUp Window.
                    this.ClickOnOkButtonOnPegasusPopUpWindow();
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            logger.LogMethodExit("ShowMessagePage",
                "HandleDuplicateTestQuestionsPopupWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On 'Ok' Button On Pegasus PopUp Window.
        /// </summary>
        private void ClickOnOkButtonOnPegasusPopUpWindow()
        {
            //logger Enrty
            logger.LogMethodEntry("ShowMessagePage",
                "ClickOnOkButtonOnPegasusPopUpWindow",
                base.isTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(ShowMessagePageResource.
                ShowMessage_Page_OkButton_Id_Locator));
            //Get HTML Element Property
            IWebElement getPropertyOfPegasusOkButton = base.
                GetWebElementPropertiesById
                (ShowMessagePageResource.
                ShowMessage_Page_OkButton_Id_Locator);
            //Click the Pegasus 'OK' Button 
            base.ClickByJavaScriptExecutor(getPropertyOfPegasusOkButton);
            //Logger Exit
            logger.LogMethodExit("ShowMessagePage",
                "ClickOnOkButtonOnPegasusPopUpWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Validation message Text when user add
        /// random 500 Question to MyTest.
        /// </summary>
        /// <returns>Text of Validation message.</returns>
        public String GetTheValidationMessageOfAddingRandonQuestionToMyTest()
        {
            //Logger Entry
            logger.LogMethodEntry("ShowMessagePage",
               "GetTheValidationMessageOfAddingRandonQuestionToMyTest",
               base.isTakeScreenShotDuringEntryExit);
            //Initialize variable
            String getTextOfValidationMessage = string.Empty;
            try
            {
                //Validate the displaying of Pegasus popup
                //when user add 500 random question to MyTest
                if (base.IsPopupPresent(ShowMessagePageResource.
                    ShowMessage_Page_Pegasus_Window_Title_Name))
                {
                    //Wait for message span id 
                    base.WaitForElement(By.Id(ShowMessagePageResource.
                        ShowMessage_Page_Validation_MSG_Span_Id_Locator));
                    //Get The Text of validation message
                    getTextOfValidationMessage = base.GetElementTextByID(
                        ShowMessagePageResource.
                        ShowMessage_Page_Validation_MSG_Span_Id_Locator).
                        Replace(Environment.NewLine, string.Empty);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Logger Exit
            logger.LogMethodExit("ShowMessagePage",
              "GetTheValidationMessageOfAddingRandonQuestionToMyTest",
              base.isTakeScreenShotDuringEntryExit);
            //Return the text of validation message 
            return getTextOfValidationMessage;
        }

        /// <summary>
        /// Gets text on Ok button.
        /// </summary>
        /// <returns></returns>
        public string GetOkButtonText()
        {
            string buttonText = string.Empty;
            logger.LogMethodEntry("ShowMessagePage",
               "GetOkButtonText", 
               base.isTakeScreenShotDuringEntryExit);
            base.SelectWindow(ShowMessagePageResource.
                      ShowMessage_Page_AlertWindow_Title_Value);
            base.WaitForElement(By.Id(ShowMessagePageResource
                .ShowMessage_Page_OkButton_Id_Locator));
            buttonText = base.GetElementTextByID(ShowMessagePageResource
                .ShowMessage_Page_OkButton_Id_Locator);
            logger.LogMethodExit("ShowMessagePage",
               "GetOkButtonText", 
               base.isTakeScreenShotDuringEntryExit);
            return buttonText;
        }

        /// <summary>
        /// Gets text on Cancel button.
        /// </summary>
        /// <returns></returns>
        public string GetCancelButtonText()
        {
            string buttonText = string.Empty;
            logger.LogMethodEntry("ShowMessagePage",
               "GetOkButtonText",
               base.isTakeScreenShotDuringEntryExit);
            base.SelectWindow(ShowMessagePageResource.
                      ShowMessage_Page_AlertWindow_Title_Value);
            base.WaitForElement(By.Id(ShowMessagePageResource
                .ShowMessage_Page_CancelButton_Id_Locator));
            buttonText = base.GetElementTextByID(ShowMessagePageResource
                .ShowMessage_Page_CancelButton_Id_Locator);
            logger.LogMethodExit("ShowMessagePage",
               "GetOkButtonText",
               base.isTakeScreenShotDuringEntryExit);
            return buttonText;
        }

        /// <summary>
        /// Clicks Ok button.
        /// </summary>
        public void ClickOkButton()
        {
            logger.LogMethodEntry("ShowMessagePage",
              "ClickOkButton",
              base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ShowMessagePageResource.
                   ShowMessage_Page_OkButton_Id_Locator));
            IWebElement alertOkButton = base.GetWebElementPropertiesById
                (ShowMessagePageResource.
                ShowMessage_Page_OkButton_Id_Locator);
            base.ClickByJavaScriptExecutor(alertOkButton);
            logger.LogMethodExit("ShowMessagePage",
              "ClickOkButton",
              base.isTakeScreenShotDuringEntryExit);

        }
        
    }
}
