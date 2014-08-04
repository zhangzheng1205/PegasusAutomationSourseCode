using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Admin.Enrollment;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus User Enrollment Page Actions
    /// </summary>
    public class UserEnrollmentPage : BasePage
    {
        /// <summary>
        /// The Static Instance Of The Logger For The Class
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(UserEnrollmentPage));

        /// <summary>
        /// Get The Last Name Of The Enrolled User
        /// </summary>        
        /// <param name="expectedLastName">This Is The Expected 
        /// Last Name Of the User</param>
        /// <returns>Last Name Of The Enrolled User</returns>
        public String GetEnrolledUserLastName(string expectedLastName)
        {
            //Get The Last Name Of The Enrolled User
            logger.LogMethodEntry("UserEnrollmentPage", "GetEnrolledUserLastName",
                base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable To Get Last Name Of The User
            string getLastName = string.Empty;
            try
            {
                //Select Default Window
                base.SelectDefaultWindow();
                //Select The Right Frame
                base.SwitchToIFrame(UserEnrollmentPageResource
                        .UserEnrollment_Page_RightFrame_Id_Locator);
                //Get The Count Of Users Enrolled In The Course
                int getUserCount = base.GetElementCountByXPath(UserEnrollmentPageResource.
                    UserEnrollment_Page_RowCountOfUsers_Xpath_Locator);
                //Get User Last Name
                getLastName = this.GetUserLastName(getUserCount, expectedLastName);
                //Switch To Default Page Content
                base.SwitchToDefaultPageContent();
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserEnrollmentPage", "GetEnrolledUserLastName",
                base.IsTakeScreenShotDuringEntryExit);
            //Return Last Name Of The User
            return getLastName;
        }

        /// <summary>
        /// Get The Last Name Of The User Enrolled In The Course
        /// </summary>
        /// <param name="getUserCount">This Is The Total number Of 
        /// Users Enrolled InThe Course</param>
        /// <param name="expectedLastName">This Is The Expected Last name 
        /// Of The Enrolled User</param>
        /// <returns>Last Name Of The User</returns>
        private String GetUserLastName(int getUserCount, string expectedLastName)
        {
            //Get Last Name Of User
            logger.LogMethodEntry("UserEnrollmentPage", "GetUserLastName",
               base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getLastName = string.Empty;
            for (int rowCount = Convert.ToInt32(
                UserEnrollmentPageResource.UserEnrollment_Page_InitialRowCount_Value);
                rowCount <= getUserCount; rowCount++)
            {
                //Get The Last Name Of The User From The Table
                getLastName = base.GetTitleAttributeValueByXPath
                    (string.Format(UserEnrollmentPageResource.
                    UserEnrollment_Page_UserLastName_Xpath_Locator, rowCount));
                //Check If The Expected Last Name Is Displayed
                if (expectedLastName == getLastName)
                {
                    break;
                }
            }
            logger.LogMethodExit("UserEnrollmentPage", "GetUserLastName",
               base.IsTakeScreenShotDuringEntryExit);
            //Return Last Name
            return getLastName;
        }

        /// <summary>
        /// Select the User in the Right Frame
        /// </summary>
        /// <param name="expectedLastName">This is Expected Last Name</param>
        public void SelectUserInRightFrame(string expectedLastName)
        {
            //Select the User In the Right Frame
            logger.LogMethodEntry("UserEnrollmentPage", "SelectUserInRightFrame",
              base.IsTakeScreenShotDuringEntryExit);
            //Initialize Variable
            string getLastName = string.Empty;
            try
            {
                //Select Course Enrollement Window
                base.SelectWindow(UserEnrollmentPageResource.
                        UserEnrollement_Page_CourseEnrollment_Window_Name);
                base.WaitForElement(By.Id(UserEnrollmentPageResource.
                    UserEnrollment_Page_RightFrame_Id_Locator));
                //Switch to Right Frame
                base.SwitchToIFrame(UserEnrollmentPageResource.
                    UserEnrollment_Page_RightFrame_Id_Locator);
                //get Total User Count
                int getUserCount = base.GetElementCountByXPath(UserEnrollmentPageResource.
                    UserEnrollment_Page_RowCountOfUsers_Xpath_Locator);
                for (int rowCount = Convert.ToInt32(
                    UserEnrollmentPageResource.UserEnrollment_Page_InitialRowCount_Value);
                    rowCount <= getUserCount; rowCount++)
                {
                    //Get The Last Name Of The User From The Table
                    getLastName = base.GetTitleAttributeValueByXPath
                        (String.Format(UserEnrollmentPageResource.
                        UserEnrollment_Page_UserLastName_Xpath_Locator, rowCount));
                    //Check If The Expected Last Name Is Displayed
                    if (expectedLastName == getLastName)
                    {
                        IWebElement getCheckBoxProperty = base.GetWebElementPropertiesByXPath
                            (String.Format(UserEnrollmentPageResource.
                            UserEnrollment_Page_UserName_Checkbox_Xpath_Locator, rowCount));
                        base.ClickByJavaScriptExecutor(getCheckBoxProperty);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("UserEnrollmentPage", "SelectUserInRightFrame",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click On Un Enroll Select Users Option
        /// </summary>
        public void ClickOnUnEnrollSelectedUsersOption()
        {
            //Click On Un Enroll Select Users option 
            logger.LogMethodEntry("UserEnrollmentPage", "ClickOnUnEnrollSelectedUsersOption",
              base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Wait for Un Enroll Select Users Option
                base.WaitForElement(By.Id(UserEnrollmentPageResource.
                       UserEnrollement_Page_UNEnrollSelecteduser_Id_Locator));
                IWebElement getlinkProperty = base.GetWebElementPropertiesById(UserEnrollmentPageResource.
                    UserEnrollement_Page_UNEnrollSelecteduser_Id_Locator);
                //Click on Un ENroll Seelct Usersd Option
                base.ClickByJavaScriptExecutor(getlinkProperty);
            }
            catch (Exception e )
            {
                ExceptionHandler.HandleException(e);                 
            }
            logger.LogMethodExit("UserEnrollmentPage", "ClickOnUnEnrollSelectedUsersOption",
           base.IsTakeScreenShotDuringEntryExit);
        }
    }
}
