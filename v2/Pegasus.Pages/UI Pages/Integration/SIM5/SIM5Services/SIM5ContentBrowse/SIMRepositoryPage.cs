using System;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using System.Threading;
using Pegasus.Pages.UI_Pages.Integration.SIM5.SIM5Services.SIM5ContentBrowse;

namespace Pegasus.Pages.UI_Pages.Integration.SIM5.SIM5Services.SIM5ContentBrowse
{
    /// <summary>
    /// This Class Handles the SIMRepositoryPage actions
    /// </summary>
    public class SIMRepositoryPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static readonly Logger logger =
            Logger.GetInstance(typeof(SIMRepositoryPage));

        /// <summary>
        /// Select Question Folder
        /// </summary>
        public void AddQuestionFolder()
        {
            //Select Question Folder
            logger.LogMethodEntry("SIMRepositoryPage", "AddQuestionFolder",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select SIM5 Select Questions Window
                this.SelectSIM5SelectQuestionsWindow();
                //Open Root Folder
                this.OpenTheFolder(SIMRepositoryPageResource.
                    SIMRepository_Page_RootFolder_Xpath_Locator);
                //Open Leaf Folder one
                this.OpenTheFolder(SIMRepositoryPageResource.
                    SIMRepository_Page_LeafFolderOne_Xpath_Locator);
                //Open Leaf Folder Two
                this.OpenTheFolder(SIMRepositoryPageResource.
                    SIMRepository_Page_LeafFolderTwo_Xpath_Locator);
                //Open Leaf Folder Three
                this.OpenTheFolder(SIMRepositoryPageResource.
                    SIMRepository_Page_LeafFolderThree_Xpath_Locator);
                //Click On Add Button
                this.ClickOnAddButton();
                //Click On Close Button
                this.ClickOnCloseButton();
                //Open Folder To Add Another Set Of Questions
                this.OpenTheFolder(SIMRepositoryPageResource.
                    SIMRepository_Page_Second_Folder_Xpath_Locator);
                //Open Child Folder
                this.OpenTheFolder(SIMRepositoryPageResource.
                    SIMRepository_Page_Child_Leaf_Xpath_Locator);
                //Click On Add and Close Button
                this.ClickOnAddAndCloseButton();              
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("SIMRepositoryPage", "AddQuestionFolder",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Close Button.
        /// </summary>
        private void ClickOnCloseButton()
        {
            //Click On Close Button
            logger.LogMethodEntry("SIMRepositoryPage", "ClickOnCloseButton",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(SIMRepositoryPageResource.
                SIMRepository_Page_Close_Button_Id_Locator));
            //Get Close Button Property
            IWebElement getCloseButtonProperty =
                base.GetWebElementPropertiesByXPath(SIMRepositoryPageResource.
                SIMRepository_Page_Close_Button_Id_Locator);
            //Click On Close Button
            base.ClickByJavaScriptExecutor(getCloseButtonProperty);
            logger.LogMethodExit("SIMRepositoryPage", "ClickOnCloseButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add Button.
        /// </summary>
        private void ClickOnAddButton()
        {
            //Click On Add Button
            logger.LogMethodEntry("SIMRepositoryPage", "ClickOnAddButton",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(SIMRepositoryPageResource.
                SIMRepository_Page_Add_Button_Id_Locator));
            //Get Add Button Property
            IWebElement getAddButtonProperty =
                base.GetWebElementPropertiesById(SIMRepositoryPageResource.
                SIMRepository_Page_Add_Button_Id_Locator);
            //Click On Add Button
            base.ClickByJavaScriptExecutor(getAddButtonProperty);
            logger.LogMethodExit("SIMRepositoryPage", "ClickOnAddButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select SIM5 Select Questions Window
        /// </summary>
        private void SelectSIM5SelectQuestionsWindow()
        {
            //Select SIM5 Select Questions Window
            logger.LogMethodEntry("SIMRepositoryPage", "SelectSIM5SelectQuestionsWindow",
              base.IsTakeScreenShotDuringEntryExit);
            base.WaitUntilWindowLoads(SIMRepositoryPageResource.
                SIMRepository_Page_SIM5SelectQuestions_Window_Name);
            //Select SIM5 Select Questions Window
            base.SelectWindow(SIMRepositoryPageResource.
                SIMRepository_Page_SIM5SelectQuestions_Window_Name);
            logger.LogMethodExit("SIMRepositoryPage", "SelectSIM5SelectQuestionsWindow",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Open the Folder
        /// </summary>
        /// <param name="xpathOfFolder">This is Xpath of the Folder</param>
        private void OpenTheFolder(String xpathOfFolder)
        {
            //Open the Folder
            logger.LogMethodEntry("SIMRepositoryPage", "OpenTheFolder",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(xpathOfFolder));
            //Get Folder Xpath
            IWebElement getXpath = base.GetWebElementPropertiesByXPath(xpathOfFolder);
            //Click On Folder
            base.ClickByJavaScriptExecutor(getXpath);
            logger.LogMethodExit("SIMRepositoryPage", "OpenTheFolder",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Add And Close Button
        /// </summary>
        private void ClickOnAddAndCloseButton()
        {
            //Click On Add And Close Button
            logger.LogMethodEntry("SIMRepositoryPage", "ClickOnAddAndCloseButton",
             base.IsTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.Id(SIMRepositoryPageResource.
                SIMRepository_Page_AddandClose_Button_Id_Locator));
            //Get Add and Close button Property
            IWebElement getAddAndCloseButtonProperty = base.GetWebElementPropertiesById(
                SIMRepositoryPageResource.SIMRepository_Page_AddandClose_Button_Id_Locator);
            //Click On Add And Close Button
            base.ClickByJavaScriptExecutor(getAddAndCloseButtonProperty);
            Thread.Sleep(Convert.ToInt32(SIMRepositoryPageResource.
                SIMRepository_Page_WaitTime));
            logger.LogMethodExit("SIMRepositoryPage", "ClickOnAddAndCloseButton",
               base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
