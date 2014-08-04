using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment;
using Pegasus.Pages.Exceptions;
using System.Threading;

namespace Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment
{
    /// <summary>
    /// This class handles the enrollment of users in class in Course space
    /// </summary>
    public class OrgAdminEnrollClassesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(OrgAdminEnrollClassesPage));

        /// <summary>
        /// Select the class from the right frame
        /// </summary>
        /// <param name="classTypeEnum">This is class by type.</param>
        public void SelectMasterLibraryClass(Class.ClassTypeEnum classTypeEnum)
        {
            //Select the class from right frame
            logger.LogMethodEntry("OrgAdminEnrollClassesPage", "SelectMasterLibraryClass",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Get the organization class
                Class orgClass = Class.Get(classTypeEnum);
                Thread.Sleep(Convert.ToInt32(OrgAdminEnrollClassesPageResource.
                    OrgAdminEnrollClasses_Page_Sleep_Value));
                // Select Manage Organization window
                base.SelectWindow(OrgAdminEnrollClassesPageResource
                    .OrgAdminEnrollClasses_Page_WindowName_Title);
                // Wait for frame id and then switch
                base.WaitForElement(By.Id(OrgAdminEnrollClassesPageResource
                    .OrgAdminEnrollClasses_Page_FrameId_Locator));
                base.SwitchToIFrame(OrgAdminEnrollClassesPageResource
                    .OrgAdminEnrollClasses_Page_FrameId_Locator);                
                // Switch to right frame id
                base.WaitForElement(By.Id(OrgAdminEnrollClassesPageResource
                    .OrgAdminEnrollClasses_Page_RightFrame_Id_Locator));               
                base.SwitchToIFrame(OrgAdminEnrollClassesPageResource
                .OrgAdminEnrollClasses_Page_RightFrame_Id_Locator);
                // Search class name 
                SearchClassName(orgClass.Name);
                switch (classTypeEnum)
                {
                    case Class.ClassTypeEnum.DigitalPathMasterLibrary:
                        // Select check box of Digital Path class
                        this.SelectDigitalPathClassNameCheckbox();
                        break;
                    case Class.ClassTypeEnum.NovaNETTemplate:
                        // Select check box of NovaNET class
                        this.SelectNovaNETClassNameCheckbox();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Select the class from right frame
            logger.LogMethodEntry("OrgAdminEnrollClassesPage", "SelectMasterLibraryClass",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search the class name in right frame.
        /// </summary>
        /// <param name="className">This is the class name.</param>
        private void SearchClassName(string className)
        {
            //Search class from right frame
            logger.LogMethodEntry("OrgAdminEnrollClassesPage", "SearchClassName",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Wait for search link & click
                base.WaitForElement(By.Id(OrgAdminEnrollClassesPageResource
                    .OrgAdminEnrollClasses_Page_SearchLink_Id_Locator));
                IWebElement getdearchLink=base.GetWebElementPropertiesById
                    (OrgAdminEnrollClassesPageResource
                     .OrgAdminEnrollClasses_Page_SearchLink_Id_Locator);
                base.ClickByJavaScriptExecutor(getdearchLink);
                // Wait for Class name text box and fill the class name
                base.WaitForElement(By.Id(OrgAdminEnrollClassesPageResource
                .OrgAdminEnrollClasses_Page_ClassName_TextBox_Id_Locator));
                base.FillTextBoxById(OrgAdminEnrollClassesPageResource
                   .OrgAdminEnrollClasses_Page_ClassName_TextBox_Id_Locator, className);
                // wait for search button and click
                base.WaitForElement(By.Id(OrgAdminEnrollClassesPageResource.
                    OrgAdminEnrollClasses_Page_SearchButton_Id_Locator));
                IWebElement getSearchButton = base.GetWebElementPropertiesById
                    (OrgAdminEnrollClassesPageResource.
                 OrgAdminEnrollClasses_Page_SearchButton_Id_Locator);
                base.ClickByJavaScriptExecutor(getSearchButton);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Search the class from right frame
            logger.LogMethodEntry("OrgAdminEnrollClassesPage", "SearchClassName",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select class Name checkbox for Digital Path Product
        /// </summary>
        private void SelectDigitalPathClassNameCheckbox()
        {
            //Search class from right frame
            logger.LogMethodEntry("OrgAdminEnrollClassesPage", "SelectDigitalPathClassNameCheckbox",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                // Select checkbox of searched class
                base.WaitForElement(By.XPath(OrgAdminEnrollClassesPageResource
                    .OrgAdminEnrollClasses_Page_SelectClass_Checkbox_Xpath_Locator));
                base.ClickButtonByXPath(OrgAdminEnrollClassesPageResource
                    .OrgAdminEnrollClasses_Page_SelectClass_Checkbox_Xpath_Locator);
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Search class from right frame
            logger.LogMethodEntry("OrgAdminEnrollClassesPage", "SelectDigitalPathClassNameCheckbox",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select class Name checkbox for NovaNET Product
        /// </summary>
        private void SelectNovaNETClassNameCheckbox()
        {
            //Search class from right frame
            logger.LogMethodEntry("OrgAdminEnrollClassesPage", "SelectNovaNETClassNameCheckbox",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Element
                base.WaitForElement(By.XPath(OrgAdminEnrollClassesPageResource.
                    OrgAdminEnrollClasses_Page_ClassExpand_Image_XPath_Locator));
                IWebElement getClassExpandButn=base.GetWebElementPropertiesByXPath
                    (OrgAdminEnrollClassesPageResource.
                    OrgAdminEnrollClasses_Page_ClassExpand_Image_XPath_Locator);
                //Click on Button
                base.ClickByJavaScriptExecutor(getClassExpandButn);
                // Select checkbox of searched class
                base.WaitForElement(By.XPath(OrgAdminEnrollClassesPageResource.
                    OrgAdminEnrollClasses_Page_SelectAllCourses_Checkbox_Xpath_Locator));
                IWebElement getSelectCourse=base.GetWebElementPropertiesByXPath
                    (OrgAdminEnrollClassesPageResource.
                    OrgAdminEnrollClasses_Page_SelectAllCourses_Checkbox_Xpath_Locator);
                //Click on Button
                base.ClickByJavaScriptExecutor(getSelectCourse);
                //Click on Radio button
                base.SelectRadioButtonByXPath(OrgAdminEnrollClassesPageResource
                    .OrgAdminEnrollClasses_Page_SelectAllCourses_Checkbox_Xpath_Locator);                
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            //Search class from right frame
            logger.LogMethodEntry("OrgAdminEnrollClassesPage", "SelectNovaNETClassNameCheckbox",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
