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
            Logger.LogMethodEntry("HomePage", "DisplayedOfChannelInHomePage",base.IsTakeScreenShotDuringEntryExit);
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
            public void DisplayedOfOptionsInChannels(string buttonName, string channelName, string pageName)
         {
             Logger.LogMethodEntry("HomePage","DisplayedOfOptionsInChannels",
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
         [When(@"I click on ""(.*)"" button in ""(.*)"" channel")]
         public void ClickOnButtonInChannel(string buttonName, string channelName)
         {
             Logger.LogMethodEntry("HomePage", "ClickOnButtonInChannel", base.IsTakeScreenShotDuringEntryExit);
                switch(channelName)
                {
                    case  "My Courses and Testbanks":
                        new HEDGlobalHomePage().ClickOptionsInMyCoursesTestbanksChannel(buttonName);
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
         [When(@"I enter ""(.*)"" and click submit")]
         public void EnterCourseIDAndClickSubmit(Course.CourseTypeEnum courseType)
         {
             Logger.LogMethodEntry("HomePage","EnterCourseIDAndClickSubmit",base.IsTakeScreenShotDuringEntryExit);
             new HEDGlobalHomePage().EnterCourseID(courseType);
             Logger.LogMethodExit("HomePage", "EnterCourseIDAndClickSubmit", base.IsTakeScreenShotDuringEntryExit);
         }

         [Then(@"I should be displayed with step ""(.*)"" and ""(.*)""")]
         public void DisplayedOfStepGuide(int stepNumber, string stepName)
         {
             Logger.LogMethodEntry("HomePage", "DisplayedOfStepGuide", base.IsTakeScreenShotDuringEntryExit);
             Logger.LogAssertion("ValidateStudentNameInPastDueSubmittedChannel", ScenarioContext.Current
             .ScenarioInfo.Title, () => Assert.IsTrue(new
             HEDGlobalHomePage().GetEnrollInCourseOptions(stepNumber, stepName)));
             Logger.LogMethodExit("HomePage", "DisplayedOfStepGuide", base.IsTakeScreenShotDuringEntryExit);
         }

         [Then(@"I should be displayed with message ""(.*)""")]
         public void DisplayedOfMessage(string expectedSuccessMessage)
         {
             Logger.LogMethodEntry("HomePage", "DisplayedOfMessage", base.IsTakeScreenShotDuringEntryExit);
             Logger.LogAssertion("DisplayedOfOptionInHeader", ScenarioContext.Current.ScenarioInfo.
                Title, () => Assert.AreEqual(expectedSuccessMessage, new HEDGlobalHomePage().getSuccessMessage()));
             Logger.LogMethodExit("HomePage", "DisplayedOfMessage", base.IsTakeScreenShotDuringEntryExit);
         }

        

            [Then(@"I should be displayed with the course name ""(.*)""")]
            public void DisplayCourseName(Course.CourseTypeEnum courseType)
            {
             Logger.LogMethodEntry("HomePage", "DisplayedOfMessage", base.IsTakeScreenShotDuringEntryExit);
             Course course = Course.Get(courseType);
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
                        HEDGlobalHomePage().GetEnrolledCourseDetailsInChanne(courseType, frameName)));
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
            public void ClickOnOpenButtonOfCourse(Course.CourseTypeEnum courseType,User.UserTypeEnum userTypeEnum)
            {
                Logger.LogMethodEntry("HomePage", "ClickOnOpenButtonOfCourse", base.IsTakeScreenShotDuringEntryExit);
                new HEDGlobalHomePage().ClickOpenButtonOfCourse(courseType, userTypeEnum);
                Logger.LogMethodExit("HomePage", "ClickOnOpenButtonOfCourse", base.IsTakeScreenShotDuringEntryExit);
            }

    }
}
