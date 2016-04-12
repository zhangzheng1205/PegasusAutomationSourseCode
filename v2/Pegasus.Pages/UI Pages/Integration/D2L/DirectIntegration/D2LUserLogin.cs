using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Integration.D2L.DirectIntegration;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    public class D2LUserLogin : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(D2LUserLogin));

        /// <summary>
        /// D2L user login
        /// </summary>
        /// <param name="userType">This is the user type enum.</param>
        public void LoginToD2L(User.UserTypeEnum userType)
        {
            logger.LogMethodEntry("D2LUserLogin", "LoginToD2L", base.IsTakeScreenShotDuringEntryExit);
            // Select window
            base.WaitUntilWindowLoads(D2LUserLoginResource.
                D2LUserLogin_Page_Title_Name);
            base.SelectWindow(D2LUserLoginResource.
                D2LUserLogin_Page_Title_Name);

            User user = User.Get(userType);
            string userName = user.Name.ToString();
            string password = user.Password.ToString();


            // Enter username
            base.WaitForElement(By.Id(D2LUserLoginResource.
                D2LUserLogin_UserName_TextBox_ID_value));
            base.ClearTextById(D2LUserLoginResource.
                D2LUserLogin_UserName_TextBox_ID_value);
            base.FillTextBoxById(D2LUserLoginResource.
                D2LUserLogin_UserName_TextBox_ID_value, userName);

            // Enter password
            base.WaitForElement(By.Id(D2LUserLoginResource.
                D2LUserLogin_Password_TextBox_ID_value));
            base.ClearTextById(D2LUserLoginResource.
                D2LUserLogin_Password_TextBox_ID_value);
            base.FillTextBoxById(D2LUserLoginResource.
                D2LUserLogin_Password_TextBox_ID_value, password);

            // Click on login button
            base.WaitForElement(By.PartialLinkText(D2LUserLoginResource.
                D2LUserLogin_LoginButton_Name));
            base.ClickButtonByPartialLinkText("Log In");

            logger.LogMethodExit("D2LUserLogin", "LoginToD2L", base.IsTakeScreenShotDuringEntryExit);

        }

    }
}