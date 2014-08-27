using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Discussion;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class contains details of Discussion page
    /// </summary>
    public class DiscussionMainUxPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(DiscussionMainUxPage));

        /// <summary>
        /// Click on cmenu icon of the response posted.
        /// </summary>
        /// <param name="postName">Post name for which cmenu icon should be clicked.</param>
        public void ClickOnCmenuOfResponse(string postName)
        {
            //Click On Cmenu Option of the repsonse posted
            logger.LogMethodEntry("DiscussionMainUXPage", "ClickOnOpenCmenuOfResponse",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            try
            {
                //Switch to Post response frame
                base.SwitchToIFrame(DiscussionMainUXPageResource.DiscussionMainUXPageResource_PostResponse_Iframe_Name);
                //Get the name of the respone posted 
                string responsePosted = base.GetElementTextByXPath(string.Format(DiscussionMainUXPageResource.
                    DiscussionMainUXPageResource_ResponseName_Xpath));
                //Split the name fetched
                string[] splitResponse = responsePosted.Split(new string[] { "..." }, StringSplitOptions.None);
                string getResponseName = splitResponse[0].Trim();
                //Check if the actual and expected response posted are same
                if (postName.Contains(getResponseName))
                {
                    //Click on the cmenu icon of the response posted
                    IWebElement getCmenuProperties = base.GetWebElementPropertiesByXPath(DiscussionMainUXPageResource.
                        DiscussionMainUXPageResource_ResponseCmenu_Xpath_Locator);
                    base.ClickByJavaScriptExecutor(getCmenuProperties);
                }

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //base.SwitchToDefaultPageContent();
            logger.LogMethodExit("DiscussionMainUXPage", "ClickOnOpenCmenuOfResponse",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Discussion frame title.
        /// </summary>
        /// <returns>Discussion frame title.</returns>
        public string GetDiscussionFrameTitle()
        {
            //Get discussion frame title
            logger.LogMethodEntry("DiscussionMainUXPage", "GetDiscussionFrameTitle",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize variable
            string discussionFrameTitle = string.Empty;
            try
            {
                //Select the discussion page window
                base.SelectWindow(base.GetPageTitle);
                base.WaitForElement(By.Id(DiscussionMainUXPageResource.
                      DiscussionMainUXPageResource_DiscussionFrame_Title_ID));
                //Get the discussion frame title, trim if there are any spaces and store it in variable
                discussionFrameTitle = base.GetElementInnerTextById(DiscussionMainUXPageResource.
                      DiscussionMainUXPageResource_DiscussionFrame_Title_ID).Trim();
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DiscussionMainUXPage", "GetDiscussionFrameTitle",
              base.IsTakeScreenShotDuringEntryExit);
            //Return the discussion frame title
            return discussionFrameTitle;
        }

        /// <summary>
        /// Select cmenu option of the discussion topic
        /// response.
        /// </summary>
        /// <param name="cmenuOption">Cmenu option to be selected.</param>
        public void SelectCmenuOption(string cmenuOption)
        {
            //Select cmenu option of the response 
            logger.LogMethodEntry("DiscussionMainUXPage", "SelectCmenuOption",
            base.IsTakeScreenShotDuringEntryExit);
            //Initialize the variable
            int cmenuOptionsCount = 0;
            try
            {
                //Get the cmenu option count
                cmenuOptionsCount = base.GetElementCountByXPath(DiscussionMainUXPageResource.
                    DiscussionMainUXPageResource_CmenuCount_Xpath_Locator);
                //Start the counter to loop through the cmenu options
                for (int i = 1; i <= cmenuOptionsCount; i++)
                {
                    //Store the cmenu option text in the variable
                    string cmenuOptionName = base.GetElementTextByXPath(string.Format(
                        DiscussionMainUXPageResource.DiscussionMainUXPageResource_ResponseCmenu_Options_Xpath_Locator, i));
                    //Validate the actual and expected cmenu option
                    if (cmenuOptionName == cmenuOption)
                    {
                        //Get the cmenu option property
                        IWebElement cmenuAccess = base.GetWebElementPropertiesByXPath(string.Format(
                           DiscussionMainUXPageResource.DiscussionMainUXPageResource_ResponseCmenu_Options_Xpath_Locator, i));
                        //Click on the cmenu option
                        base.ClickByJavaScriptExecutor(cmenuAccess);
                        //Clear the iframes selected
                        base.SwitchToDefaultPageContent();
                        break;
                    }
                }
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            logger.LogMethodExit("DiscussionMainUXPage", "SelectCmenuOption",
             base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Switch to read response pop up.
        /// </summary>
        public void SwitchToPopUp()
        {
            //Switch to read response pop up
            logger.LogMethodEntry("DiscussionMainUXPage", "SwitchToPopUp",
             base.IsTakeScreenShotDuringEntryExit);

            try
            {
                //Switch to the read response pop up
                base.SwitchToLastOpenedWindow();
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DiscussionMainUXPage", "SwitchToPopUp",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Cancel button in Discussion page.
        /// </summary>
        public void ClickOnCancelButton()
        {
            //Click on cancel button in read response pop up
            logger.LogMethodEntry("DiscussionMainUXPage", "ClickOnCancelButton",
             base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the properties of cancel button
                IWebElement cancelButtonProperties = base.GetWebElementPropertiesById(
                    DiscussionMainUXPageResource.DiscussionMainUXPageResource_Cancel_Button_Id_Locator);
                //Click on cancel button
                base.ClickByJavaScriptExecutor(cancelButtonProperties);

            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DiscussionMainUXPage", "ClickOnCancelButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Close button in read response pop up.
        /// </summary>
        public void ClickOnCloseButtonInReadResponsePopUp()
        {
            //Click on close button in read response pop up
            logger.LogMethodEntry("DiscussionMainUXPage", "ClickOnCloseButtonInReadResponsePopUp",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the close button properties
                IWebElement closeButton = base.GetWebElementPropertiesById(DiscussionMainUXPageResource.
                    DiscussionMainUXPageResource_Close_Button_Id_Locator);
                //Click on close button
                base.ClickByJavaScriptExecutor(closeButton);
            }

            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("DiscussionMainUXPage", "ClickOnCloseButtonInReadResponsePopUp",
                base.IsTakeScreenShotDuringEntryExit);
            //Switch to parent window
            base.SwitchToDefaultWindow();

        }

    }
}
