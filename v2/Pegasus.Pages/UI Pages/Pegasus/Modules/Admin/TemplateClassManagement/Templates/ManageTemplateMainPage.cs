using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Templates;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles to manage the Template page actions
    /// </summary>
    public class ManageTemplateMainPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ManageTemplateMainPage));

        /// <summary>
        /// Click Add Button To Create Template.
        /// </summary>
        public void ClickTemplateCreateLink()
        {
            //Click Template Create Button
            logger.LogMethodEntry("ManageTemplateMainPage", "ClickTemplateCreateLink",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window To Loads
                base.WaitUntilWindowLoads(ManageTemplateMainPageResource.
                ManageTemplateMain_Page_Window_Title_Name);
                //Select Window
                base.SelectWindow(ManageTemplateMainPageResource.
                    ManageTemplateMain_Page_Window_Title_Name);
                //Wait For Element
                base.WaitForElement(By.Id(ManageTemplateMainPageResource.
                    ManageTemplateMain_Page_TemplateFrame_Id_Locator));
                //Switch To Window
                base.SwitchToIFrame(ManageTemplateMainPageResource.
                    ManageTemplateMain_Page_TemplateFrame_Id_Locator);
                //Wait For Element
                base.WaitForElement(By.XPath(ManageTemplateMainPageResource.
                    ManageTemplateMain_Page_Add_Button_XPath_Locator));
                //Get HTML Element Property
                IWebElement getAddButton = base.GetWebElementPropertiesByXPath(ManageTemplateMainPageResource.
                                                                         ManageTemplateMain_Page_Add_Button_XPath_Locator);
                //Click on button
                base.ClickByJavaScriptExecutor(getAddButton);
                //Wait For Element
                base.WaitForElement(By.Id(ManageTemplateMainPageResource.
                    ManageTemplateMain_Page_TemplateLink_Id_Locator));
                //Get Element Property
                IWebElement getTemplateLink = base.GetWebElementPropertiesById(ManageTemplateMainPageResource.
                    ManageTemplateMain_Page_TemplateLink_Id_Locator);
                //Click on button
                base.ClickByJavaScriptExecutor(getTemplateLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageTemplateMainPage", "ClickTemplateCreateLink",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Template.
        /// </summary>
        /// <param name="templateName">This is template name.</param>
        public void SearchTemplate(string templateName)
        {
            logger.LogMethodEntry("ManageTemplateMainPage", "SearchTemplate",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Window
                base.SelectWindow(ManageTemplateMainPageResource.
                    ManageTemplateMain_Page_Window_Title_Name);
                //Wait For Element
                base.WaitForElement(By.Id(ManageTemplateMainPageResource.
                    ManageTemplateMain_Page_TemplateFrame_Id_Locator));
                //Switch To Window
                base.SwitchToIFrame(ManageTemplateMainPageResource.
                    ManageTemplateMain_Page_TemplateFrame_Id_Locator);
                //Wait For Element
                base.WaitForElement(By.Id(ManageTemplateMainPageResource.
                    ManageTemplateMain_Page_Search_Link_Id_Locator));
                //Get Search Link Property
                IWebElement getSearchLinkProperty = base.GetWebElementPropertiesById
                    (ManageTemplateMainPageResource.
                    ManageTemplateMain_Page_Search_Link_Id_Locator);
                //Click on Search Link
                base.ClickByJavaScriptExecutor(getSearchLinkProperty);
                //Switch To Active Element of Page
                base.SwitchToActivePageElement();
                //Input Search Parameter
                InputTemplateSearchParameter(templateName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageTemplateMainPage", "SearchTemplate",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Input Template Search Parameter.
        /// </summary>
        /// <param name="templateName">This is template name.</param>
        private void InputTemplateSearchParameter(string templateName)
        {
            //Template Search by Template Name
            logger.LogMethodEntry("ManageTemplateMainPage", "InputTemplateSearchParameter",
              base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.Id(ManageTemplateMainPageResource.
                                          ManageTemplateMain_Page_SearchSection_Textbox_Id_Locator));
            //Clear TextBox
            base.ClearTextById(ManageTemplateMainPageResource.
                                   ManageTemplateMain_Page_SearchSection_Textbox_Id_Locator);
            //Fill Section Name In TextBox 
            base.FillTextBoxById(ManageTemplateMainPageResource.
                                     ManageTemplateMain_Page_SearchSection_Textbox_Id_Locator, templateName);
            //Wait For Element
            base.WaitForElement(By.Id(ManageTemplateMainPageResource.
                                          ManageTemplateMain_Page_Search_Button_Id_Locator));
            //Click on Search Button
            base.ClickButtonById(ManageTemplateMainPageResource.
                                     ManageTemplateMain_Page_Search_Button_Id_Locator);
            //Wait For Element
            base.WaitForElement(By.Id(ManageTemplateMainPageResource.
                                          ManageTemplateMain_Page_IFrame_Left_Id_Locator));
            //Switch To IFrame
            base.SwitchToIFrame(ManageTemplateMainPageResource.
                                    ManageTemplateMain_Page_IFrame_Left_Id_Locator);
            //Wait For Element
            base.WaitForElement(By.Id(ManageTemplateMainPageResource.
                                          ManageTemplateMain_Page_Template_Grid_Id_Locator));
            logger.LogMethodExit("ManageTemplateMainPage", "InputTemplateSearchParameter",
             base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
