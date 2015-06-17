using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.MyPegasus;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus MyPegasus UX Page Actions
    /// </summary>
    public class WelcomeMessagesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger = Logger.GetInstance(typeof(WelcomeMessagesPage));

        /// <summary>
        /// To Check If Welcome Message Displyed
        /// </summary>
        /// <returns>Welcome Message Display Result</returns>
        public Boolean IsWelcomeMessageDisplayed()
        {
            // To Check If Welcome Message Displyed
            logger.LogMethodEntry("WelcomeMessagesPage", "IsWelcomeMessageDisplayed",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            Boolean isWelcomeMessageDisplayed = false;
            try
            {
                //Wait For The Welcome Message Iframe
                base.WaitForElement(By.Id(WelcomeMessagesPageResource.
                    WelcomeMessages_Page_WelcomeMessageIframe_Id_Locator));
                // Initializing Webelement for Welcome Message Iframe
                IWebElement welcomeMessageIframe = base.GetWebElementPropertiesById
                    (WelcomeMessagesPageResource.
                    WelcomeMessages_Page_WelcomeMessageIframe_Id_Locator);
                //Switch To The Welcome Message Iframe
                base.SwitchToIFrameByWebElement(welcomeMessageIframe);
                //Check If The Welcome Message is Present
                isWelcomeMessageDisplayed = base.IsElementPresent(By.Id
                    (WelcomeMessagesPageResource.
                    WelcomeMessages_Page_WelcomeMessage_Id_Locator),
                    Convert.ToInt32(WelcomeMessagesPageResource.
                    WelcomeMessages_Page_TimeToWait_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("WelcomeMessagesPage", "IsWelcomeMessageDisplayed",
                base.IsTakeScreenShotDuringEntryExit);
            //Return Is Welcome Message
            return isWelcomeMessageDisplayed;
        }

        /// <summary>
        /// Close Welcome Message Popup
        /// </summary>
        public void CloseWelcomeMessageLightBox()
        {
            // Close Welcome Message Popup
            logger.LogMethodEntry("WelcomeMessagesPage", "CloseWelcomeMessageLightBox",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait For The "Do not show this again" CheckBox
                if (base.IsElementPresent(
                    By.Id(WelcomeMessagesPageResource.
                    WelcomeMessages_Page_DontShowThisMessage_CheckBox_Id_Locator)
                    , Convert.ToInt32(WelcomeMessagesPageResource
                    .WelcomeMessages_Page_TimeToWait_Value)))
                {
                    //Wait For Element
                    base.WaitForElement(By.Id(WelcomeMessagesPageResource.
                        WelcomeMessages_Page_DontShowThisMessage_CheckBox_Id_Locator));
                    //Get Checkbox Element Property
                    IWebElement getCheckBoxProperty = base.GetWebElementPropertiesById(
                        WelcomeMessagesPageResource.
                        WelcomeMessages_Page_DontShowThisMessage_CheckBox_Id_Locator);
                    //Click On The "Do not show this again" CheckBox
                    base.ClickByJavaScriptExecutor(getCheckBoxProperty);
                    //Wait For Enter Button
                    base.WaitForElement(By.Id(WelcomeMessagesPageResource.
                        WelcomeMessages_Page_CloseWelcomeMessagePopupButton_Id_Locator));
                    //Get Enter Button Element Property                 
                    IWebElement getEnterButtonProperty = base.GetWebElementPropertiesById(WelcomeMessagesPageResource.
                        WelcomeMessages_Page_CloseWelcomeMessagePopupButton_Id_Locator);
                    //Click On Enter Button
                    base.ClickByJavaScriptExecutor(getEnterButtonProperty);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("WelcomeMessagesPage", "CloseWelcomeMessageLightBox",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close Welcome Message Popup
        /// </summary>
        public void AideCloseWelcomeMessageLightBox()
        {
            // Close Welcome Message Popup
            logger.LogMethodEntry("WelcomeMessagesPage", "AideCloseWelcomeMessageLightBox",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait For The "Do not show this again" CheckBox
                if (base.IsElementPresent(
                    By.Id(WelcomeMessagesPageResource.
                    WelcomeMessages_Page_Aide_DontShowThisMessage_CheckBox_Id_Locator)
                    , Convert.ToInt32(WelcomeMessagesPageResource
                    .WelcomeMessages_Page_TimeToWait_Value)))
                {
                    //Wait For Element
                    base.WaitForElement(By.Id(WelcomeMessagesPageResource.
                        WelcomeMessages_Page_Aide_DontShowThisMessage_CheckBox_Id_Locator));
                    //Get Checkbox Element Property
                    IWebElement getCheckBoxProperty = base.GetWebElementPropertiesById(
                        WelcomeMessagesPageResource.
                        WelcomeMessages_Page_Aide_DontShowThisMessage_CheckBox_Id_Locator);
                    //Click On The "Do not show this again" CheckBox
                    base.ClickByJavaScriptExecutor(getCheckBoxProperty);
                    //Wait For Enter Button
                    base.WaitForElement(By.Id(WelcomeMessagesPageResource.
                        WelcomeMessages_Page_CloseWelcomeMessagePopupButton_Id_Locator));
                    //Get Enter Button Element Property                 
                    IWebElement getEnterButtonProperty = base.GetWebElementPropertiesById(WelcomeMessagesPageResource.
                        WelcomeMessages_Page_CloseWelcomeMessagePopupButton_Id_Locator);
                    //Click On Enter Button
                    base.ClickByJavaScriptExecutor(getEnterButtonProperty);
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("WelcomeMessagesPage", "CloseWelcomeMessageLightBox",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check If The Welcome Message LightBox is Present
        /// </summary>
        /// <returns>Welcome Message Light Box Present Result</returns>
        public Boolean IsWelcomeMessageLightBoxPresent()
        {
            //To Check If The Welcome Message LightBox is Present
            logger.LogMethodEntry("WelcomeMessagesPage", "IsWelcomeMessageLightBoxPresent",
               base.IsTakeScreenShotDuringEntryExit);
            //Initializing variable
            Boolean isWelcomeMessageLightBoxPresent = false;
            try
            {
                Thread.Sleep(Convert.ToInt32(WelcomeMessagesPageResource.
                       WelcomeMessages_Page_ThreadSleepTime_Value));
                //Check If The LightBox Is Present
                isWelcomeMessageLightBoxPresent = base.IsElementPresent
                    (By.Id(WelcomeMessagesPageResource.
                    WelcomeMessages_Page_DontShowThisMessage_CheckBox_Id_Locator),
                    Convert.ToInt32(WelcomeMessagesPageResource.
                    WelcomeMessages_Page_TimeToWait_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("WelcomeMessagesPage", "IsWelcomeMessageLightBoxPresent",
               base.IsTakeScreenShotDuringEntryExit);
            //Return Welcome Message LightBox
            return isWelcomeMessageLightBoxPresent;
        }
    }
}
