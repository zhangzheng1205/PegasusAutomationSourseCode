using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes.Channels;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes;
using Pegasus.Pages.Exceptions;
using System.Threading;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Class User Control Page Actions
    /// </summary>
    public class ClassUserControlsPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ClassUserControlsPage));

        /// <summary>
        /// Create a Class
        /// </summary>
        /// <param name="masterLibrary">This is Master Library Name</param>
        public void CreateClassUsingMasterLibrary(string masterLibrary)
        {
            //Create a Class
            logger.LogMethodEntry("ClassUserControlsPage", "CreateClassUsingMasterLibrary",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the Class Name
                string getClassName = this.GetClassName();
                //Store Class name to Memory
                this.StoreMasterLibraryClassDetailsInMemory(getClassName);
                Thread.Sleep(Convert.ToInt32(ClassUserControlsPageResource.
                    ClassUserControls_SleepTime_Value));
                //Select the Create Class Frame
                this.SelectCreateClassFrame();
                base.WaitForElement(By.Id(ClassUserControlsPageResource.
                    ClassUserControls_Page_ChooseProduct_Id_Locator));
                IWebElement getProduct=base.GetWebElementPropertiesById
                    (ClassUserControlsPageResource.
                   ClassUserControls_Page_ChooseProduct_Id_Locator);
                base.ClickByJavaScriptExecutor(getProduct);
                //Click on Next Button
                this.ClickOnNextButton();
                Thread.Sleep(Convert.ToInt32(ClassUserControlsPageResource.
                    ClassUserControls_SleepTime_Value));
                //Select Master Library 
                this.SelectMasterLibrary(masterLibrary);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ClassUserControlsPage", "CreateClassUsingMasterLibrary",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Create a Class Using Template.
        /// </summary>
        /// <param name="template">This Template Name.</param>
        public void CreateClassUsingTemplate(string template)
        {
            //Create Class Using Template
            logger.LogMethodEntry("ClassUserControlsPage", "CreateClassUsingTemplate",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the Class Name
                string getClassName = this.GetClassName();
                //Store Template Class name in Memory
                this.StoreTemplateClassDetailsInMemory(getClassName);
                Thread.Sleep(Convert.ToInt32(ClassUserControlsPageResource.
                    ClassUserControls_SleepTime_Value));
                //Select Create Class Window
                this.SelectCreateClassWindow();
                //Select the Create Class Frame
                this.SelectCreateClassFrame();
                base.WaitForElement(By.Id(ClassUserControlsPageResource.
                    ClassUserControls_Page_CustomProduct_Id_Locator));
                IWebElement getChooseproduct=base.GetWebElementPropertiesById
                    (ClassUserControlsPageResource.
                    ClassUserControls_Page_CustomProduct_Id_Locator);
                //Choose the product
                base.ClickByJavaScriptExecutor(getChooseproduct);
                //Click on Next Button
                this.ClickOnNextButton();
                //Select the Template
                this.SelectTemplate(template);
                Thread.Sleep(Convert.ToInt32(ClassUserControlsPageResource.
                    ClassUserControls_SleepTime_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ClassUserControlsPage", "CreateClassUsingTemplate",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the Template.
        /// </summary>
        /// <param name="template">This is Template Name.</param>
        private void SelectTemplate(string template)
        {
            //Select Template and Save the Class
            logger.LogMethodEntry("ClassUserControlsPage", "SelectTemplate",
            base.IsTakeScreenShotDuringEntryExit);
            //Select the Template
            this.ClickOnTemplate(template);
            //Click on Next Button
            this.ClickOnNextButton();
            Thread.Sleep(Convert.ToInt32(ClassUserControlsPageResource.
                ClassUserControls_SleepTime_CreateClass_Value));
            //Select Create Class Window
            this.SelectCreateClassWindow();
            base.WaitForElement(By.Id(ClassUserControlsPageResource.
                ClassUserControls_Page_Enrollements_Id_Locator));
            //Select the Create Class Frame
            this.SelectCreateClassFrame();
            base.WaitForElement(By.PartialLinkText(ClassUserControlsPageResource.
                ClassUserControls_Page_CreateNew_Link_Locator));
            logger.LogMethodExit("ClassUserControlsPage", "SelectTemplate",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The Create Class Finish Button.
        /// </summary>
        public void ClickTheCreateClassFinishButton()
        {
            //Click The Create Class Finish Button
            logger.LogMethodEntry("ClassUserControlsPage", "ClickTheCreateClassFinishButton",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Click on Next Button
                this.ClickOnNextButton();
                //Click on Finish Button
                this.ClickOnFinishButton();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ClassUserControlsPage", "ClickTheCreateClassFinishButton",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select the Template.
        /// </summary>
        /// <param name="templateName">This is Template Name.</param>
        private void ClickOnTemplate(string templateName)
        {
            //Select the Template
            logger.LogMethodEntry("ClassUserControlsPage", "ClickOnTemplate",
                base.IsTakeScreenShotDuringEntryExit);
            base.IsElementLoadedInWindow(ClassUserControlsPageResource.
                ClassUserControls_Page_CreateClass_Window_Name, 
                By.Id(ClassUserControlsPageResource.
                ClassUserControl_Page_ClassCreationProcessPanel_Id_Locator));
            //Wait For Class Panel
            base.WaitForElement(By.Id(ClassUserControlsPageResource.
                ClassUserControl_Page_ClassCreationProcessPanel_Id_Locator));
            //Wait For IFrame Element
            this.SelectCreateClassFrame();
            //Click on Template Radio Button
            this.ClickOnTemplatedRadioButton(templateName);
            logger.LogMethodExit("ClassUserControlsPage", "ClickOnTemplate",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Template Radio Button.
        /// </summary>
        /// <param name="template">This is Template Name.</param>
        private void ClickOnTemplatedRadioButton(string template)
        {
            //Click On Template Radio Button
            logger.LogMethodEntry("ClassUserControlsPage", "ClickOnTemplatedRadioButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait For Element
            base.WaitForElement(By.XPath(ClassUserControlsPageResource.
                                             ClassUserControls_Page_Template_Xpath_Locator));
            //Get Count of Template
            int getTemplateCount = base.GetElementCountByXPath(ClassUserControlsPageResource.
                ClassUserControls_Page_Template_Xpath_Locator);
            for (int rowCount = 1; rowCount <= getTemplateCount; rowCount++)
            {
                //Get Template Name
                string getTemplateName = base.GetElementTextByXPath(string.Format(
                    ClassUserControlsPageResource.ClassUserControls_Page_GetTemplateName_Xpath_Locator, rowCount));
                if (getTemplateName == template)
                {
                    base.WaitForElement(By.XPath(string.Format(ClassUserControlsPageResource.
                        ClassUserControls_Page_RadioButton_Template_Xpath_Locator, rowCount)));
                    base.FocusOnElementByXPath(string.Format(ClassUserControlsPageResource.
                        ClassUserControls_Page_RadioButton_Template_Xpath_Locator, rowCount));
                    IWebElement getTemplateRadioButton = base.GetWebElementPropertiesByXPath
                        (string.Format(ClassUserControlsPageResource.
                        ClassUserControls_Page_RadioButton_Template_Xpath_Locator, rowCount));
                    //Select the template
                    base.ClickByJavaScriptExecutor(getTemplateRadioButton);
                    break;
                }
            }
            logger.LogMethodExit("ClassUserControlsPage", "ClickOnTemplatedRadioButton",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select Master Library and Save the Class
        /// </summary>
        /// <param name="masterLibrary">This is Master Library Name</param>
        private void SelectMasterLibrary(string masterLibrary)
        {
            //Select MasterLibrary and Save the Class
            logger.LogMethodEntry("ClassUserControlsPage", "SelectMasterLibrary",
            base.IsTakeScreenShotDuringEntryExit);
            //Click on MasterLibrary Radio Button
            this.ClickOnMasterLibrary(masterLibrary);
            //Click on Next button
            this.ClickOnNextButton();
            Thread.Sleep(Convert.ToInt32(ClassUserControlsPageResource.
                ClassUserControls_SleepTime_CreateClass_Value));
            //Select Create Class Window
            this.SelectCreateClassWindow();
            base.WaitForElement(By.Id(ClassUserControlsPageResource.
                ClassUserControls_Page_Enrollements_Id_Locator));
            //Select the Create Class Frame
            this.SelectCreateClassFrame();
            base.WaitForElement(By.PartialLinkText(ClassUserControlsPageResource.
                ClassUserControls_Page_CreateNew_Link_Locator));
            //Click on Next Button
            this.ClickOnNextButton();
            //Click on Finish Button
            this.ClickOnFinishButton();
            logger.LogMethodExit("ClassUserControlsPage", "SelectMasterLibrary",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Finish Button
        /// </summary>
        private void ClickOnFinishButton()
        {
            //Click on Finish Button
            logger.LogMethodEntry("ClassUserControlsPage", "ClickOnFinishButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Create Class Window
            this.SelectCreateClassWindow();
            Thread.Sleep(Convert.ToInt32(ClassUserControlsPageResource.
                ClassUserControls_SleepTime_Value));
            //Get Button Property
            IWebElement getFinishButtonProperty = base.GetWebElementPropertiesById
                (ClassUserControlsPageResource.
                ClassUserControls_Page_Finish_Id_Locator);
            //Click on Finish Button
            base.ClickByJavaScriptExecutor(getFinishButtonProperty);
            Thread.Sleep(Convert.ToInt32(ClassUserControlsPageResource.
                ClassUserControls_SleepTime_Value));
            //Check Create Class Popup Closed
            base.IsPopUpClosed(3);
            logger.LogMethodExit("ClassUserControlsPage", "ClickOnFinishButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Class Frame
        /// </summary>
        private void SelectCreateClassFrame()
        {
            //Select Create Class Frame
            logger.LogMethodEntry("ClassUserControlsPage", "SelectCreateClassFrame",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the Creat class Frame
            base.WaitForElement(By.Id(ClassUserControlsPageResource.
                ClassUserControls_Page_Frame_Id_Locator));
            base.SwitchToIFrame(ClassUserControlsPageResource.
                ClassUserControls_Page_Frame_Id_Locator);
            logger.LogMethodExit("ClassUserControlsPage", "SelectCreateClassFrame",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Next Button. 
        /// </summary>
        private void ClickOnNextButton()
        {
            //Click on Next Button
            logger.LogMethodEntry("ClassUserControlsPage", "ClickOnNextButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Select Create Class Window
            this.SelectCreateClassWindow();
            base.WaitForElement(By.Id(ClassUserControlsPageResource.
                ClassUserControls_Page_Next_Id_Locator));
            // Get Next Button Property
            IWebElement getNextButtonProperty = base.GetWebElementPropertiesById(
                ClassUserControlsPageResource.
                ClassUserControls_Page_Next_Id_Locator);
            //Click on Next Button
            base.ClickByJavaScriptExecutor(getNextButtonProperty);
            logger.LogMethodExit("ClassUserControlsPage", "ClickOnNextButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Create Class Window.
        /// </summary>
        public void SelectCreateClassWindow()
        {
            //Select Create Class Window
            logger.LogMethodEntry("ClassUserControlsPage", "SelectCreateClassWindow",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window
                base.WaitUntilWindowLoads(ClassUserControlsPageResource.
                    ClassUserControls_Page_CreateClass_Window_Name);
                base.SelectWindow(ClassUserControlsPageResource.
                    ClassUserControls_Page_CreateClass_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ClassUserControlsPage", "SelectCreateClassWindow",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the Class name.
        /// </summary>
        /// <returns>Class name.</returns>
        private String GetClassName()
        {
            //Get the Class Name
            logger.LogMethodEntry("ClassUserControlsPage", "GetClassName",
               base.IsTakeScreenShotDuringEntryExit);
            //Wait For Create Class Window Loads
            this.SelectCreateClassWindow();
            //Select the Create Class Frame
            this.SelectCreateClassFrame();
            base.WaitForElement(By.Id(ClassUserControlsPageResource.
                ClassUserControls_Page_ClassName_Input_Id_Locator));
            //Class Name Guid
            Guid className = Guid.NewGuid();
            //Fill Text Box With Class Name
            base.FillTextBoxById(ClassUserControlsPageResource.
                ClassUserControls_Page_ClassName_Input_Id_Locator, className.ToString());
            //Click on Next BUtton
            this.ClickOnNextButton();
            logger.LogMethodExit("ClassUserControlsPage", "GetClassName",
           base.IsTakeScreenShotDuringEntryExit);
            return className.ToString();
        }


        /// <summary>
        /// To Store Class Name in memory
        /// </summary>
        /// <param name="className">This is Class Name</param>
        private void StoreMasterLibraryClassDetailsInMemory(string className)
        {
            //Store Class Name in Memory
            logger.LogMethodEntry("ClassUserControlsPage",
                "StoreMasterLibraryClassDetailsInMemory", base.IsTakeScreenShotDuringEntryExit);
            Class userClass = new Class
            {
                Name = className,
                ClassType = Class.ClassTypeEnum.DigitalPathMasterLibrary,
                IsCreated = true,
            };
            //Save Class Name to Memory
            userClass.StoreClassInMemory();
            logger.LogMethodExit("ClassUserControlsPage",
                "StoreMasterLibraryClassDetailsInMemory", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To store Template Class Name in Memory.
        /// </summary>
        /// <param name="templateClassName">This is class Name.</param>
        private void StoreTemplateClassDetailsInMemory(string templateClassName)
        {
            //Store Class Name in Memory
            logger.LogMethodEntry("ClassUserControlsPage",
                "StoreTemplateClassNameInMemory", base.IsTakeScreenShotDuringEntryExit);
            Class templateClass = new Class
            {
                Name = templateClassName,
                ClassType = Class.ClassTypeEnum.NovaNETTemplate,
                IsCreated = true,
            };
            templateClass.StoreClassInMemory();
            logger.LogMethodExit("ClassUserControlsPage",
                "StoreClassDetailsInMemory", base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Select the Master Library
        /// </summary>
        /// <param name="masterLibrary">This is Master Library Name</param>
        private void ClickOnMasterLibrary(string masterLibrary)
        {
            //Select the Master Library
            logger.LogMethodEntry("ClassUserControlsPage", "ClickOnMasterLibrary",
                base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(ClassUserControlsPageResource.
                ClassUserControls_Page_Frame_Id_Locator));
            //Switch to Frame
            base.SwitchToIFrame(ClassUserControlsPageResource.
                ClassUserControls_Page_Frame_Id_Locator);
            base.WaitForElement(By.XPath(ClassUserControlsPageResource.
                ClassUserControls_Page_CourseCount_Xpath_Locator));
            //Click On The Master Library Radio Button
            this.ClickOnMasterLibraryRadioButton(masterLibrary);
            logger.LogMethodExit("ClassUserControlsPage", "ClickOnMasterLibrary",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On the Master Library Radio Button
        /// </summary>
        /// <param name="masterLibrary">This is Master Library Name</param>
        private void ClickOnMasterLibraryRadioButton(string masterLibrary)
        {
            //Click On Master Library Radio Button
            logger.LogMethodEntry("ClassUserControlsPage", "ClickOnMasterLibraryRadioButton",
                base.IsTakeScreenShotDuringEntryExit);
            //Get Count of Master Library
            int getCourseCount = base.GetElementCountByXPath(ClassUserControlsPageResource.
                ClassUserControls_Page_CourseCount_Xpath_Locator);
            for (int initialRowCount = 1; initialRowCount <= getCourseCount; initialRowCount++)
            {
                //Get Master Library Name
                string getMasterLibraryName = base.GetElementTextByXPath(string.Format(
                    ClassUserControlsPageResource.
                    ClassUserControls_Page_GetCourseName_Xpath_Locator, initialRowCount));
                if (getMasterLibraryName == masterLibrary)
                {
                    //Check if element is present
                    if (base.IsElementPresent(By.XPath(string.Format(ClassUserControlsPageResource.
                            ClassUserControls_Page_RabioButton_Course_Xpath_Locator_St, initialRowCount)),
                            Convert.ToInt32(ClassUserControlsPageResource.
                            ClassUserControls_Page_Customized_Waitforelement)))
                    {
                        base.WaitForElement(By.XPath(string.Format(ClassUserControlsPageResource.
                            ClassUserControls_Page_RabioButton_Course_Xpath_Locator_St, initialRowCount)));
                        //Click on Mastery Library Radio Button
                        IWebElement getMasterLibraryRadioButton = base.GetWebElementPropertiesByXPath
                            (string.Format(ClassUserControlsPageResource.
                            ClassUserControls_Page_RabioButton_Course_Xpath_Locator_St, initialRowCount));
                        base.ClickByJavaScriptExecutor(getMasterLibraryRadioButton);                        
                        break;
                    }
                    else
                    {
                        base.WaitForElement(By.XPath(string.Format(ClassUserControlsPageResource.
                            ClassUserControls_Page_RadioButton_Course_Xpath_Locator_Vm, initialRowCount)));
                        //Click on Mastery Library Radio Button
                        IWebElement getRadioButtonProperty = base.GetWebElementPropertiesByXPath
                            (string.Format(ClassUserControlsPageResource.
                            ClassUserControls_Page_RadioButton_Course_Xpath_Locator_Vm, initialRowCount));
                        base.ClickByJavaScriptExecutor(getRadioButtonProperty);
                        break;
                    }
                }
            }
            logger.LogMethodExit("ClassUserControlsPage", "ClickOnMasterLibraryRadioButton",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click The 'Create New' Dropdown.
        /// </summary>
        public void ClickTheCreateNewDropdown()
        {
            //Click The 'Create New' Dropdown
            logger.LogMethodEntry("ClassUserControlsPage", "ClickTheCreateNewDropdown",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the element
                base.WaitForElement(By.Id(ClassUserControlsPageResource.
                    ClassUserControls_Page_Click_CreateNew_Id_Locator));
                IWebElement getCreateNewDropdown = base.GetWebElementPropertiesById
                    (ClassUserControlsPageResource.
                    ClassUserControls_Page_Click_CreateNew_Id_Locator);
                //Click the 'Create New' dropdown
                base.ClickByJavaScriptExecutor(getCreateNewDropdown);
                //Wait for the element
                base.WaitForElement(By.Id(ClassUserControlsPageResource.
                    ClassUserControls_Page_Select_Teacher_Id_Locator));
                IWebElement getTeacher = base.GetWebElementPropertiesById
                    (ClassUserControlsPageResource.
                    ClassUserControls_Page_Select_Teacher_Id_Locator);
                //Select the 'Teacher' link
                base.ClickByJavaScriptExecutor(getTeacher);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ClassUserControlsPage", "ClickTheCreateNewDropdown",
              base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        ///Create Class Using Novanet MasterLibrary.
        /// </summary>
        /// <param name="masterLibrary">This is MasterLibrary Course.</param>
        public void CreateClassUsingNovanetMasterLibrary(string masterLibrary)
        {
            //Create Class Using Novanet MasterLibrary
            logger.LogMethodEntry("ClassUserControlsPage", 
                "CreateClassUsingNovanetMasterLibrary",
            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the Class Name
                string getClassName = this.GetClassName();
                //Store Template Class name in Memory
                this.StoreTemplateClassDetailsInMemory(getClassName);
                Thread.Sleep(Convert.ToInt32(ClassUserControlsPageResource.
                    ClassUserControls_SleepTime_Value));
                //Select the Create Class Frame
                this.SelectCreateClassFrame();
                base.WaitForElement(By.Id(ClassUserControlsPageResource.
                    ClassUserControls_Page_ChooseProduct_Id_Locator));
                IWebElement getProductSelect=base.GetWebElementPropertiesById
                    (ClassUserControlsPageResource.
                    ClassUserControls_Page_ChooseProduct_Id_Locator);
                //Select the product radio button
                base.ClickByJavaScriptExecutor(getProductSelect);
                //Click on Next Button
                this.ClickOnNextButton();
                Thread.Sleep(Convert.ToInt32(ClassUserControlsPageResource.
                    ClassUserControls_SleepTime_Value));
                //Select MasterLibrary Checkbox
                this.SelectMasterLibraryCheckbox(masterLibrary);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ClassUserControlsPage",
                "CreateClassUsingNovanetMasterLibrary",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select MasterLibrary Checkbox.
        /// </summary>
        /// <param name="masterLibrary">This is MasterLibrary course.</param>
        private void SelectMasterLibraryCheckbox(string masterLibrary)
        {
            //Select MasterLibrary Checkbox
            logger.LogMethodEntry("ClassUserControlsPage", "SelectMasterLibraryCheckbox",
            base.IsTakeScreenShotDuringEntryExit);
            //Select the Create Class Frame
            this.SelectCreateClassFrame();
            //Click MasterLibrary Checkbox
            this.ClickMasterLibraryCheckbox(masterLibrary);
            //Click on Next button
            this.ClickOnNextButton();
            Thread.Sleep(Convert.ToInt32(ClassUserControlsPageResource.
                ClassUserControls_SleepTime_CreateClass_Value));
            //Select Create Class Window
            this.SelectCreateClassWindow();
            base.WaitForElement(By.Id(ClassUserControlsPageResource.
                ClassUserControls_Page_Enrollements_Id_Locator));
            //Select the Create Class Frame
            this.SelectCreateClassFrame();
            logger.LogMethodExit("ClassUserControlsPage", "SelectMasterLibraryCheckbox",
            base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click MasterLibrary Checkbox.
        /// </summary>
        /// <param name="masterLibrary">This is MasterLibrary Course Name.</param>
        private void ClickMasterLibraryCheckbox(string masterLibrary)
        {
            //Click MasterLibrary Checkbox
            logger.LogMethodEntry("ClassUserControlsPage", "ClickMasterLibraryCheckbox",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(ClassUserControlsPageResource.
                ClassUserControls_Page_CourseName_Xpath_Locator));
                //Get Master Library Name
                string getMasterLibraryName = base.GetElementTextByXPath(
                    ClassUserControlsPageResource.
                ClassUserControls_Page_CourseName_Xpath_Locator);
                if (getMasterLibraryName == masterLibrary)
                {
                    //Wait for the element
                    base.WaitForElement(By.XPath(ClassUserControlsPageResource.
                        ClassUserControls_Page_CourseCheckbox_Xpath_Locator));
                    IWebElement getCourseCheckbox=base.GetWebElementPropertiesByXPath
                        (ClassUserControlsPageResource.
                        ClassUserControls_Page_CourseCheckbox_Xpath_Locator);
                    //Select the checkbox
                    base.ClickByJavaScriptExecutor(getCourseCheckbox);                    
                }
            logger.LogMethodExit("ClassUserControlsPage", "ClickMasterLibraryCheckbox",
            base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
