using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Templates;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Add New Template Page Actions
    /// </summary>
    public class AddTemplatePage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(AddTemplatePage));

        /// <summary>
        /// Create Tempate.
        /// </summary>
        /// <param name="courseName">This is course name.</param>
        public void CreateOrganizationTemplate(string courseName)
        {
            //Create Template
            logger.LogMethodEntry("AddTemplatePage", "CreateOrganizationTemplate",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Generate Template Details Guid
                Guid templateDetails = Guid.NewGuid();
                //Wait For Window Loads
                base.WaitUntilWindowLoads(AddTemplatePageResource.
                                              AddTemplate_Page_Window_Title_Name);
                //Select Window
                base.SelectWindow(AddTemplatePageResource.
                                      AddTemplate_Page_Window_Title_Name);
                //Wait For Element
                base.WaitForElement(By.Id(AddTemplatePageResource.
                                              AddTemplate_Page_TemplateName_Id_Locator));
                //Fill Template Name in TextBox
                base.FillTextBoxById(AddTemplatePageResource.
                   AddTemplate_Page_TemplateName_Id_Locator, templateDetails.ToString());
                //Fill Template Description in Multi TextBox
                base.FillTextBoxById(AddTemplatePageResource.
                   AddTemplate_Page_TemplateDescription_Id_Locator, templateDetails.ToString());
                //Select Course To Create Template
                SelectCourse(courseName);
                //Wait For Element
                base.WaitForElement(By.Id(AddTemplatePageResource.
                        AddTemplate_Page_Template_SaveButton_Id_Locator));
                IWebElement getAddCloseButton = base.GetWebElementPropertiesById
                    (AddTemplatePageResource.
                          AddTemplate_Page_Template_SaveButton_Id_Locator);
                //Click Save button
                base.ClickByJavaScriptExecutor(getAddCloseButton);
                //Wait Till Pop Up Closed
                if (base.IsPopUpClosed(3))
                {
                    //Store Template Details In Memory
                    StoreTemplateDetailsInMemory(templateDetails.ToString());
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("AddTemplatePage", "CreateOrganizationTemplate",
               base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// Select Course To Create Template.
        /// </summary>
        /// <param name="courseName">This is Course Name</param>
        private void SelectCourse(string courseName)
        {
            //Select Course
            logger.LogMethodEntry("AddTemplatePage", "SelectCourse",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(AddTemplatePageResource.
                AddTemplate_Page_CourseGrid_XPath_Locator));
            //Wait For Element
            base.WaitForElement(By.XPath(AddTemplatePageResource.
                AddTemplate_Page_CourseRow_XPath_Locator));
            //Get The Course Name
            string getCourseName =
                base.GetElementTextByXPath(AddTemplatePageResource.
                AddTemplate_Page_CourseRow_XPath_Locator).Trim();
            if (courseName == getCourseName)
            {
                //Wait For Element
                base.WaitForElement(By.Name(AddTemplatePageResource.
                    AddTemplate_Page_SelectTemplate_RadioButton_Name_Locator));
                //Click on Radio Button To Select Course                
                base.SelectRadioButtonByName(AddTemplatePageResource.
                    AddTemplate_Page_SelectTemplate_RadioButton_Name_Locator);
                logger.LogMethodExit("AddTemplatePage", "SelectCourse",
              base.IsTakeScreenShotDuringEntryExit);
            }
        }

        /// <summary>
        /// Store Template Details In Memory.
        /// </summary>
        /// <param name="templateName">This is Template Name.</param>
        private void StoreTemplateDetailsInMemory(string templateName)
        {
            //Store Template Details in Memory
            logger.LogMethodEntry("AddTemplatePage", "StoreTemplateDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            //Get the Course Details from Memory
            Course course = Course.Get(Course.CourseTypeEnum.Container);
            course.TemplateName = templateName;            
            logger.LogMethodExit("AddTemplatePage", "StoreTemplateDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
