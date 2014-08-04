using System;
using OpenQA.Selenium.Interactions;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using OpenQA.Selenium;
using System.Threading;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Organization;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus New Workspace Page Actions
    /// </summary>
    public class NewWorkspacePage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(NewWorkspacePage));


        /// <summary>
        /// Fill UserName Details
        /// </summary>
        /// <param name="workspaceUserName">This is username</param>
        /// <param name="adminWorkspaceType">This is workspace type</param>
        private void FillUserNameDetails(string workspaceUserName,
            AdminToolPage.AdminWorkspaceTypeEnum adminWorkspaceType)
        {
            //Fill UserName Details
            logger.LogMethodEntry("NewWorkspacePage", "FillUserNameDetails",
                base.IsTakeScreenShotDuringEntryExit);
            //Fill the Admin Title
            base.WaitForElement(By.Id(NewWorkspacePageResource.
                NewWorkspace_Page_CreateWorkspace_Title_Id_Locator));
            base.GetWebElementPropertiesById(NewWorkspacePageResource.
                NewWorkspace_Page_CreateWorkspace_Title_Id_Locator).Clear();
            base.GetWebElementPropertiesById(NewWorkspacePageResource.
                NewWorkspace_Page_CreateWorkspace_Title_Id_Locator)
                .SendKeys(workspaceUserName.ToString());
            //Fill the Admin Username
            base.WaitForElement(By.Id(NewWorkspacePageResource.
                NewWorkspace_Page_CreateWorkspace_UserName_Id_Locator));
            base.GetWebElementPropertiesById(NewWorkspacePageResource.
                NewWorkspace_Page_CreateWorkspace_UserName_Id_Locator).Clear();
            base.GetWebElementPropertiesById(NewWorkspacePageResource.
                NewWorkspace_Page_CreateWorkspace_UserName_Id_Locator).
               SendKeys(workspaceUserName.ToString());
            switch (adminWorkspaceType)
            {
                case AdminToolPage.AdminWorkspaceTypeEnum.Create:
                    //Fill the password
                    base.WaitForElement(By.Id(NewWorkspacePageResource.
                        NewWorkspace_Page_CreateWorkspace_Password_Id_Locator));
                    base.GetWebElementPropertiesById(NewWorkspacePageResource.
                        NewWorkspace_Page_CreateWorkspace_Password_Id_Locator).Clear();
                    base.GetWebElementPropertiesById(NewWorkspacePageResource.
                        NewWorkspace_Page_CreateWorkspace_Password_Id_Locator).
                       SendKeys(NewWorkspacePageResource.
                       NewWorkspace_Page_CreateWorkspace_Password_Value);
                    break;
            }
            logger.LogMethodExit("NewWorkspacePage", "FillUserNameDetails",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Store Workspace Details In Memory
        /// </summary>
        /// <param name="workspaceName">This is user type by enum</param>
        /// <param name="workspaceUserName">This is Guid  username</param>
        private void StoreWorkspaceDetailsInMemory(WorkSpace.WorkSpaceTypeEnum workspaceName,
            Guid workspaceUserName)
        {
            //Store Workspace Details In Memory
            logger.LogMethodEntry("NewWorkspacePage", "StoreWorkspaceDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit);
            //Intialize the workspace
            WorkSpace newWorkspace = new WorkSpace
            {
                Name = workspaceUserName.ToString(),
                WorkSpaceType = workspaceName,                
                IsCreated = true,
            };            
            //Save The workspace Details in memory
            newWorkspace.StoreWorkSpaceInMemory();
            switch (workspaceName)
            {
                case WorkSpace.WorkSpaceTypeEnum.HEDMilWorkSpace:
                    User user = new User
                    {
                        Name = workspaceUserName.ToString(),
                        UserType = User.UserTypeEnum.HedMiLWsAdmin,
                        IsCreated = true,
                        Password = NewWorkspacePageResource.
                        NewWorkspace_Page_CreateWorkspace_Password_Value
                    }; user.StoreUserInMemory();
                    break;
            }
            logger.LogMethodExit("NewWorkspacePage", "StoreWorkspaceDetailsInMemory",
                base.IsTakeScreenShotDuringEntryExit); ;
        }

        /// <summary>
        ///Enter First And LastName Details
        /// </summary>
        /// <param name="firstName">This is First Name</param>
        /// <param name="lastName">This is Last Name</param>
        /// <param name="adminWorkspaceType">This is workspace</param>
        private void EnterFirstAndLastNameDetails(string firstName, string lastName,
            AdminToolPage.AdminWorkspaceTypeEnum adminWorkspaceType)
        {
            //Enter First And LastName Details
            logger.LogMethodEntry("NewWorkspacePage", "EnterFirstAndLastNameDetails",
                base.IsTakeScreenShotDuringEntryExit);
            switch (adminWorkspaceType)
            {
                case AdminToolPage.AdminWorkspaceTypeEnum.Create:
                    //Fill the First name
                    base.WaitForElement(By.Id(NewWorkspacePageResource.
                       NewWorkspace_Page_CreateWorkspace_FirstName_Id_Locator));
                    base.GetWebElementPropertiesById(NewWorkspacePageResource.
                        NewWorkspace_Page_CreateWorkspace_FirstName_Id_Locator).Clear();
                    base.GetWebElementPropertiesById(NewWorkspacePageResource.
                        NewWorkspace_Page_CreateWorkspace_FirstName_Id_Locator).
                       SendKeys(firstName.ToString());
                    //Fill the Last name
                    base.WaitForElement(By.Id(NewWorkspacePageResource.
                      NewWorkspace_Page_CreateWorkspace_LastName_Id_Locator));
                    base.GetWebElementPropertiesById(NewWorkspacePageResource.
                        NewWorkspace_Page_CreateWorkspace_LastName_Id_Locator).Clear();
                    base.GetWebElementPropertiesById(NewWorkspacePageResource.
                        NewWorkspace_Page_CreateWorkspace_LastName_Id_Locator).
                       SendKeys(lastName.ToString());
                    //Fill the Email address
                    base.WaitForElement(By.Id(NewWorkspacePageResource.
                        NewWorkspace_Page_CreateWorkspace_Email_Id_Locator));
                    base.GetWebElementPropertiesById(NewWorkspacePageResource.
                        NewWorkspace_Page_CreateWorkspace_Email_Id_Locator).Clear();
                    base.GetWebElementPropertiesById(NewWorkspacePageResource.
                        NewWorkspace_Page_CreateWorkspace_Email_Id_Locator).
                       SendKeys(NewWorkspacePageResource.
                       NewWorkspace_Page_CreateWorkspace_Email_Value);
                    break;
            }
            logger.LogMethodExit("NewWorkspacePage", "EnterFirstAndLastNameDetails",
                base.IsTakeScreenShotDuringEntryExit); ;
        }

        /// <summary>
        /// Click The Save Button In Create Workspace Popup
        /// </summary>
        private void ClickTheSaveButtonInCreateWorkspacePopup()
        {
            //Click The Save Button In Create Workspace Popup
            logger.LogMethodEntry("NewWorkspacePage", "ClickTheSaveButtonInCreateWorkspacePopup",
                base.IsTakeScreenShotDuringEntryExit);
            //Wait for the save button element
            base.WaitForElement(By.Id(NewWorkspacePageResource.
                NewWorkspace_Page_CreateWorkspace_SaveUpdate_Btn_Id_Locator));
            IWebElement getSaveButton = base.GetWebElementPropertiesById
                (NewWorkspacePageResource.
                NewWorkspace_Page_CreateWorkspace_SaveUpdate_Btn_Id_Locator);
            //Click the save button
            base.ClickByJavaScriptExecutor(getSaveButton);
            Thread.Sleep(Convert.ToInt32(NewWorkspacePageResource.
                NewWorkspace_Page_CreateWorkspace_SaveUpdate_TimeValue));
            base.IsPopUpClosed(2);
            //Switch Default Window
            base.SwitchToDefaultWindow();
            logger.LogMethodExit("NewWorkspacePage", "ClickTheSaveButtonInCreateWorkspacePopup",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Is Displayed The TextBox Fields In Edit Workspace
        /// </summary>
        /// <returns>Displayed TextBox Fields value</returns>
        private Boolean IsDisplayedTheTextBoxFieldsInEditWorkspace()
        {
            // Is Displayed The TextBox Fields In Edit Workspace
            logger.LogMethodEntry("NewWorkspacePage", "IsDisplayedTheTextBoxFieldsInEditWorkspace",
                base.IsTakeScreenShotDuringEntryExit);
            //Is 'Title' textbox Displayed
            bool isTitleDisplayed = base.IsElementPresent(By.Id
                (NewWorkspacePageResource.NewWorkspace_Page_CreateWorkspace_Title_Id_Locator));
            //Is 'Description' textbox Displayed
            bool isDescriptionDisplayed = base.IsElementPresent(By.Id
                (NewWorkspacePageResource.NewWorkspace_Page_CreateWorkspace_Description_Id_Locator));
            //Is 'UserName' textbox Displayed
            bool isUserNameDisplayed = base.IsElementPresent(By.Id
                (NewWorkspacePageResource.NewWorkspace_Page_CreateWorkspace_UserName_Id_Locator));
            //Is 'Password' textbox Displayed
            bool isPasswordDisplayed = base.IsElementPresent(By.Id
                (NewWorkspacePageResource.NewWorkspace_Page_CreateWorkspace_ResetPassword_Id_Locator));
            //Is 'FirstName' textbox Displayed
            bool isFirstNameDisplayed = base.IsElementPresent(By.Id
                (NewWorkspacePageResource.NewWorkspace_Page_CreateWorkspace_FirstName_Id_Locator));
            //Is 'LastName' textbox Displayed
            bool isLastNameDisplayed = base.IsElementPresent(By.Id
                (NewWorkspacePageResource.NewWorkspace_Page_CreateWorkspace_LastName_Id_Locator));
            //Is 'Email' textbox Displayed
            bool isEmailDisplayed = base.IsElementPresent(By.Id
                (NewWorkspacePageResource.NewWorkspace_Page_CreateWorkspace_Email_Id_Locator));
            //Is 'Update' textbox Displayed
            bool isUpdateDisplayed = base.IsElementPresent(By.Id
                (NewWorkspacePageResource.NewWorkspace_Page_CreateWorkspace_SaveUpdate_Btn_Id_Locator));
            logger.LogMethodExit("NewWorkspacePage", "IsDisplayedTheTextBoxFieldsInEditWorkspace",
            base.IsTakeScreenShotDuringEntryExit);
            return (isTitleDisplayed && isDescriptionDisplayed && isUserNameDisplayed &&
                isPasswordDisplayed && isFirstNameDisplayed && isLastNameDisplayed &&
                isEmailDisplayed && isUpdateDisplayed);
        }

        /// <summary>
        /// Is Displayed Of Textbox In EditWorkspace
        /// </summary>
        /// <returns></returns>
        public Boolean IsDisplayedOfTextboxInEditWorkspace()
        {
            //Displayed Of Textbox In EditWorkspace
            logger.LogMethodEntry("NewWorkspacePage", "IsDisplayedOfTextboxInEditWorkspace",
                base.IsTakeScreenShotDuringEntryExit);
            //Initializing the Variable
            bool isDefaultTextboxsDisplayed = false;
            try
            {
                //Wairt for the window
                base.WaitUntilWindowLoads(NewWorkspacePageResource.
                    NewWorkspace_Page_EditWorkspace_Window_Name);
                base.SelectWindow(NewWorkspacePageResource.
                    NewWorkspace_Page_EditWorkspace_Window_Name);
                //  Is Displayed The TextBox Fields In Edit Workspace
                isDefaultTextboxsDisplayed = this.IsDisplayedTheTextBoxFieldsInEditWorkspace();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("NewWorkspacePage", "IsDisplayedOfTextboxInEditWorkspace",
                base.IsTakeScreenShotDuringEntryExit);
            return isDefaultTextboxsDisplayed;
        }

        /// <summary>
        /// Create and Update The Workspace
        /// </summary>
        /// <param name="adminWorkspaceType">This is Admin workspace type</param>
        /// <param name="workspaceName">This is user type by enum</param>
        public void CreateAndUpdateTheWorkspace(AdminToolPage.AdminWorkspaceTypeEnum adminWorkspaceType,
            WorkSpace.WorkSpaceTypeEnum workspaceName)
        {
            //Create and Update The Workspace
            logger.LogMethodEntry("NewWorkspacePage", "CreateAndUpdateTheWorkspace",
                base.IsTakeScreenShotDuringEntryExit);
            //Intialize Guid for workspace
            Guid workspaceUserName = Guid.NewGuid();
            try
            {
                switch (adminWorkspaceType)
                {
                    case AdminToolPage.AdminWorkspaceTypeEnum.Create:
                        //Select Window
                        base.SelectWindow(NewWorkspacePageResource.
                            NewWorkspace_Page_CTG_CreateWorkspace_Window_Name);
                        //Fill the title
                        base.WaitForElement(By.Id(NewWorkspacePageResource.
                            NewWorkspace_Page_CreateWorkspace_Title_Id_Locator));
                        base.GetWebElementPropertiesById(NewWorkspacePageResource.
                            NewWorkspace_Page_CreateWorkspace_Title_Id_Locator).Clear();
                        base.GetWebElementPropertiesById(NewWorkspacePageResource.
                           NewWorkspace_Page_CreateWorkspace_Title_Id_Locator).
                           SendKeys(workspaceUserName.ToString());
                        break;
                }
                //Fill UserName Details
                this.FillUserNameDetails(workspaceUserName.ToString(), adminWorkspaceType);
                //Enter FirstName and lastName details
                this.EnterFirstAndLastNameDetails
                    (workspaceUserName.ToString(), workspaceUserName.ToString(), adminWorkspaceType);
                //Click Save Button
                this.ClickTheSaveButtonInCreateWorkspacePopup();
                //Store User Details in Memory
                StoreWorkspaceDetailsInMemory(workspaceName, workspaceUserName);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("NewWorkspacePage", "CreateAndUpdateTheWorkspace",
                base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
