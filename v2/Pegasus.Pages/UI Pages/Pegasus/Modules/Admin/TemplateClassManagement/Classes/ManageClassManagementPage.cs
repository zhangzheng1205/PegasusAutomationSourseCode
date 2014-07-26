using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Templates;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Classes.Channels;
using Pegasus.Pages.Exceptions;
using System.Threading;
using System.Diagnostics;
using System.Configuration;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Manage Class Management Page Actions
    /// </summary>
    public class ManageClassManagementPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ManageClassManagementPage));


        /// <summary>
        /// Click on Add Classes Option Link
        /// </summary>
        public void ClickAddClassesOptionLink()
        {
            //Click on Add Classes Option
            logger.LogMethodEntry("ManageClassManagementPage", "ClickAddClassesOptionLink",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window Loads
                base.WaitUntilWindowLoads(ManageClassManagementPageResource.
                    ManageClassManagement_Page_ManageOrganization_Window_Title);
                //Select Window
                base.SelectWindow(ManageClassManagementPageResource.
                    ManageClassManagement_Page_ManageOrganization_Window_Title);
                //Wait For Element
                base.WaitForElement(By.Id(ManageClassManagementPageResource.
                    ManageClassManagement_Page_Frame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(ManageClassManagementPageResource.
                    ManageClassManagement_Page_Frame_Id_Locator);
                //Wait For Element
                base.WaitForElement(By.ClassName(ManageClassManagementPageResource.
                    ManageClassManagement_Page_AddClasses_ClassName_Locator));
                //Get Button Property
                IWebElement getAddClassesButtonProperty = base.GetWebElementPropertiesByClassName(
                    ManageClassManagementPageResource.ManageClassManagement_Page_AddClasses_ClassName_Locator);
                //Click on Add Classes Button
                base.ClickByJavaScriptExecutor(getAddClassesButtonProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageClassManagementPage", "ClickAddClassesOptionLink",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Class Search in Course Space
        /// </summary>
        /// <param name="className">This is Class name</param>
        public void ClassSearchInCoursespace(string className)
        {
            //Class Search in Course Space
            logger.LogMethodEntry("ManageClassManagementPage", "ClassSearchInCoursespace",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For ManageOrganization Window
                base.WaitUntilWindowLoads(ManageClassManagementPageResource.
                        ManageClassManagement_Page_ManageOrganization_Window_Title);
                base.SelectWindow(ManageClassManagementPageResource.
                    ManageClassManagement_Page_ManageOrganization_Window_Title);
                //Wait For Element
                base.WaitForElement(By.Id(ManageClassManagementPageResource.
                        ManageClassManagement_Page_Frame_Id_Locator));
                base.SwitchToIFrame(ManageClassManagementPageResource.
                    ManageClassManagement_Page_Frame_Id_Locator);
                //Get Link Property
                IWebElement getSearchLinkProperty = base.GetWebElementPropertiesById(ManageClassManagementPageResource.
                    ManageClassManagement_Page_Search_Id_Locator);
                //Click on Search Button
                base.ClickByJavaScriptExecutor(getSearchLinkProperty);
                base.WaitForElement(By.Id(ManageClassManagementPageResource.
                    ManageClassManagement_Page_ClassName_Input_Id_Locator));
                //Fill Text in Text Box
                base.FillTextBoxById(ManageClassManagementPageResource.
                    ManageClassManagement_Page_ClassName_Input_Id_Locator, className);
                //Get Button Property
                IWebElement getSearchButtonProperty = base.GetWebElementPropertiesById(ManageClassManagementPageResource.
                    ManageClassManagement_Page_Search_Button_Id_Locator);
                //Click on Add Classes Button
                base.ClickByJavaScriptExecutor(getSearchButtonProperty);
                Thread.Sleep(Convert.ToInt32(ManageClassManagementPageResource.
                            ManageClassManagement_Page_Sleep_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageClassManagementPage", "ClassSearchInCoursespace",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Searched Class Name
        /// </summary>
        public String GetSearchedClass()
        {
            //Get Searched Class Name
            logger.LogMethodEntry("ManageClassManagementPage", "GetSearchedClass",
                base.isTakeScreenShotDuringEntryExit);
            //Initializing getClassName Variable
            string getClassName = string.Empty;

            try
            {
                base.WaitUntilWindowLoads(ManageClassManagementPageResource.
                       ManageClassManagement_Page_ManageOrganization_Window_Title);
                //Select Manage Organization Window
                base.SelectWindow(ManageClassManagementPageResource.
                    ManageClassManagement_Page_ManageOrganization_Window_Title);
                base.WaitForElement(By.Id(ManageClassManagementPageResource.
                    ManageClassManagement_Page_Frame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(ManageClassManagementPageResource.
                    ManageClassManagement_Page_Frame_Id_Locator);
                base.WaitForElement(By.XPath(ManageClassManagementPageResource.
                    ManageClassManagement_Page_ClassName_Xpath_Locator));
                //Get Class Name
                getClassName = base.GetTitleAttributeValueByXPath(ManageClassManagementPageResource.
                    ManageClassManagement_Page_ClassName_Xpath_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageClassManagementPage", "GetSearchedClass",
                base.isTakeScreenShotDuringEntryExit);
            return getClassName;
        }

        /// <summary>
        /// Click On Class Cmenu Option Enter Class as Teacher
        /// </summary>
        public void ClickOnClassCmenuOptionEnterClassAsTeacher()
        {
            //Click on Class Cmenu Option Enter Class As Teacher
            logger.LogMethodEntry("ManageClassManagementPage",
                "ClickOnClassCmenuOptionEnterClassAsTeacher",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For Window
                base.WaitUntilWindowLoads(ManageClassManagementPageResource.
                       ManageClassManagement_Page_ManageOrganization_Window_Title);
                //Select Window
                base.SelectWindow(ManageClassManagementPageResource.
                    ManageClassManagement_Page_ManageOrganization_Window_Title);
                base.WaitForElement(By.Id(ManageClassManagementPageResource.
                    ManageClassManagement_Page_Frame_Id_Locator));
                //Switch to Frame
                base.SwitchToIFrame(ManageClassManagementPageResource.
                    ManageClassManagement_Page_Frame_Id_Locator);
                base.WaitForElement(By.XPath(ManageClassManagementPageResource.
                    ManageClassManagement_Page_ClassName_MouseHover_Xpath_Locator));
                IWebElement classTitleHover = base.GetWebElementPropertiesByXPath(
                    ManageClassManagementPageResource.
                    ManageClassManagement_Page_ClassName_MouseHover_Xpath_Locator);
                //Mouseover on Class
                base.PerformMouseHoverAction(classTitleHover);
                //Enter Class as Teacher
                this.EnterClassAsTeacher();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageClassManagementPage",
                "ClickOnClassCmenuOptionEnterClassAsTeacher",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter Class as Teacher
        /// </summary>
        private void EnterClassAsTeacher()
        {
            //Enter Class as Teacher
            logger.LogMethodEntry("ManageClassManagementPage", "EnterClassAsTeacher",
               base.isTakeScreenShotDuringEntryExit);
            //Wait for the element
            base.WaitForElement(By.XPath(ManageClassManagementPageResource.
                ManageClassManagement_Page_Cmenu_Image_Locator));
            IWebElement getCmenuButtonProperty = base.GetWebElementPropertiesByXPath
                (ManageClassManagementPageResource.
                ManageClassManagement_Page_Cmenu_Image_Locator);
            //Click on Add Classes Button
            base.ClickByJavaScriptExecutor(getCmenuButtonProperty);
            base.WaitForElement(By.PartialLinkText(ManageClassManagementPageResource.
                ManageClassManagement_Page_EnterClassAsTeacher_Link_Locator));
            IWebElement getEnterClassAsTeacherButtonProperty = 
                base.GetWebElementPropertiesByPartialLinkText(
                ManageClassManagementPageResource.
                ManageClassManagement_Page_EnterClassAsTeacher_Link_Locator);
            //Click on Add Classes Button
            base.ClickByJavaScriptExecutor(getEnterClassAsTeacherButtonProperty);
            logger.LogMethodExit("ManageClassManagementPage", "EnterClassAsTeacher",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Course Window
        /// </summary>
        public void SelectCourseWindow()
        {
            //Select Course Window
            logger.LogMethodEntry("ManageClassManagementPage", "SelectCourseWindow",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(SelectClassCourseFolderPageResource.
                            SelectClassCourseFolder_Page_SelectCourse_Window_Locator);
                //Select Select Course Window
                base.SelectWindow(SelectClassCourseFolderPageResource.
                    SelectClassCourseFolder_Page_SelectCourse_Window_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageClassManagementPage", "SelectCourseWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Overview Window
        /// </summary>
        public void SelectOverViewWindow()
        {
            //Select Overview Window
            logger.LogMethodEntry("ManageClassManagementPage", "SelectOverviewWindow",
               base.isTakeScreenShotDuringEntryExit);
            try
            {
                base.WaitUntilWindowLoads(ManageClassManagementPageResource.
                    ManageClassManagement_Page_Overview_Window_Name);
                //Select Overview Window
                base.SelectWindow(ManageClassManagementPageResource.
                    ManageClassManagement_Page_Overview_Window_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageClassManagementPage", "SelectOverviewWindow",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// To Search for Class Assigned to Copy
        /// </summary>
        /// <param name="className">This is class name.</param>
        public void SearchClassForAssignedToCopyState(string className)
        {
            //To Search for Class Assigned to Copy
            logger.LogMethodEntry("ManageClassManagementPage", "SearchClassForAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                int minutesToWait = Int32.Parse(ConfigurationManager.AppSettings["AssignedToCopyInterval"]);
                while (stopWatch.Elapsed.TotalMinutes < minutesToWait)
                {
                    //Select ManageOrganization Window
                    base.SelectWindow(ManageClassManagementPageResource.
                            ManageClassManagement_Page_ManageOrganization_Window_Title);
                    base.WaitForElement(By.Id(ManageClassManagementPageResource.
                        ManageClassManagement_Page_Frame_Id_Locator));
                    //Switch to Frame
                    base.SwitchToIFrame(ManageClassManagementPageResource.
                        ManageClassManagement_Page_Frame_Id_Locator);
                    base.WaitForElement(By.XPath(ManageClassManagementPageResource.
                        ManageClassManagement_Page_AssignToCopyText_Xpath_Locator));
                    //Get Assigned To Copy Text Message
                    string getAssignedToCopyMessage = base.GetElementTextByXPath(ManageClassManagementPageResource.
                        ManageClassManagement_Page_AssignToCopyText_Xpath_Locator);
                    if (getAssignedToCopyMessage.Contains("[Assigned to copy]") == false) break;
                    {
                        //Search the Class
                        this.ClassSearchInCoursespace(className);
                        Thread.Sleep(Convert.ToInt32(ManageClassManagementPageResource.
                            ManageClassManagement_Page_Sleep_Value));
                        //Select ManageOrganization Window
                        base.SelectWindow(ManageClassManagementPageResource.
                            ManageClassManagement_Page_ManageOrganization_Window_Title);
                    }
                }
                Thread.Sleep(Convert.ToInt32(ManageClassManagementPageResource.
                            ManageClassManagement_Page_Sleep_Value));
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageClassManagementPage", "SearchClassForAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
        }
        
        /// <summary>
        /// Select The CMenu Option
        /// </summary>
        /// <param name="cMenuOptionName">This is CMenu Option Name</param>
        public void SelectTheCMenuOption(string cMenuOptionName)
        {
            //Select The CMenu Option
            logger.LogMethodEntry("ManageClassManagementPage", "SelectTheCMenuOption",
              base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Click on Class Cmenu Option
                this.ClickOnClassCMenuIcon();
                //Wait for the CMenu Option
                base.WaitForElement(By.PartialLinkText(cMenuOptionName));
                IWebElement getCMenuOptionProperty =
                    base.GetWebElementPropertiesByPartialLinkText(cMenuOptionName);
                //Select the CMenu Option
                base.ClickByJavaScriptExecutor(getCMenuOptionProperty);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageClassManagementPage", "SelectTheCMenuOption",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Class CMenu Icon
        /// </summary>
        private void ClickOnClassCMenuIcon()
        {
            //Click on Class Cmenu Option
            logger.LogMethodEntry("ManageClassManagementPage", "ClickOnClassCMenuIcon",
               base.isTakeScreenShotDuringEntryExit);
            //Select 'Manage Organization' Window
            this.SelectManageOrganizationWindow();
            //Switch to Frame
            base.SwitchToIFrame(ManageClassManagementPageResource.
                ManageClassManagement_Page_Frame_Id_Locator);
            //Wait for the Class to Display
            base.WaitForElement(By.XPath(ManageClassManagementPageResource.
                ManageClassManagement_Page_ClassName_MouseHover_Xpath_Locator));
            IWebElement classTitleHover = base.GetWebElementPropertiesByXPath(
                ManageClassManagementPageResource.
                ManageClassManagement_Page_ClassName_MouseHover_Xpath_Locator);
            //Mouseover on Class Title
            base.PerformMouseHoverAction(classTitleHover);
            IWebElement getCmenuIconProperty = base.GetWebElementPropertiesByXPath(
                ManageClassManagementPageResource.
                ManageClassManagement_Page_Cmenu_Image_Locator);
            //Click on Class CMenu Icon
            base.ClickByJavaScriptExecutor(getCmenuIconProperty);
            logger.LogMethodExit("ManageClassManagementPage", "ClickOnClassCMenuIcon",
              base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select 'Manage Organization' Window
        /// </summary>
        private void SelectManageOrganizationWindow()
        {
            //Select 'Manage Organization' Window
            logger.LogMethodEntry("ManageClassManagementPage", "SelectManageOrganizationWindow",
               base.isTakeScreenShotDuringEntryExit);
            //Wait For 'Manage Organization' Window
            base.WaitUntilWindowLoads(ManageClassManagementPageResource.
                   ManageClassManagement_Page_ManageOrganization_Window_Title);
            //Select 'Manage Organization' Window
            base.SelectWindow(ManageClassManagementPageResource.
                ManageClassManagement_Page_ManageOrganization_Window_Title);
            base.WaitForElement(By.Id(ManageClassManagementPageResource.
                ManageClassManagement_Page_Frame_Id_Locator));
            logger.LogMethodExit("ManageClassManagementPage", "SelectManageOrganizationWindow",
               base.isTakeScreenShotDuringEntryExit);
        }
    }
}
