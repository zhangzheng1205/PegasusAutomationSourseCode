using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Pages.Exceptions;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Program_Admin.Enrollment;
using System.Threading;
using Pegasus.Automation.DataTransferObjects;

namespace Pegasus.Pages.UI_Pages
{
    /// <summary>
    /// This class handles Pegasus Enrollment Main Page Actions
    /// </summary>
    public class EnrollmentMainPage : BasePage
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger logger = Logger.GetInstance(typeof(EnrollmentMainPage));

        /// <summary>
        /// Click Enroll Button
        /// </summary>
        public void ClickEnrollButton()
        {
            //Click on Enroll Button
            logger.LogMethodEntry("EnrollmentMainPage", "ClickEnrollButton",
               base.IsTakeScreenShotDuringEntryExit);
            try
            {
                new ProgramAdminToolPage().SelectFrame();
                //click enroll button
                base.WaitForElement(By.Id(EnrollmentMainPageResource.
                    EnrollmentMain_Page_EnrollButton_Id_Locator));
                //Click on Button
                base.ClickButtonById(EnrollmentMainPageResource.
                    EnrollmentMain_Page_EnrollButton_Id_Locator);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EnrollmentMainPage", "ClickEnrollButton",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on Add User Option link
        /// </summary>
        public void ClickonAddUserOption(string addUserOption)
        {
            // Click on Add User Option link
            logger.LogMethodEntry("EnrollmentMainPage", "ClickonAddUserOption",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select Add User Option link
                base.WaitForElement(By.PartialLinkText(addUserOption));
                //Click on Link
                base.ClickLinkByPartialLinkText(addUserOption);
                //Thread value
                Thread.Sleep(Convert.ToInt32
                    (ProgramAdminManageCourseTemplatesPageResource
                    .ProgramAdminManageCourseTemplates_Page_ThreadTime_Value));
                //switch to window
                base.SwitchToDefaultPageContent();
                base.SelectWindow(ProgramAdminManageCourseTemplatesPageResource
                    .ProgramAdminManageCourseTemplates_Page_Window_Title_Name);

            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EnrollmentMainPage", "ClickonAddUserOption",
                          base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Search Section at Enrollment Tab.
        /// Author:Rashmi Shetty.
        /// Date:6/Apr/2016.
        /// </summary>
        /// <param name="courseTypeEnum">Section Name.</param>
        public void SearchSectionAtEnrollmentTab(Course.CourseTypeEnum courseTypeEnum)
        {
            // Search Section at Enrollment Tab.
            logger.LogMethodEntry("EnrollmentMainPage", "SearchSectionAtEnrollmentTab",
                            base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Get the Section Name
                Course course = Course.Get(courseTypeEnum);
                String sectionName = course.SectionName.ToString();
                //Select the window and switch to parent frame
                new ProgramAdminToolPage().SelectFrame();
                //Switch to child frame
                base.SwitchToIFrame(EnrollmentMainPageResource.
                    ProgramAdministration_Enrollment_RightFrame_Id_Locator);
                // Search Section at Enrollment Tab
                base.WaitForElement(By.PartialLinkText(EnrollmentMainPageResource.
                    ProgramAdministration_Enrollment_SearchLink_LinkText_Locator));
                //Get Element Property
                IWebElement getLinkProperty = base.GetWebElementPropertiesByLinkText
                    (EnrollmentMainPageResource.
                    ProgramAdministration_Enrollment_SearchLink_LinkText_Locator);
                //Click on The Search Link
                base.ClickByJavaScriptExecutor(getLinkProperty);
                base.WaitForElement(By.Id(EnrollmentMainPageResource.
                    ProgramAdministration_Enrollment_SearchCondition_Id_Locator));
                //Selecting the Entity by entity details
                new ManageTemplatePage().SelectTemplate(sectionName);
                //Click on section link to Enroll Users
                IWebElement sectionLink = base.GetWebElementPropertiesByCssSelector(
                                       EnrollmentMainPageResource.
                                       ProgramAdministration_Enrollment_SearchedSection_CSSSelector_Locator);
                Thread.Sleep(2000);
                base.ClickByJavaScriptExecutor(sectionLink);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EnrollmentMainPage", "SearchSectionAtEnrollmentTab",
                         base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Select the User to be Enrolled.
        /// Author:Rashmi Shetty.
        /// Date:6/Apr/2016.
        /// </summary>
        /// <param name="userTypeEnum">This is the user type.</param>
        public void SelectUserForEnrollment(String userName, String userType)
        {
            // Select the User to be Enrolled
            logger.LogMethodEntry("EnrollmentMainPage", "SelectUserForEnrollment",
                           base.IsTakeScreenShotDuringEntryExit);
            try
            {
                //Select the window and switch to parent frame
                new ProgramAdminToolPage().SelectFrame();
                //Switch to child frame
                base.SwitchToIFrame(EnrollmentMainPageResource.
                    ProgramAdministration_Enrollment_LeftFrame_Id_Locator);
                //Get the number of users available for enrollment
                base.WaitForElement(By.CssSelector(EnrollmentMainPageResource.
                    ProgramAdministration_Enrollment_UserCount_CSSSelector_Locator));
                int userCount = base.GetElementCountByCssSelector(EnrollmentMainPageResource.
                    ProgramAdministration_Enrollment_UserCount_CSSSelector_Locator);
                //Iterate to search the expected user
                SelectTheUser(userName, userCount);
                //Select the window and switch to parent frame
                new ProgramAdminToolPage().SelectFrame();
                //Enroll the selected user to the section
                AddSelectedUserToSection(userType);
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            logger.LogMethodExit("EnrollmentMainPage", "SelectUserForEnrollment",
                        base.IsTakeScreenShotDuringEntryExit);

        }

        /// <summary>
        /// To Select the expected user.
        /// Author:Rashmi Shetty.
        /// Date:6/Apr/2016.
        /// </summary>
        /// <param name="userName">This is the user enum</param>
        /// <param name="userCount">This is number of users</param>
        private void SelectTheUser(String userName, int userCount)
        {
            logger.LogMethodEntry("EnrollmentMainPage", "SelectTheUser",
                       base.IsTakeScreenShotDuringEntryExit);
            // To Select the expected user
            for (int i = 1; i <= userCount; i++)
            {
                base.WaitForElement(By.CssSelector(string.Format
                    (EnrollmentMainPageResource.
                    ProgramAdministration_Enrollment_nthrowuser_CSSSelector_Locator, i)));
                //Get the user name of each user with iteration
                string userNameActual = base.GetElementInnerTextByCssSelector
                   (string.Format
                    (EnrollmentMainPageResource.
                    ProgramAdministration_Enrollment_nthrowuser_CSSSelector_Locator, i));
                //Match actual username with expected
                if (userNameActual == userName)
                {
                    //Select user if actual username matches with expected
                    IWebElement userCheckBox = base.GetWebElementPropertiesByCssSelector(string.Format
                         (EnrollmentMainPageResource.
                         ProgramAdministration_Enrollment_nthrowusercheckbox_CSSSelector_Locator, i));
                    Thread.Sleep(2000);
                    base.ClickByJavaScriptExecutor(userCheckBox);
                    //Switch out of the frames
                    base.SwitchToDefaultPageContent();
                    break;
                }
            }
            logger.LogMethodExit("EnrollmentMainPage", "SelectTheUser",
                           base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Add the selected user as teacher or as student.
        /// Author:Rashmi Shetty.
        /// Date:6/Apr/2016.
        /// </summary>
        /// <param name="userType">This is user enum.</param>
        private void AddSelectedUserToSection(String userType)
        {
            logger.LogMethodEntry("EnrollmentMainPage", "AddSelectedUserToSection",
                         base.IsTakeScreenShotDuringEntryExit);
            // Add the selected user as teacher or as student       
            IWebElement addUserButton = base.GetWebElementPropertiesByCssSelector
                    (EnrollmentMainPageResource.
                    ProgramAdministration_Enrollment_AddUserButton_CSSSelector_Locator);
            Thread.Sleep(2000);
            base.ClickByJavaScriptExecutor(addUserButton);
            //Select usertype on enrollment
            switch (userType)
            {
                //Enroll Student for MIL product
                case "CsSmsStudent":
                case "WLCsSmsStudent":
                case "HSSCsSmsStudent":
                    IWebElement addStudent = base.GetWebElementPropertiesByLinkText(EnrollmentMainPageResource.
                        ProgramAdministration_Enrollment_AddStudentUserOption_LinkText_Locator);
                    Thread.Sleep(2000);
                    base.ClickByJavaScriptExecutor(addStudent);
                    break;
                //EnrollInstructor for MIL product
                case "CsSmsInstructor":
                case "WLCsSmsInstructor":
                case "HSSCsSmsInstructor":
                    IWebElement addInstructor = base.GetWebElementPropertiesByLinkText(EnrollmentMainPageResource.
                        ProgramAdministration_Enrollment_AddInstructorUserOption_LinkText_Locator);
                    Thread.Sleep(2000);
                    base.ClickByJavaScriptExecutor(addInstructor);
                    break;
                    //Switch out of the frames
                    base.SwitchToDefaultPageContent();

                    logger.LogMethodExit("EnrollmentMainPage", "AddSelectedUserToSection",
                                    base.IsTakeScreenShotDuringEntryExit);
            }
        }
    }
}
