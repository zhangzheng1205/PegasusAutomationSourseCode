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
    public class PowerSchoolHomePage : BasePage
    {
        /// <summary>
        /// Static instance of the logger
        /// </summary>
        private static readonly Logger Logger =
            Logger.GetInstance(typeof(PowerSchoolHomePage));

        /// <summary>
        /// Validate Power School User login
        /// </summary>
        /// <param name="userTypeEnum">This is user by type</param>
        /// <returns>Login Success Status</returns>
        public Boolean ValidatePowerSchoolUserLogin(User.UserTypeEnum userTypeEnum)
        {
            //PowserSchool User login validation
            Logger.LogMethodEntry("PowerSchoolHomePage", "ValidatePowerSchoolUserLogin",
                base.IsTakeScreenShotDuringEntryExit);
            //Check Is Login Sucessful
            bool isLoginSuccessful = base.IsElementPresent(By.XPath
                (PowerSchoolHomePageResource.
                PowerSchoolHomePage_Window_Name_Xpath_Locator), 10);
            Logger.LogMethodEntry("PowerSchoolHomePage", "ValidatePowerSchoolUserLogin",
                  base.IsTakeScreenShotDuringEntryExit);
            return isLoginSuccessful;
        }

        /// <summary>
        /// Click on Pearson Courses link.
        /// </summary>
        public void ClickPearsonCourses()
        {
            // Click on Pearson Courses link.
            Logger.LogMethodEntry("PowerSchoolHomePage", "IsPearsonCoursesLinkPresent",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get link property
                IWebElement pearsonCoursesLink = base.GetWebElementPropertiesById(
                    PowerSchoolHomePageResource.
                    PowerSchoolHomePage_PearsonCourses_Id_Locator);
                //Click the link
                base.ClickByJavaScriptExecutor(pearsonCoursesLink);
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodEntry("PowerSchoolHomePage", "IsPearsonCoursesLinkPresent",
                  base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
