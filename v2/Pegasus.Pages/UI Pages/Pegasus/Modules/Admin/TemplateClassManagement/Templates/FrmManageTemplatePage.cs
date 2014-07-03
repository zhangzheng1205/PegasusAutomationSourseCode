using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.TemplateClassManagement.Templates;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles the manage template actions.
    /// The class name is bad as per Pegasus defined page.
    /// </summary>
    public class FrmManageTemplatePage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(FrmManageTemplatePage));

        /// <summary>
        /// This is the Assigned to Copy Interval Time
        /// </summary>
        static readonly int TimeToWait = Int32.Parse
            (ConfigurationManager.AppSettings["AssignedToCopyInterval"]);

        /// <summary>
        /// Get The Name of Search Template.
        /// </summary>
        /// <returns>Returns The Name of the Template.</returns>
        public string GetSearchedTemplate()
        {
            logger.LogMethodEntry("FrmManageTemplatePage", "GetSearchedTemplate",
            base.isTakeScreenShotDuringEntryExit);
            //Initialized the variable
            string getTemplateName = string.Empty;
            try
            {
                //Select Window
                base.SelectWindow(FrmManageTemplatePageResource.
                    FrmManageTemplate_Page_Window_Title_Name);
                //Wait For Element
                base.WaitForElement(By.Id(FrmManageTemplatePageResource.
                    FrmManageTemplate_Page_OuterFrame_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(FrmManageTemplatePageResource.
                    FrmManageTemplate_Page_OuterFrame_Id_Locator);
                //Wait For Element
                base.WaitForElement(By.Id(FrmManageTemplatePageResource.
                    FrmManageTemplate_Page_InnerLeftFrame_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(FrmManageTemplatePageResource.
                    FrmManageTemplate_Page_InnerLeftFrame_Id_Locator);
                //Wait For Element
                base.WaitForElement(By.XPath(FrmManageTemplatePageResource.
                    FrmManageTemplate_Page_TemplateName_Grid_Xpath_Locator));
                //Get Template Name From Template Grid
                getTemplateName = base.GetTitleAttributeValueByXPath(FrmManageTemplatePageResource.
                    FrmManageTemplate_Page_TemplateName_Grid_Xpath_Locator);
                //Switch To Default Content
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("FrmManageTemplatePage", "GetSearchedTemplate",
           base.isTakeScreenShotDuringEntryExit);
            return getTemplateName;
        }

        /// <summary>
        /// Perform Search To Validate Assigned To Copy State.
        /// </summary>
        /// <param name="templateName">This is template name.</param>
        public void ApproveAssignedToCopyState(string templateName)
        {
            //Validate Template From Assigned To Copy State
            logger.LogMethodEntry("FrmManageTemplatePage", "ApproveAssignedToCopyState",
           base.isTakeScreenShotDuringEntryExit);
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                while (stopWatch.Elapsed.Minutes < TimeToWait)
                {
                    base.WaitUntilWindowLoads(FrmManageTemplatePageResource.
                        FrmManageTemplate_Page_Window_Title_Name);
                    //Select Manage Organization Window
                    base.SelectWindow(FrmManageTemplatePageResource.
                        FrmManageTemplate_Page_Window_Title_Name);
                    base.WaitForElement(By.Id(FrmManageTemplatePageResource.
                        FrmManageTemplate_Page_OuterFrame_Id_Locator));
                    //Switch to Main Frame
                    base.SwitchToIFrame(FrmManageTemplatePageResource.
                        FrmManageTemplate_Page_OuterFrame_Id_Locator);
                    base.WaitForElement(By.Id(FrmManageTemplatePageResource.
                        FrmManageTemplate_Page_InnerLeftFrame_Id_Locator));
                    //Switch to Left Frame
                    base.SwitchToIFrame(FrmManageTemplatePageResource.
                        FrmManageTemplate_Page_InnerLeftFrame_Id_Locator);
                    //Get Assigned To Copy Text
                    string getAssignedtoCopyText = base.GetElementTextByID(FrmManageTemplatePageResource.
                        FrmManageTemplate_Page_Template_Grid_Id_Locator);
                    if (getAssignedtoCopyText.Contains(FrmManageTemplatePageResource.
                       FrmManageTemplate_Page_AssignedToCopy_Text) == false) break;
                    {
                        //Search Template
                        new ManageTemplateMainPage().SearchTemplate(templateName);
                        //Wait For Search
                        Thread.Sleep(Convert.ToInt32(FrmManageTemplatePageResource.
                            FrmManageTemplate_Page_Thread_Sleep_Time));
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("FrmManageTemplatePage", "ApproveAssignedToCopyState",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get Out Of Assigned To Copy State Text.
        /// </summary>
        /// <returns>Assigned To Copy Text if Present, otherwise null.</returns>
        public string GetAssignedToCopyStateText()
        {
            //Get Assigned To Copy Text If Present
            logger.LogMethodEntry("FrmManageTemplatePage", "GetAssignedToCopyStateText",
               base.isTakeScreenShotDuringEntryExit);
            //Initialized null 
            IWebElement getAssignedToCopyText = null;
            try
            {
                //Get Assigned To Copy Text Element Property
                getAssignedToCopyText = base.GetWebElementPropertiesById(FrmManageTemplatePageResource.
                    FrmManageTemplate_Page_Template_Grid_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("FrmManageTemplatePage", "GetAssignedToCopyStateText",
                    base.isTakeScreenShotDuringEntryExit);
            return getAssignedToCopyText.ToString();
        }
    }
}
