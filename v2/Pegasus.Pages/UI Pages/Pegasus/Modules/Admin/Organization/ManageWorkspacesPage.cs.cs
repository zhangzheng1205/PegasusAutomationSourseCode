using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Organization;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles details of Manage Workspaces Page
    /// </summary>
    public class ManageWorkspacesPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ManageWorkspacesPage));

        /// <summary>
        /// Get the Page Title
        /// </summary>
        /// <returns>Returns Page Title</returns>
        public String GetThePageTitle()
        {
            //Get the Page Title
            logger.LogMethodEntry("ManageWorkspacesPage", "GetThePageTitle",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Default window
                base.SelectDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageWorkspacesPage", "GetThePageTitle",
                base.isTakeScreenShotDuringEntryExit);
            return base.GetPageTitle;
        }

        /// <summary>
        /// Checks the Display Of Default Contents In Workspaces Tab
        /// </summary>
        /// <returns>True if all the default contents in the Workspaces 
        /// tab are displayed otherwise False</returns>
        public Boolean IsTheDefaultContentsInWorkspacesTabDisplayed()
        {
            //Display Of Default Contents In Workspaces Tab
            logger.LogMethodEntry("ManageWorkspacesPage",
                "IsTheDefaultContentsInWorkspacesTabDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            //Initializing the Variable
            bool isDefaultContentsDisplayed = false;
            try
            {
                base.SelectWindow(ManageWorkspacesPageResource.
                    ManageWorkspacesPage_Window_Title);
                //Wait and Switch to the Frame
                base.WaitForElement(By.Id(ManageWorkspacesPageResource.
                    ManageWorkspacesPage_IfrmWorkspace_IFrame_Id_Locator));
                base.SwitchToIFrame(ManageWorkspacesPageResource.
                    ManageWorkspacesPage_IfrmWorkspace_IFrame_Id_Locator);
                //Check If All the default Contents are Displayed
                isDefaultContentsDisplayed = this.IsAllContentsDisplayed();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageWorkspacesPage",
                "IsTheDefaultContentsInWorkspacesTabDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            return isDefaultContentsDisplayed;
        }

        /// <summary>
        /// Check If All the default Contents are Displayed
        /// </summary>
        /// <returns>True if all the default contents in the Workspaces 
        /// tab are displayed otherwise False</returns>
        private bool IsAllContentsDisplayed()
        {
            //Check If All the default Contents are Displayed
            logger.LogMethodEntry("ManageWorkspacesPage","IsAllContentsDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            //Is 'Create New Workspace' link Displayed
            bool isCreateNewWorkspaceDisplayed = base.IsElementPresent(By.
                PartialLinkText(ManageWorkspacesPageResource.
                ManageWorkspacesPage_CreateNewWorkspace_Link_Text),
                Convert.ToInt32(ManageWorkspacesPageResource.
                ManageWorkspacesPage_Customized_Wait_Time));
            //Is 'Delete Selected Workspaces' link Displayed
            bool isDeleteSelectedWorkspacesDisplayed = base.IsElementPresent(By.
                Id(ManageWorkspacesPageResource.
                ManageWorkspacesPage_DeleteSelectedWorkspace_Id_Locator), Convert.ToInt32(
                ManageWorkspacesPageResource.ManageWorkspacesPage_Customized_Wait_Time));
            //Get the Header Text
            string getHeaderText = base.GetElementTextByClassName(ManageWorkspacesPageResource.
                ManageWorkspacesPage_HeaderStyle_ClassName_Locator);
            //Check if Name column is Present
            bool isNameFieldDisplayed = getHeaderText.Contains(ManageWorkspacesPageResource.
                ManageWorkspacesPage_Header_Name_Text);
            //Check if Status column is Present
            bool isStatusFieldDisplayed = getHeaderText.Contains(ManageWorkspacesPageResource.
                ManageWorkspacesPage_Header_Status_Text);
            //Check if Options column is Present
            bool isOptionsFieldDisplayed = getHeaderText.Contains(ManageWorkspacesPageResource.
                ManageWorkspacesPage_Header_Options_Text);
            logger.LogMethodExit("ManageWorkspacesPage", "IsAllContentsDisplayed",
                base.isTakeScreenShotDuringEntryExit);
            return (isCreateNewWorkspaceDisplayed &&
                isDeleteSelectedWorkspacesDisplayed && isNameFieldDisplayed &&
                isStatusFieldDisplayed && isOptionsFieldDisplayed);            
        }
    }
}
