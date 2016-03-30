using System;
using System.Threading;
using OpenQA.Selenium;
using Pegasus.Pages.UI_Pages.Integration.Contineo;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    public class PowerTeacherHomePage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PowerTeacherHomePage));

        /// <summary>
        /// Validate Power School User login
        /// </summary>
        /// <param name="userTypeEnum">This is user by type</param>
        /// <returns>Login Success Status</returns>
        public Boolean ValidatePowerSchoolUserLogin(User.UserTypeEnum userTypeEnum)
        {
            //PowserSchool User login validation
            Logger.LogMethodEntry("PowerTeacherHomePage", "ValidatePowerSchoolUserLogin",
                base.IsTakeScreenShotDuringEntryExit);
            //Check Is Login Sucessful
            //Check Is Login Sucessful
            bool isLoginSuccessful = base.IsElementPresent(By.XPath
                ("//a[@id='btnLogout']"), 10);
            Logger.LogMethodEntry("PowerTeacherHomePage", "ValidatePowerSchoolUserLogin",
                  base.IsTakeScreenShotDuringEntryExit);
            return isLoginSuccessful;
        }

        /// <summary>
        /// Click on the Applications Icon In Power School.
        /// </summary>
        /// <param name="userTypeEnum">This to get the type of user</param>
        public void ClickApplicationsIcon(User.UserTypeEnum userTypeEnum)
        {
            //PowserSchool User login validation
            Logger.LogMethodEntry("PowerTeacherHomePage", "ClickApplicationsIcon",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for element to load
                base.WaitForElement(By.Id(PowerTeacherHomePageResource.
                    PowerTeacherHomePage_Applications_Icon_Id_Locator), 10);
                IWebElement ApplicationsIcon = base.GetWebElementPropertiesById
                    (PowerTeacherHomePageResource.
                    PowerTeacherHomePage_Applications_Icon_Id_Locator);
                //Click on the Applications Icon
                base.ClickByJavaScriptExecutor(ApplicationsIcon);
                Logger.LogMethodEntry("PowerTeacherHomePage", "ClickApplicationsIcon",
                  base.IsTakeScreenShotDuringEntryExit);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
        }

        /// <summary>
        /// Verify if Pearson Courses Link is Present.
        /// </summary>
        public Boolean IsPearsonCoursesLinkPresent()
        {
            Logger.LogMethodEntry("PowerTeacherHomePage", "IsPearsonCoursesLinkPresent",
                base.IsTakeScreenShotDuringEntryExit);
            bool isLinkPresent = false;
            try
            {
                //Check is link is present
                isLinkPresent = base.IsElementPresent(By.Id(
                        PowerTeacherHomePageResource.
                        PowerTeacherHomePage_PearsonCourses_Id_Locator), 10);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("PowerTeacherHomePage", "IsPearsonCoursesLinkPresent",
                  base.IsTakeScreenShotDuringEntryExit);
            return isLinkPresent;
        }

        /// <summary>
        /// Click on Pearson Courses link.
        /// </summary>
        public void ClickPearsonCourses()
        {
            // Click on Pearson Courses link.
            Logger.LogMethodEntry("PowerTeacherHomePage", "IsPearsonCoursesLinkPresent",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get link property
                IWebElement pearsonCoursesLink = base.GetWebElementPropertiesById(
                    PowerTeacherHomePageResource.
                    PowerTeacherHomePage_PearsonCourses_Id_Locator);
                //Click the link
                base.ClickByJavaScriptExecutor(pearsonCoursesLink);
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("PowerTeacherHomePage", "IsPearsonCoursesLinkPresent",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Close Applications Drawer Panel as Contineo user
        /// </summary>
        /// <param name="userTypeEnum">This is user type based on user role.</param>
        public void CloseApplicationsDrawerPanel()
        {
            // Close Applications Drawer Panel as Contineo user
            Logger.LogMethodEntry("PowerTeacherHomePage", "CloseApplicationsDrawerPanel",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for the Close link in Applications panel
                base.WaitForElement(By.Id(PowerTeacherHomePageResource.
                    PowerTeacherHomePage_Close_Applications_Id_Locator), 10);
                //Click on the Close link
                base.ClickLinkById(PowerTeacherHomePageResource.
                    PowerTeacherHomePage_Close_Applications_Id_Locator);
                base.IsWindowsExists(PowerTeacherHomePageResource.
                    PowerTeacherHomePage_Window_Title, 10);
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }

            Logger.LogMethodExit("PowerTeacherHomePage", "CloseApplicationsDrawerPanel",
                  base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Sign Out from Power School.
        /// </summary>
        /// <param name="userTypeEnum">This is user type based on user role</param>
        public void SignOutfromPowerSchool(User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("PowerTeacherHomePage", "SignOutfromPowerSchool",
                base.IsTakeScreenShotDuringEntryExit);
            //Sign Out from Power School
            try
            {
                base.WaitForElement(By.Id(PowerTeacherHomePageResource.
                    PowerTeacherHomePage_SignOut_Link_Id_Locator), 10);
                base.ClickLinkById(PowerTeacherHomePageResource.
                    PowerTeacherHomePage_SignOut_Link_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("PowerTeacherHomePage", "SignOutfromPowerSchool",
                  base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
