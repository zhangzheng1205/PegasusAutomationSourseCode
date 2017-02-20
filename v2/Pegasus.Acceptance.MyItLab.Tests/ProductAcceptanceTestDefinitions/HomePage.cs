using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Pages;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Pages.UI_Pages.Pegasus.Modules.Discussion;
using System.Threading;
using OpenQA.Selenium;
using Pegasus.Pages.Exceptions;

namespace Pegasus.Acceptance.MyITLab.Tests.ProductAcceptanceTestDefinitions
{
    [Binding]
    public class HomePage : PegasusBaseTestFixture
    {
        /// <summary>
        /// This is the logger.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(TodaysView));


        /// <summary>
        /// Verify the channel existance in Home page 
        /// </summary>
        /// <param name="channelName">This is channel name.</param>
        /// <param name="pageTitle">This is Page title.</param>
        /// <param name="userType">This is user type enum.</param>
        [Then(@"I should be displayed with ""(.*)"" channel  on ""(.*)"" page as ""(.*)"" user")]
        public void DisplayedOfChannelInHomePage(string channelName, string pageTitle, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("HomePage", "DisplayedOfChannelInHomePage", base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (userType)
                {
                    // Get channel name from the application
                    case User.UserTypeEnum.CsSmsInstructor:
                        Logger.LogAssertion("DisplayedOfOptionInHeader",
                            ScenarioContext.Current.ScenarioInfo.
                           Title, () => Assert.AreEqual(channelName.ToLower(),
                               new HEDGlobalHomePage().
                               GetINSChannelDetails(pageTitle, channelName)));
                        break;
                    case User.UserTypeEnum.CsSmsStudent:
                        Logger.LogAssertion("DisplayedOfOptionInHeader",
                            ScenarioContext.Current.ScenarioInfo.
                        Title, () => Assert.AreEqual(channelName.ToLower(),
                            new HEDGlobalHomePage().
                            GetStudChannelDetails(pageTitle, channelName)));
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HomePage", "DisplayedOfChannelInHomePage",
                base.IsTakeScreenShotDuringEntryExit);
        }



        /// <summary>
        /// Validate the display of options dispalyed in the specified channel
        /// </summary>
        /// <param name="buttonName">This is the button name.</param>
        /// <param name="channelName">This is the channel name.</param>
        /// <param name="pageName">This is the page name.</param>
        [Then(@"I should be displayed with ""(.*)"" icon in ""(.*)"" channel of ""(.*)"" page")]
        [Then(@"I should be displayed with ""(.*)"" icon in ""(.*)"" channel")]
        [Then(@"I should be displayed with ""(.*)"" button on ""(.*)"" page as ""(.*)"" user")]
        [Then(@"I should be displayed with ""(.*)"" button in ""(.*)"" channel as ""(.*)"" user")]
        public void DisplayedOfOptionsInChannels(string buttonName, string channelName, string pageName)
        {
            Logger.LogMethodEntry("HomePage", "DisplayedOfOptionsInChannels",
                base.IsTakeScreenShotDuringEntryExit);
            try
            {
                switch (pageName)
                {
                    case "Today's View":
                        switch (channelName)
                        {
                            case "Notifications":
                                Logger.LogAssertion("DisplayedOfOptionInHeader",
                                    ScenarioContext.Current.ScenarioInfo.
                                   Title, () => Assert.AreEqual(buttonName.ToLower(),
                                       new TodaysViewUxPage().
                                       GetNotificationsChannelIconsTodaysView(buttonName, pageName)));
                                break;

                            case "Calendar":
                                Logger.LogAssertion("DisplayedOfOptionInHeader",
                                    ScenarioContext.Current.ScenarioInfo.
                                   Title, () => Assert.AreEqual(buttonName.ToLower(),
                                       new TodaysViewUxPage().
                                       GetCalendarChannelIconsTodaysView(buttonName, pageName)));
                                break;

                            case "Announcements":
                                Logger.LogAssertion("DisplayedOfOptionInHeader",
                                    ScenarioContext.Current.ScenarioInfo.
                                   Title, () => Assert.AreEqual(buttonName.ToLower(),
                                       new TodaysViewUxPage().
                                       GetAnnouncementsChannelIconsTodaysView(buttonName, pageName)));
                                break;
                        }
                        break;

                    case "Global Home":
                        switch (channelName)
                        {
                            case "My Courses and Testbanks":
                                Logger.LogAssertion("DisplayedOfOptionInHeader",
                                    ScenarioContext.Current.ScenarioInfo.
                                   Title, () => Assert.AreEqual(buttonName.ToLower(),
                                       new HEDGlobalHomePage().
                                       GetMyCoursesTestbanksButtonDetails(buttonName)));
                                break;

                            case "Announcements":
                                Logger.LogAssertion("DisplayedOfOptionInHeader",
                                    ScenarioContext.Current.ScenarioInfo.
                                   Title, () => Assert.AreEqual(buttonName.ToLower(),
                                       new HEDGlobalHomePage().
                                       GetAnnouncementsButtonDetails(buttonName)));
                                break;
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ExceptionHandler.HandleException(e);
            }
            Logger.LogMethodExit("HomePage", "DisplayedOfOptionsInChannels",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Click on the buttons in Today's view page channel
        /// </summary>
        /// <param name="buttonName">This is the button name.</param>
        /// <param name="channelName">This is the channel name.</param>
        [When(@"I click on ""(.*)"" button in ""(.*)"" channel as ""(.*)"" user")]
        public void ClickOnButtonInChannel(string buttonName, string channelName, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("HomePage", "ClickOnButtonInChannel", base.IsTakeScreenShotDuringEntryExit);
            switch (channelName)
            {
                case "My Courses and Testbanks":
                    new HEDGlobalHomePage().ClickOptionsInMyCoursesTestbanksChannel(buttonName, userType);
                    break;

                case "Announcements ":
                    new HEDGlobalHomePage().ClickOptionsInAnnouncementsChannel(buttonName);
                    break;
            }
            Logger.LogMethodExit("HomePage", "ClickOnButtonInChannel", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Enter course and click submit for enrollment
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        [When(@"I enter ""(.*)"" ID and click submit")]
        public void EnterCourseIDAndClickSubmit(Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HomePage", "EnterCourseIDAndClickSubmit", base.IsTakeScreenShotDuringEntryExit);
            //Enter course ID to enroll the student
            new HEDGlobalHomePage().EnterCourseID(courseType);
            Logger.LogMethodExit("HomePage", "EnterCourseIDAndClickSubmit", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Enter ISBN and click next to create course
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        [When(@"I click on next button with ""(.*)"" course ISBN as search criteria")]
        public void EnterCourseISBNAndClickNext(Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HomePage", "EnterCourseIDAndClickSubmit", base.IsTakeScreenShotDuringEntryExit);
            new HEDGlobalHomePage().EnterCourseIsbn(courseType);
            Logger.LogMethodExit("HomePage", "EnterCourseIDAndClickSubmit", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Display of step guide and step name
        /// </summary>
        /// <param name="stepCount">This is step count available in "Enroll In Course" lightbox.</param>
        /// <param name="stepName">This is step name available in "Enroll In Course" lightbox.</param>
        /// <param name="popUpName">This is popup name available in "Enroll In Course" lightbox.</param>
        [Then(@"I should be displayed step ""(.*)"" with ""(.*)"" in ""(.*)"" popup as ""(.*)"" user")]
        public void DisplayedOfStepGuide(int stepNumber, string stepName, string popUpName, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("HomePage", "DisplayedOfStepGuide", base.IsTakeScreenShotDuringEntryExit);
            Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel", ScenarioContext.Current
            .ScenarioInfo.Title, () => Assert.IsTrue(new
            HEDGlobalHomePage().GetCourseOptions(stepNumber, stepName, popUpName, userType)));
            Logger.LogMethodExit("HomePage", "DisplayedOfStepGuide", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display of enrollment success message
        /// </summary>
        /// <param name="stepCount">This is step count available in "Enroll In Course" lightbox.</param>
        /// <param name="stepName">This is step name available in "Enroll In Course" lightbox.</param>
        /// <param name="popUpName">This is popup name available in "Enroll In Course" lightbox.</param>
        [Then(@"I should be displayed with message ""(.*)""")]
        public void DisplayedOfMessage(string expectedSuccessMessage)
        {
            Logger.LogMethodEntry("HomePage", "DisplayedOfMessage", base.IsTakeScreenShotDuringEntryExit);
            //Compare the course enrollment success message from the application
            Logger.LogAssertion("DisplayedOfOptionInHeader", ScenarioContext.Current.ScenarioInfo.
               Title, () => Assert.AreEqual(expectedSuccessMessage, new HEDGlobalHomePage().getSuccessMessage()));
            Logger.LogMethodExit("HomePage", "DisplayedOfMessage", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Display of step guide and step name
        /// </summary>
        /// <param name="courseType">This is course type.</param>
        [Then(@"I should be displayed with the course name ""(.*)""")]
        public void DisplayCourseName(Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HomePage", "DisplayedOfMessage", base.IsTakeScreenShotDuringEntryExit);
            Course course = Course.Get(courseType);
            //Compare the step number with the app step number
            Logger.LogAssertion("DisplayedOfOptionInHeader", ScenarioContext.Current.ScenarioInfo.
               Title, () => Assert.AreEqual(course.Name.ToString(), new HEDGlobalHomePage().getCourseName()));
            Logger.LogMethodExit("HomePage", "DisplayedOfMessage", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Click on button in Enroll in a Courselightbox
        /// </summary>
        /// <param name="buttonName">This is button name.</param>
        [When(@"I click ""(.*)"" button")]
        public void ClickButton(string buttonName)
        {
            Logger.LogMethodEntry("HomePage", "ClickButton", base.IsTakeScreenShotDuringEntryExit);
            new HEDGlobalHomePage().ClickConfirmButtoninEnrollACourse(buttonName);
            Logger.LogMethodExit("HomePage", "ClickButton", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Verify the display of enrolled course in "My Courses and Testbanks" channel
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        /// <param name="userType">This is user type enum.</param>
        /// <param name="frameName">This is frame name.</param>
        [Then(@"I should be displayed with ""(.*)"" course as ""(.*)"" in ""(.*)"" channel")]
        [Then(@"I should be displayed with ""(.*)"" channel  as ""(.*)"" user")]
        public void DisplayedOfEnrolledCourseInChannel(Course.CourseTypeEnum courseType,
            User.UserTypeEnum userType, string frameName)
        {
            Logger.LogMethodEntry("HomePage", "DisplayedOfEnrolledCourseInChannel",
                base.IsTakeScreenShotDuringEntryExit);
            switch (userType)
            {
                case User.UserTypeEnum.CsSmsInstructor:
                    Logger.LogAssertion("DisplayedOfEnrolledCourseInChannel", ScenarioContext.Current
                      .ScenarioInfo.Title, () => Assert.IsTrue(new
                      HEDGlobalHomePage().GetEnrolledCourseDetailsInChannel(courseType, frameName)));
                    break;

                case User.UserTypeEnum.CsSmsStudent:
                    Logger.LogAssertion("DisplayedOfEnrolledCourseInChannel", ScenarioContext.Current
                      .ScenarioInfo.Title, () => Assert.IsTrue(new
                      HEDGlobalHomePage().GetEnrolledCourseDetailsInChannel(courseType, frameName)));
                    break;
            }
            Logger.LogMethodExit("HomePage", "DisplayedOfEnrolledCourseInChannel",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// This methord is to click on "Open" button of the course.
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        [When(@"I click on Open button of ""(.*)"" as ""(.*)"" user")]
        public void ClickOnOpenButtonOfCourse(Course.CourseTypeEnum courseType, User.UserTypeEnum userTypeEnum)
        {
            Logger.LogMethodEntry("HomePage", "ClickOnOpenButtonOfCourse", base.IsTakeScreenShotDuringEntryExit);
            new HEDGlobalHomePage().ClickOpenButtonOfCourse(courseType, userTypeEnum);
            Logger.LogMethodExit("HomePage", "ClickOnOpenButtonOfCourse", base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to create course based on ISBN.
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        [When(@"I click on ""(.*)"" button of ""(.*)"" course")]
        public void SelectCourseToCreateIcCourse(string btnName, Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("HomePage", "SelectCourseToCreateIcCourse", base.IsTakeScreenShotDuringEntryExit);
            //Select course based on course ISBN
            new HEDGlobalHomePage().CreateICCourseByISBN(btnName, courseType);
            Logger.LogMethodExit("HomePage", "SelectCourseToCreateIcCourse", base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Verify the display of enrolled course in "My Courses and Testbanks" channel
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        /// <param name="userType">This is user type enum.</param>
        /// <param name="frameName">This is frame name.</param>
        [Then(@"I should be displayed with ""(.*)"" Instructor course as ""(.*)"" in ""(.*)"" frame")]
        [Then(@"I should be displayed with ""(.*)"" MyTest course as ""(.*)"" in ""(.*)"" frame")]
        public void DisplayedOfCreatedCourseInChannel(Course.CourseTypeEnum courseType,
            User.UserTypeEnum userType, string frameName)
        {
            Logger.LogMethodEntry("HomePage", "DisplayedOfEnrolledCourseInChannel",
                base.IsTakeScreenShotDuringEntryExit);
            //Get course details from my testbank
            new HEDGlobalHomePage().GetCreatedCourseDetailsInChannel(courseType, frameName);
            Logger.LogMethodExit("HomePage", "DisplayedOfEnrolledCourseInChannel",
                base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// Select Option In View By Dropdown.
        /// </summary>
        /// <param name="dropdownOption">This is Dropdown option.</param>
        [When(@"I select ""(.*)"" option in 'View By' dropdown")]
        public void SelectOptionInViewByDropdown(string dropdownOption)
        {
            //Select Option In View By Dropdown
            Logger.LogMethodEntry("AssignmentCalendar", "SelectOptionInViewByDropdown",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Option In 'View By' Dropdown
            new CalendarDefaultUXPage().SelectViewByDropdownOption(dropdownOption);
            Logger.LogMethodExit("AssignmentCalendar", "SelectOptionInViewByDropdown",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to select the discipline.
        /// </summary>
        /// /// <param name="btnName">This is button name.</param>
        /// <param name="courseType">This is course type enum.</param>
        [When(@"I select ""(.*)"" option in 'Browse by Discipline' dropdown")]
        public void SelectDiscipline(string dropdownOption)
        {
            //Select Option In View By Dropdown
            Logger.LogMethodEntry("AssignmentCalendar", "SelectDiscipline",
               base.IsTakeScreenShotDuringEntryExit);
            //Select Option In 'View By' Dropdown
            new HEDGlobalHomePage().SelectDisciplineByDropdownOption(dropdownOption);
            Logger.LogMethodExit("AssignmentCalendar", "SelectDiscipline",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to create course based on discipline.
        /// </summary>
        /// /// <param name="btnName">This is button name.</param>
        /// <param name="courseType">This is course type enum.</param>
        [When(@"I click on ""(.*)"" button of ""(.*)"" using course descipline")]
        public void SelectCourseToCreateIcCourseByDiscipline(string btnName, Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("AssignmentCalendar", "SelectCourseToCreateIcCourseByDiscipline",
               base.IsTakeScreenShotDuringEntryExit);
            //Create IC course based on discipline

            new HEDGlobalHomePage().CreateCourseAndCourseByDiscipline(btnName, courseType);
            Logger.LogMethodExit("AssignmentCalendar", "SelectCourseToCreateIcCourseByDiscipline",
            base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// This methord is to access the c-menu option of course
        /// </summary>
        /// <param name="cmenuOption">This is cmenu option name.</param>
        /// <param name="courseType">This is course type enum.</param>
        /// <param name="userType">This is user type enum.</param>
        [When(@"I select cmenu ""(.*)"" option of Instructor course ""(.*)"" for ""(.*)""")]
        public void OpenCmenuOption(string cmenuOption, Course.CourseTypeEnum courseType, User.UserTypeEnum userType)
        {

            Logger.LogMethodEntry("GlobalHomePage", "OpenCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
            //Open the cmenu option of the course on home page
            new HEDGlobalHomePage().CmenuOptionForCourse(cmenuOption, courseType, userType);

            Logger.LogMethodExit("GlobalHomePage", "OpenCmenuOption",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to update the course name
        /// </summary>
        /// /// <param name="btnName">This is button name.</param>
        /// <param name="courseType">This is course type enum.</param>
        [When(@"I click on ""(.*)"" button for course ""(.*)"" created")]
        public void UpdateTheCourseName(string btnName, Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("GlobalHomePage", "UpdateTheCourseName",
               base.IsTakeScreenShotDuringEntryExit);
            //Update the course name on home page
            new HEDGlobalHomePage().UpdateCourseInfo(btnName, courseType);

            Logger.LogMethodExit("GlobalHomePage", "UpdateTheCourseName",
               base.IsTakeScreenShotDuringEntryExit);
        }


        /// <summary>
        /// This methord is to check the update course information
        /// </summary>
        /// <param name="courseType">This is course type enum.</param>
        [Then(@"I should  see the updated course ""(.*)"" name on my test bank")]
        public void UpdatedCourseNameOnHomePage(Course.CourseTypeEnum courseType)
        {
            Logger.LogMethodEntry("GlobalHomePage", "UpdatedCourseNameOnHomePage",
               base.IsTakeScreenShotDuringEntryExit);
            //Validate the course information updated
            new HEDGlobalHomePage().DisplayOfUpdateCourseName(courseType);

            Logger.LogMethodExit("GlobalHomePage", "UpdatedCourseNameOnHomePage",
               base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This methord is to create course based on discipline.
        /// </summary>
        /// <param name="courseStatus">This is course status.</param>
        /// <param name="courseType">This is course type enum.</param>
        /// <param name="userType">This is user type enum.</param>
        [Then(@"I should see the ""(.*)"" status updated for the ""(.*)"" course as ""(.*)""")]
        public void StatusOfCourse(string courseStatus, Course.CourseTypeEnum courseType, User.UserTypeEnum userType)
        {
            Logger.LogMethodEntry("GlobalHomePage", "StatusOfCourse",
               base.IsTakeScreenShotDuringEntryExit);
            //Validate the course updated status 
            Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel", ScenarioContext.Current
            .ScenarioInfo.Title, () => Assert.IsTrue(new
            HEDGlobalHomePage().CourseStatusOnHomePage(courseStatus, courseType)));

            Logger.LogMethodExit("GlobalHomePage", "StatusOfCourse",
               base.IsTakeScreenShotDuringEntryExit);
        }


    }
}
