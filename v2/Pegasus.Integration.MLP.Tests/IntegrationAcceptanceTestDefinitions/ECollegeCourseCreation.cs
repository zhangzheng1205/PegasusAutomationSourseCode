﻿using System;
using Pearson.Pegasus.TestAutomation.Frameworks;
using Pearson.Pegasus.TestAutomation.Frameworks.DataTransferObjects;
using Pegasus.Automation.DataTransferObjects;
using Pegasus.Integration.MLP.Tests.CommonIntegrationAcceptanceTestDefinitions;
using Pegasus.Pages.UI_Pages;
using TechTalk.SpecFlow;
using Pegasus.Integration.Hed.MLP.Tests.CommonIntegrationAcceptanceTestDefinitions;

namespace Pegasus.Integration.MLP.Tests.
    IntegrationAcceptanceTestDefinitions
{
    /// <summary>
    /// This class handle the Class creation 
    /// use caese on eCollege Protal.
    /// </summary>
    [Binding]
    public class ECollegeCourseCreation : PegasusBaseTestFixture
    {
        /// <summary>
        /// The static instance of the logger for the class.
        /// </summary>
        private static Logger Logger =
            Logger.GetInstance(typeof(ECollegeCourseCreation));

        /// <summary>
        /// Create ECollege Course.
        /// </summary>
        /// <param name="courseTypeEnum">This is course type enum.</param>
        [When(@"I create a new ""(.*)"" Course")]
        public void CreateECollegeCourse(Course.CourseTypeEnum courseTypeEnum)
        {
            //Create Course
            Logger.LogMethodEntry("ECollegeCourseCreation", "CreateECollegeCourse",
              base.IsTakeScreenShotDuringEntryExit);
            //Create a New eCollege Course 
            new SingleCrsCreationBottomPage().CreateSingleCourseRequest
                (courseTypeEnum);
            Logger.LogMethodExit("ECollegeCourseCreation", "CreateECollegeCourse",
                base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// This Mathod will validate course 
        /// creation confimation message. 
        /// </summary>
        /// <param name="successMessage"> Course creation success message</param>
        [Then(@"I should see the ""(.*)"" message")]
        public void ECollegeCourseCreationMessage(String successMessage)
        {
            //Verify Success Message
            Logger.LogMethodEntry("ECollegeCourseCreation", "ECollegeCourseCreationMessage",
               base.IsTakeScreenShotDuringEntryExit);
            //Verify Correct Message Present on the Page
            IsMessageExists(successMessage, CommonStepsResource.
                CommanSteps_ECollegeCourseCreation_Confirmation_Text);
            Logger.LogMethodExit("ECollegeCourseCreation", "ECollegeCourseCreationMessage",
              base.IsTakeScreenShotDuringEntryExit);
        }

        /// <summary>
        /// Initialize Pegasus test before test execution starts .
        /// </summary>
        [BeforeTestRun]
        public static void Setup()
        {

        }

        /// <summary>
        /// Deinitialize Pegasus test after the execution of test.
        /// </summary>
        [AfterTestRun]
        public static void TearDown()
        {

        }

    }
}
