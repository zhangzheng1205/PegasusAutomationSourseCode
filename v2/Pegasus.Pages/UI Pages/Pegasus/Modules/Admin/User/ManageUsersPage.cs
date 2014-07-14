using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.User;
using Pegasus.Pages.Exceptions;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System.Text.RegularExpressions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This Class handles Manage Users page Actions
    /// </summary>
    public class ManageUsersPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ManageUsersPage));

        /// <summary>
        /// This is User Cmenu Options
        /// </summary>
        public enum UserCmenuOption
        {
            /// <summary>
            /// This is User Information Option
            /// </summary>
            UserInformation = 1,
            /// <summary>
            /// This is Edit Option
            /// </summary>
            Edit = 2,
            /// <summary>
            /// This is Delete Option
            /// </summary>
            Delete = 3,
            /// <summary>
            /// This is Deny Access Option
            /// </summary>
            DenyAccess = 4,
            /// <summary>
            /// This is Grant Access Option
            /// </summary>
            Grantaccess
        }



        /// <summary>
        ///  Select User From The Left Frame
        /// </summary>
        /// <param name="userName">This Is UserName</param>
        public void SelectUser(string userName)
        {
            // Select User From The Left Frame
            logger.LogMethodEntry("ManageUsersPage", "SelectUser",
                base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Wait For element
                base.WaitForElement(By.Id(ManageUsersPageResource.
                        ManageUsers_Page_LeftFrame_Id_Locator));
                // Switch to left frame
                base.SwitchToIFrame(ManageUsersPageResource.
                    ManageUsers_Page_LeftFrame_Id_Locator);
                //Wait for element
                base.WaitForElement(By.Id(ManageUsersPageResource.
                    ManageUsers_Page_GridUser_Id_Locator));
                //Wait For Element
                base.WaitForElement(By.Id(ManageUsersPageResource.
                    ManageUsers_Page_GridUserRight_Id_Locator));
                IWebElement getUserSelector = base.GetWebElementPropertiesById
                    (ManageUsersPageResource.
                    ManageUsers_Page_GridUserRight_Id_Locator);
                base.ClickByJavaScriptExecutor(getUserSelector);
                //Wait Delete Link to get Enabled
                //base.WaitForElement(By.Id(ManageUsersPageResource.
                //    ManageUsers_Page_DeleteUserLink_Id_Locator));
                base.SwitchToDefaultWindow();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUsersPage", "SelectUser",
                base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get the User Name
        /// </summary>
        /// <returns>Searched User Name</returns>
        public String GetSearchedUserName()
        {
            //Get the User Name
            logger.LogMethodEntry("ManageUsersPage", "GetSearchedUserName",
                base.isTakeScreenShotDuringEntryExit);
            //Initializing the variable
            String getUserName = string.Empty;
            try
            {
                //Select the Default Window
                base.SelectDefaultWindow();
                //Wait For Left frame
                base.WaitForElement(By.Id(ManageUsersPageResource.
                        ManageUsers_Page_LeftFrame_Id_Locator));
                // Switch to Left frame
                base.SwitchToIFrame(ManageUsersPageResource.
                    ManageUsers_Page_LeftFrame_Id_Locator);
                base.WaitForElement(By.Id(ManageUsersPageResource.
                    ManageUsers_Page_GridUser_Id_Locator));
                //Get the User Name
                getUserName = base.GetTitleAttributeValueByXPath(ManageUsersPageResource.
                    ManageUsersPage_SearchedUserName_Title_Xpath_Locator);
                //Switch To Default Page Content
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUsersPage", "GetSearchedUserName",
                base.isTakeScreenShotDuringEntryExit);
            //Returns User Name
            return getUserName;
        }

        /// <summary>
        /// Click On User Cmenu Link Icon
        /// </summary>
        public void ClickOnUserCmenuLinkIcon()
        {
            //Click On User Cmenu Link Icon
            logger.LogMethodEntry("ManageUsersPage", "ClickOnUserCmenuLinkIcon"
                , base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select the Default Window
                base.SelectDefaultWindow();
                //Wait For Left frame
                base.WaitForElement(By.Id(ManageUsersPageResource.
                        ManageUsers_Page_LeftFrame_Id_Locator));
                //Switch to Left frame
                base.SwitchToIFrame(ManageUsersPageResource.
                    ManageUsers_Page_LeftFrame_Id_Locator);
                base.WaitForElement(By.Id(ManageUsersPageResource.
                    ManageUsers_Page_GridUser_Id_Locator));
                //Wait for the Cmenu Icon to Display
                base.WaitForElement(By.XPath(ManageUsersPageResource.
                    ManageUsersPage_SearchedUser_CMenu_Icon_Xpath_Locator));
                IWebElement getCmenuOption=base.GetWebElementPropertiesByXPath
                    (ManageUsersPageResource.
                    ManageUsersPage_SearchedUser_CMenu_Icon_Xpath_Locator);
                //Click on the CMenu Icon
                base.ClickByJavaScriptExecutor(getCmenuOption);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUsersPage", "ClickOnUserCmenuLinkIcon"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Check If the User CMenu Options are Displayed
        /// </summary>
        /// <returns>Cmenu options</returns>
        public String GetCMenuOptionsOfUser()
        {
            //Check If the User CMenu Options are Displayed
            logger.LogMethodEntry("ManageUsersPage", "GetUserCMenuOptions"
                , base.isTakeScreenShotDuringEntryExit);
            //Initialize the Variable
            string getContextMenus = string.Empty;
            try
            {
                //Wait for the CMenu options to be displayed
                base.WaitForElement(By.Id(ManageUsersPageResource.
                    ManageUsersPage_CMenu_Options_Division_Id_Locator));
                String getDivText = base.GetElementTextByXPath(ManageUsersPageResource
                    .ManageUsersPage_Cmenu_Div_Xpath_Locator);
                // Get the trimmed context menu text
                getContextMenus = Regex.Replace(getDivText, @"\r\n\s*", string.Empty).Trim();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUsersPage", "GetUserCMenuOptions"
                , base.isTakeScreenShotDuringEntryExit);
            return getContextMenus;
        }

        /// <summary>
        /// Select the cmenu Options
        /// </summary>
        /// <param name="cmenuOption">This is cmenu Option</param>
        public void SelectCmenuOption(UserCmenuOption cmenuOption)
        {
            //Select Cmenu Option
            logger.LogMethodEntry("ManageUsersPage", "SelectCmenuOption"
                , base.isTakeScreenShotDuringEntryExit);
            try
            {
                //Select Administration Tool Window
                //Select the Default Window
                base.SelectDefaultWindow();
                base.WaitForElement(By.Id(ManageUsersPageResource.
                    ManageUsers_Page_LeftFrame_Id_Locator));
                //Switch To Frame
                base.SwitchToIFrame(ManageUsersPageResource.
                    ManageUsers_Page_LeftFrame_Id_Locator);
                switch (cmenuOption)
                {
                    case UserCmenuOption.UserInformation:
                        //Select User Information Option
                        this.SelectUserInformationOption();
                        break;

                    case UserCmenuOption.Delete:
                        //Select Delete Option
                        this.SelectDeleteOption();
                        break;

                    case UserCmenuOption.Edit:
                        //Select Edit Option
                        this.SelectEditOption(cmenuOption);
                        break;

                    case UserCmenuOption.DenyAccess:
                        //Select Deny Access Option
                        this.SelectDenyAccessOption();
                        break;

                    case UserCmenuOption.Grantaccess:
                        //Select Grant Access Option
                        this.SelectGrantAccessOption();
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUsersPage", "SelectCmenuOption"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Edit Option
        /// </summary>
        /// <param name="cmenuOption">This is Cmenu Option</param>
        private void SelectEditOption(UserCmenuOption cmenuOption)
        {
            logger.LogMethodEntry("ManageUsersPage", "SelectEditOption"
                , base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(cmenuOption.ToString()));
            base.ClickButtonByPartialLinkText(cmenuOption.ToString());
            logger.LogMethodExit("ManageUsersPage", "SelectEditOption"
                , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Deny Access Option
        /// </summary>
        private void SelectDenyAccessOption()
        {
            //Select Deny Access Option
            logger.LogMethodEntry("ManageUsersPage", "SelectDenyAccessOption"
                , base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(ManageUsersPageResource.
                ManageUsersPage_CMenuOption_DenyAccess_Link_Text));
            //Click On Deny Access
            base.ClickButtonByPartialLinkText(ManageUsersPageResource.
                ManageUsersPage_CMenuOption_DenyAccess_Link_Text);
            logger.LogMethodExit("ManageUsersPage", "SelectDenyAccessOption"
            , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Grant Access Option
        /// </summary>
        private void SelectGrantAccessOption()
        {
            //Select Grant Access Option
            logger.LogMethodEntry("ManageUsersPage", "SelectGrantAccessOption"
             , base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(ManageUsersPageResource.
                ManageUsersPage_CMenuOption_GrantAccess_Link_Text));
            //Click On Grant Access Option
            base.ClickButtonByPartialLinkText(ManageUsersPageResource.
                ManageUsersPage_CMenuOption_GrantAccess_Link_Text);
            logger.LogMethodExit("ManageUsersPage", "SelectGrantAccessOption"
            , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select Delete Option
        /// </summary>
        private void SelectDeleteOption()
        {
            //Select Delete Option
            logger.LogMethodEntry("ManageUsersPage", "SelectDeleteOption"
             , base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.XPath(ManageUsersPageResource.
                ManagerUsersPage_DeleteOption_Xpath_Locator));
            IWebElement getDeleteCmenu = base.GetWebElementPropertiesByXPath
                (ManageUsersPageResource.
                ManagerUsersPage_DeleteOption_Xpath_Locator);
            //Click On Delete Option
            base.ClickByJavaScriptExecutor(getDeleteCmenu);
            logger.LogMethodExit("ManageUsersPage", "SelectDeleteOption"
            , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select User Information Option
        /// </summary>
        private void SelectUserInformationOption()
        {
            //Select User Information Option
            logger.LogMethodEntry("ManageUsersPage", "SelectUserInformationOption"
             , base.isTakeScreenShotDuringEntryExit);
            base.WaitForElement(By.PartialLinkText(ManageUsersPageResource.
                ManageUsersPage_CMenuOption_UserInformation_Link_Text));
            //Click on User Information Option
            base.ClickButtonByPartialLinkText(ManageUsersPageResource.
                ManageUsersPage_CMenuOption_UserInformation_Link_Text);
            logger.LogMethodExit("ManageUsersPage", "SelectUserInformationOption"
            , base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Delete The Created User In Manage User Frame.
        /// </summary>
        public void DeleteTheCreatedUserInManageUserFrame()
        {
            //Delete The Created User In Manage User Frame
            logger.LogMethodEntry("ManageUsersPage",
                "DeleteTheCreatedUserInManageUserFrame"
             , base.isTakeScreenShotDuringEntryExit);
            try
            {
                this.ClickOnUserCmenuLinkIcon();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ManageUsersPage",
                "DeleteTheCreatedUserInManageUserFrame"
            , base.isTakeScreenShotDuringEntryExit);
        }
    }
}
