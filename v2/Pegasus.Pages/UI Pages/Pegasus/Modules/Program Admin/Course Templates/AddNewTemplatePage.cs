using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Course_Templates;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class creates a new Template
    /// </summary>
    public class AddNewTemplatePage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(AddNewTemplatePage));

        /// <summary>
        /// Create New Template
        /// </summary>
        public void CreateNewTemplate()
        {
           //Create New Template
            logger.LogMethodEntry("AddNewTemplatePage", "CreateNewTemplate", 
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Add New Template Window
                base.SelectWindow(AddNewTemplatePageResource.
                        AddNewTemplate_Page_Window_Page_Title);
                base.WaitForElement(By.Id(AddNewTemplatePageResource.
                    AddNewTemplate_Page_AddTemplate_Button_Id_Locator));
                //Click on the Add Template Button
                base.ClickButtonByID(AddNewTemplatePageResource.
                    AddNewTemplate_Page_AddTemplate_Button_Id_Locator);
                base.IsPopUpClosed(Convert.ToInt32(AddNewTemplatePageResource
                    .AddNewTemplate_Page_No_of_popups));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodEntry("AddNewTemplatePage", "CreateNewTemplate", 
                base.isTakeScreenShotDuringEntryExit);
        }
    }
}
