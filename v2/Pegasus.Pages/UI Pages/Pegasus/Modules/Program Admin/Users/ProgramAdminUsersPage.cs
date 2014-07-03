using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Users;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Searching of the User Actions
    /// </summary>
    public class ProgramAdminUsersPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(ProgramAdminUsersPage));

        /// <summary>
        /// To search user
        /// </summary>
        /// <param name="username">This is UserName</param>
        public void SearchUser(string username)
        {
            //Search User 
            logger.LogMethodEntry("ProgramAdminUsersPage", "SearchUser",
                base.isTakeScreenShotDuringEntryExit);
            base.SwitchToDefaultPageContent();
            //Select Window
            base.SelectWindow(ProgramAdminUsersPageResource.ProgramAdminUsers_Page_Window_Title_Name);
            base.WaitForElement(By.Id(ProgramAdminUsersPageResource.
                ProgramAdminUsers_Page_IFrame_Middle_Name_Id_Locator));
            base.SwitchToIFrame(ProgramAdminUsersPageResource.ProgramAdminUsers_Page_IFrame_Middle_Name_Id_Locator);
            //Click search link
            base.WaitForElement(By.PartialLinkText(ProgramAdminUsersPageResource.
                ProgramAdminUsers_Page_Search_Link_Locator));
            //Click on Button
            base.ClickButtonByPartialLinkText(ProgramAdminUsersPageResource.ProgramAdminUsers_Page_Search_Link_Locator);
            //Switch To Active Element of Page
            base.SwitchToActivePageElement();
            base.WaitForElement(By.Id(ProgramAdminUsersPageResource.
                ProgramAdminUsers_Page_SearchCondition_DropDown_Id_Locator));
            //Enter User Search Parameter
            EnterUserSearchParameter(username);
            logger.LogMethodExit("ProgramAdminUsersPage", "SearchUser",
               base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// //Enter Parameter To Search User
        /// </summary>
        /// <param name="username">This is user name</param>
        private void EnterUserSearchParameter(string username)
        {
            //Enter Parameter To Search User
            logger.LogMethodEntry("ProgramAdminUsersPage", "EnterUserSearchParameter",
                base.isTakeScreenShotDuringEntryExit);
            //Select contains option in dropdown menu
            base.WaitForElement(By.Id(ProgramAdminUsersPageResource
                .ProgramAdminUsers_Page_UserName_RadioButton_Id_Locator));
            //Click on user name radio button
            base.ClickButtonByID(ProgramAdminUsersPageResource
                .ProgramAdminUsers_Page_UserName_RadioButton_Id_Locator);
            base.WaitForElement(By.Id(ProgramAdminUsersPageResource.
                                          ProgramAdminUsers_Page_SectionDetail_TextBox_Id_Locator));
            // enter username search textbox field
            base.ClearTextByID(ProgramAdminUsersPageResource.ProgramAdminUsers_Page_SectionDetail_TextBox_Id_Locator);
            base.FillTextBoxByID(ProgramAdminUsersPageResource.
                                     ProgramAdminUsers_Page_SectionDetail_TextBox_Id_Locator, username);
            //Click search button
            base.WaitForElement(By.Id(ProgramAdminUsersPageResource.ProgramAdminUsers_Page_Search_Button_Id_Locator));
            base.ClickButtonByID(ProgramAdminUsersPageResource.ProgramAdminUsers_Page_Search_Button_Id_Locator);
            logger.LogMethodExit("ProgramAdminUsersPage", "EnterUserSearchParameter",
           base.isTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Get User Name
        /// </summary>
        /// <param name="username">This is User Name</param>
        /// <returns>User Name</returns>
        public String GetUserName(string username)
        {
            //Search User Present
            logger.LogMethodEntry("ProgramAdminUsersPage", "GetUserName",
                base.isTakeScreenShotDuringEntryExit);
            string getUserName = string.Empty;
            try
            {
                //Search User
                SearchUser(username);
                base.SelectWindow(ProgramAdminUsersPageResource.
                    ProgramAdminUsers_Page_Window_Title_Name);
                //Wait For Element
                base.WaitForElement(By.Id(ProgramAdminUsersPageResource.
                    ProgramAdminUsers_Page_IFrame_Middle_Name_Id_Locator));
                base.SwitchToIFrame(ProgramAdminUsersPageResource.
                    ProgramAdminUsers_Page_IFrame_Middle_Name_Id_Locator);
                //Get the User Name Text
                getUserName = base.GetElementTextByID(ProgramAdminUsersPageResource.
                    ProgramAdminUsers_Page_ProgramAdminGrid_Username_Id_Locator);
                base.SelectWindow(ProgramAdminUsersPageResource
                    .ProgramAdminUsers_Page_Window_Title_Name);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("ProgramAdminUsersPage", "GetUserName",
                base.isTakeScreenShotDuringEntryExit);
            return getUserName;
        }

    }
}
